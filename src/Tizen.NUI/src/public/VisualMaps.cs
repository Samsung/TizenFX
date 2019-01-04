/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
using System.Text;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// A class encapsulating the transform map of the visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class VisualMap
    {
        private Vector2 _visualSize = null;
        private Vector2 _visualOffset = null;
        private Vector2 _visualOffsetPolicy = null;
        private Vector2 _visualSizePolicy = null;
        private Visual.AlignType? _visualOrigin = null;
        private Visual.AlignType? _visualAnchorPoint = null;

        private PropertyMap _visualTransformMap = null;

        private int? _depthIndex = null;

        /// <summary>
        /// outputVisualMap.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VisualMap()
        {
        }

        /// <summary>
        /// Gets or sets the size of the visual.<br />
        /// It can be either relative (percentage of the parent)
        /// or absolute (in world units).<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size2D Size
        {
            get
            {
                return _visualSize ?? (new Size2D(1, 1));
            }
            set
            {
                _visualSize = value;
                if (_visualSizePolicy == null)
                {
                    _visualSizePolicy = new Vector2(1.0f, 1.0f);
                }
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the offset of the visual.<br />
        /// It can be either relative (percentage of the parent)
        /// or absolute (in world units).<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                    _visualOffsetPolicy = new Vector2(1.0f, 1.0f);
                }
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the relative size of the visual<br />
        /// (percentage [0.0f to 1.0f] of the control).<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the relative offset of the visual<br />
        /// (percentage [0.0f to 1.0f] of the control).<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets whether the x and y offset values are relative<br />
        /// (percentage [0.0f to 1.0f] of the control) or absolute (in world units).<br />
        /// By default, both the x and the y offset are relative.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets whether the x offset values are relative<br />
        /// (percentage [0.0f to 1.0f] of the control) or absolute (in world units).<br />
        /// By default, the x offset is relative.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets whether the y offset values are relative<br />
        /// (percentage [0.0f to 1.0f] of the control) or absolute (in world units).<br />
        /// By default, the y offset is relative.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets whether the size values of the width or the height are relative<br />
        /// (percentage [0.0f to 1.0f] of the control) or absolute (in world units).<br />
        /// By default, offsets of both the width and the height are relative to the control's size.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets whether size values of the width are relative.<br />
        /// (percentage [0.0f to 1.0f] of the control) or absolute (in world units).<br />
        /// By default, the value of the width is relative to the control's width.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets whether size values of the height are relative<br />
        /// (percentage [0.0f to 1.0f] of the control) or absolute (in world units).<br />
        /// By default, the height value is relative to the control's height.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the origin of the visual within its control area.<br />
        /// By default, the origin is center.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the anchor point of the visual.<br />
        /// By default, the anchor point is center.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the depth index of the visual.<br />
        /// By default, the depth index is 0.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int DepthIndex
        {
            get
            {
                return _depthIndex ?? (0);
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
        /// Gets the transform map used by the visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap OutputTransformMap
        {
            get
            {
                ComposingTransformMap();
                return _visualTransformMap;
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void ComposingPropertyMap()
        {
            _outputVisualMap = new PropertyMap();
        }

        /// <summary>
        /// Gets the property map to create the visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                NUILog.Debug("UpdateVisual()! VisualIndex=" + VisualIndex);
                Parent.UpdateVisual(VisualIndex, Name, this);
            }
            else
            {
                NUILog.Debug("VisualIndex was not set");
            }
        }

        /// <summary>
        /// The shader of the visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected PropertyMap _shader = null;
        //private PropertyMap _transform = null;

        /// <summary>
        /// The premultipliedAlpha of the visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected bool? _premultipliedAlpha = null;

        /// <summary>
        /// The mixColor of the Visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected Color _mixColor = null;

        /// <summary>
        /// The opacity of the visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected float? _opacity = null;

        /// <summary>
        /// The FittingMode of the visual.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected VisualFittingModeType? _visualFittingMode = null;

        /// <summary>
        /// The map for visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected PropertyMap _commonlyUsedMap = null;

        /// <summary>
        /// The shader to use in the visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Enables or disables the premultiplied alpha. <br />
        /// The premultiplied alpha is false by default unless this behavior is modified by the derived visual type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// Opacity is the alpha component of the mix color discussed above.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// The fitting mode of the visual.
        /// The default is defined by the type of visual (if it is suitable to be stretched or not).
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public VisualFittingModeType VisualFittingMode
        {
            get
            {
                if (_visualFittingMode == null)
                {
                    if (this is AnimatedImageVisual ||
                        this is MeshVisual ||
                        this is PrimitiveVisual ||
                        this is TextVisual)
                    {
                        return VisualFittingModeType.FitKeepAspectRatio;
                    }
                    else
                    {
                        return VisualFittingModeType.Fill;
                    }
                }
                else
                {
                    return (VisualFittingModeType)_visualFittingMode;
                }
            }
            set
            {
                _visualFittingMode = value;
                UpdateVisual();
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of the image visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ImageVisual : VisualMap
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ImageVisual() : base()
        {
        }

        private string _url = null;
        private string _alphaMaskUrl = null;
        private string _auxiliaryImageUrl = null;
        private FittingModeType? _fittingMode = null;
        private SamplingModeType? _samplingMode = null;
        private int? _desiredWidth = null;
        private int? _desiredHeight = null;
        private bool? _synchronousLoading = false;
        private bool? _borderOnly = null;
        private Vector4 _pixelArea = null;
        private WrapModeType? _wrapModeU = null;
        private WrapModeType? _wrapModeV = null;
        private float? _auxiliaryImageAlpha = null;
        private float? _maskContentScale = null;
        private bool? _cropToMask = null;
        private ReleasePolicyType? _releasePolicy = null;
        private LoadPolicyType? _loadPolicy = null;
        private bool? _orientationCorrection = true;
        private bool? _atlasing = false;

        /// <summary>
        /// Gets or sets the URL of the image.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the URL of the alpha mask.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string AlphaMaskURL
        {
            get
            {
                return _alphaMaskUrl;
            }
            set
            {
                _alphaMaskUrl = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Overlays the auxiliary image on top of an NPatch image.
        /// The resulting visual image will be at least as large as the smallest possible n-patch or the auxiliary image, whichever is larger.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string AuxiliaryImageURL
        {
            get
            {
                return _auxiliaryImageUrl;
            }
            set
            {
                _auxiliaryImageUrl = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets fitting options used when resizing images to fit the desired dimensions.<br />
        /// If not supplied, the default is FittingModeType.ShrinkToFit.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets filtering options used when resizing images to the sample original pixels.<br />
        /// If not supplied, the default is SamplingModeType.Box.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the desired image width.<br />
        /// If not specified, the actual image width is used.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the desired image height.<br />
        /// If not specified, the actual image height is used.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets whether to load the image synchronously.<br />
        /// If not specified, the default is false, i.e., the image is loaded asynchronously.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets whether to draw the borders only (If true).<br />
        /// If not specified, the default is false.<br />
        /// For n-patch images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the image area to be displayed.<br />
        /// It is a rectangular area.<br />
        /// The first two elements indicate the top-left position of the area, and the last two elements are the areas of the width and the height respectively.<br />
        /// If not specified, the default value is Vector4 (0.0, 0.0, 1.0, 1.0), i.e., the entire area of the image.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the wrap mode for the u coordinate.<br />
        /// It decides how the texture should be sampled when the u coordinate exceeds the range of 0.0 to 1.0.<br />
        /// If not specified, the default is WrapModeType.Default(CLAMP).<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the wrap mode for the v coordinate.<br />
        /// It decides how the texture should be sampled when the v coordinate exceeds the range of 0.0 to 1.0.<br />
        /// The first two elements indicate the top-left position of the area, and the last two elements are the areas of the width and the height respectively.<br />
        /// If not specified, the default is WrapModeType.Default(CLAMP).<br />
        /// For normal quad images only.
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Gets or sets scale factor to apply to the content image before masking.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public float MaskContentScale
        {
            get
            {
                return _maskContentScale ?? 1.0f;
            }
            set
            {
                _maskContentScale = value;
                UpdateVisual();
            }
        }

        /// <summary>
        ///  Whether to crop image to mask or scale mask to fit image.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool CropToMask
        {
            get
            {
                return _cropToMask ?? false;
            }
            set
            {
                _cropToMask = value;
                UpdateVisual();
            }
        }

        /// <summary>
        ///  An alpha value for mixing between the masked main NPatch image and the auxiliary image.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public float AuxiliaryImageAlpha
        {
            get
            {
                return _auxiliaryImageAlpha ?? 1.0f;
            }
            set
            {
                _auxiliaryImageAlpha = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the Image Visual release policy.<br/>
        /// It decides if a texture should be released from the cache or kept to reduce the loading time.<br/>
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public ReleasePolicyType ReleasePolicy
        {
            get
            {
                return _releasePolicy ?? (ReleasePolicyType.Destroyed );
            }
            set
            {
                _releasePolicy = value;
                UpdateVisual();
            }
        }


        /// <summary>
        /// Gets or sets the Image Visual image loading policy.<br />
        /// It decides if a texture should be loaded immediately after source set or only after the visual is added to the window.<br />
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public LoadPolicyType LoadPolicy
        {
            get
            {
                return _loadPolicy ?? (LoadPolicyType.Attached);
            }
            set
            {
                _loadPolicy = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets whether to automatically correct the orientation based on the Exchangeable Image File (EXIF) data.<br />
        /// If not specified, the default is true.<br />
        /// For JPEG images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool OrientationCorrection
        {
            get
            {
                return _orientationCorrection ?? (true);
            }
            set
            {
                _orientationCorrection = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Whether to use the texture atlas or not.
        /// Optional. By default atlasing is off.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool Atlasing
        {
            get
            {
                return _atlasing ?? (false);
            }
            set
            {
                _atlasing = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            if (_url != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
                _outputVisualMap.Add(ImageVisualProperty.URL, new PropertyValue(_url));
                if (_alphaMaskUrl != null ) { _outputVisualMap.Add(ImageVisualProperty.AlphaMaskURL, new PropertyValue(_alphaMaskUrl)); }
                if (_auxiliaryImageUrl != null ) { _outputVisualMap.Add(ImageVisualProperty.AuxiliaryImageURL, new PropertyValue(_auxiliaryImageUrl)); }
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
                if (_maskContentScale != null) { _outputVisualMap.Add((int)ImageVisualProperty.MaskContentScale, new PropertyValue((float)_maskContentScale)); }
                if (_cropToMask != null) { _outputVisualMap.Add((int)ImageVisualProperty.CropToMask, new PropertyValue((bool)_cropToMask)); }
                if (_auxiliaryImageAlpha != null) { _outputVisualMap.Add((int)ImageVisualProperty.AuxiliaryImageAlpha, new PropertyValue((float)_auxiliaryImageAlpha)); }
                if (_releasePolicy != null) { _outputVisualMap.Add( ImageVisualProperty.ReleasePolicy , new PropertyValue((int)_releasePolicy)); }
                if (_loadPolicy != null) { _outputVisualMap.Add( ImageVisualProperty.LoadPolicy, new PropertyValue((int)_loadPolicy)); }
                if (_orientationCorrection != null) { _outputVisualMap.Add( ImageVisualProperty.OrientationCorrection, new PropertyValue((bool)_orientationCorrection)); }
                if (_atlasing != null) { _outputVisualMap.Add( ImageVisualProperty.Atlasing, new PropertyValue((bool)_atlasing)); }
                if (_visualFittingMode != null) { _outputVisualMap.Add((int)Visual.Property.VisualFittingMode, new PropertyValue((int)_visualFittingMode)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of the text visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TextVisual : VisualMap
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        private PropertyMap _shadow = null;
        private PropertyMap _underline = null;
        private PropertyMap _outline = null;
        private PropertyMap _background = null;

        /// <summary>
        /// Gets or sets the text to display in the UTF-8 format.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the requested font family to use.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the requested font style to use.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the size of font in points.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the single-line or multi-line layout option.<br />
        /// If not specified, the default is false.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the line horizontal alignment.<br />
        /// If not specified, the default is begin.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the line vertical alignment.<br />
        /// If not specified, the default is top.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the color of the text.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets whether the mark-up processing is enabled.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Gets or sets the shadow parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public PropertyMap Shadow
        {
            get
            {
                return _shadow;
            }
            set
            {
                _shadow = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the underline parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public PropertyMap Underline
        {
            get
            {
                return _underline;
            }
            set
            {
                _underline = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the outline parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public PropertyMap Outline
        {
            get
            {
                return _outline;
            }
            set
            {
                _outline = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the background parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public PropertyMap Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                if (_shadow != null) { _outputVisualMap.Add(TextVisualProperty.Shadow, new PropertyValue(_shadow)); }
                if (_underline != null) { _outputVisualMap.Add(TextVisualProperty.Underline, new PropertyValue(_underline)); }
                if (_outline != null) { _outputVisualMap.Add(TextVisualProperty.Outline, new PropertyValue(_outline)); }
                if (_background != null) { _outputVisualMap.Add(TextVisualProperty.Background, new PropertyValue(_background)); }
                if (_visualFittingMode != null) { _outputVisualMap.Add((int)Visual.Property.VisualFittingMode, new PropertyValue((int)_visualFittingMode)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of the border visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BorderVisual : VisualMap
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BorderVisual() : base()
        {
        }

        private Color _color = null;
        private float? _size = null;
        private bool? _antiAliasing = null;

        /// <summary>
        /// Gets or sets the color of the border.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the width of the border (in pixels).<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets whether the anti-aliasing of the border is required.<br />
        /// If not supplied, the default is false.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                if (_visualFittingMode != null) { _outputVisualMap.Add((int)Visual.Property.VisualFittingMode, new PropertyValue((int)_visualFittingMode)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of the color visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ColorVisual : VisualMap
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ColorVisual() : base()
        {
        }

        private Color _mixColorForColorVisual = null;
        private bool? _renderIfTransparent = false;

        /// <summary>
        /// Gets or sets the solid color required.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Gets or sets whether to render if the MixColor is transparent.
        /// By default it is false, which means that the ColorVisual will not render if the MIX_COLOR is transparent.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool RenderIfTransparent
        {
            get
            {
                return _renderIfTransparent ?? (false);
            }
            set
            {
                _renderIfTransparent = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                if (_renderIfTransparent != null) { _outputVisualMap.Add(ColorVisualProperty.RenderIfTransparent, new PropertyValue((bool)_renderIfTransparent)); }
                if (_visualFittingMode != null) { _outputVisualMap.Add((int)Visual.Property.VisualFittingMode, new PropertyValue((int)_visualFittingMode)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of the gradient visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class GradientVisual : VisualMap
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                if (_visualFittingMode != null) { _outputVisualMap.Add((int)Visual.Property.VisualFittingMode, new PropertyValue((int)_visualFittingMode)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of the mesh visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class MeshVisual : VisualMap
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the location of the ".obj" file.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the location of the ".mtl" file.<br />
        /// If not specified, then a textureless object is assumed.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the path to the directory the textures (including gloss and normal) are stored in.<br />
        /// Mandatory if using material.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the type of shading mode that the mesh will use.<br />
        /// If anything the specified shading mode requires is missing, a simpler mode that can be handled with what has been supplied will be used instead.<br />
        /// If not specified, it will use the best it can support (will try MeshVisualShadingModeValue.TexturedWithDetailedSpecularLighting first).<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets whether to use mipmaps for textures or not.<br />
        /// If not specified, the default is true.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets whether to average normals at each point to smooth textures or not.<br />
        /// If not specified, the default is true.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets the position, in the stage space, of the point light that applies lighting to the model.<br />
        /// This is based off the stage's dimensions, so using the width and the height of the stage halved will correspond to the center,
        /// and using all zeroes will place the light at the top-left corner.<br />
        /// If not specified, the default is an offset outwards from the center of the screen.<br />
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
                if (_visualFittingMode != null) { _outputVisualMap.Add((int)Visual.Property.VisualFittingMode, new PropertyValue((int)_visualFittingMode)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of the primetive visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PrimitiveVisual : VisualMap
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
            if (_shader != null) { _outputVisualMap.Add((int)Visual.Property.Shader, new PropertyValue(_shader)); }
            if (_premultipliedAlpha != null) { _outputVisualMap.Add((int)Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
            if (_opacity != null) { _outputVisualMap.Add((int)Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
            if (_visualFittingMode != null) { _outputVisualMap.Add((int)Visual.Property.VisualFittingMode, new PropertyValue((int)_visualFittingMode)); }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of the n-patch image visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class NPatchVisual : VisualMap
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public NPatchVisual() : base()
        {
        }

        private string _url = null;
        private bool? _borderOnly = null;
        private Rectangle _border = null;

        /// <summary>
        /// Gets or sets the URL of the image.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets or sets whether to draw the borders only (If true).<br />
        /// If not specified, the default is false.<br />
        /// For n-patch images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// The border of the image is in the order: left, right, bottom, top.<br />
        /// For n-patch images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                if (_visualFittingMode != null) { _outputVisualMap.Add((int)Visual.Property.VisualFittingMode, new PropertyValue((int)_visualFittingMode)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of the SVG visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class SVGVisual : VisualMap
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SVGVisual() : base()
        {
        }

        private string _url = null;

        /// <summary>
        /// The url of the svg resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                if (_visualFittingMode != null) { _outputVisualMap.Add((int)Visual.Property.VisualFittingMode, new PropertyValue((int)_visualFittingMode)); }
            }
        }
    }

    /// <summary>
    /// A class encapsulating the property map of the animated image (AGIF) visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AnimatedImageVisual : VisualMap
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AnimatedImageVisual() : base()
        {
        }

        private List<string> _urls = null;
        private int? _batchSize = null;
        private int? _cacheSize = null;
        private float? _frameDelay = null;
        private float? _loopCount = null;

        /// <summary>
        /// Gets and Sets the url in the AnimatedImageVisual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string URL
        {
            get
            {
                if( _urls != null )
                {
                    return _urls[0];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if( _urls == null )
                {
                    _urls = new List<string>();
                    _urls.Add(value);
                }
                else
                {
                    _urls[0] = value;
                }
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets and Sets the url list in the AnimatedImageVisual.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public List<string> URLS
        {
            get
            {
                return _urls;
            }
            set
            {
                _urls = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets and Sets the batch size for pre-loading images in the AnimatedImageVisual.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int BatchSize
        {
            get
            {
                return _batchSize ?? 1;
            }
            set
            {
                _batchSize = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets and Sets the cache size for loading images in the AnimatedImageVisual.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int CacheSize
        {
            get
            {
                return _cacheSize ?? 1;
            }
            set
            {
                _cacheSize = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets and Sets The number of milliseconds between each frame in the AnimatedImageVisual.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public float FrameDelay
        {
            get
            {
                return _frameDelay ?? 0.1f;
            }
            set
            {
                _frameDelay = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets and sets the number of times the AnimatedImageVisual will be looped.
        /// The default is -1. If the number is less than 0 then it loops unlimited,otherwise loop loopCount times.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public float LoopCount
        {
            get
            {
                return _loopCount ?? -1;
            }
            set
            {
                _loopCount = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            if (_urls != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.AnimatedImage));
                if( _urls.Count == 1 )
                {
                    _outputVisualMap.Add(ImageVisualProperty.URL, new PropertyValue(_urls[0]));
                }
                else
                {
                    var urlArray = new PropertyArray();
                    foreach( var url in _urls)
                    {
                        urlArray.Add(new PropertyValue(url));
                    }
                    _outputVisualMap.Add( ImageVisualProperty.URL, ( new PropertyValue( urlArray ) ) );
                }
                if (_batchSize != null ) {_outputVisualMap.Add((int)ImageVisualProperty.BatchSize, new PropertyValue((int)_batchSize)); }
                if (_cacheSize != null ) {_outputVisualMap.Add((int)ImageVisualProperty.CacheSize, new PropertyValue((int)_cacheSize)); }
                if (_frameDelay != null ) {_outputVisualMap.Add((int)ImageVisualProperty.FrameDelay, new PropertyValue((float)_frameDelay)); }
                if (_loopCount != null ) {_outputVisualMap.Add((int)ImageVisualProperty.LoopCount, new PropertyValue((int)_loopCount)); }
                if (_shader != null) { _outputVisualMap.Add((int)Visual.Property.Shader, new PropertyValue(_shader)); }
                if (_premultipliedAlpha != null) { _outputVisualMap.Add((int)Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
                if (_mixColor != null) { _outputVisualMap.Add((int)Visual.Property.MixColor, new PropertyValue(_mixColor)); }
                if (_opacity != null) { _outputVisualMap.Add((int)Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
                if (_visualFittingMode != null) { _outputVisualMap.Add((int)Visual.Property.VisualFittingMode, new PropertyValue((int)_visualFittingMode)); }
            }
        }
    }


    //temporary fix for TCT
    /// <summary>
    /// A class encapsulating the property map of the transition data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class VisualAnimator : VisualMap
    {
        /// <summary>
        /// Create VisualAnimator object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VisualAnimator() : base()
        {
        }

        private string _alphaFunction = null;
        private int _startTime = 0;
        private int _endTime = 0;
        private string _target = null;
        private string _propertyIndex = null;
        private object _destinationValue = null;

        /// <summary>
        /// Sets and Gets the AlphaFunction of this transition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Sets and Gets the StartTime of this transition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Sets and Gets the EndTime of this transition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Sets and Gets the Target of this transition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Sets and Gets the PropertyIndex of this transition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Sets and Gets the DestinationValue of this transition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            PropertyMap _animator = new PropertyMap();
            _animator.Add("alphaFunction", new PropertyValue(_alphaFunction));

            PropertyMap _timePeriod = new PropertyMap();
            _timePeriod.Add("duration", new PropertyValue((_endTime - _startTime) / 1000.0f));
            _timePeriod.Add("delay", new PropertyValue(_startTime / 1000.0f));
            _animator.Add("timePeriod", new PropertyValue(_timePeriod));

            StringBuilder sb = new StringBuilder(_propertyIndex);
            sb[0] = (char)(sb[0] | 0x20);
            string _str = sb.ToString();

            PropertyValue val = PropertyValue.CreateFromObject(_destinationValue);

            PropertyMap _transition = new PropertyMap();
            _transition.Add("target", new PropertyValue(_target));
            _transition.Add("property", new PropertyValue(_str));
            _transition.Add("targetValue", val);
            _transition.Add("animator", new PropertyValue(_animator));

            _outputVisualMap = _transition;
        }
    }
    //temporary fix for TCT



}
