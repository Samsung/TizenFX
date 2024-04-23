/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
    using Tizen.NUI;
    using Tizen.NUI.Binding;

    /// <summary>
    /// The WidgetView is a class for displaying the widget image and controlling the widget.<br />
    /// Input events that the WidgetView gets are delivered to the widget.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class WidgetView : View
    {
        static WidgetView()
        {
            if(NUIApplication.IsUsingXaml)
            {
                PreviewProperty = BindableProperty.Create(nameof(Preview), typeof(bool), typeof(Tizen.NUI.WidgetView), false, propertyChanged: SetInternalPreviewProperty, defaultValueCreator: GetInternalPreviewProperty);
                
                LoadingTextProperty = BindableProperty.Create(nameof(LoadingText), typeof(bool), typeof(Tizen.NUI.WidgetView), false, propertyChanged: SetInternalLoadingTextProperty, defaultValueCreator: GetInternalLoadingTextProperty);
                
                WidgetStateFaultedProperty = BindableProperty.Create(nameof(WidgetStateFaulted), typeof(bool), typeof(Tizen.NUI.WidgetView), false, propertyChanged: SetInternalWidgetStateFaultedProperty, defaultValueCreator: GetInternalWidgetStateFaultedProperty);
                
                PermanentDeleteProperty = BindableProperty.Create(nameof(PermanentDelete), typeof(bool), typeof(Tizen.NUI.WidgetView), false, propertyChanged: SetInternalPermanentDeleteProperty, defaultValueCreator: GetInternalPermanentDeleteProperty);
                
                RetryTextProperty = BindableProperty.Create(nameof(RetryText), typeof(Tizen.NUI.PropertyMap), typeof(Tizen.NUI.WidgetView), null, propertyChanged: SetInternalRetryTextProperty, defaultValueCreator: GetInternalRetryTextProperty);
                
                EffectProperty = BindableProperty.Create(nameof(Effect), typeof(Tizen.NUI.PropertyMap), typeof(Tizen.NUI.WidgetView), null, propertyChanged: SetInternalEffectProperty, defaultValueCreator: GetInternalEffectProperty);
                
                KeepWidgetSizeProperty = BindableProperty.Create(nameof(KeepWidgetSize), typeof(bool), typeof(Tizen.NUI.WidgetView), false, propertyChanged: SetInternalKeepWidgetSizeProperty, defaultValueCreator: GetInternalKeepWidgetSizeProperty);
                
            }
        }
        /// <summary>
        /// PreviewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PreviewProperty = null;

        internal static void SetInternalPreviewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            if (newValue != null)
            {
                instance.InternalPreview = (bool)newValue;
            }
        }
        
        internal static object GetInternalPreviewProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            return instance.InternalPreview;
        }

        /// <summary>
        /// LoadingTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LoadingTextProperty = null;

        internal static void SetInternalLoadingTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            if (newValue != null)
            {
                instance.InternalLoadingText = (bool)newValue;
            }
        }
        
        internal static object GetInternalLoadingTextProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            return instance.InternalLoadingText;
        }

        /// <summary>
        /// WidgetStateFaultedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidgetStateFaultedProperty = null;

        internal static void SetInternalWidgetStateFaultedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            if (newValue != null)
            {
                instance.InternalWidgetStateFaulted = (bool)newValue;
            }
        }
        
        internal static object GetInternalWidgetStateFaultedProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            return instance.InternalWidgetStateFaulted;
        }

        /// <summary>
        /// PermanentDeleteProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PermanentDeleteProperty = null;

        internal static void SetInternalPermanentDeleteProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            if (newValue != null)
            {
                instance.InternalPermanentDelete = (bool)newValue;
            }
        }
        
        internal static object GetInternalPermanentDeleteProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            return instance.InternalPermanentDelete;
        }

        /// <summary>
        /// RetryTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RetryTextProperty = null;

        internal static void SetInternalRetryTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            if (newValue != null)
            {
                instance.InternalRetryText = (Tizen.NUI.PropertyMap)newValue;
            }
        }
        
        internal static object GetInternalRetryTextProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            return instance.InternalRetryText;
        }

        /// <summary>
        /// EffectProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EffectProperty = null;

        internal static void SetInternalEffectProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            if (newValue != null)
            {
                instance.InternalEffect = (Tizen.NUI.PropertyMap)newValue;
            }
        }
        
        internal static object GetInternalEffectProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            return instance.InternalEffect;
        }

        /// <summary>
        /// UpdateWidgetSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty KeepWidgetSizeProperty = null;

        internal static void SetInternalKeepWidgetSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            if (newValue != null)
            {
                instance.InternalKeepWidgetSize = (bool)newValue;
            }
        }
        
        internal static object GetInternalKeepWidgetSizeProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.WidgetView)bindable;
            return instance.InternalKeepWidgetSize;
        }


        private EventHandler<WidgetViewEventArgs> widgetAddedEventHandler;
        private WidgetAddedEventCallbackType widgetAddedEventCallback;
        private EventHandler<WidgetViewEventArgs> widgetContentUpdatedEventHandler;
        private WidgetContentUpdatedEventCallbackType widgetContentUpdatedEventCallback;
        private EventHandler<WidgetViewEventArgs> widgetDeletedEventHandler;
        private WidgetDeletedEventCallbackType widgetDeletedEventCallback;
        private EventHandler<WidgetViewEventArgs> widgetCreationAbortedEventHandler;
        private WidgetCreationAbortedEventCallbackType widgetCreationAbortedEventCallback;
        private EventHandler<WidgetViewEventArgs> widgetUpdatePeriodChangedEventHandler;
        private WidgetUpdatePeriodChangedEventCallbackType widgetUpdatePeriodChangedEventCallback;
        private EventHandler<WidgetViewEventArgs> widgetFaultedEventHandler;
        private WidgetFaultedEventCallbackType widgetFaultedEventCallback;

        /// <summary>
        /// Used in xaml as factory method to create WidgetView.
        /// </summary>
        /// <param name="widgetId"></param>
        /// <param name="contentInfo"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="updatePeriod"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static WidgetView CreateWidgetView(string widgetId, string contentInfo, int width, int height, float updatePeriod)
        {
            return WidgetViewManager.Instance.AddWidget(widgetId, contentInfo, width, height, updatePeriod);
        }

        /// <summary>
        /// Creates a new WidgetView.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WidgetView(string widgetId, string contentInfo, int width, int height, float updatePeriod) : this(Interop.WidgetView.New(widgetId, contentInfo, width, height, updatePeriod), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal WidgetView(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal WidgetView(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, true, cRegister)
        {
        }

        internal WidgetView(WidgetView handle) : this(Interop.WidgetView.NewWidgetView(WidgetView.getCPtr(handle)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WidgetAddedEventCallbackType(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WidgetContentUpdatedEventCallbackType(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WidgetDeletedEventCallbackType(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WidgetCreationAbortedEventCallbackType(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WidgetUpdatePeriodChangedEventCallbackType(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WidgetFaultedEventCallbackType(IntPtr data);

        /// <summary>
        /// An event for the WidgetAdded signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when widget is added.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WidgetViewEventArgs> WidgetAdded
        {
            add
            {
                if (widgetAddedEventHandler == null)
                {
                    widgetAddedEventCallback = OnWidgetAdded;
                    WidgetViewSignal widgetAdded = WidgetAddedSignal();
                    widgetAdded?.Connect(widgetAddedEventCallback);
                    widgetAdded?.Dispose();
                }

                widgetAddedEventHandler += value;
            }

            remove
            {
                widgetAddedEventHandler -= value;

                WidgetViewSignal widgetAdded = WidgetAddedSignal();
                if (widgetAddedEventHandler == null && widgetAdded?.Empty() == false)
                {
                    widgetAdded?.Disconnect(widgetAddedEventCallback);
                }
                widgetAdded?.Dispose();
            }
        }

        /// <summary>
        /// An event for the WidgetContentUpdated signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when the widget content is updated.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WidgetViewEventArgs> WidgetContentUpdated
        {
            add
            {
                if (widgetContentUpdatedEventHandler == null)
                {
                    widgetContentUpdatedEventCallback = OnWidgetContentUpdated;
                    WidgetViewSignal widgetContentUpdated = WidgetContentUpdatedSignal();
                    widgetContentUpdated?.Connect(widgetContentUpdatedEventCallback);
                    widgetContentUpdated?.Dispose();
                }

                widgetContentUpdatedEventHandler += value;
            }

            remove
            {
                widgetContentUpdatedEventHandler -= value;

                WidgetViewSignal widgetContentUpdated = WidgetContentUpdatedSignal();
                if (widgetContentUpdatedEventHandler == null && widgetContentUpdated?.Empty() == false)
                {
                    widgetContentUpdated?.Disconnect(widgetContentUpdatedEventCallback);
                }
                widgetContentUpdated?.Dispose();
            }
        }

        /// <summary>
        /// An event for the WidgetDeleted signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when the widget is deleted.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WidgetViewEventArgs> WidgetDeleted
        {
            add
            {
                if (widgetDeletedEventHandler == null)
                {
                    widgetDeletedEventCallback = OnWidgetDeleted;
                    WidgetViewSignal widgetDeleted = WidgetDeletedSignal();
                    widgetDeleted?.Connect(widgetDeletedEventCallback);
                    widgetDeleted?.Dispose();
                }

                widgetDeletedEventHandler += value;
            }

            remove
            {
                widgetDeletedEventHandler -= value;

                WidgetViewSignal widgetDeleted = WidgetDeletedSignal();
                if (widgetDeletedEventHandler == null && widgetDeleted?.Empty() == false)
                {
                    widgetDeleted?.Disconnect(widgetDeletedEventCallback);
                }
                widgetDeleted?.Dispose();
            }
        }

        /// <summary>
        /// An event for the WidgetCreationAborted signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when the widget creation is aborted.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WidgetViewEventArgs> WidgetCreationAborted
        {
            add
            {
                if (widgetCreationAbortedEventHandler == null)
                {
                    widgetCreationAbortedEventCallback = OnWidgetCreationAborted;
                    WidgetViewSignal widgetCreationAborted = WidgetCreationAbortedSignal();
                    widgetCreationAborted?.Connect(widgetCreationAbortedEventCallback);
                    widgetCreationAborted?.Dispose();
                }

                widgetCreationAbortedEventHandler += value;
            }

            remove
            {
                widgetCreationAbortedEventHandler -= value;

                WidgetViewSignal widgetCreationAborted = WidgetCreationAbortedSignal();
                if (widgetCreationAbortedEventHandler == null && widgetCreationAborted?.Empty() == false)
                {
                    widgetCreationAborted?.Disconnect(widgetCreationAbortedEventCallback);
                }
                widgetCreationAborted?.Dispose();
            }
        }

        /// <summary>
        /// An event for the WidgetUpdatePeriodChanged signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when the widget update period is changed.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WidgetViewEventArgs> WidgetUpdatePeriodChanged
        {
            add
            {
                if (widgetUpdatePeriodChangedEventHandler == null)
                {
                    widgetUpdatePeriodChangedEventCallback = OnWidgetUpdatePeriodChanged;
                    WidgetViewSignal widgetUpdatePeriodChanged = WidgetUpdatePeriodChangedSignal();
                    widgetUpdatePeriodChanged?.Connect(widgetUpdatePeriodChangedEventCallback);
                    widgetUpdatePeriodChanged?.Dispose();
                }

                widgetUpdatePeriodChangedEventHandler += value;
            }

            remove
            {
                widgetUpdatePeriodChangedEventHandler -= value;

                WidgetViewSignal widgetUpdatePeriodChanged = WidgetUpdatePeriodChangedSignal();
                if (widgetUpdatePeriodChangedEventHandler == null && widgetUpdatePeriodChanged?.Empty() == false)
                {
                    widgetUpdatePeriodChanged?.Disconnect(widgetUpdatePeriodChangedEventCallback);
                }
                widgetUpdatePeriodChanged?.Dispose();
            }
        }

        /// <summary>
        /// An event for the WidgetFaulted signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when the widget process is not running.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WidgetViewEventArgs> WidgetFaulted
        {
            add
            {
                if (widgetFaultedEventHandler == null)
                {
                    widgetFaultedEventCallback = OnWidgetFaulted;
                    WidgetViewSignal widgetFaulted = WidgetFaultedSignal();
                    widgetFaulted?.Connect(widgetFaultedEventCallback);
                    widgetFaulted?.Dispose();
                }

                widgetFaultedEventHandler += value;
            }

            remove
            {
                widgetFaultedEventHandler -= value;

                WidgetViewSignal widgetFaulted = WidgetFaultedSignal();
                if (widgetFaultedEventHandler == null && widgetFaulted?.Empty() == false)
                {
                    widgetFaulted?.Disconnect(widgetFaultedEventCallback);
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
        /// Gets the update period.
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(PreviewProperty);
                }
                else
                {
                    return (bool)GetInternalPreviewProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PreviewProperty, value);
                }
                else
                {
                    SetInternalPreviewProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        
        private bool InternalPreview
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(LoadingTextProperty);
                }
                else
                {
                    return (bool)GetInternalLoadingTextProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LoadingTextProperty, value);
                }
                else
                {
                    SetInternalLoadingTextProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        
        private bool InternalLoadingText
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(WidgetStateFaultedProperty);
                }
                else
                {
                    return (bool)GetInternalWidgetStateFaultedProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WidgetStateFaultedProperty, value);
                }
                else
                {
                    SetInternalWidgetStateFaultedProperty(this, null, value); 
                }
                NotifyPropertyChanged();
            }
        }
        
        private bool InternalWidgetStateFaulted
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(PermanentDeleteProperty);
                }
                else
                {
                    return (bool)GetInternalPermanentDeleteProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PermanentDeleteProperty, value);
                }
                else
                {
                    SetInternalPermanentDeleteProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        
        private bool InternalPermanentDelete
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(RetryTextProperty) as PropertyMap;
                }
                else
                {
                    return GetInternalRetryTextProperty(this) as PropertyMap;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RetryTextProperty, value);
                }
                else
                {
                    SetInternalRetryTextProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        
        private PropertyMap InternalRetryText
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(EffectProperty) as PropertyMap;
                }
                else
                {
                    return GetInternalEffectProperty(this) as PropertyMap;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EffectProperty, value);
                }
                else
                {
                    SetInternalEffectProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        
        private PropertyMap InternalEffect
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
        /// Gets or sets KeepWidgetSize
        ///
        /// if this value is true, WidgetView keep widget instance's size and don't resize even if WidgetView is resized.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool KeepWidgetSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(KeepWidgetSizeProperty);
                }
                else
                {
                    return (bool)GetInternalKeepWidgetSizeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(KeepWidgetSizeProperty, value);
                }
                else
                {
                    SetInternalKeepWidgetSizeProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private bool InternalKeepWidgetSize
        {
            get
            {
                bool retValue = false;
                PropertyValue keepWidgetSize = GetProperty(WidgetView.Property.KeepWidgetSize);
                keepWidgetSize?.Get(out retValue);
                keepWidgetSize?.Dispose();
                return retValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(WidgetView.Property.KeepWidgetSize, setValue);
                setValue.Dispose();
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
            if (cPtr == global::System.IntPtr.Zero)
            {
                return null;
            }
            WidgetView ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as WidgetView;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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

            //Remove Widget from WidgetViewManager
            WidgetViewManager.Instance.RemoveWidget(this);

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (widgetAddedEventCallback != null)
            {
                WidgetViewSignal widgetAdded = this.WidgetAddedSignal();
                widgetAdded?.Disconnect(widgetAddedEventCallback);
                widgetAdded?.Dispose();
            }

            if (widgetContentUpdatedEventCallback != null)
            {
                WidgetViewSignal widgetContentUpdated = this.WidgetContentUpdatedSignal();
                widgetContentUpdated?.Disconnect(widgetContentUpdatedEventCallback);
                widgetContentUpdated?.Dispose();
            }

            if (widgetCreationAbortedEventCallback != null)
            {
                WidgetViewSignal widgetCreationAborted = this.WidgetCreationAbortedSignal();
                widgetCreationAborted?.Disconnect(widgetCreationAbortedEventCallback);
                widgetCreationAborted?.Dispose();
            }

            if (widgetDeletedEventCallback != null)
            {
                WidgetViewSignal widgetDeleted = this.WidgetDeletedSignal();
                widgetDeleted?.Disconnect(widgetDeletedEventCallback);
                widgetDeleted?.Dispose();
            }

            if (widgetFaultedEventCallback != null)
            {
                WidgetViewSignal widgetFaulted = this.WidgetFaultedSignal();
                widgetFaulted?.Disconnect(widgetFaultedEventCallback);
                widgetFaulted?.Dispose();
            }

            if (widgetUpdatePeriodChangedEventCallback != null)
            {
                WidgetViewSignal widgetUpdatePeriodChanged = this.WidgetUpdatePeriodChangedSignal();
                widgetUpdatePeriodChanged?.Disconnect(widgetUpdatePeriodChangedEventCallback);
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

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool HandleControlStateOnTouch(Touch touch)
        {
            base.HandleControlStateOnTouch(touch);
            return true; // Do not pass the touch event to the below.
        }

        // Callback for WidgetView WidgetAdded signal
        private void OnWidgetAdded(IntPtr data)
        {
            WidgetViewEventArgs e = new WidgetViewEventArgs();
            if (data != IntPtr.Zero)
            {
                e.WidgetView = WidgetView.GetWidgetViewFromPtr(data);
            }

            if (widgetAddedEventHandler != null)
            {
                widgetAddedEventHandler(this, e);
            }
        }

        // Callback for WidgetView WidgetDeleted signal
        private void OnWidgetDeleted(IntPtr data)
        {
            WidgetViewEventArgs e = new WidgetViewEventArgs();
            if (data != IntPtr.Zero)
            {
                e.WidgetView = WidgetView.GetWidgetViewFromPtr(data);
            }

            if (widgetDeletedEventHandler != null)
            {
                widgetDeletedEventHandler(this, e);
            }
        }

        // Callback for WidgetView WidgetCreationAborted signal
        private void OnWidgetCreationAborted(IntPtr data)
        {
            WidgetViewEventArgs e = new WidgetViewEventArgs();
            if (data != IntPtr.Zero)
            {
                e.WidgetView = WidgetView.GetWidgetViewFromPtr(data);
            }

            if (widgetCreationAbortedEventHandler != null)
            {
                widgetCreationAbortedEventHandler(this, e);
            }
        }



        // Callback for WidgetView WidgetContentUpdated signal
        private void OnWidgetContentUpdated(IntPtr data)
        {
            WidgetViewEventArgs e = new WidgetViewEventArgs();
            if (data != IntPtr.Zero)
            {
                e.WidgetView = WidgetView.GetWidgetViewFromPtr(data);
            }

            if (widgetContentUpdatedEventHandler != null)
            {
                widgetContentUpdatedEventHandler(this, e);
            }
        }

        // Callback for WidgetView WidgetUpdatePeriodChanged signal
        private void OnWidgetUpdatePeriodChanged(IntPtr data)
        {
            WidgetViewEventArgs e = new WidgetViewEventArgs();
            if (data != IntPtr.Zero)
            {
                e.WidgetView = WidgetView.GetWidgetViewFromPtr(data);
            }

            if (widgetUpdatePeriodChangedEventHandler != null)
            {
                widgetUpdatePeriodChangedEventHandler(this, e);
            }
        }

        // Callback for WidgetView WidgetFaulted signal
        private void OnWidgetFaulted(IntPtr data)
        {
            WidgetViewEventArgs e = new WidgetViewEventArgs();
            if (data != IntPtr.Zero)
            {
                e.WidgetView = WidgetView.GetWidgetViewFromPtr(data);
            }

            if (widgetFaultedEventHandler != null)
            {
                widgetFaultedEventHandler(this, e);
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
            /// The widget view.
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

            internal static readonly int KeepWidgetSize = Interop.WidgetView.KeepWidgetSizeGet();

            [Obsolete("Do not use this, that is deprecated in API9 and will be removed in API11. Use WidgetId instead.")]
            internal static readonly int WIDGET_ID = Interop.WidgetView.WidgetIdGet();
            [Obsolete("Do not use this, that is deprecated in API9 and will be removed in API11. Use ContentInfo instead.")]
            internal static readonly int CONTENT_INFO = Interop.WidgetView.ContentInfoGet();
            [Obsolete("Do not use this, that is deprecated in API9 and will be removed in API11. Use UpdatePeriod instead.")]
            internal static readonly int UPDATE_PERIOD = Interop.WidgetView.UpdatePeriodGet();
            [Obsolete("Do not use this, that is deprecated in API9 and will be removed in API11. Use LoadingText instead.")]
            internal static readonly int LOADING_TEXT = Interop.WidgetView.LoadingTextGet();
        }
    }

}
