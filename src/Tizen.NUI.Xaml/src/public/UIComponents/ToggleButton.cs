/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
using Tizen.NUI;
using Tizen.NUI.XamlBinding;

namespace Tizen.NUI.Xaml.UIComponents
{

    /// <summary>
    /// A ToggleButton allows the user to change a setting between two or more states.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ToggleButton : Button
    {
        private Tizen.NUI.ToggleButton _toggleButton;
        internal Tizen.NUI.ToggleButton toggleButton
        {
            get
            {
                if (null == _toggleButton)
                {
                    _toggleButton = handleInstance as Tizen.NUI.ToggleButton;
                }

                return _toggleButton;
            }
        }

        /// <summary>
        /// Create an instance for toggleButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ToggleButton() : this(new Tizen.NUI.ToggleButton())
        {
        }

        internal ToggleButton(Tizen.NUI.ToggleButton nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StateVisualsProperty = BindableProperty.Create("StateVisuals", typeof(PropertyArray), typeof(ToggleButton), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var toggleButton = ((ToggleButton)bindable).toggleButton;
            toggleButton.StateVisuals = (PropertyArray)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var toggleButton = ((ToggleButton)bindable).toggleButton;
            return toggleButton.StateVisuals;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TooltipsProperty = BindableProperty.Create("Tooltips", typeof(PropertyArray), typeof(ToggleButton), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var toggleButton = ((ToggleButton)bindable).toggleButton;
            toggleButton.Tooltips = (PropertyArray)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var toggleButton = ((ToggleButton)bindable).toggleButton;
            return toggleButton.Tooltips;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentStateIndexProperty = BindableProperty.Create("CurrentStateIndex", typeof(int), typeof(ToggleButton), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var toggleButton = ((ToggleButton)bindable).toggleButton;
            toggleButton.CurrentStateIndex = (int)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var toggleButton = ((ToggleButton)bindable).toggleButton;
            return toggleButton.CurrentStateIndex;
        });

        /// <summary>
        /// Gets and Sets the state visual array of toggle button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyArray StateVisuals
        {
            get
            {
                return (PropertyArray)GetValue(StateVisualsProperty);
            }
            set
            {
                SetValue(StateVisualsProperty, value);
            }
        }

        /// <summary>
        /// Gets and Sets the tooltips of toggle button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyArray Tooltips
        {
            get
            {
                return (PropertyArray)GetValue(TooltipsProperty);
            }
            set
            {
                SetValue(TooltipsProperty, value);
            }
        }

        /// <summary>
        /// Gets and Sets the current state index of toggle button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CurrentStateIndex
        {
            get
            {
                return (int)GetValue(CurrentStateIndexProperty);
            }
            set
            {
                SetValue(CurrentStateIndexProperty, value);
            }
        }
    }
}
