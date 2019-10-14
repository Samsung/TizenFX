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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// A class encapsulating the transform map of the visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class VisualMap
    {
        /// <summary>
        /// outputVisualMap.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected PropertyMap _outputVisualMap = null;

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

        private Vector2 _visualSize = null;
        private Vector2 _visualOffset = null;
        private Vector2 _visualOffsetPolicy = null;
        private Vector2 _visualSizePolicy = null;
        private Visual.AlignType? _visualOrigin = null;
        private Visual.AlignType? _visualAnchorPoint = null;

        private PropertyMap _visualTransformMap = null;

        private int? _depthIndex = null;

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
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void ComposingPropertyMap()
        {
            _outputVisualMap = new PropertyMap();
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
    }
}
