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
using System.ComponentModel;

namespace Tizen.NUI
{

    /// <summary>
    /// The PixelBuffer object holds a pixel buffer.
    /// The PixelBuffer keeps ownership of its initial buffer. However, the
    /// user is free to modify the pixel data, either directly or via image operations.
    ///
    /// In order to upload the pixel data to the texture memory, there are two
    /// possibilities, either convert it back to a PixelData object, which
    /// releases the PixelBuffer object, leaving the user with an empty handle
    /// (ideal for one-time indirect image manipulation) or create a new
    /// PixelData object from this object, leaving the buffer intact (ideal
    /// for continuous manipulation).
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PixelBuffer : BaseHandle
    {

        /// <summary>
        /// Create a PixelBuffer with its own data buffer.
        /// </summary>
        /// <param name="width">The pixel buffer width.</param>
        /// <param name="height">The pixel buffer height.</param>
        /// <param name="pixelFormat">The pixel format.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PixelBuffer(uint width, uint height, PixelFormat pixelFormat) : this(Interop.PixelBuffer.New(width, height, (int)pixelFormat), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PixelBuffer(PixelBuffer handle) : this(Interop.PixelBuffer.NewPixelBuffer(PixelBuffer.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PixelBuffer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Convert to a pixel data and release the object of the pixelBuffer.
        /// This handle is left empty.
        /// Any other handles that keep a reference to this object
        /// will be left with no buffer. Trying to access it will return NULL.
        /// </summary>
        /// <param name="pixelBuffer">A pixel buffer.</param>
        /// <returns>A new PixelData that takes ownership of the buffer of the pixelBuffer.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelData Convert(PixelBuffer pixelBuffer)
        {
            PixelData ret = new PixelData(Interop.PixelBuffer.Convert(PixelBuffer.getCPtr(pixelBuffer)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Copy the data from this object into a new PixelData object, which could be
        /// used for uploading to a texture.
        /// </summary>
        /// <returns>The pixel data.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PixelData CreatePixelData()
        {
            PixelData ret = new PixelData(Interop.PixelBuffer.CreatePixelData(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the width of the buffer in pixels.
        /// </summary>
        /// <returns>The width of the buffer in pixels.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetWidth()
        {
            uint ret = Interop.PixelBuffer.GetWidth(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the height of the buffer in pixels.
        /// </summary>
        /// <returns>The height of the buffer in pixels.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetHeight()
        {
            uint ret = Interop.PixelBuffer.GetHeight(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the pixel format.
        /// </summary>
        /// <returns>The pixel format.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PixelFormat GetPixelFormat()
        {
            PixelFormat ret = (PixelFormat)Interop.PixelBuffer.GetPixelFormat(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Apply the mask to this pixel data and return a new pixel data that contains
        /// the masked image. If this PixelBuffer does not have an alpha channel, then
        /// the resultant PixelBuffer will be converted to a format that supports at
        /// least the width of the color channels and the alpha channel from the mask.
        ///
        /// If cropToMask is set to <c>true</c>, then the contentScale is applied first to
        /// this buffer, and the target buffer is cropped to the size of the mask. If
        /// it is set to <c>false</c>, then the mask is scaled to match the size of this buffer
        /// before the mask is applied.
        /// </summary>
        /// <param name="mask">The mask to apply.</param>
        /// <param name="contentScale">The scaling factor to apply to the content.</param>
        /// <param name="cropToMask">Whether to crop the output to the mask size (true) or scale the mask to the content size (false).</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyMask(PixelBuffer mask, float contentScale, bool cropToMask)
        {
            Interop.PixelBuffer.ApplyMask(SwigCPtr, PixelBuffer.getCPtr(mask), contentScale, cropToMask);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Apply the mask to this pixel data and return a new pixel data containing
        /// the masked image. If this PixelBuffer does not have an alpha channel, then
        /// the resultant PixelBuffer will be converted to a format that supports at
        /// least the width of the color channels and the alpha channel from the mask.
        ///
        /// If cropToMask is set to <c>true</c>, then the contentScale is applied first to
        /// this buffer, and the target buffer is cropped to the size of the mask. If
        /// it is set to <c>false</c>, then the mask is scaled to match the size of this buffer
        /// before the mask is applied.
        /// </summary>
        /// <param name="mask">The mask to apply.</param>
        /// <param name="contentScale">The scaling factor to apply to the content.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyMask(PixelBuffer mask, float contentScale)
        {
            Interop.PixelBuffer.ApplyMask(SwigCPtr, PixelBuffer.getCPtr(mask), contentScale);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Apply the mask to this pixel data and return a new pixel data containing
        /// the masked image. If this PixelBuffer does not have an alpha channel, then
        /// the resultant PixelBuffer will be converted to a format that supports at
        /// least the width of the color channels and the alpha channel from the mask.
        ///
        /// If cropToMask is set to <c>true</c>, then the contentScale is applied first to
        /// this buffer, and the target buffer is cropped to the size of the mask. If
        /// it is set to <c>false</c>, then the mask is scaled to match the size of this buffer
        /// before the mask is applied.
        /// </summary>
        /// <param name="mask">The mask to apply.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyMask(PixelBuffer mask)
        {
            Interop.PixelBuffer.ApplyMask(SwigCPtr, PixelBuffer.getCPtr(mask));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Apply a Gaussian blur to this pixel data with the given radius.
        /// A bigger radius will yield a blurrier image. Only works for pixel data in RGBA format.
        /// </summary>
        /// <param name="blurRadius">The radius for Gaussian blur. A value of 0 or negative value indicates no blur.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyGaussianBlur(float blurRadius)
        {
            Interop.PixelBuffer.ApplyGaussianBlur(SwigCPtr, blurRadius);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Crops this buffer to the given crop rectangle.
        /// </summary>
        /// <param name="x">The top left corner's X.</param>
        /// <param name="y">The top left corner's Y.</param>
        /// <param name="width">The crop width.</param>
        /// <param name="height">The crop height.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Crop(ushort x, ushort y, ushort width, ushort height)
        {
            Interop.PixelBuffer.Crop(SwigCPtr, x, y, width, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Resizes the buffer to the given dimensions.
        /// </summary>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Resize(ushort width, ushort height)
        {
            Interop.PixelBuffer.Resize(SwigCPtr, width, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Rotate the buffer by the given angle.
        /// </summary>
        /// <param name="angle">The angle in degrees.</param>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Rotate(Degree angle)
        {
            bool ret = Interop.PixelBuffer.Rotate(SwigCPtr, Degree.getCPtr(angle));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        ///  Gets the pixel buffer
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.IntPtr GetBuffer()
        {
            global::System.IntPtr ret = Interop.PixelBuffer.GetBuffer(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PixelBuffer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal PixelBuffer Assign(PixelBuffer rhs)
        {
            PixelBuffer ret = new PixelBuffer(Interop.PixelBuffer.Assign(SwigCPtr, PixelBuffer.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PixelBuffer.DeletePixelBuffer(swigCPtr);
        }
    }
}
