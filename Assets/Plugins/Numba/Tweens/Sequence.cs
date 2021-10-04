using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
using Coroutines;
using Coroutines.Extensions;
using Object = UnityEngine.Object;
using Coroutine = Coroutines.Coroutine;
using System.Collections.ObjectModel;
using Tweens.Formulas;

namespace Tweens
{
    public sealed class Sequence : Playable<Sequence>
    {
        public class Element
        {
            public float StartTime { get; internal set; }

            public IPlayable<Playable> Playable { get; internal set; }

            public float EndTime => StartTime + Playable.Duration;

            public int Index { get; internal set; }

            internal Element(float time, IPlayable<Playable> playable)
            {
                StartTime = time;
                Playable = playable;
            }
        }

        public override Type Type => Type.Sequence;

        private readonly List<Element> _elements = new List<Element>();

        public ReadOnlyCollection<Element> Elements => _elements.AsReadOnly();

        private int _nextIndex;

        #region Constructors
        public Sequence(FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this((string)null, formula, loopsCount, loopType, direction) { }

        public Sequence(string name, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(null, name, formula, loopsCount, loopType, direction) { }

        public Sequence(GameObject owner, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : this(owner, null, formula, loopsCount, loopType, direction) { }

        public Sequence(GameObject owner, string name, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward) : base(owner, name, 0f, formula, loopsCount, loopType, direction) { }
        #endregion

        private int GetNextIndex() => _nextIndex++;

        public bool CheckCyclicReference(Sequence other)
        {
            foreach (var element in other._elements)
            {
                if (element.Playable.Type != Type.Sequence)
                    continue;

                if (element.Playable == this)
                    return true;

                if (CheckCyclicReference((Sequence)element.Playable))
                    return true;
            }

            return false;
        }

        #region Adding
        public Element Prepend(IPlayable<Playable> playable)
        {
            var leftmost = GetLeftmostElement();

            if (leftmost == null)
                return Insert(0f, playable);

            var startTime = leftmost.StartTime - playable.Duration;

            if (startTime < 0f)
            {
                for (int i = 0; i < _elements.Count; i++)
                    _elements[i].StartTime -= startTime;

                return Insert(0f, playable);
            }
            else
                return Insert(startTime, playable);
        }

        public Element Append(IPlayable<Playable> playable) => Insert(LoopDuration, playable);

        public Element Insert(float time, IPlayable<Playable> playable)
        {
            if (playable == this)
                throw new ArgumentException($"{Type} \"{Name}\": Sequence can't contain itself");

            if (playable is Sequence sequence && CheckCyclicReference(sequence))
                throw new ArgumentException($"{Type} \"{Name}\": Cyclic references in sequences are not allowed (sequence \"{sequence.Name}\" already contains sequence \"{Name}\")");

            var element = new Element(Mathf.Max(time, 0f), playable) { Index = GetNextIndex() };

            _elements.Add(element);

            if (element.EndTime > LoopDuration)
                LoopDuration = element.EndTime;

            return element;
        }
        #endregion

        #region Elements getters
        public Element GetLeftmostElement()
        {
            if (_elements.Count == 0)
                return null;

            Element element = _elements[0];

            for (int i = 1; i < _elements.Count; i++)
            {
                if (_elements[i].StartTime <= element.StartTime)
                    element = _elements[i];
            }

            return element;
        }

        public Element GetRightmostElement()
        {
            if (_elements.Count == 0)
                return null;

            Element element = _elements[0];

            for (int i = 1; i < _elements.Count; i++)
            {
                if (_elements[i].EndTime >= element.EndTime)
                    element = _elements[i];
            }

            return element;
        }

        public Element GetElement(IPlayable<Playable> playable)
        {
            foreach (var element in _elements)
            {
                if (element.Playable == playable)
                    return element;
            }

            return null;
        }

        public List<Element> GetElements(IPlayable<Playable> playable)
        {
            var elements = new List<Element>();

            foreach (var element in _elements)
            {
                if (element.Playable == playable)
                    elements.Add(element);
            }

            return elements;
        }

        public Element GetElement(string name)
        {
            foreach (var element in _elements)
            {
                if (element.Playable.Name == name)
                    return element;
            }

            return null;
        }

        public List<Element> GetElements(string name)
        {
            var elements = new List<Element>();

            foreach (var element in _elements)
            {
                if (element.Playable.Name == name)
                    elements.Add(element);
            }

            return elements;
        }
        #endregion

        #region Remove
        public int Remove(IPlayable<Playable> playable)
        {
            var elements = GetElements(playable);

            if (elements == null)
                throw new ArgumentException($"{Type} \"{Name}\": Playable \"{playable.Name}\" can not be removed, because it was not added to sequence");

            for (int i = 0; i < elements.Count; i++)
                _elements.Remove(elements[i]);

            LoopDuration = GetRightmostElement()?.EndTime ?? 0f;

            return elements.Count;
        }

        public void Remove(IEnumerable<IPlayable<Playable>> playables)
        {
            for (int i = 0; i < playables.Count(); i++)
                Remove(playables.ElementAt(i));
        }

        public void Remove(params IPlayable<Playable>[] playables) => Remove((IEnumerable<IPlayable<Playable>>)playables);

        public int Remove(string name)
        {
            var elements = GetElements(Name);

            if (elements == null)
                throw new ArgumentException($"{Type} \"{Name}\": Playable with \"{name}\" can not be removed, because it was not added to sequence");

            for (int i = 0; i < elements.Count; i++)
                _elements.Remove(elements[i]);

            LoopDuration = GetRightmostElement()?.EndTime ?? 0f;

            return elements.Count;
        }

        public void Remove(IEnumerable<string> names)
        {
            for (int i = 0; i < names.Count(); i++)
                Remove(names.ElementAt(i));
        }

        public void Remove(params string[] names) => Remove((IEnumerable<string>)names);

        public void Remove(Element element)
        {
            if (!_elements.Remove(element))
                throw new ArgumentException($"{Type} \"{Name}\": The element with hash code \"{element.GetHashCode()}\" passed for removing does not exist in the sequence");

            LoopDuration = GetRightmostElement()?.EndTime ?? 0f;
        }

        public void Remove(IEnumerable<Element> elements)
        {
            for (int i = 0; i < elements.Count(); i++)
                Remove(elements.ElementAt(i));
        }

        public void Remove(params Element[] elements) => Remove((IEnumerable<Element>)elements);

        public int RemoveAll()
        {
            var removed = _elements.Count;
            _elements.Clear();

            LoopDuration = 0f;
            return removed;
        }

        public int RemoveAll(Func<Element, bool> predicate)
        {
            var removed = 0;

            for (int i = _elements.Count - 1; i >= 0; i--)
            {
                if (predicate(_elements[i]))
                {
                    _elements.RemoveAt(i);
                    removed++;
                }
            }

            LoopDuration = 0f;
            return removed;
        }
        #endregion

        protected override void BeforeLoopStartingPerform()
        {

        }

        protected override Playable SkipTimeTo(float time)
        {
            // if loop duration is zero, then played time will also always be zero,
            // so there is no point in assigning to it.
            if (LoopDuration == 0f)
                return this;

            // TODO: Call SkipTo on all elements in [PlayedTime..time] interval.
            

            return base.SkipTimeTo(time);
        }

        protected override void PerformCompletely(int loop, float loopedNormalizedTime, Direction direction)
        {
            // TODO: Call RewindTo on all elements with respect to direction.

            if (LoopType == LoopType.Reset)
            {

            }
            else if (LoopType == LoopType.Continue)
            {

            }
            else if (LoopType == LoopType.Mirror)
            {

            }
        }

        protected override void Perform(int loop, float loopedTime, Direction direction)
        {
            // TODO: Call RewindTo on all elements in [PlayedTime..time] interval with respect to direction.

            if (LoopType == LoopType.Reset)
            {

            }
            else if (LoopType == LoopType.Continue)
            {

            }
            else if (LoopType == LoopType.Mirror)
            {

            }
        }
    }
}