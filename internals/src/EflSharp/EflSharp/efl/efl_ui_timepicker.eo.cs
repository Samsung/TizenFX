#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Timepicker widget
/// This is a widget which allows the user to pick a time using internal spinner. User can use the internal spinner to select hour, minute, AM/PM or user can input value using internal entry.</summary>
[Efl.Ui.Timepicker.NativeMethods]
[Efl.Eo.BindingEntity]
public class Timepicker : Efl.Ui.LayoutBase
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Timepicker))
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
        efl_ui_timepicker_class_get();
    /// <summary>Initializes a new instance of the <see cref="Timepicker"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Timepicker(Efl.Object parent
            , System.String style = null) : base(efl_ui_timepicker_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Timepicker(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Timepicker"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Timepicker(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Timepicker"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Timepicker(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when date is changed</summary>
    public event EventHandler ChangedEvt
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

                string key = "_EFL_UI_TIMEPICKER_EVENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TIMEPICKER_EVENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChangedEvt.</summary>
    public void OnChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_TIMEPICKER_EVENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>The current value of time
    /// <c>hour</c>: Hour. The hour value is in terms of 24 hour format from 0 to 23.
    /// 
    /// <c>min</c>: Minute. The minute range is from 0 to 59.</summary>
    /// <param name="hour">The hour value from 0 to 23.</param>
    /// <param name="min">The minute value from 0 to 59.</param>
    virtual public void GetTime(out int hour, out int min) {
                                                         Efl.Ui.Timepicker.NativeMethods.efl_ui_timepicker_time_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out hour, out min);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The current value of time
    /// <c>hour</c>: Hour. The hour value is in terms of 24 hour format from 0 to 23.
    /// 
    /// <c>min</c>: Minute. The minute range is from 0 to 59.</summary>
    /// <param name="hour">The hour value from 0 to 23.</param>
    /// <param name="min">The minute value from 0 to 59.</param>
    virtual public void SetTime(int hour, int min) {
                                                         Efl.Ui.Timepicker.NativeMethods.efl_ui_timepicker_time_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hour, min);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Control if the Timepicker displays 24 hour time or 12 hour time including AM/PM button.</summary>
    /// <returns><c>true</c> to display the 24 hour time, <c>false</c> to display 12 hour time including AM/PM button.</returns>
    virtual public bool GetAmpm() {
         var _ret_var = Efl.Ui.Timepicker.NativeMethods.efl_ui_timepicker_ampm_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control if the Timepicker displays 24 hour time or 12 hour time including AM/PM button.</summary>
    /// <param name="is_24hour"><c>true</c> to display the 24 hour time, <c>false</c> to display 12 hour time including AM/PM button.</param>
    virtual public void SetAmpm(bool is_24hour) {
                                 Efl.Ui.Timepicker.NativeMethods.efl_ui_timepicker_ampm_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),is_24hour);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control if the Timepicker displays 24 hour time or 12 hour time including AM/PM button.</summary>
    /// <value><c>true</c> to display the 24 hour time, <c>false</c> to display 12 hour time including AM/PM button.</value>
    public bool Ampm {
        get { return GetAmpm(); }
        set { SetAmpm(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Timepicker.efl_ui_timepicker_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_timepicker_time_get_static_delegate == null)
            {
                efl_ui_timepicker_time_get_static_delegate = new efl_ui_timepicker_time_get_delegate(time_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTime") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_timepicker_time_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_time_get_static_delegate) });
            }

            if (efl_ui_timepicker_time_set_static_delegate == null)
            {
                efl_ui_timepicker_time_set_static_delegate = new efl_ui_timepicker_time_set_delegate(time_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTime") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_timepicker_time_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_time_set_static_delegate) });
            }

            if (efl_ui_timepicker_ampm_get_static_delegate == null)
            {
                efl_ui_timepicker_ampm_get_static_delegate = new efl_ui_timepicker_ampm_get_delegate(ampm_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAmpm") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_timepicker_ampm_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_ampm_get_static_delegate) });
            }

            if (efl_ui_timepicker_ampm_set_static_delegate == null)
            {
                efl_ui_timepicker_ampm_set_static_delegate = new efl_ui_timepicker_ampm_set_delegate(ampm_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAmpm") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_timepicker_ampm_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_timepicker_ampm_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Timepicker.efl_ui_timepicker_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_timepicker_time_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int hour,  out int min);

        
        public delegate void efl_ui_timepicker_time_get_api_delegate(System.IntPtr obj,  out int hour,  out int min);

        public static Efl.Eo.FunctionWrapper<efl_ui_timepicker_time_get_api_delegate> efl_ui_timepicker_time_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_timepicker_time_get_api_delegate>(Module, "efl_ui_timepicker_time_get");

        private static void time_get(System.IntPtr obj, System.IntPtr pd, out int hour, out int min)
        {
            Eina.Log.Debug("function efl_ui_timepicker_time_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        hour = default(int);        min = default(int);                            
                try
                {
                    ((Timepicker)ws.Target).GetTime(out hour, out min);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_timepicker_time_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out hour, out min);
            }
        }

        private static efl_ui_timepicker_time_get_delegate efl_ui_timepicker_time_get_static_delegate;

        
        private delegate void efl_ui_timepicker_time_set_delegate(System.IntPtr obj, System.IntPtr pd,  int hour,  int min);

        
        public delegate void efl_ui_timepicker_time_set_api_delegate(System.IntPtr obj,  int hour,  int min);

        public static Efl.Eo.FunctionWrapper<efl_ui_timepicker_time_set_api_delegate> efl_ui_timepicker_time_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_timepicker_time_set_api_delegate>(Module, "efl_ui_timepicker_time_set");

        private static void time_set(System.IntPtr obj, System.IntPtr pd, int hour, int min)
        {
            Eina.Log.Debug("function efl_ui_timepicker_time_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Timepicker)ws.Target).SetTime(hour, min);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_timepicker_time_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), hour, min);
            }
        }

        private static efl_ui_timepicker_time_set_delegate efl_ui_timepicker_time_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_timepicker_ampm_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_timepicker_ampm_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_timepicker_ampm_get_api_delegate> efl_ui_timepicker_ampm_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_timepicker_ampm_get_api_delegate>(Module, "efl_ui_timepicker_ampm_get");

        private static bool ampm_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_timepicker_ampm_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Timepicker)ws.Target).GetAmpm();
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
                return efl_ui_timepicker_ampm_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_timepicker_ampm_get_delegate efl_ui_timepicker_ampm_get_static_delegate;

        
        private delegate void efl_ui_timepicker_ampm_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool is_24hour);

        
        public delegate void efl_ui_timepicker_ampm_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool is_24hour);

        public static Efl.Eo.FunctionWrapper<efl_ui_timepicker_ampm_set_api_delegate> efl_ui_timepicker_ampm_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_timepicker_ampm_set_api_delegate>(Module, "efl_ui_timepicker_ampm_set");

        private static void ampm_set(System.IntPtr obj, System.IntPtr pd, bool is_24hour)
        {
            Eina.Log.Debug("function efl_ui_timepicker_ampm_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Timepicker)ws.Target).SetAmpm(is_24hour);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_timepicker_ampm_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), is_24hour);
            }
        }

        private static efl_ui_timepicker_ampm_set_delegate efl_ui_timepicker_ampm_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

