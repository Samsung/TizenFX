#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Bidirectionaltext type</summary>
public enum TextBidirectionalType
{
/// <summary>Natural text type, same as neutral</summary>
Natural = 0,
/// <summary>Neutral text type, same as natural</summary>
Neutral = 0,
/// <summary>Left to right text type</summary>
Ltr = 1,
/// <summary>Right to left text type</summary>
Rtl = 2,
/// <summary>Inherit text type</summary>
Inherit = 3,
/// <summary>@internal EVAS_BIDI_DIRECTION_ANY_RTL is not made for public. It should be opened to public when it is accepted to EFL upstream.</summary>
AnyRtl = 4,
}

}

namespace Efl {

namespace Ui {

/// <summary>This structure includes all the information about content changes.
/// It&apos;s meant to be used to implement undo/redo.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct TextChangeInfo
{
    /// <summary>The content added/removed</summary>
    public System.String Content;
    /// <summary>The position where it was added/removed</summary>
    public uint Position;
    /// <summary>The length of content in characters (not bytes, actual unicode characters)</summary>
    public uint Length;
    /// <summary><c>true</c> if the content was inserted, <c>false</c> if removei</summary>
    public bool Insert;
    /// <summary><c>true</c> if can be merged with the previous one. Used for example with insertion when something is already selected</summary>
    public bool Merge;
    ///<summary>Constructor for TextChangeInfo.</summary>
    public TextChangeInfo(
        System.String Content = default(System.String),
        uint Position = default(uint),
        uint Length = default(uint),
        bool Insert = default(bool),
        bool Merge = default(bool)    )
    {
        this.Content = Content;
        this.Position = Position;
        this.Length = Length;
        this.Insert = Insert;
        this.Merge = Merge;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator TextChangeInfo(IntPtr ptr)
    {
        var tmp = (TextChangeInfo.NativeStruct)Marshal.PtrToStructure(ptr, typeof(TextChangeInfo.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct TextChangeInfo.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        ///<summary>Internal wrapper for field Content</summary>
        public System.IntPtr Content;
        
        public uint Position;
        
        public uint Length;
        ///<summary>Internal wrapper for field Insert</summary>
        public System.Byte Insert;
        ///<summary>Internal wrapper for field Merge</summary>
        public System.Byte Merge;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator TextChangeInfo.NativeStruct(TextChangeInfo _external_struct)
        {
            var _internal_struct = new TextChangeInfo.NativeStruct();
            _internal_struct.Content = Eina.MemoryNative.StrDup(_external_struct.Content);
            _internal_struct.Position = _external_struct.Position;
            _internal_struct.Length = _external_struct.Length;
            _internal_struct.Insert = _external_struct.Insert ? (byte)1 : (byte)0;
            _internal_struct.Merge = _external_struct.Merge ? (byte)1 : (byte)0;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator TextChangeInfo(TextChangeInfo.NativeStruct _internal_struct)
        {
            var _external_struct = new TextChangeInfo();
            _external_struct.Content = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Content);
            _external_struct.Position = _internal_struct.Position;
            _external_struct.Length = _internal_struct.Length;
            _external_struct.Insert = _internal_struct.Insert != 0;
            _external_struct.Merge = _internal_struct.Merge != 0;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

