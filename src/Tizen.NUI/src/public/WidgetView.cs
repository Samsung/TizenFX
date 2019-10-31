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

namespace Tizen.NUI
{
    using System;
    using System.Runtime.InteropServices;
    using Tizen.NUI.BaseComponents;

    /// <summary>
    /// The WidgetView is a class for displaying the widget image and controlling the widget.<br />
    /// Input events that the WidgetView gets are delivered to the widget.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class WidgetView : View
    {
        private EventHandler<WidgetViewEventArgs> _widgetAddedEventHandler;
        private WidgetAddedEventCallbackType _widgetAddedEventCallback;
        private EventHandler<WidgetViewEventArgs> _widgetContentUpdatedEventHandler;
        private WidgetContentUpdatedEventCallbackType _widgetContentUpdatedEventCallback;
        private EventHandler<WidgetViewEventArgs> _widgetDeletedEventHandler;
        private WidgetDeletedEventCallbackType _widgetDeletedEventCallback;
        private EventHandler<WidgetViewEventArgs> _widgetCreationAbortedEventHandler;
        private WidgetCreationAbortedEventCallbackType _widgetCreationAbortedEventCallback;
        private EventHandler<WidgetViewEventArgs> _widgetUpdatePeriodChangedEventHandler;
        private WidgetUpdatePeriodChangedEventCallbackType _widgetUpdatePeriodChangedEventCallback;
        private EventHandler<WidgetViewEventArgs> _widgetFaultedEventHandler;
        private WidgetFaultedEventCallbackType _widgetFaultedEventCallback;
        /// <summary>
        /// Creates a new WidgetView.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WidgetView(string widgetId, string contentInfo, int width, int height, float updatePeriod) : this(Interop.WidgetView.WidgetView_New(widgetId, contentInfo, width, height, updatePeriod), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal WidgetView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.WidgetView.WidgetView_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }
        internal WidgetView(WidgetView handle) : this(Interop.WidgetView.new_WidgetView__SWIG_1(WidgetView.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WidgetAddedEventCallbackType(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WidgetContentUpdatedEventCallbackType(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WidgetDeletedEventCallbackType(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WidgetCreationAbortedEventCallbackType(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WidgetUpdatePeriodChangedEventCallbackType(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WidgetFaultedEventCallbackType(IntPtr data);

        /// <summary>
        /// An event for the ResourceReady signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted after all resources required by a control are loaded and ready.<br />
        /// Most resources are only loaded when the control is placed on the stage.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WidgetViewEventArgs> WidgetAdded
        {
            add
            {
                if (_widgetAddedEventHandler == null)
                {
                    _widgetAddedEventCallback = OnWidgetAdded;
                    WidgetAddedSignal().Connect(_widgetAddedEventCallback);
                }

                _widgetAddedEventHandler += value;
            }

            remove
            {
                _widgetAddedEventHandler -= value;

                if (_widgetAddedEventHandler == null && WidgetAddedSignal().Empty() == false)
                {
                    WidgetAddedSignal().Disconnect(_widgetAddedEventCallback);
                }
            }
        }

        /// <summary>
        /// An event for the ResourceReady signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted after all resources required by a control are loaded and ready.<br />
        /// Most resources are only loaded when the control is placed on the stage.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WidgetViewEventArgs> WidgetContentUpdated
        {
            add
            {
                if (_widgetContentUpdatedEventHandler == null)
                {
                    _widgetContentUpdatedEventCallback = OnWidgetContentUpdated;
                    WidgetContentUpdatedSignal().Connect(_widgetContentUpdatedEventCallback);
                }

                _widgetContentUpdatedEventHandler += value;
            }

            remove
            {
                _widgetContentUpdatedEventHandler -= value;

                if (_widgetContentUpdatedEventHandler == null && WidgetContentUpdatedSignal().Empty() == false)
                {
                    WidgetContentUpdatedSignal().Disconnect(_widgetContentUpdatedEventCallback);
                }
            }
        }

        /// <summary>
        /// An event for the ResourceReady signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted after all resources required by a control are loaded and ready.<br />
        /// Most resources are only loaded when the control is placed on the stage.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WidgetViewEventArgs> WidgetDeleted
        {
            add
            {
                if (_widgetDeletedEventHandler == null)
                {
                    _widgetDeletedEventCallback = OnWidgetDeleted;
                    WidgetDeletedSignal().Connect(_widgetDeletedEventCallback);
                }

                _widgetDeletedEventHandler += value;
            }

            remove
            {
                _widgetDeletedEventHandler -= value;

                if (_widgetDeletedEventHandler == null && WidgetDeletedSignal().Empty() == false)
                {
                    WidgetDeletedSignal().Disconnect(_widgetDeletedEventCallback);
                }
            }
        }

        /// <summary>
        /// An event for the ResourceReady signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted after all resources required by a control are loaded and ready.<br />
        /// Most resources are only loaded when the control is placed on the stage.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WidgetViewEventArgs> WidgetCreationAborted
        {
            add
            {
                if (_widgetCreationAbortedEventHandler == null)
                {
                    _widgetCreationAbortedEventCallback = OnWidgetCreationAborted;
                    WidgetCreationAbortedSignal().Connect(_widgetCreationAbortedEventCallback);
                }

                _widgetCreationAbortedEventHandler += value;
            }

            remove
            {
                _widgetCreationAbortedEventHandler -= value;

                if (_widgetCreationAbortedEventHandler == null && WidgetCreationAbortedSignal().Empty() == false)
                {
                    WidgetCreationAbortedSignal().Disconnect(_widgetCreationAbortedEventCallback);
                }
            }
        }

        /// <summary>
        /// An event for the ResourceReady signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted after all resources required by a control are loaded and ready.<br />
        /// Most resources are only loaded when the control is placed on the stage.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WidgetViewEventArgs> WidgetUpdatePeriodChanged
        {
            add
            {
                if (_widgetUpdatePeriodChangedEventHandler == null)
                {
                    _widgetUpdatePeriodChangedEventCallback = OnWidgetUpdatePeriodChanged;
                    WidgetUpdatePeriodChangedSignal().Connect(_widgetUpdatePeriodChangedEventCallback);
                }

                _widgetUpdatePeriodChangedEventHandler += value;
            }

            remove
            {
                _widgetUpdatePeriodChangedEventHandler -= value;

                if (_widgetUpdatePeriodChangedEventHandler == null && WidgetUpdatePeriodChangedSignal().Empty() == false)
                {
                    WidgetUpdatePeriodChangedSignal().Disconnect(_widgetUpdatePeriodChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// An event for the ResourceReady signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted after all resources required by a control are loaded and ready.<br />
        /// Most resources are only loaded when the control is placed on the stage.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WidgetViewEventArgs> WidgetFaulted
        {
            add
            {
                if (_widgetFaultedEventHandler == null)
                {
                    _widgetFaultedEventCallback = OnWidgetFaulted;
                    WidgetFaultedSignal().Connect(_widgetFaultedEventCallback);
                }

                _widgetFaultedEventHandler += value;
            }

            remove
            {
                _widgetFaultedEventHandler -= value;

                if (_widgetFaultedEventHandler == null && WidgetFaultedSignal().Empty() == false)
                {
                    WidgetFaultedSignal().Disconnect(_widgetFaultedEventCallback);
                }
            }
        }

        /// <summary>
        /// Gets the ID of the widget.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string WidgetID
        {
            get
            {
                string temp;
                GetProperty(WidgetView.Property.WIDGET_ID).Get(out temp);
                return temp;
            }
        }

        /// <summary>
        /// Gets the ID of the instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InstanceID
        {
            get
            {
                string temp;
                GetProperty(WidgetView.Property.INSTANCE_ID).Get(out temp);
                return temp;
            }
        }

        /// <summary>
        /// Gets the content info.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ContentInfo
        {
            get
            {
                string temp;
                GetProperty(WidgetView.Property.CONTENT_INFO).Get(out temp);
                return temp;
            }
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Title
        {
            get
            {
                string temp;
                GetProperty(WidgetView.Property.TITLE).Get(out temp);
                return temp;
            }
        }

        /// <summary>
        /// Gets the update peroid.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float UpdatePeriod
        {
            get
            {
                float temp;
                GetProperty(WidgetView.Property.UPDATE_PERIOD).Get(out temp);
                return temp;
            }
        }

        /// <summary>
        /// Gets or sets the preview.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Preview
        {
            get
            {
                bool temp;
                GetProperty(WidgetView.Property.PREVIEW).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(WidgetView.Property.PREVIEW, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets or sets the loading text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool LoadingText
        {
            get
            {
                bool temp;
                GetProperty(WidgetView.Property.LOADING_TEXT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(WidgetView.Property.LOADING_TEXT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets or sets whether the widget state is faulted or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool WidgetStateFaulted
        {
            get
            {
                bool temp;
                GetProperty(WidgetView.Property.WIDGET_STATE_FAULTED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(WidgetView.Property.WIDGET_STATE_FAULTED, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets or sets whether the widget is to delete permanently or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool PermanentDelete
        {
            get
            {
                bool temp;
                GetProperty(WidgetView.Property.PERMANENT_DELETE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(WidgetView.Property.PERMANENT_DELETE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets or sets retry text.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public PropertyMap RetryText
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(WidgetView.Property.RETRY_TEXT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(WidgetView.Property.RETRY_TEXT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets or sets effect.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public PropertyMap Effect
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(WidgetView.Property.EFFECT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(WidgetView.Property.EFFECT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Pauses a given widget.
        /// </summary>
        /// <returns>True on success, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool PauseWidget()
        {
            bool ret = Interop.WidgetView.WidgetView_PauseWidget(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Resumes a given widget.
        /// </summary>
        /// <returns>True on success, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool ResumeWidget()
        {
            bool ret = Interop.WidgetView.WidgetView_ResumeWidget(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Cancels the touch event procedure.
        /// If you call this function after feed the touch down event, the widget will get ON_HOLD events.
        ///  If a widget gets ON_HOLD event, it will not do anything even if you feed touch up event.
        /// </summary>
        /// <returns>True on success, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool CancelTouchEvent()
        {
            bool ret = Interop.WidgetView.WidgetView_CancelTouchEvent(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Activates a widget in the faulted state.
        /// A widget in faulted state must be activated before adding the widget.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void ActivateFaultedWidget()
        {
            Interop.WidgetView.WidgetView_ActivateFaultedWidget(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Terminate a widget instance.
        /// </summary>
        /// <returns>True on success, false otherwise</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool TerminateWidget()
        {
            bool ret = Interop.WidgetView.WidgetView_TerminateWidget(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static WidgetView DownCast(BaseHandle handle)
        {
            WidgetView ret = new WidgetView(Interop.WidgetView.WidgetView_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static WidgetView GetWidgetViewFromPtr(global::System.IntPtr cPtr)
        {
            WidgetView ret = new WidgetView(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WidgetView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal WidgetView Assign(WidgetView handle)
        {
            WidgetView ret = new WidgetView(Interop.WidgetView.WidgetView_Assign(swigCPtr, WidgetView.getCPtr(handle)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetViewSignal WidgetAddedSignal()
        {
            WidgetViewSignal ret = new WidgetViewSignal(Interop.WidgetView.WidgetView_WidgetAddedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetViewSignal WidgetDeletedSignal()
        {
            WidgetViewSignal ret = new WidgetViewSignal(Interop.WidgetView.WidgetView_WidgetDeletedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetViewSignal WidgetCreationAbortedSignal()
        {
            WidgetViewSignal ret = new WidgetViewSignal(Interop.WidgetView.WidgetView_WidgetCreationAbortedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetViewSignal WidgetContentUpdatedSignal()
        {
            WidgetViewSignal ret = new WidgetViewSignal(Interop.WidgetView.WidgetView_WidgetContentUpdatedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetViewSignal WidgetUpdatePeriodChangedSignal()
        {
            WidgetViewSignal ret = new WidgetViewSignal(Interop.WidgetView.WidgetView_WidgetUpdatePeriodChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetViewSignal WidgetFaultedSignal()
        {
            WidgetViewSignal ret = new WidgetViewSignal(Interop.WidgetView.WidgetView_WidgetFaultedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To make the Button instance be disposed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (_widgetAddedEventCallback != null)
            {
                this.WidgetAddedSignal().Disconnect(_widgetAddedEventCallback);
            }

            if (_widgetContentUpdatedEventCallback != null)
            {
                this.WidgetContentUpdatedSignal().Disconnect(_widgetContentUpdatedEventCallback);
            }

            if (_widgetCreationAbortedEventCallback != null)
            {
                this.WidgetCreationAbortedSignal().Disconnect(_widgetCreationAbortedEventCallback);
            }

            if (_widgetDeletedEventCallback != null)
            {
                this.WidgetDeletedSignal().Disconnect(_widgetDeletedEventCallback);
            }

            if (_widgetFaultedEventCallback != null)
            {
                this.WidgetFaultedSignal().Disconnect(_widgetFaultedEventCallback);
            }

            if (_widgetUpdatePeriodChangedEventCallback != null)
            {
                this.WidgetUpdatePeriodChangedSignal().Disconnect(_widgetUpdatePeriodChangedEventCallback);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WidgetView.delete_WidgetView(swigCPtr);
        }

        // Callback for WidgetView WidgetAdded signal
        private void OnWidgetAdded(IntPtr data)
        {
            WidgetViewEventArgs e = new WidgetViewEventArgs();
            if(data != null)
            {
                e.WidgetView = WidgetView.GetWidgetViewFromPtr(data);
            }

            if (_widgetAddedEventHandler != null)
            {
                _widgetAddedEventHandler(this, e);
            }
        }

        // Callback for WidgetView WidgetDeleted signal
        private void OnWidgetDeleted(IntPtr data)
        {
            WidgetViewEventArgs e = new WidgetViewEventArgs();
            if (data != null)
            {
                e.WidgetView = WidgetView.GetWidgetViewFromPtr(data);
            }

            if (_widgetDeletedEventHandler != null)
            {
                _widgetDeletedEventHandler(this, e);
            }
        }

        // Callback for WidgetView WidgetCreationAborted signal
        private void OnWidgetCreationAborted(IntPtr data)
        {
            WidgetViewEventArgs e = new WidgetViewEventArgs();
            if (data != null)
            {
                e.WidgetView = WidgetView.GetWidgetViewFromPtr(data);
            }

            if (_widgetCreationAbortedEventHandler != null)
            {
                _widgetCreationAbortedEventHandler(this, e);
            }
        }



        // Callback for WidgetView WidgetContentUpdated signal
        private void OnWidgetContentUpdated(IntPtr data)
        {
            WidgetViewEventArgs e = new WidgetViewEventArgs();
            if (data != null)
            {
                e.WidgetView = WidgetView.GetWidgetViewFromPtr(data);
            }

            if (_widgetContentUpdatedEventHandler != null)
            {
                _widgetContentUpdatedEventHandler(this, e);
            }
        }

        // Callback for WidgetView WidgetUpdatePeriodChanged signal
        private void OnWidgetUpdatePeriodChanged(IntPtr data)
        {
            WidgetViewEventArgs e = new WidgetViewEventArgs();
            if (data != null)
            {
                e.WidgetView = WidgetView.GetWidgetViewFromPtr(data);
            }

            if (_widgetUpdatePeriodChangedEventHandler != null)
            {
                _widgetUpdatePeriodChangedEventHandler(this, e);
            }
        }

        // Callback for WidgetView WidgetFaulted signal
        private void OnWidgetFaulted(IntPtr data)
        {
            WidgetViewEventArgs e = new WidgetViewEventArgs();
            if(data != null)
            {
                e.WidgetView = WidgetView.GetWidgetViewFromPtr(data);
            }

            if (_widgetFaultedEventHandler != null)
            {
                _widgetFaultedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Event arguments of the widget view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class WidgetViewEventArgs : EventArgs
        {
            private WidgetView _widgetView;

            /// <summary>
            /// The widet view.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public WidgetView WidgetView
            {
                get
                {
                    return _widgetView;
                }
                set
                {
                    _widgetView = value;
                }
            }
        }

        internal new class Property
        {
            internal static readonly int WIDGET_ID = Interop.WidgetView.WidgetView_Property_WIDGET_ID_get();
            internal static readonly int INSTANCE_ID = Interop.WidgetView.WidgetView_Property_INSTANCE_ID_get();
            internal static readonly int CONTENT_INFO = Interop.WidgetView.WidgetView_Property_CONTENT_INFO_get();
            internal static readonly int TITLE = Interop.WidgetView.WidgetView_Property_TITLE_get();
            internal static readonly int UPDATE_PERIOD = Interop.WidgetView.WidgetView_Property_UPDATE_PERIOD_get();
            internal static readonly int PREVIEW = Interop.WidgetView.WidgetView_Property_PREVIEW_get();
            internal static readonly int LOADING_TEXT = Interop.WidgetView.WidgetView_Property_LOADING_TEXT_get();
            internal static readonly int WIDGET_STATE_FAULTED = Interop.WidgetView.WidgetView_Property_WIDGET_STATE_FAULTED_get();
            internal static readonly int PERMANENT_DELETE = Interop.WidgetView.WidgetView_Property_PERMANENT_DELETE_get();
            internal static readonly int RETRY_TEXT = Interop.WidgetView.WidgetView_Property_RETRY_TEXT_get();
            internal static readonly int EFFECT = Interop.WidgetView.WidgetView_Property_EFFECT_get();
        }
    }

}
