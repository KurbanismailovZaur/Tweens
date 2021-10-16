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
            protected Playable _playable;

            protected PhaseEvent(Playable playable) => _playable = playable;

            abstract public void Call(Direction direction);
        }

        #region Zedo duration
        private class PhaseStartEventZero : PhaseEvent
        {
            public PhaseStartEventZero(Playable playable) : base(playable) { }

            public override void Call(Direction direction) => _playable.HandlePhaseStartEventZero(direction);
        }

        private class PhaseFirstLoopStartEventZero : PhaseEvent
        {
            public PhaseFirstLoopStartEventZero(Playable playable) : base(playable) { }

            public override void Call(Direction direction) => _playable.HandlePhaseFirstLoopStartEventZero(direction);
        }

        private class PhaseLoopCompleteEventZero : PhaseEvent
        {
            private int _loop;

            public PhaseLoopCompleteEventZero(Playable playable, int loop) : base(playable) => _loop = loop;

            public override void Call(Direction direction) => _playable.HandlePhaseLoopCompleteEventZero(_loop, direction);
        }

        private class PhaseLoopStartEventZero : PhaseEvent
        {
            private int _loop;

            public PhaseLoopStartEventZero(Playable playable, int loop) : base(playable) => _loop = loop;

            public override void Call(Direction direction) => _playable.HandlePhaseLoopStartEventZero(_loop, direction);
        }

        private class PhaseCompleteEventZero : PhaseEvent
        {
            public PhaseCompleteEventZero(Playable playable) : base(playable) { }

            public override void Call(Direction direction) => _playable.HandlePhaseCompleteEventZero(direction);
        }
        #endregion

        #region Non zero duration
        private class PhaseStartEvent : PhaseEvent
        {
            public PhaseStartEvent(Playable playable) : base(playable) { }

            public override void Call(Direction direction) => _playable.HandlePhaseStartEvent(direction);
        }

        private class PhaseFirstLoopStartEvent : PhaseEvent
        {
            public PhaseFirstLoopStartEvent(Playable playable) : base(playable) { }

            public override void Call(Direction direction) => _playable.HandlePhaseFirstLoopStartEvent(direction);
        }

        private class PhaseLoopCompleteEvent : PhaseEvent
        {
            private int _loop;

            public PhaseLoopCompleteEvent(Playable playable, int loop) : base(playable) => _loop = loop;

            public override void Call(Direction direction) => _playable.HandlePhaseLoopCompleteEvent(_loop, direction);
        }

        private class PhaseLoopStartEvent : PhaseEvent
        {
            private int _loop;

            public PhaseLoopStartEvent(Playable playable, int loop) : base(playable) => _loop = loop;

            public override void Call(Direction direction) => _playable.HandlePhaseLoopStartEvent(_loop, direction);
        }

        private class PhaseLoopUpdateEvent : PhaseEvent
        {
            private float _endTime;

            private int _loop;

            private float _loopedTime;

            public PhaseLoopUpdateEvent(Playable playable, float endTime, int loop, float loopedTime) : base(playable)
            {
                _endTime = endTime;
                _loop = loop;
                _loopedTime = loopedTime;
            }

            public override void Call(Direction direction) => _playable.HandlePhaseLoopUpdateEvent(_endTime, _loop, _loopedTime, direction);
        }

        private class PhaseCompleteEvent : PhaseEvent
        {
            public PhaseCompleteEvent(Playable playable) : base(playable) { }

            public override void Call(Direction direction) => _playable.HandlePhaseCompleteEvent(direction);
        }
        #endregion
        #endregion

        private class ChronoLine
        {
            public float Time { get; set; }

            private readonly List<PhaseEvent> _events = new List<PhaseEvent>();

            public int PrePostPoint { get; internal set; }

            public ChronoLine(float time) => Time = time;

            public void AppendEvent(PhaseEvent phaseEvent) => _events.Add(phaseEvent);

            public void InsertEvent(int index, PhaseEvent phaseEvent) => _events.Insert(index, phaseEvent);

            public void CallPreEvents(Direction direction)
            {
                for (int i = 0; i < PrePostPoint; i++)
                    _events[i].Call(direction);
            }

            public void CallPostEvents(Direction direction)
            {
                for (int i = PrePostPoint; i < _events.Count; i++)
                    _events[i].Call(direction);
            }

            public void CallAllEvents(Direction direction)
            {
                for (int i = 0; i < _events.Count; i++)
                    _events[i].Call(direction);
            }
        }

        public override Type Type => Type.Sequence;

        public LoopResetBehaviour LoopResetBehaviour { get; set; }

        private readonly List<Element> _elements = new List<Element>();

        public ReadOnlyCollection<Element> Elements => _elements.AsReadOnly();

        private int _nextPriority;

        private readonly List<Element> _elementsBuffer = new List<Element>();

        private readonly List<ChronoLine> _chronolines = new List<ChronoLine>();

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
                for (int i = 0; i < _elements.Count; i++)
                    _elements[i].Playable.RewindTo(direction == Direction.Forward ? 0f : Duration, false);
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

        private void AddChronoline(ChronoLine chronoline)
        {
            for (int i = 0; i < _chronolines.Count; i++)
            {
                if (chronoline.Time < _chronolines[i].Time)
                {
                    _chronolines.Insert(i, chronoline);
                    return;
                }
            }

            _chronolines.Add(chronoline);
        }

        private ChronoLine GenerateChronoline(float time)
        {
            var chronoline = new ChronoLine(time);

            for (int i = 0; i < _elements.Count; i++)
            {
                var element = _elements[i];

                if (chronoline.Time < element.StartTime || chronoline.Time > element.EndTime)
                    continue;

                if (element.Playable.Duration == 0f)
                {
                    // For zero duration playables we call all phases events at once.
                    chronoline.AppendEvent(new PhaseStartEventZero((Playable)element.Playable));
                    chronoline.AppendEvent(new PhaseFirstLoopStartEventZero((Playable)element.Playable));

                    // Remember this element for handling its loop events later
                    _elementsBuffer.Add(element);
                }
                else
                {
                    var playedTime = (chronoline.Time - element.StartTime);

                    // Start phase.
                    if (playedTime == 0f)
                    {
                        chronoline.AppendEvent(new PhaseStartEvent((Playable)element.Playable));
                        chronoline.AppendEvent(new PhaseFirstLoopStartEvent((Playable)element.Playable));
                    }
                    else if (playedTime % element.Playable.LoopDuration == 0f && playedTime != element.Playable.Duration) // Intermediate loop phase (end not included).
                    {
                        var loop = (int)(playedTime / element.Playable.LoopDuration);
                        chronoline.InsertEvent(chronoline.PrePostPoint++, new PhaseLoopCompleteEvent((Playable)element.Playable, loop - 1));
                        chronoline.AppendEvent(new PhaseLoopStartEvent((Playable)element.Playable, loop));
                    }
                    else if (playedTime == element.Playable.Duration) // Complete phase
                    {
                        chronoline.InsertEvent(chronoline.PrePostPoint++, new PhaseLoopCompleteEvent((Playable)element.Playable, element.Playable.LoopsCount - 1));
                        chronoline.InsertEvent(chronoline.PrePostPoint++, new PhaseCompleteEvent((Playable)element.Playable));
                    }
                    else // Update phase (for elements on which chrono-line hitted not at phase times)
                        chronoline.InsertEvent(chronoline.PrePostPoint++, new PhaseLoopUpdateEvent((Playable)element.Playable, playedTime, (int)(playedTime / element.Playable.LoopDuration), playedTime % element.Playable.LoopDuration));
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
                for (int j = 0; j < _elementsBuffer.Count; j++)
                {
                    var element = _elementsBuffer[j];

                    // If reach own max loops count, than we need remove this element.
                    if (i == element.Playable.LoopsCount - 1)
                    {
                        // Complete phase.
                        chronoline.AppendEvent(new PhaseLoopCompleteEventZero((Playable)element.Playable, element.Playable.LoopsCount - 1));
                        chronoline.AppendEvent(new PhaseCompleteEventZero((Playable)element.Playable));

                        _elementsBuffer.Remove(element);
                        --j;
                    }
                    else // Intermediate phase.
                    {
                        chronoline.AppendEvent(new PhaseLoopCompleteEventZero((Playable)element.Playable, i));
                        chronoline.AppendEvent(new PhaseLoopStartEventZero((Playable)element.Playable, i + 1));
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
            // TODO: WHAT ABOUT BACKWARD DIRECTION?

            void ForwardHandler()
            {
                var nextPlayedTime = loop * LoopDuration + loopedTime;

                // If we jump to the same position, than we don't need handle this situation.
                if (nextPlayedTime == PlayedTime)
                    return;

                var loopedPlayedTime = PlayedTime % LoopDuration;
                ChronoLine lastChronoline = null;

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
                        chronoline.CallPostEvents(direction);
                    else if (chronoline.Time == loopedTime)
                    {
                        // If chronoline stay at end of loop, than we need call all events.
                        if (loopedTime == LoopDuration)
                            chronoline.CallAllEvents(direction);
                        else
                            chronoline.CallPreEvents(direction);
                    }
                    else // Otherwise means that chronoline is between start and end, and we need call all events.
                        chronoline.CallAllEvents(direction);

                    lastChronoline = chronoline;
                }

                // If last handled chronoline not stay at end of interval, than it means,
                // that we need handle one extra chronoline for update phase.
                if (lastChronoline == null || lastChronoline.Time != loopedTime)
                    GenerateChronoline(loopedTime).CallAllEvents(direction);
            }

            void BackwardHandler()
            {
                var nextPlayedTime = loop * LoopDuration + loopedTime;

                // If we jump to the same position, than we don't need handle this situation.
                if (nextPlayedTime == PlayedTime)
                    return;

                var loopedPlayedTime = PlayedTime % LoopDuration;
                ChronoLine lastChronoline = null;

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
                        chronoline.CallPostEvents(direction);
                    else if (chronoline.Time == loopedTime)
                    {
                        // If chronoline stay at end of loop, than we need call all events.
                        if (loopedTime == LoopDuration)
                            chronoline.CallAllEvents(direction);
                        else
                            chronoline.CallPreEvents(direction);
                    }
                    else // Otherwise means that chronoline is between start and end, and we need call all events.
                        chronoline.CallAllEvents(direction);

                    lastChronoline = chronoline;
                }

                // If last handled chronoline not stay at end of interval, than it means,
                // that we need handle one extra chronoline for update phase.
                if (lastChronoline.Time != loopedTime)
                    GenerateChronoline(loopedTime).CallAllEvents(direction);
            }

            if (direction == Direction.Forward)
                ForwardHandler();
            else
                BackwardHandler();
        }
        #endregion
    }
}