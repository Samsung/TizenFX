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
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TextVisualAttributes is a class which saves Button's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextVisualAttributes : VisualAttributes
    {
        /// <summary>
        /// Creates a new instance of a TextVisualAttributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextVisualAttributes() : base() { }

        /// <summary>
        /// Creates a new instance of a TextVisualAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create ButtonAttributes by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextVisualAttributes(TextVisualAttributes attributes) : base(attributes)
        {
            if (attributes == null)
            {
                return;
            }

            Text = attributes.Text;
            FontFamily = attributes.FontFamily;
            FontStyle = attributes.FontStyle;
            PointSize = attributes.PointSize;
            MultiLine = attributes.MultiLine;
            HorizontalAlignment = attributes.HorizontalAlignment;
            VerticalAlignment = attributes.VerticalAlignment;
            TextColor = attributes.TextColor;
            EnableMarkup = attributes.EnableMarkup;
            Shadow = attributes.Shadow;
            Outline = attributes.Outline;
            Underline = attributes.Underline;
            Background = attributes.Background;
        }

        /// <summary>
        /// Gets or sets the text to display in the UTF-8 format.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public StringSelector Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the requested font family to use.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string FontFamily
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the requested font style to use.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap FontStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the size of font in points.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public FloatSelector PointSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the single-line or multi-line layout option.<br />
        /// If not specified, the default is false.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool? MultiLine
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the line horizontal alignment.<br />
        /// If not specified, the default is begin.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public HorizontalAlignment? HorizontalAlignment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the line vertical alignment.<br />
        /// If not specified, the default is top.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VerticalAlignment? VerticalAlignment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the color of the text.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ColorSelector TextColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the mark-up processing is enabled.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool? EnableMarkup
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the shadow parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public PropertyMap Shadow
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the underline parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public PropertyMap Underline
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the outline parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public PropertyMap Outline
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the background parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public PropertyMap Background
        {
            get;
            set;
        }
        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new TextVisualAttributes(this);
        }
    }
}
