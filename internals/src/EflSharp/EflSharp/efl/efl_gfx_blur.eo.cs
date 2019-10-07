#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Gfx {

/// <summary>A simple API to apply blur effects.
/// Those API&apos;s might use <see cref="Efl.Gfx.IFilter"/> internally. It might be necessary to also specify the color of the blur with <see cref="Efl.Gfx.IColor.GetColor"/>.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Gfx.BlurConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IBlur : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The blur radius in pixels.</summary>
    /// <param name="rx">The horizontal blur radius.</param>
    /// <param name="ry">The vertical blur radius.</param>
    void GetRadius(out double rx, out double ry);

    /// <summary>The blur radius in pixels.</summary>
    /// <param name="rx">The horizontal blur radius.</param>
    /// <param name="ry">The vertical blur radius.</param>
    void SetRadius(double rx, double ry);

    /// <summary>An offset relative to the original pixels.
    /// This property allows for drop shadow effects.</summary>
    /// <param name="ox">Horizontal offset in pixels.</param>
    /// <param name="oy">Vertical offset in pixels.</param>
    void GetOffset(out double ox, out double oy);

    /// <summary>An offset relative to the original pixels.
    /// This property allows for drop shadow effects.</summary>
    /// <param name="ox">Horizontal offset in pixels.</param>
    /// <param name="oy">Vertical offset in pixels.</param>
    void SetOffset(double ox, double oy);

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
    void SetGrow(double radius);

    /// <summary>The blur radius in pixels.</summary>
    /// <value>The horizontal blur radius.</value>
    (double, double) Radius {
        get;
        set;
    }

    /// <summary>An offset relative to the original pixels.
    /// This property allows for drop shadow effects.</summary>
    /// <value>Horizontal offset in pixels.</value>
    (double, double) Offset {
        get;
        set;
    }

    /// <summary>How much the original image should be &quot;grown&quot; before blurring.
    /// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
    /// 
    /// This is can be used efficiently to create glow effects.</summary>
    /// <value>How much to grow the original pixel data.</value>
    double Grow {
        get;
        set;
    }

}

