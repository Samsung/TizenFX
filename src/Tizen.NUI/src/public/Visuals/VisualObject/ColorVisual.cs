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
    /// Simple visual to render a solid color.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ColorVisual : VisualBase
    {
        #region Constructor
        /// <summary>
        /// Creates an visual object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorVisual() : this(Interop.VisualObject.VisualObjectNew(), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal ColorVisual(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal ColorVisual(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
            Type = (int)Tizen.NUI.Visual.Type.Color;
        }
        #endregion

        #region Visual Properties
        /// <summary>
        /// Blur radius for this visual
        /// </summary>
        /// <remarks>
        /// This property will ignore BorderlineWidth property when we set BlurRadius property at least one time.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BlurRadius
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ColorVisualProperty.BlurRadius, value, false);
            }
            get
            {
                float ret = 0.0f;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ColorVisualProperty.BlurRadius);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Cutout policy of color visual
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorVisualCutoutPolicyType CutoutPolicy
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.ColorVisualProperty.CutoutPolicy, value);
            }
            get
            {
                int ret = (int)ColorVisualCutoutPolicyType.None;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.ColorVisualProperty.CutoutPolicy);
                propertyValue?.Get(out ret);
                return (ColorVisualCutoutPolicyType)ret;
            }
        }
        #endregion

        #region Decorated Visual Properties
        /// <summary>
        /// The radius for the rounded corners of the visual.
        /// The values in Vector4 are used in clockwise order from top-left to bottom-left : Vector4(top-left-corner, top-right-corner, bottom-right-corner, bottom-left-corner).
        /// Each radius will clamp internally to the half of smaller of the visual's width or height.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 CornerRadius
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.CornerRadius, value, false);
            }
            get
            {
                Vector4 ret = new Vector4();
                using (var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.CornerRadius))
                {
                    propertyValue?.Get(ret);
                }
                return ret;
            }
        }

        /// <summary>
        /// Whether the CornerRadius property value is relative (percentage [0.0f to 0.5f] of the visual size) or absolute (in world units).
        /// It is absolute by default.
        /// When the policy is relative, the corner radius is relative to the smaller of the visual's width and height.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VisualTransformPolicyType CornerRadiusPolicy
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.CornerRadiusPolicy, value, false);
            }
            get
            {
                int ret = (int)VisualTransformPolicyType.Absolute;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.CornerRadiusPolicy);
                propertyValue?.Get(out ret);
                return (VisualTransformPolicyType)ret;
            }
        }

        /// <summary>
        /// The squareness for the rounded corners of the visual.
        /// The values in Vector4 are used in clockwise order from top-left to bottom-left : Vector4(top-left-corner, top-right-corner, bottom-right-corner, bottom-left-corner).
        /// Each radius will clamp internally between 0.0 and 1.0.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 CornerSquareness
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.CornerSquareness, value, false);
            }
            get
            {
                Vector4 ret = new Vector4();
                using (var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.CornerSquareness))
                {
                    propertyValue?.Get(ret);
                }
                return ret;
            }
        }

        /// <summary>
        /// The width for the borderline of the visual.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BorderlineWidth
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.BorderlineWidth, value, false);
            }
            get
            {
                float ret = 0.0f;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.BorderlineWidth);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// The color for the borderline of the visual.
        /// It is Color.Black by default.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color BorderlineColor
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.BorderlineColor, value, false);
            }
            get
            {
                Color ret = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                using (var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.BorderlineColor))
                {
                    propertyValue?.Get(ret);
                }
                return ret;
            }
        }

        /// <summary>
        /// The Relative offset for the borderline of the visual.
        /// Recommended range : [-1.0f to 1.0f].
        /// If -1.0f, draw borderline inside of the visual.
        /// If 1.0f, draw borderline outside of the visual.
        /// If 0.0f, draw borderline half inside and half outside.
        /// It is 0.0f by default.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BorderlineOffset
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.BorderlineOffset, value, false);
            }
            get
            {
                float ret = 0.0f;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.BorderlineOffset);
                propertyValue?.Get(out ret);
                return ret;
            }
        }
        #endregion
    }
}