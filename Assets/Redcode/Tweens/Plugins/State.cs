namespace Redcode.Tweens
{
    /// <summary>
    /// Represent state of <c>Playable</c>.
    /// </summary>
    public enum State
	{
		/// <summary>
		/// <c>Playable</c> has never been played (or has been played, but then reseted again).
		/// </summary>
		Reseted,

		/// <summary>
		/// <c>Playable</c> playing right now.
		/// </summary>
		Playing,

		/// <summary>
		/// <c>Playable</c> paused.
		/// </summary>
		Paused,

		/// <summary>
		/// <c>Playable</c> complete playing.
		/// </summary>
		Completed
	}
}