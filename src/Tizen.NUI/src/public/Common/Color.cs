/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using Tizen.NUI.Binding;
using System.ComponentModel;
using System.Globalization;

namespace Tizen.NUI
{
    /// <summary>
    /// The Color class.
    /// This class represents a color using red, green, blue, and alpha components.
    /// It provides methods to create and manipulate colors.
    /// </summary>
    [Tizen.NUI.Binding.TypeConverter(typeof(ColorTypeConverter))]
    public class Color : Disposable, ICloneable
    {
        /// <summary>
        /// Gets the alice_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color AliceBlue = new Color(240.0f / 255.0f, 248.0f / 255.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the antique_white colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color AntiqueWhite = new Color(250.0f / 255.0f, 235.0f / 255.0f, 215.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the aqua colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Aqua = new Color(0.0f, 1.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the aqua_marine colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color AquaMarine = new Color(127.0f / 255.0f, 1.0f, 212.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the azure colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Azure = new Color(240.0f / 255.0f, 1.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the beige colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Beige = new Color(245.0f / 255.0f, 245.0f / 255.0f, 220.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the bisque colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Bisque = new Color(1.0f, 228.0f / 255.0f, 196.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the black colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Black = new Color(0.0f, 0.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the blanche_dalmond colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color BlancheDalmond = new Color(1.0f, 235.0f / 255.0f, 205.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the blue colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Blue = new Color(0.0f, 0.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the blue_violet colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color BlueViolet = new Color(138.0f / 255.0f, 43.0f / 255.0f, 226.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the brown colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Brown = new Color(165.0f / 255.0f, 42.0f / 255.0f, 42.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the burly_wood colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color BurlyWood = new Color(222.0f / 255.0f, 184.0f / 255.0f, 135.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the cadet_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color CadetBlue = new Color(95.0f / 255.0f, 158.0f / 255.0f, 160.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the chartreuse colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Chartreuse = new Color(127.0f / 255.0f, 1.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the chocolate colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Chocolate = new Color(210.0f / 255.0f, 105.0f / 255.0f, 30.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the coral colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Coral = new Color(1.0f, 127.0f / 255.0f, 80.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the cornflower_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color CornflowerBlue = new Color(100.0f / 255.0f, 149.0f / 255.0f, 237.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the cornsilk colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Cornsilk = new Color(1.0f, 248.0f / 255.0f, 220.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the crimson colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Crimson = new Color(220.0f / 255.0f, 20.0f / 255.0f, 60.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the cyan colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Cyan = new Color(0.0f, 1.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the dark_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkBlue = new Color(0.0f, 0.0f, 139.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_cyan colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkCyan = new Color(0.0f, 139.0f / 255.0f, 139.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_goldenrod colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkGoldenrod = new Color(184.0f / 255.0f, 134.0f / 255.0f, 11.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkGray = new Color(169.0f / 255.0f, 169.0f / 255.0f, 169.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkGreen = new Color(0.0f, 100.0f / 255.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the dark_grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkGrey = new Color(169.0f / 255.0f, 169.0f / 255.0f, 169.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_khaki colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkKhaki = new Color(189.0f / 255.0f, 183.0f / 255.0f, 107.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_magenta colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkMagenta = new Color(139.0f / 255.0f, 0.0f, 139.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_olive_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkOliveGreen = new Color(85.0f / 255.0f, 107.0f / 255.0f, 47.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_orange colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkOrange = new Color(1.0f, 140.0f / 255.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the dark_orchid colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkOrchid = new Color(153.0f / 255.0f, 50.0f / 255.0f, 204.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_red colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkRed = new Color(139.0f / 255.0f, 0.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the dark_salmon colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkSalmon = new Color(233.0f / 255.0f, 150.0f / 255.0f, 122.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_sea_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkSeaGreen = new Color(143.0f / 255.0f, 188.0f / 255.0f, 143.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_slate_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkSlateBlue = new Color(72.0f / 255.0f, 61.0f / 255.0f, 139.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_slate_gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkSlateGray = new Color(47.0f / 255.0f, 79.0f / 255.0f, 79.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_slate_grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkSlateGrey = new Color(47.0f / 255.0f, 79.0f / 255.0f, 79.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_turquoise colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkTurquoise = new Color(0.0f, 206.0f / 255.0f, 209.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dark_violet colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkViolet = new Color(148.0f / 255.0f, 0.0f, 211.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the deep_pink colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DeepPink = new Color(1.0f, 20.0f / 255.0f, 147.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the deep_sky_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DeepSkyBlue = new Color(0.0f, 191.0f / 255.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the dim_gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DimGray = new Color(105.0f / 255.0f, 105.0f / 255.0f, 105.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dim_grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DimGrey = new Color(105.0f / 255.0f, 105.0f / 255.0f, 105.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the dodger_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DodgerBlue = new Color(30.0f / 255.0f, 144.0f / 255.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the fire_brick colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color FireBrick = new Color(178.0f / 255.0f, 34.0f / 255.0f, 34.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the floral_white colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color FloralWhite = new Color(1.0f, 250.0f / 255.0f, 240.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the forest_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color ForestGreen = new Color(34.0f / 255.0f, 139.0f / 255.0f, 34.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the fuchsia colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Fuchsia = new Color(1.0f, 0.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the gainsboro colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Gainsboro = new Color(220.0f / 255.0f, 220.0f / 255.0f, 220.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the ghost_white colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color GhostWhite = new Color(248.0f / 255.0f, 248.0f / 255.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the gold colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Gold = new Color(1.0f, 215.0f / 255.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the golden_rod colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color GoldenRod = new Color(218.0f / 255.0f, 165.0f / 255.0f, 32.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Gray = new Color(190.0f / 255.0f, 190.0f / 255.0f, 190.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the green colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Green = new Color(0.0f, 1.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the green_yellow colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color GreenYellow = new Color(173.0f / 255.0f, 1.0f, 47.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Grey = new Color(128.0f / 255.0f, 128.0f / 255.0f, 128.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the honeydew colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Honeydew = new Color(240.0f / 255.0f, 1.0f, 240.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the hot_pink colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color HotPink = new Color(1.0f, 105.0f / 255.0f, 180.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the indianred colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Indianred = new Color(205.0f / 255.0f, 92.0f / 255.0f, 92.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the indigo colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Indigo = new Color(75.0f / 255.0f, 0.0f, 130.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the ivory colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Ivory = new Color(1.0f, 1.0f, 240.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the khaki colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Khaki = new Color(240.0f / 255.0f, 230.0f / 255.0f, 140.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the lavender colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Lavender = new Color(230.0f / 255.0f, 230.0f / 255.0f, 250.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the lavender_blush colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LavenderBlush = new Color(1.0f, 240.0f / 255.0f, 245.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the lawn_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LawnGreen = new Color(124.0f / 255.0f, 252.0f / 255.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the lemon_chiffon colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LemonChiffon = new Color(1.0f, 250.0f / 255.0f, 205.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightBlue = new Color(173.0f / 255.0f, 216.0f / 255.0f, 230.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_coral colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightCoral = new Color(240.0f / 255.0f, 128.0f / 255.0f, 128.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_cyan colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightCyan = new Color(224.0f / 255.0f, 1.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the light_golden_rod_yellow colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightGoldenRodYellow = new Color(250.0f / 255.0f, 250.0f / 255.0f, 210.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightGray = new Color(211.0f / 255.0f, 211.0f / 255.0f, 211.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightGreen = new Color(144.0f / 255.0f, 238.0f / 255.0f, 144.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightGrey = new Color(211.0f / 255.0f, 211.0f / 255.0f, 211.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_pink colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightPink = new Color(1.0f, 182.0f / 255.0f, 193.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_salmon colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightSalmon = new Color(1.0f, 160.0f / 255.0f, 122.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_sea_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightSeaGreen = new Color(32.0f / 255.0f, 178.0f / 255.0f, 170.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_sky_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightSkyBlue = new Color(135.0f / 255.0f, 206.0f / 255.0f, 250.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_slate_gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightSlateGray = new Color(119.0f / 255.0f, 136.0f / 255.0f, 153.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_slate_grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightSlateGrey = new Color(119.0f / 255.0f, 136.0f / 255.0f, 153.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_steel_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightSteelBlue = new Color(176.0f / 255.0f, 196.0f / 255.0f, 222.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the light_yellow colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightYellow = new Color(1.0f, 1.0f, 224.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the lime colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Lime = new Color(0.0f, 1.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the lime_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LimeGreen = new Color(50.0f / 255.0f, 205.0f / 255.0f, 50.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the linen colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Linen = new Color(250.0f / 255.0f, 240.0f / 255.0f, 230.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the magenta colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Magenta = new Color(1.0f, 0.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the maroon colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Maroon = new Color(176.0f / 255.0f, 48.0f / 255.0f, 96.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the medium_aqua_marine colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumAquaMarine = new Color(102.0f / 255.0f, 205.0f / 255.0f, 170.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the medium_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumBlue = new Color(0.0f, 0.0f, 205.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the medium_orchid colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumOrchid = new Color(186.0f / 255.0f, 85.0f / 255.0f, 211.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the medium_purple colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumPurple = new Color(147.0f / 255.0f, 112.0f / 255.0f, 219.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the medium_sea_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumSeaGreen = new Color(60.0f / 255.0f, 179.0f / 255.0f, 113.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the medium_slate_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumSlateBlue = new Color(123.0f / 255.0f, 104.0f / 255.0f, 238.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the medium_spring_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumSpringGreen = new Color(0.0f, 250.0f / 255.0f, 154.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the medium_turquoise colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumTurquoise = new Color(72.0f / 255.0f, 209.0f / 255.0f, 204.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the medium_violetred colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumVioletred = new Color(199.0f / 255.0f, 21.0f / 255.0f, 133.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the midnight_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MidnightBlue = new Color(25.0f / 255.0f, 25.0f / 255.0f, 112.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the mint_cream colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MintCream = new Color(245.0f / 255.0f, 1.0f, 250.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the misty_rose colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MistyRose = new Color(1.0f, 228.0f / 255.0f, 225.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the moccasin colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Moccasin = new Color(1.0f, 228.0f / 255.0f, 181.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the navajo_white colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color NavajoWhite = new Color(1.0f, 222.0f / 255.0f, 173.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the navy colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Navy = new Color(0.0f, 0.0f, 128.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the old_lace colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color OldLace = new Color(253.0f / 255.0f, 245.0f / 255.0f, 230.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the olive colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Olive = new Color(128.0f / 255.0f, 128.0f / 255.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the olive_drab colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color OliveDrab = new Color(107.0f / 255.0f, 142.0f / 255.0f, 35.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the orange colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Orange = new Color(1.0f, 165.0f / 255.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the orange_red colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color OrangeRed = new Color(1.0f, 69.0f / 255.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the orchid colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Orchid = new Color(218.0f / 255.0f, 112.0f / 255.0f, 214.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the pale_golden_rod colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PaleGoldenRod = new Color(238.0f / 255.0f, 232.0f / 255.0f, 170.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the pale_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PaleGreen = new Color(152.0f / 255.0f, 251.0f / 255.0f, 152.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the  Pale_Turquoise colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PaleTurquoise = new Color(175.0f / 255.0f, 238.0f / 255.0f, 238.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the Pale_Violet_Red colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PaleVioletRed = new Color(219.0f / 255.0f, 112.0f / 255.0f, 147.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the Papaya_whip  colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PapayaWhip = new Color(1.0f, 239.0f / 255.0f, 213.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the Peach_puff colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PeachPuff = new Color(1.0f, 218.0f / 255.0f, 185.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the peru colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Peru = new Color(205.0f / 255.0f, 133.0f / 255.0f, 63.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the pink colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Pink = new Color(1.0f, 192.0f / 255.0f, 203.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the plum colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Plum = new Color(221.0f / 255.0f, 160.0f / 255.0f, 221.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the powder_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PowderBlue = new Color(176.0f / 255.0f, 224.0f / 255.0f, 230.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the purple colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Purple = new Color(160.0f / 255.0f, 32.0f / 255.0f, 240.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the red colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Red = new Color(1.0f, 0.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the rosy_brown colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color RosyBrown = new Color(188.0f / 255.0f, 143.0f / 255.0f, 143.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the royal_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color RoyalBlue = new Color(65.0f / 255.0f, 105.0f / 255.0f, 225.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the saddle_brown colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SaddleBrown = new Color(139.0f / 255.0f, 69.0f / 255.0f, 19.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the salmon colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Salmon = new Color(250.0f / 255.0f, 128.0f / 255.0f, 114.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the sandy_brown colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SandyBrown = new Color(244.0f / 255.0f, 164.0f / 255.0f, 96.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the sea_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SeaGreen = new Color(46.0f / 255.0f, 139.0f / 255.0f, 87.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the sea_shell colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SeaShell = new Color(1.0f, 245.0f / 255.0f, 238.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the sienna colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Sienna = new Color(160.0f / 255.0f, 82.0f / 255.0f, 45.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the silver colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Silver = new Color(192.0f / 255.0f, 192.0f / 255.0f, 192.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the sky_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SkyBlue = new Color(135.0f / 255.0f, 206.0f / 255.0f, 235.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the slate_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SlateBlue = new Color(106.0f / 255.0f, 90.0f / 255.0f, 205.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the slate_gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SlateGray = new Color(112.0f / 255.0f, 128.0f / 255.0f, 144.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the slate_grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SlateGrey = new Color(112.0f / 255.0f, 128.0f / 255.0f, 144.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the snow colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Snow = new Color(1.0f, 250.0f / 255.0f, 250.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the spring_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SpringGreen = new Color(0.0f, 1.0f, 127.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the steel_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SteelBlue = new Color(70.0f / 255.0f, 130.0f / 255.0f, 180.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the tan colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Tan = new Color(210.0f / 255.0f, 180.0f / 255.0f, 140.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the teal colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Teal = new Color(0.0f, 128.0f / 255.0f, 128.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the thistle colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Thistle = new Color(216.0f / 255.0f, 191.0f / 255.0f, 216.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the tomato colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Tomato = new Color(1.0f, 99.0f / 255.0f, 71.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the transparent colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Transparent = new Color(0.0f, 0.0f, 0.0f, 0.0f);

