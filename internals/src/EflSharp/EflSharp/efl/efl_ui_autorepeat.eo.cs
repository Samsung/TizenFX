#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI autorepeat interface</summary>
[IAutorepeatNativeInherit]
public interface IAutorepeat : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The initial timeout before the autorepeat event is generated
/// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
/// 
/// See also <see cref="Efl.Ui.IAutorepeat.SetAutorepeatEnabled"/>, <see cref="Efl.Ui.IAutorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <returns>Timeout in seconds</returns>
double GetAutorepeatInitialTimeout();
    /// <summary>The initial timeout before the autorepeat event is generated
/// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
/// 
/// See also <see cref="Efl.Ui.IAutorepeat.SetAutorepeatEnabled"/>, <see cref="Efl.Ui.IAutorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <param name="t">Timeout in seconds</param>
/// <returns></returns>
void SetAutorepeatInitialTimeout( double t);
    /// <summary>The interval between each generated autorepeat event
/// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
/// 
/// See also <see cref="Efl.Ui.IAutorepeat.SetAutorepeatInitialTimeout"/>.</summary>
/// <returns>Interval in seconds</returns>
double GetAutorepeatGapTimeout();
    /// <summary>The interval between each generated autorepeat event
/// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
/// 
/// See also <see cref="Efl.Ui.IAutorepeat.SetAutorepeatInitialTimeout"/>.</summary>
/// <param name="t">Interval in seconds</param>
/// <returns></returns>
void SetAutorepeatGapTimeout( double t);
    /// <summary>Turn on/off the autorepeat event generated when the button is kept pressed
/// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> signal when they are clicked.
/// 
/// When on, keeping a button pressed will continuously emit a <c>repeated</c> signal until the button is released. The time it takes until it starts emitting the signal is given by <see cref="Efl.Ui.IAutorepeat.SetAutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.IAutorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <returns>A bool to turn on/off the event</returns>
bool GetAutorepeatEnabled();
    /// <summary>Turn on/off the autorepeat event generated when the button is kept pressed
/// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> signal when they are clicked.
/// 
/// When on, keeping a button pressed will continuously emit a <c>repeated</c> signal until the button is released. The time it takes until it starts emitting the signal is given by <see cref="Efl.Ui.IAutorepeat.SetAutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.IAutorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <param name="on">A bool to turn on/off the event</param>
/// <returns></returns>
void SetAutorepeatEnabled( bool on);
    /// <summary>Whether the button supports autorepeat.</summary>
/// <returns><c>true</c> if autorepeat is supported, <c>false</c> otherwise</returns>
bool GetAutorepeatSupported();
                                /// <summary>The initial timeout before the autorepeat event is generated
/// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
/// 
/// See also <see cref="Efl.Ui.IAutorepeat.SetAutorepeatEnabled"/>, <see cref="Efl.Ui.IAutorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <value>Timeout in seconds</value>
    double AutorepeatInitialTimeout {
        get ;
        set ;
    }
    /// <summary>The interval between each generated autorepeat event
/// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
/// 
/// See also <see cref="Efl.Ui.IAutorepeat.SetAutorepeatInitialTimeout"/>.</summary>
/// <value>Interval in seconds</value>
    double AutorepeatGapTimeout {
        get ;
        set ;
    }
    /// <summary>Turn on/off the autorepeat event generated when the button is kept pressed
/// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> signal when they are clicked.
/// 
/// When on, keeping a button pressed will continuously emit a <c>repeated</c> signal until the button is released. The time it takes until it starts emitting the signal is given by <see cref="Efl.Ui.IAutorepeat.SetAutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.IAutorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <value>A bool to turn on/off the event</value>
    bool AutorepeatEnabled {
        get ;
        set ;
    }
    /// <summary>Whether the button supports autorepeat.</summary>
/// <value><c>true</c> if autorepeat is supported, <c>false</c> otherwise</value>
    bool AutorepeatSupported {
        get ;
    }
}
/// <summary>Efl UI autorepeat interface</summary>
sealed public class IAutorepeatConcrete : 

IAutorepeat
    
