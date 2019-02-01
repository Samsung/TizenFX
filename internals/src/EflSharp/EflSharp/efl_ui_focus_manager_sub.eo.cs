#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { namespace Focus { 
/// <summary>A class that automatically registers its border elements in the parent manager
/// This sub manager will register its border elements on the parent manager. The parent manager is found with the <see cref="Efl.Ui.Focus.Object"/> interface of the <see cref="Efl.Object.Parent"/>.
/// 
/// Each sub manager also has to be a focus object, the object itself will be registered into the parent manager. It will be used as logical parent while registering the border elements.
/// 
/// You can filter the border elements by overriding the property <see cref="Efl.Ui.Focus.Manager.GetBorderElements"/>.
/// 1.20</summary>
[ManagerSubConcreteNativeInherit]
public interface ManagerSub : 
   Efl.Ui.Focus.Manager ,
   Efl.Eo.IWrapper, IDisposable
{
}
/// <summary>A class that automatically registers its border elements in the parent manager
/// This sub manager will register its border elements on the parent manager. The parent manager is found with the <see cref="Efl.Ui.Focus.Object"/> interface of the <see cref="Efl.Object.Parent"/>.
/// 
/// Each sub manager also has to be a focus object, the object itself will be registered into the parent manager. It will be used as logical parent while registering the border elements.
/// 
/// You can filter the border elements by overriding the property <see cref="Efl.Ui.Focus.Manager.GetBorderElements"/>.
/// 1.20</summary>
sealed public class ManagerSubConcrete : 