        /// <summary>
        /// Gets the turquoise colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Turquoise = new Color(64.0f / 255.0f, 224.0f / 255.0f, 208.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the violet colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Violet = new Color(238.0f / 255.0f, 130.0f / 255.0f, 238.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the wheat colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Wheat = new Color(245.0f / 255.0f, 222.0f / 255.0f, 179.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the white colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color White = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the white_smoke colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color WhiteSmoke = new Color(245.0f / 255.0f, 245.0f / 255.0f, 245.0f / 255.0f, 1.0f);

        /// <summary>
        /// Gets the yellow colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Yellow = new Color(1.0f, 1.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the yellow_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color YellowGreen = new Color(154.0f / 255.0f, 205.0f / 255.0f, 50.0f / 255.0f, 1.0f);

        internal static new void Preload()
        {
            // Do nothing. Just call for load static values.
            UIColor.Preload();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Color() : this(Interop.Vector4.NewVector4(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        /// <since_tizen> 3 </since_tizen>
        public Color(float r, float g, float b, float a) : this(Interop.Vector4.NewVector4(ValueCheck(r), ValueCheck(g), ValueCheck(b), ValueCheck(a)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The conversion constructor from an array of four floats.
        /// </summary>
        /// <param name="array">array Array of R,G,B,A.</param>
        /// <since_tizen> 3 </since_tizen>
        public Color(float[] array) : this(Interop.Vector4.NewVector4(ValueCheck(array)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The conversion constructor from text color representation.
        /// hexcode representation : #RGB #RGBA #RRGGBB #RRGGBBAA
        /// rgb representation : rgb(0-255,0-255,0-255) rgba(0-255,0-255,0-255,0.0-1.0)
        /// </summary>
        /// <param name="textColor">color text representation as Hexcode, rgb() or rgba()</param>
        /// <exception cref="ArgumentNullException">This exception is thrown when hexColor is null.</exception>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color(string textColor) : this(Interop.Vector4.NewVector4(), true)
        {
            try
            {
                if (null == textColor)
                {
                    throw new ArgumentNullException(nameof(textColor));
                }

                textColor = textColor.ToUpperInvariant();
                textColor = textColor.Replace(" ", "");

                if (textColor.Length > 0 && textColor[0] == '#')
                {
                    textColor = textColor.Replace("#", "");
                    int textColorLength = textColor.Length;

                    if (textColorLength == 6 || textColorLength == 8) /* #RRGGBB or #RRGGBBAA */
                    {
                        R = ((float)Convert.ToInt32(textColor.Substring(0, 2), 16)) / 255.0f;
                        G = ((float)Convert.ToInt32(textColor.Substring(2, 2), 16)) / 255.0f;
                        B = ((float)Convert.ToInt32(textColor.Substring(4, 2), 16)) / 255.0f;
                        A = textColor.Length > 6 ? ((float)Convert.ToInt32(textColor.Substring(6, 2), 16)) / 255.0f : 1.0f;
                    }
                    else if (textColorLength == 3 || textColorLength == 4) /* #RGB */
                    {
                        R = ((float)Convert.ToInt32(textColor.Substring(0, 1), 16)) / 15.0f;
                        G = ((float)Convert.ToInt32(textColor.Substring(1, 1), 16)) / 15.0f;
                        B = ((float)Convert.ToInt32(textColor.Substring(2, 1), 16)) / 15.0f;
                        A = textColor.Length > 3 ? ((float)Convert.ToInt32(textColor.Substring(3, 1), 16)) / 15.0f : 1.0f;
                    }
                    else
                    {
                        throw new global::System.ArgumentException("Please check your color text code");
                    }
                }
                else // example rgb(255,255,255) or rgb(255,255,255,1.0)
                {
                    bool isRGBA = textColor.StartsWith("RGBA(");
                    bool isRGB = textColor.StartsWith("RGB(");

                    if (!isRGBA && !isRGB)
                    {
                        throw new global::System.ArgumentException("Please check your color text code");
                    }

                    if (isRGBA)
                        textColor = textColor.Substring(4);
                    if (isRGB)
                        textColor = textColor.Substring(3);

                    textColor = textColor.Replace(")", "");
                    textColor = textColor.Replace("(", "");

                    string[] components = textColor.Split(',');

                    if (components.Length == 3 && isRGB)
                    {
                        R = Math.Min(1.0f, ((float)Convert.ToInt32(components[0], 10)) / 255.0f);
                        G = Math.Min(1.0f, ((float)Convert.ToInt32(components[1], 10)) / 255.0f);
                        B = Math.Min(1.0f, ((float)Convert.ToInt32(components[2], 10)) / 255.0f);
                        A = 1.0f;
                    }
                    else if (components.Length == 4 && isRGBA)
                    {
                        R = Math.Min(1.0f, ((float)Convert.ToInt32(components[0], 10)) / 255.0f);
                        G = Math.Min(1.0f, ((float)Convert.ToInt32(components[1], 10)) / 255.0f);
                        B = Math.Min(1.0f, ((float)Convert.ToInt32(components[2], 10)) / 255.0f);
                        A = Math.Min(1.0f, float.Parse(components[3], CultureInfo.InvariantCulture));
                    }
                }
            }
            catch
            {
                throw new global::System.ArgumentException("Please check your color text code");
            }
        }

        /// <summary>
        /// The conversion constructor from an System.Drawing.Color instance.
        /// </summary>
        /// <param name="color">System.Drawing.Color instance</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color(global::System.Drawing.Color color) : this(Interop.Vector4.NewVector4(), true)
        {
            R = color.R / 255.0f;
            G = color.G / 255.0f;
            B = color.B / 255.0f;
            A = color.A / 255.0f;
        }

        /// <summary>
        /// The copy constructor.
        /// </summary>
        /// <param name="other">The copy target.</param>
        /// <exception cref="ArgumentNullException"> Thrown when other is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color(Color other) : this(other == null ? throw new ArgumentNullException(nameof(other)) : other.R, other.G, other.B, other.A)
        {
        }

        internal Color(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn, false)
        {
        }

        internal Color(ColorChangedCallback cb, float r, float g, float b, float a) : this(Interop.Vector4.NewVector4(ValueCheck(r), ValueCheck(g), ValueCheck(b), ValueCheck(a)), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Color(ColorChangedCallback cb, Color other) : this(cb, other.R, other.G, other.B, other.A)
        {
        }

        internal delegate void ColorChangedCallback(float r, float g, float b, float a);
        private ColorChangedCallback callback;

        /// <summary>
        /// The red component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use the new Color(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use as follows:
        /// Color color = new Color();
        /// color.R = 0.1f;
        /// // USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Color color = new Color(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float R
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use the new Color(...) constructor")]
            set
            {
                Interop.Vector4.RSet(SwigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(value, G, B, A);
            }
            get
            {
                float ret = Interop.Vector4.RGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The green component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use the new Color(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use as follows:
        /// Color color = new Color();
        /// color.G = 0.5f;
        /// // USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Color color = new Color(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float G
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use the new Color(...) constructor")]
            set
            {
                Interop.Vector4.GSet(SwigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, value, B, A);
            }
            get
            {
                float ret = Interop.Vector4.GGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The blue component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use the new Color(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use as follows:
        /// Color color = new Color();
        /// color.B = 0.9f;
        /// // USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Color color = new Color(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float B
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use the new Color(...) constructor")]
            set
            {
                Interop.Vector4.BSet(SwigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, value, A);
            }
            get
            {
                float ret = Interop.Vector4.BGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The alpha component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use the new Color(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use as follows:
        /// Color color = new Color();
        /// color.A = 1.0f;
        /// // USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Color color = new Color(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float A
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use the new Color(...) constructor")]
            set
            {
                Interop.Vector4.ASet(SwigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, B, value);
            }
            get
            {
                float ret = Interop.Vector4.AGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The array subscript operator overload.
        /// </summary>
        /// <param name="index">The subscript index.</param>
        /// <returns>The float at the given index.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float this[uint index]
        {
            get
            {
                return ValueOfIndex(index);
            }
        }

        /// <summary>
        /// Converts the Color class to Vector4 class implicitly.
        /// </summary>
        /// <param name="color">A color to be converted to Vector4</param>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector4(Color color)
        {
            if (color == null)
            {
                return null;
            }
            return new Vector4(color.R, color.G, color.B, color.A);
        }

        /// <summary>
        /// Converts Vector4 class to Color class implicitly.
        /// </summary>
        /// <param name="vec">A Vector4 to be converted to color.</param>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Color(Vector4 vec)
        {
            if (vec == null)
            {
                return null;
            }
            return new Color(vec.R, vec.G, vec.B, vec.A);
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the addition.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator +(Color arg1, Color arg2)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            using Color result = arg1.Add(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the subtraction.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator -(Color arg1, Color arg2)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            using Color result = arg1.Subtract(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The target value.</param>
        /// <returns>The color containg the negation.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator -(Color arg1)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            using Color result = arg1.Subtract();
            return ValueCheck(result);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the multiplication.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator *(Color arg1, Color arg2)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            using Color result = arg1.Multiply(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the multiplication.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator *(Color arg1, float arg2)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            using Color result = arg1.Multiply(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the division.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator /(Color arg1, Color arg2)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            using Color result = arg1.Divide(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the division.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator /(Color arg1, float arg2)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            using Color result = arg1.Divide(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// Checks if two color classes are same.
        /// </summary>
        /// <param name="rhs">A color to be compared.</param>
        /// <returns>If two colors are are same, then true.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(Color rhs)
        {
            bool ret = Interop.Vector4.EqualTo(SwigCPtr, Color.getCPtr(rhs));

            if (rhs == null) return false;

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Checks if two color classes are different.
        /// </summary>
        /// <param name="rhs">A color to be compared.</param>
        /// <returns>If two colors are are different, then true.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(Color rhs)
        {
            bool ret = Interop.Vector4.NotEqualTo(SwigCPtr, Color.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Color(this);

        internal static Color GetColorFromPtr(global::System.IntPtr cPtr)
        {
            Color ret = new Color(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static Color ValueCheck(Color color)
        {
            float r = color.R;
            float g = color.G;
            float b = color.B;
            float a = color.A;

            if (IsInvalidValue(ref r) | IsInvalidValue(ref g) | IsInvalidValue(ref b) | IsInvalidValue(ref a))
            {
                NUILog.Error($"The value of Result is invalid! Should be between [0, 1]. Color is {color.R}, {color.G}, {color.B}, {color.A}");
            }
            color = new Color(r, g, b, a);
            return color;
        }

        internal static float ValueCheck(float value)
        {
            float refValue = value;
            if (IsInvalidValue(ref refValue))
            {
                NUILog.Error($"The value of Result is invalid! Should be between [0, 1]. float value is {value}");
            }
            return refValue;
        }

        internal static float[] ValueCheck(float[] arr)
        {
            if (null == arr)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            for (int i = 0; i < arr.Length; i++)
            {
                float refValue = arr[i];
                if (IsInvalidValue(ref refValue))
                {
                    NUILog.Error($"The value of Result is invalid! Should be between [0, 1]. arr[] is {arr[i]}");
                    arr[i] = refValue;
                }
            }
            return arr;
        }

        private static bool IsInvalidValue(ref float value)
        {
            if (value < 0.0f)
            {
                value = 0.0f;
                return true;
            }
            else if (value > 1.0f)
            {
                value = 1.0f;
                return true;
            }
            return false;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector4.DeleteVector4(swigCPtr);
        }

        private Color Add(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.Add(SwigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color AddAssign(Vector4 rhs)
        {
            Color ret = new Color(Interop.Vector4.AddAssign(SwigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Subtract(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.Subtract(SwigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color SubtractAssign(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.SubtractAssign(SwigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Multiply(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.Multiply(SwigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Multiply(float rhs)
        {
            Color ret = new Color(Interop.Vector4.Multiply(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color MultiplyAssign(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.MultiplyAssign(SwigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color MultiplyAssign(float rhs)
        {
            Color ret = new Color(Interop.Vector4.MultiplyAssign(SwigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Divide(Vector4 rhs)
        {
            Color ret = new Color(Interop.Vector4.Divide(SwigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Divide(float rhs)
        {
            Color ret = new Color(Interop.Vector4.Divide(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color DivideAssign(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.DivideAssign(SwigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color DivideAssign(float rhs)
        {
            Color ret = new Color(Interop.Vector4.DivideAssign(SwigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Subtract()
        {
            Color ret = new Color(Interop.Vector4.Subtract(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private static bool EqualsColorValue(float f1, float f2)
        {
            float EPS = (float)Math.Abs(f1 * .00001);
            if (Math.Abs(f1 - f2) <= EPS)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool EqualsColor(Color c1, Color c2)
        {
            return EqualsColorValue(c1.R, c2.R) && EqualsColorValue(c1.G, c2.G)
                && EqualsColorValue(c1.B, c2.B) && EqualsColorValue(c1.A, c2.A);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(System.Object obj)
        {
            Color color = obj as Color;
            bool equal = false;
            if (color == null)
            {
                return equal;
            }

            if (EqualsColor(this, color))
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="arg1">Color to compare</param>
        /// <param name="arg2">Color to be compared</param>
        /// <returns>true if Colors are equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(Color arg1, Color arg2)
        {
            if (arg1 is null)
            {
                if (arg2 is null)
                    return true;

                return false;
            }

            return arg1.Equals(arg2);
        }

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="arg1">Color to compare</param>
        /// <param name="arg2">Color to be compared</param>
        /// <returns>true if Colors are not equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(Color arg1, Color arg2) => !(arg1 == arg2);

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector4.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}


