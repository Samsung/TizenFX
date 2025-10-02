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
    /// Do not use! This will be deprecated!
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
        /// <param name="_">Not used parameter.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be deprecated after API level 9. ReleaseFunction is not useful in C#.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Do not use this constructor. Use PixelData(byte[], uint, uint, uint, PixelFormat).")]
        public PixelData(byte[] buffer, uint bufferSize, uint width, uint height, PixelFormat pixelFormat, PixelData.ReleaseFunction _) : this(Interop.PixelData.New(buffer, bufferSize, width, height, (int)pixelFormat), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Creates a PixelData object.
        /// </summary>
        /// <param name="buffer">The raw pixel data.</param>
        /// <param name="bufferSize">The size of the buffer in bytes.</param>
        /// <param name="width">Buffer width in pixels.</param>
        /// <param name="height">Buffer height in pixels.</param>
        /// <param name="pixelFormat">The pixel format.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PixelData(byte[] buffer, uint bufferSize, uint width, uint height, PixelFormat pixelFormat) : this(Interop.PixelData.New(buffer, bufferSize, width, height, (int)pixelFormat), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal PixelData(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, false)
        {
            // Note : PixelData don't need to be register in Registry default. So we can create this class from worker thread.
        }

        internal PixelData(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister, cRegister)
        {
        }

        /// <summary>
        /// Enumeration for function to release the pixel buffer.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be deprecated after API level 9. ReleaseFunction is not useful in C#.
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
        /// Generate Url from pixel data.
        /// </summary>
        /// <remarks>
        /// This API should not be called at worker thread.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageUrl GenerateUrl()
        {
            return GenerateUrl(false);
        }

        /// <summary>
        /// Generate Url from pixel data with pre-multiplied by alpha information.
        /// </summary>
        /// <remarks>
        /// This API should not be called at worker thread.
        /// </remarks>
        /// <param name="preMultiplied">The raw pixel data pre-multiplied by alpha.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageUrl GenerateUrl(bool preMultiplied)
        {
            ImageUrl ret = new ImageUrl(Interop.PixelData.GenerateUrl(this.SwigCPtr.Handle, preMultiplied), true);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
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

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PixelData.DeletePixelData(swigCPtr);
        }
    }
}
