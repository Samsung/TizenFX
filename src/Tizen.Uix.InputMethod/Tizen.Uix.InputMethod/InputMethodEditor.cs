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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Interop.InputMethod;

namespace Tizen.Uix.InputMethod
{
    public enum KeyCode
    {
        IME_KEY_BackSpace = 0xFF08,    /**< The backspace key */
        IME_KEY_Tab = 0xFF09,    /**< The tab key */
        IME_KEY_Linefeed = 0xFF0A,    /**< The linefeed key */
        IME_KEY_Clear = 0xFF0B,    /**< The clear key */
        IME_KEY_Return = 0xFF0D,    /**< The return key */
        IME_KEY_Pause = 0xFF13,    /**< The pause key */
        IME_KEY_Scroll_Lock = 0xFF14,    /**< The scroll lock key */
        IME_KEY_Sys_Req = 0xFF15,    /**< The sys req key */
        IME_KEY_Escape = 0xFF1B,    /**< The escape key */
        IME_KEY_Delete = 0xFFFF,    /**< The delete key */

        /* Cursor control & motion */
        IME_KEY_Home = 0xFF50,    /**< The home key */
        IME_KEY_Left = 0xFF51,    /**< The left directional key */
        IME_KEY_Up = 0xFF52,    /**< The up directional key */
        IME_KEY_Right = 0xFF53,    /**< The right directional key */
        IME_KEY_Down = 0xFF54,    /**< The down directional key */
        IME_KEY_Prior = 0xFF55,    /**< The prior, previous key */
        IME_KEY_Page_Up = 0xFF55,    /**< The page up key */
        IME_KEY_Next = 0xFF56,    /**< The next key */
        IME_KEY_Page_Down = 0xFF56,    /**< The page down key */
        IME_KEY_End = 0xFF57,    /**< The end key */
        IME_KEY_Begin = 0xFF58,    /**< The begin key */

        /* Misc Functions */
        IME_KEY_Select = 0xFF60,    /**< The select key */
        IME_KEY_Print = 0xFF61,    /**< The print key */
        IME_KEY_Execute = 0xFF62,    /**< The execute, run, do key */
        IME_KEY_Insert = 0xFF63,    /**< The insert key */
        IME_KEY_Undo = 0xFF65,    /**< The undo key */
        IME_KEY_Redo = 0xFF66,    /**< The redo key */
        IME_KEY_Menu = 0xFF67,    /**< The menu key */
        IME_KEY_Find = 0xFF68,    /**< The find key */
        IME_KEY_Cancel = 0xFF69,    /**< The cancel, stop, abort, exit key */
        IME_KEY_Help = 0xFF6A,    /**< The help key */
        IME_KEY_Break = 0xFF6B,    /**< The break key */
        IME_KEY_Mode_switch = 0xFF7E,    /**< The character set switch key */
        IME_KEY_Num_Lock = 0xFF7F,    /**< The num lock key */

        /* Keypad */
        IME_KEY_KP_Space = 0xFF80,    /**< The Numpad space key */
        IME_KEY_KP_Tab = 0xFF89,    /**< The Numpad tab key */
        IME_KEY_KP_Enter = 0xFF8D,    /**< The Numpad enter key */
        IME_KEY_KP_F1 = 0xFF91,    /**< The Numpad function 1 key */
        IME_KEY_KP_F2 = 0xFF92,    /**< The Numpad function 2 key */
        IME_KEY_KP_F3 = 0xFF93,    /**< The Numpad function 3 key */
        IME_KEY_KP_F4 = 0xFF94,    /**< The Numpad function 4 key */
        IME_KEY_KP_Home = 0xFF95,    /**< The Numpad home key */
        IME_KEY_KP_Left = 0xFF96,    /**< The Numpad left key */
        IME_KEY_KP_Up = 0xFF97,    /**< The Numpad up key */
        IME_KEY_KP_Right = 0xFF98,    /**< The Numpad right key */
        IME_KEY_KP_Down = 0xFF99,    /**< The Numpad down key */
        IME_KEY_KP_Prior = 0xFF9A,    /**< The Numpad prior, previous key */
        IME_KEY_KP_Page_Up = 0xFF9A,    /**< The Numpad page up key */
        IME_KEY_KP_Next = 0xFF9B,    /**< The Numpad next key */
        IME_KEY_KP_Page_Down = 0xFF9B,    /**< The Numpad page down key */
        IME_KEY_KP_End = 0xFF9C,    /**< The Numpad end key */
        IME_KEY_KP_Begin = 0xFF9D,    /**< The Numpad begin key */
        IME_KEY_KP_Insert = 0xFF9E,    /**< The Numpad insert key */
        IME_KEY_KP_Delete = 0xFF9F,    /**< The Numpad delete key */
        IME_KEY_KP_Equal = 0xFFBD,    /**< The Numpad equal key */
        IME_KEY_KP_Multiply = 0xFFAA,    /**< The Numpad multiply key */
        IME_KEY_KP_Add = 0xFFAB,    /**< The Numpad add key */
        IME_KEY_KP_Separator = 0xFFAC,    /**< The Numpad separator key */
        IME_KEY_KP_Subtract = 0xFFAD,    /**< The Numpad subtract key */
        IME_KEY_KP_Decimal = 0xFFAE,    /**< The Numpad decimal key */
        IME_KEY_KP_Divide = 0xFFAF,    /**< The Numpad divide key */

