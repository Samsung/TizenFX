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
    /// <summary>
    /// Enumeration of the key codes.
    /// If keycode & 0xff000000 == 0x01000000 then this key code is directly encoded 24-bit UCS character.The UCS value is keycode & 0x00ffffff.
    /// Defines the list of keys supported by the system.Note that certain keys may not be available on all devices.
    /// </summary>
    public enum KeyCode
    {
        /// <summary>
        /// The backspace key
        /// </summary>
        IME_KEY_BackSpace = 0xFF08,
        /// <summary>
        /// The tab key
        /// </summary>
        IME_KEY_Tab = 0xFF09,
        /// <summary>
        /// The linefeed key
        /// </summary>
        IME_KEY_Linefeed = 0xFF0A,
        /// <summary>
        /// The clear key
        /// </summary>
        IME_KEY_Clear = 0xFF0B,
        /// <summary>
        /// The return key
        /// </summary>
        IME_KEY_Return = 0xFF0D,
        /// <summary>
        /// The pause key
        /// </summary>
        IME_KEY_Pause = 0xFF13,
        /// <summary>
        /// The scroll lock key
        /// </summary>
        IME_KEY_Scroll_Lock = 0xFF14,
        /// <summary>
        /// The sys req key
        /// </summary>
        IME_KEY_Sys_Req = 0xFF15,
        /// <summary>
        /// The escape key
        /// </summary>
        IME_KEY_Escape = 0xFF1B,
        /// <summary>
        /// The delete key
        /// </summary>
        IME_KEY_Delete = 0xFFFF,

        /* Cursor control & motion */
        /// <summary>
        /// The home key
        /// </summary>
        IME_KEY_Home = 0xFF50,
        /// <summary>
        /// The left directional key
        /// </summary>
        IME_KEY_Left = 0xFF51,
        /// <summary>
        /// The up directional key
        /// </summary>
        IME_KEY_Up = 0xFF52,
        /// <summary>
        /// The right directional key
        /// </summary>
        IME_KEY_Right = 0xFF53,
        /// <summary>
        /// The down directional key
        /// </summary>
        IME_KEY_Down = 0xFF54,
        /// <summary>
        /// The prior, previous key
        /// </summary>
        IME_KEY_Prior = 0xFF55,
        /// <summary>
        /// The page up key
        /// </summary>
        IME_KEY_Page_Up = 0xFF55,
        /// <summary>
        /// The next key
        /// </summary>
        IME_KEY_Next = 0xFF56,
        /// <summary>
        /// The page down key
        /// </summary>
        IME_KEY_Page_Down = 0xFF56,
        /// <summary>
        /// The end key
        /// </summary>
        IME_KEY_End = 0xFF57,
        /// <summary>
        /// The begin key
        /// </summary>
        IME_KEY_Begin = 0xFF58,

        /* Misc Functions */
        /// <summary>
        /// The select key
        /// </summary>
        IME_KEY_Select = 0xFF60,
        /// <summary>
        /// The print key
        /// </summary>
        IME_KEY_Print = 0xFF61,
        /// <summary>
        /// The execute, run, do key
        /// </summary>
        IME_KEY_Execute = 0xFF62,
        /// <summary>
        /// The insert key
        /// </summary>
        IME_KEY_Insert = 0xFF63,
        /// <summary>
        /// The undo key
        /// </summary>
        IME_KEY_Undo = 0xFF65,
        /// <summary>
        /// The redo key
        /// </summary>
        IME_KEY_Redo = 0xFF66,
        /// <summary>
        /// The menu key
        /// </summary>
        IME_KEY_Menu = 0xFF67,
        /// <summary>
        /// The find key
        /// </summary>
        IME_KEY_Find = 0xFF68,
        /// <summary>
        /// The cancel, stop, abort, exit key
        /// </summary>
        IME_KEY_Cancel = 0xFF69,
        /// <summary>
        /// The help key
        /// </summary>
        IME_KEY_Help = 0xFF6A,
        /// <summary>
        /// The break key
        /// </summary>
        IME_KEY_Break = 0xFF6B,
        /// <summary>
        /// The character set switch key
        /// </summary>
        IME_KEY_Mode_switch = 0xFF7E,
        /// <summary>
        /// The num lock key
        /// </summary>
        IME_KEY_Num_Lock = 0xFF7F,

        /* Keypad */
        /// <summary>
        /// The Numpad space key
        /// </summary>
        IME_KEY_KP_Space = 0xFF80,
        /// <summary>
        /// The Numpad tab key
        /// </summary>
        IME_KEY_KP_Tab = 0xFF89,
        /// <summary>
        /// The Numpad enter key
        /// </summary>
        IME_KEY_KP_Enter = 0xFF8D,
        /// <summary>
        /// The Numpad function 1 key
        /// </summary>
        IME_KEY_KP_F1 = 0xFF91,
        /// <summary>
        /// The Numpad function 2 key
        /// </summary>
        IME_KEY_KP_F2 = 0xFF92,
        /// <summary>
        /// The Numpad function 3 key
        /// </summary>
        IME_KEY_KP_F3 = 0xFF93,
        /// <summary>
        /// The Numpad function 4 key
        /// </summary>
        IME_KEY_KP_F4 = 0xFF94,
        /// <summary>
        /// The Numpad home key
        /// </summary>
        IME_KEY_KP_Home = 0xFF95,
        /// <summary>
        /// The Numpad left key
        /// </summary>
        IME_KEY_KP_Left = 0xFF96,
        /// <summary>
        /// The Numpad up key
        /// </summary>
        IME_KEY_KP_Up = 0xFF97,
        /// <summary>
        /// The Numpad right key
        /// </summary>
        IME_KEY_KP_Right = 0xFF98,
        /// <summary>
        /// The Numpad down key
        /// </summary>
        IME_KEY_KP_Down = 0xFF99,
        /// <summary>
        /// The Numpad prior, previous key
        /// </summary>
        IME_KEY_KP_Prior = 0xFF9A,
        /// <summary>
        /// The Numpad page up key
        /// </summary>
        IME_KEY_KP_Page_Up = 0xFF9A,
        /// <summary>
        /// The Numpad next key
        /// </summary>
        IME_KEY_KP_Next = 0xFF9B,
        /// <summary>
        /// The Numpad page down key
        /// </summary>
        IME_KEY_KP_Page_Down = 0xFF9B,
        /// <summary>
        /// The Numpad end key
        /// </summary>
        IME_KEY_KP_End = 0xFF9C,
        /// <summary>
        /// The Numpad begin key
        /// </summary>
        IME_KEY_KP_Begin = 0xFF9D,
        /// <summary>
        /// The Numpad insert key
        /// </summary>
        IME_KEY_KP_Insert = 0xFF9E,
        /// <summary>
        /// The Numpad delete key
        /// </summary>
        IME_KEY_KP_Delete = 0xFF9F,
        /// <summary>
        /// The Numpad equal key
        /// </summary>
        IME_KEY_KP_Equal = 0xFFBD,
        /// <summary>
        /// The Numpad multiply key
        /// </summary>
        IME_KEY_KP_Multiply = 0xFFAA,
        /// <summary>
        /// The Numpad add key
        /// </summary>
        IME_KEY_KP_Add = 0xFFAB,
        /// <summary>
        /// The Numpad separator key
        /// </summary>
        IME_KEY_KP_Separator = 0xFFAC,
        /// <summary>
        /// The Numpad subtract key
        /// </summary>
        IME_KEY_KP_Subtract = 0xFFAD,
        /// <summary>
        /// The Numpad decimal key
        /// </summary>
        IME_KEY_KP_Decimal = 0xFFAE,
        /// <summary>
        /// The Numpad divide key
        /// </summary>
        IME_KEY_KP_Divide = 0xFFAF,
        /// <summary>
        /// The Numpad 0 key
        /// </summary>
        IME_KEY_KP_0 = 0xFFB0,
        /// <summary>
        /// The Numpad 1 key
        /// </summary>
        IME_KEY_KP_1 = 0xFFB1,
        /// <summary>
        /// The Numpad 2 key
        /// </summary>
        IME_KEY_KP_2 = 0xFFB2,
        /// <summary>
        /// The Numpad 3 key
        /// </summary>
        IME_KEY_KP_3 = 0xFFB3,
        /// <summary>
        /// The Numpad 4 key
        /// </summary>
        IME_KEY_KP_4 = 0xFFB4,
        /// <summary>
        /// The Numpad 5 key
        /// </summary>
        IME_KEY_KP_5 = 0xFFB5,
        /// <summary>
        /// The Numpad 6 key
        /// </summary>
        IME_KEY_KP_6 = 0xFFB6,
        /// <summary>
        /// The Numpad 7 key
        /// </summary>
        IME_KEY_KP_7 = 0xFFB7,
        /// <summary>
        /// The Numpad 8 key
        /// </summary>
        IME_KEY_KP_8 = 0xFFB8,
        /// <summary>
        /// The Numpad 9 key
        /// </summary>
        IME_KEY_KP_9 = 0xFFB9,

        /* Auxilliary Functions */
        /// <summary>
        /// The function 1 key
        /// </summary>
        IME_KEY_F1 = 0xFFBE,
        /// <summary>
        /// The function 2 key
        /// </summary>
        IME_KEY_F2 = 0xFFBF,
        /// <summary>
        /// The function 3 key
        /// </summary>
        IME_KEY_F3 = 0xFFC0,
        /// <summary>
        /// The function 4 key
        /// </summary>
        IME_KEY_F4 = 0xFFC1,
        /// <summary>
        /// The function 5 key
        /// </summary>
        IME_KEY_F5 = 0xFFC2,
        /// <summary>
        /// The function 6 key
        /// </summary>
        IME_KEY_F6 = 0xFFC3,
        /// <summary>
        /// The function 7 key
        /// </summary>
        IME_KEY_F7 = 0xFFC4,
        /// <summary>
        /// The function 8 key
        /// </summary>
        IME_KEY_F8 = 0xFFC5,
        /// <summary>
        /// The function 9 key
        /// </summary>
        IME_KEY_F9 = 0xFFC6,
        /// <summary>
        /// The function 10 key
        /// </summary>
        IME_KEY_F10 = 0xFFC7,
        /// <summary>
        /// The function 11 key
        /// </summary>
        IME_KEY_F11 = 0xFFC8,
        /// <summary>
        /// The function 12 key
        /// </summary>
        IME_KEY_F12 = 0xFFC9,
        /// <summary>
        /// The function 13 key
        /// </summary>
        IME_KEY_F13 = 0xFFCA,
        /// <summary>
        /// The function 14 key
        /// </summary>
        IME_KEY_F14 = 0xFFCB,
        /// <summary>
        /// The function 15 key
        /// </summary>
        IME_KEY_F15 = 0xFFCC,
        /// <summary>
        /// The function 16 key
        /// </summary>
        IME_KEY_F16 = 0xFFCD,
        /// <summary>
        /// The function 17 key
        /// </summary>
        IME_KEY_F17 = 0xFFCE,
        /// <summary>
        /// The function 18 key
        /// </summary>
        IME_KEY_F18 = 0xFFCF,
        /// <summary>
        /// The function 19 key
        /// </summary>
        IME_KEY_F19 = 0xFFD0,
        /// <summary>
        /// The function 20 key
        /// </summary>
        IME_KEY_F20 = 0xFFD1,
        /// <summary>
        /// The function 21 key
        /// </summary>
        IME_KEY_F21 = 0xFFD2,
        /// <summary>
        /// The function 22 key
        /// </summary>
        IME_KEY_F22 = 0xFFD3,
        /// <summary>
        /// The function 23 key
        /// </summary>
        IME_KEY_F23 = 0xFFD4,
        /// <summary>
        /// The function 24 key
        /// </summary>
        IME_KEY_F24 = 0xFFD5,
        /// <summary>
        /// The function 25 key
        /// </summary>
        IME_KEY_F25 = 0xFFD6,
        /// <summary>
        /// The function 26 key
        /// </summary>
        IME_KEY_F26 = 0xFFD7,
        /// <summary>
        /// The function 27 key
        /// </summary>
        IME_KEY_F27 = 0xFFD8,
        /// <summary>
        /// The function 28 key
        /// </summary>
        IME_KEY_F28 = 0xFFD9,
        /// <summary>
        /// The function 29 key
        /// </summary>
        IME_KEY_F29 = 0xFFDA,
        /// <summary>
        /// The function 30 key
        /// </summary>
        IME_KEY_F30 = 0xFFDB,
        /// <summary>
        /// The function 31 key
        /// </summary>
        IME_KEY_F31 = 0xFFDC,
        /// <summary>
        /// The function 32 key
        /// </summary>
        IME_KEY_F32 = 0xFFDD,
        /// <summary>
        /// The function 33 key
        /// </summary>
        IME_KEY_F33 = 0xFFDE,
        /// <summary>
        /// The function 34 key
        /// </summary>
        IME_KEY_F34 = 0xFFDF,
        /// <summary>
        /// The function 35 key
        /// </summary>
        IME_KEY_F35 = 0xFFE0,

        /* Modifier keys */
        /// <summary>
        /// The left shift key
        /// </summary>
        IME_KEY_Shift_L = 0xFFE1,
        /// <summary>
        /// The right shift key
        /// </summary>
        IME_KEY_Shift_R = 0xFFE2,
        /// <summary>
        /// The left control key
        /// </summary>
        IME_KEY_Control_L = 0xFFE3,
        /// <summary>
        /// The right control key
        /// </summary>
        IME_KEY_Control_R = 0xFFE4,
        /// <summary>
        /// The caps lock key
        /// </summary>
        IME_KEY_Caps_Lock = 0xFFE5,
        /// <summary>
        /// The shift lock key
        /// </summary>
        IME_KEY_Shift_Lock = 0xFFE6,
        /// <summary>
        /// The left meta key
        /// </summary>
        IME_KEY_Meta_L = 0xFFE7,
        /// <summary>
        /// The right meta key
        /// </summary>
        IME_KEY_Meta_R = 0xFFE8,
        /// <summary>
        /// The left alt key
        /// </summary>
        IME_KEY_Alt_L = 0xFFE9,
        /// <summary>
        /// The right alt key
        /// </summary>
        IME_KEY_Alt_R = 0xFFEA,
        /// <summary>
        /// The left super key
        /// </summary>
        IME_KEY_Super_L = 0xFFEB,
        /// <summary>
        /// The right super key
        /// </summary>
        IME_KEY_Super_R = 0xFFEC,
        /// <summary>
        /// The left hyper key
        /// </summary>
        IME_KEY_Hyper_L = 0xFFED,
        /// <summary>
        /// The right hyper key
        /// </summary>
        IME_KEY_Hyper_R = 0xFFEE,

        /* Latin 1 */
        /// <summary>
        /// The space key
        /// </summary>
        IME_KEY_space = 0x020,
        /// <summary>
        /// The exclamation key
        /// </summary>
        IME_KEY_exclam = 0x021,
        /// <summary>
        /// The quotedbl key
        /// </summary>
        IME_KEY_quotedbl = 0x022,
        /// <summary>
        /// The number sign key
        /// </summary>
        IME_KEY_numbersign = 0x023,
        /// <summary>
        /// The dollar key
        /// </summary>
        IME_KEY_dollar = 0x024,
        /// <summary>
        /// The percent key
        /// </summary>
        IME_KEY_percent = 0x025,
        /// <summary>
        /// The ampersand key
        /// </summary>
        IME_KEY_ampersand = 0x026,
        /// <summary>
        /// The apostrophe key
        /// </summary>
        IME_KEY_apostrophe = 0x027,
        /// <summary>
        /// The parenleft key
        /// </summary>
        IME_KEY_parenleft = 0x028,
        /// <summary>
        /// The parenright key
        /// </summary>
        IME_KEY_parenright = 0x029,
        /// <summary>
        /// The asterisk key
        /// </summary>
        IME_KEY_asterisk = 0x02a,
        /// <summary>
        /// The plus key
        /// </summary>
        IME_KEY_plus = 0x02b,
        /// <summary>
        /// The comma key
        /// </summary>
        IME_KEY_comma = 0x02c,
        /// <summary>
        /// The minus key
        /// </summary>
        IME_KEY_minus = 0x02d,
        /// <summary>
        /// The period key
        /// </summary>
        IME_KEY_period = 0x02e,
        /// <summary>
        /// The slash key
        /// </summary>
        IME_KEY_slash = 0x02f,
        /// <summary>
        /// The 0 key
        /// </summary>
        IME_KEY_0 = 0x030,
        /// <summary>
        /// The 1 key
        /// </summary>
        IME_KEY_1 = 0x031,
        /// <summary>
        /// The 2 key
        /// </summary>
        IME_KEY_2 = 0x032,
        /// <summary>
        /// The 3 key
        /// </summary>
        IME_KEY_3 = 0x033,
        /// <summary>
        /// The 4 key
        /// </summary>
        IME_KEY_4 = 0x034,
        /// <summary>
        /// The 5 key
        /// </summary>
        IME_KEY_5 = 0x035,
        /// <summary>
        /// The 6 key
        /// </summary>
        IME_KEY_6 = 0x036,
        /// <summary>
        /// The 7 key
        /// </summary>
        IME_KEY_7 = 0x037,
        /// <summary>
        /// The 8 key
        /// </summary>
        IME_KEY_8 = 0x038,
        /// <summary>
        /// The 9 key
        /// </summary>
        IME_KEY_9 = 0x039,
        /// <summary>
        /// The colon key
        /// </summary>
        IME_KEY_colon = 0x03a,
        /// <summary>
        /// The semicolon key
        /// </summary>
        IME_KEY_semicolon = 0x03b,
        /// <summary>
        /// The less key
        /// </summary>
        IME_KEY_less = 0x03c,
        /// <summary>
        /// The equal key
        /// </summary>
        IME_KEY_equal = 0x03d,
        /// <summary>
        /// The greater key
        /// </summary>
        IME_KEY_greater = 0x03e,
        /// <summary>
        /// The question key
        /// </summary>
        IME_KEY_question = 0x03f,
        /// <summary>
        /// The at key
        /// </summary>
        IME_KEY_at = 0x040,
        /// <summary>
        /// The A key
        /// </summary>
        IME_KEY_A = 0x041,
        /// <summary>
        /// The B key
        /// </summary>
        IME_KEY_B = 0x042,
        /// <summary>
        /// The C key
        /// </summary>
        IME_KEY_C = 0x043,
        /// <summary>
        /// The D key
        /// </summary>
        IME_KEY_D = 0x044,
        /// <summary>
        /// The E key
        /// </summary>
        IME_KEY_E = 0x045,
        /// <summary>
        /// The F key
        /// </summary>
        IME_KEY_F = 0x046,
        /// <summary>
        /// The G key
        /// </summary>
        IME_KEY_G = 0x047,
        /// <summary>
        /// The H key
        /// </summary>
        IME_KEY_H = 0x048,
        /// <summary>
        /// The I key
        /// </summary>
        IME_KEY_I = 0x049,
        /// <summary>
        /// The J key
        /// </summary>
        IME_KEY_J = 0x04a,
        /// <summary>
        /// The K key
        /// </summary>
        IME_KEY_K = 0x04b,
        /// <summary>
        /// The L key
        /// </summary>
        IME_KEY_L = 0x04c,
        /// <summary>
        /// The M key
        /// </summary>
        IME_KEY_M = 0x04d,
        /// <summary>
        /// The N key
        /// </summary>
        IME_KEY_N = 0x04e,
        /// <summary>
        /// The O key
        /// </summary>
        IME_KEY_O = 0x04f,
        /// <summary>
        /// The P key
        /// </summary>
        IME_KEY_P = 0x050,
        /// <summary>
        /// The Q key
        /// </summary>
        IME_KEY_Q = 0x051,
        /// <summary>
        /// The R key
        /// </summary>
        IME_KEY_R = 0x052,
        /// <summary>
        /// The S key
        /// </summary>
        IME_KEY_S = 0x053,
        /// <summary>
        /// The T key
        /// </summary>
        IME_KEY_T = 0x054,
        /// <summary>
        /// The U key
        /// </summary>
        IME_KEY_U = 0x055,
        /// <summary>
        /// The V key
        /// </summary>
        IME_KEY_V = 0x056,
        /// <summary>
        /// The W key
        /// </summary>
        IME_KEY_W = 0x057,
        /// <summary>
        /// The X key
        /// </summary>
        IME_KEY_X = 0x058,
        /// <summary>
        /// The Y key
        /// </summary>
        IME_KEY_Y = 0x059,
        /// <summary>
        /// The Z key
        /// </summary>
        IME_KEY_Z = 0x05a,
        /// <summary>
        /// The left bracket key
        /// </summary>
        IME_KEY_bracketleft = 0x05b,
        /// <summary>
        /// The backslash key
        /// </summary>
        IME_KEY_backslash = 0x05c,
        /// <summary>
        /// The right bracket key
        /// </summary>
        IME_KEY_bracketright = 0x05d,
        /// <summary>
        /// The circumflex key
        /// </summary>
        IME_KEY_asciicircum = 0x05e,
        /// <summary>
        /// The underscore key
        /// </summary>
        IME_KEY_underscore = 0x05f,
        /// <summary>
        /// The grave key
        /// </summary>
        IME_KEY_grave = 0x060,
        /// <summary>
        /// The a key
        /// </summary>
        IME_KEY_a = 0x061,
        /// <summary>
        /// The b key
        /// </summary>
        IME_KEY_b = 0x062,
        /// <summary>
        /// The c key
        /// </summary>
        IME_KEY_c = 0x063,
        /// <summary>
        /// The d key
        /// </summary>
        IME_KEY_d = 0x064,
        /// <summary>
        /// The e key
        /// </summary>
        IME_KEY_e = 0x065,
        /// <summary>
        /// The f key
        /// </summary>
        IME_KEY_f = 0x066,
        /// <summary>
        /// The g key
        /// </summary>
        IME_KEY_g = 0x067,
        /// <summary>
        /// The h key
        /// </summary>
        IME_KEY_h = 0x068,
        /// <summary>
        /// The i key
        /// </summary>
        IME_KEY_i = 0x069,
        /// <summary>
        /// The j key
        /// </summary>
        IME_KEY_j = 0x06a,
        /// <summary>
        /// The k key
        /// </summary>
        IME_KEY_k = 0x06b,
        /// <summary>
        /// The l key
        /// </summary>
        IME_KEY_l = 0x06c,
        /// <summary>
        /// The m key
        /// </summary>
        IME_KEY_m = 0x06d,
        /// <summary>
        /// The n key
        /// </summary>
        IME_KEY_n = 0x06e,
        /// <summary>
        /// The o key
        /// </summary>
        IME_KEY_o = 0x06f,
        /// <summary>
        /// The p key
        /// </summary>
        IME_KEY_p = 0x070,
        /// <summary>
        /// The q key
        /// </summary>
        IME_KEY_q = 0x071,
        /// <summary>
        /// The r key
        /// </summary>
        IME_KEY_r = 0x072,
        /// <summary>
        /// The s key
        /// </summary>
        IME_KEY_s = 0x073,
        /// <summary>
        /// The t key
        /// </summary>
        IME_KEY_t = 0x074,
        /// <summary>
        /// The u key
        /// </summary>
        IME_KEY_u = 0x075,
        /// <summary>
        /// The v key
        /// </summary>
        IME_KEY_v = 0x076,
        /// <summary>
        /// The w key
        /// </summary>
        IME_KEY_w = 0x077,
        /// <summary>
        /// The x key
        /// </summary>
        IME_KEY_x = 0x078,
        /// <summary>
        /// The y key
        /// </summary>
        IME_KEY_y = 0x079,
        /// <summary>
        /// The z key
        /// </summary>
        IME_KEY_z = 0x07a,
        /// <summary>
        /// The left brace key
        /// </summary>
        IME_KEY_braceleft = 0x07b,
        /// <summary>
        /// The bar key
        /// </summary>
        IME_KEY_bar = 0x07c,
        /// <summary>
        /// The right brace key
        /// </summary>
        IME_KEY_braceright = 0x07d,
        /// <summary>
        /// The tilde key
        /// </summary>
        IME_KEY_asciitilde = 0x07e,
    };

    /// <summary>
    /// Enumeration of the key masks.
    /// The key masks indicate which modifier keys is pressed down during the keyboard hit.The special IME_KEY_MASK_RELEASED indicates the key release event.
    /// </summary>
    public enum KeyMask
    {
        /// <summary>
        /// Key press event without modifier key
        /// </summary>
        IME_KEY_MASK_PRESSED = 0,
        /// <summary>
        /// The Shift key is pressed down
        /// </summary>
        IME_KEY_MASK_SHIFT = (1 << 0),
        /// <summary>
        /// The CapsLock key is pressed down
        /// </summary>
        IME_KEY_MASK_CAPSLOCK = (1 << 1),
        /// <summary>
        /// The Control key is pressed down
        /// </summary>
        IME_KEY_MASK_CONTROL = (1 << 2),
        /// <summary>
        /// The Alt key is pressed down
        /// </summary>
        IME_KEY_MASK_ALT = (1 << 3),
        /// <summary>
        /// The Meta key is pressed down
        /// </summary>
        IME_KEY_MASK_META = (1 << 4),
        /// <summary>
        /// The Win (between Control and Alt) is pressed down
        /// </summary>
        IME_KEY_MASK_WIN = (1 << 5),
        /// <summary>
        /// The Hyper key is pressed down
        /// </summary>
        IME_KEY_MASK_HYPER = (1 << 6),
        /// <summary>
        /// The NumLock key is pressed down
        /// </summary>
        IME_KEY_MASK_NUMLOCK = (1 << 7),
        /// <summary>
        /// Key release event
        /// </summary>
        IME_KEY_MASK_RELEASED = (1 << 15),
    }

    /// <summary>
    /// This class contains api's related to IME(Input method editor)
    /// </summary>
    public static class InputMethodEditor
    {
        private static Object thisLock = new Object();
        private static ImeCallbackStructGCHandle _imeCallbackStructGCHandle = new ImeCallbackStructGCHandle();
        private static event EventHandler<FocusInEventArgs> _focusIn;
        private static ImeFocusInCb _imeFocusInDelegate;
        private static event EventHandler<FocusOutEventArgs> _focusOut;
        private static ImeFocusOutCb _imeFocusOutDelegate;
        private static event EventHandler<SurroundingTextUpdatedEventArgs> _surroundingTextUpdated;
        private static ImeSurroundingTextUpdatedCb _imeSurroundingTextUpdatedDelegate;
        private static event EventHandler<System.EventArgs> _inputContextReset;
        private static ImeInputContextResetCb _imeInputContextResetDelegate;
        private static event EventHandler<CursorPositionUpdatedEventArgs> _cursorPositionUpdated;
        private static ImeCursorPositionUpdatedCb _imeCursorPositionUpdatedDelegate;
        private static event EventHandler<LangaugeSetEventArgs> _langaugeSet;
        private static ImeLanguageSetCb _imeLangaugeSetDelegate;
        private static event EventHandler<ImDataSetEventArgs> _imDataSet;
        private static ImeImdataSetCb _imeImDataSetDelegate;
        private static event EventHandler<LayoutSetEventArgs> _layoutSet;
        private static ImeLayoutSetCb _imeLayoutSetDelegate;
        private static event EventHandler<ReturnKeyTypeSetEventArgs> _returnKeyTypeSet;
        private static ImeReturnKeyTypeSetCb _imeReturnKeyTypeSetDelegate;
        private static event EventHandler<ReturnKeyStateSetEventArgs> _returnKeyStateSet;
        private static ImeReturnKeyStateSetCb _imeReturnKeyStateSetDelegate;
        private static event ProcessKeyEventHandler _processKey;
        private static ImeProcessKeyEventCb _imeProcessKeyDelegate;
        private static event EventHandler<DisplayLanaguageChangedEventArgs> _displayLanaguageChanged;
        private static ImeDisplayLanguageChangedCb _imeDisplayLanaguageChangedDelegate;
        private static event EventHandler<RotationDegreeChangedEventArgs> _rotationDegreeChanged;
        private static ImeRotationDegreeChangedCb _imeRotationDegreeChangedDelegate;
        private static event EventHandler<AccessibilityStateChangedEventArgs> _accessibilityStateChanged;
        private static ImeAccessibilityStateChangedCb _imeAccessibilityStateChangedDelegate;
        private static event EventHandler<OptionWindowCreatedEventArgs> _optionWindowCreated;
        private static ImeOptionWindowCreatedCb _imeOptionWindowCreatedDelegate;
        private static event EventHandler<OptionWindowDestroyedEventArgs> _optionWindowDestroyed;
        private static ImeOptionWindowDestroyedCb _imeOptionWindowDestroyedDelegate;
        private static ImeLanguageRequestedCb _imeLanguageRequestedDelegate;
        private static OutAction<string> _languageRequestedDelegate;
        private static ImeImdataRequestedCb _imeImDataRequestedDelegate;
        private static OutAction<byte, uint> _imDataRequestedDelegate;
        private static ImeGeometryRequestedCb _imeGeometryRequestedDelegate;
        private static OutAction1<int> _geometryRequestedDelegate;
        private static Action _userCreate;
        private static Action _userTerminate;
        private static Action<int, InputMethodContext> _userShow;
        private static Action<int> _userHide;
        private static ImeCreateCb _create = (IntPtr userData) =>
        {
            Log.Info(LogTag, "In Create Delegate");
            _userCreate?.Invoke();
        };
        private static ImeTerminateCb _terminate = (IntPtr userData) =>
        {
            Log.Info(LogTag, "In terminate Delegate");
            _userTerminate?.Invoke();
        };
        private static ImeShowCb _show = (int contextId, IntPtr context, IntPtr userData) =>
        {
            Log.Info(LogTag, "In Show Delegate");
            _userShow?.Invoke(contextId, new InputMethodContext(context));
        };
        private static ImeHideCb _hide = (int contextId, IntPtr userData) =>
        {
            Log.Info(LogTag, "In Hide Delegate");
            _userHide?.Invoke(contextId);
        };


        /// <summary>
        /// An Action with 1 out parameter
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="a">The out parameter</param>
        public delegate void OutAction<T>(out T a);

        /// <summary>
        /// An Action with 2 out parameter's
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <typeparam name="T1">Generic Type</typeparam>
        /// <param name="a">The out parameter 1</param>
        /// <param name="b">The out parameter 2</param>
        public delegate void OutAction<T,T1>(out T[] a, out T1 b);

        /// <summary>
        /// An Action with 4 out parameter's
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="a">The out parameter 1</param>
        /// <param name="b">The out parameter 2</param>
        /// <param name="c">The out parameter 3</param>
        /// <param name="d">The out parameter 4</param>
        public delegate void OutAction1<T>(out T a, out T b, out T c, out T d);


        /// <summary>
        /// Called when an associated text input UI control has focus.
        /// </summary>
        public static event EventHandler<FocusInEventArgs> FocusIn
        {
            add
            {
                lock (thisLock)
                {
                    _imeFocusInDelegate = (int contextId, IntPtr userData) =>
                    {
                        FocusInEventArgs args = new FocusInEventArgs(contextId);
                        _focusIn?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetFocusInCb(_imeFocusInDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add FocusIn Failed with error " + error);
                    }
                    else
                    {
                        _focusIn += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _focusIn -= value;
                }
            }
        }

        /// <summary>
        /// Called when an associated text input UI control loses focus.
        /// </summary>
        public static event EventHandler<FocusOutEventArgs> FocusOut
        {
            add
            {
                lock (thisLock)
                {
                    _imeFocusOutDelegate = (int contextId, IntPtr userData) =>
                    {
                        FocusOutEventArgs args = new FocusOutEventArgs(contextId);
                        _focusOut?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetFocusOutCb(_imeFocusOutDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add FocusOut Failed with error " + error);
                    }
                    else
                    {
                        _focusOut += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _focusOut -= value;
                }
            }
        }

        /// <summary>
        /// Called when an associated text input UI control responds to a request with the surrounding text.
        /// </summary>
        public static event EventHandler<SurroundingTextUpdatedEventArgs> SurroundingTextUpdated
        {
            add
            {
                lock (thisLock)
                {
                    _imeSurroundingTextUpdatedDelegate = (int contextId, IntPtr text, int cursorPos, IntPtr userData) =>
                    {
                        SurroundingTextUpdatedEventArgs args = new SurroundingTextUpdatedEventArgs(contextId, Marshal.PtrToStringAnsi(text), cursorPos);
                        _surroundingTextUpdated?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetSurroundingTextUpdatedCb(_imeSurroundingTextUpdatedDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add SurroundingTextUpdated Failed with error " + error);
                    }
                    else
                    {
                        _surroundingTextUpdated += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _surroundingTextUpdated -= value;
                }
            }
        }

        /// <summary>
        /// Called to reset the input context of an associated text input UI control.
        /// </summary>
        public static event EventHandler<System.EventArgs> InputContextReset
        {
            add
            {
                lock (thisLock)
                {
                    _imeInputContextResetDelegate = (IntPtr userData) =>
                    {
                        _inputContextReset?.Invoke(null, System.EventArgs.Empty);
                    };
                    ErrorCode error = ImeEventSetInputContextResetCb(_imeInputContextResetDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add InputContextReset Failed with error " + error);
                    }
                    else
                    {
                        _inputContextReset += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _inputContextReset -= value;
                }
            }
        }

        /// <summary>
        /// Called when the position of the cursor in an associated text input UI control changes.
        /// </summary>
        public static event EventHandler<CursorPositionUpdatedEventArgs> CursorPositionUpdated
        {
            add
            {
                lock (thisLock)
                {
                    _imeCursorPositionUpdatedDelegate = (int cursorPos, IntPtr userData) =>
                    {
                        CursorPositionUpdatedEventArgs args = new CursorPositionUpdatedEventArgs(cursorPos);
                        _cursorPositionUpdated?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetCursorPositionUpdatedCb(_imeCursorPositionUpdatedDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add CursorPositionUpdated Failed with error " + error);
                    }
                    else
                    {
                        _cursorPositionUpdated += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _cursorPositionUpdated -= value;
                }
            }
        }

        /// <summary>
        /// Called to set the preferred language to the input panel.
        /// It will be only called when the client application changes the edit field's language attribute after the input panel is shown.
        /// </summary>
        public static event EventHandler<LangaugeSetEventArgs> LangaugeSet
        {
            add
            {
                lock (thisLock)
                {
                    _imeLangaugeSetDelegate = (EcoreIMFInputPanelLang language, IntPtr userData) =>
                    {
                        LangaugeSetEventArgs args = new LangaugeSetEventArgs(language);
                        _langaugeSet?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetLanguageSetCb(_imeLangaugeSetDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add LangaugeSet Failed with error " + error);
                    }
                    else
                    {
                        _langaugeSet += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _langaugeSet -= value;
                }
            }
        }

        /// <summary>
        /// Called to set the application specific data to deliver to the input panel.
        /// </summary>
        public static event EventHandler<ImDataSetEventArgs> ImDataSet
        {
            add
            {
                lock (thisLock)
                {
                    _imeImDataSetDelegate = (IntPtr data, uint dataLength, IntPtr userData) =>
                    {
                        byte[] destination = new byte[dataLength];
                        Marshal.Copy(data, destination, 0, (int)dataLength);
                        ImDataSetEventArgs args = new ImDataSetEventArgs(destination, dataLength);
                        _imDataSet?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetImdataSetCb(_imeImDataSetDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add ImDataSet Failed with error " + error);
                    }
                    else
                    {
                        _imDataSet += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _imDataSet -= value;
                }
            }
        }

        /// <summary>
        /// Called when an associated text input UI control requests the input panel to set its layout.
        /// It will be only called when the client application changes the edit field's layout attribute after the input panel is shown.
        /// </summary>
        public static event EventHandler<LayoutSetEventArgs> LayoutSet
        {
            add
            {
                lock (thisLock)
                {
                    _imeLayoutSetDelegate = (EcoreIMFInputPanelLayout layout, IntPtr userData) =>
                    {
                        LayoutSetEventArgs args = new LayoutSetEventArgs(layout);
                        _layoutSet?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetLayoutSetCb(_imeLayoutSetDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add LayoutSet Failed with error " + error);
                    }
                    else
                    {
                        _layoutSet += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _layoutSet -= value;
                }
            }
        }

        /// <summary>
        /// Called when an associated text input UI control requests the input panel to set the Return key label.
        /// The input panel can show text or image on the Return button according to the Return key action.
        /// </summary>
        public static event EventHandler<ReturnKeyTypeSetEventArgs> ReturnKeyTypeSet
        {
            add
            {
                lock (thisLock)
                {
                    _imeReturnKeyTypeSetDelegate = (EcoreIMFInputPanelReturnKeyType type, IntPtr userData) =>
                    {
                        ReturnKeyTypeSetEventArgs args = new ReturnKeyTypeSetEventArgs(type);
                        _returnKeyTypeSet?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetReturnKeyTypeSetCb(_imeReturnKeyTypeSetDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add ReturnKeyTypeSet Failed with error " + error);
                    }
                    else
                    {
                        _returnKeyTypeSet += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _returnKeyTypeSet -= value;
                }
            }
        }

        /// <summary>
        /// Called when an associated text input UI control requests the input panel to enable or disable the Return key state.
        /// </summary>
        public static event EventHandler<ReturnKeyStateSetEventArgs> ReturnKeyStateSet
        {
            add
            {
                lock (thisLock)
                {
                    _imeReturnKeyStateSetDelegate = (bool state, IntPtr userData) =>
                    {
                        ReturnKeyStateSetEventArgs args = new ReturnKeyStateSetEventArgs(state);
                        _returnKeyStateSet?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetReturnKeyStateSetCb(_imeReturnKeyStateSetDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add ReturnKeyStateSet Failed with error " + error);
                    }
                    else
                    {
                        _returnKeyStateSet += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _returnKeyStateSet -= value;
                }
            }
        }

        /// <summary>
        /// This Handler is associated with ProcessKey
        /// </summary>
        /// <param name="sender">The object raising the event</param>
        /// <param name="e">An object of ProcessKeyEventArgs class</param>
        /// <returns>true if the event is processed, otherwise the event is not processed and is forwarded to the client application.</returns>
        public delegate bool ProcessKeyEventHandler(object sender, ProcessKeyEventArgs e);

        /// <summary>
        /// Called when the key event is received from the external devices or SendKey function.
        /// This Event processes the key event before an associated text input UI control does.
        /// </summary>
        /// <remarks>
        /// If the key event is from the external device, DeviceInfo will have its name, class and subclass information.
        /// </remarks>
        public static event ProcessKeyEventHandler ProcessKey
        {
            add
            {
                lock (thisLock)
                {
                    _imeProcessKeyDelegate = (KeyCode keycode, KeyMask keymask, IntPtr devInfo, IntPtr userData) =>
                    {
                        ProcessKeyEventArgs args = new ProcessKeyEventArgs(keycode, keymask, devInfo);
                        bool res = _processKey.Invoke(null, args);
                        return res;
                    };
                    ErrorCode error = ImeEventSetProcessKeyEventCb(_imeProcessKeyDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add ProcessKey Failed with error " + error);
                    }
                    else
                    {
                        _processKey += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _processKey -= value;
                }
            }
        }

        /// <summary>
        /// Called when the system display language is changed.
        /// </summary>
        public static event EventHandler<DisplayLanaguageChangedEventArgs> DisplayLanaguageChanged
        {
            add
            {
                lock (thisLock)
                {
                    _imeDisplayLanaguageChangedDelegate = (IntPtr language, IntPtr userData) =>
                    {
                        DisplayLanaguageChangedEventArgs args = new DisplayLanaguageChangedEventArgs(Marshal.PtrToStringAnsi(language));
                        _displayLanaguageChanged?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetDisplayLanguageChangedCb(_imeDisplayLanaguageChangedDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add DisplayLanaguageChanged Failed with error " + error);
                    }
                    else
                    {
                        _displayLanaguageChanged += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _displayLanaguageChanged -= value;
                }
            }
        }

        /// <summary>
        /// Called when the device is rotated.
        /// </summary>
        public static event EventHandler<RotationDegreeChangedEventArgs> RotationDegreeChanged
        {
            add
            {
                lock (thisLock)
                {
                    _imeRotationDegreeChangedDelegate = (int degree, IntPtr userData) =>
                    {
                        RotationDegreeChangedEventArgs args = new RotationDegreeChangedEventArgs(degree);
                        _rotationDegreeChanged?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetRotationDegreeChangedCb(_imeRotationDegreeChangedDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add RotationDegreeChanged Failed with error " + error);
                    }
                    else
                    {
                        _rotationDegreeChanged += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _rotationDegreeChanged -= value;
                }
            }
        }

        /// <summary>
        /// Called when Accessibility in Settings application is on or off.
        /// </summary>
        public static event EventHandler<AccessibilityStateChangedEventArgs> AccessibilityStateChanged
        {
            add
            {
                lock (thisLock)
                {
                    _imeAccessibilityStateChangedDelegate = (bool state, IntPtr userData) =>
                    {
                        AccessibilityStateChangedEventArgs args = new AccessibilityStateChangedEventArgs(state);
                        _accessibilityStateChanged?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetAccessibilityStateChangedCb(_imeAccessibilityStateChangedDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add AccessibilityStateChanged Failed with error " + error);
                    }
                    else
                    {
                        _accessibilityStateChanged += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _accessibilityStateChanged -= value;
                }
            }
        }

        /// <summary>
        /// Called to create the option window.
        /// </summary>
        /// <remarks>
        /// if Input panel requests to open the option window, type will be ImeOptionWindowType.Keyboard.
        /// And if Settings application requests to open it, type will be ImeOptionWindowType.SettingApplication.
        /// </remarks>
        public static event EventHandler<OptionWindowCreatedEventArgs> OptionWindowCreated
        {
            add
            {
                lock (thisLock)
                {
                    _imeOptionWindowCreatedDelegate = (IntPtr window, ImeOptionWindowType type, IntPtr userData) =>
                    {
                        OptionWindowCreatedEventArgs args = new OptionWindowCreatedEventArgs(new EditorWindow(window), type);
                        _optionWindowCreated?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetOptionWindowCreatedCb(_imeOptionWindowCreatedDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add OptionWindowCreated Failed with error " + error);
                    }
                    else
                    {
                        _optionWindowCreated += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _optionWindowCreated -= value;
                }
            }
        }

        /// <summary>
        /// Called to destroy the option window.
        /// </summary>
        public static event EventHandler<OptionWindowDestroyedEventArgs> OptionWindowDestroyed
        {
            add
            {
                lock (thisLock)
                {
                    _imeOptionWindowDestroyedDelegate = (IntPtr window, IntPtr userData) =>
                    {
                        OptionWindowDestroyedEventArgs args = new OptionWindowDestroyedEventArgs(new EditorWindow(window));
                        _optionWindowDestroyed?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetOptionWindowDestroyedCb(_imeOptionWindowDestroyedDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add OptionWindowDestroyed Failed with error " + error);
                    }
                    else
                    {
                        _optionWindowDestroyed += value;
                    }
                }
            }
            remove
            {
                lock (thisLock)
                {
                    _optionWindowDestroyed -= value;
                }
            }
        }

        /// <summary>
        /// Sets the languageRequested Action
        /// </summary>
        /// <param name="languageRequested">
        /// Called when an associated text input UI control requests the language from the input panel, requesting for language code.
        /// </param>
        public static void SetLanguageRequested(OutAction<string> languageRequested)
        {
            _imeLanguageRequestedDelegate = (IntPtr userData, out IntPtr langCode) =>
            {
                string langauage;
                _languageRequestedDelegate(out langauage);
                char[] languageArray = langauage.ToCharArray();
                langCode = new IntPtr();
                Marshal.Copy(languageArray, 0, langCode, languageArray.Length);
            };
            ErrorCode error = ImeEventSetLanguageRequestedCb(_imeLanguageRequestedDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Add SetLanguageRequested Failed with error " + error);
            }
            _languageRequestedDelegate = languageRequested;
        }

        /// <summary>
        /// Sets the imDataRequested Action
        /// </summary>
        /// <param name="imDataRequested">
        /// Called when an associated text input UI control requests the application specific data from the input panel, requesting for data array and it's length.
        /// </param>
        public static void SetImDataRequested(OutAction<byte, uint> imDataRequested)
        {
            _imeImDataRequestedDelegate = (IntPtr userData, out IntPtr data, out uint dataLength) =>
            {
                byte[] dataArr;
                uint lenghtArr;
                _imDataRequestedDelegate(out dataArr, out lenghtArr);
                data = new IntPtr();
                Marshal.Copy(dataArr, 0, data, (int)lenghtArr);
                dataLength = lenghtArr;
            };
            ErrorCode error = ImeEventSetImdataRequestedCb(_imeImDataRequestedDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Add SetImDataRequested Failed with error " + error);
            }
            _imDataRequestedDelegate = imDataRequested;
        }

        /// <summary>
        /// Sets the GeometryRequested Action
        /// </summary>
        /// <param name="GeometryRequested">
        /// Called when an associated text input UI control requests the position and size from the input panel, requesting for x,y,w,h values.
        /// </param>
        public static void SetGeometryRequested(OutAction1<int> GeometryRequested)
        {
            _imeGeometryRequestedDelegate = (IntPtr userData, out int x, out int y, out int w, out int h) =>
            {
                int x1, y1, w1, h1;
                _geometryRequestedDelegate(out x1, out y1, out w1, out h1);
                x = x1;
                y = y1;
                w = w1;
                h = h1;
            };
            ErrorCode error = ImeEventSetGeometryRequestedCb(_imeGeometryRequestedDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Add SetGeometryRequested Failed with error " + error);
            }
            _geometryRequestedDelegate = GeometryRequested;
        }

        /// <summary>
        /// Runs the main loop of IME application.
        /// This function starts to run IME application's main loop.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <param name="create">This is called to initialize IME application before the main loop starts up</param>
        /// <param name="terminate">This is called when IME application is terminated</param>
        /// <param name="show">This is called when IME application is shown</param>
        /// <param name="hide">This is called when IME application is hidden</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) Operation failed
        /// </exception>
        public static void Run(Action create, Action terminate, Action<int, InputMethodContext> show, Action<int> hide)
        {
            _userCreate = create;
            _userTerminate = terminate;
            _userShow = show;
            _userHide = hide;

            ImeCallbackStruct _imeCallbackStruct = _imeCallbackStructGCHandle._imeCallbackStruct;
            _imeCallbackStruct.create = _create;
            _imeCallbackStruct.terminate = _terminate;
            _imeCallbackStruct.hide = _hide;
            _imeCallbackStruct.show = _show;

            ErrorCode error = ImeRun(GCHandle.ToIntPtr(_imeCallbackStructGCHandle._imeCallbackStructHandle), IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Run Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Sends a key event to the associated text input UI control.
        /// </summary>
        /// <remarks>
        /// This function sends key down or up event with key mask to the client application. If forwardKey is true, this key event goes to the edit filed directly.
        /// And if forwardKey is false, the ProcessKey event receives the key event before the edit field.
        /// </remarks>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <param name="keyCode">The key code to be sent</param>
        /// <param name="keyMask">The modifier key mask</param>
        /// <param name="forwardKey">The flag to send the key event directly to the edit field</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// </exception>
        public static void SendKeyEvent(KeyCode keyCode, KeyMask keyMask, bool forwardKey)
        {
            ErrorCode error = ImeSendKeyEvent(keyCode, keyMask, forwardKey);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SendEvent Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Sends the text to the associated text input UI control.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <param name="str">The UTF-8 string to be committed</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// </exception>
        public static void CommitString(string str)
        {
            ErrorCode error = ImeCommitString(str);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "CommitString Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Requests to show preedit string.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// </exception>
        public static void ShowPreEditString()
        {
            ErrorCode error = ImeShowPreeditString();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "ShowPreEditString Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Requests to hide preedit string.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// </exception>
        public static void HidePreEditString()
        {
            ErrorCode error = ImeHidePreeditString();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "HidePreEditString Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Updates a new preedit string.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <param name="str">The UTF-8 string to be updated in preedit</param>
        /// <param name="attrs">
        /// The list which has ime_preedit_attribute lists, strings can be composed of multiple string attributes: underline, highlight color and reversal color.
        /// The attrs can be null if no attributes to set
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// 3) Invalid Parameter
        /// </exception>
        public static void UpdatePreEditString(string str, List<PreEditAttribute> attrs)
        {
            IntPtr einaList = IntPtr.Zero;
            GCHandle einaListHandle = GCHandle.Alloc(einaList);
            List<GCHandle> attributeHandleList = new List<GCHandle>();
            foreach (PreEditAttribute attribute in attrs)
            {
                ImePreEditAttributeStruct imePreEditAttribute = new ImePreEditAttributeStruct();
                imePreEditAttribute.start = attribute.Start;
                imePreEditAttribute.length = attribute.Length;
                imePreEditAttribute.type = (int)attribute.Type;
                imePreEditAttribute.value = attribute.Value;
                GCHandle attributeHandle = GCHandle.Alloc(imePreEditAttribute);
                attributeHandleList.Add(attributeHandle);
                einaList = Interop.EinaList.EinaListAppend(einaListHandle.AddrOfPinnedObject(),attributeHandle.AddrOfPinnedObject());
            }
            ErrorCode error = ImeUpdatePreeditString(str, einaListHandle.AddrOfPinnedObject());
            einaListHandle.Free();
            foreach(GCHandle handle in attributeHandleList)
            {
                handle.Free();
            }
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "UpdatePreEditString Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Requests the surrounding text from the position of the cursor, asynchronously.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <param name="maxLenBefore">The maximum length of string to be retrieved before the cursor, -1 means unlimited</param>
        /// <param name="maxLenAfter">The maximum length of string to be retrieved after the cursor, -1 means unlimited</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// </exception>
        public static void RequestSurroundingText(int maxLenBefore, int maxLenAfter)
        {
            ErrorCode error = ImeRequestSurroundingText(maxLenBefore, maxLenAfter);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "RequestSurroundingText Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Requests to delete surrounding text.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <param name="offset">The offset value from the cursor position</param>
        /// <param name="len">The length of the text to delete</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// 3) Invalid Parameter
        /// </exception>
        public static void DeleteSurroundingText(int offset, int len)
        {
            ErrorCode error = ImeDeleteSurroundingText(offset, len);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "DeleteSurroundingText Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Gets the surrounding text from the position of the cursor, synchronously.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <param name="maxLenBefore">The maximum length of string to be retrieved before the cursor, -1 means unlimited</param>
        /// <param name="maxLenAfter">The maximum length of string to be retrieved after the cursor, -1 means unlimited</param>
        /// <param name="text">The surrounding text</param>
        /// <param name="cursorPosition">The cursor position</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// 3) Invalid Parameter
        /// 4) Failed to obtain text due to out of memory
        /// </exception>
        public static void GetSurroundingText(int maxLenBefore, int maxLenAfter, out string text, out int cursorPosition)
        {
            IntPtr txt;
            ErrorCode error = ImeGetSurroundingText(maxLenBefore, maxLenAfter, out txt, out cursorPosition);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetSurroundingText Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
            text = Marshal.PtrToStringAnsi(txt);
        }

        /// <summary>
        /// Requests to set selection.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <param name="start">The start cursor position in text (in characters not bytes)</param>
        /// <param name="end">The end cursor position in text (in characters not bytes)</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// 3) Invalid Parameter
        /// </exception>
        public static void SetSelection(int start, int end)
        {
            ErrorCode error = ImeSetSelection(start, end);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetSelection Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// This API returns the input panel main window.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <returns>The input panel main window object on success, otherwise null</returns>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// 3) Operation Failed
        /// </exception>
        public static EditorWindow GetMainWindow()
        {
            EditorWindow obj = new EditorWindow(ImeGetMainWindow());
            ErrorCode error = (ErrorCode)Tizen.Internals.Errors.ErrorFacts.GetLastResult();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetMainWindow Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
            return obj;
        }

        /// <summary>
        /// This API updates the input panel window's size information.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <param name="portraitWidth">The width in portrait mode</param>
        /// <param name="portraitHeight">The height in portrait mode</param>
        /// <param name="landscapeWidth">The width in landscape mode</param>
        /// <param name="landscapeHeight">The height in landscape mode</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// </exception>
        public static void SetSize(int portraitWidth, int portraitHeight, int landscapeWidth, int landscapeHeight)
        {
            ErrorCode error = ImeSetSize(portraitWidth, portraitHeight, landscapeWidth, landscapeHeight);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetSize Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Requests to create an option window from the input panel.
        /// The input panel can call this function to open the option window. This function calls OptionWindowCreated Event with ImeOptionWindowType.Keyboard.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) Operation failed
        /// 3) IME main loop isn't started yet
        /// 4) OptionWindowCreated event has not been set
        /// </exception>
        /// <precondition>
        /// OptionWindowCreated and OptionWindowDestroyed event should be set
        /// </precondition>
        public static void CreateOptionWindow()
        {
            ErrorCode error = ImeCreateOptionWindow();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "CreapteOptionWindow Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Requests to destroy an option window.
        /// The input panel can call this function to close the option window which is created from either the input panel or Settings application.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/ime
        /// </priviledge>
        /// <param name="window">The option window to destroy</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) Invalid Parameter
        /// 3) IME main loop isn't started yet
        /// </exception>
        public static void DestroyOptionWindow(EditorWindow window)
        {
            ErrorCode error = ImeDestroyOptionWindow(window._handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "DestroyOptionWindow Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }
    }
}
