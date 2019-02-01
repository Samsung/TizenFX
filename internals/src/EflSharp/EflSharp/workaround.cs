#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

///<summary>Eo class description, passed to efl_class_new.</summary>
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
public struct ClassDescription
{
    ///<summary>Current Eo version.</summary>
    public uint version;
    ///<summary>Name of the class.</summary>
    [MarshalAs(UnmanagedType.LPStr)] public String name;
    ///<summary>Class type.</summary>
    public int class_type;
    ///<summary>Size of data (private + protected + public) per instance.</summary>
    public UIntPtr data_size;
    ///<summary>Initializer for the class.</summary>
    public IntPtr class_initializer;
    ///<summary>Constructor of the class.</summary>
    public IntPtr class_constructor;
    ///<summary>Destructor of the class.</summary>
    public IntPtr class_destructor;
}

///<summary>Description of an Eo API operation.</summary>
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
public struct Efl_Op_Description
{
    ///<summary>The EAPI function offering this op. (String with the name of the function on Windows)</summary>
    public IntPtr api_func;
    ///<summary>The static function to be called for this op</summary>
    public IntPtr func;
}

///<summary>List of operations on a given Object.</summary>
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
public struct Efl_Object_Ops
{
    ///<summary>The op descriptions array of size count.</summary>
    public IntPtr descs;
    ///<summary>Number of op descriptions.</summary>
    public UIntPtr count;
};

[StructLayout(LayoutKind.Sequential)]
public struct EolianPD
{
    public IntPtr pointer;
}

#pragma warning disable 0169
public struct EvasObjectBoxLayout
{
    IntPtr o;
    IntPtr priv;
    IntPtr user_data;
};
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
public struct EvasObjectBoxData
{
}
public struct EvasObjectBoxOption {
    IntPtr obj;
    [MarshalAsAttribute(UnmanagedType.U1)] bool max_reached;
    [MarshalAsAttribute(UnmanagedType.U1)] bool min_reached;
    Evas.Coord alloc_size;
};
#pragma warning restore 0169

namespace Efl {

[StructLayout(LayoutKind.Sequential)]
public struct EventDescription {
    public IntPtr Name;
    [MarshalAs(UnmanagedType.U1)] public bool Unfreezable;
    [MarshalAs(UnmanagedType.U1)] public bool Legacy_is;
    [MarshalAs(UnmanagedType.U1)] public bool Restart;

    private static Dictionary<string, IntPtr> descriptions = new Dictionary<string, IntPtr>();

    public EventDescription(string name)
    {
        this.Name = GetNative(name);
        this.Unfreezable = false;
        this.Legacy_is = false;
        this.Restart = false;
    }

    public static IntPtr GetNative(string name)
    {
        if (!descriptions.ContainsKey(name))
        {
            IntPtr data = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, name);

            if (data == IntPtr.Zero) {
                string error = Eina.StringConversion.NativeUtf8ToManagedString(Efl.Eo.Globals.dlerror());
                throw new Exception(error);
            }
            descriptions.Add(name, data);
        }
        return descriptions[name];
    }
};

public delegate void EventCb(System.IntPtr data, ref Event_StructInternal evt);

[StructLayout(LayoutKind.Sequential)]
public struct TextCursorCursor {
    IntPtr obj;
    UIntPtr pos; // UIntPtr to automatically change size_t between 32/64
    IntPtr node;
    [MarshalAsAttribute(UnmanagedType.U1)]bool changed;
}

[StructLayout(LayoutKind.Sequential)]
public struct TextAnnotateAnnotation {
    IntPtr list;
    IntPtr obj;
    IntPtr start_node;
    IntPtr end_node;
    [MarshalAsAttribute(UnmanagedType.U1)]bool is_item;
}

public delegate void SignalCb(IntPtr data, IntPtr obj, IntPtr emission, IntPtr source);

namespace Access {

public delegate IntPtr ReadingInfoCb(System.IntPtr data, ref Efl.Canvas.Object obj);

public delegate bool GestureCb(System.IntPtr data, ref Efl.Access.GestureInfo info, ref Efl.Canvas.Object obj);

public struct ReadingInfoTypeMask {
    private uint mask;

