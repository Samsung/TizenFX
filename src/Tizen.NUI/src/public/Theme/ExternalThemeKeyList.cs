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
using System.Diagnostics;
using System.Reflection;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

namespace Tizen.NUI
{
    /// <summary>
    /// This class holds a list of string key and corresponding setter function.
    /// <para>
    /// Key
    /// Represents a specific property in a style, for example,
    /// the key "/Text/PixelSize" of styleType "Button" means "ButtonStyle.Text.PixelSize".
    /// </para>
    /// <para>
    /// Action
    /// One action takes two values,
    /// * viewStyle : A style instance in a theme.
    /// * value: A string value that will overwrite a property value in a given viewStyle.
    /// The action parses a given string value into a typed object and set it to the viewStyle.
    /// </para>
    /// </summary>
    internal class ExternalThemeKeyList
    {
        private Type componentType;
        private Type styleType;
        private object selectorData;
        private List<KeyActionPair> list = new List<KeyActionPair>();

        /// <summary>
        /// Create a new key list
        /// For example,
        /// <code>
        /// new ExternalThemeKeyList(typeof(Button), typeof(ButtonStyle));
        /// </code>
        /// This means that the keys are related with ButtonStyle and they are defined to decorate Button component.
        /// </summary>
        internal ExternalThemeKeyList(Type componentType, Type styleType)
        {
            this.componentType = componentType;
            this.styleType = styleType;
        }

        /// <summary>
        /// Add a key with a corresponding action.
        /// For example,
        /// <code>
        /// var keyList = new ExternalThemeKeyList(typeof(Button), typeof(ButtonStyle));
        /// keyList.Add&lt;Extents&gt;("/Margin", (ViewStyle style, Extents value) => viewStyle.Margin = value);
        /// </code>
        /// </summary>
        internal ExternalThemeKeyList Add<T>(string key, Action<ViewStyle, T> setter)
        {
            list.Add(new KeyActionPair(componentType.Name + key, (ViewStyle viewStyle, string stringInput) =>
            {
                if (ParseXamlStringToObject<T>(stringInput) is T tValue)
                {
                    if (tValue != null)
                    {
                        setter(viewStyle, tValue);
                    }
                }
            }));
            return this;
        }

        /// <summary>
        /// <para>
        /// The series of actions for a selector.
        /// T is a content type of a selector.
        /// For example, assume that the component type is "Progress",
        /// <code>
        /// AddSelector&lt;Color&gt;("/TrackColor", setter);
        /// </code>
        /// This will produce additional keys and actions for 5 basic ControlStates,
        /// "Progress/TrackColor"
        /// "Progress/TrackColorFocused"
        /// "Progress/TrackColorPressed"
        /// "Progress/TrackColorDisabled"
        /// "Progress/TrackColorOther"
        /// </para>
        /// <para>
        /// Note that if you want to add actions for additional control states, please specify them as parameter.
        /// </para>
        /// </summary>
        /// <code>
        /// AddSelector&lt;Color&gt;("/TrackColor", setter, ControlState.DisabledSelected);
        /// </code>
        internal ExternalThemeKeyList AddSelector<T>(string key, Action<ViewStyle, Selector<T>> setter, params ControlState[] additionalStates)
        {
            list.Add(new KeyActionPair(componentType.Name + key, GenSelectorAction<T>(ControlState.Normal)));
            list.Add(new KeyActionPair(componentType.Name + key + nameof(ControlState.Focused), GenSelectorAction<T>(ControlState.Focused)));
            list.Add(new KeyActionPair(componentType.Name + key + nameof(ControlState.Pressed), GenSelectorAction<T>(ControlState.Pressed)));
            list.Add(new KeyActionPair(componentType.Name + key + nameof(ControlState.Disabled), GenSelectorAction<T>(ControlState.Disabled)));
            list.Add(new KeyActionPair(componentType.Name + key + nameof(ControlState.Other), GenSelectorAction<T>(ControlState.Other)));

            foreach (var state in additionalStates)
            {
                list.Add(new KeyActionPair(componentType.Name + key + nameof(state), GenSelectorAction<T>(state)));
            }

            list.Add(new KeyActionPair(GenSelectorFinalizer(setter)));

            return this;
        }

