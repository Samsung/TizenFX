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
using System.ComponentModel;

namespace Tizen.NUI.Accessibility
{
    /// <summary>
    /// Interface representing a table cell.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAtspiTableCell
    {
        /// <summary>
        /// Returns the table this cell belongs to.
        /// </summary>
        /// <returns> The table </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IAtspiTable AccessibilityGetTable();

        /// <summary>
        /// Returns the position of this cell in the table.
        /// </summary>
        /// <returns> A pair of integers (row index, column index) </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Tuple<int, int> AccessibilityGetCellPosition();

        /// <summary>
        /// Returns the number of rows occupied by this cell.
        /// </summary>
        /// <returns> The number of rows </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetCellRowSpan();

        /// <summary>
        /// Returns the number of columns occupied by this cell.
        /// </summary>
        /// <returns> The number of columns </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetCellColumnSpan();
    }
}
