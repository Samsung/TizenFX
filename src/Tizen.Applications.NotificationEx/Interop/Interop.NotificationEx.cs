/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen;
using System;
using System.Runtime.InteropServices;
using Tizen.Applications.NotificationEx;

internal static partial class Interop
{
    internal static partial class NotificationEx
    {

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_button_create")]
        internal static extern ErrorCode ButtonCreate(out IntPtr handle, string id, string title);
        //int noti_ex_item_button_create(noti_ex_item_h* handle, const char* id, const char* title);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_button_get_title")]
        internal static extern ErrorCode ButtonGetTitle(IntPtr handle, out string title);
        //int noti_ex_item_button_get_title(noti_ex_item_h handle, char **title);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_button_set_multi_language_title")]
        internal static extern ErrorCode ButtonSetMultiLanguageTitle(IntPtr handle, IntPtr multi);
        //int noti_ex_item_button_set_multi_language_title(noti_ex_item_h handle, noti_ex_multi_lang_h multi);



        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_action_app_control_create")]
        internal static extern ErrorCode ActionAppControlCreate(out IntPtr handle, IntPtr appControl, string extra);
        //int noti_ex_action_app_control_create(noti_ex_action_h *handle, app_control_h app_control, const char *extra);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_action_app_control_set")]
        internal static extern ErrorCode ActionAppControlSet(IntPtr handle, IntPtr appControl);
        //int noti_ex_action_app_control_set(noti_ex_action_h handle, app_control_h app_control);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_action_app_control_get")]
        internal static extern ErrorCode ActionAppControlGet(IntPtr handle, out IntPtr appControl);
        //int noti_ex_action_app_control_get(noti_ex_action_h handle, app_control_h* app_control);

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_time_create")]
        internal static extern ErrorCode TimeCreate(out IntPtr handle, string id, Int32 time);
        //int noti_ex_item_time_create(noti_ex_item_h *handle, const char *id, time_t time);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_time_get_time")]
        internal static extern ErrorCode TimeGetTime(IntPtr handle, out Int32 time);
        //int noti_ex_item_time_get_time(noti_ex_item_h handle, time_t *time);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_time_set_time")]
        internal static extern ErrorCode TimeSetTime(IntPtr handle, Int32 time);
        //int noti_ex_item_time_set_time(noti_ex_item_h handle, time_t time);


        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_text_create")]
        internal static extern ErrorCode TextCreate(out IntPtr handle, string id, string text, string hyperlink);
        //int noti_ex_item_text_create(noti_ex_item_h* handle, const char* id, const char* text, const char* hyperlink);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_text_set_contents")]
        internal static extern ErrorCode TextSetContents(IntPtr handle, string contents);
        //int noti_ex_item_text_set_contents(noti_ex_item_h handle, const char* contents);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_text_get_contents")]
        internal static extern ErrorCode TextGetContents(IntPtr handle, out string contents);
        //int noti_ex_item_text_get_contents(noti_ex_item_h handle, char** contents);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_text_get_hyperlink")]
        internal static extern ErrorCode TextGetHyperlink(IntPtr handle, out string hyperlink);
        //int noti_ex_item_text_get_hyperlink(noti_ex_item_h handle, char** hyperlink);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_text_set_multi_language")]
        internal static extern ErrorCode TextSetMultiLanguage(IntPtr handle, IntPtr multi);
        //int noti_ex_item_text_set_multi_language(noti_ex_item_h handle, noti_ex_multi_lang_h multi);
        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////


        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_chat_message_create")]
        internal static extern ErrorCode ChatMessageCreate(out IntPtr handle, string id, IntPtr itemName, IntPtr itemText, IntPtr itemImage, IntPtr itemTime, ChatMessageType type);
        //int noti_ex_item_chat_message_create(noti_ex_item_h* handle, const char* id, noti_ex_item_h name, noti_ex_item_h text, noti_ex_item_h image, noti_ex_item_h time, noti_ex_item_chat_message_type_e message_type);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_chat_message_get_name")]
        internal static extern ErrorCode ChatMessageGetName(IntPtr handle, out IntPtr name);
        //int noti_ex_item_chat_message_get_name(noti_ex_item_h handle, noti_ex_item_h* name);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_chat_message_get_text")]
        internal static extern ErrorCode ChatMessageGetText(IntPtr handle, out IntPtr text);
        //int noti_ex_item_chat_message_get_text(noti_ex_item_h handle, noti_ex_item_h* text);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_chat_message_get_image")]
        internal static extern ErrorCode ChatMessageGetImage(IntPtr handle, out IntPtr image);
        //int noti_ex_item_chat_message_get_image(noti_ex_item_h handle, noti_ex_item_h* image);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_chat_message_get_time")]
        internal static extern ErrorCode ChatMessageGetTime(IntPtr handle, out IntPtr time);
        //int noti_ex_item_chat_message_get_time(noti_ex_item_h handle, noti_ex_item_h* time);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_chat_message_get_message_type")]
        internal static extern ErrorCode ChatMessageGetMessageType(IntPtr handle, out ChatMessageType type);
        //int noti_ex_item_chat_message_get_message_type(noti_ex_item_h handle, noti_ex_item_chat_message_type_e* message_type);


        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////


        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_checkbox_create")]
        internal static extern ErrorCode CheckboxCreate(out IntPtr handle, string id, string title, bool is_checked);
        //int noti_ex_item_checkbox_create(noti_ex_item_h* handle, const char* id, const char* title, bool checked);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_checkbox_get_title")]
        internal static extern ErrorCode CheckboxGetTitle(IntPtr handle, out string title);
        //int noti_ex_item_checkbox_get_title(noti_ex_item_h handle, char** title);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_checkbox_set_multi_language_title")]
        internal static extern ErrorCode CheckboxSetMultiLanguage(IntPtr handle, IntPtr multi);
        //int noti_ex_item_checkbox_set_multi_language_title(noti_ex_item_h handle, noti_ex_multi_lang_h multi);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_checkbox_get_check_state")]
        internal static extern ErrorCode CheckboxGetCheckedState(IntPtr handle, out bool is_checked);
        //int noti_ex_item_checkbox_get_check_state(noti_ex_item_h handle, bool*checked);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_checkbox_set_check_state")]
        internal static extern ErrorCode CheckboxSetCheckedState(IntPtr handle, bool is_checked);
        //int noti_ex_item_checkbox_set_check_state(noti_ex_item_h handle, bool checked);


        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_entry_create")]
        internal static extern ErrorCode EntryCreate(out IntPtr handle, string id);
        //int noti_ex_item_entry_create(noti_ex_item_h* handle, const char* id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_entry_get_text")]
        internal static extern ErrorCode EntryGetText(IntPtr handle, out string text);
        //int noti_ex_item_entry_get_text(noti_ex_item_h handle, char** text);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_entry_set_text")]
        internal static extern ErrorCode EntrySetText(IntPtr handle, string text);
        //int noti_ex_item_entry_set_text(noti_ex_item_h handle, const char* text);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_entry_set_multi_language")]
        internal static extern ErrorCode EntrySetMultiLanguage(IntPtr handle, IntPtr multi);
        //int noti_ex_item_entry_set_multi_language(noti_ex_item_h handle, noti_ex_multi_lang_h multi);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_progress_create")]
        internal static extern ErrorCode ProgressCreate(out IntPtr handle, string id, float min, float current, float max);
        //int noti_ex_item_progress_create(noti_ex_item_h* handle, const char* id, float min, float current, float max);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_progress_get_current")]
        internal static extern ErrorCode ProgressGetCurrent(IntPtr handle, out float current);
        //int noti_ex_item_progress_get_current(noti_ex_item_h handle, float* current);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_progress_set_current")]
        internal static extern ErrorCode ProgressSetCurrent(IntPtr handle, float current);
        //int noti_ex_item_progress_set_current(noti_ex_item_h handle, float current);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_progress_get_min")]
        internal static extern ErrorCode ProgressGetMin(IntPtr handle, out float min);
        //int noti_ex_item_progress_get_min(noti_ex_item_h handle, float* min);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_progress_get_max")]
        internal static extern ErrorCode ProgressGetMax(IntPtr handle, out float max);
        //int noti_ex_item_progress_get_max(noti_ex_item_h handle, float* max);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_progress_get_type")]
        internal static extern ErrorCode ProgressGetType(IntPtr handle, out int type);
        //int noti_ex_item_progress_get_type(noti_ex_item_h handle, int* type);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_progress_set_type")]
        internal static extern ErrorCode ProgressSetType(IntPtr handle, int type);
        //int noti_ex_item_progress_set_type(noti_ex_item_h handle, int type);



        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////


