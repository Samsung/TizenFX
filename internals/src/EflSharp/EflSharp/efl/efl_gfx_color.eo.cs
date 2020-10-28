#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>Efl Gfx Color mixin class
/// (Since EFL 1.22)</summary>
[IColorNativeInherit]
public interface IColor : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Retrieves the general/main color of the given Evas object.
/// Retrieves the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
/// 
/// Usually youll use this attribute for text and rectangle objects, where the main color is their unique one. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
/// 
/// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
/// 
/// Use null pointers on the components you&apos;re not interested in: they&apos;ll be ignored by the function.
/// (Since EFL 1.22)</summary>
/// <param name="r"></param>
/// <param name="g"></param>
/// <param name="b"></param>
/// <param name="a"></param>
/// <returns></returns>
void GetColor( out int r,  out int g,  out int b,  out int a);
    /// <summary>Sets the general/main color of the given Evas object to the given one.
/// See also <see cref="Efl.Gfx.IColor.GetColor"/> (for an example)
/// 
/// These color values are expected to be premultiplied by alpha.
/// (Since EFL 1.22)</summary>
/// <param name="r"></param>
/// <param name="g"></param>
/// <param name="b"></param>
/// <param name="a"></param>
/// <returns></returns>
void SetColor( int r,  int g,  int b,  int a);
    /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.
/// (Since EFL 1.22)</summary>
/// <returns>the hex color code.</returns>
System.String GetColorCode();
    /// <summary>Set the color of given Evas object to the given hex color code(#RRGGBBAA). e.g. efl_gfx_color_code_set(obj, &quot;#FFCCAACC&quot;);
/// (Since EFL 1.22)</summary>
/// <param name="colorcode">the hex color code.</param>
/// <returns></returns>
void SetColorCode( System.String colorcode);
                    /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.
/// (Since EFL 1.22)</summary>
/// <value>the hex color code.</value>
    System.String ColorCode {
        get ;
        set ;
    }
}
/// <summary>Efl Gfx Color mixin class
/// (Since EFL 1.22)</summary>
sealed public class IColorConcrete : 

