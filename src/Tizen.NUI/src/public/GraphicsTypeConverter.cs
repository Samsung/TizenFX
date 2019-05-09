/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
        /// </summary>
        /// <returns>Convert script to px</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float ConvertScriptToPixel(string scriptValue)
        {
            float convertedValue = 0;
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
            return convertedValue;
        }

        /// <summary>
        /// </summary>
        /// <returns>Convert other type to px</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float ConvertToPixel(float value)
        {
            return value * (Window.Instance.Dpi.X / defaultDpi);
        }

        /// <summary>
        /// </summary>
        /// <returns>Convert px to other type</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float ConvertFromPixel(float value)
        {
            return value * (defaultDpi / Window.Instance.Dpi.X);
        }

    }

}