        internal enum NativeEventInfoType
        {
            Post,
            Update,
            Delete,
            Get,
            Error,
            DeleteAll,
        }

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_event_info_clone")]
        internal static extern ErrorCode EventInfoClone(IntPtr handle, out IntPtr cloned_handle);
        //int noti_ex_event_info_clone(noti_ex_event_info_h handle, noti_ex_event_info_h* cloned_handle);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_event_info_destroy")]
        internal static extern ErrorCode EventInfoDestroy(IntPtr handle);
        //int noti_ex_event_info_destroy(noti_ex_event_info_h handle);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_event_info_get_event_type")]
        internal static extern ErrorCode EventInfoGetEventType(IntPtr handle, out int event_type);
        //int noti_ex_event_info_get_event_type(noti_ex_event_info_h handle, noti_ex_event_info_type_e* event_type);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_event_info_get_owner")]
        internal static extern ErrorCode EventInfoGetOwner(IntPtr handle, out string owner);
        //int noti_ex_event_info_get_owner(noti_ex_event_info_h handle, char** owner);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_event_info_get_channel")]
        internal static extern ErrorCode EventInfoGetChannel(IntPtr handle, out string channel);
        //int noti_ex_event_info_get_channel(noti_ex_event_info_h handle, char** channel);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_event_info_get_item_id")]
        internal static extern ErrorCode EventInfoGetItemId(IntPtr handle, out string item_id);
        //int noti_ex_event_info_get_item_id(noti_ex_event_info_h handle, char** item_id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_event_info_get_request_id")]
        internal static extern ErrorCode EventInfoGetRequestId(IntPtr handle, out int req_id);
        //int noti_ex_event_info_get_request_id(noti_ex_event_info_h handle, int* req_id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_group_create")]
        internal static extern ErrorCode GroupCreate(out IntPtr handle, string id);
        //int noti_ex_item_group_create(noti_ex_item_h* handle, const char* id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_group_set_direction")]
        internal static extern ErrorCode GroupSetDirection(IntPtr handle, bool vertical);
        //int noti_ex_item_group_set_direction(noti_ex_item_h handle, bool vertical);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_group_is_vertical")]
        internal static extern ErrorCode GroupIsVertical(IntPtr handle, out bool vertical);
        //int noti_ex_item_group_is_vertical(noti_ex_item_h handle, bool* vertical);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_group_get_app_label")]
        internal static extern ErrorCode GroupGetAppLabel(IntPtr handle, out string label);
        //int noti_ex_item_group_get_app_label(noti_ex_item_h handle, char** label);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_group_add_child")]
        internal static extern ErrorCode GroupAddChild(IntPtr handle, IntPtr child);
        //int noti_ex_item_group_add_child(noti_ex_item_h handle, noti_ex_item_h child);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_group_remove_child")]
        internal static extern ErrorCode GroupRemoveChild(IntPtr handle, string item_id);
        //int noti_ex_item_group_remove_child(noti_ex_item_h handle, const char* item_id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_group_remove_child")]
        internal static extern ErrorCode GroupRemoveChildren(IntPtr handle);
        //int noti_ex_item_group_remove_child(noti_ex_item_h handle, const char* item_id);

