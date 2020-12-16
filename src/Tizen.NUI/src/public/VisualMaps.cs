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
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
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
        /// When deleting the field, change it to private.
        [Obsolete("Deprecated in API9, Will be removed in API11, Please use as keyword instead!")]
        [SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
        protected PropertyMap _outputVisualMap = null;

        /// <summary>
        /// The shader of the visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// When deleting the field, change it to private.
        [Obsolete("Deprecated in API9, Will be removed in API11, Please use as keyword instead!")]
        [SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
        protected PropertyMap _shader = null;
        //private PropertyMap _transform = null;

        /// <summary>
        /// The premultipliedAlpha of the visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// When deleting the field, change it to private.
        [Obsolete("Deprecated in API9, Will be removed in API11, Please use as keyword instead!")]
        [SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
        protected bool? _premultipliedAlpha = null;

        /// <summary>
        /// The mixColor of the Visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// When deleting the field, change it to private.
        [Obsolete("Deprecated in API9, Will be removed in API11, Please use as keyword instead!")]
        [SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
        protected Color _mixColor = null;

        /// <summary>
        /// The opacity of the visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// When deleting the field, change it to private.
        [Obsolete("Deprecated in API9, Will be removed in API11, Please use as keyword instead!")]
        [SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
        protected float? _opacity = null;

        /// <summary>
        /// The FittingMode of the visual.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// When deleting the field, change it to private.
        [Obsolete("Deprecated in API9, Will be removed in API11, Please use as keyword instead!")]
        [SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
        protected VisualFittingModeType? _visualFittingMode = null;

        /// <summary>
        /// The map for visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// When deleting the field, change it to private.
        [Obsolete("Deprecated in API9, Will be removed in API11, Please use as keyword instead!")]
        [SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
        protected PropertyMap _commonlyUsedMap = null;

        /// <summary>
        /// The corner radius value of the visual.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private float? cornerRadius = null;

        private Vector2 visualSize = null;
        private Vector2 visualOffset = null;
        private Vector2 visualOffsetPolicy = null;
        private Vector2 visualSizePolicy = null;
        private Visual.AlignType? visualOrigin = null;
        private Visual.AlignType? visualAnchorPoint = null;

        private PropertyMap visualTransformMap = null;

        private int? depthIndex = null;

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
                return visualSize ?? (new Size2D(1, 1));
            }
            set
            {
                visualSize = value;
                if (visualSizePolicy == null)
                {
                    visualSizePolicy = new Vector2(1.0f, 1.0f);
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
                return visualOffset ?? (new Vector2(0.0f, 0.0f));
            }
            set
            {
                visualOffset = value;
                if (visualOffsetPolicy == null)
                {
                    visualOffsetPolicy = new Vector2(1.0f, 1.0f);
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
                return visualSize ?? (new RelativeVector2(1.0f, 1.0f));
            }
            set
            {
                visualSize = value;
                visualSizePolicy = new Vector2(0.0f, 0.0f);
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
                return visualOffset ?? (new RelativeVector2(0.0f, 0.0f));
            }
            set
            {
                visualOffset = value;
                visualOffsetPolicy = new Vector2(0.0f, 0.0f);
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
                if (visualOffsetPolicy != null && visualOffsetPolicy.X == 1.0f
                    && visualOffsetPolicy.Y == 1.0f)
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
                        visualOffsetPolicy = new Vector2(0.0f, 0.0f);
                        break;
                    case VisualTransformPolicyType.Absolute:
                        visualOffsetPolicy = new Vector2(1.0f, 1.0f);
                        break;
                    default:
                        visualOffsetPolicy = new Vector2(0.0f, 0.0f);
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
                if (visualOffsetPolicy != null && visualOffsetPolicy.X == 1.0f)
                {
                    return VisualTransformPolicyType.Absolute;
                }
                return VisualTransformPolicyType.Relative;
            }
            set
            {
                float x = 0.0f;

                switch (value)
                {
                    case VisualTransformPolicyType.Relative:
                        x = 0.0f;
                        break;
                    case VisualTransformPolicyType.Absolute:
                        x = 1.0f;
                        break;
                    default:
                        x = 0.0f;
                        break;
                }
                visualOffsetPolicy = new Vector2(x, visualOffsetPolicy?.Y ?? 0);

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
                if (visualOffsetPolicy != null && visualOffsetPolicy.Y == 1.0f)
                {
                    return VisualTransformPolicyType.Absolute;
                }
                return VisualTransformPolicyType.Relative;
            }
            set
            {
                float y = 0.0f;

                switch (value)
                {
                    case VisualTransformPolicyType.Relative:
                        y = 0.0f;
                        break;
                    case VisualTransformPolicyType.Absolute:
                        y = 1.0f;
                        break;
                    default:
                        y = 0.0f;
                        break;
                }
                visualOffsetPolicy = new Vector2(visualOffsetPolicy?.X ?? 0, y);
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
                if (visualSizePolicy != null && visualSizePolicy.X == 1.0f
                    && visualSizePolicy.Y == 1.0f)
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
                        visualSizePolicy = new Vector2(0.0f, 0.0f);
                        break;
                    case VisualTransformPolicyType.Absolute:
                        visualSizePolicy = new Vector2(1.0f, 1.0f);
                        break;
                    default:
                        visualSizePolicy = new Vector2(0.0f, 0.0f);
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
                if (visualSizePolicy != null && visualSizePolicy.Width == 1.0f)
                {
                    return VisualTransformPolicyType.Absolute;
                }
                return VisualTransformPolicyType.Relative;
            }
            set
            {
                float width = 0.0f;
                switch (value)
                {
                    case VisualTransformPolicyType.Relative:
                        width = 0.0f;
                        break;
                    case VisualTransformPolicyType.Absolute:
                        width = 1.0f;
                        break;
                    default:
                        width = 0.0f;
                        break;
                }

                visualSizePolicy = new Vector2(width, visualSizePolicy?.Height ?? 0);
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
                if (visualSizePolicy != null && visualSizePolicy.Height == 1.0f)
                {
                    return VisualTransformPolicyType.Absolute;
                }
                return VisualTransformPolicyType.Relative;
            }
            set
            {
                float height = 0.0f;

                switch (value)
                {
                    case VisualTransformPolicyType.Relative:
                        height = 0.0f;
                        break;
                    case VisualTransformPolicyType.Absolute:
                        height = 1.0f;
                        break;
                    default:
                        height = 0.0f;
                        break;
                }
                visualSizePolicy = new Vector2(visualSizePolicy?.Width ?? 0, height);
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
                return visualOrigin ?? (Visual.AlignType.Center);
            }
            set
            {
                visualOrigin = value;
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
                return visualAnchorPoint ?? (Visual.AlignType.Center);
            }
            set
            {
                visualAnchorPoint = value;
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
                return depthIndex ?? (0);
            }
            set
            {
                depthIndex = value;
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
                return visualTransformMap;
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

        /// <summary>
        /// The corner radius of the visual.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CornerRadius
        {
            protected get
            {
                return cornerRadius ?? (0.0f);
            }
            set
            {
                cornerRadius = value;
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

        /// <summary>
        /// Suppress UpdateVisual() to update properties to Parent.
        /// If it is set to true, UpdateVisual() is ignored unless it is called with force.
        /// </summary>
        internal bool SuppressUpdateVisual { get; set; } = false;

        internal void UpdateVisual(bool force = false)
        {
            if (VisualIndex > 0 && (!SuppressUpdateVisual || force))
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
            if (null == _outputVisualMap)
            {
                _outputVisualMap = new PropertyMap();
            }

            if (_shader != null) { _outputVisualMap.Add(Visual.Property.Shader, new PropertyValue(_shader)); }
            if (_premultipliedAlpha != null) { _outputVisualMap.Add(Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
            if (_mixColor != null) { _outputVisualMap.Add(Visual.Property.MixColor, new PropertyValue(_mixColor)); }
            if (_opacity != null) { _outputVisualMap.Add(Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
            if (_visualFittingMode != null) { _outputVisualMap.Add(Visual.Property.VisualFittingMode, new PropertyValue((int)_visualFittingMode)); }
            if (cornerRadius != null) { _outputVisualMap.Add(Visual.Property.CornerRadius, new PropertyValue((int)cornerRadius)); }
        }

        private void ComposingTransformMap()
        {
            visualTransformMap = new PropertyMap();
            if (visualSize != null) { visualTransformMap.Add((int)VisualTransformPropertyType.Size, new PropertyValue(visualSize)); }
            if (visualOffset != null) { visualTransformMap.Add((int)VisualTransformPropertyType.Offset, new PropertyValue(visualOffset)); }
            if (visualOffsetPolicy != null) { visualTransformMap.Add((int)VisualTransformPropertyType.OffsetPolicy, new PropertyValue(visualOffsetPolicy)); }
            if (visualSizePolicy != null) { visualTransformMap.Add((int)VisualTransformPropertyType.SizePolicy, new PropertyValue(visualSizePolicy)); }
            if (visualOrigin != null) { visualTransformMap.Add((int)VisualTransformPropertyType.Origin, new PropertyValue((int)visualOrigin)); }
            if (visualAnchorPoint != null) { visualTransformMap.Add((int)VisualTransformPropertyType.AnchorPoint, new PropertyValue((int)visualAnchorPoint)); }
        }
    }
}
