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
    using global::System;
    using global::System.ComponentModel;
    using global::System.Runtime.InteropServices;

    /// <summary>
    /// Class for Encoded Image Buffer.
    /// Buffer comes from System.IO.Stream.
    /// This data will decode internally when you use GeneratedUrl as View's ResourceUrl.
    /// Note: This class doesn't allow to fix/change anything.
    /// Only constructor allow to setup data.
    /// </summary>
    /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EncodedImageBuffer : BaseHandle
    {
        private VectorUnsignedChar mCachedBuffer; // cached encoded raw buffer

        /// <summary>
        /// The list of type of encoded image buffer.
        /// It will be used when we want to specify the buffer data type.
        /// </summary>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names")]
        public enum ImageTypes
        {
            /// <summary>
            /// Regular images.
            /// </summary>
            /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
            [EditorBrowsable(EditorBrowsableState.Never)]
            RegularImage = 0,

            /// <summary>
            /// Vector rasterize images.
            /// </summary>
            /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
            [EditorBrowsable(EditorBrowsableState.Never)]
            VectorImage,

            /// <summary>
            /// Animated vector rasterize images.
            /// </summary>
            /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
            [EditorBrowsable(EditorBrowsableState.Never)]
            AnimatedVectorImage,
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stream">The Stream of the image file.</param>
        /// <exception cref="ArgumentNullException"> Thrown when stream is null. </exception>
        /// <exception cref="InvalidOperationException"> Thrown when stream don't have any data. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EncodedImageBuffer(System.IO.Stream stream) : this(GetRawBuffrFromStreamHelper(stream), ImageTypes.RegularImage)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor with image type.
        /// </summary>
        /// <param name="stream">The Stream of the image file.</param>
        /// <param name="imageType">The type of the image stream.</param>
        /// <exception cref="ArgumentNullException"> Thrown when stream is null. </exception>
        /// <exception cref="InvalidOperationException"> Thrown when stream don't have any data. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EncodedImageBuffer(System.IO.Stream stream, ImageTypes imageType) : this(GetRawBuffrFromStreamHelper(stream), imageType)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal EncodedImageBuffer(VectorUnsignedChar buffer, ImageTypes imageType) : this(Interop.EncodedImageBuffer.New(VectorUnsignedChar.getCPtr(buffer), (int)imageType), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            mCachedBuffer = buffer;
        }

        internal EncodedImageBuffer(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, false)
        {
            // Note : EncodedImageBuffer don't need to be register in Registry default. So we can create this class from worker thread.
        }

        internal EncodedImageBuffer(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        /// <summary>
        /// The type of image for this EncodedImageBuffer.
        /// </summary>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageTypes ImageType
        {
            set
            {
                Interop.EncodedImageBuffer.SetImageType(SwigCPtr, (int)value);
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            get
            {
                ImageTypes ret = (ImageTypes)Interop.EncodedImageBuffer.GetImageType(SwigCPtr);
                NDalicPINVOKE.ThrowExceptionIfExists();
                return ret;
            }
        }

        /// <summary>
        /// Generate URI from current buffer.
        /// We can now use this url for ImageView.ResourceUrl
        /// Note : the url lifecycle is same as ImageUrl and it's internal usage.
        /// Store only ImageUrl.ToString() result and re-use that url is Undefined Behavior.
        /// </summary>
        /// <remarks>
        /// This API should not be called at worker thread.
        /// </remarks>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageUrl GenerateUrl()
        {
            return new ImageUrl(Interop.EncodedImageBuffer.GenerateUrl(this.SwigCPtr.Handle), true);
        }

        /// <summary>
        /// Get current raw buffer. (read-only)
        /// Note : the raw buffer doesn't have memory ownership.
        /// Access to write something to raw buffer is Undefined Behavior.
        /// </summary>
        /// This will not be public opened.
        internal VectorUnsignedChar GetRawBuffer()
        {
            mCachedBuffer ??= new VectorUnsignedChar(Interop.EncodedImageBuffer.GetRawBuffer(this.SwigCPtr.Handle), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return mCachedBuffer;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="type"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                mCachedBuffer?.Dispose();
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            Interop.EncodedImageBuffer.DeleteEncodedImageBuffer(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get VectorUnsignedChar from System.IO.Stream.
        /// This funcion exist only for Constructor.
        /// </summary>
        /// This will not be public opened.
        private static VectorUnsignedChar GetRawBuffrFromStreamHelper(System.IO.Stream stream)
        {
            if(stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if(!stream.CanRead)
            {
                throw new InvalidOperationException("stream don't support to read");
            }

            // Copy stream to memoryStream
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            stream.CopyTo(memoryStream);
            memoryStream.Seek(0, System.IO.SeekOrigin.Begin);

            long streamLength = memoryStream.Length;
            if(streamLength <= 0)
            {
                throw new InvalidOperationException("stream length is <= 0");
            }

            // Allocate buffer that internal DALi engine can read
            VectorUnsignedChar buffer = new VectorUnsignedChar();

            buffer.Resize((uint)streamLength);
            var bufferBegin = buffer.Begin();
            global::System.Runtime.InteropServices.HandleRef bufferRef = SWIGTYPE_p_unsigned_char.getCPtr(bufferBegin);

            // Copy data from memoryStream to buffer
            System.Runtime.InteropServices.Marshal.Copy(memoryStream.GetBuffer(), 0, bufferRef.Handle, (int)streamLength);

            memoryStream.Dispose();

            return buffer;
        }
    }
}
