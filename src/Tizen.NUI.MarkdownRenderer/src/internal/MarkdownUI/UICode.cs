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
    /// <summary>
    /// Renders a code block as a NUI View, including an optional language label and styled code text.
    /// </summary>
    internal class UICode : View
    {
        private readonly CodeStyle code;

        private UICodeText uiCodeTitle;
        private UICodeText uiCodeText;

        public string ContentHash { get; set; } = string.Empty;

        public string Language
        {
            get => uiCodeTitle.Text;
            set => uiCodeTitle.Text = value;
        }

        public string Code
        {
            get => uiCodeText.Text;
            set => uiCodeText.Text = value;
        }

        public UICode(string language, string text, int indent, CodeStyle codeStyle, string hash, bool asyncRendering) : base()
        {
            ContentHash = hash;
            code = codeStyle;
            SetupLayout(indent);

            Add(CreateTitle(language, asyncRendering));
            Add(CreateCode(text, asyncRendering));
        }

        private void SetupLayout(int indent)
        {
            Layout = new MarkdownLinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            };
            WidthSpecification = LayoutParamPolicies.MatchParent;
            Margin = new Extents((ushort)indent, 0, 0, 0);
            LayoutDirection = ViewLayoutDirectionType.LTR;
        }

        private View CreateTitle(string text, bool asyncRendering)
        {
            var view = new View()
            {
                Layout = new MarkdownLinearLayout() {},
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = new Color(code.TitleBackgroundColor),
                Padding = new Extents((ushort)code.Padding),
                CornerRadius = new Vector4(code.CornerRadius, code.CornerRadius, 0, 0),
            };
            uiCodeTitle = new UICodeText(asyncRendering)
            {
                Text = text,
                FontFamily = code.TitleFontFamily,
                PixelSize = code.TitleFontSize,
                TextColor = new Color(code.TitleFontColor),
            };
            view.Add(uiCodeTitle);
            return view;
        }

        private View CreateCode(string text, bool asyncRendering)
        {
            var view = new View()
            {
                Layout = new MarkdownLinearLayout() {},
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = new Color(code.BackgroundColor),
                Padding = new Extents((ushort)code.Padding),
                CornerRadius = new Vector4(0, 0, code.CornerRadius, code.CornerRadius),
            };
            uiCodeText = new UICodeText(asyncRendering)
            {
                Text = text,
                FontFamily = code.FontFamily,
                PixelSize = code.FontSize,
                TextColor = new Color(code.FontColor),
            };
            view.Add(uiCodeText);
            return view;
        }

        private class UICodeText : UIText
        {
            public UICodeText(bool asyncRendering) : base()
            {
                MultiLine = true;
                Ellipsis = false;
                RenderMode = asyncRendering ? TextRenderMode.AsyncManual : TextRenderMode.Sync;
            }
        }
    }
}
