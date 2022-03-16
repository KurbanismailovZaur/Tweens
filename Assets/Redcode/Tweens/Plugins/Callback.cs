using System;

namespace Redcode.Tweens
{
    /// <summary>
    /// Represents the callback function that can be used in sequences.
    /// </summary>
    public class Callback : Playable<Callback>
    {
        public override Type Type => Type.Callback;

        private Action _callback;

        private bool _startPhaseFlag;

        /// <summary>
        /// Create callback.
        /// </summary>
        /// <param name="name">Name of the callback.</param>
        /// <param name="callback">Function which will be invoked when sequence playing.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="callback"/> is null.</exception>
        public Callback(string name, Action callback) : base(null, name, 0f) => _callback = callback ?? throw new ArgumentNullException(nameof(callback));

        protected override void BeforeStarting(Direction direction, int loop, int parentContinueLoopIndex, int continueMaxLoopsCount) => _startPhaseFlag = true;

        protected override void RewindZeroHandler(int loop, float loopedNormalizedTime, Direction direction, bool emitEvents, int parentLoop, int continueMaxLoopsCount)
        {
            if (!_startPhaseFlag || !emitEvents)
                return;

            _callback();
            _startPhaseFlag = false;
        }
    }
}