        IME_KEY_KP_0 = 0xFFB0,    /**< The Numpad 0 key */
        IME_KEY_KP_1 = 0xFFB1,    /**< The Numpad 1 key */
        IME_KEY_KP_2 = 0xFFB2,    /**< The Numpad 2 key */
        IME_KEY_KP_3 = 0xFFB3,    /**< The Numpad 3 key */
        IME_KEY_KP_4 = 0xFFB4,    /**< The Numpad 4 key */
        IME_KEY_KP_5 = 0xFFB5,    /**< The Numpad 5 key */
        IME_KEY_KP_6 = 0xFFB6,    /**< The Numpad 6 key */
        IME_KEY_KP_7 = 0xFFB7,    /**< The Numpad 7 key */
        IME_KEY_KP_8 = 0xFFB8,    /**< The Numpad 8 key */
        IME_KEY_KP_9 = 0xFFB9,    /**< The Numpad 9 key */

        /* Auxilliary Functions */
        IME_KEY_F1 = 0xFFBE,    /**< The function 1 key */
        IME_KEY_F2 = 0xFFBF,    /**< The function 2 key */
        IME_KEY_F3 = 0xFFC0,    /**< The function 3 key */
        IME_KEY_F4 = 0xFFC1,    /**< The function 4 key */
        IME_KEY_F5 = 0xFFC2,    /**< The function 5 key */
        IME_KEY_F6 = 0xFFC3,    /**< The function 6 key */
        IME_KEY_F7 = 0xFFC4,    /**< The function 7 key */
        IME_KEY_F8 = 0xFFC5,    /**< The function 8 key */
        IME_KEY_F9 = 0xFFC6,    /**< The function 9 key */
        IME_KEY_F10 = 0xFFC7,    /**< The function 10 key */
        IME_KEY_F11 = 0xFFC8,    /**< The function 11 key */
        IME_KEY_F12 = 0xFFC9,    /**< The function 12 key */
        IME_KEY_F13 = 0xFFCA,    /**< The function 13 key */
        IME_KEY_F14 = 0xFFCB,    /**< The function 14 key */
        IME_KEY_F15 = 0xFFCC,    /**< The function 15 key */
        IME_KEY_F16 = 0xFFCD,    /**< The function 16 key */
        IME_KEY_F17 = 0xFFCE,    /**< The function 17 key */
        IME_KEY_F18 = 0xFFCF,    /**< The function 18 key */
        IME_KEY_F19 = 0xFFD0,    /**< The function 19 key */
        IME_KEY_F20 = 0xFFD1,    /**< The function 20 key */
        IME_KEY_F21 = 0xFFD2,    /**< The function 21 key */
        IME_KEY_F22 = 0xFFD3,    /**< The function 22 key */
        IME_KEY_F23 = 0xFFD4,    /**< The function 23 key */
        IME_KEY_F24 = 0xFFD5,    /**< The function 24 key */
        IME_KEY_F25 = 0xFFD6,    /**< The function 25 key */
        IME_KEY_F26 = 0xFFD7,    /**< The function 26 key */
        IME_KEY_F27 = 0xFFD8,    /**< The function 27 key */
        IME_KEY_F28 = 0xFFD9,    /**< The function 28 key */
        IME_KEY_F29 = 0xFFDA,    /**< The function 29 key */
        IME_KEY_F30 = 0xFFDB,    /**< The function 30 key */
        IME_KEY_F31 = 0xFFDC,    /**< The function 31 key */
        IME_KEY_F32 = 0xFFDD,    /**< The function 32 key */
        IME_KEY_F33 = 0xFFDE,    /**< The function 33 key */
        IME_KEY_F34 = 0xFFDF,    /**< The function 34 key */
        IME_KEY_F35 = 0xFFE0,    /**< The function 35 key */

