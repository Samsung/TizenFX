#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { namespace Focus { 
/// <summary>EFL UI Focus Parent Provider interface</summary>
[IParentProviderNativeInherit]
public interface IParentProvider : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Called to get the logical parent of widget</summary>
/// <param name="widget">Object to find parent for</param>
/// <returns>Parent of parameter object</returns>
Efl.Ui.Focus.IObject FindLogicalParent( Efl.Ui.Focus.IObject widget);
    }
/// <summary>EFL UI Focus Parent Provider interface</summary>
sealed public class IParentProviderConcrete : 

IParentProvider
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IParentProviderConcrete))
                return Efl.Ui.Focus.IParentProviderNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle {
        get { return handle; }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_focus_parent_provider_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IParentProviderConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IParentProviderConcrete()
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
    /// <summary>Called to get the logical parent of widget</summary>
    /// <param name="widget">Object to find parent for</param>
    /// <returns>Parent of parameter object</returns>
    public Efl.Ui.Focus.IObject FindLogicalParent( Efl.Ui.Focus.IObject widget) {
                                 var _ret_var = Efl.Ui.Focus.IParentProviderNativeInherit.efl_ui_focus_parent_provider_find_logical_parent_ptr.Value.Delegate(this.NativeHandle, widget);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.IParentProviderConcrete.efl_ui_focus_parent_provider_interface_get();
    }
}
public class IParentProviderNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_focus_parent_provider_find_logical_parent_static_delegate == null)
            efl_ui_focus_parent_provider_find_logical_parent_static_delegate = new efl_ui_focus_parent_provider_find_logical_parent_delegate(find_logical_parent);
        if (methods.FirstOrDefault(m => m.Name == "FindLogicalParent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_parent_provider_find_logical_parent"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_parent_provider_find_logical_parent_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.Focus.IParentProviderConcrete.efl_ui_focus_parent_provider_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.IParentProviderConcrete.efl_ui_focus_parent_provider_interface_get();
    }


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.IObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.IObject efl_ui_focus_parent_provider_find_logical_parent_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.IObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.IObject widget);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.IObjectConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.IObject efl_ui_focus_parent_provider_find_logical_parent_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.IObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.IObject widget);
     public static Efl.Eo.FunctionWrapper<efl_ui_focus_parent_provider_find_logical_parent_api_delegate> efl_ui_focus_parent_provider_find_logical_parent_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_parent_provider_find_logical_parent_api_delegate>(_Module, "efl_ui_focus_parent_provider_find_logical_parent");
     private static Efl.Ui.Focus.IObject find_logical_parent(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.IObject widget)
    {
        Eina.Log.Debug("function efl_ui_focus_parent_provider_find_logical_parent was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Efl.Ui.Focus.IObject _ret_var = default(Efl.Ui.Focus.IObject);
            try {
                _ret_var = ((IParentProvider)wrapper).FindLogicalParent( widget);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_ui_focus_parent_provider_find_logical_parent_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  widget);
        }
    }
    private static efl_ui_focus_parent_provider_find_logical_parent_delegate efl_ui_focus_parent_provider_find_logical_parent_static_delegate;
}
} } } 
