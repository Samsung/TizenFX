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
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class AsyncImageLoader : BaseHandle
    {
        private EventHandler<ImageLoadedEventArgs> imageLoadedEventHandler;
        private EventHandler<PixelBufferLoadedEventArgs> pixelBufferLoadedEventHandler;
        private ImageLoadedSignalType imageLoadedCallback;
        private PixelBufferLoadedSignalType pixelBufferLoadedCallback;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void ImageLoadedSignalType(uint loadingTaskId, IntPtr pixelData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PixelBufferLoadedSignalType(uint loadingTaskId, uint pixelBufferCount, IntPtr pixelBuffer0, IntPtr pixelBuffer1, IntPtr pixelBuffer2);

        internal AsyncImageLoader(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.AsyncImageLoader.DeleteAsyncImageLoader(swigCPtr);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AsyncImageLoader() : this(Interop.AsyncImageLoader.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Load(string url)
        {
            uint ret = Interop.AsyncImageLoader.Load(SwigCPtr, url);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Load(string url, Uint16Pair dimensions)
        {
            uint ret = Interop.AsyncImageLoader.Load(SwigCPtr, url, Uint16Pair.getCPtr(dimensions));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Load(string url, Uint16Pair dimensions, FittingModeType fittingMode, SamplingModeType samplingMode, bool orientationCorrection)
        {
            uint ret = Interop.AsyncImageLoader.Load(SwigCPtr, url, Uint16Pair.getCPtr(dimensions), (int)fittingMode, (int)samplingMode, orientationCorrection);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Cancel(uint loadingTaskId)
        {
            bool ret = Interop.AsyncImageLoader.Cancel(SwigCPtr, loadingTaskId);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CancelAll()
        {
            Interop.AsyncImageLoader.CancelAll(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// You can override it to clean-up your own resources
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

                if (imageLoadedCallback != null)
                {
                    Interop.AsyncImageLoader.ImageLoadedSignalDisconnect(SwigCPtr, imageLoadedCallback.ToHandleRef(this));
                    imageLoadedCallback = null;
                    imageLoadedEventHandler = null;
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }

                if (pixelBufferLoadedCallback != null)
                {
                    Interop.AsyncImageLoader.PixelBufferLoadedSignalDisconnect(SwigCPtr, pixelBufferLoadedCallback.ToHandleRef(this));
                    pixelBufferLoadedCallback = null;
                    pixelBufferLoadedEventHandler = null;
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            CancelAll();

            base.Dispose(type);
        }

        /// <summary>
        /// Event when pixel data are loaded.
        /// null or empty PixelData if load failed.
        /// </summary>
        /// <remarks>
        /// We cannot use both ImageLoaded and PixelBufferLoaded events.
        /// If we use PixelBufferLoaded, ImageLoaded will be ignored.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ImageLoadedEventArgs> ImageLoaded
        {
            add
            {
                if (imageLoadedEventHandler == null)
                {
                    imageLoadedCallback = OnImageLoaded;
                    Interop.AsyncImageLoader.ImageLoadedSignalConnect(SwigCPtr, imageLoadedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                imageLoadedEventHandler += value;
            }

            remove
            {
                imageLoadedEventHandler -= value;
                if (imageLoadedEventHandler == null && imageLoadedCallback != null)
                {
                    Interop.AsyncImageLoader.ImageLoadedSignalDisconnect(SwigCPtr, imageLoadedCallback.ToHandleRef(this));
                    imageLoadedCallback = null;
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
            }
        }

        /// <summary>
        /// Event when pixel buffers are loaded.
        /// null or empty PixelBuffer list if load failed.
        /// </summary>
        /// <remarks>
        /// We cannot use both ImageLoaded and PixelBufferLoaded events.
        /// If we use PixelBufferLoaded, ImageLoaded will be ignored.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<PixelBufferLoadedEventArgs> PixelBufferLoaded
        {
            add
            {
                if (pixelBufferLoadedEventHandler == null)
                {
                    pixelBufferLoadedCallback = OnPixelBufferLoaded;
                    Interop.AsyncImageLoader.PixelBufferLoadedSignalConnect(SwigCPtr, pixelBufferLoadedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                pixelBufferLoadedEventHandler += value;
            }

            remove
            {
                pixelBufferLoadedEventHandler -= value;
                if (pixelBufferLoadedEventHandler == null && pixelBufferLoadedCallback != null)
                {
                    Interop.AsyncImageLoader.PixelBufferLoadedSignalDisconnect(SwigCPtr, pixelBufferLoadedCallback.ToHandleRef(this));
                    pixelBufferLoadedCallback = null;
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
            }
        }

        private void OnImageLoaded(uint loadingTaskId, IntPtr pixelData)
        {
            ImageLoadedEventArgs e = new ImageLoadedEventArgs();
            e.LoadingTaskId = loadingTaskId;
            e.PixelData = pixelData != IntPtr.Zero ? new PixelData(pixelData, false) : null;

            imageLoadedEventHandler?.Invoke(this, e);
        }

        private void OnPixelBufferLoaded(uint loadingTaskId, uint pixelBufferListCount, IntPtr pixelBuffer0, IntPtr pixelBuffer1, IntPtr pixelBuffer2)
        {
            PixelBufferLoadedEventArgs e = new PixelBufferLoadedEventArgs();
            e.LoadingTaskId = loadingTaskId;
            e.PixelBuffers = null;

            if (pixelBufferListCount > 0u)
            {
                e.PixelBuffers = new List<PixelBuffer>();
                if (pixelBufferListCount > 0u)
                {
                    e.PixelBuffers.Add(pixelBuffer0 != IntPtr.Zero ? new PixelBuffer(pixelBuffer0, false) : null);
                }
                if (pixelBufferListCount > 1u)
                {
                    e.PixelBuffers.Add(pixelBuffer1 != IntPtr.Zero ? new PixelBuffer(pixelBuffer0, false) : null);
                }
                if (pixelBufferListCount > 2u)
                {
                    e.PixelBuffers.Add(pixelBuffer2 != IntPtr.Zero ? new PixelBuffer(pixelBuffer0, false) : null);
                }
            }

            pixelBufferLoadedEventHandler?.Invoke(this, e);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ImageLoadedEventArgs : EventArgs
        {
            public uint LoadingTaskId { get; internal set; }
            public PixelData PixelData { get; internal set; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public class PixelBufferLoadedEventArgs : EventArgs
        {
            public uint LoadingTaskId { get; internal set; }
            public List<PixelBuffer> PixelBuffers { get; internal set; }
        }
    }
}
