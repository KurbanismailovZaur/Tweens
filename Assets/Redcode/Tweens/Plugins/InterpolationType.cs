namespace Redcode.Tweens
{
	/// <summary>
	/// Represent type of interpolation which will be used in tweaks.
	/// </summary>
    public enum InterpolationType : byte
	{
		/// <summary>
		/// Use linear formula.
		/// </summary>
		Linear,

		/// <summary>
		/// Use spherical formula (useful for tweaking directions).
		/// </summary>
		Spherical
	}
}