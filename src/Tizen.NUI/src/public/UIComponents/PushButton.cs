/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
    public class PushButton : Button
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(PushButton), null, 
                BindingMode.OneWay, null, null, null, null, null as BindableProperty.CreateDefaultValueDelegate);
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(PushButton), null, 
                BindingMode.OneWay, null, null, null, null, null as BindableProperty.CreateDefaultValueDelegate);

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal PushButton(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.PushButton_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PushButton obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// To dispose the PushButton instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_PushButton(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        internal new class Property
        {
            internal static readonly int UNSELECTED_ICON = NDalicPINVOKE.PushButton_Property_UNSELECTED_ICON_get();
            internal static readonly int SELECTED_ICON = NDalicPINVOKE.PushButton_Property_SELECTED_ICON_get();
            internal static readonly int ICON_ALIGNMENT = NDalicPINVOKE.PushButton_Property_ICON_ALIGNMENT_get();
            internal static readonly int LABEL_PADDING = NDalicPINVOKE.PushButton_Property_LABEL_PADDING_get();
            internal static readonly int ICON_PADDING = NDalicPINVOKE.PushButton_Property_ICON_PADDING_get();
        }

        /// <summary>
        /// Creates the PushButton.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PushButton() : this(NDalicPINVOKE.PushButton_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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