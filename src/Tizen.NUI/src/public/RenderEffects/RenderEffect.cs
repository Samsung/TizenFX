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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// View's optional render effect.
    /// Applications can apply RenderEffect as the example below :
    /// <code>
    ///
    /// view.SetRenderEffect(RenderEffect.CreateBackgroundBlurEffect(20));
    /// view.ClearRenderEffect();
    ///
    /// </code>
    /// Note that a view owns at most one render effect.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RenderEffect : BaseHandle
    {
        /// <summary>
        /// Enumeration for selecting how the mask source interprets pixel data
        /// Alpha: Uses the alpha channel of the mask texture. (Default)
        /// Luminance: Converts RGB to grayscale and uses the luminance as mask value.
        /// </summary>
        public enum MaskMode
        {
            Alpha = 0,
            Luminance,
        }
        internal RenderEffect(global::System.IntPtr cPtr) : base(cPtr)
        {
        }

        /// <summary>
        /// Create a background blur effect
        /// </summary>
        /// <remarks>
        /// Created RenderEffect is immutable.
        /// </remarks>
        /// <param name="blurRadius">The blur radius value. The unit is pixel for standard cases.</param>
        /// <param name="blurOnce">Whether to blur once or always.</param>
        /// <returns>Background blur effect with given blur radius.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RenderEffect CreateBackgroundBlurEffect(float blurRadius, bool blurOnce=false)
        {
            return new RenderEffect(Interop.BackgroundBlurEffect.New((uint)Math.Round(blurRadius, 0), blurOnce));
        }

        /// <summary>
        /// Create a mask effect
        /// </summary>
        /// <remarks>
        /// Created RenderEffect is immutable.
        /// </remarks>
        /// <param name="control">The mask source control.</param>
        /// <returns>mask effect with given control.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RenderEffect CreateMaskEffect(View control)
        {
            return new RenderEffect(Interop.MaskEffect.New(control.SwigCPtr));
        }

        /// <summary>
        /// Create a mask effect
        /// </summary>
        /// <remarks>
        /// Created RenderEffect is immutable.
        /// </remarks>
        /// <param name="control">The mask source control.</param>
        /// <param name="maskMode">Defines pixel data type (alpha, luminance) used as the mask source.</param>
        /// <param name="positionX">The X Position of mask source.</param>
        /// <param name="positionY">The Y Position of mask source.</param>
        /// <param name="scaleX">The X Scale of mask source.</param>
        /// <param name="scaleY">The Y Scale of mask source.</param>
        /// <returns>mask effect with given control.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RenderEffect CreateMaskEffect(View control, MaskMode maskMode, float positionX = 0.0f, float positionY = 0.0f, float scaleX = 1.0f, float scaleY = 1.0f)
        {
            return new RenderEffect(Interop.MaskEffect.New(control.SwigCPtr, maskMode, positionX, positionY, scaleX, scaleY));
        }
    }
}