/// <summary>A simple API to apply blur effects.
/// Those API&apos;s might use <see cref="Efl.Gfx.IFilter"/> internally. It might be necessary to also specify the color of the blur with <see cref="Efl.Gfx.IColor.GetColor"/>.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class BlurConcrete :
    Efl.Eo.EoWrapper
    , IBlur
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(BlurConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private BlurConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_gfx_blur_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IBlur"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private BlurConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>The blur radius in pixels.</summary>
    /// <param name="rx">The horizontal blur radius.</param>
    /// <param name="ry">The vertical blur radius.</param>
    public void GetRadius(out double rx, out double ry) {
        Efl.Gfx.BlurConcrete.NativeMethods.efl_gfx_blur_radius_get_ptr.Value.Delegate(this.NativeHandle,out rx, out ry);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The blur radius in pixels.</summary>
    /// <param name="rx">The horizontal blur radius.</param>
    /// <param name="ry">The vertical blur radius.</param>
    public void SetRadius(double rx, double ry) {
        Efl.Gfx.BlurConcrete.NativeMethods.efl_gfx_blur_radius_set_ptr.Value.Delegate(this.NativeHandle,rx, ry);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>An offset relative to the original pixels.
    /// This property allows for drop shadow effects.</summary>
    /// <param name="ox">Horizontal offset in pixels.</param>
    /// <param name="oy">Vertical offset in pixels.</param>
    public void GetOffset(out double ox, out double oy) {
        Efl.Gfx.BlurConcrete.NativeMethods.efl_gfx_blur_offset_get_ptr.Value.Delegate(this.NativeHandle,out ox, out oy);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>An offset relative to the original pixels.
    /// This property allows for drop shadow effects.</summary>
    /// <param name="ox">Horizontal offset in pixels.</param>
    /// <param name="oy">Vertical offset in pixels.</param>
    public void SetOffset(double ox, double oy) {
        Efl.Gfx.BlurConcrete.NativeMethods.efl_gfx_blur_offset_set_ptr.Value.Delegate(this.NativeHandle,ox, oy);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>How much the original image should be &quot;grown&quot; before blurring.
    /// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
    /// 
    /// This is can be used efficiently to create glow effects.</summary>
    /// <returns>How much to grow the original pixel data.</returns>
    public double GetGrow() {
        var _ret_var = Efl.Gfx.BlurConcrete.NativeMethods.efl_gfx_blur_grow_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>How much the original image should be &quot;grown&quot; before blurring.
    /// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
    /// 
    /// This is can be used efficiently to create glow effects.</summary>
    /// <param name="radius">How much to grow the original pixel data.</param>
    public void SetGrow(double radius) {
        Efl.Gfx.BlurConcrete.NativeMethods.efl_gfx_blur_grow_set_ptr.Value.Delegate(this.NativeHandle,radius);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The blur radius in pixels.</summary>
    /// <value>The horizontal blur radius.</value>
    public (double, double) Radius {
        get {
            double _out_rx = default(double);
            double _out_ry = default(double);
            GetRadius(out _out_rx,out _out_ry);
            return (_out_rx,_out_ry);
        }
        set { SetRadius( value.Item1,  value.Item2); }
    }

    /// <summary>An offset relative to the original pixels.
    /// This property allows for drop shadow effects.</summary>
    /// <value>Horizontal offset in pixels.</value>
    public (double, double) Offset {
        get {
            double _out_ox = default(double);
            double _out_oy = default(double);
            GetOffset(out _out_ox,out _out_oy);
            return (_out_ox,_out_oy);
        }
        set { SetOffset( value.Item1,  value.Item2); }
    }

    /// <summary>How much the original image should be &quot;grown&quot; before blurring.
    /// Growing is a combination of blur &amp; color levels adjustment. If the value of grow is positive, the pixels will appear more &quot;fat&quot; or &quot;bold&quot; than the original. If the value is negative, a shrink effect happens instead.
    /// 
    /// This is can be used efficiently to create glow effects.</summary>
    /// <value>How much to grow the original pixel data.</value>
    public double Grow {
        get { return GetGrow(); }
        set { SetGrow(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Gfx.BlurConcrete.efl_gfx_blur_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Efl);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gfx_blur_radius_get_static_delegate == null)
            {
                efl_gfx_blur_radius_get_static_delegate = new efl_gfx_blur_radius_get_delegate(radius_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRadius") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_blur_radius_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_radius_get_static_delegate) });
            }

            if (efl_gfx_blur_radius_set_static_delegate == null)
            {
                efl_gfx_blur_radius_set_static_delegate = new efl_gfx_blur_radius_set_delegate(radius_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRadius") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_blur_radius_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_radius_set_static_delegate) });
            }

            if (efl_gfx_blur_offset_get_static_delegate == null)
            {
                efl_gfx_blur_offset_get_static_delegate = new efl_gfx_blur_offset_get_delegate(offset_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetOffset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_blur_offset_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_offset_get_static_delegate) });
            }

            if (efl_gfx_blur_offset_set_static_delegate == null)
            {
                efl_gfx_blur_offset_set_static_delegate = new efl_gfx_blur_offset_set_delegate(offset_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetOffset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_blur_offset_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_offset_set_static_delegate) });
            }

            if (efl_gfx_blur_grow_get_static_delegate == null)
            {
                efl_gfx_blur_grow_get_static_delegate = new efl_gfx_blur_grow_get_delegate(grow_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGrow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_blur_grow_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_grow_get_static_delegate) });
            }

            if (efl_gfx_blur_grow_set_static_delegate == null)
            {
                efl_gfx_blur_grow_set_static_delegate = new efl_gfx_blur_grow_set_delegate(grow_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGrow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_blur_grow_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_blur_grow_set_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Gfx.BlurConcrete.efl_gfx_blur_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_gfx_blur_radius_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double rx,  out double ry);

        
        public delegate void efl_gfx_blur_radius_get_api_delegate(System.IntPtr obj,  out double rx,  out double ry);

        public static Efl.Eo.FunctionWrapper<efl_gfx_blur_radius_get_api_delegate> efl_gfx_blur_radius_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_radius_get_api_delegate>(Module, "efl_gfx_blur_radius_get");

        private static void radius_get(System.IntPtr obj, System.IntPtr pd, out double rx, out double ry)
        {
            Eina.Log.Debug("function efl_gfx_blur_radius_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                rx = default(double);ry = default(double);
                try
                {
                    ((IBlur)ws.Target).GetRadius(out rx, out ry);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_blur_radius_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out rx, out ry);
            }
        }

        private static efl_gfx_blur_radius_get_delegate efl_gfx_blur_radius_get_static_delegate;

        
        private delegate void efl_gfx_blur_radius_set_delegate(System.IntPtr obj, System.IntPtr pd,  double rx,  double ry);

        
        public delegate void efl_gfx_blur_radius_set_api_delegate(System.IntPtr obj,  double rx,  double ry);

        public static Efl.Eo.FunctionWrapper<efl_gfx_blur_radius_set_api_delegate> efl_gfx_blur_radius_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_radius_set_api_delegate>(Module, "efl_gfx_blur_radius_set");

        private static void radius_set(System.IntPtr obj, System.IntPtr pd, double rx, double ry)
        {
            Eina.Log.Debug("function efl_gfx_blur_radius_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IBlur)ws.Target).SetRadius(rx, ry);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_blur_radius_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), rx, ry);
            }
        }

        private static efl_gfx_blur_radius_set_delegate efl_gfx_blur_radius_set_static_delegate;

        
        private delegate void efl_gfx_blur_offset_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double ox,  out double oy);

        
        public delegate void efl_gfx_blur_offset_get_api_delegate(System.IntPtr obj,  out double ox,  out double oy);

        public static Efl.Eo.FunctionWrapper<efl_gfx_blur_offset_get_api_delegate> efl_gfx_blur_offset_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_offset_get_api_delegate>(Module, "efl_gfx_blur_offset_get");

        private static void offset_get(System.IntPtr obj, System.IntPtr pd, out double ox, out double oy)
        {
            Eina.Log.Debug("function efl_gfx_blur_offset_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                ox = default(double);oy = default(double);
                try
                {
                    ((IBlur)ws.Target).GetOffset(out ox, out oy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_blur_offset_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out ox, out oy);
            }
        }

        private static efl_gfx_blur_offset_get_delegate efl_gfx_blur_offset_get_static_delegate;

        
        private delegate void efl_gfx_blur_offset_set_delegate(System.IntPtr obj, System.IntPtr pd,  double ox,  double oy);

        
        public delegate void efl_gfx_blur_offset_set_api_delegate(System.IntPtr obj,  double ox,  double oy);

        public static Efl.Eo.FunctionWrapper<efl_gfx_blur_offset_set_api_delegate> efl_gfx_blur_offset_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_offset_set_api_delegate>(Module, "efl_gfx_blur_offset_set");

        private static void offset_set(System.IntPtr obj, System.IntPtr pd, double ox, double oy)
        {
            Eina.Log.Debug("function efl_gfx_blur_offset_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IBlur)ws.Target).SetOffset(ox, oy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_blur_offset_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ox, oy);
            }
        }

        private static efl_gfx_blur_offset_set_delegate efl_gfx_blur_offset_set_static_delegate;

        
        private delegate double efl_gfx_blur_grow_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_gfx_blur_grow_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_blur_grow_get_api_delegate> efl_gfx_blur_grow_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_grow_get_api_delegate>(Module, "efl_gfx_blur_grow_get");

        private static double grow_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_blur_grow_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IBlur)ws.Target).GetGrow();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_gfx_blur_grow_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_blur_grow_get_delegate efl_gfx_blur_grow_get_static_delegate;

        
        private delegate void efl_gfx_blur_grow_set_delegate(System.IntPtr obj, System.IntPtr pd,  double radius);

        
        public delegate void efl_gfx_blur_grow_set_api_delegate(System.IntPtr obj,  double radius);

        public static Efl.Eo.FunctionWrapper<efl_gfx_blur_grow_set_api_delegate> efl_gfx_blur_grow_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_blur_grow_set_api_delegate>(Module, "efl_gfx_blur_grow_set");

        private static void grow_set(System.IntPtr obj, System.IntPtr pd, double radius)
        {
            Eina.Log.Debug("function efl_gfx_blur_grow_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IBlur)ws.Target).SetGrow(radius);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_blur_grow_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), radius);
            }
        }

        private static efl_gfx_blur_grow_set_delegate efl_gfx_blur_grow_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_GfxBlurConcrete_ExtensionMethods {
    public static Efl.BindableProperty<double> Grow<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Gfx.IBlur, T>magic = null) where T : Efl.Gfx.IBlur {
        return new Efl.BindableProperty<double>("grow", fac);
    }

}
#pragma warning restore CS1591
#endif
