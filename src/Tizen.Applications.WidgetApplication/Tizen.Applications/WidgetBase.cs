/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications
{
    /// <summary>
    /// The abstract class for widget instances.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class WidgetBase
    {
        internal IntPtr Handle;
        private const string LogTag = "Tizen.Applications.WidgetBase";

        /// <summary>
        /// Window object for this widget instance.
        /// It will be created after OnCreate method is invoked.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected Window Window;

        /// <summary>
        /// Delete type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum WidgetDestroyType
        {
            /// <summary>
            /// User deleted this widget from the viewer.
            /// </summary>
            Permanent = 0,

            /// <summary>
            /// Widget is deleted because of other reasons. (For example, widget process is terminated temporarily by the system)
            /// </summary>
            Temporary
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WidgetBase()
        {
        }

        /// <summary>
        /// ID for this widget instance.
        /// It will be created after OnCreate method is invoked.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Id { get; private set; }

        /// <summary>
        /// Sets the content information to the widget.
        /// </summary>
        /// <param name="info">The data set to save.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="NotSupportedException">Thrown when the API is not supported in this device.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of an unrecoverable error.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void SetContent(Bundle info)
        {
            Interop.Widget.ErrorCode err = Interop.Widget.SetContent(Handle, info.SafeBundleHandle);

            if (err != Interop.Widget.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to set content. Err = " + err);

                switch(err)
                {
                    case Interop.Widget.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid parameter of SetContent()");

                    case Interop.Widget.ErrorCode.NotSupported:
                        throw new NotSupportedException();

                    case Interop.Widget.ErrorCode.OutOfMemory:
                    case Interop.Widget.ErrorCode.Fault:
                        throw new InvalidOperationException();
                }

            }
        }

        /// <summary>
        /// Sends the title to the widget.
        /// </summary>
        /// <param name="title">When an accessibility mode is turned on, this string will be read.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="NotSupportedException">Thrown when the API is not supported in this device.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of an unrecoverable error.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void SetTitle(string title)
        {
            Interop.Widget.ErrorCode err = Interop.Widget.SetTitle(Handle, title);

            if (err != Interop.Widget.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to set title. Err = " + err);

                switch (err)
                {
                    case Interop.Widget.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid parameter of SetContent()");

                    case Interop.Widget.ErrorCode.NotSupported:
                        throw new NotSupportedException();

                    case Interop.Widget.ErrorCode.OutOfMemory:
                    case Interop.Widget.ErrorCode.Fault:
                        throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// Finishes the context for the widget instance.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the API is not supported in this device.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of an unrecoverable error.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Exit()
        {
            Interop.Widget.ErrorCode err = Interop.Widget.TerminateContext(Handle);

            if (err != Interop.Widget.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to terminate context. Err = " + err);

                switch (err)
                {
                    case Interop.Widget.ErrorCode.NotSupported:
                        throw new NotSupportedException();

                    case Interop.Widget.ErrorCode.InvalidParameter:
                    case Interop.Widget.ErrorCode.Fault:
                        throw new InvalidOperationException();
                }
            }
        }

        internal void Bind(IntPtr handle, string id)
        {
            Handle = handle;
            Id = id;
        }

        /// <summary>
        /// Overrides this method if want to handle the behavior when the widget instance is started.
        /// </summary>
        /// <param name="content">The data set for the previous status.</param>
        /// <param name="w">The pixel value for the widget width.</param>
        /// <param name="h">The pixel value for the widget height.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnCreate(Bundle content, int w, int h)
        {
            IntPtr win;

            Interop.Widget.GetWin(Handle, out win);
            Window = new WidgetWindow(win);
            Window.Resize(w, h);
            Window.Show();
        }

        /// <summary>
        /// Overrides this method if want to handle the behavior when the widget instance is destroyed.
        /// </summary>
        /// <param name="reason">The reason for destruction.</param>
        /// <param name="content">The data set to save.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnDestroy(WidgetDestroyType reason, Bundle content)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle the behavior when the widget instance is paused.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnPause()
        {
        }

        /// <summary>
        /// Overrides this method if want to handle the behavior when the widget instance is resumed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnResume()
        {
        }

        /// <summary>
        /// Overrides this method if want to handle the behavior when the widget instance is resized.
        /// </summary>
        /// <param name="w">Widget width.</param>
        /// <param name="h">Widget height.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnResize(int w, int h)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle the behavior when the widget instance is updated.
        /// </summary>
        /// <param name="content">The data set for updating this widget will be provided by the requester.</param>
        /// <param name="isForce">Although the widget is paused, if it is true, the widget can be updated.</param>
        /// <since_tizen> 3 </since_tizen>
        public virtual void OnUpdate(Bundle content, bool isForce)
        {
        }

    }
}
