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

namespace Tizen.NUI.UIComponents
{

    using System;
    using System.Runtime.InteropServices;
    using Tizen.NUI.BaseComponents;

    /// <summary>
    /// The slider is a control to enable sliding an indicator between two values.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Slider : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Slider(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Slider_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Slider obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (this != null)
            {
                if (_sliderValueChangedCallbackDelegate != null)
                {
                    ValueChangedSignal().Disconnect(_sliderValueChangedCallbackDelegate);
                }

                if (_sliderSlidingFinishedCallbackDelegate != null)
                {
                    SlidingFinishedSignal().Disconnect(_sliderSlidingFinishedCallbackDelegate);
                }

                if (_sliderMarkReachedCallbackDelegate != null)
                {
                    MarkReachedSignal().Disconnect(_sliderMarkReachedCallbackDelegate);
                }
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Slider(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// The ValueChanged event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class ValueChangedEventArgs : EventArgs
        {
            private Slider _slider;
            private float _slideValue;

            /// <summary>
            /// The slider.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Slider Slider
            {
                get
                {
                    return _slider;
                }
                set
                {
                    _slider = value;
                }
            }

            /// <summary>
            /// The slider value.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public float SlideValue
            {
                get
                {
                    return _slideValue;
                }
                set
                {
                    _slideValue = value;
                }
            }
        }

        /// <summary>
        /// The SlidingFinished event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class SlidingFinishedEventArgs : EventArgs
        {
            private Slider _slider;
            private float _slideValue;

            /// <summary>
            /// The slider.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Slider Slider
            {
                get
                {
                    return _slider;
                }
                set
                {
                    _slider = value;
                }
            }

            /// <summary>
            /// The slider value.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public float SlideValue
            {
                get
                {
                    return _slideValue;
                }
                set
                {
                    _slideValue = value;
                }
            }
        }

        /// <summary>
        /// The MarkReached event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class MarkReachedEventArgs : EventArgs
        {
            private Slider _slider;
            private int _slideValue;

            /// <summary>
            /// The slider.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Slider Slider
            {
                get
                {
                    return _slider;
                }
                set
                {
                    _slider = value;
                }
            }

            /// <summary>
            /// The slider value.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public int SlideValue
            {
                get
                {
                    return _slideValue;
                }
                set
                {
                    _slideValue = value;
                }
            }
        }


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ValueChangedCallbackDelegate(IntPtr slider, float slideValue);
        private EventHandlerWithReturnType<object, ValueChangedEventArgs, bool> _sliderValueChangedEventHandler;
        private ValueChangedCallbackDelegate _sliderValueChangedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool SlidingFinishedCallbackDelegate(IntPtr slider, float slideValue);
        private EventHandlerWithReturnType<object, SlidingFinishedEventArgs, bool> _sliderSlidingFinishedEventHandler;
        private SlidingFinishedCallbackDelegate _sliderSlidingFinishedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool MarkReachedCallbackDelegate(IntPtr slider, int slideValue);
        private EventHandlerWithReturnType<object, MarkReachedEventArgs, bool> _sliderMarkReachedEventHandler;
        private MarkReachedCallbackDelegate _sliderMarkReachedCallbackDelegate;

        /// <summary>
        /// An event emitted when the slider value changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, ValueChangedEventArgs, bool> ValueChanged
        {
            add
            {
                if (_sliderValueChangedEventHandler == null)
                {
                    _sliderValueChangedCallbackDelegate = (OnValueChanged);
                    ValueChangedSignal().Connect(_sliderValueChangedCallbackDelegate);
                }
                _sliderValueChangedEventHandler += value;
            }
            remove
            {
                _sliderValueChangedEventHandler -= value;
                if (_sliderValueChangedEventHandler == null && ValueChangedSignal().Empty() == false)
                {
                    ValueChangedSignal().Disconnect(_sliderValueChangedCallbackDelegate);
                }
            }
        }

        // Callback for Slider ValueChanged signal
        private bool OnValueChanged(IntPtr slider, float slideValue)
        {
            ValueChangedEventArgs e = new ValueChangedEventArgs();

            // Populate all members of "e" (ValueChangedEventArgs) with real page
            e.Slider = Slider.GetSliderFromPtr(slider);
            e.SlideValue = slideValue;

            if (_sliderValueChangedEventHandler != null)
            {
                //here we send all page to user event handlers
                return _sliderValueChangedEventHandler(this, e);
            }
            return false;
        }

        /// <summary>
        /// An event emitted when the sliding is finished.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, SlidingFinishedEventArgs, bool> SlidingFinished
        {
            add
            {
                if (_sliderSlidingFinishedEventHandler == null)
                {
                    _sliderSlidingFinishedCallbackDelegate = (OnSlidingFinished);
                    SlidingFinishedSignal().Connect(_sliderSlidingFinishedCallbackDelegate);
                }
                _sliderSlidingFinishedEventHandler += value;
            }
            remove
            {
                _sliderSlidingFinishedEventHandler -= value;
                if (_sliderSlidingFinishedEventHandler == null && SlidingFinishedSignal().Empty() == false)
                {
                    SlidingFinishedSignal().Disconnect(_sliderSlidingFinishedCallbackDelegate);
                }
            }
        }

        // Callback for Slider SlidingFinished signal
        private bool OnSlidingFinished(IntPtr slider, float slideValue)
        {
            SlidingFinishedEventArgs e = new SlidingFinishedEventArgs();

            // Populate all members of "e" (SlidingFinishedEventArgs) with real page
            e.Slider = Slider.GetSliderFromPtr(slider);
            e.SlideValue = slideValue;

            if (_sliderSlidingFinishedEventHandler != null)
            {
                //here we send all page to user event handlers
                return _sliderSlidingFinishedEventHandler(this, e);
            }
            return false;
        }

        /// <summary>
        /// An event emitted when the slider handle reaches a mark.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, MarkReachedEventArgs, bool> MarkReached
        {
            add
            {
                if (_sliderMarkReachedEventHandler == null)
                {
                    _sliderMarkReachedCallbackDelegate = (OnMarkReached);
                    MarkReachedSignal().Connect(_sliderMarkReachedCallbackDelegate);
                }
                _sliderMarkReachedEventHandler += value;
            }
            remove
            {
                _sliderMarkReachedEventHandler -= value;
                if (_sliderMarkReachedEventHandler == null && MarkReachedSignal().Empty() == false)
                {
                    MarkReachedSignal().Disconnect(_sliderMarkReachedCallbackDelegate);
                }
            }
        }

        // Callback for Slider MarkReached signal
        private bool OnMarkReached(IntPtr slider, int slideValue)
        {
            MarkReachedEventArgs e = new MarkReachedEventArgs();

            // Populate all members of "e" (MarkReachedEventArgs) with real page
            e.Slider = Slider.GetSliderFromPtr(slider);
            e.SlideValue = slideValue;

            if (_sliderMarkReachedEventHandler != null)
            {
                //here we send all page to user event handlers
                return _sliderMarkReachedEventHandler(this, e);
            }
            return false;
        }

        /// <summary>
        /// Gets the slider from the pointer.
        /// </summary>
        /// <param name="cPtr">The pointer of the slider.</param>
        /// <returns>The object of the slider type.</returns>
        internal static Slider GetSliderFromPtr(global::System.IntPtr cPtr)
        {
            Slider ret = new Slider(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal new class Property : global::System.IDisposable
        {
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;
            protected bool swigCMemOwn;

            internal Property(global::System.IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Property obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            //A Flag to check who called Dispose(). (By User or DisposeQueue)
            private bool isDisposeQueued = false;
            //A Flat to check if it is already disposed.
            protected bool disposed = false;

            ~Property()
            {
                if (!isDisposeQueued)
                {
                    isDisposeQueued = true;
                    DisposeQueue.Instance.Add(this);
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public void Dispose()
            {
                //Throw excpetion if Dispose() is called in separate thread.
                if (!Window.IsInstalled())
                {
                    throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
                }

                if (isDisposeQueued)
                {
                    Dispose(DisposeTypes.Implicit);
                }
                else
                {
                    Dispose(DisposeTypes.Explicit);
                    System.GC.SuppressFinalize(this);
                }
            }

            protected virtual void Dispose(DisposeTypes type)
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

                //Release your own unmanaged resources here.
                //You should not access any managed member here except static instance.
                //because the execution order of Finalizes is non-deterministic.

                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        NDalicPINVOKE.delete_Slider_Property(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }

                disposed = true;
            }

            internal Property() : this(NDalicPINVOKE.new_Slider_Property(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            internal static readonly int LOWER_BOUND = NDalicPINVOKE.Slider_Property_LOWER_BOUND_get();
            internal static readonly int UPPER_BOUND = NDalicPINVOKE.Slider_Property_UPPER_BOUND_get();
            internal static readonly int VALUE = NDalicPINVOKE.Slider_Property_VALUE_get();
            internal static readonly int TRACK_VISUAL = NDalicPINVOKE.Slider_Property_TRACK_VISUAL_get();
            internal static readonly int HANDLE_VISUAL = NDalicPINVOKE.Slider_Property_HANDLE_VISUAL_get();
            internal static readonly int PROGRESS_VISUAL = NDalicPINVOKE.Slider_Property_PROGRESS_VISUAL_get();
            internal static readonly int POPUP_VISUAL = NDalicPINVOKE.Slider_Property_POPUP_VISUAL_get();
            internal static readonly int POPUP_ARROW_VISUAL = NDalicPINVOKE.Slider_Property_POPUP_ARROW_VISUAL_get();
            internal static readonly int DISABLED_COLOR = NDalicPINVOKE.Slider_Property_DISABLED_COLOR_get();
            internal static readonly int VALUE_PRECISION = NDalicPINVOKE.Slider_Property_VALUE_PRECISION_get();
            internal static readonly int SHOW_POPUP = NDalicPINVOKE.Slider_Property_SHOW_POPUP_get();
            internal static readonly int SHOW_VALUE = NDalicPINVOKE.Slider_Property_SHOW_VALUE_get();
            internal static readonly int MARKS = NDalicPINVOKE.Slider_Property_MARKS_get();
            internal static readonly int SNAP_TO_MARKS = NDalicPINVOKE.Slider_Property_SNAP_TO_MARKS_get();
            internal static readonly int MARK_TOLERANCE = NDalicPINVOKE.Slider_Property_MARK_TOLERANCE_get();

        }

        /// <summary>
        /// Creates the slider control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Slider() : this(NDalicPINVOKE.Slider_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        internal Slider(Slider handle) : this(NDalicPINVOKE.new_Slider__SWIG_1(Slider.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Slider Assign(Slider handle)
        {
            Slider ret = new Slider(NDalicPINVOKE.Slider_Assign(swigCPtr, Slider.getCPtr(handle)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Downcasts an object handle to the slider.<br />
        /// If the handle points to a slider, then the downcast produces a valid handle.<br />
        /// If not, then the returned handle is left uninitialized.<br />
        /// </summary>
        /// <param name="handle">The handle to an object.</param>
        /// <returns>The handle to a slider or an uninitialized handle.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Slider DownCast(BaseHandle handle)
        {
            Slider ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as Slider;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SliderValueChangedSignal ValueChangedSignal()
        {
            SliderValueChangedSignal ret = new SliderValueChangedSignal(NDalicPINVOKE.Slider_ValueChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SliderValueChangedSignal SlidingFinishedSignal()
        {
            SliderValueChangedSignal ret = new SliderValueChangedSignal(NDalicPINVOKE.Slider_SlidingFinishedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SliderMarkReachedSignal MarkReachedSignal()
        {
            SliderMarkReachedSignal ret = new SliderMarkReachedSignal(NDalicPINVOKE.Slider_MarkReachedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The lower bound property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float LowerBound
        {
            get
            {
                float temp = 0.0f;
                GetProperty(Slider.Property.LOWER_BOUND).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.LOWER_BOUND, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The upper bound property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float UpperBound
        {
            get
            {
                float temp = 0.0f;
                GetProperty(Slider.Property.UPPER_BOUND).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.UPPER_BOUND, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The value property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Value
        {
            get
            {
                float temp = 0.0f;
                GetProperty(Slider.Property.VALUE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.VALUE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The track visual property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap TrackVisual
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(Slider.Property.TRACK_VISUAL).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.TRACK_VISUAL, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The handle visual property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap HandleVisual
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(Slider.Property.HANDLE_VISUAL).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.HANDLE_VISUAL, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The progress visual property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap ProgressVisual
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(Slider.Property.PROGRESS_VISUAL).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.PROGRESS_VISUAL, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The popup visual property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap PopupVisual
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(Slider.Property.POPUP_VISUAL).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.POPUP_VISUAL, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The popup arrow visual property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap PopupArrowVisual
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(Slider.Property.POPUP_ARROW_VISUAL).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.POPUP_ARROW_VISUAL, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The disable color property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 DisabledColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(Slider.Property.DISABLED_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.DISABLED_COLOR, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The value precision property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int ValuePrecision
        {
            get
            {
                int temp = 0;
                GetProperty(Slider.Property.VALUE_PRECISION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.VALUE_PRECISION, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The show popup property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool ShowPopup
        {
            get
            {
                bool temp = false;
                GetProperty(Slider.Property.SHOW_POPUP).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.SHOW_POPUP, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The show value property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool ShowValue
        {
            get
            {
                bool temp = false;
                GetProperty(Slider.Property.SHOW_VALUE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.SHOW_VALUE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The marks property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyArray Marks
        {
            get
            {
                Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
                GetProperty(Slider.Property.MARKS).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.MARKS, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The snap to marks property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool SnapToMarks
        {
            get
            {
                bool temp = false;
                GetProperty(Slider.Property.SNAP_TO_MARKS).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.SNAP_TO_MARKS, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The mark tolerance property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float MarkTolerance
        {
            get
            {
                float temp = 0.0f;
                GetProperty(Slider.Property.MARK_TOLERANCE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Slider.Property.MARK_TOLERANCE, new Tizen.NUI.PropertyValue(value));
            }
        }

    }

}