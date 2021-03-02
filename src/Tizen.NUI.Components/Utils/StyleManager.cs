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
    [Obsolete("This will be removed soon. Please use ThemeManager instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class StyleManager
    {
        /// <summary>
        /// StyleManager construct.
        /// </summary>
        private StyleManager()
        {
            ThemeManager.ThemeChanged += OnThemeChanged;
        }

        /// <summary>
        /// An event for the theme changed signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        [Obsolete("This will be removed soon. Please use ThemeManager instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ThemeChangeEventArgs> ThemeChangedEvent;

        /// <summary>
        /// StyleManager static instance.
        /// </summary>
        [Obsolete("This will be removed soon. Please use ThemeManager instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StyleManager Instance { get; } = new StyleManager();

        /// <summary>
        /// Style theme.
        /// </summary>
        [Obsolete("This will be removed soon. Please use ThemeManager instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Theme
        {
            get
            {
                return ThemeManager.CurrentTheme.Id;
            }
            set
            {
                if (value == null) return;

                var key = value.ToUpperInvariant();

                // Please note that it does not check "key == Theme" here,
                // because of the font size issue of the Tizen.NUI.StyleManager.
                // (There are applications to use NUI.Components.StyleManager.ThemeChangedEvent to fix Tizen.NUI.StyleManager font size issue.)
                // Please do not check equality until we fix that issue.

                if (!ThemeMap.ContainsKey(key) || ThemeMap[key] == null)
                {
                    ThemeMap[key] = new Theme()
                    {
                        Id = value
                    };
                }

                ThemeManager.CurrentTheme = ThemeMap[key];
            }
        }

        /// <summary>
        /// (Theme name, Theme instance)
        /// </summary>
        private Dictionary<string, Theme> ThemeMap { get; } = new Dictionary<string, Theme> { ["DEFAULT"] = ThemeManager.DefaultTheme };

        /// <summary>
        /// Register style in StyleManager.
        /// </summary>
        /// <param name="style">Style name.</param>
        /// <param name="theme">Theme id.</param>
        /// <param name="styleType">Style type.</param>
        /// <param name="bDefault">Flag to decide if it is default style.</param>
        [Obsolete("This will be removed soon. Please use ThemeManager instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterStyle(string style, string theme, Type styleType, bool bDefault = false)
        {
            if (style == null)
            {
                throw new InvalidOperationException($"style can't be null");
            }

            if (Activator.CreateInstance(styleType) is StyleBase styleBase)
            {
                var key = "DEFAULT";

                if (bDefault && theme != null)
                {
                    ThemeMap[key].AddStyleWithoutClone(style, styleBase.GetViewStyle());
                }

                if (theme != null)
                {
                    key = theme.ToUpperInvariant();
                }

                if (!ThemeMap.ContainsKey(key) || ThemeMap[key] == null)
                {
                    ThemeMap[key] = new Theme()
                    {
                        Id = theme ?? key
                    };
                }

                if (ThemeMap[key].HasStyle(style))
                {
                    throw new InvalidOperationException($"{style} already be used");
                }

                ThemeMap[key].AddStyleWithoutClone(style, styleBase.GetViewStyle());
            }
        }

        /// <summary>
        /// Get style.
        /// </summary>
        /// <param name="style">Style name.</param>
        /// <returns>The style corresponding to style name .</returns>
        [Obsolete("This will be removed soon. Please use ThemeManager instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle GetViewStyle(string style)
        {
            if (style == null)
            {
                return null;
            }

            return ThemeManager.GetStyle(style);
        }

        /// <summary>
        /// Register a style for a component to theme.
        /// </summary>
        /// <param name="targetTheme">The target theme name to register a component style. It theme should be a known one.</param>
        /// <param name="component">The type of ComponentStyle</param>
        /// <param name="style">The derived class of StyleBase</param>
        [Obsolete("This will be removed soon. Please use ThemeManager instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterComponentStyle(string targetTheme, Type component, Type style)
        {
            if (targetTheme == null || component == null || style == null)
            {
                throw new ArgumentException("The argument targetTheme must be specified");
            }

            var key = targetTheme.ToUpperInvariant();

            if (!ThemeMap.ContainsKey(key) || ThemeMap[key] == null)
            {
                Tizen.Log.Error("NUI", "The theme name should be a known one.");
                return;
            }

            if (Activator.CreateInstance(style) as StyleBase != null)
            {
                ThemeMap[key].AddStyleWithoutClone(component.FullName, (Activator.CreateInstance(style) as StyleBase).GetViewStyle());
            }
        }

        /// <summary>
        /// Get components style in the current theme.
        /// </summary>
        /// <param name="component">The type of component</param>
        /// <returns>The style of the component.</returns>
        [Obsolete("This will be removed soon. Please use ThemeManager instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle GetComponentStyle(Type component)
        {
            return ThemeManager.GetStyle(component.FullName);
        }

        private void OnThemeChanged(object target, ThemeChangedEventArgs args)
        {
            ThemeChangedEvent?.Invoke(null, new ThemeChangeEventArgs { CurrentTheme = args.ThemeId });
        }

        /// <summary>
        /// ThemeChangeEventArgs is a class to record theme change event arguments which will sent to user.
        /// </summary>
        [Obsolete("This will be removed soon. Please use ThemeManager instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ThemeChangeEventArgs : EventArgs
        {
            /// <summary>
            /// CurrentTheme
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string CurrentTheme { get; set; }
        }
    }
}
