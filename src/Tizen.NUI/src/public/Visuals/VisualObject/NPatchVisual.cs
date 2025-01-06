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
    /// The visual which can display an n-patch image resource.
    /// It will be used when we want to display n-patch image, border only n-patch, or make regular image stretched.
    /// </summary>
    /// <remarks>
    /// Following ImageVisual properties are not supported in NPatchVisual.
    /// - CornerRadius
    /// - BorderlineWidth
    /// - AlphaMaskUrl
    /// </remarks>
    /// <remarks>
    /// We assume that the image is a n-patch image always. So it does not support other image formats, like svg, lottie.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NPatchVisual : ImageVisual
    {
        #region Constructor
        /// <summary>
        /// Creates an visual object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NPatchVisual() : this(Interop.VisualObject.VisualObjectNew(), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal NPatchVisual(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal NPatchVisual(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
            Type = (int)Tizen.NUI.Visual.Type.NPatch;
        }
        #endregion

        #region Visual Properties
        /// <summary>
        /// Gets or sets whether to draw the borders only (If true).<br />
        /// If not specified, the default is false.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool BorderOnly
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.NpatchImageVisualProperty.BorderOnly, value);
            }
            get
            {
                bool ret = false;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.NpatchImageVisualProperty.BorderOnly);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// The border of the regular image is in the order: left, right, bottom, top.<br />
        /// </summary>
        /// <remarks>
        /// Note that it is not mean the value from 9 patch image.<br />
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle Border
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.NpatchImageVisualProperty.Border, (value == null) ? null : value);
            }
            get
            {
                Rectangle ret = new Rectangle();
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.NpatchImageVisualProperty.Border);
                propertyValue?.Get(ret);
                return ret;
            }
        }

        /// <summary>
        /// Overlays the auxiliary image on top of an NPatch image.
        /// The resulting visual image will be at least as large as the smallest possible n-patch or the auxiliary image, whichever is larger.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AuxiliaryImageUrl
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.AuxiliaryImageURL, string.IsNullOrEmpty(value) ? null : value);
            }
            get
            {
                string ret = "";
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.AuxiliaryImageURL);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// An alpha value for mixing between the masked main NPatch image and the auxiliary image.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float AuxiliaryImageAlpha
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ImageVisualProperty.AuxiliaryImageAlpha, value);
            }
            get
            {
                float ret = 1.0f;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ImageVisualProperty.AuxiliaryImageAlpha);
                propertyValue?.Get(out ret);
                return ret;
            }
        }
        #endregion
    }
}