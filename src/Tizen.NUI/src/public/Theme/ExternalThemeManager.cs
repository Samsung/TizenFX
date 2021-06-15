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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Tizen.Applications;

namespace Tizen.NUI
{
    [SuppressMessage("Microsoft.Design", "CA1031: Do not catch general exception types", Justification = "This method is to handle external resources that may throw an exception but ignorable. This method should not interrupt the main stream.")]
    internal static class ExternalThemeManager
    {
        private static Tizen.Applications.ThemeManager.ThemeLoader themeLoader;
        private static string id;
        private static string version;

        static ExternalThemeManager() { }

        public static void Initialize()
        {
            if (themeLoader != null)
            {
                return;
            }

            try
            {
                themeLoader = new Tizen.Applications.ThemeManager.ThemeLoader();
                themeLoader.ThemeChanged += OnExternalPlatformThemeChanged;
            }
            catch (Exception e)
            {
                Tizen.Log.Info("NUI", $"[Ignorable] {e.GetType().Name} occurred while setting Tizen.Applications.ThemeManager: {e.Message}");
            }
        }


        /// <summary> Returns the theme's shared resource path that is currently loading. </summary>
        public static string SharedResourcePath { get; set; } = String.Empty;

        // FIXME Please remove this API after fix ThemeLoader.CurrentTheme is fixed.
        public static string CurrentThemeId
        {
            get
            {
                if (id == null) UpdateCurrentThemeIdAndVersion();
                return id;
            }
        }

        // FIXME Please remove this API after fix ThemeLoader.CurrentTheme is fixed.
        public static string CurrentThemeVersion
        {
            get
            {
                if (version == null) UpdateCurrentThemeIdAndVersion();
                return version;
            }
        }

        public static bool SetTheme(string id)
        {
            if (themeLoader != null)
            {
                try
                {
                    themeLoader.CurrentTheme = themeLoader.LoadTheme(id);
                    return true;
                }
                catch (Exception e)
                {
                    Tizen.Log.Info("NUI", $"[Ignorable] {e.GetType().Name} occurred while getting load theme using {themeLoader.GetType().FullName}: {e.Message}");
                }
            }

            return false;
        }

        public static string GetSharedResourcePath(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    using (var themePkgInfo = ApplicationManager.GetInstalledApplication(id))
                    {
                        return themePkgInfo.SharedResourcePath;
                    }
                }
                catch (ArgumentException e)
                {
                    Tizen.Log.Error("NUI", $"{e.GetType().Name} occurred while getting theme application info.");
                }
                catch (InvalidOperationException e)
                {
                    Tizen.Log.Error("NUI", $"{e.GetType().Name} occurred while getting theme application info.");
                }
            }

            return null;
        }

        private static void UpdateCurrentThemeIdAndVersion()
        {
            if (themeLoader == null)
            {
                return;
            }

            Tizen.Applications.ThemeManager.Theme tizenTheme = null;

            try
            {
                tizenTheme = themeLoader.CurrentTheme;
            }
            catch (Exception e)
            {
                Tizen.Log.Info("NUI", $"[Ignorable] {e.GetType().Name} occurred while getting current theme using {themeLoader.GetType().FullName}: {e.Message}");
            }

            if (tizenTheme == null || string.IsNullOrEmpty(tizenTheme.Id) || string.IsNullOrEmpty(tizenTheme.Version))
            {
                return;
            }

            Tizen.Log.Info("NUI", $"TizenTheme: Id({tizenTheme.Id}), Version({tizenTheme.Version}), Title({tizenTheme.Title})");

            id = tizenTheme.Id;
            version = tizenTheme.Version;
        }

        private static void OnExternalPlatformThemeChanged(object sender, Tizen.Applications.ThemeManager.ThemeEventArgs e)
        {
            Tizen.Log.Info("NUI", $"TizenTheme: Id({e.Theme.Id}), Version({e.Theme.Version}), Title({e.Theme.Title})");

            id = e.Theme.Id;
            version = e.Theme.Version;

            if (!ThemeManager.PlatformThemeEnabled) return;

            ThemeManager.ApplyExternalPlatformTheme(id, version);
        }
    }
}

