/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// StyleManager is a class to manager all style.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class StyleManager
    {
        internal const float PointSizeNormal = 12;
        internal const float PointSizeTitle = 16;

        private const string defaultThemeName = "DEFAULT"; //"default";
        private const string wearableThemeName = "WEARABLE"; //"wearable";
        
        private string currentThemeName = defaultThemeName;
        private Dictionary<string, Dictionary<string, StyleBase>> themeStyleSet = new Dictionary<string, Dictionary<string, StyleBase>>();
        private Dictionary<string, StyleBase> defaultStyleSet = new Dictionary<string, StyleBase>();

        /// <summary>
        /// (Theme name, Theme instance)
        /// </summary>
        private Dictionary<string, Dictionary<Type, StyleBase>> componentStyleByTheme = new Dictionary<string, Dictionary<Type, StyleBase>>();
        
        /// <summary>
        /// (Theme name, Theme instance)
        /// </summary>
        private Dictionary<string, Theme> themeMap = new Dictionary<string, Theme>();

        private EventHandler<ThemeChangeEventArgs> themeChangeHandler;

        private Theme currentTheme;

        /// <summary>
        /// StyleManager construct.
        /// </summary>
        private StyleManager()
        {
            SetInitialThemeByDeviceProfile();
        }

        /// <summary>
        /// An event for the theme changed signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ThemeChangeEventArgs> ThemeChangedEvent
        {
            add
            {
                themeChangeHandler += value;
            }
            remove
            {
                themeChangeHandler -= value;
            }
        }

        /// <summary>
        /// StyleManager static instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StyleManager Instance { get; } = new StyleManager();

        /// <summary>
        /// Style theme.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Theme
        {
            get
            {
                return currentThemeName;
            }

            set
            {
                if (value != null && currentThemeName != value)
                {
                    currentThemeName = value.ToUpperInvariant();
                    themeChangeHandler?.Invoke(null, new ThemeChangeEventArgs { CurrentTheme = currentThemeName });

                    UpdateTheme();
                }
            }
        }

        /// <summary>
        /// Register style in StyleManager.
        /// </summary>
        /// <param name="style">Style name.</param>
        /// <param name="theme">Theme.</param>
        /// <param name="styleType">Style type.</param>
        /// <param name="bDefault">Flag to decide if it is default style.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterStyle(string style, string theme, Type styleType, bool bDefault = false)
        {
            if (style == null)
            {
                throw new InvalidOperationException($"style can't be null");
            }

            if (theme == null || bDefault == true)
            {
                if (defaultStyleSet.ContainsKey(style))
                {
                    throw new InvalidOperationException($"{style}] already be used");
                }
                else
                {
                    defaultStyleSet.Add(style, Activator.CreateInstance(styleType) as StyleBase);
                }
                return;
            }

            theme = theme.ToUpperInvariant();

            if (themeStyleSet.ContainsKey(style) && themeStyleSet[style].ContainsKey(theme))
            {
                throw new InvalidOperationException($"{style}] already be used");
            }

            if (!themeStyleSet.ContainsKey(style))
            {
                themeStyleSet.Add(style, new Dictionary<string, StyleBase>());
            }

            themeStyleSet[style].Add(theme, Activator.CreateInstance(styleType) as StyleBase);
        }

        /// <summary>
        /// Get style.
        /// </summary>
        /// <param name="style">Style name.</param>
        /// <returns>The style corresponding to style name .</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle GetViewStyle(string style)
        {
            if (style == null)
            {
                return null;
            }

            if (themeStyleSet.ContainsKey(style) && themeStyleSet[style].ContainsKey(Theme))
            {
                return (themeStyleSet[style][Theme])?.GetViewStyle();
            }
            else if (defaultStyleSet.ContainsKey(style))
            {
                return (defaultStyleSet[style])?.GetViewStyle();
            }

            return null;
        }

        /// <summary>
        /// Register a style for a component to theme.
        /// </summary>
        /// <param name="targetTheme">The target theme name to register a component style. It theme should be a known one.</param>
        /// <param name="component">The type of ComponentStyle</param>
        /// <param name="style">The derived class of StyleBase</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterComponentStyle(string targetTheme, Type component, Type style)
        {
            if (targetTheme == null || component == null || style == null)
            {
                throw new ArgumentException("The argument targetTheme must be specified");
            }

            if (!themeMap.ContainsKey(targetTheme))
            {
                Tizen.Log.Error("NUI", "The theme name should be a known one.");
                return;
            }

            if (!componentStyleByTheme.ContainsKey(targetTheme))
            {
                componentStyleByTheme.Add(targetTheme, new Dictionary<Type, StyleBase>());
            }

            if (componentStyleByTheme[targetTheme].ContainsKey(component))
            {
                componentStyleByTheme[targetTheme][component] = Activator.CreateInstance(style) as StyleBase;
            }
            else
            {
                componentStyleByTheme[targetTheme].Add(component, Activator.CreateInstance(style) as StyleBase);
            }
        }

        /// <summary>
        /// Get components style in the current theme.
        /// </summary>
        /// <param name="component">The type of component</param>
        /// <returns>The style of the component.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle GetComponentStyle(Type component)
        {
            if (componentStyleByTheme.ContainsKey(currentThemeName) && componentStyleByTheme[currentThemeName].ContainsKey(component))
            {
                return componentStyleByTheme[currentThemeName][component].GetViewStyle();
            }

            return currentTheme.GetComponentStyle(component);
        }

        /// <summary>
        /// ThemeChangeEventArgs is a class to record theme change event arguments which will sent to user.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ThemeChangeEventArgs : EventArgs
        {
            /// <summary>
            /// CurrentTheme
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string CurrentTheme;
        }

        internal static string GetFrameworkResourcePath(string resourceFileName)
        {
            return "/usr/share/dotnet.tizen/framework/res/" + resourceFileName;
        }

        private void SetInitialThemeByDeviceProfile()
        {
            Theme wearableTheme = WearableTheme.Instance;
            Theme defaultTheme = DefaultTheme.Instance;
            themeMap.Add(wearableThemeName, wearableTheme);
            themeMap.Add(defaultThemeName, defaultTheme);

            currentThemeName = defaultThemeName;
            currentTheme = defaultTheme;

            string currentProfile;

            try
            {
                System.Information.TryGetValue<string>("tizen.org/feature/profile", out currentProfile);
                Tizen.Log.Info("NUI", "Profile for initial theme found : " + currentProfile);
            }
            catch
            {
                Tizen.Log.Error("NUI", "Unknown device profile\n");
                return;
            }

            if (string.Equals(currentProfile, wearableThemeName))
            {
                currentThemeName = wearableThemeName;
                currentTheme = wearableTheme;
            }
        }

        private void UpdateTheme()
        {
            if (themeMap.ContainsKey(currentThemeName))
            {
                currentTheme = themeMap[currentThemeName];
            }
            else
            {
                currentTheme = DefaultTheme.Instance;
            }
        }
    }
}
