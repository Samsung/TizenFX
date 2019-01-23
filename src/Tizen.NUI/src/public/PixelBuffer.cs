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
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        /// <summary>
        /// Create a PixelBuffer with its own data buffer.
        /// </summary>
        /// <param name="width">The pixel buffer width.</param>
        /// <param name="height">The pixel buffer height.</param>
        /// <param name="pixelFormat">The pixel format.</param>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PixelBuffer(uint width, uint height, PixelFormat pixelFormat) : this(NDalicPINVOKE.PixelBuffer_New(width, height, (int)pixelFormat), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PixelBuffer(PixelBuffer handle) : this(NDalicPINVOKE.new_PixelBuffer__SWIG_1(PixelBuffer.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PixelBuffer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.PixelBuffer_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
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
            PixelData ret = new PixelData(NDalicPINVOKE.PixelBuffer_Convert(PixelBuffer.getCPtr(pixelBuffer)), true);
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
            PixelData ret = new PixelData(NDalicPINVOKE.PixelBuffer_CreatePixelData(swigCPtr), true);
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
            uint ret = NDalicPINVOKE.PixelBuffer_GetWidth(swigCPtr);
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
            uint ret = NDalicPINVOKE.PixelBuffer_GetHeight(swigCPtr);
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
            PixelFormat ret = (PixelFormat)NDalicPINVOKE.PixelBuffer_GetPixelFormat(swigCPtr);
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
            NDalicPINVOKE.PixelBuffer_ApplyMask__SWIG_0(swigCPtr, PixelBuffer.getCPtr(mask), contentScale, cropToMask);
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
            NDalicPINVOKE.PixelBuffer_ApplyMask__SWIG_1(swigCPtr, PixelBuffer.getCPtr(mask), contentScale);
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
            NDalicPINVOKE.PixelBuffer_ApplyMask__SWIG_2(swigCPtr, PixelBuffer.getCPtr(mask));
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
            NDalicPINVOKE.PixelBuffer_ApplyGaussianBlur(swigCPtr, blurRadius);
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
            NDalicPINVOKE.PixelBuffer_Crop(swigCPtr, x, y, width, height);
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
            NDalicPINVOKE.PixelBuffer_Resize(swigCPtr, width, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PixelBuffer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal PixelBuffer Assign(PixelBuffer rhs)
        {
            PixelBuffer ret = new PixelBuffer(NDalicPINVOKE.PixelBuffer_Assign(swigCPtr, PixelBuffer.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_unsigned_char GetBuffer()
        {
            global::System.IntPtr cPtr = NDalicPINVOKE.PixelBuffer_GetBuffer(swigCPtr);
            SWIGTYPE_p_unsigned_char ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_unsigned_char(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User.
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //Because the execution order of Finalizes is non-deterministic.
            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_PixelBuffer(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

    }

}
