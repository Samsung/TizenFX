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
        private string text = null;
        private string fontFamily = null;
        private PropertyMap fontStyle = null;
        private float pointSize = defaultPointSize;
        private bool? multiLine = null;
        private string horizontalAlignment = null;
        private string verticalAlignment = null;
        private Color textColor = null;
        private bool? enableMarkup = null;
        private PropertyMap shadow = null;
        private PropertyMap underline = null;
        private PropertyMap outline = null;
        private PropertyMap background = null;

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
                return text;
            }
            set
            {
                text = value;
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
                return fontFamily;
            }
            set
            {
                fontFamily = value;
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
                return fontStyle;
            }
            set
            {
                fontStyle = value;
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
                return pointSize;
            }
            set
            {
                pointSize = value;
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
                return multiLine ?? (false);
            }
            set
            {
                multiLine = value;
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
                switch (horizontalAlignment)
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
                            horizontalAlignment = "BEGIN";
                            break;
                        }
                    case HorizontalAlignment.Center:
                        {
                            horizontalAlignment = "CENTER";
                            break;
                        }
                    case HorizontalAlignment.End:
                        {
                            horizontalAlignment = "END";
                            break;
                        }
                    default:
                        {
                            horizontalAlignment = "BEGIN";
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
                switch (verticalAlignment)
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
                            verticalAlignment = "TOP";
                            break;
                        }
                    case VerticalAlignment.Center:
                        {
                            verticalAlignment = "CENTER";
                            break;
                        }
                    case VerticalAlignment.Bottom:
                        {
                            verticalAlignment = "BOTTOM";
                            break;
                        }
                    default:
                        {
                            verticalAlignment = "TOP";
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
                return textColor;
            }
            set
            {
                textColor = value;
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
                return enableMarkup ?? (false);
            }
            set
            {
                enableMarkup = value;
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
                return shadow;
            }
            set
            {
                shadow = value;
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
                return underline;
            }
            set
            {
                underline = value;
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
                return outline;
            }
            set
            {
                outline = value;
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
                return background;
            }
            set
            {
                background = value;
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

            if (text != null)
            {
                PropertyValue temp = new PropertyValue((int)Visual.Type.Text);
                _outputVisualMap.Add(Visual.Property.Type, temp);
                temp.Dispose();

                temp = new PropertyValue(text);
                _outputVisualMap.Add(TextVisualProperty.Text, temp);
                temp.Dispose();

                temp = new PropertyValue((float)pointSize);
                _outputVisualMap.Add(TextVisualProperty.PointSize, temp);
                temp.Dispose();

                if (fontFamily != null)
                {
                    temp = new PropertyValue(fontFamily);
                    _outputVisualMap.Add(TextVisualProperty.FontFamily, temp);
                    temp.Dispose();
                }
                if (fontStyle != null)
                {
                    temp = new PropertyValue(fontStyle);
                    _outputVisualMap.Add(TextVisualProperty.FontStyle, temp);
                    temp.Dispose();
                }
                if (multiLine != null)
                {
                    temp = new PropertyValue((bool)multiLine);
                    _outputVisualMap.Add(TextVisualProperty.MultiLine, temp);
                    temp.Dispose();
                }
                if (horizontalAlignment != null)
                {
                    temp = new PropertyValue(horizontalAlignment);
                    _outputVisualMap.Add(TextVisualProperty.HorizontalAlignment, temp);
                    temp.Dispose();
                }
                if (verticalAlignment != null)
                {
                    temp = new PropertyValue(verticalAlignment);
                    _outputVisualMap.Add(TextVisualProperty.VerticalAlignment, temp);
                    temp.Dispose();
                }
                if (textColor != null)
                {
                    temp = new PropertyValue(textColor);
                    _outputVisualMap.Add(TextVisualProperty.TextColor, temp);
                    temp.Dispose();
                }
                if (enableMarkup != null)
                {
                    temp = new PropertyValue((bool)enableMarkup);
                    _outputVisualMap.Add(TextVisualProperty.EnableMarkup, temp);
                    temp.Dispose();
                }
                if (shadow != null)
                {
                    temp = new PropertyValue(shadow);
                    _outputVisualMap.Add(TextVisualProperty.Shadow, temp);
                    temp.Dispose();
                }
                if (underline != null)
                {
                    temp = new PropertyValue(underline);
                    _outputVisualMap.Add(TextVisualProperty.Underline, temp);
                    temp.Dispose();
                }
                if (outline != null)
                {
                    temp = new PropertyValue(outline);
                    _outputVisualMap.Add(TextVisualProperty.Outline, temp);
                    temp.Dispose();
                }
                if (background != null)
                {
                    temp = new PropertyValue(background);
                    _outputVisualMap.Add(TextVisualProperty.Background, temp);
                    temp.Dispose();
                }
                base.ComposingPropertyMap();
            }
        }
    }
}
