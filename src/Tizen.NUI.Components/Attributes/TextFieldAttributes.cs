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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TextFieldAttributes is a class which saves TextField's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextFieldAttributes : ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a TextFieldAttributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextFieldAttributes() : base() { }

        /// <summary>
        /// Construct with specified attribute.
        /// </summary>
        /// <param name="attributes">The specified TextFieldAttributes.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextFieldAttributes(TextFieldAttributes attributes) : base(attributes)
        {
            if(null == attributes)
            {
                return;
            }
            if (null != attributes.Text)
            {
                Text = attributes.Text.Clone() as StringSelector;
            }
            if (null != attributes.PlaceholderText)
            {
                PlaceholderText = attributes.PlaceholderText.Clone() as StringSelector;
            }
            if (null != attributes.TranslatablePlaceholderText)
            {
                TranslatablePlaceholderText = attributes.TranslatablePlaceholderText.Clone() as StringSelector;
            }
            if (null != attributes.HorizontalAlignment)
            {
                HorizontalAlignment = attributes.HorizontalAlignment;
            }
            if (null != attributes.VerticalAlignment)
            {
                VerticalAlignment = attributes.VerticalAlignment;
            }
            if (null != attributes.EnableMarkup)
            {
                EnableMarkup = attributes.EnableMarkup;
            }
            if (null != attributes.TextColor)
            {
                TextColor = attributes.TextColor.Clone() as ColorSelector;
            }
            if (null != attributes.PlaceholderTextColor)
            {
                PlaceholderTextColor = attributes.PlaceholderTextColor.Clone() as ColorSelector;
            }
            if (null != attributes.PrimaryCursorColor)
            {
                PrimaryCursorColor = attributes.PrimaryCursorColor.Clone() as ColorSelector;
            }
            if (null != attributes.SecondaryCursorColor)
            {
                SecondaryCursorColor = attributes.SecondaryCursorColor.Clone() as ColorSelector;
            }
            if (null != attributes.FontFamily)
            {
                FontFamily = attributes.FontFamily;
            }
            if (null != attributes.PointSize)
            {
                PointSize = attributes.PointSize.Clone() as FloatSelector;
            }
            if (null != attributes.EnableCursorBlink)
            {
                EnableCursorBlink = attributes.EnableCursorBlink;
            }
            if (null != attributes.EnableSelection)
            {
                EnableSelection = attributes.EnableSelection;
            }
            if (null != attributes.CursorWidth)
            {
                CursorWidth = attributes.CursorWidth;
            }
            if (null != attributes.EnableEllipsis)
            {
                EnableEllipsis = attributes.EnableEllipsis;
            }
        }

        /// <summary>
        /// Gets or sets text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets place holder text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector PlaceholderText
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets translatable place holder text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector TranslatablePlaceholderText
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets horizontal alignment of text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment? HorizontalAlignment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets vertical alignment of text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignment? VerticalAlignment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets enable mark up.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableMarkup
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets text color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector TextColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets place holder text color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector PlaceholderTextColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets primary cursor color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector PrimaryCursorColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets secondary cursor color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector SecondaryCursorColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets font family of text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets point size of text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector PointSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets enable cursor blink.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableCursorBlink
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets enable selection.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableSelection
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets cursor width.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CursorWidth
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if enable ellipsis.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableEllipsis
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
            return new TextFieldAttributes(this);
        }

        /// <summary>
        /// Apply ViewAttributes to TextField.
        /// </summary>
        public override void ApplyToView(View view, ControlStates state)
        {
            base.ApplyToView(view, state);

            TextField textField = view as TextField;
            TextFieldAttributes textFieldAttrs = this;
            if (textField != null && textFieldAttrs != null)
            {
                if (textFieldAttrs.Text?.GetValue(state) != null)
                {
                    textField.Text = textFieldAttrs.Text.GetValue(state);
                }
                if (textFieldAttrs.PlaceholderText?.GetValue(state) != null)
                {
                    textField.PlaceholderText = textFieldAttrs.PlaceholderText.GetValue(state);
                }
                if (textFieldAttrs.TranslatablePlaceholderText?.GetValue(state) != null)
                {
                    textField.TranslatablePlaceholderText = textFieldAttrs.TranslatablePlaceholderText.GetValue(state);
                }
                if (textFieldAttrs.TextColor?.GetValue(state) != null)
                {
                    textField.TextColor = textFieldAttrs.TextColor.GetValue(state);
                }
                if (textFieldAttrs.PlaceholderTextColor?.GetValue(state) != null)
                {
                    textField.PlaceholderTextColor = textFieldAttrs.PlaceholderTextColor.GetValue(state);
                }
                if (textFieldAttrs.PrimaryCursorColor?.GetValue(state) != null)
                {
                    textField.PrimaryCursorColor = textFieldAttrs.PrimaryCursorColor.GetValue(state);
                }
                if (textFieldAttrs.SecondaryCursorColor?.GetValue(state) != null)
                {
                    textField.SecondaryCursorColor = textFieldAttrs.SecondaryCursorColor.GetValue(state);
                }
                if (textFieldAttrs.PointSize?.GetValue(state) != null)
                {
                    textField.PointSize = textFieldAttrs.PointSize.GetValue(state).Value;
                }
                if (textFieldAttrs.HorizontalAlignment != null)
                {
                    textField.HorizontalAlignment = textFieldAttrs.HorizontalAlignment.Value;
                }
                if (textFieldAttrs.VerticalAlignment != null)
                {
                    textField.VerticalAlignment = textFieldAttrs.VerticalAlignment.Value;
                }
                if (textFieldAttrs.EnableMarkup != null)
                {
                    textField.EnableMarkup = textFieldAttrs.EnableMarkup.Value;
                }
                if (textFieldAttrs.FontFamily != null)
                {
                    textField.FontFamily = textFieldAttrs.FontFamily;
                }
                if (textFieldAttrs.EnableCursorBlink != null)
                {
                    textField.EnableCursorBlink = textFieldAttrs.EnableCursorBlink.Value;
                }
                if (textFieldAttrs.EnableSelection != null)
                {
                    textField.EnableSelection = textFieldAttrs.EnableSelection.Value;
                }
                if (textFieldAttrs.CursorWidth != null)
                {
                    textField.CursorWidth = textFieldAttrs.CursorWidth.Value;
                }
                if (textFieldAttrs.EnableEllipsis != null)
                {
                    textField.Ellipsis = textFieldAttrs.EnableEllipsis.Value;
                }
            }
        }
    }
}
