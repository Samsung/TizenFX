﻿/*
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
using System.ComponentModel;

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

        /// <summary>
        /// Whether the scripts can open windows.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool ScriptsCanOpenWindows
        {
            get
            {
                return Interop.ChromiumEwk.ewk_settings_scripts_can_open_windows_get(_handle);
            }

            set
            {
                Interop.ChromiumEwk.ewk_settings_scripts_can_open_windows_set(_handle, value);
            }
        }
 
        /// <summary>
        /// Enable or Disable force zoom.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ForceZoom
        {
            get
            {
                return Interop.ChromiumEwk.ewk_settings_force_zoom_get(_handle);
            }

            set
            {
                Interop.ChromiumEwk.ewk_settings_force_zoom_set(_handle, value);
            }
        }

        /// <summary>
        /// Enable or Disable text autosizing.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TextAutosizing
        {
            get
            {
                return Interop.ChromiumEwk.ewk_settings_text_autosizing_enabled_get(_handle);
            }

            set
            {
                Interop.ChromiumEwk.ewk_settings_text_autosizing_enabled_set(_handle, value);
            }
        }

        /// <summary>
        /// Enable or Disable text zoom.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TextZoom
        {
            get
            {
                return Interop.ChromiumEwk.ewk_settings_text_zoom_enabled_get(_handle);
            }

            set
            {
                Interop.ChromiumEwk.ewk_settings_text_zoom_enabled_set(_handle, value);
            }
        }

        /// <summary>
        /// Enable or Disable the usage of keypad without user action.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UseKeypadWithoutUserAction
        {
            get
            {
                return Interop.ChromiumEwk.ewk_settings_uses_keypad_without_user_action_get(_handle);
            }

            set
            {
                Interop.ChromiumEwk.ewk_settings_uses_keypad_without_user_action_set(_handle, value);
            }
        }

        /// <summary>
        /// Enable or Disable Extra feature such as "edge,enable", "zoom,enable", "longpress,enable"
        /// "doubletap,enable" and "selection,magnifier".
        /// </summary>
        /// <param name="name">The name of the feature user wants to set or reset.</param>
        /// <param name="enable">The boolean value to set or reset.</param>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetExtraFeature(string name, bool enable)
        {
            Interop.ChromiumEwk.ewk_settings_extra_feature_set(_handle, name, enable);
        }

        /// <summary>
        /// Get status of Extra feature such as "edge,enable", "zoom,enable", "longpress,enable"
        /// "doubletap,enable" and "selection,magnifier".
        /// </summary>
        /// <param name="name">The name of the feature user wants to know status.</param>
        /// <returns>Status true or false is returned.</returns>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetExtraFeatureStatus(string name)
        {
             return Interop.ChromiumEwk.ewk_settings_extra_feature_get(_handle, name);
        }
    }
}
