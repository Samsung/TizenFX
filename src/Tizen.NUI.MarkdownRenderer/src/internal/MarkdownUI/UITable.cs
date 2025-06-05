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
    internal class UITableRow : View
    {
        private readonly View container;
        private readonly View underline;

        private readonly TableStyle style;
        private readonly bool isHeaderRow;

        public UITableRow(bool isHeader, TableStyle tableStyle) : base()
        {
            isHeaderRow = isHeader;
            style = tableStyle;
            SetupLayout();
            if (isHeaderRow)
            {
                container = CreateContainer();
                base.Add(container);
                underline = CreateUnderline();
                base.Add(underline);
            }
        }

        /// <summary>
        /// Adds a child view to the table row content container.
        /// </summary>
        public override void Add(View child)
        {
            if (isHeaderRow)
                container.Add(child);
            else
                base.Add(child);
        }

        /// <summary>
        /// Removes a child view from the table row content container.
        /// </summary>
        public override void Remove(View child)
        {
            if (isHeaderRow)
                container.Remove(child);
            else
                base.Remove(child);
        }

        private void SetupLayout()
        {
            Layout = new LinearLayout()
            {
                LinearOrientation = isHeaderRow ? LinearLayout.Orientation.Vertical : LinearLayout.Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Begin,
            };
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.WrapContent;
            BackgroundColor = Color.Transparent;
        }

        private View CreateUnderline()
        {
            return new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = style.BorderThickness,
                BackgroundColor = new Color(style.BorderColor),
            };
        }

        private View CreateContainer()
        {
            return new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Transparent,
            };
        }
    }

    internal class UITableCell : View
    {
        private readonly TableStyle style;

        public UITableCell(TableStyle tableStyle) : base()
        {
            style = tableStyle;
            SetupLayout();
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
            Padding = new Extents((ushort)style.ItemPadding);
        }
    }

    internal class UITable : View
    {
        private readonly TableStyle style;
        private readonly CommonStyle common;

        public UITable(TableStyle tableStyle, CommonStyle commonStyle) : base()
        {
            style = tableStyle;
            common = commonStyle;
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
            BackgroundColor = new Color(style.BackgroundColor);
            Padding = new Extents((ushort)style.Padding);
            Margin = new Extents(0, 0, (ushort)common.Margin, (ushort)common.Margin);
        }
    }
}
