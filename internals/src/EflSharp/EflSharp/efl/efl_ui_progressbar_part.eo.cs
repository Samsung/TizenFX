#define EFL_BETA
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
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.ProgressbarPart.NativeMethods]
[Efl.Eo.BindingEntity]
public class ProgressbarPart : Efl.Ui.LayoutPart, Efl.Ui.IRangeDisplay
{
    /// <summary>Pointer to the native class description.</summary>
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
            ) : base(efl_ui_progressbar_part_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected ProgressbarPart(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ProgressbarPart"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected ProgressbarPart(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ProgressbarPart"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ProgressbarPart(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>Emitted when the <see cref="Efl.Ui.IRangeDisplay.RangeValue"/> is getting changed.</summary>
    public event EventHandler ChangedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_RANGE_EVENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_RANGE_EVENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_RANGE_EVENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Emitted when the <see cref="Efl.Ui.IRangeDisplay.RangeValue"/> has reached the minimum of <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/>.</summary>
    public event EventHandler MinReachedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_RANGE_EVENT_MIN_REACHED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_RANGE_EVENT_MIN_REACHED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event MinReachedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnMinReachedEvent(EventArgs e)
    {
        var key = "_EFL_UI_RANGE_EVENT_MIN_REACHED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Emitted when the <c>range_value</c> has reached the maximum of <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/>.</summary>
    public event EventHandler MaxReachedEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_RANGE_EVENT_MAX_REACHED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_RANGE_EVENT_MAX_REACHED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event MaxReachedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnMaxReachedEvent(EventArgs e)
    {
        var key = "_EFL_UI_RANGE_EVENT_MAX_REACHED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>Control the value (position) of the widget within its valid range.
    /// Values outside the limits defined in <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/> are ignored and an error is printed.</summary>
    /// <returns>The range value (must be within the bounds of <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/>).</returns>
    public virtual double GetRangeValue() {
        var _ret_var = Efl.Ui.RangeDisplayConcrete.NativeMethods.efl_ui_range_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the value (position) of the widget within its valid range.
    /// Values outside the limits defined in <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/> are ignored and an error is printed.</summary>
    /// <param name="val">The range value (must be within the bounds of <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/>).</param>
    public virtual void SetRangeValue(double val) {
        Efl.Ui.RangeDisplayConcrete.NativeMethods.efl_ui_range_value_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Set the minimum and maximum values for given range widget.
    /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="Efl.Ui.IRangeDisplay.GetRangeValue"/>.
    /// 
    /// The default minimum and maximum values may be different for each class.
    /// 
    /// Note: maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    public virtual void GetRangeLimits(out double min, out double max) {
        Efl.Ui.RangeDisplayConcrete.NativeMethods.efl_ui_range_limits_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out min, out max);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Set the minimum and maximum values for given range widget.
    /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="Efl.Ui.IRangeDisplay.GetRangeValue"/>.
    /// 
    /// The default minimum and maximum values may be different for each class.
    /// 
    /// Note: maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    public virtual void SetRangeLimits(double min, double max) {
        Efl.Ui.RangeDisplayConcrete.NativeMethods.efl_ui_range_limits_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),min, max);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control the value (position) of the widget within its valid range.
    /// Values outside the limits defined in <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/> are ignored and an error is printed.</summary>
    /// <value>The range value (must be within the bounds of <see cref="Efl.Ui.IRangeDisplay.GetRangeLimits"/>).</value>
    public double RangeValue {
        get { return GetRangeValue(); }
        set { SetRangeValue(value); }
    }

    /// <summary>Set the minimum and maximum values for given range widget.
    /// If the current value is less than <c>min</c>, it will be updated to <c>min</c>. If it is bigger then <c>max</c>, will be updated to <c>max</c>. The resulting value can be obtained with <see cref="Efl.Ui.IRangeDisplay.GetRangeValue"/>.
    /// 
    /// The default minimum and maximum values may be different for each class.
    /// 
    /// Note: maximum must be greater than minimum, otherwise behavior is undefined.</summary>
    /// <value>The minimum value.</value>
    public (double, double) RangeLimits {
        get {
            double _out_min = default(double);
            double _out_max = default(double);
            GetRangeLimits(out _out_min,out _out_max);
            return (_out_min,_out_max);
        }
        set { SetRangeLimits( value.Item1,  value.Item2); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ProgressbarPart.efl_ui_progressbar_part_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutPart.NativeMethods
    {
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.ProgressbarPart.efl_ui_progressbar_part_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiProgressbarPart_ExtensionMethods {
    public static Efl.BindableProperty<double> RangeValue<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ProgressbarPart, T>magic = null) where T : Efl.Ui.ProgressbarPart {
        return new Efl.BindableProperty<double>("range_value", fac);
    }

    public static Efl.BindableProperty<double> RangeValue<T>(this Efl.BindablePart<T> part, Efl.Csharp.ExtensionTag<Efl.Ui.ProgressbarPart, T>magic = null) where T : Efl.Ui.ProgressbarPart {
        return new Efl.BindableProperty<double>(part.PartName, "range_value", part.Binder);
    }

}
#pragma warning restore CS1591
#endif
