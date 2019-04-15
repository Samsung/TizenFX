#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Gfx { 
/// <summary>A simple API to apply blur effects.
/// Those API&apos;s might use <see cref="Efl.Gfx.IFilter"/> internally. It might be necessary to also specify the color of the blur with <see cref="Efl.Gfx.IColor.GetColor"/>.</summary>
[IBlurNativeInherit]
public interface IBlur : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The blur radius in pixels.</summary>
/// <param name="rx">The horizontal blur radius.</param>
/// <param name="ry">The vertical blur radius.</param>
/// <returns></returns>
void GetRadius( out double rx,  out double ry);
    /// <summary>The blur radius in pixels.</summary>
/// <param name="rx">The horizontal blur radius.</param>
/// <param name="ry">The vertical blur radius.</param>
/// <returns></returns>
void SetRadius( double rx,  double ry);
    /// <summary>An offset relative to the original pixels.
/// This property allows for drop shadow effects.</summary>
/// <param name="ox">Horizontal offset in pixels.</param>
/// <param name="oy">Vertical offset in pixels.</param>
/// <returns></returns>
void GetOffset( out double ox,  out double oy);
    /// <summary>An offset relative to the original pixels.
/// This property allows for drop shadow effects.</summary>
/// <param name="ox">Horizontal offset in pixels.</param>
/// <param name="oy">Vertical offset in pixels.</param>
/// <returns></returns>
void SetOffset( double ox,  double oy);
    /// <summary>How much the original image should be &quot;grown&quot; before blurring.
/// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
/// 
/// This is can be used efficiently to create glow effects.</summary>
/// <returns>How much to grow the original pixel data.</returns>
double GetGrow();
    /// <summary>How much the original image should be &quot;grown&quot; before blurring.
/// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
/// 
/// This is can be used efficiently to create glow effects.</summary>
/// <param name="radius">How much to grow the original pixel data.</param>
/// <returns></returns>
void SetGrow( double radius);
                            /// <summary>How much the original image should be &quot;grown&quot; before blurring.
/// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
/// 
/// This is can be used efficiently to create glow effects.</summary>
/// <value>How much to grow the original pixel data.</value>
    double Grow {
        get ;
        set ;
    }
}
/// <summary>A simple API to apply blur effects.
/// Those API&apos;s might use <see cref="Efl.Gfx.IFilter"/> internally. It might be necessary to also specify the color of the blur with <see cref="Efl.Gfx.IColor.GetColor"/>.</summary>
sealed public class IBlurConcrete : 

