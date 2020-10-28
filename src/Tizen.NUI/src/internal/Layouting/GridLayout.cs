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
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class implements a grid layout
    /// </summary>
    internal class GridLayout : LayoutGroup
    {
        const int AUTO_FIT = -1;
        private int _columns = 1;
        private int _rows = 1;
        private int _totalWidth;
        private int _totalHeight;
        private int _requestedColumnWidth = 1;
        private int _numberOfRequestedColumns;
        private GridLocations _locations;

        /// <summary>
        /// [draft] GridLayout Constructor/>
        /// </summary>
        /// <returns> New Grid object.</returns>
        public GridLayout()
        {
            _locations = new GridLocations();
        }

        // <summary>
        // [Draft] Get/Set the number of columns in the grid
        // </summary>
        public int Columns
        {
            get
            {
                return GetColumns();
            }
            set
            {
                SetColumns(value);
            }
        }


        /// <summary>
        /// [draft ] Sets the number of columns the GridLayout should have. />
        /// </summary>
        /// <param name="columns">The number of columns.</param>
        internal void SetColumns(int columns)
        {
            _numberOfRequestedColumns = columns;
            if( columns != _columns)
            {
                _columns = Math.Max(1, _columns);
                _columns = columns;
                RequestLayout();
            }
        }

        /// <summary>
        /// [draft ] Gets the number of columns in the Grid />
        /// </summary>
        /// <returns>The number of columns in the Grid.</returns>
        internal int GetColumns()
        {
            return _columns;
        }

        void DetermineNumberOfColumns( int availableSpace )
        {
            if( _numberOfRequestedColumns == AUTO_FIT )
            {
                if( availableSpace > 0 )
                {
                    // Can only calculate number of columns if a column width has been set
                    _columns = ( _requestedColumnWidth > 0 ) ? ( availableSpace / _requestedColumnWidth ) : 1;
                }
            }
        }

        protected override void OnMeasure( MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec )
        {
            var gridWidthMode = widthMeasureSpec.Mode;
            var gridHeightMode = heightMeasureSpec.Mode;
            int widthSize = (int)widthMeasureSpec.Size.AsRoundedValue();
            int heightSize = (int)heightMeasureSpec.Size.AsRoundedValue();

            int availableContentWidth;
            int availableContentHeight;

            int desiredChildHeight;
            int desiredChildWidth;

            Extents gridLayoutPadding = Owner.Padding;

            var childCount = _children.Count;

            // WIDTH SPECIFICATIONS

            // measure first child and use it's dimensions for layout measurement

            if (childCount > 0)
            {
                LayoutItem childLayoutItem = _children[0];
                View childOwner = childLayoutItem.Owner;

                MeasureChild( childLayoutItem, widthMeasureSpec, heightMeasureSpec );
                desiredChildHeight = (int)childLayoutItem.MeasuredHeight.Size.AsRoundedValue();
                desiredChildWidth = (int)childLayoutItem.MeasuredWidth.Size.AsRoundedValue();

                // If child has a margin then add it to desired size
                Extents childMargin = childOwner.Margin;
                desiredChildHeight += childMargin.Top + childMargin.Bottom;
                desiredChildWidth += childMargin.Start + childMargin.End;

                _totalWidth = desiredChildWidth * _columns;
                Log.Info("NUI", "Grid::OnMeasure TotalDesiredWidth(" + _totalWidth + ") \n" );

                // Include padding for max and min checks
                _totalWidth += gridLayoutPadding.Start + gridLayoutPadding.End;

                // Ensure width does not exceed specified at most width or less than mininum width
                _totalWidth = Math.Max( _totalWidth, (int)SuggestedMinimumWidth.AsRoundedValue() );

                // widthMode EXACTLY so grid must be the given width
                if( gridWidthMode == MeasureSpecification.ModeType.Exactly || gridWidthMode == MeasureSpecification.ModeType.AtMost )
                {
                    // In the case of AT_MOST, widthSize is the max limit.
                    _totalWidth = Math.Min( _totalWidth, widthSize );
                }

                availableContentWidth = _totalWidth - gridLayoutPadding.Start - gridLayoutPadding.End;
                widthSize = _totalWidth;

                Log.Info("NUI", "Grid::OnMeasure availableContentWidth:" + availableContentWidth + " TotalWidth(" + _totalWidth + ") \n" );
                // HEIGHT SPECIFICATIONS

                // heightMode EXACTLY so grid must be the given height
                if( gridHeightMode == MeasureSpecification.ModeType.Exactly || gridHeightMode == MeasureSpecification.ModeType.AtMost )
                {
                    if( childCount > 0 )
                    {
                        _totalHeight = gridLayoutPadding.Top + gridLayoutPadding.Bottom;

                        for( int i = 0; i < childCount; i += _columns )
                        {
                          _totalHeight += desiredChildHeight;
                        }
                        Log.Info( "NUI", "Grid::OnMeasure TotalDesiredHeight(" + _totalHeight + ") \n" );

                        // Ensure ourHeight does not exceed specified at most height
                        _totalHeight = Math.Min( _totalHeight, heightSize );
                        _totalHeight = Math.Max( _totalHeight, (int)SuggestedMinimumHeight.AsRoundedValue() );

                        heightSize = _totalHeight;
                    } // Child exists

                    // In the case of AT_MOST, availableContentHeight is the max limit.
                    availableContentHeight = heightSize - gridLayoutPadding.Top - gridLayoutPadding.Bottom;
                }
                else
                {
                  // Grid expands to fit content

                  // If number of columns AUTO_FIT then set to 1 column.
                  _columns = ( _columns > 0 ) ? _columns : 1;
                  // Calculate numbers of rows, round down result as later check for remainder.
                  _rows = childCount / _columns;
                  // If number of cells not cleanly dividable by columns, add another row to house remainder cells.
                  _rows += ( childCount % _columns > 0 ) ? 1 : 0;

                  availableContentHeight = desiredChildHeight * _rows;
                }

            // If number of columns not defined
            DetermineNumberOfColumns( availableContentWidth );

            // Locations define the start, end,top and bottom of each cell.
            _locations.CalculateLocations(_columns, availableContentWidth, availableContentHeight, childCount);

            } // Children exists

            SetMeasuredDimensions( ResolveSizeAndState( new LayoutLength(widthSize), widthMeasureSpec, MeasuredSize.StateType.MeasuredSizeOK ),
                                   ResolveSizeAndState( new LayoutLength(heightSize), heightMeasureSpec,  MeasuredSize.StateType.MeasuredSizeOK ) );
        }

        protected override void OnLayout( bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom )
        {
            List<GridLocations.Cell> locations = _locations.GetLocations();

            Extents gridLayoutPadding = Owner.Padding;
            Extents childMargins = new Extents();

            // Margin for all children dependant on if set on first child
            if( _children.Count > 0 )
            {
              childMargins = _children[0]?.Owner?.Margin;
            }

            int index = 0;
            foreach( LayoutItem childLayout in _children )
            {
                // for each child
                if( childLayout != null )
                {
                    // Get start and end position of child x1,x2
                    int x1 = locations[ index ].Start;
                    int x2 = locations[ index ].End;

                    // Get top and bottom position of child y1,y2
                    int y1 = locations[ index ].Top;
                    int y2 = locations[ index ].Bottom;

                    Log.Info("NUI", "CellSize(" + (x2-x1) + "," + (y2-y1) +
                                    ") CellPos(" + x1 + "," + y1 + "," + x2 + "," + y2  +")\n");

                    // Offset children by the grids padding if present
                    x1 += gridLayoutPadding.Start;
                    x2 += gridLayoutPadding.Start;
                    y1 += gridLayoutPadding.Top;
                    y2 += gridLayoutPadding.Top;

                    // Offset children by the margin of the first child ( if required ).
                    x1 += childMargins.Start;
                    x2 -= childMargins.End;
                    y1 += childMargins.Top;
                    y2 -= childMargins.Bottom;

                    childLayout.Layout( new LayoutLength(x1), new LayoutLength(y1),
                                        new LayoutLength(x2), new LayoutLength(y2) );
                    index++;
                }
            }
        }
    }
}
