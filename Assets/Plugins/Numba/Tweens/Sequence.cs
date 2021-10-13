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

            public int Priority { get; internal set; }

            internal Element(float time, IPlayable<Playable> playable, int index)
            {
                StartTime = time;
                Playable = playable;
                Priority = index;
            }
        }

        #region Phase events
        private abstract class PhaseEvent
        {
            protected Playable Playable { get; private set; }

            public PhaseEvent(Playable playable) => Playable = playable;

            public abstract void Call(Direction direction);
        }

        #region Zero duration
        private class PhaseStartEventZero : PhaseEvent
        {
            public PhaseStartEventZero(Playable playable) : base(playable) { }

            public override void Call(Direction direction) => Playable.CallRewindZeroPhaseStartEvent(direction);
        }

        private class PhaseLoopStartEventZero : PhaseEvent
        {
            private int _loop;

            public PhaseLoopStartEventZero(Playable playable, int loop) : base(playable) => _loop = loop;

            public override void Call(Direction direction) => Playable.CallRewindZeroPhaseLoopStartEvent(_loop, direction);
        }

        private class PhaseLoopCompleteEventZero : PhaseEvent
        {
            private int _loop;

            public PhaseLoopCompleteEventZero(Playable playable, int loop) : base(playable) => _loop = loop;

            public override void Call(Direction direction) => Playable.CallRewindZeroPhaseLoopCompleteEvent(_loop, direction);
        }

        private class PhaseCompleteEventZero : PhaseEvent
        {
            public PhaseCompleteEventZero(Playable playable) : base(playable) { }

            public override void Call(Direction direction) => Playable.CallRewindZeroPhaseCompleteEvent(direction);
        }
        #endregion

        #region Non zero duration
        private class PhaseStartEvent : PhaseEvent
        {
            public PhaseStartEvent(Playable playable) : base(playable) { }

            public override void Call(Direction direction) => Playable.CallRewindPhaseStartEvent(direction);
        }

        private class PhaseLoopStartEvent : PhaseEvent
        {
            private float _startTime;

            private int _playedLoop;

            public PhaseLoopStartEvent(Playable playable, float startTime, int playedLoop) : base(playable)
            {
                _startTime = startTime;
                _playedLoop = playedLoop;
            }

            public override void Call(Direction direction) => Playable.CallRewindPhaseLoopStartEvent(_startTime, _playedLoop, direction);
        }

        private class PhaseLoopStartIntermediateEvent : PhaseEvent
        {
            private int _loopIndex;

            public PhaseLoopStartIntermediateEvent(Playable playable, int loopIndex) : base(playable) => _loopIndex = loopIndex;

            public override void Call(Direction direction) => Playable.CallRewindPhaseLoopStartIntermediateEvent(_loopIndex, direction);
        }

        private class PhaseLoopCompleteIntermediateEvent : PhaseEvent
        {
            private int _loopIndex;

            private float _loopedTime;

            private float _endTime;

            public PhaseLoopCompleteIntermediateEvent(Playable playable, float endTime, int loopIndex, float loopedTime) : base(playable)
            {
                _endTime = endTime;
                _loopIndex = loopIndex;
                _loopedTime = loopedTime;
            }

            public override void Call(Direction direction) => Playable.CallRewindPhaseLoopCompleteIntermediateEvent(_endTime, _loopIndex, _loopedTime, direction);
        }

        private class PhaseLoopCompleteEvent : PhaseEvent
        {
            private float _endTime;

            private int _timeLoop;

            public PhaseLoopCompleteEvent(Playable playable, float endTime, int timeLoop) : base(playable)
            {
                _endTime = endTime;
                _timeLoop = timeLoop;
            }

            public override void Call(Direction direction) => Playable.CallRewindPhaseLoopCompleteEvent(_endTime, _timeLoop, direction);
        }

        private class PhaseUpdateEvent : PhaseEvent
        {
            private float _endTime;

            private int _timeLoop;

            private float _loopedTime;

            public PhaseUpdateEvent(Playable playable, float endTime, int timeLoop, float loopedTime) : base(playable)
            {
                _endTime = endTime;
                _timeLoop = timeLoop;
                _loopedTime = loopedTime;
            }

            public override void Call(Direction direction) => Playable.CallRewindPhaseUpdateEvent(_endTime, _timeLoop, _loopedTime, direction);
        }

        private class PhaseCompleteEvent : PhaseEvent
        {
            private int _timeLoop;

            public PhaseCompleteEvent(Playable playable, int timeLoop) : base(playable) => _timeLoop = timeLoop;

            public override void Call(Direction direction) => Playable.CallRewindPhaseCompleteEvent(_timeLoop, direction);
        }
        #endregion
        #endregion

        private class ChronoLine
        {
            public float Time { get; set; }

            private List<PhaseEvent> _events = new List<PhaseEvent>();

            public ChronoLine(float time) => Time = time;

            public void AddEvent(PhaseEvent phaseEvent) => _events.Add(phaseEvent);
        }

        public override Type Type => Type.Sequence;

        public LoopResetBehaviour LoopResetBehaviour { get; set; }

        private readonly List<Element> _elements = new List<Element>();

        public ReadOnlyCollection<Element> Elements => _elements.AsReadOnly();

        private int _nextPriority;

        private readonly List<Element> _elementsBuffer = new List<Element>();

        private readonly List<ChronoLine> _lines = new List<ChronoLine>();

        #region Constructors
        public Sequence(FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind) : this((string)null, formula, loopsCount, loopType, direction, loopResetBehaviour) { }

        public Sequence(string name, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind) : this(null, name, formula, loopsCount, loopType, direction, loopResetBehaviour) { }

        public Sequence(GameObject owner, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind) : this(owner, null, formula, loopsCount, loopType, direction, loopResetBehaviour) { }

        public Sequence(GameObject owner, string name, FormulaBase formula = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, Direction direction = Direction.Forward, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind) : base(owner, name, 0f, formula, loopsCount, loopType, direction)
        {
            LoopResetBehaviour = loopResetBehaviour;
        }
        #endregion

        private int GetNextPriority() => _nextPriority++;

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

            var element = new Element(Mathf.Max(time, 0f), playable, GetNextPriority());

            _elements.Add(element);

            if (element.EndTime > LoopDuration)
                LoopDuration = element.EndTime;

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

            }
            else
            {
                for (int i = 0; i < _elements.Count; i++)
                    _elements[i].Playable.SkipTo(direction == Direction.Forward ? 0f : Duration);
            }
        }
        #endregion

        private void FillBufferWithElementsOnInterval(float start, float end, Direction direction)
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
            if (direction == Direction.Backward)
                (loopedPlayedTime, loopedTime) = (LoopDuration - loopedPlayedTime, LoopDuration - loopedTime);

            FillBufferWithElementsOnInterval(loopedPlayedTime, loopedTime, direction);

            for (int i = 0; i < _elementsBuffer.Count; i++)
                _elements[i].Playable.SkipTo(loopedTime - _elements[i].StartTime);

            _elementsBuffer.Clear();
        }
        #endregion

        private bool ChronoLineExist(float time)
        {
            for (int i = 0; i < _lines.Count; i++)
            {
                if (_lines[i].Time == time)
                    return true;
            }

            return false;
        }

        private ChronoLine GenerateChronoLine(float time)
        {
            var line = new ChronoLine(time);
            var insertIndex = 0;

            for (int i = 0; i < _elements.Count; i++)
            {
                var element = _elements[i];

                if (line.Time < element.StartTime && line.Time > element.EndTime)
                    continue;

                if (element.Playable.Duration == 0f)
                {
                    // For zero duration playables we call all phases events at once.
                    line.AddEvent(new PhaseStartEventZero((Playable)element.Playable));

                    for (int j = 0; j < element.Playable.LoopsCount; j++)
                    {
                        line.AddEvent(new PhaseLoopStartEventZero((Playable)element.Playable, j));
                        line.AddEvent(new PhaseLoopCompleteEventZero((Playable)element.Playable, j));
                    }

                    line.AddEvent(new PhaseCompleteEventZero((Playable)element.Playable));
                }
                else
                {
                    // Start phase.
                    if (element.StartTime == line.Time)
                    {
                        line.AddEvent(new PhaseStartEvent((Playable)element.Playable));
                        line.AddEvent(new PhaseLoopStartEvent((Playable)element.Playable, 0f, 0));
                    }
                    else
                    {
                        var playedTime = (line.Time - element.StartTime);
                        if (playedTime % element.Playable.LoopDuration == 0f && playedTime != element.Playable.Duration) // Intermediate loop phase.
                        {

                        }

                    }

                }


            }

            return line;
        }

        public Sequence GenerateChronoLines()
        {
            for (int i = 0; i < _elements.Count; i++)
            {
                var element = _elements[i];

                if (element.Playable.Duration == 0f)
                {
                    if (ChronoLineExist(element.StartTime))
                        continue;

                    _lines.Add(GenerateChronoLine(element.StartTime));
                }
                else
                {
                    for (int j = 0; j <= element.Playable.LoopsCount; j++)
                    {
                        var phaseTime = element.StartTime + element.Playable.LoopDuration * j;

                        if (ChronoLineExist(phaseTime))
                            continue;

                        _lines.Add(GenerateChronoLine(phaseTime));
                    }
                }
            }

            _lines.Sort((a, b) => a.Time.CompareTo(b.Time));

            return this;
        }

        private void FillEventsBuffer(float start, float end, Direction direction)
        {
            for (int i = 0; i < _elementsBuffer.Count; i++)
            {
                FillBufferWithElementsOnInterval(start, end, direction);

                var element = _elementsBuffer[i];



                _elementsBuffer.Clear();
            }
        }



        #region Rewind
        protected override void RewindZeroHandler(int loop, float loopedNormalizedTime, Direction direction)
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

        protected override void RewindHandler(int loop, float loopedTime, Direction direction)
        {
            // TODO: what about backward direction?



            var nextPlayedTime = loop * LoopDuration + loopedTime;

            // If we jump to the same position, than we don't need handle this situation.
            if (nextPlayedTime == PlayedTime)
                return;

            var loopedPlayedTime = PlayedTime % LoopDuration;

            FillEventsBuffer(loopedPlayedTime, nextPlayedTime, direction);

            PlayedTime = nextPlayedTime;
        }
        #endregion
    }
}