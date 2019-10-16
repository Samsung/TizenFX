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
    /// The Text Attributes class.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextAttributes : ViewAttributes
    {
        /// <summary>
        /// Construct TextAttributes.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes() : base() { }
        /// <summary>
        /// Construct with specified attribute.
        /// </summary>
        /// <param name="attributes">The specified TextAttributes.</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes(TextAttributes attributes) : base(attributes)
        {
            if(attributes == null)
            {
                return;
            }
            if (attributes.Text != null)
            {
                Text = attributes.Text.Clone() as StringSelector;
            }

            if (attributes.TranslatableText != null)
            {
                TranslatableText = attributes.TranslatableText.Clone() as StringSelector;
            }

            if (attributes.MultiLine != null)
            {
                MultiLine = attributes.MultiLine;
            }

            if (attributes.HorizontalAlignment != null)
            {
                HorizontalAlignment = attributes.HorizontalAlignment;
            }

            if (attributes.VerticalAlignment != null)
            {
                VerticalAlignment = attributes.VerticalAlignment;
            }

            if (attributes.EnableMarkup != null)
            {
                EnableMarkup = attributes.EnableMarkup;
            }

            if (attributes.EnableAutoScroll != null)
            {
                EnableAutoScroll = attributes.EnableAutoScroll;
            }

            if (attributes.AutoScrollSpeed != null)
            {
                AutoScrollSpeed = attributes.AutoScrollSpeed;
            }

            if (attributes.AutoScrollLoopCount != null)
            {
                AutoScrollLoopCount = attributes.AutoScrollLoopCount;
            }

            if (attributes.AutoScrollGap != null)
            {
                AutoScrollGap = attributes.AutoScrollGap;
            }

            if (attributes.AutoScrollLoopDelay != null)
            {
                AutoScrollLoopDelay = attributes.AutoScrollLoopDelay;
            }

            if (attributes.AutoScrollStopMode != null)
            {
                AutoScrollStopMode = attributes.AutoScrollStopMode;
            }

            if (attributes.LineSpacing != null)
            {
                LineSpacing = attributes.LineSpacing;
            }

            if (attributes.TextColor != null)
            {
                TextColor = attributes.TextColor.Clone() as ColorSelector;
            }

            if (attributes.FontFamily != null)
            {
                FontFamily = attributes.FontFamily;
            }

            if (attributes.PointSize != null)
            {
                PointSize = attributes.PointSize.Clone() as FloatSelector;
            }

            if (attributes.OutstrokeColor != null)
            {
                OutstrokeColor = attributes.OutstrokeColor.Clone() as ColorSelector;
            }
            if (attributes.OutstrokeThickness != null)
            {
                OutstrokeThickness = attributes.OutstrokeThickness.Clone() as IntSelector;
            }
        }
        /// <summary>
        /// TextLabel Text
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector Text
        {
            get;
            set;
        }
        /// <summary>
        /// The TranslatableText property
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector TranslatableText
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel MultiLine
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? MultiLine
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel HorizontalAlignment
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment? HorizontalAlignment
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel VerticalAlignment
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignment? VerticalAlignment
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel EnableMarkup
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableMarkup
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel EnableAutoScroll
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableAutoScroll
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel AutoScrollSpeed
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? AutoScrollSpeed
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel AutoScrollLoopCount
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? AutoScrollLoopCount
{
            get;
            set;
        }
        /// <summary>
        /// TextLabel AutoScrollGap
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? AutoScrollGap
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel AutoScrollLoopDelay
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? AutoScrollLoopDelay
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel AutoScrollStopMode
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AutoScrollStopMode? AutoScrollStopMode
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel LineSpacing
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? LineSpacing
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel TextColor
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector TextColor
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel FontFamily
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel PointSize
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector PointSize
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel OutstrokeColor
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector OutstrokeColor
        {
            get;
            set;
        }
        /// <summary>
        /// TextLabel OutstrokeThickness
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IntSelector OutstrokeThickness
        {
            get;
            set;
        }
        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new TextAttributes(this);
        }

        /// <summary>
        /// Apply ViewAttributes to TextControl.
        /// </summary>
        public override void ApplyToView(View view, ControlStates state = ControlStates.Normal)
        {
            base.ApplyToView(view, state);
            TextLabel text = view as TextLabel;
            TextAttributes textAttrs = this;

            if (text != null && textAttrs != null)
            {
                if (textAttrs.Text?.GetValue(state) != null)
                {
                    text.Text = textAttrs.Text.GetValue(state);
                }
                if (textAttrs.TranslatableText?.GetValue(state) != null)
                {
                    text.TranslatableText = textAttrs.TranslatableText.GetValue(state);
                }
                if (textAttrs.MultiLine != null)
                {
                    text.MultiLine = textAttrs.MultiLine.Value;
                }
                if (textAttrs.HorizontalAlignment != null)
                {
                    text.HorizontalAlignment = textAttrs.HorizontalAlignment.Value;
                }
                if (textAttrs.VerticalAlignment != null)
                {
                    text.VerticalAlignment = textAttrs.VerticalAlignment.Value;
                }
                if (textAttrs.EnableMarkup != null)
                {
                    text.EnableMarkup = textAttrs.EnableMarkup.Value;
                }
                if (textAttrs.AutoScrollLoopCount != null)
                {
                    text.AutoScrollLoopCount = textAttrs.AutoScrollLoopCount.Value;
                }
                if (textAttrs.AutoScrollSpeed != null)
                {
                    text.AutoScrollSpeed = textAttrs.AutoScrollSpeed.Value;
                }
                if (textAttrs.AutoScrollGap != null)
                {
                    text.AutoScrollGap = textAttrs.AutoScrollGap.Value;
                }
                if (textAttrs.AutoScrollLoopDelay != null)
                {
                    text.AutoScrollLoopDelay = textAttrs.AutoScrollLoopDelay.Value;
                }
                if (textAttrs.AutoScrollStopMode != null)
                {
                    text.AutoScrollStopMode = textAttrs.AutoScrollStopMode.Value;
                }
                if (textAttrs.LineSpacing != null)
                {
                    text.LineSpacing = textAttrs.LineSpacing.Value;
                }
                if (textAttrs.TextColor?.GetValue(state) != null)
                {
                    text.TextColor = textAttrs.TextColor.GetValue(state);
                }
                if (textAttrs.FontFamily != null)
                {
                    text.FontFamily = textAttrs.FontFamily;
                }
                if (textAttrs.PointSize?.GetValue(state) != null)
                {
                    text.PointSize = textAttrs.PointSize.GetValue(state).Value;
                }

                int thickness = 0;

                if (textAttrs.OutstrokeThickness?.GetValue(state) != null)
                {
                    thickness = textAttrs.OutstrokeThickness.GetValue(state).Value;
                }

                if (textAttrs.OutstrokeColor?.GetValue(state) != null)
                {
                    Color outstrokeColor = textAttrs.OutstrokeColor.GetValue(state);
                    PropertyMap outlineMap = new PropertyMap();
                    outlineMap.Add("color", new PropertyValue(new Color(outstrokeColor.R, outstrokeColor.G, outstrokeColor.B, outstrokeColor.A)));
                    outlineMap.Add("width", new PropertyValue(thickness));
                    //text.Outline = outlineMap;
                }
                else
                {
                    //text.Outline = new PropertyMap();
                }
            }
        }
    }
}
