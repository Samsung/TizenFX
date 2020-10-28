#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
[IDirectionReadonlyNativeInherit]
public interface IDirectionReadonly : 
    Efl.Ui.IDirection ,
    Efl.Eo.IWrapper, IDisposable
{
}
/// <summary></summary>
sealed public class IDirectionReadonlyConcrete : 

IDirectionReadonly
    , Efl.Ui.IDirection
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IDirectionReadonlyConcrete))
                return Efl.Ui.IDirectionReadonlyNativeInherit.GetEflClassStatic();
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
        efl_ui_direction_readonly_mixin_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IDirectionReadonlyConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IDirectionReadonlyConcrete()
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
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <returns>Direction of the widget.</returns>
    public Efl.Ui.Dir GetDirection() {
         var _ret_var = Efl.Ui.IDirectionNativeInherit.efl_ui_direction_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <param name="dir">Direction of the widget.</param>
    /// <returns></returns>
    public void SetDirection( Efl.Ui.Dir dir) {
                                 Efl.Ui.IDirectionNativeInherit.efl_ui_direction_set_ptr.Value.Delegate(this.NativeHandle, dir);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the direction of a given widget.
/// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
/// 
/// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
/// <value>Direction of the widget.</value>
    public Efl.Ui.Dir Direction {
        get { return GetDirection(); }
        set { SetDirection( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IDirectionReadonlyConcrete.efl_ui_direction_readonly_mixin_get();
    }
}
public class IDirectionReadonlyNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_direction_get_static_delegate == null)
            efl_ui_direction_get_static_delegate = new efl_ui_direction_get_delegate(direction_get);
        if (methods.FirstOrDefault(m => m.Name == "GetDirection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_get_static_delegate)});
        if (efl_ui_direction_set_static_delegate == null)
            efl_ui_direction_set_static_delegate = new efl_ui_direction_set_delegate(direction_set);
        if (methods.FirstOrDefault(m => m.Name == "SetDirection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_set_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.IDirectionReadonlyConcrete.efl_ui_direction_readonly_mixin_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IDirectionReadonlyConcrete.efl_ui_direction_readonly_mixin_get();
    }


     private delegate Efl.Ui.Dir efl_ui_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Ui.Dir efl_ui_direction_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate> efl_ui_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate>(_Module, "efl_ui_direction_get");
     private static Efl.Ui.Dir direction_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_direction_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Ui.Dir _ret_var = default(Efl.Ui.Dir);
            try {
                _ret_var = ((IDirectionReadonlyConcrete)wrapper).GetDirection();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_direction_get_delegate efl_ui_direction_get_static_delegate;


     private delegate void efl_ui_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir dir);


     public delegate void efl_ui_direction_set_api_delegate(System.IntPtr obj,   Efl.Ui.Dir dir);
     public static Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate> efl_ui_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate>(_Module, "efl_ui_direction_set");
     private static void direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir)
    {
        Eina.Log.Debug("function efl_ui_direction_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IDirectionReadonlyConcrete)wrapper).SetDirection( dir);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
        }
    }
    private static efl_ui_direction_set_delegate efl_ui_direction_set_static_delegate;
}
} } 
