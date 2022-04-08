using UnityEngine;

namespace Redcode.Extensions
{
    public static class Color32Extensions
    {
        #region With
        /// <summary>
        /// Set value to color's channel.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="channel">Channel index of the color.</param>
        /// <param name="value">Value to set.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 With(this Color32 color, int channel, byte value)
        {
            color[channel] = value;
            return color;
        }

        /// <summary>
        /// Set color's red channel value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="r">Value to set.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithR(this Color32 color, byte r) => With(color, 0, r);

        /// <summary>
        /// Set color's green channel value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="g">Value to set.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithG(this Color32 color, byte g) => With(color, 1, g);

        /// <summary>
        /// Set color's blue channel value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="b">Value to set.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithB(this Color32 color, byte b) => With(color, 2, b);

        /// <summary>
        /// Set color's alpha channel value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="a">Value to set.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithA(this Color32 color, byte a) => With(color, 3, a);

        /// <summary>
        /// Set values to color's channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="channel1">First channel index of the color.</param>
        /// <param name="value1">First channel value.</param>
        /// <param name="channel2">Second channel index of the color.</param>
        /// <param name="value2">Second channel value.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 With(this Color32 color, int channel1, byte value1, int channel2, byte value2)
        {
            color[channel1] = value1;
            color[channel2] = value2;

            return color;
        }

        /// <summary>
        /// Set color's red and green channels value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="r">Value to set in red channel.</param>
        /// <param name="g">Value to set in green channel.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithRG(this Color32 color, byte r, byte g) => With(color, 0, r, 1, g);

        /// <summary>
        /// Set color's red and blue channels value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="r">Value to set in red channel.</param>
        /// <param name="b">Value to set in blue channel.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithRB(this Color32 color, byte r, byte b) => With(color, 0, r, 2, b);

        /// <summary>
        /// Set color's red and alpha channels value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="r">Value to set in red channel.</param>
        /// <param name="a">Value to set in alpha channel.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithRA(this Color32 color, byte r, byte a) => With(color, 0, r, 3, a);

        /// <summary>
        /// Set color's green and blue channels value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="g">Value to set in green channel.</param>
        /// <param name="b">Value to set in blue channel.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithGB(this Color32 color, byte g, byte b) => With(color, 1, g, 2, b);

        /// <summary>
        /// Set color's green and alpha channels value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="g">Value to set in green channel.</param>
        /// <param name="a">Value to set in alpha channel.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithGA(this Color32 color, byte g, byte a) => With(color, 1, g, 3, a);

        /// <summary>
        /// Set color's blue and alpha channels value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="b">Value to set in blue channel.</param>
        /// <param name="a">Value to set in alpha channel.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithBA(this Color32 color, byte b, byte a) => With(color, 2, b, 3, a);

        /// <summary>
        /// Set values to color's channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="channel1">First channel index of the color.</param>
        /// <param name="value1">First channel value.</param>
        /// <param name="channel2">Second channel index of the color.</param>
        /// <param name="value2">Second channel value.</param>
        /// <param name="channel3">Third channel index of the color.</param>
        /// <param name="value3">Third channel value.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 With(this Color32 color, int channel1, byte value1, int channel2, byte value2, int channel3, byte value3)
        {
            color[channel1] = value1;
            color[channel2] = value2;
            color[channel3] = value3;

            return color;
        }

        /// <summary>
        /// Set color's red, green and blue channels value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="r">Value to set in red channel.</param>
        /// <param name="g">Value to set in green channel.</param>
        /// <param name="b">Value to set in blue channel.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithRGB(this Color32 color, byte r, byte g, byte b) => With(color, 0, r, 1, g, 2, b);

        /// <summary>
        /// Set color's red, green and alpha channels value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="r">Value to set in red channel.</param>
        /// <param name="g">Value to set in green channel.</param>
        /// <param name="a">Value to set in alpha channel.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithRGA(this Color32 color, byte r, byte g, byte a) => With(color, 0, r, 1, g, 3, a);

        /// <summary>
        /// Set color's red, blue and alpha channels value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="r">Value to set in red channel.</param>
        /// <param name="b">Value to set in blue channel.</param>
        /// <param name="a">Value to set in alpha channel.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithRBA(this Color32 color, byte r, byte b, byte a) => With(color, 0, r, 2, b, 3, a);

        /// <summary>
        /// Set color's green, blue and alpha channels value.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="g">Value to set in green channel.</param>
        /// <param name="b">Value to set in blue channel.</param>
        /// <param name="a">Value to set in alpha channel.</param>
        /// <returns>Changed copy of the color.</returns>
        public static Color32 WithGBA(this Color32 color, byte g, byte b, byte a) => With(color, 1, g, 2, b, 3, a);
        #endregion

        #region Get
        /// <summary>
        /// Gets <see cref="Vector2"/> color values by channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="channel1">First channel.</param>
        /// <param name="channel2">Second channel.</param>
        /// <returns><see cref="Vector2"/> color channels.</returns>
        public static Vector2 Get(this Color32 color, int channel1, int channel2) => new Vector2(color[channel1], color[channel2]);

