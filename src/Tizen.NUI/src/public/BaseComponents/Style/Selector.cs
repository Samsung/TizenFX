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
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// Selector class, which is related by Control State, it is base class for other Selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Selector<T> : BindableObject
    {
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        public static implicit operator Selector<T>(T value)
        {
            Selector<T> selector = new Selector<T>();
            selector.All = value;
            return selector;
        }

        /// <summary>
        /// All State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T All
        {
            get;
            set;
        }
        /// <summary>
        /// Normal State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Normal
        {
            get;
            set;
        }
        /// <summary>
        /// Pressed State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Pressed
        {
            get;
            set;
        }
        /// <summary>
        /// Focused State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Focused
        {
            get;
            set;
        }
        /// <summary>
        /// Selected State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Selected
        {
            get;
            set;
        }
        /// <summary>
        /// Disabled State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Disabled
        {
            get;
            set;
        }
        /// <summary>
        /// DisabledFocused State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T DisabledFocused
        {
            get;
            set;
        }
        /// <summary>
        /// SelectedFocused State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        public T SelectedFocused
        {
            get;
            set;
        }
        /// <summary>
        /// DisabledSelected State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T DisabledSelected
        {
            get;
            set;
        }
        /// <summary>
        /// Other State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Other
        {
            get;
            set;
        }
        /// <summary>
        /// Get value by State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T GetValue(ControlStates state)
        {
            if(All != null)
            {
                return All;
            }
            switch(state)
            {
                case ControlStates.Normal:
                    return Normal != null? Normal : Other;
                case ControlStates.Focused:
                    return Focused != null? Focused : Other;
                case ControlStates.Pressed:
                    return Pressed != null? Pressed : Other;
                case ControlStates.Disabled:
                    return Disabled != null? Disabled : Other;
                case ControlStates.Selected:
                    return Selected != null? Selected : Other;
                case ControlStates.DisabledFocused:
                    return DisabledFocused != null? DisabledFocused : Other;
                case ControlStates.DisabledSelected:
                    return DisabledSelected != null? DisabledSelected : Other;
                case ControlStates.SelectedFocused:
                    return SelectedFocused != null ? SelectedFocused : Other;
                default:
                    return Other;
            }
        }
        /// <summary>
        /// Clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clone(Selector<T> selector)
        {
            All = selector.All;
            Normal = selector.Normal;
            Focused = selector.Focused;
            Pressed = selector.Pressed;
            Disabled = selector.Disabled;
            Selected = selector.Selected;
            DisabledSelected = selector.DisabledSelected;
            DisabledFocused = selector.DisabledFocused;
            SelectedFocused = selector.SelectedFocused;
            Other = selector.Other;
        }
    }

    public class TriggerableSelector<T> : Selector<T>
    {
        public TriggerableSelector(View view, BindableProperty bindableProperty)
        {
            targetView = view;
            targetBindableProperty = bindableProperty;
            view.ControlStateChangeEvent += OnViewControlState;
        }

        /// <summary>
        /// Clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Clone(Selector<T> selector)
        {
            base.Clone(selector);

            if (null != targetView && null != GetValue(targetView.ControlState))
            {
                targetView.SetValue(targetBindableProperty, GetValue(targetView.ControlState));
            }
        }

        private void OnViewControlState(View obj, ControlStates state)
        {
            if (null != obj && null != GetValue(state))
            {
                obj.SetValue(targetBindableProperty, GetValue(state));
            }
        }

        private View targetView;
        private BindableProperty targetBindableProperty;
    }
}
