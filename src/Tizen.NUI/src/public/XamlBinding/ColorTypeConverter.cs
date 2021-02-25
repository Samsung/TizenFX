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
using System.ComponentModel;
using System.Globalization;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.ColorTypeConverter")]
    [TypeConversion(typeof(Color))]
    public class ColorTypeConverter : TypeConverter
    {
        // Supported inputs
        // HEX		#rgb, #argb, #rrggbb, #aarrggbb
        // float array      0.5,0.5,0.5,0.5
        // Predefined color	    case insensitive
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                value = value.Trim();
                if (value.StartsWith("#", StringComparison.Ordinal))
                {
                    return FromHex(value);
                }

                string[] parts = value.Split(',');
                if (parts.Length == 1) //like Red or Color.Red
                {
                    parts = value.Split('.');
                    if (parts.Length == 1 || (parts.Length == 2 && parts[0] == "Color"))
                    {
                        string color = parts[parts.Length - 1];
                        switch (color)
                        {
                            case "Black": return Color.Black;
                            case "White": return Color.White;
                            case "Red": return Color.Red;
                            case "Green": return Color.Green;
                            case "Blue": return Color.Blue;
                            case "Yellow": return Color.Yellow;
                            case "Magenta": return Color.Magenta;
                            case "Cyan": return Color.Cyan;
                            case "Transparent": return Color.Transparent;
                        }
                    }
                }
                else if (parts.Length == 4) //like 0.5,0.5,0.5,0.5
                {
                    return new Color(Single.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                                     Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
                                     Single.Parse(parts[2].Trim(), CultureInfo.InvariantCulture),
                                     Single.Parse(parts[3].Trim(), CultureInfo.InvariantCulture));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Color)}");
        }

        static uint ToHex(char c)
        {
            ushort x = (ushort)c;
            if (x >= '0' && x <= '9')
                return (uint)(x - '0');

            x |= 0x20;
            if (x >= 'a' && x <= 'f')
                return (uint)(x - 'a' + 10);
            return 0;
        }

        static uint ToHexD(char c)
        {
            var j = ToHex(c);
            return (j << 4) | j;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Color FromRgba(int r, int g, int b, int a)
        {
            float red = (float)r / 255;
            float green = (float)g / 255;
            float blue = (float)b / 255;
            float alpha = (float)a / 255;
            return new Color(red, green, blue, alpha);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Color FromRgb(int r, int g, int b)
        {
            return FromRgba(r, g, b, 255);
        }

        static Color FromHex(string hex)
        {
            // Undefined
            if (hex.Length < 3)
                return Color.Black;
            int idx = (hex[0] == '#') ? 1 : 0;

            switch (hex.Length - idx)
            {
                case 3: //#rgb => ffrrggbb
                    var t1 = ToHexD(hex[idx++]);
                    var t2 = ToHexD(hex[idx++]);
                    var t3 = ToHexD(hex[idx]);

                    return FromRgb((int)t1, (int)t2, (int)t3);

                case 4: //#argb => aarrggbb
                    var f1 = ToHexD(hex[idx++]);
                    var f2 = ToHexD(hex[idx++]);
                    var f3 = ToHexD(hex[idx++]);
                    var f4 = ToHexD(hex[idx]);
                    return FromRgba((int)f2, (int)f3, (int)f4, (int)f1);

                case 6: //#rrggbb => ffrrggbb
                    return FromRgb((int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                            (int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                            (int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx])));

                case 8: //#aarrggbb
                    var a1 = ToHex(hex[idx++]) << 4 | ToHex(hex[idx++]);
                    return FromRgba((int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                            (int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                            (int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx])),
                            (int)a1);

                default: //everything else will result in unexpected results
                    return Color.Black;
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ConvertToString(object value)
        {
            if (value != null)
            {
                Color color = (Color)value;
                return color.R.ToString() + " " + color.G.ToString() + " " + color.B.ToString() + " " + color.A.ToString();
            }
            return "";
        }
    }
}
