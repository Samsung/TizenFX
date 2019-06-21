#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>EFL Gesture Zoom class</summary>
[Efl.Canvas.GestureZoom.NativeMethods]
public class GestureZoom : Efl.Canvas.Gesture
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(GestureZoom))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_canvas_gesture_zoom_class_get();
    /// <summary>Initializes a new instance of the <see cref="GestureZoom"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public GestureZoom(Efl.Object parent= null
            ) : base(efl_canvas_gesture_zoom_class_get(), typeof(GestureZoom), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="GestureZoom"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected GestureZoom(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="GestureZoom"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected GestureZoom(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Gets zoom center point reported to user</summary>
    /// <returns>The radius value</returns>
    virtual public double GetRadius() {
         var _ret_var = Efl.Canvas.GestureZoom.NativeMethods.efl_gesture_zoom_radius_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets zoom value. (1.0 means no zoom)</summary>
    /// <returns>The zoom value</returns>
    virtual public double GetZoom() {
         var _ret_var = Efl.Canvas.GestureZoom.NativeMethods.efl_gesture_zoom_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.GestureZoom.efl_canvas_gesture_zoom_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Gesture.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gesture_zoom_radius_get_static_delegate == null)
            {
                efl_gesture_zoom_radius_get_static_delegate = new efl_gesture_zoom_radius_get_delegate(radius_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRadius") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_zoom_radius_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_zoom_radius_get_static_delegate) });
            }

            if (efl_gesture_zoom_get_static_delegate == null)
            {
                efl_gesture_zoom_get_static_delegate = new efl_gesture_zoom_get_delegate(zoom_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetZoom") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_zoom_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_zoom_get_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.GestureZoom.efl_canvas_gesture_zoom_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_gesture_zoom_radius_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_gesture_zoom_radius_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gesture_zoom_radius_get_api_delegate> efl_gesture_zoom_radius_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_zoom_radius_get_api_delegate>(Module, "efl_gesture_zoom_radius_get");

        private static double radius_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gesture_zoom_radius_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((GestureZoom)ws.Target).GetRadius();
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
                return efl_gesture_zoom_radius_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gesture_zoom_radius_get_delegate efl_gesture_zoom_radius_get_static_delegate;

        
        private delegate double efl_gesture_zoom_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_gesture_zoom_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gesture_zoom_get_api_delegate> efl_gesture_zoom_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_zoom_get_api_delegate>(Module, "efl_gesture_zoom_get");

        private static double zoom_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gesture_zoom_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((GestureZoom)ws.Target).GetZoom();
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
                return efl_gesture_zoom_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gesture_zoom_get_delegate efl_gesture_zoom_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

