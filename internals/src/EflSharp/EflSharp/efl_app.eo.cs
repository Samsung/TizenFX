#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Object representing the application itself</summary>
[AppNativeInherit]
public class App : Efl.Loop, Efl.Eo.IWrapper,Efl.Core.CommandLine
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.AppNativeInherit nativeInherit = new Efl.AppNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (App))
            return Efl.AppNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_app_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public App(Efl.Object parent= null
         ) :
      base(efl_app_class_get(), typeof(App), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public App(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected App(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static App static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new App(obj.NativeHandle);
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
private static object PauseEvtKey = new object();
   /// <summary>Called when the application is not going be displayed or otherwise used by a user for some time</summary>
   public event EventHandler PauseEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_PAUSE";
            if (add_cpp_event_handler(efl.Libs.Ecore, key, this.evt_PauseEvt_delegate)) {
               eventHandlers.AddHandler(PauseEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_PAUSE";
            if (remove_cpp_event_handler(key, this.evt_PauseEvt_delegate)) { 
               eventHandlers.RemoveHandler(PauseEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PauseEvt.</summary>
   public void On_PauseEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[PauseEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PauseEvt_delegate;
   private void on_PauseEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_PauseEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ResumeEvtKey = new object();
   /// <summary>Called before a window is rendered after a pause event</summary>
   public event EventHandler ResumeEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_RESUME";
            if (add_cpp_event_handler(efl.Libs.Ecore, key, this.evt_ResumeEvt_delegate)) {
               eventHandlers.AddHandler(ResumeEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_RESUME";
            if (remove_cpp_event_handler(key, this.evt_ResumeEvt_delegate)) { 
               eventHandlers.RemoveHandler(ResumeEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ResumeEvt.</summary>
   public void On_ResumeEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ResumeEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ResumeEvt_delegate;
   private void on_ResumeEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ResumeEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object StandbyEvtKey = new object();
   /// <summary>Called when the application&apos;s windows are all destroyed</summary>
   public event EventHandler StandbyEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_STANDBY";
            if (add_cpp_event_handler(efl.Libs.Ecore, key, this.evt_StandbyEvt_delegate)) {
               eventHandlers.AddHandler(StandbyEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_STANDBY";
            if (remove_cpp_event_handler(key, this.evt_StandbyEvt_delegate)) { 
               eventHandlers.RemoveHandler(StandbyEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event StandbyEvt.</summary>
   public void On_StandbyEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[StandbyEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_StandbyEvt_delegate;
   private void on_StandbyEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_StandbyEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object TerminateEvtKey = new object();
   /// <summary>Called before starting the shutdown of the application</summary>
   public event EventHandler TerminateEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_TERMINATE";
            if (add_cpp_event_handler(efl.Libs.Ecore, key, this.evt_TerminateEvt_delegate)) {
               eventHandlers.AddHandler(TerminateEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_TERMINATE";
            if (remove_cpp_event_handler(key, this.evt_TerminateEvt_delegate)) { 
               eventHandlers.RemoveHandler(TerminateEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event TerminateEvt.</summary>
   public void On_TerminateEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[TerminateEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_TerminateEvt_delegate;
   private void on_TerminateEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_TerminateEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SignalUsr1EvtKey = new object();
   /// <summary>System specific, but on unix maps to SIGUSR1 signal to the process - only called on main loop object</summary>
   public event EventHandler SignalUsr1Evt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_SIGNAL_USR1";
            if (add_cpp_event_handler(efl.Libs.Ecore, key, this.evt_SignalUsr1Evt_delegate)) {
               eventHandlers.AddHandler(SignalUsr1EvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_SIGNAL_USR1";
            if (remove_cpp_event_handler(key, this.evt_SignalUsr1Evt_delegate)) { 
               eventHandlers.RemoveHandler(SignalUsr1EvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SignalUsr1Evt.</summary>
   public void On_SignalUsr1Evt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SignalUsr1EvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SignalUsr1Evt_delegate;
   private void on_SignalUsr1Evt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SignalUsr1Evt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SignalUsr2EvtKey = new object();
   /// <summary>System specific, but on unix maps to SIGUSR2 signal to the process - only called on main loop object</summary>
   public event EventHandler SignalUsr2Evt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_SIGNAL_USR2";
            if (add_cpp_event_handler(efl.Libs.Ecore, key, this.evt_SignalUsr2Evt_delegate)) {
               eventHandlers.AddHandler(SignalUsr2EvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_SIGNAL_USR2";
            if (remove_cpp_event_handler(key, this.evt_SignalUsr2Evt_delegate)) { 
               eventHandlers.RemoveHandler(SignalUsr2EvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SignalUsr2Evt.</summary>
   public void On_SignalUsr2Evt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SignalUsr2EvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SignalUsr2Evt_delegate;
   private void on_SignalUsr2Evt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SignalUsr2Evt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SignalHupEvtKey = new object();
   /// <summary>System specific, but on unix maps to SIGHUP signal to the process - only called on main loop object</summary>
   public event EventHandler SignalHupEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_SIGNAL_HUP";
            if (add_cpp_event_handler(efl.Libs.Ecore, key, this.evt_SignalHupEvt_delegate)) {
               eventHandlers.AddHandler(SignalHupEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_APP_EVENT_SIGNAL_HUP";
            if (remove_cpp_event_handler(key, this.evt_SignalHupEvt_delegate)) { 
               eventHandlers.RemoveHandler(SignalHupEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SignalHupEvt.</summary>
   public void On_SignalHupEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SignalHupEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SignalHupEvt_delegate;
   private void on_SignalHupEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SignalHupEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_PauseEvt_delegate = new Efl.EventCb(on_PauseEvt_NativeCallback);
      evt_ResumeEvt_delegate = new Efl.EventCb(on_ResumeEvt_NativeCallback);
      evt_StandbyEvt_delegate = new Efl.EventCb(on_StandbyEvt_NativeCallback);
      evt_TerminateEvt_delegate = new Efl.EventCb(on_TerminateEvt_NativeCallback);
      evt_SignalUsr1Evt_delegate = new Efl.EventCb(on_SignalUsr1Evt_NativeCallback);
      evt_SignalUsr2Evt_delegate = new Efl.EventCb(on_SignalUsr2Evt_NativeCallback);
      evt_SignalHupEvt_delegate = new Efl.EventCb(on_SignalHupEvt_NativeCallback);
   }
   /// <summary>Returns the app object that is representing this process
   /// Note: This function call only works in the main loop thread of the process.</summary>
   /// <returns>Application for this process</returns>
   public static Efl.App GetAppMain() {
       var _ret_var = Efl.AppNativeInherit.efl_app_main_get_ptr.Value.Delegate();
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Indicates the version of EFL with which this application was compiled against/for.
   /// This might differ from <see cref="Efl.App.GetEflVersion"/>.</summary>
   /// <returns>Efl build version</returns>
   virtual public Efl.Version GetBuildEflVersion() {
       var _ret_var = Efl.AppNativeInherit.efl_app_build_efl_version_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Version>(_ret_var);
      
      return __ret_tmp;
 }
   /// <summary>Indicates the currently running version of EFL.
   /// This might differ from <see cref="Efl.App.GetBuildEflVersion"/>.</summary>
   /// <returns>Efl version</returns>
   virtual public Efl.Version GetEflVersion() {
       var _ret_var = Efl.AppNativeInherit.efl_app_efl_version_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Version>(_ret_var);
      
      return __ret_tmp;
 }
   /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
   /// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
   /// 
   /// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
   /// 
   /// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
   /// 
   /// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
   /// <returns></returns>
   virtual public  System.String GetCommand() {
       var _ret_var = Efl.Core.CommandLineNativeInherit.efl_core_command_line_command_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Use an array to fill this object
   /// Every element of a string is a argument.</summary>
   /// <param name="array">An array where every array field is an argument</param>
   /// <returns>On success <c>true</c>, <c>false</c> otherwise</returns>
   virtual public bool SetCommandArray( Eina.Array< System.String> array) {
       var _in_array = array.Handle;
array.Own = false;
array.OwnContent = false;
                  var _ret_var = Efl.Core.CommandLineNativeInherit.efl_core_command_line_command_array_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_array);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Use a string to fill this object
   /// The string will be split at every unescaped &apos; &apos;, every resulting substring will be a new argument to the command line.</summary>
   /// <param name="str">A command in form of a string</param>
   /// <returns>On success <c>true</c>, <c>false</c> otherwise</returns>
   virtual public bool SetCommandString(  System.String str) {
                         var _ret_var = Efl.Core.CommandLineNativeInherit.efl_core_command_line_command_string_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), str);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get the accessor which enables access to each argument that got passed to this object.</summary>
   /// <returns></returns>
   virtual public Eina.Accessor< System.String> CommandAccess() {
       var _ret_var = Efl.Core.CommandLineNativeInherit.efl_core_command_line_command_access_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Accessor< System.String>(_ret_var, false, false);
 }
   /// <summary>Returns the app object that is representing this process
/// Note: This function call only works in the main loop thread of the process.</summary>
/// <value>Application for this process</value>
   public static Efl.App AppMain {
      get { return GetAppMain(); }
   }
   /// <summary>Indicates the version of EFL with which this application was compiled against/for.
/// This might differ from <see cref="Efl.App.GetEflVersion"/>.</summary>
/// <value>Efl build version</value>
   public Efl.Version BuildEflVersion {
      get { return GetBuildEflVersion(); }
   }
   /// <summary>Indicates the currently running version of EFL.
/// This might differ from <see cref="Efl.App.GetBuildEflVersion"/>.</summary>
/// <value>Efl version</value>
   public Efl.Version EflVersion {
      get { return GetEflVersion(); }
   }
   /// <summary>A commandline that encodes arguments in a command string. This command is unix shell-style, thus whitespace separates arguments unless escaped. Also a semi-colon &apos;;&apos;, ampersand &apos;&amp;&apos;, pipe/bar &apos;|&apos;, hash &apos;#&apos;, bracket, square brace, brace character (&apos;(&apos;, &apos;)&apos;, &apos;[&apos;, &apos;]&apos;, &apos;{&apos;, &apos;}&apos;), exclamation mark &apos;!&apos;,  backquote &apos;`&apos;, greator or less than (&apos;&gt;&apos; &apos;&lt;&apos;) character unless escaped or in quotes would cause args_count/value to not be generated properly, because it would force complex shell interpretation which will not be supported in evaluating the arg_count/value information, but the final shell may interpret this if this is executed via a command-line shell. To not be a complex shell command, it should be simple with paths, options and variable expansions, but nothing more complex involving the above unescaped characters.
/// &quot;cat -option /path/file&quot; &quot;cat &apos;quoted argument&apos;&quot; &quot;cat ~/path/escaped argument&quot; &quot;/bin/cat escaped argument <c>VARIABLE</c>&quot; etc.
/// 
/// It should not try and use &quot;complex shell features&quot; if you want the arg_count and arg_value set to be correct after setting the command string. For example none of:
/// 
/// &quot;VAR=x /bin/command &amp;&amp; /bin/othercommand &gt;&amp; /dev/null&quot; &quot;VAR=x /bin/command `/bin/othercommand` | /bin/cmd2 &amp;&amp; cmd3 &amp;&quot; etc.
/// 
/// If you set the command the arg_count/value property contents can change and be completely re-evaluated by parsing the command string into an argument array set along with interpreting escapes back into individual argument strings.</summary>
/// <value></value>
   public  System.String Command {
      get { return GetCommand(); }
   }
   /// <summary>Use an array to fill this object
/// Every element of a string is a argument.</summary>
/// <value>An array where every array field is an argument</value>
   public Eina.Array< System.String> CommandArray {
      set { SetCommandArray( value); }
   }
   /// <summary>Use a string to fill this object
/// The string will be split at every unescaped &apos; &apos;, every resulting substring will be a new argument to the command line.</summary>
/// <value>A command in form of a string</value>
   public  System.String CommandString {
      set { SetCommandString( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.App.efl_app_class_get();
   }
}
public class AppNativeInherit : Efl.LoopNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_app_build_efl_version_get_static_delegate == null)
      efl_app_build_efl_version_get_static_delegate = new efl_app_build_efl_version_get_delegate(build_efl_version_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_app_build_efl_version_get"), func = Marshal.GetFunctionPointerForDelegate(efl_app_build_efl_version_get_static_delegate)});
      if (efl_app_efl_version_get_static_delegate == null)
      efl_app_efl_version_get_static_delegate = new efl_app_efl_version_get_delegate(efl_version_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_app_efl_version_get"), func = Marshal.GetFunctionPointerForDelegate(efl_app_efl_version_get_static_delegate)});
      if (efl_core_command_line_command_get_static_delegate == null)
      efl_core_command_line_command_get_static_delegate = new efl_core_command_line_command_get_delegate(command_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_core_command_line_command_get"), func = Marshal.GetFunctionPointerForDelegate(efl_core_command_line_command_get_static_delegate)});
      if (efl_core_command_line_command_array_set_static_delegate == null)
      efl_core_command_line_command_array_set_static_delegate = new efl_core_command_line_command_array_set_delegate(command_array_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_core_command_line_command_array_set"), func = Marshal.GetFunctionPointerForDelegate(efl_core_command_line_command_array_set_static_delegate)});
      if (efl_core_command_line_command_string_set_static_delegate == null)
      efl_core_command_line_command_string_set_static_delegate = new efl_core_command_line_command_string_set_delegate(command_string_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_core_command_line_command_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_core_command_line_command_string_set_static_delegate)});
      if (efl_core_command_line_command_access_static_delegate == null)
      efl_core_command_line_command_access_static_delegate = new efl_core_command_line_command_access_delegate(command_access);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_core_command_line_command_access"), func = Marshal.GetFunctionPointerForDelegate(efl_core_command_line_command_access_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.App.efl_app_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.App.efl_app_class_get();
   }


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.App, Efl.Eo.NonOwnTag>))] private delegate Efl.App efl_app_main_get_delegate();


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.App, Efl.Eo.NonOwnTag>))] public delegate Efl.App efl_app_main_get_api_delegate();
    public static Efl.Eo.FunctionWrapper<efl_app_main_get_api_delegate> efl_app_main_get_ptr = new Efl.Eo.FunctionWrapper<efl_app_main_get_api_delegate>(_Module, "efl_app_main_get");
    private static Efl.App app_main_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_app_main_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.App _ret_var = default(Efl.App);
         try {
            _ret_var = App.GetAppMain();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_app_main_get_ptr.Value.Delegate();
      }
   }


    private delegate  System.IntPtr efl_app_build_efl_version_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_app_build_efl_version_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_app_build_efl_version_get_api_delegate> efl_app_build_efl_version_get_ptr = new Efl.Eo.FunctionWrapper<efl_app_build_efl_version_get_api_delegate>(_Module, "efl_app_build_efl_version_get");
    private static  System.IntPtr build_efl_version_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_app_build_efl_version_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Version _ret_var = default(Efl.Version);
         try {
            _ret_var = ((App)wrapper).GetBuildEflVersion();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);
      } else {
         return efl_app_build_efl_version_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_app_build_efl_version_get_delegate efl_app_build_efl_version_get_static_delegate;


    private delegate  System.IntPtr efl_app_efl_version_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_app_efl_version_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_app_efl_version_get_api_delegate> efl_app_efl_version_get_ptr = new Efl.Eo.FunctionWrapper<efl_app_efl_version_get_api_delegate>(_Module, "efl_app_efl_version_get");
    private static  System.IntPtr efl_version_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_app_efl_version_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Version _ret_var = default(Efl.Version);
         try {
            _ret_var = ((App)wrapper).GetEflVersion();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);
      } else {
         return efl_app_efl_version_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_app_efl_version_get_delegate efl_app_efl_version_get_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_core_command_line_command_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_core_command_line_command_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_core_command_line_command_get_api_delegate> efl_core_command_line_command_get_ptr = new Efl.Eo.FunctionWrapper<efl_core_command_line_command_get_api_delegate>(_Module, "efl_core_command_line_command_get");
    private static  System.String command_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_core_command_line_command_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((App)wrapper).GetCommand();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_core_command_line_command_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_core_command_line_command_get_delegate efl_core_command_line_command_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_core_command_line_command_array_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr array);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_core_command_line_command_array_set_api_delegate(System.IntPtr obj,    System.IntPtr array);
    public static Efl.Eo.FunctionWrapper<efl_core_command_line_command_array_set_api_delegate> efl_core_command_line_command_array_set_ptr = new Efl.Eo.FunctionWrapper<efl_core_command_line_command_array_set_api_delegate>(_Module, "efl_core_command_line_command_array_set");
    private static bool command_array_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr array)
   {
      Eina.Log.Debug("function efl_core_command_line_command_array_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_array = new Eina.Array< System.String>(array, true, true);
                     bool _ret_var = default(bool);
         try {
            _ret_var = ((App)wrapper).SetCommandArray( _in_array);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_core_command_line_command_array_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  array);
      }
   }
   private static efl_core_command_line_command_array_set_delegate efl_core_command_line_command_array_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_core_command_line_command_string_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String str);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_core_command_line_command_string_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String str);
    public static Efl.Eo.FunctionWrapper<efl_core_command_line_command_string_set_api_delegate> efl_core_command_line_command_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_core_command_line_command_string_set_api_delegate>(_Module, "efl_core_command_line_command_string_set");
    private static bool command_string_set(System.IntPtr obj, System.IntPtr pd,   System.String str)
   {
      Eina.Log.Debug("function efl_core_command_line_command_string_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((App)wrapper).SetCommandString( str);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_core_command_line_command_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  str);
      }
   }
   private static efl_core_command_line_command_string_set_delegate efl_core_command_line_command_string_set_static_delegate;


    private delegate  System.IntPtr efl_core_command_line_command_access_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_core_command_line_command_access_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_core_command_line_command_access_api_delegate> efl_core_command_line_command_access_ptr = new Efl.Eo.FunctionWrapper<efl_core_command_line_command_access_api_delegate>(_Module, "efl_core_command_line_command_access");
    private static  System.IntPtr command_access(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_core_command_line_command_access was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Accessor< System.String> _ret_var = default(Eina.Accessor< System.String>);
         try {
            _ret_var = ((App)wrapper).CommandAccess();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_core_command_line_command_access_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_core_command_line_command_access_delegate efl_core_command_line_command_access_static_delegate;
}
} 