        internal delegate int GroupForeachChildCallback(IntPtr handle, IntPtr userData);
        //typedef int (*noti_ex_item_group_foreach_child_cb)(noti_ex_item_h handle, void *user_data);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_group_foreach_child")]
        internal static extern ErrorCode GroupForeachChild(IntPtr handle, GroupForeachChildCallback callback, IntPtr user_data);
        //int noti_ex_item_group_foreach_child(noti_ex_item_h handle, noti_ex_item_group_foreach_child_cb callback, void* user_data);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_image_create")]
        internal static extern ErrorCode ImageCreate(out IntPtr handle, string id, string image_path);
        //int noti_ex_item_image_create(noti_ex_item_h* handle, const char* id, const char* image_path);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_image_get_image_path")]
        internal static extern ErrorCode ImageGetImagePath(IntPtr handle, out string image_path);
        //int noti_ex_item_image_get_image_path(noti_ex_item_h handle, char** image_path);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_input_selector_create")]
        internal static extern ErrorCode InputSelectorCreate(out IntPtr handle, string id);
        //int noti_ex_item_input_selector_create(noti_ex_item_h* handle, const char* id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_input_selector_get_contents")]
        internal static extern ErrorCode InputSelectorGetContents(IntPtr handle, out IntPtr list, out int count);
        //int noti_ex_item_input_selector_get_contents(noti_ex_item_h handle, char*** list, int* count);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_input_selector_set_contents")]
        internal static extern ErrorCode InputSelectorSetContents(IntPtr handle, string[] contents, int count);
        //int noti_ex_item_input_selector_set_contents(noti_ex_item_h handle, const char** contents, int count);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_input_selector_set_multi_language_contents")]
        internal static extern ErrorCode InputSelectorSetMultiLanguageContents(IntPtr handle, IntPtr multi_language_list, int count);
        //int noti_ex_item_input_selector_set_multi_language_contents(noti_ex_item_h handle, noti_ex_multi_lang_h* multi_language_list, int count);

        internal enum NativeItemType
        {
            Null,
            Text,
            Image,
            Icon,
            Butoon,
            ChatMessage,
            CheckBox,
            IconText,
            InputSelector,
            Group,
            Entry,
            Progress,
            Time,
            Custom = 100
        }

        internal enum NativeActionType
        {
            Null,
            AppControl,
            Visibility,
            Custom = 100
        }

        internal enum NativePolicy
        {
            None,
            OnBootClear,
            SimMode
        }

