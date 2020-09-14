/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Tizen.Applications;
using Tizen.Applications.Exceptions;

namespace Tizen.NUI
{
    /// <summary>
    /// Represents the Frame Broker.
    /// </summary>
    internal abstract class FrameBrokerBase : IDisposable
    {
        private string LogTag = "NUI";
        private readonly SafeFrameBrokerHandle _handle;
        private Dictionary<int, Interop.FrameBroker.AppControlResultCallback> _resultCallbackMaps = new Dictionary<int, Interop.FrameBroker.AppControlResultCallback>();
        private int _resultId = 0;
        private Interop.FrameBroker.FrameContextLifecycleCallbacks _callbacks;
        private IntPtr _context = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Initializes the FrameBroker class.
        /// </summary>
        /// <param name="window">The window instance of Ecore_Wl2_Window pointer.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid parameter.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed to create the frame broker handle.</exception>
        /// <remarks>This class is only avaliable for platform level signed applications.</remarks>
        internal FrameBrokerBase(Window window)
        {
            Interop.FrameBroker.ErrorCode err;

            if (window == null)
            {
                throw FrameBrokerBaseErrorFactory.GetException(Interop.FrameBroker.ErrorCode.InvalidParameter, "Invalid parameter");
            }

            _callbacks.OnCreate = new Interop.FrameBroker.FrameContextCreateCallback(OnCreateNative);
            _callbacks.OnResume = new Interop.FrameBroker.FrameContextResumeCallback(OnResumeNavie);
            _callbacks.OnPause = new Interop.FrameBroker.FrameContextPauseCallback(OnPauseNative);
            _callbacks.OnDestroy = new Interop.FrameBroker.FrameContextDestroyCallback(OnDestroyNative);
            _callbacks.OnError = new Interop.FrameBroker.FrameContextErrorCallback(OnErrorNative);
            _callbacks.OnUpdate = new Interop.FrameBroker.FrameContextUpdateCallback(OnUpdateNative);

            err = Interop.FrameBroker.Create(window.GetNativeWindowHandler(), ref _callbacks, IntPtr.Zero, out _handle);
            if (err != Interop.FrameBroker.ErrorCode.None)
            {
                throw FrameBrokerBaseErrorFactory.GetException(err, "Failed to create frame broker handle");
            }
        }

        /// <summary>
        /// Sends the launch request asynchronously.
        /// </summary>
        /// <remarks>
        /// The operation is mandatory information for the launch request.
        /// If the operation is not specified, AppControlOperations.Default is used by default.
        /// If the operation is AppControlOperations.Default, the application ID is mandatory to explicitly launch the application.<br/>
        /// Since Tizen 2.4, the launch request of the service application over out of packages is restricted by the platform.
        /// Also, implicit launch requests are NOT delivered to service applications since 2.4.
        /// To launch a service application, an explicit launch request with the application ID given by property ApplicationId MUST be sent.
        /// </remarks>
        /// <param name="appControl">The AppControl.</param>
        /// <param name="toProvider"> The flag, if it's true, the launch request is sent to the frame provider application.</param>
        /// <returns>A task with the result of the launch request.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of the argument is invalid.</exception>
        /// <exception cref="AppNotFoundException">Thrown when the application to run is not found.</exception>
        /// <exception cref="LaunchRejectedException">Thrown when the launch request is rejected.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        internal Task<FrameBrokerBaseResult> SendLaunchRequest(AppControl appControl, bool toProvider)
        {
            if (appControl == null)
            {
                throw FrameBrokerBaseErrorFactory.GetException(Interop.FrameBroker.ErrorCode.InvalidParameter, "Invalid parameter");
            }

            var task = new TaskCompletionSource<FrameBrokerBaseResult>();
            int requestId = 0;

            lock (_resultCallbackMaps)
            {
                requestId = _resultId++;
                _resultCallbackMaps[requestId] = (handle, result, userData) =>
                {
                    task.SetResult((FrameBrokerBaseResult)result);
                    lock (_resultCallbackMaps)
                    {
                        _resultCallbackMaps.Remove((int)userData);
                    }
                };
            }

            Interop.FrameBroker.ErrorCode err;
            if (toProvider)
                err = Interop.FrameBroker.SendLaunchRequestToProvider(_handle, appControl.SafeAppControlHandle, _resultCallbackMaps[requestId], null, (IntPtr)requestId);
            else
                err = Interop.FrameBroker.SendLaunchRequest(_handle, appControl.SafeAppControlHandle, _resultCallbackMaps[requestId], null, (IntPtr)requestId);

            if (err != Interop.FrameBroker.ErrorCode.None)
            {
                throw FrameBrokerBaseErrorFactory.GetException(err, "Failed to send launch request");
            }

            return task.Task;
        }

