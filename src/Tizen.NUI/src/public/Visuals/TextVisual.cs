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
    /// A class encapsulating the property map of the text visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TextVisual : VisualMap
    {
        static private float defaultPointSize = 18;
        private string _text = null;
        private string _fontFamily = null;
        private PropertyMap _fontStyle = null;
        private float _pointSize = defaultPointSize;
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
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextVisual() : base()
        {
        }

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
                return _pointSize;
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
            _outputVisualMap = new PropertyMap();

            if (_text != null)
            {
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
                if (_shadow != null) { _outputVisualMap.Add(TextVisualProperty.Shadow, new PropertyValue(_shadow)); }
                if (_underline != null) { _outputVisualMap.Add(TextVisualProperty.Underline, new PropertyValue(_underline)); }
                if (_outline != null) { _outputVisualMap.Add(TextVisualProperty.Outline, new PropertyValue(_outline)); }
                if (_background != null) { _outputVisualMap.Add(TextVisualProperty.Background, new PropertyValue(_background)); }
                base.ComposingPropertyMap();
            }
        }
    }
}