        internal enum NativeMainType
        {
            None,
            Title,
            Contents,
            Icon,
            Button
        }

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_color_create")]
        internal static extern ErrorCode ColorCreate(out IntPtr handle, byte a, byte r, byte g, byte b);
        //int noti_ex_color_create(noti_ex_color_h* handle, unsigned char a, unsigned char r, unsigned char g, unsigned char b);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_color_destroy")]
        internal static extern ErrorCode ColorDestroy(IntPtr handle);
        //int noti_ex_color_destroy(noti_ex_color_h handle);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_color_get_alpha")]
        internal static extern ErrorCode ColorGetAlpha(IntPtr handle, out byte val);
        //int noti_ex_color_get_alpha(noti_ex_color_h handle, unsigned char* val);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_color_get_alpha")]
        internal static extern ErrorCode ColorGetRed(IntPtr handle, out byte val);
        //int noti_ex_color_get_red(noti_ex_color_h handle, unsigned char* val);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_color_get_green")]
        internal static extern ErrorCode ColorGetGreen(IntPtr handle, out byte val);
        //int noti_ex_color_get_green(noti_ex_color_h handle, unsigned char* val);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_color_get_blue")]
        internal static extern ErrorCode ColorGetBlue(IntPtr handle, out byte val);
        //int noti_ex_color_get_blue(noti_ex_color_h handle, unsigned char* val);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_padding_create")]
        internal static extern ErrorCode PaddingCreate(out IntPtr handle, int left, int top, int right, int bottom);
        //int noti_ex_padding_create(noti_ex_padding_h* handle, int left, int top, int right, int bottom);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_padding_create")]
        internal static extern ErrorCode PaddingDestroy(IntPtr handle);
        //int noti_ex_padding_destroy(noti_ex_padding_h handle);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_padding_get_left")]
        internal static extern ErrorCode PaddingGetLeft(IntPtr handle, out int left);
        //int noti_ex_padding_get_left(noti_ex_padding_h handle, int* val);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_padding_get_top")]
        internal static extern ErrorCode PaddingGetTop(IntPtr handle, out int left);
        //int noti_ex_padding_get_top(noti_ex_padding_h handle, int* val);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_padding_get_right")]
        internal static extern ErrorCode PaddingGetRight(IntPtr handle, out int left);
        //int noti_ex_padding_get_right(noti_ex_padding_h handle, int* val);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_padding_get_bottom")]
        internal static extern ErrorCode PaddingGetBottom(IntPtr handle, out int bottom);
        //int noti_ex_padding_get_bottom(noti_ex_padding_h handle, int* val);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_geometry_create")]
        internal static extern ErrorCode GeometryCreate(out IntPtr handle, int x, int y, int w, int h);
        //int noti_ex_geometry_create(noti_ex_geometry_h* handle, int x, int y, int w, int h);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_geometry_destroy")]
        internal static extern ErrorCode GeometryDestroy(IntPtr handle);
        //int noti_ex_geometry_destroy(noti_ex_geometry_h handle);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_geometry_get_x")]
        internal static extern ErrorCode GeometryGetX(IntPtr handle, out int val);
        //int noti_ex_geometry_get_x(noti_ex_geometry_h handle, int* val);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_geometry_get_y")]
        internal static extern ErrorCode GeometryGetY(IntPtr handle, out int val);
        //int noti_ex_geometry_get_y(noti_ex_geometry_h handle, int* val);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_geometry_get_width")]
        internal static extern ErrorCode GeometryGetWidth(IntPtr handle, out int val);
        //int noti_ex_geometry_get_width(noti_ex_geometry_h handle, int* val);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_geometry_get_height")]
        internal static extern ErrorCode GeometryGetHeight(IntPtr handle, out int val);
        //int noti_ex_geometry_get_height(noti_ex_geometry_h handle, int* val);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_style_create")]
        internal static extern ErrorCode StyleCreate(out IntPtr handle, IntPtr color, IntPtr padding, IntPtr geometry);
        //int noti_ex_style_create(noti_ex_style_h* handle, noti_ex_color_h color, noti_ex_padding_h padding, noti_ex_geometry_h geometry);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_style_create")]
        internal static extern ErrorCode StyleDestroy(IntPtr handle);
        //int noti_ex_style_destroy(noti_ex_style_h handle);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_style_get_padding")]
        internal static extern ErrorCode StyleGetPadding(IntPtr handle, out IntPtr padding);
        //int noti_ex_style_get_padding(noti_ex_style_h handle, noti_ex_padding_h* padding);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_style_set_geometry")]
        internal static extern ErrorCode StyleSetPadding(IntPtr handle, IntPtr padding);
        //int noti_ex_style_set_padding(noti_ex_style_h handle, noti_ex_padding_h padding);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_style_get_color")]
        internal static extern ErrorCode StyleGetColor(IntPtr handle, out IntPtr color);
        //int noti_ex_style_get_color(noti_ex_style_h handle, noti_ex_color_h* color);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_style_set_color")]
        internal static extern ErrorCode StyleSetColor(IntPtr handle, IntPtr color);
        //int noti_ex_style_set_color(noti_ex_style_h handle, noti_ex_color_h color);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_style_get_geometry")]
        internal static extern ErrorCode StyleGetGeometry(IntPtr handle, out IntPtr geometry);
        //int noti_ex_style_get_geometry(noti_ex_style_h handle, noti_ex_geometry_h* geometry);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_style_set_geometry")]
        internal static extern ErrorCode StyleSetGeometry(IntPtr handle, IntPtr geometry);
        //int noti_ex_style_set_geometry(noti_ex_style_h handle, noti_ex_geometry_h geometry);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_style_get_background_image")]
        internal static extern ErrorCode StyleGetBackgroundImage(IntPtr handle, out string image_path);
        //int noti_ex_style_get_background_image(noti_ex_style_h handle, char** image_path);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_style_set_background_image")]
        internal static extern ErrorCode StyleSetBackgroundImage(IntPtr handle, string image_path);
        //int noti_ex_style_set_background_image(noti_ex_style_h handle, char* image_path);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_style_get_background_color")]
        internal static extern ErrorCode StyleGetBackgroundColor(IntPtr handle, out IntPtr color);
        //int noti_ex_style_get_background_color(noti_ex_style_h handle, noti_ex_color_h* color);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_style_set_background_color")]
        internal static extern ErrorCode StyleSetBackgroundColor(IntPtr handle, IntPtr color);
        //int noti_ex_style_set_background_color(noti_ex_style_h handle, noti_ex_color_h color);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_led_info_create")]
        internal static extern ErrorCode LEDInfoCreate(out IntPtr handle, IntPtr color);
        //int noti_ex_led_info_create(noti_ex_led_info_h* handle, noti_ex_color_h color);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_led_info_destroy")]
        internal static extern ErrorCode LEDInfoDestroy(IntPtr handle);
        //int noti_ex_led_info_destroy(noti_ex_led_info_h handle);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_led_info_set_on_period")]
        internal static extern ErrorCode LEDInfoSetOnPeriod(IntPtr handle, int ms);
        //int noti_ex_led_info_set_on_period(noti_ex_led_info_h handle, int ms);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_led_info_get_on_period")]
        internal static extern ErrorCode LEDInfoGetOnPeriod(IntPtr handle, out int ms);
        //int noti_ex_led_info_get_on_period(noti_ex_led_info_h handle, int* ms);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_led_info_set_off_period")]
        internal static extern ErrorCode LEDInfoSetOffPeriod(IntPtr handle, int ms);
        //int noti_ex_led_info_set_off_period(noti_ex_led_info_h handle, int ms);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_led_info_get_off_period")]
        internal static extern ErrorCode LEDInfoGetOffPeriod(IntPtr handle, out int ms);
        //int noti_ex_led_info_get_off_period(noti_ex_led_info_h handle, int* ms);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_led_info_get_color")]
        internal static extern ErrorCode LEDInfoGetColor(IntPtr handle, out IntPtr color);
        //int noti_ex_led_info_get_color(noti_ex_led_info_h handle, noti_ex_color_h* color);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_led_info_set_color")]
        internal static extern ErrorCode LEDInfoSetColor(IntPtr handle, IntPtr color);
        //int noti_ex_led_info_set_color(noti_ex_led_info_h handle, noti_ex_color_h color);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_action_destroy")]
        internal static extern ErrorCode ActionDestroy(IntPtr handle);
        //int noti_ex_action_destroy(noti_ex_action_h handle);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_action_get_type")]
        internal static extern ErrorCode ActionGetType(IntPtr handle, out int type);
        //int noti_ex_action_get_type(noti_ex_action_h handle, int* type);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_action_is_local")]
        internal static extern ErrorCode ActionIsLocal(IntPtr handle, out bool is_local);
        //int noti_ex_action_is_local(noti_ex_action_h handle, bool* local);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_action_execute")]
        internal static extern ErrorCode ActionExecute(IntPtr handle, IntPtr item);
        //int noti_ex_action_execute(noti_ex_action_h handle, noti_ex_item_h item);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_action_get_extra")]
        internal static extern ErrorCode ActionGetExtra(IntPtr handle, out string extra);
        //int noti_ex_action_get_extra(noti_ex_action_h handle, char** extra);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_info_get_hide_time")]
        internal static extern ErrorCode InfoGetHideTime(IntPtr handle, out int hide_time);
        //int noti_ex_item_info_get_hide_time(noti_ex_item_info_h handle, int* hide_time);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_info_set_hide_time")]
        internal static extern ErrorCode InfoSetHideTime(IntPtr handle, int hide_time);
        //int noti_ex_item_info_set_hide_time(noti_ex_item_info_h handle, int hide_time);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_info_get_delete_time")]
        internal static extern ErrorCode InfoGetDeleteTime(IntPtr handle, out int delete_time);
        //int noti_ex_item_info_get_delete_time(noti_ex_item_info_h handle, int* delete_time);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_info_set_delete_time")]
        internal static extern ErrorCode InfoSetDeleteTime(IntPtr handle, int delete_time);
        //int noti_ex_item_info_set_delete_time(noti_ex_item_info_h handle, int delete_time);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_info_get_time")]
        internal static extern ErrorCode InfoGetTime(IntPtr handle, out int time);
        //int noti_ex_item_info_get_time(noti_ex_item_info_h handle, time_t* time);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_destroy")]
        internal static extern ErrorCode ItemDestroy(IntPtr handle);
        //int noti_ex_item_destroy(noti_ex_item_h handle);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_find_by_id")]
        internal static extern ErrorCode ItemFindById(IntPtr handle, string id, out IntPtr item);
        //int noti_ex_item_find_by_id(noti_ex_item_h handle, const char* id, noti_ex_item_h *item);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_type")]
        internal static extern ErrorCode ItemGetType(IntPtr handle, out int type);
        //int noti_ex_item_get_type(noti_ex_item_h handle, int* type);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_shared_paths")]
        internal static extern ErrorCode ItemGetSharedPaths(IntPtr handle, out IntPtr paths, out int count);
        //int noti_ex_item_get_shared_paths(noti_ex_item_h handle, char*** paths, int* count);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_id")]
        internal static extern ErrorCode ItemGetId(IntPtr handle, out string id);
        //int noti_ex_item_get_id(noti_ex_item_h handle, char** id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_id")]
        internal static extern ErrorCode ItemSetId(IntPtr handle, string id);
        //int noti_ex_item_set_id(noti_ex_item_h handle, const char* id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_action")]
        internal static extern ErrorCode ItemGetAction(IntPtr handle, out IntPtr action);
        //int noti_ex_item_get_action(noti_ex_item_h handle, noti_ex_action_h* action);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_action")]
        internal static extern ErrorCode ItemSetAction(IntPtr handle, IntPtr action);
        //int noti_ex_item_set_action(noti_ex_item_h handle, noti_ex_action_h action);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_style")]
        internal static extern ErrorCode ItemGetStyle(IntPtr handle, out IntPtr style);
        //int noti_ex_item_get_style(noti_ex_item_h handle, noti_ex_style_h* style);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_style")]
        internal static extern ErrorCode ItemSetStyle(IntPtr handle, IntPtr style);
        //int noti_ex_item_set_style(noti_ex_item_h handle, noti_ex_style_h style);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_visible")]
        internal static extern ErrorCode ItemSetVisible(IntPtr handle, bool visible);
        //int noti_ex_item_set_visible(noti_ex_item_h handle, bool visible);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_visible")]
        internal static extern ErrorCode ItemGetVisible(IntPtr handle, out bool visible);
        //int noti_ex_item_get_visible(noti_ex_item_h handle, bool* visible);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_enable")]
        internal static extern ErrorCode ItemSetEnable(IntPtr handle, bool visible);
        //int noti_ex_item_set_enable(noti_ex_item_h handle, bool enable);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_enable")]
        internal static extern ErrorCode ItemGetEnable(IntPtr handle, out bool visible);
        //int noti_ex_item_get_enable(noti_ex_item_h handle, bool* enable);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_add_receiver")]
        internal static extern ErrorCode ItemAddReceiver(IntPtr handle, string receiver_group);
        //int noti_ex_item_add_receiver(noti_ex_item_h handle, const char* receiver_group);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_remove_receiver")]
        internal static extern ErrorCode ItemRemoveReceiver(IntPtr handle, string receiver_group);
        //int noti_ex_item_remove_receiver(noti_ex_item_h handle, const char* receiver_group);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_receiver_list")]
        internal static extern ErrorCode ItemGetReceiverList(IntPtr handle, out IntPtr list, out int count);
        //int noti_ex_item_get_receiver_list(noti_ex_item_h handle, char*** list, int* count);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_free_string_list")]
        internal static extern ErrorCode ItemFreeStringList(IntPtr list, int count);
        //int noti_ex_item_free_string_list(char** list, int count);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_policy")]
        internal static extern ErrorCode ItemSetPolicy(IntPtr handle, int policy);
        //int noti_ex_item_set_policy(noti_ex_item_h handle, int policy);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_policy")]
        internal static extern ErrorCode ItemGetPolicy(IntPtr handle, out int policy);
        //int noti_ex_item_get_policy(noti_ex_item_h handle, int* policy);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_channel")]
        internal static extern ErrorCode ItemGetChannel(IntPtr handle, out string channel);
        //int noti_ex_item_get_channel(noti_ex_item_h handle, char** channel);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_channel")]
        internal static extern ErrorCode ItemSetChannel(IntPtr handle, string channel);
        //int noti_ex_item_set_channel(noti_ex_item_h handle, const char* channel);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_led_info")]
        internal static extern ErrorCode ItemSetLedInfo(IntPtr handle, IntPtr led);
        //int noti_ex_item_set_led_info(noti_ex_item_h handle, noti_ex_led_info_h led);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_led_info")]
        internal static extern ErrorCode ItemGetLedInfo(IntPtr handle, out IntPtr led);
        //int noti_ex_item_get_led_info(noti_ex_item_h handle, noti_ex_led_info_h* led);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_sound_path")]
        internal static extern ErrorCode ItemSetSoundPath(IntPtr handle, string path);
        //int noti_ex_item_set_sound_path(noti_ex_item_h handle, const char* path);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_sound_path")]
        internal static extern ErrorCode ItemGetSoundPath(IntPtr handle, out string path);
        //int noti_ex_item_get_sound_path(noti_ex_item_h handle, char** path);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_vibration_path")]
        internal static extern ErrorCode ItemSetVibrationPath(IntPtr handle, string path);
        //int noti_ex_item_set_vibration_path(noti_ex_item_h handle, const char* path);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_vibration_path")]
        internal static extern ErrorCode ItemGetVibrationPath(IntPtr handle, out string path);
        //int noti_ex_item_get_vibration_path(noti_ex_item_h handle, char** path);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_info")]
        internal static extern ErrorCode ItemGetInfo(IntPtr handle, out IntPtr info);
        //int noti_ex_item_get_info(noti_ex_item_h handle, noti_ex_item_info_h* info);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_sender_app_id")]
        internal static extern ErrorCode ItemGetSenderAppId(IntPtr handle, out string id);
        //int noti_ex_item_get_sender_app_id(noti_ex_item_h handle, char** id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_tag")]
        internal static extern ErrorCode ItemGetTag(IntPtr handle, out string tag);
        //int noti_ex_item_get_tag(noti_ex_item_h handle, char** tag);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_tag")]
        internal static extern ErrorCode ItemSetTag(IntPtr handle, string tag);
        //int noti_ex_item_set_tag(noti_ex_item_h handle, const char* tag);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_ongoing_state")]
        internal static extern ErrorCode ItemGetOngoingState(IntPtr handle, out bool ongoing);
        //int noti_ex_item_get_ongoing_state(noti_ex_item_h handle, bool* ongoing);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_ongoing_state")]
        internal static extern ErrorCode ItemSetOngoingState(IntPtr handle, bool ongoing);
        //int noti_ex_item_set_ongoing_state(noti_ex_item_h handle, bool ongoing);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_check_type_exist")]
        internal static extern ErrorCode ItemCheckTypeExist(IntPtr handle, out bool exist);
        //int noti_ex_item_check_type_exist(noti_ex_item_h handle, int type, bool* exist);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_get_main_type")]
        internal static extern ErrorCode ItemGetMainType(IntPtr handle, out int type);
        //int noti_ex_item_get_main_type(noti_ex_item_h handle, int* type);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_main_type")]
        internal static extern ErrorCode ItemSetMainType(IntPtr handle, string id, int type);
        //int noti_ex_item_set_main_type(noti_ex_item_h handle, const char* id, int type);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_item_set_main_type")]
        internal static extern ErrorCode ItemFindByMainType(IntPtr handle, int type, out IntPtr item);
        //int noti_ex_item_find_by_main_type(noti_ex_item_h handle, int type, noti_ex_item_h* item);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_action_visibility_create")]
        internal static extern ErrorCode ActionVisibilityCreate(out IntPtr handle, string extra);
        //int noti_ex_action_visibility_create(noti_ex_action_h* handle, const char* extra);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_action_visibility_set")]
        internal static extern ErrorCode ActionVisibilitySet(IntPtr handle, string id, bool visible);
        //int noti_ex_action_visibility_set(noti_ex_action_h handle, const char* id, bool visible);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_multi_lang_create")]
        internal static extern ErrorCode MultiLanguageCreate(out IntPtr handle, string msgid, string format, params object[] args);
        //int noti_ex_multi_lang_create(noti_ex_multi_lang_h* handle, const char* msgid, const char* format, ...);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_multi_lang_destroy")]
        internal static extern ErrorCode MultiLanguageDestroy(IntPtr handle);
        //int noti_ex_multi_lang_destroy(noti_ex_multi_lang_h handle);

