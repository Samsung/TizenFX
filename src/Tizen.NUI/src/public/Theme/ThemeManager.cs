/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
extern alias TizenSystemInformation;
using TizenSystemInformation.Tizen.System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.Xaml;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary></summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ThemeManager
    {
        private enum Profile
        {
            Common = 0,
            Mobile = 1,
            TV = 2,
            Wearable = 3
        }

        private static readonly string[] nuiThemeProjects =
        {
            "Tizen.NUI",
            "Tizen.NUI.Components",
            "Tizen.NUI.Wearable"
        };

        /// <summary>
        /// Table that indicates deefault theme id by device profile.
        /// Note that, the fallback of null value is Common value.
        /// </summary>
        private static readonly string[] profileDefaultTheme =
        {
            /* Common   */ "Tizen.NUI.Theme.Common",
            /* Mobile   */ "Tizen.NUI.Theme.Common",
            /* TV       */ null,
            /* Wearable */ "Tizen.NUI.Theme.Wearable",
        };

        private static Theme currentTheme;
        private static List<Theme> builtinThemes; // First item is default theme of the current profile.
        private static bool isLoadingDefault = false;
        private static Profile? currentProfile;

        /// <summary>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<ThemeChangedEventArgs> ThemeChanged;

        internal static Theme CurrentTheme
        {
            get
            {
                if (currentTheme == null)
                {
                    currentTheme = DefaultTheme;
                }
                return currentTheme;
            }
            set
            {
                currentTheme = value;
                NotifyThemeChanged();
            }
        }

        internal static Theme DefaultTheme
        {
            get => BuiltinThemes?[0] ?? new Theme();
        }

        private static List<Theme> BuiltinThemes
        {
            get
            {
                if (builtinThemes == null && !isLoadingDefault)
                {
                    isLoadingDefault = true;

                    // Set the default theme as first item.
                    builtinThemes = new List<Theme>
                    {
                        LoadBuiltinTheme(profileDefaultTheme[(int)CurrentProfile])
                    };

                    isLoadingDefault = false;
                }
                return builtinThemes;
            }
        }

        private static Profile CurrentProfile
        {
            get
            {
                if (currentProfile == null)
                {
                    currentProfile = Profile.Common;
                    string profileString = "";

                    try
                    {
                        Information.TryGetValue<string>("tizen.org/feature/profile", out profileString);
                        Tizen.Log.Info("NUI", "Profile for initial theme found : " + profileString);
                    }
                    catch
                    {
                        Tizen.Log.Info("NUI", "Unknown device profile\n");
                    }
                    finally
                    {
                        if (string.Equals(profileString, "mobile"))
                        {
                            currentProfile = Profile.Mobile;
                        }
                        else if (string.Equals(profileString, "tv"))
                        {
                            currentProfile = Profile.TV;
                        }
                        else if (string.Equals(profileString, "wearable"))
                        {
                            currentProfile = Profile.Wearable;
                        }
                    }
                }
                return (Profile)currentProfile;
            }
        }

        /// <summary>
        /// Apply them to the NUI.
        /// This changes look of the existing components with property <seealso cref="View.ThemeChangeSensitive"/> on.
        /// This also affects all components created afterwards.
        /// </summary>
        /// <param name="theme">The theme instance to be applied.</param>
        /// <exception cref="ArgumentNullException">The given theme is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ApplyTheme(Theme theme)
        {
            var newTheme = (Theme)theme?.Clone() ?? throw new ArgumentNullException($"Invalid theme.");

            if (string.IsNullOrEmpty(newTheme.Id))
            {
                newTheme.Id = "NONAME";
            }

            CurrentTheme = newTheme;
        }

        /// <summary>
        /// Load a style with style name in the current theme.
        /// For components, the style name is a component name (e.g. Button) in normal case.
        /// </summary>
        /// <param name="styleName">The style name</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ViewStyle GetStyle(string styleName)
        {
            if (styleName == null)
            {
                throw new ArgumentNullException(nameof(styleName));
            }
            return (CurrentTheme.GetStyle(styleName) ?? DefaultTheme.GetStyle(styleName))?.Clone();
        }

        /// <summary>
        /// Load a style with View type in the current theme.
        /// </summary>
        /// <param name="viewType">The type of View</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ViewStyle GetStyle(Type viewType)
        {
            if (viewType == null)
            {
                throw new ArgumentNullException(nameof(viewType));
            }

            var currentType = viewType;
            ViewStyle resultStyle = null;

            do
            {
                if (currentType.Equals(typeof(Tizen.NUI.BaseComponents.View))) break;
                resultStyle = GetStyle(currentType.Name);
                currentType = currentType.BaseType;
            }
            while (resultStyle == null && currentType != null);

            return resultStyle;
        }

        /// <summary>
        /// Get a cloned built-in theme.
        /// </summary>
        /// <param name="themeId">The built-in theme id.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Theme GetBuiltinTheme(string themeId)
        {
            Theme result = null;
            int index = BuiltinThemes.FindIndex(x => string.IsNullOrEmpty(x?.Id) && x.Id.Equals(themeId, StringComparison.OrdinalIgnoreCase));
            if (index > 0)
            {
                result = (Theme)BuiltinThemes[index];
            }
            else
            {
                var theme = LoadBuiltinTheme(themeId);
                BuiltinThemes.Add(theme);
                result = theme;
            }
            return (Theme)result?.Clone();
        }

        private static Theme LoadBuiltinTheme(string id)
        {
            var loaded = new Theme()
            {
                Id = id,
            };

            if (string.IsNullOrEmpty(id)) return loaded;

            foreach (var project in nuiThemeProjects)
            {
                string path = StyleManager.FrameworkResourcePath + "/Theme/" + project + "_" + id + ".xaml";

                try
                {
                    loaded.Merge(path);
                    loaded.Id = id;
                }
                catch (XamlParseException)
                {
                    Tizen.Log.Error("NUI", $"Could not find \"{path}\".\n");
                    Tizen.Log.Error("NUI", $"The assemblies used in the file may not be included in the project.\n");
                }
                catch (Exception)
                {
                    Tizen.Log.Error("NUI", $"Could not load \"{path}\"\n");
                }
            }

            return loaded;
        }

        private static void NotifyThemeChanged()
        {
            ThemeChanged?.Invoke(null, new ThemeChangedEventArgs(CurrentTheme?.Id));
        }
    }
}
