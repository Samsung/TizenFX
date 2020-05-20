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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Interface that includes styles for all components for a theme
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal abstract class Theme
    {
        private Dictionary<Type, ComponentStyleGetter> styleMap;

        protected Theme()
        {
            styleMap = new Dictionary<Type, ComponentStyleGetter>();
            styleMap.Add(typeof(Button), GetButtonStyle);
            styleMap.Add(typeof(CheckBox), GetCheckBoxStyle);
            styleMap.Add(typeof(DropDown), GetDropDownStyle);
            styleMap.Add(typeof(DropDown.DropDownDataItem), GetDropDownItemStyle);
            styleMap.Add(typeof(Popup), GetPopupStyle);
            styleMap.Add(typeof(Progress), GetProgressStyle);
            styleMap.Add(typeof(RadioButton), GetRadioButtonStyle);
            styleMap.Add(typeof(Slider), GetSliderStyle);
            styleMap.Add(typeof(Switch), GetSwitchStyle);
            styleMap.Add(typeof(Tab), GetTabStyle);
            styleMap.Add(typeof(Toast), GetToastStyle);
        }

        internal delegate ViewStyle ComponentStyleGetter();

        internal ViewStyle GetComponentStyle(Type type)
        {
            return styleMap.ContainsKey(type) ? styleMap[type]() : null;
        }

        internal void OverwriteComponentStyle(Type type, ComponentStyleGetter styleGetter)
        {
            styleMap.Add(typeof(Toast), GetToastStyle);
        }

        protected abstract ButtonStyle GetButtonStyle();

        protected abstract ButtonStyle GetCheckBoxStyle();

        protected abstract DropDownStyle GetDropDownStyle();

        protected abstract DropDownItemStyle GetDropDownItemStyle();

        protected abstract PopupStyle GetPopupStyle();

        protected abstract ProgressStyle GetProgressStyle();

        protected abstract ButtonStyle GetRadioButtonStyle();

        protected abstract SliderStyle GetSliderStyle();

        protected abstract SwitchStyle GetSwitchStyle();

        protected abstract TabStyle GetTabStyle();

        protected abstract ToastStyle GetToastStyle();
    }
}
