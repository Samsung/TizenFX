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
using System.ComponentModel;
using static Interop.InputMethod;

namespace Tizen.Uix.InputMethod
{
    /// <summary>
    /// Enumeration for the key codes.
    /// If keycode &amp; 0xff000000 == 0x01000000 then this key code is directly encoded to 24-bit UCS character. The UCS value is keycode &amp; 0x00ffffff.
    /// Defines the list of keys supported by the system. Note that certain keys may not be available on all the devices.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum KeyCode
    {
        /// <summary>
        /// The Backspace key.
        /// </summary>
        BackSpace = 0xFF08,
        /// <summary>
        /// The Tab key.
        /// </summary>
        Tab = 0xFF09,
        /// <summary>
        /// The Linefeed key.
        /// </summary>
        Linefeed = 0xFF0A,
        /// <summary>
        /// The Clear key.
        /// </summary>
        Clear = 0xFF0B,
        /// <summary>
        /// The Return key.
        /// </summary>
        Return = 0xFF0D,
        /// <summary>
        /// The Pause key.
        /// </summary>
        Pause = 0xFF13,
        /// <summary>
        /// The Scroll lock key.
        /// </summary>
        ScrollLock = 0xFF14,
        /// <summary>
        /// The System Request key.
        /// </summary>
        SysReq = 0xFF15,
        /// <summary>
        /// The Escape key.
        /// </summary>
        Escape = 0xFF1B,
        /// <summary>
        /// The Delete key.
        /// </summary>
        Delete = 0xFFFF,

        /* Cursor control & motion */
        /// <summary>
        /// The Home key.
        /// </summary>
        Home = 0xFF50,
        /// <summary>
        /// The Left directional key.
        /// </summary>
        Left = 0xFF51,
        /// <summary>
        /// The Up directional key.
        /// </summary>
        Up = 0xFF52,
        /// <summary>
        /// The Right directional key.
        /// </summary>
        Right = 0xFF53,
        /// <summary>
        /// The Down directional key.
        /// </summary>
        Down = 0xFF54,
        /// <summary>
        /// The Prior, Previous key.
        /// </summary>
        Prior = 0xFF55,
        /// <summary>
        /// The Page Up key.
        /// </summary>
        Page_Up = 0xFF55,
        /// <summary>
        /// The Next key.
        /// </summary>
        Next = 0xFF56,
        /// <summary>
        /// The Page Down key.
        /// </summary>
        Page_Down = 0xFF56,
        /// <summary>
        /// The End key.
        /// </summary>
        End = 0xFF57,
        /// <summary>
        /// The Begin key.
        /// </summary>
        Begin = 0xFF58,

        /* Misc Functions */
        /// <summary>
        /// The Select key.
        /// </summary>
        Select = 0xFF60,
        /// <summary>
        /// The Print key.
        /// </summary>
        Print = 0xFF61,
        /// <summary>
        /// The Execute, Run, Do key.
        /// </summary>
        Execute = 0xFF62,
        /// <summary>
        /// The Insert key.
        /// </summary>
        Insert = 0xFF63,
        /// <summary>
        /// The Undo key.
        /// </summary>
        Undo = 0xFF65,
        /// <summary>
        /// The Redo key.
        /// </summary>
        Redo = 0xFF66,
        /// <summary>
        /// The Menu key.
        /// </summary>
        Menu = 0xFF67,
        /// <summary>
        /// The Find key.
        /// </summary>
        Find = 0xFF68,
        /// <summary>
        /// The Cancel, Stop, Abort, Exit key.
        /// </summary>
        Cancel = 0xFF69,
        /// <summary>
        /// The Help key.
        /// </summary>
        Help = 0xFF6A,
        /// <summary>
        /// The Break key.
        /// </summary>
        Break = 0xFF6B,
        /// <summary>
        /// The character set switch key.
        /// </summary>
        Mode_switch = 0xFF7E,
        /// <summary>
        /// The Number Lock key.
        /// </summary>
        Num_Lock = 0xFF7F,

        /* Keypad */
        /// <summary>
        /// The Numpad Space key.
        /// </summary>
        KPSpace = 0xFF80,
        /// <summary>
        /// The Numpad Tab key.
        /// </summary>
        KPTab = 0xFF89,
        /// <summary>
        /// The Numpad Enter key.
        /// </summary>
        KPEnter = 0xFF8D,
        /// <summary>
        /// The Numpad Function 1 key.
        /// </summary>
        KPF1 = 0xFF91,
        /// <summary>
        /// The Numpad Function 2 key.
        /// </summary>
        KPF2 = 0xFF92,
        /// <summary>
        /// The Numpad Function 3 key.
        /// </summary>
        KPF3 = 0xFF93,
        /// <summary>
        /// The Numpad Function 4 key.
        /// </summary>
        KPF4 = 0xFF94,
        /// <summary>
        /// The Numpad Home key.
        /// </summary>
        KPHome = 0xFF95,
        /// <summary>
        /// The Numpad Left key.
        /// </summary>
        KPLeft = 0xFF96,
        /// <summary>
        /// The Numpad Up key.
        /// </summary>
        KPUp = 0xFF97,
        /// <summary>
        /// The Numpad Right key.
        /// </summary>
        KPRight = 0xFF98,
        /// <summary>
        /// The Numpad Down key.
        /// </summary>
        KPDown = 0xFF99,
        /// <summary>
        /// The Numpad Prior, Previous key.
        /// </summary>
        KPPrior = 0xFF9A,
        /// <summary>
        /// The Numpad Page Up key.
        /// </summary>
        KPPage_Up = 0xFF9A,
        /// <summary>
        /// The Numpad Next key.
        /// </summary>
        KPNext = 0xFF9B,
        /// <summary>
        /// The Numpad Page Down key.
        /// </summary>
        KPPage_Down = 0xFF9B,
        /// <summary>
        /// The Numpad End key.
        /// </summary>
        KPEnd = 0xFF9C,
        /// <summary>
        /// The Numpad Begin key.
        /// </summary>
        KPBegin = 0xFF9D,
        /// <summary>
        /// The Numpad Insert key.
        /// </summary>
        KPInsert = 0xFF9E,
        /// <summary>
        /// The Numpad Delete key.
        /// </summary>
        KPDelete = 0xFF9F,
        /// <summary>
        /// The Numpad Equal key.
        /// </summary>
        KPEqual = 0xFFBD,
        /// <summary>
        /// The Numpad Multiply key.
        /// </summary>
        KPMultiply = 0xFFAA,
        /// <summary>
        /// The Numpad Add key.
        /// </summary>
        KPAdd = 0xFFAB,
        /// <summary>
        /// The Numpad Separator key.
        /// </summary>
        KPSeparator = 0xFFAC,
        /// <summary>
        /// The Numpad Subtract key.
        /// </summary>
        KPSubtract = 0xFFAD,
        /// <summary>
        /// The Numpad Decimal key.
        /// </summary>
        KPDecimal = 0xFFAE,
        /// <summary>
        /// The Numpad Divide key.
        /// </summary>
        KPDivide = 0xFFAF,
        /// <summary>
        /// The Numpad 0 key.
        /// </summary>
        KP0 = 0xFFB0,
        /// <summary>
        /// The Numpad 1 key.
        /// </summary>
        KP1 = 0xFFB1,
        /// <summary>
        /// The Numpad 2 key.
        /// </summary>
        KP2 = 0xFFB2,
        /// <summary>
        /// The Numpad 3 key.
        /// </summary>
        KP3 = 0xFFB3,
        /// <summary>
        /// The Numpad 4 key.
        /// </summary>
        KP4 = 0xFFB4,
        /// <summary>
        /// The Numpad 5 key.
        /// </summary>
        KP5 = 0xFFB5,
        /// <summary>
        /// The Numpad 6 key.
        /// </summary>
        KP6 = 0xFFB6,
        /// <summary>
        /// The Numpad 7 key.
        /// </summary>
        KP7 = 0xFFB7,
        /// <summary>
        /// The Numpad 8 key.
        /// </summary>
        KP8 = 0xFFB8,
        /// <summary>
        /// The Numpad 9 key.
        /// </summary>
        KP9 = 0xFFB9,

        /* Auxiliary Functions */
        /// <summary>
        /// The Function 1 key.
        /// </summary>
        F1 = 0xFFBE,
        /// <summary>
        /// The Function 2 key.
        /// </summary>
        F2 = 0xFFBF,
        /// <summary>
        /// The Function 3 key.
        /// </summary>
        F3 = 0xFFC0,
        /// <summary>
        /// The Function 4 key.
        /// </summary>
        F4 = 0xFFC1,
        /// <summary>
        /// The Function 5 key.
        /// </summary>
        F5 = 0xFFC2,
        /// <summary>
        /// The Function 6 key.
        /// </summary>
        F6 = 0xFFC3,
        /// <summary>
        /// The Function 7 key.
        /// </summary>
        F7 = 0xFFC4,
        /// <summary>
        /// The Function 8 key.
        /// </summary>
        F8 = 0xFFC5,
        /// <summary>
        /// The Function 9 key.
        /// </summary>
        F9 = 0xFFC6,
        /// <summary>
        /// The Function 10 key.
        /// </summary>
        F10 = 0xFFC7,
        /// <summary>
        /// The Function 11 key.
        /// </summary>
        F11 = 0xFFC8,
        /// <summary>
        /// The Function 12 key.
        /// </summary>
        F12 = 0xFFC9,
        /// <summary>
        /// The Function 13 key.
        /// </summary>
        F13 = 0xFFCA,
        /// <summary>
        /// The Function 14 key.
        /// </summary>
        F14 = 0xFFCB,
        /// <summary>
        /// The Function 15 key.
        /// </summary>
        F15 = 0xFFCC,
        /// <summary>
        /// The Function 16 key.
        /// </summary>
        F16 = 0xFFCD,
        /// <summary>
        /// The Function 17 key.
        /// </summary>
        F17 = 0xFFCE,
        /// <summary>
        /// The Function 18 key.
        /// </summary>
        F18 = 0xFFCF,
        /// <summary>
        /// The Function 19 key.
        /// </summary>
        F19 = 0xFFD0,
        /// <summary>
        /// The Function 20 key.
        /// </summary>
        F20 = 0xFFD1,
        /// <summary>
        /// The Function 21 key.
        /// </summary>
        F21 = 0xFFD2,
        /// <summary>
        /// The Function 22 key.
        /// </summary>
        F22 = 0xFFD3,
        /// <summary>
        /// The Function 23 key.
        /// </summary>
        F23 = 0xFFD4,
        /// <summary>
        /// The Function 24 key.
        /// </summary>
        F24 = 0xFFD5,
        /// <summary>
        /// The Function 25 key.
        /// </summary>
        F25 = 0xFFD6,
        /// <summary>
        /// The Function 26 key.
        /// </summary>
        F26 = 0xFFD7,
        /// <summary>
        /// The Function 27 key.
        /// </summary>
        F27 = 0xFFD8,
        /// <summary>
        /// The Function 28 key.
        /// </summary>
        F28 = 0xFFD9,
        /// <summary>
        /// The Function 29 key.
        /// </summary>
        F29 = 0xFFDA,
        /// <summary>
        /// The Function 30 key.
        /// </summary>
        F30 = 0xFFDB,
        /// <summary>
        /// The Function 31 key.
        /// </summary>
        F31 = 0xFFDC,
        /// <summary>
        /// The Function 32 key.
        /// </summary>
        F32 = 0xFFDD,
        /// <summary>
        /// The Function 33 key.
        /// </summary>
        F33 = 0xFFDE,
        /// <summary>
        /// The Function 34 key.
        /// </summary>
        F34 = 0xFFDF,
        /// <summary>
        /// The Function 35 key.
        /// </summary>
        F35 = 0xFFE0,

        /* Modifier keys */
        /// <summary>
        /// The Left Shift key.
        /// </summary>
        ShiftL = 0xFFE1,
        /// <summary>
        /// The Right Shift key.
        /// </summary>
        ShiftR = 0xFFE2,
        /// <summary>
        /// The Left Control key.
        /// </summary>
        ControlL = 0xFFE3,
        /// <summary>
        /// The Right Control key.
        /// </summary>
        ControlR = 0xFFE4,
        /// <summary>
        /// The Caps Lock key.
        /// </summary>
        CapsLock = 0xFFE5,
        /// <summary>
        /// The Shift Lock key.
        /// </summary>
        ShiftLock = 0xFFE6,
        /// <summary>
        /// The Left Meta key.
        /// </summary>
        MetaL = 0xFFE7,
        /// <summary>
        /// The Right Meta key.
        /// </summary>
        MetaR = 0xFFE8,
        /// <summary>
        /// The Left Alt key.
        /// </summary>
        AltL = 0xFFE9,
        /// <summary>
        /// The Right Alt key.
        /// </summary>
        AltR = 0xFFEA,
        /// <summary>
        /// The Left Super key.
        /// </summary>
        SuperL = 0xFFEB,
        /// <summary>
        /// The Right Super key.
        /// </summary>
        SuperR = 0xFFEC,
        /// <summary>
        /// The Left Hyper key.
        /// </summary>
        HyperL = 0xFFED,
        /// <summary>
        /// The Right Hyper key.
        /// </summary>
        HyperR = 0xFFEE,

        /* Latin 1 */
        /// <summary>
        /// The Space key.
        /// </summary>
        Space = 0x020,
        /// <summary>
        /// The Exclamation key.
        /// </summary>
        Exclam = 0x021,
        /// <summary>
        /// The Quotedbl key.
        /// </summary>
        Quotedbl = 0x022,
        /// <summary>
        /// The Number Sign key.
        /// </summary>
        NumberSign = 0x023,
        /// <summary>
        /// The Dollar key.
        /// </summary>
        Dollar = 0x024,
        /// <summary>
        /// The Percent key.
        /// </summary>
        Percent = 0x025,
        /// <summary>
        /// The Ampersand key.
        /// </summary>
        Ampersand = 0x026,
        /// <summary>
        /// The Apostrophe key.
        /// </summary>
        Apostrophe = 0x027,
        /// <summary>
        /// The Parenleft key.
        /// </summary>
        Parenleft = 0x028,
        /// <summary>
        /// The Parenright key.
        /// </summary>
        Parenright = 0x029,
        /// <summary>
        /// The Asterisk key.
        /// </summary>
        Asterisk = 0x02a,
        /// <summary>
        /// The Plus key.
        /// </summary>
        Plus = 0x02b,
        /// <summary>
        /// The Comma key.
        /// </summary>
        Comma = 0x02c,
        /// <summary>
        /// The Minus key.
        /// </summary>
        Minus = 0x02d,
        /// <summary>
        /// The Period key.
        /// </summary>
        Period = 0x02e,
        /// <summary>
        /// The Slash key.
        /// </summary>
        Slash = 0x02f,
        /// <summary>
        /// The 0 key.
        /// </summary>
        Keypad0 = 0x030,
        /// <summary>
        /// The 1 key.
        /// </summary>
        Keypad1 = 0x031,
        /// <summary>
        /// The 2 key.
        /// </summary>
        Keypad2 = 0x032,
        /// <summary>
        /// The 3 key.
        /// </summary>
        Keypad3 = 0x033,
        /// <summary>
        /// The 4 key.
        /// </summary>
        Keypad4 = 0x034,
        /// <summary>
        /// The 5 key.
        /// </summary>
        Keypad5 = 0x035,
        /// <summary>
        /// The 6 key.
        /// </summary>
        Keypad6 = 0x036,
        /// <summary>
        /// The 7 key.
        /// </summary>
        Keypad7 = 0x037,
        /// <summary>
        /// The 8 key.
        /// </summary>
        Keypad8 = 0x038,
        /// <summary>
        /// The 9 key.
        /// </summary>
        Keypad9 = 0x039,
        /// <summary>
        /// The Colon key.
        /// </summary>
        Colon = 0x03a,
        /// <summary>
        /// The Semicolon key.
        /// </summary>
        Semicolon = 0x03b,
        /// <summary>
        /// The Less key.
        /// </summary>
        Less = 0x03c,
        /// <summary>
        /// The Equal key.
        /// </summary>
        Equal = 0x03d,
        /// <summary>
        /// The Greater key.
        /// </summary>
        Greater = 0x03e,
        /// <summary>
        /// The Question key.
        /// </summary>
        Question = 0x03f,
        /// <summary>
        /// The At key.
        /// </summary>
        At = 0x040,
        /// <summary>
        /// The A key.
        /// </summary>
        KeypadA = 0x041,
        /// <summary>
        /// The B key.
        /// </summary>
        KeypadB = 0x042,
        /// <summary>
        /// The C key.
        /// </summary>
        KeypadC = 0x043,
        /// <summary>
        /// The D key.
        /// </summary>
        KeypadD = 0x044,
        /// <summary>
        /// The E key.
        /// </summary>
        KeypadE = 0x045,
        /// <summary>
        /// The F key.
        /// </summary>
        KeypadF = 0x046,
        /// <summary>
        /// The G key.
        /// </summary>
        KeypadG = 0x047,
        /// <summary>
        /// The H key.
        /// </summary>
        KeypadH = 0x048,
        /// <summary>
        /// The I key.
        /// </summary>
        KeypadI = 0x049,
        /// <summary>
        /// The J key.
        /// </summary>
        KeypadJ = 0x04a,
        /// <summary>
        /// The K key.
        /// </summary>
        KeypadK = 0x04b,
        /// <summary>
        /// The L key.
        /// </summary>
        KeypadL = 0x04c,
        /// <summary>
        /// The M key.
        /// </summary>
        KeypadM = 0x04d,
        /// <summary>
        /// The N key.
        /// </summary>
        KeypadN = 0x04e,
        /// <summary>
        /// The O key.
        /// </summary>
        KeypadO = 0x04f,
        /// <summary>
        /// The P key.
        /// </summary>
        KeypadP = 0x050,
        /// <summary>
        /// The Q key.
        /// </summary>
        KeypadQ = 0x051,
        /// <summary>
        /// The R key.
        /// </summary>
        KeypadR = 0x052,
        /// <summary>
        /// The S key.
        /// </summary>
        KeypadS = 0x053,
        /// <summary>
        /// The T key.
        /// </summary>
        KeypadT = 0x054,
        /// <summary>
        /// The U key.
        /// </summary>
        KeypadU = 0x055,
        /// <summary>
        /// The V key.
        /// </summary>
        KeypadV = 0x056,
        /// <summary>
        /// The W key.
        /// </summary>
        KeypadW = 0x057,
        /// <summary>
        /// The X key.
        /// </summary>
        KeypadX = 0x058,
        /// <summary>
        /// The Y key.
        /// </summary>
        KeypadY = 0x059,
        /// <summary>
        /// The Z key.
        /// </summary>
        KeypadZ = 0x05a,
        /// <summary>
        /// The Left Bracket key.
        /// </summary>
        BracketLeft = 0x05b,
        /// <summary>
        /// The Backslash key.
        /// </summary>
        Backslash = 0x05c,
        /// <summary>
        /// The Right Bracket key.
        /// </summary>
        BracketRight = 0x05d,
        /// <summary>
        /// The Circumflex key.
        /// </summary>
        AsciiCircum = 0x05e,
        /// <summary>
        /// The Underscore key.
        /// </summary>
        Underscore = 0x05f,
        /// <summary>
        /// The Grave key.
        /// </summary>
        Grave = 0x060,
        /// <summary>
        /// The a key.
        /// </summary>
        Keypada = 0x061,
        /// <summary>
        /// The b key.
        /// </summary>
        Keypadb = 0x062,
        /// <summary>
        /// The c key.
        /// </summary>
        Keypadc = 0x063,
        /// <summary>
        /// The d key.
        /// </summary>
        Keypadd = 0x064,
        /// <summary>
        /// The e key.
        /// </summary>
        Keypade = 0x065,
        /// <summary>
        /// The f key.
        /// </summary>
        Keypadf = 0x066,
        /// <summary>
        /// The g key.
        /// </summary>
        Keypadg = 0x067,
        /// <summary>
        /// The h key.
        /// </summary>
        Keypadh = 0x068,
        /// <summary>
        /// The i key.
        /// </summary>
        Keypadi = 0x069,
        /// <summary>
        /// The j key.
        /// </summary>
        Keypadj = 0x06a,
        /// <summary>
        /// The k key.
        /// </summary>
        Keypadk = 0x06b,
        /// <summary>
        /// The l key.
        /// </summary>
        Keypadl = 0x06c,
        /// <summary>
        /// The m key.
        /// </summary>
        Keypadm = 0x06d,
        /// <summary>
        /// The n key.
        /// </summary>
        Keypadn = 0x06e,
        /// <summary>
        /// The o key.
        /// </summary>
        Keypado = 0x06f,
        /// <summary>
        /// The p key.
        /// </summary>
        Keypadp = 0x070,
        /// <summary>
        /// The q key.
        /// </summary>
        Keypadq = 0x071,
        /// <summary>
        /// The r key.
        /// </summary>
        Keypadr = 0x072,
        /// <summary>
        /// The s key.
        /// </summary>
        Keypads = 0x073,
        /// <summary>
        /// The t key.
        /// </summary>
        Keypadt = 0x074,
        /// <summary>
        /// The u key.
        /// </summary>
        Keypadu = 0x075,
        /// <summary>
        /// The v key.
        /// </summary>
        Keypadv = 0x076,
        /// <summary>
        /// The w key.
        /// </summary>
        Keypadw = 0x077,
        /// <summary>
        /// The x key.
        /// </summary>
        Keypadx = 0x078,
        /// <summary>
        /// The y key.
        /// </summary>
        Keypady = 0x079,
        /// <summary>
        /// The z key.
        /// </summary>
        Keypadz = 0x07a,
        /// <summary>
        /// The Left Brace key.
        /// </summary>
        BraceLeft = 0x07b,
        /// <summary>
        /// The Bar key.
        /// </summary>
        Bar = 0x07c,
        /// <summary>
        /// The Right Brace key.
        /// </summary>
        BraceRight = 0x07d,
        /// <summary>
        /// The Tilde key.
        /// </summary>
        AsciiTilde = 0x07e,
    };

