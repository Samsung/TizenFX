/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    public partial class GridLayout
    {
        private Node[] hEdgeList;
        private Node[] vEdgeList;

        private int maxRowCount;
        private int maxColumnConut;
        private float[] hLocations;
        private float[] vLocations;
        private int totalHorizontalExpand = 0;
        private int totalVerticalExpand = 0;

        private List<GridChild> gridChildren;

        /// <summary>
        /// The nested class to represent a node of DAG.
        /// </summary>
        private class Node
        {
            /// <summary>The start vertex with the same value as <c>Column/Row</c> child property.</summary>
            public int Start { get; }

            /// <summary>The end vertex with the same value as <c>Column+ColumnSpan/Row+RowSpan</c>.</summary>
            public int End { get; }

            /// <summary>The edge with the same value as measured width/height of child.</summary>
            public float Edge { get; }

            /// <summary>The stretch with the same value as <c>HorizontalStretch/VerticalStretch</c>.</summary>
            public StretchFlags Stretch { get; }

            /// <summary>The expanded size. It can be updated by expand calculation.</summary>
            public float ExpandedSize { get; set; }

            public Node(int vertex, int span, float edge, StretchFlags stretch)
            {
                Start = vertex;
                End = vertex + span;
                Edge = edge;
                Stretch = stretch;
                ExpandedSize = 0;
            }
        }
        private class GridChild
        {
            public LayoutItem LayoutItem { get; }
            public Node Column { get; }
            public Node Row { get; }
            public GridChild(LayoutItem layoutItem, Node column, Node row)
            {
                LayoutItem = layoutItem;
                Column = column;
                Row = row;
            }
        }

        private void InitChildren(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            InitChildrenData(widthMeasureSpec, heightMeasureSpec);

            InitEdgeList(ref hEdgeList);
            InitLocations(ref hLocations);

            InitEdgeList(ref vEdgeList);
            InitLocations(ref vLocations);
        }

        private void InitChildrenWithExpand(LayoutLength width, LayoutLength height)
        {
            if (totalHorizontalExpand > 0)
            {
                ReInitLocationsWithExpand(ref hLocations, width);
            }
            if (totalVerticalExpand > 0)
            {
                ReInitLocationsWithExpand(ref vLocations, height);
            }
        }

        private void ReInitLocationsWithExpand(ref float[] locations, LayoutLength parentSize)
        {
            bool isHorizontal = (locations == hLocations);
            Node[] edgeList = isHorizontal ? hEdgeList : vEdgeList;
            int maxIndex = isHorizontal ? maxColumnConut : maxRowCount;
            float space = isHorizontal ? ColumnSpacing : RowSpacing;
            float totalExpand = isHorizontal ? totalHorizontalExpand : totalVerticalExpand;

            float parentDecimalSize = parentSize.AsDecimal();
            float maxExpandedSize = parentDecimalSize * LayoutChildren.Count;
            float minExpandedSize = 0;
            float newChildrenSize = locations[maxIndex] - locations[0] - space;

            // No available space
            if (newChildrenSize > parentDecimalSize)
                return;

            // binary search for finding maximum expanded size.
            while ((int)(newChildrenSize + 0.5) != (int)parentDecimalSize)
            {
                float curExpandedSize = (maxExpandedSize + minExpandedSize) / 2;
                for (int i = 0; i < edgeList.Length; i++)
                {
                    Node node = edgeList[i];
                    // update expanded size.
                    if (node.Stretch.HasFlag(StretchFlags.Expand))
                        node.ExpandedSize = curExpandedSize / totalExpand;
                }

                // re-init locations based on updated expanded size.
                InitLocations(ref locations);
                newChildrenSize = locations[maxIndex] - locations[0] - space;

                // internal child size cannot exceed the Gridlayout size.
                if (newChildrenSize > parentDecimalSize)
                {
                    maxExpandedSize = curExpandedSize;
                }
                else
                {
                    minExpandedSize = curExpandedSize;
                }
            }
        }

        private void InitChildrenData(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            bool isHorizontal = (GridOrientation == Orientation.Horizontal);
            int mainPivot = 0, subPivot = 0;
            int[] pivotStack = new int[isHorizontal ? Columns : Rows];

            vLocations = hLocations = null;
            vEdgeList = hEdgeList = null;
            gridChildren = new List<GridChild>();
            maxColumnConut = Columns;
            maxRowCount = Rows;

            totalVerticalExpand = 0;
            totalHorizontalExpand = 0;

            foreach (LayoutItem item in IterateLayoutChildren())
            {
                int column, columnSpan, row, rowSpan;
                StretchFlags verticalStretch, horizontalStretch;
                View view = item.Owner;

                column = GetColumn(view);
                columnSpan = GetColumnSpan(view);
                row = GetRow(view);
                rowSpan = GetRowSpan(view);
                verticalStretch = GetVerticalStretch(view);
                horizontalStretch = GetHorizontalStretch(view);

                if (column + columnSpan > maxColumnConut || row + rowSpan > maxRowCount)
                {
                    if (column + columnSpan > maxColumnConut)
                        Tizen.Log.Error("NUI", "Column + ColumnSapn exceeds Grid Columns. Column + ColumnSpan (" + column + " + " + columnSpan + ") > Grid Columns(" + maxColumnConut + ")");
                    else
                        Tizen.Log.Error("NUI", "Row + RowSapn exceeds Grid Rows. Row + RowSapn (" + row + " + " + rowSpan + ") > Grid Rows(" + maxRowCount + ")");

                    gridChildren.Add(new GridChild(null, new Node(0, 1, 0, 0), new Node(0, 1, 0, 0)));

                    continue;
                }

                if (horizontalStretch.HasFlag(StretchFlags.Expand))
                    totalHorizontalExpand++;

                if (verticalStretch.HasFlag(StretchFlags.Expand))
                    totalVerticalExpand++;

                // assign column/row depending on GridOrientation. The main axis count(Columns on Horizontal, Rows otherwise) won't be exceeded
                // explicit column(row) count which is assigned by Columns(Rows). but, cross axis count(Rows(Columns)) can be increased by sub axis count.
                if (column == AutoColumn || row == AutoRow)
                {
                    (int point, int span) mainAxis = isHorizontal ? (column, columnSpan) : (row, rowSpan);
                    (int point, int span) subAxis = isHorizontal ? (row, rowSpan) : (column, columnSpan);

                    if (subAxis.point != AutoColumn && subAxis.point != AutoRow)
                        subPivot = subAxis.point;
                    if (mainAxis.point != AutoColumn && mainAxis.point != AutoRow)
                        mainPivot = mainAxis.point;

                    if (mainPivot + mainAxis.span > pivotStack.Length)
                    {
                        mainPivot = 0;
                        subPivot++;
                    }

                    for (int n = mainPivot + mainAxis.span - 1; n >= mainPivot; n--)
                    {
                        if (pivotStack[n] > subPivot)
                        {
                            mainPivot = n + 1;
                            n = mainPivot + mainAxis.span;

                            if (n > pivotStack.Length)
                            {
                                if (mainAxis.point != AutoColumn && mainAxis.point != AutoRow)
                                    mainPivot = mainAxis.point;
                                else
                                    mainPivot = 0;

                                n = mainPivot + mainAxis.span;
                                subPivot++;
                            }
                        }
                    }

                    if (isHorizontal)
                    {
                        column = mainPivot;
                        row = subPivot;
                    }
                    else
                    {
                        column = subPivot;
                        row = mainPivot;
                    }

                    for (int start = mainPivot, end = mainPivot + mainAxis.span; start < end; start++)
                    {
                        pivotStack[start] = subPivot + subAxis.span;
                    }

                    mainPivot += mainAxis.span;
                }

                if (maxColumnConut < column + columnSpan)
                    maxColumnConut = column + columnSpan;
                if (maxRowCount < row + rowSpan)
                    maxRowCount = row + rowSpan;

                MeasureChildWithMargins(item, widthMeasureSpec, new LayoutLength(0), heightMeasureSpec, new LayoutLength(0));
                gridChildren.Add(new GridChild(item,
                                               new Node(column, columnSpan, item.MeasuredWidth.Size.AsDecimal() + item.Owner.Margin.Start + item.Owner.Margin.End, horizontalStretch),
                                               new Node(row, rowSpan, item.MeasuredHeight.Size.AsDecimal() + item.Owner.Margin.Top + item.Owner.Margin.Bottom, verticalStretch)));
            }
        }

        /// <summary> Initialize the edge list sorted by start vertex. </summary>
        private void InitEdgeList(ref Node[] edgeList)
        {
            bool isHorizontal = (edgeList == hEdgeList);
            int axisCount = isHorizontal ? Columns : Rows;

            edgeList = new Node[gridChildren.Count + axisCount];

            for (int i = 0; i < gridChildren.Count; i++)
                edgeList[i] = isHorizontal ? gridChildren[i].Column : gridChildren[i].Row;

            // Add virtual edge that have no edge for connecting adjacent cells.
            for (int i = gridChildren.Count, end = gridChildren.Count + axisCount, v = 0; i < end; i++, v++)
                edgeList[i] = new Node(v, 1, 0, 0);

            Array.Sort(edgeList, (a, b) => a.Start.CompareTo(b.Start));
        }

        /// <summary>
        /// Locations are longest path from zero-vertex. that means 'locations[MAX] - locations[0]' is maximum size of children.
        /// Since GridLayout is Directed Acyclic Graph(DAG) which have no negative cycles, longest path can be found in linear time.
        /// </summary>
        private void InitLocations(ref float[] locations)
        {
            bool isHorizontal = (locations == hLocations);
            int maxAxisCount = isHorizontal ? maxColumnConut : maxRowCount;
            Node[] edgeList = isHorizontal ? hEdgeList : vEdgeList;
            float space = isHorizontal ? ColumnSpacing : RowSpacing;

            locations = new float[maxAxisCount + 1];

            for (int i = 0; i < edgeList.Length; i++)
            {
                float newLocation = locations[edgeList[i].Start] + edgeList[i].Edge + edgeList[i].ExpandedSize;
                if (edgeList[i].Edge + edgeList[i].ExpandedSize > 0)
                    newLocation += space;

                if (locations[edgeList[i].End] < newLocation)
                {
                    locations[edgeList[i].End] = newLocation;
                }
            }
        }
    }
}
