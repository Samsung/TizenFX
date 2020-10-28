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

/// <summary>Interface for autorepeating clicks.
/// This interface abstracts functions for enabling / disabling this feature. When enabled, keeping a button pressed will continuously emit the <c>repeated</c> event until the button is released. The time it takes until it starts emitting the event is given by <see cref="Efl.Ui.IAutorepeat.AutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.IAutorepeat.AutorepeatGapTimeout"/>.</summary>
[Efl.Ui.IAutorepeatConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IAutorepeat : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The initial timeout before the autorepeat event is generated.
/// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
/// 
/// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatEnabled"/> and <see cref="Efl.Ui.IAutorepeat.AutorepeatGapTimeout"/>.</summary>
/// <returns>Timeout in seconds.</returns>
double GetAutorepeatInitialTimeout();
    /// <summary>The initial timeout before the autorepeat event is generated.
/// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
/// 
/// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatEnabled"/> and <see cref="Efl.Ui.IAutorepeat.AutorepeatGapTimeout"/>.</summary>
/// <param name="t">Timeout in seconds.</param>
void SetAutorepeatInitialTimeout(double t);
    /// <summary>The interval between each generated autorepeat event.
/// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
/// 
/// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatInitialTimeout"/>.</summary>
/// <returns>Time interval in seconds.</returns>
double GetAutorepeatGapTimeout();
    /// <summary>The interval between each generated autorepeat event.
/// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
/// 
/// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatInitialTimeout"/>.</summary>
/// <param name="t">Time interval in seconds.</param>
void SetAutorepeatGapTimeout(double t);
    /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
/// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
/// <returns>A bool to turn on/off the repeat event generation.</returns>
bool GetAutorepeatEnabled();
    /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
/// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
/// <param name="on">A bool to turn on/off the repeat event generation.</param>
void SetAutorepeatEnabled(bool on);
                            /// <summary>Called when a repeated event is emitted</summary>
    event EventHandler RepeatedEvt;
    /// <summary>The initial timeout before the autorepeat event is generated.
    /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatEnabled"/> and <see cref="Efl.Ui.IAutorepeat.AutorepeatGapTimeout"/>.</summary>
    /// <value>Timeout in seconds.</value>
    double AutorepeatInitialTimeout {
        get;
        set;
    }
    /// <summary>The interval between each generated autorepeat event.
    /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatInitialTimeout"/>.</summary>
    /// <value>Time interval in seconds.</value>
    double AutorepeatGapTimeout {
        get;
        set;
    }
    /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
    /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
    /// <value>A bool to turn on/off the repeat event generation.</value>
    bool AutorepeatEnabled {
        get;
        set;
    }
}
/// <summary>Interface for autorepeating clicks.
/// This interface abstracts functions for enabling / disabling this feature. When enabled, keeping a button pressed will continuously emit the <c>repeated</c> event until the button is released. The time it takes until it starts emitting the event is given by <see cref="Efl.Ui.IAutorepeat.AutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.IAutorepeat.AutorepeatGapTimeout"/>.</summary>
sealed public  class IAutorepeatConcrete :
    Efl.Eo.EoWrapper
    , IAutorepeat
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IAutorepeatConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private IAutorepeatConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_ui_autorepeat_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IAutorepeat"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IAutorepeatConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Called when a repeated event is emitted</summary>
    public event EventHandler RepeatedEvt
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

                string key = "_EFL_UI_AUTOREPEAT_EVENT_REPEATED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_AUTOREPEAT_EVENT_REPEATED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event RepeatedEvt.</summary>
    public void OnRepeatedEvt(EventArgs e)
    {
        var key = "_EFL_UI_AUTOREPEAT_EVENT_REPEATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>The initial timeout before the autorepeat event is generated.
    /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatEnabled"/> and <see cref="Efl.Ui.IAutorepeat.AutorepeatGapTimeout"/>.</summary>
    /// <returns>Timeout in seconds.</returns>
    public double GetAutorepeatInitialTimeout() {
         var _ret_var = Efl.Ui.IAutorepeatConcrete.NativeMethods.efl_ui_autorepeat_initial_timeout_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The initial timeout before the autorepeat event is generated.
    /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatEnabled"/> and <see cref="Efl.Ui.IAutorepeat.AutorepeatGapTimeout"/>.</summary>
    /// <param name="t">Timeout in seconds.</param>
    public void SetAutorepeatInitialTimeout(double t) {
                                 Efl.Ui.IAutorepeatConcrete.NativeMethods.efl_ui_autorepeat_initial_timeout_set_ptr.Value.Delegate(this.NativeHandle,t);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The interval between each generated autorepeat event.
    /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatInitialTimeout"/>.</summary>
    /// <returns>Time interval in seconds.</returns>
    public double GetAutorepeatGapTimeout() {
         var _ret_var = Efl.Ui.IAutorepeatConcrete.NativeMethods.efl_ui_autorepeat_gap_timeout_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The interval between each generated autorepeat event.
    /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatInitialTimeout"/>.</summary>
    /// <param name="t">Time interval in seconds.</param>
    public void SetAutorepeatGapTimeout(double t) {
                                 Efl.Ui.IAutorepeatConcrete.NativeMethods.efl_ui_autorepeat_gap_timeout_set_ptr.Value.Delegate(this.NativeHandle,t);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
    /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
    /// <returns>A bool to turn on/off the repeat event generation.</returns>
    public bool GetAutorepeatEnabled() {
         var _ret_var = Efl.Ui.IAutorepeatConcrete.NativeMethods.efl_ui_autorepeat_enabled_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
    /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
    /// <param name="on">A bool to turn on/off the repeat event generation.</param>
    public void SetAutorepeatEnabled(bool on) {
                                 Efl.Ui.IAutorepeatConcrete.NativeMethods.efl_ui_autorepeat_enabled_set_ptr.Value.Delegate(this.NativeHandle,on);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The initial timeout before the autorepeat event is generated.
    /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatEnabled"/> and <see cref="Efl.Ui.IAutorepeat.AutorepeatGapTimeout"/>.</summary>
    /// <value>Timeout in seconds.</value>
    public double AutorepeatInitialTimeout {
        get { return GetAutorepeatInitialTimeout(); }
        set { SetAutorepeatInitialTimeout(value); }
    }
    /// <summary>The interval between each generated autorepeat event.
    /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.AutorepeatInitialTimeout"/>.</summary>
    /// <value>Time interval in seconds.</value>
    public double AutorepeatGapTimeout {
        get { return GetAutorepeatGapTimeout(); }
        set { SetAutorepeatGapTimeout(value); }
    }
    /// <summary>Turn on/off the autorepeat event generated when a button is kept pressed.
    /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> event when they are clicked.</summary>
    /// <value>A bool to turn on/off the repeat event generation.</value>
    public bool AutorepeatEnabled {
        get { return GetAutorepeatEnabled(); }
        set { SetAutorepeatEnabled(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IAutorepeatConcrete.efl_ui_autorepeat_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_autorepeat_initial_timeout_get_static_delegate == null)
            {
                efl_ui_autorepeat_initial_timeout_get_static_delegate = new efl_ui_autorepeat_initial_timeout_get_delegate(autorepeat_initial_timeout_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAutorepeatInitialTimeout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_initial_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_initial_timeout_get_static_delegate) });
            }

            if (efl_ui_autorepeat_initial_timeout_set_static_delegate == null)
            {
                efl_ui_autorepeat_initial_timeout_set_static_delegate = new efl_ui_autorepeat_initial_timeout_set_delegate(autorepeat_initial_timeout_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAutorepeatInitialTimeout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_initial_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_initial_timeout_set_static_delegate) });
            }

            if (efl_ui_autorepeat_gap_timeout_get_static_delegate == null)
            {
                efl_ui_autorepeat_gap_timeout_get_static_delegate = new efl_ui_autorepeat_gap_timeout_get_delegate(autorepeat_gap_timeout_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAutorepeatGapTimeout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_gap_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_gap_timeout_get_static_delegate) });
            }

            if (efl_ui_autorepeat_gap_timeout_set_static_delegate == null)
            {
                efl_ui_autorepeat_gap_timeout_set_static_delegate = new efl_ui_autorepeat_gap_timeout_set_delegate(autorepeat_gap_timeout_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAutorepeatGapTimeout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_gap_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_gap_timeout_set_static_delegate) });
            }

            if (efl_ui_autorepeat_enabled_get_static_delegate == null)
            {
                efl_ui_autorepeat_enabled_get_static_delegate = new efl_ui_autorepeat_enabled_get_delegate(autorepeat_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAutorepeatEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_enabled_get_static_delegate) });
            }

            if (efl_ui_autorepeat_enabled_set_static_delegate == null)
            {
                efl_ui_autorepeat_enabled_set_static_delegate = new efl_ui_autorepeat_enabled_set_delegate(autorepeat_enabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAutorepeatEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_autorepeat_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_enabled_set_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IAutorepeatConcrete.efl_ui_autorepeat_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate double efl_ui_autorepeat_initial_timeout_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_autorepeat_initial_timeout_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_get_api_delegate> efl_ui_autorepeat_initial_timeout_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_get_api_delegate>(Module, "efl_ui_autorepeat_initial_timeout_get");

        private static double autorepeat_initial_timeout_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_autorepeat_initial_timeout_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((IAutorepeat)ws.Target).GetAutorepeatInitialTimeout();
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
                return efl_ui_autorepeat_initial_timeout_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_autorepeat_initial_timeout_get_delegate efl_ui_autorepeat_initial_timeout_get_static_delegate;

        
        private delegate void efl_ui_autorepeat_initial_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,  double t);

        
        public delegate void efl_ui_autorepeat_initial_timeout_set_api_delegate(System.IntPtr obj,  double t);

        public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_set_api_delegate> efl_ui_autorepeat_initial_timeout_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_set_api_delegate>(Module, "efl_ui_autorepeat_initial_timeout_set");

        private static void autorepeat_initial_timeout_set(System.IntPtr obj, System.IntPtr pd, double t)
        {
            Eina.Log.Debug("function efl_ui_autorepeat_initial_timeout_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IAutorepeat)ws.Target).SetAutorepeatInitialTimeout(t);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_autorepeat_initial_timeout_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), t);
            }
        }

        private static efl_ui_autorepeat_initial_timeout_set_delegate efl_ui_autorepeat_initial_timeout_set_static_delegate;

        
        private delegate double efl_ui_autorepeat_gap_timeout_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_autorepeat_gap_timeout_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_get_api_delegate> efl_ui_autorepeat_gap_timeout_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_get_api_delegate>(Module, "efl_ui_autorepeat_gap_timeout_get");

        private static double autorepeat_gap_timeout_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_autorepeat_gap_timeout_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((IAutorepeat)ws.Target).GetAutorepeatGapTimeout();
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
                return efl_ui_autorepeat_gap_timeout_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_autorepeat_gap_timeout_get_delegate efl_ui_autorepeat_gap_timeout_get_static_delegate;

        
        private delegate void efl_ui_autorepeat_gap_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,  double t);

        
        public delegate void efl_ui_autorepeat_gap_timeout_set_api_delegate(System.IntPtr obj,  double t);

        public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_set_api_delegate> efl_ui_autorepeat_gap_timeout_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_set_api_delegate>(Module, "efl_ui_autorepeat_gap_timeout_set");

        private static void autorepeat_gap_timeout_set(System.IntPtr obj, System.IntPtr pd, double t)
        {
            Eina.Log.Debug("function efl_ui_autorepeat_gap_timeout_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IAutorepeat)ws.Target).SetAutorepeatGapTimeout(t);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_autorepeat_gap_timeout_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), t);
            }
        }

        private static efl_ui_autorepeat_gap_timeout_set_delegate efl_ui_autorepeat_gap_timeout_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_autorepeat_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_autorepeat_enabled_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_get_api_delegate> efl_ui_autorepeat_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_get_api_delegate>(Module, "efl_ui_autorepeat_enabled_get");

        private static bool autorepeat_enabled_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_autorepeat_enabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IAutorepeat)ws.Target).GetAutorepeatEnabled();
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
                return efl_ui_autorepeat_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_autorepeat_enabled_get_delegate efl_ui_autorepeat_enabled_get_static_delegate;

        
        private delegate void efl_ui_autorepeat_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool on);

        
        public delegate void efl_ui_autorepeat_enabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool on);

        public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_set_api_delegate> efl_ui_autorepeat_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_set_api_delegate>(Module, "efl_ui_autorepeat_enabled_set");

        private static void autorepeat_enabled_set(System.IntPtr obj, System.IntPtr pd, bool on)
        {
            Eina.Log.Debug("function efl_ui_autorepeat_enabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IAutorepeat)ws.Target).SetAutorepeatEnabled(on);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_autorepeat_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), on);
            }
        }

        private static efl_ui_autorepeat_enabled_set_delegate efl_ui_autorepeat_enabled_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiIAutorepeatConcrete_ExtensionMethods {
    public static Efl.BindableProperty<double> AutorepeatInitialTimeout<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IAutorepeat, T>magic = null) where T : Efl.Ui.IAutorepeat {
        return new Efl.BindableProperty<double>("autorepeat_initial_timeout", fac);
    }

    public static Efl.BindableProperty<double> AutorepeatGapTimeout<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IAutorepeat, T>magic = null) where T : Efl.Ui.IAutorepeat {
        return new Efl.BindableProperty<double>("autorepeat_gap_timeout", fac);
    }

    public static Efl.BindableProperty<bool> AutorepeatEnabled<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IAutorepeat, T>magic = null) where T : Efl.Ui.IAutorepeat {
        return new Efl.BindableProperty<bool>("autorepeat_enabled", fac);
    }

}
#pragma warning restore CS1591
#endif
