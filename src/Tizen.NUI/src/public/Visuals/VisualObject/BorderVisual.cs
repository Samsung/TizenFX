// Copyright (c) 2024 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Tizen.NUI.Visuals
{
    /// <summary>
    /// Simple visual to render a solid border.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BorderVisual : VisualBase
    {
        #region Constructor
        /// <summary>
        /// Creates an visual object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BorderVisual() : this(Interop.VisualObject.VisualObjectNew(), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal BorderVisual(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal BorderVisual(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
            Type = (int)Tizen.NUI.Visual.Type.Border;
        }
        #endregion

        #region Visual Properties
        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.Color BorderColor
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.BorderVisualProperty.Color, value);
            }
            get
            {
                Tizen.NUI.Color ret = new Tizen.NUI.Color();
                using (var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.BorderVisualProperty.Color))
                {
                    propertyValue?.Get(ret);
                }
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the width of the border (in pixels).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BorderWidth
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.BorderVisualProperty.Size, value);
            }
            get
            {
                float ret = 0.0f;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.BorderVisualProperty.Size);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets whether the anti-aliasing of the border is required. default is false.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AntiAliasing
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.BorderVisualProperty.AntiAliasing, value);
            }
            get
            {
                bool ret = false;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.BorderVisualProperty.AntiAliasing);
                propertyValue?.Get(out ret);
                return ret;
            }
        }
        #endregion
    }
}