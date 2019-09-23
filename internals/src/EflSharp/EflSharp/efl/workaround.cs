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

namespace Efl
{

[StructLayout(LayoutKind.Sequential)]
public struct EventDescription
{
    public IntPtr Name;
    [MarshalAs(UnmanagedType.U1)] public bool Unfreezable;
    [MarshalAs(UnmanagedType.U1)] public bool Legacy_is;
    [MarshalAs(UnmanagedType.U1)] public bool Restart;

    private static Dictionary<string, IntPtr> descriptions = new Dictionary<string, IntPtr>();

    public EventDescription(string module, string name)
    {
        this.Name = GetNative(module, name);
        this.Unfreezable = false;
        this.Legacy_is = false;
        this.Restart = false;
    }

    public static IntPtr GetNative(string module, string name)
    {
        if (!descriptions.ContainsKey(name))
        {
            IntPtr data = Efl.Eo.FunctionInterop.LoadFunctionPointer(module, name);

            if (data == IntPtr.Zero)
            {
                string error = Eina.StringConversion.NativeUtf8ToManagedString(Efl.Eo.Globals.dlerror());
                throw new Exception(error);
            }

            descriptions.Add(name, data);
        }

        return descriptions[name];
    }
};

/// <summary>
/// A parameter passed in event callbacks holding extra event parameters.
/// This is the full event information passed to callbacks in C.
/// (Since EFL 1.22)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct Event
{
    /// <summary>The object the callback was called on.
    /// (Since EFL 1.22)</summary>
    public Efl.Object Object;

    /// <summary>The event description.
    /// (Since EFL 1.22)</summary>
    public Efl.EventDescription Desc;

    /// <summary>Extra event information passed by the event caller.
    /// Must be cast to the event type declared in the EO file. Keep in mind that:
    /// 1) Objects are passed as a normal Eo*. Event subscribers can call functions on these objects.
    /// 2) Structs, built-in types and containers are passed as const pointers, with one level of indirection.
    /// (Since EFL 1.22)</summary>
    public System.IntPtr Info;

    /// <summary>Constructor for Event.</summary>
    public Event(
        Efl.Object obj = default(Efl.Object),
        Efl.EventDescription desc = default(Efl.EventDescription),
        System.IntPtr info = default(System.IntPtr))
    {
        this.Object = obj;
        this.Desc = desc;
        this.Info = info;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator Event(IntPtr ptr)
    {
        var tmp = (Event.NativeStruct) Marshal.PtrToStructure(ptr, typeof(Event.NativeStruct));
        return tmp;
    }

    /// <summary>Internal wrapper for struct Event.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        /// <summary>Internal wrapper for field Object</summary>
        public System.IntPtr Object;

        /// <summary>Internal wrapper for field Desc</summary>
        public System.IntPtr Desc;

        /// <summary>Internal wrapper for field Info</summary>
        public System.IntPtr Info;

        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        /// <param name="externalStruct">Managed struct to be converted.</param>
        /// <returns>Native representation of the managed struct.</returns>
        public static implicit operator Event.NativeStruct(Event externalStruct)
        {
            var internalStruct = new Event.NativeStruct();
            internalStruct.Object = externalStruct.Object?.NativeHandle ?? System.IntPtr.Zero;
            internalStruct.Desc = Eina.PrimitiveConversion.ManagedToPointerAlloc(externalStruct.Desc);
            internalStruct.Info = externalStruct.Info;
            return internalStruct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        /// <param name="internalStruct">Native struct to be converted.</param>
        /// <returns>Managed representation of the native struct.</returns>
        public static implicit operator Event(Event.NativeStruct internalStruct)
        {
            var externalStruct = new Event();
            externalStruct.Object = (Efl.Object) Efl.Eo.Globals.CreateWrapperFor(internalStruct.Object);
            externalStruct.Desc = Eina.PrimitiveConversion.PointerToManaged<Efl.EventDescription>(internalStruct.Desc);
            externalStruct.Info = internalStruct.Info;
            return externalStruct;
        }
    }
}

public delegate void EventCb(System.IntPtr data, ref Event.NativeStruct evt);
public delegate void FreeWrapperSupervisorCb(System.IntPtr obj);

[StructLayout(LayoutKind.Sequential)]
public struct TextCursorCursor
{
    IntPtr obj;
    UIntPtr pos; // UIntPtr to automatically change size_t between 32/64
    IntPtr node;
    [MarshalAsAttribute(UnmanagedType.U1)]bool changed;
}

[StructLayout(LayoutKind.Sequential)]
public struct TextAnnotateAnnotation
{
    IntPtr list;
    IntPtr obj;
    IntPtr start_node;
    IntPtr end_node;
    [MarshalAsAttribute(UnmanagedType.U1)]bool is_item;
}

namespace Access
{

public delegate IntPtr ReadingInfoCb(System.IntPtr data, ref Efl.Canvas.Object obj);

public delegate bool GestureCb(System.IntPtr data, ref Efl.Access.GestureInfo info, ref Efl.Canvas.Object obj);

public struct ActionData
{
    public IntPtr name;
    public IntPtr action;
    public IntPtr param;
    public IntPtr func;
}

} // namespace Access

} // namespace Efl

// Global delegates
public delegate int Eina_Compare_Cb(IntPtr a, IntPtr b);
public delegate void EinaFreeCb(IntPtr data);
public delegate void EvasSmartCb(IntPtr data, IntPtr obj, IntPtr event_info);