        internal delegate void ManagerEventsAddCallback(IntPtr handle, IntPtr info, IntPtr addedItems, int count, IntPtr userData);
        //typedef void (*noti_ex_manager_events_add_cb)(noti_ex_manager_h handle, noti_ex_event_info_h info, noti_ex_item_h *added_items, int count, void* user_data);

        internal delegate void ManagerEventsUpdateCallback(IntPtr handle, IntPtr info, IntPtr updatedItem, IntPtr userData);
        //typedef void (* noti_ex_manager_events_update_cb) (noti_ex_manager_h handle, noti_ex_event_info_h info, noti_ex_item_h updated_item, void* user_data);

        internal delegate void ManagerEventsDeleteCallback(IntPtr handle, IntPtr info, IntPtr deletedItem, IntPtr userData);
        //typedef void (* noti_ex_manager_events_delete_cb) (noti_ex_manager_h handle, noti_ex_event_info_h info, noti_ex_item_h deleted_item, void* user_data);

        internal delegate void ManagerEventsErrorCallback(IntPtr handle, ErrorCode error, int requestId, IntPtr userData);
        //typedef void (* noti_ex_manager_events_error_cb) (noti_ex_manager_h handle, noti_ex_error_e error, int request_id, void* user_data);

        internal struct ManagerEventCallbacks
        {
            public ManagerEventsAddCallback OnAdd;
            public ManagerEventsUpdateCallback OnUpdate;
            public ManagerEventsDeleteCallback OnDelete;
            public ManagerEventsErrorCallback OnError;
        }

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_manager_create")]
        internal static extern ErrorCode ManagerCreate(out IntPtr handle, string receiverGroup, ManagerEventCallbacks eventCallback, IntPtr userData);
        //int noti_ex_manager_create(noti_ex_manager_h* handle, const char* receiver_group, noti_ex_manager_events_s event_callbacks, void* user_data);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_manager_destroy")]
        internal static extern ErrorCode ManagerDestroy(IntPtr handle);
        //int noti_ex_manager_destroy(noti_ex_manager_h handle);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_manager_get")]
        internal static extern ErrorCode ManagerGet(IntPtr handle, out IntPtr items, out int count);
        //int noti_ex_manager_get(noti_ex_manager_h handle, noti_ex_item_h** items, int* count);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_manager_get_by_channel")]
        internal static extern ErrorCode ManagerGetByChannel(IntPtr handle, string channel, out IntPtr items, out int count);
        //int noti_ex_manager_get_by_channel(noti_ex_manager_h handle, char* channel, noti_ex_item_h** items, int* count);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_manager_update")]
        internal static extern ErrorCode ManagerUpdate(IntPtr handle, IntPtr item, out int requestId);
        //int noti_ex_manager_update(noti_ex_manager_h handle, noti_ex_item_h item, int* request_id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_manager_delete")]
        internal static extern ErrorCode ManagerDelete(IntPtr handle, IntPtr noti, out int requestId);
        //int noti_ex_manager_delete(noti_ex_manager_h handle, noti_ex_item_h noti, int* request_id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_manager_delete_all")]
        internal static extern ErrorCode ManagerDeleteAll(IntPtr handle, out int requestId);
        //int noti_ex_manager_delete_all(noti_ex_manager_h handle, int* request_id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_manager_hide")]
        internal static extern ErrorCode ManagerHide(IntPtr handle, IntPtr item, out int requestId);
        //int noti_ex_manager_hide(noti_ex_manager_h handle, noti_ex_item_h item, int* request_id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_manager_find_by_root_id")]
        internal static extern ErrorCode ManagerFindByRootID(IntPtr handle, string rootId, out IntPtr item);
        //int noti_ex_manager_find_by_root_id(noti_ex_manager_h handle, const char* root_id, noti_ex_item_h *item);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_manager_send_error")]
        internal static extern ErrorCode ManagerSendError(IntPtr handle, IntPtr info, ErrorCode error);
        //int noti_ex_manager_send_error(noti_ex_manager_h handle, noti_ex_event_info_h info, noti_ex_error_e error);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_manager_get_notification_count")]
        internal static extern ErrorCode ManagerGetNotificationCount(IntPtr handle, out int count);
        //int noti_ex_manager_get_notification_count(noti_ex_manager_h handle, int* cnt);


