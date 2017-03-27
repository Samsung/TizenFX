// Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A class encapsulating the transform map of visual.
    /// </summary>
    public class VisualMap
    {
        private Vector2 _visualSize = Vector2.Zero;
        private Vector2 _visualOffset = Vector2.Zero;
        private Vector2 _visualOffsetPolicy = new Vector2((int)VisualTransformPolicyType.Absolute, (int)VisualTransformPolicyType.Absolute); // default absolute
        private Vector2 _visualSizePolicy = new Vector2((int)VisualTransformPolicyType.Absolute, (int)VisualTransformPolicyType.Absolute); // default absolute
        private AlignType _visualOrigin = AlignType.TopBegin;
        private AlignType _visualAnchorPoint = AlignType.TopBegin;

        private PropertyMap _visualTransformMap = null;

        private float _depthIndex = 0.0f;
        protected PropertyMap _outputVisualMap = null;

        public VisualMap()
        {
        }

        /// <summary>
        /// Get or set size of the visual.
        /// It can be either relative (percentage of the parent)
        /// or absolute (in world units).
        /// </summary>
        public Vector2 VisualSize
        {
            get
            {
                return _visualSize;
            }
            set
            {
                _visualSize = value;
            }
        }

        /// <summary>
        /// Get or set offset of the visual.
        /// It can be either relative (percentage of the parent)
        /// or absolute (in world units).
        /// </summary>
        public Vector2 Offset
        {
            get
            {
                return _visualOffset;
            }
            set
            {
                _visualOffset = value;
            }
        }

        /// <summary>
        /// Get or set offset policy of the visual.
        /// Indicates which components of the offset are relative
        /// (percentage of the parent) or absolute (in world units).
        /// 0 indicates the component is relative, and 1 absolute.
        /// </summary>
        public Vector2 OffsetPolicy
        {
            get
            {
                return _visualOffsetPolicy;
            }
            set
            {
                _visualOffsetPolicy = value;
            }
        }

        /// <summary>
        /// Get or set size policy of the visual.
        /// Indicates which components of the size are relative
        /// (percentage of the parent) or absolute (in world units).
        /// 0 indicates the component is relative, and 1 absolute.
        /// </summary>
        public Vector2 SizePolicy
        {
            get
            {
                return _visualSizePolicy;
            }
            set
            {
                _visualSizePolicy = value;
            }
        }

        /// <summary>
        /// Get or set the origin of the visual within its control area.
        /// </summary>
        public AlignType Origin
        {
            get
            {
                return _visualOrigin;
            }
            set
            {
                _visualOrigin = value;
            }
        }

        /// <summary>
        /// Get or set the anchor-point of the visual.
        /// </summary>
        public AlignType AnchorPoint
        {
            get
            {
                return _visualAnchorPoint;
            }
            set
            {
                _visualAnchorPoint = value;
            }
        }

        /// <summary>
        /// Get or set the depth index of the visual.
        /// </summary>
        public float DepthIndex
        {
            get
            {
                return _depthIndex;
            }
            set
            {
                _depthIndex = value;
            }
        }

        private void ComposingTransformMap()
        {
            if (_visualSize != Vector2.Zero)
            {
                _visualTransformMap = new PropertyMap();
                _visualTransformMap.Add((int)VisualTransformPropertyType.Size, new PropertyValue(_visualSize));
                _visualTransformMap.Add((int)VisualTransformPropertyType.Offset, new PropertyValue(_visualOffset));
                _visualTransformMap.Add((int)VisualTransformPropertyType.OffsetPolicy, new PropertyValue(_visualOffsetPolicy));
                _visualTransformMap.Add((int)VisualTransformPropertyType.SizePolicy, new PropertyValue(_visualSizePolicy));
                _visualTransformMap.Add((int)VisualTransformPropertyType.Origin, new PropertyValue((int)_visualOrigin));
                _visualTransformMap.Add((int)VisualTransformPropertyType.AnchorPoint, new PropertyValue((int)_visualAnchorPoint));
            }
        }

        /// <summary>
        /// Get the transform map used by the visual.
        /// </summary>
        public PropertyMap OutputTransformMap
        {
            get
            {
                ComposingTransformMap();
                return _visualTransformMap;
            }
        }

        protected virtual void ComposingPropertyMap()
        {
            _outputVisualMap = new PropertyMap();
        }

        /// <summary>
        /// Get the property map to create the visual.
        /// </summary>
        public PropertyMap OutputVisualMap
        {
            get
            {
                ComposingPropertyMap();
                return _outputVisualMap;
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a image visual.
    /// </summary>
    public class ImageVisualMap : VisualMap
    {
        public ImageVisualMap() : base()
        {
        }

        private string _url = "";
        private FittingModeType _fittingMode = FittingModeType.ShrinkToFit;
        private SamplingModeType _samplingMode = SamplingModeType.Box;
        private int _desiredWidth = 0;
        private int _desiredHeight = 0;
        private bool _synchronousLoading = false;
        private bool _borderOnly = false;
        private Vector4 _pixelArea = new Vector4(0.0f, 0.0f, 1.0f, 1.0f);
        private WrapModeType _wrapModeU = WrapModeType.ClampToEdge;
        private WrapModeType _wrapModeV = WrapModeType.ClampToEdge;

        /// <summary>
        /// Get or set the URL of the image.
        /// </summary>
        public string URL
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        /// <summary>
        /// Get or set fitting options, used when resizing images to fit desired dimensions.
        /// If not supplied, default is FittingMode::SHRINK_TO_FIT.
        /// For Normal Quad images only.
        /// </summary>
        public FittingModeType FittingMode
        {
            get
            {
                return _fittingMode;
            }
            set
            {
                _fittingMode = value;
            }
        }

        /// <summary>
        /// Get or set filtering options, used when resizing images to sample original pixels.
        /// If not supplied, default is SamplingMode::BOX.
        /// For Normal Quad images only.
        /// </summary>
        public SamplingModeType SamplingMode
        {
            get
            {
                return _samplingMode;
            }
            set
            {
                _samplingMode = value;
            }
        }

        /// <summary>
        /// Get or set the desired image width.
        /// If not specified, the actual image width is used.
        /// For Normal Quad images only.
        /// </summary>
        public int DesiredWidth
        {
            get
            {
                return _desiredWidth;
            }
            set
            {
                _desiredWidth = value;
            }
        }

        /// <summary>
        /// Get or set the desired image height.
        /// If not specified, the actual image height is used.
        /// For Normal Quad images only.
        /// </summary>
        public int DesiredHeight
        {
            get
            {
                return _desiredHeight;
            }
            set
            {
                _desiredHeight = value;
            }
        }

        /// <summary>
        /// Get or set whether to load the image synchronously.
        /// If not specified, the default is false, i.e. the image is loaded asynchronously.
        /// For Normal Quad images only.
        /// </summary>
        public bool SynchronousLoading
        {
            get
            {
                return _synchronousLoading;
            }
            set
            {
                _synchronousLoading = value;
            }
        }

        /// <summary>
        /// Get or set whether to draws the borders only(If true).
        /// If not specified, the default is false.
        /// For N-Patch images only.
        /// </summary>
        public bool BorderOnly
        {
            get
            {
                return _borderOnly;
            }
            set
            {
                _borderOnly = value;
            }
        }

        /// <summary>
        /// Get or set the image area to be displayed.
        /// It is a rectangular area.
        /// The first two elements indicate the top-left position of the area, and the last two elements are the area width and height respectively.
        /// If not specified, the default value is [0.0, 0.0, 1.0, 1.0], i.e. the entire area of the image.
        /// For For Normal QUAD image only.
        /// </summary>
        public Vector4 PixelArea
        {
            get
            {
                return _pixelArea;
            }
            set
            {
                _pixelArea = value;
            }
        }

        /// <summary>
        /// Get or set the wrap mode for u coordinate.
        /// It decides how the texture should be sampled when the u coordinate exceeds the range of 0.0 to 1.0.
        /// If not specified, the default is CLAMP.
        /// For Normal QUAD image only.
        /// </summary>
        public WrapModeType WrapModeU
        {
            get
            {
                return _wrapModeU;
            }
            set
            {
                _wrapModeU = value;
            }
        }

        /// <summary>
        /// Get or set the wrap mode for v coordinate.
        /// It decides how the texture should be sampled when the v coordinate exceeds the range of 0.0 to 1.0.
        /// The first two elements indicate the top-left position of the area, and the last two elements are the area width and height respectively.
        /// If not specified, the default is CLAMP.
        /// For Normal QUAD image only.
        /// </summary>
        public WrapModeType WrapModeV
        {
            get
            {
                return _wrapModeV;
            }
            set
            {
                _wrapModeV = value;
            }
        }

        protected override void ComposingPropertyMap()
        {
            if (_url != "")
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
                _outputVisualMap.Add(ImageVisualProperty.URL, new PropertyValue(_url));
                _outputVisualMap.Add(ImageVisualProperty.FittingMode, new PropertyValue((int)_fittingMode));
                _outputVisualMap.Add(ImageVisualProperty.SamplingMode, new PropertyValue((int)_samplingMode));

                if (_desiredWidth != 0)
                {
                    _outputVisualMap.Add(ImageVisualProperty.DesiredWidth, new PropertyValue(_desiredWidth));
                }

                if (_desiredHeight != 0)
                {
                    _outputVisualMap.Add(ImageVisualProperty.DesiredHeight, new PropertyValue(_desiredHeight));
                }

                _outputVisualMap.Add(ImageVisualProperty.SynchronousLoading, new PropertyValue(_synchronousLoading));
                _outputVisualMap.Add(ImageVisualProperty.BorderOnly, new PropertyValue(_borderOnly));
                _outputVisualMap.Add(ImageVisualProperty.PixelArea, new PropertyValue(_pixelArea));
                _outputVisualMap.Add(ImageVisualProperty.WrapModeU, new PropertyValue((int)_wrapModeU));
                _outputVisualMap.Add(ImageVisualProperty.WrapModeV, new PropertyValue((int)_wrapModeV));
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a text visual.
    /// </summary>
    public class TextVisualMap : VisualMap
    {
        public TextVisualMap() : base()
        {
        }

        private string _text = "";
        private string _fontFamily = "";
        private PropertyMap _fontStyle = null;
        private float _pointSize = 0.0f;
        private bool _multiLine = false;
        private string _horizontalAlignment = "BEGIN";
        private string _verticalAlignment = "TOP";
        private Color _textColor = Color.Black;
        private bool _enableMarkup = false;

        /// <summary>
        /// Get or set the text to display in UTF-8 format.
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        /// <summary>
        /// Get or set the requested font family to use.
        /// </summary>
        public string FontFamily
        {
            get
            {
                return _fontFamily;
            }
            set
            {
                _fontFamily = value;
            }
        }

        /// <summary>
        /// Get or set the requested font style to use.
        /// </summary>
        public PropertyMap FontStyle
        {
            get
            {
                return _fontStyle;
            }
            set
            {
                _fontStyle = value;
            }
        }

        /// <summary>
        /// Get or set the size of font in points.
        /// </summary>
        public float PointSize
        {
            get
            {
                return _pointSize;
            }
            set
            {
                _pointSize = value;
            }
        }

        /// <summary>
        /// Get or set the single-line or multi-line layout option.
        /// </summary>
        public bool MultiLine
        {
            get
            {
                return _multiLine;
            }
            set
            {
                _multiLine = value;
            }
        }

        /// <summary>
        /// Get or set the line horizontal alignment.
        /// If not specified, the default is BEGIN.
        /// </summary>
        public string HorizontalAlignment
        {
            get
            {
                return _horizontalAlignment;
            }
            set
            {
                _horizontalAlignment = value;
            }
        }

        /// <summary>
        /// Get or set the line vertical alignment.
        /// If not specified, the default is TOP.
        /// </summary>
        public string VerticalAlignment
        {
            get
            {
                return _verticalAlignment;
            }
            set
            {
                _verticalAlignment = value;
            }
        }

        /// <summary>
        /// Get or set the color of the text.
        /// </summary>
        public Color TextColor
        {
            get
            {
                return _textColor;
            }
            set
            {
                _textColor = value;
            }
        }

        /// <summary>
        /// Get or set whether the mark-up processing is enabled.
        /// </summary>
        public bool EnableMarkup
        {
            get
            {
                return _enableMarkup;
            }
            set
            {
                _enableMarkup = value;
            }
        }

        protected override void ComposingPropertyMap()
        {
            if (_text != "")
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
                _outputVisualMap.Add(TextVisualProperty.Text, new PropertyValue(_text));

                if (_fontFamily != "")
                {
                    _outputVisualMap.Add(TextVisualProperty.FontFamily, new PropertyValue(_fontFamily));
                }

                if (_fontStyle != null)
                {
                    _outputVisualMap.Add(TextVisualProperty.FontStyle, new PropertyValue(_fontStyle));
                }

                if (_pointSize != 0)
                {
                    _outputVisualMap.Add(TextVisualProperty.PointSize, new PropertyValue(_pointSize));
                }

                _outputVisualMap.Add(TextVisualProperty.MultiLine, new PropertyValue(_multiLine));
                _outputVisualMap.Add(TextVisualProperty.HorizontalAlignment, new PropertyValue(_horizontalAlignment));
                _outputVisualMap.Add(TextVisualProperty.VerticalAlignment, new PropertyValue(_verticalAlignment));
                _outputVisualMap.Add(TextVisualProperty.TextColor, new PropertyValue(_textColor));
                _outputVisualMap.Add(TextVisualProperty.EnableMarkup, new PropertyValue(_enableMarkup));
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a border visual.
    /// </summary>
    public class BorderVisualMap : VisualMap
    {
        public BorderVisualMap() : base()
        {
        }

        private Color _color = Color.Black;
        private float _size = 0.000001f;
        private bool _antiAliasing = false;

        /// <summary>
        /// Get or set the color of the border.
        /// </summary>
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        /// <summary>
        /// Get or set the width of the border (in pixels).
        /// </summary>
        public float Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }

        /// <summary>
        /// Get or set whether anti-aliasing of the border is required.
        /// If not supplied, default is false.
        /// </summary>
        public bool AntiAliasing
        {
            get
            {
                return _antiAliasing;
            }
            set
            {
                _antiAliasing = value;
            }
        }

        protected override void ComposingPropertyMap()
        {
            if (_size > 0.000001f)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Border));
                _outputVisualMap.Add(BorderVisualProperty.Color, new PropertyValue(_color));
                _outputVisualMap.Add(BorderVisualProperty.Size, new PropertyValue(_size));
                _outputVisualMap.Add(BorderVisualProperty.AntiAliasing, new PropertyValue(_antiAliasing));
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a color visual.
    /// </summary>
    public class ColorVisualMap : VisualMap
    {
        public ColorVisualMap() : base()
        {
        }

        private Color _mixColor = Color.Black;

        /// <summary>
        /// Get or set the solid color required.
        /// </summary>
        public Color MixColor
        {
            get
            {
                return _mixColor;
            }
            set
            {
                _mixColor = value;
            }
        }

        protected override void ComposingPropertyMap()
        {
            _outputVisualMap = new PropertyMap();
            _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color));
            _outputVisualMap.Add(ColorVisualProperty.MixColor, new PropertyValue(_mixColor));
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a gradient visual.
    /// </summary>
    public class GradientVisualMap : VisualMap
    {
        public GradientVisualMap() : base()
        {
        }

        private Vector2 _startPosition = Vector2.Zero;
        private Vector2 _endPosition = Vector2.Zero;
        private Vector2 _center = Vector2.Zero;
        private float _radius = 0.000001f;
        private PropertyArray _stopOffset = null; //0.0, 1.0
        private PropertyArray _stopColor = null; // Color.Black, Color.Blue
        private GradientVisualUnitsType _units = GradientVisualUnitsType.ObjectBoundingBox;
        private GradientVisualSpreadMethodType _spreadMethod = GradientVisualSpreadMethodType.Pad;

        /// <summary>
        /// Get or set the start position of a linear gradient.
        /// Mandatory for Linear.
        /// </summary>
        public Vector2 StartPosition
        {
            get
            {
                return _startPosition;
            }
            set
            {
                _startPosition = value;
            }
        }

        /// <summary>
        /// Get or set the end position of a linear gradient.
        /// Mandatory for Linear.
        /// </summary>
        public Vector2 EndPosition
        {
            get
            {
                return _endPosition;
            }
            set
            {
                _endPosition = value;
            }
        }

        /// <summary>
        /// Get or set the center point of a radial gradient.
        /// Mandatory for Radial.
        /// </summary>
        public Vector2 Center
        {
            get
            {
                return _center;
            }
            set
            {
                _center = value;
            }
        }

        /// <summary>
        /// Get or set the size of the radius of a radial gradient.
        /// Mandatory for Radial.
        /// </summary>
        public float Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        /// <summary>
        /// Get or set all the stop offsets.
        /// A PropertyArray of float.
        /// If not supplied, default is 0.0f and 1.0f.
        /// </summary>
        public PropertyArray StopOffset
        {
            get
            {
                return _stopOffset;
            }
            set
            {
                _stopOffset = value;
            }
        }

        /// <summary>
        /// Get or set the color at the stop offsets.
        /// A PropertyArray of Color.
        /// At least 2 values required to show a gradient.
        /// </summary>
        public PropertyArray StopColor
        {
            get
            {
                return _stopColor;
            }
            set
            {
                _stopColor = value;
            }
        }

        /// <summary>
        /// Get or set defines the coordinate system for certain attributes of the points in a gradient.
        /// If not supplied, default is GradientVisualUnitsType.OBJECT_BOUNDING_BOX.
        /// </summary>
        public GradientVisualUnitsType Units
        {
            get
            {
                return _units;
            }
            set
            {
                _units = value;
            }
        }

        /// <summary>
        /// Get or set indicates what happens if the gradient starts or ends inside the bounds of the target rectangle.
        /// If not supplied, default is GradientVisualSpreadMethodType.PAD.
        /// </summary>
        public GradientVisualSpreadMethodType SpreadMethod
        {
            get
            {
                return _spreadMethod;
            }
            set
            {
                _spreadMethod = value;
            }
        }

        protected override void ComposingPropertyMap()
        {
            if (_startPosition != Vector2.Zero && _endPosition != Vector2.Zero && _center != Vector2.Zero
                && _radius > 0.000001f && _stopColor != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Gradient));
                _outputVisualMap.Add(GradientVisualProperty.StartPosition, new PropertyValue(_startPosition));
                _outputVisualMap.Add(GradientVisualProperty.EndPosition, new PropertyValue(_endPosition));
                _outputVisualMap.Add(GradientVisualProperty.Center, new PropertyValue(_center));
                _outputVisualMap.Add(GradientVisualProperty.Radius, new PropertyValue(_radius));

                if (_stopOffset != null)
                {
                    _outputVisualMap.Add(GradientVisualProperty.StopOffset, new PropertyValue(_stopOffset));
                }

                _outputVisualMap.Add(GradientVisualProperty.StopColor, new PropertyValue(_stopColor));
                _outputVisualMap.Add(GradientVisualProperty.Units, new PropertyValue((int)_units));
                _outputVisualMap.Add(GradientVisualProperty.SpreadMethod, new PropertyValue((int)_spreadMethod));
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a mesh visual.
    /// </summary>
    public class MeshVisualMap : VisualMap
    {
        public MeshVisualMap() : base()
        {
        }

        private string _objectURL = "";
        private string _materialtURL = "";
        private string _texturesPath = "";
        private MeshVisualShadingModeValue _shadingMode = MeshVisualShadingModeValue.TexturedWithDetailedSpecularLighting;
        private bool _useMipmapping = true;
        private bool _useSoftNormals = true;
        private Vector3 _lightPosition = null; //default center of screen

        /// <summary>
        /// Get or set the location of the ".obj" file.
        /// </summary>
        public string ObjectURL
        {
            get
            {
                return _objectURL;
            }
            set
            {
                _objectURL = value;
            }
        }

        /// <summary>
        /// Get or set the location of the ".mtl" file.
        /// If not specified, then a textureless object is assumed.
        /// </summary>
        public string MaterialtURL
        {
            get
            {
                return _materialtURL;
            }
            set
            {
                _materialtURL = value;
            }
        }

        /// <summary>
        /// Get or set path to the directory the textures (including gloss and normal) are stored in.
        /// Mandatory if using material.
        /// </summary>
        public string TexturesPath
        {
            get
            {
                return _texturesPath;
            }
            set
            {
                _texturesPath = value;
            }
        }

        /// <summary>
        /// Get or set the type of shading mode that the mesh will use.
        /// If anything the specified shading mode requires is missing, a simpler mode that can be handled with what has been supplied will be used instead.
        /// If not specified, it will use the best it can support (will try MeshVisualShadingModeValue.TEXTURED_WITH_DETAILED_SPECULAR_LIGHTING first).
        /// </summary>
        public MeshVisualShadingModeValue ShadingMode
        {
            get
            {
                return _shadingMode;
            }
            set
            {
                _shadingMode = value;
            }
        }

        /// <summary>
        /// Get or set whether to use mipmaps for textures or not.
        /// If not specified, the default is true.
        /// </summary>
        public bool UseMipmapping
        {
            get
            {
                return _useMipmapping;
            }
            set
            {
                _useMipmapping = value;
            }
        }

        /// <summary>
        /// Get or set whether to average normals at each point to smooth textures or not.
        /// If not specified, the default is true.
        /// </summary>
        public bool UseSoftNormals
        {
            get
            {
                return _useSoftNormals;
            }
            set
            {
                _useSoftNormals = value;
            }
        }

        /// <summary>
        /// Get or set the position, in stage space, of the point light that applies lighting to the model.
        /// This is based off the stage's dimensions, so using the width and height of the stage halved will correspond to the center,
        /// and using all zeroes will place the light at the top left corner.
        /// If not specified, the default is an offset outwards from the center of the screen.
        /// </summary>
        public Vector3 LightPosition
        {
            get
            {
                return _lightPosition;
            }
            set
            {
                _lightPosition = value;
            }
        }

        protected override void ComposingPropertyMap()
        {
            if (_objectURL != "")
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Mesh));
                _outputVisualMap.Add(MeshVisualProperty.ObjectURL, new PropertyValue(_objectURL));

                if (_materialtURL != "" && _texturesPath != "")
                {
                    _outputVisualMap.Add(MeshVisualProperty.MaterialtURL, new PropertyValue(_materialtURL));
                    _outputVisualMap.Add(MeshVisualProperty.TexturesPath, new PropertyValue(_texturesPath));
                }

                _outputVisualMap.Add(MeshVisualProperty.ShadingMode, new PropertyValue((int)_shadingMode));
                _outputVisualMap.Add(MeshVisualProperty.UseMipmapping, new PropertyValue(_useMipmapping));
                _outputVisualMap.Add(MeshVisualProperty.UseSoftNormals, new PropertyValue(_useSoftNormals));

                if (_lightPosition != null)
                {
                    _outputVisualMap.Add(MeshVisualProperty.LightPosition, new PropertyValue(_lightPosition));
                }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a primetive visual.
    /// </summary>
    public class PrimitiveVisualMap : VisualMap
    {
        public PrimitiveVisualMap() : base()
        {
        }

        private PrimitiveVisualShapeType _shape = PrimitiveVisualShapeType.Sphere;
        private Color _mixColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        private int _slices = 128;
        private int _stacks = 128;
        private float _scaleTopRadius = 1.0f;
        private float _scaleBottomRadius = 1.5f;
        private float _scaleHeight = 3.0f;
        private float _scaleRadius = 1.0f;
        private Vector3 _scaleDimensions = Vector3.One;
        private float _bevelPercentage = 0.0f;
        private float _bevelSmoothness = 0.0f;
        private Vector3 _lightPosition = null; // default ?? center of screen

        /// <summary>
        /// Get or set the specific shape to render.
        /// If not specified, the default is PrimitiveVisualShapeType.SPHERE.
        /// </summary>
        public PrimitiveVisualShapeType Shape
        {
            get
            {
                return _shape;
            }
            set
            {
                _shape = value;
            }
        }

        /// <summary>
        /// Get or set the color of the shape.
        /// If not specified, the default is Color(0.5, 0.5, 0.5, 1.0).
        /// Applies to ALL shapes.
        /// </summary>
        public Color MixColor
        {
            get
            {
                return _mixColor;
            }
            set
            {
                _mixColor = value;
            }
        }

        /// <summary>
        /// Get or set the number of slices as you go around the shape.
        /// For spheres and conical frustrums, this determines how many divisions there are as you go around the object.
        /// If not specified, the default is 128.
        /// The range is from 1 to 255.
        /// </summary>
        public int Slices
        {
            get
            {
                return _slices;
            }
            set
            {
                _slices = value;
            }
        }

        /// <summary>
        /// Get or set the number of stacks as you go down the shape.
        /// For spheres, 'stacks' determines how many layers there are as you go down the object.
        /// If not specified, the default is 128.
        /// The range is from 1 to 255.
        /// </summary>
        public int Stacks
        {
            get
            {
                return _stacks;
            }
            set
            {
                _stacks = value;
            }
        }

        /// <summary>
        /// Get or set the scale of the radius of the top circle of a conical frustrum.
        /// If not specified, the default is 1.0f.
        /// Applies to: - PrimitiveVisualShapeType.CONICAL_FRUSTRUM
        /// Only values greater than or equal to 0.0f are accepted.
        /// </summary>
        public float ScaleTopRadius
        {
            get
            {
                return _scaleTopRadius;
            }
            set
            {
                _scaleTopRadius = value;
            }
        }

        /// <summary>
        /// Get or set the scale of the radius of the bottom circle of a conical frustrum.
        /// If not specified, the default is 1.5f.
        /// Applies to:  - PrimitiveVisualShapeType.CONICAL_FRUSTRUM
        ///              - PrimitiveVisualShapeType.CONE
        /// Only values greater than or equal to 0.0f are accepted.
        /// </summary>
        public float ScaleBottomRadius
        {
            get
            {
                return _scaleBottomRadius;
            }
            set
            {
                _scaleBottomRadius = value;
            }
        }

        /// <summary>
        /// Get or set the scale of the height of a conic.
        /// If not specified, the default is 3.0f.
        /// Applies to:
        ///      - Shape::CONICAL_FRUSTRUM
        ///      - Shape::CONE
        ///      - Shape::CYLINDER
        /// Only values greater than or equal to 0.0f are accepted.
        /// </summary>
        public float ScaleHeight
        {
            get
            {
                return _scaleHeight;
            }
            set
            {
                _scaleHeight = value;
            }
        }

        /// <summary>
        /// Get or set the scale of the radius of a cylinder.
        /// If not specified, the default is 1.0f.
        /// Applies to:
        ///      - Shape::CYLINDER
        /// Only values greater than or equal to 0.0f are accepted.
        /// </summary>
        public float ScaleRadius
        {
            get
            {
                return _scaleRadius;
            }
            set
            {
                _scaleRadius = value;
            }
        }

        /// <summary>
        /// Get or set the dimensions of a cuboid. Scales in the same fashion as a 9-patch image.
        /// If not specified, the default is Vector3.One.
        /// Applies to:
        ///      - Shape::CUBE
        ///      - Shape::OCTAHEDRON
        ///      - Shape::BEVELLED_CUBE
        /// Each vector3 parameter should be greater than or equal to 0.0f.
        /// </summary>
        public Vector3 ScaleDimensions
        {
            get
            {
                return _scaleDimensions;
            }
            set
            {
                _scaleDimensions = value;
            }
        }

        /// <summary>
        /// Get or set determines how bevelled the cuboid should be, based off the smallest dimension.
        /// Bevel percentage ranges from 0.0 to 1.0. It affects the ratio of the outer face widths to the width of the overall cube.
        /// If not specified, the default is 0.0f (no bevel).
        /// Applies to:
        ///      - Shape::BEVELLED_CUBE
        /// The range is from 0.0f to 1.0f.
        /// </summary>
        public float BevelPercentage
        {
            get
            {
                return _bevelPercentage;
            }
            set
            {
                _bevelPercentage = value;
            }
        }

        /// <summary>
        /// Get or set defines how smooth the bevelled edges should be.
        /// If not specified, the default is 0.0f (sharp edges).
        /// Applies to:
        ///      - Shape::BEVELLED_CUBE
        /// The range is from 0.0f to 1.0f.
        /// </summary>
        public float BevelSmoothness
        {
            get
            {
                return _bevelSmoothness;
            }
            set
            {
                _bevelSmoothness = value;
            }
        }

        /// <summary>
        /// Get or set the position, in stage space, of the point light that applies lighting to the model.
        /// This is based off the stage's dimensions, so using the width and height of the stage halved will correspond to the center,
        /// and using all zeroes will place the light at the top left corner.
        /// If not specified, the default is an offset outwards from the center of the screen.
        /// Applies to ALL shapes.
        /// </summary>
        public Vector3 LightPosition
        {
            get
            {
                return _lightPosition;
            }
            set
            {
                _lightPosition = value;
            }
        }

        protected override void ComposingPropertyMap()
        {
            _outputVisualMap = new PropertyMap(); ;
            _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Primitive));
            _outputVisualMap.Add(PrimitiveVisualProperty.Shape, new PropertyValue((int)_shape));
            _outputVisualMap.Add(PrimitiveVisualProperty.MixColor, new PropertyValue(_mixColor));
            _outputVisualMap.Add(PrimitiveVisualProperty.Slices, new PropertyValue(_slices));
            _outputVisualMap.Add(PrimitiveVisualProperty.Stacks, new PropertyValue(_stacks));
            _outputVisualMap.Add(PrimitiveVisualProperty.ScaleTopRadius, new PropertyValue(_scaleTopRadius));
            _outputVisualMap.Add(PrimitiveVisualProperty.ScaleBottomRadius, new PropertyValue(_scaleBottomRadius));
            _outputVisualMap.Add(PrimitiveVisualProperty.ScaleHeight, new PropertyValue(_scaleHeight));
            _outputVisualMap.Add(PrimitiveVisualProperty.ScaleRadius, new PropertyValue(_scaleRadius));
            _outputVisualMap.Add(PrimitiveVisualProperty.ScaleDimensions, new PropertyValue(_scaleDimensions));
            _outputVisualMap.Add(PrimitiveVisualProperty.BevelPercentage, new PropertyValue(_bevelPercentage));
            _outputVisualMap.Add(PrimitiveVisualProperty.BevelSmoothness, new PropertyValue(_bevelSmoothness));

            if (_lightPosition != null)
            {
                _outputVisualMap.Add(PrimitiveVisualProperty.LightPosition, new PropertyValue(_lightPosition));
            }
        }
    }


    public enum WrapModeType
    {
        Default = 0,
        ClampToEdge,
        Repeat,
        MirroredRepeat
    }

    public enum GradientVisualUnitsType
    {
        ObjectBoundingBox,
        UserSpace
    }

    public enum GradientVisualSpreadMethodType
    {
        Pad,
        Reflect,
        Repeat
    }

    public enum MeshVisualShadingModeValue
    {
        TexturelessWithDiffuseLighting,
        TexturedWithSpecularLighting,
        TexturedWithDetailedSpecularLighting
    }

    public enum PrimitiveVisualShapeType
    {
        Sphere,
        ConicalFrustrum,
        Cone,
        Cylinder,
        Cube,
        Octahedron,
        BevelledCube
    }

    public enum FittingModeType
    {
        ShrinkToFit,
        ScaleToFill,
        FitWidth,
        FitHeight
    }

    public enum SamplingModeType
    {
        Box,
        Nearest,
        Linear,
        BoxThenNearest,
        BoxThenLinear,
        NoFilter,
        DontCare
    }

    public enum VisualTransformPolicyType
    {
        Relative = 0,
        Absolute = 1
    }

    public enum AlignType
    {
        TopBegin = 0,
        TopCenter,
        TopEnd,
        CenterBegin,
        Center,
        CenterEnd,
        BottomBegin,
        BottomCenter,
        BottomEnd
    }

    public enum VisualTransformPropertyType
    {
        Offset,
        Size,
        Origin,
        AnchorPoint,
        OffsetPolicy,
        SizePolicy
    }

    public struct Visual
    {
        public enum Type
        {
            Border,
            Color,
            Gradient,
            Image,
            Mesh,
            Primitive,
            Wireframe,
            Text
        }

        public struct Property
        {
            public static readonly int Type = NDalic.VISUAL_PROPERTY_TYPE;
            public static readonly int Shader = NDalic.VISUAL_PROPERTY_SHADER;
            public static readonly int Transform = NDalic.VISUAL_PROPERTY_TRANSFORM;
            public static readonly int PremultipliedAlpha = NDalic.VISUAL_PROPERTY_PREMULTIPLIED_ALPHA;
            public static readonly int MixColor = NDalic.VISUAL_PROPERTY_MIX_COLOR;
        }

        public struct ShaderProperty
        {
            public static readonly int VertexShader = NDalic.VISUAL_SHADER_VERTEX;
            public static readonly int FragmentShader = NDalic.VISUAL_SHADER_FRAGMENT;
            public static readonly int ShaderSubdivideGridX = NDalic.VISUAL_SHADER_SUBDIVIDE_GRID_X;
            public static readonly int ShaderSubdivideGridY = NDalic.VISUAL_SHADER_SUBDIVIDE_GRID_Y;
            public static readonly int ShaderHints = NDalic.VISUAL_SHADER_HINTS;
        }
    }

    public struct BorderVisualProperty
    {
        public static readonly int Color = NDalic.BORDER_VISUAL_COLOR;
        public static readonly int Size = NDalic.BORDER_VISUAL_SIZE;
        public static readonly int AntiAliasing = NDalic.BORDER_VISUAL_ANTI_ALIASING;
    }

    public struct ColorVisualProperty
    {
        public static readonly int MixColor = NDalic.COLOR_VISUAL_MIX_COLOR;
    }

    public struct GradientVisualProperty
    {
        public static readonly int StartPosition = NDalic.GRADIENT_VISUAL_START_POSITION;
        public static readonly int EndPosition = NDalic.GRADIENT_VISUAL_END_POSITION;
        public static readonly int Center = NDalic.GRADIENT_VISUAL_CENTER;
        public static readonly int Radius = NDalic.GRADIENT_VISUAL_RADIUS;
        public static readonly int StopOffset = NDalic.GRADIENT_VISUAL_STOP_OFFSET;
        public static readonly int StopColor = NDalic.GRADIENT_VISUAL_STOP_COLOR;
        public static readonly int Units = NDalic.GRADIENT_VISUAL_UNITS;
        public static readonly int SpreadMethod = NDalic.GRADIENT_VISUAL_SPREAD_METHOD;
    }

    public struct ImageVisualProperty
    {
        public static readonly int URL = NDalic.IMAGE_VISUAL_URL;
        public static readonly int FittingMode = NDalic.IMAGE_VISUAL_FITTING_MODE;
        public static readonly int SamplingMode = NDalic.IMAGE_VISUAL_SAMPLING_MODE;
        public static readonly int DesiredWidth = NDalic.IMAGE_VISUAL_DESIRED_WIDTH;
        public static readonly int DesiredHeight = NDalic.IMAGE_VISUAL_DESIRED_HEIGHT;
        public static readonly int SynchronousLoading = NDalic.IMAGE_VISUAL_SYNCHRONOUS_LOADING;
        public static readonly int BorderOnly = NDalic.IMAGE_VISUAL_BORDER_ONLY;
        public static readonly int PixelArea = NDalic.IMAGE_VISUAL_PIXEL_AREA;
        public static readonly int WrapModeU = NDalic.IMAGE_VISUAL_WRAP_MODE_U;
        public static readonly int WrapModeV = NDalic.IMAGE_VISUAL_WRAP_MODE_V;
    }

    public struct MeshVisualProperty
    {
        public static readonly int ObjectURL = NDalic.MESH_VISUAL_OBJECT_URL;
        public static readonly int MaterialtURL = NDalic.MESH_VISUAL_MATERIAL_URL;
        public static readonly int TexturesPath = NDalic.MESH_VISUAL_TEXTURES_PATH;
        public static readonly int ShadingMode = NDalic.MESH_VISUAL_SHADING_MODE;
        public static readonly int UseMipmapping = NDalic.MESH_VISUAL_USE_MIPMAPPING;
        public static readonly int UseSoftNormals = NDalic.MESH_VISUAL_USE_SOFT_NORMALS;
        public static readonly int LightPosition = NDalic.MESH_VISUAL_LIGHT_POSITION;
    }

    public struct PrimitiveVisualProperty
    {
        public static readonly int Shape = NDalic.PRIMITIVE_VISUAL_SHAPE;
        public static readonly int MixColor = NDalic.PRIMITIVE_VISUAL_MIX_COLOR;
        public static readonly int Slices = NDalic.PRIMITIVE_VISUAL_SLICES;
        public static readonly int Stacks = NDalic.PRIMITIVE_VISUAL_STACKS;
        public static readonly int ScaleTopRadius = NDalic.PRIMITIVE_VISUAL_SCALE_TOP_RADIUS;
        public static readonly int ScaleBottomRadius = NDalic.PRIMITIVE_VISUAL_SCALE_BOTTOM_RADIUS;
        public static readonly int ScaleHeight = NDalic.PRIMITIVE_VISUAL_SCALE_HEIGHT;
        public static readonly int ScaleRadius = NDalic.PRIMITIVE_VISUAL_SCALE_RADIUS;
        public static readonly int ScaleDimensions = NDalic.PRIMITIVE_VISUAL_SCALE_DIMENSIONS;
        public static readonly int BevelPercentage = NDalic.PRIMITIVE_VISUAL_BEVEL_PERCENTAGE;
        public static readonly int BevelSmoothness = NDalic.PRIMITIVE_VISUAL_BEVEL_SMOOTHNESS;
        public static readonly int LightPosition = NDalic.PRIMITIVE_VISUAL_LIGHT_POSITION;
    }

    public struct TextVisualProperty
    {
        public static readonly int Text = NDalic.TEXT_VISUAL_TEXT;
        public static readonly int FontFamily = NDalic.TEXT_VISUAL_FONT_FAMILY;
        public static readonly int FontStyle = NDalic.TEXT_VISUAL_FONT_STYLE;
        public static readonly int PointSize = NDalic.TEXT_VISUAL_POINT_SIZE;
        public static readonly int MultiLine = NDalic.TEXT_VISUAL_MULTI_LINE;
        public static readonly int HorizontalAlignment = NDalic.TEXT_VISUAL_HORIZONTAL_ALIGNMENT;
        public static readonly int VerticalAlignment = NDalic.TEXT_VISUAL_VERTICAL_ALIGNMENT;
        public static readonly int TextColor = NDalic.TEXT_VISUAL_TEXT_COLOR;
        public static readonly int EnableMarkup = NDalic.TEXT_VISUAL_ENABLE_MARKUP;
    }


}
