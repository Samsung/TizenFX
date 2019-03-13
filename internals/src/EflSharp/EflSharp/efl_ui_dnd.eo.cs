#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
[DndNativeInherit]
public interface Dnd : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Start a drag and drop process at the drag side. During dragging, there are three events emitted as belows: - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_ACCEPT - EFL_UI_DND_EVENT_DRAG_DONE</summary>
/// <param name="format">The data format</param>
/// <param name="data">The drag data</param>
/// <param name="action">Action when data is transferred</param>
/// <param name="icon_func">Function pointer to create icon</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns></returns>
 void DragStart( Efl.Ui.SelectionFormat format,  Eina.Slice data,  Efl.Ui.SelectionAction action,  Efl.Dnd.DragIconCreate icon_func,   uint seat);
   /// <summary>Set the action for the drag</summary>
/// <param name="action">Drag action</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns></returns>
 void SetDragAction( Efl.Ui.SelectionAction action,   uint seat);
   /// <summary>Cancel the on-going drag</summary>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns></returns>
 void DragCancel(  uint seat);
   /// <summary>Make the current object as drop target. There are four events emitted: - EFL_UI_DND_EVENT_DRAG_ENTER - EFL_UI_DND_EVENT_DRAG_LEAVE - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_DROP.</summary>
/// <param name="format">Accepted data format</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns></returns>
 void AddDropTarget( Efl.Ui.SelectionFormat format,   uint seat);
   /// <summary>Delete the dropable status from object</summary>
/// <param name="format">Accepted data format</param>
/// <param name="seat">Specified seat for multiple seats case.</param>
/// <returns></returns>
 void DelDropTarget( Efl.Ui.SelectionFormat format,   uint seat);
                  /// <summary>accept drag data</summary>
   event EventHandler<Efl.Ui.DndDragAcceptEvt_Args> DragAcceptEvt;
   /// <summary>drag is done (mouse up)</summary>
   event EventHandler DragDoneEvt;
   /// <summary>called when the drag object enters this object</summary>
   event EventHandler DragEnterEvt;
   /// <summary>called when the drag object leaves this object</summary>
   event EventHandler DragLeaveEvt;
   /// <summary>called when the drag object changes drag position</summary>
   event EventHandler<Efl.Ui.DndDragPosEvt_Args> DragPosEvt;
   /// <summary>called when the drag object dropped on this object</summary>
   event EventHandler<Efl.Ui.DndDragDropEvt_Args> DragDropEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Dnd.DragAcceptEvt"/>.</summary>
public class DndDragAcceptEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public bool arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Dnd.DragPosEvt"/>.</summary>
public class DndDragPosEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Dnd.DragPos arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Dnd.DragDropEvt"/>.</summary>
public class DndDragDropEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.SelectionData arg { get; set; }
}
/// <summary></summary>
sealed public class DndConcrete : 

