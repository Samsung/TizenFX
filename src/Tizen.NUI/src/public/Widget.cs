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
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// Widget object should be created by WidgetApplication.
    /// </summary>
    public class Widget : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Widget(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicManualPINVOKE.Widget_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Widget obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// To make Widget instance be disposed.
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (_createCallback != null)
            {
                this.CreateSignal().Disconnect(_createCallback);
            }

            if (_pauseCallback != null)
            {
                this.PauseSignal().Disconnect(_pauseCallback);
            }

            if (_resizeCallback != null)
            {
                this.ResizeSignal().Disconnect(_resizeCallback);
            }

            if (_resumeCallback != null)
            {
                this.ResumeSignal().Disconnect(_resumeCallback);
            }

            if (_terminateCallback != null)
            {
                this.TerminateSignal().Disconnect(_terminateCallback);
            }

            if (_updateCallback != null)
            {
                this.UpdateSignal().Disconnect(_updateCallback);
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicManualPINVOKE.delete_Widget(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// This is the constructor for Widget.
        /// </summary>
        /// <param name="id">for widget instance</param>
        /// <since_tizen> 4 </since_tizen>
        public Widget(string id) : this(NDalicManualPINVOKE.Widget_New(id), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Widget(Widget widget) : this(NDalicManualPINVOKE.new_Widget__SWIG_1(Widget.getCPtr(widget)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Widget Assign(Widget widget)
        {
            Widget ret = new Widget(NDalicManualPINVOKE.Widget_Assign(swigCPtr, Widget.getCPtr(widget)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Event arguments that passed via KeyEvent signal.
        /// </summary>
        public class CreateEventArgs : EventArgs
        {
            /// <summary>
            /// widget id.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public string ID
            {
                get;
                set;
            }

            /// <summary>
            /// a bundle.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public SWIGTYPE_p_bundle Bundle
            {
                get;
                set;
            }

            /// <summary>
            /// window.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public Window Window
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void CreateCallbackType(string id, IntPtr bundle, IntPtr window);
        private CreateCallbackType _createCallback;
        private EventHandler<CreateEventArgs> _createEventHandler;

        /// <summary>
        /// Create event.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<CreateEventArgs> Create
        {
            add
            {
                if (_createEventHandler == null)
                {
                    _createCallback = OnCreate;
                    CreateSignal().Connect(_createCallback);
                }

                _createEventHandler += value;
            }

            remove
            {
                _createEventHandler -= value;

                if (_createEventHandler == null && CreateSignal().Empty() == false)
                {
                   CreateSignal().Disconnect(_createCallback);
                }
            }
        }

        private void OnCreate(string id, IntPtr bundle, IntPtr window)
        {
            CreateEventArgs e = new CreateEventArgs();

            e.ID = id;

            if (bundle != null)
            {
                e.Bundle = new SWIGTYPE_p_bundle(bundle, false);
            }
            if (window != null)
            {
                e.Window = new Window(window, false);
            }

            _createEventHandler?.Invoke(this, e);
        }

        internal WidgetCreateSignalType CreateSignal()
        {
            WidgetCreateSignalType ret = new WidgetCreateSignalType(NDalicManualPINVOKE.Widget_CreateSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Event arguments that passed via terminate event signal.
        /// </summary>
        public class TerminateEventArgs : EventArgs
        {
            /// <summary>
            /// widget id.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public string ID
            {
                get;
                set;
            }

            /// <summary>
            /// a bundle.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public SWIGTYPE_p_bundle Bundle
            {
                get;
                set;
            }

            /// <summary>
            /// widget terminate type.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public WidgetTerminateType WidgetTerminateType
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TerminateCallbackType(string id, IntPtr bundle, WidgetTerminateType widgetTerminateType);
        private TerminateCallbackType _terminateCallback;
        private EventHandler<TerminateEventArgs> _terminateEventHandler;

        /// <summary>
        /// Terminate event.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<TerminateEventArgs> Terminate
        {
            add
            {
                if (_terminateEventHandler == null)
                {
                    _terminateCallback = OnTerminate;
                    TerminateSignal().Connect(_terminateCallback);
                }

                _terminateEventHandler += value;
            }

            remove
            {
                _terminateEventHandler -= value;

                if (_terminateEventHandler == null && TerminateSignal().Empty() == false)
                {
                   TerminateSignal().Disconnect(_terminateCallback);
                }
            }
        }

        private void OnTerminate(string id, IntPtr bundle, WidgetTerminateType widgetTerminateType)
        {
            TerminateEventArgs e = new TerminateEventArgs();
            e.ID = id;

            if (bundle != null)
            {
                e.Bundle = new SWIGTYPE_p_bundle(bundle, false);
            }

            e.WidgetTerminateType = widgetTerminateType;
            _terminateEventHandler?.Invoke(this, e);
        }

        internal WidgetTerminateSignalType TerminateSignal()
        {
            WidgetTerminateSignalType ret = new WidgetTerminateSignalType(NDalicManualPINVOKE.Widget_TerminateSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Event arguments that passed via pause event signal.
        /// </summary>
        public class PauseEventArgs : EventArgs
        {
            /// <summary>
            /// widget id.
            /// </summary>
        /// <since_tizen> 4 </since_tizen>
            public string ID
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void PauseCallbackType(string id);
        private PauseCallbackType _pauseCallback;
        private EventHandler<PauseEventArgs> _pauseEventHandler;

        /// <summary>
        /// Pause event.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<PauseEventArgs> Pause
        {
            add
            {
                if (_pauseEventHandler == null)
                {
                    _pauseCallback = OnPause;
                    PauseSignal().Connect(_pauseCallback);
                }

                _pauseEventHandler += value;
            }

            remove
            {
                _pauseEventHandler -= value;

                if (_pauseEventHandler == null && PauseSignal().Empty() == false)
                {
                   PauseSignal().Disconnect(_pauseCallback);
                }
            }
        }

        private void OnPause(string id)
        {
            PauseEventArgs e = new PauseEventArgs();
            e.ID = id;

            _pauseEventHandler?.Invoke(this, e);
        }

        internal WidgetPauseSignalType PauseSignal()
        {
            WidgetPauseSignalType ret = new WidgetPauseSignalType(NDalicManualPINVOKE.Widget_PauseSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Event arguments that passed via pause event signal.
        /// </summary>
        public class ResumeEventArgs : EventArgs
        {
            /// <summary>
            /// widget id.
            /// </summary>
        /// <since_tizen> 4 </since_tizen>
            public string ID
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ResumeCallbackType(string id);
        private ResumeCallbackType _resumeCallback;
        private EventHandler<ResumeEventArgs> _resumeEventHandler;

        /// <summary>
        /// Resume event.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<ResumeEventArgs> Resume
        {
            add
            {
                if (_resumeEventHandler == null)
                {
                    _resumeCallback = OnResume;
                    ResumeSignal().Connect(_resumeCallback);
                }

                _resumeEventHandler += value;
            }

            remove
            {
                _resumeEventHandler -= value;

                if (_resumeEventHandler == null && ResumeSignal().Empty() == false)
                {
                   ResumeSignal().Disconnect(_resumeCallback);
                }
            }
        }

        private void OnResume(string id)
        {
            ResumeEventArgs e = new ResumeEventArgs();
            e.ID = id;

            _resumeEventHandler?.Invoke(this, e);
        }

        internal WidgetResumeSignalType ResumeSignal()
        {
            WidgetResumeSignalType ret = new WidgetResumeSignalType(NDalicManualPINVOKE.Widget_ResumeSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Event arguments that passed via resize signal.
        /// </summary>
        public class ResizeEventArgs : EventArgs
        {
            /// <summary>
            /// widget id.
            /// </summary>
        /// <since_tizen> 4 </since_tizen>
            public string ID
            {
                get;
                set;
            }

            /// <summary>
            /// window.
            /// </summary>
        /// <since_tizen> 4 </since_tizen>
            public Window Window
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ResizeCallbackType(string id, IntPtr window);
        private ResizeCallbackType _resizeCallback;
        private EventHandler<ResizeEventArgs> _resizeEventHandler;

        /// <summary>
        /// Resize event.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<ResizeEventArgs> Resize
        {
            add
            {
                if (_resizeEventHandler == null)
                {
                    _resizeCallback = OnResize;
                    ResizeSignal().Connect(_resizeCallback);
                }

                _resizeEventHandler += value;
            }

            remove
            {
                _resizeEventHandler -= value;

                if (_resizeEventHandler == null && ResizeSignal().Empty() == false)
                {
                   ResizeSignal().Disconnect(_resizeCallback);
                }
            }
        }

        private void OnResize(string id, IntPtr window)
        {
            ResizeEventArgs e = new ResizeEventArgs();
            e.ID = id;
            if (window != null)
            {
                e.Window = new Window(window, false);
            }

            _resizeEventHandler?.Invoke(this, e);
        }

        internal WidgetResizeSignalType ResizeSignal()
        {
            WidgetResizeSignalType ret = new WidgetResizeSignalType(NDalicManualPINVOKE.Widget_ResizeSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Event arguments that passed via update event signal.
        /// </summary>
        public class UpdateEventArgs : EventArgs
        {
            /// <summary>
            /// widget data.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public string ID
            {
                get;
                set;
            }

            /// <summary>
            /// A bundle.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public SWIGTYPE_p_bundle Bundle
            {
                get;
                set;
            }

            /// <summary>
            /// It means several steps.
            /// </summary>
            /// <remark>
            /// 0 -> no force
            /// 1 -> force but do something
            /// 2 -> force
            /// </remark>
            /// <since_tizen> 4 </since_tizen>
            public int Force
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void UpdateCallbackType(string id, IntPtr bundle, int force);
        private UpdateCallbackType _updateCallback;
        private EventHandler<UpdateEventArgs> _updateEventHandler;

        /// <summary>
        /// Update event.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<UpdateEventArgs> Update
        {
            add
            {
                if (_updateEventHandler == null)
                {
                    _updateCallback = OnUpdate;
                    UpdateSignal().Connect(_updateCallback);
                }

                _updateEventHandler += value;
            }

            remove
            {
                _updateEventHandler -= value;

                if (_updateEventHandler == null && UpdateSignal().Empty() == false)
                {
                   UpdateSignal().Disconnect(_updateCallback);
                }
            }
        }

        private void OnUpdate(string id, IntPtr bundle, int force)
        {
            UpdateEventArgs e = new UpdateEventArgs();
            e.ID = id;
            if (bundle != null)
            {
                e.Bundle = new SWIGTYPE_p_bundle(bundle, false);
            }
            e.Force = force;

            _updateEventHandler?.Invoke(this, e);
        }

        internal WidgetUpdateSignalType UpdateSignal()
        {
            WidgetUpdateSignalType ret = new WidgetUpdateSignalType(NDalicManualPINVOKE.Widget_UpdateSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Enumeration for terminate type of widget instance.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum WidgetTerminateType
        {
            /// <summary>
            /// User deleted this widget from the viewer
            /// </summary>
            Permanent,
            /// <summary>
            /// Widget is deleted because of other reasons (e.g. widget process is terminated temporarily by the system)
            /// </summary>
            Temporary
        }

        /// <summary>
        /// Enumeration for lifecycle event type of widget instance.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum WidgetLifecycleEventType
        {
            /// <summary>
            /// The widget is dead.
            /// </summary>
            AppDead = 0,
            /// <summary>
            /// The widget is dead.
            /// </summary>
            Create = 1,
            /// <summary>
            /// The widget is destroyed.
            /// </summary>
            Destroy = 2,
            /// <summary>
            /// The widget is paused.
            /// </summary>
            Pause = 3,
            /// <summary>
            /// The widget is resumed.
            /// </summary>
            Resume = 4
        }
    }
}
