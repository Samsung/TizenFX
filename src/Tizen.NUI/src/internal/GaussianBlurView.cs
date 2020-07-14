/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// GaussianBlurView is a class for applying a render process that blurs an image.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GaussianBlurView : View
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GaussianBlurViewProperty = BindableProperty.Create(nameof(BlurStrength), typeof(float), typeof(GaussianBlurView), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var gaussianBlurView = (GaussianBlurView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(gaussianBlurView.swigCPtr, gaussianBlurView.GetBlurStrengthPropertyIndex(), new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var gaussianBlurView = (GaussianBlurView)bindable;
            float temp;
            Tizen.NUI.Object.GetProperty(gaussianBlurView.swigCPtr, gaussianBlurView.GetBlurStrengthPropertyIndex()).Get(out temp);
            return temp;
        });
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal GaussianBlurView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.GaussianBlurView.GaussianBlurView_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(GaussianBlurView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.GaussianBlurView.delete_GaussianBlurView(swigCPtr);
        }

        /// <summary>
        /// Dispose GaussianBlurView and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (_finishedCallback != null)
            {
                FinishedSignal().Disconnect(_finishedCallback);
            }

            base.Dispose(type);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FinishedCallbackType(IntPtr application);
        private DaliEventHandler<object, EventArgs> _finishedEventHandler;
        private FinishedCallbackType _finishedCallback;

        /// <summary>
        /// If ActivateOnce has been called, then connect to this signal to be notified when the target actor has been rendered.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, EventArgs> Finished
        {
            add
            {
                // Restricted to only one listener
                if (_finishedEventHandler == null)
                {
                    _finishedCallback = new FinishedCallbackType(OnFinished);
                    FinishedSignal().Connect(_finishedCallback);
                }
                _finishedEventHandler += value;
            }

            remove
            {
                _finishedEventHandler -= value;

                if (_finishedEventHandler == null && FinishedSignal().Empty() == false)
                {
                    FinishedSignal().Disconnect(_finishedCallback);
                }
            }
        }

        // Callback for GaussianBlurView FinishedSignal
        private void OnFinished(IntPtr data)
        {
            EventArgs e = new EventArgs();

            if (_finishedEventHandler != null)
            {
                //here we send all data to user event handlers
                _finishedEventHandler(this, e);
            }
        }

        /// <summary>
        /// The BlurStrength property. A value of 0.0 is zero blur and 1.0 is full blur. Default is 1.0.
        /// if you set the blur to 0.0, the result will be no blur BUT the internal rendering will still be happening.
        /// If you wish to turn the blur off, you should remove the GaussianBlurView object from the window also.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BlurStrength
        {
            get
            {
                return (float)GetValue(GaussianBlurViewProperty);
            }
            set
            {
                SetValue(GaussianBlurViewProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GaussianBlurView() : this(Interop.GaussianBlurView.GaussianBlurView_New__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="numSamples">The size of the Gaussian blur kernel (number of samples in horizontal / vertical blur directions)</param>
        /// <param name="blurBellCurveWidth">
        /// The constant controlling the Gaussian function, must be > 0.0. Controls the width of the bell curve, i.e. the look of the blur and also indirectly
        /// the amount of blurriness Smaller numbers for a tighter curve. Useful values in the range [0.5..3.0] - near the bottom of that range the curve is weighted heavily towards
        /// the centre pixel of the kernel (so there won't be much blur), near the top of that range the pixels have nearly equal weighting (closely approximating a box filter
        /// therefore). Values close to zero result in the bell curve lying almost entirely within a single pixel, in other words there will be basically no blur as neighbouring pixels
        /// have close to zero weights.
        /// </param>
        /// <param name="renderTargetPixelFormat">The pixel format of the render targets we are using to perform the blur.</param>
        /// <param name="downsampleWidthScale">
        ///  width scale factor applied during the blur process, scaling the size of the source image to the size of the final blurred image output.
        ///  Useful for downsampling - trades visual quality for processing speed. A value of 1.0f results in no scaling applied.
        /// </param>
        /// <param name="downsampleHeightScale">
        /// The height scale factor applied during the blur process, scaling the size of the source image to the size of the final blurred image output.
        /// Useful for downsampling - trades visual quality for processing speed. A value of 1.0f results in no scaling applied.
        /// </param>
        /// <param name="blurUserImage">
        /// If this is set to true, the GaussianBlurView object will operate in a special mode that allows the user to blur an image of their choice. See
        /// SetUserImageAndOutputRenderTarget().
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GaussianBlurView(uint numSamples, float blurBellCurveWidth, PixelFormat renderTargetPixelFormat, float downsampleWidthScale, float downsampleHeightScale, bool blurUserImage) : this(Interop.GaussianBlurView.GaussianBlurView_New__SWIG_1(numSamples, blurBellCurveWidth, (int)renderTargetPixelFormat, downsampleWidthScale, downsampleHeightScale, blurUserImage), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GaussianBlurView(GaussianBlurView handle) : this(Interop.GaussianBlurView.new_GaussianBlurView__SWIG_1(GaussianBlurView.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Start rendering the GaussianBlurView. Must be called after you Add() it to the window.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Activate()
        {
            Interop.GaussianBlurView.GaussianBlurView_Activate(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Render the GaussianBlurView once.
        /// Must be called after you Add() it to the window.
        /// Listen to the Finished signal to determine when the rendering has completed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ActivateOnce()
        {
            Interop.GaussianBlurView.GaussianBlurView_ActivateOnce(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stop rendering the GaussianBlurView. Must be called after you Remove() it from the window.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deactivate()
        {
            Interop.GaussianBlurView.GaussianBlurView_Deactivate(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private int GetBlurStrengthPropertyIndex()
        {
            int ret = Interop.GaussianBlurView.GaussianBlurView_GetBlurStrengthPropertyIndex(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        internal void SetBackgroundColor(Vector4 color)
        {
            Interop.GaussianBlurView.GaussianBlurView_SetBackgroundColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector4 GetBackgroundColor()
        {
            Vector4 ret = new Vector4(Interop.GaussianBlurView.GaussianBlurView_GetBackgroundColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private GaussianBlurViewSignal FinishedSignal()
        {
            GaussianBlurViewSignal ret = new GaussianBlurViewSignal(Interop.GaussianBlurView.GaussianBlurView_FinishedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetUserImageAndOutputRenderTarget(Texture inputTexture, FrameBuffer outputRenderTarget)
        {
            Interop.GaussianBlurView.GaussianBlurView_SetUserImageAndOutputRenderTarget(swigCPtr, Texture.getCPtr(inputTexture), FrameBuffer.getCPtr(outputRenderTarget));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
