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

using ElmSharp;
using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Elementary
    {
        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_win_add(IntPtr parent, string name, int type);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_win_util_standard_add(string name, string title);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_activate(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_title_set(IntPtr obj, string title);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_win_title_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_win_title_get(IntPtr obj);

        internal static string elm_win_title_get(IntPtr obj)
        {
            var text = _elm_win_title_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_screen_size_get(IntPtr obj, out int x, out int y, out int w, out int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_resize_object_del(IntPtr obj, IntPtr subobj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_resize_object_add(IntPtr obj, IntPtr subobj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_raise(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_lower(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_alpha_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_alpha_set(IntPtr obj, bool alpha);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_win_role_get")]
        internal static extern IntPtr _elm_win_role_get(IntPtr obj);

        internal static string elm_win_role_get(IntPtr obj)
        {
            var text = _elm_win_role_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_role_set(IntPtr obj, string role);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_win_focus_highlight_style_get")]
        internal static extern IntPtr _elm_win_focus_highlight_style_get(IntPtr obj);

        internal static string elm_win_focus_highlight_style_get(IntPtr obj)
        {
            return Marshal.PtrToStringAnsi(_elm_win_focus_highlight_style_get(obj));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_focus_highlight_style_set(IntPtr obj, string style);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_borderless_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_borderless_set(IntPtr obj, bool borderless);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_focus_highlight_enabled_set(IntPtr obj, bool enabled);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_focus_highlight_enabled_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_autodel_set(IntPtr obj, bool autodel);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_autodel_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_override_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_override_set(IntPtr obj, bool isOverride);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_indicator_opacity_set(IntPtr obj, int opacity);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_indicator_opacity_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_indicator_mode_set(IntPtr obj, IndicatorMode mode);

        [DllImport(Libraries.Elementary)]
        internal static extern IndicatorMode elm_win_indicator_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_demand_attention_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_demand_attention_set(IntPtr obj, bool demandAttention);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_conformant_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_conformant_set(IntPtr obj, bool conformant);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_fullscreen_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_fullscreen_set(IntPtr obj, bool fullscreen);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_rotation_set(IntPtr obj, int rotation);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_rotation_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_rotation_with_resize_set(IntPtr obj, int rotation);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_prop_focus_skip_set(IntPtr obj, bool skip);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_wm_rotation_supported_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_focus_get(IntPtr obj);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_win_wm_rotation_available_rotations_set")]
        internal static extern void _elm_win_wm_rotation_available_rotations_set(IntPtr obj, IntPtr rotations, uint count);

        internal static void elm_win_wm_rotation_available_rotations_set(IntPtr obj, int[] rotations)
        {
            IntPtr pRotations = Marshal.AllocHGlobal(Marshal.SizeOf<int>() * rotations.Length);
            Marshal.Copy(rotations, 0, pRotations, rotations.Length);
            _elm_win_wm_rotation_available_rotations_set(obj, pRotations, (uint)rotations.Length);
            Marshal.FreeHGlobal(pRotations);
        }

        [DllImport(Libraries.Elementary, EntryPoint = "elm_win_wm_rotation_available_rotations_get")]
        internal static extern bool _elm_win_wm_rotation_available_rotations_get(IntPtr obj, out IntPtr rotations, out int count);

        internal static bool elm_win_wm_rotation_available_rotations_get(IntPtr obj, out int[] rotations)
        {
            IntPtr rotationArrPtr;
            int count;
            if (_elm_win_wm_rotation_available_rotations_get(obj, out rotationArrPtr, out count))
            {
                rotations = new int[count];
                Marshal.Copy(rotationArrPtr, rotations, 0, count);
                Libc.Free(rotationArrPtr);
                return true;
            }
            rotations = null;
            return false;
        }

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_layer_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_layer_set(IntPtr obj, int layer);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_sticky_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_sticky_set(IntPtr obj, bool sticky);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_screen_dpi_get(IntPtr obj, out int xdpi, out int ydpi);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_iconified_set(IntPtr obj, bool iconified);

        [DllImport(Libraries.Elementary)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool elm_win_iconified_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_floating_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_floating_mode_set(IntPtr obj, bool floating);

        [DllImport(Libraries.Elementary)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool elm_win_keygrab_set(IntPtr obj, string key, ulong  modifiers, ulong notModifiers, int proirity, KeyGrabMode grabMode);

        [DllImport(Libraries.Elementary)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool elm_win_keygrab_unset(IntPtr obj, string key, ulong modifiers, ulong notModifiers);

        [DllImport(Libraries.Eext)]
        internal static extern bool eext_win_keygrab_set(IntPtr obj, string key);

        [DllImport(Libraries.Eext)]
        internal static extern bool eext_win_keygrab_unset(IntPtr obj, string key);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_keyboard_win_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_keyboard_win_set(IntPtr obj, bool isKeyboard);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_keyboard_mode_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_keyboard_mode_set(IntPtr obj, int mode);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_inwin_activate(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_win_inwin_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_win_inwin_content_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_inwin_content_set(IntPtr obj, IntPtr content);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_win_inwin_content_unset(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern double elm_win_aspect_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_aspect_set(IntPtr obj, double aspect);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_autohide_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_autohide_set(IntPtr obj, bool autohide);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_center(IntPtr obj, bool h, bool v);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_focus_highlight_animate_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_focus_highlight_animate_set(IntPtr obj, bool animate);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_win_icon_name_get")]
        internal static extern IntPtr _elm_win_icon_name_get(IntPtr obj);

        internal static string elm_win_icon_name_get(IntPtr obj)
        {
            return Marshal.PtrToStringAnsi(_elm_win_icon_name_get(obj));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_icon_name_set(IntPtr obj, string iconName);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_win_icon_object_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_icon_object_set(IntPtr obj, IntPtr icon);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_win_inlined_image_object_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_modal_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_modal_set(IntPtr obj, bool modal);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_noblank_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_noblank_set(IntPtr obj, bool noblank);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_norender_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_norender_pop(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_norender_push(IntPtr obj);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_win_profile_get")]
        internal static extern IntPtr _elm_win_profile_get(IntPtr obj);

        internal static string elm_win_profile_get(IntPtr obj)
        {
            return Marshal.PtrToStringAnsi(_elm_win_profile_get(obj));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_profile_set(IntPtr obj, string profile);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_quickpanel_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_quickpanel_priority_major_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_quickpanel_priority_major_set(IntPtr obj, int priority);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_quickpanel_priority_minor_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_quickpanel_priority_minor_set(IntPtr obj, int priority);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_quickpanel_set(IntPtr obj, bool quickpanel);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_quickpanel_zone_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_quickpanel_zone_set(IntPtr obj, int zone);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_render(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_screen_constrain_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_screen_constrain_set(IntPtr obj, bool constrain);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_screen_position_get(IntPtr obj, out int x, out int y);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_shaped_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_shaped_set(IntPtr obj, bool shaped);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_size_base_get(IntPtr obj, out int w, out int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_size_base_set(IntPtr obj, int w, int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_size_step_get(IntPtr obj, out int w, out int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_size_step_set(IntPtr obj, int w, int h);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_socket_listen(IntPtr obj, string svcname, int svcnum, bool svcsys);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_win_trap_data_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_trap_set(IntPtr obj, IntPtr trap);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_urgent_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_urgent_set(IntPtr obj, bool urgent);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_win_util_dialog_add(IntPtr obj, string name, string title);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_withdrawn_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_withdrawn_set(IntPtr obj, bool withdrawn);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_wm_rotation_manual_rotation_done(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_wm_rotation_manual_rotation_done_get(IntPtr obj, bool withdrawn);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_wm_rotation_manual_rotation_done_set(IntPtr obj, bool set);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_wm_rotation_preferred_rotation_get(IntPtr obj, bool withdrawn);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_available_profiles_get(IntPtr obj, out string[] profiles, out int count);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_available_profiles_set(IntPtr obj, string[] profiles, int count);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_win_fake_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_fake_canvas_set(IntPtr obj, IntPtr oee);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_win_illume_command_send(IntPtr obj, IntPtr param);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_aux_hint_add(IntPtr obj, string hint, string val);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_aux_hint_del(IntPtr obj, int id);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_win_aux_hint_val_set(IntPtr obj, int id, string val);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_win_aux_hint_val_get")]
        internal static extern IntPtr _elm_win_aux_hint_val_get(IntPtr obj, int id);

        internal static string elm_win_aux_hint_val_get(IntPtr obj, int id)
        {
            return Marshal.PtrToStringAnsi(_elm_win_aux_hint_val_get(obj, id));
        }

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_win_aux_hint_id_get(IntPtr obj, string hint);
    }
}