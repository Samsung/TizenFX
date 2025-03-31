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
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;

#pragma warning disable CS0162 // Unreachable code detected: Some lines can be unreachable in TV profile
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
#pragma warning disable CA1724
    public static class ThemeManager
#pragma warning restore CA1724
    {
        /// <summary>
        /// The default light theme name preloaded in platform.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const string DefaultLightThemeName = "org.tizen.default-light-theme";

        /// <summary>
        /// The default dark theme name preloaded in platform.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const string DefaultDarkThemeName = "org.tizen.default-dark-theme";

        private static Theme baseTheme; // The base theme. It includes all styles including structures (Size, Position, Policy) of components.
        private static Theme platformTheme; // The platform theme. This may include color and image information without structure detail.
        private static Theme userTheme; // The user custom theme.
        private static Theme themeForUpdate; // platformTheme + userTheme. It is used when the component need to update according to theme change.
        private static Theme themeForInitialize; // baseTheme + platformTheme + userTheme. It is used when the component is created.
        private static readonly List<Theme> cachedPlatformThemes = new List<Theme>(); // Themes provided by framework.
        private static readonly List<string> packages = new List<string>();// This is to store base theme creators by packages.
        private static bool platformThemeEnabled;
        private static bool isInEventProgress;
        private static bool updateThemeDirty;

        static ThemeManager()
        {
            if (InitialThemeDisabled) return;

            ExternalThemeManager.Initialize();
            ExternalThemeManager.PlatformThemeChanged += OnExternalThemeChanged;
            AddPackageTheme(DefaultThemeCreator.Instance);
        }

        /// <summary>
        /// An event invoked when the theme is about to change (not applied to the views yet).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<ThemeChangedEventArgs> ThemeChanging;

        /// <summary>
        /// An event invoked after the theme has changed by <see cref="ApplyTheme(Theme)"/>.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static event EventHandler<ThemeChangedEventArgs> ThemeChanged;

        /// <summary>
        /// Internal one should be called before calling public ThemeChanged
        /// </summary>
        internal static WeakEvent<EventHandler<ThemeChangedEventArgs>> ThemeChangedInternal = new WeakEvent<EventHandler<ThemeChangedEventArgs>>();

        /// <summary>
        /// The current theme Id.
        /// It returns null when no theme is applied.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string ThemeId
        {
            get => userTheme?.Id;
        }

        /// <summary>
        /// The current platform theme Id.
        /// Note that it returns null when the platform theme is disabled.
        /// If the <seealso cref="NUIApplication.ThemeOptions.PlatformThemeEnabled"/> is given, it can be one of followings in tizen 6.5:
        /// <list type="bullet">
        /// <item>
        /// <description>org.tizen.default-light-theme</description>
        /// </item>
        /// <item>
        /// <description>org.tizen.default-dark-theme</description>
        /// </item>
        /// </list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string PlatformThemeId
        {
            get => platformTheme?.Id ?? (platformThemeEnabled ? baseTheme?.Id : null);
        }

        /// <summary>
        /// To support deprecated StyleManager.
        /// NOTE that, please remove this after remove Tizen.NUI.Components.StyleManager
        /// </summary>
        internal static Theme BaseTheme
        {
            get
            {
                if (baseTheme == null)
                {
                    baseTheme = new Theme();
                    UpdateThemeForInitialize();
                }
                return baseTheme;
            }
            set
            {
                baseTheme = value;
                UpdateThemeForInitialize();
            }
        }

        /// <summary>
        /// To support deprecated StyleManager.
        /// NOTE that, please remove this after remove Tizen.NUI.Components.StyleManager
        /// </summary>
        internal static Theme CurrentTheme
        {
            get => userTheme ?? baseTheme;
            set
            {
                userTheme = value;
                UpdateThemeForInitialize();
                NotifyThemeChanged();
            }
        }

        internal static bool PlatformThemeEnabled
        {
            get => platformThemeEnabled;
            set
            {
                if (platformThemeEnabled == value) return;

                platformThemeEnabled = value;

                if (platformThemeEnabled)
                {
                    ApplyExternalPlatformTheme(ExternalThemeManager.CurrentThemeId, ExternalThemeManager.CurrentThemeVersion);
                }
            }
        }

        internal static bool ApplicationThemeChangeSensitive { get; set; }

#if PROFILE_TV
        internal const bool InitialThemeDisabled = true;
#else
        internal const bool InitialThemeDisabled = false;
#endif

        /// <summary>
        /// Apply custom theme to the NUI.
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

            if (newTheme.SmallBrokenImageUrl != null) StyleManager.Instance.SetBrokenImageUrl(StyleManager.BrokenImageType.Small, newTheme.SmallBrokenImageUrl);
            if (newTheme.BrokenImageUrl != null) StyleManager.Instance.SetBrokenImageUrl(StyleManager.BrokenImageType.Normal, newTheme.BrokenImageUrl);
            if (newTheme.LargeBrokenImageUrl != null) StyleManager.Instance.SetBrokenImageUrl(StyleManager.BrokenImageType.Large, newTheme.LargeBrokenImageUrl);

            userTheme = newTheme;
            UpdateThemeForInitialize();
            UpdateThemeForUpdate();
            NotifyThemeChanged();
        }

        /// <summary>
        /// Append a theme to the current theme and apply it.
        /// This will change the appearance of the existing components with property <seealso cref="View.ThemeChangeSensitive"/> on.
        /// This also affects all components created afterwards.
        /// </summary>
        /// <param name="theme">The theme instance to be appended.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given theme is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void AppendTheme(Theme theme)
        {
            if (theme == null)
            {
                throw new ArgumentNullException(nameof(theme));
            }

            // var newTheme = (Theme)theme?.Clone() ?? throw new ArgumentNullException(nameof(theme));

            if (string.IsNullOrEmpty(theme.Id))
            {
                theme.Id = "NONAME";
            }

            if (theme.SmallBrokenImageUrl != null) StyleManager.Instance.SetBrokenImageUrl(StyleManager.BrokenImageType.Small, theme.SmallBrokenImageUrl);
            if (theme.BrokenImageUrl != null) StyleManager.Instance.SetBrokenImageUrl(StyleManager.BrokenImageType.Normal, theme.BrokenImageUrl);
            if (theme.LargeBrokenImageUrl != null) StyleManager.Instance.SetBrokenImageUrl(StyleManager.BrokenImageType.Large, theme.LargeBrokenImageUrl);

            if (userTheme == null) userTheme = theme;
            else
            {
                userTheme.Merge(theme);
            }

            UpdateThemeForInitialize();
            UpdateThemeForUpdate();
            NotifyThemeChanged();
        }

        /// <summary>
        /// Append a theme to the current base theme and apply it.
        /// This will change the appearance of the existing components with property <seealso cref="View.ThemeChangeSensitive"/> on.
        /// This also affects all components created afterwards.
        /// </summary>
        /// <param name="theme">The theme instance to be appended.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given theme is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void AppendBaseTheme(Theme theme)
        {
            var newTheme = (Theme)theme?.Clone() ?? throw new ArgumentNullException(nameof(theme));

            if (string.IsNullOrEmpty(newTheme.Id))
            {
                newTheme.Id = "NONAME";
            }

            if (newTheme.SmallBrokenImageUrl != null) StyleManager.Instance.SetBrokenImageUrl(StyleManager.BrokenImageType.Small, newTheme.SmallBrokenImageUrl);
            if (newTheme.BrokenImageUrl != null) StyleManager.Instance.SetBrokenImageUrl(StyleManager.BrokenImageType.Normal, newTheme.BrokenImageUrl);
            if (newTheme.LargeBrokenImageUrl != null) StyleManager.Instance.SetBrokenImageUrl(StyleManager.BrokenImageType.Large, newTheme.LargeBrokenImageUrl);

            if (baseTheme == null) baseTheme = newTheme;
            else
            {
                baseTheme = (Theme)baseTheme.Clone();
                baseTheme.MergeWithoutClone(newTheme);
            }

            UpdateThemeForInitialize();
            NotifyThemeChanged();
        }

        /// <summary>
        /// Change tizen theme.
        /// User may change this to one of platform installed one.
        /// Note that this is global theme changing which effects all applications.
        /// </summary>
        /// <param name="themeId">The installed theme Id.</param>
        /// <returns>true on success, false when it failed to find installed theme with given themeId.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given themeId is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool ApplyPlatformTheme(string themeId)
        {
            if (themeId == null) throw new ArgumentNullException(nameof(themeId));

            return ExternalThemeManager.SetTheme(themeId);
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
            return GetInitialStyleWithoutClone(styleName)?.Clone();
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
            return GetInitialStyleWithoutClone(viewType)?.Clone();
        }

        /// <summary>
        /// Load a platform style with style name in the current theme.
        /// It returns null when the platform theme is disabled. <see cref="NUIApplication.ThemeOptions.PlatformThemeEnabled" />.
        /// </summary>
        /// <param name="styleName">The style name.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given styleName is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ViewStyle GetPlatformStyle(string styleName)
        {
            if (styleName == null) throw new ArgumentNullException(nameof(styleName));
            return platformTheme?.GetStyle(styleName)?.Clone();
        }

        /// <summary>
        /// Load a platform style with view type in the current theme.
        /// It returns null when the platform theme is disabled. <see cref="NUIApplication.ThemeOptions.PlatformThemeEnabled" />.
        /// </summary>
        /// <param name="viewType"> The type of the view. Full name of the given type will be a key to find a style in the current theme. (e.g. Tizen.NUI.Components.Button) </param>
        /// <exception cref="ArgumentNullException">Thrown when the given viewType is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ViewStyle GetPlatformStyle(Type viewType)
        {
            if (viewType == null) throw new ArgumentNullException(nameof(viewType));
            return platformTheme?.GetStyle(viewType)?.Clone();
        }

        /// <summary>
        /// Load a style with style name in the current theme.
        /// </summary>
        /// <param name="styleName">The style name.</param>
        internal static ViewStyle GetUpdateStyleWithoutClone(string styleName) => ThemeForUpdate?.GetStyle(styleName);

        /// <summary>
        /// Load a style with View type in the current theme.
        /// </summary>
        /// <param name="viewType">The type of View.</param>
        internal static ViewStyle GetUpdateStyleWithoutClone(Type viewType) => ThemeForUpdate?.GetStyle(viewType);

        /// <summary>
        /// Load a initial component style.
        /// </summary>
        internal static ViewStyle GetInitialStyleWithoutClone(string styleName) => themeForInitialize?.GetStyle(styleName);

        /// <summary>
        /// Load a initial component style.
        /// </summary>
        internal static ViewStyle GetInitialStyleWithoutClone(Type viewType) => themeForInitialize?.GetStyle(viewType);

        /// <summary>
        /// Get a platform installed theme.
        /// </summary>
        /// <param name="themeId">The theme id.</param>
        internal static Theme LoadPlatformTheme(string themeId)
        {
            Debug.Assert(themeId != null);

            // Check if it is already loaded.
            int index = cachedPlatformThemes.FindIndex(x => string.Equals(x.Id, themeId, StringComparison.OrdinalIgnoreCase));
            if (index >= 0)
            {
                Tizen.Log.Info("NUI", $"Hit cache.");
                var found = cachedPlatformThemes[index];
                // If the cached is not a full set, update it.
                if (found.PackageCount < packages.Count)
                {
                    UpdatePlatformTheme(found);
                    Tizen.Log.Info("NUI", $"Update cache.");
                }
                return found;
            }

            var newTheme = CreatePlatformTheme(themeId);
            if (newTheme != null)
            {
                cachedPlatformThemes.Add(newTheme);
                Tizen.Log.Info("NUI", $"Platform theme has been loaded successfully.");
            }
            return newTheme;
        }

        /// <summary>
        /// !!! This is for internal use in fhub-nui. Do not open it.
        /// Set a theme to be used as fallback.
        /// The fallback theme is set to profile specified theme by default.
        /// </summary>
        /// <param name="fallbackTheme">The theme instance to be applied as a fallback.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static void ApplyFallbackTheme(Theme fallbackTheme)
        {
            Debug.Assert(fallbackTheme != null);
            BaseTheme = (Theme)fallbackTheme?.Clone();
        }

        /// <summary>
        /// Apply an external platform theme.
        /// </summary>
        /// <param name="id">The external theme id.</param>
        /// <param name="version">The external theme version.</param>
        private static void ApplyExternalPlatformTheme(string id, string version)
        {
            if (InitialThemeDisabled) return;

            // If the given theme is invalid, do nothing.
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            // If no platform theme has been applied and the base theme can cover the given one, do nothing.
            if (platformTheme == null && baseTheme != null && baseTheme.HasSameIdAndVersion(id, version))
            {
                Tizen.Log.Info("NUI", "The base theme can cover platform theme: Skip loading.");
                return;
            }

            // If the given theme is already applied, do nothing.
            if (platformTheme != null && platformTheme.HasSameIdAndVersion(id, version))
            {
                Tizen.Log.Info("NUI", "Platform theme is already applied: Skip loading.");
                return;
            }

            var loaded = LoadPlatformTheme(id);

            if (loaded != null)
            {
                Tizen.Log.Info("NUI", $"{loaded.Id} has been applied successfully.");
                platformTheme = loaded;
                UpdateThemeForInitialize();
                UpdateThemeForUpdate();
                NotifyThemeChanged(true);
            }
        }

        internal static void AddPackageTheme(IThemeCreator themeCreator)
        {
            string packageName;
            if (InitialThemeDisabled || packages.Contains(packageName = themeCreator.GetType().Assembly.GetName().Name))
            {
                return;
            }

            Tizen.Log.Debug("NUI", $"AddPackageTheme({themeCreator.GetType().Assembly.GetName().Name})");
            packages.Add(packageName);

            // Base theme
            var packageBaseTheme = themeCreator.Create();
            Debug.Assert(packageBaseTheme != null);

            if (baseTheme == null) baseTheme = packageBaseTheme;
            else baseTheme.MergeWithoutClone(packageBaseTheme);
            baseTheme.PackageCount++;

            if (platformThemeEnabled)
            {
                Tizen.Log.Info("NUI", $"Platform theme is enabled");
                if (platformTheme != null)
                {
                    UpdatePlatformTheme(platformTheme);
                }
                else
                {
                    if (!string.IsNullOrEmpty(ExternalThemeManager.CurrentThemeId) && !baseTheme.HasSameIdAndVersion(ExternalThemeManager.CurrentThemeId, ExternalThemeManager.CurrentThemeVersion))
                    {
                        var loaded = LoadPlatformTheme(ExternalThemeManager.CurrentThemeId);
                        if (loaded != null)
                        {
                            platformTheme = loaded;
                        }
                    }
                }
                UpdateThemeForUpdate();
            }
            UpdateThemeForInitialize();
        }

        // TODO Please make it private after removing Tizen.NUI.Components.StyleManager.
        internal static void UpdateThemeForUpdate()
        {
            updateThemeDirty = true;
        }

        static Theme ThemeForUpdate
        {
            get
            {
                if (updateThemeDirty)
                {
                    if (userTheme == null)
                    {
                        themeForUpdate = platformTheme;
                    }
                    else if (platformTheme == null)
                    {
                        themeForUpdate = userTheme;
                    }
                    else
                    {
                        themeForUpdate = new Theme();
                        themeForUpdate.Merge(platformTheme);
                        themeForUpdate.Merge(userTheme);
                    }
                    updateThemeDirty = false;
                }
                return themeForUpdate;
            }
        }

        // TODO Please make it private after removing Tizen.NUI.Components.StyleManager.
        internal static void UpdateThemeForInitialize()
        {
            if (platformTheme == null && userTheme == null)
            {
                themeForInitialize = baseTheme;
                return;
            }

            themeForInitialize = new Theme();

            if (baseTheme != null) themeForInitialize.Merge(baseTheme);

            if (userTheme == null)
            {
                if (platformTheme != null) themeForInitialize.Merge(platformTheme);
            }
            else
            {
                if (platformTheme != null) themeForInitialize.Merge(platformTheme);
                themeForInitialize.Merge(userTheme);
            }
        }

        private static void UpdatePlatformTheme(Theme theme)
        {
            var sharedResourcePath = ExternalThemeManager.GetSharedResourcePath(theme.Id);

            if (sharedResourcePath == null)
            {
                return;
            }

            for (var i = theme.PackageCount; i < packages.Count; i++)
            {
                theme.Merge(CreatePlatformTheme(sharedResourcePath, packages[i]));
            }
            theme.PackageCount = packages.Count;
        }

        private static Theme CreatePlatformTheme(string id)
        {
            var sharedResourcePath = ExternalThemeManager.GetSharedResourcePath(id);

            if (sharedResourcePath == null)
            {
                return null;
            }

            var newTheme = new Theme()
            {
                Id = id
            };

            foreach (var packageName in packages)
            {
                newTheme.MergeWithoutClone(CreatePlatformTheme(sharedResourcePath, packageName));
            }
            newTheme.PackageCount = packages.Count;

            return newTheme;
        }

        [SuppressMessage("Microsoft.Design", "CA1031: Do not catch general exception types", Justification = "This method is to handle external resources that may throw an exception but ignorable. This method should not interrupt the main stream.")]
        private static Theme CreatePlatformTheme(string sharedResourcePath, string assemblyName)
        {
            ExternalThemeManager.SharedResourcePath = sharedResourcePath;
            try
            {
                return new Theme(sharedResourcePath + assemblyName + ".Theme.xaml");
            }
            catch (System.IO.FileNotFoundException)
            {
                Tizen.Log.Info("NUI", $"[Ignorable] Current tizen theme does not have NUI theme.");
            }
            catch (Exception e)
            {
                Tizen.Log.Info("NUI", $"[Ignorable] {e.GetType().Name} occurred while applying tizen theme to {assemblyName}: {e.Message}");
            }

            return new Theme();
        }

        private static void AddToPlatformThemes(Theme theme)
        {
            int index = cachedPlatformThemes.FindIndex(x => x.Id.Equals(theme.Id, StringComparison.OrdinalIgnoreCase));
            if (index >= 0)
            {
                Tizen.Log.Info("NUI", $"Existing {theme.Id} item is overwritten");
                cachedPlatformThemes[index] = theme;
            }
            else
            {
                cachedPlatformThemes.Add(theme);
                Tizen.Log.Info("NUI", $"New {theme.Id} is saved.");
            }
        }

        private static void NotifyThemeChanged(bool platformThemeUpdated = false)
        {
            if (isInEventProgress) return;
            isInEventProgress = true;

            var platformThemeId = PlatformThemeId;
            var userThemeId = userTheme?.Id;
            ThemeChanging?.Invoke(null, new ThemeChangedEventArgs(userThemeId, platformThemeId, platformThemeUpdated));
            ThemeChangedInternal.Invoke(null, new ThemeChangedEventArgs(userThemeId, platformThemeId, platformThemeUpdated));
            ThemeChanged?.Invoke(null, new ThemeChangedEventArgs(userThemeId, platformThemeId, platformThemeUpdated));

            isInEventProgress = false;
        }

        private static void OnExternalThemeChanged(object sender, EventArgs e)
        {
            if (!PlatformThemeEnabled)
            {
                return;
            }

            ApplyExternalPlatformTheme(ExternalThemeManager.CurrentThemeId, ExternalThemeManager.CurrentThemeVersion);
        }
    }
}
#pragma warning restore CS0162 // Unreachable code detected
