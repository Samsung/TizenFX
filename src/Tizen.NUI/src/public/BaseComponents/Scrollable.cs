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
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// Base class for derived Scrollable that contains actors that can be scrolled manually
    /// (via touch) or automatically.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Scrollable : View
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootEffectColorProperty = BindableProperty.Create(nameof(OvershootEffectColor), typeof(Vector4), typeof(Scrollable), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.OvershootEffectColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.OvershootEffectColor).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootAnimationSpeedProperty = BindableProperty.Create(nameof(OvershootAnimationSpeed), typeof(float), typeof(Scrollable), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.OvershootAnimationSpeed, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.OvershootAnimationSpeed).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootEnabledProperty = BindableProperty.Create(nameof(OvershootEnabled), typeof(bool), typeof(Scrollable), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.OvershootEnabled, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.OvershootEnabled).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootSizeProperty = BindableProperty.Create(nameof(OvershootSize), typeof(Vector2), typeof(Scrollable), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.OvershootSize, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.OvershootSize).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollToAlphaFunctionProperty = BindableProperty.Create(nameof(ScrollToAlphaFunction), typeof(int), typeof(Scrollable), default(int), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.ScrollToAlphaFunction, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.ScrollToAlphaFunction).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollRelativePositionProperty = BindableProperty.Create(nameof(ScrollRelativePosition), typeof(Vector2), typeof(Scrollable), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.ScrollRelativePosition, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.ScrollRelativePosition).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPositionMinProperty = BindableProperty.Create(nameof(ScrollPositionMin), typeof(Vector2), typeof(Scrollable), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.ScrollPositionMin, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.ScrollPositionMin).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPositionMaxProperty = BindableProperty.Create(nameof(ScrollPositionMax), typeof(Vector2), typeof(Scrollable), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.ScrollPositionMax, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.ScrollPositionMax).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CanScrollVerticalProperty = BindableProperty.Create(nameof(CanScrollVertical), typeof(bool), typeof(Scrollable), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.CanScrollVertical, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.CanScrollVertical).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CanScrollHorizontalProperty = BindableProperty.Create(nameof(CanScrollHorizontal), typeof(bool), typeof(Scrollable), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.CanScrollHorizontal, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((HandleRef)scrollable.SwigCPtr, Scrollable.Property.CanScrollHorizontal).Get(out temp);
            return temp;
        }));

        private DaliEventHandler<object, StartedEventArgs> scrollableStartedEventHandler;
        private StartedCallbackDelegate scrollableStartedCallbackDelegate;
        private DaliEventHandler<object, UpdatedEventArgs> scrollableUpdatedEventHandler;
        private UpdatedCallbackDelegate scrollableUpdatedCallbackDelegate;
        private DaliEventHandler<object, CompletedEventArgs> scrollableCompletedEventHandler;
        private CompletedCallbackDelegate scrollableCompletedCallbackDelegate;

        /// <summary>
        /// Create an instance of scrollable.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Scrollable() : this(Interop.Scrollable.NewScrollable(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Scrollable(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void StartedCallbackDelegate(IntPtr vector2);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void UpdatedCallbackDelegate(IntPtr vector2);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void CompletedCallbackDelegate(IntPtr vector2);

        /// <summary>
        /// The ScrollStarted event emitted when the Scrollable has moved (whether by touch or animation).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event DaliEventHandler<object, StartedEventArgs> ScrollStarted
        {
            add
            {
                // Restricted to only one listener
                if (scrollableStartedEventHandler == null)
                {
                    scrollableStartedEventHandler += value;

                    scrollableStartedCallbackDelegate = new StartedCallbackDelegate(OnStarted);
                    this.ScrollStartedSignal().Connect(scrollableStartedCallbackDelegate);
                }
            }

            remove
            {
                if (scrollableStartedEventHandler != null)
                {
                    this.ScrollStartedSignal().Disconnect(scrollableStartedCallbackDelegate);
                }

                scrollableStartedEventHandler -= value;
            }
        }

        /// <summary>
        /// The ScrollUpdated event emitted when the Scrollable has moved (whether by touch or animation).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event DaliEventHandler<object, UpdatedEventArgs> ScrollUpdated
        {
            add
            {
                // Restricted to only one listener
                if (scrollableUpdatedEventHandler == null)
                {
                    scrollableUpdatedEventHandler += value;

                    scrollableUpdatedCallbackDelegate = new UpdatedCallbackDelegate(OnUpdated);
                    this.ScrollUpdatedSignal().Connect(scrollableUpdatedCallbackDelegate);
                }
            }

            remove
            {
                if (scrollableUpdatedEventHandler != null)
                {
                    this.ScrollUpdatedSignal().Disconnect(scrollableUpdatedCallbackDelegate);
                }

                scrollableUpdatedEventHandler -= value;
            }
        }

        /// <summary>
        /// The ScrollCompleted event emitted when the Scrollable has completed movement
        /// (whether by touch or animation).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event DaliEventHandler<object, CompletedEventArgs> ScrollCompleted
        {
            add
            {
                // Restricted to only one listener
                if (scrollableCompletedEventHandler == null)
                {
                    scrollableCompletedEventHandler += value;

                    scrollableCompletedCallbackDelegate = new CompletedCallbackDelegate(OnCompleted);
                    this.ScrollCompletedSignal().Connect(scrollableCompletedCallbackDelegate);
                }
            }

            remove
            {
                if (scrollableCompletedEventHandler != null)
                {
                    this.ScrollCompletedSignal().Disconnect(scrollableCompletedCallbackDelegate);
                }

                scrollableCompletedEventHandler -= value;
            }
        }

        /// <summary>
        /// Sets and Gets the color of the overshoot effect.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 OvershootEffectColor
        {
            get
            {
                return (Vector4)GetValue(OvershootEffectColorProperty);
            }
            set
            {
                SetValue(OvershootEffectColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Sets and Gets the speed of overshoot animation in pixels per second.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float OvershootAnimationSpeed
        {
            get
            {
                return (float)GetValue(OvershootAnimationSpeedProperty);
            }
            set
            {
                SetValue(OvershootAnimationSpeedProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Checks if scroll overshoot has been enabled or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool OvershootEnabled
        {
            get
            {
                return (bool)GetValue(OvershootEnabledProperty);
            }
            set
            {
                SetValue(OvershootEnabledProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets OvershootSize property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 OvershootSize
        {
            get
            {
                return (Vector2)GetValue(OvershootSizeProperty);
            }
            set
            {
                SetValue(OvershootSizeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets ScrollToAlphaFunction property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int ScrollToAlphaFunction
        {
            get
            {
                return (int)GetValue(ScrollToAlphaFunctionProperty);
            }
            set
            {
                SetValue(ScrollToAlphaFunctionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets ScrollRelativePosition property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScrollRelativePosition
        {
            get
            {
                return (Vector2)GetValue(ScrollRelativePositionProperty);
            }
            set
            {
                SetValue(ScrollRelativePositionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets ScrollPositionMin property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScrollPositionMin
        {
            get
            {
                return (Vector2)GetValue(ScrollPositionMinProperty);
            }
            set
            {
                SetValue(ScrollPositionMinProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets ScrollPositionMax property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScrollPositionMax
        {
            get
            {
                return (Vector2)GetValue(ScrollPositionMaxProperty);
            }
            set
            {
                SetValue(ScrollPositionMaxProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets CanScrollVertical property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool CanScrollVertical
        {
            get
            {
                return (bool)GetValue(CanScrollVerticalProperty);
            }
            set
            {
                SetValue(CanScrollVerticalProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets CanScrollHorizontal property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool CanScrollHorizontal
        {
            get
            {
                return (bool)GetValue(CanScrollHorizontalProperty);
            }
            set
            {
                SetValue(CanScrollHorizontalProperty, value);
                NotifyPropertyChanged();
            }
        }

        internal ScrollableSignal ScrollStartedSignal()
        {
            ScrollableSignal ret = new ScrollableSignal(Interop.Scrollable.ScrollStartedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ScrollableSignal ScrollUpdatedSignal()
        {
            ScrollableSignal ret = new ScrollableSignal(Interop.Scrollable.ScrollUpdatedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ScrollableSignal ScrollCompletedSignal()
        {
            ScrollableSignal ret = new ScrollableSignal(Interop.Scrollable.ScrollCompletedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
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
            if (this != null)
            {
                DisConnectFromSignals();
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Scrollable.DeleteScrollable(swigCPtr);
        }

        private void DisConnectFromSignals()
        {
            // Save current CPtr.
            global::System.Runtime.InteropServices.HandleRef currentCPtr = SwigCPtr;

            // Use BaseHandle CPtr as current might have been deleted already in derived classes.
            SwigCPtr = GetBaseHandleCPtrHandleRef;

            if (scrollableCompletedCallbackDelegate != null)
            {
                this.ScrollCompletedSignal().Disconnect(scrollableCompletedCallbackDelegate);
            }

            if (scrollableUpdatedCallbackDelegate != null)
            {
                this.ScrollUpdatedSignal().Disconnect(scrollableUpdatedCallbackDelegate);
            }

            if (scrollableStartedCallbackDelegate != null)
            {
                this.ScrollStartedSignal().Disconnect(scrollableStartedCallbackDelegate);
            }

            // BaseHandle CPtr is used in Registry and there is danger of deletion if we keep using it here.
            // Restore current CPtr.
            SwigCPtr = currentCPtr;
        }

        private void OnStarted(IntPtr vector2)
        {
            if (scrollableStartedEventHandler != null)
            {
                StartedEventArgs e = new StartedEventArgs();

                // Populate all members of "e" (StartedEventArgs) with real data
                e.Vector2 = Tizen.NUI.Vector2.GetVector2FromPtr(vector2);
                //here we send all data to user event handlers
                scrollableStartedEventHandler(this, e);
            }

        }

        private void OnUpdated(IntPtr vector2)
        {
            if (scrollableUpdatedEventHandler != null)
            {
                UpdatedEventArgs e = new UpdatedEventArgs();

                // Populate all members of "e" (UpdatedEventArgs) with real data
                e.Vector2 = Tizen.NUI.Vector2.GetVector2FromPtr(vector2);
                //here we send all data to user event handlers
                scrollableUpdatedEventHandler(this, e);
            }

        }

        private void OnCompleted(IntPtr vector2)
        {
            if (scrollableCompletedEventHandler != null)
            {
                CompletedEventArgs e = new CompletedEventArgs();

                // Populate all members of "e" (CompletedEventArgs) with real data
                e.Vector2 = Tizen.NUI.Vector2.GetVector2FromPtr(vector2);
                //here we send all data to user event handlers
                scrollableCompletedEventHandler(this, e);
            }

        }

        private bool IsOvershootEnabled()
        {
            bool ret = Interop.Scrollable.IsOvershootEnabled(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void SetOvershootEnabled(bool enable)
        {
            Interop.Scrollable.SetOvershootEnabled(SwigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SetOvershootEffectColor(Vector4 color)
        {
            Interop.Scrollable.SetOvershootEffectColor(SwigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private Vector4 GetOvershootEffectColor()
        {
            Vector4 ret = new Vector4(Interop.Scrollable.GetOvershootEffectColor(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void SetOvershootAnimationSpeed(float pixelsPerSecond)
        {
            Interop.Scrollable.SetOvershootAnimationSpeed(SwigCPtr, pixelsPerSecond);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private float GetOvershootAnimationSpeed()
        {
            float ret = Interop.Scrollable.GetOvershootAnimationSpeed(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The scroll animation started event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class StartedEventArgs : EventArgs
        {
            private Vector2 vector2;

            /// <summary>
            /// Vector2.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Vector2 Vector2
            {
                get
                {
                    return vector2;
                }
                set
                {
                    vector2 = value;
                }
            }
        }

        /// <summary>
        /// The scrollable updated event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class UpdatedEventArgs : EventArgs
        {
            private Vector2 vector2;

            /// <summary>
            /// Vector2.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Vector2 Vector2
            {
                get
                {
                    return vector2;
                }
                set
                {
                    vector2 = value;
                }
            }
        }

        /// <summary>
        /// The scroll animation completed event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class CompletedEventArgs : EventArgs
        {
            private Vector2 vector2;

            /// <summary>
            /// Vector2.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Vector2 Vector2
            {
                get
                {
                    return vector2;
                }
                set
                {
                    vector2 = value;
                }
            }
        }

        /// <summary>
        /// Enumeration for the instance of properties belonging to the Scrollable class.
        /// </summary>
        internal new class Property
        {
            /// <summary>
            /// The color of the overshoot effect.
            /// </summary>
            internal static readonly int OvershootEffectColor = Interop.Scrollable.OvershootEffectColorGet();
            /// <summary>
            /// The speed of overshoot animation in pixels per second.
            /// </summary>
            internal static readonly int OvershootAnimationSpeed = Interop.Scrollable.OvershootAnimationSpeedGet();
            /// <summary>
            /// Whether to enables or disable scroll overshoot.
            /// </summary>
            internal static readonly int OvershootEnabled = Interop.Scrollable.OvershootEnabledGet();
            /// <summary>
            /// The size of the overshoot.
            /// </summary>
            internal static readonly int OvershootSize = Interop.Scrollable.OvershootSizeGet();
            /// <summary>
            /// scrollToAlphaFunction.
            /// </summary>
            internal static readonly int ScrollToAlphaFunction = Interop.Scrollable.ScrollToAlphaFunctionGet();
            /// <summary>
            /// scrollRelativePosition
            /// </summary>
            internal static readonly int ScrollRelativePosition = Interop.Scrollable.ScrollRelativePositionGet();
            /// <summary>
            /// scrollPositionMin
            /// </summary>
            internal static readonly int ScrollPositionMin = Interop.Scrollable.ScrollPositionMinGet();
            /// <summary>
            /// scrollPositionMinX.
            /// </summary>
            internal static readonly int ScrollPositionMinX = Interop.Scrollable.ScrollPositionMinXGet();
            /// <summary>
            /// scrollPositionMinY.
            /// </summary>
            internal static readonly int ScrollPositionMinY = Interop.Scrollable.ScrollPositionMinYGet();
            /// <summary>
            /// scrollPositionMax.
            /// </summary>
            internal static readonly int ScrollPositionMax = Interop.Scrollable.ScrollPositionMaxGet();
            /// <summary>
            /// scrollPositionMaxX.
            /// </summary>
            internal static readonly int ScrollPositionMaxX = Interop.Scrollable.ScrollPositionMaxXGet();
            /// <summary>
            /// scrollPositionMaxY.
            /// </summary>
            internal static readonly int ScrollPositionMaxY = Interop.Scrollable.ScrollPositionMaxYGet();
            /// <summary>
            /// canScrollVertical
            /// </summary>
            internal static readonly int CanScrollVertical = Interop.Scrollable.CanScrollVerticalGet();
            /// <summary>
            /// canScrollHorizontal.
            /// </summary>
            internal static readonly int CanScrollHorizontal = Interop.Scrollable.CanScrollHorizontalGet();
        }
    }
}
