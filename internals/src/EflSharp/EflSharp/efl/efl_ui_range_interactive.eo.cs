#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Interface that extends the normal displaying properties with usage properties.
/// The properties defined here are used to manipulate the way a user interacts with a displayed range.</summary>
[Efl.Ui.IRangeInteractiveConcrete.NativeMethods]
public interface IRangeInteractive : 
    Efl.Ui.IRangeDisplay ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Control the step used to increment or decrement values for given widget.
/// This value will be incremented or decremented to the displayed value.
/// 
/// By default step value is equal to 1.
/// 
/// Warning: The step value should be bigger than 0.</summary>
/// <returns>The step value.</returns>
double GetRangeStep();
    /// <summary>Control the step used to increment or decrement values for given widget.
/// This value will be incremented or decremented to the displayed value.
/// 
/// By default step value is equal to 1.
/// 
/// Warning: The step value should be bigger than 0.</summary>
/// <param name="step">The step value.</param>
void SetRangeStep(double step);
            /// <summary>Control the step used to increment or decrement values for given widget.
    /// This value will be incremented or decremented to the displayed value.
    /// 
    /// By default step value is equal to 1.
    /// 
    /// Warning: The step value should be bigger than 0.</summary>
    /// <value>The step value.</value>
    double RangeStep {
        get ;
        set ;
    }
}
/// <summary>Interface that extends the normal displaying properties with usage properties.
/// The properties defined here are used to manipulate the way a user interacts with a displayed range.</summary>
sealed public class IRangeInteractiveConcrete :
    Efl.Eo.EoWrapper
    , IRangeInteractive
    , Efl.Ui.IRangeDisplay
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IRangeInteractiveConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_ui_range_interactive_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IRangeInteractive"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    private IRangeInteractiveConcrete(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Control the step used to increment or decrement values for given widget.
    /// This value will be incremented or decremented to the displayed value.
    /// 
    /// By default step value is equal to 1.
    /// 
    /// Warning: The step value should be bigger than 0.</summary>
    /// <returns>The step value.</returns>
    public double GetRangeStep() {
         var _ret_var = Efl.Ui.IRangeInteractiveConcrete.NativeMethods.efl_ui_range_step_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the step used to increment or decrement values for given widget.
    /// This value will be incremented or decremented to the displayed value.
    /// 
    /// By default step value is equal to 1.
    /// 
    /// Warning: The step value should be bigger than 0.</summary>
    /// <param name="step">The step value.</param>
    public void SetRangeStep(double step) {
                                 Efl.Ui.IRangeInteractiveConcrete.NativeMethods.efl_ui_range_step_set_ptr.Value.Delegate(this.NativeHandle,step);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the range value (in percentage) on a given range widget
    /// Use this call to set range levels.
    /// 
    /// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
    /// <returns>The range value (must be between $0.0 and 1.0)</returns>
    public double GetRangeValue() {
         var _ret_var = Efl.Ui.IRangeDisplayConcrete.NativeMethods.efl_ui_range_value_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the range value (in percentage) on a given range widget
    /// Use this call to set range levels.
    /// 
    /// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
    /// <param name="val">The range value (must be between $0.0 and 1.0)</param>
    public void SetRangeValue(double val) {
                                 Efl.Ui.IRangeDisplayConcrete.NativeMethods.efl_ui_range_value_set_ptr.Value.Delegate(this.NativeHandle,val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the minimum and maximum values of the given range widget.
    /// Note: If only one value is needed, the other pointer can be passed as <c>null</c>.</summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    public void GetRangeMinMax(out double min, out double max) {
                                                         Efl.Ui.IRangeDisplayConcrete.NativeMethods.efl_ui_range_min_max_get_ptr.Value.Delegate(this.NativeHandle,out min, out max);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set the minimum and maximum values for given range widget.
    /// Define the allowed range of values to be selected by the user.
    /// 
    /// If actual value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The actual value can be obtained with <see cref="Efl.Ui.IRangeDisplay.GetRangeValue"/>
    /// 
    /// The minimum and maximum values may be different for each class.
    /// 
    /// Warning: maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    public void SetRangeMinMax(double min, double max) {
                                                         Efl.Ui.IRangeDisplayConcrete.NativeMethods.efl_ui_range_min_max_set_ptr.Value.Delegate(this.NativeHandle,min, max);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Control the step used to increment or decrement values for given widget.
    /// This value will be incremented or decremented to the displayed value.
    /// 
    /// By default step value is equal to 1.
    /// 
    /// Warning: The step value should be bigger than 0.</summary>
    /// <value>The step value.</value>
    public double RangeStep {
        get { return GetRangeStep(); }
        set { SetRangeStep(value); }
    }
    /// <summary>Control the range value (in percentage) on a given range widget
    /// Use this call to set range levels.
    /// 
    /// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
    /// <value>The range value (must be between $0.0 and 1.0)</value>
    public double RangeValue {
        get { return GetRangeValue(); }
        set { SetRangeValue(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IRangeInteractiveConcrete.efl_ui_range_interactive_interface_get();
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

            if (efl_ui_range_step_get_static_delegate == null)
            {
                efl_ui_range_step_get_static_delegate = new efl_ui_range_step_get_delegate(range_step_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRangeStep") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_step_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_step_get_static_delegate) });
            }

            if (efl_ui_range_step_set_static_delegate == null)
            {
                efl_ui_range_step_set_static_delegate = new efl_ui_range_step_set_delegate(range_step_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRangeStep") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_step_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_step_set_static_delegate) });
            }

            if (efl_ui_range_value_get_static_delegate == null)
            {
                efl_ui_range_value_get_static_delegate = new efl_ui_range_value_get_delegate(range_value_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRangeValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_value_get_static_delegate) });
            }

            if (efl_ui_range_value_set_static_delegate == null)
            {
                efl_ui_range_value_set_static_delegate = new efl_ui_range_value_set_delegate(range_value_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRangeValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_value_set_static_delegate) });
            }

            if (efl_ui_range_min_max_get_static_delegate == null)
            {
                efl_ui_range_min_max_get_static_delegate = new efl_ui_range_min_max_get_delegate(range_min_max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRangeMinMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_min_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_min_max_get_static_delegate) });
            }

            if (efl_ui_range_min_max_set_static_delegate == null)
            {
                efl_ui_range_min_max_set_static_delegate = new efl_ui_range_min_max_set_delegate(range_min_max_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRangeMinMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_range_min_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_range_min_max_set_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IRangeInteractiveConcrete.efl_ui_range_interactive_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_ui_range_step_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_range_step_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_range_step_get_api_delegate> efl_ui_range_step_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_step_get_api_delegate>(Module, "efl_ui_range_step_get");

        private static double range_step_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_range_step_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((IRangeInteractive)ws.Target).GetRangeStep();
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
                return efl_ui_range_step_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_range_step_get_delegate efl_ui_range_step_get_static_delegate;

        
        private delegate void efl_ui_range_step_set_delegate(System.IntPtr obj, System.IntPtr pd,  double step);

        
        public delegate void efl_ui_range_step_set_api_delegate(System.IntPtr obj,  double step);

        public static Efl.Eo.FunctionWrapper<efl_ui_range_step_set_api_delegate> efl_ui_range_step_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_step_set_api_delegate>(Module, "efl_ui_range_step_set");

        private static void range_step_set(System.IntPtr obj, System.IntPtr pd, double step)
        {
            Eina.Log.Debug("function efl_ui_range_step_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IRangeInteractive)ws.Target).SetRangeStep(step);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_range_step_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), step);
            }
        }

        private static efl_ui_range_step_set_delegate efl_ui_range_step_set_static_delegate;

        
        private delegate double efl_ui_range_value_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_range_value_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_range_value_get_api_delegate> efl_ui_range_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_value_get_api_delegate>(Module, "efl_ui_range_value_get");

        private static double range_value_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_range_value_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((IRangeInteractive)ws.Target).GetRangeValue();
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
                return efl_ui_range_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_range_value_get_delegate efl_ui_range_value_get_static_delegate;

        
        private delegate void efl_ui_range_value_set_delegate(System.IntPtr obj, System.IntPtr pd,  double val);

        
        public delegate void efl_ui_range_value_set_api_delegate(System.IntPtr obj,  double val);

        public static Efl.Eo.FunctionWrapper<efl_ui_range_value_set_api_delegate> efl_ui_range_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_value_set_api_delegate>(Module, "efl_ui_range_value_set");

        private static void range_value_set(System.IntPtr obj, System.IntPtr pd, double val)
        {
            Eina.Log.Debug("function efl_ui_range_value_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IRangeInteractive)ws.Target).SetRangeValue(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_range_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_ui_range_value_set_delegate efl_ui_range_value_set_static_delegate;

        
        private delegate void efl_ui_range_min_max_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double min,  out double max);

        
        public delegate void efl_ui_range_min_max_get_api_delegate(System.IntPtr obj,  out double min,  out double max);

        public static Efl.Eo.FunctionWrapper<efl_ui_range_min_max_get_api_delegate> efl_ui_range_min_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_min_max_get_api_delegate>(Module, "efl_ui_range_min_max_get");

        private static void range_min_max_get(System.IntPtr obj, System.IntPtr pd, out double min, out double max)
        {
            Eina.Log.Debug("function efl_ui_range_min_max_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        min = default(double);        max = default(double);                            
                try
                {
                    ((IRangeInteractive)ws.Target).GetRangeMinMax(out min, out max);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_range_min_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out min, out max);
            }
        }

        private static efl_ui_range_min_max_get_delegate efl_ui_range_min_max_get_static_delegate;

        
        private delegate void efl_ui_range_min_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  double min,  double max);

        
        public delegate void efl_ui_range_min_max_set_api_delegate(System.IntPtr obj,  double min,  double max);

        public static Efl.Eo.FunctionWrapper<efl_ui_range_min_max_set_api_delegate> efl_ui_range_min_max_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_min_max_set_api_delegate>(Module, "efl_ui_range_min_max_set");

        private static void range_min_max_set(System.IntPtr obj, System.IntPtr pd, double min, double max)
        {
            Eina.Log.Debug("function efl_ui_range_min_max_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IRangeInteractive)ws.Target).SetRangeMinMax(min, max);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_range_min_max_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), min, max);
            }
        }

        private static efl_ui_range_min_max_set_delegate efl_ui_range_min_max_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

