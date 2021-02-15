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

using System.Diagnostics;
using System;
using System.Drawing;

namespace Tizen.NUI
{
    using global::System;
    using global::System.ComponentModel;
    using global::System.Runtime.InteropServices;
    using Tizen.NUI.BaseComponents;

    /// <summary>
    /// Capture snapshots the current scene and save as a file.
    /// Applications should follow the example below to create capture :
    /// <code>
    /// Capture capture = new Capture();
    /// </code>
    /// If required, you can also subscribe Finished event :
    /// <code>
    /// capture.Finished += onCaptureFinished;
    /// </code>
    /// At the subcribed event handler, user can know whether capture finish succeeded state.
    /// <code>
    /// private void onCaptureFinished(object sender, CaptureFinishedEventArgs e)
    /// {
    ///   if(e.Success) { //capture success, do something. }
    ///   else { //capture failure, do something. }
    /// }
    /// </code>
    /// suppose that we want to capture View 'A'. And, the View 'A' is overlapped by another View 'B' that is not a child of 'A'.
    /// in this case, if source is root of scene, the captured image includes a part of View 'B' on the 'A'.
    /// however, if source is just View 'A', the result includes only 'A'.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Capture : BaseHandle
    {
        /// <summary>
        /// Create an Capture.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Capture() : this(Interop.Capture.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Capture(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
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
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            Interop.Capture.Delete(swigCPtr);
        }

        /// <summary>
        /// Start capture and save the image as a file.
        /// </summary>
        /// <param name="source">source View or Layer to be used for capture.
        /// This source must be added on the window in advance.</param>
        /// <param name="position">top-left position of area to be captured.
        /// this position is defined in the window.</param>
        /// <param name="size">captured size.</param>
        /// <param name="path">image file path to be saved as a file.
        /// If path is empty string, the captured result is not be saved as a file.</param>
        /// <param name="color">background color of captured scene.</param>
        /// <exception cref="InvalidOperationException">This exception can be due to the invalid size values, of when width or height is lower than zero.</exception>
        /// <exception cref="ArgumentNullException">This exception is thrown when size or path or position or color is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Start(Container source, Position position, Size size, string path, Color color)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            else if (size.Width <= 0 || size.Height <= 0)
            {
                throw new InvalidOperationException("size should larger than zero");
            }
            else if (null == path)
            {
                throw new ArgumentNullException("path should not be null");
            }
            else if (null == position)
            {
                throw new ArgumentNullException(nameof(position));
            }
            else if (null == color)
            {
                throw new ArgumentNullException(nameof(color));
            }

