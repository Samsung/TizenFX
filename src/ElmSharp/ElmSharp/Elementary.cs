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
using System.IO;

namespace ElmSharp
{
    /// <summary>
    /// The Elementary is a General Elementary,a VERY SIMPLE toolkit.
    /// </summary>
    public static class Elementary
    {
        private static readonly string _themeFilePath = "/usr/share/elm-sharp/elm-sharp-theme.edj";

        /// <summary>
        /// Initializes Elementary.
        /// </summary>
        public static void Initialize()
        {
            Interop.Elementary.elm_init(0, null);
        }

        /// <summary>
        /// Shuts down Elementary.
        /// </summary>
        public static void Shutdown()
        {
            Interop.Elementary.elm_shutdown();
        }

        /// <summary>
        /// Runs Elementary's main loop.
        /// </summary>
        public static void Run()
        {
            Interop.Elementary.elm_run();
        }

        /// <summary>
        /// Prepends a theme overlay to the list of overlays.
        /// </summary>
        public static void ThemeOverlay()
        {
            if (File.Exists(_themeFilePath))
            {
                Interop.Elementary.elm_theme_overlay_add(IntPtr.Zero, _themeFilePath);
            }
        }

        /// <summary>
        /// Gets the amount of inertia a scroller imposes during region bring animations.
        /// </summary>
        /// <returns>The bring in scroll friction</returns>
        public static double GetSystemScrollFriction()
        {
            return Interop.Elementary.elm_config_scroll_bring_in_scroll_friction_get();
        }

        /// <summary>
        /// Sets the amount of inertia a scroller imposes during region bring animations.
        /// </summary>
        /// <param name="timeSet">The bring in scroll friction</param>
        public static void SetSystemScrollFriction(double timeSet)
        {
            Interop.Elementary.elm_config_scroll_bring_in_scroll_friction_set(timeSet);
        }

        /// <summary>
        /// Gets Elementary's profile in use.
        /// </summary>
        /// <returns>The profile name</returns>
        public static string GetProfile()
        {
            return Interop.Elementary.elm_config_profile_get();
        }

        /// <summary>
        /// Sets the global scaling factor.
        /// This sets the globally configured scaling factor that is applied to all objects.
        /// </summary>
        /// <param name="scale">The scaling factor to set</param>
        public static void SetScale(double scale)
        {
            Interop.Elementary.elm_config_scale_set(scale);
        }

        /// <summary>
        /// Gets the global scaling factor.
        /// This gets the globally configured scaling factor that is applied to all objects.
        /// </summary>
        /// <returns>The scaling factor</returns>
        public static double GetScale()
        {
            return Interop.Elementary.elm_config_scale_get();
        }
    }
}
