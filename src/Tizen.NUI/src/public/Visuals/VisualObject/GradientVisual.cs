// Copyright (c) 2025 Samsung Electronics Co., Ltd.
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
    /// Visual to render gradient.<br />
    /// </summary>
    /// <note>
    /// To make linear gradient, use StartPosition and EndPosition.<br />
    /// To make radial gradient, use Center and Radius.<br />
    /// To make conic gradient, use Center and StartAngle.<br />
    /// </note>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GradientVisual : VisualBase
    {
        private IList<float> _stopOffsets;
        private IList<UIColor> _stopColors;

        #region Constructor
        /// <summary>
        /// Creates an visual object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GradientVisual() : this(Interop.VisualObject.VisualObjectNew(), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal GradientVisual(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal GradientVisual(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
            Type = (int)Tizen.NUI.Visual.Type.Gradient;
        }
        #endregion

        #region Visual Properties

        /// <summary>
        /// Gets or sets the start position of a linear gradient.<br />
        /// Mandatory for linear.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UIVector2 StartPosition
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.StartPosition, value);
            }
            get
            {
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.GradientVisualProperty.StartPosition);
                propertyValue.GetVector2Component(out var x, out var y);
                return new UIVector2(x, y);
            }
        }

        /// <summary>
        /// Gets or sets the end position of a linear gradient.<br />
        /// Mandatory for linear.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UIVector2 EndPosition
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.EndPosition, value);
            }
            get
            {
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.GradientVisualProperty.EndPosition);
                propertyValue.GetVector2Component(out var x, out var y);
                return new UIVector2(x, y);
            }
        }

        /// <summary>
        /// Gets or sets the center point of a radial gradient.<br />
        /// Mandatory for radial and conic.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UIVector2 Center
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.Center, value);
            }
            get
            {
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.GradientVisualProperty.Center);
                propertyValue.GetVector2Component(out var x, out var y);
                return new UIVector2(x, y);
            }
        }

         /// <summary>
        /// Gets or sets the size of the radius of a radial gradient.<br />
        /// Mandatory for radial.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Radius
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.Radius, value);
            }
            get
            {
                float ret = 0.0f;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.GradientVisualProperty.Radius);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets all the stop offsets.<br />
        /// A PropertyArray of float.<br />
        /// If not supplied, the default is 0.0f and 1.0f.<br />
        /// Optional.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<float> StopOffsets
        {
            set
            {
                _stopOffsets = value;
                PropertyArray stopOffsetArray = new PropertyArray();
                foreach (float val in _stopOffsets)
                {
                    stopOffsetArray.Add(new PropertyValue(val));
                }

                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.StopOffset, stopOffsetArray);
            }
            get
            {
                return _stopOffsets;
            }
        }

        /// <summary>
        /// Gets or sets the color at the stop offsets.<br />
        /// A PropertyArray of color.<br />
        /// At least 2 values are required to show a gradient.<br />
        /// Mandatory.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<UIColor> StopColors
        {
            set
            {
                _stopColors = value;
                PropertyArray stopColorArray = new PropertyArray();
                foreach (UIColor val in _stopColors)
                {
                    stopColorArray.Add(new PropertyValue(new Vector4(val.R, val.G, val.B, val.A)));
                }
                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.StopColor, stopColorArray);
            }
            get
            {
                return _stopColors;
            }
        }

        /// <summary>
        /// Gets or sets descriptions of the coordinate system for certain attributes of the points in a gradient.<br />
        /// If not supplied, the default is GradientVisualUnitsType.ObjectBoundingBox.<br />
        /// Optional.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GradientVisualUnitsType Units
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.Units, value);
            }
            get
            {
                int ret = (int)GradientVisualUnitsType.ObjectBoundingBox;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.GradientVisualProperty.Units);
                propertyValue?.Get(out ret);
                return (GradientVisualUnitsType)ret;
            }
        }

        /// <summary>
        /// Gets or sets indications of what happens if the gradient starts or ends inside the bounds of the target rectangle.<br />
        /// If not supplied, the default is GradientVisualSpreadMethodType.Pad.<br />
        /// Optional.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GradientVisualSpreadMethodType SpreadMethod
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.SpreadMethod, value);
            }
            get
            {
                int ret = (int)GradientVisualSpreadMethodType.Pad;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.GradientVisualProperty.SpreadMethod);
                propertyValue?.Get(out ret);
                return (GradientVisualSpreadMethodType)ret;
            }
        }

        /// <summary>
        /// Gets or sets the gradient's start position offset.<br />
        /// If not supplied, the default is 0.0f.<br />
        /// Optional.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float StartOffset
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.StartOffset, value);
            }
            get
            {
                float ret = 0.0f;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.GradientVisualProperty.StartOffset);
                propertyValue?.Get(out ret);
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the start angle of the conic gradient.<br />
        /// Mandatory for conic.<br />
        /// Optional.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float StartAngle
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.StartAngle, value);
            }
            get
            {
                float ret = 0.0f;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.GradientVisualProperty.StartAngle);
                propertyValue?.Get(out ret);
                return ret;
            }
        }
        #endregion
    }
}