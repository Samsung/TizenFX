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

namespace Tizen.NUI
{

    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FrameUpdateCallbackInterface : Disposable
    {
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal FrameUpdateCallbackInterface(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FrameUpdateCallbackInterface() : this(Interop.FrameUpdateCallbackInterface.newFrameUpdateCallbackInterface(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            DirectorConnect();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FrameUpdateCallbackInterface obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        private void DirectorConnect()
        {
            Delegate0 = new DelegateFrameUpdateCallbackInterface(DirectorOnUpdate);
            Interop.FrameUpdateCallbackInterface.FrameUpdateCallbackInterfaceDirectorConnect(SwigCPtr, Delegate0);
        }

        private global::System.IntPtr proxyIntPtr;
        private void DirectorOnUpdate(global::System.IntPtr proxy, float elapsedSeconds)
        {
            proxyIntPtr = proxy;
            OnUpdate(elapsedSeconds);
            return;
        }

        internal delegate void DelegateFrameUpdateCallbackInterface(global::System.IntPtr proxy, float elapsedSeconds);
        private DelegateFrameUpdateCallbackInterface Delegate0;


        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnUpdate(float elapsedSeconds)
        {

        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetPosition(uint id, Vector3 position)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceGetPosition(proxyIntPtr, id, Vector3.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool SetPosition(uint id, Vector3 position)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceSetPosition(proxyIntPtr, id, Vector3.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool BakePosition(uint id, Vector3 position)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceBakePosition(proxyIntPtr, id, Vector3.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetSize(uint id, Vector3 size)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceGetSize(proxyIntPtr, id, Vector3.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool SetSize(uint id, Vector3 size)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceSetSize(proxyIntPtr, id, Vector3.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool BakeSize(uint id, Vector3 size)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceBakeSize(proxyIntPtr, id, Vector3.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool SetScale(uint id, Vector3 scale)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceSetScale(proxyIntPtr, id, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetScale(uint id, Vector3 scale)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceSetScale(proxyIntPtr, id, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool BakeScale(uint id, Vector3 scale)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceBakeScale(proxyIntPtr, id, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetColor(uint id, Vector4 color)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceBakeScale(proxyIntPtr, id, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool SetColor(uint id, Vector4 color)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceBakeScale(proxyIntPtr, id, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool BakeColor(uint id, Vector4 color)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceBakeScale(proxyIntPtr, id, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetPositionAndSize(uint id, Vector3 Position, Vector3 Size)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceGetPositionAndSize(proxyIntPtr, id, Vector3.getCPtr(Position), Vector3.getCPtr(Size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void AddFrameUpdateCallback(global::System.Runtime.InteropServices.HandleRef windowCPtr, global::System.Runtime.InteropServices.HandleRef layerCPtr)
        {
            Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceAddFrameUpdateCallback(windowCPtr, SwigCPtr, layerCPtr);
        }

        internal void RemoveFrameUpdateCallback(global::System.Runtime.InteropServices.HandleRef windowCPtr)
        {
            Interop.FrameUpdateCallbackInterface.FraemCallbackInterfaceRemoveFrameUpdateCallback(windowCPtr, SwigCPtr);
        }
    }
}
