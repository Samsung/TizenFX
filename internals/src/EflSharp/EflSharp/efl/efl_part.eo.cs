#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Interface for objects supporting named parts.
/// An object implementing this interface will be able to provide access to some of its sub-objects by name. This gives access to parts as defined in a widget&apos;s theme.
/// 
/// Part proxy objects have a special lifetime that is limited to one and only one function call. This behavior is implemented in efl_part() which call Efl.Part.part_get(). Calling Efl.Part.part_get() directly should be avoided.
/// 
/// In other words, the caller does not hold a reference to this proxy object. It may be possible, in languages that allow it, to get an extra reference to this part object and extend its lifetime to more than a single function call.
/// 
/// In pseudo-code, this means only the following two use cases are supported:
/// 
/// obj.func(part(obj, &quot;part&quot;), args)
/// 
/// And:
/// 
/// part = ref(part(obj, &quot;part&quot;)) func1(part, args) func2(part, args) func3(part, args) unref(part)
/// (Since EFL 1.22)</summary>
[IPartNativeInherit]
public interface IPart : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Get a proxy object referring to a part of an object.
/// (Since EFL 1.22)</summary>
/// <param name="name">The part name.</param>
/// <returns>A (proxy) object, valid for a single call.</returns>
Efl.Object GetPart( System.String name);
    }
/// <summary>Interface for objects supporting named parts.
/// An object implementing this interface will be able to provide access to some of its sub-objects by name. This gives access to parts as defined in a widget&apos;s theme.
/// 
/// Part proxy objects have a special lifetime that is limited to one and only one function call. This behavior is implemented in efl_part() which call Efl.Part.part_get(). Calling Efl.Part.part_get() directly should be avoided.
/// 
/// In other words, the caller does not hold a reference to this proxy object. It may be possible, in languages that allow it, to get an extra reference to this part object and extend its lifetime to more than a single function call.
/// 
/// In pseudo-code, this means only the following two use cases are supported:
/// 
/// obj.func(part(obj, &quot;part&quot;), args)
/// 
/// And:
/// 
/// part = ref(part(obj, &quot;part&quot;)) func1(part, args) func2(part, args) func3(part, args) unref(part)
/// (Since EFL 1.22)</summary>
sealed public class IPartConcrete : 

IPart
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IPartConcrete))
                return Efl.IPartNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle {
        get { return handle; }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_part_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IPartConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IPartConcrete()
    {
        Dispose(false);
    }
    ///<summary>Releases the underlying native instance.</summary>
    void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero) {
            Efl.Eo.Globals.efl_unref(handle);
            handle = System.IntPtr.Zero;
        }
    }
    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    ///<summary>Verifies if the given object is equal to this one.</summary>
    public override bool Equals(object obj)
    {
        var other = obj as Efl.Object;
        if (other == null)
            return false;
        return this.NativeHandle == other.NativeHandle;
    }
    ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }
    ///<summary>Turns the native pointer into a string representation.</summary>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }
    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
    }
    /// <summary>Get a proxy object referring to a part of an object.
    /// (Since EFL 1.22)</summary>
    /// <param name="name">The part name.</param>
    /// <returns>A (proxy) object, valid for a single call.</returns>
    public Efl.Object GetPart( System.String name) {
                                 var _ret_var = Efl.IPartNativeInherit.efl_part_get_ptr.Value.Delegate(this.NativeHandle, name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IPartConcrete.efl_part_interface_get();
    }
}
public class IPartNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_part_get_static_delegate == null)
            efl_part_get_static_delegate = new efl_part_get_delegate(part_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPart") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_part_get"), func = Marshal.GetFunctionPointerForDelegate(efl_part_get_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.IPartConcrete.efl_part_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.IPartConcrete.efl_part_interface_get();
    }


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_part_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Object efl_part_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String name);
     public static Efl.Eo.FunctionWrapper<efl_part_get_api_delegate> efl_part_get_ptr = new Efl.Eo.FunctionWrapper<efl_part_get_api_delegate>(_Module, "efl_part_get");
     private static Efl.Object part_get(System.IntPtr obj, System.IntPtr pd,  System.String name)
    {
        Eina.Log.Debug("function efl_part_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Efl.Object _ret_var = default(Efl.Object);
            try {
                _ret_var = ((IPart)wrapper).GetPart( name);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_part_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
        }
    }
    private static efl_part_get_delegate efl_part_get_static_delegate;
}
} 