            if (source is View || source is Layer)
            {
                Interop.Capture.Start4(SwigCPtr, source.SwigCPtr, new Vector2(position.X, position.Y).SwigCPtr, new Vector2(size.Width, size.Height).SwigCPtr, path, new Vector4(color.R, color.G, color.B, color.A).SwigCPtr);

                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Start capture and save the image as a file.
        /// </summary>
        /// <param name="source">source View or Layer to be used for capture.
        /// This source must be added on the window in advance.</param>
        /// <param name="size">captured size.</param>
        /// <param name="path">image file path to be saved as a file.
        /// If path is empty string, the captured result is not be saved as a file.</param>
        /// <param name="color">background color of captured scene.</param>
        /// <param name="quality">The value to control image quality for jpeg file format in the range [1, 100].</param>
        /// <exception cref="InvalidOperationException">This exception can be due to the invalid size values, of when width or height is lower than zero.</exception>
        /// <exception cref="ArgumentNullException">This exception is thrown when size or path or color is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Start(Container source, Size size, string path, Color color, uint quality)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            else if (size.Width <= 0 || size.Height <= 0)
            {
                throw new InvalidOperationException("size should larger than zero");
            }
            else if (null == path)
            {
                throw new ArgumentNullException("path should not be null");
            }
            else if (quality > 100)
            {
                throw new InvalidOperationException("quality should between 0 to 100");
            }
            else if (null == color)
            {
                throw new ArgumentNullException(nameof(color));
            }

            if (source is View || source is Layer)
            {
                Interop.Capture.Start3(SwigCPtr, source.SwigCPtr, new Vector2(size.Width, size.Height).SwigCPtr, path, new Vector4(color.R, color.G, color.B, color.A).SwigCPtr, quality);

                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Start capture and save the image as a file.
        /// </summary>
        /// <param name="source">source View or Layer to be used for capture.
        /// This source must be added on the window in advance.</param>
        /// <param name="size">captured size.</param>
        /// <param name="path">image file path to be saved as a file.
        /// If path is empty string, the captured result is not be saved as a file.</param>
        /// <param name="color">background color of captured scene.</param>
        /// <exception cref="InvalidOperationException">This exception can be due to the invalid size values, of when width or height is lower than zero.</exception>
        /// <exception cref="ArgumentNullException">This exception is thrown when size or path or color is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Start(Container source, Size size, string path, Color color)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            else if (size.Width <= 0 || size.Height <= 0)
            {
                throw new InvalidOperationException("size should larger than zero");
            }
            else if (null == path)
            {
                throw new ArgumentNullException("path should not be null");
            }
            else if (null == color)
            {
                throw new ArgumentNullException(nameof(color));
            }

            if (source is View || source is Layer)
            {
                Interop.Capture.Start1(SwigCPtr, source.SwigCPtr, new Vector2(size.Width, size.Height).SwigCPtr, path, new Vector4(color.R, color.G, color.B, color.A).SwigCPtr);

                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Start capture and save the image as a file.
        /// </summary>
        /// <remarks>
        /// Background color of captured scene is transparent.
        /// </remarks>
        /// <param name="source">source View or Layer to be used for capture.
        /// This source must be added on the window in advance.</param>
        /// <param name="size">captured size.</param>
        /// <param name="path">image file path to be saved as a file.
        /// If path is empty string, the captured result is not be saved as a file.</param>
        /// <exception cref="InvalidOperationException">This exception can be due to the invalid size values, of when width or height is lower than zero.</exception>
        /// <exception cref="ArgumentNullException">This exception is thrown when size or path is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Start(Container source, Size size, string path)
        {
            if (null == size)
            {
                throw new ArgumentNullException(nameof(size));
            }
            else if (size.Width <= 0 || size.Height <= 0)
            {
                throw new InvalidOperationException("size should larger than zero");
            }
            else if (null == path)
            {
                throw new ArgumentNullException("path should not be null");
            }

            if (source is View || source is Layer)
            {
                Interop.Capture.Start2(SwigCPtr, source.SwigCPtr, new Vector2(size.Width, size.Height).SwigCPtr, path);

                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Set result image quality in case of jpeg.
        /// </summary>
        /// <param name="quality">quality The value to control image quality for jpeg file format in the range [1, 100]</param>
        /// <exception cref="InvalidOperationException">This exception can be due to the invalid size values, of when quality is lower than zero or over than 100.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetImageQuality(uint quality)
        {
            if (quality < 0 || quality > 100)
            {
                throw new InvalidOperationException("quality should between zero to 100");
            }

            Interop.Capture.SetImageQuality(SwigCPtr, quality);
        }

        private void onFinished(IntPtr data, int state)
        {
            if (data != IntPtr.Zero)
            {
                var arg = new CaptureFinishedEventArgs();
                // dali native definition :
                // enum class FinishState
                // {
                //   SUCCEEDED, ///< Succeeded in saving the result after capture
                //   FAILED     ///< Failed to capture by time out or to save the result
                // };
                arg.Success = (state == 0) ? true : false;
                finishedEventHandler?.Invoke(this, arg);
            }
        }

        private CaptureSignal finishedSignal;
        private delegate void finishedCallbackType(IntPtr data, int state);
        private finishedCallbackType finishedCallback;
        private EventHandler<CaptureFinishedEventArgs> finishedEventHandler;

        /// <summary>
        /// For subscribing Finished event sent by this class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<CaptureFinishedEventArgs> Finished
        {
            add
            {
                if (finishedEventHandler == null && disposed == false)
                {
                    finishedSignal = new CaptureSignal(Interop.Capture.Get(SwigCPtr), false);
                    finishedCallback = onFinished;
                    finishedSignal.Connect(finishedCallback);
                }
                finishedEventHandler += value;
            }
            remove
            {
                finishedEventHandler -= value;

                if (finishedEventHandler == null && finishedSignal?.Empty() == false)
                {
                    finishedCallback = onFinished;
                    finishedSignal.Disconnect(finishedCallback);
                }
            }
        }

        /// <summary>
        /// Get NativeImageSource that is saved captured image.
        /// </summary>
        /// <returns>NativeImageSource that is saved captured image.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NativeImageSource GetNativeImageSource()
        {
            Tizen.Log.Debug("NUI", $"GetNativeImageSource()");
            return new NativeImageSource(Interop.Capture.GetNativeImageSourcePtr(SwigCPtr), true);
        }
    }

    /// <summary>
    /// CaptureFinishedEventArgs
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CaptureFinishedEventArgs : EventArgs
    {
        /// <summary>
        /// Status of saving the result after capture.
        /// </summary>
        /// <value>
        /// true when succeeded in saving the result after capture.
        /// false when failed to capture by time out or to save the result.
        /// </value>
        public bool Success { get; internal set; }
    }

    internal class CaptureSignal : Disposable
    {
        internal CaptureSignal(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            if (SwigCMemOwn)
            {
                Interop.Capture.DeleteSignal(swigCPtr);
            }
        }

        public bool Empty()
        {
            bool ret = Interop.Capture.SignalEmpty(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetConnectionCount()
        {
            uint ret = Interop.Capture.SignalGetConnectionCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Connect(Delegate func)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate<Delegate>(func);
            {
                Interop.Capture.SignalConnect(SwigCPtr, new HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void Disconnect(Delegate func)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate<Delegate>(func);
            {
                Interop.Capture.SignalDisconnect(SwigCPtr, new HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void Emit(Capture src, bool success)
        {
            Interop.Capture.SignalEmit(SwigCPtr, src.SwigCPtr, (success ? 0 : 1));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
