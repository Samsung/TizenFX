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
using System.Globalization;

namespace ElmSharp
{
    /// <summary>
    /// The Color is a struct to record the check's state.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public struct Color
    {
        readonly int _a;
        readonly int _r;
        readonly int _g;
        readonly int _b;

        readonly Mode _mode;

        enum Mode
        {
            Default,
            Rgb
        }

        /// <summary>
        /// Gets a default Color instance.
        /// </summary>
        /// <remarks>
        /// In the default Color instance, the mode type is default with RGBA all set as -1.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public static Color Default
        {
            get { return new Color(-1, -1, -1, -1, Mode.Default); }
        }

        /// <summary>
        /// Gets whether the Color instance's mode is default or not.
        /// The return type is bool.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsDefault
        {
            get { return _mode == Mode.Default; }
        }

        /// <summary>
        /// Gets the A value of RGBA.
        /// A means the Alpha in color.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int A
        {
            get { return _a; }
        }

        /// <summary>
        /// Gets the R value of RGBA.
        /// R means the Red in color.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int R
        {
            get { return _r; }
        }

        /// <summary>
        /// Gets the G value of RGBA.
        /// G means the Green in color.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int G
        {
            get { return _g; }
        }

        /// <summary>
        /// Gets the B value of RGBA.
        /// B means the Blue in color.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int B
        {
            get { return _b; }
        }

        /// <summary>
        /// Creates and initializes a new instance of the Color class
        /// with RGB parameters.
        /// </summary>
        /// <param name="r">Red of RGB.</param>
        /// <param name="g">Green of RGB.</param>
        /// <param name="b">Blue of RGB.</param>
        /// <since_tizen> preview </since_tizen>
        public Color(int r, int g, int b) : this(r, g, b, 255)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the Color class
        /// with RGBA parameters.
        /// </summary>
        /// <param name="r">Red of RGBA.</param>
        /// <param name="g">Green of RGBA.</param>
        /// <param name="b">Blue of RGBA.</param>
        /// <param name="a">Alpha of RGBA.</param>
        /// <since_tizen> preview </since_tizen>
        public Color(int r, int g, int b, int a) : this(r, g, b, a, Mode.Rgb)
        {
        }

        Color(int r, int g, int b, int a, Mode mode)
        {
            _mode = mode;
            if (mode == Mode.Rgb)
            {
                _r = Clamp(r, 0, 255);
                _g = Clamp(g, 0, 255);
                _b = Clamp(b, 0, 255);
                _a = Clamp(a, 0, 255);
            }
            else // Default
            {
                _r = _g = _b = _a = -1;
            }
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        /// <since_tizen> preview </since_tizen>
        public override int GetHashCode()
        {
            int hashcode = _r.GetHashCode();
            hashcode = (hashcode * 397) ^ _g.GetHashCode();
            hashcode = (hashcode * 397) ^ _b.GetHashCode();
            hashcode = (hashcode * 397) ^ _a.GetHashCode();
            return hashcode;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        /// true if the object and this instance are of the same type and represent the same value.
        /// otherwise, false.
        /// </returns>
        /// <since_tizen> preview </since_tizen>
        public override bool Equals(object obj)
        {
            if (obj is Color)
            {
                return EqualsInner(this, (Color)obj);
            }
            return base.Equals(obj);
        }

        /// <summary>
        /// Compares whether the two Color instances are same or not.
        /// </summary>
        /// <param name="a">A Color instance.</param>
        /// <param name="b">A Color instance.</param>
        /// <returns>The result whether the two instances are the same or not.
        /// Return type is bool. If they are same, return true.
        /// </returns>
        /// <since_tizen> preview </since_tizen>
        public static bool operator ==(Color a, Color b)
        {
            return EqualsInner(a, b);
        }

        /// <summary>
        /// Compares whether the two Color instances are different or not.
        /// </summary>
        /// <param name="a">A Color instance.</param>
        /// <param name="b">A Color instance.</param>
        /// <returns>The result whether the two instances are different or not.
        /// Return type is bool. If they are different, return true.
        /// </returns>
        /// <since_tizen> preview </since_tizen>
        public static bool operator !=(Color a, Color b)
        {
            return !(a == b);
        }

        static bool EqualsInner(Color color1, Color color2)
        {
            if (color1._mode == Mode.Default && color2._mode == Mode.Default)
                return true;
            return color1._r == color2._r && color1._g == color2._g && color1._b == color2._b && color1._a == color2._a;
        }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>The fully qualified type name.</returns>
        /// <since_tizen> preview </since_tizen>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "[Color: R={0}, G={1}, B={2}, A={3}]", R, G, B, A);
        }

        /// <summary>
        /// Gets a Color instance with a hexadecimal string parameter.
        /// </summary>
        /// <param name="hex">Hexadecimal string.</param>
        /// <returns>New instance of the Color struct.</returns>
        /// <since_tizen> preview </since_tizen>
        public static Color FromHex(string hex)
        {
            string ret = hex.Replace("#", "");
            switch (ret.Length)
            {
                case 3: //#rgb => ffrrggbb
                    ret = string.Format("ff{0}{1}{2}{3}{4}{5}", ret[0], ret[0], ret[1], ret[1], ret[2], ret[2]);
                    break;
                case 4: //#argb => aarrggbb
                    ret = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", ret[0], ret[0], ret[1], ret[1], ret[2], ret[2], ret[3], ret[3]);
                    break;
                case 6: //#rrggbb => ffrrggbb
                    ret = string.Format("ff{0}", ret);
                    break;
            }
            return FromUint(Convert.ToUInt32(ret.Replace("#", ""), 16));
        }

        /// <summary>
        /// Gets a Color instance with an unsigned integer parameter.
        /// </summary>
        /// <param name="argb">Unsigned integer indicates RGBA.</param>
        /// <returns>New instance of the Color struct.</returns>
        /// <since_tizen> preview </since_tizen>
        public static Color FromUint(uint argb)
        {
            return FromRgba((byte)((argb & 0x00ff0000) >> 0x10), (byte)((argb & 0x0000ff00) >> 0x8), (byte)(argb & 0x000000ff), (byte)((argb & 0xff000000) >> 0x18));
        }

        /// <summary>
        /// Gets a Color instance with R,G,B,A parameters.
        /// </summary>
        /// <param name="r">Red of RGBA.</param>
        /// <param name="g">Green of RGBA.</param>
        /// <param name="b">Blue of RGBA.</param>
        /// <param name="a">Alpha of RGBA.</param>
        /// <returns>New instance of the Color struct.</returns>
        /// <since_tizen> preview </since_tizen>
        public static Color FromRgba(int r, int g, int b, int a)
        {
            return new Color(r, g, b, a);
        }

        /// <summary>
        /// Gets a Color instance with R,G,B parameters.
        /// </summary>
        /// <param name="r">Red of RGB.</param>
        /// <param name="g">Green of RGB.</param>
        /// <param name="b">Blue of RGB.</param>
        /// <returns>New instance of the Color struct.</returns>
        /// <since_tizen> preview </since_tizen>
        public static Color FromRgb(int r, int g, int b)
        {
            return FromRgba(r, g, b, 255);
        }

        internal static int Clamp(int self, int min, int max)
        {
            return Math.Min(max, Math.Max(self, min));
        }

        #region Color Definitions
        /// <summary>
        /// The Tansparent is a predefined Color instance. It's RGBA value is (0, 0, 0, 0).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Transparent = FromRgba(0, 0, 0, 0);
        /// <summary>
        /// The Aqua is a predefined Color instance. It's RGB value is (0, 255, 255).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Aqua = FromRgb(0, 255, 255);
        /// <summary>
        /// The Black is a predefined Color instance. It's RGB value is (0, 0, 0).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Black = FromRgb(0, 0, 0);
        /// <summary>
        /// The Blue is a predefined Color instance. It's RGB value is (0, 0, 255).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Blue = FromRgb(0, 0, 255);
        /// <summary>
        /// The Fuchsia is a predefined Color instance. It's RGB value is (255, 0, 255).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Fuchsia = FromRgb(255, 0, 255);
        /// <summary>
        /// The Gray is a predefined Color instance. It's RGB value is (128, 128, 128).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Gray = FromRgb(128, 128, 128);
        /// <summary>
        /// The Green is a predefined Color instance. It's RGB value is (0, 128, 0).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Green = FromRgb(0, 128, 0);
        /// <summary>
        /// The Lime is a predefined Color instance. It's RGB value is (0, 255, 0).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Lime = FromRgb(0, 255, 0);
        /// <summary>
        /// The Maroon is a predefined Color instance. It's RGB value is (128, 0, 0).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Maroon = FromRgb(128, 0, 0);
        /// <summary>
        /// The Navy is a predefined Color instance. It's RGB value is (0, 0, 128).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Navy = FromRgb(0, 0, 128);
        /// <summary>
        /// The Olive is a predefined Color instance. It's RGB value is (128, 128, 0).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Olive = FromRgb(128, 128, 0);
        /// <summary>
        /// The Orange is a predefined Color instance. It's RGB value is (255, 165, 0).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Orange = FromRgb(255, 165, 0);
        /// <summary>
        /// The Purple is a predefined Color instance. It's RGB value is (128, 0, 128).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Purple = FromRgb(128, 0, 128);
        /// <summary>
        /// The Pink is a predefined Color instance. It's RGB value is (255, 102, 255).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Pink = FromRgb(255, 102, 255);
        /// <summary>
        /// The Red is a predefined Color instance. It's RGB value is (255, 0, 0).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Red = FromRgb(255, 0, 0);
        /// <summary>
        /// The Silver is a predefined Color instance. It's RGB value is (192, 192, 192).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Silver = FromRgb(192, 192, 192);
        /// <summary>
        /// The Teal is a predefined Color instance. It's RGB value is (0, 128, 128).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Teal = FromRgb(0, 128, 128);
        /// <summary>
        /// The White is a predefined Color instance. It's RGB value is (255, 255, 255).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color White = FromRgb(255, 255, 255);
        /// <summary>
        /// The Yellow is a predefined Color instance. It's RGB value is (255, 255, 0).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly Color Yellow = FromRgb(255, 255, 0);
        #endregion
    }
}