ManagerSub
   , Efl.Ui.Focus.Manager
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ManagerSubConcrete))
            return Efl.Ui.Focus.ManagerSubConcreteNativeInherit.GetEflClassStatic();
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
      efl_ui_focus_manager_sub_mixin_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ManagerSubConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ManagerSubConcrete()
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
   public static ManagerSubConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ManagerSubConcrete(obj.NativeHandle);
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
private static object RedirectChangedEvtKey = new object();
   /// <summary>Emitted when the redirect object has changed, the old manager is passed as event info
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ManagerRedirectChangedEvt_Args> RedirectChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_REDIRECT_CHANGED";
            if (add_cpp_event_handler(key, this.evt_RedirectChangedEvt_delegate)) {
               eventHandlers.AddHandler(RedirectChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_REDIRECT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_RedirectChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(RedirectChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event RedirectChangedEvt.</summary>
   public void On_RedirectChangedEvt(Efl.Ui.Focus.ManagerRedirectChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ManagerRedirectChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ManagerRedirectChangedEvt_Args>)eventHandlers[RedirectChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_RedirectChangedEvt_delegate;
   private void on_RedirectChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ManagerRedirectChangedEvt_Args args = new Efl.Ui.Focus.ManagerRedirectChangedEvt_Args();
      args.arg = new Efl.Ui.Focus.ManagerConcrete(evt.Info);
      try {
         On_RedirectChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object FlushPreEvtKey = new object();
   /// <summary>Emitted once the graph calculationg will be performed
   /// 1.20</summary>
   public event EventHandler FlushPreEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_FLUSH_PRE";
            if (add_cpp_event_handler(key, this.evt_FlushPreEvt_delegate)) {
               eventHandlers.AddHandler(FlushPreEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_FLUSH_PRE";
            if (remove_cpp_event_handler(key, this.evt_FlushPreEvt_delegate)) { 
               eventHandlers.RemoveHandler(FlushPreEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FlushPreEvt.</summary>
   public void On_FlushPreEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[FlushPreEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FlushPreEvt_delegate;
   private void on_FlushPreEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_FlushPreEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object CoordsDirtyEvtKey = new object();
   /// <summary>Emitted once the graph is dirty, this means there are potential changes in border_elements you want to know about
   /// 1.20</summary>
   public event EventHandler CoordsDirtyEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_COORDS_DIRTY";
            if (add_cpp_event_handler(key, this.evt_CoordsDirtyEvt_delegate)) {
               eventHandlers.AddHandler(CoordsDirtyEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_COORDS_DIRTY";
            if (remove_cpp_event_handler(key, this.evt_CoordsDirtyEvt_delegate)) { 
               eventHandlers.RemoveHandler(CoordsDirtyEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event CoordsDirtyEvt.</summary>
   public void On_CoordsDirtyEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[CoordsDirtyEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_CoordsDirtyEvt_delegate;
   private void on_CoordsDirtyEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_CoordsDirtyEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object FocusChangedEvtKey = new object();
   /// <summary>Emitted if the manager has focused an object, the passed focus object is the last focused object
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ManagerFocusChangedEvt_Args> FocusChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_FOCUS_CHANGED";
            if (add_cpp_event_handler(key, this.evt_FocusChangedEvt_delegate)) {
               eventHandlers.AddHandler(FocusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_FOCUS_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_FocusChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(FocusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FocusChangedEvt.</summary>
   public void On_FocusChangedEvt(Efl.Ui.Focus.ManagerFocusChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ManagerFocusChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ManagerFocusChangedEvt_Args>)eventHandlers[FocusChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FocusChangedEvt_delegate;
   private void on_FocusChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ManagerFocusChangedEvt_Args args = new Efl.Ui.Focus.ManagerFocusChangedEvt_Args();
      args.arg = new Efl.Ui.Focus.ObjectConcrete(evt.Info);
      try {
         On_FocusChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Dirty_logic_freezeChangedEvtKey = new object();
   /// <summary>Called when this focus manager is frozen or unfrozen, even_info beeing <c>true</c> indicates that it is now frozen, <c>false</c> indicates that it is unfrozen.
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ManagerDirty_logic_freezeChangedEvt_Args> Dirty_logic_freezeChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_DIRTY_LOGIC_FREEZE_CHANGED";
            if (add_cpp_event_handler(key, this.evt_Dirty_logic_freezeChangedEvt_delegate)) {
               eventHandlers.AddHandler(Dirty_logic_freezeChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_DIRTY_LOGIC_FREEZE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Dirty_logic_freezeChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Dirty_logic_freezeChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Dirty_logic_freezeChangedEvt.</summary>
   public void On_Dirty_logic_freezeChangedEvt(Efl.Ui.Focus.ManagerDirty_logic_freezeChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ManagerDirty_logic_freezeChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ManagerDirty_logic_freezeChangedEvt_Args>)eventHandlers[Dirty_logic_freezeChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Dirty_logic_freezeChangedEvt_delegate;
   private void on_Dirty_logic_freezeChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ManagerDirty_logic_freezeChangedEvt_Args args = new Efl.Ui.Focus.ManagerDirty_logic_freezeChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
      try {
         On_Dirty_logic_freezeChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_RedirectChangedEvt_delegate = new Efl.EventCb(on_RedirectChangedEvt_NativeCallback);
      evt_FlushPreEvt_delegate = new Efl.EventCb(on_FlushPreEvt_NativeCallback);
      evt_CoordsDirtyEvt_delegate = new Efl.EventCb(on_CoordsDirtyEvt_NativeCallback);
      evt_FocusChangedEvt_delegate = new Efl.EventCb(on_FocusChangedEvt_NativeCallback);
      evt_Dirty_logic_freezeChangedEvt_delegate = new Efl.EventCb(on_Dirty_logic_freezeChangedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_manager_focus_get(System.IntPtr obj);
   /// <summary>The element which is currently focused by this manager
   /// For the case focus is a logical child, then the item will go to the next none logical element. If there is none, focus will stay where it is right now.
   /// 1.20</summary>
   /// <returns>Focused element
   /// 1.20</returns>
   public Efl.Ui.Focus.Object GetManagerFocus() {
       var _ret_var = efl_ui_focus_manager_focus_get(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_manager_focus_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object focus);
   /// <summary>The element which is currently focused by this manager
   /// For the case focus is a logical child, then the item will go to the next none logical element. If there is none, focus will stay where it is right now.
   /// 1.20</summary>
   /// <param name="focus">Focused element
   /// 1.20</param>
   /// <returns></returns>
   public  void SetManagerFocus( Efl.Ui.Focus.Object focus) {
                         efl_ui_focus_manager_focus_set(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get(),  focus);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Manager efl_ui_focus_manager_redirect_get(System.IntPtr obj);
   /// <summary>Add a another manager to serve the move requests.
   /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
   /// 1.20</summary>
   /// <returns>The redirect manager.
   /// 1.20</returns>
   public Efl.Ui.Focus.Manager GetRedirect() {
       var _ret_var = efl_ui_focus_manager_redirect_get(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_manager_redirect_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager redirect);
   /// <summary>Add a another manager to serve the move requests.
   /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
   /// 1.20</summary>
   /// <param name="redirect">The redirect manager.
   /// 1.20</param>
   /// <returns></returns>
   public  void SetRedirect( Efl.Ui.Focus.Manager redirect) {
                         efl_ui_focus_manager_redirect_set(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get(),  redirect);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  System.IntPtr efl_ui_focus_manager_border_elements_get(System.IntPtr obj);
   /// <summary>The list of elements which are at the border of the graph.
   /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.Manager.Move"/>
   /// 1.20</summary>
   /// <returns>An iterator over the border objects.
   /// 1.20</returns>
   public Eina.Iterator<Efl.Ui.Focus.Object> GetBorderElements() {
       var _ret_var = efl_ui_focus_manager_border_elements_get(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Ui.Focus.Object>(_ret_var, false, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  System.IntPtr efl_ui_focus_manager_viewport_elements_get(System.IntPtr obj,   Eina.Rect_StructInternal viewport);
   /// <summary>The list of elements which are at the border of the viewport.
   /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.Manager.Move"/>
   /// 1.20</summary>
   /// <param name="viewport"></param>
   /// <returns></returns>
   public Eina.Iterator<Efl.Ui.Focus.Object> GetViewportElements( Eina.Rect viewport) {
       var _in_viewport = Eina.Rect_StructConversion.ToInternal(viewport);
                  var _ret_var = efl_ui_focus_manager_viewport_elements_get(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get(),  _in_viewport);
      Eina.Error.RaiseIfUnhandledException();
                  return new Eina.Iterator<Efl.Ui.Focus.Object>(_ret_var, false, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_manager_root_get(System.IntPtr obj);
   /// <summary>Root node for all logical subtrees.
   /// This property can only be set once.
   /// 1.20</summary>
   /// <returns>Will be registered into this manager object.
   /// 1.20</returns>
   public Efl.Ui.Focus.Object GetRoot() {
       var _ret_var = efl_ui_focus_manager_root_get(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_manager_root_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object root);
   /// <summary>Root node for all logical subtrees.
   /// This property can only be set once.
   /// 1.20</summary>
   /// <param name="root">Will be registered into this manager object.
   /// 1.20</param>
   /// <returns>If <c>true</c>, this is the root node
   /// 1.20</returns>
   public bool SetRoot( Efl.Ui.Focus.Object root) {
                         var _ret_var = efl_ui_focus_manager_root_set(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get(),  root);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_manager_move(System.IntPtr obj,   Efl.Ui.Focus.Direction direction);
   /// <summary>Move the focus into the given direction.
   /// This call flushes all changes. This means all changes between the last flush and now are computed
   /// 1.20</summary>
   /// <param name="direction">The direction to move to
   /// 1.20</param>
   /// <returns>The element which is now focused
   /// 1.20</returns>
   public Efl.Ui.Focus.Object Move( Efl.Ui.Focus.Direction direction) {
                         var _ret_var = efl_ui_focus_manager_move(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get(),  direction);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_manager_request_move(System.IntPtr obj,   Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child,  [MarshalAs(UnmanagedType.U1)]  bool logical);
   /// <summary>Return the object next in the <c>direction</c> from <c>child</c>.
   /// 1.20</summary>
   /// <param name="direction">Direction to move focus
   /// 1.20</param>
   /// <param name="child">The child where to look from. Pass <c>null</c> to indicate the last focused child.
   /// 1.20</param>
   /// <param name="logical">Weather you want to have a logical node as result or a logical. Note, at a move call no logical node will get focus, and this is passed as <c>false</c> there.
   /// 1.20</param>
   /// <returns>Next object to focus
   /// 1.20</returns>
   public Efl.Ui.Focus.Object MoveRequest( Efl.Ui.Focus.Direction direction,  Efl.Ui.Focus.Object child,  bool logical) {
                                                             var _ret_var = efl_ui_focus_manager_request_move(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get(),  direction,  child,  logical);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_manager_request_subchild(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child);
   /// <summary>Returns a widget that can receive focus
   /// The returned widget is in a child of the passed param. Its garanteed that child will not be prepared once again, so you can call this function out of a prepare call.
   /// 1.20</summary>
   /// <param name="child">Parent for returned child
   /// 1.20</param>
   /// <returns>Child of passed parameter
   /// 1.20</returns>
   public Efl.Ui.Focus.Object RequestSubchild( Efl.Ui.Focus.Object child) {
                         var _ret_var = efl_ui_focus_manager_request_subchild(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get(),  child);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  System.IntPtr efl_ui_focus_manager_fetch(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child);
   /// <summary>This will fetch the data from a registered node.
   /// Be aware this function will trigger all dirty nodes to be computed
   /// 1.20</summary>
   /// <param name="child">The child object to inspect.
   /// 1.20</param>
   /// <returns>The list of relations starting from <c>child</c>.
   /// 1.20</returns>
   public Efl.Ui.Focus.Relations Fetch( Efl.Ui.Focus.Object child) {
                         var _ret_var = efl_ui_focus_manager_fetch(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get(),  child);
      Eina.Error.RaiseIfUnhandledException();
                  var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.Focus.Relations>(_ret_var);
      Marshal.FreeHGlobal(_ret_var);
      return __ret_tmp;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern Efl.Ui.Focus.ManagerLogicalEndDetail_StructInternal efl_ui_focus_manager_logical_end(System.IntPtr obj);
   /// <summary>Return the last logical object.
   /// The returned object is the last object that would be returned if you start at the root and move the direction into next.
   /// 1.20</summary>
   /// <returns>Last object
   /// 1.20</returns>
   public Efl.Ui.Focus.ManagerLogicalEndDetail LogicalEnd() {
       var _ret_var = efl_ui_focus_manager_logical_end(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return Efl.Ui.Focus.ManagerLogicalEndDetail_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_manager_reset_history(System.IntPtr obj);
   /// <summary>Reset the history stack of this manager object. This means the most upper element will be unfocused, all other elements will be removed from the remembered before.
   /// To not break the assertion that there should be always a focused element, you should focus a other element immidiatly after calling that.
   /// 1.20</summary>
   /// <returns></returns>
   public  void ResetHistory() {
       efl_ui_focus_manager_reset_history(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_manager_pop_history_stack(System.IntPtr obj);
   /// <summary>Removes the most upper history element, and move focus on.
   /// If there is a element that was focused before, it will be taken. Otherwise, the best fitting element from the registered elements will be focused.
   /// 1.20</summary>
   /// <returns></returns>
   public  void PopHistoryStack() {
       efl_ui_focus_manager_pop_history_stack(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_manager_setup_on_first_touch(System.IntPtr obj,   Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object entry);
   /// <summary>Called when this manager is set as redirect
   /// 1.20</summary>
   /// <param name="direction">The direction in which this should be setup
   /// 1.20</param>
   /// <param name="entry">The object that caused this manager to be redirect
   /// 1.20</param>
   /// <returns></returns>
   public  void SetupOnFirstTouch( Efl.Ui.Focus.Direction direction,  Efl.Ui.Focus.Object entry) {
                                           efl_ui_focus_manager_setup_on_first_touch(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get(),  direction,  entry);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_manager_dirty_logic_freeze(System.IntPtr obj);
   /// <summary>This disables the cache invalidation when a object is moved.
   /// Even the object is moved, the focus manager will not recalculate its relations, this can be used when you know that the set of widgets in the focus manager is equally moved. so the relations between the widets in the set do not change.
   /// 1.20</summary>
   /// <returns></returns>
   public  void FreezeDirtyLogic() {
       efl_ui_focus_manager_dirty_logic_freeze(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_manager_dirty_logic_unfreeze(System.IntPtr obj);
   /// <summary>This enables the cache invalidation when a object is moved.
   /// This is the counter part to <see cref="Efl.Ui.Focus.Manager.FreezeDirtyLogic"/>
   /// 1.20</summary>
   /// <returns></returns>
   public  void DirtyLogicUnfreeze() {
       efl_ui_focus_manager_dirty_logic_unfreeze(Efl.Ui.Focus.ManagerConcrete.efl_ui_focus_manager_interface_get());
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>The element which is currently focused by this manager
/// For the case focus is a logical child, then the item will go to the next none logical element. If there is none, focus will stay where it is right now.
/// 1.20</summary>
   public Efl.Ui.Focus.Object ManagerFocus {
      get { return GetManagerFocus(); }
      set { SetManagerFocus( value); }
   }
   /// <summary>Add a another manager to serve the move requests.
/// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
/// 1.20</summary>
   public Efl.Ui.Focus.Manager Redirect {
      get { return GetRedirect(); }
      set { SetRedirect( value); }
   }
   /// <summary>The list of elements which are at the border of the graph.
/// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.Manager.Move"/>
/// 1.20</summary>
   public Eina.Iterator<Efl.Ui.Focus.Object> BorderElements {
      get { return GetBorderElements(); }
   }
   /// <summary>Root node for all logical subtrees.
/// This property can only be set once.
/// 1.20</summary>
   public Efl.Ui.Focus.Object Root {
      get { return GetRoot(); }
      set { SetRoot( value); }
   }
}
public class ManagerSubConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_focus_manager_focus_get_static_delegate = new efl_ui_focus_manager_focus_get_delegate(manager_focus_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_focus_get_static_delegate)});
      efl_ui_focus_manager_focus_set_static_delegate = new efl_ui_focus_manager_focus_set_delegate(manager_focus_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_focus_set_static_delegate)});
      efl_ui_focus_manager_redirect_get_static_delegate = new efl_ui_focus_manager_redirect_get_delegate(redirect_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_redirect_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_redirect_get_static_delegate)});
      efl_ui_focus_manager_redirect_set_static_delegate = new efl_ui_focus_manager_redirect_set_delegate(redirect_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_redirect_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_redirect_set_static_delegate)});
      efl_ui_focus_manager_border_elements_get_static_delegate = new efl_ui_focus_manager_border_elements_get_delegate(border_elements_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_border_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_border_elements_get_static_delegate)});
      efl_ui_focus_manager_viewport_elements_get_static_delegate = new efl_ui_focus_manager_viewport_elements_get_delegate(viewport_elements_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_viewport_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_viewport_elements_get_static_delegate)});
      efl_ui_focus_manager_root_get_static_delegate = new efl_ui_focus_manager_root_get_delegate(root_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_root_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_root_get_static_delegate)});
      efl_ui_focus_manager_root_set_static_delegate = new efl_ui_focus_manager_root_set_delegate(root_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_root_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_root_set_static_delegate)});
      efl_ui_focus_manager_move_static_delegate = new efl_ui_focus_manager_move_delegate(move);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_move"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_move_static_delegate)});
      efl_ui_focus_manager_request_move_static_delegate = new efl_ui_focus_manager_request_move_delegate(request_move);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_request_move"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_request_move_static_delegate)});
      efl_ui_focus_manager_request_subchild_static_delegate = new efl_ui_focus_manager_request_subchild_delegate(request_subchild);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_request_subchild"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_request_subchild_static_delegate)});
      efl_ui_focus_manager_fetch_static_delegate = new efl_ui_focus_manager_fetch_delegate(fetch);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_fetch"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_fetch_static_delegate)});
      efl_ui_focus_manager_logical_end_static_delegate = new efl_ui_focus_manager_logical_end_delegate(logical_end);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_logical_end"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_logical_end_static_delegate)});
      efl_ui_focus_manager_reset_history_static_delegate = new efl_ui_focus_manager_reset_history_delegate(reset_history);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_reset_history"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_reset_history_static_delegate)});
      efl_ui_focus_manager_pop_history_stack_static_delegate = new efl_ui_focus_manager_pop_history_stack_delegate(pop_history_stack);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_pop_history_stack"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_pop_history_stack_static_delegate)});
      efl_ui_focus_manager_setup_on_first_touch_static_delegate = new efl_ui_focus_manager_setup_on_first_touch_delegate(setup_on_first_touch);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_setup_on_first_touch"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_setup_on_first_touch_static_delegate)});
      efl_ui_focus_manager_dirty_logic_freeze_static_delegate = new efl_ui_focus_manager_dirty_logic_freeze_delegate(dirty_logic_freeze);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_dirty_logic_freeze"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_dirty_logic_freeze_static_delegate)});
      efl_ui_focus_manager_dirty_logic_unfreeze_static_delegate = new efl_ui_focus_manager_dirty_logic_unfreeze_delegate(dirty_logic_unfreeze);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_manager_dirty_logic_unfreeze"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_dirty_logic_unfreeze_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Focus.ManagerSubConcrete.efl_ui_focus_manager_sub_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Focus.ManagerSubConcrete.efl_ui_focus_manager_sub_mixin_get();
   }


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_manager_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_manager_focus_get(System.IntPtr obj);
    private static Efl.Ui.Focus.Object manager_focus_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_focus_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Object _ret_var = default(Efl.Ui.Focus.Object);
         try {
            _ret_var = ((ManagerSubConcrete)wrapper).GetManagerFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_manager_focus_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_manager_focus_get_delegate efl_ui_focus_manager_focus_get_static_delegate;


    private delegate  void efl_ui_focus_manager_focus_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object focus);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_manager_focus_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object focus);
    private static  void manager_focus_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Object focus)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_focus_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ManagerSubConcrete)wrapper).SetManagerFocus( focus);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_manager_focus_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  focus);
      }
   }
   private efl_ui_focus_manager_focus_set_delegate efl_ui_focus_manager_focus_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Manager efl_ui_focus_manager_redirect_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Manager efl_ui_focus_manager_redirect_get(System.IntPtr obj);
    private static Efl.Ui.Focus.Manager redirect_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_redirect_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Manager _ret_var = default(Efl.Ui.Focus.Manager);
         try {
            _ret_var = ((ManagerSubConcrete)wrapper).GetRedirect();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_manager_redirect_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_manager_redirect_get_delegate efl_ui_focus_manager_redirect_get_static_delegate;


    private delegate  void efl_ui_focus_manager_redirect_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager redirect);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_manager_redirect_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager redirect);
    private static  void redirect_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Manager redirect)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_redirect_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ManagerSubConcrete)wrapper).SetRedirect( redirect);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_manager_redirect_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  redirect);
      }
   }
   private efl_ui_focus_manager_redirect_set_delegate efl_ui_focus_manager_redirect_set_static_delegate;


    private delegate  System.IntPtr efl_ui_focus_manager_border_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_focus_manager_border_elements_get(System.IntPtr obj);
    private static  System.IntPtr border_elements_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_border_elements_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Ui.Focus.Object> _ret_var = default(Eina.Iterator<Efl.Ui.Focus.Object>);
         try {
            _ret_var = ((ManagerSubConcrete)wrapper).GetBorderElements();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_ui_focus_manager_border_elements_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_manager_border_elements_get_delegate efl_ui_focus_manager_border_elements_get_static_delegate;


    private delegate  System.IntPtr efl_ui_focus_manager_viewport_elements_get_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect_StructInternal viewport);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_focus_manager_viewport_elements_get(System.IntPtr obj,   Eina.Rect_StructInternal viewport);
    private static  System.IntPtr viewport_elements_get(System.IntPtr obj, System.IntPtr pd,  Eina.Rect_StructInternal viewport)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_viewport_elements_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_viewport = Eina.Rect_StructConversion.ToManaged(viewport);
                     Eina.Iterator<Efl.Ui.Focus.Object> _ret_var = default(Eina.Iterator<Efl.Ui.Focus.Object>);
         try {
            _ret_var = ((ManagerSubConcrete)wrapper).GetViewportElements( _in_viewport);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var.Handle;
      } else {
         return efl_ui_focus_manager_viewport_elements_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  viewport);
      }
   }
   private efl_ui_focus_manager_viewport_elements_get_delegate efl_ui_focus_manager_viewport_elements_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_manager_root_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_manager_root_get(System.IntPtr obj);
    private static Efl.Ui.Focus.Object root_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_root_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Object _ret_var = default(Efl.Ui.Focus.Object);
         try {
            _ret_var = ((ManagerSubConcrete)wrapper).GetRoot();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_manager_root_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_manager_root_get_delegate efl_ui_focus_manager_root_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_manager_root_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object root);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_manager_root_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object root);
    private static bool root_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Object root)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_root_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((ManagerSubConcrete)wrapper).SetRoot( root);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_focus_manager_root_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  root);
      }
   }
   private efl_ui_focus_manager_root_set_delegate efl_ui_focus_manager_root_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_manager_move_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.Direction direction);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_manager_move(System.IntPtr obj,   Efl.Ui.Focus.Direction direction);
    private static Efl.Ui.Focus.Object move(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction direction)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_move was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Ui.Focus.Object _ret_var = default(Efl.Ui.Focus.Object);
         try {
            _ret_var = ((ManagerSubConcrete)wrapper).Move( direction);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_focus_manager_move(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  direction);
      }
   }
   private efl_ui_focus_manager_move_delegate efl_ui_focus_manager_move_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_manager_request_move_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child,  [MarshalAs(UnmanagedType.U1)]  bool logical);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_manager_request_move(System.IntPtr obj,   Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child,  [MarshalAs(UnmanagedType.U1)]  bool logical);
    private static Efl.Ui.Focus.Object request_move(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction direction,  Efl.Ui.Focus.Object child,  bool logical)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_request_move was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        Efl.Ui.Focus.Object _ret_var = default(Efl.Ui.Focus.Object);
         try {
            _ret_var = ((ManagerSubConcrete)wrapper).MoveRequest( direction,  child,  logical);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_ui_focus_manager_request_move(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  direction,  child,  logical);
      }
   }
   private efl_ui_focus_manager_request_move_delegate efl_ui_focus_manager_request_move_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_manager_request_subchild_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_manager_request_subchild(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child);
    private static Efl.Ui.Focus.Object request_subchild(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Object child)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_request_subchild was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Ui.Focus.Object _ret_var = default(Efl.Ui.Focus.Object);
         try {
            _ret_var = ((ManagerSubConcrete)wrapper).RequestSubchild( child);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_focus_manager_request_subchild(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child);
      }
   }
   private efl_ui_focus_manager_request_subchild_delegate efl_ui_focus_manager_request_subchild_static_delegate;


    private delegate  System.IntPtr efl_ui_focus_manager_fetch_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_focus_manager_fetch(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child);
    private static  System.IntPtr fetch(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Object child)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_fetch was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Ui.Focus.Relations _ret_var = default(Efl.Ui.Focus.Relations);
         try {
            _ret_var = ((ManagerSubConcrete)wrapper).Fetch( child);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);
      } else {
         return efl_ui_focus_manager_fetch(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child);
      }
   }
   private efl_ui_focus_manager_fetch_delegate efl_ui_focus_manager_fetch_static_delegate;


    private delegate Efl.Ui.Focus.ManagerLogicalEndDetail_StructInternal efl_ui_focus_manager_logical_end_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Efl.Ui.Focus.ManagerLogicalEndDetail_StructInternal efl_ui_focus_manager_logical_end(System.IntPtr obj);
    private static Efl.Ui.Focus.ManagerLogicalEndDetail_StructInternal logical_end(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_logical_end was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.ManagerLogicalEndDetail _ret_var = default(Efl.Ui.Focus.ManagerLogicalEndDetail);
         try {
            _ret_var = ((ManagerSubConcrete)wrapper).LogicalEnd();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Ui.Focus.ManagerLogicalEndDetail_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_focus_manager_logical_end(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_manager_logical_end_delegate efl_ui_focus_manager_logical_end_static_delegate;


    private delegate  void efl_ui_focus_manager_reset_history_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_manager_reset_history(System.IntPtr obj);
    private static  void reset_history(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_reset_history was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ManagerSubConcrete)wrapper).ResetHistory();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_manager_reset_history(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_manager_reset_history_delegate efl_ui_focus_manager_reset_history_static_delegate;


    private delegate  void efl_ui_focus_manager_pop_history_stack_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_manager_pop_history_stack(System.IntPtr obj);
    private static  void pop_history_stack(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_pop_history_stack was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ManagerSubConcrete)wrapper).PopHistoryStack();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_manager_pop_history_stack(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_manager_pop_history_stack_delegate efl_ui_focus_manager_pop_history_stack_static_delegate;


    private delegate  void efl_ui_focus_manager_setup_on_first_touch_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object entry);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_manager_setup_on_first_touch(System.IntPtr obj,   Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object entry);
    private static  void setup_on_first_touch(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction direction,  Efl.Ui.Focus.Object entry)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_setup_on_first_touch was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ManagerSubConcrete)wrapper).SetupOnFirstTouch( direction,  entry);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_focus_manager_setup_on_first_touch(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  direction,  entry);
      }
   }
   private efl_ui_focus_manager_setup_on_first_touch_delegate efl_ui_focus_manager_setup_on_first_touch_static_delegate;


    private delegate  void efl_ui_focus_manager_dirty_logic_freeze_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_manager_dirty_logic_freeze(System.IntPtr obj);
    private static  void dirty_logic_freeze(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_dirty_logic_freeze was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ManagerSubConcrete)wrapper).FreezeDirtyLogic();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_manager_dirty_logic_freeze(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_manager_dirty_logic_freeze_delegate efl_ui_focus_manager_dirty_logic_freeze_static_delegate;


    private delegate  void efl_ui_focus_manager_dirty_logic_unfreeze_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_manager_dirty_logic_unfreeze(System.IntPtr obj);
    private static  void dirty_logic_unfreeze(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_dirty_logic_unfreeze was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ManagerSubConcrete)wrapper).DirtyLogicUnfreeze();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_manager_dirty_logic_unfreeze(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_manager_dirty_logic_unfreeze_delegate efl_ui_focus_manager_dirty_logic_unfreeze_static_delegate;
}
} } } 
