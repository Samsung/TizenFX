/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Mono.Cecil;
using Mono.Cecil.Cil;
using Tizen.NUI.Xaml;
using Tizen.NUI.Xaml.Build.Tasks;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    class ColorTypeConverter : ICompiledTypeConverter
    {
        internal class Color
        {
            internal float r;
            internal float g;
            internal float b;
            internal float a;

            internal Color(float r, float g, float b, float a)
            {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = a;
            }

            /// <summary>
            /// Gets the black colored Color class.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly Color Black = new Color(0.0f, 0.0f, 0.0f, 1.0f);

            /// <summary>
            /// Gets the white colored Color class.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly Color White = new Color(1.0f, 1.0f, 1.0f, 1.0f);

            /// <summary>
            /// Gets the red colored Color class.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly Color Red = new Color(1.0f, 0.0f, 0.0f, 1.0f);

            /// <summary>
            /// Gets the green colored Color class.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly Color Green = new Color(0.0f, 1.0f, 0.0f, 1.0f);

            /// <summary>
            /// Gets the blue colored Color class.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly Color Blue = new Color(0.0f, 0.0f, 1.0f, 1.0f);

            /// <summary>
            /// Gets the yellow colored Color class.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly Color Yellow = new Color(1.0f, 1.0f, 0.0f, 1.0f);

            /// <summary>
            /// Gets the magenta colored Color class.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly Color Magenta = new Color(1.0f, 0.0f, 1.0f, 1.0f);

            /// <summary>
            /// Gets the cyan colored Color class.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly Color Cyan = new Color(0.0f, 1.0f, 1.0f, 1.0f);

            /// <summary>
            /// Gets the  transparent colored Color class.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly Color Transparent = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }

        IEnumerable<Instruction> GenerateIL(ModuleDefinition module, params double[] args)
        {
            foreach (var d in args)
                yield return Instruction.Create(OpCodes.Ldc_R8, d);

            yield return Instruction.Create(OpCodes.Newobj, module.ImportCtorReference((XamlTask.nuiAssemblyName, XamlTask.nuiNameSpace, "Color"),
                parameterTypes: args.Select(a => ("mscorlib", "System", "Single")).ToArray()));
        }

        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            var module = context.Body.Method.Module;

            Color ret = ConvertFromInvariantString(value);

            if (null == ret)
            {
                throw new XamlParseException($"Cannot convert \"{value}\" into {typeof(Color)}", node);
            }

            return GenerateIL(module, ret.r, ret.g, ret.b, ret.a);
        }

        private Color ConvertFromInvariantString(string value)
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

            return null;
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

        public static Color FromRgba(int r, int g, int b, int a)
        {
            float red = (float)r / 255;
            float green = (float)g / 255;
            float blue = (float)b / 255;
            float alpha = (float)a / 255;
            return new Color(red, green, blue, alpha);
        }

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

                case 4: //#rgba => rrggbbaa
                    var f1 = ToHexD(hex[idx++]);
                    var f2 = ToHexD(hex[idx++]);
                    var f3 = ToHexD(hex[idx++]);
                    var f4 = ToHexD(hex[idx]);
                    return FromRgba((int)f1, (int)f2, (int)f3, (int)f4);

                case 6: //#rrggbb => ffrrggbb
                    return FromRgb((int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                            (int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                            (int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx])));

                case 8: //#rrggbbaa
                    return FromRgba((int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                            (int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                            (int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                            (int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx])));

                default: //everything else will result in unexpected results
                    return Color.Black;
            }
        }
    }
}
 
