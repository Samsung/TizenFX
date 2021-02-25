/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.UIComponents
{
    /// <summary>
    /// The ProgressBar is a control to give the user an indication of the progress of an operation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// This will be deprecated
    [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ProgressBar : View
    {
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProgressValueProperty = BindableProperty.Create(nameof(ProgressValue), typeof(float), typeof(ProgressBar), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var progressBar = (ProgressBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.ProgressValue, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var progressBar = (ProgressBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.ProgressValue).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SecondaryProgressValueProperty = BindableProperty.Create(nameof(SecondaryProgressValue), typeof(float), typeof(ProgressBar), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var progressBar = (ProgressBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.SecondaryProgressValue, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var progressBar = (ProgressBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.SecondaryProgressValue).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndeterminateProperty = BindableProperty.Create(nameof(Indeterminate), typeof(bool), typeof(ProgressBar), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var progressBar = (ProgressBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.INDETERMINATE, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var progressBar = (ProgressBar)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.INDETERMINATE).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackVisualProperty = BindableProperty.Create(nameof(TrackVisual), typeof(PropertyMap), typeof(ProgressBar), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var progressBar = (ProgressBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.TrackVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var progressBar = (ProgressBar)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.TrackVisual).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProgressVisualProperty = BindableProperty.Create(nameof(ProgressVisual), typeof(PropertyMap), typeof(ProgressBar), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var progressBar = (ProgressBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.ProgressVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var progressBar = (ProgressBar)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.ProgressVisual).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SecondaryProgressVisualProperty = BindableProperty.Create(nameof(SecondaryProgressVisual), typeof(PropertyMap), typeof(ProgressBar), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var progressBar = (ProgressBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.SecondaryProgressVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var progressBar = (ProgressBar)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.SecondaryProgressVisual).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndeterminateVisualProperty = BindableProperty.Create(nameof(IndeterminateVisual), typeof(PropertyMap), typeof(ProgressBar), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var progressBar = (ProgressBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.IndeterminateVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var progressBar = (ProgressBar)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.IndeterminateVisual).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndeterminateVisualAnimationProperty = BindableProperty.Create(nameof(IndeterminateVisualAnimation), typeof(PropertyArray), typeof(ProgressBar), new PropertyArray(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var progressBar = (ProgressBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.IndeterminateVisualAnimation, new Tizen.NUI.PropertyValue((PropertyArray)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var progressBar = (ProgressBar)bindable;
            Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
            Tizen.NUI.Object.GetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.IndeterminateVisualAnimation).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelVisualProperty = BindableProperty.Create(nameof(LabelVisual), typeof(PropertyMap), typeof(ProgressBar), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var progressBar = (ProgressBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.LabelVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var progressBar = (ProgressBar)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty((HandleRef)progressBar.SwigCPtr, ProgressBar.Property.LabelVisual).Get(temp);
            return temp;
        }));

        private EventHandler<ValueChangedEventArgs> _progressBarValueChangedEventHandler;
        private ValueChangedCallbackDelegate _progressBarValueChangedCallbackDelegate;

        /// <summary>
        /// Creates the ProgressBar.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProgressBar() : this(Interop.ProgressBar.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal ProgressBar(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ValueChangedCallbackDelegate(IntPtr progressBar, float progressValue, float secondaryProgressValue);

        /// <summary>
        /// The event is sent when the ProgressBar value changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ValueChangedEventArgs> ValueChanged
        {
            add
            {
                if (_progressBarValueChangedEventHandler == null)
                {
                    _progressBarValueChangedCallbackDelegate = (OnValueChanged);
                    ProgressBarValueChangedSignal valueChanged = ValueChangedSignal();
                    valueChanged?.Connect(_progressBarValueChangedCallbackDelegate);
                    valueChanged?.Dispose();
                }
                _progressBarValueChangedEventHandler += value;
            }
            remove
            {
                _progressBarValueChangedEventHandler -= value;
                ProgressBarValueChangedSignal valueChanged = ValueChangedSignal();
                if (_progressBarValueChangedEventHandler == null && valueChanged.Empty() == false)
                {
                    valueChanged?.Disconnect(_progressBarValueChangedCallbackDelegate);
                }
                valueChanged?.Dispose();
            }
        }

        /// <summary>
        /// The progress value of the progress bar, the progress runs from 0 to 1.<br />
        /// If the value is set to 0, then the progress bar will be set to beginning.<br />
        /// If the value is set to 1, then the progress bar will be set to end.<br />
        /// Any value outside the range is ignored.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ProgressValue
        {
            get
            {
                return (float)GetValue(ProgressValueProperty);
            }
            set
            {
                SetValue(ProgressValueProperty, value);
            }
        }

        /// <summary>
        /// The secondary progress value of the progress bar, the secondary progress runs from 0 to 1.<br />
        /// Optional. If not supplied, the default is 0.<br />
        /// If the value is set to 0, then the progress bar will be set secondary progress to beginning.<br />
        /// If the value is set to 1, then the progress bar will be set secondary progress to end.<br />
        /// Any value outside of the range is ignored.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SecondaryProgressValue
        {
            get
            {
                return (float)GetValue(SecondaryProgressValueProperty);
            }
            set
            {
                SetValue(SecondaryProgressValueProperty, value);
            }
        }

        /// <summary>
        /// Sets the progress bar as \e indeterminate state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Indeterminate
        {
            get
            {
                return (bool)GetValue(IndeterminateProperty);
            }
            set
            {
                SetValue(IndeterminateProperty, value);
            }
        }

        /// <summary>
        /// The track visual value of progress bar, it's full progress area, and it's shown behind the PROGRESS_VISUAL.<br />
        /// Optional. If not supplied, the default track visual will be shown.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap TrackVisual
        {
            get
            {
                return (PropertyMap)GetValue(TrackVisualProperty);
            }
            set
            {
                SetValue(TrackVisualProperty, value);
            }
        }

        /// <summary>
        /// The progress visual value of the progress bar, the size of the progress visual is changed based on the PROGRESS_VALUE.<br />
        /// Optional. If not supplied, then the default progress visual will be shown.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap ProgressVisual
        {
            get
            {
                return (PropertyMap)GetValue(ProgressVisualProperty);
            }
            set
            {
                SetValue(ProgressVisualProperty, value);
            }
        }

        /// <summary>
        /// The secondary progress visual of the progress bar, the size of the secondary progress visual is changed based on the SECONDARY_PROGRESS_VALUE.<br />
        /// Optional. If not supplied, then the secondary progress visual will not be shown.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap SecondaryProgressVisual
        {
            get
            {
                return (PropertyMap)GetValue(SecondaryProgressVisualProperty);
            }
            set
            {
                SetValue(SecondaryProgressVisualProperty, value);
            }
        }

        /// <summary>
        /// The indeterminate visual of the progress bar.<br />
        /// Optional. If not supplied, then the default indeterminate visual will be shown.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap IndeterminateVisual
        {
            get
            {
                return (PropertyMap)GetValue(IndeterminateVisualProperty);
            }
            set
            {
                SetValue(IndeterminateVisualProperty, value);
            }
        }

        /// <summary>
        /// The transition data for the indeterminate visual animation.<br />
        /// Optional. If not supplied, then the default animation will be played.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyArray IndeterminateVisualAnimation
        {
            get
            {
                return (PropertyArray)GetValue(IndeterminateVisualAnimationProperty);
            }
            set
            {
                SetValue(IndeterminateVisualAnimationProperty, value);
            }
        }

        /// <summary>
        /// The label visual of the progress bar.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap LabelVisual
        {
            get
            {
                return (PropertyMap)GetValue(LabelVisualProperty);
            }
            set
            {
                SetValue(LabelVisualProperty, value);
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ProgressBar obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal ProgressBarValueChangedSignal ValueChangedSignal()
        {
            ProgressBarValueChangedSignal ret = new ProgressBarValueChangedSignal(Interop.ProgressBar.ValueChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To dispose the ProgressBar instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (this != null && _progressBarValueChangedCallbackDelegate != null)
            {
                ProgressBarValueChangedSignal valueChanged = ValueChangedSignal();
                valueChanged?.Disconnect(_progressBarValueChangedCallbackDelegate);
                valueChanged?.Dispose();
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ProgressBar.DeleteProgressBar(swigCPtr);
        }

        // Callback for ProgressBar ValueChanged signal
        private void OnValueChanged(IntPtr progressBar, float progressValue, float secondaryProgressValue)
        {
            ValueChangedEventArgs e = new ValueChangedEventArgs();

            // Populate all members of "e" (ValueChangedEventArgs) with real page
            e.ProgressBar = Registry.GetManagedBaseHandleFromNativePtr(progressBar) as ProgressBar;
            e.ProgressValue = progressValue;
            e.SecondaryProgressValue = secondaryProgressValue;

            if (_progressBarValueChangedEventHandler != null)
            {
                _progressBarValueChangedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Event arguments that passed via the ValueChangedEventArgs.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class ValueChangedEventArgs : EventArgs
        {
            private ProgressBar _progressBar;
            private float _progressValue;
            private float _secondaryProgressValue;

            /// <summary>
            /// ProgressBar
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ProgressBar ProgressBar
            {
                get
                {
                    return _progressBar;
                }
                set
                {
                    _progressBar = value;
                }
            }

            /// <summary>
            /// The progress value of the progress bar, the progress runs from 0 to 1.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            public float ProgressValue
            {
                get
                {
                    return _progressValue;
                }
                set
                {
                    _progressValue = value;
                }
            }

            /// <summary>
            /// The secondary progress value of the progress bar, the secondary progress runs from 0 to 1.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            public float SecondaryProgressValue
            {
                get
                {
                    return _secondaryProgressValue;
                }
                set
                {
                    _secondaryProgressValue = value;
                }
            }

        }

        internal new class Property
        {
            internal static readonly int ProgressValue = Interop.ProgressBar.ProgressValueGet();
            internal static readonly int SecondaryProgressValue = Interop.ProgressBar.SecondaryProgressValueGet();
            internal static readonly int INDETERMINATE = Interop.ProgressBar.IndeterminateGet();
            internal static readonly int TrackVisual = Interop.ProgressBar.TrackVisualGet();
            internal static readonly int ProgressVisual = Interop.ProgressBar.ProgressVisualGet();
            internal static readonly int SecondaryProgressVisual = Interop.ProgressBar.SecondaryProgressVisualGet();
            internal static readonly int IndeterminateVisual = Interop.ProgressBar.IndeterminateVisualGet();
            internal static readonly int IndeterminateVisualAnimation = Interop.ProgressBar.IndeterminateVisualAnimationGet();
            internal static readonly int LabelVisual = Interop.ProgressBar.LabelVisualGet();
        }
    }
}