{
    ///<summary>Pointer to the native class description.</summary>
    public System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (IAutorepeatConcrete))
                return Efl.Ui.IAutorepeatNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    private  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle {
        get { return handle; }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
        efl_ui_autorepeat_interface_get();
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    private IAutorepeatConcrete(System.IntPtr raw)
    {
        handle = raw;
        RegisterEventProxies();
    }
    ///<summary>Destructor.</summary>
    ~IAutorepeatConcrete()
    {
        Dispose(false);
    }
    ///<summary>Releases the underlying native instance.</summary>
    void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero) {
            Efl.Eo.Globals.efl_unref(handle);
            handle = System.IntPtr.Zero;
        }
    }
    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    ///<summary>Verifies if the given object is equal to this one.</summary>
    public override bool Equals(object obj)
    {
        var other = obj as Efl.Object;
        if (other == null)
            return false;
        return this.NativeHandle == other.NativeHandle;
    }
    ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }
    ///<summary>Turns the native pointer into a string representation.</summary>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }
    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
     void RegisterEventProxies()
    {
    }
    /// <summary>The initial timeout before the autorepeat event is generated
    /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.SetAutorepeatEnabled"/>, <see cref="Efl.Ui.IAutorepeat.SetAutorepeatGapTimeout"/>.</summary>
    /// <returns>Timeout in seconds</returns>
    public double GetAutorepeatInitialTimeout() {
         var _ret_var = Efl.Ui.IAutorepeatNativeInherit.efl_ui_autorepeat_initial_timeout_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The initial timeout before the autorepeat event is generated
    /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.SetAutorepeatEnabled"/>, <see cref="Efl.Ui.IAutorepeat.SetAutorepeatGapTimeout"/>.</summary>
    /// <param name="t">Timeout in seconds</param>
    /// <returns></returns>
    public void SetAutorepeatInitialTimeout( double t) {
                                 Efl.Ui.IAutorepeatNativeInherit.efl_ui_autorepeat_initial_timeout_set_ptr.Value.Delegate(this.NativeHandle, t);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The interval between each generated autorepeat event
    /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.SetAutorepeatInitialTimeout"/>.</summary>
    /// <returns>Interval in seconds</returns>
    public double GetAutorepeatGapTimeout() {
         var _ret_var = Efl.Ui.IAutorepeatNativeInherit.efl_ui_autorepeat_gap_timeout_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The interval between each generated autorepeat event
    /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
    /// 
    /// See also <see cref="Efl.Ui.IAutorepeat.SetAutorepeatInitialTimeout"/>.</summary>
    /// <param name="t">Interval in seconds</param>
    /// <returns></returns>
    public void SetAutorepeatGapTimeout( double t) {
                                 Efl.Ui.IAutorepeatNativeInherit.efl_ui_autorepeat_gap_timeout_set_ptr.Value.Delegate(this.NativeHandle, t);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Turn on/off the autorepeat event generated when the button is kept pressed
    /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> signal when they are clicked.
    /// 
    /// When on, keeping a button pressed will continuously emit a <c>repeated</c> signal until the button is released. The time it takes until it starts emitting the signal is given by <see cref="Efl.Ui.IAutorepeat.SetAutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.IAutorepeat.SetAutorepeatGapTimeout"/>.</summary>
    /// <returns>A bool to turn on/off the event</returns>
    public bool GetAutorepeatEnabled() {
         var _ret_var = Efl.Ui.IAutorepeatNativeInherit.efl_ui_autorepeat_enabled_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Turn on/off the autorepeat event generated when the button is kept pressed
    /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> signal when they are clicked.
    /// 
    /// When on, keeping a button pressed will continuously emit a <c>repeated</c> signal until the button is released. The time it takes until it starts emitting the signal is given by <see cref="Efl.Ui.IAutorepeat.SetAutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.IAutorepeat.SetAutorepeatGapTimeout"/>.</summary>
    /// <param name="on">A bool to turn on/off the event</param>
    /// <returns></returns>
    public void SetAutorepeatEnabled( bool on) {
                                 Efl.Ui.IAutorepeatNativeInherit.efl_ui_autorepeat_enabled_set_ptr.Value.Delegate(this.NativeHandle, on);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether the button supports autorepeat.</summary>
    /// <returns><c>true</c> if autorepeat is supported, <c>false</c> otherwise</returns>
    public bool GetAutorepeatSupported() {
         var _ret_var = Efl.Ui.IAutorepeatNativeInherit.efl_ui_autorepeat_supported_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The initial timeout before the autorepeat event is generated
/// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
/// 
/// See also <see cref="Efl.Ui.IAutorepeat.SetAutorepeatEnabled"/>, <see cref="Efl.Ui.IAutorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <value>Timeout in seconds</value>
    public double AutorepeatInitialTimeout {
        get { return GetAutorepeatInitialTimeout(); }
        set { SetAutorepeatInitialTimeout( value); }
    }
    /// <summary>The interval between each generated autorepeat event
/// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
/// 
/// See also <see cref="Efl.Ui.IAutorepeat.SetAutorepeatInitialTimeout"/>.</summary>
/// <value>Interval in seconds</value>
    public double AutorepeatGapTimeout {
        get { return GetAutorepeatGapTimeout(); }
        set { SetAutorepeatGapTimeout( value); }
    }
    /// <summary>Turn on/off the autorepeat event generated when the button is kept pressed
/// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> signal when they are clicked.
/// 
/// When on, keeping a button pressed will continuously emit a <c>repeated</c> signal until the button is released. The time it takes until it starts emitting the signal is given by <see cref="Efl.Ui.IAutorepeat.SetAutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.IAutorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <value>A bool to turn on/off the event</value>
    public bool AutorepeatEnabled {
        get { return GetAutorepeatEnabled(); }
        set { SetAutorepeatEnabled( value); }
    }
    /// <summary>Whether the button supports autorepeat.</summary>
/// <value><c>true</c> if autorepeat is supported, <c>false</c> otherwise</value>
    public bool AutorepeatSupported {
        get { return GetAutorepeatSupported(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IAutorepeatConcrete.efl_ui_autorepeat_interface_get();
    }
}
public class IAutorepeatNativeInherit  : Efl.Eo.NativeClass{
    public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_autorepeat_initial_timeout_get_static_delegate == null)
            efl_ui_autorepeat_initial_timeout_get_static_delegate = new efl_ui_autorepeat_initial_timeout_get_delegate(autorepeat_initial_timeout_get);
        if (methods.FirstOrDefault(m => m.Name == "GetAutorepeatInitialTimeout") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_initial_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_initial_timeout_get_static_delegate)});
        if (efl_ui_autorepeat_initial_timeout_set_static_delegate == null)
            efl_ui_autorepeat_initial_timeout_set_static_delegate = new efl_ui_autorepeat_initial_timeout_set_delegate(autorepeat_initial_timeout_set);
        if (methods.FirstOrDefault(m => m.Name == "SetAutorepeatInitialTimeout") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_initial_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_initial_timeout_set_static_delegate)});
        if (efl_ui_autorepeat_gap_timeout_get_static_delegate == null)
            efl_ui_autorepeat_gap_timeout_get_static_delegate = new efl_ui_autorepeat_gap_timeout_get_delegate(autorepeat_gap_timeout_get);
        if (methods.FirstOrDefault(m => m.Name == "GetAutorepeatGapTimeout") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_gap_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_gap_timeout_get_static_delegate)});
        if (efl_ui_autorepeat_gap_timeout_set_static_delegate == null)
            efl_ui_autorepeat_gap_timeout_set_static_delegate = new efl_ui_autorepeat_gap_timeout_set_delegate(autorepeat_gap_timeout_set);
        if (methods.FirstOrDefault(m => m.Name == "SetAutorepeatGapTimeout") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_gap_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_gap_timeout_set_static_delegate)});
        if (efl_ui_autorepeat_enabled_get_static_delegate == null)
            efl_ui_autorepeat_enabled_get_static_delegate = new efl_ui_autorepeat_enabled_get_delegate(autorepeat_enabled_get);
        if (methods.FirstOrDefault(m => m.Name == "GetAutorepeatEnabled") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_enabled_get_static_delegate)});
        if (efl_ui_autorepeat_enabled_set_static_delegate == null)
            efl_ui_autorepeat_enabled_set_static_delegate = new efl_ui_autorepeat_enabled_set_delegate(autorepeat_enabled_set);
        if (methods.FirstOrDefault(m => m.Name == "SetAutorepeatEnabled") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_enabled_set_static_delegate)});
        if (efl_ui_autorepeat_supported_get_static_delegate == null)
            efl_ui_autorepeat_supported_get_static_delegate = new efl_ui_autorepeat_supported_get_delegate(autorepeat_supported_get);
        if (methods.FirstOrDefault(m => m.Name == "GetAutorepeatSupported") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_supported_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_supported_get_static_delegate)});
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.IAutorepeatConcrete.efl_ui_autorepeat_interface_get();
    }
    public static  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.IAutorepeatConcrete.efl_ui_autorepeat_interface_get();
    }


     private delegate double efl_ui_autorepeat_initial_timeout_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_ui_autorepeat_initial_timeout_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_get_api_delegate> efl_ui_autorepeat_initial_timeout_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_get_api_delegate>(_Module, "efl_ui_autorepeat_initial_timeout_get");
     private static double autorepeat_initial_timeout_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_autorepeat_initial_timeout_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((IAutorepeat)wrapper).GetAutorepeatInitialTimeout();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_autorepeat_initial_timeout_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_autorepeat_initial_timeout_get_delegate efl_ui_autorepeat_initial_timeout_get_static_delegate;


     private delegate void efl_ui_autorepeat_initial_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,   double t);


     public delegate void efl_ui_autorepeat_initial_timeout_set_api_delegate(System.IntPtr obj,   double t);
     public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_set_api_delegate> efl_ui_autorepeat_initial_timeout_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_set_api_delegate>(_Module, "efl_ui_autorepeat_initial_timeout_set");
     private static void autorepeat_initial_timeout_set(System.IntPtr obj, System.IntPtr pd,  double t)
    {
        Eina.Log.Debug("function efl_ui_autorepeat_initial_timeout_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IAutorepeat)wrapper).SetAutorepeatInitialTimeout( t);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_autorepeat_initial_timeout_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  t);
        }
    }
    private static efl_ui_autorepeat_initial_timeout_set_delegate efl_ui_autorepeat_initial_timeout_set_static_delegate;


     private delegate double efl_ui_autorepeat_gap_timeout_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_ui_autorepeat_gap_timeout_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_get_api_delegate> efl_ui_autorepeat_gap_timeout_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_get_api_delegate>(_Module, "efl_ui_autorepeat_gap_timeout_get");
     private static double autorepeat_gap_timeout_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_autorepeat_gap_timeout_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((IAutorepeat)wrapper).GetAutorepeatGapTimeout();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_autorepeat_gap_timeout_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_autorepeat_gap_timeout_get_delegate efl_ui_autorepeat_gap_timeout_get_static_delegate;


     private delegate void efl_ui_autorepeat_gap_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,   double t);


     public delegate void efl_ui_autorepeat_gap_timeout_set_api_delegate(System.IntPtr obj,   double t);
     public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_set_api_delegate> efl_ui_autorepeat_gap_timeout_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_set_api_delegate>(_Module, "efl_ui_autorepeat_gap_timeout_set");
     private static void autorepeat_gap_timeout_set(System.IntPtr obj, System.IntPtr pd,  double t)
    {
        Eina.Log.Debug("function efl_ui_autorepeat_gap_timeout_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IAutorepeat)wrapper).SetAutorepeatGapTimeout( t);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_autorepeat_gap_timeout_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  t);
        }
    }
    private static efl_ui_autorepeat_gap_timeout_set_delegate efl_ui_autorepeat_gap_timeout_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_autorepeat_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_autorepeat_enabled_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_get_api_delegate> efl_ui_autorepeat_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_get_api_delegate>(_Module, "efl_ui_autorepeat_enabled_get");
     private static bool autorepeat_enabled_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_autorepeat_enabled_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IAutorepeat)wrapper).GetAutorepeatEnabled();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_autorepeat_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_autorepeat_enabled_get_delegate efl_ui_autorepeat_enabled_get_static_delegate;


     private delegate void efl_ui_autorepeat_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool on);


     public delegate void efl_ui_autorepeat_enabled_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool on);
     public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_set_api_delegate> efl_ui_autorepeat_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_set_api_delegate>(_Module, "efl_ui_autorepeat_enabled_set");
     private static void autorepeat_enabled_set(System.IntPtr obj, System.IntPtr pd,  bool on)
    {
        Eina.Log.Debug("function efl_ui_autorepeat_enabled_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((IAutorepeat)wrapper).SetAutorepeatEnabled( on);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_autorepeat_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  on);
        }
    }
    private static efl_ui_autorepeat_enabled_set_delegate efl_ui_autorepeat_enabled_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_autorepeat_supported_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_autorepeat_supported_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_supported_get_api_delegate> efl_ui_autorepeat_supported_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_supported_get_api_delegate>(_Module, "efl_ui_autorepeat_supported_get");
     private static bool autorepeat_supported_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_autorepeat_supported_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((IAutorepeat)wrapper).GetAutorepeatSupported();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_autorepeat_supported_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_autorepeat_supported_get_delegate efl_ui_autorepeat_supported_get_static_delegate;
}
} } 
