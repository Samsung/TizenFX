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
    /// Represents a single row within a markdown table, supporting both header and body rows.
    /// Header rows include a container for cell content and an underline for separation.
    /// </summary>
    internal class UITableRow : View
    {
        private readonly View container;
        private readonly View underline;

        private readonly TableStyle table;
        private readonly bool isHeaderRow;

        /// <summary>
        /// Initializes a new instance of the UITableRow class.
        /// as either a header or a body row with the given style.
        /// </summary>
        /// <param name="isHeader">Whether this row is a header row.</param>
        /// <param name="tableStyle">The style to apply to the row.</param>
        public UITableRow(bool isHeader, TableStyle tableStyle) : base()
        {
            isHeaderRow = isHeader;
            table = tableStyle;
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
        /// Adds a child view to the table row.  
        /// For header rows, children are added to the container; for body rows, directly to the row.
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

        /// <summary>
        /// Configures the layout, sizing, and background for the table row.
        /// </summary>
        private void SetupLayout()
        {
            if (isHeaderRow)
                Layout = new MarkdownLinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical };
            else
                Layout = new MarkdownLinearLayout() {};

            WidthSpecification = LayoutParamPolicies.MatchParent;
        }

        /// <summary>
        /// Creates the underline view for header rows.
        /// </summary>
        private View CreateUnderline()
        {
            return new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = table.BorderThickness,
                BackgroundColor = new Color(table.BorderColor),
            };
        }

        /// <summary>
        /// Creates the container for header row cell content.
        /// </summary>
        private View CreateContainer()
        {
            return new View()
            {
                Layout = new MarkdownLinearLayout() {},
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
        }
    }

    /// <summary>
    /// Represents a single cell within a markdown table.
    /// Applies style and padding according to the table's style settings.
    /// </summary>
    internal class UITableCell : View
    {
        private readonly TableStyle table;

        public UITableCell(TableStyle tableStyle) : base()
        {
            table = tableStyle;
            SetupLayout();
        }

        private void SetupLayout()
        {
            Layout = new MarkdownLinearLayout() {};
            WidthSpecification = LayoutParamPolicies.MatchParent;
            Padding = new Extents((ushort)table.ItemPadding);
        }
    }

    /// <summary>
    /// Represents a markdown table, containing header and body rows.
    /// Applies overall table style and outer margin.
    /// </summary>
    internal class UITable : View
    {
        private readonly TableStyle table;

        public UITable(TableStyle tableStyle) : base()
        {
            table = tableStyle;
            SetupLayout();
        }

        private void SetupLayout()
        {
            Layout = new MarkdownLinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            };
            WidthSpecification = LayoutParamPolicies.MatchParent;
            BackgroundColor = new Color(table.BackgroundColor);
            Padding = new Extents((ushort)table.Padding);
            CornerRadius = table.CornerRadius;
        }
    }
}
