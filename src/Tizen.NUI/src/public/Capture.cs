using System.Diagnostics;
using System;
using System.Drawing;
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

namespace Tizen.NUI
{
    using global::System;
    using global::System.ComponentModel;
    using global::System.Runtime.InteropServices;
    using global::System.ComponentModel;
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

        internal Capture(IntPtr cPtr, bool cMemoryOwn) : base(Interop.Capture.Upcast(cPtr), cMemoryOwn)
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
        /// <param name="source">source View or Layer to be used for capture.</param>
        /// <param name="size">captured size.</param>
        /// <param name="path">image file path to be saved as a file.
        /// If path is empty string, the captured result is not be saved as a file.</param>
        /// <param name="color">background color of captured scene.</param>
        /// <exception cref="InvalidOperationException">This exception can be due to the invalid size values, of when width or height is lower than zero.</exception>
        /// <exception cref="ArgumentNullException">This exception is due to the path is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Start(Container source, Size size, string path, Color color)
        {
            if (size.Width <= 0 || size.Height <=0)
            {
                throw new InvalidOperationException("size should larger than zero");
            }
            else if (null == path)
            {
                throw new ArgumentNullException("path should not be null");
            }

            if (source is View || source is Layer)
            {
                Interop.Capture.Start1(swigCPtr, source.SwigCPtr, new Vector2(size.Width, size.Height).SwigCPtr, path, new Vector4(color.R, color.G, color.B, color.A).SwigCPtr);

                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Start capture and save the image as a file.
        /// </summary>
        /// <remarks>
        /// Background color of captured scene is transparent.
        /// </remarks>
        /// <param name="source">source View or Layer to be used for capture.</param>
        /// <param name="size">captured size.</param>
        /// <param name="path">image file path to be saved as a file.
        /// If path is empty string, the captured result is not be saved as a file.</param>
        /// <exception cref="InvalidOperationException">This exception can be due to the invalid size values, of when width or height is lower than zero.</exception>
        /// <exception cref="ArgumentNullException">This exception is due to the path is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Start(Container source, Size size, string path)
        {
            if (size.Width <= 0 || size.Height <=0)
            {
                throw new InvalidOperationException("size should larger than zero");
            }
            else if (null == path)
            {
                throw new ArgumentNullException("path should not be null");
            }
            
            if (source is View || source is Layer)
            {
                Interop.Capture.Start2(swigCPtr, source.SwigCPtr, new Vector2(size.Width, size.Height).SwigCPtr, path);

                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
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
                    finishedSignal = new CaptureSignal(Interop.Capture.Get(swigCPtr), false);
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
            return new NativeImageSource(Interop.Capture.GetNativeImageSourcePtr(swigCPtr), true);
        }

        /// <summary>
        /// Generate captured image's Url
        /// </summary>
        /// <returns>The Url string representing this captured image source</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GenerateUrl()
        {
            string url = "";
            url = Interop.Capture.GenerageUrl(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return url;
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
            if (swigCMemOwn)
            {
                Interop.Capture.DeleteSignal(swigCPtr);
            }
        }

        public bool Empty()
        {
            bool ret = Interop.Capture.SignalEmpty(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetConnectionCount()
        {
            uint ret = Interop.Capture.SignalGetConnectionCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Connect(Delegate func)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate<Delegate>(func);
            {
                Interop.Capture.SignalConnect(swigCPtr, new HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void Disconnect(Delegate func)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate<Delegate>(func);
            {
                Interop.Capture.SignalDisconnect(swigCPtr, new HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void Emit(Capture src, bool success)
        {
            Interop.Capture.SignalEmit(swigCPtr, src.SwigCPtr, (success ? 0 : 1));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
