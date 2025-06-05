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
    /// Represents the visual element for the Quote bar, which is a vertical bar displayed beside the quote text.
    /// </summary>
    internal class QuoteBar : View
    {
        public QuoteBar(QuoteStyle quoteStyle, int barMargin) : base()
        {
            WidthSpecification = quoteStyle.BarWidth;
            HeightSpecification = 0; // Height will be set by parent layout.
            BackgroundColor = new Color(quoteStyle.BarColor);
            Margin = new Extents((ushort)barMargin, (ushort)barMargin, (ushort)quoteStyle.BarMargin, (ushort)quoteStyle.BarMargin);
        }
    }

    /// <summary>
    /// Represents a Markdown quote block, which includes a vertical bar and a container for the quote text.
    /// </summary>
    internal class Quote : View
    {
        private readonly View bar;
        private readonly View container;

        private readonly QuoteStyle style;
        private readonly CommonStyle common;
        private readonly ParagraphStyle paragraph;
        private readonly bool isHeaderQuote;

        public Quote(bool isHeader, QuoteStyle quoteStyle, CommonStyle commonStyle, ParagraphStyle paragraphStyle) : base()
        {
            isHeaderQuote = isHeader;
            style = quoteStyle;
            common = commonStyle;
            paragraph = paragraphStyle;

            SetupLayout();
            bar = CreateBar();
            container = CreateContainer();

            base.Add(bar);
            base.Add(container);
        }

        /// <summary>
        /// Adds a child view to the quote content container.
        /// </summary>
        public override void Add(View child)
        {
            container.Add(child);
        }

        /// <summary>
        /// Removes a child view from the quote content container.
        /// </summary>
        public override void Remove(View child)
        {
            container.Remove(child);
        }

        private void SetupLayout()
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

            int barMargin = (int)Math.Round(((paragraph.FontSize * 1.4f) - style.BarWidth) / 2);
            int indent = isHeaderQuote ? common.Indent : (int)(common.Indent - (style.BarWidth + barMargin * 2));
            Margin = new Extents((ushort)indent, 0, (ushort)common.Margin, (ushort)common.Margin);
        }

        private View CreateBar()
        {
            int barMargin = (int)Math.Round(((paragraph.FontSize * 1.4f) - style.BarWidth) / 2);
            return new QuoteBar(style, barMargin);
        }

        private View CreateContainer()
        {
            return new View()
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
        }

        /// <summary>
        /// Custom layout for the Quote component that adjusts the height of the QuoteBar.
        /// </summary>
        private class QuoteLayout : LinearLayout
        {
            protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                if (Owner is Quote quote && quote.bar is not null)
                {
                    // Clear bar height before measuring
                    quote.bar.Layout.MeasuredHeight = new MeasuredSize(new LayoutLength(0), MeasuredSize.StateType.MeasuredSizeOK);

                    base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

                    float totalHeight = MeasuredHeight.Size.AsDecimal();
                    int verticalMargin = quote.bar.Margin.Top + quote.bar.Margin.Bottom;
                    quote.bar.Layout.MeasuredHeight = new MeasuredSize(new LayoutLength(totalHeight - verticalMargin), MeasuredSize.StateType.MeasuredSizeOK);
                }
            }
        }
    }
}
