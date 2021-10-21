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

            public Playable Playable { get; internal set; }

            public float EndTime => StartTime + Playable.Duration;

            public int Order { get; internal set; }

            internal Element(float time, Playable playable, int order)
            {
                StartTime = time;
                Playable = playable;
                Order = order;
            }
        }

        #region Phases
        private abstract class Phase
        {
            protected Element _element;

            protected Phase(Element element) => _element = element;

            abstract public void Call(Direction direction);
        }

        #region Zedo duration
        private class PhaseStartZeroed : Phase
        {
            public PhaseStartZeroed(Element element) : base(element) { }

            public override void Call(Direction direction) => _element.Playable.HandlePhaseStartZeroed(direction);
        }

        private class PhaseFirstLoopStartZeroed : Phase
        {
            public PhaseFirstLoopStartZeroed(Element element) : base(element) { }

            public override void Call(Direction direction) => _element.Playable.HandlePhaseFirstLoopStartZeroed(direction);
        }

        private class PhaseLoopCompleteZeroed : Phase
        {
            private int _loop;

            public PhaseLoopCompleteZeroed(Element element, int loop) : base(element) => _loop = loop;

            public override void Call(Direction direction) => _element.Playable.HandlePhaseLoopCompleteZeroed(_loop, direction);
        }

        private class PhaseLoopStartZeroed : Phase
        {
            private int _loop;

            public PhaseLoopStartZeroed(Element element, int loop) : base(element) => _loop = loop;

            public override void Call(Direction direction) => _element.Playable.HandlePhaseLoopStartZeroed(_loop, direction);
        }

        private class PhaseCompleteZeroed : Phase
        {
            public PhaseCompleteZeroed(Element element) : base(element) { }

            public override void Call(Direction direction) => _element.Playable.HandlePhaseCompleteZeroed(direction);
        }
        #endregion

        #region Non zero duration
        private class PhaseStart : Phase
        {
            public PhaseStart(Element element) : base(element) { }

            public override void Call(Direction direction) => _element.Playable.HandlePhaseStart(direction);
        }

        private class PhaseFirstLoopStart : Phase
        {
            public PhaseFirstLoopStart(Element element) : base(element) { }

            public override void Call(Direction direction) => _element.Playable.HandlePhaseFirstLoopStart(direction);
        }

        private class PhaseLoopComplete : Phase
        {
            private int _loop;

            public PhaseLoopComplete(Element element, int loop) : base(element) => _loop = loop;

            public override void Call(Direction direction) => _element.Playable.HandlePhaseLoopComplete(_loop, direction);
        }

        private class PhaseLoopStart : Phase
        {
            private int _loop;

            public PhaseLoopStart(Element element, int loop) : base(element) => _loop = loop;

            public override void Call(Direction direction) => _element.Playable.HandlePhaseLoopStart(_loop, direction);
        }

        private class PhaseLoopUpdate : Phase
        {
            private float _endTime;

            private int _loop;

            private float _loopedTime;

            public PhaseLoopUpdate(Element element, float endTime, int loop, float loopedTime) : base(element)
            {
                _endTime = endTime;
                _loop = loop;
                _loopedTime = loopedTime;
            }

            public override void Call(Direction direction) => _element.Playable.HandlePhaseLoopUpdate(_endTime, _loop, _loopedTime, direction);
        }

        private class PhaseComplete : Phase
        {
            public PhaseComplete(Element element) : base(element) { }

            public override void Call(Direction direction) => _element.Playable.HandlePhaseComplete(direction);
        }
        #endregion
        #endregion

        private class Chronoline
        {
            internal class Chain
            {
                internal int PrePostPoint { get; set; }

                private readonly List<Phase> _events = new List<Phase>();

                internal int EventsCount => _events.Count;

                internal void AppendEvent(Phase phaseEvent) => _events.Add(phaseEvent);

                internal void InsertEvent(int index, Phase phaseEvent) => _events.Insert(index, phaseEvent);

                internal void CallPreEvents(Direction direction)
                {
                    for (int i = 0; i < PrePostPoint; i++)
                        _events[i].Call(direction);
                }

                internal void CallPostEvents(Direction direction)
                {
                    for (int i = PrePostPoint; i < _events.Count; i++)
                        _events[i].Call(direction);
                }

                internal void CallAllEvents(Direction direction)
                {
                    for (int i = 0; i < _events.Count; i++)
                        _events[i].Call(direction);
                }
            }

            internal class ChainsData
            {
                internal Chain Forward { get; set; } = new Chain();

                internal Chain Backward { get; set; } = new Chain();

                internal void AppendEvent(Phase phaseEvent)
                {
                    Forward.AppendEvent(phaseEvent);
                    Backward.AppendEvent(phaseEvent);
                }

                internal void InsertEvent(int index, Phase phaseEvent)
                {
                    Forward.InsertEvent(index, phaseEvent);
                    Backward.InsertEvent(index, phaseEvent);
                }
            }

            internal float Time { get; set; }

            internal ChainsData Chains { get; set; } = new ChainsData();

            internal Chronoline(float time) => Time = time;
        }

        // Used for detecting intersection type between chronoline and element.
        private enum IntersectionType
        {
            Start,
            Update,
            Loop,
            Complete
        }

        public override Type Type => Type.Sequence;

        public LoopResetBehaviour LoopResetBehaviour { get; set; }

        private readonly List<Element> _elements = new List<Element>();

        public ReadOnlyCollection<Element> Elements => _elements.AsReadOnly();

        private int _nextOrder;

        private readonly List<Element> _elementsBuffer = new List<Element>();

        private readonly List<Chronoline> _chronolines = new List<Chronoline>();

        // Needed for handling zeroed loops.
        // Used for understanding in which direction zeroed sequence was played.
        private float _lastLoopedNormalizedTime;

        #region Played time calculators (used in injectings methods)
        private static Func<Chronoline, Element, float> _forwardPlayedTimeCalcualtor = (chronoline, element) => chronoline.Time - element.StartTime; 

        private static Func<Chronoline, Element, float> _backwardPlayedTimeCalcualtor = (chronoline, element) => element.EndTime - chronoline.Time; 
        #endregion

        #region Constructors
        public Sequence(FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind) : this((string)null, formula, loopsCount, loopType, direction, loopResetBehaviour) { }

        public Sequence(string name, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind) : this(null, name, formula, loopsCount, loopType, direction, loopResetBehaviour) { }

        public Sequence(GameObject owner, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind) : this(owner, null, formula, loopsCount, loopType, direction, loopResetBehaviour) { }

        public Sequence(GameObject owner, string name, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind) : base(owner, name, 0f, formula, loopsCount, loopType, direction)
        {
            LoopResetBehaviour = loopResetBehaviour;
        }
        #endregion

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

        #region Elements
        #region Add
        public Element Prepend(Playable playable)
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

        public Element Append(Playable playable) => Insert(LoopDuration, playable);

        public Element Insert(float time, Playable playable) => Insert(_nextOrder++, time, playable);

        public Element Insert(int order, float time, Playable playable)
        {
            if (playable == this)
                throw new ArgumentException($"{Type} \"{Name}\": Sequence can't contain itself");

            if (playable is Sequence sequence && CheckCyclicReference(sequence))
                throw new ArgumentException($"{Type} \"{Name}\": Cyclic references in sequences are not allowed (sequence \"{sequence.Name}\" already contains sequence \"{Name}\")");

            order = Mathf.Clamp(order, 0, _elements.Count);

            var element = new Element(Mathf.Max(time, 0f), playable, order);

            _elements.Insert(order, element);

            for (int i = order + 1; i < _elements.Count; i++)
                ++_elements[i].Order;

            if (element.EndTime > LoopDuration)
                LoopDuration = element.EndTime;

            InjectPhaseEventsForElement(element);

            return element;
        }
        #endregion

        #region Get
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
        #endregion

        public Sequence SetLoopResetBehaviour(LoopResetBehaviour loopResetBehaviour)
        {
            LoopResetBehaviour = loopResetBehaviour;
            return this;
        }

        #region Before loop starting
        protected override void BeforeStarting(Direction direction) => BeforeLoopStarting(direction, LoopResetBehaviour);

        private void BeforeLoopStarting(Direction direction, LoopResetBehaviour loopResetBehaviour)
        {
            if (loopResetBehaviour == LoopResetBehaviour.Rewind)
            {
                for (int i = 0; i < _elements.Count; i++)
                {
                    var element = _elements[i];

                    if (element.Playable.Duration == 0f)
                        element.Playable.RewindTo(direction == Direction.Forward ? -1f : 1f, false);
                    else
                        element.Playable.RewindTo(direction == Direction.Forward ? 0f : Duration, false);
                }
            }
            else
            {
                for (int i = 0; i < _elements.Count; i++)
                    _elements[i].Playable.SkipTo(direction == Direction.Forward ? 0f : Duration);
            }
        }
        #endregion

        #region Skip
        protected override Playable SkipTimeTo(float time)
        {
            // if loop duration is zero, then played time will also always be zero,
            // so there is no point in assigning to it.
            if (time == PlayedTime || LoopDuration == 0f)
                return this;

            var (startTime, endTime, direction) = time > PlayedTime ? (PlayedTime, time, Direction.Forward) : (Duration - PlayedTime, Duration - time, Direction.Backward);
            var loopedPlayedTime = LoopTime(PlayedTime);

            var playedLoop = (int)(startTime / LoopDuration);
            var timeLoop = (int)(endTime / LoopDuration);

            // Loop started phase
            if (startTime == playedLoop * LoopDuration)
            {
                BeforeLoopStarting(direction, LoopResetBehaviour.Skip);
                loopedPlayedTime = 0f;
            }

            // Intermediate phase
            for (int i = playedLoop + 1; i <= timeLoop - 1; i++)
            {
                var loopedTime = LoopTime(LoopDuration * i);
                SkipHandler(loopedPlayedTime, loopedTime, direction);

                BeforeLoopStarting(direction, LoopResetBehaviour.Skip);
                loopedPlayedTime = 0f;
            }

            // Loop completed phase.
            if (endTime == timeLoop * LoopDuration)
                SkipHandler(loopedPlayedTime, LoopDuration, direction);
            else // Loop update phases.
            {
                // Last intermediate loop phase. For example, when we start from
                // middle looped position and ended on other middle looped position.
                if (timeLoop - playedLoop > 0)
                {
                    SkipHandler(loopedPlayedTime, LoopDuration, direction);

                    BeforeLoopStarting(direction, LoopResetBehaviour.Skip);
                    loopedPlayedTime = 0f;
                }

                // Update phase.
                var loopedTime = LoopTime(endTime);

                SkipHandler(loopedPlayedTime, loopedTime, direction);
                loopedPlayedTime = loopedTime;
            }

            PlayedTime = Mathf.Clamp(time, 0f, Duration);
            return this;
        }

        private void SkipHandler(float loopedPlayedTime, float loopedTime, Direction direction)
        {
            void FillBufferWithElementsOnInterval(float start, float end, Direction direction)
            {
                // second expression in end of two methods below is for playables with zero duration and which placed at end of loop.
                bool CompareZeroForward(Element element, float start, float end) => (element.StartTime < end && element.EndTime >= start) || (end == LoopDuration && element.StartTime == end);

                bool CompareZeroBackward(Element element, float start, float end) => (element.EndTime > end && element.StartTime <= start) || (end == 0 && element.StartTime == 0);

                bool CompareForward(Element element, float start, float end) => element.StartTime < end && element.EndTime > start;

                bool CompareBackward(Element element, float start, float end) => element.EndTime > end && element.StartTime < start;


                if (direction == Direction.Forward)
                {
                    for (int i = 0; i < _elements.Count; i++)
                    {
                        var element = _elements[i];

                        if (element.Playable.Duration == 0f && CompareZeroForward(element, start, end))
                            _elementsBuffer.Add(element);
                        else if (element.Playable.Duration != 0f && CompareForward(element, start, end))
                            _elementsBuffer.Add(element);
                    }
                }
                else
                {
                    for (int i = 0; i < _elements.Count; i++)
                    {
                        var element = _elements[i];

                        if (element.Playable.Duration == 0f && CompareZeroBackward(element, start, end))
                            _elementsBuffer.Add(element);
                        else if (element.Playable.Duration != 0f && CompareBackward(element, start, end))
                            _elementsBuffer.Add(element);
                    }
                }
            }

            if (direction == Direction.Backward)
                (loopedPlayedTime, loopedTime) = (LoopDuration - loopedPlayedTime, LoopDuration - loopedTime);

            FillBufferWithElementsOnInterval(loopedPlayedTime, loopedTime, direction);

            for (int i = 0; i < _elementsBuffer.Count; i++)
                _elements[i].Playable.SkipTo(loopedTime - _elements[i].StartTime);

            _elementsBuffer.Clear();
        }
        #endregion

        private bool ChronolineExist(float time)
        {
            for (int i = 0; i < _chronolines.Count; i++)
            {
                if (_chronolines[i].Time == time)
                    return true;
            }

            return false;
        }

        private void AddChronoline(Chronoline chronoline)
        {
            var index = 0;
            for (; index < _chronolines.Count; index++)
            {
                if (_chronolines[index].Time < chronoline.Time)
                    continue;
            }

            _chronolines.Insert(index, chronoline);
        }

        private Chronoline GenerateChronoline(float time)
        {
            var chronoline = new Chronoline(time);

            for (int i = 0; i < _elements.Count; i++)
            {
                var element = _elements[i];

                if (chronoline.Time < element.StartTime || chronoline.Time > element.EndTime)
                    continue;

                if (element.Playable.Duration == 0f)
                {
                    // For zero duration playables we call all phases events at once.
                    chronoline.Chains.AppendEvent(new PhaseStartZeroed(element));
                    chronoline.Chains.AppendEvent(new PhaseFirstLoopStartZeroed(element));

                    // Remember this element for handling its loop events later
                    _elementsBuffer.Add(element);
                }
                else
                {
                    // This function receive played time and chain, and than can detect and automatically
                    // add event in desired position in chain events list.
                    void GenerateEvents(float playedTime, Chronoline.Chain chain)
                    {
                        // Start phase.
                        if (playedTime == 0f)
                        {
                            chain.AppendEvent(new PhaseStart(element));
                            chain.AppendEvent(new PhaseFirstLoopStart(element));
                        }
                        else if (playedTime % element.Playable.LoopDuration == 0f && playedTime != element.Playable.Duration) // Intermediate loop phase (end not included).
                        {
                            var loop = (int)(playedTime / element.Playable.LoopDuration);
                            chain.InsertEvent(chain.PrePostPoint++, new PhaseLoopComplete(element, loop - 1));
                            chain.AppendEvent(new PhaseLoopStart(element, loop));
                        }
                        else if (playedTime == element.Playable.Duration) // Complete phase
                        {
                            chain.InsertEvent(chain.PrePostPoint++, new PhaseLoopComplete(element, element.Playable.LoopsCount - 1));
                            chain.InsertEvent(chain.PrePostPoint++, new PhaseComplete(element));
                        }
                        else // Update phase (for elements on which chrono-line hitted not at phase times)
                            chain.InsertEvent(chain.PrePostPoint++, new PhaseLoopUpdate(element, playedTime, (int)(playedTime / element.Playable.LoopDuration), playedTime % element.Playable.LoopDuration));
                    }

                    // Generate forward and backward events.
                    GenerateEvents(chronoline.Time - element.StartTime, chronoline.Chains.Forward);
                    GenerateEvents(element.EndTime - chronoline.Time, chronoline.Chains.Backward);
                }
            }

            if (_elementsBuffer.Count == 0)
                return chronoline;

            // Find max loops count for parallel handling phase events on zero duration elements.
            // On some iteration elements which reached own max loops count will be removed.
            var maxLoopsCount = _elementsBuffer[0].Playable.LoopsCount;
            for (int i = 1; i < _elementsBuffer.Count; i++)
                maxLoopsCount = Math.Max(maxLoopsCount, _elementsBuffer[i].Playable.LoopsCount);

            for (int i = 0; i < maxLoopsCount; i++)
            {
                // It is not matter which chain we will use, forward or backward, both have same events count.
                var insertIndex = chronoline.Chains.Forward.EventsCount;

                for (int j = 0; j < _elementsBuffer.Count; j++)
                {
                    var element = _elementsBuffer[j];

                    // If reach own max loops count, than we need remove this element.
                    if (i == element.Playable.LoopsCount - 1)
                    {
                        // Complete phase.
                        chronoline.Chains.InsertEvent(insertIndex++, new PhaseLoopCompleteZeroed(element, element.Playable.LoopsCount - 1));
                        chronoline.Chains.InsertEvent(insertIndex++, new PhaseCompleteZeroed(element));

                        _elementsBuffer.Remove(element);
                        --j;
                    }
                    else // Intermediate phase.
                    {
                        chronoline.Chains.InsertEvent(insertIndex++, new PhaseLoopCompleteZeroed(element, i));
                        chronoline.Chains.AppendEvent(new PhaseLoopStartZeroed(element, i + 1));
                    }
                }
            }

            return chronoline;
        }

        public Sequence GenerateChronolines()
        {
            _chronolines.Clear();

            for (int i = 0; i < _elements.Count; i++)
            {
                var element = _elements[i];

                if (element.Playable.Duration == 0f)
                {
                    if (ChronolineExist(element.StartTime))
                        continue;

                    AddChronoline(GenerateChronoline(element.StartTime));
                }
                else
                {
                    for (int j = 0; j <= element.Playable.LoopsCount; j++)
                    {
                        var phaseTime = element.StartTime + element.Playable.LoopDuration * j;

                        if (ChronolineExist(phaseTime))
                            continue;

                        AddChronoline(GenerateChronoline(phaseTime));
                    }
                }
            }

            return this;
        }

        private IntersectionType GetIntersectionType(Element element, float playedTime)
        {
            if (playedTime == 0f)
                return IntersectionType.Start;
            else if (playedTime == element.Playable.Duration)
                return IntersectionType.Complete;
            else if (playedTime % element.Playable.LoopDuration == 0f)
                return IntersectionType.Loop;
            else
                return IntersectionType.Update;
        }

        private void InjectPhaseEventsForElement(Element element)
        {
            // Handle old chronolines on element [start -> end] and [end -> start] intervals.
            for (int i = 0; i < _chronolines.Count; i++)
            {
                var chronoline = _chronolines[i];

                if (chronoline.Time < element.StartTime)
                    continue;

                if (chronoline.Time > element.EndTime)
                    break;

                void InjectEvents(float playedTime, Func<Chronoline, Element, float> playedTimeCalculator, Chronoline.Chain chain)
                {
                    bool ElementNotIntersectsOrSelf(Chronoline chronoline, int index, out Element oldElement)
                    {
                        oldElement = _elements[index];

                        if (chronoline.Time < oldElement.StartTime || chronoline.Time > oldElement.EndTime || oldElement == element)
                            return true;

                        return false;
                    }

                    if (element.Playable.Duration == 0f)
                    {
                        var insertIndex = 0;

                        // Cycle for all elements handle first phase loops start events.
                        for (int j = 0; j < _elements.Count; j++)
                        {
                            var oldElement = _elements[j];

                            if (chronoline.Time < oldElement.StartTime || chronoline.Time > oldElement.EndTime)
                                continue;

                            if (oldElement == element)
                            {
                                chain.InsertEvent(insertIndex++, new PhaseStart(element));
                                chain.InsertEvent(insertIndex++, new PhaseFirstLoopStart(element));

                                // Save new element to zeroed buffer for handling it within others zeroed elements.
                                _elementsBuffer.Add(oldElement);

                                continue;
                            }

                            var intersectionType = GetIntersectionType(oldElement, playedTimeCalculator(chronoline, oldElement));

                            if (intersectionType == IntersectionType.Start)
                                insertIndex += 2;
                            if (intersectionType == IntersectionType.Loop)
                                ++insertIndex;

                            // Remember zeroed element for handle it later.
                            if (oldElement.Playable.Duration == 0f)
                                _elementsBuffer.Add(oldElement);
                        }

                        // Cycle for new element loops count (for adding phase loop events to chain).
                        for (int j = 0; j < element.Playable.LoopsCount; j++)
                        {
                            // Used for calculating loop start phase event position for newly added element.
                            var startPhaseShift = 0;

                            // Cycle for zeroed elements (for correcting insert index and placing new element phase loop events).
                            for (int k = 0; k < _elementsBuffer.Count; k++)
                            {
                                var zeroedElement = _elementsBuffer[k];

                                // For current element we need add its phase events to chain.
                                if (zeroedElement == element)
                                {
                                    chain.InsertEvent(insertIndex++, new PhaseLoopComplete(element, j));

                                    if (j == element.Playable.LoopsCount - 1)
                                    {
                                        chain.InsertEvent(insertIndex, new PhaseComplete(element));
                                        goto END;
                                    }

                                    continue;
                                }

                                // If zeroed element not at phase complete event, than need add 1 event (LoopComplete).
                                if (j < zeroedElement.Playable.LoopsCount - 1)
                                {
                                    ++insertIndex;

                                    // We need remember that loop start phase event on element placed before current
                                    // emit before current element's start phase event too.
                                    if (zeroedElement.Order < element.Order)
                                        ++startPhaseShift;
                                }
                                else
                                {
                                    insertIndex += 2;
                                    _elementsBuffer.RemoveAt(k--);
                                }
                            }

                            insertIndex += startPhaseShift;
                            chain.InsertEvent(insertIndex++, new PhaseLoopStart(element, j + 1));

                            var startsEventsLeft = _elementsBuffer.Count - 1 - _elementsBuffer.IndexOf(element);
                            insertIndex += startsEventsLeft;
                        }

                    END:
                        _elementsBuffer.Clear();
                    }
                    else
                    {
                        if (playedTime == 0f) // Start phase.
                        {
                            var insertIndex = 0;

                            // Cycle for elements which placed before current.
                            for (int j = 0; j < element.Order; j++)
                            {
                                if (ElementNotIntersectsOrSelf(chronoline, j, out Element oldElement))
                                    continue;

                                var intersectionType = GetIntersectionType(oldElement, playedTimeCalculator(chronoline, oldElement));

                                if (intersectionType == IntersectionType.Start)
                                    insertIndex += 2;
                                if (intersectionType == IntersectionType.Loop)
                                    ++insertIndex;
                            }

                            chain.InsertEvent(insertIndex++, new PhaseStart(element));
                            chain.InsertEvent(insertIndex, new PhaseFirstLoopStart(element));

                            chain.PrePostPoint += 2;
                        }
                        else
                        {
                            if (playedTime % element.Playable.LoopDuration == 0f && playedTime != element.Playable.Duration) // Intermediate phase.
                            {
                                var preInsertIndex = 0;
                                var postInsertIndex = 0;

                                for (int j = 0; j < element.Order; j++)
                                {
                                    if (ElementNotIntersectsOrSelf(chronoline, j, out Element oldElement))
                                        continue;

                                    if (element.Playable.Duration == 0f)
                                        postInsertIndex += 2;
                                    else
                                    {
                                        var intersectionType = GetIntersectionType(oldElement, playedTimeCalculator(chronoline, oldElement));

                                        if (intersectionType == IntersectionType.Start)
                                            postInsertIndex += 2;
                                        else if (intersectionType == IntersectionType.Update)
                                            ++preInsertIndex;
                                        else if (intersectionType == IntersectionType.Loop)
                                        {
                                            ++postInsertIndex;
                                            ++preInsertIndex;
                                        }
                                        else if (intersectionType == IntersectionType.Complete)
                                            preInsertIndex += 2;
                                    }
                                }

                                var loop = (int)(playedTime / element.Playable.LoopDuration);

                                chain.InsertEvent(preInsertIndex, new PhaseLoopComplete(element, loop - 1));
                                ++chain.PrePostPoint;

                                chain.InsertEvent(chain.PrePostPoint + postInsertIndex, new PhaseLoopStart(element, loop));

                            }
                            else // Update and complete phases.
                            {
                                var insertIndex = 0;

                                // Cycle for elements which placed before current.
                                for (int j = 0; j < element.Order; j++)
                                {
                                    if (ElementNotIntersectsOrSelf(chronoline, j, out Element oldElement))
                                        continue;

                                    var intersectionType = GetIntersectionType(oldElement, playedTimeCalculator(chronoline, oldElement));

                                    if (intersectionType == IntersectionType.Update || intersectionType == IntersectionType.Loop)
                                        ++insertIndex;
                                    else if (intersectionType == IntersectionType.Complete)
                                        insertIndex += 2;
                                }

                                if (playedTime == element.Playable.Duration) // Complete phase
                                {
                                    chain.InsertEvent(insertIndex++, new PhaseLoopComplete(element, element.Playable.LoopsCount - 1));
                                    chain.InsertEvent(insertIndex, new PhaseComplete(element));

                                    chain.PrePostPoint += 2;
                                }
                                else // Update phase
                                {
                                    chain.InsertEvent(insertIndex, new PhaseLoopUpdate(element, playedTime, (int)(playedTime / element.Playable.LoopDuration), playedTime % element.Playable.LoopDuration));
                                    ++chain.PrePostPoint;
                                }
                            }
                        }
                    }
                }

                InjectEvents(chronoline.Time - element.StartTime, _forwardPlayedTimeCalcualtor, chronoline.Chains.Forward);
                InjectEvents(element.EndTime - chronoline.Time, _backwardPlayedTimeCalcualtor, chronoline.Chains.Backward);
            }

            // Handle new chronolines.
            if (element.Playable.Duration == 0f)
            {
                // Handle all phase events at once.
                if (!ChronolineExist(element.StartTime))
                    AddChronoline(GenerateChronoline(element.StartTime));
            }
            else
            {
                // Handle start chronoline.
                if (!ChronolineExist(element.StartTime))
                    AddChronoline(GenerateChronoline(element.StartTime));

                // Handle intermediate new chronolines (loop lines).
                for (int j = 0; j <= element.Playable.LoopsCount; j++)
                {
                    var phaseTime = element.StartTime + element.Playable.LoopDuration * j;

                    if (ChronolineExist(phaseTime))
                        continue;

                    AddChronoline(GenerateChronoline(phaseTime));
                }

                // Handle end chronoline.
                if (!ChronolineExist(element.EndTime))
                    AddChronoline(GenerateChronoline(element.EndTime));
            }
        }

        #region Rewind
        protected override void RewindZeroHandler(int loop, float loopedNormalizedTime, Direction direction)
        {
            if (_lastLoopedNormalizedTime != 0f || loopedNormalizedTime != 1f)
            {
                _lastLoopedNormalizedTime = loopedNormalizedTime;
                return;
            }

            if (direction == Direction.Forward)
                _chronolines[0].Chains.Forward.CallAllEvents(Direction.Forward);
            else
                _chronolines[0].Chains.Backward.CallAllEvents(Direction.Backward);

            _lastLoopedNormalizedTime = loopedNormalizedTime;
        }

        protected override void RewindHandler(int loop, float loopedTime, Direction direction)
        {
            if (direction == Direction.Forward)
            {
                var nextPlayedTime = loop * LoopDuration + loopedTime;

                // If we jump to the same position, than we don't need handle this situation.
                if (nextPlayedTime == PlayedTime)
                    return;

                var loopedPlayedTime = PlayedTime % LoopDuration;
                Chronoline lastChronoline = null;

                for (int i = 0; i < _chronolines.Count; i++)
                {
                    var chronoline = _chronolines[i];

                    // If chronoline stay back from start time, than we just skip it.
                    if (chronoline.Time < loopedPlayedTime)
                        continue;

                    // If chronoline start in front if end time, than we need stop cycle.
                    if (chronoline.Time > loopedTime)
                        break;

                    // If chronoline stay at start time, than we need handle only post events.
                    if (chronoline.Time == loopedPlayedTime)
                        chronoline.Chains.Forward.CallPostEvents(Direction.Forward);
                    else if (chronoline.Time == loopedTime)
                    {
                        // If chronoline stay at end of loop, than we need call all events.
                        if (loopedTime == LoopDuration)
                            chronoline.Chains.Forward.CallAllEvents(Direction.Forward);
                        else
                            chronoline.Chains.Forward.CallPreEvents(Direction.Forward);
                    }
                    else // Otherwise means that chronoline is between start and end, and we need call all events.
                        chronoline.Chains.Forward.CallAllEvents(Direction.Forward);

                    lastChronoline = chronoline;
                }

                // If last handled chronoline not stay at end of interval, than it means,
                // that we need handle one extra chronoline for update phase.
                if (lastChronoline == null || lastChronoline.Time != loopedTime)
                    GenerateChronoline(loopedTime).Chains.Forward.CallAllEvents(Direction.Forward);
            }
            else
            {
                var nextPlayedTime = Duration - (loop * LoopDuration + loopedTime);

                // If we jump to the same position, than we don't need handle this situation.
                if (nextPlayedTime == PlayedTime)
                    return;

                var loopedPlayedTime = LoopDuration - LoopTime(PlayedTime);
                Chronoline lastChronoline = null;

                for (int i = _chronolines.Count - 1; i >= 0; i--)
                {
                    var chronoline = _chronolines[i];
                    var backwardChronolineTime = LoopDuration - chronoline.Time;

                    // If chronoline stay back from start time, than we just skip it.
                    if (backwardChronolineTime < loopedPlayedTime)
                        continue;

                    // If chronoline start in front if end time, than we need stop cycle.
                    if (backwardChronolineTime > loopedTime)
                        break;

                    // If chronoline stay at start time, than we need handle only post events.
                    if (backwardChronolineTime == loopedPlayedTime)
                        chronoline.Chains.Backward.CallPostEvents(Direction.Backward);
                    else if (backwardChronolineTime == loopedTime)
                    {
                        // If chronoline stay at end of loop, than we need call all events.
                        if (loopedTime == LoopDuration)
                            chronoline.Chains.Backward.CallAllEvents(Direction.Backward);
                        else
                            chronoline.Chains.Backward.CallPreEvents(Direction.Backward);
                    }
                    else // Otherwise means that chronoline is between start and end, and we need call all events.
                        chronoline.Chains.Backward.CallAllEvents(Direction.Backward);

                    lastChronoline = chronoline;
                }

                // If last handled chronoline not stay at end of interval, than it means,
                // that we need handle one extra chronoline for update phase.
                if (lastChronoline == null || LoopDuration - lastChronoline.Time != loopedTime)
                    GenerateChronoline(LoopDuration - loopedTime).Chains.Backward.CallAllEvents(Direction.Backward);
            }
        }
        #endregion
    }
}