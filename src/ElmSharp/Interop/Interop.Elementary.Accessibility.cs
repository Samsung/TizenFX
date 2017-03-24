/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Elementary
    {
        internal enum Elm_Atspi_Relation_Type
        {
            ELM_ATSPI_RELATION_NULL,
            ELM_ATSPI_RELATION_LABEL_FOR,
            ELM_ATSPI_RELATION_LABELLED_BY,
            ELM_ATSPI_RELATION_CONTROLLER_FOR,
            ELM_ATSPI_RELATION_CONTROLLED_BY,
            ELM_ATSPI_RELATION_MEMBER_OF,
            ELM_ATSPI_RELATION_TOOLTIP_FOR,
            ELM_ATSPI_RELATION_NODE_CHILD_OF,
            ELM_ATSPI_RELATION_NODE_PARENT_OF,
            ELM_ATSPI_RELATION_EXTENDED,
            ELM_ATSPI_RELATION_FLOWS_TO,
            ELM_ATSPI_RELATION_FLOWS_FROM,
            ELM_ATSPI_RELATION_SUBWINDOW_OF,
            ELM_ATSPI_RELATION_EMBEDS,
            ELM_ATSPI_RELATION_EMBEDDED_BY,
            ELM_ATSPI_RELATION_POPUP_FOR,
            ELM_ATSPI_RELATION_PARENT_WINDOW_OF,
            ELM_ATSPI_RELATION_DESCRIPTION_FOR,
            ELM_ATSPI_RELATION_DESCRIBED_BY,
            ELM_ATSPI_RELATION_LAST_DEFINED,
        }

        internal enum Elm_Atspi_Role
        {
            ELM_ATSPI_ROLE_INVALID,
            ELM_ATSPI_ROLE_ACCELERATOR_LABEL,
            ELM_ATSPI_ROLE_ALERT,
            ELM_ATSPI_ROLE_ANIMATION,
            ELM_ATSPI_ROLE_ARROW,
            ELM_ATSPI_ROLE_CALENDAR,
            ELM_ATSPI_ROLE_CANVAS,
            ELM_ATSPI_ROLE_CHECK_BOX,
            ELM_ATSPI_ROLE_CHECK_MENU_ITEM,
            ELM_ATSPI_ROLE_COLOR_CHOOSER,
            ELM_ATSPI_ROLE_COLUMN_HEADER,
            ELM_ATSPI_ROLE_COMBO_BOX,
            ELM_ATSPI_ROLE_DATE_EDITOR,
            ELM_ATSPI_ROLE_DESKTOP_ICON,
            ELM_ATSPI_ROLE_DESKTOP_FRAME,
            ELM_ATSPI_ROLE_DIAL,
            ELM_ATSPI_ROLE_DIALOG,
            ELM_ATSPI_ROLE_DIRECTORY_PANE,
            ELM_ATSPI_ROLE_DRAWING_AREA,
            ELM_ATSPI_ROLE_FILE_CHOOSER,
            ELM_ATSPI_ROLE_FILLER,
            ELM_ATSPI_ROLE_FOCUS_TRAVERSABLE,
            ELM_ATSPI_ROLE_FONT_CHOOSER,
            ELM_ATSPI_ROLE_FRAME,
            ELM_ATSPI_ROLE_GLASS_PANE,
            ELM_ATSPI_ROLE_HTML_CONTAINER,
            ELM_ATSPI_ROLE_ICON,
            ELM_ATSPI_ROLE_IMAGE,
            ELM_ATSPI_ROLE_INTERNAL_FRAME,
            ELM_ATSPI_ROLE_LABEL,
            ELM_ATSPI_ROLE_LAYERED_PANE,
            ELM_ATSPI_ROLE_LIST,
            ELM_ATSPI_ROLE_LIST_ITEM,
            ELM_ATSPI_ROLE_MENU,
            ELM_ATSPI_ROLE_MENU_BAR,
            ELM_ATSPI_ROLE_MENU_ITEM,
            ELM_ATSPI_ROLE_OPTION_PANE,
            ELM_ATSPI_ROLE_PAGE_TAB,
            ELM_ATSPI_ROLE_PAGE_TAB_LIST,
            ELM_ATSPI_ROLE_PANEL,
            ELM_ATSPI_ROLE_PASSWORD_TEXT,
            ELM_ATSPI_ROLE_POPUP_MENU,
            ELM_ATSPI_ROLE_PROGRESS_BAR,
            ELM_ATSPI_ROLE_PUSH_BUTTON,
            ELM_ATSPI_ROLE_RADIO_BUTTON,
            ELM_ATSPI_ROLE_RADIO_MENU_ITEM,
            ELM_ATSPI_ROLE_ROOT_PANE,
            ELM_ATSPI_ROLE_ROW_HEADER,
            ELM_ATSPI_ROLE_SCROLL_BAR,
            ELM_ATSPI_ROLE_SCROLL_PANE,
            ELM_ATSPI_ROLE_SEPARATOR,
            ELM_ATSPI_ROLE_SLIDER,
            ELM_ATSPI_ROLE_SPIN_BUTTON,
            ELM_ATSPI_ROLE_SPLIT_PANE,
            ELM_ATSPI_ROLE_STATUS_BAR,
            ELM_ATSPI_ROLE_TABLE,
            ELM_ATSPI_ROLE_TABLE_CELL,
            ELM_ATSPI_ROLE_TABLE_COLUMN_HEADER,
            ELM_ATSPI_ROLE_TABLE_ROW_HEADER,
            ELM_ATSPI_ROLE_TEAROFF_MENU_ITEM,
            ELM_ATSPI_ROLE_TERMINAL,
            ELM_ATSPI_ROLE_TEXT,
            ELM_ATSPI_ROLE_TOGGLE_BUTTON,
            ELM_ATSPI_ROLE_TOOL_BAR,
            ELM_ATSPI_ROLE_TOOL_TIP,
            ELM_ATSPI_ROLE_TREE,
            ELM_ATSPI_ROLE_TREE_TABLE,
            ELM_ATSPI_ROLE_UNKNOWN,
            ELM_ATSPI_ROLE_VIEWPORT,
            ELM_ATSPI_ROLE_WINDOW,
            ELM_ATSPI_ROLE_EXTENDED,
            ELM_ATSPI_ROLE_HEADER,
            ELM_ATSPI_ROLE_FOOTER,
            ELM_ATSPI_ROLE_PARAGRAPH,
            ELM_ATSPI_ROLE_RULER,
            ELM_ATSPI_ROLE_APPLICATION,
            ELM_ATSPI_ROLE_AUTOCOMPLETE,
            ELM_ATSPI_ROLE_EDITBAR,
            ELM_ATSPI_ROLE_EMBEDDED,
            ELM_ATSPI_ROLE_ENTRY,
            ELM_ATSPI_ROLE_CHART,
            ELM_ATSPI_ROLE_CAPTION,
            ELM_ATSPI_ROLE_DOCUMENT_FRAME,
            ELM_ATSPI_ROLE_HEADING,
            ELM_ATSPI_ROLE_PAGE,
            ELM_ATSPI_ROLE_SECTION,
            ELM_ATSPI_ROLE_REDUNDANT_OBJECT,
            ELM_ATSPI_ROLE_FORM,
            ELM_ATSPI_ROLE_LINK,
            ELM_ATSPI_ROLE_INPUT_METHOD_WINDOW,
            ELM_ATSPI_ROLE_TABLE_ROW,
            ELM_ATSPI_ROLE_TREE_ITEM,
            ELM_ATSPI_ROLE_DOCUMENT_SPREADSHEET,
            ELM_ATSPI_ROLE_DOCUMENT_PRESENTATION,
            ELM_ATSPI_ROLE_DOCUMENT_TEXT,
            ELM_ATSPI_ROLE_DOCUMENT_WEB,
            ELM_ATSPI_ROLE_DOCUMENT_EMAIL,
            ELM_ATSPI_ROLE_COMMENT,
            ELM_ATSPI_ROLE_LIST_BOX,
            ELM_ATSPI_ROLE_GROUPING,
            ELM_ATSPI_ROLE_IMAGE_MAP,
            ELM_ATSPI_ROLE_NOTIFICATION,
            ELM_ATSPI_ROLE_INFO_BAR
        }

        [Flags]
        internal enum Elm_Accessible_Reading_Info_Type
        {
            ELM_ACCESSIBLE_READING_INFO_TYPE_NAME = 0x1,
            ELM_ACCESSIBLE_READING_INFO_TYPE_ROLE = 0x2,
            ELM_ACCESSIBLE_READING_INFO_TYPE_DESCRIPTION = 0x4,
            ELM_ACCESSIBLE_READING_INFO_TYPE_STATE = 0x8
        }

        internal delegate void Elm_Atspi_Say_Signal_Cb(IntPtr data, string say_signal);
        internal delegate string Elm_Atspi_Reading_Info_Cb(IntPtr data, IntPtr obj);

        [DllImport(Libraries.Elementary)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool elm_atspi_accessible_relationship_append(IntPtr obj, Elm_Atspi_Relation_Type type, IntPtr relationObj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_atspi_accessible_relationship_remove(IntPtr obj, Elm_Atspi_Relation_Type type, IntPtr relationObj);

        [DllImport(Libraries.Elementary)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool elm_atspi_accessible_relationship_append(IntPtr obj, int type, IntPtr relationObj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_atspi_accessible_relationship_remove(IntPtr obj, int type, IntPtr relationObj);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_atspi_accessible_translation_domain_get")]
        internal static extern IntPtr _elm_atspi_accessible_translation_domain_get(IntPtr obj);

        internal static string elm_atspi_accessible_translation_domain_get(IntPtr obj)
        {
            var str = _elm_atspi_accessible_translation_domain_get(obj);
            return Marshal.PtrToStringAnsi(str);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_atspi_accessible_translation_domain_set(IntPtr obj, string domain);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_atspi_accessible_name_set(IntPtr obj, string name);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_atspi_accessible_name_get")]
        internal static extern IntPtr _elm_atspi_accessible_name_get(IntPtr obj);

        internal static string elm_atspi_accessible_name_get(IntPtr obj)
        {
            var str = _elm_atspi_accessible_name_get(obj);
            return Marshal.PtrToStringAnsi(str);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_atspi_accessible_name_cb_set(IntPtr obj, Elm_Atspi_Reading_Info_Cb name_cb, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern Elm_Atspi_Role elm_atspi_accessible_role_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_atspi_accessible_role_set(IntPtr obj, Elm_Atspi_Role role);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_atspi_accessible_description_set(IntPtr obj, string description);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_atspi_accessible_description_get")]
        internal static extern IntPtr _elm_atspi_accessible_description_get(IntPtr obj);
        internal static string elm_atspi_accessible_description_get(IntPtr obj)
        {
            var str = _elm_atspi_accessible_description_get(obj);
            return Marshal.PtrToStringAnsi(str);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_atspi_accessible_description_cb_set(IntPtr obj, Elm_Atspi_Reading_Info_Cb description_cb, IntPtr data);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_atspi_accessible_reading_info_type_set(IntPtr obj, Elm_Accessible_Reading_Info_Type reading_info);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_atspi_accessible_reading_info_type_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_atspi_accessible_can_highlight_set(IntPtr obj, bool can_highlight);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_atspi_accessible_can_highlight_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_atspi_component_highlight_grab(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_atspi_component_highlight_clear(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_atspi_bridge_utils_say(string text, bool discardable, Elm_Atspi_Say_Signal_Cb func, IntPtr data);
    }
}