IBlur
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IBlurConcrete))
                return Efl.Gfx.IBlurNativeInherit.GetEflClassStatic();
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
        efl_gfx_blur_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IBlurConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IBlurConcrete()
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
    /// <summary>The blur radius in pixels.</summary>
    /// <param name="rx">The horizontal blur radius.</param>
    /// <param name="ry">The vertical blur radius.</param>
    /// <returns></returns>
    public void GetRadius( out double rx,  out double ry) {
                                                         Efl.Gfx.IBlurNativeInherit.efl_gfx_blur_radius_get_ptr.Value.Delegate(this.NativeHandle, out rx,  out ry);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The blur radius in pixels.</summary>
    /// <param name="rx">The horizontal blur radius.</param>
    /// <param name="ry">The vertical blur radius.</param>
    /// <returns></returns>
    public void SetRadius( double rx,  double ry) {
                                                         Efl.Gfx.IBlurNativeInherit.efl_gfx_blur_radius_set_ptr.Value.Delegate(this.NativeHandle, rx,  ry);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>An offset relative to the original pixels.
    /// This property allows for drop shadow effects.</summary>
    /// <param name="ox">Horizontal offset in pixels.</param>
    /// <param name="oy">Vertical offset in pixels.</param>
    /// <returns></returns>
    public void GetOffset( out double ox,  out double oy) {
                                                         Efl.Gfx.IBlurNativeInherit.efl_gfx_blur_offset_get_ptr.Value.Delegate(this.NativeHandle, out ox,  out oy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>An offset relative to the original pixels.
    /// This property allows for drop shadow effects.</summary>
    /// <param name="ox">Horizontal offset in pixels.</param>
    /// <param name="oy">Vertical offset in pixels.</param>
    /// <returns></returns>
    public void SetOffset( double ox,  double oy) {
                                                         Efl.Gfx.IBlurNativeInherit.efl_gfx_blur_offset_set_ptr.Value.Delegate(this.NativeHandle, ox,  oy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>How much the original image should be &quot;grown&quot; before blurring.
    /// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
    /// 
    /// This is can be used efficiently to create glow effects.</summary>
    /// <returns>How much to grow the original pixel data.</returns>
    public double GetGrow() {
         var _ret_var = Efl.Gfx.IBlurNativeInherit.efl_gfx_blur_grow_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>How much the original image should be &quot;grown&quot; before blurring.
    /// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
    /// 
    /// This is can be used efficiently to create glow effects.</summary>
    /// <param name="radius">How much to grow the original pixel data.</param>
    /// <returns></returns>
    public void SetGrow( double radius) {
                                 Efl.Gfx.IBlurNativeInherit.efl_gfx_blur_grow_set_ptr.Value.Delegate(this.NativeHandle, radius);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>How much the original image should be &quot;grown&quot; before blurring.
/// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
/// 
/// This is can be used efficiently to create glow effects.</summary>
/// <value>How much to grow the original pixel data.</value>
    public double Grow {
        get { return GetGrow(); }
        set { SetGrow( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IBlurConcrete.efl_gfx_blur_interface_get();
    }
}
public class IBlurNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_gfx_blur_radius_get_static_delegate == null)
            efl_gfx_blur_radius_get_static_delegate = new efl_gfx_blur_radius_get_delegate(radius_get);
        if (methods.FirstOrDefault(m => m.Name == "GetRadius") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_blur_radius_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_radius_get_static_delegate)});
        if (efl_gfx_blur_radius_set_static_delegate == null)
            efl_gfx_blur_radius_set_static_delegate = new efl_gfx_blur_radius_set_delegate(radius_set);
        if (methods.FirstOrDefault(m => m.Name == "SetRadius") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_blur_radius_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_radius_set_static_delegate)});
        if (efl_gfx_blur_offset_get_static_delegate == null)
            efl_gfx_blur_offset_get_static_delegate = new efl_gfx_blur_offset_get_delegate(offset_get);
        if (methods.FirstOrDefault(m => m.Name == "GetOffset") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_blur_offset_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_offset_get_static_delegate)});
        if (efl_gfx_blur_offset_set_static_delegate == null)
            efl_gfx_blur_offset_set_static_delegate = new efl_gfx_blur_offset_set_delegate(offset_set);
        if (methods.FirstOrDefault(m => m.Name == "SetOffset") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_blur_offset_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_offset_set_static_delegate)});
        if (efl_gfx_blur_grow_get_static_delegate == null)
            efl_gfx_blur_grow_get_static_delegate = new efl_gfx_blur_grow_get_delegate(grow_get);
        if (methods.FirstOrDefault(m => m.Name == "GetGrow") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_blur_grow_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_grow_get_static_delegate)});
        if (efl_gfx_blur_grow_set_static_delegate == null)
            efl_gfx_blur_grow_set_static_delegate = new efl_gfx_blur_grow_set_delegate(grow_set);
        if (methods.FirstOrDefault(m => m.Name == "SetGrow") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_blur_grow_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_grow_set_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Gfx.IBlurConcrete.efl_gfx_blur_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.IBlurConcrete.efl_gfx_blur_interface_get();
    }


     private delegate void efl_gfx_blur_radius_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double rx,   out double ry);


     public delegate void efl_gfx_blur_radius_get_api_delegate(System.IntPtr obj,   out double rx,   out double ry);
     public static Efl.Eo.FunctionWrapper<efl_gfx_blur_radius_get_api_delegate> efl_gfx_blur_radius_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_radius_get_api_delegate>(_Module, "efl_gfx_blur_radius_get");
     private static void radius_get(System.IntPtr obj, System.IntPtr pd,  out double rx,  out double ry)
    {
        Eina.Log.Debug("function efl_gfx_blur_radius_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    rx = default(double);        ry = default(double);                            
            try {
                ((IBlur)wrapper).GetRadius( out rx,  out ry);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_gfx_blur_radius_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out rx,  out ry);
        }
    }
    private static efl_gfx_blur_radius_get_delegate efl_gfx_blur_radius_get_static_delegate;


     private delegate void efl_gfx_blur_radius_set_delegate(System.IntPtr obj, System.IntPtr pd,   double rx,   double ry);


     public delegate void efl_gfx_blur_radius_set_api_delegate(System.IntPtr obj,   double rx,   double ry);
     public static Efl.Eo.FunctionWrapper<efl_gfx_blur_radius_set_api_delegate> efl_gfx_blur_radius_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_radius_set_api_delegate>(_Module, "efl_gfx_blur_radius_set");
     private static void radius_set(System.IntPtr obj, System.IntPtr pd,  double rx,  double ry)
    {
        Eina.Log.Debug("function efl_gfx_blur_radius_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((IBlur)wrapper).SetRadius( rx,  ry);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_gfx_blur_radius_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rx,  ry);
        }
    }
    private static efl_gfx_blur_radius_set_delegate efl_gfx_blur_radius_set_static_delegate;


     private delegate void efl_gfx_blur_offset_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double ox,   out double oy);


     public delegate void efl_gfx_blur_offset_get_api_delegate(System.IntPtr obj,   out double ox,   out double oy);
     public static Efl.Eo.FunctionWrapper<efl_gfx_blur_offset_get_api_delegate> efl_gfx_blur_offset_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_offset_get_api_delegate>(_Module, "efl_gfx_blur_offset_get");
     private static void offset_get(System.IntPtr obj, System.IntPtr pd,  out double ox,  out double oy)
    {
        Eina.Log.Debug("function efl_gfx_blur_offset_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    ox = default(double);        oy = default(double);                            
            try {
                ((IBlur)wrapper).GetOffset( out ox,  out oy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_gfx_blur_offset_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out ox,  out oy);
        }
    }
    private static efl_gfx_blur_offset_get_delegate efl_gfx_blur_offset_get_static_delegate;


     private delegate void efl_gfx_blur_offset_set_delegate(System.IntPtr obj, System.IntPtr pd,   double ox,   double oy);


     public delegate void efl_gfx_blur_offset_set_api_delegate(System.IntPtr obj,   double ox,   double oy);
     public static Efl.Eo.FunctionWrapper<efl_gfx_blur_offset_set_api_delegate> efl_gfx_blur_offset_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_offset_set_api_delegate>(_Module, "efl_gfx_blur_offset_set");
     private static void offset_set(System.IntPtr obj, System.IntPtr pd,  double ox,  double oy)
    {
        Eina.Log.Debug("function efl_gfx_blur_offset_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((IBlur)wrapper).SetOffset( ox,  oy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_gfx_blur_offset_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ox,  oy);
        }
    }
    private static efl_gfx_blur_offset_set_delegate efl_gfx_blur_offset_set_static_delegate;


     private delegate double efl_gfx_blur_grow_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_gfx_blur_grow_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_blur_grow_get_api_delegate> efl_gfx_blur_grow_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_grow_get_api_delegate>(_Module, "efl_gfx_blur_grow_get");
     private static double grow_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_blur_grow_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((IBlur)wrapper).GetGrow();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_blur_grow_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_blur_grow_get_delegate efl_gfx_blur_grow_get_static_delegate;


     private delegate void efl_gfx_blur_grow_set_delegate(System.IntPtr obj, System.IntPtr pd,   double radius);


     public delegate void efl_gfx_blur_grow_set_api_delegate(System.IntPtr obj,   double radius);
     public static Efl.Eo.FunctionWrapper<efl_gfx_blur_grow_set_api_delegate> efl_gfx_blur_grow_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_grow_set_api_delegate>(_Module, "efl_gfx_blur_grow_set");
     private static void grow_set(System.IntPtr obj, System.IntPtr pd,  double radius)
    {
        Eina.Log.Debug("function efl_gfx_blur_grow_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IBlur)wrapper).SetGrow( radius);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_blur_grow_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  radius);
        }
    }
    private static efl_gfx_blur_grow_set_delegate efl_gfx_blur_grow_set_static_delegate;
}
} } 
