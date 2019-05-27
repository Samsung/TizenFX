#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Elementary progressbar internal part class</summary>
[Efl.Ui.ProgressbarPart.NativeMethods]
public class ProgressbarPart : Efl.Ui.LayoutPart, Efl.Eo.IWrapper,Efl.Ui.IRangeDisplay
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ProgressbarPart))
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
        efl_ui_progressbar_part_class_get();
    /// <summary>Initializes a new instance of the <see cref="ProgressbarPart"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public ProgressbarPart(Efl.Object parent= null
            ) : base(efl_ui_progressbar_part_class_get(), typeof(ProgressbarPart), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="ProgressbarPart"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected ProgressbarPart(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="ProgressbarPart"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ProgressbarPart(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
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

    /// <summary>Control the range value (in percentage) on a given range widget
    /// Use this call to set range levels.
    /// 
    /// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
    /// <returns>The range value (must be between $0.0 and 1.0)</returns>
    virtual public double GetRangeValue() {
         var _ret_var = Efl.Ui.IRangeDisplayConcrete.NativeMethods.efl_ui_range_value_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the range value (in percentage) on a given range widget
    /// Use this call to set range levels.
    /// 
    /// Note: If you pass a value out of the specified interval for <c>val</c>, it will be interpreted as the closest of the boundary values in the interval.</summary>
    /// <param name="val">The range value (must be between $0.0 and 1.0)</param>
    virtual public void SetRangeValue(double val) {
                                 Efl.Ui.IRangeDisplayConcrete.NativeMethods.efl_ui_range_value_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the minimum and maximum values of the given range widget.
    /// Note: If only one value is needed, the other pointer can be passed as <c>null</c>.</summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    virtual public void GetRangeMinMax(out double min, out double max) {
                                                         Efl.Ui.IRangeDisplayConcrete.NativeMethods.efl_ui_range_min_max_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out min, out max);
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
    virtual public void SetRangeMinMax(double min, double max) {
                                                         Efl.Ui.IRangeDisplayConcrete.NativeMethods.efl_ui_range_min_max_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),min, max);
        Eina.Error.RaiseIfUnhandledException();
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
        return Efl.Ui.ProgressbarPart.efl_ui_progressbar_part_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutPart.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

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

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.ProgressbarPart.efl_ui_progressbar_part_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate double efl_ui_range_value_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_range_value_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_range_value_get_api_delegate> efl_ui_range_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_range_value_get_api_delegate>(Module, "efl_ui_range_value_get");

        private static double range_value_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_range_value_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((ProgressbarPart)wrapper).GetRangeValue();
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((ProgressbarPart)wrapper).SetRangeValue(val);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                        min = default(double);        max = default(double);                            
                try
                {
                    ((ProgressbarPart)wrapper).GetRangeMinMax(out min, out max);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((ProgressbarPart)wrapper).SetRangeMinMax(min, max);
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

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

