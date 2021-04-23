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

namespace Tizen.NUI
{
    /// <summary>
    /// The Color class.
    /// </summary>
    [Tizen.NUI.Binding.TypeConverter(typeof(ColorTypeConverter))]
    public class Color : Disposable, ICloneable
    {
        /// <summary>
        /// Gets the alice_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color AliceBlue = NDalic.ALICE_BLUE;

        /// <summary>
        /// Gets the antique_white colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color AntiqueWhite = NDalic.ANTIQUE_WHITE;

        /// <summary>
        /// Gets the aqua colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Aqua = NDalic.AQUA;

        /// <summary>
        /// Gets the aqua_marine colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color AquaMarine = NDalic.AQUA_MARINE;

        /// <summary>
        /// Gets the azure colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Azure = NDalic.AZURE;

        /// <summary>
        /// Gets the beige colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Beige = NDalic.BEIGE;

        /// <summary>
        /// Gets the bisque colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Bisque = NDalic.BISQUE;

        /// <summary>
        /// Gets the black colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Black = NDalic.BLACK;

        /// <summary>
        /// Gets the blanche_dalmond colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color BlancheDalmond = NDalic.BLANCHE_DALMOND;

        /// <summary>
        /// Gets the blue colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Blue = NDalic.BLUE;

        /// <summary>
        /// Gets the blue_violet colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color BlueViolet = NDalic.BLUE_VIOLET;

        /// <summary>
        /// Gets the brown colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Brown = NDalic.BROWN;

        /// <summary>
        /// Gets the burly_wood colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color BurlyWood = NDalic.BURLY_WOOD;

        /// <summary>
        /// Gets the cadet_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color CadetBlue = NDalic.CADET_BLUE;

        /// <summary>
        /// Gets the chartreuse colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Chartreuse = NDalic.CHARTREUSE;

        /// <summary>
        /// Gets the chocolate colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Chocolate = NDalic.CHOCOLATE;

        /// <summary>
        /// Gets the coral colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Coral = NDalic.CORAL;

        /// <summary>
        /// Gets the cornflower_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color CornflowerBlue = NDalic.CORNFLOWER_BLUE;

        /// <summary>
        /// Gets the cornsilk colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Cornsilk = NDalic.CORNSILK;

        /// <summary>
        /// Gets the crimson colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Crimson = NDalic.CRIMSON;

        /// <summary>
        /// Gets the cyan colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Cyan = NDalic.CYAN;

        /// <summary>
        /// Gets the dark_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkBlue = NDalic.DARK_BLUE;

        /// <summary>
        /// Gets the dark_cyan colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkCyan = NDalic.DARK_CYAN;

        /// <summary>
        /// Gets the dark_goldenrod colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkGoldenrod = NDalic.DARK_GOLDENROD;

        /// <summary>
        /// Gets the dark_gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkGray = NDalic.DARK_GRAY;

        /// <summary>
        /// Gets the dark_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkGreen = NDalic.DARK_GREEN;

        /// <summary>
        /// Gets the dark_grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkGrey = NDalic.DARK_GREY;

        /// <summary>
        /// Gets the dark_khaki colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkKhaki = NDalic.DARK_KHAKI;

        /// <summary>
        /// Gets the dark_magenta colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkMagenta = NDalic.DARK_MAGENTA;

        /// <summary>
        /// Gets the dark_olive_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkOliveGreen = NDalic.DARK_OLIVE_GREEN;

        /// <summary>
        /// Gets the dark_orange colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkOrange = NDalic.DARK_ORANGE;

        /// <summary>
        /// Gets the dark_orchid colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkOrchid = NDalic.DARK_ORCHID;

        /// <summary>
        /// Gets the dark_red colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkRed = NDalic.DARK_RED;

        /// <summary>
        /// Gets the dark_salmon colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkSalmon = NDalic.DARK_SALMON;

        /// <summary>
        /// Gets the dark_sea_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkSeaGreen = NDalic.DARK_SEA_GREEN;

        /// <summary>
        /// Gets the dark_slate_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkSlateBlue = NDalic.DARK_SLATE_BLUE;

        /// <summary>
        /// Gets the dark_slate_gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkSlateGray = NDalic.DARK_SLATE_GRAY;

        /// <summary>
        /// Gets the dark_slate_grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkSlateGrey = NDalic.DARK_SLATE_GREY;

        /// <summary>
        /// Gets the dark_turquoise colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkTurquoise = NDalic.DARK_TURQUOISE;

