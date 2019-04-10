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

namespace Tizen.NUI
{

    internal class DragAndDropDetector : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal DragAndDropDetector(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.DragAndDropDetector.DragAndDropDetector_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(DragAndDropDetector obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

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
                    Interop.DragAndDropDetector.delete_DragAndDropDetector(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        public DragAndDropDetector() : this(Interop.DragAndDropDetector.new_DragAndDropDetector(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public string GetContent()
        {
            string ret = Interop.DragAndDropDetector.DragAndDropDetector_GetContent(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector2 GetCurrentScreenPosition()
        {
            Vector2 ret = new Vector2(Interop.DragAndDropDetector.DragAndDropDetector_GetCurrentScreenPosition(swigCPtr), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public SWIGTYPE_p_Dali__SignalT_void_fDali__DragAndDropDetectorF_t EnteredSignal()
        {
            SWIGTYPE_p_Dali__SignalT_void_fDali__DragAndDropDetectorF_t ret = new SWIGTYPE_p_Dali__SignalT_void_fDali__DragAndDropDetectorF_t(Interop.DragAndDropDetector.DragAndDropDetector_EnteredSignal(swigCPtr), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public SWIGTYPE_p_Dali__SignalT_void_fDali__DragAndDropDetectorF_t ExitedSignal()
        {
            SWIGTYPE_p_Dali__SignalT_void_fDali__DragAndDropDetectorF_t ret = new SWIGTYPE_p_Dali__SignalT_void_fDali__DragAndDropDetectorF_t(Interop.DragAndDropDetector.DragAndDropDetector_ExitedSignal(swigCPtr), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public SWIGTYPE_p_Dali__SignalT_void_fDali__DragAndDropDetectorF_t MovedSignal()
        {
            SWIGTYPE_p_Dali__SignalT_void_fDali__DragAndDropDetectorF_t ret = new SWIGTYPE_p_Dali__SignalT_void_fDali__DragAndDropDetectorF_t(Interop.DragAndDropDetector.DragAndDropDetector_MovedSignal(swigCPtr), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        public SWIGTYPE_p_Dali__SignalT_void_fDali__DragAndDropDetectorF_t DroppedSignal()
        {
            SWIGTYPE_p_Dali__SignalT_void_fDali__DragAndDropDetectorF_t ret = new SWIGTYPE_p_Dali__SignalT_void_fDali__DragAndDropDetectorF_t(Interop.DragAndDropDetector.DragAndDropDetector_DroppedSignal(swigCPtr), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