        /* Modifier keys */
        IME_KEY_Shift_L = 0xFFE1,    /**< The left shift key */
        IME_KEY_Shift_R = 0xFFE2,    /**< The right shift key */
        IME_KEY_Control_L = 0xFFE3,    /**< The left control key */
        IME_KEY_Control_R = 0xFFE4,    /**< The right control key */
        IME_KEY_Caps_Lock = 0xFFE5,    /**< The caps lock key */
        IME_KEY_Shift_Lock = 0xFFE6,    /**< The shift lock key */

        IME_KEY_Meta_L = 0xFFE7,    /**< The left meta key */
        IME_KEY_Meta_R = 0xFFE8,    /**< The right meta key */
        IME_KEY_Alt_L = 0xFFE9,    /**< The left alt key */
        IME_KEY_Alt_R = 0xFFEA,    /**< The right alt key */
        IME_KEY_Super_L = 0xFFEB,    /**< The left super key */
        IME_KEY_Super_R = 0xFFEC,    /**< The right super key */
        IME_KEY_Hyper_L = 0xFFED,    /**< The left hyper key */
        IME_KEY_Hyper_R = 0xFFEE,    /**< The right hyper key */

        /* Latin 1 */
        IME_KEY_space = 0x020,    /**< The space key */
        IME_KEY_exclam = 0x021,    /**< The exclamation key */
        IME_KEY_quotedbl = 0x022,    /**< The quotedbl key */
        IME_KEY_numbersign = 0x023,    /**< The number sign key */
        IME_KEY_dollar = 0x024,    /**< The dollar key */
        IME_KEY_percent = 0x025,    /**< The percent key */
        IME_KEY_ampersand = 0x026,    /**< The ampersand key */
        IME_KEY_apostrophe = 0x027,    /**< The apostrophe key */
        IME_KEY_parenleft = 0x028,    /**< The parenleft key */
        IME_KEY_parenright = 0x029,    /**< The parenright key */
        IME_KEY_asterisk = 0x02a,    /**< The asterisk key */
        IME_KEY_plus = 0x02b,    /**< The plus key */
        IME_KEY_comma = 0x02c,    /**< The comma key */
        IME_KEY_minus = 0x02d,    /**< The minus key */
        IME_KEY_period = 0x02e,    /**< The period key */
        IME_KEY_slash = 0x02f,    /**< The slash key */
        IME_KEY_0 = 0x030,    /**< The 0 key */
        IME_KEY_1 = 0x031,    /**< The 1 key */
        IME_KEY_2 = 0x032,    /**< The 2 key */
        IME_KEY_3 = 0x033,    /**< The 3 key */
        IME_KEY_4 = 0x034,    /**< The 4 key */
        IME_KEY_5 = 0x035,    /**< The 5 key */
        IME_KEY_6 = 0x036,    /**< The 6 key */
        IME_KEY_7 = 0x037,    /**< The 7 key */
        IME_KEY_8 = 0x038,    /**< The 8 key */
        IME_KEY_9 = 0x039,    /**< The 9 key */
        IME_KEY_colon = 0x03a,    /**< The colon key */
        IME_KEY_semicolon = 0x03b,    /**< The semicolon key */
        IME_KEY_less = 0x03c,    /**< The less key */
        IME_KEY_equal = 0x03d,    /**< The equal key */
        IME_KEY_greater = 0x03e,    /**< The greater key */
        IME_KEY_question = 0x03f,    /**< The question key */
        IME_KEY_at = 0x040,    /**< The at key */
        IME_KEY_A = 0x041,    /**< The A key */
        IME_KEY_B = 0x042,    /**< The B key */
        IME_KEY_C = 0x043,    /**< The C key */
        IME_KEY_D = 0x044,    /**< The D key */
        IME_KEY_E = 0x045,    /**< The E key */
        IME_KEY_F = 0x046,    /**< The F key */
        IME_KEY_G = 0x047,    /**< The G key */
        IME_KEY_H = 0x048,    /**< The H key */
        IME_KEY_I = 0x049,    /**< The I key */
        IME_KEY_J = 0x04a,    /**< The J key */
        IME_KEY_K = 0x04b,    /**< The K key */
        IME_KEY_L = 0x04c,    /**< The L key */
        IME_KEY_M = 0x04d,    /**< The M key */
        IME_KEY_N = 0x04e,    /**< The N key */
        IME_KEY_O = 0x04f,    /**< The O key */
        IME_KEY_P = 0x050,    /**< The P key */
        IME_KEY_Q = 0x051,    /**< The Q key */
        IME_KEY_R = 0x052,    /**< The R key */
        IME_KEY_S = 0x053,    /**< The S key */
        IME_KEY_T = 0x054,    /**< The T key */
        IME_KEY_U = 0x055,    /**< The U key */
        IME_KEY_V = 0x056,    /**< The V key */
        IME_KEY_W = 0x057,    /**< The W key */
        IME_KEY_X = 0x058,    /**< The X key */
        IME_KEY_Y = 0x059,    /**< The Y key */
        IME_KEY_Z = 0x05a,    /**< The Z key */
        IME_KEY_bracketleft = 0x05b,    /**< The left bracket key */
        IME_KEY_backslash = 0x05c,    /**< The backslash key */
        IME_KEY_bracketright = 0x05d,    /**< The right bracket key */
        IME_KEY_asciicircum = 0x05e,    /**< The circumflex key */
        IME_KEY_underscore = 0x05f,    /**< The underscore key */
        IME_KEY_grave = 0x060,    /**< The grave key */
        IME_KEY_a = 0x061,    /**< The a key */
        IME_KEY_b = 0x062,    /**< The b key */
        IME_KEY_c = 0x063,    /**< The c key */
        IME_KEY_d = 0x064,    /**< The d key */
        IME_KEY_e = 0x065,    /**< The e key */
        IME_KEY_f = 0x066,    /**< The f key */
        IME_KEY_g = 0x067,    /**< The g key */
        IME_KEY_h = 0x068,    /**< The h key */
        IME_KEY_i = 0x069,    /**< The i key */
        IME_KEY_j = 0x06a,    /**< The j key */
        IME_KEY_k = 0x06b,    /**< The k key */
        IME_KEY_l = 0x06c,    /**< The l key */
        IME_KEY_m = 0x06d,    /**< The m key */
        IME_KEY_n = 0x06e,    /**< The n key */
        IME_KEY_o = 0x06f,    /**< The o key */
        IME_KEY_p = 0x070,    /**< The p key */
        IME_KEY_q = 0x071,    /**< The q key */
        IME_KEY_r = 0x072,    /**< The r key */
        IME_KEY_s = 0x073,    /**< The s key */
        IME_KEY_t = 0x074,    /**< The t key */
        IME_KEY_u = 0x075,    /**< The u key */
        IME_KEY_v = 0x076,    /**< The v key */
        IME_KEY_w = 0x077,    /**< The w key */
        IME_KEY_x = 0x078,    /**< The x key */
        IME_KEY_y = 0x079,    /**< The y key */
        IME_KEY_z = 0x07a,    /**< The z key */
        IME_KEY_braceleft = 0x07b,    /**< The left brace key */
        IME_KEY_bar = 0x07c,    /**< The bar key */
        IME_KEY_braceright = 0x07d,    /**< The right brace key */
        IME_KEY_asciitilde = 0x07e    /**< The tilde key */
    };

    public enum KeyMask
    {
        IME_KEY_MASK_PRESSED = 0,       /**< Key press event without modifier key */
        IME_KEY_MASK_SHIFT = (1 << 0),    /**< The Shift key is pressed down */
        IME_KEY_MASK_CAPSLOCK = (1 << 1), /**< The CapsLock key is pressed down */
        IME_KEY_MASK_CONTROL = (1 << 2),  /**< The Control key is pressed down */
        IME_KEY_MASK_ALT = (1 << 3),      /**< The Alt key is pressed down */
        IME_KEY_MASK_META = (1 << 4),     /**< The Meta key is pressed down */
        IME_KEY_MASK_WIN = (1 << 5),      /**< The Win (between Control and Alt) is pressed down */
        IME_KEY_MASK_HYPER = (1 << 6),    /**< The Hyper key is pressed down */
        IME_KEY_MASK_NUMLOCK = (1 << 7),  /**< The NumLock key is pressed down */
        IME_KEY_MASK_RELEASED = (1 << 15) /**< Key release event */
    };
}