        /// <summary>
        /// Gets the dark_violet colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DarkViolet = NDalic.DARK_VIOLET;

        /// <summary>
        /// Gets the deep_pink colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DeepPink = NDalic.DEEP_PINK;

        /// <summary>
        /// Gets the deep_sky_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DeepSkyBlue = NDalic.DEEP_SKY_BLUE;

        /// <summary>
        /// Gets the dim_gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DimGray = NDalic.DIM_GRAY;

        /// <summary>
        /// Gets the dim_grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DimGrey = NDalic.DIM_GREY;

        /// <summary>
        /// Gets the dodger_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color DodgerBlue = NDalic.DODGER_BLUE;

        /// <summary>
        /// Gets the fire_brick colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color FireBrick = NDalic.FIRE_BRICK;

        /// <summary>
        /// Gets the floral_white colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color FloralWhite = NDalic.FLORAL_WHITE;

        /// <summary>
        /// Gets the forest_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color ForestGreen = NDalic.FOREST_GREEN;

        /// <summary>
        /// Gets the fuchsia colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Fuchsia = NDalic.FUCHSIA;

        /// <summary>
        /// Gets the gainsboro colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Gainsboro = NDalic.GAINSBORO;

        /// <summary>
        /// Gets the ghost_white colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color GhostWhite = NDalic.GHOST_WHITE;

        /// <summary>
        /// Gets the gold colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Gold = NDalic.GOLD;

        /// <summary>
        /// Gets the golden_rod colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color GoldenRod = NDalic.GOLDEN_ROD;

        /// <summary>
        /// Gets the gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Gray = NDalic.GRAY;

        /// <summary>
        /// Gets the green colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Green = NDalic.GREEN;

        /// <summary>
        /// Gets the green_yellow colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color GreenYellow = NDalic.GREEN_YELLOW;

        /// <summary>
        /// Gets the grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Grey = NDalic.GREY;

        /// <summary>
        /// Gets the honeydew colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Honeydew = NDalic.HONEYDEW;

        /// <summary>
        /// Gets the hot_pink colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color HotPink = NDalic.HOT_PINK;

        /// <summary>
        /// Gets the indianred colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Indianred = NDalic.INDIANRED;

        /// <summary>
        /// Gets the indigo colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Indigo = NDalic.INDIGO;

        /// <summary>
        /// Gets the ivory colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Ivory = NDalic.IVORY;

        /// <summary>
        /// Gets the khaki colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Khaki = NDalic.KHAKI;

        /// <summary>
        /// Gets the lavender colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Lavender = NDalic.LAVENDER;

        /// <summary>
        /// Gets the lavender_blush colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LavenderBlush = NDalic.LAVENDER_BLUSH;

        /// <summary>
        /// Gets the lawn_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LawnGreen = NDalic.LAWN_GREEN;

        /// <summary>
        /// Gets the lemon_chiffon colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LemonChiffon = NDalic.LEMON_CHIFFON;

        /// <summary>
        /// Gets the light_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightBlue = NDalic.LIGHT_BLUE;

        /// <summary>
        /// Gets the light_coral colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightCoral = NDalic.LIGHT_CORAL;

        /// <summary>
        /// Gets the light_cyan colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightCyan = NDalic.LIGHT_CYAN;

        /// <summary>
        /// Gets the light_golden_rod_yellow colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightGoldenRodYellow = NDalic.LIGHT_GOLDEN_ROD_YELLOW;

        /// <summary>
        /// Gets the light_gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightGray = NDalic.LIGHT_GRAY;

        /// <summary>
        /// Gets the light_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightGreen = NDalic.LIGHT_GREEN;

        /// <summary>
        /// Gets the light_grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightGrey = NDalic.LIGHT_GREY;

        /// <summary>
        /// Gets the light_pink colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightPink = NDalic.LIGHT_PINK;

        /// <summary>
        /// Gets the light_salmon colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightSalmon = NDalic.LIGHT_SALMON;

        /// <summary>
        /// Gets the light_sea_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightSeaGreen = NDalic.LIGHT_SEA_GREEN;

        /// <summary>
        /// Gets the light_sky_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightSkyBlue = NDalic.LIGHT_SKY_BLUE;

        /// <summary>
        /// Gets the light_slate_gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightSlateGray = NDalic.LIGHT_SLATE_GRAY;

