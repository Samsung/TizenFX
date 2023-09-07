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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Accessibility
{
    /// <summary>
    /// Interface representing objects which can store a set of selected items.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAtspiSelection
    {
        /// <summary>
        /// Gets the number of selected children.
        /// </summary>
        /// <returns> The number of selected children (zero if none) </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetSelectedChildrenCount();

        /// <summary>
        /// Gets a specific selected child.
        /// </summary>
        /// <remarks>
        /// <c>selectedChildIndex</c> refers to the list of selected children, not the list of all children.
        /// </remarks>
        /// <param name="selectedChildIndex"> The index of the selected child </param>
        /// <returns> The selected child or nullptr if index is invalid </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        View AccessibilityGetSelectedChild(int selectedChildIndex);

        /// <summary>
        /// Selects a child.
        /// </summary>
        /// <param name="childIndex"> The index of the child </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilitySelectChild(int childIndex);

        /// <summary>
        /// Deselects a selected child.
        /// </summary>
        /// <param name="selectedChildIndex"> The index of the selected child </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityDeselectSelectedChild(int selectedChildIndex);

        /// <summary>
        /// Checks whether a child is selected.
        /// </summary>
        /// <param name="childIndex"> The index of the child </param>
        /// <returns>< True if given child is selected, false otherwise /returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityIsChildSelected(int childIndex);

        /// <summary>
        /// Selects all children.
        /// </summary>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilitySelectAll();

        /// <summary>
        /// Deselects all children.
        /// </summary>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityClearSelection();

        /// <summary>
        /// Deselects a child.
        /// </summary>
        /// <param name="childIndex"> The index of the child. </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityDeselectChild(int childIndex);
    }
}
