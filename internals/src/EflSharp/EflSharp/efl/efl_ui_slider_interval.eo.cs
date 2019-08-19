#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>An interval slider.
/// This is a slider with two indicators.</summary>
[Efl.Ui.SliderInterval.NativeMethods]
[Efl.Eo.BindingEntity]
public class SliderInterval : Efl.Ui.Slider
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(SliderInterval))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_slider_interval_class_get();
    /// <summary>Initializes a new instance of the <see cref="SliderInterval"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public SliderInterval(Efl.Object parent
            , System.String style = null) : base(efl_ui_slider_interval_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected SliderInterval(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="SliderInterval"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected SliderInterval(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="SliderInterval"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected SliderInterval(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Sets up position of two indicators at start and end position.</summary>
    /// <param name="from">interval minimum value</param>
    /// <param name="to">interval maximum value</param>
    virtual public void GetIntervalValue(out double from, out double to) {
                                                         Efl.Ui.SliderInterval.NativeMethods.efl_ui_slider_interval_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out from, out to);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets up position of two indicators at start and end position.</summary>
    /// <param name="from">interval minimum value</param>
    /// <param name="to">interval maximum value</param>
    virtual public void SetIntervalValue(double from, double to) {
                                                         Efl.Ui.SliderInterval.NativeMethods.efl_ui_slider_interval_value_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),from, to);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.SliderInterval.efl_ui_slider_interval_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Slider.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_slider_interval_value_get_static_delegate == null)
            {
                efl_ui_slider_interval_value_get_static_delegate = new efl_ui_slider_interval_value_get_delegate(interval_value_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIntervalValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_slider_interval_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_slider_interval_value_get_static_delegate) });
            }

            if (efl_ui_slider_interval_value_set_static_delegate == null)
            {
                efl_ui_slider_interval_value_set_static_delegate = new efl_ui_slider_interval_value_set_delegate(interval_value_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetIntervalValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_slider_interval_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_slider_interval_value_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.SliderInterval.efl_ui_slider_interval_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_slider_interval_value_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double from,  out double to);

        
        public delegate void efl_ui_slider_interval_value_get_api_delegate(System.IntPtr obj,  out double from,  out double to);

        public static Efl.Eo.FunctionWrapper<efl_ui_slider_interval_value_get_api_delegate> efl_ui_slider_interval_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_slider_interval_value_get_api_delegate>(Module, "efl_ui_slider_interval_value_get");

        private static void interval_value_get(System.IntPtr obj, System.IntPtr pd, out double from, out double to)
        {
            Eina.Log.Debug("function efl_ui_slider_interval_value_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        from = default(double);        to = default(double);                            
                try
                {
                    ((SliderInterval)ws.Target).GetIntervalValue(out from, out to);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_slider_interval_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out from, out to);
            }
        }

        private static efl_ui_slider_interval_value_get_delegate efl_ui_slider_interval_value_get_static_delegate;

        
        private delegate void efl_ui_slider_interval_value_set_delegate(System.IntPtr obj, System.IntPtr pd,  double from,  double to);

        
        public delegate void efl_ui_slider_interval_value_set_api_delegate(System.IntPtr obj,  double from,  double to);

        public static Efl.Eo.FunctionWrapper<efl_ui_slider_interval_value_set_api_delegate> efl_ui_slider_interval_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_slider_interval_value_set_api_delegate>(Module, "efl_ui_slider_interval_value_set");

        private static void interval_value_set(System.IntPtr obj, System.IntPtr pd, double from, double to)
        {
            Eina.Log.Debug("function efl_ui_slider_interval_value_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((SliderInterval)ws.Target).SetIntervalValue(from, to);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_slider_interval_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), from, to);
            }
        }

        private static efl_ui_slider_interval_value_set_delegate efl_ui_slider_interval_value_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