        /// <summary>
        /// Gets the light_slate_grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightSlateGrey = NDalic.LIGHT_SLATE_GREY;

        /// <summary>
        /// Gets the light_steel_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightSteelBlue = NDalic.LIGHT_STEEL_BLUE;

        /// <summary>
        /// Gets the light_yellow colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LightYellow = NDalic.LIGHT_YELLOW;

        /// <summary>
        /// Gets the lime colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Lime = NDalic.LIME;

        /// <summary>
        /// Gets the lime_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color LimeGreen = NDalic.LIME_GREEN;

        /// <summary>
        /// Gets the linen colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Linen = NDalic.LINEN;

        /// <summary>
        /// Gets the magenta colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Magenta = NDalic.MAGENTA;

        /// <summary>
        /// Gets the maroon colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Maroon = NDalic.MAROON;

        /// <summary>
        /// Gets the medium_aqua_marine colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumAquaMarine = NDalic.MEDIUM_AQUA_MARINE;

        /// <summary>
        /// Gets the medium_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumBlue = NDalic.MEDIUM_BLUE;

        /// <summary>
        /// Gets the medium_orchid colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumOrchid = NDalic.MEDIUM_ORCHID;

        /// <summary>
        /// Gets the medium_purple colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumPurple = NDalic.MEDIUM_PURPLE;

        /// <summary>
        /// Gets the medium_sea_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumSeaGreen = NDalic.MEDIUM_SEA_GREEN;

        /// <summary>
        /// Gets the medium_slate_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumSlateBlue = NDalic.MEDIUM_SLATE_BLUE;

        /// <summary>
        /// Gets the medium_spring_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumSpringGreen = NDalic.MEDIUM_SPRING_GREEN;

        /// <summary>
        /// Gets the medium_turquoise colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumTurquoise = NDalic.MEDIUM_TURQUOISE;

        /// <summary>
        /// Gets the medium_violetred colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MediumVioletred = NDalic.MEDIUM_VIOLETRED;

        /// <summary>
        /// Gets the midnight_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MidnightBlue = NDalic.MIDNIGHT_BLUE;

        /// <summary>
        /// Gets the mint_cream colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MintCream = NDalic.MINT_CREAM;

        /// <summary>
        /// Gets the misty_rose colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color MistyRose = NDalic.MISTY_ROSE;

        /// <summary>
        /// Gets the moccasin colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Moccasin = NDalic.MOCCASIN;

        /// <summary>
        /// Gets the navajo_white colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color NavajoWhite = NDalic.NAVAJO_WHITE;

        /// <summary>
        /// Gets the navy colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Navy = NDalic.NAVY;

        /// <summary>
        /// Gets the old_lace colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color OldLace = NDalic.OLD_LACE;

        /// <summary>
        /// Gets the olive colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Olive = NDalic.OLIVE;

        /// <summary>
        /// Gets the olive_drab colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color OliveDrab = NDalic.OLIVE_DRAB;

        /// <summary>
        /// Gets the orange colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Orange = NDalic.ORANGE;

        /// <summary>
        /// Gets the orange_red colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color OrangeRed = NDalic.ORANGE_RED;

        /// <summary>
        /// Gets the orchid colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Orchid = NDalic.ORCHID;

        /// <summary>
        /// Gets the pale_golden_rod colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PaleGoldenRod = NDalic.PALE_GOLDEN_ROD;

        /// <summary>
        /// Gets the pale_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PaleGreen = NDalic.PALE_GREEN;

        /// <summary>
        /// Gets the  Pale_Turquoise colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PaleTurquoise = NDalic.PALE_TURQUOISE;

        /// <summary>
        /// Gets the Pale_Violet_Red colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PaleVioletRed = NDalic.PALE_VIOLET_RED;

        /// <summary>
        /// Gets the Papaya_whip  colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PapayaWhip = NDalic.PAPAYA_WHIP;

        /// <summary>
        /// Gets the Peach_puff colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PeachPuff = NDalic.PEACH_PUFF;

        /// <summary>
        /// Gets the peru colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Peru = NDalic.PERU;

        /// <summary>
        /// Gets the pink colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Pink = NDalic.PINK;

        /// <summary>
        /// Gets the plum colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Plum = NDalic.PLUM;

        /// <summary>
        /// Gets the powder_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color PowderBlue = NDalic.POWDER_BLUE;

        /// <summary>
        /// Gets the purple colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Purple = NDalic.PURPLE;

