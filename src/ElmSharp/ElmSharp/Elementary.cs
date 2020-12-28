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
    /// Focus Autoscroll mode.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum FocusAutoScrollMode
    {
        /// <summary>
        /// Directly show the focused region or item automatically.
        /// </summary>
        Show,

        /// <summary>
        /// Do not show the focused region or item automatically.
        /// </summary>
        None,

        /// <summary>
        /// Bring in the focused region or item automatically, which might involve the scrolling.
        /// </summary>
        BringIn
    }

    /// <summary>
    /// The Elementary is a general elementary, a VERY SIMPLE toolkit.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public static class Elementary
    {
        private const string _themeFilePath = "/usr/share/elm-sharp/elm-sharp-theme.edj";
        private const string _tvThemeFilePath = "/usr/share/elm-sharp/vd-elm-sharp-theme.edj";

        /// <summary>
        /// EvasObjectRealized will be triggered when the EvasObject is realized.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static event EventHandler EvasObjectRealized;

        /// <summary>
        /// ItemObjectRealized will be triggered when the ItemObject is realized.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static event EventHandler ItemObjectRealized;

        internal static void SendEvasObjectRealized(EvasObject obj)
        {
            EvasObjectRealized?.Invoke(obj, EventArgs.Empty);
        }

        internal static void SendItemObjectRealized(ItemObject obj)
        {
            ItemObjectRealized?.Invoke(obj, EventArgs.Empty);
        }

        /// <summary>
        /// Gets or sets the configured finger size.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Gets or sets the enable status of the focus highlight animation.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// <since_tizen> preview </since_tizen>
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
        /// Gets or sets the amount of inertia, a scroller imposes during a region to bring animations.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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
        /// Gets or sets the focus on autoscroll mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static FocusAutoScrollMode FocusAutoScrollMode
        {
            get
            {
                return (FocusAutoScrollMode)Interop.Elementary.elm_config_focus_autoscroll_mode_get();
            }
            set
            {
                Interop.Elementary.elm_config_focus_autoscroll_mode_set((Interop.Elementary.Elm_Focus_Autoscroll_Mode)value);
            }
        }

        /// <summary>
        /// Initializes Elementary.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static void Initialize()
        {
            if (!Window.IsPreloaded)
                Interop.Elementary.elm_init(0, null);
        }

        /// <summary>
        /// Shuts down Elementary.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static void Shutdown()
        {
            Interop.Elementary.elm_shutdown();
        }

        /// <summary>
        /// Runs the elementary's main loop.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static void Run()
        {
            Interop.Elementary.elm_run();
        }

        /// <summary>
        /// Prepends a theme overlay to the list of overlays.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ThemeOverlay()
        {
            if (!Window.IsPreloaded)
            {
                if (File.Exists(_themeFilePath))
                    AddThemeOverlay(_themeFilePath);

                if (Elementary.GetProfile() == "tv" && File.Exists(_tvThemeFilePath))
                    AddThemeOverlay(_tvThemeFilePath);
            }
        }

        /// <summary>
        /// Prepends a theme overlay to the list of overlays.
        /// </summary>
        /// <param name="filePath">The edje file path to be used.</param>
        /// <since_tizen> preview </since_tizen>
        public static void AddThemeOverlay(string filePath)
        {
            Interop.Elementary.elm_theme_overlay_add(IntPtr.Zero, filePath);
        }

        /// <summary>
        /// Deletes a theme overlay from the list of overlays.
        /// </summary>
        /// <param name="filePath">The name of the theme overlay.</param>
        /// <since_tizen> preview </since_tizen>
        public static void DeleteThemeOverlay(string filePath)
        {
            Interop.Elementary.elm_theme_overlay_del(IntPtr.Zero, filePath);
        }

        /// <summary>
        /// Frees a theme.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static void FreeTheme()
        {
            Interop.Elementary.elm_theme_free(IntPtr.Zero);
        }

        /// <summary>
        /// Sets the theme search order for the given theme.
        /// </summary>
        /// <param name="theme">Theme search string.</param>
        /// <remarks>This sets the search string for the theme in path-notation from the first theme to search, to last, delimited by the : character. For example, "shiny:/path/to/file.edj:default".</remarks>
        /// <since_tizen> preview </since_tizen>
        public static void SetTheme(string theme)
        {
            Interop.Elementary.elm_theme_set(IntPtr.Zero, theme);
        }

        /// <summary>
        /// Flushes the current theme.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static void FlushTheme()
        {
            Interop.Elementary.elm_theme_flush(IntPtr.Zero);
        }

        /// <summary>
        /// This flushes all the themes (default and specific ones).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static void FlushAllThemes()
        {
            Interop.Elementary.elm_theme_full_flush();
        }

        /// <summary>
        /// Deletes a theme extension from the list of extensions.
        /// </summary>
        /// <param name="item">The name of the theme extension.</param>
        /// <since_tizen> preview </since_tizen>
        public static void DeleteThemeExtention(string item)
        {
            Interop.Elementary.elm_theme_extension_del(IntPtr.Zero, item);
        }

        /// <summary>
        /// Gets the amount of inertia that a scroller imposes during region to bring animations.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static double GetSystemScrollFriction()
        {
            return BringInScrollFriction;
        }

        /// <summary>
        /// Sets the amount of inertia that a scroller imposes during the region bring animations.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetSystemScrollFriction(double timeSet)

        {
            BringInScrollFriction = timeSet;
        }

        /// <summary>
        /// Gets the elementary's profile in use.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string GetProfile()
        {
            return Interop.Elementary.elm_config_profile_get();
        }

        /// <summary>
        /// Sets the global scaling factor.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetScale(double scale)
        {
            Scale = scale;
        }

        /// <summary>
        /// Gets the global scaling factor.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static double GetScale()
        {
            return Scale;
        }

        /// <summary>
        /// Use FlushAllCache instead.
        /// </summary>
        [Obsolete("use FlushAllCache instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void FlushAllCashe()
        {
            Interop.Elementary.elm_cache_all_flush();
        }

        /// <summary>
        /// Flushes all the cache.
        /// Frees all data that was in cache and is not currently being used, to reduce memory usage. This frees Edje's, Evas', and Eet's cache.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static void FlushAllCache()
        {
            Interop.Elementary.elm_cache_all_flush();
        }

        /// <summary>
        /// Changes the language of the current application.
        /// </summary>
        /// <param name="language">The language to set must be the full name of the locale.</param>
        /// <since_tizen> preview </since_tizen>
        public static void SetLanguage(string language)
        {
            Interop.Elementary.elm_language_set(language);
        }

        /// <summary>
        /// Sets a new policy's value (for a given policy group/identifier).
        /// </summary>
        /// <param name="policy">The policy identifier.</param>
        /// <param name="value">The policy value, which depends on the identifier.</param>
        /// <returns></returns>
        /// <since_tizen> preview </since_tizen>
        public static bool SetPolicy(uint policy, int value)
        {
            return Interop.Elementary.elm_policy_set(policy, value);
        }

        /// <summary>
        /// Reloads the elementary's configuration, bounded to the current selected profile.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ReloadConfig()
        {
            Interop.Elementary.elm_config_reload();
        }

        /// <summary>
        /// Flushes all the configuration settings, and then applies those settings to all applications using elementary on the current display.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static void FlushAllConfig()
        {
            Interop.Elementary.elm_config_all_flush();
        }
    }
}
