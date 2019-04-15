#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Type of a part in an Efl.Canvas.Layout object (edje object).</summary>
public enum LayoutPartType
{
/// <summary>None type value, indicates invalid parts.</summary>
None = 0,
/// <summary>Rectangle type value.</summary>
Rectangle = 1,
/// <summary>Text type value.</summary>
Text = 2,
/// <summary>Image type value.</summary>
Image = 3,
/// <summary>Swallow  type value.</summary>
Swallow = 4,
/// <summary>Text block type value.</summary>
Textblock = 5,
/// <summary>Gradient type value.</summary>
Gradient = 6,
/// <summary>Group type value.</summary>
Group = 7,
/// <summary>Box type value.</summary>
Box = 8,
/// <summary>Table type value.</summary>
Table = 9,
/// <summary>External type value.</summary>
External = 10,
/// <summary>Proxy type value.</summary>
Proxy = 11,
/// <summary>Spacer type value
/// (Since EFL 1.7.)</summary>
Spacer = 12,
/// <summary>Canvas 3D type: mesh node.</summary>
MeshNode = 13,
/// <summary>Canvas 3D type: light.</summary>
Light = 14,
/// <summary>Canvas 3D type: camera.</summary>
Camera = 15,
/// <summary>Snapshot
/// (Since EFL 1.16.)</summary>
Snapshot = 16,
/// <summary>Vector
/// (Since EFL 1.18.)</summary>
Vector = 17,
/// <summary>Last type value.</summary>
Last = 18,
}
} } 
namespace Edje { 
/// <summary>All available cursor states</summary>
public enum Cursor
{
/// <summary>Main cursor state</summary>
Main = 0,
/// <summary>Selection begin cursor state</summary>
SelectionBegin = 1,
/// <summary>Selection end cursor state</summary>
SelectionEnd = 2,
/// <summary>Pre-edit start cursor state</summary>
PreeditStart = 3,
/// <summary>Pre-edit end cursor state</summary>
PreeditEnd = 4,
/// <summary>User cursor state</summary>
User = 5,
/// <summary>User extra cursor state</summary>
UserExtra = 6,
}
} 
namespace Edje { namespace Text { 
/// <summary>All Text auto capital mode type values</summary>
public enum AutocapitalType
{
/// <summary>None mode value</summary>
None = 0,
/// <summary>Word mode value</summary>
Word = 1,
/// <summary>Sentence mode value</summary>
Sentence = 2,
/// <summary>All characters mode value</summary>
Allcharacter = 3,
}
} } 
namespace Edje { 
/// <summary>Input hints</summary>
public enum InputHints
{
/// <summary>No active hints
/// (Since EFL 1.12)</summary>
None = 0,
/// <summary>Suggest word auto completion
/// (Since EFL 1.12)</summary>
AutoComplete = 1,
/// <summary>Typed text should not be stored.
/// (Since EFL 1.12)</summary>
SensitiveData = 2,
}
} 
namespace Edje { namespace InputPanel { 
/// <summary>Input panel language</summary>
public enum Lang
{
/// <summary>Automatic
/// (Since EFL 1.2)</summary>
Automatic = 0,
/// <summary>Alphabet
/// (Since EFL 1.2)</summary>
Alphabet = 1,
}
} } 
namespace Edje { namespace InputPanel { 
/// <summary>Input panel return key types</summary>
public enum ReturnKeyType
{
/// <summary>Default
/// (Since EFL 1.2)</summary>
Default = 0,
/// <summary>Done
/// (Since EFL 1.2)</summary>
Done = 1,
/// <summary>Go
/// (Since EFL 1.2)</summary>
Go = 2,
/// <summary>Join
/// (Since EFL 1.2)</summary>
Join = 3,
/// <summary>Login
/// (Since EFL 1.2)</summary>
Login = 4,
/// <summary>Next
/// (Since EFL 1.2)</summary>
Next = 5,
/// <summary>Search or magnifier icon
/// (Since EFL 1.2)</summary>
Search = 6,
/// <summary>Send
/// (Since EFL 1.2)</summary>
Send = 7,
/// <summary>Sign-in
/// (Since EFL 1.8)</summary>
Signin = 8,
}
} } 
namespace Edje { namespace InputPanel { 
/// <summary>Input panel layout</summary>
public enum Layout
{
/// <summary>Default layout</summary>
Normal = 0,
/// <summary>Number layout</summary>
Number = 1,
/// <summary>Email layout</summary>
Email = 2,
/// <summary>URL layout</summary>
Url = 3,
/// <summary>Phone Number layout</summary>
Phonenumber = 4,
/// <summary>IP layout</summary>
Ip = 5,
/// <summary>Month layout</summary>
Month = 6,
/// <summary>Number Only layout</summary>
Numberonly = 7,
/// <summary>Never use this</summary>
Invalid = 8,
/// <summary>Hexadecimal layout
/// (Since EFL 1.2)</summary>
Hex = 9,
/// <summary>Command-line terminal layout including esc, alt, ctrl key, so on (no auto-correct, no auto-capitalization)
/// (Since EFL 1.2)</summary>
Terminal = 10,
/// <summary>Like normal, but no auto-correct, no auto-capitalization etc.
/// (Since EFL 1.2)</summary>
Password = 11,
/// <summary>Date and time layout
/// (Since EFL 1.8)</summary>
Datetime = 12,
/// <summary>Emoticon layout
/// (Since EFL 1.10)</summary>
Emoticon = 13,
/// <summary>Voice layout, but if the IME does not support voice layout, then normal layout will be shown.
/// (Since EFL 1.19)</summary>
Voice = 14,
}
} } 
namespace Edje { 
/// <summary>Perspective info for maps inside edje objects</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Perspective
{
    ///<summary>Placeholder field</summary>
    public IntPtr field;
    public static implicit operator Perspective(IntPtr ptr)
    {
        var tmp = (Perspective.NativeStruct)Marshal.PtrToStructure(ptr, typeof(Perspective.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct Perspective.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator Perspective.NativeStruct(Perspective _external_struct)
        {
            var _internal_struct = new Perspective.NativeStruct();
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator Perspective(Perspective.NativeStruct _internal_struct)
        {
            var _external_struct = new Perspective();
            return _external_struct;
        }

    }

}

} 