        /// <summary>
        /// Gets the red colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Red = NDalic.RED;

        /// <summary>
        /// Gets the rosy_brown colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color RosyBrown = NDalic.ROSY_BROWN;

        /// <summary>
        /// Gets the royal_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color RoyalBlue = NDalic.ROYAL_BLUE;

        /// <summary>
        /// Gets the saddle_brown colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SaddleBrown = NDalic.SADDLE_BROWN;

        /// <summary>
        /// Gets the salmon colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Salmon = NDalic.SALMON;

        /// <summary>
        /// Gets the sandy_brown colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SandyBrown = NDalic.SANDY_BROWN;

        /// <summary>
        /// Gets the sea_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SeaGreen = NDalic.SEA_GREEN;

        /// <summary>
        /// Gets the sea_shell colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SeaShell = NDalic.SEA_SHELL;

        /// <summary>
        /// Gets the sienna colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Sienna = NDalic.SIENNA;

        /// <summary>
        /// Gets the silver colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Silver = NDalic.SILVER;

        /// <summary>
        /// Gets the sky_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SkyBlue = NDalic.SKY_BLUE;

        /// <summary>
        /// Gets the slate_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SlateBlue = NDalic.SLATE_BLUE;

        /// <summary>
        /// Gets the slate_gray colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SlateGray = NDalic.SLATE_GRAY;

        /// <summary>
        /// Gets the slate_grey colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SlateGrey = NDalic.SLATE_GREY;

        /// <summary>
        /// Gets the snow colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Snow = NDalic.SNOW;

        /// <summary>
        /// Gets the spring_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SpringGreen = NDalic.SPRING_GREEN;

        /// <summary>
        /// Gets the steel_blue colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color SteelBlue = NDalic.STEEL_BLUE;

        /// <summary>
        /// Gets the tan colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Tan = NDalic.TAN;

        /// <summary>
        /// Gets the teal colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Teal = NDalic.TEAL;

        /// <summary>
        /// Gets the thistle colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Thistle = NDalic.THISTLE;

        /// <summary>
        /// Gets the tomato colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Tomato = NDalic.TOMATO;

        /// <summary>
        /// Gets the  transparent colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Transparent = NDalic.TRANSPARENT;

        /// <summary>
        /// Gets the turquoise colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Turquoise = NDalic.TURQUOISE;

        /// <summary>
        /// Gets the violet colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Violet = NDalic.VIOLET;

        /// <summary>
        /// Gets the wheat colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color Wheat = NDalic.WHEAT;

        /// <summary>
        /// Gets the white colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color White = NDalic.WHITE;

        /// <summary>
        /// Gets the white_smoke colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color WhiteSmoke = NDalic.WHITE_SMOKE;

        /// <summary>
        /// Gets the yellow colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Yellow = NDalic.YELLOW;

        /// <summary>
        /// Gets the yellow_green colored Color class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Color YellowGreen = NDalic.YELLOW_GREEN;


        private readonly bool hashDummy;

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
                        A = Math.Min(1.0f, float.Parse(components[3]));
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

        internal Color(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            hashDummy = false;
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
        private ColorChangedCallback callback = null;

        /// <summary>
        /// The red component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Color(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Color color = new Color();
        /// color.R = 0.1f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Color color = new Color(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float R
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Color(...) constructor")]
            set
            {
                Interop.Vector4.RSet(SwigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, B, A);
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
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Color(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Color color = new Color();
        /// color.G = 0.5f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Color color = new Color(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float G
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Color(...) constructor")]
            set
            {
                Interop.Vector4.GSet(SwigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, B, A);
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
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Color(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Color color = new Color();
        /// color.B = 0.9f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Color color = new Color(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float B
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Color(...) constructor")]
            set
            {
                Interop.Vector4.BSet(SwigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, B, A);
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
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Color(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Color color = new Color();
        /// color.A = 1.0f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Color color = new Color(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float A
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Color(...) constructor")]
            set
            {
                Interop.Vector4.ASet(SwigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, B, A);
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
            Color result = arg1.Add(arg2);
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
            Color result = arg1.Subtract(arg2);
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
            Color result = arg1.Subtract();
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
            Color result = arg1.Multiply(arg2);
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
            Color result = arg1.Multiply(arg2);
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
            Color result = arg1.Divide(arg2);
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
            Color result = arg1.Divide(arg2);
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

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Color obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

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

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return hashDummy.GetHashCode();
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector4.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}


