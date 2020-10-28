/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.WebView
{
    /// <summary>
    /// This class provides the properties for setting the preference of a specific WebView.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class Settings
    {
        private IntPtr _handle;

        internal Settings(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Whether the JavaScript can be executed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool JavaScriptEnabled
        {
            get
            {
                return Interop.ChromiumEwk.ewk_settings_javascript_enabled_get(_handle);
            }

            set
            {
                Interop.ChromiumEwk.ewk_settings_javascript_enabled_set(_handle, value);
            }
        }

        /// <summary>
        /// Whether the images can be loaded automatically.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool LoadImageAutomatically
        {
            get
            {
                return Interop.ChromiumEwk.ewk_settings_loads_images_automatically_get(_handle);
            }

            set
            {
                Interop.ChromiumEwk.ewk_settings_loads_images_automatically_set(_handle, value);
            }
        }

        /// <summary>
        /// The default text encoding name.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string DefaultTextEncodingName
        {
            get
            {
                return Interop.ChromiumEwk.ewk_settings_default_text_encoding_name_get(_handle);
            }

            set
            {
                Interop.ChromiumEwk.ewk_settings_default_text_encoding_name_set(_handle, value);
            }
        }

        /// <summary>
        /// The default font size of a pixel.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int DefaultFontSize
        {
            get
            {
                return Interop.ChromiumEwk.ewk_settings_default_font_size_get(_handle);
            }

            set
            {
                Interop.ChromiumEwk.ewk_settings_default_font_size_set(_handle, value);
            }
        }
    }
}
