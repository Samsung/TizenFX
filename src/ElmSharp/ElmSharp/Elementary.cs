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
using System.ComponentModel;
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
        /// Gets or sets the configured finger size.
        /// </summary>
        public static int FingerSize
        {
            get
            {
                return Interop.Elementary.elm_config_finger_size_get();
            }
            set
            {
                Interop.Elementary.elm_config_finger_size_set(value);
            }
        }

        /// <summary>
        /// Gets or sets the enable status of the focus highlight animation
        /// </summary>
        public static bool IsFocusHighlightAnimation
        {
            get
            {
                return Interop.Elementary.elm_config_focus_highlight_animate_get();
            }
            set
            {
                Interop.Elementary.elm_config_focus_highlight_animate_set(value);
            }
        }

        /// <summary>
        /// Gets or sets the system mirrored mode.
        /// This determines the default mirrored mode of widgets.
        /// </summary>
        public static bool IsMirrored
        {
            get
            {
                return Interop.Elementary.elm_config_mirrored_get();
            }
            set
            {
                Interop.Elementary.elm_config_mirrored_set(value);
            }
        }

        /// <summary>
        /// Gets or sets the enable status of the focus highlight.
        /// </summary>
        public static bool CanFocusHighlight
        {
            get
            {
                return Interop.Elementary.elm_config_focus_highlight_enabled_get();
            }
            set
            {
                Interop.Elementary.elm_config_focus_highlight_enabled_set(value);
            }
        }

        /// <summary>
        /// Gets or sets the base scale of the application.
        /// </summary>
        public static double AppBaseScale
        {
            get
            {
                return Interop.Elementary.elm_app_base_scale_get();
            }
            set
            {
                Interop.Elementary.elm_app_base_scale_set(value);
            }
        }

        /// <summary>
        /// Gets or sets the global scaling factor.
        /// </summary>
        public static double Scale
        {
            get
            {
                return Interop.Elementary.elm_config_scale_get();
            }
            set
            {
                Interop.Elementary.elm_config_scale_set(value);
            }
        }

        /// <summary>
        /// Gets or sets the amount of inertia a scroller imposes during region bring animations.
        /// </summary>
        public static double BringInScrollFriction
        {
            get
            {
                return Interop.Elementary.elm_config_scroll_bring_in_scroll_friction_get();
            }
            set
            {
                Interop.Elementary.elm_config_scroll_bring_in_scroll_friction_set(value);
            }
        }

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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ThemeOverlay()
        {
            if (File.Exists(_themeFilePath))
            {
                AddThemeOverlay(_themeFilePath);
            }
        }

        /// <summary>
        /// Prepends a theme overlay to the list of overlays
        /// </summary>
        /// <param name="filePath">The Edje file path to be used.</param>
        public static void AddThemeOverlay(string filePath)
        {
            Interop.Elementary.elm_theme_overlay_add(IntPtr.Zero, filePath);
        }

        /// <summary>
        /// Delete a theme overlay from the list of overlays
        /// </summary>
        /// <param name="filePath">The name of the theme overlay.</param>
        public static void DeleteThemeOverlay(string filePath)
        {
            Interop.Elementary.elm_theme_overlay_del(IntPtr.Zero, filePath);
        }

        /// <summary>
        /// Free a theme
        /// </summary>
        public static void FreeTheme()
        {
            Interop.Elementary.elm_theme_free(IntPtr.Zero);
        }

        /// <summary>
        /// Set the theme search order for the given theme
        /// </summary>
        /// <param name="theme">Theme search string</param>
        /// <remarks>This sets the search string for the theme in path-notation from first theme to search, to last, delimited by the : character. Example:"shiny:/path/to/file.edj:default"</remarks>
        public static void SetTheme(string theme)
        {
            Interop.Elementary.elm_theme_set(IntPtr.Zero, theme);
        }

        /// <summary>
        /// Flush the current theme.
        /// </summary>
        public static void FlushTheme()
        {
            Interop.Elementary.elm_theme_flush(IntPtr.Zero);
        }

        /// <summary>
        /// This flushes all themes (default and specific ones).
        /// </summary>
        public static void FlushAllThemes()
        {
            Interop.Elementary.elm_theme_full_flush();
        }

        /// <summary>
        /// Deletes a theme extension from the list of extensions.
        /// </summary>
        /// <param name="item">The name of the theme extension.</param>
        public static void DeleteThemeExtention(string item)
        {
            Interop.Elementary.elm_theme_extension_del(IntPtr.Zero, item);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static double GetSystemScrollFriction()
        {
            return BringInScrollFriction;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetSystemScrollFriction(double timeSet)
        {
            BringInScrollFriction = timeSet;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string GetProfile()
        {
            return Interop.Elementary.elm_config_profile_get();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetScale(double scale)
        {
            Scale = scale;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static double GetScale()
        {
            return Scale;
        }

        /// <summary>
        /// Flush all caches.
        /// Frees all data that was in cache and is not currently being used to reduce memory usage. This frees Edje's, Evas' and Eet's cache.
        /// </summary>
        public static void FlushAllCashe()
        {
            Interop.Elementary.elm_cache_all_flush();
        }

        /// <summary>
        /// Changes the language of the current application.
        /// </summary>
        /// <param name="language">The language to set, must be the full name of the locale.</param>
        public static void SetLanguage(string language)
        {
            Interop.Elementary.elm_language_set(language);
        }

        /// <summary>
        /// Sets a new policy's value (for a given policy group/identifier).
        /// </summary>
        /// <param name="policy">The policy identifier</param>
        /// <param name="value">The policy value, which depends on the identifier</param>
        /// <returns></returns>
        public static bool SetPolicy(uint policy, int value)
        {
            return Interop.Elementary.elm_policy_set(policy, value);
        }

        /// <summary>
        /// Reloads Elementary's configuration, bounded to the current selected profile.
        /// </summary>
        public static void ReloadConfig()
        {
            Interop.Elementary.elm_config_reload();
        }

        /// <summary>
        /// Flushes all config settings and then applies those settings to all applications using elementary on the current display.
        /// </summary>
        public static void FlushAllConfig()
        {
            Interop.Elementary.elm_config_all_flush();
        }
    }
}