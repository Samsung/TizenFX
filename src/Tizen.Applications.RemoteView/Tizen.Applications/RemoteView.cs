/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using ElmSharp;
using System;
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the proxy class for the widget application.
    /// </summary>
    public class RemoteView
    {
        /// <summary>
        /// The event types to send.
        /// </summary>
        public enum Event
        {
            /// <summary>
            /// Type for feeding the mouse-up event to the widget application.
            /// </summary>
            FeedMouseUp,

            /// <summary>
            /// Type for canceling the click event procedure.
            /// </summary>
            CancelClick
        }

        /// <summary>
        /// Layout object including preview image, overlay text, loading text, and remote screen image.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        public Layout Layout { get; internal set; }

        /// <summary>
        /// The widget ID.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        public string Id
        {
            get
            {
                IntPtr ptr = Interop.WidgetViewerEvas.GetWidgetId(Layout);

                return Marshal.PtrToStringAnsi(ptr);
            }
        }

        /// <summary>
        /// The update period.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        public double Period
        {
            get
            {
                return Interop.WidgetViewerEvas.GetPeriod(Layout);
            }
        }

        /// <summary>
        /// Contents of the widget.
        /// </summary>
        /// <remarks>
        /// This string can be used for creating contents of the widget again after rebooting a device or it can be recovered from a crash (abnormal status).
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        public string Content
        {
            get
            {
                IntPtr ptr = Interop.WidgetViewerEvas.GetContentInfo(Layout);

                return Marshal.PtrToStringAnsi(ptr);
            }
        }

        /// <summary>
        /// Summarized string of the widget content for accessibility.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        public string Title
        {
            get
            {
                IntPtr ptr = Interop.WidgetViewerEvas.GetTitleString(Layout);

                return Marshal.PtrToStringAnsi(ptr);
            }
        }

        internal RemoteView()
        {
        }

        internal static void CheckException(Interop.WidgetViewerEvas.ErrorCode err)
        {
            switch (err)
            {
                case Interop.WidgetViewerEvas.ErrorCode.Fault:
                    throw new InvalidOperationException("Fault at unmanaged code");

                case Interop.WidgetViewerEvas.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();

                case Interop.WidgetViewerEvas.ErrorCode.NotSupported:
                    throw new NotSupportedException();

                case Interop.WidgetViewerEvas.ErrorCode.InvalidParameter:
                    throw new InvalidOperationException("Invalid parameter error at unmanaged code");

                case Interop.WidgetViewerEvas.ErrorCode.AlreadyExist:
                    throw new InvalidOperationException("Already exist");

                case Interop.WidgetViewerEvas.ErrorCode.MaxExceeded:
                    throw new InvalidOperationException("Max exceeded");
            }
        }

        /// <summary>
        /// Pauses all the connected widget applications.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        /// <exception cref="InvalidOperationException">Thrown when this operation failed.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when this operation is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when this operation is not supported for this device.</exception>
        public static void PauseAll()
        {
            CheckException(Interop.WidgetViewerEvas.NotifyPausedStatusOfViewer());
        }

        /// <summary>
        /// Resumes all the connected widget applications.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        /// <exception cref="InvalidOperationException">Thrown when this operation failed.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when this operation is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when this operation is not supported for this device<./exception>
        public static void ResumeAll()
        {
            CheckException(Interop.WidgetViewerEvas.NotifyResumedStatusOfViewer());
        }

        /// <summary>
        /// Pauses the widget application which is connected on this proxy.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        /// <exception cref="InvalidOperationException">Thrown when this operation failed.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when this operation is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when this operation is not supported for this device.</exception>
        public void Pause()
        {
            CheckException(Interop.WidgetViewerEvas.PauseWidget(Layout));
        }

        /// <summary>
        /// Resumes the widget application which is connected on this proxy.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        /// <exception cref="InvalidOperationException">Thrown when this operation failed.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when this operation is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when this operation is not supported for this device.</exception>
        public void Resume()
        {
            CheckException(Interop.WidgetViewerEvas.ResumeWidget(Layout));
        }

        /// <summary>
        /// Sends the event to the widget application which is connected on this proxy.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/widget.viewer</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown when this operation is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when this operation is not supported for this device.</exception>
        public void SendEvent(Event ev)
        {
            switch (ev)
            {
                case Event.FeedMouseUp:
                    Interop.WidgetViewerEvas.FeedMouseUpEvent(Layout);
                    break;

                case Event.CancelClick:
                    Interop.WidgetViewerEvas.CancelClickEvent(Layout);
                    break;

                default:
                    throw new NotSupportedException("Not supported event type");
            }

            int err = Internals.Errors.ErrorFacts.GetLastResult();
            CheckException((Interop.WidgetViewerEvas.ErrorCode)err);
        }

        internal void HideLoadingMessage()
        {
            Interop.WidgetViewerEvas.DisableLoading(Layout);
            int err = Internals.Errors.ErrorFacts.GetLastResult();
            CheckException((Interop.WidgetViewerEvas.ErrorCode)err);
        }

        internal void HidePreviewImage()
        {
            Interop.WidgetViewerEvas.DisablePreview(Layout);
            int err = Internals.Errors.ErrorFacts.GetLastResult();
            CheckException((Interop.WidgetViewerEvas.ErrorCode)err);
        }

        internal void HideOverlayText()
        {
            Interop.WidgetViewerEvas.DisableOverlayText(Layout);
            int err = Internals.Errors.ErrorFacts.GetLastResult();
            CheckException((Interop.WidgetViewerEvas.ErrorCode)err);
        }

    }
}
