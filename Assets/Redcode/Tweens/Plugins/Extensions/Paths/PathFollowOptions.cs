namespace Redcode.Tweens.Extensions
{
	/// <summary>
	/// Represent path follow options.
	/// </summary>
    public enum PathFollowOptions
	{
		/// <summary>
		/// Don't use rotation.
		/// </summary>
		None,

		/// <summary>
		/// Use points rotation. Also interpolate rotation when between points.
		/// </summary>
		UsePointRotation,

		/// <summary>
		/// Use path direction as rotation.
		/// </summary>
		UsePathDirection
	}
}