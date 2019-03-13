#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI autorepeat interface</summary>
[AutorepeatNativeInherit]
public interface Autorepeat : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>The initial timeout before the autorepeat event is generated
/// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
/// 
/// See also <see cref="Efl.Ui.Autorepeat.SetAutorepeatEnabled"/>, <see cref="Efl.Ui.Autorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <returns>Timeout in seconds</returns>
double GetAutorepeatInitialTimeout();
   /// <summary>The initial timeout before the autorepeat event is generated
/// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
/// 
/// See also <see cref="Efl.Ui.Autorepeat.SetAutorepeatEnabled"/>, <see cref="Efl.Ui.Autorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <param name="t">Timeout in seconds</param>
/// <returns></returns>
 void SetAutorepeatInitialTimeout( double t);
   /// <summary>The interval between each generated autorepeat event
/// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
/// 
/// See also <see cref="Efl.Ui.Autorepeat.SetAutorepeatInitialTimeout"/>.</summary>
/// <returns>Interval in seconds</returns>
double GetAutorepeatGapTimeout();
   /// <summary>The interval between each generated autorepeat event
/// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
/// 
/// See also <see cref="Efl.Ui.Autorepeat.SetAutorepeatInitialTimeout"/>.</summary>
/// <param name="t">Interval in seconds</param>
/// <returns></returns>
 void SetAutorepeatGapTimeout( double t);
   /// <summary>Turn on/off the autorepeat event generated when the button is kept pressed
/// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> signal when they are clicked.
/// 
/// When on, keeping a button pressed will continuously emit a <c>repeated</c> signal until the button is released. The time it takes until it starts emitting the signal is given by <see cref="Efl.Ui.Autorepeat.SetAutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.Autorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <returns>A bool to turn on/off the event</returns>
bool GetAutorepeatEnabled();
   /// <summary>Turn on/off the autorepeat event generated when the button is kept pressed
/// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> signal when they are clicked.
/// 
/// When on, keeping a button pressed will continuously emit a <c>repeated</c> signal until the button is released. The time it takes until it starts emitting the signal is given by <see cref="Efl.Ui.Autorepeat.SetAutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.Autorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <param name="on">A bool to turn on/off the event</param>
/// <returns></returns>
 void SetAutorepeatEnabled( bool on);
   /// <summary>Whether the button supports autorepeat.</summary>
/// <returns><c>true</c> if autorepeat is supported, <c>false</c> otherwise</returns>
bool GetAutorepeatSupported();
                        /// <summary>The initial timeout before the autorepeat event is generated
/// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
/// 
/// See also <see cref="Efl.Ui.Autorepeat.SetAutorepeatEnabled"/>, <see cref="Efl.Ui.Autorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <value>Timeout in seconds</value>
   double AutorepeatInitialTimeout {
      get ;
      set ;
   }
   /// <summary>The interval between each generated autorepeat event
/// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
/// 
/// See also <see cref="Efl.Ui.Autorepeat.SetAutorepeatInitialTimeout"/>.</summary>
/// <value>Interval in seconds</value>
   double AutorepeatGapTimeout {
      get ;
      set ;
   }
   /// <summary>Turn on/off the autorepeat event generated when the button is kept pressed
/// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> signal when they are clicked.
/// 
/// When on, keeping a button pressed will continuously emit a <c>repeated</c> signal until the button is released. The time it takes until it starts emitting the signal is given by <see cref="Efl.Ui.Autorepeat.SetAutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.Autorepeat.SetAutorepeatGapTimeout"/>.</summary>
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
sealed public class AutorepeatConcrete : 

