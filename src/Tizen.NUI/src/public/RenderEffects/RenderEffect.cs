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
    /// view.SetRenderEffect(RenderEffect.CreateBackgroundBlurEffect(20));
    /// view.ClearRenderEffect();
    ///
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
    }
}
