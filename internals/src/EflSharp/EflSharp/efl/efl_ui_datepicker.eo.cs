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
public class Datepicker : Efl.Ui.LayoutBase, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
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
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Datepicker(Efl.Object parent
            , System.String style = null) : base(efl_ui_datepicker_class_get(), typeof(Datepicker), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Datepicker"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Datepicker(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="Datepicker"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Datepicker(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
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

    /// <summary>Called when date value is changed</summary>
    public event EventHandler ChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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

                string key = "_EFL_UI_DATEPICKER_EVENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_DATEPICKER_EVENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChangedEvt.</summary>
    public void OnChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_DATEPICKER_EVENT_CHANGED";
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
    virtual public void GetMin(out int year, out int month, out int day) {
                                                                                 Efl.Ui.Datepicker.NativeMethods.efl_ui_datepicker_min_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out year, out month, out day);
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
    virtual public void SetMin(int year, int month, int day) {
                                                                                 Efl.Ui.Datepicker.NativeMethods.efl_ui_datepicker_min_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),year, month, day);
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
    virtual public void GetMax(out int year, out int month, out int day) {
                                                                                 Efl.Ui.Datepicker.NativeMethods.efl_ui_datepicker_max_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out year, out month, out day);
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
    virtual public void SetMax(int year, int month, int day) {
                                                                                 Efl.Ui.Datepicker.NativeMethods.efl_ui_datepicker_max_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),year, month, day);
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
    virtual public void GetDate(out int year, out int month, out int day) {
                                                                                 Efl.Ui.Datepicker.NativeMethods.efl_ui_datepicker_date_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),out year, out month, out day);
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
    virtual public void SetDate(int year, int month, int day) {
                                                                                 Efl.Ui.Datepicker.NativeMethods.efl_ui_datepicker_date_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),year, month, day);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Datepicker.efl_ui_datepicker_class_get();
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

            if (efl_ui_datepicker_min_get_static_delegate == null)
            {
                efl_ui_datepicker_min_get_static_delegate = new efl_ui_datepicker_min_get_delegate(min_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_min_get_static_delegate) });
            }

            if (efl_ui_datepicker_min_set_static_delegate == null)
            {
                efl_ui_datepicker_min_set_static_delegate = new efl_ui_datepicker_min_set_delegate(min_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMin") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_min_set_static_delegate) });
            }

            if (efl_ui_datepicker_max_get_static_delegate == null)
            {
                efl_ui_datepicker_max_get_static_delegate = new efl_ui_datepicker_max_get_delegate(max_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_max_get_static_delegate) });
            }

            if (efl_ui_datepicker_max_set_static_delegate == null)
            {
                efl_ui_datepicker_max_set_static_delegate = new efl_ui_datepicker_max_set_delegate(max_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMax") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_datepicker_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_datepicker_max_set_static_delegate) });
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

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Datepicker.efl_ui_datepicker_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate void efl_ui_datepicker_min_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int year,  out int month,  out int day);

        
        public delegate void efl_ui_datepicker_min_get_api_delegate(System.IntPtr obj,  out int year,  out int month,  out int day);

        public static Efl.Eo.FunctionWrapper<efl_ui_datepicker_min_get_api_delegate> efl_ui_datepicker_min_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_datepicker_min_get_api_delegate>(Module, "efl_ui_datepicker_min_get");

        private static void min_get(System.IntPtr obj, System.IntPtr pd, out int year, out int month, out int day)
        {
            Eina.Log.Debug("function efl_ui_datepicker_min_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                year = default(int);        month = default(int);        day = default(int);                                    
                try
                {
                    ((Datepicker)wrapper).GetMin(out year, out month, out day);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_datepicker_min_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out year, out month, out day);
            }
        }

        private static efl_ui_datepicker_min_get_delegate efl_ui_datepicker_min_get_static_delegate;

        
        private delegate void efl_ui_datepicker_min_set_delegate(System.IntPtr obj, System.IntPtr pd,  int year,  int month,  int day);

        
        public delegate void efl_ui_datepicker_min_set_api_delegate(System.IntPtr obj,  int year,  int month,  int day);

        public static Efl.Eo.FunctionWrapper<efl_ui_datepicker_min_set_api_delegate> efl_ui_datepicker_min_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_datepicker_min_set_api_delegate>(Module, "efl_ui_datepicker_min_set");

        private static void min_set(System.IntPtr obj, System.IntPtr pd, int year, int month, int day)
        {
            Eina.Log.Debug("function efl_ui_datepicker_min_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    
                try
                {
                    ((Datepicker)wrapper).SetMin(year, month, day);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_datepicker_min_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), year, month, day);
            }
        }

        private static efl_ui_datepicker_min_set_delegate efl_ui_datepicker_min_set_static_delegate;

        
        private delegate void efl_ui_datepicker_max_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int year,  out int month,  out int day);

        
        public delegate void efl_ui_datepicker_max_get_api_delegate(System.IntPtr obj,  out int year,  out int month,  out int day);

        public static Efl.Eo.FunctionWrapper<efl_ui_datepicker_max_get_api_delegate> efl_ui_datepicker_max_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_datepicker_max_get_api_delegate>(Module, "efl_ui_datepicker_max_get");

        private static void max_get(System.IntPtr obj, System.IntPtr pd, out int year, out int month, out int day)
        {
            Eina.Log.Debug("function efl_ui_datepicker_max_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                year = default(int);        month = default(int);        day = default(int);                                    
                try
                {
                    ((Datepicker)wrapper).GetMax(out year, out month, out day);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_datepicker_max_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out year, out month, out day);
            }
        }

        private static efl_ui_datepicker_max_get_delegate efl_ui_datepicker_max_get_static_delegate;

        
        private delegate void efl_ui_datepicker_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  int year,  int month,  int day);

        
        public delegate void efl_ui_datepicker_max_set_api_delegate(System.IntPtr obj,  int year,  int month,  int day);

        public static Efl.Eo.FunctionWrapper<efl_ui_datepicker_max_set_api_delegate> efl_ui_datepicker_max_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_datepicker_max_set_api_delegate>(Module, "efl_ui_datepicker_max_set");

        private static void max_set(System.IntPtr obj, System.IntPtr pd, int year, int month, int day)
        {
            Eina.Log.Debug("function efl_ui_datepicker_max_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    
                try
                {
                    ((Datepicker)wrapper).SetMax(year, month, day);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_datepicker_max_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), year, month, day);
            }
        }

        private static efl_ui_datepicker_max_set_delegate efl_ui_datepicker_max_set_static_delegate;

        
        private delegate void efl_ui_datepicker_date_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int year,  out int month,  out int day);

        
        public delegate void efl_ui_datepicker_date_get_api_delegate(System.IntPtr obj,  out int year,  out int month,  out int day);

        public static Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_get_api_delegate> efl_ui_datepicker_date_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_datepicker_date_get_api_delegate>(Module, "efl_ui_datepicker_date_get");

        private static void date_get(System.IntPtr obj, System.IntPtr pd, out int year, out int month, out int day)
        {
            Eina.Log.Debug("function efl_ui_datepicker_date_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                year = default(int);        month = default(int);        day = default(int);                                    
                try
                {
                    ((Datepicker)wrapper).GetDate(out year, out month, out day);
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    
                try
                {
                    ((Datepicker)wrapper).SetDate(year, month, day);
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

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

