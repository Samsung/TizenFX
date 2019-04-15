#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>An interface for duplication of objects.
/// Objects implementing this interface can be duplicated with <see cref="Efl.IDuplicate.DoDuplicate"/>.</summary>
[IDuplicateNativeInherit]
public interface IDuplicate : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Creates a carbon copy of this object and returns it.
/// The newly created object will have no event handlers or anything of the sort.</summary>
/// <returns>Returned carbon copy</returns>
Efl.IDuplicate DoDuplicate();
    }
/// <summary>An interface for duplication of objects.
/// Objects implementing this interface can be duplicated with <see cref="Efl.IDuplicate.DoDuplicate"/>.</summary>
sealed public class IDuplicateConcrete : 

IDuplicate
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IDuplicateConcrete))
                return Efl.IDuplicateNativeInherit.GetEflClassStatic();
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
        efl_duplicate_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IDuplicateConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IDuplicateConcrete()
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
    /// <summary>Creates a carbon copy of this object and returns it.
    /// The newly created object will have no event handlers or anything of the sort.</summary>
    /// <returns>Returned carbon copy</returns>
    public Efl.IDuplicate DoDuplicate() {
         var _ret_var = Efl.IDuplicateNativeInherit.efl_duplicate_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IDuplicateConcrete.efl_duplicate_interface_get();
    }
}
public class IDuplicateNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_duplicate_static_delegate == null)
            efl_duplicate_static_delegate = new efl_duplicate_delegate(duplicate);
        if (methods.FirstOrDefault(m => m.Name == "DoDuplicate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_duplicate"), func = Marshal.GetFunctionPointerForDelegate(efl_duplicate_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.IDuplicateConcrete.efl_duplicate_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.IDuplicateConcrete.efl_duplicate_interface_get();
    }


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.IDuplicateConcrete, Efl.Eo.OwnTag>))] private delegate Efl.IDuplicate efl_duplicate_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.IDuplicateConcrete, Efl.Eo.OwnTag>))] public delegate Efl.IDuplicate efl_duplicate_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_duplicate_api_delegate> efl_duplicate_ptr = new Efl.Eo.FunctionWrapper<efl_duplicate_api_delegate>(_Module, "efl_duplicate");
     private static Efl.IDuplicate duplicate(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_duplicate was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.IDuplicate _ret_var = default(Efl.IDuplicate);
            try {
                _ret_var = ((IDuplicate)wrapper).DoDuplicate();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_duplicate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_duplicate_delegate efl_duplicate_static_delegate;
}
} 
