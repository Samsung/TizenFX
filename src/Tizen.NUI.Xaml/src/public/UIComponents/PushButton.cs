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

using System;
using System.ComponentModel;
using System.Windows.Input;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml.UIComponents
{
    /// <summary>
    /// The PushButton changes its appearance when it is pressed, and returns to its original when it is released.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PushButton : Button
    {
        private Tizen.NUI.UIComponents.PushButton _pushButton;
        internal Tizen.NUI.UIComponents.PushButton pushButton
        {
            get
            {
                if (null == _pushButton)
                {
                    _pushButton = handleInstance as Tizen.NUI.UIComponents.PushButton;
                }

                return _pushButton;
            }
        }

        /// <summary>
        /// Creates the PushButton.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PushButton() : this(new Tizen.NUI.UIComponents.PushButton())
        {
        }

        internal PushButton(Tizen.NUI.UIComponents.PushButton nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CommandProperty = Binding.BindableProperty.Create("Command", typeof(ICommand), typeof(PushButton), null,
                BindingMode.OneWay, null, null, null, null, null as Binding.BindableProperty.CreateDefaultValueDelegate);
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CommandParameterProperty = Binding.BindableProperty.Create("CommandParameter", typeof(object), typeof(PushButton), null,
                BindingMode.OneWay, null, null, null, null, null as Binding.BindableProperty.CreateDefaultValueDelegate);

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ICommand Command
        {
            get
            {
                return (ICommand)base.GetValue(PushButton.CommandProperty);
            }
            set
            {
                base.SetValue(PushButton.CommandProperty, value);
            }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object CommandParameter
        {
            get
            {
                return base.GetValue(PushButton.CommandParameterProperty);
            }
            set
            {
                base.SetValue(PushButton.CommandParameterProperty, value);
            }
        }
    }
}