        /// <summary>
        /// Gets <see cref="Vector2"/> by r and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector2"/> color channels.</returns>
        public static Vector2 GetRG(this Color32 color) => Get(color, 0, 1);

        /// <summary>
        /// Gets <see cref="Vector2"/> by r and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector2"/> color channels.</returns>
        public static Vector2 GetRB(this Color32 color) => Get(color, 0, 2);

        /// <summary>
        /// Gets <see cref="Vector2"/> by r and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector2"/> color channels.</returns>
        public static Vector2 GetRA(this Color32 color) => Get(color, 0, 3);

        /// <summary>
        /// Gets <see cref="Vector2"/> by g and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector2"/> color channels.</returns>
        public static Vector2 GetGR(this Color32 color) => Get(color, 1, 0);

        /// <summary>
        /// Gets <see cref="Vector2"/> by g and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector2"/> color channels.</returns>
        public static Vector2 GetGB(this Color32 color) => Get(color, 1, 2);

        /// <summary>
        /// Gets <see cref="Vector2"/> by g and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector2"/> color channels.</returns>
        public static Vector2 GetGA(this Color32 color) => Get(color, 1, 3);

        /// <summary>
        /// Gets <see cref="Vector2"/> by b and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector2"/> color channels.</returns>
        public static Vector2 GetBR(this Color32 color) => Get(color, 2, 0);

        /// <summary>
        /// Gets <see cref="Vector2"/> by b and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector2"/> color channels.</returns>
        public static Vector2 GetBG(this Color32 color) => Get(color, 2, 1);

        /// <summary>
        /// Gets <see cref="Vector2"/> by b and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector2"/> color channels.</returns>
        public static Vector2 GetBA(this Color32 color) => Get(color, 2, 3);

        /// <summary>
        /// Gets <see cref="Vector2"/> by a and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector2"/> color channels.</returns>
        public static Vector2 GetAR(this Color32 color) => Get(color, 3, 0);

        /// <summary>
        /// Gets <see cref="Vector2"/> by a and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector2"/> color channels.</returns>
        public static Vector2 GetAG(this Color32 color) => Get(color, 3, 1);

        /// <summary>
        /// Gets <see cref="Vector2"/> by a and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector2"/> color channels.</returns>
        public static Vector2 GetAB(this Color32 color) => Get(color, 3, 2);

        /// <summary>
        /// Gets <see cref="Vector3"/> by channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="channel1">First channel.</param>
        /// <param name="channel2">Second channel.</param>
        /// <param name="channel3">Third channel.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 Get(this Color32 color, int channel1, int channel2, int channel3) => new Vector3(color[channel1], color[channel2], color[channel3]);

        /// <summary>
        /// Gets <see cref="Vector3"/> by r, g and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetRGB(this Color32 color) => Get(color, 0, 1, 2);

        /// <summary>
        /// Gets <see cref="Vector3"/> by r, g and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetRGA(this Color32 color) => Get(color, 0, 1, 3);

        /// <summary>
        /// Gets <see cref="Vector3"/> by r, b and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetRBG(this Color32 color) => Get(color, 0, 2, 1);

        /// <summary>
        /// Gets <see cref="Vector3"/> by r, b and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetRBA(this Color32 color) => Get(color, 0, 2, 3);

        /// <summary>
        /// Gets <see cref="Vector3"/> by r, a and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetRAG(this Color32 color) => Get(color, 0, 3, 1);

        /// <summary>
        /// Gets <see cref="Vector3"/> by r, a and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetRAB(this Color32 color) => Get(color, 0, 3, 2);

        /// <summary>
        /// Gets <see cref="Vector3"/> by g, r and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetGRB(this Color32 color) => Get(color, 1, 0, 2);

        /// <summary>
        /// Gets <see cref="Vector3"/> by g, r and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetGRA(this Color32 color) => Get(color, 1, 0, 3);

        /// <summary>
        /// Gets <see cref="Vector3"/> by g, b and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetGBR(this Color32 color) => Get(color, 1, 2, 0);

        /// <summary>
        /// Gets <see cref="Vector3"/> by g, b and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetGBA(this Color32 color) => Get(color, 1, 2, 3);

        /// <summary>
        /// Gets <see cref="Vector3"/> by g, a and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetGAR(this Color32 color) => Get(color, 1, 3, 0);

        /// <summary>
        /// Gets <see cref="Vector3"/> by g, a and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetGAB(this Color32 color) => Get(color, 1, 3, 2);

        /// <summary>
        /// Gets <see cref="Vector3"/> by b, r and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetBRG(this Color32 color) => Get(color, 2, 0, 1);

        /// <summary>
        /// Gets <see cref="Vector3"/> by b, r and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetBRA(this Color32 color) => Get(color, 2, 0, 3);

        /// <summary>
        /// Gets <see cref="Vector3"/> by b, g and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetBGR(this Color32 color) => Get(color, 2, 1, 0);

