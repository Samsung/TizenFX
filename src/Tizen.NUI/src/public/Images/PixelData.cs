/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
    ///  The PixelData object holds a pixel buffer.<br />
    ///  The PixelData takes over the ownership of the pixel buffer.<br />
    ///  The buffer memory must not be released outside of this class, instead,
    ///  the PixelData object will release it automatically when the reference count falls to zero.
    /// </summary>
    /// Please DO NOT use! This will be deprecated!
    /// PixelData class requires externally allocated pixel memory buffer and this buffer loses its ownership by native DALi.
    /// And this would make some problem, because dotnet runtime would change the address of memory allocated.
    /// So this is required to be removed.
    /// currently no use. will be added later
    /// <since_tizen> 5 </since_tizen>
    /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PixelData : BaseHandle
    {

        /// <summary>
        /// Creates a PixelData object.
        /// </summary>
        /// <param name="buffer">The raw pixel data.</param>
        /// <param name="bufferSize">The size of the buffer in bytes.</param>
        /// <param name="width">Buffer width in pixels.</param>
        /// <param name="height">Buffer height in pixels.</param>
        /// <param name="pixelFormat">The pixel format.</param>
        /// <param name="releaseFunction">The function used to release the memory.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PixelData(byte[] buffer, uint bufferSize, uint width, uint height, PixelFormat pixelFormat, PixelData.ReleaseFunction releaseFunction) : this(Interop.PixelData.New(buffer, bufferSize, width, height, (int)pixelFormat, (int)releaseFunction), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal PixelData(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Enumeration for function to release the pixel buffer.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ReleaseFunction
        {
            /// <summary>
            /// Use free function to release the pixel buffer.
            /// </summary>
            Free,

            /// <summary>
            /// Use delete[] operator to release the pixel buffer.
            /// </summary>
            DeleteArray
        }

        /// <summary>
        /// Get URI from pixel data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Url
        {
            get
            {
                string Uri = "";
                Uri = Interop.PixelData.GenerateUrl(this.SwigCPtr.Handle);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return Uri;
            }
        }

        /// <summary>
        /// Gets the width of the buffer in pixels.
        /// </summary>
        /// <returns>The width of the buffer in pixels.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetWidth()
        {
            uint ret = Interop.PixelData.GetWidth(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the height of the buffer in pixels.
        /// </summary>
        /// <returns>The height of the buffer in pixels.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetHeight()
        {
            uint ret = Interop.PixelData.GetHeight(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the pixel format.
        /// </summary>
        /// <returns>The pixel format.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PixelFormat GetPixelFormat()
        {
            PixelFormat ret = (PixelFormat)Interop.PixelData.GetPixelFormat(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PixelData obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PixelData.DeletePixelData(swigCPtr);
        }
    }
}
