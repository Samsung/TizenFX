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

namespace Tizen.NUI
{
    internal class BaseObject : RefObject
    {
        internal BaseObject(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        //you can override it to clean-up your own resources.
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }

        public bool DoAction(string actionName, PropertyMap attributes)
        {
            bool ret = Interop.BaseObject.DoAction(SwigCPtr, actionName, PropertyMap.getCPtr(attributes));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string GetTypeName()
        {
            string ret = Interop.BaseObject.GetTypeName(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool GetTypeInfo(Tizen.NUI.TypeInfo info)
        {
            bool ret = Interop.BaseObject.GetTypeInfo(SwigCPtr, Tizen.NUI.TypeInfo.getCPtr(info));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool DoConnectSignal(ConnectionTrackerInterface connectionTracker, string signalName, SWIGTYPE_p_FunctorDelegate functorDelegate)
        {
            bool ret = Interop.BaseObject.DoConnectSignal(SwigCPtr, ConnectionTrackerInterface.getCPtr(connectionTracker), signalName, SWIGTYPE_p_FunctorDelegate.getCPtr(functorDelegate));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
