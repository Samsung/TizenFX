/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
    public partial class FrameUpdateCallbackInterface
    {
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetPosition(uint id, out UIVector2 position)
        {
            float x = 0.0f;
            float y = 0.0f;
            bool ret = false;
            if (proxyIntPtr != IntPtr.Zero)
            {
                ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceGetPositionVector2Componentwise(proxyIntPtr, id, ref x, ref y);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            position = new UIVector2(x, y);
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool BakePosition(uint id, UIVector2 position)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceBakePositionVector2Componentwise(proxyIntPtr, id, position.X, position.Y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetSize(uint id, out UIVector2 size)
        {
            float x = 0.0f;
            float y = 0.0f;
            bool ret = false;
            if (proxyIntPtr != IntPtr.Zero)
            {
                ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceGetSizeVector2Componentwise(proxyIntPtr, id, ref x, ref y);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            size = new UIVector2(x, y);
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool BakeSize(uint id, UIVector2 size)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceBakeSizeVector2Componentwise(proxyIntPtr, id, size.X, size.Y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetScale(uint id, out UIVector2 scale)
        {
            float x = 0.0f;
            float y = 0.0f;
            bool ret = false;
            if (proxyIntPtr != IntPtr.Zero)
            {
                ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceGetScaleVector2Componentwise(proxyIntPtr, id, ref x, ref y);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            scale = new UIVector2(x, y);
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool BakeScale(uint id, UIVector2 scale)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceBakeScaleVector2Componentwise(proxyIntPtr, id, scale.X, scale.Y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool GetColor(uint id, out UIColor color)
        {
            float r = 0.0f;
            float g = 0.0f;
            float b = 0.0f;
            float a = 0.0f;
            bool ret = false;
            if (proxyIntPtr != IntPtr.Zero)
            {
                ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceGetColorVector4Componentwise(proxyIntPtr, id, ref r, ref g, ref b, ref a);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            color = new UIColor(r, g, b, a);
            return ret;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool BakeColor(uint id, UIColor color)
        {
            if (proxyIntPtr == IntPtr.Zero)
            {
                return false;
            }
            bool ret = Interop.FrameUpdateCallbackInterface.FrameCallbackInterfaceBakeColorVector4Componentwise(proxyIntPtr, id, color.R, color.G, color.B, color.A);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
