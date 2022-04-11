namespace Redcode.Tweens
{
    /// <summary>
    /// Represent direction in which <see cref="IPlayable"/> or <see cref="Playable.IRepeater{T}"/> will be playing.
    /// </summary>
    public enum Direction : byte
	{
        /// <summary>
        /// Playing in forward direction.
        /// </summary>
		Forward,

        /// <summary>
        /// Playing in backward direction.
        /// </summary>
		Backward
	}
}