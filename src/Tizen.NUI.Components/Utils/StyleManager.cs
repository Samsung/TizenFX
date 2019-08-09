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
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// StyleManager is a class to manager all style.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class StyleManager
    {
        private string theme = "default";
        private Dictionary<string, Dictionary<string, Type>> themeStyleSet = new Dictionary<string, Dictionary<string, Type>>();
        private Dictionary<string, Type> defaultStyleSet = new Dictionary<string, Type>();
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
                if(theme != value)
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
            if(style == null)
            {
                throw new InvalidOperationException($"style can't be null");
            }

            if(theme == null || bDefault == true)
            {
                if(defaultStyleSet.ContainsKey(style))
                {
                    throw new InvalidOperationException($"{style}] already be used");
                }
                else
                {
                    defaultStyleSet.Add(style, styleType);
                }
                return;
            }

            if(themeStyleSet.ContainsKey(style) && themeStyleSet[style].ContainsKey(theme))
            {
                throw new InvalidOperationException($"{style}] already be used");
            }
            if(!themeStyleSet.ContainsKey(style))
            {
                themeStyleSet.Add(style, new Dictionary<string, Type>());
            }
            themeStyleSet[style].Add(theme, styleType);
        }

        /// <summary>
        /// Get attributes by style.
        /// </summary>
        /// <param name="style">Style name.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Attributes GetAttributes(string style)
        {
            if(style == null)
            {
                return null;
            }
            object obj = null;

            if(themeStyleSet.ContainsKey(style) && themeStyleSet[style].ContainsKey(Theme))
            {
                obj = Activator.CreateInstance(themeStyleSet[style][Theme]);
            }
            else if(defaultStyleSet.ContainsKey(style))
            {
                obj = Activator.CreateInstance(defaultStyleSet[style]);
            }

            return (obj as StyleBase)?.GetAttributes();
        }

        /// <summary>
        /// ThemeChangeEventArgs is a class to record theme change event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ThemeChangeEventArgs : EventArgs
        {
            public string CurrentTheme;
        }
    }
}
