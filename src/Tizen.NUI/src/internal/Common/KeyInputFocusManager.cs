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
        private static readonly KeyInputFocusManager instance = KeyInputFocusManager.GetInternal();
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

        /// <summary>
        /// Gets the singleton of the KeyInputFocusManager object.
        /// </summary>
        public static KeyInputFocusManager Instance
        {
            get
            {
                return instance;
            }
        }

        [global::System.Obsolete("Do not use this, that will be deprecated. Use KeyInputFocusManager.Instance instead.")]
        public static KeyInputFocusManager Get()
        {
            return KeyInputFocusManager.Instance;
        }

        private static KeyInputFocusManager GetInternal()
        {
            global::System.IntPtr cPtr = Interop.KeyInputFocusManager.Get();

            if(cPtr == global::System.IntPtr.Zero)
            {
                NUILog.ErrorBacktrace("KeyInputFocusManager.Instance called before Application created, or after Application terminated!");
            }

            KeyInputFocusManager ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as KeyInputFocusManager;
            if (ret != null)
            {
                NUILog.ErrorBacktrace("KeyInputFocusManager.GetInternal() Should be called only one time!");
                object dummyObect = new object();

                global::System.Runtime.InteropServices.HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(dummyObect, cPtr);
                Interop.BaseHandle.DeleteBaseHandle(CPtr);
                CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            else
            {
                ret = new KeyInputFocusManager(cPtr, true);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                NUILog.ErrorBacktrace("We should not manually dispose for singleton class!");
            }
            else
            {
                base.Dispose(disposing);
            }
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

    }
}
