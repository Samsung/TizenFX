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
        private WeakReference<View> _ownerView;

        private static int aliveCount;

        internal void SetOwnerView(View view)
        {
            if (_ownerView != null)
            {
                if (!_ownerView.Equals(view) && _ownerView.TryGetTarget(out View previousTarget) && previousTarget != null)
                {
                    previousTarget.ClearRenderEffect(false);
                }
            }
            _ownerView = view ? new WeakReference<View>(view) : null;
        }

        internal RenderEffect(global::System.IntPtr cPtr) : base(cPtr)
        {
            ++aliveCount;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if ((_ownerView != null) && _ownerView.TryGetTarget(out View target) && target != null)
            {
                target.ClearRenderEffect();
                _ownerView = null;
            }

            --aliveCount;

            base.Dispose(type);
        }

        /// <summary>
        /// Gets the number of currently alived RenderEffect object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int AliveCount => aliveCount;

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
        /// Refreshes render effect
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Refresh()
        {
            Interop.RenderEffect.Refresh(SwigCPtr);
        }

        /// <summary>
        /// Check whether effect is activated or not.
        /// </summary>
        /// <returns>True if effect is activated, False otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsActivated()
        {
            return Interop.RenderEffect.IsActivated(SwigCPtr);
        }

        /// <summary>
        /// Create a background blur effect
        /// </summary>
        /// <param name="blurRadius">The blur radius value. The unit is pixel for standard cases.</param>
        /// <returns>Background blur effect with given blur radius.</returns>
        /// <remarks>
        /// The blurRadius parameter is adjusted due to downscaling and kernel compression, resulting in a smaller effective value.
        /// This means the blur intensity changes in discrete steps rather than continuously, with the step size determined by (2 / downscale factor).
        /// For example, with a default BlurDownscaleFactor of 0.25, the step size is 8.
        /// To ensure proper functionality, a minimum blurRadius value of 2 steps is required, with intensity updates occurring at every step size increment.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackgroundBlurEffect CreateBackgroundBlurEffect(float blurRadius)
        {
            return new BackgroundBlurEffect(Interop.BackgroundBlurEffect.New((uint)Math.Round(blurRadius, 0)));
        }

        /// <summary>
        /// Create a blur effect
        /// </summary>
        /// <param name="blurRadius">The blur radius value. The unit is pixel for standard cases.</param>
        /// <returns>Blur effect with given blur radius.</returns>
        /// <remarks>
        /// The blurRadius parameter is adjusted due to downscaling and kernel compression, resulting in a smaller effective value.
        /// This means the blur intensity changes in discrete steps rather than continuously, with the step size determined by (2 / downscale factor).
        /// For example, with a default BlurDownscaleFactor of 0.25, the step size is 8.
        /// To ensure proper functionality, a minimum blurRadius value of 2 steps is required, with intensity updates occurring at every step size increment.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GaussianBlurEffect CreateGaussianBlurEffect(float blurRadius)
        {
            return new GaussianBlurEffect(Interop.GaussianBlurEffect.New((uint)Math.Round(blurRadius, 0)));
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
