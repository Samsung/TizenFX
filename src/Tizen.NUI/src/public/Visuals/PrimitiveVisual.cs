﻿/*
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
    /// A class encapsulating the property map of the primetive visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PrimitiveVisual : VisualMap
    {
        private PrimitiveVisualShapeType? _shape = null;
        private Color _mixColorForPrimitiveVisual = null;
        private int? _slices = null;
        private int? _stacks = null;
        private float? _scaleTopRadius = null;
        private float? _scaleBottomRadius = null;
        private float? _scaleHeight = null;
        private float? _scaleRadius = null;
        private Vector3 _scaleDimensions = null;
        private float? _bevelPercentage = null;
        private float? _bevelSmoothness = null;
        private Vector3 _lightPosition = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PrimitiveVisual() : base()
        {
        }

        /// <summary>
        /// Gets or sets the specific shape to render.<br />
        /// If not specified, the default is PrimitiveVisualShapeType.Sphere.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PrimitiveVisualShapeType Shape
        {
            get
            {
                return _shape ?? (PrimitiveVisualShapeType.Sphere);
            }
            set
            {
                _shape = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the color of the shape.<br />
        /// If not specified, the default is Color (0.5, 0.5, 0.5, 1.0).<br />
        /// Applies to all shapes.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new Color MixColor
        {
            get
            {
                return _mixColorForPrimitiveVisual ?? (new Color(0.5f, 0.5f, 0.5f, 1.0f));
            }
            set
            {
                _mixColorForPrimitiveVisual = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the number of slices as you go around the shape.<br />
        /// For spheres and conical frustrums, this determines how many divisions there are as you go around the object.<br />
        /// If not specified, the default is 128.<br />
        /// The range is from 1 to 255.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Slices
        {
            get
            {
                return _slices ?? (128);
            }
            set
            {
                _slices = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the number of stacks as you go down the shape.<br />
        /// For spheres, 'stacks' determines how many layers there are as you go down the object.<br />
        /// If not specified, the default is 128.<br />
        /// The range is from 1 to 255.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Stacks
        {
            get
            {
                return _stacks ?? (128);
            }
            set
            {
                _stacks = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the scale of the radius of the top circle of a conical frustrum.<br />
        /// If not specified, the default is 1.0f.<br />
        /// Applies to: - PrimitiveVisualShapeType.ConicalFrustrum<br />
        /// Only values greater than or equal to 0.0f are accepted.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScaleTopRadius
        {
            get
            {
                return _scaleTopRadius ?? (1.0f);
            }
            set
            {
                _scaleTopRadius = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the scale of the radius of the bottom circle of a conical frustrum.<br />
        /// If not specified, the default is 1.5f.<br />
        /// Applies to:  - PrimitiveVisualShapeType.ConicalFrustrum<br />
        ///              - PrimitiveVisualShapeType.Cone<br />
        /// Only values greater than or equal to 0.0f are accepted.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScaleBottomRadius
        {
            get
            {
                return _scaleBottomRadius ?? (1.5f);
            }
            set
            {
                _scaleBottomRadius = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the scale of the height of a conic.<br />
        /// If not specified, the default is 3.0f.<br />
        /// Applies to:<br />
        ///      - PrimitiveVisualShapeType.ConicalFrustrum<br />
        ///      - PrimitiveVisualShapeType.Cone<br />
        ///      - PrimitiveVisualShapeType.Cylinder<br />
        /// Only values greater than or equal to 0.0f are accepted.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScaleHeight
        {
            get
            {
                return _scaleHeight ?? (3.0f);
            }
            set
            {
                _scaleHeight = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the scale of the radius of a cylinder.<br />
        /// If not specified, the default is 1.0f.<br />
        /// Applies to:<br />
        ///      - PrimitiveVisualShapeType.Cylinder<br />
        /// Only values greater than or equal to 0.0f are accepted.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScaleRadius
        {
            get
            {
                return _scaleRadius ?? (1.0f);
            }
            set
            {
                _scaleRadius = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the dimensions of a cuboid. Scales in the same fashion as a 9-patch image.<br />
        /// If not specified, the default is Vector3.One.<br />
        /// Applies to:<br />
        ///      - PrimitiveVisualShapeType.Cube<br />
        ///      - PrimitiveVisualShapeType.Octahedron<br />
        ///      - PrimitiveVisualShapeType.BevelledCube<br />
        /// Each Vector3 parameter should be greater than or equal to 0.0f.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 ScaleDimensions
        {
            get
            {
                return _scaleDimensions ?? (Vector3.One);
            }
            set
            {
                _scaleDimensions = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets determines how bevelled the cuboid should be, based off the smallest dimension.<br />
        /// Bevel percentage ranges from 0.0 to 1.0. It affects the ratio of the outer face widths to the width of the overall cube.<br />
        /// If not specified, the default is 0.0f (no bevel).<br />
        /// Applies to:<br />
        ///      - PrimitiveVisualShapeType.BevelledCube<br />
        /// The range is from 0.0f to 1.0f.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float BevelPercentage
        {
            get
            {
                return _bevelPercentage ?? (0.0f);
            }
            set
            {
                _bevelPercentage = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets descriptions of how smooth the bevelled edges should be.<br />
        /// If not specified, the default is 0.0f (sharp edges).<br />
        /// Applies to:<br />
        ///      - PrimitiveVisualShapeType.BevelledCube<br />
        /// The range is from 0.0f to 1.0f.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float BevelSmoothness
        {
            get
            {
                return _bevelSmoothness ?? (0.0f);
            }
            set
            {
                _bevelSmoothness = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the position, in the stage space, of the point light that applies lighting to the model.<br />
        /// This is based off the stage's dimensions, so using the width and the height of the stage halved will correspond to the center,
        /// and using all zeroes will place the light at the top-left corner.<br />
        /// If not specified, the default is an offset outwards from the center of the screen.<br />
        /// Applies to all shapes.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 LightPosition
        {
            get
            {
                return _lightPosition;
            }
            set
            {
                _lightPosition = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            _outputVisualMap = new PropertyMap(); ;
            _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Primitive));
            if (_shape != null) { _outputVisualMap.Add(PrimitiveVisualProperty.Shape, new PropertyValue((int)_shape)); }
            if (_mixColorForPrimitiveVisual != null) { _outputVisualMap.Add(PrimitiveVisualProperty.MixColor, new PropertyValue(_mixColorForPrimitiveVisual)); }
            if (_slices != null) { _outputVisualMap.Add(PrimitiveVisualProperty.Slices, new PropertyValue((int)_slices)); }
            if (_stacks != null) { _outputVisualMap.Add(PrimitiveVisualProperty.Stacks, new PropertyValue((int)_stacks)); }
            if (_scaleTopRadius != null) { _outputVisualMap.Add(PrimitiveVisualProperty.ScaleTopRadius, new PropertyValue((float)_scaleTopRadius)); }
            if (_scaleBottomRadius != null) { _outputVisualMap.Add(PrimitiveVisualProperty.ScaleBottomRadius, new PropertyValue((float)_scaleBottomRadius)); }
            if (_scaleHeight != null) { _outputVisualMap.Add(PrimitiveVisualProperty.ScaleHeight, new PropertyValue((float)_scaleHeight)); }
            if (_scaleRadius != null) { _outputVisualMap.Add(PrimitiveVisualProperty.ScaleRadius, new PropertyValue((float)_scaleRadius)); }
            if (_scaleDimensions != null) { _outputVisualMap.Add(PrimitiveVisualProperty.ScaleDimensions, new PropertyValue(_scaleDimensions)); }
            if (_bevelPercentage != null) { _outputVisualMap.Add(PrimitiveVisualProperty.BevelPercentage, new PropertyValue((float)_bevelPercentage)); }
            if (_bevelSmoothness != null) { _outputVisualMap.Add(PrimitiveVisualProperty.BevelSmoothness, new PropertyValue((float)_bevelSmoothness)); }
            if (_lightPosition != null) { _outputVisualMap.Add(PrimitiveVisualProperty.LightPosition, new PropertyValue(_lightPosition)); }
            if (_shader != null) { _outputVisualMap.Add(Visual.Property.Shader, new PropertyValue(_shader)); }
            if (_premultipliedAlpha != null) { _outputVisualMap.Add(Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
            if (_opacity != null) { _outputVisualMap.Add(Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
            if (_visualFittingMode != null) { _outputVisualMap.Add(Visual.Property.VisualFittingMode, new PropertyValue((int)_visualFittingMode)); }
        }
    }
}
