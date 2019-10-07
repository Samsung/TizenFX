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
public struct UIKit_Op_Description
{
    ///<summary>The EAPI function offering this op. (String with the name of the function on Windows)</summary>
    public IntPtr api_func;
    ///<summary>The static function to be called for this op</summary>
    public IntPtr func;
}

///<summary>List of operations on a given Object.</summary>
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
public struct UIKit_Object_Ops
{
    ///<summary>The op descriptions array of size count.</summary>
    public IntPtr descs;
    ///<summary>Number of op descriptions.</summary>
    public UIntPtr count;
};

namespace UIKit
{

///<summary>This struct holds the description of a specific event (Since EFL 1.22).</summary>
[StructLayout(LayoutKind.Sequential)]
public struct EventDescription
{
    ///<summary>Name of the event.</summary>
    public IntPtr Name;
    ///<summary><c>true</c> if the event cannot be frozen.</summary>
    [MarshalAs(UnmanagedType.U1)] public bool Unfreezable;
    ///<summary>Internal use: <c>true</c> if this is a legacy event.</summary>
    [MarshalAs(UnmanagedType.U1)] public bool Legacy_is;
    ///<summary><c>true</c> if when the even is triggered again from a callback it
    ///will start from where it was.</summary>
    [MarshalAs(UnmanagedType.U1)] public bool Restart;

    private static Dictionary<string, IntPtr> descriptions = new Dictionary<string, IntPtr>();

    ///<summary>Constructor for EventDescription</summary>
    ///<param name="moduleName">The name of the module containing the event.</param>
    ///<param name="name">The name of the event.</param>
    public EventDescription(string moduleName, string name)
    {
        this.Name = GetNative(moduleName, name);
        this.Unfreezable = false;
        this.Legacy_is = false;
        this.Restart = false;
    }

    ///<summary>Get the native structure.</summary>
    ///<param name="moduleName">The name of the module containing the event.</param>
    ///<param name="name">The name of the event.</param>
    ///<returns>Pointer to the native structure.</returns>
    public static IntPtr GetNative(string moduleName, string name)
    {
        if (!descriptions.ContainsKey(name))
        {
            IntPtr data = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(moduleName, name);

            if (data == IntPtr.Zero)
            {
                string error = UIKit.DataTypes.StringConversion.NativeUtf8ToManagedString(UIKit.Wrapper.Globals.dlerror());
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
[UIKit.Wrapper.BindingEntity]
public struct Event
{
    /// <summary>The object the callback was called on.
    /// (Since EFL 1.22)</summary>
    public UIKit.Object Object;

    /// <summary>The event description.
    /// (Since EFL 1.22)</summary>
    public UIKit.EventDescription Desc;

    /// <summary>Extra event information passed by the event caller.
    /// Must be cast to the event type declared in the EO file. Keep in mind that:
    /// 1) Objects are passed as a normal Eo*. Event subscribers can call functions on these objects.
    /// 2) Structs, built-in types and containers are passed as const pointers, with one level of indirection.
    /// (Since EFL 1.22)</summary>
    public System.IntPtr Info;

    /// <summary>Constructor for Event.</summary>
    public Event(
        UIKit.Object obj = default(UIKit.Object),
        UIKit.EventDescription desc = default(UIKit.EventDescription),
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
            internalStruct.Desc = UIKit.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(externalStruct.Desc);
            internalStruct.Info = externalStruct.Info;
            return internalStruct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        /// <param name="internalStruct">Native struct to be converted.</param>
        /// <returns>Managed representation of the native struct.</returns>
        public static implicit operator Event(Event.NativeStruct internalStruct)
        {
            var externalStruct = new Event();
            externalStruct.Object = (UIKit.Object) UIKit.Wrapper.Globals.CreateWrapperFor(internalStruct.Object);
            externalStruct.Desc = UIKit.DataTypes.PrimitiveConversion.PointerToManaged<UIKit.EventDescription>(internalStruct.Desc);
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

public delegate IntPtr ReadingInfoCb(System.IntPtr data, ref UIKit.Canvas.Object obj);

//public delegate bool GestureCb(System.IntPtr data, ref UIKit.Access.GestureInfo info, ref UIKit.Canvas.Object obj);

public struct ActionData
{
    public IntPtr name;
    public IntPtr action;
    public IntPtr param;
    public IntPtr func;
}

} // namespace Access

} // namespace UIKit

// Global delegates
public delegate void EinaFreeCb(IntPtr data);
public delegate void EvasSmartCb(IntPtr data, IntPtr obj, IntPtr event_info);
