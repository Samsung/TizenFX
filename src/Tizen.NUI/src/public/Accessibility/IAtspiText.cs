/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAtspiText
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        string AccessibilityGetText(int startOffset, int endOffset);

        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetCharacterCount();

        [EditorBrowsable(EditorBrowsableState.Never)]
        int AccessibilityGetCursorOffset();

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilitySetCursorOffset(int offset);

        [EditorBrowsable(EditorBrowsableState.Never)]
        AccessibilityRange AccessibilityGetTextAtOffset(int offset, AccessibilityTextBoundary boundary);

        [EditorBrowsable(EditorBrowsableState.Never)]
        AccessibilityRange AccessibilityGetSelection(int selectionNumber);

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilityRemoveSelection(int selectionNumber);

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool AccessibilitySetSelection(int selectionNumber, int startOffset, int endOffset);

        [EditorBrowsable(EditorBrowsableState.Never)]
        Rectangle AccessibilityGetRangeExtents(int startOffset, int endOffset, AccessibilityCoordinateType coordType);
    }
}