IColor
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IColorConcrete))
                return Efl.Gfx.IColorNativeInherit.GetEflClassStatic();
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
        efl_gfx_color_mixin_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IColorConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IColorConcrete()
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
    /// <summary>Retrieves the general/main color of the given Evas object.
    /// Retrieves the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
    /// 
    /// Usually youll use this attribute for text and rectangle objects, where the main color is their unique one. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
    /// 
    /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
    /// 
    /// Use null pointers on the components you&apos;re not interested in: they&apos;ll be ignored by the function.
    /// (Since EFL 1.22)</summary>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    public void GetColor( out int r,  out int g,  out int b,  out int a) {
                                                                                                         Efl.Gfx.IColorNativeInherit.efl_gfx_color_get_ptr.Value.Delegate(this.NativeHandle, out r,  out g,  out b,  out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Sets the general/main color of the given Evas object to the given one.
    /// See also <see cref="Efl.Gfx.IColor.GetColor"/> (for an example)
    /// 
    /// These color values are expected to be premultiplied by alpha.
    /// (Since EFL 1.22)</summary>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    public void SetColor( int r,  int g,  int b,  int a) {
                                                                                                         Efl.Gfx.IColorNativeInherit.efl_gfx_color_set_ptr.Value.Delegate(this.NativeHandle, r,  g,  b,  a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.
    /// (Since EFL 1.22)</summary>
    /// <returns>the hex color code.</returns>
    public System.String GetColorCode() {
         var _ret_var = Efl.Gfx.IColorNativeInherit.efl_gfx_color_code_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the color of given Evas object to the given hex color code(#RRGGBBAA). e.g. efl_gfx_color_code_set(obj, &quot;#FFCCAACC&quot;);
    /// (Since EFL 1.22)</summary>
    /// <param name="colorcode">the hex color code.</param>
    /// <returns></returns>
    public void SetColorCode( System.String colorcode) {
                                 Efl.Gfx.IColorNativeInherit.efl_gfx_color_code_set_ptr.Value.Delegate(this.NativeHandle, colorcode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.
/// (Since EFL 1.22)</summary>
/// <value>the hex color code.</value>
    public System.String ColorCode {
        get { return GetColorCode(); }
        set { SetColorCode( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IColorConcrete.efl_gfx_color_mixin_get();
    }
}
public class IColorNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_gfx_color_get_static_delegate == null)
            efl_gfx_color_get_static_delegate = new efl_gfx_color_get_delegate(color_get);
        if (methods.FirstOrDefault(m => m.Name == "GetColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_get_static_delegate)});
        if (efl_gfx_color_set_static_delegate == null)
            efl_gfx_color_set_static_delegate = new efl_gfx_color_set_delegate(color_set);
        if (methods.FirstOrDefault(m => m.Name == "SetColor") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_set_static_delegate)});
        if (efl_gfx_color_code_get_static_delegate == null)
            efl_gfx_color_code_get_static_delegate = new efl_gfx_color_code_get_delegate(color_code_get);
        if (methods.FirstOrDefault(m => m.Name == "GetColorCode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_get_static_delegate)});
        if (efl_gfx_color_code_set_static_delegate == null)
            efl_gfx_color_code_set_static_delegate = new efl_gfx_color_code_set_delegate(color_code_set);
        if (methods.FirstOrDefault(m => m.Name == "SetColorCode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_set_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Gfx.IColorConcrete.efl_gfx_color_mixin_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IColorConcrete.efl_gfx_color_mixin_get();
    }


     private delegate void efl_gfx_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out int r,   out int g,   out int b,   out int a);


     public delegate void efl_gfx_color_get_api_delegate(System.IntPtr obj,   out int r,   out int g,   out int b,   out int a);
     public static Efl.Eo.FunctionWrapper<efl_gfx_color_get_api_delegate> efl_gfx_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_get_api_delegate>(_Module, "efl_gfx_color_get");
     private static void color_get(System.IntPtr obj, System.IntPtr pd,  out int r,  out int g,  out int b,  out int a)
    {
        Eina.Log.Debug("function efl_gfx_color_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                    r = default(int);        g = default(int);        b = default(int);        a = default(int);                                            
            try {
                ((IColorConcrete)wrapper).GetColor( out r,  out g,  out b,  out a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_gfx_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
        }
    }
    private static efl_gfx_color_get_delegate efl_gfx_color_get_static_delegate;


     private delegate void efl_gfx_color_set_delegate(System.IntPtr obj, System.IntPtr pd,   int r,   int g,   int b,   int a);


     public delegate void efl_gfx_color_set_api_delegate(System.IntPtr obj,   int r,   int g,   int b,   int a);
     public static Efl.Eo.FunctionWrapper<efl_gfx_color_set_api_delegate> efl_gfx_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_set_api_delegate>(_Module, "efl_gfx_color_set");
     private static void color_set(System.IntPtr obj, System.IntPtr pd,  int r,  int g,  int b,  int a)
    {
        Eina.Log.Debug("function efl_gfx_color_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                        
            try {
                ((IColorConcrete)wrapper).SetColor( r,  g,  b,  a);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                } else {
            efl_gfx_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
        }
    }
    private static efl_gfx_color_set_delegate efl_gfx_color_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_gfx_color_code_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_gfx_color_code_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_color_code_get_api_delegate> efl_gfx_color_code_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_code_get_api_delegate>(_Module, "efl_gfx_color_code_get");
     private static System.String color_code_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_color_code_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((IColorConcrete)wrapper).GetColorCode();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_color_code_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_color_code_get_delegate efl_gfx_color_code_get_static_delegate;


     private delegate void efl_gfx_color_code_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String colorcode);


     public delegate void efl_gfx_color_code_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String colorcode);
     public static Efl.Eo.FunctionWrapper<efl_gfx_color_code_set_api_delegate> efl_gfx_color_code_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_code_set_api_delegate>(_Module, "efl_gfx_color_code_set");
     private static void color_code_set(System.IntPtr obj, System.IntPtr pd,  System.String colorcode)
    {
        Eina.Log.Debug("function efl_gfx_color_code_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IColorConcrete)wrapper).SetColorCode( colorcode);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_color_code_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  colorcode);
        }
    }
    private static efl_gfx_color_code_set_delegate efl_gfx_color_code_set_static_delegate;
}
} } 
