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

namespace Tizen.NUI
{
    /// <summary>
    /// Mask effect of a View.
    /// <note>
    /// MaskEffect uses the target's camera to render both target and source.<br />
    /// To apply the mask correctly, align the source's size and position with the target.<br />
    /// Use 'targetMaskOnce' / 'sourceMaskOnce' to skip re-rendering static inputs.<br />
    /// </note>
    /// Applications can apply MaskEffect as the example below :
    /// <code>
    /// MaskEffect effect = new MaskEffect();
    /// view.SetRenderEffect(effect);
    /// </code>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MaskEffect : RenderEffect
    {
        internal MaskEffect(global::System.IntPtr cPtr) : base(cPtr)
        {
        }

        /// <summary>
        /// The property determines whether the target should be rendered once or every frame.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TargetMaskOnce
        {
            get
            {
                bool targetMaskOnce = Interop.MaskEffect.GetTargetMaskOnce(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return targetMaskOnce;
            }

            set
            {
                Interop.MaskEffect.SetTargetMaskOnce(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The property determines whether the source should be rendered once or every frame.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SourceMaskOnce
        {
            get
            {
                bool sourceMaskOnce = Interop.MaskEffect.GetSourceMaskOnce(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return sourceMaskOnce;
            }

            set
            {
                Interop.MaskEffect.SetSourceMaskOnce(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }
    }
}
