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

using global::System.Threading;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class ViewSignal : Disposable
    {
        internal ViewSignal(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ActorSignal.DeleteActorSignal(swigCPtr);
        }

        public bool Empty()
        {
            bool ret = Interop.ActorSignal.Empty(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetConnectionCount()
        {
            uint ret = Interop.ActorSignal.GetConnectionCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Connect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            {
                Interop.ActorSignal.Connect(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void Disconnect(System.Delegate func)
        {
            try
            {
                System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
                {
                    Interop.ActorSignal.Disconnect(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
            catch (global::System.Exception ex)
            {
                Tizen.Log.Fatal("NUI", $"[ERROR] exception! {ex}: {ex.Message}");
                Tizen.Log.Fatal("NUI", $"[ERROR] current threadID : {Thread.CurrentThread.ManagedThreadId}");
                Tizen.Log.Fatal("NUI", $"[ERROR] back trace!");
                global::System.Diagnostics.StackTrace st = new global::System.Diagnostics.StackTrace(true);
                for (int i = 0; i < st.FrameCount; i++)
                {
                    global::System.Diagnostics.StackFrame sf = st.GetFrame(i);
                    Tizen.Log.Fatal("NUI", " Method " + sf.GetMethod());
                }
            }
        }

        public void Emit(View arg)
        {
            Interop.ActorSignal.Emit(SwigCPtr, View.getCPtr(arg));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ViewSignal() : this(Interop.ActorSignal.NewActorSignal(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
