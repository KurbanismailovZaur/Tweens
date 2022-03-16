using Redcode.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Redcode.Tweens
{
    /// <summary>
    /// Represents a container class capable of storing lots of any <see cref="IPlayable"/> and animating them.
    /// </summary>
    public sealed class Sequence : Playable<Sequence>
    {
        #region Inner types
        /// <summary>
        /// Represents sequence element.
        /// </summary>
        public class Element
        {
            /// <summary>
            /// Sequence which contain the element.
            /// </summary>
            public Sequence Sequence { get; internal set; }

            private float _startTime;

            /// <summary>
            /// Time at which the element start playing.
            /// </summary>
            public float StartTime
            {
                get => _startTime;
                set => Sequence.ChangeElementStartTime(this, value);
            }

            /// <summary>
            /// Reference to playable, which will be played when sequence start play.
            /// </summary>
            public IPlayable Playable { get; internal set; }

            /// <summary>
            /// The time at which an element in the sequence completes playback.
            /// </summary>
            public float EndTime => StartTime + Playable.Duration;

            private int _order;

            /// <summary>
            /// Element's order in the sequence. Elements with a lower order will be processed 
            /// <br/>by the sequencing before the current one, and elements with a higher order
            /// <br/>will be processed after it. 
            /// </summary>
            public int Order
            {
                get => _order;
                set => Sequence.ChangeElementOrder(this, value);
            }

            internal Element(float startTime, IPlayable playable, int order)
            {
                _startTime = startTime;
                Playable = playable;
                _order = order;
            }

            internal void SetStartTime(float startTime) => _startTime = startTime;

            internal void SetOrder(int order) => _order = order;

            /// <summary>
            /// Sets new start time and order.
            /// </summary>
            /// <param name="startTime">New start time.</param>
            /// <param name="order">New order.</param>
            public void SetStartTimeAndOrder(float startTime, int order)
            {
                StartTime = startTime;
                Order = order;
            }

            /// <summary>
            /// Overrides the default behavior to improve debugging.
            /// </summary>
            /// <returns><see cref="Playable"/>'s name.</returns>
            public override string ToString() => Playable.Name;
        }

        #region Phases
        private abstract class Phase
        {
            protected Element _element;

            internal Element Element => _element;

            protected Phase(Element element) => _element = element;

            abstract internal void Call(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount);
        }

        #region Zedo duration
        private class PhaseStartZeroed : Phase
        {
            internal PhaseStartZeroed(Element element) : base(element) { }

            internal override void Call(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
            {
                if (emitEvents)
                    ((Playable)_element.Playable).HandlePhaseStartZeroed(direction, continueRepeatIndex, continueMaxLoopsCount);
                else
                    ((Playable)_element.Playable).HandlePhaseStartZeroedNoEvents(direction, continueRepeatIndex, continueMaxLoopsCount);
            }
        }

        private class PhaseFirstLoopStartZeroed : Phase
        {
            internal PhaseFirstLoopStartZeroed(Element element) : base(element) { }

            internal override void Call(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
            {
                if (emitEvents)
                    ((Playable)_element.Playable).HandlePhaseFirstLoopStartZeroed(direction, continueRepeatIndex, continueMaxLoopsCount);
                else
                    ((Playable)_element.Playable).HandlePhaseFirstLoopStartZeroedNoEvents(direction, continueRepeatIndex, continueMaxLoopsCount);
            }
        }

        private class PhaseLoopCompleteZeroed : Phase
        {
            private int _loop;

            internal PhaseLoopCompleteZeroed(Element element, int loop) : base(element) => _loop = loop;

            internal override void Call(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
            {
                if (emitEvents)
                    ((Playable)_element.Playable).HandlePhaseLoopCompleteZeroed(_loop, direction, continueRepeatIndex, continueMaxLoopsCount);
                else
                    ((Playable)_element.Playable).HandlePhaseLoopCompleteZeroedNoEvents(_loop, direction, continueRepeatIndex, continueMaxLoopsCount);
            }
        }

        private class PhaseLoopStartZeroed : Phase
        {
            private int _loop;

            internal PhaseLoopStartZeroed(Element element, int loop) : base(element) => _loop = loop;

            internal override void Call(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
            {
                if (emitEvents)
                    ((Playable)_element.Playable).HandlePhaseLoopStartZeroed(_loop, direction, continueRepeatIndex, continueMaxLoopsCount);
                else
                    ((Playable)_element.Playable).HandlePhaseLoopStartZeroedNoEvents(_loop, direction, continueRepeatIndex, continueMaxLoopsCount);
            }
        }

        private class PhaseLoopUpdateZeroed : Phase
        {
            private int _loop;

            internal PhaseLoopUpdateZeroed(Element element, int loop) : base(element) => _loop = loop;

            internal override void Call(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
            {
                if (emitEvents)
                    ((Playable)_element.Playable).HandlePhaseLoopUpdateZeroed(_loop, direction, continueRepeatIndex, continueMaxLoopsCount);
                else
                    ((Playable)_element.Playable).HandlePhaseLoopUpdateZeroedNoEvents(_loop, direction, continueRepeatIndex, continueMaxLoopsCount);
            }
        }

        private class PhaseCompleteZeroed : Phase
        {
            internal PhaseCompleteZeroed(Element element) : base(element) { }

            internal override void Call(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
            {
                if (emitEvents)
                    ((Playable)_element.Playable).HandlePhaseCompleteZeroed(direction, continueRepeatIndex, continueMaxLoopsCount);
                else
                    ((Playable)_element.Playable).HandlePhaseCompleteZeroedNoEvents(direction, continueRepeatIndex, continueMaxLoopsCount);
            }
        }
        #endregion

        #region Non zero duration
        private class PhaseStart : Phase
        {
            public PhaseStart(Element element) : base(element) { }

            internal override void Call(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
            {
                if (emitEvents)
                    ((Playable)_element.Playable).HandlePhaseStart(direction, continueRepeatIndex, continueMaxLoopsCount);
                else
                    ((Playable)_element.Playable).HandlePhaseStartNoEvents(direction, continueRepeatIndex, continueMaxLoopsCount);
            }
        }

        private class PhaseFirstLoopStart : Phase
        {
            public PhaseFirstLoopStart(Element element) : base(element) { }

            internal override void Call(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
            {
                if (emitEvents)
                    ((Playable)_element.Playable).HandlePhaseFirstLoopStart(direction, continueRepeatIndex, continueMaxLoopsCount);
                else
                    ((Playable)_element.Playable).HandlePhaseFirstLoopStartNoEvents(direction, continueRepeatIndex, continueMaxLoopsCount);
            }
        }

        private class PhaseLoopComplete : Phase
        {
            private int _loop;

            internal PhaseLoopComplete(Element element, int loop) : base(element) => _loop = loop;

            internal override void Call(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
            {
                if (emitEvents)
                    ((Playable)_element.Playable).HandlePhaseLoopComplete(_loop, direction, continueRepeatIndex, continueMaxLoopsCount);
                else
                    ((Playable)_element.Playable).HandlePhaseLoopCompleteNoEvents(_loop, direction, continueRepeatIndex, continueMaxLoopsCount);
            }
        }

        private class PhaseLoopStart : Phase
        {
            private int _loop;

            internal PhaseLoopStart(Element element, int loop) : base(element) => _loop = loop;

            internal override void Call(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
            {
                if (emitEvents)
                    ((Playable)_element.Playable).HandlePhaseLoopStart(_loop, direction, continueRepeatIndex, continueMaxLoopsCount);
                else
                    ((Playable)_element.Playable).HandlePhaseLoopStartNoEvents(_loop, direction, continueRepeatIndex, continueMaxLoopsCount);
            }
        }

        private class PhaseLoopUpdate : Phase
        {
            private float _endTime;

            private int _loop;

            private float _loopedTime;

            // Need for mirror's mode to detect should we delete chronoline or no.
            public float LoopedTime => _loopedTime;

            internal PhaseLoopUpdate(Element element, float endTime, int loop, float loopedTime) : base(element)
            {
                _endTime = endTime;
                _loop = loop;
                _loopedTime = loopedTime;
            }

            internal override void Call(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
            {
                if (emitEvents)
                    ((Playable)_element.Playable).HandlePhaseLoopUpdate(_endTime, _loop, _loopedTime, direction, continueRepeatIndex, continueMaxLoopsCount);
                else
                    ((Playable)_element.Playable).HandlePhaseLoopUpdateNoEvents(_endTime, _loop, _loopedTime, direction, continueRepeatIndex, continueMaxLoopsCount);
            }
        }

        private class PhaseComplete : Phase
        {
            internal PhaseComplete(Element element) : base(element) { }

            internal override void Call(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
            {
                if (emitEvents)
                    ((Playable)_element.Playable).HandlePhaseComplete(direction, continueRepeatIndex, continueMaxLoopsCount);
                else
                    ((Playable)_element.Playable).HandlePhaseCompleteNoEvents(direction, continueRepeatIndex, continueMaxLoopsCount);
            }
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

                internal void CallPreEvents(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
                {
                    for (int i = 0; i < PrePostPoint; i++)
                        _events[i].Call(direction, emitEvents, continueRepeatIndex, continueMaxLoopsCount);
                }

                internal void CallPostEvents(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
                {
                    for (int i = PrePostPoint; i < _events.Count; i++)
                        _events[i].Call(direction, emitEvents, continueRepeatIndex, continueMaxLoopsCount);
                }

                internal void CallAllEvents(Direction direction, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
                {
                    for (int i = 0; i < _events.Count; i++)
                        _events[i].Call(direction, emitEvents, continueRepeatIndex, continueMaxLoopsCount);
                }

                internal void RemoveElementsPhaseEvents(Element element)
                {
                    for (int i = 0; i < _events.Count; i++)
                    {
                        var @event = _events[i];

                        if (@event.Element != element)
                            continue;

                        // If we delete pre-event, than we need decrease pre/post point.
                        if (i < PrePostPoint)
                            --PrePostPoint;

                        _events.RemoveAt(i--);
                    }
                }

                internal bool HasUsefulEvents()
                {
                    // If we have post-events, than it is 100% that non update events exist.
                    if (PrePostPoint < _events.Count)
                        return true;

                    // If we have pre-events, than we need to check it type on non update event.
                    for (int i = 0; i < PrePostPoint; i++)
                    {
                        if (!(_events[i] is PhaseLoopUpdate @event) || @event.Element.Playable.LoopType == LoopType.Mirror && (@event.LoopedTime % (@event.Element.Playable.LoopDuration / 2f)).Approximately(0f))
                            return true;
                    }

                    // Otwerwise the chain is not contains non update events.
                    return false;
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

            internal void RemovePhaseEventsForElement(Element element)
            {
                Chains.Forward.RemoveElementsPhaseEvents(element);
                Chains.Backward.RemoveElementsPhaseEvents(element);
            }

            // It is not matter, what direction chain we use.
            internal bool HasUsefulEvents() => Chains.Forward.HasUsefulEvents();
        }

        /// <summary>
        /// Used for detecting intersection type between chronoline and element.
        /// </summary>
        private enum IntersectionType : byte
        {
            Start,
            Update,
            Loop,
            Complete
        }
        #endregion

        #region State
        public override Type Type => Type.Sequence;

        /// <summary>
        /// Behaviour which applied to sequence before every loop start event.
        /// </summary>
        public LoopResetBehaviour LoopResetBehaviour { get; set; }

        private readonly List<Element> _elements = new List<Element>();

        /// <summary>
        /// Sequence elements.
        /// </summary>
        public ReadOnlyCollection<Element> Elements { get; private set; }

        private int _nextOrder;

        private readonly List<Element> _elementsBuffer = new List<Element>();

        private readonly List<Chronoline> _chronolines = new List<Chronoline>();

        /// <summary>
        /// Needed for handling zeroed loops.
        /// Used for understanding in which direction zeroed sequence was played.
        /// </summary>
        private float _lastLoopedNormalizedTime;
        #endregion

        #region Played time calculators (used in injectings methods)
        private static Func<float, Element, float> _forwardPlayedTimeCalcualtor = (chronolineTime, element) => chronolineTime - element.StartTime;

        private static Func<float, Element, float> _backwardPlayedTimeCalcualtor = (chronolineTime, element) => element.EndTime - chronolineTime;
        #endregion

        #region Constructors
        /// <summary>
        /// Create sequence object.
        /// </summary>
        /// <param name="ease"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="loopResetBehaviour"><inheritdoc cref="LoopResetBehaviour" path="/summary"/></param>
        /// <param name="direction"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Sequence(Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward) : this((string)null, ease, loopsCount, loopType, loopResetBehaviour, direction) { }

        /// <summary>
        /// <inheritdoc cref="Sequence.Sequence(Ease, int, LoopType, LoopResetBehaviour, Direction)"/>
        /// </summary>
        /// <param name="name">Name of the sequence (usefull for finding nested sequences and for debugging).</param>
        /// <param name="ease"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="loopResetBehaviour"><inheritdoc cref="LoopResetBehaviour" path="/summary"/></param>
        /// <param name="direction"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Sequence(string name, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward) : this(null, name, ease, loopsCount, loopType, loopResetBehaviour, direction) { }

        /// <summary>
        /// <inheritdoc cref="Sequence.Sequence(Ease, int, LoopType, LoopResetBehaviour, Direction)"/>
        /// </summary>
        /// <param name="owner">Game object to which this sequence will be attached.</param>
        /// <param name="ease"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="loopResetBehaviour"><inheritdoc cref="LoopResetBehaviour" path="/summary"/></param>
        /// <param name="direction"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Sequence(GameObject owner, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward) : this(owner, null, ease, loopsCount, loopType, loopResetBehaviour, direction) { }

        /// <summary>
        /// <inheritdoc cref="Sequence.Sequence(Ease, int, LoopType, LoopResetBehaviour, Direction)"/>
        /// </summary>
        /// <param name="owner"><inheritdoc cref="Sequence(GameObject, Ease, int, LoopType, LoopResetBehaviour, Direction)" path="/param[@name='owner']"/></param>
        /// <param name="name"><inheritdoc cref="Sequence(string, Ease, int, LoopType, LoopResetBehaviour, Direction)" path="/param[@name='name']"/></param>
        /// <param name="ease"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='ease']"/></param>
        /// <param name="loopsCount"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='loopsCount']"/></param>
        /// <param name="loopType"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='loopType']"/></param>
        /// <param name="loopResetBehaviour"><inheritdoc cref="LoopResetBehaviour" path="/summary"/></param>
        /// <param name="direction"><inheritdoc cref="Playable{T}.Playable(GameObject, string, float, Ease, int, LoopType, Direction)" path="/param[@name='direction']"/></param>
        public Sequence(GameObject owner, string name, Ease ease = null, int loopsCount = 1, LoopType loopType = LoopType.Reset, LoopResetBehaviour loopResetBehaviour = LoopResetBehaviour.Rewind, Direction direction = Direction.Forward) : base(owner, name, 0f, ease, loopsCount, loopType, direction)
        {
            Elements = _elements.AsReadOnly();
            LoopResetBehaviour = loopResetBehaviour;
        }
        #endregion

        /// <summary>
        /// Sets loop reset behaviour.
        /// </summary>
        /// <param name="loopResetBehaviour">New loop reset behaviour.</param>
        /// <returns>The <see cref="Sequence"/></returns>
        public Sequence SetLoopResetBehaviour(LoopResetBehaviour loopResetBehaviour)
        {
            LoopResetBehaviour = loopResetBehaviour;
            return this;
        }

        private bool CheckCyclicReference(Sequence other)
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

        private void AddChronolineToNecessaryPosition(Chronoline chronoline)
        {
            var index = 0;
            for (; index < _chronolines.Count; index++)
            {
                if (_chronolines[index].Time > chronoline.Time)
                    break;
            }

            _chronolines.Insert(index, chronoline);
        }

        private bool ChronolineExist(float time)
        {
            for (int i = 0; i < _chronolines.Count; i++)
            {
                if (_chronolines[i].Time.Approximately(time))
                    return true;
            }

            return false;
        }

        private IntersectionType GetIntersectionType(Element element, float playedTime)
        {
            if (playedTime.Approximately(0f))
                return IntersectionType.Start;
            else if (playedTime.Approximately(element.Playable.Duration))
                return IntersectionType.Complete;
            else if ((playedTime % element.Playable.LoopDuration).Approximately(0f))
                return IntersectionType.Loop;
            else
                return IntersectionType.Update;
        }

        #region Chronolines
        /// <summary>
        /// Create new chronoline and generate all phase events.
        /// </summary>
        /// <param name="time">The time, which will be used for generating phase events.</param>
        /// <returns>Created chronoline.</returns>
        private Chronoline GenerateChronoline(float time)
        {
            var chronoline = new Chronoline(time);

            for (int i = 0; i < _elements.Count; i++)
            {
                var element = _elements[i];

                if (chronoline.Time < element.StartTime || chronoline.Time > element.EndTime)
                    continue;

                if (element.Playable.Duration.Approximately(0f))
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
                        if (playedTime.Approximately(0f))
                        {
                            chain.AppendEvent(new PhaseStart(element));
                            chain.AppendEvent(new PhaseFirstLoopStart(element));
                        }
                        else if ((playedTime % element.Playable.LoopDuration).Approximately(0f) && !playedTime.Approximately(element.Playable.Duration)) // Intermediate loop phase (end not included).
                        {
                            var loop = (int)(playedTime / element.Playable.LoopDuration);
                            chain.InsertEvent(chain.PrePostPoint++, new PhaseLoopComplete(element, loop - 1));
                            chain.AppendEvent(new PhaseLoopStart(element, loop));
                        }
                        else if (playedTime.Approximately(element.Playable.Duration)) // Complete phase
                        {
                            chain.InsertEvent(chain.PrePostPoint++, new PhaseLoopComplete(element, element.Playable.LoopsCount - 1));
                            chain.InsertEvent(chain.PrePostPoint++, new PhaseComplete(element));
                        }
                        else // Update phase (for elements on which chrono-line hitted not at phase times)
                        {
                            float x = playedTime;
                            float y = element.Playable.Duration;

                            chain.InsertEvent(chain.PrePostPoint++, new PhaseLoopUpdate(element, playedTime, (int)(playedTime / element.Playable.LoopDuration), playedTime % element.Playable.LoopDuration));
                        }
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

                // Additional cycle for handling mirror's mode update half-event.
                for (int j = 0; j < _elementsBuffer.Count; j++)
                {
                    var element = _elementsBuffer[j];

                    if (element.Playable.LoopType == LoopType.Mirror)
                        chronoline.Chains.InsertEvent(insertIndex++, new PhaseLoopUpdateZeroed(element, i));
                }

                // Handling other events.
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

        /// <summary>
        /// Injects all element's phase events to necessary chronolines.
        /// </summary>
        /// <param name="element">Element whose phase events are to be injected.</param>
        private void InjectPhaseEventsForElement(Element element)
        {
            // Handle old chronolines on element's [start -> end] and [end -> start] intervals.
            for (int i = 0; i < _chronolines.Count; i++)
            {
                var chronoline = _chronolines[i];

                if (chronoline.Time < element.StartTime)
                    continue;

                if (chronoline.Time > element.EndTime)
                    break;

                void InjectEvents(float playedTime, Func<float, Element, float> playedTimeCalculator, Chronoline.Chain chain)
                {
                    bool ElementNotIntersectsOrSelf(Chronoline chronoline, int index, out Element oldElement)
                    {
                        oldElement = _elements[index];

                        if (chronoline.Time < oldElement.StartTime || chronoline.Time > oldElement.EndTime || oldElement == element)
                            return true;

                        return false;
                    }

                    if (element.Playable.Duration.Approximately(0f))
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
                                chain.InsertEvent(chain.PrePostPoint + insertIndex++, new PhaseStartZeroed(element));
                                chain.InsertEvent(chain.PrePostPoint + insertIndex++, new PhaseFirstLoopStartZeroed(element));

                                // Save new element to zeroed buffer for handling it within others zeroed elements.
                                _elementsBuffer.Add(oldElement);

                                continue;
                            }

                            // For zeroed elements this return start, otherwise calculated value will be returned.
                            var intersectionType = GetIntersectionType(oldElement, playedTimeCalculator(chronoline.Time, oldElement));

                            if (intersectionType == IntersectionType.Start)
                                insertIndex += 2;
                            if (intersectionType == IntersectionType.Loop)
                                ++insertIndex;

                            // Remember zeroed element for handle it later.
                            if (oldElement.Playable.Duration.Approximately(0f))
                                _elementsBuffer.Add(oldElement);
                        }

                        // Cycle for new element loops count (for adding phase loop events to chain).
                        for (int j = 0; j < element.Playable.LoopsCount; j++)
                        {
                            // Cycle for inserting mirror's mode half-update phase.
                            for (int k = 0; k < _elementsBuffer.Count; k++)
                            {
                                var zeroedElement = _elementsBuffer[k];

                                if (zeroedElement.Playable.LoopType == LoopType.Mirror)
                                {
                                    ++insertIndex;

                                    if (zeroedElement == element)
                                        chain.InsertEvent(chain.PrePostPoint + insertIndex - 1, new PhaseLoopUpdateZeroed(element, j));
                                }
                            }

                            // Used for calculating loop start phase event position for newly added element.
                            var startPhaseShift = 0;

                            // Cycle for zeroed elements (for correcting insert index and placing new element phase loop events).
                            for (int k = 0; k < _elementsBuffer.Count; k++)
                            {
                                var zeroedElement = _elementsBuffer[k];

                                // For current element we need add its phase events to chain.
                                if (zeroedElement == element)
                                {
                                    chain.InsertEvent(chain.PrePostPoint + insertIndex++, new PhaseLoopCompleteZeroed(element, j));

                                    if (j == element.Playable.LoopsCount - 1)
                                    {
                                        chain.InsertEvent(chain.PrePostPoint + insertIndex, new PhaseCompleteZeroed(element));
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
                            chain.InsertEvent(chain.PrePostPoint + insertIndex++, new PhaseLoopStartZeroed(element, j + 1));

                            var startsEventsLeft = _elementsBuffer.Count - 1 - _elementsBuffer.IndexOf(element);
                            insertIndex += startsEventsLeft;
                        }

                    END:
                        _elementsBuffer.Clear();
                    }
                    else
                    {
                        if (playedTime.Approximately(0f)) // Start phase.
                        {
                            var insertIndex = 0;

                            // Cycle for elements which placed before current.
                            for (int j = 0; j < element.Order; j++)
                            {
                                if (ElementNotIntersectsOrSelf(chronoline, j, out Element oldElement))
                                    continue;

                                var intersectionType = GetIntersectionType(oldElement, playedTimeCalculator(chronoline.Time, oldElement));

                                if (intersectionType == IntersectionType.Start)
                                    insertIndex += 2;
                                if (intersectionType == IntersectionType.Loop)
                                    ++insertIndex;
                            }

                            chain.InsertEvent(chain.PrePostPoint + insertIndex++, new PhaseStart(element));
                            chain.InsertEvent(chain.PrePostPoint + insertIndex, new PhaseFirstLoopStart(element));
                        }
                        else
                        {
                            if ((playedTime % element.Playable.LoopDuration).Approximately(0f) && !playedTime.Approximately(element.Playable.Duration)) // Intermediate phase.
                            {
                                var preInsertIndex = 0;
                                var postInsertIndex = 0;

                                for (int j = 0; j < element.Order; j++)
                                {
                                    if (ElementNotIntersectsOrSelf(chronoline, j, out Element oldElement))
                                        continue;

                                    if (element.Playable.Duration.Approximately(0f))
                                        postInsertIndex += 2;
                                    else
                                    {
                                        var intersectionType = GetIntersectionType(oldElement, playedTimeCalculator(chronoline.Time, oldElement));

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

                                    var intersectionType = GetIntersectionType(oldElement, playedTimeCalculator(chronoline.Time, oldElement));

                                    if (intersectionType == IntersectionType.Update || intersectionType == IntersectionType.Loop)
                                        ++insertIndex;
                                    else if (intersectionType == IntersectionType.Complete)
                                        insertIndex += 2;
                                }

                                if (playedTime.Approximately(element.Playable.Duration)) // Complete phase
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
            if (element.Playable.Duration.Approximately(0f))
            {
                // Handle all phase events at once.
                if (!ChronolineExist(element.StartTime))
                    AddChronolineToNecessaryPosition(GenerateChronoline(element.StartTime));
            }
            else
            {
                int loopsCount = element.Playable.LoopsCount;
                float loopDuration = element.Playable.LoopDuration;

                // For element in mirror's mode we need handle its half-events too, so we need half-step.
                if (element.Playable.LoopType == LoopType.Mirror)
                {
                    loopsCount *= 2;
                    loopDuration /= 2f;
                }

                // Handle all loops phase events.
                for (int j = 0; j <= loopsCount; j++)
                {
                    var phaseTime = element.StartTime + loopDuration * j;

                    if (!ChronolineExist(phaseTime))
                        AddChronolineToNecessaryPosition(GenerateChronoline(phaseTime));
                }
            }
        }
        #endregion

        #region Adding elements
        /// <summary>
        /// Adds a <paramref name="playable"/> to the left of all elements in the sequence.
        /// </summary>
        /// <param name="playable">Playable to add.</param>
        /// <returns><see cref="Element"/> which represent added <paramref name="playable"/>.</returns>
        public Element Prepend(IPlayable playable) => Prepend(_nextOrder, playable);

        /// <summary>
        /// <inheritdoc cref="Prepend(IPlayable)"/> Uses passed <paramref name="order"/> for <paramref name="playable"/>.
        /// </summary>
        /// <param name="order">Element's order.</param>
        /// <param name="playable"><inheritdoc cref="Prepend(IPlayable)"/></param>
        /// <returns><inheritdoc cref="Prepend(IPlayable)"/></returns>
        public Element Prepend(int order, IPlayable playable)
        {
            var leftmost = GetLeftmostElement();

            if (leftmost == null)
                return Insert(0f, order, playable);

            var startTime = leftmost.StartTime - playable.Duration;

            if (startTime < 0f)
            {
                for (int i = 0; i < _elements.Count; i++)
                    _elements[i].SetStartTime(_elements[i].StartTime - startTime);

                return Insert(0f, order, playable);
            }
            else
                return Insert(startTime, order, playable);
        }

        /// <summary>
        /// Adds a <paramref name="playable"/> to the right of all elements in the sequence.
        /// </summary>
        /// <param name="playable">Playable to add.</param>
        /// <returns><see cref="Element"/> which represent added <paramref name="playable"/>.</returns>
        public Element Append(IPlayable playable) => Append(_nextOrder, playable);

        /// <summary>
        /// <inheritdoc cref="Append(IPlayable)"/> Uses passed <paramref name="order"/> for <paramref name="playable"/>.
        /// </summary>
        /// <param name="order">Element's order.</param>
        /// <param name="playable"><inheritdoc cref="Append(IPlayable)"/></param>
        /// <returns><inheritdoc cref="Append(IPlayable)"/></returns>
        public Element Append(int order, IPlayable playable) => Insert(LoopDuration, order, playable);

        /// <summary>
        /// Inserts a <paramref name="playable"/> into the specified <paramref name="time"/> of the sequence
        /// </summary>
        /// <param name="time">The time at which playback of the element begins.</param>
        /// <param name="playable">Playable to add.</param>
        /// <returns><see cref="Element"/> which represent added <paramref name="playable"/>.</returns>
        public Element Insert(float time, IPlayable playable) => Insert(time, _nextOrder, playable);

        /// <summary>
        /// <inheritdoc cref="Insert(float, IPlayable)"/> Uses passed <paramref name="order"/> for <paramref name="playable"/>.
        /// </summary>
        /// <param name="time"><inheritdoc cref="Insert(float, IPlayable)" path="/param[@name='time']"/></param>
        /// <param name="order">Element's order.</param>
        /// <param name="playable"><inheritdoc cref="Insert(float, IPlayable)" path="/param[@name='playable']"/></param>
        /// <returns><inheritdoc cref="Insert(float, IPlayable)"/></returns>
        public Element Insert(float time, int order, IPlayable playable)
        {
            if (playable == this)
                throw new ArgumentException($"{Type} \"{Name}\": Sequence can't contain itself");

            if (playable is Sequence sequence && CheckCyclicReference(sequence))
                throw new ArgumentException($"{Type} \"{Name}\": Cyclic references in sequences are not allowed (sequence \"{sequence.Name}\" already contains sequence \"{Name}\")");

            order = Mathf.Clamp(order, 0, _elements.Count);

            var element = new Element(Mathf.Max(time, 0f), (Playable)playable, order);
            ++_nextOrder;

            return InsertElement(element);
        }

        private Element InsertElement(Element element)
        {
            element.Sequence = this;
            _elements.Insert(element.Order, element);

            for (int i = element.Order + 1; i < _elements.Count; i++)
                _elements[i].SetOrder(_elements[i].Order + 1);

            if (element.EndTime > LoopDuration)
                LoopDuration = element.EndTime;

            // Dummy playables shoud not participate in chronolines.
            if (element.Playable.Type != Type.Interval)
                InjectPhaseEventsForElement(element);

            // We need subscribe only first time when playable was added.
            if (GetElements(element.Playable).Count == 1)
                ((Playable)element.Playable).StateChanged += Playable_StateChanged;

            return element;
        }
        #endregion

        #region Adding callbacks
        /// <summary>
        /// Adds a <paramref name="callback"/> to the left of all elements in a sequence.
        /// </summary>
        /// <param name="callback">Callback to add.</param>
        /// <returns><see cref="Element"/> which represent added <paramref name="callback"/>.</returns>
        public Element PrependCallback(Action callback) => PrependCallback(_nextOrder, callback);

        /// <summary>
        /// <inheritdoc cref="PrependCallback(Action)"/> Uses passed <paramref name="order"/> for <paramref name="callback"/>.
        /// </summary>
        /// <param name="order">Element's order.</param>
        /// <param name="callback"><inheritdoc cref="PrependCallback(Action)"/></param>
        /// <returns><inheritdoc cref="PrependCallback(Action)"/></returns>
        public Element PrependCallback(int order, Action callback) => PrependCallback(order, null, callback);

        /// <summary>
        /// <inheritdoc cref="PrependCallback(Action)"/>
        /// </summary>
        /// <param name="name">Callback's name.</param>
        /// <param name="callback"><inheritdoc cref="PrependCallback(Action)"/></param>
        /// <returns><inheritdoc cref="PrependCallback(Action)"/></returns>
        public Element PrependCallback(string name, Action callback) => PrependCallback(_nextOrder, name, callback);

        /// <summary>
        /// <inheritdoc cref="PrependCallback(Action)"/> Uses passed <paramref name="order"/> for <paramref name="callback"/>.
        /// </summary>
        /// <param name="order"><inheritdoc cref="PrependCallback(int, Action)" path="/param[@name='order']"/></param>
        /// <param name="name"><inheritdoc cref="PrependCallback(string, Action)" path="/param[@name='name']"/></param>
        /// <param name="callback"><inheritdoc cref="PrependCallback(Action)"/></param>
        /// <returns><inheritdoc cref="PrependCallback(Action)"/></returns>
        public Element PrependCallback(int order, string name, Action callback) => InsertCallback(GetLeftmostElement()?.StartTime ?? 0f, order, name, callback);

        /// <summary>
        /// Adds a <paramref name="callback"/> to the right of all items in a sequence.
        /// </summary>
        /// <param name="callback">Callback to add.</param>
        /// <returns><see cref="Element"/> which represent added <paramref name="callback"/>.</returns>
        public Element AppendCallback(Action callback) => AppendCallback(_nextOrder, callback);

        /// <summary>
        /// <inheritdoc cref="AppendCallback(Action)"/> Uses passed <paramref name="order"/> for <paramref name="callback"/>.
        /// </summary>
        /// <param name="order">Element's order.</param>
        /// <param name="callback"><inheritdoc cref="AppendCallback(Action)"/></param>
        /// <returns><inheritdoc cref="AppendCallback(Action)"/></returns>
        public Element AppendCallback(int order, Action callback) => AppendCallback(order, null, callback);

        /// <summary>
        /// <inheritdoc cref="AppendCallback(Action)"/>
        /// </summary>
        /// <param name="name">Callback's name.</param>
        /// <param name="callback"><inheritdoc cref="AppendCallback(Action)"/></param>
        /// <returns><inheritdoc cref="AppendCallback(Action)"/></returns>
        public Element AppendCallback(string name, Action callback) => AppendCallback(_nextOrder, name, callback);

        /// <summary>
        /// <inheritdoc cref="AppendCallback(Action)"/> Uses passed <paramref name="order"/> for <paramref name="callback"/>.
        /// </summary>
        /// <param name="order"><inheritdoc cref="AppendCallback(int, Action)" path="/param[@name='order']"/></param>
        /// <param name="name"><inheritdoc cref="AppendCallback(string, Action)" path="/param[@name='name']"/></param>
        /// <param name="callback"><inheritdoc cref="AppendCallback(Action)"/></param>
        /// <returns><inheritdoc cref="AppendCallback(Action)"/></returns>
        public Element AppendCallback(int order, string name, Action callback) => InsertCallback(LoopDuration, order, name, callback);

        /// <summary>
        /// Inserts a <paramref name="callback"/> into the specified <paramref name="time"/> of the sequence.
        /// </summary>
        /// <param name="time">Time where to insert.</param>
        /// <param name="callback">Callback to add.</param>
        /// <returns><see cref="Element"/> which represent inserted <paramref name="callback"/>.</returns>
        public Element InsertCallback(float time, Action callback) => InsertCallback(time, _nextOrder, callback);

        /// <summary>
        /// <inheritdoc cref="InsertCallback(float, Action)"/> Uses passed <paramref name="order"/> for <paramref name="callback"/>.
        /// </summary>
        /// <param name="time"><inheritdoc cref="InsertCallback(float, Action)" path="/param[@name='time']"/></param>
        /// <param name="order">Element's order.</param>
        /// <param name="callback"><inheritdoc cref="InsertCallback(float, Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="InsertCallback(float, Action)"/></returns>
        public Element InsertCallback(float time, int order, Action callback) => InsertCallback(time, order, null, callback);

        /// <summary>
        /// <inheritdoc cref="InsertCallback(float, Action)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="InsertCallback(float, Action)" path="/param[@name='time']"/></param>
        /// <param name="name">Callback's name</param>
        /// <param name="callback"><inheritdoc cref="InsertCallback(float, Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="InsertCallback(float, Action)"/></returns>
        public Element InsertCallback(float time, string name, Action callback) => InsertCallback(time, _nextOrder, name, callback);

        /// <summary>
        /// <inheritdoc cref="InsertCallback(float, Action)"/> Uses passed <paramref name="order"/> for <paramref name="callback"/>.
        /// </summary>
        /// <param name="time"><inheritdoc cref="InsertCallback(float, Action)" path="/param[@name='time']"/></param>
        /// <param name="order"><inheritdoc cref="InsertCallback(float, int, Action)" path="/param[@name='order']"/></param>
        /// <param name="name"><inheritdoc cref="InsertCallback(float, string, Action)" path="/param[@name='name']"/></param>
        /// <param name="callback"><inheritdoc cref="InsertCallback(float, Action)" path="/param[@name='callback']"/></param>
        /// <returns><inheritdoc cref="InsertCallback(float, Action)"/></returns>
        public Element InsertCallback(float time, int order, string name, Action callback) => Insert(time, order, new Callback(name, callback));
        #endregion

        #region Adding intervals
        /// <summary>
        /// Adds an empty <see cref="Interval"/> to the left of all elements in the sequence.
        /// </summary>
        /// <param name="duration">Interval length in seconds.</param>
        /// <returns><see cref="Element"/> which represent the interval.</returns>
        public Element PrependInterval(float duration) => PrependInterval(null, duration);

        /// <summary>
        /// <inheritdoc cref="PrependInterval(float)"/>
        /// </summary>
        /// <param name="name">Interval's name.</param>
        /// <param name="duration"><inheritdoc cref="PrependInterval(float)"/></param>
        /// <returns><inheritdoc cref="PrependInterval(float)"/></returns>
        public Element PrependInterval(string name, float duration) => Prepend(new Interval(name, duration));

        /// <summary>
        /// Adds an empty <see cref="Interval"/> to the right of all elements in the sequence.
        /// </summary>
        /// <param name="duration">Interval length in seconds.</param>
        /// <returns><see cref="Element"/> which represent the interval.</returns>
        public Element AppendInterval(float duration) => AppendInterval(null, duration);

        /// <summary>
        /// <inheritdoc cref="AppendInterval(float)"/>
        /// </summary>
        /// <param name="name">Interval's name.</param>
        /// <param name="duration"><inheritdoc cref="AppendInterval(float)"/></param>
        /// <returns><inheritdoc cref="AppendInterval(float)"/></returns>
        public Element AppendInterval(string name, float duration) => Append(new Interval(name, duration));

        /// <summary>
        /// Inserts an empty <see cref="Interval"/> into the specified <paramref name="time"/> of the sequence.
        /// </summary>
        /// <param name="time">Time where to insert.</param>
        /// <param name="duration">Interval length in seconds.</param>
        /// <returns><see cref="Element"/> which represent the interval.</returns>
        public Element InsertInterval(float time, float duration) => InsertInterval(time, null, duration);

        /// <summary>
        /// <inheritdoc cref="InsertInterval(float, float)"/>
        /// </summary>
        /// <param name="time"><inheritdoc cref="InsertInterval(float, float)" path="/param[@name='time']"/></param>
        /// <param name="name">Interval's name.</param>
        /// <param name="duration"><inheritdoc cref="InsertInterval(float, float)" path="/param[@name='duration']"/></param>
        /// <returns><inheritdoc cref="InsertInterval(float, float)"/></returns>
        public Element InsertInterval(float time, string name, float duration) => Insert(time, new Interval(name, duration));
        #endregion

        /// <summary>
        /// State changed handler, needed to recalculate phase events for changed playable element 
        /// </summary>
        /// <param name="playable">Observable playable.</param>
        private void Playable_StateChanged(Playable playable)
        {
            foreach (var element in GetElements(playable))
            {
                RemoveElement(element);
                Insert(element.StartTime, element.Order, element.Playable);
            }
        }

        #region Containing elements
        /// <summary>
        /// Checks if there is an element containing a playable with the specified <paramref name="name"/> in the sequence.
        /// </summary>
        /// <param name="name">Playable name.</param>
        /// <returns><see langword="true"/> if element containing a playable with given <paramref name="name"/> exists.</returns>
        public bool Contains(string name) => GetElement(name) != null;

        /// <summary>
        /// Checks if there is an element containing the specified <paramref name="playable"/> in the sequence.
        /// </summary>
        /// <param name="playable">The playable you are looking for.</param>
        /// <returns><see langword="true"/> if element containing a playable exists.</returns>
        public bool Contains(IPlayable playable) => GetElement(playable) != null;

        /// <summary>
        /// Checks if the specified <paramref name="element"/> is in the sequence.
        /// </summary>
        /// <param name="element">The element you are looking for.</param>
        /// <returns><see langword="true"/> if element exists.</returns>
        public bool Contains(Element element) => _elements.Contains(element);
        #endregion

        #region Geting elements
        /// <summary>
        /// Finds the leftmost element in the sequence.
        /// </summary>
        /// <returns>The leftmost element in the sequence.</returns>
        public Element GetLeftmostElement() => _elements.FirstOrDefault(el => el.StartTime.Approximately(_elements.Min(el => el.StartTime)));

        /// <summary>
        /// Finds the leftmost elements in the sequence.
        /// </summary>
        /// <returns>The leftmost elements in the sequence.</returns>
        public List<Element> GetLeftmostElements()
        {
            if (_elements.Count == 0)
                return new List<Element>(0);

            return _elements.Where(el => el.StartTime.Approximately(_elements.Min(el => el.StartTime))).ToList();
        }

        /// <summary>
        /// Finds the rightmost element in the sequence.
        /// </summary>
        /// <returns>Thertightmost element in the sequence.</returns>
        public Element GetRightmostElement() => _elements.FirstOrDefault(el => el.EndTime.Approximately(_elements.Max(el => el.EndTime)));

        /// <summary>
        /// Finds the rightmost elements in the sequence.
        /// </summary>
        /// <returns>The rightmost elements in the sequence.</returns>
        public List<Element> GetRightmostElements()
        {
            if (_elements.Count == 0)
                return new List<Element>(0);

            return _elements.Where(el => el.EndTime.Approximately(_elements.Max(el => el.EndTime))).ToList();
        }

        /// <summary>
        /// Finds the first element that contains the specified <paramref name="playable"/>.
        /// </summary>
        /// <param name="playable">The playable you are looking for.</param>
        /// <returns>Element that contains the specified playable.</returns>
        public Element GetElement(IPlayable playable) => _elements.FirstOrDefault(el => el.Playable == playable);

        /// <summary>
        /// Finds all elements that contains the specified <paramref name="playable"/>.
        /// </summary>
        /// <param name="playable">The playable you are looking for.</param>
        /// <returns>Elements that contains the specified playable.</returns>
        public List<Element> GetElements(IPlayable playable) => _elements.Where(el => el.Playable == playable).ToList();

        /// <summary>
        /// Finds the first element that contains playable with the specified <paramref name="name"/>. 
        /// </summary>
        /// <param name="name">Playable name.</param>
        /// <returns>Element that contains playable with the specified <paramref name="name"/>.</returns>
        public Element GetElement(string name) => _elements.FirstOrDefault(el => el.Playable.Name == name);

        /// <summary>
        /// Finds all elements that contains playable with the specified <paramref name="name"/>. 
        /// </summary>
        /// <param name="name">Playable name.</param>
        /// <returns>Elements that contains playable with the specified <paramref name="name"/>.</returns>
        public List<Element> GetElements(string name) => _elements.Where(el => el.Playable.Name == name).ToList();

        /// <summary>
        /// Finds an element with the specified <paramref name="order"/>.
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Element with the specified <paramref name="order"/>.</returns>
        public Element GetElement(int order) => _elements[order];
        #endregion

        #region Removing elements
        /// <summary>
        /// Deletes all elements with the specified <paramref name="playable"/>.
        /// </summary>
        /// <param name="playable">The playable you want to delete.</param>
        /// <returns>Number of deleted elements.</returns>
        public int Remove(IPlayable playable)
        {
            var elements = GetElements(playable);
            Remove(elements);

            return elements.Count;
        }

        /// <summary>
        /// Deletes all elements with the specified <paramref name="playables"/>.
        /// </summary>
        /// <param name="playables">The playables you want to delete.</param>
        /// <returns>Number of deleted elements.</returns>
        public int Remove(IEnumerable<IPlayable> playables)
        {
            var count = 0;

            foreach (var playable in playables)
                count += Remove(playable);

            return count;
        }

        /// <summary>
        /// <inheritdoc cref="Remove(IEnumerable{IPlayable})"/>
        /// </summary>
        /// <param name="playables"><inheritdoc cref="Remove(IEnumerable{IPlayable})"/></param>
        /// <returns><inheritdoc cref="Remove(IEnumerable{IPlayable})"/></returns>
        public int Remove(params IPlayable[] playables) => Remove((IEnumerable<IPlayable>)playables);

        /// <summary>
        /// Deletes all elements containings a playable with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Playable's name you want to delete.</param>
        /// <returns>Number of deleted elements.</returns>
        public int Remove(string name)
        {
            var elements = GetElements(name);
            Remove(elements);

            return elements.Count;
        }

        /// <summary>
        /// Deletes all elements containings a playables with the specified <paramref name="names"/>.
        /// </summary>
        /// <param name="names">Playables names you want to delete.</param>
        /// <returns>Number of deleted elements.</returns>
        public int Remove(IEnumerable<string> names)
        {
            var count = 0;

            foreach (var name in names)
                count += Remove(name);

            return count;
        }

        /// <summary>
        /// <inheritdoc cref="Remove(IEnumerable{string})"/>
        /// </summary>
        /// <param name="names"><inheritdoc cref="Remove(IEnumerable{string})"/></param>
        /// <returns><inheritdoc cref="Remove(IEnumerable{string})"/></returns>
        public int Remove(params string[] names) => Remove((IEnumerable<string>)names);

        /// <summary>
        /// Deletes the element with the specified order.
        /// </summary>
        /// <param name="order">Element's order you want to delete.</param>
        public void Remove(int order) => RemoveElement(GetElement(order));

        /// <summary>
        /// Deletes the element.
        /// </summary>
        /// <param name="element">Element you want to delete.</param>
        /// <exception cref="ArgumentException">Throwed when element not exist in sequence.</exception>
        public void Remove(Element element)
        {
            if (!_elements.Contains(element))
                throw new ArgumentException($"{Type} \"{Name}\": The element with hash code \"{element.GetHashCode()}\" passed for removing does not exist in the sequence");

            RemoveElement(element);
        }

        /// <summary>
        /// Deletes elements.
        /// </summary>
        /// <param name="elements">Elements you want to delete.</param>
        public void Remove(IEnumerable<Element> elements)
        {
            foreach (var element in elements)
                Remove(element);
        }

        /// <summary>
        /// <inheritdoc cref="Remove(IEnumerable{Element})"/>
        /// </summary>
        /// <param name="elements"><inheritdoc cref="Remove(IEnumerable{Element})"/></param>
        public void Remove(params Element[] elements) => Remove((IEnumerable<Element>)elements);

        /// <summary>
        /// Deletes elements that satisfy the condition.
        /// </summary>
        /// <param name="predicate">The condition.</param>
        /// <returns>Number of deleted elements.</returns>
        public int RemoveAll(Predicate<Element> predicate)
        {
            var count = 0;

            for (int i = 0; i < _elements.Count; i++)
            {
                var element = _elements[i];

                if (predicate(element))
                {
                    RemoveElement(element);
                    ++count;
                    --i;
                }
            }

            return count;
        }

        /// <summary>
        /// Delete all elements.
        /// </summary>
        /// <returns>Number of deleted elements</returns>
        public int Clear()
        {
            var removed = _elements.Count;

            while (_elements.Count != 0)
                RemoveElement(_elements[0]);

            _nextOrder = 0;
            LoopDuration = 0f;

            return removed;
        }

        /// <summary>
        /// Remove element and all his phase events in chronolines.
        /// </summary>
        /// <param name="element">Element to remove</param>
        private void RemoveElement(Element element)
        {
            // Interval objects not participate in chronolines.
            if (element.Playable.Type != Type.Interval)
            {
                var chronolines = _chronolines.Where(cl => cl.Time >= element.StartTime && cl.Time <= element.EndTime).ToList();

                foreach (var chronoline in chronolines)
                {
                    chronoline.RemovePhaseEventsForElement(element);

                    if (!chronoline.HasUsefulEvents())
                        _chronolines.Remove(chronoline);
                }
            }

            _elements.Remove(element);
            element.Sequence = null;

            // Decrease order on all elements next to the current.
            for (int i = element.Order; i < _elements.Count; i++)
                _elements[i].SetOrder(_elements[i].Order - 1);

            LoopDuration = GetRightmostElement()?.EndTime ?? 0f;

            // We Unsusbcribe from playable state chaned event only if this playable no more exist in sequence.
            if (GetElements(element.Playable).Count == 0)
                ((Playable)element.Playable).StateChanged -= Playable_StateChanged;
        }
        #endregion

        #region Changing elements
        private void ChangeElementStartTime(Element element, float startTime)
        {
            startTime = Mathf.Max(startTime, 0f);

            if (element.StartTime.Approximately(startTime))
                return;

            RemoveElement(element);
            element.SetStartTime(startTime);
            InsertElement(element);
        }

        private void ChangeElementOrder(Element element, int order)
        {
            order = Mathf.Clamp(order, 0, _elements.Count);

            if (element.Order == order)
                return;

            RemoveElement(element);
            element.SetOrder(order);
            InsertElement(element);
        }
        #endregion

        #region Swaping elements
        /// <summary>
        /// Swaps two elements by theys orders.
        /// </summary>
        /// <param name="orderA">Order of first element.</param>
        /// <param name="orderB">Order of second element.</param>
        public void Swap(int orderA, int orderB)
        {
            if (orderA == orderB)
                return;

            if (orderA > orderB)
                (orderA, orderB) = (orderB, orderA);

            var (elementA, elementB) = (GetElement(orderA), GetElement(orderB));

            RemoveElement(elementA);
            RemoveElement(elementB);

            (elementA.Order, elementB.Order) = (orderB, orderA);

            InsertElement(elementB);
            InsertElement(elementA);
        }

        /// <summary>
        /// Swaps two elements.
        /// </summary>
        /// <param name="elementA">First element.</param>
        /// <param name="elementB">Second element.</param>
        public void Swap(Element elementA, Element elementB)
        {
            if (elementA == elementB)
                return;

            if (elementA.Order > elementB.Order)
                (elementA, elementB) = (elementB, elementA);

            Remove(elementA);
            Remove(elementB);

            (elementA.Order, elementB.Order) = (elementB.Order, elementA.Order);

            InsertElement(elementB);
            InsertElement(elementA);
        }
        #endregion

        #region Before loop starting
        protected override void BeforeStarting(Direction direction, int loop, int parentContinueLoopIndex, int continueMaxLoopsCount) => BeforeStarting(direction, LoopResetBehaviour, loop, parentContinueLoopIndex, continueMaxLoopsCount);

        private void BeforeStarting(Direction direction, LoopResetBehaviour loopResetBehaviour, int loop, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            if (loopResetBehaviour == LoopResetBehaviour.Skip)
            {
                for (int i = 0; i < _elements.Count; i++)
                    _elements[i].Playable.SkipTo(direction == Direction.Forward ? 0f : Duration);

                return;
            }

            if (LoopType == LoopType.Continue)
            {
                parentContinueLoopIndex = parentContinueLoopIndex * LoopsCount + loop;
                continueMaxLoopsCount *= LoopsCount;
            }

            if (!(LoopType == LoopType.Mirror && direction == Direction.Backward))
                parentContinueLoopIndex = continueMaxLoopsCount - parentContinueLoopIndex - 1;

            //Debug.Log($"<color=#FF8888><b>[{Name}] Before starting: loop {loop} {direction} {LoopType} {loopResetBehaviour} {parentContinueLoopIndex} {continueMaxLoopsCount}</b></color>");

            if (LoopType != LoopType.Mirror)
            {
                for (int i = 0; i < _elements.Count; i++)
                {
                    var element = _elements[i];

                    var (backwardTime, forwardTime) = element.Playable.Duration.Approximately(0f) ? (-1f, 1f) : (0f, element.Playable.Duration);
                    var time = direction == Direction.Forward ? backwardTime : forwardTime;

                    ((Playable)element.Playable).RewindTo(time, parentContinueLoopIndex, continueMaxLoopsCount, false);
                }
            }
            else
            {
                for (int i = 0; i < _elements.Count; i++)
                {
                    var element = _elements[i];

                    var time = element.Playable.Duration.Approximately(0f) ? -1f : 0f;
                    ((Playable)element.Playable).RewindTo(time, parentContinueLoopIndex, continueMaxLoopsCount, false);
                }
            }

            //Debug.Log($"<color=#88FFFF><b>[{Name}] Before starting completed</b></color>");
        }
        #endregion

        #region Skip
        protected override Playable SkipTimeTo(float time)
        {
            // if loop duration is zero, then played time will also always be zero,
            // so there is no point in assigning to it.
            if (time.Approximately(PlayedTime) || LoopDuration.Approximately(0f))
                return this;

            var (startTime, endTime, direction) = time > PlayedTime ? (PlayedTime, time, Direction.Forward) : (Duration - PlayedTime, Duration - time, Direction.Backward);
            var loopedPlayedTime = LoopTime(PlayedTime);

            var playedLoop = (int)(startTime / LoopDuration);
            var timeLoop = (int)(endTime / LoopDuration);

            // Loop started phase
            if (startTime.Approximately(playedLoop * LoopDuration))
            {
                BeforeStarting(direction, LoopResetBehaviour.Skip, playedLoop, 0, 1);
                loopedPlayedTime = 0f;
            }

            // Intermediate phase
            for (int i = playedLoop + 1; i <= timeLoop - 1; i++)
            {
                SkipHandler(loopedPlayedTime, playedLoop - 1, direction);

                BeforeStarting(direction, LoopResetBehaviour.Skip, playedLoop, 0, 1);
                loopedPlayedTime = 0f;
            }

            // Loop completed phase.
            if (endTime.Approximately(timeLoop * LoopDuration))
                SkipHandler(loopedPlayedTime, LoopDuration, direction);
            else // Loop update phases.
            {
                // Last intermediate loop phase. For example, when we start from
                // middle looped position and ended on other middle looped position.
                if (timeLoop - playedLoop > 0)
                {
                    SkipHandler(loopedPlayedTime, LoopDuration, direction);

                    BeforeStarting(direction, LoopResetBehaviour.Skip, timeLoop, 0, 1);
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
                // second expression in end of two functions below is for playables with zero duration and which placed at end of loop.
                bool CompareZeroForward(Element element, float start, float end) => (element.StartTime < end && element.EndTime >= start) || (end.Approximately(LoopDuration) && element.StartTime.Approximately(end));

                bool CompareZeroBackward(Element element, float start, float end) => (element.EndTime > end && element.StartTime <= start) || (end.Approximately(0f) && element.StartTime.Approximately(0f));

                bool CompareForward(Element element, float start, float end) => element.StartTime < end && element.EndTime > start;

                bool CompareBackward(Element element, float start, float end) => element.EndTime > end && element.StartTime < start;

                if (direction == Direction.Forward)
                {
                    for (int i = 0; i < _elements.Count; i++)
                    {
                        var element = _elements[i];

                        if (element.Playable.Duration.Approximately(0f) && CompareZeroForward(element, start, end))
                            _elementsBuffer.Add(element);
                        else if (!element.Playable.Duration.Approximately(0f) && CompareForward(element, start, end))
                            _elementsBuffer.Add(element);
                    }
                }
                else
                {
                    for (int i = 0; i < _elements.Count; i++)
                    {
                        var element = _elements[i];

                        if (element.Playable.Duration.Approximately(0f) && CompareZeroBackward(element, start, end))
                            _elementsBuffer.Add(element);
                        else if (!element.Playable.Duration.Approximately(0f) && CompareBackward(element, start, end))
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

        #region Rewind
        private void CheckAndIncreaseContinueParameters(ref int parentContinueLoopIndex, ref int continueMaxLoopsCount, int loop)
        {
            if (LoopType != LoopType.Continue)
                return;

            parentContinueLoopIndex = parentContinueLoopIndex * LoopsCount + loop;
            continueMaxLoopsCount *= LoopsCount;
        }

        protected override void RewindZeroHandler(int loop, float loopedNormalizedTime, Direction direction, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            // This is avoid situation when we jump to the same position.
            if (_lastLoopedNormalizedTime.Approximately(loopedNormalizedTime))
                return;

            if (_lastLoopedNormalizedTime.Approximately(1f) && loopedNormalizedTime.Approximately(0f))
            {
                _lastLoopedNormalizedTime = 0;
                return;
            }

            // If sequence is empty, than there is nothing to handle.
            if (_chronolines.Count != 0)
            {
                CheckAndIncreaseContinueParameters(ref parentContinueLoopIndex, ref continueMaxLoopsCount, loop);

                if (LoopType != LoopType.Mirror)
                    // It is not matter what chain (forward or backward) we use when sequence is zeroed.
                    _chronolines[0].Chains.Forward.CallAllEvents(direction, emitEvents, parentContinueLoopIndex, continueMaxLoopsCount);
                else
                {
                    var (forwardParentContinueLoopIndex, backwardParentContinueLoopIndex) = direction == Direction.Forward ? (parentContinueLoopIndex, continueMaxLoopsCount - parentContinueLoopIndex - 1) : (continueMaxLoopsCount - parentContinueLoopIndex - 1, parentContinueLoopIndex);

                    // If it is first half of mirror mode, than we move forward.
                    if (loopedNormalizedTime.Approximately(0.5f))
                        _chronolines[0].Chains.Forward.CallAllEvents(Direction.Forward, emitEvents, forwardParentContinueLoopIndex, continueMaxLoopsCount);
                    else // else - backward.
                        _chronolines[0].Chains.Backward.CallAllEvents(Direction.Backward, emitEvents, backwardParentContinueLoopIndex, continueMaxLoopsCount);
                }
            }

            _lastLoopedNormalizedTime = loopedNormalizedTime;
        }

        protected override void RewindHandler(int loop, float loopedTime, Direction direction, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount)
        {
            #region Local functions
            bool RemapTimes(float loopedPlayedTime, float loopedTime, Ease ease, out (float loopedPlayedTime, float loopedTime) remaped)
            {
                remaped.loopedPlayedTime = Mathf.Clamp(ease.Remap(loopedPlayedTime / LoopDuration) * LoopDuration, 0f, LoopDuration);
                remaped.loopedTime = Mathf.Clamp(ease.Remap(loopedTime / LoopDuration) * LoopDuration, 0f, LoopDuration);

                return !remaped.loopedPlayedTime.Approximately(remaped.loopedTime);
            }

            void HandleChronolinesOnForwardInterval(List<Chronoline> chronolines, float remapedLoopedPlayedTime, float remapedLoopedTime, float loopDuration, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount, ref Chronoline lastChronoline)
            {
                for (int i = 0; i < chronolines.Count; i++)
                {
                    var chronoline = chronolines[i];

                    // If chronoline stay back from start time, than we just skip it.
                    if (chronoline.Time < remapedLoopedPlayedTime)
                        continue;

                    // If chronoline start in front if end time, than we need stop cycle.
                    if (chronoline.Time > remapedLoopedTime)
                        break;

                    // If chronoline stay at start time, than we need handle only post events.
                    if (chronoline.Time.Approximately(remapedLoopedPlayedTime))
                        chronoline.Chains.Forward.CallPostEvents(Direction.Forward, emitEvents, parentContinueLoopIndex, continueMaxLoopsCount);
                    else if (chronoline.Time.Approximately(remapedLoopedTime))
                    {
                        // If chronoline stay at end of loop, than we need call all events.
                        if (remapedLoopedTime.Approximately(loopDuration))
                            chronoline.Chains.Forward.CallAllEvents(Direction.Forward, emitEvents, parentContinueLoopIndex, continueMaxLoopsCount);
                        else
                            chronoline.Chains.Forward.CallPreEvents(Direction.Forward, emitEvents, parentContinueLoopIndex, continueMaxLoopsCount);
                    }
                    else // Otherwise means that chronoline is between start and end, and we need call all events.
                        chronoline.Chains.Forward.CallAllEvents(Direction.Forward, emitEvents, parentContinueLoopIndex, continueMaxLoopsCount);

                    lastChronoline = chronoline;
                }
            }

            void HandleChronolinesOnBackwardInterval(List<Chronoline> chronolines, float remapedLoopedPlayedTime, float remapedLoopedTime, float loopDuration, bool emitEvents, int parentContinueLoopIndex, int continueMaxLoopsCount, ref Chronoline lastChronoline)
            {
                for (int i = chronolines.Count - 1; i >= 0; i--)
                {
                    var chronoline = chronolines[i];
                    var backwardChronolineTime = loopDuration - chronoline.Time;

                    // If chronoline stay back from start time, than we just skip it.
                    if (backwardChronolineTime < remapedLoopedPlayedTime)
                        continue;

                    // If chronoline start in front if end time, than we need stop cycle.
                    if (backwardChronolineTime > remapedLoopedTime)
                        break;

                    // If chronoline stay at start time, than we need handle only post events.
                    if (backwardChronolineTime.Approximately(remapedLoopedPlayedTime))
                        chronoline.Chains.Backward.CallPostEvents(Direction.Backward, emitEvents, parentContinueLoopIndex, continueMaxLoopsCount);
                    else if (backwardChronolineTime.Approximately(remapedLoopedTime))
                    {
                        // If chronoline stay at end of loop, than we need call all events.
                        if (remapedLoopedTime.Approximately(loopDuration))
                            chronoline.Chains.Backward.CallAllEvents(Direction.Backward, emitEvents, parentContinueLoopIndex, continueMaxLoopsCount);
                        else
                            chronoline.Chains.Backward.CallPreEvents(Direction.Backward, emitEvents, parentContinueLoopIndex, continueMaxLoopsCount);
                    }
                    else // Otherwise means that chronoline is between start and end, and we need call all events.
                        chronoline.Chains.Backward.CallAllEvents(Direction.Backward, emitEvents, parentContinueLoopIndex, continueMaxLoopsCount);

                    lastChronoline = chronoline;
                }
            }

            void HandleUpdatePhases(float time, Direction direction, Func<float, Element, float> playedTimeCalcualtor, bool emitEvents, int continueRepeatIndex, int continueMaxLoopsCount)
            {
                for (int i = 0; i < _elements.Count; i++)
                {
                    var element = _elements[i];

                    if (element.Playable.Type == Type.Interval || time <= element.StartTime || time >= element.EndTime)
                        continue;

                    var playedTime = playedTimeCalcualtor(time, element);

                    if (emitEvents)
                        ((Playable)element.Playable).HandlePhaseLoopUpdate(playedTime, (int)(playedTime / element.Playable.LoopDuration), playedTime % element.Playable.LoopDuration, direction, continueRepeatIndex, continueMaxLoopsCount);
                    else
                        ((Playable)element.Playable).HandlePhaseLoopUpdateNoEvents(playedTime, (int)(playedTime / element.Playable.LoopDuration), playedTime % element.Playable.LoopDuration, direction, continueRepeatIndex, continueMaxLoopsCount);
                }
            }

            void HandleForwardBackwardIntervals((float loopedPlayedTime, float loopedTime) remaped, float forwardUpdateTime, float backwardUpdateTime, int forwardParentContinueLoopIndex, int backwardParentContinueLoopIndex, ref Chronoline lastChronoline)
            {
                if (remaped.loopedTime > remaped.loopedPlayedTime)
                {
                    HandleChronolinesOnForwardInterval(_chronolines, remaped.loopedPlayedTime, remaped.loopedTime, LoopDuration, emitEvents, forwardParentContinueLoopIndex, continueMaxLoopsCount, ref lastChronoline);

                    if (lastChronoline == null || !lastChronoline.Time.Approximately(loopedTime))
                        HandleUpdatePhases(forwardUpdateTime, Direction.Forward, _forwardPlayedTimeCalcualtor, emitEvents, forwardParentContinueLoopIndex, continueMaxLoopsCount);
                }
                else
                {
                    HandleChronolinesOnBackwardInterval(_chronolines, remaped.loopedPlayedTime, remaped.loopedTime, LoopDuration, emitEvents, backwardParentContinueLoopIndex, continueMaxLoopsCount, ref lastChronoline);

                    if (lastChronoline == null || !lastChronoline.Time.Approximately(loopedTime))
                        HandleUpdatePhases(backwardUpdateTime, Direction.Backward, _backwardPlayedTimeCalcualtor, emitEvents, backwardParentContinueLoopIndex, continueMaxLoopsCount);
                }
            }

            void HandleBackwardForwardIntervals((float loopedPlayedTime, float loopedTime) remaped, float backwardUpdateTime, float forwardUpdateTime, int backwardParentContinueLoopIndex, int forwardParentContinueLoopIndex, ref Chronoline lastChronoline)
            {
                if (remaped.loopedTime > remaped.loopedPlayedTime)
                {
                    HandleChronolinesOnBackwardInterval(_chronolines, remaped.loopedPlayedTime, remaped.loopedTime, LoopDuration, emitEvents, backwardParentContinueLoopIndex, continueMaxLoopsCount, ref lastChronoline);

                    if (lastChronoline == null || !lastChronoline.Time.Approximately(loopedTime))
                        HandleUpdatePhases(backwardUpdateTime, Direction.Backward, _backwardPlayedTimeCalcualtor, emitEvents, backwardParentContinueLoopIndex, continueMaxLoopsCount);
                }
                else
                {
                    HandleChronolinesOnForwardInterval(_chronolines, remaped.loopedPlayedTime, remaped.loopedTime, LoopDuration, emitEvents, forwardParentContinueLoopIndex, continueMaxLoopsCount, ref lastChronoline);

                    if (lastChronoline == null || !lastChronoline.Time.Approximately(loopedTime))
                        HandleUpdatePhases(forwardUpdateTime, Direction.Forward, _forwardPlayedTimeCalcualtor, emitEvents, forwardParentContinueLoopIndex, continueMaxLoopsCount);
                }
            }
            #endregion

            Chronoline lastChronoline = null;

            if (direction == Direction.Forward)
            {
                var nextPlayedTime = loop * LoopDuration + loopedTime;

                // If we jump to the same position, than we don't need handle this situation.
                if (nextPlayedTime.Approximately(PlayedTime))
                    return;

                CheckAndIncreaseContinueParameters(ref parentContinueLoopIndex, ref continueMaxLoopsCount, loop);

                var loopedPlayedTime = PlayedTime % LoopDuration;

                if (LoopType != LoopType.Mirror)
                {
                    if (!RemapTimes(loopedPlayedTime, loopedTime, Ease, out (float loopedPlayedTime, float loopedTime) remaped))
                        return;

                    var (forwardParentContinueLoopIndex, backwardParentContinueLoopIndex) = direction == Direction.Forward ? (parentContinueLoopIndex, continueMaxLoopsCount - parentContinueLoopIndex - 1) : (continueMaxLoopsCount - parentContinueLoopIndex - 1, parentContinueLoopIndex);
                    HandleForwardBackwardIntervals(remaped, remaped.loopedTime, remaped.loopedPlayedTime, forwardParentContinueLoopIndex, backwardParentContinueLoopIndex, ref lastChronoline);
                }
                else
                {
                    loopedPlayedTime *= 2f;
                    loopedTime *= 2;

                    var (forwardParentContinueLoopIndex, backwardParentContinueLoopIndex) = direction == Direction.Forward ? (parentContinueLoopIndex, continueMaxLoopsCount - parentContinueLoopIndex - 1) : (continueMaxLoopsCount - parentContinueLoopIndex - 1, parentContinueLoopIndex);

                    // Forward handling.
                    if (loopedPlayedTime < LoopDuration)
                    {
                        if (!RemapTimes(loopedPlayedTime, loopedTime, Ease, out (float loopedPlayedTime, float loopedTime) remaped))
                            return;

                        HandleForwardBackwardIntervals(remaped, remaped.loopedTime, remaped.loopedPlayedTime, forwardParentContinueLoopIndex, backwardParentContinueLoopIndex, ref lastChronoline);
                    }
                    else // Backward handling
                    {
                        loopedPlayedTime %= LoopDuration;
                        loopedTime = LoopTime(loopedTime);

                        if (!RemapTimes(loopedPlayedTime, loopedTime, Ease.Invertion.With(Ease), out (float loopedPlayedTime, float loopedTime) remaped))
                            return;

                        HandleBackwardForwardIntervals(remaped, LoopDuration - remaped.loopedTime, LoopDuration - remaped.loopedPlayedTime, backwardParentContinueLoopIndex, forwardParentContinueLoopIndex, ref lastChronoline);
                    }
                }
            }
            else
            {
                var nextPlayedTime = Duration - (loop * LoopDuration + loopedTime);

                // If we jump to the same position, than we don't need handle this situation.
                if (nextPlayedTime.Approximately(PlayedTime))
                    return;

                CheckAndIncreaseContinueParameters(ref parentContinueLoopIndex, ref continueMaxLoopsCount, loop);

                var loopedPlayedTime = LoopDuration - LoopTime(PlayedTime);

                if (LoopType != LoopType.Mirror)
                {
                    if (!RemapTimes(loopedPlayedTime, loopedTime, Ease.Invertion.With(Ease), out (float loopedPlayedTime, float loopedTime) remaped))
                        return;

                    var (forwardParentContinueLoopIndex, backwardParentContinueLoopIndex) = direction == Direction.Forward ? (parentContinueLoopIndex, continueMaxLoopsCount - parentContinueLoopIndex - 1) : (continueMaxLoopsCount - parentContinueLoopIndex - 1, parentContinueLoopIndex);
                    HandleBackwardForwardIntervals(remaped, LoopDuration - remaped.loopedTime, LoopDuration - remaped.loopedPlayedTime, backwardParentContinueLoopIndex, forwardParentContinueLoopIndex, ref lastChronoline);
                }
                else
                {
                    loopedPlayedTime *= 2f;
                    loopedTime *= 2;

                    var (forwardParentContinueLoopIndex, backwardParentContinueLoopIndex) = direction == Direction.Forward ? (parentContinueLoopIndex, continueMaxLoopsCount - parentContinueLoopIndex - 1) : (continueMaxLoopsCount - parentContinueLoopIndex - 1, parentContinueLoopIndex);

                    // Forward handling.
                    if (loopedPlayedTime < LoopDuration)
                    {
                        if (!RemapTimes(loopedPlayedTime, loopedTime, Ease, out (float loopedPlayedTime, float loopedTime) remaped))
                            return;

                        HandleForwardBackwardIntervals(remaped, remaped.loopedTime, remaped.loopedPlayedTime, forwardParentContinueLoopIndex, backwardParentContinueLoopIndex, ref lastChronoline);
                    }
                    else // Backward handling
                    {
                        loopedPlayedTime %= LoopDuration;
                        loopedTime = LoopTime(loopedTime);

                        if (!RemapTimes(loopedPlayedTime, loopedTime, Ease.Invertion.With(Ease), out (float loopedPlayedTime, float loopedTime) remaped))
                            return;

                        HandleBackwardForwardIntervals(remaped, LoopDuration - remaped.loopedTime, LoopDuration - remaped.loopedPlayedTime, backwardParentContinueLoopIndex, forwardParentContinueLoopIndex, ref lastChronoline);
                    }
                }
            }
        }
        #endregion
    }
}