/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This internal class houses the algorithm for computing the locations and size of cells.
    /// </summary>
    internal class GridLocations
    {
        /// <summary>
        /// A struct holding the 4 points which make up a cell.
        /// </summary>
        public struct Cell
        {
            public int Start;
            public int End;
            public int Top;
            public int Bottom;

            /// <summary>
            /// Initialize a cell with the given points.
            /// </summary>
            /// <param name="start">The start x coordinate.</param>
            /// <param name="end">The end x coordinate.</param>
            /// <param name="top">The top y coordinate.</param>
            /// <param name="bottom">The bottom y coordinate.</param>

            public Cell(int start, int end, int top, int bottom)
            {
                Start = start;
                End = end;
                Top = top;
                Bottom = bottom;
            }
        };

        private List<Cell> _locationsVector;

        /// <summary>
        /// [Draft]Constructor
        /// </summary>
        public GridLocations()
        {
            _locationsVector = new List<Cell>();
        }

        /// <summary>
        /// Get locations vector with position of each cell and cell size.
        /// </summary>
        public List<Cell> GetLocations()
        {
            return _locationsVector;
        }

        /// <summary>
        /// [Draft] Uses the given parameters to calculate the x,y coordinates of each cell and cell size.
        /// </summary>
        public void CalculateLocations(int numberOfColumns, int availableWidth, int availableHeight, int numberOfCells)
        {
            numberOfColumns = Math.Max(numberOfColumns, 1);
            _locationsVector.Clear();

            // Calculate width and height of columns and rows.

            // Calculate numbers of rows, round down result as later check for remainder.
            int remainder = 0;
            int numberOfRows = Math.DivRem(numberOfCells, numberOfColumns, out remainder);
            // If number of cells not cleanly dividable by columns, add another row to house remainder cells.
            numberOfRows += (remainder > 0) ? 1 : 0;

            // Rounding on column widths performed here,
            // if visually noticeable then can divide the space explicitly between columns.
            int columnWidth = availableWidth / numberOfColumns;

            int rowHeight = availableHeight;

            if (numberOfRows > 0)
            {
                // Column height supplied so use this unless exceeds available height.
                rowHeight = (availableHeight / numberOfRows);
            }

            int y1 = 0;
            int y2 = y1 + rowHeight;

            // Calculate start, end, top and bottom coordinate of each cell.

            // Iterate rows
            for (var i = 0u; i < numberOfRows; i++)
            {
                int x1 = 0;
                int x2 = x1 + columnWidth;

                // Iterate columns
                for (var j = 0; j < numberOfColumns; j++)
                {
                    Cell cell = new Cell(x1, x2, y1, y2);
                    _locationsVector.Add(cell);
                    // Calculate starting x and ending x position of each column
                    x1 = x2;
                    x2 = x2 + columnWidth;
                }

                // Calculate top y and bottom y position of each row.
                y1 = y2;
                y2 = y2 + rowHeight;
            }
        }


        /// <summary>
        /// [Draft] Uses the given parameters to calculate the x,y coordinates of each cell and cell size.
        /// </summary>
        public void CalculateLocationsRow(int numberOfRows, int availableWidth, int availableHeight, int numberOfCells)
        {
            numberOfRows = Math.Max(numberOfRows, 1);
            _locationsVector.Clear();

            int remainder = 0;
            int numberOfColumns = Math.DivRem(numberOfCells, numberOfRows, out remainder);

            numberOfColumns += (remainder > 0) ? 1 : 0;

            int rowHeight = availableHeight / numberOfRows;
            int columnWidth = availableHeight;

            if (numberOfColumns > 0)
            {
                columnWidth = (availableWidth / numberOfColumns);
            }

            int x1 = 0;
            int x2 = x1 + columnWidth;

            for (var i = 0u; i < numberOfColumns; i++)
            {
                int y1 = 0;
                int y2 = y1 + rowHeight;

                for (var j = 0; j < numberOfRows; j++)
                {
                    Cell cell = new Cell(x1, x2, y1, y2);
                    _locationsVector.Add(cell);
                    y1 = y2;
                    y2 = y2 + rowHeight;
                }

                x1 = x2;
                x2 = x2 + columnWidth;
            }
        }
    }
}
