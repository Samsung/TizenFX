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
    internal class KeyInputFocusManager : BaseHandle
    {

        internal KeyInputFocusManager(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.KeyInputFocusManager.KeyInputFocusManager_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }


        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.KeyInputFocusManager.delete_KeyInputFocusManager(swigCPtr);
        }

        private KeyInputFocusManager() : this(Interop.KeyInputFocusManager.new_KeyInputFocusManager(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static KeyInputFocusManager Get()
        {
            KeyInputFocusManager ret = new KeyInputFocusManager(Interop.KeyInputFocusManager.KeyInputFocusManager_Get(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFocus(View control)
        {
            Interop.KeyInputFocusManager.KeyInputFocusManager_SetFocus(swigCPtr, View.getCPtr(control));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public View GetCurrentFocusControl()
        {
            View ret = new View(Interop.KeyInputFocusManager.KeyInputFocusManager_GetCurrentFocusControl(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void RemoveFocus(View control)
        {
            Interop.KeyInputFocusManager.KeyInputFocusManager_RemoveFocus(swigCPtr, View.getCPtr(control));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__Control_Dali__Toolkit__ControlF_t KeyInputFocusChangedSignal()
        {
            SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__Control_Dali__Toolkit__ControlF_t ret = new SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__Control_Dali__Toolkit__ControlF_t(Interop.KeyInputFocusManager.KeyInputFocusManager_KeyInputFocusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
