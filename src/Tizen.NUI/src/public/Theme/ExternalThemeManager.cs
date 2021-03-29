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
using System.Diagnostics.CodeAnalysis;
using Tizen.Applications;

namespace Tizen.NUI
{
    [SuppressMessage("Microsoft.Design", "CA1031: Do not catch general exception types", Justification = "This method is to handle external resources that may throw an exception but ignorable. This method should not interrupt the main stream.")]
    internal static class ExternalThemeManager
    {
        private static Tizen.Applications.ThemeManager.ThemeLoader themeLoader = InitializeThemeLoader();

        private static string sharedResourcePath;
#if DEBUG
        private static IExternalTheme theme;
#endif
        static ExternalThemeManager() { }

        public static string SharedResourcePath
        {
            get
            {
                if (themeLoader == null)
                {
                    return string.Empty;
                }
#if DEBUG
                if (theme != null)
                {
                    return string.Empty;
                }
#endif
                if (sharedResourcePath != null)
                {
                    return sharedResourcePath;
                }

                var tizenTheme = themeLoader.CurrentTheme;

                if (tizenTheme == null || string.IsNullOrEmpty(tizenTheme.Id) || string.IsNullOrEmpty(tizenTheme.Version))
                {
                    sharedResourcePath = string.Empty;
                }
                else
                {
                    ApplicationInfo themePkgInfo;
                    try
                    {
                        themePkgInfo = ApplicationManager.GetInstalledApplication(tizenTheme.Id);
                    }
                    catch (ArgumentException e)
                    {
                        Tizen.Log.Error("NUI", $"{e.GetType().Name} occurred while getting theme application info.");
                        throw;
                    }
                    catch (InvalidOperationException e)
                    {
                        Tizen.Log.Error("NUI", $"{e.GetType().Name} occurred while getting theme application info.");
                        throw;
                    }

                    if (themePkgInfo == null)
                    {
                        sharedResourcePath = string.Empty;
                    }
                    else
                    {
                        sharedResourcePath = themePkgInfo.SharedResourcePath;
                    }
                }

                return sharedResourcePath;
            }
        }

        public static void Initialize()
        {
            if (themeLoader == null)
            {
                return;
            }

            themeLoader.ThemeChanged += OnTizenThemeChanged;
        }

        public static IExternalTheme GetCurrentTheme()
        {
            if (themeLoader == null)
            {
                return null;
            }

#if DEBUG
            if (theme != null)
            {
                return theme;
            }
#endif
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
                return null;
            }

            Tizen.Log.Info("NUI", $"TizenTheme: Id({tizenTheme.Id}), Version({tizenTheme.Version}), Title({tizenTheme.Title})");

            return new TizenExternalTheme(tizenTheme);
        }

        public static IExternalTheme GetTheme(string id)
        {
            if (themeLoader == null)
            {
                return null;
            }

            Tizen.Applications.ThemeManager.Theme tizenTheme = null;

            try
            {
                tizenTheme = themeLoader.LoadTheme(id);
            }
            catch (Exception e)
            {
                Tizen.Log.Info("NUI", $"[Ignorable] {e.GetType().Name} occurred while getting load theme using {themeLoader.GetType().FullName}: {e.Message}");
            }

            return tizenTheme == null ? null : new TizenExternalTheme(tizenTheme);
        }

#if DEBUG
        public static void SetTestTheme(IExternalTheme testTheme)
        {
            if (testTheme == null)
            {
                throw new ArgumentNullException(nameof(testTheme));
            }

            if (string.IsNullOrEmpty(testTheme.Id) || string.IsNullOrEmpty(testTheme.Version))
            {
                throw new ArgumentException();
            }

            theme = testTheme;
            ThemeManager.ApplyExternalTheme(theme);
        }

        public static void SetTestTheme(string id, string version, Dictionary<string, string> testData)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }
            if (testData == null)
            {
                throw new ArgumentNullException(nameof(testData));
            }

            theme = new DictionaryExternalTheme(id, version, testData);
            ThemeManager.ApplyExternalTheme(theme);
        }
#endif

        private static void OnTizenThemeChanged(object sender, Tizen.Applications.ThemeManager.ThemeEventArgs e)
        {
#if DEBUG
            theme = null;
#endif
            Tizen.Log.Info("NUI", $"TizenTheme: Id({e.Theme.Id}), Version({e.Theme.Version}), Title({e.Theme.Title})");
            sharedResourcePath = null;
            ThemeManager.ApplyExternalTheme(new TizenExternalTheme(e.Theme));
        }

        private static Tizen.Applications.ThemeManager.ThemeLoader InitializeThemeLoader()
        {
            try
            {
                return new Tizen.Applications.ThemeManager.ThemeLoader();
            }
            catch (Exception e)
            {
                Tizen.Log.Info("NUI", $"[Ignorable] {e.GetType().Name} occurred while setting Tizen.Applications.ThemeManager: {e.Message}");
            }

            return null;
        }
    }
}

