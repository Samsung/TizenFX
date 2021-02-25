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
using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Texture represents a texture object used as input or output by shaders.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Texture : BaseHandle
    {

        /// <summary>
        /// Creates a new Texture object.
        /// </summary>
        /// <param name="type">The type of the texture.</param>
        /// <param name="format">The format of the pixel data.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <since_tizen> 3 </since_tizen>
        public Texture(TextureType type, PixelFormat format, uint width, uint height) : this(Interop.Texture.New((int)type, (int)format, width, height), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Texture(NativeImageInterface nativeImageInterface) : this(Interop.Texture.New(NativeImageInterface.getCPtr(nativeImageInterface)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal Texture(IntPtr tbmSurface) : this(Interop.Texture.NewTbmSurface(tbmSurface), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Texture(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Uploads data to the texture from a PixelData object.
        /// </summary>
        /// <param name="pixelData">The pixelData object.</param>
        /// <returns>True if the PixelData object has compatible pixel format and fits within the texture, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Upload(PixelData pixelData)
        {
            bool ret = Interop.Texture.Upload(SwigCPtr, PixelData.getCPtr(pixelData));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Uploads data to the texture from a PixelData object.
        /// </summary>
        /// <param name="pixelData">The pixelData object.</param>
        /// <param name="layer">The layer of a cube map or array texture.</param>
        /// <param name="mipmap">The level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">The horizontal offset of the rectangular area in the texture that will be updated.</param>
        /// <param name="yOffset">The vertical offset of the rectangular area in the texture that will be updated.</param>
        /// <param name="width">The width of the rectangular area in the texture that will be updated.</param>
        /// <param name="height">height of the rectangular area in the texture that will be updated.</param>
        /// <returns>True if the PixelData object has compatible pixel format and fits within the texture, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Upload(PixelData pixelData, uint layer, uint mipmap, uint xOffset, uint yOffset, uint width, uint height)
        {
            bool ret = Interop.Texture.Upload(SwigCPtr, PixelData.getCPtr(pixelData), layer, mipmap, xOffset, yOffset, width, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Generates mipmaps for the texture.<br />
        /// This will auto generate all the mipmaps for the texture based on the data in the base level.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void GenerateMipmaps()
        {
            Interop.Texture.GenerateMipmaps(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the width of the texture.<br />
        /// </summary>
        /// <returns>The width, in pixels, of the texture.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetWidth()
        {
            uint ret = Interop.Texture.GetWidth(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the height of the texture..<br />
        /// </summary>
        /// <returns>The height, in pixels, of the texture.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetHeight()
        {
            uint ret = Interop.Texture.GetHeight(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Texture obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Texture.DeleteTexture(swigCPtr);
        }
    }
}
