namespace Redcode.Tweens
{
    /// <summary>
    /// Represent behaviour which applied to sequences before every loop start event.
    /// </summary>
    public enum LoopResetBehaviour : byte
	{
		/// <summary>
		/// Before every loop start event sequence will rewind all its elements to start state without emitting they events.
		/// </summary>
		Rewind,

		/// <summary>
		/// Before every loop start event sequence will skip all its elements to start state.
		/// </summary>
		Skip
	}
}