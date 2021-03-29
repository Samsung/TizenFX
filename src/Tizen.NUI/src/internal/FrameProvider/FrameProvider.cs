/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;
using Tizen.Applications;

namespace Tizen.NUI
{
    /// <summary>
    /// Represents the Frame Provider.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class FrameProvider : IDisposable
    {
        private string logTag = "NUI";
        private readonly SafeFrameProviderHandle handle;
        private Interop.FrameProvider.FrameProviderEventCallbacks callbacks;
        private bool disposed = false;

        /// <summary>
        /// Initializes the FrameProvider class.
        /// </summary>
        /// <param name="window">The window instance of Ecore_Wl2_Window pointer.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid parameter.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed to create the frame broker handle.</exception>
        /// <remarks>This class is only available for platform level signed applications.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal FrameProvider(Window window)
        {
            Interop.FrameProvider.ErrorCode err;

            if (window == null)
            {
                throw FrameProviderErrorFactory.GetException(Interop.FrameProvider.ErrorCode.InvalidParameter, "Invalid parameter");
            }

            callbacks.OnShow = new Interop.FrameProvider.ShowCallback(OnShowNative);
            callbacks.OnHide = new Interop.FrameProvider.HideCallback(OnHideNative);

            err = Interop.FrameProvider.Create(window.GetNativeWindowHandler(), ref callbacks, IntPtr.Zero, out handle);
            if (err != Interop.FrameProvider.ErrorCode.None)
            {
                throw FrameProviderErrorFactory.GetException(err, "Failed to create frame provider handle");
            }
        }

        /// <summary>
        /// Occurs whenever the window is shown.
        /// </summary>
        /// <remarks>You have to call NotifyShowStatus() to notify that the object is prepared to show.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal event EventHandler Shown;

        /// <summary>
        /// Occurs whenever the window is hidden.
        /// </summary>
        /// <remarks>You have to call NotifyHideStatus() to notify that the object is prepared to hide.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal event EventHandler Hidden;

        private void OnShowNative(IntPtr handle, IntPtr userData)
        {
            Log.Debug(logTag, "OnShowNative()");
            Shown?.Invoke(this, EventArgs.Empty);
        }

        private void OnHideNative(IntPtr handle, IntPtr userdata)
        {
            Log.Debug(logTag, "OnHideNative()");
            Hidden?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Notifies that the object is prepared to show.
        /// </summary>
        /// <param name="extraData">The extra data.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void NotifyShowStatus(Bundle extraData)
        {
            Interop.FrameProvider.ErrorCode err = Interop.FrameProvider.NotifyShowStatus(handle, extraData.SafeBundleHandle);
            if (err != Interop.FrameProvider.ErrorCode.None)
            {
                throw FrameProviderErrorFactory.GetException(err, "Failed to notify show status");
            }
        }

        /// <summary>
        /// Notifies that the object is prepared to hide.
        /// </summary>
        /// <param name="extraData">The extra data.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void NotifyHideStatus(Bundle extraData)
        {
            Interop.FrameProvider.ErrorCode err = Interop.FrameProvider.NotifyHideStatus(handle, extraData.SafeBundleHandle);
            if (err != Interop.FrameProvider.ErrorCode.None)
            {
                throw FrameProviderErrorFactory.GetException(err, "Failed to notify hide status");
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                handle.Dispose();
                disposed = true;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
