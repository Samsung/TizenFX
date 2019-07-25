#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>EFL Gesture Recognizer Triple Tap class</summary>
[Efl.Canvas.GestureRecognizerTripleTap.NativeMethods]
[Efl.Eo.BindingEntity]
public class GestureRecognizerTripleTap : Efl.Canvas.GestureRecognizer
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(GestureRecognizerTripleTap))
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
        efl_canvas_gesture_recognizer_triple_tap_class_get();
    /// <summary>Initializes a new instance of the <see cref="GestureRecognizerTripleTap"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public GestureRecognizerTripleTap(Efl.Object parent= null
            ) : base(efl_canvas_gesture_recognizer_triple_tap_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected GestureRecognizerTripleTap(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="GestureRecognizerTripleTap"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected GestureRecognizerTripleTap(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="GestureRecognizerTripleTap"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected GestureRecognizerTripleTap(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Sets the time between taps to be recognized as a double tap.</summary>
    /// <returns>Time value.</returns>
    virtual public double GetTimeout() {
         var _ret_var = Efl.Canvas.GestureRecognizerTripleTap.NativeMethods.efl_gesture_recognizer_triple_tap_timeout_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the time between taps to be recognized as a double tap.</summary>
    /// <param name="time">Time value.</param>
    virtual public void SetTimeout(double time) {
                                 Efl.Canvas.GestureRecognizerTripleTap.NativeMethods.efl_gesture_recognizer_triple_tap_timeout_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),time);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Sets the time between taps to be recognized as a double tap.</summary>
    /// <value>Time value.</value>
    public double Timeout {
        get { return GetTimeout(); }
        set { SetTimeout(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.GestureRecognizerTripleTap.efl_canvas_gesture_recognizer_triple_tap_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.GestureRecognizer.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_gesture_recognizer_triple_tap_timeout_get_static_delegate == null)
            {
                efl_gesture_recognizer_triple_tap_timeout_get_static_delegate = new efl_gesture_recognizer_triple_tap_timeout_get_delegate(timeout_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTimeout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_recognizer_triple_tap_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_recognizer_triple_tap_timeout_get_static_delegate) });
            }

            if (efl_gesture_recognizer_triple_tap_timeout_set_static_delegate == null)
            {
                efl_gesture_recognizer_triple_tap_timeout_set_static_delegate = new efl_gesture_recognizer_triple_tap_timeout_set_delegate(timeout_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTimeout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gesture_recognizer_triple_tap_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gesture_recognizer_triple_tap_timeout_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.GestureRecognizerTripleTap.efl_canvas_gesture_recognizer_triple_tap_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_gesture_recognizer_triple_tap_timeout_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_gesture_recognizer_triple_tap_timeout_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gesture_recognizer_triple_tap_timeout_get_api_delegate> efl_gesture_recognizer_triple_tap_timeout_get_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_recognizer_triple_tap_timeout_get_api_delegate>(Module, "efl_gesture_recognizer_triple_tap_timeout_get");

        private static double timeout_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gesture_recognizer_triple_tap_timeout_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((GestureRecognizerTripleTap)ws.Target).GetTimeout();
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
                return efl_gesture_recognizer_triple_tap_timeout_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gesture_recognizer_triple_tap_timeout_get_delegate efl_gesture_recognizer_triple_tap_timeout_get_static_delegate;

        
        private delegate void efl_gesture_recognizer_triple_tap_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,  double time);

        
        public delegate void efl_gesture_recognizer_triple_tap_timeout_set_api_delegate(System.IntPtr obj,  double time);

        public static Efl.Eo.FunctionWrapper<efl_gesture_recognizer_triple_tap_timeout_set_api_delegate> efl_gesture_recognizer_triple_tap_timeout_set_ptr = new Efl.Eo.FunctionWrapper<efl_gesture_recognizer_triple_tap_timeout_set_api_delegate>(Module, "efl_gesture_recognizer_triple_tap_timeout_set");

        private static void timeout_set(System.IntPtr obj, System.IntPtr pd, double time)
        {
            Eina.Log.Debug("function efl_gesture_recognizer_triple_tap_timeout_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((GestureRecognizerTripleTap)ws.Target).SetTimeout(time);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gesture_recognizer_triple_tap_timeout_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), time);
            }
        }

        private static efl_gesture_recognizer_triple_tap_timeout_set_delegate efl_gesture_recognizer_triple_tap_timeout_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

