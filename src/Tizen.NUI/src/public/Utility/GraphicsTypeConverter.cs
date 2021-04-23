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

using System.ComponentModel;
using System.Globalization;

namespace Tizen.NUI
{
    /// <summary>
    /// GraphicsTypeConverter class to convert types.
    /// </summary>
    /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GraphicsTypeConverter
    {

        private const float defaultDpi = 160.0f;

        /// <summary>
        /// Converts script to px
        /// </summary>
        /// <returns>Pixel value that is converted from input string</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float ConvertScriptToPixel(string scriptValue)
        {
            float convertedValue = 0;
            if (scriptValue != null)
            {
                if (scriptValue.EndsWith("dp"))
                {
                    convertedValue = ConvertToPixel(float.Parse(scriptValue.Substring(0, scriptValue.LastIndexOf("dp")), CultureInfo.InvariantCulture));
                }
                else if (scriptValue.EndsWith("px"))
                {
                    convertedValue = float.Parse(scriptValue.Substring(0, scriptValue.LastIndexOf("px")), CultureInfo.InvariantCulture);
                }
                else
                {
                    if (!float.TryParse(scriptValue, NumberStyles.Any, CultureInfo.InvariantCulture, out convertedValue))
                    {
                        NUILog.Error("Cannot convert the script {scriptValue}\n");
                        convertedValue = 0;
                    }
                }
            }
            return convertedValue;
        }

        /// <summary>
        /// Converts other type to px
        /// </summary>
        /// <returns>Pixel value that is converted by the the display matric</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float ConvertToPixel(float value)
        {
            return value * (NUIApplication.GetDefaultWindow().Dpi.X / defaultDpi);
        }

        /// <summary>
        /// Converts px to other type
        /// </summary>
        /// <returns>An converted value from pixel</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float ConvertFromPixel(float value)
        {
            return value * (defaultDpi / NUIApplication.GetDefaultWindow().Dpi.X);
        }
    }
}
