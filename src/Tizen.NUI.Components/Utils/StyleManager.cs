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

using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    using global::System;

    /// <summary>
    /// StyleManager is a class to manager all style.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class StyleManager
    {
        private static readonly string defaultThemeName = "default";
        private string theme = defaultThemeName;
        private Dictionary<string, Dictionary<string, StyleBase>> themeStyleSet = new Dictionary<string, Dictionary<string, StyleBase>>();
        private Dictionary<string, StyleBase> defaultStyleSet = new Dictionary<string, StyleBase>();
        private Dictionary<string, Dictionary<Type, StyleBase>> componentStyleByTheme = new Dictionary<string, Dictionary<Type, StyleBase>>();
        private EventHandler<ThemeChangeEventArgs> themeChangeHander;

        /// <summary>
        /// StyleManager construct.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private StyleManager()
        {
        }

        /// <summary>
        /// An event for the theme changed signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ThemeChangeEventArgs> ThemeChangedEvent
        {
            add
            {
                themeChangeHander += value;
            }
            remove
            {
                themeChangeHander -= value;
            }
        }

        /// <summary>
        /// StyleManager static instance.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StyleManager Instance { get; } = new StyleManager();

        /// <summary>
        /// Style theme.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Theme
        {
            get
            {
                return theme;
            }

            set
            {
                if (theme != value)
                {
                    theme = value;
                    themeChangeHander?.Invoke(null, new ThemeChangeEventArgs { CurrentTheme = theme });
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
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// Get attributes by style.
        /// </summary>
        /// <param name="style">Style name.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle GetViewStyle(string style)
        {
            if (style == null)
            {
                return null;
            }

            if (themeStyleSet.ContainsKey(style) && themeStyleSet[style].ContainsKey(Theme))
            {
                return (themeStyleSet[style][Theme])?.GetAttributes();
            }
            else if (defaultStyleSet.ContainsKey(style))
            {
                return (defaultStyleSet[style])?.GetAttributes();
            }

            return null;
        }

        /// <summary>
        /// Register a style for a component to theme.
        /// </summary>
        /// <param name="targetTheme">Theme</param>
        /// <param name="component">The type of ComponentStyle</param>
        /// <param name="style">The type of style</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterComponentStyle(string targetTheme, Type component, Type style)
        {
            if (targetTheme == null)
            {
                throw new ArgumentException("The argument targetTheme must be specified");
            }

            if (defaultThemeName.Equals(targetTheme))
            {
                // Ensure default component styles have loaded before override custom default style
                LoadDefaultComponentStyle();
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle GetComponentStyle(Type component)
        {
            var currentTheme = theme;

            if (!componentStyleByTheme.ContainsKey(theme))
            {
                currentTheme = defaultThemeName;
            }

            if (defaultThemeName.Equals(currentTheme))
            {
                LoadDefaultComponentStyle();
            }

            if (!componentStyleByTheme[currentTheme].ContainsKey(component))
            {
                return null;
            }

            return (componentStyleByTheme[currentTheme][component])?.GetAttributes();
        }

        /// <summary>
        /// ThemeChangeEventArgs is a class to record theme change event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ThemeChangeEventArgs : EventArgs
        {
            /// <summary>
            /// CurrentTheme
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string CurrentTheme;
        }

        private void LoadDefaultComponentStyle()
        {
            if (componentStyleByTheme.ContainsKey(defaultThemeName))
            {
                return;
            }

            componentStyleByTheme.Add(defaultThemeName, new Dictionary<Type, StyleBase>());

            var defaultComponentsStyle = componentStyleByTheme[defaultThemeName];
            defaultComponentsStyle.Add(typeof(Tizen.NUI.Components.Button), new DefaultButtonStyle());
            defaultComponentsStyle.Add(typeof(Tizen.NUI.Components.CheckBox), new DefaultCheckBoxStyle());
            defaultComponentsStyle.Add(typeof(Tizen.NUI.Components.RadioButton), new DefaultRadioButtonStyle());
            defaultComponentsStyle.Add(typeof(Tizen.NUI.Components.Switch), new DefaultSwitchStyle());
            defaultComponentsStyle.Add(typeof(Tizen.NUI.Components.Progress), new DefaultProgressStyle());
            defaultComponentsStyle.Add(typeof(Tizen.NUI.Components.Slider), new DefaultSliderStyle());
            defaultComponentsStyle.Add(typeof(Tizen.NUI.Components.Toast), new DefaultToastStyle());
            defaultComponentsStyle.Add(typeof(Tizen.NUI.Components.Popup), new DefaultPopupStyle());
            defaultComponentsStyle.Add(typeof(Tizen.NUI.Components.DropDown), new DefaultDropDownStyle());
            defaultComponentsStyle.Add(typeof(Tizen.NUI.Components.DropDown.DropDownDataItem), new DefaultDropDownItemStyle());
            defaultComponentsStyle.Add(typeof(Tizen.NUI.Components.Tab), new DefaultTabStyle());
        }
    }
}
