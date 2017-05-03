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
    using Tizen.NUI.UIComponents;
    using Tizen.NUI.BaseComponents;

    /// <summary>
    /// A class encapsulating the transform map of visual.
    /// </summary>
    public class VisualMap
    {
        private Vector2 _visualSize = null;
        private Vector2 _visualOffset = null;
        private Vector2 _visualOffsetPolicy = null;
        private Vector2 _visualSizePolicy = null;
        private Visual.AlignType? _visualOrigin = null;
        private Visual.AlignType? _visualAnchorPoint = null;

        private PropertyMap _visualTransformMap = null;

        private float? _depthIndex = null;
        protected PropertyMap _outputVisualMap = null;

        internal string Name
        {
            set;
            get;
        }

        internal int VisualIndex
        {
            set;
            get;
        }

        internal VisualView Parent
        {
            set;
            get;
        }

        public VisualMap()
        {
        }

        /// <summary>
        /// Get or set size of the visual.<br>
        /// It can be either relative (percentage of the parent)
        /// or absolute (in world units).<br>
        /// Optional.
        /// </summary>
        public Vector2 Size
        {
            get
            {
                return _visualSize ?? (new Vector2(1.0f, 1.0f));
            }
            set
            {
                _visualSize = value;
                if (_visualSizePolicy == null)
                {
                    _visualSizePolicy = new Vector2(0.0f, 0.0f);
                }
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set offset of the visual.<br>
        /// It can be either relative (percentage of the parent)
        /// or absolute (in world units).<br>
        /// Optional.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return _visualOffset ?? (new Vector2(0.0f, 0.0f));
            }
            set
            {
                _visualOffset = value;
                if (_visualOffsetPolicy == null)
                {
                    _visualOffsetPolicy = new Vector2(0.0f, 0.0f);
                }
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set relative size of the visual<br>
        /// (percentage [0.0f to 1.0f] of the control).<br>
        /// Optional.
        /// </summary>
        public RelativeVector2 RelativeSize
        {
            get
            {
                return _visualSize ?? (new RelativeVector2(1.0f, 1.0f));
            }
            set
            {
                _visualSize = value;
                _visualSizePolicy = new Vector2(0.0f, 0.0f);
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set relative offset of the visual<br>
        /// (percentage [0.0f to 1.0f] of the control).<br>
        /// Optional.
        /// </summary>
        public RelativeVector2 RelativePosition
        {
            get
            {
                return _visualOffset ?? (new RelativeVector2(0.0f, 0.0f));
            }
            set
            {
                _visualOffset = value;
                _visualOffsetPolicy = new Vector2(0.0f, 0.0f);
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set whether the x and y offset values are relative<br>
        /// (percentage [0.0f to 1.0f] of the control) or absolute (in world units).<br>
        /// Be default, both the x and the y offset is relative.<br>
        /// Optional.
        /// </summary>
        public VisualTransformPolicyType PositionPolicy
        {
            get
            {
                if (_visualOffsetPolicy != null && _visualOffsetPolicy.X == 1.0f
                    && _visualOffsetPolicy.Y == 1.0f)
                {
                    return VisualTransformPolicyType.Absolute;
                }
                return VisualTransformPolicyType.Relative;
            }
            set
            {
                switch (value)
                {
                    case VisualTransformPolicyType.Relative:
                        _visualOffsetPolicy = new Vector2(0.0f, 0.0f);
                        break;
                    case VisualTransformPolicyType.Absolute:
                        _visualOffsetPolicy = new Vector2(1.0f, 1.0f);
                        break;
                    default:
                        _visualOffsetPolicy = new Vector2(0.0f, 0.0f);
                        break;
                }
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set whether the x offset values are relative<br>
        /// (percentage [0.0f to 1.0f] of the control) or absolute (in world units).<br>
        /// Be default, the x offset is relative.<br>
        /// Optional.
        /// </summary>
        public VisualTransformPolicyType PositionPolicyX
        {
            get
            {
                if (_visualOffsetPolicy != null && _visualOffsetPolicy.X == 1.0f)
                {
                    return VisualTransformPolicyType.Absolute;
                }
                return VisualTransformPolicyType.Relative;
            }
            set
            {
                if (_visualOffsetPolicy == null)
                {
                    _visualOffsetPolicy = new Vector2(0.0f, 0.0f);
                }

                switch (value)
                {
                    case VisualTransformPolicyType.Relative:
                        _visualOffsetPolicy.X = 0.0f;
                        break;
                    case VisualTransformPolicyType.Absolute:
                        _visualOffsetPolicy.X = 1.0f;
                        break;
                    default:
                        _visualOffsetPolicy.X = 0.0f;
                        break;
                }

                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set whether the y offset values are relative<br>
        /// (percentage [0.0f to 1.0f] of the control) or absolute (in world units).<br>
        /// Be default, the y offset is relative.<br>
        /// Optional.
        /// </summary>
        public VisualTransformPolicyType PositionPolicyY
        {
            get
            {
                if (_visualOffsetPolicy != null && _visualOffsetPolicy.Y == 1.0f)
                {
                    return VisualTransformPolicyType.Absolute;
                }
                return VisualTransformPolicyType.Relative;
            }
            set
            {
                if (_visualOffsetPolicy == null)
                {
                    _visualOffsetPolicy = new Vector2(0.0f, 0.0f);
                }

                switch (value)
                {
                    case VisualTransformPolicyType.Relative:
                        _visualOffsetPolicy.Y = 0.0f;
                        break;
                    case VisualTransformPolicyType.Absolute:
                        _visualOffsetPolicy.Y = 1.0f;
                        break;
                    default:
                        _visualOffsetPolicy.Y = 0.0f;
                        break;
                }
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set whether the width or height size values are relative<br>
        /// (percentage [0.0f to 1.0f] of the control) or absolute (in world units).<br>
        /// Be default, both the width and the height offset is relative to the control's size.<br>
        /// Optional.
        /// </summary>
        public VisualTransformPolicyType SizePolicy
        {
            get
            {
                if (_visualSizePolicy != null && _visualSizePolicy.X == 1.0f
                    && _visualSizePolicy.Y == 1.0f)
                {
                    return VisualTransformPolicyType.Absolute;
                }
                return VisualTransformPolicyType.Relative;
            }
            set
            {
                switch (value)
                {
                    case VisualTransformPolicyType.Relative:
                        _visualSizePolicy = new Vector2(0.0f, 0.0f);
                        break;
                    case VisualTransformPolicyType.Absolute:
                        _visualSizePolicy = new Vector2(1.0f, 1.0f);
                        break;
                    default:
                        _visualSizePolicy = new Vector2(0.0f, 0.0f);
                        break;
                }
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set whether the width size values are relative<br>
        /// (percentage [0.0f to 1.0f] of the control) or absolute (in world units).<br>
        /// Be default, the width value is relative to the control's width.<br>
        /// Optional.
        /// </summary>
        public VisualTransformPolicyType SizePolicyWidth
        {
            get
            {
                if (_visualSizePolicy != null && _visualSizePolicy.Width == 1.0f)
                {
                    return VisualTransformPolicyType.Absolute;
                }
                return VisualTransformPolicyType.Relative;
            }
            set
            {
                if (_visualSizePolicy == null)
                {
                    _visualSizePolicy = new Vector2(0.0f, 0.0f);
                }

                switch (value)
                {
                    case VisualTransformPolicyType.Relative:
                        _visualSizePolicy.Width = 0.0f;
                        break;
                    case VisualTransformPolicyType.Absolute:
                        _visualSizePolicy.Width = 1.0f;
                        break;
                    default:
                        _visualSizePolicy.Width = 0.0f;
                        break;
                }
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set whether the height size values are relative<br>
        /// (percentage [0.0f to 1.0f] of the control) or absolute (in world units).<br>
        /// Be default, both the height value is relative to the control's height.<br>
        /// Optional.
        /// </summary>
        public VisualTransformPolicyType SizePolicyHeight
        {
            get
            {
                if (_visualSizePolicy != null && _visualSizePolicy.Height == 1.0f)
                {
                    return VisualTransformPolicyType.Absolute;
                }
                return VisualTransformPolicyType.Relative;
            }
            set
            {
                if (_visualSizePolicy == null)
                {
                    _visualSizePolicy = new Vector2(0.0f, 0.0f);
                }

                switch (value)
                {
                    case VisualTransformPolicyType.Relative:
                        _visualSizePolicy.Height = 0.0f;
                        break;
                    case VisualTransformPolicyType.Absolute:
                        _visualSizePolicy.Height = 1.0f;
                        break;
                    default:
                        _visualSizePolicy.Height = 0.0f;
                        break;
                }
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the origin of the visual within its control area.<br>
        /// By default, the origin is Center.<br>
        /// Optional.
        /// </summary>
        public Visual.AlignType Origin
        {
            get
            {
                return _visualOrigin ?? (Visual.AlignType.Center);
            }
            set
            {
                _visualOrigin = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the anchor-point of the visual.<br>
        /// By default, the anchor point is Center.<br>
        /// Optional.
        /// </summary>
        public Visual.AlignType AnchorPoint
        {
            get
            {
                return _visualAnchorPoint ?? (Visual.AlignType.Center);
            }
            set
            {
                _visualAnchorPoint = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the depth index of the visual.<br>
        /// By default, the depth index is 0.<br>
        /// Optional.
        /// </summary>
        public float DepthIndex
        {
            get
            {
                return _depthIndex ?? (0.0f);
            }
            set
            {
                _depthIndex = value;
            }
        }

        private void ComposingTransformMap()
        {
            _visualTransformMap = new PropertyMap();
            if (_visualSize != null) { _visualTransformMap.Add((int)VisualTransformPropertyType.Size, new PropertyValue(_visualSize)); }
            if (_visualOffset != null) { _visualTransformMap.Add((int)VisualTransformPropertyType.Offset, new PropertyValue(_visualOffset)); }
            if (_visualOffsetPolicy != null) { _visualTransformMap.Add((int)VisualTransformPropertyType.OffsetPolicy, new PropertyValue(_visualOffsetPolicy)); }
            if (_visualSizePolicy != null) { _visualTransformMap.Add((int)VisualTransformPropertyType.SizePolicy, new PropertyValue(_visualSizePolicy)); }
            if (_visualOrigin != null) { _visualTransformMap.Add((int)VisualTransformPropertyType.Origin, new PropertyValue((int)_visualOrigin)); }
            if (_visualAnchorPoint != null) { _visualTransformMap.Add((int)VisualTransformPropertyType.AnchorPoint, new PropertyValue((int)_visualAnchorPoint)); }
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

        internal void UpdateVisual()
        {
            if (VisualIndex > 0)
            {
#if DEBUG_ON
                Tizen.Log.Debug("NUI", "UpdateVisual()! VisualIndex=" + VisualIndex);
#endif
                Parent.UpdateVisual(VisualIndex, Name, this);
            }
            else
            {
#if DEBUG_ON
                Tizen.Log.Debug("NUI", "VisualIndex was not set");
#endif
            }
        }

        protected PropertyMap _shader = null;
        //private PropertyMap _transform = null;
        protected bool? _premultipliedAlpha = null;
        protected Color _mixColor = null;
        protected float? _opacity = null;
        protected PropertyMap _commonlyUsedMap = null;

        /// <summary>
        /// The shader to use in the visual.
        /// </summary>
        public PropertyMap Shader
        {
            get
            {
                return _shader;
            }
            set
            {
                _shader = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Enables/disables premultiplied alpha. <br>
        /// The premultiplied alpha is false by default unless this behaviour is modified by the derived Visual type.
        /// </summary>
        public bool PremultipliedAlpha
        {
            get
            {
                return _premultipliedAlpha ?? (false);
            }
            set
            {
                _premultipliedAlpha = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Mix color is a blend color for any visual.
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Opacity is the alpha component of the mixColor, above.
        /// </summary>
        public float Opacity
        {
            get
            {
                return _opacity ?? (1.0f);
            }
            set
            {
                _opacity = value;
                UpdateVisual();
            }
        }

    }

    /// <summary>
    /// A class encapsulating the property map of a image visual.
    /// </summary>
    public class ImageVisual : VisualMap
    {
        public ImageVisual() : base()
        {
        }

        private string _url = null;
        private FittingModeType? _fittingMode = null;
        private SamplingModeType? _samplingMode = null;
        private int? _desiredWidth = null;
        private int? _desiredHeight = null;
        private bool? _synchronousLoading = false;
        private bool? _borderOnly = null;
        private Vector4 _pixelArea = null;
        private WrapModeType? _wrapModeU = null;
        private WrapModeType? _wrapModeV = null;

        /// <summary>
        /// Get or set the URL of the image.<br>
        /// Mandatory.
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set fitting options, used when resizing images to fit desired dimensions.<br>
        /// If not supplied, default is FittingModeType.ShrinkToFit.<br>
        /// For Normal Quad images only.<br>
        /// Optional.
        /// </summary>
        public FittingModeType FittingMode
        {
            get
            {
                return _fittingMode ?? (FittingModeType.ShrinkToFit);
            }
            set
            {
                _fittingMode = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set filtering options, used when resizing images to sample original pixels.<br>
        /// If not supplied, default is SamplingModeType.Box.<br>
        /// For Normal Quad images only.<br>
        /// Optional.
        /// </summary>
        public SamplingModeType SamplingMode
        {
            get
            {
                return _samplingMode ?? (SamplingModeType.Box);
            }
            set
            {
                _samplingMode = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the desired image width.<br>
        /// If not specified, the actual image width is used.<br>
        /// For Normal Quad images only.<br>
        /// Optional.
        /// </summary>
        public int DesiredWidth
        {
            get
            {
                return _desiredWidth ?? (-1);
            }
            set
            {
                _desiredWidth = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the desired image height.<br>
        /// If not specified, the actual image height is used.<br>
        /// For Normal Quad images only.<br>
        /// Optional.
        /// </summary>
        public int DesiredHeight
        {
            get
            {
                return _desiredHeight ?? (-1);
            }
            set
            {
                _desiredHeight = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set whether to load the image synchronously.<br>
        /// If not specified, the default is false, i.e. the image is loaded asynchronously.<br>
        /// For Normal Quad images only.<br>
        /// Optional.
        /// </summary>
        public bool SynchronousLoading
        {
            get
            {
                return _synchronousLoading ?? (false);
            }
            set
            {
                _synchronousLoading = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set whether to draws the borders only(If true).<br>
        /// If not specified, the default is false.<br>
        /// For N-Patch images only.<br>
        /// Optional.
        /// </summary>
        public bool BorderOnly
        {
            get
            {
                return _borderOnly ?? (false);
            }
            set
            {
                _borderOnly = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the image area to be displayed.<br>
        /// It is a rectangular area.<br>
        /// The first two elements indicate the top-left position of the area, and the last two elements are the area width and height respectively.<br>
        /// If not specified, the default value is Vector4(0.0, 0.0, 1.0, 1.0), i.e. the entire area of the image.<br>
        /// For For Normal QUAD image only.<br>
        /// Optional.
        /// </summary>
        public Vector4 PixelArea
        {
            get
            {
                return _pixelArea ?? (new Vector4(0.0f, 0.0f, 1.0f, 1.0f));
            }
            set
            {
                _pixelArea = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the wrap mode for u coordinate.<br>
        /// It decides how the texture should be sampled when the u coordinate exceeds the range of 0.0 to 1.0.<br>
        /// If not specified, the default is WrapModeType.Default(CLAMP).<br>
        /// For Normal QUAD image only.<br>
        /// Optional.
        /// </summary>
        public WrapModeType WrapModeU
        {
            get
            {
                return _wrapModeU ?? (WrapModeType.Default);
            }
            set
            {
                _wrapModeU = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the wrap mode for v coordinate.<br>
        /// It decides how the texture should be sampled when the v coordinate exceeds the range of 0.0 to 1.0.<br>
        /// The first two elements indicate the top-left position of the area, and the last two elements are the area width and height respectively.<br>
        /// If not specified, the default is WrapModeType.Default(CLAMP).<br>
        /// For Normal QUAD image only.
        /// Optional.
        /// </summary>
        public WrapModeType WrapModeV
        {
            get
            {
                return _wrapModeV ?? (WrapModeType.Default);
            }
            set
            {
                _wrapModeV = value;
                UpdateVisual();
            }
        }

        protected override void ComposingPropertyMap()
        {
            if (_url != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
                _outputVisualMap.Add(ImageVisualProperty.URL, new PropertyValue(_url));
                if (_fittingMode != null) { _outputVisualMap.Add(ImageVisualProperty.FittingMode, new PropertyValue((int)_fittingMode)); }
                if (_samplingMode != null) { _outputVisualMap.Add(ImageVisualProperty.SamplingMode, new PropertyValue((int)_samplingMode)); }
                if (_desiredWidth != null) { _outputVisualMap.Add(ImageVisualProperty.DesiredWidth, new PropertyValue((int)_desiredWidth)); }
                if (_desiredHeight != null) { _outputVisualMap.Add(ImageVisualProperty.DesiredHeight, new PropertyValue((int)_desiredHeight)); }
                if (_synchronousLoading != null) { _outputVisualMap.Add(ImageVisualProperty.SynchronousLoading, new PropertyValue((bool)_synchronousLoading)); }
                if (_borderOnly != null) { _outputVisualMap.Add(ImageVisualProperty.BorderOnly, new PropertyValue((bool)_borderOnly)); }
                if (_pixelArea != null) { _outputVisualMap.Add(ImageVisualProperty.PixelArea, new PropertyValue(_pixelArea)); }
                if (_wrapModeU != null) { _outputVisualMap.Add(ImageVisualProperty.WrapModeU, new PropertyValue((int)_wrapModeU)); }
                if (_wrapModeV != null) { _outputVisualMap.Add(ImageVisualProperty.WrapModeV, new PropertyValue((int)_wrapModeV)); }
                if (_shader != null) { _outputVisualMap.Add((int)Visual.Property.Shader, new PropertyValue(_shader)); }
                if (_premultipliedAlpha != null) { _outputVisualMap.Add((int)Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
                if (_mixColor != null) { _outputVisualMap.Add((int)Visual.Property.MixColor, new PropertyValue(_mixColor)); }
                if (_opacity != null) { _outputVisualMap.Add((int)Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a text visual.
    /// </summary>
    public class TextVisual : VisualMap
    {
        public TextVisual() : base()
        {
        }

        private string _text = null;
        private string _fontFamily = null;
        private PropertyMap _fontStyle = null;
        private float? _pointSize = null;
        private bool? _multiLine = null;
        private string _horizontalAlignment = null;
        private string _verticalAlignment = null;
        private Color _textColor = null;
        private bool? _enableMarkup = null;

        /// <summary>
        /// Get or set the text to display in UTF-8 format.<br>
        /// Mandatory.
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the requested font family to use.<br>
        /// Optional.
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the requested font style to use.<br>
        /// Optional.
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the size of font in points.<br>
        /// Mandatory.
        /// </summary>
        public float PointSize
        {
            get
            {
                return _pointSize ?? (0.0f);
            }
            set
            {
                _pointSize = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the single-line or multi-line layout option.<br>
        /// If not specified, the default is false.<br>
        /// Optional.
        /// </summary>
        public bool MultiLine
        {
            get
            {
                return _multiLine ?? (false);
            }
            set
            {
                _multiLine = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the line horizontal alignment.<br>
        /// If not specified, the default is Begin.<br>
        /// Optional.
        /// </summary>
        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                switch (_horizontalAlignment)
                {
                    case "BEGIN":
                        return HorizontalAlignment.Begin;
                    case "CENTER":
                        return HorizontalAlignment.Center;
                    case "END":
                        return HorizontalAlignment.End;
                    default:
                        return HorizontalAlignment.Begin;
                }
            }
            set
            {
                switch (value)
                {
                    case HorizontalAlignment.Begin:
                    {
                        _horizontalAlignment = "BEGIN";
                        break;
                    }
                    case HorizontalAlignment.Center:
                    {
                        _horizontalAlignment = "CENTER";
                        break;
                    }
                    case HorizontalAlignment.End:
                    {
                        _horizontalAlignment = "END";
                        break;
                    }
                    default:
                    {
                        _horizontalAlignment = "BEGIN";
                        break;
                    }
                }
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the line vertical alignment.<br>
        /// If not specified, the default is Top.<br>
        /// Optional.
        /// </summary>
        public VerticalAlignment VerticalAlignment
        {
            get
            {
                switch (_verticalAlignment)
                {
                    case "TOP":
                        return VerticalAlignment.Top;
                    case "CENTER":
                        return VerticalAlignment.Center;
                    case "BOTTOM":
                        return VerticalAlignment.Bottom;
                    default:
                        return VerticalAlignment.Top;
                }
            }
            set
            {
                switch (value)
                {
                    case VerticalAlignment.Top:
                    {
                        _verticalAlignment = "TOP";
                        break;
                    }
                    case VerticalAlignment.Center:
                    {
                        _verticalAlignment = "CENTER";
                        break;
                    }
                    case VerticalAlignment.Bottom:
                    {
                        _verticalAlignment = "BOTTOM";
                        break;
                    }
                    default:
                    {
                        _verticalAlignment = "TOP";
                        break;
                    }
                }
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the color of the text.<br>
        /// Optional.
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set whether the mark-up processing is enabled.<br>
        /// Optional.
        /// </summary>
        public bool EnableMarkup
        {
            get
            {
                return _enableMarkup ?? (false);
            }
            set
            {
                _enableMarkup = value;
                UpdateVisual();
            }
        }

        protected override void ComposingPropertyMap()
        {
            if (_text != null && _pointSize != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
                _outputVisualMap.Add(TextVisualProperty.Text, new PropertyValue(_text));
                _outputVisualMap.Add(TextVisualProperty.PointSize, new PropertyValue((float)_pointSize));
                if (_fontFamily != null) { _outputVisualMap.Add(TextVisualProperty.FontFamily, new PropertyValue(_fontFamily)); }
                if (_fontStyle != null) { _outputVisualMap.Add(TextVisualProperty.FontStyle, new PropertyValue(_fontStyle)); }
                if (_multiLine != null) { _outputVisualMap.Add(TextVisualProperty.MultiLine, new PropertyValue((bool)_multiLine)); }
                if (_horizontalAlignment != null) { _outputVisualMap.Add(TextVisualProperty.HorizontalAlignment, new PropertyValue(_horizontalAlignment)); }
                if (_verticalAlignment != null) { _outputVisualMap.Add(TextVisualProperty.VerticalAlignment, new PropertyValue(_verticalAlignment)); }
                if (_textColor != null) { _outputVisualMap.Add(TextVisualProperty.TextColor, new PropertyValue(_textColor)); }
                if (_enableMarkup != null) { _outputVisualMap.Add(TextVisualProperty.EnableMarkup, new PropertyValue((bool)_enableMarkup)); }
                if (_shader != null) { _outputVisualMap.Add((int)Visual.Property.Shader, new PropertyValue(_shader)); }
                if (_premultipliedAlpha != null) { _outputVisualMap.Add((int)Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
                if (_mixColor != null) { _outputVisualMap.Add((int)Visual.Property.MixColor, new PropertyValue(_mixColor)); }
                if (_opacity != null) { _outputVisualMap.Add((int)Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a border visual.
    /// </summary>
    public class BorderVisual : VisualMap
    {
        public BorderVisual() : base()
        {
        }

        private Color _color = null;
        private float? _size = null;
        private bool? _antiAliasing = null;

        /// <summary>
        /// Get or set the color of the border.<br>
        /// Mandatory.
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the width of the border (in pixels).<br>
        /// Mandatory.
        /// </summary>
        public float BorderSize
        {
            get
            {
                return _size ?? (-1.0f);
            }
            set
            {
                _size = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set whether anti-aliasing of the border is required.<br>
        /// If not supplied, default is false.<br>
        /// Optional.
        /// </summary>
        public bool AntiAliasing
        {
            get
            {
                return _antiAliasing ?? (false);
            }
            set
            {
                _antiAliasing = value;
                UpdateVisual();
            }
        }

        protected override void ComposingPropertyMap()
        {
            if (_color != null && _size != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Border));
                _outputVisualMap.Add(BorderVisualProperty.Size, new PropertyValue((float)_size));
                _outputVisualMap.Add(BorderVisualProperty.Color, new PropertyValue(_color));
                if (_antiAliasing != null) { _outputVisualMap.Add(BorderVisualProperty.AntiAliasing, new PropertyValue((bool)_antiAliasing)); }
                if (_shader != null) { _outputVisualMap.Add((int)Visual.Property.Shader, new PropertyValue(_shader)); }
                if (_premultipliedAlpha != null) { _outputVisualMap.Add((int)Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
                if (_mixColor != null) { _outputVisualMap.Add((int)Visual.Property.MixColor, new PropertyValue(_mixColor)); }
                if (_opacity != null) { _outputVisualMap.Add((int)Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a color visual.
    /// </summary>
    public class ColorVisual : VisualMap
    {
        public ColorVisual() : base()
        {
        }

        private Color _mixColorForColorVisual = null;

        /// <summary>
        /// Get or set the solid color required.<br>
        /// Mandatory.
        /// </summary>
        public Color Color
        {
            get
            {
                return _mixColorForColorVisual;
            }
            set
            {
                _mixColorForColorVisual = value;
                UpdateVisual();
            }
        }

        protected override void ComposingPropertyMap()
        {
            if (_mixColorForColorVisual != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color));
                _outputVisualMap.Add(ColorVisualProperty.MixColor, new PropertyValue(_mixColorForColorVisual));
                if (_shader != null) { _outputVisualMap.Add((int)Visual.Property.Shader, new PropertyValue(_shader)); }
                if (_premultipliedAlpha != null) { _outputVisualMap.Add((int)Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
                if (_opacity != null) { _outputVisualMap.Add((int)Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a gradient visual.
    /// </summary>
    public class GradientVisual : VisualMap
    {
        public GradientVisual() : base()
        {
        }

        private Vector2 _startPosition = null;
        private Vector2 _endPosition = null;
        private Vector2 _center = null;
        private float? _radius = null;
        private PropertyArray _stopOffset = null;
        private PropertyArray _stopColor = null;
        private GradientVisualUnitsType? _units = null;
        private GradientVisualSpreadMethodType? _spreadMethod = null;

        /// <summary>
        /// Get or set the start position of a linear gradient.<br>
        /// Mandatory for Linear.<br>
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the end position of a linear gradient.<br>
        /// Mandatory for Linear.<br>
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the center point of a radial gradient.<br>
        /// Mandatory for Radial.<br>
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the size of the radius of a radial gradient.<br>
        /// Mandatory for Radial.<br>
        /// </summary>
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
        /// Get or set all the stop offsets.<br>
        /// A PropertyArray of float.<br>
        /// If not supplied, default is 0.0f and 1.0f.<br>
        /// Optional.
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the color at the stop offsets.<br>
        /// A PropertyArray of Color.<br>
        /// At least 2 values required to show a gradient.<br>
        /// Mandatory.
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set defines the coordinate system for certain attributes of the points in a gradient.<br>
        /// If not supplied, default is GradientVisualUnitsType.ObjectBoundingBox.<br>
        /// Optional.
        /// </summary>
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
        /// Get or set indicates what happens if the gradient starts or ends inside the bounds of the target rectangle.<br>
        /// If not supplied, default is GradientVisualSpreadMethodType.Pad.<br>
        /// Optional.
        /// </summary>
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

        protected override void ComposingPropertyMap()
        {
            if (((_startPosition != null && _endPosition != null) || (_center != null && _radius != null)) && _stopColor != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Gradient));
                _outputVisualMap.Add(GradientVisualProperty.StopColor, new PropertyValue(_stopColor));
                if (_startPosition != null) { _outputVisualMap.Add(GradientVisualProperty.StartPosition, new PropertyValue(_startPosition)); }
                if (_endPosition != null) { _outputVisualMap.Add(GradientVisualProperty.EndPosition, new PropertyValue(_endPosition)); }
                if (_center != null) { _outputVisualMap.Add(GradientVisualProperty.Center, new PropertyValue(_center)); }
                if (_radius != null) { _outputVisualMap.Add(GradientVisualProperty.Radius, new PropertyValue((float)_radius)); }
                if (_stopOffset != null) { _outputVisualMap.Add(GradientVisualProperty.StopOffset, new PropertyValue(_stopOffset)); }
                if (_units != null) { _outputVisualMap.Add(GradientVisualProperty.Units, new PropertyValue((int)_units)); }
                if (_spreadMethod != null) { _outputVisualMap.Add(GradientVisualProperty.SpreadMethod, new PropertyValue((int)_spreadMethod)); }
                if (_shader != null) { _outputVisualMap.Add((int)Visual.Property.Shader, new PropertyValue(_shader)); }
                if (_premultipliedAlpha != null) { _outputVisualMap.Add((int)Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
                if (_mixColor != null) { _outputVisualMap.Add((int)Visual.Property.MixColor, new PropertyValue(_mixColor)); }
                if (_opacity != null) { _outputVisualMap.Add((int)Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a mesh visual.
    /// </summary>
    public class MeshVisual : VisualMap
    {
        public MeshVisual() : base()
        {
        }

        private string _objectURL = null;
        private string _materialtURL = null;
        private string _texturesPath = null;
        private MeshVisualShadingModeValue? _shadingMode = null;
        private bool? _useMipmapping = null;
        private bool? _useSoftNormals = null;
        private Vector3 _lightPosition = null;

        /// <summary>
        /// Get or set the location of the ".obj" file.<br>
        /// Mandatory.
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the location of the ".mtl" file.<br>
        /// If not specified, then a textureless object is assumed.<br>
        /// Optional.
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set path to the directory the textures (including gloss and normal) are stored in.<br>
        /// Mandatory if using material.<br>
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the type of shading mode that the mesh will use.<br>
        /// If anything the specified shading mode requires is missing, a simpler mode that can be handled with what has been supplied will be used instead.<br>
        /// If not specified, it will use the best it can support (will try MeshVisualShadingModeValue.TexturedWithDetailedSpecularLighting first).<br>
        /// Optional.
        /// </summary>
        public MeshVisualShadingModeValue ShadingMode
        {
            get
            {
                return _shadingMode ?? (MeshVisualShadingModeValue.TexturedWithDetailedSpecularLighting);
            }
            set
            {
                _shadingMode = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set whether to use mipmaps for textures or not.<br>
        /// If not specified, the default is true.<br>
        /// Optional.
        /// </summary>
        public bool UseMipmapping
        {
            get
            {
                return _useMipmapping ?? (true);
            }
            set
            {
                _useMipmapping = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set whether to average normals at each point to smooth textures or not.<br>
        /// If not specified, the default is true.<br>
        /// Optional.
        /// </summary>
        public bool UseSoftNormals
        {
            get
            {
                return _useSoftNormals ?? (true);
            }
            set
            {
                _useSoftNormals = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set the position, in stage space, of the point light that applies lighting to the model.<br>
        /// This is based off the stage's dimensions, so using the width and height of the stage halved will correspond to the center,
        /// and using all zeroes will place the light at the top left corner.<br>
        /// If not specified, the default is an offset outwards from the center of the screen.<br>
        /// Optional.
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
                UpdateVisual();
            }
        }

        protected override void ComposingPropertyMap()
        {
            if (_objectURL != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Mesh));
                _outputVisualMap.Add(MeshVisualProperty.ObjectURL, new PropertyValue(_objectURL));
                if (_materialtURL != null) { _outputVisualMap.Add(MeshVisualProperty.MaterialtURL, new PropertyValue(_materialtURL)); }
                if (_texturesPath != null) { _outputVisualMap.Add(MeshVisualProperty.TexturesPath, new PropertyValue(_texturesPath)); }
                if (_shadingMode != null) { _outputVisualMap.Add(MeshVisualProperty.ShadingMode, new PropertyValue((int)_shadingMode)); }
                if (_useMipmapping != null) { _outputVisualMap.Add(MeshVisualProperty.UseMipmapping, new PropertyValue((bool)_useMipmapping)); }
                if (_useSoftNormals != null) { _outputVisualMap.Add(MeshVisualProperty.UseSoftNormals, new PropertyValue((bool)_useSoftNormals)); }
                if (_shader != null) { _outputVisualMap.Add((int)Visual.Property.Shader, new PropertyValue(_shader)); }
                if (_premultipliedAlpha != null) { _outputVisualMap.Add((int)Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
                if (_mixColor != null) { _outputVisualMap.Add((int)Visual.Property.MixColor, new PropertyValue(_mixColor)); }
                if (_opacity != null) { _outputVisualMap.Add((int)Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a primetive visual.
    /// </summary>
    public class PrimitiveVisual : VisualMap
    {
        public PrimitiveVisual() : base()
        {
        }

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
        /// Get or set the specific shape to render.<br>
        /// If not specified, the default is PrimitiveVisualShapeType.Sphere.<br>
        /// Optional.
        /// </summary>
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
        /// Get or set the color of the shape.<br>
        /// If not specified, the default is Color(0.5, 0.5, 0.5, 1.0).<br>
        /// Applies to ALL shapes.<br>
        /// Optional.
        /// </summary>
        public Color MixColor
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
        /// Get or set the number of slices as you go around the shape.<br>
        /// For spheres and conical frustrums, this determines how many divisions there are as you go around the object.<br>
        /// If not specified, the default is 128.<br>
        /// The range is from 1 to 255.<br>
        /// Optional.
        /// </summary>
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
        /// Get or set the number of stacks as you go down the shape.<br>
        /// For spheres, 'stacks' determines how many layers there are as you go down the object.<br>
        /// If not specified, the default is 128.<br>
        /// The range is from 1 to 255.<br>
        /// Optional.
        /// </summary>
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
        /// Get or set the scale of the radius of the top circle of a conical frustrum.<br>
        /// If not specified, the default is 1.0f.<br>
        /// Applies to: - PrimitiveVisualShapeType.ConicalFrustrum<br>
        /// Only values greater than or equal to 0.0f are accepted.<br>
        /// Optional.
        /// </summary>
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
        /// Get or set the scale of the radius of the bottom circle of a conical frustrum.<br>
        /// If not specified, the default is 1.5f.<br>
        /// Applies to:  - PrimitiveVisualShapeType.ConicalFrustrum<br>
        ///              - PrimitiveVisualShapeType.Cone<br>
        /// Only values greater than or equal to 0.0f are accepted.<br>
        /// Optional.
        /// </summary>
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
        /// Get or set the scale of the height of a conic.<br>
        /// If not specified, the default is 3.0f.<br>
        /// Applies to:<br>
        ///      - PrimitiveVisualShapeType.ConicalFrustrum<br>
        ///      - PrimitiveVisualShapeType.Cone<br>
        ///      - PrimitiveVisualShapeType.Cylinder<br>
        /// Only values greater than or equal to 0.0f are accepted.<br>
        /// Optional.
        /// </summary>
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
        /// Get or set the scale of the radius of a cylinder.<br>
        /// If not specified, the default is 1.0f.<br>
        /// Applies to:<br>
        ///      - PrimitiveVisualShapeType.Cylinder<br>
        /// Only values greater than or equal to 0.0f are accepted.<br>
        /// Optional.
        /// </summary>
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
        /// Get or set the dimensions of a cuboid. Scales in the same fashion as a 9-patch image.<br>
        /// If not specified, the default is Vector3.One.<br>
        /// Applies to:<br>
        ///      - PrimitiveVisualShapeType.Cube<br>
        ///      - PrimitiveVisualShapeType.Octahedron<br>
        ///      - PrimitiveVisualShapeType.BevelledCube<br>
        /// Each vector3 parameter should be greater than or equal to 0.0f.<br>
        /// Optional.
        /// </summary>
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
        /// Get or set determines how bevelled the cuboid should be, based off the smallest dimension.<br>
        /// Bevel percentage ranges from 0.0 to 1.0. It affects the ratio of the outer face widths to the width of the overall cube.<br>
        /// If not specified, the default is 0.0f (no bevel).<br>
        /// Applies to:<br>
        ///      - PrimitiveVisualShapeType.BevelledCube<br>
        /// The range is from 0.0f to 1.0f.<br>
        /// Optional.
        /// </summary>
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
        /// Get or set defines how smooth the bevelled edges should be.<br>
        /// If not specified, the default is 0.0f (sharp edges).<br>
        /// Applies to:<br>
        ///      - PrimitiveVisualShapeType.BevelledCube<br>
        /// The range is from 0.0f to 1.0f.<br>
        /// Optional.
        /// </summary>
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
        /// Get or set the position, in stage space, of the point light that applies lighting to the model.<br>
        /// This is based off the stage's dimensions, so using the width and height of the stage halved will correspond to the center,
        /// and using all zeroes will place the light at the top left corner.<br>
        /// If not specified, the default is an offset outwards from the center of the screen.<br>
        /// Applies to ALL shapes.<br>
        /// Optional.
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
                UpdateVisual();
            }
        }

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
            if (_shader != null) { _outputVisualMap.Add((int)Visual.Property.Shader, new PropertyValue(_shader)); }
            if (_premultipliedAlpha != null) { _outputVisualMap.Add((int)Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
            if (_opacity != null) { _outputVisualMap.Add((int)Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a n-patch image visual.
    /// </summary>
    public class NPatchVisual : VisualMap
    {
        public NPatchVisual() : base()
        {
        }

        private string _url = null;
        private bool? _borderOnly = null;
        private Rectangle _border = null;

        /// <summary>
        /// Get or set the URL of the image.<br>
        /// Mandatory.
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
                UpdateVisual();
            }
        }

        /// <summary>
        /// Get or set whether to draws the borders only(If true).<br>
        /// If not specified, the default is false.<br>
        /// For N-Patch images only.<br>
        /// Optional.
        /// </summary>
        public bool BorderOnly
        {
            get
            {
                return _borderOnly ?? false;
            }
            set
            {
                _borderOnly = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// The border of the image in the order: left, right, bottom, top.<br>
        /// For N-Patch images only.<br>
        /// Optional.
        /// </summary>
        public Rectangle Border
        {
            get
            {
                return _border;
            }
            set
            {
                _border = value;
                UpdateVisual();
            }
        }

        protected override void ComposingPropertyMap()
        {
            if (_url != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.NPatch));
                _outputVisualMap.Add(NpatchImageVisualProperty.URL, new PropertyValue(_url));
                if (_borderOnly != null) { _outputVisualMap.Add(NpatchImageVisualProperty.BorderOnly, new PropertyValue((bool)_borderOnly)); }
                if (_border != null) { _outputVisualMap.Add(NpatchImageVisualProperty.Border, new PropertyValue(_border)); }
                if (_shader != null) { _outputVisualMap.Add((int)Visual.Property.Shader, new PropertyValue(_shader)); }
                if (_premultipliedAlpha != null) { _outputVisualMap.Add((int)Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
                if (_mixColor != null) { _outputVisualMap.Add((int)Visual.Property.MixColor, new PropertyValue(_mixColor)); }
                if (_opacity != null) { _outputVisualMap.Add((int)Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a SVG visual.
    /// </summary>
    public class SVGVisual : VisualMap
    {
        public SVGVisual() : base()
        {
        }

        private string _url = null;

        public string URL
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                UpdateVisual();
            }
        }

        protected override void ComposingPropertyMap()
        {
            if (_url != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.SVG));
                _outputVisualMap.Add(ImageVisualProperty.URL, new PropertyValue(_url));
                if (_shader != null) { _outputVisualMap.Add((int)Visual.Property.Shader, new PropertyValue(_shader)); }
                if (_premultipliedAlpha != null) { _outputVisualMap.Add((int)Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
                if (_mixColor != null) { _outputVisualMap.Add((int)Visual.Property.MixColor, new PropertyValue(_mixColor)); }
                if (_opacity != null) { _outputVisualMap.Add((int)Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a Animated Image(AGIF) visual.
    /// </summary>
    public class AnimatedImageVisual : VisualMap
    {
        public AnimatedImageVisual() : base()
        {
        }

        private string _url = null;

        public string URL
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                UpdateVisual();
            }
        }

        protected override void ComposingPropertyMap()
        {
            if (_url != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.AnimatedImage));
                _outputVisualMap.Add(ImageVisualProperty.URL, new PropertyValue(_url));
                if (_shader != null) { _outputVisualMap.Add((int)Visual.Property.Shader, new PropertyValue(_shader)); }
                if (_premultipliedAlpha != null) { _outputVisualMap.Add((int)Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
                if (_mixColor != null) { _outputVisualMap.Add((int)Visual.Property.MixColor, new PropertyValue(_mixColor)); }
                if (_opacity != null) { _outputVisualMap.Add((int)Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of a visual transition(Animator).
    /// </summary>
    public class VisualAnimator : VisualMap
    {
        public VisualAnimator() : base()
        {
        }

        private string _alphaFunction = null;
        private int _startTime = 0;
        private int _endTime = 0;
        private string _target = null;
        private string _propertyIndex = null;
        private object _destinationValue = null;

        public AlphaFunction.BuiltinFunctions AlphaFunction
        {
            get
            {
                switch (_alphaFunction)
                {
                    case "LINEAR":
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.Linear;
                    case "REVERSE":
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.Reverse;
                    case "EASE_IN_SQUARE":
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInSquare;
                    case "EASE_OUT_SQUARE":
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutSquare;
                    case "EASE_IN":
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseIn;
                    case "EASE_OUT":
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOut;
                    case "EASE_IN_OUT":
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInOut;
                    case "EASE_IN_SINE":
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInSine;
                    case "EASE_OUT_SINE":
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutSine;
                    case "EASE_IN_OUT_SINE":
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInOutSine;
                    case "BOUNCE":
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.Bounce;
                    case "SIN":
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.Sin;
                    case "EASE_OUT_BACK":
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutBack;
                    default:
                        return Tizen.NUI.AlphaFunction.BuiltinFunctions.Default;
                }
            }
            set
            {
                switch (value)
                {
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Linear:
                    {
                        _alphaFunction = "LINEAR";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Reverse:
                    {
                        _alphaFunction = "REVERSE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInSquare:
                    {
                        _alphaFunction = "EASE_IN_SQUARE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutSquare:
                    {
                        _alphaFunction = "EASE_OUT_SQUARE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseIn:
                    {
                        _alphaFunction = "EASE_IN";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOut:
                    {
                        _alphaFunction = "EASE_OUT";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInOut:
                    {
                        _alphaFunction = "EASE_IN_OUT";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInSine:
                    {
                        _alphaFunction = "EASE_IN_SINE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutSine:
                    {
                        _alphaFunction = "EASE_OUT_SINE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInOutSine:
                    {
                        _alphaFunction = "EASE_IN_OUT_SINE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Bounce:
                    {
                        _alphaFunction = "BOUNCE";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Sin:
                    {
                        _alphaFunction = "SIN";
                        break;
                    }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutBack:
                    {
                        _alphaFunction = "EASE_OUT_BACK";
                        break;
                    }
                    default:
                    {
                        _alphaFunction = "DEFAULT";
                        break;
                    }
                }
            }
        }

        public int StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        public int EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        public string Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }

        public string PropertyIndex
        {
            get
            {
                return _propertyIndex;
            }
            set
            {
                _propertyIndex = value;
            }
        }

        public object DestinationValue
        {
            get
            {
                return _destinationValue;
            }
            set
            {
                _destinationValue = value;
            }
        }

        protected override void ComposingPropertyMap()
        {
            PropertyMap _animator = new PropertyMap();
            _animator.Add("alphaFunction", new PropertyValue(_alphaFunction));

            PropertyMap _timePeriod = new PropertyMap();
            _timePeriod.Add("duration", new PropertyValue((_endTime - _startTime) / 1000.0f));
            _timePeriod.Add("delay", new PropertyValue(_startTime / 1000.0f));
            _animator.Add("timePeriod", new PropertyValue(_timePeriod));

            string _str1 = _propertyIndex.Substring(0, 1);
            string _str2 = _propertyIndex.Substring(1);
            string _str = _str1.ToLower() + _str2;

            PropertyValue val = PropertyValue.CreateFromObject(_destinationValue);

            PropertyMap _transition = new PropertyMap();
            _transition.Add("target", new PropertyValue(_target));
            _transition.Add("property", new PropertyValue(_str));
            _transition.Add("targetValue", val);
            _transition.Add("animator", new PropertyValue(_animator));

            _outputVisualMap = _transition;
        }
    }

}
