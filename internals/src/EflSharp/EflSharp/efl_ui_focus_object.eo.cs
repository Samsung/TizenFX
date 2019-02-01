#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { namespace Focus { 
/// <summary>Functions of focusable objects.
/// 1.20</summary>
[ObjectConcreteNativeInherit]
public interface Object : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>The geometry used to calculate relationships between other objects.
/// 1.20</summary>
/// <returns>The geometry to use.
/// 1.20</returns>
Eina.Rect GetFocusGeometry();
   /// <summary>Returns whether the widget is currently focused or not.
/// 1.20</summary>
/// <returns>The focused state of the object
/// 1.20</returns>
bool GetFocus();
   /// <summary>This is called by the manager and should never be called by anyone else.
/// It can be used by configuring a focus object to adapt to any changes that are required.
/// 
/// The function emits the focus state events, if focus is different to the previous state.
/// 1.20</summary>
/// <param name="focus">The focused state of the object
/// 1.20</param>
/// <returns></returns>
 void SetFocus( bool focus);
   /// <summary>Describes which manager is used to register.
/// If an instance of this interface is the root of a manager, this instance should not have a manager where as root of this property. The other manager in this instance will be set as focused in the corresponding manager. This instance should be registered with its own manager as redirect.
/// 1.20</summary>
/// <returns>The manager object
/// 1.20</returns>
Efl.Ui.Focus.Manager GetFocusManager();
   /// <summary>Describes which logical parent is used by this object.
/// 1.20</summary>
/// <returns>The focus parent.
/// 1.20</returns>
Efl.Ui.Focus.Object GetFocusParent();
   /// <summary>set if a child of this element has focus or not.
/// 1.20</summary>
/// <returns></returns>
bool GetChildFocus();
   /// <summary>set if a child of this element has focus or not.
/// 1.20</summary>
/// <param name="child_focus"></param>
/// <returns></returns>
 void SetChildFocus( bool child_focus);
   /// <summary>Tells the object that its children will be queried soon by the given manager. The call will be a NOP if there is already a active preprare_logical call on this object
/// Deleting manager items in this call will result in undefined behaviour and may cause your system to crash.
/// 1.20</summary>
/// <returns></returns>
 void PrepareLogical();
   /// <summary>No description supplied.
/// 1.20</summary>
/// <returns></returns>
 void PrepareLogicalNoneRecursive();
   /// <summary>Virtual function handling focus in/out events on the widget
/// 1.20</summary>
/// <returns><c>true</c> if this widget can handle focus, <c>false</c> otherwise
/// 1.20</returns>
bool UpdateOnFocus();
                                 /// <summary>Emitted if the focus state has changed
   /// 1.20</summary>
   event EventHandler<Efl.Ui.Focus.ObjectFocusChangedEvt_Args> FocusChangedEvt;
   /// <summary>Emitted when a new manager is the parent for this object.
   /// 1.20</summary>
   event EventHandler<Efl.Ui.Focus.ObjectManagerChangedEvt_Args> ManagerChangedEvt;
   /// <summary>Emitted when a new logical parent should be used.
   /// 1.20</summary>
   event EventHandler<Efl.Ui.Focus.ObjectLogicalChangedEvt_Args> LogicalChangedEvt;
   /// <summary>Emitted if child_focus has changed
   /// 1.20</summary>
   event EventHandler<Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args> Child_focusChangedEvt;
   /// <summary>Emitted if focus geometry of this object has changed
   /// 1.20</summary>
   event EventHandler Focus_geometryChangedEvt;
   /// <summary>The geometry used to calculate relationships between other objects.
/// 1.20</summary>
   Eina.Rect FocusGeometry {
      get ;
   }
   /// <summary>Returns whether the widget is currently focused or not.
/// 1.20</summary>
   bool Focus {
      get ;
      set ;
   }
   /// <summary>Describes which manager is used to register.
/// If an instance of this interface is the root of a manager, this instance should not have a manager where as root of this property. The other manager in this instance will be set as focused in the corresponding manager. This instance should be registered with its own manager as redirect.
/// 1.20</summary>
   Efl.Ui.Focus.Manager FocusManager {
      get ;
   }
   /// <summary>Describes which logical parent is used by this object.
