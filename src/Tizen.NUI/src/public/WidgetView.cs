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
using System.ComponentModel;

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
        public WidgetView(string widgetId, string contentInfo, int width, int height, float updatePeriod) : this(Interop.WidgetView.New(widgetId, contentInfo, width, height, updatePeriod), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal WidgetView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.WidgetView.Upcast(cPtr), cMemoryOwn)
        {
        }
        internal WidgetView(WidgetView handle) : this(Interop.WidgetView.NewWidgetView(WidgetView.getCPtr(handle)), true)
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
                    WidgetViewSignal widgetAdded = WidgetAddedSignal();
                    widgetAdded?.Connect(_widgetAddedEventCallback);
                    widgetAdded?.Dispose();
                }

                _widgetAddedEventHandler += value;
            }

            remove
            {
                _widgetAddedEventHandler -= value;

                WidgetViewSignal widgetAdded = WidgetAddedSignal();
                if (_widgetAddedEventHandler == null && widgetAdded?.Empty() == false)
                {
                    widgetAdded?.Disconnect(_widgetAddedEventCallback);
                }
                widgetAdded?.Dispose();
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
                    WidgetViewSignal widgetContentUpdated = WidgetContentUpdatedSignal();
                    widgetContentUpdated?.Connect(_widgetContentUpdatedEventCallback);
                    widgetContentUpdated?.Dispose();
                }

                _widgetContentUpdatedEventHandler += value;
            }

            remove
            {
                _widgetContentUpdatedEventHandler -= value;

                WidgetViewSignal widgetContentUpdated = WidgetContentUpdatedSignal();
                if (_widgetContentUpdatedEventHandler == null && widgetContentUpdated?.Empty() == false)
                {
                    widgetContentUpdated?.Disconnect(_widgetContentUpdatedEventCallback);
                }
                widgetContentUpdated?.Dispose();
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
                    WidgetViewSignal widgetDeleted = WidgetDeletedSignal();
                    widgetDeleted?.Connect(_widgetDeletedEventCallback);
                    widgetDeleted?.Dispose();
                }

                _widgetDeletedEventHandler += value;
            }

            remove
            {
                _widgetDeletedEventHandler -= value;

                WidgetViewSignal widgetDeleted = WidgetDeletedSignal();
                if (_widgetDeletedEventHandler == null && widgetDeleted?.Empty() == false)
                {
                    widgetDeleted?.Disconnect(_widgetDeletedEventCallback);
                }
                widgetDeleted?.Dispose();
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
                    WidgetViewSignal widgetCreationAborted = WidgetCreationAbortedSignal();
                    widgetCreationAborted?.Connect(_widgetCreationAbortedEventCallback);
                    widgetCreationAborted?.Dispose();
                }

                _widgetCreationAbortedEventHandler += value;
            }

            remove
            {
                _widgetCreationAbortedEventHandler -= value;

                WidgetViewSignal widgetCreationAborted = WidgetCreationAbortedSignal();
                if (_widgetCreationAbortedEventHandler == null && widgetCreationAborted?.Empty() == false)
                {
                    widgetCreationAborted?.Disconnect(_widgetCreationAbortedEventCallback);
                }
                widgetCreationAborted?.Dispose();
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
                    WidgetViewSignal widgetUpdatePeriodChanged = WidgetUpdatePeriodChangedSignal();
                    widgetUpdatePeriodChanged?.Connect(_widgetUpdatePeriodChangedEventCallback);
                    widgetUpdatePeriodChanged?.Dispose();
                }

                _widgetUpdatePeriodChangedEventHandler += value;
            }

            remove
            {
                _widgetUpdatePeriodChangedEventHandler -= value;

                WidgetViewSignal widgetUpdatePeriodChanged = WidgetUpdatePeriodChangedSignal();
                if (_widgetUpdatePeriodChangedEventHandler == null && widgetUpdatePeriodChanged?.Empty() == false)
                {
                    widgetUpdatePeriodChanged?.Disconnect(_widgetUpdatePeriodChangedEventCallback);
                }
                widgetUpdatePeriodChanged?.Dispose();
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
                    WidgetViewSignal widgetFaulted = WidgetFaultedSignal();
                    widgetFaulted?.Connect(_widgetFaultedEventCallback);
                    widgetFaulted?.Dispose();
                }

                _widgetFaultedEventHandler += value;
            }

            remove
            {
                _widgetFaultedEventHandler -= value;

                WidgetViewSignal widgetFaulted = WidgetFaultedSignal();
                if (_widgetFaultedEventHandler == null && widgetFaulted?.Empty() == false)
                {
                    widgetFaulted?.Disconnect(_widgetFaultedEventCallback);
                }
                widgetFaulted?.Dispose();
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
                string retValue = "";
                PropertyValue widgetId = GetProperty(WidgetView.Property.WidgetId);
                widgetId?.Get(out retValue);
                widgetId?.Dispose();
                return retValue;
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
                string retValue = "";
                PropertyValue instanceId = GetProperty(WidgetView.Property.InstanceId);
                instanceId?.Get(out retValue);
                instanceId?.Dispose();
                return retValue;
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
                string retValue = "";
                PropertyValue contentInfo = GetProperty(WidgetView.Property.ContentInfo);
                contentInfo?.Get(out retValue);
                contentInfo?.Dispose();
                return retValue;
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
                string retValue = "";
                PropertyValue title = GetProperty(WidgetView.Property.TITLE);
                title?.Get(out retValue);
                title?.Dispose();
                return retValue;
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
                float retValue = 0;
                PropertyValue updatePeriod = GetProperty(WidgetView.Property.UpdatePeriod);
                updatePeriod?.Get(out retValue);
                updatePeriod?.Dispose();
                return retValue;
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
                bool retValue = false;
                PropertyValue preview = GetProperty(WidgetView.Property.PREVIEW);
                preview?.Get(out retValue);
                preview?.Dispose();
                return retValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(WidgetView.Property.PREVIEW, setValue);
                setValue?.Dispose();
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
                bool retValue = false;
                PropertyValue loadingText = GetProperty(WidgetView.Property.LoadingText);
                loadingText?.Get(out retValue);
                loadingText?.Dispose();
                return retValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(WidgetView.Property.LoadingText, setValue);
                setValue?.Dispose();
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
                bool retValue = false;
                PropertyValue widgetStateFaulted = GetProperty(WidgetView.Property.WidgetStateFaulted);
                widgetStateFaulted?.Get(out retValue);
                widgetStateFaulted?.Dispose();
                return retValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(WidgetView.Property.WidgetStateFaulted, setValue);
                setValue?.Dispose();
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
                bool retValue = false;
                PropertyValue permanentDelete = GetProperty(WidgetView.Property.PermanentDelete);
                permanentDelete?.Get(out retValue);
                permanentDelete?.Dispose();
                return retValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(WidgetView.Property.PermanentDelete, setValue);
                setValue.Dispose();
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
                PropertyMap retValue = new PropertyMap();
                PropertyValue retryText = GetProperty(WidgetView.Property.RetryText);
                retryText?.Get(retValue);
                retryText?.Dispose();
                return retValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(WidgetView.Property.RetryText, setValue);
                setValue?.Dispose();
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
                PropertyMap retValue = new PropertyMap();
                PropertyValue effect = GetProperty(WidgetView.Property.EFFECT);
                effect?.Get(retValue);
                effect?.Dispose();
                return retValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(WidgetView.Property.EFFECT, setValue);
                setValue?.Dispose();
            }
        }

        /// <summary>
        /// Pauses a given widget.
        /// </summary>
        /// <returns>True on success, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool PauseWidget()
        {
            bool ret = Interop.WidgetView.PauseWidget(SwigCPtr);
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
            bool ret = Interop.WidgetView.ResumeWidget(SwigCPtr);
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
            bool ret = Interop.WidgetView.CancelTouchEvent(SwigCPtr);
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
            Interop.WidgetView.ActivateFaultedWidget(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Terminate a widget instance.
        /// </summary>
        /// <returns>True on success, false otherwise</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool TerminateWidget()
        {
            bool ret = Interop.WidgetView.TerminateWidget(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static WidgetView DownCast(BaseHandle handle)
        {
            WidgetView ret = new WidgetView(Interop.WidgetView.DownCast(BaseHandle.getCPtr(handle)), true);
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
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal WidgetView Assign(WidgetView handle)
        {
            WidgetView ret = new WidgetView(Interop.WidgetView.Assign(SwigCPtr, WidgetView.getCPtr(handle)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetViewSignal WidgetAddedSignal()
        {
            WidgetViewSignal ret = new WidgetViewSignal(Interop.WidgetView.WidgetAddedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetViewSignal WidgetDeletedSignal()
        {
            WidgetViewSignal ret = new WidgetViewSignal(Interop.WidgetView.WidgetDeletedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetViewSignal WidgetCreationAbortedSignal()
        {
            WidgetViewSignal ret = new WidgetViewSignal(Interop.WidgetView.WidgetCreationAbortedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetViewSignal WidgetContentUpdatedSignal()
        {
            WidgetViewSignal ret = new WidgetViewSignal(Interop.WidgetView.WidgetContentUpdatedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetViewSignal WidgetUpdatePeriodChangedSignal()
        {
            WidgetViewSignal ret = new WidgetViewSignal(Interop.WidgetView.WidgetUpdatePeriodChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WidgetViewSignal WidgetFaultedSignal()
        {
            WidgetViewSignal ret = new WidgetViewSignal(Interop.WidgetView.WidgetFaultedSignal(SwigCPtr), false);
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
                WidgetViewSignal widgetAdded = this.WidgetAddedSignal();
                widgetAdded?.Disconnect(_widgetAddedEventCallback);
                widgetAdded?.Dispose();
            }

            if (_widgetContentUpdatedEventCallback != null)
            {
                WidgetViewSignal widgetContentUpdated = this.WidgetContentUpdatedSignal();
                widgetContentUpdated?.Disconnect(_widgetContentUpdatedEventCallback);
                widgetContentUpdated?.Dispose();
            }

            if (_widgetCreationAbortedEventCallback != null)
            {
                WidgetViewSignal widgetCreationAborted = this.WidgetCreationAbortedSignal();
                widgetCreationAborted?.Disconnect(_widgetCreationAbortedEventCallback);
                widgetCreationAborted?.Dispose();
            }

            if (_widgetDeletedEventCallback != null)
            {
                WidgetViewSignal widgetDeleted = this.WidgetDeletedSignal();
                widgetDeleted?.Disconnect(_widgetDeletedEventCallback);
                widgetDeleted?.Dispose();
            }

            if (_widgetFaultedEventCallback != null)
            {
                WidgetViewSignal widgetFaulted = this.WidgetFaultedSignal();
                widgetFaulted?.Disconnect(_widgetFaultedEventCallback);
                widgetFaulted?.Dispose();
            }

            if (_widgetUpdatePeriodChangedEventCallback != null)
            {
                WidgetViewSignal widgetUpdatePeriodChanged = this.WidgetUpdatePeriodChangedSignal();
                widgetUpdatePeriodChanged?.Disconnect(_widgetUpdatePeriodChangedEventCallback);
                widgetUpdatePeriodChanged?.Dispose();
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WidgetView.DeleteWidgetView(swigCPtr);
        }

        // Callback for WidgetView WidgetAdded signal
        private void OnWidgetAdded(IntPtr data)
        {
            WidgetViewEventArgs e = new WidgetViewEventArgs();
            if (data != null)
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
            if (data != null)
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
            internal static readonly int WidgetId = Interop.WidgetView.WidgetIdGet();
            internal static readonly int InstanceId = Interop.WidgetView.InstanceIdGet();
            internal static readonly int ContentInfo = Interop.WidgetView.ContentInfoGet();
            internal static readonly int TITLE = Interop.WidgetView.TitleGet();
            internal static readonly int UpdatePeriod = Interop.WidgetView.UpdatePeriodGet();
            internal static readonly int PREVIEW = Interop.WidgetView.PreviewGet();
            internal static readonly int LoadingText = Interop.WidgetView.LoadingTextGet();
            internal static readonly int WidgetStateFaulted = Interop.WidgetView.WidgetStateFaultedGet();
            internal static readonly int PermanentDelete = Interop.WidgetView.PermanentDeleteGet();
            internal static readonly int RetryText = Interop.WidgetView.RetryTextGet();
            internal static readonly int EFFECT = Interop.WidgetView.EffectGet();


            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use WidgetId instead!")]
            internal static readonly int WIDGET_ID = Interop.WidgetView.WidgetIdGet();
            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ContentInfo instead!")]
            internal static readonly int CONTENT_INFO = Interop.WidgetView.ContentInfoGet();
            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use UpdatePeriod instead!")]
            internal static readonly int UPDATE_PERIOD = Interop.WidgetView.UpdatePeriodGet();
            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use LoadingText instead!")]
            internal static readonly int LOADING_TEXT = Interop.WidgetView.LoadingTextGet();
        }
    }

}
