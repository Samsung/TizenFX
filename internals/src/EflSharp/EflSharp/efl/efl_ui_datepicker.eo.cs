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

/// <summary>Datepicker widget
/// This is a widget which allows the user to pick a date using internal spinner. User can use the internal spinner to select year, month, day or user can input value using internal entry.</summary>
[Efl.Ui.Datepicker.NativeMethods]
[Efl.Eo.BindingEntity]
public class Datepicker : Efl.Ui.LayoutBase
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Datepicker))
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
        efl_ui_datepicker_class_get();

    /// <summary>Initializes a new instance of the <see cref="Datepicker"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
/// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Datepicker(Efl.Object parent
            , System.String style = null) : base(efl_ui_datepicker_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Datepicker(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Datepicker"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Datepicker(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Datepicker"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Datepicker(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when date value is changed</summary>
    public event EventHandler DateChangedEvent
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

                string key = "_EFL_UI_DATEPICKER_EVENT_DATE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_DATEPICKER_EVENT_DATE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event DateChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDateChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_DATEPICKER_EVENT_DATE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }


    /// <summary>The lower boundary of date.
    /// <c>year</c>: Year. The year range is from 1900 to 2137.
    /// 
    /// <c>month</c>: Month. The month range is from 1 to 12.
    /// 
    /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
    /// <param name="year">The year value.</param>
    /// <param name="month">The month value from 1 to 12.</param>
    /// <param name="day">The day value from 1 to 31.</param>
    public virtual void GetDateMin(out int year, out int month, out int day) {
        Efl.Ui.Datepicker.NativeMethods.efl_ui_datepicker_date_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out year, out month, out day);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The lower boundary of date.
    /// <c>year</c>: Year. The year range is from 1900 to 2137.
    /// 
    /// <c>month</c>: Month. The month range is from 1 to 12.
    /// 
    /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
    /// <param name="year">The year value.</param>
    /// <param name="month">The month value from 1 to 12.</param>
    /// <param name="day">The day value from 1 to 31.</param>
    public virtual void SetDateMin(int year, int month, int day) {
        Efl.Ui.Datepicker.NativeMethods.efl_ui_datepicker_date_min_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),year, month, day);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The upper boundary of date.
    /// <c>year</c>: Year. The year range is from 1900 to 2137.
    /// 
    /// <c>month</c>: Month. The month range is from 1 to 12.
    /// 
    /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
    /// <param name="year">The year value.</param>
    /// <param name="month">The month value from 1 to 12.</param>
    /// <param name="day">The day value from 1 to 31.</param>
    public virtual void GetDateMax(out int year, out int month, out int day) {
        Efl.Ui.Datepicker.NativeMethods.efl_ui_datepicker_date_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out year, out month, out day);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The upper boundary of date.
    /// <c>year</c>: Year. The year range is from 1900 to 2137.
    /// 
    /// <c>month</c>: Month. The month range is from 1 to 12.
    /// 
    /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
    /// <param name="year">The year value.</param>
    /// <param name="month">The month value from 1 to 12.</param>
    /// <param name="day">The day value from 1 to 31.</param>
    public virtual void SetDateMax(int year, int month, int day) {
        Efl.Ui.Datepicker.NativeMethods.efl_ui_datepicker_date_max_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),year, month, day);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The current value of date.
    /// <c>year</c>: Year. The year range is from 1900 to 2137.
    /// 
    /// <c>month</c>: Month. The month range is from 0 to 11.
    /// 
    /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
    /// <param name="year">The year value.</param>
    /// <param name="month">The month value from 1 to 12.</param>
    /// <param name="day">The day value from 1 to 31.</param>
    public virtual void GetDate(out int year, out int month, out int day) {
        Efl.Ui.Datepicker.NativeMethods.efl_ui_datepicker_date_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out year, out month, out day);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The current value of date.
    /// <c>year</c>: Year. The year range is from 1900 to 2137.
    /// 
    /// <c>month</c>: Month. The month range is from 0 to 11.
    /// 
    /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
    /// <param name="year">The year value.</param>
    /// <param name="month">The month value from 1 to 12.</param>
    /// <param name="day">The day value from 1 to 31.</param>
    public virtual void SetDate(int year, int month, int day) {
        Efl.Ui.Datepicker.NativeMethods.efl_ui_datepicker_date_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),year, month, day);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The lower boundary of date.
    /// <c>year</c>: Year. The year range is from 1900 to 2137.
    /// 
    /// <c>month</c>: Month. The month range is from 1 to 12.
    /// 
    /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
    /// <value>The year value.</value>
    public (int, int, int) DateMin {
        get {
            int _out_year = default(int);
            int _out_month = default(int);
            int _out_day = default(int);
            GetDateMin(out _out_year,out _out_month,out _out_day);
            return (_out_year,_out_month,_out_day);
        }
        set { SetDateMin( value.Item1,  value.Item2,  value.Item3); }
    }

    /// <summary>The upper boundary of date.
    /// <c>year</c>: Year. The year range is from 1900 to 2137.
    /// 
    /// <c>month</c>: Month. The month range is from 1 to 12.
    /// 
    /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
    /// <value>The year value.</value>
    public (int, int, int) DateMax {
        get {
            int _out_year = default(int);
            int _out_month = default(int);
            int _out_day = default(int);
            GetDateMax(out _out_year,out _out_month,out _out_day);
            return (_out_year,_out_month,_out_day);
        }
        set { SetDateMax( value.Item1,  value.Item2,  value.Item3); }
    }

    /// <summary>The current value of date.
    /// <c>year</c>: Year. The year range is from 1900 to 2137.
    /// 
    /// <c>month</c>: Month. The month range is from 0 to 11.
    /// 
    /// <c>day</c>: Day. The day range is from 1 to 31 according to <c>month</c>.</summary>
    /// <value>The year value.</value>
    public (int, int, int) Date {
        get {
            int _out_year = default(int);
            int _out_month = default(int);
            int _out_day = default(int);
            GetDate(out _out_year,out _out_month,out _out_day);
            return (_out_year,_out_month,_out_day);
        }
        set { SetDate( value.Item1,  value.Item2,  value.Item3); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Datepicker.efl_ui_datepicker_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_datepicker_date_min_get_static_delegate == null)
            {
                efl_ui_datepicker_date_min_get_static_delegate = new efl_ui_datepicker_date_min_get_delegate(date_min_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDateMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_date_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_min_get_static_delegate) });
            }

            if (efl_ui_datepicker_date_min_set_static_delegate == null)
            {
                efl_ui_datepicker_date_min_set_static_delegate = new efl_ui_datepicker_date_min_set_delegate(date_min_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDateMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_date_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_min_set_static_delegate) });
            }

            if (efl_ui_datepicker_date_max_get_static_delegate == null)
            {
                efl_ui_datepicker_date_max_get_static_delegate = new efl_ui_datepicker_date_max_get_delegate(date_max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDateMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_date_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_max_get_static_delegate) });
            }

            if (efl_ui_datepicker_date_max_set_static_delegate == null)
            {
                efl_ui_datepicker_date_max_set_static_delegate = new efl_ui_datepicker_date_max_set_delegate(date_max_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDateMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_date_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_max_set_static_delegate) });
            }

            if (efl_ui_datepicker_date_get_static_delegate == null)
            {
                efl_ui_datepicker_date_get_static_delegate = new efl_ui_datepicker_date_get_delegate(date_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_date_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_get_static_delegate) });
            }

            if (efl_ui_datepicker_date_set_static_delegate == null)
            {
                efl_ui_datepicker_date_set_static_delegate = new efl_ui_datepicker_date_set_delegate(date_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_date_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_date_set_static_delegate) });
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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Datepicker.efl_ui_datepicker_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_datepicker_date_min_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int year,  out int month,  out int day);

        
        public delegate void efl_ui_datepicker_date_min_get_api_delegate(System.IntPtr obj,  out int year,  out int month,  out int day);

        public static Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_min_get_api_delegate> efl_ui_datepicker_date_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_min_get_api_delegate>(Module, "efl_ui_datepicker_date_min_get");

        private static void date_min_get(System.IntPtr obj, System.IntPtr pd, out int year, out int month, out int day)
        {
            Eina.Log.Debug("function efl_ui_datepicker_date_min_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                year = default(int);month = default(int);day = default(int);
                try
                {
                    ((Datepicker)ws.Target).GetDateMin(out year, out month, out day);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_datepicker_date_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out year, out month, out day);
            }
        }

        private static efl_ui_datepicker_date_min_get_delegate efl_ui_datepicker_date_min_get_static_delegate;

        
        private delegate void efl_ui_datepicker_date_min_set_delegate(System.IntPtr obj, System.IntPtr pd,  int year,  int month,  int day);

        
        public delegate void efl_ui_datepicker_date_min_set_api_delegate(System.IntPtr obj,  int year,  int month,  int day);

        public static Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_min_set_api_delegate> efl_ui_datepicker_date_min_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_min_set_api_delegate>(Module, "efl_ui_datepicker_date_min_set");

        private static void date_min_set(System.IntPtr obj, System.IntPtr pd, int year, int month, int day)
        {
            Eina.Log.Debug("function efl_ui_datepicker_date_min_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Datepicker)ws.Target).SetDateMin(year, month, day);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_datepicker_date_min_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), year, month, day);
            }
        }

        private static efl_ui_datepicker_date_min_set_delegate efl_ui_datepicker_date_min_set_static_delegate;

        
        private delegate void efl_ui_datepicker_date_max_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int year,  out int month,  out int day);

        
        public delegate void efl_ui_datepicker_date_max_get_api_delegate(System.IntPtr obj,  out int year,  out int month,  out int day);

        public static Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_max_get_api_delegate> efl_ui_datepicker_date_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_max_get_api_delegate>(Module, "efl_ui_datepicker_date_max_get");

        private static void date_max_get(System.IntPtr obj, System.IntPtr pd, out int year, out int month, out int day)
        {
            Eina.Log.Debug("function efl_ui_datepicker_date_max_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                year = default(int);month = default(int);day = default(int);
                try
                {
                    ((Datepicker)ws.Target).GetDateMax(out year, out month, out day);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_datepicker_date_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out year, out month, out day);
            }
        }

        private static efl_ui_datepicker_date_max_get_delegate efl_ui_datepicker_date_max_get_static_delegate;

        
        private delegate void efl_ui_datepicker_date_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  int year,  int month,  int day);

        
        public delegate void efl_ui_datepicker_date_max_set_api_delegate(System.IntPtr obj,  int year,  int month,  int day);

        public static Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_max_set_api_delegate> efl_ui_datepicker_date_max_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_max_set_api_delegate>(Module, "efl_ui_datepicker_date_max_set");

        private static void date_max_set(System.IntPtr obj, System.IntPtr pd, int year, int month, int day)
        {
            Eina.Log.Debug("function efl_ui_datepicker_date_max_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Datepicker)ws.Target).SetDateMax(year, month, day);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_datepicker_date_max_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), year, month, day);
            }
        }

        private static efl_ui_datepicker_date_max_set_delegate efl_ui_datepicker_date_max_set_static_delegate;

        
        private delegate void efl_ui_datepicker_date_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int year,  out int month,  out int day);

        
        public delegate void efl_ui_datepicker_date_get_api_delegate(System.IntPtr obj,  out int year,  out int month,  out int day);

        public static Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_get_api_delegate> efl_ui_datepicker_date_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_get_api_delegate>(Module, "efl_ui_datepicker_date_get");

        private static void date_get(System.IntPtr obj, System.IntPtr pd, out int year, out int month, out int day)
        {
            Eina.Log.Debug("function efl_ui_datepicker_date_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                year = default(int);month = default(int);day = default(int);
                try
                {
                    ((Datepicker)ws.Target).GetDate(out year, out month, out day);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_datepicker_date_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out year, out month, out day);
            }
        }

        private static efl_ui_datepicker_date_get_delegate efl_ui_datepicker_date_get_static_delegate;

        
        private delegate void efl_ui_datepicker_date_set_delegate(System.IntPtr obj, System.IntPtr pd,  int year,  int month,  int day);

        
        public delegate void efl_ui_datepicker_date_set_api_delegate(System.IntPtr obj,  int year,  int month,  int day);

        public static Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_set_api_delegate> efl_ui_datepicker_date_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_set_api_delegate>(Module, "efl_ui_datepicker_date_set");

        private static void date_set(System.IntPtr obj, System.IntPtr pd, int year, int month, int day)
        {
            Eina.Log.Debug("function efl_ui_datepicker_date_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Datepicker)ws.Target).SetDate(year, month, day);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_datepicker_date_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), year, month, day);
            }
        }

        private static efl_ui_datepicker_date_set_delegate efl_ui_datepicker_date_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiDatepicker_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
