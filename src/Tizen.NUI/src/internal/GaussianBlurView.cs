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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{

    using System;
    using System.Runtime.InteropServices;


    internal class GaussianBlurView : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal GaussianBlurView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.GaussianBlurView.GaussianBlurView_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(GaussianBlurView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

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

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.GaussianBlurView.delete_GaussianBlurView(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }



        /// <since_tizen> 3 </since_tizen>
        public class FinishedEventArgs : EventArgs
        {
            private GaussianBlurView _gaussianBlurView;

            /// <since_tizen> 3 </since_tizen>
            public GaussianBlurView GaussianBlurView
            {
                get
                {
                    return _gaussianBlurView;
                }
                set
                {
                    _gaussianBlurView = value;
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FinishedEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, FinishedEventArgs> _gaussianFinishedEventHandler;
        private FinishedEventCallbackDelegate _gaussianFinishedEventCallbackDelegate;

        public event DaliEventHandler<object, FinishedEventArgs> Finished
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_gaussianFinishedEventHandler == null)
                    {
                        _gaussianFinishedEventHandler += value;

                        _gaussianFinishedEventCallbackDelegate = new FinishedEventCallbackDelegate(OnFinished);
                        this.FinishedSignal().Connect(_gaussianFinishedEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_gaussianFinishedEventHandler != null)
                    {
                        this.FinishedSignal().Disconnect(_gaussianFinishedEventCallbackDelegate);
                    }

                    _gaussianFinishedEventHandler -= value;
                }
            }
        }

        // Callback for GaussianBlurView FinishedSignal
        private void OnFinished(IntPtr data)
        {
            FinishedEventArgs e = new FinishedEventArgs();

            // Populate all members of "e" (FinishedEventArgs) with real data
            e.GaussianBlurView = Registry.GetManagedBaseHandleFromNativePtr(data) as GaussianBlurView;

            if (_gaussianFinishedEventHandler != null)
            {
                //here we send all data to user event handlers
                _gaussianFinishedEventHandler(this, e);
            }
        }

        public GaussianBlurView() : this(Interop.GaussianBlurView.GaussianBlurView_New__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public GaussianBlurView(uint numSamples, float blurBellCurveWidth, PixelFormat renderTargetPixelFormat, float downsampleWidthScale, float downsampleHeightScale, bool blurUserImage) : this(Interop.GaussianBlurView.GaussianBlurView_New__SWIG_1(numSamples, blurBellCurveWidth, (int)renderTargetPixelFormat, downsampleWidthScale, downsampleHeightScale, blurUserImage), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public GaussianBlurView(uint numSamples, float blurBellCurveWidth, PixelFormat renderTargetPixelFormat, float downsampleWidthScale, float downsampleHeightScale) : this(Interop.GaussianBlurView.GaussianBlurView_New__SWIG_2(numSamples, blurBellCurveWidth, (int)renderTargetPixelFormat, downsampleWidthScale, downsampleHeightScale), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public GaussianBlurView(GaussianBlurView handle) : this(Interop.GaussianBlurView.new_GaussianBlurView__SWIG_1(GaussianBlurView.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public GaussianBlurView Assign(GaussianBlurView ZoomView)
        {
            GaussianBlurView ret = new GaussianBlurView(Interop.GaussianBlurView.GaussianBlurView_Assign(swigCPtr, GaussianBlurView.getCPtr(ZoomView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static GaussianBlurView DownCast(BaseHandle handle)
        {
            GaussianBlurView ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as GaussianBlurView;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public new void Add(View child)
        {
            Interop.GaussianBlurView.GaussianBlurView_Add(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public new void Remove(View child)
        {
            Interop.GaussianBlurView.GaussianBlurView_Remove(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Activate()
        {
            Interop.GaussianBlurView.GaussianBlurView_Activate(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ActivateOnce()
        {
            Interop.GaussianBlurView.GaussianBlurView_ActivateOnce(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Deactivate()
        {
            Interop.GaussianBlurView.GaussianBlurView_Deactivate(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetUserImageAndOutputRenderTarget(Image inputImage, FrameBufferImage outputRenderTarget)
        {
            Interop.GaussianBlurView.GaussianBlurView_SetUserImageAndOutputRenderTarget(swigCPtr, Image.getCPtr(inputImage), FrameBufferImage.getCPtr(outputRenderTarget));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public int GetBlurStrengthPropertyIndex()
        {
            int ret = Interop.GaussianBlurView.GaussianBlurView_GetBlurStrengthPropertyIndex(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public FrameBufferImage GetBlurredRenderTarget()
        {
            FrameBufferImage ret = new FrameBufferImage(Interop.GaussianBlurView.GaussianBlurView_GetBlurredRenderTarget(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public new void SetBackgroundColor(Vector4 color)
        {
            Interop.GaussianBlurView.GaussianBlurView_SetBackgroundColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public new Vector4 GetBackgroundColor()
        {
            Vector4 ret = new Vector4(Interop.GaussianBlurView.GaussianBlurView_GetBackgroundColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public GaussianBlurViewSignal FinishedSignal()
        {
            GaussianBlurViewSignal ret = new GaussianBlurViewSignal(Interop.GaussianBlurView.GaussianBlurView_FinishedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