    /// <summary>
    /// Enumeration for the key masks.
    /// The key masks indicate which modifier keys are pressed down during the keyboard hit. The special MASK_RELEASED indicates the key release event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum KeyMask
    {
        /// <summary>
        /// Key press event without the modifier key.
        /// </summary>
        Pressed = 0,
        /// <summary>
        /// The Shift key is pressed down.
        /// </summary>
        Shift = (1 << 0),
        /// <summary>
        /// The CapsLock key is pressed down.
        /// </summary>
        CapsLock = (1 << 1),
        /// <summary>
        /// The Control key is pressed down.
        /// </summary>
        Control = (1 << 2),
        /// <summary>
        /// The Alt key is pressed down.
        /// </summary>
        Alt = (1 << 3),
        /// <summary>
        /// The Meta key is pressed down.
        /// </summary>
        Meta = (1 << 4),
        /// <summary>
        /// The Win key (between Control and Alt) is pressed down.
        /// </summary>
        Win = (1 << 5),
        /// <summary>
        /// The Hyper key is pressed down.
        /// </summary>
        Hyper = (1 << 6),
        /// <summary>
        /// The NumLock key is pressed down.
        /// </summary>
        NumLock = (1 << 7),
        /// <summary>
        /// Key release event.
        /// </summary>
        Released = (1 << 15),
    }