        /// <summary>
        /// Notifies that the animation is started.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed because of the argument is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of system error.</exception>
        internal void StartAnimation()
        {
            Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.StartAnimation(_context);
            if (err != Interop.FrameBroker.ErrorCode.None)
            {
                throw FrameBrokerBaseErrorFactory.GetException(err, "Failed to notify that the animation is started");
            }
        }

        /// <summary>
        /// Notifies that the animation is finished.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed because of the argument is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of system error.</exception>
        internal void FinishAnimation()
        {
            Interop.FrameBroker.ErrorCode err = Interop.FrameBroker.FinishAnimation(_context);
            if (err != Interop.FrameBroker.ErrorCode.None)
            {
                throw FrameBrokerBaseErrorFactory.GetException(err, "Failed to notify that the animation is finished");
            }
        }

        /// <summary>
        /// Occurs whenever the frame is created.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFrameCreated()
        {
            Log.Warn(LogTag, "The OnFrameCreated() is not implemented");
        }

        /// <summary>
        /// Occurs Whenever the frame is resumed.
        /// </summary>
        /// <param name="frame">The frame data.</param>
        /// <remarks>
        /// When the frame has been prepared, this function is called.
        /// The caller can start animations, To notify that the animation is started, the caller should call StartAnimation().
        /// After the animation is finished, the caller should call FinishAnimation() to notify.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFrameResumed(FrameData frame)
        {
            Log.Warn(LogTag, "The OnFrameResumed() is not implemented");
        }

        /// <summary>
        /// Occurs Whenever the frame is updated.
        /// </summary>
        /// <param name="frame">The frame data.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFrameUpdated(FrameData frame)
        {
            Log.Warn(LogTag, "The OnFrameUpdated() is not implemented");
        }

        /// <summary>
        /// Occurs Whenever the frame is paused.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFramePaused()
        {
            Log.Warn(LogTag, "The OnFramePaused() is not implemented");
        }

        /// <summary>
        /// Occurs Whenever the frame is destroyed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFrameDestroyed()
        {
            Log.Warn(LogTag, "The OnFrameDestroyed() is not implemented");
        }

        /// <summary>
        /// Occurs Whenever the system error is occurred.
        /// </summary>
        /// <param name="error">The frame error.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFrameErred(FrameError error)
        {
            Log.Warn(LogTag, "The OnFrameErred() is not implemented");
        }
                
        private void OnCreateNative(IntPtr context, IntPtr userData)
        {
            _context = context;
            OnFrameCreated();
        }

        private void OnResumeNavie(IntPtr context, IntPtr frame, IntPtr userData)
        {
            OnFrameResumed(new FrameData(frame));
        }

        private void OnPauseNative(IntPtr context, IntPtr userData)
        {
            OnFramePaused();
        }

        private void OnDestroyNative(IntPtr context, IntPtr userData)
        {
            _context = IntPtr.Zero;
            OnFrameDestroyed();
        }

        private void OnErrorNative(IntPtr context, int error, IntPtr userData)
        {
            _context = IntPtr.Zero;
            OnFrameErred((FrameError)error);
        }

        private void OnUpdateNative(IntPtr context, IntPtr frame, IntPtr userData)
        {
            OnFrameUpdated(new FrameData(frame));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _handle.Dispose();
                _disposed = true;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);

        }
    }
}
