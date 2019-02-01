#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl Ui Selection class</summary>
[SelectionConcreteNativeInherit]
public interface Selection : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Set the selection data to the object</summary>
/// <param name="type">Selection Type</param>
/// <param name="format">Selection Format</param>
/// <param name="data"></param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns>Future for tracking when the selection is lost</returns>
 Eina.Future SetSelection( Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,   uint seat);
   /// <summary>Get the data from the object that has selection</summary>
/// <param name="type">Selection Type</param>
/// <param name="format">Selection Format</param>
/// <param name="data_func">Data ready function pointer</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns></returns>
 void GetSelection( Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Efl.Ui.SelectionDataReady data_func,   uint seat);
   /// <summary>Clear the selection data from the object</summary>
/// <param name="type">Selection Type</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns></returns>
 void ClearSelection( Efl.Ui.SelectionType type,   uint seat);
   /// <summary>Determine whether the selection data has owner</summary>
/// <param name="type">Selection type</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns>EINA_TRUE if there is object owns selection, otherwise EINA_FALSE</returns>
bool HasOwner( Efl.Ui.SelectionType type,   uint seat);
      System.Threading.Tasks.Task<Eina.Value> SetSelectionAsync( Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Eina.Slice data,  uint seat, System.Threading.CancellationToken token=default(System.Threading.CancellationToken));
            /// <summary>Called when display server&apos;s selection has changed</summary>
   event EventHandler<Efl.Ui.SelectionSelectionChangedEvt_Args> SelectionChangedEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Selection.SelectionChangedEvt"/>.</summary>
public class SelectionSelectionChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.SelectionChanged arg { get; set; }
}
/// <summary>Efl Ui Selection class</summary>
sealed public class SelectionConcrete : 