    /// <summary>
    /// This class contains the API's related to the IME (Input method editor).
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public static class InputMethodEditor
    {
        private static ImeCallbackStructGCHandle _imeCallbackStructGCHandle = new ImeCallbackStructGCHandle();
        private static event EventHandler<FocusedInEventArgs> _focusIn;
        private static ImeFocusedInCb _imeFocusedInDelegate;
        private static event EventHandler<FocusedOutEventArgs> _focusOut;
        private static ImeFocusedOutCb _imeFocusedOutDelegate;
        private static event EventHandler<SurroundingTextUpdatedEventArgs> _surroundingTextUpdated;
        private static ImeSurroundingTextUpdatedCb _imeSurroundingTextUpdatedDelegate;
        private static event EventHandler<EventArgs> _inputContextReset;
        private static ImeInputContextResetCb _imeInputContextResetDelegate;
        private static event EventHandler<CursorPositionUpdatedEventArgs> _cursorPositionUpdated;
        private static ImeCursorPositionUpdatedCb _imeCursorPositionUpdatedDelegate;
        private static event EventHandler<LanguageSetEventArgs> _langaugeSet;
        private static ImeLanguageSetCb _imeLanguageSetDelegate;
        private static event EventHandler<SetDataEventArgs> _imDataSet;
        private static ImeImdataSetCb _imeDataSetDelegate;
        private static event EventHandler<LayoutSetEventArgs> _layoutSet;
        private static ImeLayoutSetCb _imeLayoutSetDelegate;
        private static event EventHandler<ReturnKeySetEventArgs> _returnKeyTypeSet;
        private static ImeReturnKeySetCb _imeReturnKeySetDelegate;
        private static event EventHandler<ReturnKeyStateSetEventArgs> _returnKeyStateSet;
        private static ImeReturnKeyStateSetCb _imeReturnKeyStateSetDelegate;
        private static ImeProcessKeyEventCb _imeProcessKeyDelegate;
        private static event EventHandler<DisplayLanguageChangedEventArgs> _displayLanguageChanged;
        private static ImeDisplayLanguageChangedCb _imeDisplayLanguageChangedDelegate;
        private static event EventHandler<RotationChangedEventArgs> _rotationDegreeChanged;
        private static ImeRotationChangedCb _imeRotationChangedDelegate;
        private static event EventHandler<AccessibilityStateChangedEventArgs> _accessibilityStateChanged;
        private static ImeAccessibilityStateChangedCb _imeAccessibilityStateChangedDelegate;
        private static event EventHandler<PredictionHintUpdatedEventArgs> _predictionHintUpdated;
        private static ImePredictionHintSetCb _imePredictionHintSetDelegate;
        private static event EventHandler<PredictionHintDataUpdatedEventArgs> _predictionHintDataUpdated;
        private static ImePredictionHintDataSetCb _imePredictionHintDataSetDelegate;
        private static event EventHandler<MimeTypeUpdateRequestedEventArgs> _mimeTypeUpdateRequested;
        private static ImeMimeTypeSetRequestCb _imeMimeTypeSetRequestDelegate;
        private static ImeLanguageRequestedCb _imeLanguageRequestedDelegate;
        private static OutAction<string> _languageRequestedDelegate;
        private static BoolAction<KeyCode, KeyMask, InputMethodDeviceInformation> _processKeyDelagate;
        private static ImeImdataRequestedCb _imeImDataRequestedDelegate;
        private static OutArrayAction<byte> _imDataRequestedDelegate;
        private static ImeGeometryRequestedCb _imeGeometryRequestedDelegate;
        private static OutAction<Rect> _geometryRequestedDelegate;
        private static Action _userCreate;
        private static Action _userTerminate;
        private static Action<ContextId, InputMethodContext> _userShow;
        private static Action<ContextId> _userHide;
        private static ImeCreateCb _create = (IntPtr userData) =>
        {
            Log.Info(LogTag, "In Create Delegate");
            _userCreate?.Invoke();
        };
        private static ImeTerminateCb _terminate = (IntPtr userData) =>
        {
            Log.Info(LogTag, "In terminate Delegate");
            _userTerminate?.Invoke();
            _imeCallbackStructGCHandle.Dispose();
        };
        private static ImeShowCb _show = (int contextId, IntPtr context, IntPtr userData) =>
        {
            Log.Info(LogTag, "In Show Delegate");
            _userShow?.Invoke(new ContextId(contextId), new InputMethodContext(context));
        };
        private static ImeHideCb _hide = (int contextId, IntPtr userData) =>
        {
            Log.Info(LogTag, "In Hide Delegate");
            _userHide?.Invoke(new ContextId(contextId));
        };

        /// <summary>
        /// Structure representing the ContextId.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public struct ContextId : IEquatable<ContextId>
        {
            internal ContextId(int id)
            {
                Id = id;
            }

            internal int Id
            {
                get;
                private set;
            }

            /// <summary>
            /// Compares whether the ContextIds are equal.
            /// </summary>
            /// <param name="other">The ContextId to compare with this instance.</param>
            /// <returns>true if the ContextIds is the same; otherwise, false.</returns>
            /// <since_tizen> 4 </since_tizen>
            public bool Equals(ContextId other)
            {
                return this.Id == other.Id;
            }
        }

        /// <summary>
        /// Rectangle representing the position and size of the UI control.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public struct Rect
        {
            /// <summary>
            /// The X position in the screen.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public int x;

            /// <summary>
            /// The Y position in the screen.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public int y;

            /// <summary>
            /// The window width.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public int w;

            /// <summary>
            /// The window height.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public int h;
        }

        /// <summary>
        /// An action with 1 out parameter.
        /// </summary>
        /// <typeparam name="T">Generic Type.</typeparam>
        /// <param name="a">The out parameter.</param>
        /// <since_tizen> 4 </since_tizen>
        public delegate void OutAction<T>(out T a);

        /// <summary>
        /// An action with an array out parameter.
        /// </summary>
        /// <typeparam name="T">Generic Type.</typeparam>
        /// <param name="a">The out parameter 1.</param>
        /// <since_tizen> 4 </since_tizen>
        public delegate void OutArrayAction<T>(out T[] a);

        /// <summary>
        /// An action with 3 input parameters returning a bool.
        /// </summary>
        /// <typeparam name="T">Generic type for parameter 1.</typeparam>
        /// <typeparam name="T1">Generic type for parameter 2.</typeparam>
        /// <typeparam name="T2">Generic type for parameter 3.</typeparam>
        /// <param name="a">The input parameter 1.</param>
        /// <param name="b">The input parameter 2.</param>
        /// <param name="c">The input parameter 3.</param>
        /// <returns></returns>
        /// <since_tizen> 4 </since_tizen>
        public delegate bool BoolAction<T, T1, T2>(T a, T1 b, T2 c);

        /// <summary>
        /// Called when an associated text input UI control has focus.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<FocusedInEventArgs> FocusedIn
        {
            add
            {
                _imeFocusedInDelegate = (int contextId, IntPtr userData) =>
                {
                    FocusedInEventArgs args = new FocusedInEventArgs(contextId);
                    _focusIn?.Invoke(null, args);
                };
                ErrorCode error = ImeEventSetFocusedInCb(_imeFocusedInDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add FocusedIn Failed with error " + error);
                }
                else
                {
                    _focusIn += value;
                }
            }
            remove
            {
                _focusIn -= value;
            }
        }

        /// <summary>
        /// Called when an associated text input UI control loses focus.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<FocusedOutEventArgs> FocusedOut
        {
            add
            {
                _imeFocusedOutDelegate = (int contextId, IntPtr userData) =>
                {
                    FocusedOutEventArgs args = new FocusedOutEventArgs(contextId);
                    _focusOut?.Invoke(null, args);
                };
                ErrorCode error = ImeEventSetFocusedOutCb(_imeFocusedOutDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add FocusedOut Failed with error " + error);
                }
                else
                {
                    _focusOut += value;
                }
            }
            remove
            {
                _focusOut -= value;
            }
        }

        /// <summary>
        /// Called when an associated text input UI control responds to a request with the surrounding text.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<SurroundingTextUpdatedEventArgs> SurroundingTextUpdated
        {
            add
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
            remove
            {
                _surroundingTextUpdated -= value;
            }
        }

        /// <summary>
        /// Called to reset the input context of an associated text input UI control.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<EventArgs> InputContextReset
        {
            add
            {
                _imeInputContextResetDelegate = (IntPtr userData) =>
                {
                    _inputContextReset?.Invoke(null, EventArgs.Empty);
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
            remove
            {
                _inputContextReset -= value;
            }
        }

        /// <summary>
        /// Called when the position of the cursor in an associated text input UI control changes.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<CursorPositionUpdatedEventArgs> CursorPositionUpdated
        {
            add
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
            remove
            {
                _cursorPositionUpdated -= value;
            }
        }

        /// <summary>
        /// Called to set the preferred language to the input panel.
        /// It will only be called when the client application changes the edit field's language attribute after the input panel is shown.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<LanguageSetEventArgs> LanguageSet
        {
            add
            {
                _imeLanguageSetDelegate = (InputPanelLanguage language, IntPtr userData) =>
                {
                    LanguageSetEventArgs args = new LanguageSetEventArgs(language);
                    _langaugeSet?.Invoke(null, args);
                };
                ErrorCode error = ImeEventSetLanguageSetCb(_imeLanguageSetDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add LanguageSet Failed with error " + error);
                }
                else
                {
                    _langaugeSet += value;
                }
            }
            remove
            {
                _langaugeSet -= value;
            }
        }

        /// <summary>
        /// Called to set the application specific data to deliver to the input panel.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<SetDataEventArgs> DataSet
        {
            add
            {
                _imeDataSetDelegate = (IntPtr data, uint dataLength, IntPtr userData) =>
                {
                    byte[] destination = new byte[dataLength];
                    Marshal.Copy(data, destination, 0, (int)dataLength);
                    SetDataEventArgs args = new SetDataEventArgs(destination, dataLength);
                    _imDataSet?.Invoke(null, args);
                };
                ErrorCode error = ImeEventSetImdataSetCb(_imeDataSetDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add DataSet Failed with error " + error);
                }
                else
                {
                    _imDataSet += value;
                }
            }
            remove
            {
                _imDataSet -= value;
            }
        }

        /// <summary>
        /// Called when an associated text input UI control requests the input panel to set its layout.
        /// It will only be called when the client application changes the edit field's layout attribute after the input panel is shown.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<LayoutSetEventArgs> LayoutSet
        {
            add
            {
                _imeLayoutSetDelegate = (InputPanelLayout layout, IntPtr userData) =>
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
            remove
            {
                _layoutSet -= value;
            }
        }

        /// <summary>
        /// Called when an associated text input UI control requests the input panel to set the Return key label.
        /// The input panel can show the text or an image on the Return button, according to the Return key action.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<ReturnKeySetEventArgs> ReturnKeySet
        {
            add
            {
                _imeReturnKeySetDelegate = (InputPanelReturnKey type, IntPtr userData) =>
                {
                    ReturnKeySetEventArgs args = new ReturnKeySetEventArgs(type);
                    _returnKeyTypeSet?.Invoke(null, args);
                };
                ErrorCode error = ImeEventSetReturnKeySetCb(_imeReturnKeySetDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add ReturnKeySet Failed with error " + error);
                }
                else
                {
                    _returnKeyTypeSet += value;
                }
            }
            remove
            {
                _returnKeyTypeSet -= value;
            }
        }

        /// <summary>
        /// Called when an associated text input UI control requests the input panel to enable or disable the Return key state.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<ReturnKeyStateSetEventArgs> ReturnKeyStateSet
        {
            add
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
            remove
            {
                _returnKeyStateSet -= value;
            }
        }

        /// <summary>
        /// Called when the system display language is changed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<DisplayLanguageChangedEventArgs> DisplayLanguageChanged
        {
            add
            {
                _imeDisplayLanguageChangedDelegate = (IntPtr language, IntPtr userData) =>
                {
                    DisplayLanguageChangedEventArgs args = new DisplayLanguageChangedEventArgs(Marshal.PtrToStringAnsi(language));
                    _displayLanguageChanged?.Invoke(null, args);
                };
                ErrorCode error = ImeEventSetDisplayLanguageChangedCb(_imeDisplayLanguageChangedDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add DisplayLanguageChanged Failed with error " + error);
                }
                else
                {
                    _displayLanguageChanged += value;
                }
            }
            remove
            {
                _displayLanguageChanged -= value;
            }
        }

        /// <summary>
        /// Called when the device is rotated.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<RotationChangedEventArgs> RotationChanged
        {
            add
            {
                _imeRotationChangedDelegate = (int degree, IntPtr userData) =>
                {
                    RotationChangedEventArgs args = new RotationChangedEventArgs(degree);
                    _rotationDegreeChanged?.Invoke(null, args);
                };
                ErrorCode error = ImeEventSetRotationChangedCb(_imeRotationChangedDelegate, IntPtr.Zero);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Add RotationChanged Failed with error " + error);
                }
                else
                {
                    _rotationDegreeChanged += value;
                }
            }
            remove
            {
                _rotationDegreeChanged -= value;
            }
        }

        /// <summary>
        /// Called when Accessibility in settings application is on or off.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<AccessibilityStateChangedEventArgs> AccessibilityStateChanged
        {
            add
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
            remove
            {
                _accessibilityStateChanged -= value;
            }
        }

        /// <summary>
        /// Sets the languageRequested action.
        /// </summary>
        /// <param name="languageRequested">
        /// Called when an associated text input UI control requests the language from the input panel, requesting for language code.
        /// </param>
        /// <since_tizen> 4 </since_tizen>
        public static void SetLanguageRequestedCallback(OutAction<string> languageRequested)
        {
            _imeLanguageRequestedDelegate = (IntPtr userData, out IntPtr langCode) =>
            {
                string language;
                _languageRequestedDelegate(out language);
                langCode = (IntPtr)Marshal.StringToHGlobalAnsi(language);
            };
            ErrorCode error = ImeEventSetLanguageRequestedCallbackCb(_imeLanguageRequestedDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Add SetLanguageRequestedCallback Failed with error " + error);
            }
            _languageRequestedDelegate = languageRequested;
        }

        /// <summary>
        /// Sets the processKey action.
        /// If the key event is from the external device, DeviceInfo will have its name, class, and subclass information.
        /// </summary>
        /// <param name="processKey">
        /// The action is called when the key event is received from the external devices or the SendKey function.
        /// This Event processes the key event before an associated text input UI control does.
        /// </param>
        /// <since_tizen> 4 </since_tizen>
        public static void SetProcessKeyCallback(BoolAction<KeyCode, KeyMask, InputMethodDeviceInformation> processKey)
        {
            _imeProcessKeyDelegate = (KeyCode keyCode, KeyMask keyMask, IntPtr devInfo, IntPtr userData) =>
            {
                return _processKeyDelagate(keyCode, keyMask, new InputMethodDeviceInformation(devInfo));
            };
            ErrorCode error = ImeEventSetProcessKeyEventCb(_imeProcessKeyDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Add ProcessKey Failed with error " + error);
            }
            _processKeyDelagate = processKey;
        }

        /// <summary>
        /// Sets the imDataRequested action.
        /// </summary>
        /// <param name="imDataRequested">
        /// Called when an associated text input UI control requests the application specific data from the input panel, requesting for data array and it's length.
        /// </param>
        /// <since_tizen> 4 </since_tizen>
        public static void SetDataRequestedCallback(OutArrayAction<byte> imDataRequested)
        {
            _imeImDataRequestedDelegate = (IntPtr userData, out IntPtr data, out uint dataLength) =>
            {
                byte[] dataArr;
                _imDataRequestedDelegate(out dataArr);
                data = Marshal.AllocHGlobal(dataArr.Length);
                Marshal.Copy(dataArr, 0, data, dataArr.Length);
                dataLength = (uint)dataArr.Length;
            };
            ErrorCode error = ImeEventSetImdataRequestedCb(_imeImDataRequestedDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Add SetDataRequestedCallback Failed with error " + error);
            }
            _imDataRequestedDelegate = imDataRequested;
        }

        /// <summary>
        /// Sets the GeometryRequested action.
        /// </summary>
        /// <param name="geometryRequested">
        /// Called when an associated text input UI control requests the position and size from the input panel, requesting for x, y, w, h values.
        /// </param>
        /// <since_tizen> 4 </since_tizen>
        public static void SetGeometryRequestedCallback(OutAction<Rect> geometryRequested)
        {
            _imeGeometryRequestedDelegate = (IntPtr userData, out int x, out int y, out int w, out int h) =>
            {
                Rect rect = new Rect();
                _geometryRequestedDelegate(out rect);
                x = rect.x;
                y = rect.y;
                w = rect.w;
                h = rect.h;
            };
            ErrorCode error = ImeEventSetGeometryRequestedCallbackCb(_imeGeometryRequestedDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Add SetGeometryRequestedCallback Failed with error " + error);
            }
            _geometryRequestedDelegate = geometryRequested;
        }

        /// <summary>
        /// Runs the main loop of the IME application.
        /// This function starts to run the IME application's main loop.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <remarks>
        /// This API is a blocking call, as it starts the main loop of the application.
        /// </remarks>
        /// <param name="create">This is called to initialize the IME application before the main loop starts up.</param>
        /// <param name="terminate">This is called when the IME application is terminated.</param>
        /// <param name="show">
        /// This is called when the IME application is shown.
        /// It provides the context information and the context ID.
        /// </param>
        /// <param name="hide">
        /// This is called when the IME application is hidden.
        /// It provides the context ID.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) Operation failed.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public static void Run(Action create, Action terminate, Action<ContextId, InputMethodContext> show, Action<ContextId> hide)
        {
            _userCreate = create;
            _userTerminate = terminate;
            _userShow = show;
            _userHide = hide;
            _imeCallbackStructGCHandle._imeCallbackStruct.create = _create;
            _imeCallbackStructGCHandle._imeCallbackStruct.terminate = _terminate;
            _imeCallbackStructGCHandle._imeCallbackStruct.hide = _hide;
            _imeCallbackStructGCHandle._imeCallbackStruct.show = _show;

            ImeSetDotnetFlag(true);
            ErrorCode error = ImeRun(ref _imeCallbackStructGCHandle._imeCallbackStruct, IntPtr.Zero);
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
        /// This function sends a key down or up event with the key mask to the client application. If forwardKey is true, this key event goes to the edit filed directly.
        /// And if forwardKey is false, the ProcessKey event receives the key event before the edit field.
        /// </remarks>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="keyCode">The key code to be sent.</param>
        /// <param name="keyMask">The modifier key mask.</param>
        /// <param name="forwardKey">The flag to send the key event directly to the edit field.</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public static void SendKeyEvent(KeyCode keyCode, KeyMask keyMask, bool forwardKey = false)
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
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="str">The string to be committed.</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// Requests to show the pre-edit string.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// Requests to hide the pre-edit string.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// Updates a new pre-edit string.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="str">The string to be updated in pre-edit.</param>
        /// <param name="attrs">
        /// The list which has ime_preedit_attribute lists, strings can be composed of multiple string attributes: underline, highlight color, and reversal color.
        /// The attrs list can be empty if no attributes to set.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// 3) Invalid parameter.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public static void UpdatePreEditString(string str, IEnumerable<PreEditAttribute> attrs)
        {
            IntPtr einaList = IntPtr.Zero;
            foreach (PreEditAttribute attribute in attrs)
            {
                IntPtr attr = IntPtr.Zero;
                ImePreEditAttributeStruct imePreEditAttribute = new ImePreEditAttributeStruct();
                imePreEditAttribute.start = attribute.Start;
                imePreEditAttribute.length = attribute.Length;
                imePreEditAttribute.type = (int)attribute.Type;
                imePreEditAttribute.value = attribute.Value;
                attr = Marshal.AllocHGlobal(Marshal.SizeOf(imePreEditAttribute));
                Marshal.WriteIntPtr(attr, IntPtr.Zero);
                Marshal.StructureToPtr(imePreEditAttribute, attr, false);
                einaList = Interop.EinaList.EinaListAppend(einaList, attr);
            }
            ErrorCode error = ImeUpdatePreeditString(str, einaList);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "UpdatePreEditString Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Requests the surrounding text from the position of the cursor, asynchronously.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="maxLenBefore">The maximum length of the string to be retrieved before the cursor, -1 means unlimited.</param>
        /// <param name="maxLenAfter">The maximum length of the string to be retrieved after the cursor, -1 means unlimited.</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <postcondition>
        /// The requested surrounding text can be received using the SurroundingTextUpdated event, only if it is set.
        /// </postcondition>
        /// <since_tizen> 4 </since_tizen>
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
        /// Requests to delete the surrounding text.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="offset">The offset value from the cursor position.</param>
        /// <param name="len">The length of the text to delete.</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// 3) Invalid parameter.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="maxLenBefore">The maximum length of the string to be retrieved before the cursor, -1 means unlimited.</param>
        /// <param name="maxLenAfter">The maximum length of the string to be retrieved after the cursor, -1 means unlimited.</param>
        /// <param name="text">The surrounding text.</param>
        /// <param name="cursorPosition">The cursor position.</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// 3) Invalid parameter.
        /// 4) Failed to obtain text due to out of memory.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// Requests to set the selection.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="start">The start cursor position in text (in characters not bytes).</param>
        /// <param name="end">The end cursor position in text (in characters not bytes).</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// 3) Invalid parameter.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <returns>The input panel main window object on success, otherwise null.</returns>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// 3) Operation failed.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public static EditorWindow GetMainWindow()
        {
            EditorWindow._handle = ImeGetMainWindow();
            EditorWindow obj = new EditorWindow();
            ErrorCode error = (ErrorCode)Tizen.Internals.Errors.ErrorFacts.GetLastResult();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetMainWindow Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
            return obj;
        }

        /// <summary>
        /// Sends the request to hide the IME.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public static void RequestHide()
        {
            ErrorCode error = ImeRequestHide();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "RequestHide Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// This API requests the InputMethodEditor to initialize.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) Operation failed.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Create()
        {
            ErrorCode error = ImeInitialize();
            Log.Info(LogTag, "ImeInitialize result : " + error);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "ImeInitialize Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }

            error = ImePrepare();
            Log.Info(LogTag, "ImePrepare result : " + error);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "ImePrepare Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// This API requests the InputMethodEditor to finalize.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) Operation failed.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Destroy()
        {
            ErrorCode error = ImeFinalize();
            Log.Info(LogTag, "ImeFinalize result : " + error);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "ImeFinalize Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Sets the floating mode to on or off.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="floatingMode"><c>true</c> to set the floating mode to on and <c>false</c> to set it to off.</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public static void SetFloatingMode(bool floatingMode)
        {
            ErrorCode error = ImeSetFloatingMode(floatingMode);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetFloatingMode Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Allows the floating input panel window to move along with the mouse pointer when the mouse is pressed.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <remarks>
        /// This function can be used in floating mode. If the floating mode is deactivated, calling this function has no effect.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public static void SetFloatingDragStart()
        {
            ErrorCode error = ImeSetFloatingDragStart();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetFloatingDragStart Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Does not allow the movement of the floating input panel window with the mouse pointer when the mouse is pressed.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <remarks>
        /// This function can be used in floating mode. If the floating mode is deactivated, calling this function has no effect.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public static void SetFloatingDragEnd()
        {
            ErrorCode error = ImeSetFloatingDragEnd();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetFloatingDragEnd Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Notifies the changed language of the input panel to the the associated text input UI control.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <remarks>
        /// LanguageRequestedCallback is raised after this API is called when the App requests changed language information.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SendLanguageUpdated()
        {
            ErrorCode error = ImeUpdateInputPanelEvent(ImeEventType.Language, 0);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SendLanguageUpdated Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Sends the changed shift mode of the input panel to the the associated text input UI control.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="enable"><c>true</c> if shift button is clicked, otherwise <c>false</c>.</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SendShiftModeUpdated(bool enable)
        {
            ErrorCode error = ImeUpdateInputPanelEvent(ImeEventType.ShiftMode, enable ? (uint)ImeShiftMode.On : (uint)ImeShiftMode.Off);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SendInputPanelEvent Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Notifies the changed geometry of input panel window to the associated text input UI control.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SendCustomGeometryUpdated()
        {
            ErrorCode error = ImeUpdateInputPanelEvent(ImeEventType.Geometry, 0);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SendCustomGeometryUpdated Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Gets the selected text synchronously.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <returns>The selected text.</returns>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public static string GetSelectedText()
        {
            IntPtr txt;
            ErrorCode error = ImeGetSelectedText(out txt);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetSelectedText Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
            return Marshal.PtrToStringAnsi(txt);
        }

        /// <summary>
        /// Called to set the prediction hint string to deliver to the input panel.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static event EventHandler<PredictionHintUpdatedEventArgs> PredictionHintUpdated
        {
            add
            {
                if (_imePredictionHintSetDelegate == null)
                {
                    _imePredictionHintSetDelegate = (IntPtr predictionHint, IntPtr userData) =>
                    {
                        PredictionHintUpdatedEventArgs args = new PredictionHintUpdatedEventArgs(Marshal.PtrToStringAnsi(predictionHint));
                        _predictionHintUpdated?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetPredictionHintSetCb(_imePredictionHintSetDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add PredictionHintUpdated Failed with error " + error);
                    }
                }
                _predictionHintUpdated += value;
            }
            remove
            {
                _predictionHintUpdated -= value;
            }
        }

        /// <summary>
        /// Called to set the prediction hint key and value to deliver to the input panel.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static event EventHandler<PredictionHintDataUpdatedEventArgs> PredictionHintDataUpdated
        {
            add
            {
                if (_imePredictionHintDataSetDelegate == null)
                {
                    _imePredictionHintDataSetDelegate = (IntPtr key, IntPtr keyValue, IntPtr userData) =>
                    {
                        PredictionHintDataUpdatedEventArgs args = new PredictionHintDataUpdatedEventArgs(Marshal.PtrToStringAnsi(key), Marshal.PtrToStringAnsi(keyValue));
                        _predictionHintDataUpdated?.Invoke(null, args);
                    };

                    ErrorCode error = ImeEventSetPredictionHintDataSetCb(_imePredictionHintDataSetDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add PredictionHintDataUpdated Failed with error " + error);
                    }
                }
                _predictionHintDataUpdated += value;
            }
            remove
            {
                _predictionHintDataUpdated -= value;
            }
        }

        /// <summary>
        /// Called when an associated text input UI control requests the text entry to set the MIME type.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static event EventHandler<MimeTypeUpdateRequestedEventArgs> MimeTypeUpdateRequested
        {
            add
            {
                if (_imeMimeTypeSetRequestDelegate == null)
                {
                    _imeMimeTypeSetRequestDelegate = (IntPtr mimeType, IntPtr userData) =>
                    {
                        MimeTypeUpdateRequestedEventArgs args = new MimeTypeUpdateRequestedEventArgs(Marshal.PtrToStringAnsi(mimeType));
                        _mimeTypeUpdateRequested?.Invoke(null, args);
                    };
                    ErrorCode error = ImeEventSetMimeTypeSetRequestCb(_imeMimeTypeSetRequestDelegate, IntPtr.Zero);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Add MimeTypeUpdateRequested Failed with error " + error);
                    }
                }
                _mimeTypeUpdateRequested += value;
            }
            remove
            {
                _mimeTypeUpdateRequested -= value;
            }
        }

        /// <summary>
        /// Sends a private command to the associated text input UI control.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="command">The UTF-8 string to be sent.</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// 3) Invalid parameter.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SendPrivateCommand(string command)
        {
            ErrorCode error = ImeSendPrivateCommand(command);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SendPrivateCommand Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Commits contents such as image to the associated text input UI control.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="content">The content URI to be sent.</param>
        /// <param name="description">The content description.</param>
        /// <param name="mimeType">The MIME type received from the MimeTypeSetRequest</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function.
        /// 2) The IME main loop has not started yet.
        /// 3) Invalid parameter.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public static void CommitContent(string content, string description, string mimeType)
        {
            ErrorCode error = ImeCommitContent(content, description, mimeType);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "CommitContent Failed with error " + error);
                throw InputMethodExceptionFactory.CreateException(error);
            }
        }
    }
}
