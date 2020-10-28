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
    internal class RenderTaskList : BaseHandle
    {

        internal RenderTaskList(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.RenderTask.RenderTaskList_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RenderTaskList obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.RenderTask.delete_RenderTaskList(swigCPtr);
        }

        public RenderTaskList() : this(Interop.RenderTask.new_RenderTaskList__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static RenderTaskList DownCast(BaseHandle handle)
        {
            RenderTaskList ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as RenderTaskList;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public RenderTaskList(RenderTaskList handle) : this(Interop.RenderTask.new_RenderTaskList__SWIG_1(RenderTaskList.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public RenderTaskList Assign(RenderTaskList rhs)
        {
            RenderTaskList ret = new RenderTaskList(Interop.RenderTask.RenderTaskList_Assign(swigCPtr, RenderTaskList.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public RenderTask CreateTask()
        {
            RenderTask ret = new RenderTask(Interop.RenderTask.RenderTaskList_CreateTask(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void RemoveTask(RenderTask task)
        {
            Interop.RenderTask.RenderTaskList_RemoveTask(swigCPtr, RenderTask.getCPtr(task));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public uint GetTaskCount()
        {
            uint ret = Interop.RenderTask.RenderTaskList_GetTaskCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public RenderTask GetTask(uint index)
        {
            RenderTask ret = new RenderTask(Interop.RenderTask.RenderTaskList_GetTask(swigCPtr, index), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
