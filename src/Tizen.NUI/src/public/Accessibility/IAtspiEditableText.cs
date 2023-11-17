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
    /// Interface representing objects which can store editable texts.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAtspiEditableText : IAtspiText
    {
        /// <summary>
        /// Copies text in range to system clipboard.
        /// </summary>
        /// <param name="startPosition"> The index of first character </param>
        /// <param name="endPosition"> The index of first character after the last one expected </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityCopyText(int startPosition, int endPosition);

        /// <summary>
        /// Cuts text in range to system clipboard.
        /// </summary>
        /// <param name="startPosition"> The index of first character </param>
        /// <param name="endPosition"> The index of first character after the last one expected </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityCutText(int startPosition, int endPosition);

        /// <summary>
        /// Inserts text at startPosition.
        /// </summary>
        /// <param name="startPosition"> The index of first character </param>
        /// <param name="text"> The text content </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityInsertText(int startPosition, string text);

        /// <summary>
        /// Replaces text with content.
        /// </summary>
        /// <param name="newContents"> The text content </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilitySetTextContents(string newContents);

        /// <summary>
        /// Deletes text in range.
        /// </summary>
        /// <param name="startPosition"> The index of first character </param>
        /// <param name="endPosition"> The index of first character after the last one expected </param>
        /// <returns> True on success, false otherwise </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityDeleteText(int startPosition, int endPosition);
    }
}