Autorepeat
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (AutorepeatConcrete))
            return Efl.Ui.AutorepeatNativeInherit.GetEflClassStatic();
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
   public AutorepeatConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~AutorepeatConcrete()
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
   ///<summary>Casts obj into an instance of this type.</summary>
   public static AutorepeatConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new AutorepeatConcrete(obj.NativeHandle);
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
    void register_event_proxies()
   {
   }
   /// <summary>The initial timeout before the autorepeat event is generated
   /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
   /// 
   /// See also <see cref="Efl.Ui.Autorepeat.SetAutorepeatEnabled"/>, <see cref="Efl.Ui.Autorepeat.SetAutorepeatGapTimeout"/>.</summary>
   /// <returns>Timeout in seconds</returns>
   public double GetAutorepeatInitialTimeout() {
       var _ret_var = Efl.Ui.AutorepeatNativeInherit.efl_ui_autorepeat_initial_timeout_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The initial timeout before the autorepeat event is generated
   /// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
   /// 
   /// See also <see cref="Efl.Ui.Autorepeat.SetAutorepeatEnabled"/>, <see cref="Efl.Ui.Autorepeat.SetAutorepeatGapTimeout"/>.</summary>
   /// <param name="t">Timeout in seconds</param>
   /// <returns></returns>
   public  void SetAutorepeatInitialTimeout( double t) {
                         Efl.Ui.AutorepeatNativeInherit.efl_ui_autorepeat_initial_timeout_set_ptr.Value.Delegate(this.NativeHandle, t);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The interval between each generated autorepeat event
   /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
   /// 
   /// See also <see cref="Efl.Ui.Autorepeat.SetAutorepeatInitialTimeout"/>.</summary>
   /// <returns>Interval in seconds</returns>
   public double GetAutorepeatGapTimeout() {
       var _ret_var = Efl.Ui.AutorepeatNativeInherit.efl_ui_autorepeat_gap_timeout_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The interval between each generated autorepeat event
   /// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
   /// 
   /// See also <see cref="Efl.Ui.Autorepeat.SetAutorepeatInitialTimeout"/>.</summary>
   /// <param name="t">Interval in seconds</param>
   /// <returns></returns>
   public  void SetAutorepeatGapTimeout( double t) {
                         Efl.Ui.AutorepeatNativeInherit.efl_ui_autorepeat_gap_timeout_set_ptr.Value.Delegate(this.NativeHandle, t);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Turn on/off the autorepeat event generated when the button is kept pressed
   /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> signal when they are clicked.
   /// 
   /// When on, keeping a button pressed will continuously emit a <c>repeated</c> signal until the button is released. The time it takes until it starts emitting the signal is given by <see cref="Efl.Ui.Autorepeat.SetAutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.Autorepeat.SetAutorepeatGapTimeout"/>.</summary>
   /// <returns>A bool to turn on/off the event</returns>
   public bool GetAutorepeatEnabled() {
       var _ret_var = Efl.Ui.AutorepeatNativeInherit.efl_ui_autorepeat_enabled_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Turn on/off the autorepeat event generated when the button is kept pressed
   /// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> signal when they are clicked.
   /// 
   /// When on, keeping a button pressed will continuously emit a <c>repeated</c> signal until the button is released. The time it takes until it starts emitting the signal is given by <see cref="Efl.Ui.Autorepeat.SetAutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.Autorepeat.SetAutorepeatGapTimeout"/>.</summary>
   /// <param name="on">A bool to turn on/off the event</param>
   /// <returns></returns>
   public  void SetAutorepeatEnabled( bool on) {
                         Efl.Ui.AutorepeatNativeInherit.efl_ui_autorepeat_enabled_set_ptr.Value.Delegate(this.NativeHandle, on);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Whether the button supports autorepeat.</summary>
   /// <returns><c>true</c> if autorepeat is supported, <c>false</c> otherwise</returns>
   public bool GetAutorepeatSupported() {
       var _ret_var = Efl.Ui.AutorepeatNativeInherit.efl_ui_autorepeat_supported_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The initial timeout before the autorepeat event is generated
/// Sets the timeout, in seconds, since the button is pressed until the first <c>repeated</c> signal is emitted. If <c>t</c> is 0.0 or less, there won&apos;t be any delay and the event will be fired the moment the button is pressed.
/// 
/// See also <see cref="Efl.Ui.Autorepeat.SetAutorepeatEnabled"/>, <see cref="Efl.Ui.Autorepeat.SetAutorepeatGapTimeout"/>.</summary>
/// <value>Timeout in seconds</value>
   public double AutorepeatInitialTimeout {
      get { return GetAutorepeatInitialTimeout(); }
      set { SetAutorepeatInitialTimeout( value); }
   }
   /// <summary>The interval between each generated autorepeat event
/// After the first <c>repeated</c> event is fired, all subsequent ones will follow after a delay of <c>t</c> seconds for each.
/// 
/// See also <see cref="Efl.Ui.Autorepeat.SetAutorepeatInitialTimeout"/>.</summary>
/// <value>Interval in seconds</value>
   public double AutorepeatGapTimeout {
      get { return GetAutorepeatGapTimeout(); }
      set { SetAutorepeatGapTimeout( value); }
   }
   /// <summary>Turn on/off the autorepeat event generated when the button is kept pressed
/// When off, no autorepeat is performed and buttons emit a normal <c>clicked</c> signal when they are clicked.
/// 
/// When on, keeping a button pressed will continuously emit a <c>repeated</c> signal until the button is released. The time it takes until it starts emitting the signal is given by <see cref="Efl.Ui.Autorepeat.SetAutorepeatInitialTimeout"/>, and the time between each new emission by <see cref="Efl.Ui.Autorepeat.SetAutorepeatGapTimeout"/>.</summary>
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
}
public class AutorepeatNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_autorepeat_initial_timeout_get_static_delegate == null)
      efl_ui_autorepeat_initial_timeout_get_static_delegate = new efl_ui_autorepeat_initial_timeout_get_delegate(autorepeat_initial_timeout_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_initial_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_initial_timeout_get_static_delegate)});
      if (efl_ui_autorepeat_initial_timeout_set_static_delegate == null)
      efl_ui_autorepeat_initial_timeout_set_static_delegate = new efl_ui_autorepeat_initial_timeout_set_delegate(autorepeat_initial_timeout_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_initial_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_initial_timeout_set_static_delegate)});
      if (efl_ui_autorepeat_gap_timeout_get_static_delegate == null)
      efl_ui_autorepeat_gap_timeout_get_static_delegate = new efl_ui_autorepeat_gap_timeout_get_delegate(autorepeat_gap_timeout_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_gap_timeout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_gap_timeout_get_static_delegate)});
      if (efl_ui_autorepeat_gap_timeout_set_static_delegate == null)
      efl_ui_autorepeat_gap_timeout_set_static_delegate = new efl_ui_autorepeat_gap_timeout_set_delegate(autorepeat_gap_timeout_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_gap_timeout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_gap_timeout_set_static_delegate)});
      if (efl_ui_autorepeat_enabled_get_static_delegate == null)
      efl_ui_autorepeat_enabled_get_static_delegate = new efl_ui_autorepeat_enabled_get_delegate(autorepeat_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_enabled_get_static_delegate)});
      if (efl_ui_autorepeat_enabled_set_static_delegate == null)
      efl_ui_autorepeat_enabled_set_static_delegate = new efl_ui_autorepeat_enabled_set_delegate(autorepeat_enabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_enabled_set_static_delegate)});
      if (efl_ui_autorepeat_supported_get_static_delegate == null)
      efl_ui_autorepeat_supported_get_static_delegate = new efl_ui_autorepeat_supported_get_delegate(autorepeat_supported_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_autorepeat_supported_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_autorepeat_supported_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.AutorepeatConcrete.efl_ui_autorepeat_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.AutorepeatConcrete.efl_ui_autorepeat_interface_get();
   }


    private delegate double efl_ui_autorepeat_initial_timeout_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_ui_autorepeat_initial_timeout_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_get_api_delegate> efl_ui_autorepeat_initial_timeout_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_get_api_delegate>(_Module, "efl_ui_autorepeat_initial_timeout_get");
    private static double autorepeat_initial_timeout_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_autorepeat_initial_timeout_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Autorepeat)wrapper).GetAutorepeatInitialTimeout();
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


    private delegate  void efl_ui_autorepeat_initial_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,   double t);


    public delegate  void efl_ui_autorepeat_initial_timeout_set_api_delegate(System.IntPtr obj,   double t);
    public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_set_api_delegate> efl_ui_autorepeat_initial_timeout_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_initial_timeout_set_api_delegate>(_Module, "efl_ui_autorepeat_initial_timeout_set");
    private static  void autorepeat_initial_timeout_set(System.IntPtr obj, System.IntPtr pd,  double t)
   {
      Eina.Log.Debug("function efl_ui_autorepeat_initial_timeout_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Autorepeat)wrapper).SetAutorepeatInitialTimeout( t);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Autorepeat)wrapper).GetAutorepeatGapTimeout();
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


    private delegate  void efl_ui_autorepeat_gap_timeout_set_delegate(System.IntPtr obj, System.IntPtr pd,   double t);


    public delegate  void efl_ui_autorepeat_gap_timeout_set_api_delegate(System.IntPtr obj,   double t);
    public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_set_api_delegate> efl_ui_autorepeat_gap_timeout_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_gap_timeout_set_api_delegate>(_Module, "efl_ui_autorepeat_gap_timeout_set");
    private static  void autorepeat_gap_timeout_set(System.IntPtr obj, System.IntPtr pd,  double t)
   {
      Eina.Log.Debug("function efl_ui_autorepeat_gap_timeout_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Autorepeat)wrapper).SetAutorepeatGapTimeout( t);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Autorepeat)wrapper).GetAutorepeatEnabled();
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


    private delegate  void efl_ui_autorepeat_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool on);


    public delegate  void efl_ui_autorepeat_enabled_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool on);
    public static Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_set_api_delegate> efl_ui_autorepeat_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_autorepeat_enabled_set_api_delegate>(_Module, "efl_ui_autorepeat_enabled_set");
    private static  void autorepeat_enabled_set(System.IntPtr obj, System.IntPtr pd,  bool on)
   {
      Eina.Log.Debug("function efl_ui_autorepeat_enabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Autorepeat)wrapper).SetAutorepeatEnabled( on);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Autorepeat)wrapper).GetAutorepeatSupported();
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
