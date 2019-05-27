#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl screen interface
/// (Since EFL 1.22)</summary>
[Efl.IScreenConcrete.NativeMethods]
public interface IScreen : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Get screen size (in pixels) for the screen.
/// Note that on some display systems this information is not available and a value of 0x0 will be returned.
/// (Since EFL 1.22)</summary>
/// <returns>The screen size in pixels.</returns>
Eina.Size2D GetScreenSizeInPixels();
    /// <summary>Get screen scaling factor.
/// This is the factor by which window contents will be scaled on the screen.
/// 
/// Note that on some display systems this information is not available and a value of 1.0 will be returned.
/// (Since EFL 1.22)</summary>
/// <returns>The screen scaling factor.</returns>
float GetScreenScaleFactor();
    /// <summary>Get the rotation of the screen.
/// Most engines only return multiples of 90.
/// (Since EFL 1.22)</summary>
/// <returns>Screen rotation in degrees.</returns>
int GetScreenRotation();
    /// <summary>Get the pixel density in DPI (Dots Per Inch) for the screen that a window is on.
/// (Since EFL 1.22)</summary>
/// <param name="xdpi">Horizontal DPI.</param>
/// <param name="ydpi">Vertical DPI.</param>
void GetScreenDpi(out int xdpi, out int ydpi);
                    /// <summary>Get screen size (in pixels) for the screen.
/// Note that on some display systems this information is not available and a value of 0x0 will be returned.
/// (Since EFL 1.22)</summary>
/// <value>The screen size in pixels.</value>
    Eina.Size2D ScreenSizeInPixels {
        get ;
    }
    /// <summary>Get screen scaling factor.
/// This is the factor by which window contents will be scaled on the screen.
/// 
/// Note that on some display systems this information is not available and a value of 1.0 will be returned.
/// (Since EFL 1.22)</summary>
/// <value>The screen scaling factor.</value>
    float ScreenScaleFactor {
        get ;
    }
    /// <summary>Get the rotation of the screen.
/// Most engines only return multiples of 90.
/// (Since EFL 1.22)</summary>
/// <value>Screen rotation in degrees.</value>
    int ScreenRotation {
        get ;
    }
}
/// <summary>Efl screen interface
/// (Since EFL 1.22)</summary>
sealed public class IScreenConcrete : 

IScreen
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IScreenConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle
    {
        get { return handle; }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_screen_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IScreen"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IScreenConcrete(System.IntPtr raw)
    {
        handle = raw;
    }
    ///<summary>Destructor.</summary>
    ~IScreenConcrete()
    {
        Dispose(false);
    }

    ///<summary>Releases the underlying native instance.</summary>
    private void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero)
        {
            IntPtr h = handle;
            handle = IntPtr.Zero;

            IntPtr gcHandlePtr = IntPtr.Zero;
            if (disposing)
            {
                Efl.Eo.Globals.efl_mono_native_dispose(h, gcHandlePtr);
            }
            else
            {
                Monitor.Enter(Efl.All.InitLock);
                if (Efl.All.MainLoopInitialized)
                {
                    Efl.Eo.Globals.efl_mono_thread_safe_native_dispose(h, gcHandlePtr);
                }

                Monitor.Exit(Efl.All.InitLock);
            }
        }

    }

    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    /// <summary>Get screen size (in pixels) for the screen.
    /// Note that on some display systems this information is not available and a value of 0x0 will be returned.
    /// (Since EFL 1.22)</summary>
    /// <returns>The screen size in pixels.</returns>
    public Eina.Size2D GetScreenSizeInPixels() {
         var _ret_var = Efl.IScreenConcrete.NativeMethods.efl_screen_size_in_pixels_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get screen scaling factor.
    /// This is the factor by which window contents will be scaled on the screen.
    /// 
    /// Note that on some display systems this information is not available and a value of 1.0 will be returned.
    /// (Since EFL 1.22)</summary>
    /// <returns>The screen scaling factor.</returns>
    public float GetScreenScaleFactor() {
         var _ret_var = Efl.IScreenConcrete.NativeMethods.efl_screen_scale_factor_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the rotation of the screen.
    /// Most engines only return multiples of 90.
    /// (Since EFL 1.22)</summary>
    /// <returns>Screen rotation in degrees.</returns>
    public int GetScreenRotation() {
         var _ret_var = Efl.IScreenConcrete.NativeMethods.efl_screen_rotation_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the pixel density in DPI (Dots Per Inch) for the screen that a window is on.
    /// (Since EFL 1.22)</summary>
    /// <param name="xdpi">Horizontal DPI.</param>
    /// <param name="ydpi">Vertical DPI.</param>
    public void GetScreenDpi(out int xdpi, out int ydpi) {
                                                         Efl.IScreenConcrete.NativeMethods.efl_screen_dpi_get_ptr.Value.Delegate(this.NativeHandle,out xdpi, out ydpi);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get screen size (in pixels) for the screen.
/// Note that on some display systems this information is not available and a value of 0x0 will be returned.
/// (Since EFL 1.22)</summary>
/// <value>The screen size in pixels.</value>
    public Eina.Size2D ScreenSizeInPixels {
        get { return GetScreenSizeInPixels(); }
    }
    /// <summary>Get screen scaling factor.
/// This is the factor by which window contents will be scaled on the screen.
/// 
/// Note that on some display systems this information is not available and a value of 1.0 will be returned.
/// (Since EFL 1.22)</summary>
/// <value>The screen scaling factor.</value>
    public float ScreenScaleFactor {
        get { return GetScreenScaleFactor(); }
    }
    /// <summary>Get the rotation of the screen.
/// Most engines only return multiples of 90.
/// (Since EFL 1.22)</summary>
/// <value>Screen rotation in degrees.</value>
    public int ScreenRotation {
        get { return GetScreenRotation(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IScreenConcrete.efl_screen_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
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

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.IScreenConcrete.efl_screen_interface_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate Eina.Size2D.NativeStruct efl_screen_size_in_pixels_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_screen_size_in_pixels_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_screen_size_in_pixels_get_api_delegate> efl_screen_size_in_pixels_get_ptr = new Efl.Eo.FunctionWrapper<efl_screen_size_in_pixels_get_api_delegate>(Module, "efl_screen_size_in_pixels_get");

        private static Eina.Size2D.NativeStruct screen_size_in_pixels_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_screen_size_in_pixels_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((IScreen)wrapper).GetScreenSizeInPixels();
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            float _ret_var = default(float);
                try
                {
                    _ret_var = ((IScreen)wrapper).GetScreenScaleFactor();
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IScreen)wrapper).GetScreenRotation();
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                        xdpi = default(int);        ydpi = default(int);                            
                try
                {
                    ((IScreen)wrapper).GetScreenDpi(out xdpi, out ydpi);
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

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

