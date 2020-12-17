/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using Tizen.NUI;

namespace Tizen.NUI.BaseComponents
{
    public partial class View
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum RelationType
        {
            NULL_OF = 0,
            LABEL_FOR,
            LABELLED_BY,
            CONTROLLER_FOR,
            CONTROLLED_BY,
            MEMBER_OF,
            TOOLTIP_FOR,
            NODE_CHILD_OF,
            NODE_PARENT_OF,
            EXTENDED,
            FLOWS_TO,
            FLOWS_FROM,
            SUBWINDOW_OF,
            EMBEDS,
            EMBEDDED_BY,
            POPUP_FOR,
            PARENT_WINDOW_OF,
            DESCRIPTION_FOR,
            DESCRIBED_BY,
            DETAILS,
            DETAILS_FOR,
            ERROR_MESSAGE,
            ERROR_FOR,
            MAX_COUNT
        };

        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ReadingInfoType
        {
            NAME = 0,
            ROLE,
            DESCRIPTION,
            STATE
        };

        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum AccessibilityState
        {
            INVALID = 0,
            ACTIVE,
            ARMED,
            BUSY,
            CHECKED,
            COLLAPSED,
            DEFUNCT,
            EDITABLE,
            ENABLED,
            EXPANDABLE,
            EXPANDED,
            FOCUSABLE,
            FOCUSED,
            HAS_TOOLTIP,
            HORIZONTAL,
            ICONIFIED,
            MODAL,
            MULTI_LINE,
            MULTI_SELECTABLE,
            OPAQUE,
            PRESSED,
            RESIZEABLE,
            SELECTABLE,
            SELECTED,
            SENSITIVE,
            SHOWING,
            SINGLE_LINE,
            STALE,
            TRANSIENT,
            VERTICAL,
            VISIBLE,
            MANAGES_DESCENDANTS,
            INDETERMINATE,
            REQUIRED,
            TRUNCATED,
            ANIMATED,
            INVALID_ENTRY,
            SUPPORTS_AUTOCOMPLETION,
            SELECTABLE_TEXT,
            IS_DEFAULT,
            VISITED,
            CHECKABLE,
            HAS_POPUP,
            READ_ONLY,
            HIGHLIGHTED,
            HIGHLIGHTABLE,
            MAX_COUNT,
        };

        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum AccessibilityGesture
        {
            ONE_FINGER_HOVER = 0,
            TWO_FINGER_HOVER,
            THREE_FINGER_HOVER,
            ONE_FINGER_FLICK_LEFT,
            ONE_FINGER_FLICK_RIGHT,
            ONE_FINGER_FLICK_UP,
            ONE_FINGER_FLICK_DOWN,
            TWO_FINGERS_FLICK_LEFT,
            TWO_FINGERS_FLICK_RIGHT,
            TWO_FINGERS_FLICK_UP,
            TWO_FINGERS_FLICK_DOWN,
            THREE_FINGERS_FLICK_LEFT,
            THREE_FINGERS_FLICK_RIGHT,
            THREE_FINGERS_FLICK_UP,
            THREE_FINGERS_FLICK_DOWN,
            ONE_FINGER_SINGLE_TAP,
            ONE_FINGER_DOUBLE_TAP,
            ONE_FINGER_TRIPLE_TAP,
            TWO_FINGERS_SINGLE_TAP,
            TWO_FINGERS_DOUBLE_TAP,
            TWO_FINGERS_TRIPLE_TAP,
            THREE_FINGERS_SINGLE_TAP,
            THREE_FINGERS_DOUBLE_TAP,
            THREE_FINGERS_TRIPLE_TAP,
            ONE_FINGER_FLICK_LEFT_RETURN,
            ONE_FINGER_FLICK_RIGHT_RETURN,
            ONE_FINGER_FLICK_UP_RETURN,
            ONE_FINGER_FLICK_DOWN_RETURN,
            TWO_FINGERS_FLICK_LEFT_RETURN,
            TWO_FINGERS_FLICK_RIGHT_RETURN,
            TWO_FINGERS_FLICK_UP_RETURN,
            TWO_FINGERS_FLICK_DOWN_RETURN,
            THREE_FINGERS_FLICK_LEFT_RETURN,
            THREE_FINGERS_FLICK_RIGHT_RETURN,
            THREE_FINGERS_FLICK_UP_RETURN,
            THREE_FINGERS_FLICK_DOWN_RETURN,
            ONE_FINGER_DOUBLE_TAP_N_HOLD,
            TWO_FINGERS_DOUBLE_TAP_N_HOLD,
            THREE_FINGERS_DOUBLE_TAP_N_HOLD,
            MAX_COUNT
        };

        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum GestureState
        {
            BEGIN = 0,
            ONGOING,
            ENDED,
            ABORTED
        };
    }
}
