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

using System.Runtime.InteropServices;

namespace Tizen.NUI
{

    internal class FrameBuffer : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal FrameBuffer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.FrameBuffer.FrameBuffer_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FrameBuffer obj)
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
                    Interop.FrameBuffer.delete_FrameBuffer(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <since_tizen> 3 </since_tizen>
        public class Attachment
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

        public FrameBuffer(uint width, uint height, uint attachments) : this(Interop.FrameBuffer.FrameBuffer_New(width, height, attachments), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();

        }

        public void AttachColorTexture(Texture texture)
        {
            Interop.FrameBuffer.FrameBuffer_AttachColorTexture__SWIG_0(swigCPtr, Texture.getCPtr(texture));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public void AttachColorTexture(Texture texture, uint mipmapLevel, uint layer)
        {
            Interop.FrameBuffer.FrameBuffer_AttachColorTexture__SWIG_1(swigCPtr, Texture.getCPtr(texture), mipmapLevel, layer);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        public Texture GetColorTexture()
        {
            //to fix memory leak issue, match the handle count with native side.
            global::System.IntPtr cPtr = Interop.FrameBuffer.FrameBuffer_GetColorTexture(swigCPtr);
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            Texture ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as Texture;
            Interop.BaseHandle.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
