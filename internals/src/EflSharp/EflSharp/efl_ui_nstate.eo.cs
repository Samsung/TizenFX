#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI nstate class</summary>
[NstateNativeInherit]
public class Nstate : Efl.Ui.Button, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.NstateNativeInherit nativeInherit = new Efl.Ui.NstateNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Nstate))
            return Efl.Ui.NstateNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Nstate obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_nstate_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Nstate(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Nstate", efl_ui_nstate_class_get(), typeof(Nstate), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Nstate(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Nstate(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Nstate static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Nstate(obj.NativeHandle);
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
private static object ChangedEvtKey = new object();
   /// <summary>Called when the value changed.</summary>
   public event EventHandler ChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_NSTATE_EVENT_CHANGED";
            if (add_cpp_event_handler(key, this.evt_ChangedEvt_delegate)) {
               eventHandlers.AddHandler(ChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_NSTATE_EVENT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ChangedEvt.</summary>
   public void On_ChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ChangedEvt_delegate;
   private void on_ChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ChangedEvt_delegate = new Efl.EventCb(on_ChangedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  int efl_ui_nstate_count_get(System.IntPtr obj);
   /// <summary>Maximum number of states</summary>
   /// <returns>The number of states.</returns>
   virtual public  int GetCount() {
       var _ret_var = efl_ui_nstate_count_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_nstate_count_set(System.IntPtr obj,    int nstate);
   /// <summary>Maximum number of states</summary>
   /// <param name="nstate">The number of states.</param>
   /// <returns></returns>
   virtual public  void SetCount(  int nstate) {
                         efl_ui_nstate_count_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  nstate);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  int efl_ui_nstate_value_get(System.IntPtr obj);
   /// <summary>Get the state value.</summary>
   /// <returns>The state.</returns>
   virtual public  int GetValue() {
       var _ret_var = efl_ui_nstate_value_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_nstate_value_set(System.IntPtr obj,    int state);
   /// <summary>Set the particular state given in (0...nstate}.</summary>
   /// <param name="state">The state.</param>
   /// <returns></returns>
   virtual public  void SetValue(  int state) {
                         efl_ui_nstate_value_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  state);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_nstate_activate(System.IntPtr obj);
   /// <summary>Activate widget</summary>
   /// <returns></returns>
   virtual public  void Activate() {
       efl_ui_nstate_activate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Maximum number of states</summary>
   public  int Count {
      get { return GetCount(); }
      set { SetCount( value); }
   }
   /// <summary>Get the state value.</summary>
   public  int Value {
      get { return GetValue(); }
      set { SetValue( value); }
   }
}
public class NstateNativeInherit : Efl.Ui.ButtonNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_nstate_count_get_static_delegate = new efl_ui_nstate_count_get_delegate(count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_nstate_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_nstate_count_get_static_delegate)});
      efl_ui_nstate_count_set_static_delegate = new efl_ui_nstate_count_set_delegate(count_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_nstate_count_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_nstate_count_set_static_delegate)});
      efl_ui_nstate_value_get_static_delegate = new efl_ui_nstate_value_get_delegate(value_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_nstate_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_nstate_value_get_static_delegate)});
      efl_ui_nstate_value_set_static_delegate = new efl_ui_nstate_value_set_delegate(value_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_nstate_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_nstate_value_set_static_delegate)});
      efl_ui_nstate_activate_static_delegate = new efl_ui_nstate_activate_delegate(activate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_nstate_activate"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_nstate_activate_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Nstate.efl_ui_nstate_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Nstate.efl_ui_nstate_class_get();
   }


    private delegate  int efl_ui_nstate_count_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_ui_nstate_count_get(System.IntPtr obj);
    private static  int count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_nstate_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Nstate)wrapper).GetCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_nstate_count_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_nstate_count_get_delegate efl_ui_nstate_count_get_static_delegate;


    private delegate  void efl_ui_nstate_count_set_delegate(System.IntPtr obj, System.IntPtr pd,    int nstate);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_nstate_count_set(System.IntPtr obj,    int nstate);
    private static  void count_set(System.IntPtr obj, System.IntPtr pd,   int nstate)
   {
      Eina.Log.Debug("function efl_ui_nstate_count_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Nstate)wrapper).SetCount( nstate);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_nstate_count_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  nstate);
      }
   }
   private efl_ui_nstate_count_set_delegate efl_ui_nstate_count_set_static_delegate;


    private delegate  int efl_ui_nstate_value_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_ui_nstate_value_get(System.IntPtr obj);
    private static  int value_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_nstate_value_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Nstate)wrapper).GetValue();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_nstate_value_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_nstate_value_get_delegate efl_ui_nstate_value_get_static_delegate;


    private delegate  void efl_ui_nstate_value_set_delegate(System.IntPtr obj, System.IntPtr pd,    int state);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_nstate_value_set(System.IntPtr obj,    int state);
    private static  void value_set(System.IntPtr obj, System.IntPtr pd,   int state)
   {
      Eina.Log.Debug("function efl_ui_nstate_value_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Nstate)wrapper).SetValue( state);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_nstate_value_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  state);
      }
   }
   private efl_ui_nstate_value_set_delegate efl_ui_nstate_value_set_static_delegate;


    private delegate  void efl_ui_nstate_activate_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_nstate_activate(System.IntPtr obj);
    private static  void activate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_nstate_activate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Nstate)wrapper).Activate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_nstate_activate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_nstate_activate_delegate efl_ui_nstate_activate_static_delegate;
}
} } 