Dnd
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (DndConcrete))
            return Efl.Ui.DndNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_dnd_mixin_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public DndConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~DndConcrete()
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
   public static DndConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new DndConcrete(obj.NativeHandle);
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
   private bool add_cpp_event_handler(string lib, string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(lib, key);
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
         IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
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
private static object DragAcceptEvtKey = new object();
   /// <summary>accept drag data</summary>
   public event EventHandler<Efl.Ui.DndDragAcceptEvt_Args> DragAcceptEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_ACCEPT";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_DragAcceptEvt_delegate)) {
               eventHandlers.AddHandler(DragAcceptEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_ACCEPT";
            if (remove_cpp_event_handler(key, this.evt_DragAcceptEvt_delegate)) { 
               eventHandlers.RemoveHandler(DragAcceptEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DragAcceptEvt.</summary>
   public void On_DragAcceptEvt(Efl.Ui.DndDragAcceptEvt_Args e)
   {
      EventHandler<Efl.Ui.DndDragAcceptEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.DndDragAcceptEvt_Args>)eventHandlers[DragAcceptEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DragAcceptEvt_delegate;
   private void on_DragAcceptEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.DndDragAcceptEvt_Args args = new Efl.Ui.DndDragAcceptEvt_Args();
      args.arg = (bool)Marshal.PtrToStructure(evt.Info, typeof(bool));
      try {
         On_DragAcceptEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DragDoneEvtKey = new object();
   /// <summary>drag is done (mouse up)</summary>
   public event EventHandler DragDoneEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_DONE";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_DragDoneEvt_delegate)) {
               eventHandlers.AddHandler(DragDoneEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_DONE";
            if (remove_cpp_event_handler(key, this.evt_DragDoneEvt_delegate)) { 
               eventHandlers.RemoveHandler(DragDoneEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DragDoneEvt.</summary>
   public void On_DragDoneEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[DragDoneEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DragDoneEvt_delegate;
   private void on_DragDoneEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_DragDoneEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DragEnterEvtKey = new object();
   /// <summary>called when the drag object enters this object</summary>
   public event EventHandler DragEnterEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_ENTER";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_DragEnterEvt_delegate)) {
               eventHandlers.AddHandler(DragEnterEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_ENTER";
            if (remove_cpp_event_handler(key, this.evt_DragEnterEvt_delegate)) { 
               eventHandlers.RemoveHandler(DragEnterEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DragEnterEvt.</summary>
   public void On_DragEnterEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[DragEnterEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DragEnterEvt_delegate;
   private void on_DragEnterEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_DragEnterEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DragLeaveEvtKey = new object();
   /// <summary>called when the drag object leaves this object</summary>
   public event EventHandler DragLeaveEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_LEAVE";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_DragLeaveEvt_delegate)) {
               eventHandlers.AddHandler(DragLeaveEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_LEAVE";
            if (remove_cpp_event_handler(key, this.evt_DragLeaveEvt_delegate)) { 
               eventHandlers.RemoveHandler(DragLeaveEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DragLeaveEvt.</summary>
   public void On_DragLeaveEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[DragLeaveEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DragLeaveEvt_delegate;
   private void on_DragLeaveEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_DragLeaveEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DragPosEvtKey = new object();
   /// <summary>called when the drag object changes drag position</summary>
   public event EventHandler<Efl.Ui.DndDragPosEvt_Args> DragPosEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_POS";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_DragPosEvt_delegate)) {
               eventHandlers.AddHandler(DragPosEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_POS";
            if (remove_cpp_event_handler(key, this.evt_DragPosEvt_delegate)) { 
               eventHandlers.RemoveHandler(DragPosEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DragPosEvt.</summary>
   public void On_DragPosEvt(Efl.Ui.DndDragPosEvt_Args e)
   {
      EventHandler<Efl.Ui.DndDragPosEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.DndDragPosEvt_Args>)eventHandlers[DragPosEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DragPosEvt_delegate;
   private void on_DragPosEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.DndDragPosEvt_Args args = new Efl.Ui.DndDragPosEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_DragPosEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object DragDropEvtKey = new object();
   /// <summary>called when the drag object dropped on this object</summary>
   public event EventHandler<Efl.Ui.DndDragDropEvt_Args> DragDropEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_DROP";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_DragDropEvt_delegate)) {
               eventHandlers.AddHandler(DragDropEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_DND_EVENT_DRAG_DROP";
            if (remove_cpp_event_handler(key, this.evt_DragDropEvt_delegate)) { 
               eventHandlers.RemoveHandler(DragDropEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DragDropEvt.</summary>
   public void On_DragDropEvt(Efl.Ui.DndDragDropEvt_Args e)
   {
      EventHandler<Efl.Ui.DndDragDropEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.DndDragDropEvt_Args>)eventHandlers[DragDropEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DragDropEvt_delegate;
   private void on_DragDropEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.DndDragDropEvt_Args args = new Efl.Ui.DndDragDropEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_DragDropEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_DragAcceptEvt_delegate = new Efl.EventCb(on_DragAcceptEvt_NativeCallback);
      evt_DragDoneEvt_delegate = new Efl.EventCb(on_DragDoneEvt_NativeCallback);
      evt_DragEnterEvt_delegate = new Efl.EventCb(on_DragEnterEvt_NativeCallback);
      evt_DragLeaveEvt_delegate = new Efl.EventCb(on_DragLeaveEvt_NativeCallback);
      evt_DragPosEvt_delegate = new Efl.EventCb(on_DragPosEvt_NativeCallback);
      evt_DragDropEvt_delegate = new Efl.EventCb(on_DragDropEvt_NativeCallback);
   }
   /// <summary>Start a drag and drop process at the drag side. During dragging, there are three events emitted as belows: - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_ACCEPT - EFL_UI_DND_EVENT_DRAG_DONE</summary>
   /// <param name="format">The data format</param>
   /// <param name="data">The drag data</param>
   /// <param name="action">Action when data is transferred</param>
   /// <param name="icon_func">Function pointer to create icon</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   public  void DragStart( Efl.Ui.SelectionFormat format,  Eina.Slice data,  Efl.Ui.SelectionAction action,  Efl.Dnd.DragIconCreate icon_func,   uint seat) {
                                                                                     GCHandle icon_func_handle = GCHandle.Alloc(icon_func);
            Efl.Ui.DndNativeInherit.efl_ui_dnd_drag_start_ptr.Value.Delegate(this.NativeHandle, format,  data,  action, GCHandle.ToIntPtr(icon_func_handle), Efl.Dnd.DragIconCreateWrapper.Cb, Efl.Eo.Globals.free_gchandle,  seat);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }
   /// <summary>Set the action for the drag</summary>
   /// <param name="action">Drag action</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   public  void SetDragAction( Efl.Ui.SelectionAction action,   uint seat) {
                                           Efl.Ui.DndNativeInherit.efl_ui_dnd_drag_action_set_ptr.Value.Delegate(this.NativeHandle, action,  seat);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Cancel the on-going drag</summary>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   public  void DragCancel(  uint seat) {
                         Efl.Ui.DndNativeInherit.efl_ui_dnd_drag_cancel_ptr.Value.Delegate(this.NativeHandle, seat);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Make the current object as drop target. There are four events emitted: - EFL_UI_DND_EVENT_DRAG_ENTER - EFL_UI_DND_EVENT_DRAG_LEAVE - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_DROP.</summary>
   /// <param name="format">Accepted data format</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   public  void AddDropTarget( Efl.Ui.SelectionFormat format,   uint seat) {
                                           Efl.Ui.DndNativeInherit.efl_ui_dnd_drop_target_add_ptr.Value.Delegate(this.NativeHandle, format,  seat);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Delete the dropable status from object</summary>
   /// <param name="format">Accepted data format</param>
   /// <param name="seat">Specified seat for multiple seats case.</param>
   /// <returns></returns>
   public  void DelDropTarget( Efl.Ui.SelectionFormat format,   uint seat) {
                                           Efl.Ui.DndNativeInherit.efl_ui_dnd_drop_target_del_ptr.Value.Delegate(this.NativeHandle, format,  seat);
      Eina.Error.RaiseIfUnhandledException();
                               }
}
public class DndNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_dnd_drag_start_static_delegate == null)
      efl_ui_dnd_drag_start_static_delegate = new efl_ui_dnd_drag_start_delegate(drag_start);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_dnd_drag_start"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drag_start_static_delegate)});
      if (efl_ui_dnd_drag_action_set_static_delegate == null)
      efl_ui_dnd_drag_action_set_static_delegate = new efl_ui_dnd_drag_action_set_delegate(drag_action_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_dnd_drag_action_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drag_action_set_static_delegate)});
      if (efl_ui_dnd_drag_cancel_static_delegate == null)
      efl_ui_dnd_drag_cancel_static_delegate = new efl_ui_dnd_drag_cancel_delegate(drag_cancel);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_dnd_drag_cancel"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drag_cancel_static_delegate)});
      if (efl_ui_dnd_drop_target_add_static_delegate == null)
      efl_ui_dnd_drop_target_add_static_delegate = new efl_ui_dnd_drop_target_add_delegate(drop_target_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_dnd_drop_target_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drop_target_add_static_delegate)});
      if (efl_ui_dnd_drop_target_del_static_delegate == null)
      efl_ui_dnd_drop_target_del_static_delegate = new efl_ui_dnd_drop_target_del_delegate(drop_target_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_dnd_drop_target_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drop_target_del_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.DndConcrete.efl_ui_dnd_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.DndConcrete.efl_ui_dnd_mixin_get();
   }


    private delegate  void efl_ui_dnd_drag_start_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionFormat format,   Eina.Slice data,   Efl.Ui.SelectionAction action,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,    uint seat);


    public delegate  void efl_ui_dnd_drag_start_api_delegate(System.IntPtr obj,   Efl.Ui.SelectionFormat format,   Eina.Slice data,   Efl.Ui.SelectionAction action,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,    uint seat);
    public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_start_api_delegate> efl_ui_dnd_drag_start_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_start_api_delegate>(_Module, "efl_ui_dnd_drag_start");
    private static  void drag_start(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  Efl.Ui.SelectionAction action, IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_drag_start was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                Efl.Dnd.DragIconCreateWrapper icon_func_wrapper = new Efl.Dnd.DragIconCreateWrapper(icon_func, icon_func_data, icon_func_free_cb);
               
         try {
            ((DndConcrete)wrapper).DragStart( format,  data,  action,  icon_func_wrapper.ManagedCb,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_ui_dnd_drag_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  format,  data,  action, icon_func_data, icon_func, icon_func_free_cb,  seat);
      }
   }
   private static efl_ui_dnd_drag_start_delegate efl_ui_dnd_drag_start_static_delegate;


    private delegate  void efl_ui_dnd_drag_action_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionAction action,    uint seat);


    public delegate  void efl_ui_dnd_drag_action_set_api_delegate(System.IntPtr obj,   Efl.Ui.SelectionAction action,    uint seat);
    public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_action_set_api_delegate> efl_ui_dnd_drag_action_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_action_set_api_delegate>(_Module, "efl_ui_dnd_drag_action_set");
    private static  void drag_action_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionAction action,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_drag_action_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((DndConcrete)wrapper).SetDragAction( action,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_dnd_drag_action_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  action,  seat);
      }
   }
   private static efl_ui_dnd_drag_action_set_delegate efl_ui_dnd_drag_action_set_static_delegate;


    private delegate  void efl_ui_dnd_drag_cancel_delegate(System.IntPtr obj, System.IntPtr pd,    uint seat);


    public delegate  void efl_ui_dnd_drag_cancel_api_delegate(System.IntPtr obj,    uint seat);
    public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_cancel_api_delegate> efl_ui_dnd_drag_cancel_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_cancel_api_delegate>(_Module, "efl_ui_dnd_drag_cancel");
    private static  void drag_cancel(System.IntPtr obj, System.IntPtr pd,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_drag_cancel was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((DndConcrete)wrapper).DragCancel( seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_dnd_drag_cancel_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private static efl_ui_dnd_drag_cancel_delegate efl_ui_dnd_drag_cancel_static_delegate;


    private delegate  void efl_ui_dnd_drop_target_add_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionFormat format,    uint seat);


    public delegate  void efl_ui_dnd_drop_target_add_api_delegate(System.IntPtr obj,   Efl.Ui.SelectionFormat format,    uint seat);
    public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drop_target_add_api_delegate> efl_ui_dnd_drop_target_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drop_target_add_api_delegate>(_Module, "efl_ui_dnd_drop_target_add");
    private static  void drop_target_add(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_drop_target_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((DndConcrete)wrapper).AddDropTarget( format,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_dnd_drop_target_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  format,  seat);
      }
   }
   private static efl_ui_dnd_drop_target_add_delegate efl_ui_dnd_drop_target_add_static_delegate;


    private delegate  void efl_ui_dnd_drop_target_del_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectionFormat format,    uint seat);


    public delegate  void efl_ui_dnd_drop_target_del_api_delegate(System.IntPtr obj,   Efl.Ui.SelectionFormat format,    uint seat);
    public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drop_target_del_api_delegate> efl_ui_dnd_drop_target_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drop_target_del_api_delegate>(_Module, "efl_ui_dnd_drop_target_del");
    private static  void drop_target_del(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format,   uint seat)
   {
      Eina.Log.Debug("function efl_ui_dnd_drop_target_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((DndConcrete)wrapper).DelDropTarget( format,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_dnd_drop_target_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  format,  seat);
      }
   }
   private static efl_ui_dnd_drop_target_del_delegate efl_ui_dnd_drop_target_del_static_delegate;
}
} } 
