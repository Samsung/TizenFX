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
    public static class Elementary
    {
        private static readonly string _themeFilePath = "/usr/share/elm-sharp/elm-sharp-theme.edj";

        public static void Initialize()
        {
            Interop.Elementary.elm_init(0, null);
        }

        public static void Shutdown()
        {
            Interop.Elementary.elm_shutdown();
        }

        public static void Run()
        {
            Interop.Elementary.elm_run();
        }

        public static void ThemeOverlay()
        {
            if (File.Exists(_themeFilePath))
            {
                Interop.Elementary.elm_theme_overlay_add(IntPtr.Zero, _themeFilePath);
            }
        }

        public static double GetSystemScrollFriction()
        {
            return Interop.Elementary.elm_config_scroll_bring_in_scroll_friction_get();
        }

        public static void SetSystemScrollFriction(double timeSet)
        {
            Interop.Elementary.elm_config_scroll_bring_in_scroll_friction_set(timeSet);
        }
    }
}
