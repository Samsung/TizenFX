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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using System.Windows.Input;
using System.Collections.Generic;

namespace Tizen.NUI.UIComponents
{
    /// <summary>
    /// The PushButton changes its appearance when it is pressed, and returns to its original when it is released.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// This will be deprecated
    [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PushButton : Button
    {
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(PushButton), null,
                BindingMode.OneWay, null, null, null, null, null as BindableProperty.CreateDefaultValueDelegate);
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(PushButton), null,
                BindingMode.OneWay, null, null, null, null, null as BindableProperty.CreateDefaultValueDelegate);



        /// <summary>
        /// Creates the PushButton.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PushButton() : this(Interop.PushButton.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PushButton(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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

        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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

        /// Only used by the IL of xaml, will never changed to not hidden.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsCreateByXaml
        {
            get
            {
                return base.IsCreateByXaml;
            }
            set
            {
                base.IsCreateByXaml = value;

                if (value == true)
                {
                    this.Clicked += (sender, e) =>
                    {
                        ICommand command = this.Command;
                        if (command != null)
                        {
                            command.Execute(this.CommandParameter);
                        }
                        return true;
                    };
                }
            }
        }


        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PushButton.DeletePushButton(swigCPtr);
        }

        internal new class Property
        {
            internal static readonly int LabelPadding = Interop.PushButton.LabelPaddingGet();
            internal static readonly int IconPadding = Interop.PushButton.IconPaddingGet();
        }
    }
}
