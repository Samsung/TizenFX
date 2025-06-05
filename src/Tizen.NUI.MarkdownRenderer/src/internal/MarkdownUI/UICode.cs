/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.MarkdownRenderer
{
    internal class UICode : View
    {
        private readonly CodeStyle style;
        private readonly CommonStyle common;

        public UICode(string language, string text, CodeStyle codeStyle, CommonStyle commonStyle) : base()
        {
            style = codeStyle;
            common = commonStyle;
            SetupLayout();

            Add(CreateTitle(language));
            Add(CreateCode(text));
        }

        private void SetupLayout()
        {
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Begin,
            };
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.WrapContent;
            BackgroundColor = Color.Transparent;
            Margin = new Extents(0, 0, (ushort)common.Margin, (ushort)common.Margin);
        }

        private UICodeText CreateTitle(string text)
        {
            return new UICodeText()
            {
                Text = text,
                FontFamily = style.TitleFontFamily,
                PixelSize = style.TitleFontSize,
                TextColor = new Color(style.TitleFontColor),
                BackgroundColor = new Color(style.TitleBackgroundColor),
                Padding = new Extents((ushort)style.Padding),
            };
        }

        private UICodeText CreateCode(string text)
        {
            return new UICodeText()
            {
                Text = text,
                FontFamily = style.FontFamily,
                PixelSize = style.FontSize,
                TextColor = new Color(style.FontColor),
                BackgroundColor = new Color(style.BackgroundColor),
                Padding = new Extents((ushort)style.Padding),
            };
        }

        private class UICodeText : TextLabel
        {
            public UICodeText() : base()
            {
                MultiLine = true;
                EnableMarkup = false;
                WidthSpecification = LayoutParamPolicies.MatchParent;
                HeightSpecification = LayoutParamPolicies.WrapContent;
            }
        }
    }
}
