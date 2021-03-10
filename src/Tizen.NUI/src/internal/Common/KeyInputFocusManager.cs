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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class KeyInputFocusManager : BaseHandle
    {
        internal KeyInputFocusManager(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.KeyInputFocusManager.DeleteKeyInputFocusManager(swigCPtr);
        }

        private KeyInputFocusManager() : this(Interop.KeyInputFocusManager.NewKeyInputFocusManager(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static KeyInputFocusManager Get()
        {
            KeyInputFocusManager ret = new KeyInputFocusManager(Interop.KeyInputFocusManager.Get(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFocus(View control)
        {
            Interop.KeyInputFocusManager.SetFocus(SwigCPtr, View.getCPtr(control));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public View GetCurrentFocusControl()
        {
            View ret = new View(Interop.KeyInputFocusManager.GetCurrentFocusControl(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void RemoveFocus(View control)
        {
            Interop.KeyInputFocusManager.RemoveFocus(SwigCPtr, View.getCPtr(control));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__Control_Dali__Toolkit__ControlF_t KeyInputFocusChangedSignal()
        {
            SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__Control_Dali__Toolkit__ControlF_t ret = new SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__Control_Dali__Toolkit__ControlF_t(Interop.KeyInputFocusManager.KeyInputFocusChangedSignal(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