        /// <summary>
        /// Note that, the view's background can be either color or image value.
        /// This method add keys for a selector and each action can handle both color and string (for image url).
        /// </summary>
        internal ExternalThemeKeyList AddBackgroundSelector(string key, Action<ViewStyle, Selector<Color>> colorSetter, Action<ViewStyle, Selector<string>> imageSetter, params ControlState[] additionalStates)
        {
            list.Add(new KeyActionPair(componentType.Name + key, GenBackgroundSelectorAction(ControlState.Normal)));
            list.Add(new KeyActionPair(componentType.Name + key + nameof(ControlState.Focused), GenBackgroundSelectorAction(ControlState.Focused)));
            list.Add(new KeyActionPair(componentType.Name + key + nameof(ControlState.Pressed), GenBackgroundSelectorAction(ControlState.Pressed)));
            list.Add(new KeyActionPair(componentType.Name + key + nameof(ControlState.Disabled), GenBackgroundSelectorAction(ControlState.Disabled)));
            list.Add(new KeyActionPair(componentType.Name + key + nameof(ControlState.Other), GenBackgroundSelectorAction(ControlState.Other)));

            foreach (var state in additionalStates)
            {
                list.Add(new KeyActionPair(componentType.Name + key + nameof(state), GenBackgroundSelectorAction(state)));
            }

            list.Add(new KeyActionPair(GenColorOrImageSelectorFinalizer(colorSetter, imageSetter)));

            return this;
        }

        internal void ApplyKeyActions(IExternalTheme externalTheme, Theme theme)
        {
            var style = theme.GetStyle(componentType.FullName);

            foreach (var item in list)
            {
                if (item.IsFinalizer)
                {
                    item.Action(style, null);
                    continue;
                }

                string newValue = externalTheme.GetValue(item.Key);
                if (newValue != null)
                {
                    if (style == null || style.GetType() != styleType)
                    {
                        style = Activator.CreateInstance(styleType) as ViewStyle;
                        theme.AddStyleWithoutClone(componentType.FullName, style);
                    }

                    // Invoke action with the existing style to overwrite properties of it.
                    item.Action(style, newValue);
                }
            }
        }

        private Action<ViewStyle, string> GenSelectorAction<T>(ControlState state)
        {
            return (ViewStyle viewStyle, string stringInput) =>
            {
                if (ParseXamlStringToObject<T>(stringInput) is T tValue)
                {
                    if (selectorData == null)
                    {
                        selectorData = new Selector<T>();
                    }
                    ((Selector<T>)selectorData).AddWithoutDuplicationCheck(state, tValue);
                }
            };
        }

        private Action<ViewStyle, string> GenBackgroundSelectorAction(ControlState state)
        {
            return (ViewStyle viewStyle, string stringInput) =>
            {
                var imageUrl = TryConvertToResourcePath(stringInput);

                if (imageUrl != null)
                {
                    if (selectorData == null || (selectorData as Selector<string> == null))
                    {
                        selectorData = new Selector<string>();
                    }
                    ((Selector<string>)selectorData).AddWithoutDuplicationCheck(state, imageUrl);
                }
                else if (ParseXamlStringToObject<Color>(stringInput) is Color color)
                {
                    if (selectorData == null || (selectorData as Selector<Color> == null))
                    {
                        selectorData = new Selector<Color>();
                    }
                    ((Selector<Color>)selectorData).AddWithoutDuplicationCheck(state, color);
                }
            };
        }

        private Action<ViewStyle, string> GenSelectorFinalizer<T>(Action<ViewStyle, Selector<T>> setter)
        {
            return (ViewStyle viewStyle, string value) =>
            {
                if (selectorData == null || viewStyle == null)
                {
                    return;
                }
                setter(viewStyle, (Selector<T>)selectorData);
                selectorData = null;
            };
        }

        private Action<ViewStyle, string> GenColorOrImageSelectorFinalizer(Action<ViewStyle, Selector<Color>> colorSetter, Action<ViewStyle, Selector<string>> imageSetter)
        {
            return (ViewStyle viewStyle, string value) =>
            {
                if (viewStyle == null)
                {
                    return;
                }
                if (selectorData is Selector<Color> colorSelector)
                {
                    colorSetter(viewStyle, colorSelector);
                }
                else if (selectorData is Selector<string> imageSelector)
                {
                    imageSetter(viewStyle, imageSelector);
                }
                selectorData = null;
            };
        }

        private static object ParseXamlStringToObject<T>(string stringInput)
        {
            if (typeof(T) == typeof(string))
            {
                return TryConvertToResourcePath(stringInput) ?? stringInput;
            }
            return stringInput.ConvertTo(typeof(T), () => typeof(T).GetTypeInfo(), null);
        }

        private static string TryConvertToResourcePath(string stringInput)
        {
            Debug.Assert(stringInput != null);
            if (stringInput.StartsWith("{") && stringInput.EndsWith("}"))
            {
                // TODO Need to use Tizen.Applications.ThemeManager.Theme.GetPath instead SharedResourcePath after fixing abort problem.
                return ExternalThemeManager.SharedResourcePath + "/" + stringInput.Substring(1, stringInput.Length - 2);
            }
            return null;
        }

        internal struct KeyActionPair
        {
            public KeyActionPair(string key, Action<ViewStyle, string> action)
            {
                Key = key;
                Action = action;
            }

            public KeyActionPair(Action<ViewStyle, string> action)
            {
                Key = null;
                Action = action;
            }

            public bool IsFinalizer => (Key == null);

            public string Key { get; }

            public Action<ViewStyle, string> Action { get; }
        }
    }
}
