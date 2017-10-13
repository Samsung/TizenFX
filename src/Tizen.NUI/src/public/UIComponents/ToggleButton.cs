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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{

    /// <summary>
    /// A ToggleButton allows the user to change a setting between two or more states.
    /// </summary>
    public class ToggleButton : Tizen.NUI.UIComponents.Button
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal ToggleButton(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.ToggleButton_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ToggleButton obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="type">The dispose type</param>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
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
                    NDalicPINVOKE.delete_ToggleButton(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// This should be internal, please do not use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new class Property
        {
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int STATE_VISUALS = NDalicPINVOKE.ToggleButton_Property_STATE_VISUALS_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int TOOLTIPS = NDalicPINVOKE.ToggleButton_Property_TOOLTIPS_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int CURRENT_STATE_INDEX = NDalicPINVOKE.ToggleButton_Property_CURRENT_STATE_INDEX_get();
        }

        /// <summary>
        /// Create an instance for toggleButton.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ToggleButton() : this(NDalicPINVOKE.ToggleButton_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Gets and Sets the state visual array of toggle button.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyArray StateVisuals
        {
            get
            {
                Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
                GetProperty(ToggleButton.Property.STATE_VISUALS).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(ToggleButton.Property.STATE_VISUALS, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets the tooltips of toggle button.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyArray Tooltips
        {
            get
            {
                Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
                GetProperty(ToggleButton.Property.TOOLTIPS).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(ToggleButton.Property.TOOLTIPS, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets and Sets the current state index of toggle button.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int CurrentStateIndex
        {
            get
            {
                int temp = 0;
                GetProperty(ToggleButton.Property.CURRENT_STATE_INDEX).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ToggleButton.Property.CURRENT_STATE_INDEX, new Tizen.NUI.PropertyValue(value));
            }
        }

    }

}