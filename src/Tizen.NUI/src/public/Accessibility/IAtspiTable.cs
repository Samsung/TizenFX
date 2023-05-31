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
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAtspiTable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetRowCount();

        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetColumnCount();

        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetSelectedRowCount();

        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetSelectedColumnCount();

        [EditorBrowsable(EditorBrowsableState.Never)]
        View AccessibilityGetCaption();

        [EditorBrowsable(EditorBrowsableState.Never)]
        View AccessibilityGetSummary();

        [EditorBrowsable(EditorBrowsableState.Never)]
        IAtspiTableCell AccessibilityGetCell(int row, int column);

        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetChildIndex(int row, int column);

        [EditorBrowsable(EditorBrowsableState.Never)]
        Tuple<int, int> AccessibilityGetPositionByChildIndex(int childIndex);

        [EditorBrowsable(EditorBrowsableState.Never)]
        string AccessibilityGetRowDescription(int row);

        [EditorBrowsable(EditorBrowsableState.Never)]
        string AccessibilityGetColumnDescription(int column);

        [EditorBrowsable(EditorBrowsableState.Never)]
        View AccessibilityGetRowHeader(int row);

        [EditorBrowsable(EditorBrowsableState.Never)]
        View AccessibilityGetColumnHeader(int column);

        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<int> AccessibilityGetSelectedRows();

        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<int> AccessibilityGetSelectedColumns();

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityIsRowSelected(int row);

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityIsColumnSelected(int column);

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityIsCellSelected(int row, int column);

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityAddRowSelection(int row);

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityAddColumnSelection(int column);

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityRemoveRowSelection(int row);

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityRemoveColumnSelection(int column);
    }
}
