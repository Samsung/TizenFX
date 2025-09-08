/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// Gaussian blur effect of a View.
    /// Applications can apply GaussianBlurEffect as the example below :
    /// <code>
    /// GaussianBlurEffect effect = new GaussianBlurEffect();
    /// view.SetRenderEffect(effect);
    /// </code>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GaussianBlurEffect : RenderEffect
    {
        internal GaussianBlurEffect(global::System.IntPtr cPtr) : base(cPtr)
        {
        }

        /// <summary>
        /// The property determines whether to render the effect only once or at every frame update.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool BlurOnce
        {
            get
            {
                bool blurOnce = Interop.GaussianBlurEffect.GetBlurOnce(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return blurOnce;
            }

            set
            {
                Interop.GaussianBlurEffect.SetBlurOnce(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void BlurFinishedEventCallbackType(IntPtr renderTask);
        private event EventHandler blurFinishedEventHandler;
        private BlurFinishedEventCallbackType blurFinishedCallback;

        /// <summary>
        /// Event when blur once finishes rendering. Does nothing when blur once is set to false(which redraws every frame).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Finished
        {
            add
            {
                if (blurFinishedEventHandler == null)
                {
                    blurFinishedCallback = OnFinished;
                    Interop.GaussianBlurEffect.FinishedSignalConnect(SwigCPtr, blurFinishedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                blurFinishedEventHandler += value;
            }
            remove
            {
                blurFinishedEventHandler -= value;
                if (blurFinishedEventHandler == null && blurFinishedCallback != null)
                {
                    Interop.GaussianBlurEffect.FinishedSignalDisconnect(SwigCPtr, blurFinishedCallback.ToHandleRef(this));
                    blurFinishedCallback = null;
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }

            }
        }

        private void OnFinished(IntPtr renderTask)
        {
            blurFinishedEventHandler?.Invoke(this, null);
        }

        /// <summary>
        /// The property is blur radius value.
        /// The unit is pixel, but the property is in float type since many other platforms use float for blur effect radius.
        /// </summary>
        /// <remarks>
        /// The blurRadius parameter is adjusted due to downscaling and kernel compression, resulting in a smaller effective value.
        /// This means the blur intensity changes in discrete steps rather than continuously, with the step size determined by (2 / downscale factor).
        /// For example, with a default BlurDownscaleFactor of 0.25, the step size is 8.
        /// To ensure proper functionality, a minimum blurRadius value of 2 steps is required, with intensity updates occurring at every step size increment.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BlurRadius
        {
            get
            {
                uint blurRadius = Interop.GaussianBlurEffect.GetBlurRadius(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (float)blurRadius;
            }

            set
            {
                Interop.GaussianBlurEffect.SetBlurRadius(SwigCPtr, (uint)Math.Round(value, 0));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The property downscales input texture's width and height to enhance performance.
        /// The value should be bigger than 0.0f and lower than 1.0f. Note that values near zero may ignore blur calculation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BlurDownscaleFactor
        {
            get
            {
                float downscaleFactor = Interop.GaussianBlurEffect.GetBlurDownscaleFactor(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return downscaleFactor;
            }

            set
            {
                Interop.GaussianBlurEffect.SetBlurDownscaleFactor(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Adds blur strength animation to the effect.
        /// Basically it is to animate blurring clear texture, but when starting value(fromValue) is bigger than the end value(toValue),
        /// it may show a reversed animation that instead clarifies blurred texture.
        /// </summary>
        /// <param name="animation">Animation instance to add blur strength animation.</param>
        /// <param name="alphaFunction">The alpha function to apply. If none, it will use animation's default alpha function.</param>
        /// <param name="timePeriod">Duration of animation. If none, it will use the animation's duration.</param>
        /// <param name="fromValue">Starting blur strength value of the animation. The value resides in range of [0,1].</param>
        /// <param name="toValue">End of blur strength value of the animation. The value resides in range of [0,1].</param>
        /// <exception cref="ArgumentNullException"> Thrown when the animation is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddBlurStrengthAnimation(Animation animation, AlphaFunction alphaFunction, TimePeriod timePeriod, float fromValue, float toValue)
        {
            if (animation == null) throw new ArgumentNullException(nameof(animation));

            Interop.GaussianBlurEffect.AddBlurStrengthAnimation(SwigCPtr, Animation.getCPtr(animation), AlphaFunction.getCPtr(alphaFunction), TimePeriod.getCPtr(timePeriod), fromValue, toValue);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Adds blur opacity animation to the effect.
        /// Basically it is to animate blurring clear texture, but when starting value(fromValue) is bigger than the end value(toValue),
        /// it may show a reversed animation that instead clarifies blurred texture.
        /// </summary>
        /// <param name="animation">Animation instance to add blur opacity animation.</param>
        /// <param name="alphaFunction">The alpha function to apply. If none, it will use animation's default alpha function.</param>
        /// <param name="timePeriod">Duration of animation. If none, it will use the animation's duration.</param>
        /// <param name="fromValue">Starting blur opacity value of the animation. The value resides in range of [0,1].</param>
        /// <param name="toValue">End of blur opacity value of the animation. The value resides in range of [0,1].</param>
        /// <exception cref="ArgumentNullException"> Thrown when the animation is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddBlurOpacityAnimation(Animation animation, AlphaFunction alphaFunction, TimePeriod timePeriod, float fromValue, float toValue)
        {
            if (animation == null) throw new ArgumentNullException(nameof(animation));

            Interop.GaussianBlurEffect.AddBlurOpacityAnimation(SwigCPtr, Animation.getCPtr(animation), AlphaFunction.getCPtr(alphaFunction), TimePeriod.getCPtr(timePeriod), fromValue, toValue);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
