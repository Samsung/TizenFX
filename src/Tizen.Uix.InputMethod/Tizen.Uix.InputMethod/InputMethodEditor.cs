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
    /// Enumeration of the key codes.
    /// If keycode &amp; 0xff000000 == 0x01000000 then this key code is directly encoded 24-bit UCS character.The UCS value is keycode &amp; 0x00ffffff.
    /// Defines the list of keys supported by the system.Note that certain keys may not be available on all devices.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum KeyCode
    {
        /// <summary>
        /// The backspace key
        /// </summary>
        BackSpace = 0xFF08,
        /// <summary>
        /// The tab key
        /// </summary>
        Tab = 0xFF09,
        /// <summary>
        /// The linefeed key
        /// </summary>
        Linefeed = 0xFF0A,
        /// <summary>
        /// The clear key
        /// </summary>
        Clear = 0xFF0B,
        /// <summary>
        /// The return key
        /// </summary>
        Return = 0xFF0D,
        /// <summary>
        /// The pause key
        /// </summary>
        Pause = 0xFF13,
        /// <summary>
        /// The scroll lock key
        /// </summary>
        ScrollLock = 0xFF14,
        /// <summary>
        /// The sys req key
        /// </summary>
        SysReq = 0xFF15,
        /// <summary>
        /// The escape key
        /// </summary>
        Escape = 0xFF1B,
        /// <summary>
        /// The delete key
        /// </summary>
        Delete = 0xFFFF,

        /* Cursor control & motion */
        /// <summary>
        /// The home key
        /// </summary>
        Home = 0xFF50,
        /// <summary>
        /// The left directional key
        /// </summary>
        Left = 0xFF51,
        /// <summary>
        /// The up directional key
        /// </summary>
        Up = 0xFF52,
        /// <summary>
        /// The right directional key
        /// </summary>
        Right = 0xFF53,
        /// <summary>
        /// The down directional key
        /// </summary>
        Down = 0xFF54,
        /// <summary>
        /// The prior, previous key
        /// </summary>
        Prior = 0xFF55,
        /// <summary>
        /// The page up key
        /// </summary>
        Page_Up = 0xFF55,
        /// <summary>
        /// The next key
        /// </summary>
        Next = 0xFF56,
        /// <summary>
        /// The page down key
        /// </summary>
        Page_Down = 0xFF56,
        /// <summary>
        /// The end key
        /// </summary>
        End = 0xFF57,
        /// <summary>
        /// The begin key
        /// </summary>
        Begin = 0xFF58,

        /* Misc Functions */
        /// <summary>
        /// The select key
        /// </summary>
        Select = 0xFF60,
        /// <summary>
        /// The print key
        /// </summary>
        Print = 0xFF61,
        /// <summary>
        /// The execute, run, do key
        /// </summary>
        Execute = 0xFF62,
        /// <summary>
        /// The insert key
        /// </summary>
        Insert = 0xFF63,
        /// <summary>
        /// The undo key
        /// </summary>
        Undo = 0xFF65,
        /// <summary>
        /// The redo key
        /// </summary>
        Redo = 0xFF66,
        /// <summary>
        /// The menu key
        /// </summary>
        Menu = 0xFF67,
        /// <summary>
        /// The find key
        /// </summary>
        Find = 0xFF68,
        /// <summary>
        /// The cancel, stop, abort, exit key
        /// </summary>
        Cancel = 0xFF69,
        /// <summary>
        /// The help key
        /// </summary>
        Help = 0xFF6A,
        /// <summary>
        /// The break key
        /// </summary>
        Break = 0xFF6B,
        /// <summary>
        /// The character set switch key
        /// </summary>
        Mode_switch = 0xFF7E,
        /// <summary>
        /// The num lock key
        /// </summary>
        Num_Lock = 0xFF7F,

        /* Keypad */
        /// <summary>
        /// The Numpad space key
        /// </summary>
        KPSpace = 0xFF80,
        /// <summary>
        /// The Numpad tab key
        /// </summary>
        KPTab = 0xFF89,
        /// <summary>
        /// The Numpad enter key
        /// </summary>
        KPEnter = 0xFF8D,
        /// <summary>
        /// The Numpad function 1 key
        /// </summary>
        KPF1 = 0xFF91,
        /// <summary>
        /// The Numpad function 2 key
        /// </summary>
        KPF2 = 0xFF92,
        /// <summary>
        /// The Numpad function 3 key
        /// </summary>
        KPF3 = 0xFF93,
        /// <summary>
        /// The Numpad function 4 key
        /// </summary>
        KPF4 = 0xFF94,
        /// <summary>
        /// The Numpad home key
        /// </summary>
        KPHome = 0xFF95,
        /// <summary>
        /// The Numpad left key
        /// </summary>
        KPLeft = 0xFF96,
        /// <summary>
        /// The Numpad up key
        /// </summary>
        KPUp = 0xFF97,
        /// <summary>
        /// The Numpad right key
        /// </summary>
        KPRight = 0xFF98,
        /// <summary>
        /// The Numpad down key
        /// </summary>
        KPDown = 0xFF99,
        /// <summary>
        /// The Numpad prior, previous key
        /// </summary>
        KPPrior = 0xFF9A,
        /// <summary>
        /// The Numpad page up key
        /// </summary>
        KPPage_Up = 0xFF9A,
        /// <summary>
        /// The Numpad next key
        /// </summary>
        KPNext = 0xFF9B,
        /// <summary>
        /// The Numpad page down key
        /// </summary>
        KPPage_Down = 0xFF9B,
        /// <summary>
        /// The Numpad end key
        /// </summary>
        KPEnd = 0xFF9C,
        /// <summary>
        /// The Numpad begin key
        /// </summary>
        KPBegin = 0xFF9D,
        /// <summary>
        /// The Numpad insert key
        /// </summary>
        KPInsert = 0xFF9E,
        /// <summary>
        /// The Numpad delete key
        /// </summary>
        KPDelete = 0xFF9F,
        /// <summary>
        /// The Numpad equal key
        /// </summary>
        KPEqual = 0xFFBD,
        /// <summary>
        /// The Numpad multiply key
        /// </summary>
        KPMultiply = 0xFFAA,
        /// <summary>
        /// The Numpad add key
        /// </summary>
        KPAdd = 0xFFAB,
        /// <summary>
        /// The Numpad separator key
        /// </summary>
        KPSeparator = 0xFFAC,
        /// <summary>
        /// The Numpad subtract key
        /// </summary>
        KPSubtract = 0xFFAD,
        /// <summary>
        /// The Numpad decimal key
        /// </summary>
        KPDecimal = 0xFFAE,
        /// <summary>
        /// The Numpad divide key
        /// </summary>
        KPDivide = 0xFFAF,
        /// <summary>
        /// The Numpad 0 key
        /// </summary>
        KP0 = 0xFFB0,
        /// <summary>
        /// The Numpad 1 key
        /// </summary>
        KP1 = 0xFFB1,
        /// <summary>
        /// The Numpad 2 key
        /// </summary>
        KP2 = 0xFFB2,
        /// <summary>
        /// The Numpad 3 key
        /// </summary>
        KP3 = 0xFFB3,
        /// <summary>
        /// The Numpad 4 key
        /// </summary>
        KP4 = 0xFFB4,
        /// <summary>
        /// The Numpad 5 key
        /// </summary>
        KP5 = 0xFFB5,
        /// <summary>
        /// The Numpad 6 key
        /// </summary>
        KP6 = 0xFFB6,
        /// <summary>
        /// The Numpad 7 key
        /// </summary>
        KP7 = 0xFFB7,
        /// <summary>
        /// The Numpad 8 key
        /// </summary>
        KP8 = 0xFFB8,
        /// <summary>
        /// The Numpad 9 key
        /// </summary>
        KP9 = 0xFFB9,

        /* Auxiliary Functions */
        /// <summary>
        /// The function 1 key
        /// </summary>
        F1 = 0xFFBE,
        /// <summary>
        /// The function 2 key
        /// </summary>
        F2 = 0xFFBF,
        /// <summary>
        /// The function 3 key
        /// </summary>
        F3 = 0xFFC0,
        /// <summary>
        /// The function 4 key
        /// </summary>
        F4 = 0xFFC1,
        /// <summary>
        /// The function 5 key
        /// </summary>
        F5 = 0xFFC2,
        /// <summary>
        /// The function 6 key
        /// </summary>
        F6 = 0xFFC3,
        /// <summary>
        /// The function 7 key
        /// </summary>
        F7 = 0xFFC4,
        /// <summary>
        /// The function 8 key
        /// </summary>
        F8 = 0xFFC5,
        /// <summary>
        /// The function 9 key
        /// </summary>
        F9 = 0xFFC6,
        /// <summary>
        /// The function 10 key
        /// </summary>
        F10 = 0xFFC7,
        /// <summary>
        /// The function 11 key
        /// </summary>
        F11 = 0xFFC8,
        /// <summary>
        /// The function 12 key
        /// </summary>
        F12 = 0xFFC9,
        /// <summary>
        /// The function 13 key
        /// </summary>
        F13 = 0xFFCA,
        /// <summary>
        /// The function 14 key
        /// </summary>
        F14 = 0xFFCB,
        /// <summary>
        /// The function 15 key
        /// </summary>
        F15 = 0xFFCC,
        /// <summary>
        /// The function 16 key
        /// </summary>
        F16 = 0xFFCD,
        /// <summary>
        /// The function 17 key
        /// </summary>
        F17 = 0xFFCE,
        /// <summary>
        /// The function 18 key
        /// </summary>
        F18 = 0xFFCF,
        /// <summary>
        /// The function 19 key
        /// </summary>
        F19 = 0xFFD0,
        /// <summary>
        /// The function 20 key
        /// </summary>
        F20 = 0xFFD1,
        /// <summary>
        /// The function 21 key
        /// </summary>
        F21 = 0xFFD2,
        /// <summary>
        /// The function 22 key
        /// </summary>
        F22 = 0xFFD3,
        /// <summary>
        /// The function 23 key
        /// </summary>
        F23 = 0xFFD4,
        /// <summary>
        /// The function 24 key
        /// </summary>
        F24 = 0xFFD5,
        /// <summary>
        /// The function 25 key
        /// </summary>
        F25 = 0xFFD6,
        /// <summary>
        /// The function 26 key
        /// </summary>
        F26 = 0xFFD7,
        /// <summary>
        /// The function 27 key
        /// </summary>
        F27 = 0xFFD8,
        /// <summary>
        /// The function 28 key
        /// </summary>
        F28 = 0xFFD9,
        /// <summary>
        /// The function 29 key
        /// </summary>
        F29 = 0xFFDA,
        /// <summary>
        /// The function 30 key
        /// </summary>
        F30 = 0xFFDB,
        /// <summary>
        /// The function 31 key
        /// </summary>
        F31 = 0xFFDC,
        /// <summary>
        /// The function 32 key
        /// </summary>
        F32 = 0xFFDD,
        /// <summary>
        /// The function 33 key
        /// </summary>
        F33 = 0xFFDE,
        /// <summary>
        /// The function 34 key
        /// </summary>
        F34 = 0xFFDF,
        /// <summary>
        /// The function 35 key
        /// </summary>
        F35 = 0xFFE0,

        /* Modifier keys */
        /// <summary>
        /// The left shift key
        /// </summary>
        ShiftL = 0xFFE1,
        /// <summary>
        /// The right shift key
        /// </summary>
        ShiftR = 0xFFE2,
        /// <summary>
        /// The left control key
        /// </summary>
        ControlL = 0xFFE3,
        /// <summary>
        /// The right control key
        /// </summary>
        ControlR = 0xFFE4,
        /// <summary>
        /// The caps lock key
        /// </summary>
        CapsLock = 0xFFE5,
        /// <summary>
        /// The shift lock key
        /// </summary>
        ShiftLock = 0xFFE6,
        /// <summary>
        /// The left meta key
        /// </summary>
        MetaL = 0xFFE7,
        /// <summary>
        /// The right meta key
        /// </summary>
        MetaR = 0xFFE8,
        /// <summary>
        /// The left alt key
        /// </summary>
        AltL = 0xFFE9,
        /// <summary>
        /// The right alt key
        /// </summary>
        AltR = 0xFFEA,
        /// <summary>
        /// The left super key
        /// </summary>
        SuperL = 0xFFEB,
        /// <summary>
        /// The right super key
        /// </summary>
        SuperR = 0xFFEC,
        /// <summary>
        /// The left hyper key
        /// </summary>
        HyperL = 0xFFED,
        /// <summary>
        /// The right hyper key
        /// </summary>
        HyperR = 0xFFEE,

        /* Latin 1 */
        /// <summary>
        /// The space key
        /// </summary>
        Space = 0x020,
        /// <summary>
        /// The exclamation key
        /// </summary>
        Exclam = 0x021,
        /// <summary>
        /// The quotedbl key
        /// </summary>
        Quotedbl = 0x022,
        /// <summary>
        /// The number sign key
        /// </summary>
        NumberSign = 0x023,
        /// <summary>
        /// The dollar key
        /// </summary>
        Dollar = 0x024,
        /// <summary>
        /// The percent key
        /// </summary>
        Percent = 0x025,
        /// <summary>
        /// The ampersand key
        /// </summary>
        Ampersand = 0x026,
        /// <summary>
        /// The apostrophe key
        /// </summary>
        Apostrophe = 0x027,
        /// <summary>
        /// The parenleft key
        /// </summary>
        Parenleft = 0x028,
        /// <summary>
        /// The parenright key
        /// </summary>
        Parenright = 0x029,
        /// <summary>
        /// The asterisk key
        /// </summary>
        Asterisk = 0x02a,
        /// <summary>
        /// The plus key
        /// </summary>
        Plus = 0x02b,
        /// <summary>
        /// The comma key
        /// </summary>
        Comma = 0x02c,
        /// <summary>
        /// The minus key
        /// </summary>
        Minus = 0x02d,
        /// <summary>
        /// The period key
        /// </summary>
        Period = 0x02e,
        /// <summary>
        /// The slash key
        /// </summary>
        Slash = 0x02f,
        /// <summary>
        /// The 0 key
        /// </summary>
        Keypad0 = 0x030,
        /// <summary>
        /// The 1 key
        /// </summary>
        Keypad1 = 0x031,
        /// <summary>
        /// The 2 key
        /// </summary>
        Keypad2 = 0x032,
        /// <summary>
        /// The 3 key
        /// </summary>
        Keypad3 = 0x033,
        /// <summary>
        /// The 4 key
        /// </summary>
        Keypad4 = 0x034,
        /// <summary>
        /// The 5 key
        /// </summary>
        Keypad5 = 0x035,
        /// <summary>
        /// The 6 key
        /// </summary>
        Keypad6 = 0x036,
        /// <summary>
        /// The 7 key
        /// </summary>
        Keypad7 = 0x037,
        /// <summary>
        /// The 8 key
        /// </summary>
        Keypad8 = 0x038,
        /// <summary>
        /// The 9 key
        /// </summary>
        Keypad9 = 0x039,
        /// <summary>
        /// The colon key
        /// </summary>
        Colon = 0x03a,
        /// <summary>
        /// The semicolon key
        /// </summary>
        Semicolon = 0x03b,
        /// <summary>
        /// The less key
        /// </summary>
        Less = 0x03c,
        /// <summary>
        /// The equal key
        /// </summary>
        Equal = 0x03d,
        /// <summary>
        /// The greater key
        /// </summary>
        Greater = 0x03e,
        /// <summary>
        /// The question key
        /// </summary>
        Question = 0x03f,
        /// <summary>
        /// The at key
        /// </summary>
        At = 0x040,
        /// <summary>
        /// The A key
        /// </summary>
        KeypadA = 0x041,
        /// <summary>
        /// The B key
        /// </summary>
        KeypadB = 0x042,
        /// <summary>
        /// The C key
        /// </summary>
        KeypadC = 0x043,
        /// <summary>
        /// The D key
        /// </summary>
        KeypadD = 0x044,
        /// <summary>
        /// The E key
        /// </summary>
        KeypadE = 0x045,
        /// <summary>
        /// The F key
        /// </summary>
        KeypadF = 0x046,
        /// <summary>
        /// The G key
        /// </summary>
        KeypadG = 0x047,
        /// <summary>
        /// The H key
        /// </summary>
        KeypadH = 0x048,
        /// <summary>
        /// The I key
        /// </summary>
        KeypadI = 0x049,
        /// <summary>
        /// The J key
        /// </summary>
        KeypadJ = 0x04a,
        /// <summary>
        /// The K key
        /// </summary>
        KeypadK = 0x04b,
        /// <summary>
        /// The L key
        /// </summary>
        KeypadL = 0x04c,
        /// <summary>
        /// The M key
        /// </summary>
        KeypadM = 0x04d,
        /// <summary>
        /// The N key
        /// </summary>
        KeypadN = 0x04e,
        /// <summary>
        /// The O key
        /// </summary>
        KeypadO = 0x04f,
        /// <summary>
        /// The P key
        /// </summary>
        KeypadP = 0x050,
        /// <summary>
        /// The Q key
        /// </summary>
        KeypadQ = 0x051,
        /// <summary>
        /// The R key
        /// </summary>
        KeypadR = 0x052,
        /// <summary>
        /// The S key
        /// </summary>
        KeypadS = 0x053,
        /// <summary>
        /// The T key
        /// </summary>
        KeypadT = 0x054,
        /// <summary>
        /// The U key
        /// </summary>
        KeypadU = 0x055,
        /// <summary>
        /// The V key
        /// </summary>
        KeypadV = 0x056,
        /// <summary>
        /// The W key
        /// </summary>
        KeypadW = 0x057,
        /// <summary>
        /// The X key
        /// </summary>
        KeypadX = 0x058,
        /// <summary>
        /// The Y key
        /// </summary>
        KeypadY = 0x059,
        /// <summary>
        /// The Z key
        /// </summary>
        KeypadZ = 0x05a,
        /// <summary>
        /// The left bracket key
        /// </summary>
        BracketLeft = 0x05b,
        /// <summary>
        /// The backslash key
        /// </summary>
        Backslash = 0x05c,
        /// <summary>
        /// The right bracket key
        /// </summary>
        BracketRight = 0x05d,
        /// <summary>
        /// The circumflex key
        /// </summary>
        AsciiCircum = 0x05e,
        /// <summary>
        /// The underscore key
        /// </summary>
        Underscore = 0x05f,
        /// <summary>
        /// The grave key
        /// </summary>
        Grave = 0x060,
        /// <summary>
        /// The a key
        /// </summary>
        Keypada = 0x061,
        /// <summary>
        /// The b key
        /// </summary>
        Keypadb = 0x062,
        /// <summary>
        /// The c key
        /// </summary>
        Keypadc = 0x063,
        /// <summary>
        /// The d key
        /// </summary>
        Keypadd = 0x064,
        /// <summary>
        /// The e key
        /// </summary>
        Keypade = 0x065,
        /// <summary>
        /// The f key
        /// </summary>
        Keypadf = 0x066,
        /// <summary>
        /// The g key
        /// </summary>
        Keypadg = 0x067,
        /// <summary>
        /// The h key
        /// </summary>
        Keypadh = 0x068,
        /// <summary>
        /// The i key
        /// </summary>
        Keypadi = 0x069,
        /// <summary>
        /// The j key
        /// </summary>
        Keypadj = 0x06a,
        /// <summary>
        /// The k key
        /// </summary>
        Keypadk = 0x06b,
        /// <summary>
        /// The l key
        /// </summary>
        Keypadl = 0x06c,
        /// <summary>
        /// The m key
        /// </summary>
        Keypadm = 0x06d,
        /// <summary>
        /// The n key
        /// </summary>
        Keypadn = 0x06e,
        /// <summary>
        /// The o key
        /// </summary>
        Keypado = 0x06f,
        /// <summary>
        /// The p key
        /// </summary>
        Keypadp = 0x070,
        /// <summary>
        /// The q key
        /// </summary>
        Keypadq = 0x071,
        /// <summary>
        /// The r key
        /// </summary>
        Keypadr = 0x072,
        /// <summary>
        /// The s key
        /// </summary>
        Keypads = 0x073,
        /// <summary>
        /// The t key
        /// </summary>
        Keypadt = 0x074,
        /// <summary>
        /// The u key
        /// </summary>
        Keypadu = 0x075,
        /// <summary>
        /// The v key
        /// </summary>
        Keypadv = 0x076,
        /// <summary>
        /// The w key
        /// </summary>
        Keypadw = 0x077,
        /// <summary>
        /// The x key
        /// </summary>
        Keypadx = 0x078,
        /// <summary>
        /// The y key
        /// </summary>
        Keypady = 0x079,
        /// <summary>
        /// The z key
        /// </summary>
        Keypadz = 0x07a,
        /// <summary>
        /// The left brace key
        /// </summary>
        BraceLeft = 0x07b,
        /// <summary>
        /// The bar key
        /// </summary>
        Bar = 0x07c,
        /// <summary>
        /// The right brace key
        /// </summary>
        BraceRight = 0x07d,
        /// <summary>
        /// The tilde key
        /// </summary>
        AsciiTilde = 0x07e,
    };

    /// <summary>
    /// Enumeration of the key masks.
    /// The key masks indicate which modifier keys is pressed down during the keyboard hit.The special MASK_RELEASED indicates the key release event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum KeyMask
    {
        /// <summary>
        /// Key press event without modifier key
        /// </summary>
        Pressed = 0,
        /// <summary>
        /// The Shift key is pressed down
        /// </summary>
        Shift = (1 << 0),
        /// <summary>
        /// The CapsLock key is pressed down
        /// </summary>
        CapsLock = (1 << 1),
        /// <summary>
        /// The Control key is pressed down
        /// </summary>
        Control = (1 << 2),
        /// <summary>
        /// The Alt key is pressed down
        /// </summary>
        Alt = (1 << 3),
        /// <summary>
        /// The Meta key is pressed down
        /// </summary>
        Meta = (1 << 4),
        /// <summary>
        /// The Win (between Control and Alt) is pressed down
        /// </summary>
        Win = (1 << 5),
        /// <summary>
        /// The Hyper key is pressed down
        /// </summary>
        Hyper = (1 << 6),
        /// <summary>
        /// The NumLock key is pressed down
        /// </summary>
        NumLock = (1 << 7),
        /// <summary>
        /// Key release event
        /// </summary>
        Released = (1 << 15),
    }

    /// <summary>
    /// This class contains api's related to IME(Input method editor)
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public static class InputMethodEditor
    {
        private static Object thisLock = new Object();
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
        /// Structure representing ContextId
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
            /// compare whether ContextId are equal
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public bool Equals(ContextId other)
            {
                return this.Id == other.Id;
            }
        }

        /// <summary>
        /// rectangle representing the position and size of UI Control
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public struct Rect
        {
            /// <summary>
            /// The x position in screen
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public int x;

            /// <summary>
            /// The y position in screen
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public int y;

            /// <summary>
            /// The window width
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public int w;

            /// <summary>
            /// The window height
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public int h;
        }

        /// <summary>
        /// An Action with 1 out parameter
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="a">The out parameter</param>
        /// <since_tizen> 4 </since_tizen>
        public delegate void OutAction<T>(out T a);

        /// <summary>
        /// An Action with an array out parameter
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="a">The out parameter 1</param>
        /// <since_tizen> 4 </since_tizen>
        public delegate void OutArrayAction<T>(out T[] a);

        /// <summary>
        /// An Action with 3 Input Parameter returning a bool
        /// </summary>
        /// <typeparam name="T">Generic Type for Parameter 1</typeparam>
        /// <typeparam name="T1">Generic Type for Parameter 2</typeparam>
        /// <typeparam name="T2">Generic Type for Parameter 3</typeparam>
        /// <param name="a">The Input Parameter 1</param>
        /// <param name="b">The Input Parameter 2</param>
        /// <param name="c">The Input Parameter 3</param>
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
                lock (thisLock)
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
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<FocusedOutEventArgs> FocusedOut
        {
            add
            {
                lock (thisLock)
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<EventArgs> InputContextReset
        {
            add
            {
                lock (thisLock)
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<LanguageSetEventArgs> LanguageSet
        {
            add
            {
                lock (thisLock)
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
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<SetDataEventArgs> DataSet
        {
            add
            {
                lock (thisLock)
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
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<LayoutSetEventArgs> LayoutSet
        {
            add
            {
                lock (thisLock)
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
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<ReturnKeySetEventArgs> ReturnKeySet
        {
            add
            {
                lock (thisLock)
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
        /// <since_tizen> 4 </since_tizen>
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
        /// Called when the system display Language is changed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<DisplayLanguageChangedEventArgs> DisplayLanguageChanged
        {
            add
            {
                lock (thisLock)
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
            }
            remove
            {
                lock (thisLock)
                {
                    _displayLanguageChanged -= value;
                }
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
                lock (thisLock)
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
        /// <since_tizen> 4 </since_tizen>
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
        /// Sets the languageRequested Action
        /// </summary>
        /// <param name="languageRequested">
        /// Called when an associated text input UI control requests the language from the input panel, requesting for language code.
        /// </param>
        /// <since_tizen> 4 </since_tizen>
        public static void SetLanguageRequestedCallback(OutAction<string> languageRequested)
        {
            _imeLanguageRequestedDelegate = (IntPtr userData, out IntPtr langCode) =>
            {
                string langauage;
                _languageRequestedDelegate(out langauage);
                char[] languageArray = langauage.ToCharArray();
                langCode = new IntPtr();
                Marshal.Copy(languageArray, 0, langCode, languageArray.Length);
            };
            ErrorCode error = ImeEventSetLanguageRequestedCallbackCb(_imeLanguageRequestedDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Add SetLanguageRequestedCallback Failed with error " + error);
            }
            _languageRequestedDelegate = languageRequested;
        }

        /// <summary>
        /// Sets the processKey Action
        /// If the key event is from the external device, DeviceInfo will have its name, class and subclass information.
        /// </summary>
        /// <param name="processKey">
        /// The Action is alled when the key event is received from the external devices or SendKey function.
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
        /// Sets the imDataRequested Action
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
                data = new IntPtr();
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
        /// Sets the GeometryRequested Action
        /// </summary>
        /// <param name="geometryRequested">
        /// Called when an associated text input UI control requests the position and size from the input panel, requesting for x,y,w,h values.
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
        /// Runs the main loop of IME application.
        /// This function starts to run IME application's main loop.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <remarks>
        /// This API is a blocking call, as it starts the main loop of the application.
        /// </remarks>
        /// <param name="create">This is called to initialize IME application before the main loop starts up</param>
        /// <param name="terminate">This is called when IME application is terminated</param>
        /// <param name="show">
        /// This is called when IME application is shown
        /// It provides the Context Information and the Context Id
        /// </param>
        /// <param name="hide">
        /// This is called when IME application is hidden
        /// It provides the Context Id
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) Operation failed
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
        /// This function sends key down or up event with key mask to the client application. If forwardKey is true, this key event goes to the edit filed directly.
        /// And if forwardKey is false, the ProcessKey event receives the key event before the edit field.
        /// </remarks>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="keyCode">The key code to be sent</param>
        /// <param name="keyMask">The modifier key mask</param>
        /// <param name="forwardKey">The flag to send the key event directly to the edit field</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
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
        /// <param name="str">The string to be committed</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
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
        /// Requests to show preedit string.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
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
        /// Requests to hide preedit string.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
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
        /// Updates a new preedit string.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="str">The string to be updated in preedit</param>
        /// <param name="attrs">
        /// The list which has ime_preedit_attribute lists, strings can be composed of multiple string attributes: underline, highlight color and reversal color.
        /// The attrs list can be empty if no attributes to set
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// 3) Invalid Parameter
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public static void UpdatePreEditString(string str, IEnumerable<PreEditAttribute> attrs)
        {
            IntPtr einaList = IntPtr.Zero;
            List<GCHandle> attributeHandleList = new List<GCHandle>();
            foreach (PreEditAttribute attribute in attrs)
            {
                ImePreEditAttributeStruct imePreEditAttribute = new ImePreEditAttributeStruct();
                imePreEditAttribute.start = attribute.Start;
                imePreEditAttribute.length = attribute.Length;
                imePreEditAttribute.type = (int)attribute.Type;
                imePreEditAttribute.value = attribute.Value;
                GCHandle attributeHandle = GCHandle.Alloc(imePreEditAttribute, GCHandleType.Pinned);
                attributeHandleList.Add(attributeHandle);
                einaList = Interop.EinaList.EinaListAppend(einaList, attributeHandle.AddrOfPinnedObject());
            }
            ErrorCode error = ImeUpdatePreeditString(str, einaList);
            foreach (GCHandle handle in attributeHandleList)
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
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="maxLenBefore">The maximum length of string to be retrieved before the cursor, -1 means unlimited</param>
        /// <param name="maxLenAfter">The maximum length of string to be retrieved after the cursor, -1 means unlimited</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// </exception>
        /// <postcondition>
        /// The requested surrounding text can be received using the SurroundingTextUpdated Event, only if it is set.
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
        /// Requests to delete surrounding text.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="offset">The offset value from the cursor position</param>
        /// <param name="len">The length of the text to delete</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// 3) Invalid Parameter
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
        /// Requests to set selection.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <param name="start">The start cursor position in text (in characters not bytes)</param>
        /// <param name="end">The end cursor position in text (in characters not bytes)</param>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// 3) Invalid Parameter
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
        /// <returns>The input panel main window object on success, otherwise null</returns>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) IME main loop isn't started yet
        /// 3) Operation Failed
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
        /// This API requests the InputMethodEditor to initialize
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) Operation Failed
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
        /// This API requests the InputMethodEditor to finalize
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/ime
        /// </privilege>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) The application does not have the privilege to call this function
        /// 2) Operation Failed
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
    }
}
