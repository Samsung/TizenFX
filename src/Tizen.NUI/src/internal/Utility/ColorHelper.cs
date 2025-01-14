/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using System.Diagnostics;
using System.Globalization;

namespace Tizen.NUI
{
    internal static class ColorHelper
    {
        public static bool TryParseString(string textColor, out float r, out float g, out float b, out float a)
        {
            Debug.Assert(textColor != null);
            r = g = b = a = default;

            try
            {
                string textInput = textColor.ToUpperInvariant();
                textInput = textInput.Replace(" ", "");

                if (textInput.Length > 0 && textInput[0] == '#')
                {
                    textInput = textInput.Replace("#", "");
                    int textColorLength = textInput.Length;

                    if (textColorLength == 6 || textColorLength == 8) /* #RRGGBB or #RRGGBBAA */
                    {
                        r = ((float)Convert.ToInt32(textInput.Substring(0, 2), 16)) / 255.0f;
                        g = ((float)Convert.ToInt32(textInput.Substring(2, 2), 16)) / 255.0f;
                        b = ((float)Convert.ToInt32(textInput.Substring(4, 2), 16)) / 255.0f;
                        a = textInput.Length > 6 ? ((float)Convert.ToInt32(textInput.Substring(6, 2), 16)) / 255.0f : 1.0f;
                        return true;
                    }

                    if (textColorLength == 3 || textColorLength == 4) /* #RGB */
                    {
                        r = ((float)Convert.ToInt32(textInput.Substring(0, 1), 16)) / 15.0f;
                        g = ((float)Convert.ToInt32(textInput.Substring(1, 1), 16)) / 15.0f;
                        b = ((float)Convert.ToInt32(textInput.Substring(2, 1), 16)) / 15.0f;
                        a = textInput.Length > 3 ? ((float)Convert.ToInt32(textInput.Substring(3, 1), 16)) / 15.0f : 1.0f;
                        return true;
                    }

                    return false;
                }

                // example rgb(255,255,255) or rgb(255,255,255,1.0)
                bool isRGBA = textInput.StartsWith("RGBA(");
                bool isRGB = textInput.StartsWith("RGB(");

                if (!isRGBA && !isRGB)
                {
                    return false;
                }

                if (isRGBA)
                    textInput = textInput.Substring(4);
                if (isRGB)
                    textInput = textInput.Substring(3);

                textInput = textInput.Replace(")", "");
                textInput = textInput.Replace("(", "");

                string[] components = textInput.Split(',');

                if (components.Length == 3 && isRGB)
                {
                    r = Math.Min(1.0f, ((float)Convert.ToInt32(components[0], 10)) / 255.0f);
                    g = Math.Min(1.0f, ((float)Convert.ToInt32(components[1], 10)) / 255.0f);
                    b = Math.Min(1.0f, ((float)Convert.ToInt32(components[2], 10)) / 255.0f);
                    a = 1.0f;
                    return true;
                }

                if (components.Length == 4 && isRGBA)
                {
                    r = Math.Min(1.0f, ((float)Convert.ToInt32(components[0], 10)) / 255.0f);
                    g = Math.Min(1.0f, ((float)Convert.ToInt32(components[1], 10)) / 255.0f);
                    b = Math.Min(1.0f, ((float)Convert.ToInt32(components[2], 10)) / 255.0f);
                    a = Math.Min(1.0f, float.Parse(components[3], CultureInfo.InvariantCulture));
                    return true;
                }
            }
            catch
            {
            }

            return false;
        }
    }

}


