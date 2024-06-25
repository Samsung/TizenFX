/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
    /// <summary>
    /// View's optional render effect. Inherit this class to define a new render effect.
    /// Applications can apply RenderEffect as the example below :
    /// <code>
    /// view.SetRenderEffect(DerivedRenderEffect::New());
    /// view.ClearRenderEffect();
    /// </code>
    /// Note that a view owns at most one render effect.
    /// </summary>
    public class RenderEffect : BaseHandle
    {
        internal RenderEffect(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }
    }

    public class BackgroundBlurEffect : RenderEffect
    {
        /// <summary>
        /// Create a BackgroundBlurEffect.
        /// The default values are:
        ///     float downscaleFactor = 0.4f;
        ///     uint  blurRadius = 5;
        ///     float bellCurveWidth = 1.5f;
        /// </summary>
        public BackgroundBlurEffect() : this(Interop.BackgroundBlurEffect.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create a BackgroundBlurEffect.
        /// </summary>
        /// <param name="downscaleFactor"> A value out of 0 to 1, defines input texture downscaling for faster computation.</param>
        /// <param name="blurRadius">Size of gaussian kernel, determines blur intensity.</param>
        /// <param name="bellCurveWidth">Width of gaussian kernel, determines blur intensity.</param>
        public BackgroundBlurEffect(float downscaleFactor, uint blurRadius, float bellCurveWidth) : this(Interop.BackgroundBlurEffect.New(downscaleFactor, blurRadius, bellCurveWidth), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal BackgroundBlurEffect(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.BackgroundBlurEffect.Delete(swigCPtr);
        }
  }
}
