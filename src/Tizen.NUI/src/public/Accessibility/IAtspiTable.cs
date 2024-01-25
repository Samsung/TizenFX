/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Accessibility
{
    /// <summary>
    /// Interface representing a table.
    /// </summary>
    /// <remarks>
    /// The selection methods extend the Selection interface, so both should be implemented by table and grid controls.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAtspiTable
    {
        /// <summary>
        /// Gets the number of rows.
        /// </summary>
        /// <returns> The number of rows </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetRowCount();

        /// <summary>
        /// Gets the number of columns.
        /// </summary>
        /// <returns> The number of columns </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetColumnCount();

        /// <summary>
        /// Gets the number of selected rows.
        /// </summary>
        /// <returns> The number of selected rows </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetSelectedRowCount();

        /// <summary>
        /// Gets the number of selected columns.
        /// </summary>
        /// <returns> The number of selected columns </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetSelectedColumnCount();

        /// <summary>
        /// Gets the table's caption.
        /// </summary>
        /// <returns> The caption or null </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        View AccessibilityGetCaption();

        /// <summary>
        /// Gets the table's summary.
        /// </summary>
        /// <returns> The summary or null </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        View AccessibilityGetSummary();

        /// <summary>
        /// Gets the cell at the specified position.
        /// </summary>
        /// <param name="row"> Row number </param>
        /// <param name="column"> Column number </param>
        /// <returns> The cell or null </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IAtspiTableCell AccessibilityGetCell(int row, int column);

        /// <summary>
        /// Gets the one-dimensional index of a cell.
        /// </summary>
        /// <remarks>
        /// The returned index should be such that:
        ///  <code>
        ///   GetChildAtIndex(GetChildIndex(row, column)) == GetCell(row, column)
        ///  </code>
        /// </remarks>
        /// <param name="row"> Row number </param>
        /// <param name="column"> Column number </param>
        /// <returns> The one-dimensional index </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetChildIndex(int row, int column);

        /// <summary>
        /// Gets the position (row and column) of a cell.
        /// </summary>
        /// <param name="childIndex"> One-dimensional index of the cell </param>
        /// <returns> A pair of integers (row index, column index) </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Tuple<int, int> AccessibilityGetPositionByChildIndex(int childIndex);

        /// <summary>
        /// Gets the description of a row.
        /// </summary>
        /// <param name="row"> Row number </param>
        /// <returns> The description of the row </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string AccessibilityGetRowDescription(int row);

        /// <summary>
        /// Gets the description of a column.
        /// </summary>
        /// <param name="column"> Column number </param>
        /// <returns> The description of the column </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string AccessibilityGetColumnDescription(int column);

        /// <summary>
        /// Gets the header of a row.
        /// </summary>
        /// <param name="row"> Row number </param>
        /// <returns> The row header or null </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        View AccessibilityGetRowHeader(int row);

        /// <summary>
        /// Gets the header of a column.
        /// </summary>
        /// <param name="column"> Column number </param>
        /// <returns> The column header or null </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        View AccessibilityGetColumnHeader(int column);

        /// <summary>
        /// Gets all selected rows' numbers.
        /// </summary>
        /// <returns> Selected rows' numbers </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<int> AccessibilityGetSelectedRows();

        /// <summary>
        /// Gets all selected columns' numbers.
        /// </summary>
        /// <returns> Selected columns' numbers </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<int> AccessibilityGetSelectedColumns();

        /// <summary>
        /// Checks if a row is selected.
        /// </summary>
        /// <param name="row"> Row number </param>
        /// <returns> True if the row is selected, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityIsRowSelected(int row);

        /// <summary>
        /// Checks if a column is selected.
        /// </summary>
        /// <param name="column"> Column number </param>
        /// <returns> True if the column is selected, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityIsColumnSelected(int column);

        /// <summary>
        /// Checks if a cell is selected.
        /// </summary>
        /// <param name="row"> Row number of the cell </param>
        /// <param name="column"> Column number of the cell </param>
        /// <returns> True if the cell is selected, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityIsCellSelected(int row, int column);

        /// <summary>
        /// Selects a row.
        /// </summary>
        /// <param name="row"> Row number </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityAddRowSelection(int row);

        /// <summary>
        /// Selects a column.
        /// </summary>
        /// <param name="column"> Column number </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityAddColumnSelection(int column);

        /// <summary>
        /// Unselects a row.
        /// </summary>
        /// <param name="row"> Row number </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityRemoveRowSelection(int row);

        /// <summary>
        /// Unselects a column.
        /// </summary>
        /// <param name="column"> Column number </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityRemoveColumnSelection(int column);
    }
}
