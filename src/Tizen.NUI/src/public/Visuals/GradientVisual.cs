/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// A class encapsulating the property map of the gradient visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class GradientVisual : VisualMap
    {
        private Vector2 _startPosition = null;
        private Vector2 _endPosition = null;
        private Vector2 _center = null;
        private float? _radius = null;
        private PropertyArray _stopOffset = null;
        private PropertyArray _stopColor = null;
        private GradientVisualUnitsType? _units = null;
        private GradientVisualSpreadMethodType? _spreadMethod = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public GradientVisual() : base()
        {
        }

        /// <summary>
        /// Gets or sets the start position of a linear gradient.<br />
        /// Mandatory for linear.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 StartPosition
        {
            get
            {
                return _startPosition;
            }
            set
            {
                _startPosition = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the end position of a linear gradient.<br />
        /// Mandatory for linear.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 EndPosition
        {
            get
            {
                return _endPosition;
            }
            set
            {
                _endPosition = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the center point of a radial gradient.<br />
        /// Mandatory for radial.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 Center
        {
            get
            {
                return _center;
            }
            set
            {
                _center = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the size of the radius of a radial gradient.<br />
        /// Mandatory for radial.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Radius
        {
            get
            {
                return _radius ?? (-1.0f);
            }
            set
            {
                _radius = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets all the stop offsets.<br />
        /// A PropertyArray of float.<br />
        /// If not supplied, the default is 0.0f and 1.0f.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyArray StopOffset
        {
            get
            {
                return _stopOffset;
            }
            set
            {
                _stopOffset = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the color at the stop offsets.<br />
        /// A PropertyArray of color.<br />
        /// At least 2 values are required to show a gradient.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyArray StopColor
        {
            get
            {
                return _stopColor;
            }
            set
            {
                _stopColor = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets descriptions of the coordinate system for certain attributes of the points in a gradient.<br />
        /// If not supplied, the default is GradientVisualUnitsType.ObjectBoundingBox.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public GradientVisualUnitsType Units
        {
            get
            {
                return _units ?? (GradientVisualUnitsType.ObjectBoundingBox);
            }
            set
            {
                _units = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets indications of what happens if the gradient starts or ends inside the bounds of the target rectangle.<br />
        /// If not supplied, the default is GradientVisualSpreadMethodType.Pad.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public GradientVisualSpreadMethodType SpreadMethod
        {
            get
            {
                return _spreadMethod ?? (GradientVisualSpreadMethodType.Pad);
            }
            set
            {
                _spreadMethod = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            if (((_startPosition != null && _endPosition != null) || (_center != null && _radius != null)) && _stopColor != null)
            {
                _outputVisualMap = new PropertyMap();
                PropertyValue temp = new PropertyValue((int)Visual.Type.Gradient);
                _outputVisualMap.Add(Visual.Property.Type, temp);
                temp.Dispose();

                temp = new PropertyValue(_stopColor);
                _outputVisualMap.Add(GradientVisualProperty.StopColor, temp);
                temp.Dispose();

                if (_startPosition != null)
                {
                    temp = new PropertyValue(_startPosition);
                    _outputVisualMap.Add(GradientVisualProperty.StartPosition, temp);
                    temp.Dispose();
                }

                if (_endPosition != null)
                {
                    temp = new PropertyValue(_endPosition);
                    _outputVisualMap.Add(GradientVisualProperty.EndPosition, temp);
                    temp.Dispose();
                }

                if (_center != null)
                {
                    temp = new PropertyValue(_center);
                    _outputVisualMap.Add(GradientVisualProperty.Center, temp);
                    temp.Dispose();
                }

                if (_radius != null)
                {
                    temp = new PropertyValue((float)_radius);
                    _outputVisualMap.Add(GradientVisualProperty.Radius, temp);
                    temp.Dispose();
                }

                if (_stopOffset != null)
                {
                    temp = new PropertyValue(_stopOffset);
                    _outputVisualMap.Add(GradientVisualProperty.StopOffset, temp);
                    temp.Dispose();
                }

                if (_units != null)
                {
                    temp = new PropertyValue((int)_units);
                    _outputVisualMap.Add(GradientVisualProperty.Units, temp);
                    temp.Dispose();
                }

                if (_spreadMethod != null)
                {
                    temp = new PropertyValue((int)_spreadMethod);
                    _outputVisualMap.Add(GradientVisualProperty.SpreadMethod, temp);
                    temp.Dispose();
                }
                base.ComposingPropertyMap();
            }
        }
    }
}
