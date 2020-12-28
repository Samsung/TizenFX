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
    internal static partial class Evas
    {
        public enum ObjectCallbackType
        {
            MouseIn,
            MouseOut,
            MouseDown,
            MouseUp,
            MouseMove,
            MouseWheel,
            MultiDown,
            MultiUp,
            MultiMove,
            Free,
            KeyDown,
            KeyUp,
            FocusIn,
            FocusOut,
            Show,
            Hide,
            Move,
            Resize,
            Restack,
            Del,
            Hold,
            ChangedSizeHints,
            ImagePreloaded,
            CanvasFocusIn,
            CanvasFocusOut,
            RenderFlushPre,
            RenderFlushPost,
            CanvasObjectFocusIn,
            CanvasObjectFocusOut,
            ImageUnloaded,
            RenderPre,
            RenderPost,
            ImageResize,
            DeviceChanged,
            AxisUpdate,
            CanvasViewportResize
        }

        public enum LoadError
        {
            None = 0, /* No error on load */
            Generic = 1, /* A non-specific error occurred */
            DoesNotRxist = 2, /* File (or file path) does not exist */
            PermissionDenied = 3, /* Permission denied to an existing file (or path) */
            ResourceAllocationFailed = 4, /* Allocation of resources failure prevented load */
            CorruptFile = 5, /* File corrupt (but was detected as a known format) */
            UnknownFormat = 6 /* File is not a known format */
        }

        public enum Colorspace
        {
            Argb8888, /* ARGB 32 bits per pixel, high-byte is Alpha, accessed 1 32bit word at a time */
            Ycbcr422p709pl, /* YCbCr 4:2:2 Planar, ITU.BT-709 specifications. The data pointed to is just an array of row pointer, pointing to the Y rows, then the Cb, then Cr rows */
            Ergb565a5p, /* 16bit rgb565 + Alpha plane at end - 5 bits of the 8 being used per alpha byte */
            Egry8, /* 8bit grayscale */
            Eycbcr422601pl, /*  YCbCr 4:2:2, ITU.BT-601 specifications. The data pointed to is just an array of row pointer, pointing to line of Y,Cb,Y,Cr bytes */
            Eycbcr420nv12601pl, /* YCbCr 4:2:0, ITU.BT-601 specification. The data pointed to is just an array of row pointer, pointing to the Y rows, then the Cb,Cr rows. */
            Eycbcr420tm12601pl, /* YCbCr 4:2:0, ITU.BT-601 specification. The data pointed to is just an array of tiled row pointer, pointing to the Y rows, then the Cb,Cr rows. */
            Eagry88, /* AY 8bits Alpha and 8bits Grey, accessed 1 16bits at a time */
            Eetc1, /* OpenGL ETC1 encoding of RGB texture (4 bit per pixel) @since 1.10 */
            Ergb8etc2, /* OpenGL GL_COMPRESSED_RGB8_ETC2 texture compression format (4 bit per pixel) @since 1.10 */
            Ergba8etc2eac, /* OpenGL GL_COMPRESSED_RGBA8_ETC2_EAC texture compression format, supports alpha (8 bit per pixel) @since 1.10 */
            Eetc1alpha,     /* ETC1 with alpha support using two planes: ETC1 RGB and ETC1 grey for alpha @since 1.11 */
        }

        public enum ImageScaleHint
        {
            None = 0, /* No scale hint at all */
            Dynamic = 1, /* Image is being re-scaled over time, thus turning scaling cache @b off for its data */
            Static = 2 /* Image is not being re-scaled over time, thus turning scaling cache @b on for its data */
        }

        public enum RenderOp
        {
            Blend = 0, /* default op: d = d*(1-sa) + s */
            BlendRel = 1, /* d = d*(1 - sa) + s*da */
            Copy = 2, /* d = s */
            CopyRel = 3, /* d = s*da */
            Add = 4, /* d = d + s */
            AddRel = 5, /* d = d + s*da */
            Sub = 6, /* d = d - s */
            SubRel = 7, /* d = d - s*da */
            Tint = 8, /* d = d*s + d*(1 - sa) + s*(1 - da) */
            TintRel = 9, /* d = d*(1 - sa + s) */
            Mask = 10, /* d = d*sa */
            Mul = 11 /* d = d*s */
        }

        public enum ObjectCallbackPriority
        {
            After = 100,
            Before = -100,
            Default = 0
        }

        public enum TableHomogeneousMode
        {
            None = 0,
            Table = 1,
            Item = 2
        }

        public enum TextStyleType
        {
            Plain, /* plain, standard text */
            Shadow, /* text with shadow underneath */
            Outline, /* text with an outline */
            SoftOutline, /* text with a soft outline */
            Glow, /* text with a glow effect */
            OutlineShadow, /* text with both outline and shadow effects */
            FarShadow, /* text with (far) shadow underneath */
            OutlineSoftShadow, /* text with outline and soft shadow effects combined */
            SoftShadow, /* text with(soft) shadow underneath */
            FarSoftShadow, /* text with(far soft) shadow underneath */
            ShadowDirectionBottomRight, /* shadow growing to bottom right */
            ShadowDirectionBottom, /* shadow growing to the bottom */
            ShadowDirectionBottomLeft, /* shadow growing to bottom left */
            ShadowDirectionLeft, /* shadow growing to the left */
            ShadowDirectionTopLeft, /* shadow growing to top left */
            ShadowDirectionTop, /* shadow growing to the top */
            ShadowDirectionTopRight, /* shadow growing to top right */
            ShadowDirectionRight, /* shadow growing to the right */
        }

        //public struct TextBlockStyle
        //{
        //    string StyleText;
        //    string DefaultTag;

        //    List objects;
        //    bool DeleteMe;
        //}

        //public struct StyleTag
        //{
        //}

        internal delegate void EventCallback(IntPtr data, IntPtr evas, IntPtr obj, IntPtr info);

        internal delegate void EvasCallback(IntPtr data, IntPtr evas, IntPtr info);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_event_callback_add(IntPtr obj, ObjectCallbackType type, EvasCallback func, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_event_callback_del(IntPtr obj, ObjectCallbackType type, EvasCallback func);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_event_callback_add(IntPtr obj, ObjectCallbackType type, EventCallback func, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_event_callback_del(IntPtr obj, ObjectCallbackType type, EventCallback func);

        public delegate void SmartCallback(IntPtr data, IntPtr obj, IntPtr info);

        public static readonly string BackKeyName = "XF86Back";
        public static readonly string MenuKeyName = "XF86Menu";

        public enum ButtonFlags
        {
            None, DoubleClick, TripleClick
        }

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_key_grab(IntPtr obj, string keyname, ulong modifier, ulong not_modifier, bool exclusive);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_key_ungrab(IntPtr obj, string keyname, ulong modifier, ulong not_modifier);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_data_get(IntPtr obj, string keyname);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_data_set(IntPtr obj, string keyname, IntPtr data);

        [DllImport(Libraries.Evas, EntryPoint = "evas_object_type_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _evas_object_type_get(IntPtr obj);

        internal static string evas_object_type_get(IntPtr obj)
        {
            var text = _evas_object_type_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_evas_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_del(IntPtr objectPtr);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_show(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_hide(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_visible_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_smart_callback_add(IntPtr obj, string eventName, SmartCallback seh, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_smart_callback_del(IntPtr obj, string eventName, SmartCallback seh);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_min_set(IntPtr obj, int w, int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_min_get(IntPtr obj, out int w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_min_get(IntPtr obj, IntPtr w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_min_get(IntPtr obj, out int w, IntPtr h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_max_set(IntPtr obj, int w, int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_max_get(IntPtr obj, out int w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_max_get(IntPtr obj, IntPtr w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_max_get(IntPtr obj, out int w, IntPtr h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_weight_get(IntPtr obj, out double x, out double y);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_weight_get(IntPtr obj, out double x, IntPtr y);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_weight_get(IntPtr obj, IntPtr x, out double y);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_align_get(IntPtr obj, out double x, out double y);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_align_get(IntPtr obj, out double x, IntPtr y);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_align_get(IntPtr obj, IntPtr x, out double y);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_weight_set(IntPtr obj, double x, double y);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_align_set(IntPtr obj, double x, double y);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_move(IntPtr obj, int x, int y);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_resize(IntPtr obj, int w, int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_geometry_set(IntPtr obj, int x, int y, int w, int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_geometry_get(IntPtr obj, out int x, out int y, out int w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_geometry_get(IntPtr obj, out int x, IntPtr y, IntPtr w, IntPtr h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_geometry_get(IntPtr obj, IntPtr x, out int y, IntPtr w, IntPtr h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_geometry_get(IntPtr obj, IntPtr x, IntPtr y, out int w, IntPtr h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_geometry_get(IntPtr obj, IntPtr x, IntPtr y, IntPtr w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_geometry_get(IntPtr obj, IntPtr x, IntPtr y, out int w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_geometry_get(IntPtr obj, out int x, out int y, IntPtr w, IntPtr h);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_smart_members_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_map_new(int count);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_map_util_points_populate_from_object_full(IntPtr map, IntPtr obj, int z);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_map_util_points_populate_from_geometry(IntPtr map, int x, int y, int w, int h, int z);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_map_util_rotate(IntPtr map, double degree, int cx, int cy);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_map_util_3d_rotate(IntPtr map, double dx, double dy, double dz, int cx, int cy, int cz);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_map_util_zoom(IntPtr map, double x, double y, int cx, int cy);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_map_point_coord_set(IntPtr map, int idx, int x, int y, int z);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_map_point_coord_get(IntPtr map, int idx, out int x, out int y, out int z);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_map_enable_set(IntPtr obj, bool enabled);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_map_enable_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_map_util_object_move_sync_set(IntPtr map, bool enabled);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_map_util_object_move_sync_get(IntPtr map);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_map_set(IntPtr obj, IntPtr map);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_map_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_map_free(IntPtr map);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_polygon_add(IntPtr evas);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_polygon_point_add(IntPtr evas, int x, int y);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_polygon_points_clear(IntPtr evas);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_rectangle_add(IntPtr evas);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_color_set(IntPtr obj, int r, int g, int b, int a);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_color_get(IntPtr obj, out int r, out int g, out int b, out int a);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_color_get(IntPtr obj, IntPtr r, IntPtr g, IntPtr b, out int a);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_clip_set(IntPtr obj, IntPtr clip);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_clip_unset(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_clip_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_lower(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_event_feed_mouse_move(IntPtr obj, int x, int y, int timestamp, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_event_feed_mouse_down(IntPtr obj, int b, ButtonFlags flags, int timestamp, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_event_feed_mouse_up(IntPtr obj, int b, ButtonFlags flags, int timestamp, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_event_feed_key_down(IntPtr obj, string keyname, string key, string str, string compose, int timestamp, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_event_feed_key_up(IntPtr obj, string keyname, string key, string str, string compose, int timestamp, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_ref(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_unref(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern int evas_object_ref_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_repeat_events_set(IntPtr obj, bool repeat);

        [DllImport(Libraries.Evas)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool evas_object_repeat_events_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_propagate_events_set(IntPtr obj, bool propagate);

        [DllImport(Libraries.Evas)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool evas_object_propagate_events_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_pass_events_set(IntPtr obj, bool propagate);

        [DllImport(Libraries.Evas)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool evas_object_pass_events_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_textblock_size_native_get(IntPtr obj, out int w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_textblock_size_formatted_get(IntPtr obj, out int w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_smart_changed(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_smart_calculate(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_color_argb_premul(int a, ref int r, ref int g, ref int b);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_damage_rectangle_add(IntPtr obj, int x, int y, int w, int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_data_argb_premul(uint data, uint length);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_event_callback_del_full(IntPtr obj, ObjectCallbackType type, EvasCallback func, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_font_path_global_append(string path);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_image_cache_flush(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_image_cache_set(IntPtr obj, int size);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_pointer_canvas_xy_get(IntPtr obj, out int mx, out int my);

        [DllImport(Libraries.Evas, EntryPoint = "evas_load_error_str")]
        internal static extern IntPtr _evas_load_error_str(LoadError error);

        internal static string evas_load_error_str(LoadError error)
        {
            return Marshal.PtrToStringAnsi(_evas_load_error_str(error));
        }

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_data_del(IntPtr obj, string key);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_focus_set(IntPtr obj, bool focus);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_freeze_events_set(IntPtr obj, bool freeze);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_layer_set(IntPtr obj, int layer);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_raise(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_render_op_set(IntPtr obj, RenderOp op);

        [DllImport(Libraries.Evas)]
        internal static extern RenderOp evas_object_render_op_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_aspect_set(IntPtr obj, int aspect, int w, int h);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_smart_add(IntPtr obj, IntPtr smart);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_smart_data_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_smart_data_set(IntPtr obj, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_smart_member_add(IntPtr obj, IntPtr smart);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_smart_member_del(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_stack_above(IntPtr obj, IntPtr avobe);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_text_add(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_text_font_set(IntPtr obj, string font, int size);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_text_text_set(IntPtr obj, string text);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_textblock_add(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_textblock_style_set(IntPtr obj, IntPtr textBlockStyle);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_textblock_text_markup_set(IntPtr obj, string text);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_obscured_clear(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_smart_class_new(IntPtr obj);

        [DllImport(Libraries.Evas, EntryPoint = "evas_device_name_get")]
        internal static extern IntPtr _evas_device_name_get(IntPtr obj);

        internal static string evas_device_name_get(IntPtr obj)
        {
            return Marshal.PtrToStringAnsi(_evas_device_name_get(obj));
        }

        [DllImport(Libraries.Evas)]
        internal static extern void evas_font_path_global_clear();

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_object_above_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_event_callback_priority_add(IntPtr obj, ObjectCallbackType type, ObjectCallbackPriority priority, EventCallback func, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_focus_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_freeze_events_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern int evas_object_layer_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_smart_callback_priority_add(IntPtr obj, string eventName, ObjectCallbackPriority priority, EventCallback func, IntPtr data);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_smart_clipped_smart_set(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_table_homogeneous_set(IntPtr obj, TableHomogeneousMode mode);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_table_pack(IntPtr obj, IntPtr child, uint col, uint row, uint colspan, uint rowspan);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_table_padding_set(IntPtr obj, int horizontal, int vertical);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_text_filter_program_set(IntPtr obj, string program);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_text_glow_color_set(IntPtr obj, int r, int g, int b, int a);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_text_outline_color_set(IntPtr obj, int r, int g, int b, int a);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_text_shadow_color_set(IntPtr obj, int r, int g, int b, int a);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_text_style_set(IntPtr obj, TextStyleType type);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_textblock_line_number_geometry_get(IntPtr obj, int line, out int x, out int y, out int w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_textblock_valign_set(IntPtr obj, double align);

        [DllImport(Libraries.Evas)]
        internal static extern int evas_string_char_len_get(string str);

        [DllImport(Libraries.Evas)]
        internal static extern int evas_textblock_style_free(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern IntPtr evas_textblock_style_new();

        [DllImport(Libraries.Evas)]
        internal static extern void evas_textblock_style_set(IntPtr obj, string text);

        [DllImport(Libraries.Evas)]
        internal static extern string evas_textblock_text_markup_to_utf8(IntPtr obj, string text);

        [DllImport(Libraries.Evas)]
        internal static extern string evas_textblock_text_utf8_to_markup(IntPtr obj, string text);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_obscured_rectangle_add(IntPtr obj, int x, int y, int w, int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_render(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_norender(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern int evas_image_cache_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_font_path_global_prepend(string path);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_font_reinit();

        [DllImport(Libraries.Evas)]
        internal static extern void evas_color_argb_unpremul(int a, ref int r, ref int g, ref int b);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_color_hsv_to_rgb(int r, int g, int b, out float h, out float s, out float v);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_color_rgb_to_hsv(float h, float s, float v, out int r, out int g, out int b);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_stack_below(IntPtr obj, IntPtr below);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_size_hint_aspect_get(IntPtr obj, out int aspect, out int w, out int h);

        internal static void SetX(IntPtr obj, int x)
        {
            int y = GetY(obj);
            evas_object_move(obj, x, y);
        }

        internal static void SetY(IntPtr obj, int y)
        {
            int x = GetX(obj);
            evas_object_move(obj, x, y);
        }

        internal static void SetWidth(IntPtr obj, int w)
        {
            int h = GetHeight(obj);
            evas_object_resize(obj, w, h);
        }

        internal static void SetHeight(IntPtr obj, int h)
        {
            int w = GetWidth(obj);
            evas_object_resize(obj, w, h);
        }

        internal static int GetX(IntPtr obj)
        {
            int x;
            evas_object_geometry_get(obj, out x, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            return x;
        }

        internal static int GetY(IntPtr obj)
        {
            int y;
            evas_object_geometry_get(obj, IntPtr.Zero, out y, IntPtr.Zero, IntPtr.Zero);
            return y;
        }

        internal static int GetWidth(IntPtr obj)
        {
            int w;
            evas_object_geometry_get(obj, IntPtr.Zero, IntPtr.Zero, out w, IntPtr.Zero);
            return w;
        }

        internal static int GetHeight(IntPtr obj)
        {
            int h;
            evas_object_geometry_get(obj, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, out h);
            return h;
        }

        internal static double GetAlignX(IntPtr obj)
        {
            double x;
            evas_object_size_hint_align_get(obj, out x, IntPtr.Zero);
            return x;
        }

        internal static double GetAlignY(IntPtr obj)
        {
            double y;
            evas_object_size_hint_align_get(obj, IntPtr.Zero, out y);
            return y;
        }

        internal static void SetAlignX(IntPtr obj, double x)
        {
            double y = GetAlignY(obj);
            evas_object_size_hint_align_set(obj, x, y);
        }

        internal static void SetAlignY(IntPtr obj, double y)
        {
            double x = GetAlignX(obj);
            evas_object_size_hint_align_set(obj, x, y);
        }

        internal static double GetWeightX(IntPtr obj)
        {
            double x;
            evas_object_size_hint_weight_get(obj, out x, IntPtr.Zero);
            return x;
        }

        internal static double GetWeightY(IntPtr obj)
        {
            double y;
            evas_object_size_hint_weight_get(obj, IntPtr.Zero, out y);
            return y;
        }

        internal static void SetWeightX(IntPtr obj, double x)
        {
            double y = GetWeightY(obj);
            evas_object_size_hint_weight_set(obj, x, y);
        }

        internal static void SetWeightY(IntPtr obj, double y)
        {
            double x = GetWeightX(obj);
            evas_object_size_hint_weight_set(obj, x, y);
        }

        internal static int GetAlpha(IntPtr obj)
        {
            int a;
            evas_object_color_get(obj, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, out a);
            return a;
        }

        internal static void SetAlpha(IntPtr obj, int a)
        {
            evas_object_color_set(obj, a, a, a, a);
        }

        internal static void SetPremultipliedColor(IntPtr obj, int r, int g, int b, int a)
        {
            evas_object_color_set(obj, r * a / 255, g * a / 255, b * a / 255, a);
        }
    }
}