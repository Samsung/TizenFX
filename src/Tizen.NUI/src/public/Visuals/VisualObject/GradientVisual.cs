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
    /// Visual to render gradient.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GradientVisual : VisualBase
    {
        private List<float> stopOffset;
        private List<Vector4> stopColor;

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 StartPosition
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.StartPosition, value);
            }
            get
            {
                Vector2 ret = new Vector2();
                using (var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.GradientVisualProperty.StartPosition))
                {
                    propertyValue?.Get(ret);
                }
                return ret;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 EndPosition
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.EndPosition, value);
            }
            get
            {
                Vector2 ret = new Vector2();
                using (var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.GradientVisualProperty.EndPosition))
                {
                    propertyValue?.Get(ret);
                }
                return ret;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Center
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.Center, value);
            }
            get
            {
                Vector2 ret = new Vector2();
                using (var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.GradientVisualProperty.Center))
                {
                    propertyValue?.Get(ret);
                }
                return ret;
            }
        }

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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<float> StopOffset
        {
            set
            {
                stopOffset = value;
                PropertyArray stopOffsetArray = new PropertyArray();
                foreach (float val in stopOffset)
                {
                    stopOffsetArray.Add(new PropertyValue(val));
                }

                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.StopOffset, stopOffsetArray);
            }
            get
            {
                return stopOffset;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<Vector4> StopColor
        {
            set
            {
                stopColor = value;
                PropertyArray stopColorArray = new PropertyArray();
                foreach (Vector4 val in stopColor)
                {
                    stopColorArray.Add(new PropertyValue(val));
                }
                UpdateVisualProperty((int)Tizen.NUI.GradientVisualProperty.StopColor, stopColorArray);
            }
            get
            {
                return stopColor;
            }
        }

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