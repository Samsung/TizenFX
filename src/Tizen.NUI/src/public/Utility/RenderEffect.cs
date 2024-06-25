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
using System;

namespace Tizen.NUI
{
    /// <summary>
    /// View's optional render effect.
    /// Applications can apply RenderEffect as the example below :
    /// <code>
    /// 
    /// RenderEffect effect = RenderEffect.CreateBackgroundBlurEffect(20.0f);
    ///
    /// view.SetRenderEffect(effect);
    /// view.ClearRenderEffect();
    ///
    /// </code>
    /// Note that a view owns at most one render effect.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RenderEffect : BaseHandle
    {
        internal RenderEffect(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Create a background blur effect
        /// </summary>
        /// <remarks>
        /// Created RenderEffect is immutable.
        /// </remarks>
        /// <param name="blurRadius">The blur radius value. The unit is pixel for standard cases.</param>
        /// <returns>Background blur effect with given blur radius.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RenderEffect CreateBackgroundBlurEffect(float blurRadius)
        {
            return new BackgroundBlurEffect((uint)Math.Round(blurRadius, 0));
        }
    }


    /// <summary>
    /// Applications can create BackgroundBlurEffect as :
    /// <code>
    /// RenderEffect.CreateBackgroundBlurEffect(blurRadius);
    /// </code>
    [EditorBrowsable(EditorBrowsableState.Never)]
    sealed class BackgroundBlurEffect : RenderEffect
    {
        /// <summary>
        /// Create a BackgroundBlurEffect.
        /// The default values are:
        ///     uint  blurRadius = 5;
        /// </summary>
        internal BackgroundBlurEffect() : this(Interop.BackgroundBlurEffect.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create a BackgroundBlurEffect.
        /// </summary>
        /// <param name="blurRadius">Size of gaussian kernel, determines blur intensity.</param>
        internal BackgroundBlurEffect(uint blurRadius) : this(Interop.BackgroundBlurEffect.New(blurRadius), true)
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
