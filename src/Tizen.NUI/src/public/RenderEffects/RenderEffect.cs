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
using System.ComponentModel;
using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// Enumeration for selecting how the mask source interprets pixel data
    /// Alpha: Uses the alpha channel of the mask texture. (Default)
    /// Luminance: Converts RGB to grayscale and uses the luminance as mask value.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum MaskEffectMode
    {
        Alpha = 0,
        Luminance,
    }

    /// <summary>
    /// View's optional render effect.
    /// Applications can apply RenderEffect as the example below :
    /// <code>
    /// BackgroundBlurEffect effect = RenderEffect.CreateBackgroundBlurEffect(20);
    /// view.SetRenderEffect(effect); // activates effect
    /// effect.Deactivate();
    /// effect.Activate();
    /// view.ClearRenderEffect(); // deactivates effect
    /// </code>
    /// Note that a view owns at most one render effect.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RenderEffect : BaseHandle
    {
        internal RenderEffect(global::System.IntPtr cPtr) : base(cPtr)
        {
        }

        /// <summary>
        /// Activates render effect
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Activate()
        {
            Interop.RenderEffect.Activate(SwigCPtr);
        }

        /// <summary>
        /// Deactivates render effect
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deactivate()
        {
            Interop.RenderEffect.Deactivate(SwigCPtr);
        }

        /// <summary>
        /// Create a background blur effect
        /// </summary>
        /// <param name="blurRadius">The blur radius value. The unit is pixel for standard cases.</param>
        /// <returns>Background blur effect with given blur radius.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackgroundBlurEffect CreateBackgroundBlurEffect(float blurRadius)
        {
            return new BackgroundBlurEffect(Interop.BackgroundBlurEffect.New((uint)Math.Round(blurRadius, 0)));
        }

        /// <summary>
        /// Create a mask effect
        /// </summary>
        /// <param name="control">The mask source control.</param>
        /// <returns>mask effect with given control.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MaskEffect CreateMaskEffect(View control)
        {
            return new MaskEffect(Interop.MaskEffect.New(control.SwigCPtr));
        }

        /// <summary>
        /// Create a mask effect
        /// </summary>
        /// <param name="control">The mask source control.</param>
        /// <param name="maskMode">Defines pixel data type (alpha, luminance) used as the mask source.</param>
        /// <param name="positionX">The X Position of mask source.</param>
        /// <param name="positionY">The Y Position of mask source.</param>
        /// <param name="scaleX">The X Scale of mask source.</param>
        /// <param name="scaleY">The Y Scale of mask source.</param>
        /// <returns>mask effect with given control.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MaskEffect CreateMaskEffect(View control, MaskEffectMode maskMode, float positionX = 0.0f, float positionY = 0.0f, float scaleX = 1.0f, float scaleY = 1.0f)
        {
            return new MaskEffect(Interop.MaskEffect.New(control.SwigCPtr, maskMode, positionX, positionY, scaleX, scaleY));
        }
    }
}
