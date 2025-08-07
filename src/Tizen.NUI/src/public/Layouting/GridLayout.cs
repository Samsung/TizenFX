/* Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
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
        public static readonly BindableProperty ColumnProperty = null;

        /// <summary>
        /// ColumnSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColumnSpanProperty = null;

        /// <summary>
        /// RowProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RowProperty = null;

        /// <summary>
        /// RowSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RowSpanProperty = null;

        /// <summary>
        /// HorizontalStretchProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalStretchProperty = null;

        /// <summary>
        /// VerticalStretchProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalStretchProperty = null;

        /// <summary>
        /// HorizontalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = null;

        /// <summary>
        /// VerticalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = null;


        [EditorBrowsable(EditorBrowsableState.Never)]
        public const int AutoColumn = int.MinValue;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const int AutoRow = int.MinValue;

        private static Dictionary<View, int> columnMap;
        private static Dictionary<View, int> columnSpanMap;
        private static Dictionary<View, int> rowMap;
        private static Dictionary<View, int> rowSpanMap;
        private static Dictionary<View, StretchFlags> horizontalStretchMap;
        private static Dictionary<View, StretchFlags> verticalStretchMap;
        private static Dictionary<View, Alignment> horizontalAlignmentMap;
        private static Dictionary<View, Alignment> verticalAlignmentMap;

        private Orientation gridOrientation = Orientation.Horizontal;
        private int columns = 1;
        private int rows = 1;
        private float columnSpacing;
        private float rowSpacing;

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
        /// Gets the column index.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The column index of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static int GetColumn(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<int>(view, ColumnProperty);
            }
            else
            {
                if (columnMap.TryGetValue(view, out var column))
                {
                    return column;
                }
                else
                {
                    return AutoColumn;
                }
            }
        }

        /// <summary>
        /// Gets the column span.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The column span of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static int GetColumnSpan(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<int>(view, ColumnSpanProperty);
            }
            else
            {
                if (columnSpanMap.TryGetValue(view, out var columnSpan))
                {
                    return columnSpan;
                }
                else
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// Gets the row index.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The row index of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static int GetRow(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<int>(view, RowProperty);
            }
            else
            {
                if (rowMap.TryGetValue(view, out var row))
                {
                    return row;
                }
                else
                {
                    return AutoRow;
                }
            }
        }

        /// <summary>
        /// Gets the row span.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The row span of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static int GetRowSpan(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<int>(view, RowSpanProperty);
            }
            else
            {
                if (rowSpanMap.TryGetValue(view, out var rowSpan))
                {
                    return rowSpan;
                }
                else
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// Gets the value how child is resized within its horizontal space.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The horizontal stretch flag of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static StretchFlags GetHorizontalStretch(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<StretchFlags>(view, HorizontalStretchProperty);
            }
            else
            {
                if (horizontalStretchMap.TryGetValue(view, out var horizontalStretch))
                {
                    return horizontalStretch;
                }
                else
                {
                    return StretchFlags.None;
                }
            }
        }

        /// <summary>
        /// Gets the value how child is resized within its vertical space.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The vertical stretch flag of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static StretchFlags GetVerticalStretch(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<StretchFlags>(view, VerticalStretchProperty);
            }
            else
            {
                if (verticalStretchMap.TryGetValue(view, out var verticalStretch))
                {
                    return verticalStretch;
                }
                else
                {
                    return StretchFlags.None;
                }
            }
        }

        /// <summary>
        /// Gets the horizontal alignment of this child.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The horizontal alignment of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static Alignment GetHorizontalAlignment(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<Alignment>(view, HorizontalAlignmentProperty);
            }
            else
            {
                if (horizontalAlignmentMap.TryGetValue(view, out var horizontalAlignment))
                {
                    return horizontalAlignment;
                }
                else
                {
                    return Alignment.Start;
                }
            }
        }

        /// <summary>
        /// Gets the vertical alignment of this child.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <returns>The vertical alignment of <paramref name="view"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static Alignment GetVerticalAlignment(View view)
        {
            if (NUIApplication.IsUsingXaml)
            {
                return GetAttachedValue<Alignment>(view, VerticalAlignmentProperty);
            }
            else
            {
                if (verticalAlignmentMap.TryGetValue(view, out var verticalAlignment))
                {
                    return verticalAlignment;
                }
                else
                {
                    return Alignment.Start;
                }
            }
        }

        /// <summary>
        /// Sets the column index the child occupies. A default column is <see cref="AutoColumn"/>.<br/>
        /// If column is a <see cref="AutoColumn"/>, child will be automatically laid out depending on <see cref="GridOrientation"/>.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The column index of <paramref name="view"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> cannot be a negative value other than <see cref="AutoColumn"/>.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetColumn(View view, int value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, ColumnProperty, value);
            }
            else
            {
                _ = view ?? throw new ArgumentNullException(nameof(view));
                if (value >= 0)
                {
                    columnMap[view] = value;
                    view.Layout?.RequestLayout();
                }
            }
        }

        /// <summary>
        /// Sets the column span the child occupies. the default value is 1.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The column span of <paramref name="view"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> cannot be less than 1.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetColumnSpan(View view, int value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, ColumnSpanProperty, value);
            }
            else
            {
                _ = view ?? throw new ArgumentNullException(nameof(view));
                if (value >= 1)
                {
                    columnSpanMap[view] = value;
                    view.Layout?.RequestLayout();
                }
            }
        }

        /// <summary>
        /// Sets the row index the child occupies. A default row index is <see cref="AutoRow"/>.<br/>
        /// If row is a <see cref="AutoRow"/>, child will be automatically laid out depending on <see cref="GridOrientation"/>.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The row index of <paramref name="view"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> cannot be a negative value other than <see cref="AutoRow"/>.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetRow(View view, int value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, RowProperty, value);
            }
            else
            {
                _ = view ?? throw new ArgumentNullException(nameof(view));
                if (value >= 0)
                {
                    rowMap[view] = value;
                    view.Layout?.RequestLayout();
                }
            }
        }

        /// <summary>
        /// Sets the row span the child occupies. the default value is 1.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The row span of <paramref name="view"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> cannot be less than 1.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetRowSpan(View view, int value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, RowSpanProperty, value);
            }
            else
            {
                _ = view ?? throw new ArgumentNullException(nameof(view));
                if (value >= 1)
                {
                    rowSpanMap[view] = value;
                    view.Layout?.RequestLayout();
                }
            }
        }

        /// <summary>
        /// Sets the value how child is resized within its horizontal space. <see cref="StretchFlags.None"/> by default.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The horizontal stretch flag of <paramref name="view"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> should be <see cref="StretchFlags"/>.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetHorizontalStretch(View view, StretchFlags value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, HorizontalStretchProperty, value);
            }
            else
            {
                _ = view ?? throw new ArgumentNullException(nameof(view));
                if (value >= StretchFlags.None && value <= StretchFlags.ExpandAndFill)
                {
                    horizontalStretchMap[view] = value;
                    view.Layout?.RequestLayout();
                }
            }
        }

        /// <summary>
        /// Set the value how child is resized within its vertical space. <see cref="StretchFlags.None"/> by default.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The vertical stretch flag of <paramref name="view"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> should be <see cref="StretchFlags"/>.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetVerticalStretch(View view, StretchFlags value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, VerticalStretchProperty, value);
            }
            else
            {
                _ = view ?? throw new ArgumentNullException(nameof(view));
                if (value >= StretchFlags.None && value <= StretchFlags.ExpandAndFill)
                {
                    verticalStretchMap[view] = value;
                    view.Layout?.RequestLayout();
                }
            }
        }

        /// <summary>
        /// Set the horizontal alignment of this child inside the cells. <see cref="Alignment.Start"/> by default.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The horizontal alignment flag of <paramref name="view"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> should be <see cref="Alignment"/>.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetHorizontalAlignment(View view, Alignment value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, HorizontalAlignmentProperty, value);
            }
            else
            {
                _ = view ?? throw new ArgumentNullException(nameof(view));
                if (value >= Alignment.Start && value <= Alignment.End)
                {
                    horizontalAlignmentMap[view] = value;
                    view.Layout?.RequestLayout();
                }
            }
        }

        /// <summary>
        /// Set the vertical alignment of this child inside the cells.
        /// </summary>
        /// <param name="view">The child view.</param>
        /// <param name="value">The vertical alignment flag of <paramref name="view"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="view"/> cannot be null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="value"/> should be <see cref="Alignment"/>.</exception>
        /// <since_tizen> 8 </since_tizen>
        public static void SetVerticalAlignment(View view, Alignment value)
        {
            if (NUIApplication.IsUsingXaml)
            {
                SetAttachedValue(view, VerticalAlignmentProperty, value);
            }
            else
            {
                _ = view ?? throw new ArgumentNullException(nameof(view));
                if (value >= Alignment.Start && value <= Alignment.End)
                {
                    verticalAlignmentMap[view] = value;
                    view.Layout?.RequestLayout();
                }
            }
        }

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

        static GridLayout()
        {
            if (NUIApplication.IsUsingXaml)
            {
                ColumnProperty = BindableProperty.CreateAttached("Column", typeof(int), typeof(GridLayout), AutoColumn,
                    validateValue: (bindable, value) => (int)value >= 0 || (int)value == AutoColumn, propertyChanged: OnChildPropertyChanged);
                ColumnSpanProperty = BindableProperty.CreateAttached("ColumnSpan", typeof(int), typeof(GridLayout), 1,
                    validateValue: (bindable, value) => (int)value >= 1, propertyChanged: OnChildPropertyChanged);
                RowProperty = BindableProperty.CreateAttached("Row", typeof(int), typeof(GridLayout), AutoRow,
                    validateValue: (bindable, value) => (int)value >= 0 || (int)value == AutoRow, propertyChanged: OnChildPropertyChanged);
                RowSpanProperty = BindableProperty.CreateAttached("RowSpan", typeof(int), typeof(GridLayout), 1,
                    validateValue: (bindable, value) => (int)value >= 1, propertyChanged: OnChildPropertyChanged);
                HorizontalStretchProperty = BindableProperty.CreateAttached("HorizontalStretch", typeof(StretchFlags), typeof(GridLayout), default(StretchFlags),
                    validateValue: ValidateEnum((int)StretchFlags.None, (int)StretchFlags.ExpandAndFill), propertyChanged: OnChildPropertyChanged);
                VerticalStretchProperty = BindableProperty.CreateAttached("VerticalStretch", typeof(StretchFlags), typeof(GridLayout), default(StretchFlags),
                    validateValue: ValidateEnum((int)StretchFlags.None, (int)StretchFlags.ExpandAndFill), propertyChanged: OnChildPropertyChanged);
                HorizontalAlignmentProperty = BindableProperty.CreateAttached("HorizontalAlignment", typeof(Alignment), typeof(GridLayout), Alignment.Start,
                    validateValue: ValidateEnum((int)Alignment.Start, (int)Alignment.End), propertyChanged: OnChildPropertyChanged);
                VerticalAlignmentProperty = BindableProperty.CreateAttached("VerticalAlignment", typeof(Alignment), typeof(GridLayout), Alignment.Start,
                    validateValue: ValidateEnum((int)Alignment.Start, (int)Alignment.End), propertyChanged: OnChildPropertyChanged);
            }
            else
            {
                columnMap = new Dictionary<View, int>();
                columnSpanMap = new Dictionary<View, int>();
                rowMap = new Dictionary<View, int>();
                rowSpanMap = new Dictionary<View, int>();
                horizontalStretchMap = new Dictionary<View, StretchFlags>();
                verticalStretchMap = new Dictionary<View, StretchFlags>();
                horizontalAlignmentMap = new Dictionary<View, Alignment>();
                verticalAlignmentMap = new Dictionary<View, Alignment>();
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
            int widthSize = 0;
            int heightSize;
            var widthMode = widthMeasureSpec.Mode;
            var heightMode = heightMeasureSpec.Mode;

            InitChildren(widthMeasureSpec, heightMeasureSpec);

            if (widthMode == MeasureSpecification.ModeType.Exactly)
            {
                widthSize = (int)widthMeasureSpec.Size.AsRoundedValue();
            }
            else
            {
                if (hLocations?.Length > maxColumnConut)
                {
                    widthSize = (int)(hLocations[maxColumnConut] - hLocations[0] - columnSpacing);
                }
            }

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

            for (int i = 0; i < gridChildren.Count; i++)
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
                float childLeft = hLocations[column] + Padding.Start + view.Margin.Start;
                float childTop = vLocations[row] + Padding.Top + view.Margin.Top;
                float width = hLocations[columnEnd] - hLocations[column] - ColumnSpacing - view.Margin.Start - view.Margin.End;
                float height = vLocations[rowEnd] - vLocations[row] - RowSpacing - view.Margin.Top - view.Margin.Bottom;
                bool needMeasuredWidth = false;
                bool needMeasuredHeight = false;

                if (child.Column.Stretch.HasFlag(StretchFlags.Fill))
                {
                    needMeasuredWidth = true;
                }
                else
                {
                    childLeft += (width - child.LayoutItem.MeasuredWidth.Size.AsDecimal()) * halign.ToFloat();
                    width = child.LayoutItem.MeasuredWidth.Size.AsDecimal();
                }

                if (child.Row.Stretch.HasFlag(StretchFlags.Fill))
                {
                    needMeasuredHeight = true;
                }
                else
                {
                    childTop += (height - child.LayoutItem.MeasuredHeight.Size.AsDecimal()) * valign.ToFloat();
                    height = child.LayoutItem.MeasuredHeight.Size.AsDecimal();
                }

                if (needMeasuredWidth || needMeasuredHeight)
                {
                    // To calculate the grand children's Measure() with the mode type Exactly,
                    // children's Measure() is called with MatchParent if the children have WrapContent.
                    //
                    // i.e.
                    // If children have Wrapcontent and the grand children have MatchParent,
                    // then grand children's MeasuredWidth/Height do not fill the children
                    // because the grand children's Measure() is called with the mode type AtMost.
                    var layoutWidth = child.LayoutItem.Owner.LayoutWidth;
                    var layoutHeight = child.LayoutItem.Owner.LayoutHeight;
                    using Size2D origSize = new Size2D(child.LayoutItem.Owner.Size2D.Width, child.LayoutItem.Owner.Size2D.Height);

                    if (needMeasuredWidth)
                    {
                        child.LayoutItem.Owner.LayoutWidth = LayoutDimension.MatchParent;
                    }
                    if (needMeasuredHeight)
                    {
                        child.LayoutItem.Owner.LayoutHeight = LayoutDimension.MatchParent;
                    }

                    MeasureSpecification widthSpec = new MeasureSpecification(new LayoutLength(width), MeasureSpecification.ModeType.Exactly);
                    MeasureSpecification heightSpec = new MeasureSpecification(new LayoutLength(height), MeasureSpecification.ModeType.Exactly);
                    MeasureChild(child.LayoutItem, widthSpec, heightSpec);

                    if (needMeasuredWidth)
                    {
                        child.LayoutItem.Owner.LayoutWidth = layoutWidth;
                    }
                    if (needMeasuredHeight)
                    {
                        child.LayoutItem.Owner.LayoutHeight = layoutHeight;
                    }

                    // If the both Width/HeightSpecification are set with values bigger than 0,
                    // then the child's Size2D is changed with the values of Width/HeightSpecification.
                    // The Size2D changes, caused by setting Width/HeightSpecification, should be reverted.
                    if (needMeasuredWidth && needMeasuredHeight && (layoutWidth > 0) && (layoutHeight > 0))
                    {
                        child.LayoutItem.Owner.SetSize(origSize.Width, origSize.Height);
                    }
                }

                child.LayoutItem.Layout(new LayoutLength(childLeft), new LayoutLength(childTop), new LayoutLength(childLeft + width), new LayoutLength(childTop + height));
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
            /// Respect measured size of the child.
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
