/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// Widget provides some common functionality required by all custom widget.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class Widget : BaseHandle
    {
        internal WidgetImpl widgetImpl;
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        /// <summary>
        /// Creates a Widget handle.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Widget() : this(new WidgetImpl(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Widget(WidgetImpl widgetImpl, bool swigCMemOwn) : this(Interop.Widget.Widget_New__SWIG_1(WidgetImpl.getCPtr(widgetImpl)), swigCMemOwn)
        {
            this.widgetImpl = widgetImpl;
            widgetImpl.WidgetInstanceCreated += OnWidgetInstanceCreated;
            widgetImpl.WidgetInstanceDestroyed += OnWidgetInstanceDestroyed;
            widgetImpl.WidgetInstancePaused += OnWidgetInstancePaused;
            widgetImpl.WidgetInstanceResumed += OnWidgetInstanceResumed;
            widgetImpl.WidgetInstanceResized += OnWidgetInstanceResized;
            widgetImpl.WidgetInstanceUpdated += OnWidgetInstanceUpdated;

            WidgetApplication.Instance?.AddWidgetInstance(this);
        }

        internal Widget(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Widget.Widget_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Enumeration for termination type of widget
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum TerminationType
        {
            /// <summary>
            /// User deleted this widget from the viewer
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Permanent,
            /// <summary>
            /// Widget is deleted because of other reasons (e.g. widget process is terminated temporarily by system)
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Temporary
        }

        /// <summary>
        /// Set content info to WidgetView.
        /// </summary>
        /// <param name="contentInfo">Content info is kind of context information which contains current status of widget.</param>
        /// <since_tizen> 4 </since_tizen>
        public void SetContentInfo(string contentInfo)
        {
            widgetImpl.SetContentInfo(contentInfo);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Widget obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal System.IntPtr GetIntPtr()
        {
            return swigCPtr.Handle;
        }
        internal Widget Assign(Widget widget)
        {
            Widget ret = new Widget(Interop.Widget.Widget_Assign(swigCPtr, Widget.getCPtr(widget)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The user should override this function to determine when they create widget.
        /// </summary>
        /// <param name="contentInfo">Information from WidgetView for creating. It contains previous status of widget which is sent by SetContentInfo before.</param>
        /// <param name="window">Window for widget</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void OnCreate(string contentInfo, Window window)
        {
        }

        /// <summary>
        /// The user should override this function to determine when they terminate widget.
        /// </summary>
        /// <param name="contentInfo">Data from WidgetView for deleting</param>
        /// <param name="type">Termination type. When user delete widget view, termination type is PERMANENT.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void OnTerminate(string contentInfo, Widget.TerminationType type)
        {
        }

        /// <summary>
        /// The user should override this function to determine when they pause widget.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void OnPause()
        {
        }

        /// <summary>
        /// The user should override this function to determine when they resume widget.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void OnResume()
        {
        }

        /// <summary>
        /// The user should override this function to determine when they resize widget.
        /// </summary>
        /// <param name="window">Window for widget</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void OnResize(Window window)
        {
        }

        /// <summary>
        /// The user should override this function to determine when they update widget.
        /// </summary>
        /// <param name="contentInfo">Data from WidgetView for updating</param>
        /// <param name="force">Although the widget is paused, if it is true, the widget can be updated</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void OnUpdate(string contentInfo, int force)
        {
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="type">The dispose type</param>
        /// <since_tizen> 4 </since_tizen>
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

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.Widget.delete_Widget(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        private void OnWidgetInstanceCreated(object sender, WidgetImpl.WIdgetInstanceOnCreateArgs e)
        {
            OnCreate(e.ContentInfo, e.Window);
        }

        private void OnWidgetInstanceDestroyed(object sender, WidgetImpl.WIdgetInstanceOnDestroyArgs e)
        {
            OnTerminate(e.ContentInfo, e.TerminateType);
        }

        private void OnWidgetInstancePaused(object sender, EventArgs e)
        {
            OnPause();
        }

        private void OnWidgetInstanceResumed(object sender, EventArgs e)
        {
            OnResume();
        }

        private void OnWidgetInstanceResized(object sender, WidgetImpl.WidgetInstanceOnResizeArgs e)
        {
            OnResize(e.Window);
        }

        private void OnWidgetInstanceUpdated(object sender, WidgetImpl.WidgetInstanceOnUpdateArgs e)
        {
            OnUpdate(e.ContentInfo, e.Force);
        }
    }
}