        /// <summary>
        /// Gets <see cref="Vector3"/> by b, g and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetBGA(this Color32 color) => Get(color, 2, 1, 3);

        /// <summary>
        /// Gets <see cref="Vector3"/> by b, a and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetBAR(this Color32 color) => Get(color, 2, 3, 0);

        /// <summary>
        /// Gets <see cref="Vector3"/> by b, a and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetBAG(this Color32 color) => Get(color, 2, 3, 1);

        /// <summary>
        /// Gets <see cref="Vector3"/> by a, r and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetARG(this Color32 color) => Get(color, 3, 0, 1);

        /// <summary>
        /// Gets <see cref="Vector3"/> by a, r and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetARB(this Color32 color) => Get(color, 3, 0, 2);

        /// <summary>
        /// Gets <see cref="Vector3"/> by a, g and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetAGR(this Color32 color) => Get(color, 3, 1, 0);

        /// <summary>
        /// Gets <see cref="Vector3"/> by a, g and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetAGB(this Color32 color) => Get(color, 3, 1, 2);

        /// <summary>
        /// Gets <see cref="Vector3"/> by a, b and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetABR(this Color32 color) => Get(color, 3, 2, 0);

        /// <summary>
        /// Gets <see cref="Vector3"/> by a, b and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Vector3"/> color channels.</returns>
        public static Vector3 GetABG(this Color32 color) => Get(color, 3, 2, 1);

        /// <summary>
        /// Gets color by channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <param name="channel1">First channel.</param>
        /// <param name="channel2">Second channel.</param>
        /// <param name="channel3">Third channel.</param>
        /// <param name="channel4">Fourth channel.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color Get(this Color32 color, int channel1, int channel2, int channel3, int channel4) => new Color32(color[channel1], color[channel2], color[channel3], color[channel4]);

        /// <summary>
        /// Gets color by r, g, a and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetRGAB(this Color32 color) => Get(color, 0, 1, 3, 2);

        /// <summary>
        /// Gets color by r, b, g and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetRBGA(this Color32 color) => Get(color, 0, 2, 1, 3);

        /// <summary>
        /// Gets color by r, b, a and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetRBAG(this Color32 color) => Get(color, 0, 2, 3, 1);

        /// <summary>
        /// Gets color by r, a, g and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetRAGB(this Color32 color) => Get(color, 0, 3, 1, 2);

        /// <summary>
        /// Gets color by r, a, b and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetRABG(this Color32 color) => Get(color, 0, 3, 2, 1);

        /// <summary>
        /// Gets color by g, r, b and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetGRBA(this Color32 color) => Get(color, 1, 0, 2, 3);

        /// <summary>
        /// Gets color by g, r, a and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetGRAB(this Color32 color) => Get(color, 1, 0, 3, 2);

        /// <summary>
        /// Gets color by g, b, r and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetGBRA(this Color32 color) => Get(color, 1, 2, 0, 3);

        /// <summary>
        /// Gets color by g, b, a and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetGBAR(this Color32 color) => Get(color, 1, 2, 3, 0);

        /// <summary>
        /// Gets color by g, a, r and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetGARB(this Color32 color) => Get(color, 1, 3, 0, 2);

        /// <summary>
        /// Gets color by g, a, b and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetGABR(this Color32 color) => Get(color, 1, 3, 2, 0);

        /// <summary>
        /// Gets color by b, r, g and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetBRGA(this Color32 color) => Get(color, 2, 0, 1, 3);

        /// <summary>
        /// Gets color by b, r, a and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetBRAG(this Color32 color) => Get(color, 2, 0, 3, 1);

        /// <summary>
        /// Gets color by b, g, r and a channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetBGRA(this Color32 color) => Get(color, 2, 1, 0, 3);

        /// <summary>
        /// Gets color by b, g, a and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetBGAR(this Color32 color) => Get(color, 2, 1, 3, 0);

        /// <summary>
        /// Gets color by b, a, r and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetBARG(this Color32 color) => Get(color, 2, 3, 0, 1);

        /// <summary>
        /// Gets color by b, a, g and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetBAGR(this Color32 color) => Get(color, 2, 3, 1, 0);

        /// <summary>
        /// Gets color by a, r, g and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetARGB(this Color32 color) => Get(color, 3, 0, 1, 2);

        /// <summary>
        /// Gets color by a, r, b and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetARBG(this Color32 color) => Get(color, 3, 0, 2, 1);

        /// <summary>
        /// Gets color by a, g, r and b channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetAGRB(this Color32 color) => Get(color, 3, 1, 0, 2);

        /// <summary>
        /// Gets color by a, g, b and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetAGBR(this Color32 color) => Get(color, 3, 1, 2, 0);

        /// <summary>
        /// Gets color by a, b, r and g channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetABRG(this Color32 color) => Get(color, 3, 2, 0, 1);

        /// <summary>
        /// Gets color by a, b, g and r channels.
        /// </summary>
        /// <param name="color">Target color.</param>
        /// <returns><see cref="Color"/> color.</returns>
        public static Color GetABGR(this Color32 color) => Get(color, 3, 2, 1, 0);
        #endregion
    }
}