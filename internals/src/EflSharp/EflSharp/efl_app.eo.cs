#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>No description supplied.</summary>
[AppNativeInherit]
public class App : Efl.Loop, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.AppNativeInherit nativeInherit = new Efl.AppNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (App))
            return Efl.AppNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(App obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_app_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public App(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("App", efl_app_class_get(), typeof(App), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected App(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public App(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
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
            if (add_cpp_event_handler(key, this.evt_PauseEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ResumeEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_StandbyEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_TerminateEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_SignalUsr1Evt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_SignalUsr2Evt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_SignalHupEvt_delegate)) {
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.App, Efl.Eo.NonOwnTag>))] protected static extern Efl.App efl_app_main_get(System.IntPtr obj);
   /// <summary>Returns the app object that is representing this process
   /// Note: This function call only works in the main loop thread of the process.</summary>
   /// <returns>Application for this process</returns>
   public static Efl.App GetAppMain() {
       var _ret_var = efl_app_main_get(Efl.App.efl_app_class_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  System.IntPtr efl_app_build_efl_version_get(System.IntPtr obj);
   /// <summary>Indicates the version of EFL with which this application was compiled against/for.
   /// This might differ from <see cref="Efl.App.GetEflVersion"/>.</summary>
   /// <returns>Efl version</returns>
   virtual public Efl.Version GetBuildEflVersion() {
       var _ret_var = efl_app_build_efl_version_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Version>(_ret_var);
      
      return __ret_tmp;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  System.IntPtr efl_app_efl_version_get(System.IntPtr obj);
   /// <summary>Indicates the currently running version of EFL.
   /// This might differ from <see cref="Efl.App.GetBuildEflVersion"/>.</summary>
   /// <returns>Efl version</returns>
   virtual public Efl.Version GetEflVersion() {
       var _ret_var = efl_app_efl_version_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Version>(_ret_var);
      
      return __ret_tmp;
 }
   /// <summary>Returns the app object that is representing this process
/// Note: This function call only works in the main loop thread of the process.</summary>
   public static Efl.App AppMain {
      get { return GetAppMain(); }
   }
   /// <summary>Indicates the version of EFL with which this application was compiled against/for.
/// This might differ from <see cref="Efl.App.GetEflVersion"/>.</summary>
   public Efl.Version BuildEflVersion {
      get { return GetBuildEflVersion(); }
   }
   /// <summary>Indicates the currently running version of EFL.
/// This might differ from <see cref="Efl.App.GetBuildEflVersion"/>.</summary>
   public Efl.Version EflVersion {
      get { return GetEflVersion(); }
   }
}
public class AppNativeInherit : Efl.LoopNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_app_build_efl_version_get_static_delegate = new efl_app_build_efl_version_get_delegate(build_efl_version_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_app_build_efl_version_get"), func = Marshal.GetFunctionPointerForDelegate(efl_app_build_efl_version_get_static_delegate)});
      efl_app_efl_version_get_static_delegate = new efl_app_efl_version_get_delegate(efl_version_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_app_efl_version_get"), func = Marshal.GetFunctionPointerForDelegate(efl_app_efl_version_get_static_delegate)});
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


    private delegate  System.IntPtr efl_app_build_efl_version_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  System.IntPtr efl_app_build_efl_version_get(System.IntPtr obj);
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
         return efl_app_build_efl_version_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_app_build_efl_version_get_delegate efl_app_build_efl_version_get_static_delegate;


    private delegate  System.IntPtr efl_app_efl_version_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  System.IntPtr efl_app_efl_version_get(System.IntPtr obj);
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
         return efl_app_efl_version_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_app_efl_version_get_delegate efl_app_efl_version_get_static_delegate;
}
} 