        internal delegate void ReporterEventsErrorCallback(IntPtr handle, ErrorCode error, int requestId, IntPtr userData);
        //typedef void (* noti_ex_reporter_events_error_cb) (noti_ex_reporter_h handle, noti_ex_error_e error, int request_id, void* user_data);

        internal delegate void ReporterEventsEventCallback(IntPtr handle, IntPtr eventInfo, IntPtr items, int count, IntPtr userData);
        //typedef void (* noti_ex_reporter_events_event_cb) (noti_ex_reporter_h handle, noti_ex_event_info_h info, noti_ex_item_h* items, int count, void* user_data);

        internal struct ReporterEventCallbacks
        {
            public ReporterEventsEventCallback OnEvent;
            public ReporterEventsErrorCallback OnError;
        }

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_reporter_create")]
        internal static extern ErrorCode ReporterCreate(out IntPtr handle, ReporterEventCallbacks eventCallback, IntPtr userData);
        //int noti_ex_reporter_create(noti_ex_reporter_h* handle, noti_ex_reporter_events_s event_callbacks, void* user_data);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_reporter_destroy")]
        internal static extern ErrorCode ReporterDestroy(IntPtr handle);
        //int noti_ex_reporter_destroy(noti_ex_reporter_h handle);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_reporter_send_error")]
        internal static extern ErrorCode ReporterSendError(IntPtr handle, IntPtr info, ErrorCode error);
        //int noti_ex_reporter_send_error(noti_ex_reporter_h handle, noti_ex_event_info_h info, noti_ex_error_e error);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_reporter_post")]
        internal static extern ErrorCode ReporterPost(IntPtr handle, IntPtr noti, out int requestId);
        //int noti_ex_reporter_post(noti_ex_reporter_h handle, noti_ex_item_h noti, int* request_id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_reporter_post_list")]
        internal static extern ErrorCode ReporterPostList(IntPtr handle, IntPtr notiList, int count, out int requestId);
        //int noti_ex_reporter_post_list(noti_ex_reporter_h handle, noti_ex_item_h* noti_list, int count, int* request_id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_reporter_update")]
        internal static extern ErrorCode ReporterUpdate(IntPtr handle, IntPtr noti, out int requestId);
        //int noti_ex_reporter_update(noti_ex_reporter_h handle, noti_ex_item_h noti, int* request_id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_reporter_delete")]
        internal static extern ErrorCode ReporterDelete(IntPtr handle, IntPtr noti, out int requestId);
        //int noti_ex_reporter_delete(noti_ex_reporter_h handle, noti_ex_item_h noti, int* request_id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_reporter_delete_all")]
        internal static extern ErrorCode ReporterDeleteAll(IntPtr handle, out int requestId);
        //int noti_ex_reporter_delete_all(noti_ex_reporter_h handle, int* request_id);

        [DllImport(Libraries.NotificationEx, EntryPoint = "noti_ex_reporter_find_by_root_id")]
        internal static extern ErrorCode ReporterFindByRootId(IntPtr handle, string rootId, out IntPtr item);
        //int noti_ex_reporter_find_by_root_id(noti_ex_reporter_h handle, const char* root_id, noti_ex_item_h* item);
    }
}
