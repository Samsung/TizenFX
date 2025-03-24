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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents.VectorGraphics
{
    /// <summary>
    /// CanvasView is a class for displaying vector primitives.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class CanvasView : View
    {
        private List<Drawable> drawables; //The list of added drawables

        /// <summary>
        /// ViewBoxProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ViewBoxProperty = null;
        internal static void SetInternalViewBoxProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (CanvasView)bindable;
            if (newValue != null)
            {
                instance.InternalViewBox = (Tizen.NUI.Size2D)newValue;
            }
        }
        internal static object GetInternalViewBoxProperty(BindableObject bindable)
        {
            var instance = (CanvasView)bindable;
            return instance.InternalViewBox;
        }

        /// <summary>
        /// SynchronousLoadingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronousLoadingProperty = null;
        internal static void SetInternalSynchronousLoadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (CanvasView)bindable;
            if (newValue != null)
            {
                instance.InternalSynchronousLoading = (bool)newValue;
            }
        }
        internal static object GetInternalSynchronousLoadingProperty(BindableObject bindable)
        {
            var instance = (CanvasView)bindable;
            return instance.InternalSynchronousLoading;
        }

        /// <summary>
        /// RasterizationRequestManuallyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RasterizationRequestManuallyProperty = null;
        internal static void SetInternalRasterizationRequestManuallyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (CanvasView)bindable;
            if (newValue != null)
            {
                instance.InternalRasterizationRequestManually = (bool)newValue;
            }
        }
        internal static object GetInternalRasterizationRequestManuallyProperty(BindableObject bindable)
        {
            var instance = (CanvasView)bindable;
            return instance.InternalRasterizationRequestManually;
        }

        static CanvasView()
        {
            if (NUIApplication.IsUsingXaml)
            {
                ViewBoxProperty = BindableProperty.Create(nameof(ViewBox), typeof(Tizen.NUI.Size2D), typeof(CanvasView), null,
                  propertyChanged: SetInternalViewBoxProperty, defaultValueCreator: GetInternalViewBoxProperty);
                SynchronousLoadingProperty = BindableProperty.Create(nameof(SynchronousLoading), typeof(bool), typeof(CanvasView), true,
                  propertyChanged: SetInternalSynchronousLoadingProperty, defaultValueCreator: GetInternalSynchronousLoadingProperty);
                RasterizationRequestManuallyProperty = BindableProperty.Create(nameof(RasterizationRequestManually), typeof(bool), typeof(CanvasView), false,
                  propertyChanged: SetInternalRasterizationRequestManuallyProperty, defaultValueCreator: GetInternalRasterizationRequestManuallyProperty);
            }
        }

        /// <summary>
        /// Creates an initialized CanvasView.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public CanvasView() : this(Interop.CanvasView.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an initialized CanvasView.
        /// </summary>
        /// <param name="viewBox">The size of viewbox.</param>
        /// <exception cref="ArgumentNullException"> Thrown when viewBox is null. </exception>
        /// <since_tizen> 9 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA2000: Dispose objects before losing scope", Justification = "It does not have dispose ownership.")]
        public CanvasView(Size2D viewBox) : this(viewBox == null ? throw new ArgumentNullException(nameof(viewBox)) : Interop.CanvasView.New(Uint16Pair.getCPtr(new Uint16Pair((uint)viewBox.Width, (uint)viewBox.Height))), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal CanvasView(global::System.IntPtr cPtr, bool shown = true) : base(cPtr, shown)
        {
            drawables = new List<Drawable>();
            if (!shown)
            {
                SetVisible(false);
            }
        }

        /// <summary>
        /// You can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                drawables.Clear();
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CanvasView.DeleteCanvasView(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The viewbox of the CanvasView.
        /// The viewbox means the size of CanvasView's internal space.
        /// If the size of the viewbox is larger than the size of the CanvasView, the shapes are displayed smaller than the specified size.
        /// The default value of the viewbox is the same as the size of the canvasview.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Size2D ViewBox
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ViewBoxProperty) as Size2D;
                }
                else
                {
                    return InternalViewBox;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ViewBoxProperty, value);
                }
                else
                {
                    InternalViewBox = value;
                }
                NotifyPropertyChanged();
            }
        }

        private Size2D InternalViewBox
        {
            get
            {
                Size2D retVal = new Size2D(0, 0);
                PropertyValue viewBoxPropertyValue = GetProperty(Interop.CanvasView.PropertyViewBoxGet());
                viewBoxPropertyValue?.Get(retVal);
                viewBoxPropertyValue?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.CanvasView.PropertyViewBoxGet(), setVal);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                setVal?.Dispose();
            }
        }

        /// <summary>
        /// Whether we rasterize CanvasView synchronously or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SynchronousLoading
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(SynchronousLoadingProperty);
                }
                else
                {
                    return InternalSynchronousLoading;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SynchronousLoadingProperty, value);
                }
                else
                {
                    InternalSynchronousLoading = value;
                }
                NotifyPropertyChanged();
            }
        }

        private bool InternalSynchronousLoading
        {
            get
            {
                bool retVal = true;
                PropertyValue synchronousLoadingPropertyValue = GetProperty(Interop.CanvasView.PropertySynchronousLoadingGet());
                synchronousLoadingPropertyValue?.Get(out retVal);
                synchronousLoadingPropertyValue?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.CanvasView.PropertySynchronousLoadingGet(), setVal);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                setVal?.Dispose();
            }
        }

        /// <summary>
        /// Whether we rasterize CanvasView manually or not.
        /// </summary>
        /// <remarks>
        /// If true, need to call <see cref="RequestRasterization()"/> to rasterize CanvasView.
        /// If false, CanvasView will be rasterized automatically even if we don't call <see cref="RequestRasterization()"/>.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RasterizationRequestManually
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(RasterizationRequestManuallyProperty);
                }
                else
                {
                    return InternalRasterizationRequestManually;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RasterizationRequestManuallyProperty, value);
                }
                else
                {
                    InternalRasterizationRequestManually = value;
                }
                NotifyPropertyChanged();
            }
        }

        private bool InternalRasterizationRequestManually
        {
            get
            {
                bool retVal = false;
                PropertyValue rasterizationRequestManuallyValue = GetProperty(Interop.CanvasView.PropertyRasterizationRequestManuallyGet());
                rasterizationRequestManuallyValue?.Get(out retVal);
                rasterizationRequestManuallyValue?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(Interop.CanvasView.PropertyRasterizationRequestManuallyGet(), setVal);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                setVal?.Dispose();
            }
        }

        /// <summary>
        /// Add drawable object to the CanvasView.
        /// This method is similar to registration. The added shape is drawn on the inner canvas.
        /// </summary>
        /// <param name="drawable">Drawable object</param>
        /// <exception cref="ArgumentNullException"> Thrown when drawable is null. </exception>
        /// <since_tizen> 9 </since_tizen>
        public void AddDrawable(Drawable drawable)
        {
            if (drawable == null)
            {
                throw new ArgumentNullException(nameof(drawable));
            }
            Interop.CanvasView.AddDrawable(View.getCPtr(this), BaseHandle.getCPtr(drawable));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            if (!drawables.Contains(drawable))
            {
                drawables.Add(drawable);
            }
        }

        /// <summary>
        /// Remove drawable object to the CanvasView.
        /// This method is similar to deregistration.
        /// </summary>
        /// <param name="drawable">Drawable object</param>
        /// <exception cref="ArgumentNullException"> Thrown when drawable is null. </exception>
        /// <since_tizen> 9 </since_tizen>
        public void RemoveDrawable(Drawable drawable)
        {
            if (drawable == null)
            {
                throw new ArgumentNullException(nameof(drawable));
            }
            Interop.CanvasView.RemoveDrawable(View.getCPtr(this), BaseHandle.getCPtr(drawable));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            drawables.Remove(drawable);
        }

        /// <summary>
        /// Remove all drawable objects added to the CanvasView.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void RemoveAllDrawables()
        {
            Interop.CanvasView.RemoveAllDrawables(View.getCPtr(this));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            drawables.Clear();
        }

        /// <summary>
        /// Reqeust rasterization manually to the CanvasView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RequestRasterization()
        {
            Interop.CanvasView.RequestRasterization(View.getCPtr(this));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
