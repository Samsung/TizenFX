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
 * See the License for the Sdpecific language governing permissions and
 * limitations under the License.
 *
 */

using System.ComponentModel;
using System.Globalization;

namespace Tizen.NUI
{
    /// <summary>
    /// Default SdpTypeConverter class to convert dp types.
    /// </summary>
    /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class SdpTypeConverter : GraphicsTypeConverter
    {
        private volatile static SdpTypeConverter sdpTypeConverter;

        /// <summary>
        /// An unique Singleton Instance of SdpTypeConverter
        /// </summary>
        /// <value>Singleton instance of SdpTypeConverter</value>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SdpTypeConverter Instance
        {
            get
            {
                if (sdpTypeConverter == null)
                {
                    sdpTypeConverter = new SdpTypeConverter();
                }

                return sdpTypeConverter;
            }
        }

        /// <summary>
        /// Converts script to pixel
        /// </summary>
        /// <returns>Pixel value that is converted from input string</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ConvertScriptToPixel(string scriptValue)
        {
            float convertedValue = 0;
            if (scriptValue != null)
            {
                if (scriptValue.EndsWith("sdp"))
                {
                    convertedValue = ConvertToPixel(float.Parse(scriptValue.Substring(0, scriptValue.LastIndexOf("sdp")), CultureInfo.InvariantCulture));
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
        /// Converts Sdp type to pixel
        /// </summary>
        /// <returns>Pixel value that is converted by the the diSdplay matric</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ConvertToPixel(float value)
        {
            return value * ((float)(GraphicsTypeManager.Instance.Dpi * GraphicsTypeManager.Instance.ScalingFactor) / GraphicsTypeManager.Instance.BaselineDpi);
        }

        /// <summary>
        /// Converts pixel to Sdp type
        /// </summary>
        /// <returns>An converted value from pixel</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ConvertFromPixel(float value)
        {
            return value * (GraphicsTypeManager.Instance.BaselineDpi / (float)(GraphicsTypeManager.Instance.Dpi * GraphicsTypeManager.Instance.ScalingFactor));
        }
    }
}
