#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI Property interface. view object can have <see cref="Efl.IModel"/> and need to set cotent with those model stored data. the interface can help binding the factory to create object with model property data. see <see cref="Efl.IModel"/> see <see cref="Efl.Ui.IFactory"/></summary>
[IFactoryBindNativeInherit]
public interface IFactoryBind : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>bind the factory with the given key string. when the data is ready or changed, factory create the object and bind the data to the key action and process promised work. Note: the input <see cref="Efl.Ui.IFactory"/> need to be <see cref="Efl.Ui.IPropertyBind.PropertyBind"/> at least once.</summary>
/// <param name="key">Key string for bind model property data</param>
/// <param name="factory"><see cref="Efl.Ui.IFactory"/> for create and bind model property data</param>
/// <returns></returns>
void FactoryBind( System.String key,  Efl.Ui.IFactory factory);
    }
/// <summary>Efl UI Property interface. view object can have <see cref="Efl.IModel"/> and need to set cotent with those model stored data. the interface can help binding the factory to create object with model property data. see <see cref="Efl.IModel"/> see <see cref="Efl.Ui.IFactory"/></summary>
sealed public class IFactoryBindConcrete : 

IFactoryBind
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IFactoryBindConcrete))
                return Efl.Ui.IFactoryBindNativeInherit.GetEflClassStatic();
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
        efl_ui_factory_bind_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IFactoryBindConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IFactoryBindConcrete()
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
    /// <summary>bind the factory with the given key string. when the data is ready or changed, factory create the object and bind the data to the key action and process promised work. Note: the input <see cref="Efl.Ui.IFactory"/> need to be <see cref="Efl.Ui.IPropertyBind.PropertyBind"/> at least once.</summary>
    /// <param name="key">Key string for bind model property data</param>
    /// <param name="factory"><see cref="Efl.Ui.IFactory"/> for create and bind model property data</param>
    /// <returns></returns>
    public void FactoryBind( System.String key,  Efl.Ui.IFactory factory) {
                                                         Efl.Ui.IFactoryBindNativeInherit.efl_ui_factory_bind_ptr.Value.Delegate(this.NativeHandle, key,  factory);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IFactoryBindConcrete.efl_ui_factory_bind_interface_get();
    }
}
public class IFactoryBindNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_factory_bind_static_delegate == null)
            efl_ui_factory_bind_static_delegate = new efl_ui_factory_bind_delegate(factory_bind);
        if (methods.FirstOrDefault(m => m.Name == "FactoryBind") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_factory_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_factory_bind_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.IFactoryBindConcrete.efl_ui_factory_bind_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IFactoryBindConcrete.efl_ui_factory_bind_interface_get();
    }


     private delegate void efl_ui_factory_bind_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.IFactoryConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.IFactory factory);


     public delegate void efl_ui_factory_bind_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.IFactoryConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.IFactory factory);
     public static Efl.Eo.FunctionWrapper<efl_ui_factory_bind_api_delegate> efl_ui_factory_bind_ptr = new Efl.Eo.FunctionWrapper<efl_ui_factory_bind_api_delegate>(_Module, "efl_ui_factory_bind");
     private static void factory_bind(System.IntPtr obj, System.IntPtr pd,  System.String key,  Efl.Ui.IFactory factory)
    {
        Eina.Log.Debug("function efl_ui_factory_bind was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((IFactoryBind)wrapper).FactoryBind( key,  factory);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_factory_bind_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  factory);
        }
    }
    private static efl_ui_factory_bind_delegate efl_ui_factory_bind_static_delegate;
}
} } 
