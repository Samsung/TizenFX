using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Efl
{
    namespace Ui
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
        }
    }
}
