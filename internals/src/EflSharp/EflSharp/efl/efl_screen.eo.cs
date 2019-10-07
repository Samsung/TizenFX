#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl screen interface</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.ScreenConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IScreen : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Screen size (in pixels) for the screen.
    /// Note that on some display systems this information is not available and a value of 0x0 will be returned.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The screen size in pixels.</returns>
    Eina.Size2D GetScreenSizeInPixels();

    /// <summary>Screen scaling factor.
    /// This is the factor by which window contents will be scaled on the screen.
    /// 
    /// Note that on some display systems this information is not available and a value of 1.0 will be returned.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The screen scaling factor.</returns>
    float GetScreenScaleFactor();

    /// <summary>The rotation of the screen.
    /// Most engines only return multiples of 90.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Screen rotation in degrees.</returns>
    int GetScreenRotation();

    /// <summary>The pixel density in DPI (Dots Per Inch) for the screen that a window is on.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="xdpi">Horizontal DPI.</param>
    /// <param name="ydpi">Vertical DPI.</param>
    void GetScreenDpi(out int xdpi, out int ydpi);

    /// <summary>Screen size (in pixels) for the screen.
    /// Note that on some display systems this information is not available and a value of 0x0 will be returned.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The screen size in pixels.</value>
    Eina.Size2D ScreenSizeInPixels {
        get;
    }

    /// <summary>Screen scaling factor.
    /// This is the factor by which window contents will be scaled on the screen.
    /// 
    /// Note that on some display systems this information is not available and a value of 1.0 will be returned.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The screen scaling factor.</value>
    float ScreenScaleFactor {
        get;
    }

    /// <summary>The rotation of the screen.
    /// Most engines only return multiples of 90.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Screen rotation in degrees.</value>
    int ScreenRotation {
        get;
    }

    /// <summary>The pixel density in DPI (Dots Per Inch) for the screen that a window is on.</summary>
    /// <since_tizen> 6 </since_tizen>
    (int, int) ScreenDpi {
        get;
    }

}