Selection
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (SelectionConcrete))
            return Efl.Ui.SelectionConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_selection_mixin_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public SelectionConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~SelectionConcrete()
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
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static SelectionConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new SelectionConcrete(obj.NativeHandle);
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
   private readonly object eventLock = new object();
   private Dictionary<string, int> event_cb_count = new Dictionary<string, int>();
   private bool add_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
          bool result = Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } 
      event_cb_count[key]++;
      return true;
   }
   private bool remove_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 1) {
         IntPtr desc = Efl.EventDescription.GetNative(key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
         bool result = Efl.Eo.Globals.efl_event_callback_del(handle, desc, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to remove event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } else if (event_count == 0) {
         Eina.Log.Error($"Trying to remove proxy for event {key} when there is nothing registered.");
         return false;
      } 
      event_cb_count[key]--;
      return true;
   }
private static object SelectionChangedEvtKey = new object();
   /// <summary>Called when display server&apos;s selection has changed</summary>
   public event EventHandler<Efl.Ui.SelectionSelectionChangedEvt_Args> SelectionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SELECTION_EVENT_SELECTION_CHANGED";
            if (add_cpp_event_handler(key, this.evt_SelectionChangedEvt_delegate)) {
               eventHandlers.AddHandler(SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SELECTION_EVENT_SELECTION_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_SelectionChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionChangedEvt.</summary>
   public void On_SelectionChangedEvt(Efl.Ui.SelectionSelectionChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.SelectionSelectionChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.SelectionSelectionChangedEvt_Args>)eventHandlers[SelectionChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionChangedEvt_delegate;
   private void on_SelectionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.SelectionSelectionChangedEvt_Args args = new Efl.Ui.SelectionSelectionChangedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_SelectionChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_SelectionChangedEvt_delegate = new Efl.EventCb(on_SelectionChangedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private static extern  Eina.Future efl_ui_selection_set(System.IntPtr obj,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,   Eina.Slice data,    uint seat);
   /// <summary>Set the selection data to the object</summary>
   /// <param name="type">Selection Type</param>
   /// <param name="format">Selection Format</param>
   /// <param name="data"></param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns>Future for tracking when the selection is lost</returns>
   public  Eina.Future SetSelection( Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,   uint seat) {
                                                                               var _ret_var = efl_ui_selection_set(Efl.Ui.SelectionConcrete.efl_ui_selection_mixin_get(),  type,  format,  data,  seat);
      Eina.Error.RaiseIfUnhandledException();
                                                      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_selection_get(System.IntPtr obj,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,    uint seat);
   /// <summary>Get the data from the object that has selection</summary>
   /// <param name="type">Selection Type</param>
   /// <param name="format">Selection Format</param>
   /// <param name="data_func">Data ready function pointer</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   public  void GetSelection( Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Efl.Ui.SelectionDataReady data_func,   uint seat) {
                                                                   GCHandle data_func_handle = GCHandle.Alloc(data_func);
            efl_ui_selection_get(Efl.Ui.SelectionConcrete.efl_ui_selection_mixin_get(),  type,  format, GCHandle.ToIntPtr(data_func_handle), Efl.Ui.SelectionDataReadyWrapper.Cb, Efl.Eo.Globals.free_gchandle,  seat);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_selection_clear(System.IntPtr obj,   Efl.Ui.SelectionType type,    uint seat);
   /// <summary>Clear the selection data from the object</summary>
   /// <param name="type">Selection Type</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   public  void ClearSelection( Efl.Ui.SelectionType type,   uint seat) {
                                           efl_ui_selection_clear(Efl.Ui.SelectionConcrete.efl_ui_selection_mixin_get(),  type,  seat);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_selection_has_owner(System.IntPtr obj,   Efl.Ui.SelectionType type,    uint seat);
   /// <summary>Determine whether the selection data has owner</summary>
   /// <param name="type">Selection type</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns>EINA_TRUE if there is object owns selection, otherwise EINA_FALSE</returns>
   public bool HasOwner( Efl.Ui.SelectionType type,   uint seat) {
                                           var _ret_var = efl_ui_selection_has_owner(Efl.Ui.SelectionConcrete.efl_ui_selection_mixin_get(),  type,  seat);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   public System.Threading.Tasks.Task<Eina.Value> SetSelectionAsync( Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Eina.Slice data,  uint seat, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
      Eina.Future future = SetSelection(  type,  format,  data,  seat);
      return Efl.Eo.Globals.WrapAsync(future, token);
   }
}
public class SelectionConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_selection_set_static_delegate = new efl_ui_selection_set_delegate(selection_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_selection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_set_static_delegate)});
      efl_ui_selection_get_static_delegate = new efl_ui_selection_get_delegate(selection_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_get_static_delegate)});
      efl_ui_selection_clear_static_delegate = new efl_ui_selection_clear_delegate(selection_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_selection_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_clear_static_delegate)});
      efl_ui_selection_has_owner_static_delegate = new efl_ui_selection_has_owner_delegate(has_owner);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_selection_has_owner"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_has_owner_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.SelectionConcrete.efl_ui_selection_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.SelectionConcrete.efl_ui_selection_mixin_get();
   }


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_ui_selection_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,   Eina.Slice data,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private static extern  Eina.Future efl_ui_selection_set(System.IntPtr obj,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,   Eina.Slice data,    uint seat);
    private static  Eina.Future selection_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_selection_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                           Eina.Future _ret_var = default( Eina.Future);
         try {
            _ret_var = ((SelectionConcrete)wrapper).SetSelection( type,  format,  data,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                      return _ret_var;
      } else {
         return efl_ui_selection_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  format,  data,  seat);
      }
   }
   private efl_ui_selection_set_delegate efl_ui_selection_set_static_delegate;


    private delegate  void efl_ui_selection_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_selection_get(System.IntPtr obj,   Efl.Ui.SelectionType type,   Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,    uint seat);
    private static  void selection_get(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format, IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_selection_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                              Efl.Ui.SelectionDataReadyWrapper data_func_wrapper = new Efl.Ui.SelectionDataReadyWrapper(data_func, data_func_data, data_func_free_cb);
               
         try {
            ((SelectionConcrete)wrapper).GetSelection( type,  format,  data_func_wrapper.ManagedCb,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_ui_selection_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  format, data_func_data, data_func, data_func_free_cb,  seat);
      }
   }
   private efl_ui_selection_get_delegate efl_ui_selection_get_static_delegate;


    private delegate  void efl_ui_selection_clear_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionType type,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_selection_clear(System.IntPtr obj,   Efl.Ui.SelectionType type,    uint seat);
    private static  void selection_clear(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_selection_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((SelectionConcrete)wrapper).ClearSelection( type,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_selection_clear(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  seat);
      }
   }
   private efl_ui_selection_clear_delegate efl_ui_selection_clear_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_selection_has_owner_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionType type,    uint seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_selection_has_owner(System.IntPtr obj,   Efl.Ui.SelectionType type,    uint seat);
    private static bool has_owner(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_selection_has_owner was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((SelectionConcrete)wrapper).HasOwner( type,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_ui_selection_has_owner(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  type,  seat);
      }
   }
   private efl_ui_selection_has_owner_delegate efl_ui_selection_has_owner_static_delegate;
}
} } 
