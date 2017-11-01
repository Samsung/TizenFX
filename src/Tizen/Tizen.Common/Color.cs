/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Common
{
    /// <summary>
    /// Structure that represents a color as RGBA.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct Color : IEquatable<Color>
    {
        /// <summary>
        /// Empty color instance. All components are 0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Empty = FromRgba(0, 0, 0, 0);

        /// <summary>
        /// Transparent color instance. All components are 0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Transparent = FromRgba(0, 0, 0, 0);

        /// <summary>
        /// Aqua color instance. Its RGB value is (0, 255, 255).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Aqua = FromRgb(0, 255, 255);

        /// <summary>
        /// Black color instance. Its RGB value is (0, 0, 0).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Black = FromRgb(0, 0, 0);

        /// <summary>
        /// Blue color instance. Its RGB value is (0, 0, 255).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Blue = FromRgb(0, 0, 255);

        /// <summary>
        /// Fuchsia color instance. Its RGB value is (255, 0, 255).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Fuchsia = FromRgb(255, 0, 255);

        /// <summary>
        /// Gray color instance. Its RGB value is (128, 128, 128).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Gray = FromRgb(128, 128, 128);

        /// <summary>
        /// Green color instance. Its RGB value is (0, 128, 0).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Green = FromRgb(0, 128, 0);

        /// <summary>
        /// Lime color instance. Its RGB value is (0, 255, 0).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Lime = FromRgb(0, 255, 0);

        /// <summary>
        /// Maroon color instance. Its RGB value is (128, 0, 0).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Maroon = FromRgb(128, 0, 0);

        /// <summary>
        /// Navy color instance. Its RGB value is (0, 0, 128).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Navy = FromRgb(0, 0, 128);

        /// <summary>
        /// Olive color instance. Its RGB value is (128, 128, 0).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Olive = FromRgb(128, 128, 0);

        /// <summary>
        /// Purple color instance. Its RGB value is (128, 0, 128).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Purple = FromRgb(128, 0, 128);

        /// <summary>
        /// Pink color instance. Its RGB value is (255, 102, 255).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Pink = FromRgb(255, 102, 255);

        /// <summary>
        /// Red color instance. Its RGB value is (255, 0, 0).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Red = FromRgb(255, 0, 0);

        /// <summary>
        /// Silver color instance. Its RGB value is (192, 192, 192).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Silver = FromRgb(192, 192, 192);

        /// <summary>
        /// Teal color instance. Its RGB value is (0, 128, 128).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Teal = FromRgb(0, 128, 128);

        /// <summary>
        /// White color instance. Its RGB value is (255, 255, 255).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color White = FromRgb(255, 255, 255);

        /// <summary>
        /// Yellow color instance. Its RGB value is (255, 255, 0).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Yellow = FromRgb(255, 255, 0);

        private int _value;

        /// <summary>
        /// Initiates new Color with r,g,b,a components.
        /// </summary>
        /// <param name="r">Red (0 ~ 255)</param>
        /// <param name="g">Green (0 ~ 255)</param>
        /// <param name="b">Blue (0 ~ 255)</param>
        /// <param name="a">Alpha (0 ~ 255)</param>
        /// <since_tizen> 3 </since_tizen>
        public Color(int r, int g, int b, int a)
        {
            if (r > 255 || r < 0)
                throw CreateColorArgumentException(r, "red");
            if (g > 255 || g < 0)
                throw CreateColorArgumentException(g, "green");
            if (b > 255 || b < 0)
                throw CreateColorArgumentException(b, "blue");
            if (a > 255 || a < 0)
                throw CreateColorArgumentException(a, "alpha");

            _value = (int)(((uint)r << 24) + ((uint)g << 16) + ((uint)b << 8) + (uint)a);
        }

        /// <summary>
        /// Initiates new Color with r,g,b components. The alpha value will be 255 as default.
        /// </summary>
        /// <param name="r">Red (0 ~ 255)</param>
        /// <param name="g">Green (0 ~ 255)</param>
        /// <param name="b">Blue (0 ~ 255)</param>
        /// <since_tizen> 3 </since_tizen>
        public Color(int r, int g, int b) : this(r, g, b, 255)
        {
        }

        #region Properties

        /// <summary>
        /// Gets the Red component of the color.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int R
        {
            get { return (byte)(_value >> 24); }
        }

        /// <summary>
        /// Gets the Green component of the color.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int G
        {
            get { return (byte)(_value >> 16); }
        }

        /// <summary>
        /// Gets the blue component of the color.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int B
        {
            get { return (byte)(_value >> 8); }
        }

        /// <summary>
        /// Gets the alpha component of the color.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int A
        {
            get { return (byte)_value; }
        }

        #endregion  // Properties

        #region Static Methods

        /// <summary>
        /// Returns a boolean indicating whether the two given Colors are equal.
        /// </summary>
        /// <param name="color1">The first Color to compare.</param>
        /// <param name="color2">The second Color to compare.</param>
        /// <returns>True if the Colors are equal; False otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator ==(Color color1, Color color2)
        {
            return color1.Equals(color2);
        }

        /// <summary>
        /// Returns a boolean indicating whether the two given Colors are not equal.
        /// </summary>
        /// <param name="color1">The first Color to compare.</param>
        /// <param name="color2">The second Color to compare.</param>
        /// <returns>True if the Colors are not equal; False if they are equal.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator !=(Color color1, Color color2)
        {
            return !color1.Equals(color2);
        }

        /// <summary>
        /// Returns a new RGB color instance.
        /// </summary>
        /// <param name="r">The red component of the color.</param>
        /// <param name="g">The green component of the color.</param>
        /// <param name="b">The blue component of the color.</param>
        /// <returns></returns>
        /// <since_tizen> 3 </since_tizen>
        public static Color FromRgb(int r, int g, int b)
        {
            return new Color(r, g, b);
        }

        /// <summary>
        /// Returns a new RGBA color instance.
        /// </summary>
        /// <param name="r">The red component of the color.</param>
        /// <param name="g">The green component of the color.</param>
        /// <param name="b">The blue component of the color.</param>
        /// <param name="a">The alpha component of the color.</param>
        /// <returns>the RGBA color instance.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Color FromRgba(int r, int g, int b, int a)
        {
            return new Color(r, g, b, a);
        }

        /// <summary>
        /// Returns a new RGB Color instance with the requested Red, Green, and Blue channels. The Alpha channel is set if hex contains one.
        /// </summary>
        /// <param name="hex">A string that contains the hexadecimal RGB(A) color representation.</param>
        /// <returns>the RGBA color instance.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Color FromHex(string hex)
        {
            if (hex == null)
            {
                throw new ArgumentNullException("hex");
            }

            // #fff
            // #ffffff
            // #ffff
            // #ffffffff
            if (hex.Length > 0 && hex[0] == '#') hex = hex.Substring(1);
            if (hex.Length == 3) hex += "F";
            if (hex.Length == 4)
                hex = new String(new char[] { hex[0], hex[0], hex[1], hex[1], hex[2], hex[2], hex[3], hex[3] });
            if (hex.Length == 6) hex += "FF";
            if (hex.Length != 8)
            {
                throw new ArgumentException(@"Hex string is not valid color. length of hex should be 3, 4, 6, 8");
            }
            Color c = new Color();
            c._value = Convert.ToInt32(hex, 16);
            return c;
        }

        private static ArgumentException CreateColorArgumentException(int value, string color)
        {
            return new ArgumentException(string.Format("'{0}' is not a valid" +
                        " value for '{1}'. '{1}' should be greater or equal to 0 and" +
                        " less than or equal to 255.", value, color));
        }

        #endregion  // Static Methods

        #region Methods

        /// <summary>
        /// Gets the 32-bits RGBA value of the color.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int GetRgba()
        {
            return _value;
        }

        /// <summary>
        /// Gets the 32-bits ARGB value of the color.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int GetArgb()
        {
            return (int)((uint)A << 24 | (uint)R << 16 | (uint)G << 8 | (uint)B);
        }

        /// <summary>
        /// Returns a string representation in Hex. (ex: \#FFFFFFFF in RGBA order)
        /// </summary>
        /// <returns>The string representation in Hex.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string ToHex()
        {
            return "#" + _value.ToString("X8");
        }

        /// <summary>
        /// Returns a boolean indicating whether the given Color is equal to this Color instance.
        /// </summary>
        /// <param name="other">The Color to compare this instance to.</param>
        /// <returns>True if the other Color is equal to this instance; False otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Equals(Color other)
        {
            return _value == other._value;
        }

        /// <summary>
        /// Returns a boolean indicating whether the given Object is equal to this Color instance.
        /// </summary>
        /// <param name="obj">The Object to compare against.</param>
        /// <returns>True if the Object is equal to this Color; False otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override bool Equals(object obj)
        {
            if (obj is Color)
            {
                return Equals((Color)obj);
            }
            return false;
        }

        /// <summary>
        /// Returns a string representation of the Color.
        /// </summary>
        /// <returns>The string representation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override string ToString()
        {
            return string.Format("Color [R={0}, G={1}, B={2}, A={3}]", R, G, B, A);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        #endregion  // Methods
    }
}