    public static implicit operator ReadingInfoTypeMask(uint x)
    {
        return new ReadingInfoTypeMask{mask=x};
    }
    public static implicit operator uint(ReadingInfoTypeMask x)
    {
        return x.mask;
    }
}

public struct ActionData {
    public IntPtr name;
    public IntPtr action;
    public IntPtr param;
    public IntPtr func;
}

} // namespace Access

} // namespace Efl

namespace Evas {

public struct Coord {
    int val;

    public Coord(int value) { val = value; }
    static public implicit operator Coord(int val) {
        return new Coord(val);
    }
    static public implicit operator int(Coord coord) {
        return coord.val;
    }
}

/* Copied from Evas_Legacy.h */
public enum TextStyleType
{
   ///<summary> plain, standard text.</summary>
   Plain = 0,
   ///<summary> text with shadow underneath.</summary>
   Shadow,
   ///<summary> text with an outline.</summary>
   Outline,
   ///<summary> text with a soft outline.</summary>
   SoftOutline,
   ///<summary> text with a glow effect.</summary>
   Glow,
   ///<summary> text with both outline and shadow effects.</summary>
   OutlineShadow,
   ///<summary> text with (far) shadow underneath.</summary>
   FarShadow,
   ///<summary> text with outline and soft shadow effects combined.</summary>
   OutlineSoftShadow,
   ///<summary> text with (soft) shadow underneath.</summary>
   SoftShadow,
   ///<summary> text with (far soft) shadow underneath.</summary>
   FarSoftShadow,

   // Shadow direction modifiers
   ///<summary> shadow growing to bottom right.</summary>
   ShadowDirectionBottomRight = 0 /* 0 >> 4 */,
  ///<summary> shadow growing to the bottom.</summary>
   ShadowDirectionBottom= 16 /* 1 >> 4 */,
   ///<summary> shadow growing to bottom left.</summary>
   ShadowDirectionBottomLeft = 32 /* 2 >> 4 */,
   ///<summary> shadow growing to the left.</summary>
   ShadowDirectionLeft = 48 /* 3 >> 4 */,
   ///<summary> shadow growing to top left.</summary>
   ShadowDirectionTopLeft = 64 /* 4 >> 4 */,
   ///<summary> shadow growing to the top.</summary>
   ShadowDirectionTop = 80 /* 5 >> 4 */,
   ///<summary> shadow growing to top right.</summary>
   ShadowDirectionTopRight = 96 /* 6 >> 4 */,
   ///<summary> shadow growing to the right.</summary>
   ShadowDirectionRight = 112 /* 7 >> 4 */
};

} // namespace Evas

// Global delegates
public delegate int Eina_Compare_Cb(IntPtr a, IntPtr b);
public delegate void ElmInterfaceScrollableCb(IntPtr obj, IntPtr data);
public delegate void ElmInterfaceScrollableMinLimitCb(IntPtr obj,
                                                     [MarshalAsAttribute(UnmanagedType.U1)]bool w,
                                                     [MarshalAsAttribute(UnmanagedType.U1)]bool h);
public delegate void ElmInterfaceScrollableResizeCb(IntPtr obj, Evas.Coord w, Evas.Coord h);
[return: MarshalAsAttribute(UnmanagedType.U1)]
public delegate bool ElmMultibuttonentryItemFilterCb(IntPtr obj, IntPtr item_label, IntPtr item_data, IntPtr data);
public delegate IntPtr ElmMultibuttonentryFormatCb(int count, IntPtr data);
public delegate void EinaFreeCb(IntPtr data);
public delegate void EvasSmartCb(IntPtr data, IntPtr obj, IntPtr event_info);
public delegate void ElmObjectItemSignalCb(IntPtr data, IntPtr item, IntPtr emission, IntPtr source);
public delegate void ElmTooltipItemContentCb(IntPtr data, IntPtr obj, IntPtr tooltip, IntPtr item);
