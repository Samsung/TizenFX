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
    /// Interface representing objects which can store immutable texts.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAtspiText
    {
        /// <summary>
        /// Gets stored text in given range.
        /// </summary>
        /// <param name="startOffset"> The index of first character </param>
        /// <param name="endOffset"> The index of first character after the last one expected </param>
        /// <returns> The substring of stored text </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string AccessibilityGetText(int startOffset, int endOffset);

        /// <summary>
        /// Gets number of all stored characters.
        /// </summary>
        /// <returns> The number of characters </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetCharacterCount();

        /// <summary>
        /// Gets the cursor offset.
        /// </summary>
        /// <returns> Value of cursor offset </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetCursorOffset();

        /// <summary>
        /// Sets the cursor offset.
        /// </summary>
        /// <param name="offset"> Cursor offset </param>
        /// <returns> True if successful </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilitySetCursorOffset(int offset);

        /// <summary>
        /// Gets substring of stored text truncated in concrete gradation.
        /// </summary>
        /// <param name="offset"> The position in stored text </param>
        /// <param name="boundary"> The enumeration describing text gradation </param>
        /// <returns> Range structure containing acquired text and offsets in original string </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        AccessibilityRange AccessibilityGetTextAtOffset(int offset, AccessibilityTextBoundary boundary);

        /// <summary>
        /// Gets selected text.
        /// </summary>
        /// <remarks>
        ///  Currently only one selection (i.e. with index = 0) is supported
        /// </remarks>
        /// <param name="selectionNumber"> The selection index </param>
        /// <returns> Range structure containing acquired text and offsets in original string </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        AccessibilityRange AccessibilityGetSelection(int selectionNumber);

        /// <summary>
        /// Removes the whole selection.
        /// </summary>
        /// <remarks>
        ///  Currently only one selection (i.e. with index = 0) is supported
        /// </remarks>
        /// <param name="selectionNumber"> The selection index </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityRemoveSelection(int selectionNumber);

        /// <summary>
        /// Sets selected text.
        /// </summary>
        /// <remarks>
        ///  Currently only one selection (i.e. with index = 0) is supported
        /// </remarks>
        /// <param name="selectionNumber"> The selection index </param>
        /// <param name="startOffset"> The index of first character </param>
        /// <param name="endOffset"> The index of first character after the last one expected </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilitySetSelection(int selectionNumber, int startOffset, int endOffset);

        /// <summary>
        /// Gets the bounding box for text within a range in text.
        /// </summary>
        /// <param name="startOffset"> The index of first character </param>
        /// <param name="endOffset"> The index of first character after the last one expected </param>
        /// <param name="coordType"> The enumeration with type of coordinate system </param>
        /// <returns> Rectangle giving the position and size of the specified range of text </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Rectangle AccessibilityGetRangeExtents(int startOffset, int endOffset, AccessibilityCoordinateType coordType);
    }
}
