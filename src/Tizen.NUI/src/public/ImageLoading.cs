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
    /// Loading an image.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
    [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromFile(string url, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode, bool orientationCorrection)
        {
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(NDalicPINVOKE.LoadImageFromFile__SWIG_0(url, Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode, orientationCorrection), true);
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
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromFile(string url, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode)
        {
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(NDalicPINVOKE.LoadImageFromFile__SWIG_1(url, Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode), true);
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
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromFile(string url, Size2D size, FittingModeType fittingMode)
        {
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(NDalicPINVOKE.LoadImageFromFile__SWIG_2(url, Uint16Pair.getCPtr(uSize), (int)fittingMode), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from local file.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case loading failed.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromFile(string url, Size2D size)
        {
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(NDalicPINVOKE.LoadImageFromFile__SWIG_3(url, Uint16Pair.getCPtr(uSize)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from local file.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case loading failed.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer LoadImageFromFile(string url)
        {
            PixelBuffer ret = new PixelBuffer(NDalicPINVOKE.LoadImageFromFile__SWIG_4(url), true);
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
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D GetClosestImageSize(string filename, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode, bool orientationCorrection)
        {
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            var val = new Uint16Pair(NDalicPINVOKE.GetClosestImageSize__SWIG_0(filename, Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode, orientationCorrection), true);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());
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
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D GetClosestImageSize(string filename, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode)
        {
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            var val = new Uint16Pair(NDalicPINVOKE.GetClosestImageSize__SWIG_1(filename, Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode), true);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());
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
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D GetClosestImageSize(string filename, Size2D size, FittingModeType fittingMode)
        {
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            var val = new Uint16Pair(NDalicPINVOKE.GetClosestImageSize__SWIG_2(filename, Uint16Pair.getCPtr(uSize), (int)fittingMode), true);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Determine the size of an image that LoadImageFromFile will provide when given the same image loading parameters.
        /// </summary>
        /// <param name="filename">The name of the image.</param>
        /// <param name="size">The requested size for the image</param>
        /// <returns>Dimensions that image will have if it is loaded with given parameters.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D GetClosestImageSize(string filename, Size2D size)
        {
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            var val = new Uint16Pair(NDalicPINVOKE.GetClosestImageSize__SWIG_3(filename, Uint16Pair.getCPtr(uSize)), true);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Determine the size of an image that LoadImageFromFile will provide when given the same image loading parameters.
        /// </summary>
        /// <param name="filename">The name of the image.</param>
        /// <returns>Dimensions that image will have if it is loaded with given parameters.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D GetClosestImageSize(string filename)
        {
            var val = new Uint16Pair(NDalicPINVOKE.GetClosestImageSize__SWIG_4(filename), true);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Get the size of an original image
        /// </summary>
        /// <param name="filename">The name of the image.</param>
        /// <returns>Dimension of the original image.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D GetOriginalImageSize(string filename)
        {
            var val = new Uint16Pair(NDalicPINVOKE.GetOriginalImageSize(filename), true);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());
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
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer DownloadImageSynchronously(string url, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode, bool orientationCorrection)
        {
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(NDalicPINVOKE.DownloadImageSynchronously__SWIG_0(url, Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode, orientationCorrection), true);
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
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer DownloadImageSynchronously(string url, Size2D size, FittingModeType fittingMode, SamplingModeType samplingMode)
        {
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(NDalicPINVOKE.DownloadImageSynchronously__SWIG_1(url, Uint16Pair.getCPtr(uSize), (int)fittingMode, (int)samplingMode), true);
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
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer DownloadImageSynchronously(string url, Size2D size, FittingModeType fittingMode)
        {
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(NDalicPINVOKE.DownloadImageSynchronously__SWIG_2(url, Uint16Pair.getCPtr(uSize), (int)fittingMode), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from a remote resource.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <param name="size">The width and height to fit the loaded image to, 0.0 means whole image.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case downloading or decoding failed.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer DownloadImageSynchronously(string url, Size2D size)
        {
            var uSize = new Uint16Pair((uint)size.Width, (uint)size.Height);
            PixelBuffer ret = new PixelBuffer(NDalicPINVOKE.DownloadImageSynchronously__SWIG_3(url, Uint16Pair.getCPtr(uSize)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Load an image synchronously from a remote resource.
        /// </summary>
        /// <param name="url">The URL of the image file to load.</param>
        /// <returns>Handle to the loaded PixelBuffer object or an empty handle in case downloading or decoding failed.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5. Therefore, currently this would be used as an in-house API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PixelBuffer DownloadImageSynchronously(string url)
        {
            PixelBuffer ret = new PixelBuffer(NDalicPINVOKE.DownloadImageSynchronously__SWIG_4(url), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }
}
