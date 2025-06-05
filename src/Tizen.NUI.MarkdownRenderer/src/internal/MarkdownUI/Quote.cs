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
    /// Represents a custom layout for the Quote component, extending the LinearLayout.
    /// Handles the measurement logic for the QuoteBar.
    /// </summary>
    internal class QuoteLayout : LinearLayout
    {
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            foreach (var child in Owner.Children)
            {
                if (child is QuoteBar)
                    child.Layout.MeasuredHeight = new MeasuredSize(new LayoutLength(0), MeasuredSize.StateType.MeasuredSizeOK);
            }

            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            foreach (var child in Owner.Children)
            {
                if (child is QuoteBar)
                {
                    int margin = child.Margin.Top + child.Margin.Bottom;
                    float totalHeight = MeasuredHeight.Size.AsDecimal();
                    child.Layout.MeasuredHeight = new MeasuredSize(new LayoutLength(totalHeight - (float)margin), MeasuredSize.StateType.MeasuredSizeOK);
                }
            }
        }
    }

    /// <summary>
    /// Represents the visual element for the Quote bar, which is a vertical bar displayed beside the quote text.
    /// </summary>
    internal class QuoteBar : View
    {
        public QuoteBar(QuoteStyle quoteStyle, int margin) : base()
        {
            WidthSpecification = quoteStyle.BarWidth;
            HeightSpecification = 0;
            BackgroundColor = new Color(quoteStyle.BarColor);
            Margin = new Extents((ushort)margin, (ushort)margin, (ushort)quoteStyle.BarMargin, (ushort)quoteStyle.BarMargin);
        }
    }

    /// <summary>
    /// Represents a Markdown quote block, which includes a vertical bar and a container for the quote text.
    /// </summary>
    internal class Quote : View
    {
        private View bar;
        private View container;
        private bool header;

        private QuoteStyle style;
        private CommonStyle common;
        private ParagraphStyle paragraph;

        public Quote(bool isHeader, QuoteStyle quoteStyle, CommonStyle commonStyle, ParagraphStyle paragraphStyle) : base()
        {
            header = isHeader;
            style = quoteStyle;
            common = commonStyle;
            paragraph = paragraphStyle;

            Initialize();
        }

        public override void Add(View view)
        {
            container.Add(view);
        }

        private void Initialize()
        {
            Layout = new QuoteLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
            };
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.WrapContent;
            BackgroundColor = Color.Transparent;

            int barMargin = (ushort)Math.Round(((paragraph.FontSize * 1.4f) - style.BarWidth) / 2);

            int indent = header ? common.Indent : common.Indent - (style.BarWidth + barMargin + barMargin);
            Margin = new Extents((ushort)indent, 0, (ushort)common.Margin, (ushort)common.Margin);

            bar = new QuoteBar(style, barMargin);
            base.Add(bar);

            container = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                },
                BackgroundColor = Color.Transparent,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Padding = new Extents((ushort)style.Padding),
            };
            base.Add(container);
        }
    }
}