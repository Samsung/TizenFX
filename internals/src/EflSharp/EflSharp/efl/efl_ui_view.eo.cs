#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI view interface</summary>
[IViewNativeInherit]
public interface IView : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Model that is/will be</summary>
/// <returns>Efl model</returns>
Efl.IModel GetModel();
    /// <summary>Model that is/will be</summary>
/// <param name="model">Efl model</param>
/// <returns></returns>
void SetModel( Efl.IModel model);
            /// <summary>Model that is/will be</summary>
/// <value>Efl model</value>
    Efl.IModel Model {
        get ;
        set ;
    }
}
/// <summary>Efl UI view interface</summary>
sealed public class IViewConcrete : 

IView
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IViewConcrete))
                return Efl.Ui.IViewNativeInherit.GetEflClassStatic();
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
        efl_ui_view_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IViewConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IViewConcrete()
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
    /// <summary>Model that is/will be</summary>
    /// <returns>Efl model</returns>
    public Efl.IModel GetModel() {
         var _ret_var = Efl.Ui.IViewNativeInherit.efl_ui_view_model_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Model that is/will be</summary>
    /// <param name="model">Efl model</param>
    /// <returns></returns>
    public void SetModel( Efl.IModel model) {
                                 Efl.Ui.IViewNativeInherit.efl_ui_view_model_set_ptr.Value.Delegate(this.NativeHandle, model);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Model that is/will be</summary>
/// <value>Efl model</value>
    public Efl.IModel Model {
        get { return GetModel(); }
        set { SetModel( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IViewConcrete.efl_ui_view_interface_get();
    }
}
public class IViewNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_view_model_get_static_delegate == null)
            efl_ui_view_model_get_static_delegate = new efl_ui_view_model_get_delegate(model_get);
        if (methods.FirstOrDefault(m => m.Name == "GetModel") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_view_model_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_get_static_delegate)});
        if (efl_ui_view_model_set_static_delegate == null)
            efl_ui_view_model_set_static_delegate = new efl_ui_view_model_set_delegate(model_set);
        if (methods.FirstOrDefault(m => m.Name == "SetModel") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_view_model_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_set_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.IViewConcrete.efl_ui_view_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IViewConcrete.efl_ui_view_interface_get();
    }


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.IModelConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.IModel efl_ui_view_model_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.IModelConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.IModel efl_ui_view_model_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_view_model_get_api_delegate> efl_ui_view_model_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_view_model_get_api_delegate>(_Module, "efl_ui_view_model_get");
     private static Efl.IModel model_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_view_model_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.IModel _ret_var = default(Efl.IModel);
            try {
                _ret_var = ((IView)wrapper).GetModel();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_view_model_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_view_model_get_delegate efl_ui_view_model_get_static_delegate;


     private delegate void efl_ui_view_model_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.IModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.IModel model);


     public delegate void efl_ui_view_model_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.IModelConcrete, Efl.Eo.NonOwnTag>))]  Efl.IModel model);
     public static Efl.Eo.FunctionWrapper<efl_ui_view_model_set_api_delegate> efl_ui_view_model_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_view_model_set_api_delegate>(_Module, "efl_ui_view_model_set");
     private static void model_set(System.IntPtr obj, System.IntPtr pd,  Efl.IModel model)
    {
        Eina.Log.Debug("function efl_ui_view_model_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IView)wrapper).SetModel( model);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_view_model_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  model);
        }
    }
    private static efl_ui_view_model_set_delegate efl_ui_view_model_set_static_delegate;
}
} } 
