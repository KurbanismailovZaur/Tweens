using UnityEngine;

namespace Redcode.Tweens
{
    /// <summary>
    /// Represent time type for playing methods. <br/>If you want to play the animation independently
    /// of the <see cref="Time.timeScale"/> multiplier, use <see cref="TimeType.Unscaled"/>. 
    /// </summary>
    public enum TimeType
	{
		/// <summary>
		/// Play playables with <see cref="Time.timeScale"/>. <br/>
		/// If <see cref="Time.timeScale"/> will be 0, then animation will be frozen.
		/// </summary>
		Scaled,

		/// <summary>
		/// Play playables without respect to <see cref="Time.timeScale"/>. <br/>
		/// <see cref="Time.timeScale"/> will not affect to animation.
		/// </summary>
		Unscaled
	}
}