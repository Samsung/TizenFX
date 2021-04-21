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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// This static module provides methods that can manage NUI <see cref="Theme"/>.
    /// </summary>
    /// <example>
    /// To apply custom theme to the application, try <see cref="ApplyTheme(Theme)"/>.
    /// <code>
    /// var customTheme = new Theme(res + "customThemeFile.xaml");
    /// ThemeManager.ApplyTheme(customTheme);
    /// </code>
    /// </example>
    /// <summary></summary>
    /// <since_tizen> 9 </since_tizen>
    public static class ThemeManager
    {
        private static Theme defaultTheme;
        private static Theme currentTheme;
        private static readonly List<Theme> builtinThemes = new List<Theme>(); // Themes provided by framework.
        private static readonly List<IThemeCreator> packages = new List<IThemeCreator>();// This is to store default theme creators by packages.

        static ThemeManager()
        {
            AddPackageTheme(DefaultThemeCreator.Instance);
        }

        /// <summary>
        /// An event invoked after the theme has changed by <see cref="ApplyTheme(Theme)"/>.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static event EventHandler<ThemeChangedEventArgs> ThemeChanged;

        /// <summary>
        /// Internal one should be called before calling public ThemeChanged
        /// </summary>
        internal static WeakEvent<EventHandler<ThemeChangedEventArgs>> ThemeChangedInternal = new WeakEvent<EventHandler<ThemeChangedEventArgs>>();

        /// NOTE that, please remove this after remove Tizen.NUI.Components.StyleManager
        internal static Theme DefaultTheme
        {
            get => defaultTheme;
            set => defaultTheme = value;
        }

        internal static Theme CurrentTheme
        {
            get => currentTheme ?? defaultTheme;
            set
            {
                currentTheme = value;
                NotifyThemeChanged();
            }
        }

        private static bool ThemeApplied => defaultTheme.Count > 0 || (currentTheme != null && currentTheme.Count > 0);

        /// <summary>
        /// Apply theme to the NUI.
        /// This will change the appearance of the existing components with property <seealso cref="View.ThemeChangeSensitive"/> on.
        /// This also affects all components created afterwards.
        /// </summary>
        /// <param name="theme">The theme instance to be applied.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given theme is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static void ApplyTheme(Theme theme)
        {
            var newTheme = (Theme)theme?.Clone() ?? throw new ArgumentNullException(nameof(theme));

            if (string.IsNullOrEmpty(newTheme.Id))
            {
                newTheme.Id = "NONAME";
            }

            CurrentTheme = newTheme;
        }

        /// <summary>
        /// Change base theme.
        /// Originally base theme is a platform profile specific theme.
        /// User may change this to one of platform installed one.
        /// </summary>
        /// <param name="themeId">The installed theme Id.</param>
        /// <returns>true on success, false when it failed to find installed theme with given themeId.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given themeId is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool ApplyBaseTheme(string themeId)
        {
            if (themeId == null) throw new ArgumentNullException(nameof(themeId));

            var theme = GetBuiltinTheme(themeId);

            if (theme != null)
            {
                defaultTheme = theme;
                NotifyThemeChanged();
                return true;
            }

            Tizen.Log.Info("NUI", $"No Theme found with given id : {themeId}");

            return false;
        }

        /// <summary>
        /// Load a style with style name in the current theme.
        /// For components, the default style name of a component is a component name with namespace (e.g. Tizen.NUI.Components.Button).
        /// </summary>
        /// <param name="styleName">The style name.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given styleName is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static ViewStyle GetStyle(string styleName)
        {
            if (styleName == null) throw new ArgumentNullException(nameof(styleName));
            return GetStyleWithoutClone(styleName)?.Clone();
        }

        /// <summary>
        /// Load a style with view type in the current theme.
        /// If it failed to find a style with the given type, it will try with it's parent type until it succeeds.
        /// </summary>
        /// <param name="viewType"> The type of the view. Full name of the given type will be a key to find a style in the current theme. (e.g. Tizen.NUI.Components.Button) </param>
        /// <exception cref="ArgumentNullException">Thrown when the given viewType is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static ViewStyle GetStyle(Type viewType)
        {
            if (viewType == null) throw new ArgumentNullException(nameof(viewType));
            return GetStyleWithoutClone(viewType)?.Clone();
        }

        /// <summary>
        /// Load a style with style name in the current theme.
        /// </summary>
        /// <param name="styleName">The style name.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static ViewStyle GetStyleWithoutClone(string styleName)
        {
            if (!ThemeApplied) return null;

            return currentTheme?.GetStyle(styleName) ?? defaultTheme.GetStyle(styleName);
        }

        /// <summary>
        /// Load a style with View type in the current theme.
        /// </summary>
        /// <param name="viewType">The type of View.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static ViewStyle GetStyleWithoutClone(Type viewType)
        {
            if (!ThemeApplied) return null;

            return currentTheme?.GetStyle(viewType) ?? defaultTheme.GetStyle(viewType);
        }

        /// <summary>
        /// Get a built-in theme.
        /// </summary>
        /// <param name="themeId">The built-in theme id.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static Theme GetBuiltinTheme(string themeId)
        {
            Debug.Assert(themeId != null);

            Theme result = null;
            int index = builtinThemes.FindIndex(x => string.Equals(x.Id, themeId, StringComparison.OrdinalIgnoreCase));
            if (index >= 0)
            {
                result = builtinThemes[index];
            }
            else
            {
                result = LoadBuiltinTheme(themeId);
            }
            return result;
        }

        /// <summary>
        /// !!! This is for internal use in fhub-nui. Please do not open it.
        /// Set a theme to be used as fallback.
        /// The fallback theme is set to profile specified theme by default.
        /// </summary>
        /// <param name="fallbackTheme">The theme instance to be applied as a fallback.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static void ApplyFallbackTheme(Theme fallbackTheme)
        {
            Debug.Assert(fallbackTheme != null);
            defaultTheme = (Theme)fallbackTheme?.Clone();
        }

        /// <summary>
        /// Set an external theme as a base theme.
        /// </summary>
        /// <param name="externalTheme">The external theme instance to be applied as base.</param>
        internal static void ApplyExternalTheme(IExternalTheme externalTheme)
        {
            Debug.Assert(defaultTheme != null);

            if (defaultTheme.HasSameIdAndVersion(externalTheme))
            {
                return;
            }

            int index = builtinThemes.FindIndex(x => x.HasSameIdAndVersion(externalTheme));
            if (index >= 0 && builtinThemes[index].PackageCount == packages.Count)
            {
                defaultTheme = builtinThemes[index];
                NotifyThemeChanged();
                return;
            }

            var newTheme = new Theme()
            {
                Id = externalTheme.Id,
                Version = externalTheme.Version
            };

            AddToBuiltinThemes(newTheme);

            foreach (IThemeCreator themeCreator in packages)
            {
                var packageTheme = themeCreator.Create();
                Debug.Assert(packageTheme != null);

                packageTheme.ApplyExternalTheme(externalTheme, themeCreator.GetExternalThemeKeyListSet());
                newTheme.MergeWithoutClone(packageTheme);
            }

            defaultTheme = newTheme;
            NotifyThemeChanged();
        }

        internal static void AddPackageTheme(IThemeCreator themeCreator)
        {
            if (packages.Contains(themeCreator))
            {
                return;
            }
            packages.Add(themeCreator);

            var packageTheme = themeCreator.Create();
            Debug.Assert(packageTheme != null);

            var externalTheme = ExternalThemeManager.GetCurrentTheme();
            if (externalTheme != null && !packageTheme.HasSameIdAndVersion(externalTheme))
            {
                packageTheme.ApplyExternalTheme(externalTheme, themeCreator.GetExternalThemeKeyListSet());
            }

            if (defaultTheme == null)
            {
                defaultTheme = new Theme()
                {
                    Id = packageTheme.Id,
                    Version = packageTheme.Version
                };
                AddToBuiltinThemes(defaultTheme);
            }

            defaultTheme.MergeWithoutClone(packageTheme);
            defaultTheme.PackageCount++;
        }

        private static void AddToBuiltinThemes(Theme theme)
        {
            int index = builtinThemes.FindIndex(x => x.Id.Equals(theme.Id, StringComparison.OrdinalIgnoreCase));
            if (index >= 0)
            {
                builtinThemes[index] = theme;
            }
            else
            {
                builtinThemes.Add(theme);
            }
        }

        private static Theme LoadBuiltinTheme(string id)
        {
            Debug.Assert(id != null);
            // Load from tizen-theme-manager
            var externalTheme = ExternalThemeManager.GetTheme(id);

            if (externalTheme == null)
            {
                return null;
            }

            var newTheme = new Theme()
            {
                Id = externalTheme.Id,
                Version = externalTheme.Version
            };

            AddToBuiltinThemes(newTheme);

            foreach (IThemeCreator themeCreator in packages)
            {
                var packageTheme = themeCreator.Create();
                Debug.Assert(packageTheme != null);

                packageTheme.ApplyExternalTheme(externalTheme, themeCreator.GetExternalThemeKeyListSet());
                newTheme.MergeWithoutClone(packageTheme);
            }

            return newTheme;
        }

        private static void NotifyThemeChanged()
        {
            Debug.Assert(defaultTheme != null);

            var id = currentTheme?.Id ?? defaultTheme.Id;
            ThemeChangedInternal.Invoke(null, new ThemeChangedEventArgs(id));
            ThemeChanged?.Invoke(null, new ThemeChangedEventArgs(id));
        }
    }
}