/// 1.20</summary>
   Efl.Ui.Focus.Object FocusParent {
      get ;
   }
   /// <summary>set if a child of this element has focus or not.
/// 1.20</summary>
   bool ChildFocus {
      get ;
      set ;
   }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.Object.FocusChangedEvt"/>.</summary>
public class ObjectFocusChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public bool arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.Object.ManagerChangedEvt"/>.</summary>
public class ObjectManagerChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.Focus.Manager arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.Object.LogicalChangedEvt"/>.</summary>
public class ObjectLogicalChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.Focus.Object arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.Object.Child_focusChangedEvt"/>.</summary>
public class ObjectChild_focusChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public bool arg { get; set; }
}
/// <summary>Functions of focusable objects.
/// 1.20</summary>
sealed public class ObjectConcrete : 

Object
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ObjectConcrete))
            return Efl.Ui.Focus.ObjectConcreteNativeInherit.GetEflClassStatic();
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
      efl_ui_focus_object_mixin_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ObjectConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ObjectConcrete()
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
   public static ObjectConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ObjectConcrete(obj.NativeHandle);
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
private static object FocusChangedEvtKey = new object();
   /// <summary>Emitted if the focus state has changed
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ObjectFocusChangedEvt_Args> FocusChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_CHANGED";
            if (add_cpp_event_handler(key, this.evt_FocusChangedEvt_delegate)) {
               eventHandlers.AddHandler(FocusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_FocusChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(FocusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FocusChangedEvt.</summary>
   public void On_FocusChangedEvt(Efl.Ui.Focus.ObjectFocusChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ObjectFocusChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ObjectFocusChangedEvt_Args>)eventHandlers[FocusChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FocusChangedEvt_delegate;
   private void on_FocusChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ObjectFocusChangedEvt_Args args = new Efl.Ui.Focus.ObjectFocusChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
      try {
         On_FocusChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ManagerChangedEvtKey = new object();
   /// <summary>Emitted when a new manager is the parent for this object.
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ObjectManagerChangedEvt_Args> ManagerChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_MANAGER_CHANGED";
            if (add_cpp_event_handler(key, this.evt_ManagerChangedEvt_delegate)) {
               eventHandlers.AddHandler(ManagerChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_MANAGER_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ManagerChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ManagerChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ManagerChangedEvt.</summary>
   public void On_ManagerChangedEvt(Efl.Ui.Focus.ObjectManagerChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ObjectManagerChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ObjectManagerChangedEvt_Args>)eventHandlers[ManagerChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ManagerChangedEvt_delegate;
   private void on_ManagerChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ObjectManagerChangedEvt_Args args = new Efl.Ui.Focus.ObjectManagerChangedEvt_Args();
      args.arg = new Efl.Ui.Focus.ManagerConcrete(evt.Info);
      try {
         On_ManagerChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object LogicalChangedEvtKey = new object();
   /// <summary>Emitted when a new logical parent should be used.
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ObjectLogicalChangedEvt_Args> LogicalChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_LOGICAL_CHANGED";
            if (add_cpp_event_handler(key, this.evt_LogicalChangedEvt_delegate)) {
               eventHandlers.AddHandler(LogicalChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_LOGICAL_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_LogicalChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(LogicalChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event LogicalChangedEvt.</summary>
   public void On_LogicalChangedEvt(Efl.Ui.Focus.ObjectLogicalChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ObjectLogicalChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ObjectLogicalChangedEvt_Args>)eventHandlers[LogicalChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_LogicalChangedEvt_delegate;
   private void on_LogicalChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ObjectLogicalChangedEvt_Args args = new Efl.Ui.Focus.ObjectLogicalChangedEvt_Args();
      args.arg = new Efl.Ui.Focus.ObjectConcrete(evt.Info);
      try {
         On_LogicalChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Child_focusChangedEvtKey = new object();
   /// <summary>Emitted if child_focus has changed
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args> Child_focusChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_CHILD_FOCUS_CHANGED";
            if (add_cpp_event_handler(key, this.evt_Child_focusChangedEvt_delegate)) {
               eventHandlers.AddHandler(Child_focusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_CHILD_FOCUS_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Child_focusChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Child_focusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Child_focusChangedEvt.</summary>
   public void On_Child_focusChangedEvt(Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args>)eventHandlers[Child_focusChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Child_focusChangedEvt_delegate;
   private void on_Child_focusChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args args = new Efl.Ui.Focus.ObjectChild_focusChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
      try {
         On_Child_focusChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Focus_geometryChangedEvtKey = new object();
   /// <summary>Emitted if focus geometry of this object has changed
   /// 1.20</summary>
   public event EventHandler Focus_geometryChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_GEOMETRY_CHANGED";
            if (add_cpp_event_handler(key, this.evt_Focus_geometryChangedEvt_delegate)) {
               eventHandlers.AddHandler(Focus_geometryChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_GEOMETRY_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Focus_geometryChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Focus_geometryChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Focus_geometryChangedEvt.</summary>
   public void On_Focus_geometryChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[Focus_geometryChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Focus_geometryChangedEvt_delegate;
   private void on_Focus_geometryChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_Focus_geometryChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_FocusChangedEvt_delegate = new Efl.EventCb(on_FocusChangedEvt_NativeCallback);
      evt_ManagerChangedEvt_delegate = new Efl.EventCb(on_ManagerChangedEvt_NativeCallback);
      evt_LogicalChangedEvt_delegate = new Efl.EventCb(on_LogicalChangedEvt_NativeCallback);
      evt_Child_focusChangedEvt_delegate = new Efl.EventCb(on_Child_focusChangedEvt_NativeCallback);
      evt_Focus_geometryChangedEvt_delegate = new Efl.EventCb(on_Focus_geometryChangedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern Eina.Rect_StructInternal efl_ui_focus_object_focus_geometry_get(System.IntPtr obj);
   /// <summary>The geometry used to calculate relationships between other objects.
   /// 1.20</summary>
   /// <returns>The geometry to use.
   /// 1.20</returns>
   public Eina.Rect GetFocusGeometry() {
       var _ret_var = efl_ui_focus_object_focus_geometry_get(Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_object_focus_get(System.IntPtr obj);
   /// <summary>Returns whether the widget is currently focused or not.
   /// 1.20</summary>
   /// <returns>The focused state of the object
   /// 1.20</returns>
   public bool GetFocus() {
       var _ret_var = efl_ui_focus_object_focus_get(Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_object_focus_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool focus);
   /// <summary>This is called by the manager and should never be called by anyone else.
   /// It can be used by configuring a focus object to adapt to any changes that are required.
   /// 
   /// The function emits the focus state events, if focus is different to the previous state.
   /// 1.20</summary>
   /// <param name="focus">The focused state of the object
   /// 1.20</param>
   /// <returns></returns>
   public  void SetFocus( bool focus) {
                         efl_ui_focus_object_focus_set(Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get(),  focus);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Manager efl_ui_focus_object_focus_manager_get(System.IntPtr obj);
   /// <summary>Describes which manager is used to register.
   /// If an instance of this interface is the root of a manager, this instance should not have a manager where as root of this property. The other manager in this instance will be set as focused in the corresponding manager. This instance should be registered with its own manager as redirect.
   /// 1.20</summary>
   /// <returns>The manager object
   /// 1.20</returns>
   public Efl.Ui.Focus.Manager GetFocusManager() {
       var _ret_var = efl_ui_focus_object_focus_manager_get(Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_object_focus_parent_get(System.IntPtr obj);
   /// <summary>Describes which logical parent is used by this object.
   /// 1.20</summary>
   /// <returns>The focus parent.
   /// 1.20</returns>
   public Efl.Ui.Focus.Object GetFocusParent() {
       var _ret_var = efl_ui_focus_object_focus_parent_get(Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_object_child_focus_get(System.IntPtr obj);
   /// <summary>set if a child of this element has focus or not.
   /// 1.20</summary>
   /// <returns></returns>
   public bool GetChildFocus() {
       var _ret_var = efl_ui_focus_object_child_focus_get(Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_object_child_focus_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool child_focus);
   /// <summary>set if a child of this element has focus or not.
   /// 1.20</summary>
   /// <param name="child_focus"></param>
   /// <returns></returns>
   public  void SetChildFocus( bool child_focus) {
                         efl_ui_focus_object_child_focus_set(Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get(),  child_focus);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_object_prepare_logical(System.IntPtr obj);
   /// <summary>Tells the object that its children will be queried soon by the given manager. The call will be a NOP if there is already a active preprare_logical call on this object
   /// Deleting manager items in this call will result in undefined behaviour and may cause your system to crash.
   /// 1.20</summary>
   /// <returns></returns>
   public  void PrepareLogical() {
       efl_ui_focus_object_prepare_logical(Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    private static extern  void efl_ui_focus_object_prepare_logical_none_recursive(System.IntPtr obj);
   /// <summary>No description supplied.
   /// 1.20</summary>
   /// <returns></returns>
   public  void PrepareLogicalNoneRecursive() {
       efl_ui_focus_object_prepare_logical_none_recursive(Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_object_on_focus_update(System.IntPtr obj);
   /// <summary>Virtual function handling focus in/out events on the widget
   /// 1.20</summary>
   /// <returns><c>true</c> if this widget can handle focus, <c>false</c> otherwise
   /// 1.20</returns>
   public bool UpdateOnFocus() {
       var _ret_var = efl_ui_focus_object_on_focus_update(Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The geometry used to calculate relationships between other objects.
/// 1.20</summary>
   public Eina.Rect FocusGeometry {
      get { return GetFocusGeometry(); }
   }
   /// <summary>Returns whether the widget is currently focused or not.
/// 1.20</summary>
   public bool Focus {
      get { return GetFocus(); }
      set { SetFocus( value); }
   }
   /// <summary>Describes which manager is used to register.
/// If an instance of this interface is the root of a manager, this instance should not have a manager where as root of this property. The other manager in this instance will be set as focused in the corresponding manager. This instance should be registered with its own manager as redirect.
/// 1.20</summary>
   public Efl.Ui.Focus.Manager FocusManager {
      get { return GetFocusManager(); }
   }
   /// <summary>Describes which logical parent is used by this object.
/// 1.20</summary>
   public Efl.Ui.Focus.Object FocusParent {
      get { return GetFocusParent(); }
   }
   /// <summary>set if a child of this element has focus or not.
/// 1.20</summary>
   public bool ChildFocus {
      get { return GetChildFocus(); }
      set { SetChildFocus( value); }
   }
}
public class ObjectConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_focus_object_focus_geometry_get_static_delegate = new efl_ui_focus_object_focus_geometry_get_delegate(focus_geometry_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_focus_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_geometry_get_static_delegate)});
      efl_ui_focus_object_focus_get_static_delegate = new efl_ui_focus_object_focus_get_delegate(focus_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_get_static_delegate)});
      efl_ui_focus_object_focus_set_static_delegate = new efl_ui_focus_object_focus_set_delegate(focus_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_set_static_delegate)});
      efl_ui_focus_object_focus_manager_get_static_delegate = new efl_ui_focus_object_focus_manager_get_delegate(focus_manager_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_focus_manager_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_manager_get_static_delegate)});
      efl_ui_focus_object_focus_parent_get_static_delegate = new efl_ui_focus_object_focus_parent_get_delegate(focus_parent_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_focus_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_parent_get_static_delegate)});
      efl_ui_focus_object_child_focus_get_static_delegate = new efl_ui_focus_object_child_focus_get_delegate(child_focus_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_child_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_child_focus_get_static_delegate)});
      efl_ui_focus_object_child_focus_set_static_delegate = new efl_ui_focus_object_child_focus_set_delegate(child_focus_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_child_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_child_focus_set_static_delegate)});
      efl_ui_focus_object_prepare_logical_static_delegate = new efl_ui_focus_object_prepare_logical_delegate(prepare_logical);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_prepare_logical"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_prepare_logical_static_delegate)});
      efl_ui_focus_object_prepare_logical_none_recursive_static_delegate = new efl_ui_focus_object_prepare_logical_none_recursive_delegate(prepare_logical_none_recursive);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_prepare_logical_none_recursive"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_prepare_logical_none_recursive_static_delegate)});
      efl_ui_focus_object_on_focus_update_static_delegate = new efl_ui_focus_object_on_focus_update_delegate(on_focus_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_object_on_focus_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_on_focus_update_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get();
   }


    private delegate Eina.Rect_StructInternal efl_ui_focus_object_focus_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Eina.Rect_StructInternal efl_ui_focus_object_focus_geometry_get(System.IntPtr obj);
    private static Eina.Rect_StructInternal focus_geometry_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_focus_geometry_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetFocusGeometry();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_focus_object_focus_geometry_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_focus_geometry_get_delegate efl_ui_focus_object_focus_geometry_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_object_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_object_focus_get(System.IntPtr obj);
    private static bool focus_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_focus_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_object_focus_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_focus_get_delegate efl_ui_focus_object_focus_get_static_delegate;


    private delegate  void efl_ui_focus_object_focus_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool focus);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_object_focus_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool focus);
    private static  void focus_set(System.IntPtr obj, System.IntPtr pd,  bool focus)
   {
      Eina.Log.Debug("function efl_ui_focus_object_focus_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ObjectConcrete)wrapper).SetFocus( focus);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_object_focus_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  focus);
      }
   }
   private efl_ui_focus_object_focus_set_delegate efl_ui_focus_object_focus_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Manager efl_ui_focus_object_focus_manager_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Manager efl_ui_focus_object_focus_manager_get(System.IntPtr obj);
    private static Efl.Ui.Focus.Manager focus_manager_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_focus_manager_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Manager _ret_var = default(Efl.Ui.Focus.Manager);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetFocusManager();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_object_focus_manager_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_focus_manager_get_delegate efl_ui_focus_object_focus_manager_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_object_focus_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_object_focus_parent_get(System.IntPtr obj);
    private static Efl.Ui.Focus.Object focus_parent_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_focus_parent_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Object _ret_var = default(Efl.Ui.Focus.Object);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetFocusParent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_object_focus_parent_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_focus_parent_get_delegate efl_ui_focus_object_focus_parent_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_object_child_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_object_child_focus_get(System.IntPtr obj);
    private static bool child_focus_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_child_focus_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ObjectConcrete)wrapper).GetChildFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_object_child_focus_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_child_focus_get_delegate efl_ui_focus_object_child_focus_get_static_delegate;


    private delegate  void efl_ui_focus_object_child_focus_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool child_focus);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_object_child_focus_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool child_focus);
    private static  void child_focus_set(System.IntPtr obj, System.IntPtr pd,  bool child_focus)
   {
      Eina.Log.Debug("function efl_ui_focus_object_child_focus_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ObjectConcrete)wrapper).SetChildFocus( child_focus);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_object_child_focus_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child_focus);
      }
   }
   private efl_ui_focus_object_child_focus_set_delegate efl_ui_focus_object_child_focus_set_static_delegate;


    private delegate  void efl_ui_focus_object_prepare_logical_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_object_prepare_logical(System.IntPtr obj);
    private static  void prepare_logical(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_prepare_logical was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ObjectConcrete)wrapper).PrepareLogical();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_object_prepare_logical(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_prepare_logical_delegate efl_ui_focus_object_prepare_logical_static_delegate;


    private delegate  void efl_ui_focus_object_prepare_logical_none_recursive_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_object_prepare_logical_none_recursive(System.IntPtr obj);
    private static  void prepare_logical_none_recursive(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_prepare_logical_none_recursive was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ObjectConcrete)wrapper).PrepareLogicalNoneRecursive();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_object_prepare_logical_none_recursive(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_prepare_logical_none_recursive_delegate efl_ui_focus_object_prepare_logical_none_recursive_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_object_on_focus_update_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_object_on_focus_update(System.IntPtr obj);
    private static bool on_focus_update(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_object_on_focus_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ObjectConcrete)wrapper).UpdateOnFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_object_on_focus_update(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_object_on_focus_update_delegate efl_ui_focus_object_on_focus_update_static_delegate;
}
} } } 
