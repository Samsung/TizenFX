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

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RenderTaskList : BaseHandle
    {
        internal RenderTaskList(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.RenderTask.DeleteRenderTaskList(swigCPtr);
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RenderTaskList() : this(Interop.RenderTask.NewRenderTaskList(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RenderTaskList DownCast(BaseHandle handle)
        {
            _ = handle ?? throw new System.ArgumentNullException(nameof(handle));
            RenderTaskList ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as RenderTaskList;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal RenderTaskList Assign(RenderTaskList rhs)
        {
            RenderTaskList ret = new RenderTaskList(Interop.RenderTask.RenderTaskListAssign(SwigCPtr, RenderTaskList.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RenderTask CreateTask()
        {
            RenderTask ret = new RenderTask(this, Interop.RenderTask.RenderTaskListCreateTask(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveTask(RenderTask task)
        {
            Interop.RenderTask.RenderTaskListRemoveTask(SwigCPtr, RenderTask.getCPtr(task));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetTaskCount()
        {
            uint ret = Interop.RenderTask.RenderTaskListGetTaskCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RenderTask GetTask(uint index)
        {
            global::System.IntPtr cPtr = Interop.RenderTask.RenderTaskListGetTask(SwigCPtr, index);

            RenderTask ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as RenderTask;
            if (ret != null)
            {
                HandleRef CPtr = new HandleRef(this, cPtr);
                Interop.BaseHandle.DeleteBaseHandle(CPtr);
                CPtr = new HandleRef(null, global::System.IntPtr.Zero);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            else
            {
                ret = new RenderTask(this, cPtr, true);
                return ret;
            }
        }
    }
}
