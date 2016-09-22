// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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
        internal delegate void EventCallback(IntPtr data, IntPtr evas, IntPtr obj, IntPtr info);

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
        internal static extern IntPtr evas_object_data_get(IntPtr obj, string keyname) ;

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
        internal static extern IntPtr evas_object_image_add(IntPtr obj);

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
        internal static extern void evas_object_geometry_set(IntPtr obj,int x, int y, int w, int h);

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

        [DllImport(Libraries.Elementary)]
        internal static extern void evas_object_ref(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void evas_object_unref(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int evas_object_ref_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void evas_object_repeat_events_set(IntPtr obj, bool repeat);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_textblock_size_native_get(IntPtr obj, out int w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_textblock_size_formatted_get(IntPtr obj, out int w, out int h);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_smart_changed(IntPtr obj);

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
            evas_object_color_set(obj, r*a/255, g*a/255, b*a/255, a);
        }
    }
}
