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

    /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class FrameUpdateCallbackInterface : Disposable
    {
        private uint onUpdateCallbackVersion;

        private static int aliveCount;

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal FrameUpdateCallbackInterface(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            ++aliveCount;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FrameUpdateCallbackInterface() : this(0u)
        {
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FrameUpdateCallbackInterface(uint updateCallbackVersion) : this(Interop.FrameUpdateCallbackInterface.newFrameUpdateCallbackInterface(), true)
        {
            onUpdateCallbackVersion = updateCallbackVersion;
            DirectorConnect();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            --aliveCount;

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.FrameUpdateCallbackInterface.DeleteFrameUpdateCallbackInterface(swigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint UpdateCallbackVersion => onUpdateCallbackVersion;

        /// <summary>
        /// Gets the number of currently alived FrameUpdateCallbackInterface object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int AliveCount => aliveCount;

        private void DirectorConnect()
        {
            Delegate1 = new DelegateFrameUpdateCallbackInterfaceV1(DirectorOnUpdate);
            Interop.FrameUpdateCallbackInterface.FrameUpdateCallbackInterfaceDirectorConnectV1(SwigCPtr, Delegate1);
        }

        private global::System.IntPtr proxyIntPtr = global::System.IntPtr.Zero;

        private bool DirectorOnUpdate(global::System.IntPtr proxy, float elapsedSeconds)
        {
            bool ret = false;

            proxyIntPtr = proxy;
            if (onUpdateCallbackVersion == 0u)
            {
                OnUpdate(elapsedSeconds);
            }
            else if (onUpdateCallbackVersion == 1u)
            {
                ret = OnUpdate(this, elapsedSeconds);
            }
            proxyIntPtr = global::System.IntPtr.Zero;

            return ret;
        }

        internal delegate bool DelegateFrameUpdateCallbackInterfaceV1(global::System.IntPtr proxy, float elapsedSeconds);
        private DelegateFrameUpdateCallbackInterfaceV1 Delegate1;

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnUpdate(float elapsedSeconds)
        {
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool OnUpdate(FrameUpdateCallbackInterface obj, float elapsedSeconds)
        {
            // Let we call Versoin 0 API. To keep backward capability.
            OnUpdate(elapsedSeconds);
            return false;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetPosition(uint id, Vector3 position)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceGetPosition(proxyIntPtr, id, Vector3.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool SetPosition(uint id, Vector3 position)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceSetPosition(proxyIntPtr, id, Vector3.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool BakePosition(uint id, Vector3 position)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceBakePosition(proxyIntPtr, id, Vector3.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetOrientation(uint id, Rotation rotation)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceGetOrientation(proxyIntPtr, id, Rotation.getCPtr(rotation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool SetOrientation(uint id, Rotation rotation)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceSetOrientation(proxyIntPtr, id, Rotation.getCPtr(rotation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool BakeOrientation(uint id, Rotation rotation)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceBakeOrientation(proxyIntPtr, id, Rotation.getCPtr(rotation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetSize(uint id, Vector3 size)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceGetSize(proxyIntPtr, id, Vector3.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool SetSize(uint id, Vector3 size)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceSetSize(proxyIntPtr, id, Vector3.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool BakeSize(uint id, Vector3 size)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceBakeSize(proxyIntPtr, id, Vector3.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetScale(uint id, Vector3 scale)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceGetScale(proxyIntPtr, id, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool SetScale(uint id, Vector3 scale)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceSetScale(proxyIntPtr, id, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool BakeScale(uint id, Vector3 scale)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceBakeScale(proxyIntPtr, id, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetColor(uint id, Vector4 color)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceGetColor(proxyIntPtr, id, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool SetColor(uint id, Vector4 color)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceSetColor(proxyIntPtr, id, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool BakeColor(uint id, Vector4 color)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceBakeColor(proxyIntPtr, id, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetPositionAndSize(uint id, Vector3 Position, Vector3 Size)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceGetPositionAndSize(proxyIntPtr, id, Vector3.getCPtr(Position), Vector3.getCPtr(Size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetWorldPositionScaleAndSize(uint id, Vector3 Position, Vector3 Scale, Vector3 Size)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceGetWorldPositionScaleAndSize(proxyIntPtr, id, Vector3.getCPtr(Position), Vector3.getCPtr(Scale), Vector3.getCPtr(Size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetWorldTransformAndSize(uint id, Vector3 Position, Vector3 Scale, Rotation Orientation, Vector3 Size)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceGetWorldTransformAndSize(proxyIntPtr, id, Vector3.getCPtr(Position), Vector3.getCPtr(Scale), Rotation.getCPtr(Orientation),Vector3.getCPtr(Size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void AddFrameUpdateCallback(global::System.Runtime.InteropServices.HandleRef windowCPtr, global::System.Runtime.InteropServices.HandleRef layerCPtr)
        {
            Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceAddFrameUpdateCallback(windowCPtr, SwigCPtr, layerCPtr);
        }

        internal void RemoveFrameUpdateCallback(global::System.Runtime.InteropServices.HandleRef windowCPtr)
        {
            Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceRemoveFrameUpdateCallback(windowCPtr, SwigCPtr);
        }
    }
}
