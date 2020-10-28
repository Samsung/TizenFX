/* Copyright (c) 2019 Samsung Electronics Co., Ltd.
.*
.* Licensed under the Apache License, Version 2.0 (the "License");
.* you may not use this file except in compliance with the License.
.* You may obtain a copy of the License at
.*
.* http://www.apache.org/licenses/LICENSE-2.0
.*
.* Unless required by applicable law or agreed to in writing, software
.* distributed under the License is distributed on an "AS IS" BASIS,
.* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
.* See the License for the specific language governing permissions and
.* limitations under the License.
.*
.*/

using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// GridLayout is a 2D grid pattern layout that consists of a set of rows and columns.
    /// </summary>
    public partial class GridLayout : LayoutGroup
    {
        /// <summary>
        /// ColumnProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColumnProperty = BindableProperty.CreateAttached("Column", typeof(int), typeof(GridLayout), CellUndefined, validateValue: (bindable, value) => (int)value >= 0, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// ColumnSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColumnSpanProperty = BindableProperty.CreateAttached("ColumnSpan", typeof(int), typeof(GridLayout), 1, validateValue: (bindable, value) => (int)value >= 1, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// RowProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RowProperty = BindableProperty.CreateAttached("Row", typeof(int), typeof(GridLayout), CellUndefined, validateValue: (bindable, value) => (int)value >= 0, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// RowSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RowSpanProperty = BindableProperty.CreateAttached("RowSpan", typeof(int), typeof(GridLayout), 1, validateValue: (bindable, value) => (int)value >= 1, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// HorizontalStretchProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalStretchProperty = BindableProperty.CreateAttached("HorizontalStretch", typeof(StretchFlags), typeof(GridLayout), default(StretchFlags), validateValue: ValidateEnum((int)StretchFlags.None, (int)StretchFlags.ExpandAndFill), propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// VerticalStretchProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalStretchProperty = BindableProperty.CreateAttached("VerticalStretch", typeof(StretchFlags), typeof(GridLayout), default(StretchFlags), validateValue: ValidateEnum((int)StretchFlags.None, (int)StretchFlags.ExpandAndFill), propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// HorizontalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.CreateAttached("HorizontalAlignment", typeof(Alignment), typeof(GridLayout), Alignment.Start, validateValue: ValidateEnum((int)Alignment.Start, (int)Alignment.End), propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// VerticalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.CreateAttached("VerticalAlignment", typeof(Alignment), typeof(GridLayout), Alignment.Start, validateValue: ValidateEnum((int)Alignment.Start, (int)Alignment.End), propertyChanged: OnChildPropertyChanged);

        private const int CellUndefined = int.MinValue;
        private Orientation gridOrientation = Orientation.Horizontal;
        private int columns = 1;
        private int rows = 1;
        private float columnSpacing = 0;
        private float rowSpacing = 0;

        /// <summary>
        /// Enumeration for the direction in which the content is laid out
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public enum Orientation
        {
            /// <summary>
            /// Horizontal (row)
            /// </summary>
            Horizontal,
            /// <summary>
            /// Vertical (column)
            /// </summary>
            Vertical
        }

        /// <summary>
        /// Get the column index.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static int GetColumn(View view) => GetAttachedValue<int>(view, ColumnProperty);

        /// <summary>
        /// Get the column span.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static int GetColumnSpan(View view) => GetAttachedValue<int>(view, ColumnSpanProperty);

        /// <summary>
        /// Get the row index.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static int GetRow(View view) => GetAttachedValue<int>(view, RowProperty);

        /// <summary>
        /// Get the row span.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static int GetRowSpan(View view) => GetAttachedValue<int>(view, RowSpanProperty);

        /// <summary>
        /// Get the value how child is resized within its horizontal space.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static StretchFlags GetHorizontalStretch(View view) => GetAttachedValue<StretchFlags>(view, HorizontalStretchProperty);

        /// <summary>
        /// Get the value how child is resized within its vertical space.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static StretchFlags GetVerticalStretch(View view) => GetAttachedValue<StretchFlags>(view, VerticalStretchProperty);

        /// <summary>
        /// Get the horizontal alignment of this child.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static Alignment GetHorizontalAlignment(View view) => GetAttachedValue<Alignment>(view, HorizontalAlignmentProperty);

        /// <summary>
        /// Get the vertical alignment of this child.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static Alignment GetVerticalAlignment(View view) => GetAttachedValue<Alignment>(view, VerticalAlignmentProperty);

        /// <summary>
        /// Set the column index.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static void SetColumn(View view, int value) => SetAttachedValue(view, ColumnProperty, value);

        /// <summary>
        /// Set the column span.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static void SetColumnSpan(View view, int value) => SetAttachedValue(view, ColumnSpanProperty, value);

        /// <summary>
        /// Set the row index.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static void SetRow(View view, int value) => SetAttachedValue(view, RowProperty, value);

        /// <summary>
        /// Set the row span.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static void SetRowSpan(View view, int value) => SetAttachedValue(view, RowSpanProperty, value);

        /// <summary>
        /// Set the value how child is resized within its horizontal space. <see cref="StretchFlags.Fill"/> by default.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static void SetHorizontalStretch(View view, StretchFlags value) => SetAttachedValue(view, HorizontalStretchProperty, value);

        /// <summary>
        /// Set the value how child is resized within its vertical space. <see cref="StretchFlags.Fill"/> by default.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static void SetVerticalStretch(View view, StretchFlags value) => SetAttachedValue(view, VerticalStretchProperty, value);

        /// <summary>
        /// Set the horizontal alignment of this child inside the cells.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static void SetHorizontalAlignment(View view, Alignment value) => SetAttachedValue(view, HorizontalAlignmentProperty, value);

        /// <summary>
        /// Set the vertical alignment of this child inside the cells.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public static void SetVerticalAlignment(View view, Alignment value) => SetAttachedValue(view, VerticalAlignmentProperty, value);

        /// <summary>
        /// The distance between columns.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public float ColumnSpacing
        {
            get => columnSpacing;
            set
            {
                if (columnSpacing == value) return;
                columnSpacing = value > 0 ? value : 0;

                RequestLayout();
            }
        }

        /// <summary>
        /// The distance between rows.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public float RowSpacing
        {
            get => rowSpacing;
            set
            {
                if (rowSpacing == value) return;
                rowSpacing = value > 0 ? value : 0;

                RequestLayout();
            }
        }

        /// <summary>
        /// Get/Set the orientation in the layout
        /// </summary>
        /// <exception cref="InvalidEnumArgumentException">Thrown when using invalid arguments that are enumerators.</exception>
        /// <since_tizen> 8 </since_tizen>
        public Orientation GridOrientation
        {
            get => gridOrientation;
            set
            {
                if (gridOrientation == value) return;
                if (value != Orientation.Horizontal && value != Orientation.Vertical)
                    throw new InvalidEnumArgumentException(nameof(GridOrientation));

                gridOrientation = value;
                RequestLayout();
            }
        }

        /// <summary>
        /// GridLayout Constructor.
        /// </summary>
        /// <returns> New Grid object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public GridLayout()
        {
        }

        /// <summary>
        /// Gets or Sets the number of columns in the grid.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int Columns
        {
            get => columns;
            set
            {
                if (value == columns) return;

                if (value < 1) value = 1;
                columns = value;
                RequestLayout();
            }
        }

        /// <summary>
        /// Gets or Sets the number of rows in the grid.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public int Rows
        {
            get => rows;
            set
            {
                if (value == rows) return;

                if (value < 1) value = 1;
                rows = value;
                RequestLayout();
            }
        }

        /// <summary>
        /// Measure the layout and its content to determine the measured width and the measured height.<br />
        /// </summary>
        /// <param name="widthMeasureSpec">horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">vertical space requirements as imposed by the parent.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            int widthSize;
            int heightSize;
            var widthMode = widthMeasureSpec.Mode;
            var heightMode = heightMeasureSpec.Mode;

            InitChildren(widthMeasureSpec, heightMeasureSpec);

            if (widthMode == MeasureSpecification.ModeType.Exactly)
                widthSize = (int)widthMeasureSpec.Size.AsRoundedValue();
            else
                widthSize = (int)(hLocations[maxColumnConut] - hLocations[0] - columnSpacing);

            if (heightMode == MeasureSpecification.ModeType.Exactly)
                heightSize = (int)heightMeasureSpec.Size.AsRoundedValue();
            else
                heightSize = (int)(vLocations[maxRowCount] - vLocations[0] - rowSpacing);

            LayoutLength widthLength = new LayoutLength(widthSize + Padding.Start + Padding.End);
            LayoutLength heightLenght = new LayoutLength(heightSize + Padding.Top + Padding.Bottom);

            MeasuredSize widthMeasuredSize = ResolveSizeAndState(widthLength, widthMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK);
            MeasuredSize heightMeasuredSize = ResolveSizeAndState(heightLenght, heightMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK);

            SetMeasuredDimensions(widthMeasuredSize, heightMeasuredSize);
        }

        /// <summary>
        /// Assign a size and position to each of its children.<br />
        /// </summary>
        /// <param name="changed">This is a new size or position for this layout.</param>
        /// <param name="left">Left position, relative to parent.</param>
        /// <param name="top"> Top position, relative to parent.</param>
        /// <param name="right">Right position, relative to parent.</param>
        /// <param name="bottom">Bottom position, relative to parent.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            InitChildrenWithExpand(MeasuredWidth.Size - Padding.Start - Padding.End, MeasuredHeight.Size - Padding.Top - Padding.Bottom);

            for (int i = 0; i < gridChildren.Length; i++)
            {
                GridChild child = gridChildren[i];
                View view = child.LayoutItem?.Owner;

                if (view == null) continue;

                Alignment halign = GetHorizontalAlignment(view);
                Alignment valign = GetVerticalAlignment(view);

                int column = child.Column.Start;
                int row = child.Row.Start;
                int columnEnd = child.Column.End;
                int rowEnd = child.Row.End;
                float l = hLocations[column] + Padding.Start + view.Margin.Start;
                float t = vLocations[row] + Padding.Top + view.Margin.Top;
                float width = hLocations[columnEnd] - hLocations[column] - ColumnSpacing - view.Margin.Start - view.Margin.End;
                float height = vLocations[rowEnd] - vLocations[row] - RowSpacing - view.Margin.Top - view.Margin.Bottom;

                if (!child.Column.Stretch.HasFlag(StretchFlags.Fill))
                {
                    l += (width - child.LayoutItem.MeasuredWidth.Size.AsDecimal()) * halign.ToFloat();
                    width = child.LayoutItem.MeasuredWidth.Size.AsDecimal();
                }

                if (!child.Row.Stretch.HasFlag(StretchFlags.Fill))
                {
                    t += (height - child.LayoutItem.MeasuredHeight.Size.AsDecimal()) * valign.ToFloat();
                    height = child.LayoutItem.MeasuredHeight.Size.AsDecimal();
                }

                child.LayoutItem.Layout(new LayoutLength(l), new LayoutLength(t), new LayoutLength(l + width), new LayoutLength(t + height));
            }
        }

        /// <summary>
        /// The value how child is resized within its space.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [Flags]
        public enum StretchFlags
        {
            /// <summary>
            /// Respect mesured size of the child.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            None = 0,
            /// <summary>
            /// Resize to completely fill the space.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Fill = 1,
            /// <summary>
            /// Expand to share available space in GridLayout.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Expand = 2,
            /// <summary>
            /// Expand to share available space in GridLayout and fill the space.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            ExpandAndFill = Fill + Expand,
        }

        /// <summary>
        /// The alignment of the grid layout child.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public enum Alignment
        {
            /// <summary>
            /// At the start of the container.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Start = 0,
            /// <summary>
            /// At the center of the container
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            Center = 1,
            /// <summary>
            /// At the end of the container.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            End = 2,
        }
    }

    // Extension Method of GridLayout.Alignment.
    internal static class AlignmentExtension
    {
        public static float ToFloat(this GridLayout.Alignment align)
        {
            return 0.5f * (float)align;
        }
    }
}
