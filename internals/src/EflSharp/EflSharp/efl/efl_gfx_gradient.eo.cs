#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl graphics gradient interface</summary>
[IGradientNativeInherit]
public interface IGradient : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Get the list of color stops.</summary>
/// <param name="colors">Color stops list</param>
/// <param name="length">Length of the list</param>
/// <returns></returns>
void GetStop( out Efl.Gfx.GradientStop colors,  out uint length);
    /// <summary>Set the list of color stops for the gradient</summary>
/// <param name="colors">Color stops list</param>
/// <param name="length">Length of the list</param>
/// <returns></returns>
void SetStop( ref Efl.Gfx.GradientStop colors,  uint length);
    /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
/// <returns>Spread type to be used</returns>
Efl.Gfx.GradientSpread GetSpread();
    /// <summary>Specifies the spread method that should be used for this gradient.</summary>
/// <param name="s">Spread type to be used</param>
/// <returns></returns>
void SetSpread( Efl.Gfx.GradientSpread s);
                    /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
/// <value>Spread type to be used</value>
    Efl.Gfx.GradientSpread Spread {
        get ;
        set ;
    }
}
/// <summary>Efl graphics gradient interface</summary>
sealed public class IGradientConcrete : 

IGradient
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IGradientConcrete))
                return Efl.Gfx.IGradientNativeInherit.GetEflClassStatic();
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
        efl_gfx_gradient_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IGradientConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IGradientConcrete()
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
    /// <summary>Get the list of color stops.</summary>
    /// <param name="colors">Color stops list</param>
    /// <param name="length">Length of the list</param>
    /// <returns></returns>
    public void GetStop( out Efl.Gfx.GradientStop colors,  out uint length) {
                         var _out_colors = new System.IntPtr();
                                Efl.Gfx.IGradientNativeInherit.efl_gfx_gradient_stop_get_ptr.Value.Delegate(this.NativeHandle, out _out_colors,  out length);
        Eina.Error.RaiseIfUnhandledException();
        colors = Eina.PrimitiveConversion.PointerToManaged<Efl.Gfx.GradientStop>(_out_colors);
                                 }
    /// <summary>Set the list of color stops for the gradient</summary>
    /// <param name="colors">Color stops list</param>
    /// <param name="length">Length of the list</param>
    /// <returns></returns>
    public void SetStop( ref Efl.Gfx.GradientStop colors,  uint length) {
         Efl.Gfx.GradientStop.NativeStruct _in_colors = colors;
                                                Efl.Gfx.IGradientNativeInherit.efl_gfx_gradient_stop_set_ptr.Value.Delegate(this.NativeHandle, ref _in_colors,  length);
        Eina.Error.RaiseIfUnhandledException();
                        colors = _in_colors;
                 }
    /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
    /// <returns>Spread type to be used</returns>
    public Efl.Gfx.GradientSpread GetSpread() {
         var _ret_var = Efl.Gfx.IGradientNativeInherit.efl_gfx_gradient_spread_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies the spread method that should be used for this gradient.</summary>
    /// <param name="s">Spread type to be used</param>
    /// <returns></returns>
    public void SetSpread( Efl.Gfx.GradientSpread s) {
                                 Efl.Gfx.IGradientNativeInherit.efl_gfx_gradient_spread_set_ptr.Value.Delegate(this.NativeHandle, s);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Returns the spread method use by this gradient. The default is EFL_GFX_GRADIENT_SPREAD_PAD.</summary>
/// <value>Spread type to be used</value>
    public Efl.Gfx.GradientSpread Spread {
        get { return GetSpread(); }
        set { SetSpread( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IGradientConcrete.efl_gfx_gradient_interface_get();
    }
}
public class IGradientNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_gfx_gradient_stop_get_static_delegate == null)
            efl_gfx_gradient_stop_get_static_delegate = new efl_gfx_gradient_stop_get_delegate(stop_get);
        if (methods.FirstOrDefault(m => m.Name == "GetStop") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_stop_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_stop_get_static_delegate)});
        if (efl_gfx_gradient_stop_set_static_delegate == null)
            efl_gfx_gradient_stop_set_static_delegate = new efl_gfx_gradient_stop_set_delegate(stop_set);
        if (methods.FirstOrDefault(m => m.Name == "SetStop") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_stop_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_stop_set_static_delegate)});
        if (efl_gfx_gradient_spread_get_static_delegate == null)
            efl_gfx_gradient_spread_get_static_delegate = new efl_gfx_gradient_spread_get_delegate(spread_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSpread") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_spread_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_spread_get_static_delegate)});
        if (efl_gfx_gradient_spread_set_static_delegate == null)
            efl_gfx_gradient_spread_set_static_delegate = new efl_gfx_gradient_spread_set_delegate(spread_set);
        if (methods.FirstOrDefault(m => m.Name == "SetSpread") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_gradient_spread_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_gradient_spread_set_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Gfx.IGradientConcrete.efl_gfx_gradient_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IGradientConcrete.efl_gfx_gradient_interface_get();
    }


     private delegate void efl_gfx_gradient_stop_get_delegate(System.IntPtr obj, System.IntPtr pd,   out System.IntPtr colors,   out uint length);


     public delegate void efl_gfx_gradient_stop_get_api_delegate(System.IntPtr obj,   out System.IntPtr colors,   out uint length);
     public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_stop_get_api_delegate> efl_gfx_gradient_stop_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_stop_get_api_delegate>(_Module, "efl_gfx_gradient_stop_get");
     private static void stop_get(System.IntPtr obj, System.IntPtr pd,  out System.IntPtr colors,  out uint length)
    {
        Eina.Log.Debug("function efl_gfx_gradient_stop_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    Efl.Gfx.GradientStop _out_colors = default(Efl.Gfx.GradientStop);
        length = default(uint);                            
            try {
                ((IGradient)wrapper).GetStop( out _out_colors,  out length);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        colors = Eina.PrimitiveConversion.ManagedToPointerAlloc(_out_colors);
                                        } else {
            efl_gfx_gradient_stop_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out colors,  out length);
        }
    }
    private static efl_gfx_gradient_stop_get_delegate efl_gfx_gradient_stop_get_static_delegate;


     private delegate void efl_gfx_gradient_stop_set_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Gfx.GradientStop.NativeStruct colors,   uint length);


     public delegate void efl_gfx_gradient_stop_set_api_delegate(System.IntPtr obj,   ref Efl.Gfx.GradientStop.NativeStruct colors,   uint length);
     public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_stop_set_api_delegate> efl_gfx_gradient_stop_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_stop_set_api_delegate>(_Module, "efl_gfx_gradient_stop_set");
     private static void stop_set(System.IntPtr obj, System.IntPtr pd,  ref Efl.Gfx.GradientStop.NativeStruct colors,  uint length)
    {
        Eina.Log.Debug("function efl_gfx_gradient_stop_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Efl.Gfx.GradientStop _in_colors = colors;
                                                    
            try {
                ((IGradient)wrapper).SetStop( ref _in_colors,  length);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        colors = _in_colors;
                        } else {
            efl_gfx_gradient_stop_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref colors,  length);
        }
    }
    private static efl_gfx_gradient_stop_set_delegate efl_gfx_gradient_stop_set_static_delegate;


     private delegate Efl.Gfx.GradientSpread efl_gfx_gradient_spread_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Gfx.GradientSpread efl_gfx_gradient_spread_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_spread_get_api_delegate> efl_gfx_gradient_spread_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_spread_get_api_delegate>(_Module, "efl_gfx_gradient_spread_get");
     private static Efl.Gfx.GradientSpread spread_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_gradient_spread_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Gfx.GradientSpread _ret_var = default(Efl.Gfx.GradientSpread);
            try {
                _ret_var = ((IGradient)wrapper).GetSpread();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_gradient_spread_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_gradient_spread_get_delegate efl_gfx_gradient_spread_get_static_delegate;


     private delegate void efl_gfx_gradient_spread_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.GradientSpread s);


     public delegate void efl_gfx_gradient_spread_set_api_delegate(System.IntPtr obj,   Efl.Gfx.GradientSpread s);
     public static Efl.Eo.FunctionWrapper<efl_gfx_gradient_spread_set_api_delegate> efl_gfx_gradient_spread_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_gradient_spread_set_api_delegate>(_Module, "efl_gfx_gradient_spread_set");
     private static void spread_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.GradientSpread s)
    {
        Eina.Log.Debug("function efl_gfx_gradient_spread_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IGradient)wrapper).SetSpread( s);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_gradient_spread_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  s);
        }
    }
    private static efl_gfx_gradient_spread_set_delegate efl_gfx_gradient_spread_set_static_delegate;
}
} } 
