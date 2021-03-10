/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

using System.ComponentModel;

namespace Tizen.NUI
{
    /// This will be released at Tizen.NET API Level 6, so currently this would be used as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FrameBuffer : BaseHandle
    {

        internal FrameBuffer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FrameBuffer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.FrameBuffer.DeleteFrameBuffer(swigCPtr);
        }

        /// <since_tizen> 3 </since_tizen>
        public sealed class Attachment
        {
            /// <since_tizen> 3 </since_tizen>
            public enum Mask
            {
                NONE = 0,
                DEPTH = 1 << 0,
                STENCIL = 1 << 1,
                DEPTH_STENCIL = DEPTH | STENCIL
            }
        }

        public FrameBuffer(uint width, uint height, uint attachments) : this(Interop.FrameBuffer.New(width, height, attachments), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        public void AttachColorTexture(Texture texture)
        {
            Interop.FrameBuffer.AttachColorTexture(SwigCPtr, Texture.getCPtr(texture));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AttachColorTexture(Texture texture, uint mipmapLevel, uint layer)
        {
            Interop.FrameBuffer.AttachColorTexture(SwigCPtr, Texture.getCPtr(texture), mipmapLevel, layer);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Texture GetColorTexture()
        {
            //to fix memory leak issue, match the handle count with native side.
            global::System.IntPtr cPtr = Interop.FrameBuffer.GetColorTexture(SwigCPtr);
            Texture ret = this.GetInstanceSafely<Texture>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
