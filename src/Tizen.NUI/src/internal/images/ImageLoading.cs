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
    /// A class containing methods providing image loading
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("please use ImageLoader instead!")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "<Pending>")]
    public class ImageLoading
    {
        /// <summary>
        /// Load an image synchronously from local file.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <param name="fittingMode">The method used to fit the shape of the image before loading to the shape defined by the size parameter.</param>
        /// <param name="samplingMode">The filtering method used when sampling pixels from the input image while fitting it to desired size.</param>
        /// <param name="orientationCorrection">Reorient the image to respect any orientation metadata in its header.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case loading failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromFile(string url, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode, bool orientationCorrection)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.LoadImageFromFile(url, Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode, orientationCorrection), true);
            uSize.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from local file.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <param name="fittingMode">The method used to fit the shape of the image before loading to the shape defined by the size parameter.</param>
        /// <param name="samplingMode">The filtering method used when sampling pixels from the input image while fitting it to desired size.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case loading failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromFile(string url, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.LoadImageFromFile(url, Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode), true);
            uSize.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from local file.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <param name="fittingMode">The method used to fit the shape of the image before loading to the shape defined by the size parameter.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case loading failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromFile(string url, Size2D size, FittingModeType fittingMode)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.LoadImageFromFile(url, Uint16Pair.getCPtr(uSize), (int)fittingMode), true);
            uSize.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from local file.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case loading failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromFile(string url, Size2D size)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.LoadImageFromFile(url, Uint16Pair.getCPtr(uSize)), true);
            uSize.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from local file.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case loading failed.</returns>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromFile(string url)
        {
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.LoadImageFromFile(url), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from Stream. Load from current position to end of stream.
        /// </summary>
        /// <param name="stream">The Stream of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <param name="fittingMode">The method used to fit the shape of the image before loading to the shape defined by the size parameter.</param>
        /// <param name="samplingMode">The filtering method used when sampling pixels from the input image while fitting it to desired size.</param>
        /// <param name="orientationCorrection">Reorient the image to respect any orientation metadata in its header.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case loading failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when stream or size is null. </exception>
        /// <exception cref="InvalidOperationException"> Thrown when stream don't have any data. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromBuffer(System.IO.Stream stream, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode, bool orientationCorrection)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (size == null)
            {
                throw new ArgumentNullException(nameof(size));
            }
            long streamLength = stream.Length - stream.Position;
            if (streamLength <= 0)
            {
                throw new InvalidOperationException("stream lenght is <= 0");
            }

            // Read data from stream
            byte[] streamData = new byte[streamLength];
            stream.Read(streamData, 0, (int)streamLength);

            // Allocate buffer that internal DALi engine can read
            VectorUnsignedChar buffer = new VectorUnsignedChar();

            buffer.Resize((uint)streamLength);
            var bufferBegin = buffer.Begin();
            global::System.Runtime.InteropServices.HandleRef bufferRef = SWIGTYPE_p_unsigned_char.getCPtr(bufferBegin);

            // Copy data from stream to buffer
            System.Runtime.InteropServices.Marshal.Copy(streamData, 0, bufferRef.Handle, (int)streamLength);

            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.LoadImageFromBuffer(VectorUnsignedChar.getCPtr(buffer), Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode, orientationCorrection), true);
            uSize.Dispose();
            buffer.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from Stream. Load from current position to end of stream.
        /// </summary>
        /// <param name="stream">The Stream of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <param name="fittingMode">The method used to fit the shape of the image before loading to the shape defined by the size parameter.</param>
        /// <param name="samplingMode">The filtering method used when sampling pixels from the input image while fitting it to desired size.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case loading failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when stream or size is null. </exception>
        /// <exception cref="InvalidOperationException"> Thrown when stream don't have any data. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromBuffer(System.IO.Stream stream, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (size == null)
            {
                throw new ArgumentNullException(nameof(size));
            }
            long streamLength = stream.Length - stream.Position;
            if (streamLength <= 0)
            {
                throw new InvalidOperationException("stream lenght is <= 0");
            }

            // Read data from stream
            byte[] streamData = new byte[streamLength];
            stream.Read(streamData, 0, (int)streamLength);

            // Allocate buffer that internal DALi engine can read
            VectorUnsignedChar buffer = new VectorUnsignedChar();

            buffer.Resize((uint)streamLength);
            var bufferBegin = buffer.Begin();
            global::System.Runtime.InteropServices.HandleRef bufferRef = SWIGTYPE_p_unsigned_char.getCPtr(bufferBegin);

            // Copy data from stream to buffer
            System.Runtime.InteropServices.Marshal.Copy(streamData, 0, bufferRef.Handle, (int)streamLength);

            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.LoadImageFromBuffer(VectorUnsignedChar.getCPtr(buffer), Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode), true);
            uSize.Dispose();
            buffer.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from Stream. Load from current position to end of stream.
        /// </summary>
        /// <param name="stream">The Stream of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <param name="fittingMode">The method used to fit the shape of the image before loading to the shape defined by the size parameter.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case loading failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when stream or size is null. </exception>
        /// <exception cref="InvalidOperationException"> Thrown when stream don't have any data. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromBuffer(System.IO.Stream stream, Size2D size, FittingModeType fittingMode)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (size == null)
            {
                throw new ArgumentNullException(nameof(size));
            }
            long streamLength = stream.Length - stream.Position;
            if (streamLength <= 0)
            {
                throw new InvalidOperationException("stream lenght is <= 0");
            }

            // Read data from stream
            byte[] streamData = new byte[streamLength];
            stream.Read(streamData, 0, (int)streamLength);

            // Allocate buffer that internal DALi engine can read
            VectorUnsignedChar buffer = new VectorUnsignedChar();

            buffer.Resize((uint)streamLength);
            var bufferBegin = buffer.Begin();
            global::System.Runtime.InteropServices.HandleRef bufferRef = SWIGTYPE_p_unsigned_char.getCPtr(bufferBegin);

            // Copy data from stream to buffer
            System.Runtime.InteropServices.Marshal.Copy(streamData, 0, bufferRef.Handle, (int)streamLength);

            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.LoadImageFromBuffer(VectorUnsignedChar.getCPtr(buffer), Uint16Pair.getCPtr(uSize), (int)fittingMode), true);
            uSize.Dispose();
            buffer.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from Stream. Load from current position to end of stream.
        /// </summary>
        /// <param name="stream">The Stream of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case loading failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when stream or size is null. </exception>
        /// <exception cref="InvalidOperationException"> Thrown when stream don't have any data. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromBuffer(System.IO.Stream stream, Size2D size)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (size == null)
            {
                throw new ArgumentNullException(nameof(size));
            }
            long streamLength = stream.Length - stream.Position;
            if (streamLength <= 0)
            {
                throw new InvalidOperationException("stream lenght is <= 0");
            }

            // Read data from stream
            byte[] streamData = new byte[streamLength];
            stream.Read(streamData, 0, (int)streamLength);

            // Allocate buffer that internal DALi engine can read
            VectorUnsignedChar buffer = new VectorUnsignedChar();

            buffer.Resize((uint)streamLength);
            var bufferBegin = buffer.Begin();
            global::System.Runtime.InteropServices.HandleRef bufferRef = SWIGTYPE_p_unsigned_char.getCPtr(bufferBegin);

            // Copy data from stream to buffer
            System.Runtime.InteropServices.Marshal.Copy(streamData, 0, bufferRef.Handle, (int)streamLength);

            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.LoadImageFromBuffer(VectorUnsignedChar.getCPtr(buffer), Uint16Pair.getCPtr(uSize)), true);
            uSize.Dispose();
            buffer.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from Stream. Load from current position to end of stream.
        /// </summary>
        /// <param name="stream">The Stream of the image file to load.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case loading failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when stream is null. </exception>
        /// <exception cref="InvalidOperationException"> Thrown when stream don't have any data. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromBuffer(System.IO.Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            long streamLength = stream.Length - stream.Position;
            if (streamLength <= 0)
            {
                throw new InvalidOperationException("stream lenght is <= 0");
            }

            // Read data from stream
            byte[] streamData = new byte[streamLength];
            stream.Read(streamData, 0, (int)streamLength);

            // Allocate buffer that internal DALi engine can read
            VectorUnsignedChar buffer = new VectorUnsignedChar();

            buffer.Resize((uint)streamLength);
            var bufferBegin = buffer.Begin();
            global::System.Runtime.InteropServices.HandleRef bufferRef = SWIGTYPE_p_unsigned_char.getCPtr(bufferBegin);

            // Copy data from stream to buffer
            System.Runtime.InteropServices.Marshal.Copy(streamData, 0, bufferRef.Handle, (int)streamLength);

            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.LoadImageFromBuffer(VectorUnsignedChar.getCPtr(buffer)), true);
            buffer.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Determine the size of an image that LoadImageFromFile will provide when given the same image loading parameters.
        /// </summary>
        /// <param name="filename">The name of the image.</param>
        /// <param name="size">The requested size for the image.</param>
        /// <param name="fittingMode">The method to use to map the source image to the desired dimensions.</param>
        /// <param name="samplingMode">The image filter to use if the image needs to be downsampled to the requested size.</param>
        /// <param name="orientationCorrection">Whether to use image metadata to rotate or flip the image, for example, from portrait to landscape.</param>
        /// <returns>Dimensions that image will have if it is loaded with given parameters.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D GetClosestImageSize(string filename, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode, bool orientationCorrection)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            var val = new Uint16Pair(Interop.ImageLoading.GetClosestImageSize(filename, Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode, orientationCorrection), true);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());
            val.Dispose();
            uSize.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Determine the size of an image that LoadImageFromFile will provide when given the same image loading parameters.
        /// </summary>
        /// <param name="filename">The name of the image.</param>
        /// <param name="size">The requested size for the image</param>
        /// <param name="fittingMode">The method to use to map the source image to the desired dimensions.</param>
        /// <param name="samplingMode">The image filter to use if the image needs to be downsampled to the requested size.</param>
        /// <returns>Dimensions that image will have if it is loaded with given parameters.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D GetClosestImageSize(string filename, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            var val = new Uint16Pair(Interop.ImageLoading.GetClosestImageSize(filename, Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode), true);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());
            val.Dispose();
            uSize.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Determine the size of an image that LoadImageFromFile will provide when given the same image loading parameters.
        /// </summary>
        /// <param name="filename">The name of the image.</param>
        /// <param name="size">The requested size for the image</param>
        /// <param name="fittingMode">The method to use to map the source image to the desired dimensions.</param>
        /// <returns>Dimensions that image will have if it is loaded with given parameters.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D GetClosestImageSize(string filename, Size2D size, FittingModeType fittingMode)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            var val = new Uint16Pair(Interop.ImageLoading.GetClosestImageSize(filename, Uint16Pair.getCPtr(uSize), (int)fittingMode), true);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());
            val.Dispose();
            uSize.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Determine the size of an image that LoadImageFromFile will provide when given the same image loading parameters.
        /// </summary>
        /// <param name="filename">The name of the image.</param>
        /// <param name="size">The requested size for the image</param>
        /// <returns>Dimensions that image will have if it is loaded with given parameters.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D GetClosestImageSize(string filename, Size2D size)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            var val = new Uint16Pair(Interop.ImageLoading.GetClosestImageSize(filename, Uint16Pair.getCPtr(uSize)), true);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());
            val.Dispose();
            uSize.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Determine the size of an image that LoadImageFromFile will provide when given the same image loading parameters.
        /// </summary>
        /// <param name="filename">The name of the image.</param>
        /// <returns>Dimensions that image will have if it is loaded with given parameters.</returns>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D GetClosestImageSize(string filename)
        {
            var val = new Uint16Pair(Interop.ImageLoading.GetClosestImageSize(filename), true);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());
            val.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Get the size of an original image rotated according to image metadata
        /// </summary>
        /// <param name="filename">The name of the image.</param>
        /// <returns>Dimension of the original image.</returns>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D GetOriginalImageSize(string filename)
        {
            return GetOriginalImageSize(filename, true);
        }

        /// <summary>
        /// Get the size of an original image rotated according to image metadata
        /// </summary>
        /// <param name="filename">The name of the image.</param>
        /// <param name="orientationCorrection">Reorient the image to respect any orientation metadata in its header.</param>
        /// <returns>Dimension of the original image.</returns>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D GetOriginalImageSize(string filename, bool orientationCorrection)
        {
            var val = new Uint16Pair(Interop.ImageLoading.GetOriginalImageSize(filename, orientationCorrection), true);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());
            val.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from a remote resource.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <param name="fittingMode">The method used to fit the shape of the image before loading to the shape defined by the size parameter.</param>
        /// <param name="samplingMode">The filtering method used when sampling pixels from the input image while fitting it to desired size.</param>
        /// <param name="orientationCorrection">Reorient the image to respect any orientation metadata in its header.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case downloading or decoding failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer DownloadImageSynchronously(string url, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode, bool orientationCorrection)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.DownloadImageSynchronously(url, Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode, orientationCorrection), true);
            uSize.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from a remote resource.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <param name="fittingMode">The method used to fit the shape of the image before loading to the shape defined by the size parameter.</param>
        /// <param name="samplingMode">The filtering method used when sampling pixels from the input image while fitting it to desired size.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case downloading or decoding failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer DownloadImageSynchronously(string url, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.DownloadImageSynchronously(url, Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode), true);
            uSize.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from a remote resource.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <param name="fittingMode">The method used to fit the shape of the image before loading to the shape defined by the size parameter.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case downloading or decoding failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer DownloadImageSynchronously(string url, Size2D size, FittingModeType fittingMode)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.DownloadImageSynchronously(url, Uint16Pair.getCPtr(uSize), (int)fittingMode), true);
            uSize.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Hidden API (Inhouse API).
        /// Using Uri class to provide safe service and secure API.
        /// Load an image synchronously from a remote resource.
        /// </summary>
        /// <param name="uri">The URI of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <param name="fittingMode">The method used to fit the shape of the image before loading to the shape defined by the size parameter.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case downloading or decoding failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <exception cref="ArgumentNullException">Thrown when uri is null.</exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer DownloadImageSynchronously(Uri uri, Size2D size, FittingModeType fittingMode)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.DownloadImageSynchronously(uri.AbsoluteUri, Uint16Pair.getCPtr(uSize), (int)fittingMode), true);
            uSize.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from a remote resource.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case downloading or decoding failed.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer DownloadImageSynchronously(string url, Size2D size)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.DownloadImageSynchronously(url, Uint16Pair.getCPtr(uSize)), true);
            uSize.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from a remote resource.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case downloading or decoding failed.</returns>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer DownloadImageSynchronously(string url)
        {
            PixelBuffer ret = new PixelBuffer(Interop.ImageLoading.DownloadImageSynchronously(url), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }
}
