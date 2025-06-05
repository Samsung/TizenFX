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
    internal class UIListItemText : View
    {
        private readonly ParagraphStyle style;

        public UIListItemText(string text, ParagraphStyle paragraphStyle) : base()
        {
            style = paragraphStyle;
            SetupLayout();

            Add(CreateBullet());
            Add(new UIParagraph(text, style));
        }

        private void SetupLayout()
        {
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Begin,
            };
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.WrapContent;
            BackgroundColor = Color.Transparent;
        }

        private View CreateBullet()
        {
            int bulletSize = (int)Math.Round(style.FontSize / 4);
            ushort bulletMargin = (ushort)Math.Round((style.LineHeight - bulletSize) / 2);
            var bullet = new View()
            {
                WidthSpecification = bulletSize,
                HeightSpecification = bulletSize,
                BackgroundColor = new Color(style.FontColor),
                Margin = new Extents(bulletMargin),
            };
            return bullet;
        }
    }

    internal class UIListItem : View
    {
        private readonly CommonStyle style;

        public UIListItem(CommonStyle commonStyle) : base()
        {
            style = commonStyle;
            SetupLayout();
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
            Margin = new Extents((ushort)style.Indent, 0, 0, 0);
        }
    }

    internal class UIList : View
    {
        private readonly CommonStyle style;

        public UIList(CommonStyle commonStyle) : base()
        {
            style = commonStyle;
            SetupLayout();
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
            Margin = new Extents(0, 0, (ushort)style.Margin, (ushort)style.Margin);
        }
    }
}