/// <summary>Efl screen interface</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class ScreenConcrete :
    Efl.Eo.EoWrapper
    , IScreen
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ScreenConcrete))
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
    private ScreenConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_screen_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IScreen"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ScreenConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Screen size (in pixels) for the screen.
    /// Note that on some display systems this information is not available and a value of 0x0 will be returned.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The screen size in pixels.</returns>
    public Eina.Size2D GetScreenSizeInPixels() {
        var _ret_var = Efl.ScreenConcrete.NativeMethods.efl_screen_size_in_pixels_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Screen scaling factor.
    /// This is the factor by which window contents will be scaled on the screen.
    /// 
    /// Note that on some display systems this information is not available and a value of 1.0 will be returned.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The screen scaling factor.</returns>
    public float GetScreenScaleFactor() {
        var _ret_var = Efl.ScreenConcrete.NativeMethods.efl_screen_scale_factor_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The rotation of the screen.
    /// Most engines only return multiples of 90.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Screen rotation in degrees.</returns>
    public int GetScreenRotation() {
        var _ret_var = Efl.ScreenConcrete.NativeMethods.efl_screen_rotation_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The pixel density in DPI (Dots Per Inch) for the screen that a window is on.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="xdpi">Horizontal DPI.</param>
    /// <param name="ydpi">Vertical DPI.</param>
    public void GetScreenDpi(out int xdpi, out int ydpi) {
        Efl.ScreenConcrete.NativeMethods.efl_screen_dpi_get_ptr.Value.Delegate(this.NativeHandle,out xdpi, out ydpi);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Screen size (in pixels) for the screen.
    /// Note that on some display systems this information is not available and a value of 0x0 will be returned.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The screen size in pixels.</value>
    public Eina.Size2D ScreenSizeInPixels {
        get { return GetScreenSizeInPixels(); }
    }

    /// <summary>Screen scaling factor.
    /// This is the factor by which window contents will be scaled on the screen.
    /// 
    /// Note that on some display systems this information is not available and a value of 1.0 will be returned.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The screen scaling factor.</value>
    public float ScreenScaleFactor {
        get { return GetScreenScaleFactor(); }
    }

    /// <summary>The rotation of the screen.
    /// Most engines only return multiples of 90.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Screen rotation in degrees.</value>
    public int ScreenRotation {
        get { return GetScreenRotation(); }
    }

    /// <summary>The pixel density in DPI (Dots Per Inch) for the screen that a window is on.</summary>
    /// <since_tizen> 6 </since_tizen>
    public (int, int) ScreenDpi {
        get {
            int _out_xdpi = default(int);
            int _out_ydpi = default(int);
            GetScreenDpi(out _out_xdpi,out _out_ydpi);
            return (_out_xdpi,_out_ydpi);
        }
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.ScreenConcrete.efl_screen_interface_get();
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

            if (efl_screen_size_in_pixels_get_static_delegate == null)
            {
                efl_screen_size_in_pixels_get_static_delegate = new efl_screen_size_in_pixels_get_delegate(screen_size_in_pixels_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScreenSizeInPixels") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_screen_size_in_pixels_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_size_in_pixels_get_static_delegate) });
            }

            if (efl_screen_scale_factor_get_static_delegate == null)
            {
                efl_screen_scale_factor_get_static_delegate = new efl_screen_scale_factor_get_delegate(screen_scale_factor_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScreenScaleFactor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_screen_scale_factor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_scale_factor_get_static_delegate) });
            }

            if (efl_screen_rotation_get_static_delegate == null)
            {
                efl_screen_rotation_get_static_delegate = new efl_screen_rotation_get_delegate(screen_rotation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScreenRotation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_screen_rotation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_rotation_get_static_delegate) });
            }

            if (efl_screen_dpi_get_static_delegate == null)
            {
                efl_screen_dpi_get_static_delegate = new efl_screen_dpi_get_delegate(screen_dpi_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScreenDpi") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_screen_dpi_get"), func = Marshal.GetFunctionPointerForDelegate(efl_screen_dpi_get_static_delegate) });
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
            return Efl.ScreenConcrete.efl_screen_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Eina.Size2D.NativeStruct efl_screen_size_in_pixels_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_screen_size_in_pixels_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_screen_size_in_pixels_get_api_delegate> efl_screen_size_in_pixels_get_ptr = new Efl.Eo.FunctionWrapper<efl_screen_size_in_pixels_get_api_delegate>(Module, "efl_screen_size_in_pixels_get");

        private static Eina.Size2D.NativeStruct screen_size_in_pixels_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_screen_size_in_pixels_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IScreen)ws.Target).GetScreenSizeInPixels();
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
                return efl_screen_size_in_pixels_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_screen_size_in_pixels_get_delegate efl_screen_size_in_pixels_get_static_delegate;

        
        private delegate float efl_screen_scale_factor_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate float efl_screen_scale_factor_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_screen_scale_factor_get_api_delegate> efl_screen_scale_factor_get_ptr = new Efl.Eo.FunctionWrapper<efl_screen_scale_factor_get_api_delegate>(Module, "efl_screen_scale_factor_get");

        private static float screen_scale_factor_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_screen_scale_factor_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                float _ret_var = default(float);
                try
                {
                    _ret_var = ((IScreen)ws.Target).GetScreenScaleFactor();
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
                return efl_screen_scale_factor_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_screen_scale_factor_get_delegate efl_screen_scale_factor_get_static_delegate;

        
        private delegate int efl_screen_rotation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_screen_rotation_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_screen_rotation_get_api_delegate> efl_screen_rotation_get_ptr = new Efl.Eo.FunctionWrapper<efl_screen_rotation_get_api_delegate>(Module, "efl_screen_rotation_get");

        private static int screen_rotation_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_screen_rotation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IScreen)ws.Target).GetScreenRotation();
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
                return efl_screen_rotation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_screen_rotation_get_delegate efl_screen_rotation_get_static_delegate;

        
        private delegate void efl_screen_dpi_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int xdpi,  out int ydpi);

        
        public delegate void efl_screen_dpi_get_api_delegate(System.IntPtr obj,  out int xdpi,  out int ydpi);

        public static Efl.Eo.FunctionWrapper<efl_screen_dpi_get_api_delegate> efl_screen_dpi_get_ptr = new Efl.Eo.FunctionWrapper<efl_screen_dpi_get_api_delegate>(Module, "efl_screen_dpi_get");

        private static void screen_dpi_get(System.IntPtr obj, System.IntPtr pd, out int xdpi, out int ydpi)
        {
            Eina.Log.Debug("function efl_screen_dpi_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                xdpi = default(int);ydpi = default(int);
                try
                {
                    ((IScreen)ws.Target).GetScreenDpi(out xdpi, out ydpi);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_screen_dpi_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out xdpi, out ydpi);
            }
        }

        private static efl_screen_dpi_get_delegate efl_screen_dpi_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflScreenConcrete_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
