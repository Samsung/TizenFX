#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary></summary>
[ScrollbarNativeInherit]
public interface Scrollbar : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Scrollbar visibility policy</summary>
/// <param name="hbar">Horizontal scrollbar</param>
/// <param name="vbar">Vertical scrollbar</param>
/// <returns></returns>
 void GetBarMode( out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar);
   /// <summary>Scrollbar visibility policy</summary>
/// <param name="hbar">Horizontal scrollbar</param>
/// <param name="vbar">Vertical scrollbar</param>
/// <returns></returns>
 void SetBarMode( Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar);
   /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
/// <param name="width">Value between 0.0 and 1.0</param>
/// <param name="height">Value between 0.0 and 1.0</param>
/// <returns></returns>
 void GetBarSize( out double width,  out double height);
   /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
/// <param name="posx">Value between 0.0 and 1.0</param>
/// <param name="posy">Value between 0.0 and 1.0</param>
/// <returns></returns>
 void GetBarPosition( out double posx,  out double posy);
   /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
/// <param name="posx">Value between 0.0 and 1.0</param>
/// <param name="posy">Value between 0.0 and 1.0</param>
/// <returns></returns>
 void SetBarPosition( double posx,  double posy);
   /// <summary>Update bar visibility.
/// The object will call this function whenever the bar need to be shown or hidden.</summary>
/// <returns></returns>
 void UpdateBarVisibility();
                     /// <summary>Called when bar is pressed</summary>
   event EventHandler<Efl.Ui.ScrollbarBarPressEvt_Args> BarPressEvt;
   /// <summary>Called when bar is unpressed</summary>
   event EventHandler<Efl.Ui.ScrollbarBarUnpressEvt_Args> BarUnpressEvt;
   /// <summary>Called when bar is dragged</summary>
   event EventHandler<Efl.Ui.ScrollbarBarDragEvt_Args> BarDragEvt;
   /// <summary>Called when bar size is changed</summary>
   event EventHandler BarSizeChangedEvt;
   /// <summary>Called when bar position is changed</summary>
   event EventHandler BarPosChangedEvt;
   /// <summary>Callend when bar is shown</summary>
   event EventHandler<Efl.Ui.ScrollbarBarShowEvt_Args> BarShowEvt;
   /// <summary>Called when bar is hidden</summary>
   event EventHandler<Efl.Ui.ScrollbarBarHideEvt_Args> BarHideEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Scrollbar.BarPressEvt"/>.</summary>
public class ScrollbarBarPressEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.ScrollbarDirection arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Scrollbar.BarUnpressEvt"/>.</summary>
public class ScrollbarBarUnpressEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.ScrollbarDirection arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Scrollbar.BarDragEvt"/>.</summary>
public class ScrollbarBarDragEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.ScrollbarDirection arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Scrollbar.BarShowEvt"/>.</summary>
public class ScrollbarBarShowEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.ScrollbarDirection arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Scrollbar.BarHideEvt"/>.</summary>
public class ScrollbarBarHideEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.ScrollbarDirection arg { get; set; }
}
/// <summary></summary>
sealed public class ScrollbarConcrete : 

Scrollbar
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ScrollbarConcrete))
            return Efl.Ui.ScrollbarNativeInherit.GetEflClassStatic();
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_ui_scrollbar_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public ScrollbarConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~ScrollbarConcrete()
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
   public static ScrollbarConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ScrollbarConcrete(obj.NativeHandle);
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
         IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
private static object BarPressEvtKey = new object();
   /// <summary>Called when bar is pressed</summary>
   public event EventHandler<Efl.Ui.ScrollbarBarPressEvt_Args> BarPressEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_BarPressEvt_delegate)) {
               eventHandlers.AddHandler(BarPressEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
            if (remove_cpp_event_handler(key, this.evt_BarPressEvt_delegate)) { 
               eventHandlers.RemoveHandler(BarPressEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event BarPressEvt.</summary>
   public void On_BarPressEvt(Efl.Ui.ScrollbarBarPressEvt_Args e)
   {
      EventHandler<Efl.Ui.ScrollbarBarPressEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ScrollbarBarPressEvt_Args>)eventHandlers[BarPressEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_BarPressEvt_delegate;
   private void on_BarPressEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ScrollbarBarPressEvt_Args args = new Efl.Ui.ScrollbarBarPressEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
      try {
         On_BarPressEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object BarUnpressEvtKey = new object();
   /// <summary>Called when bar is unpressed</summary>
   public event EventHandler<Efl.Ui.ScrollbarBarUnpressEvt_Args> BarUnpressEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_BarUnpressEvt_delegate)) {
               eventHandlers.AddHandler(BarUnpressEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
            if (remove_cpp_event_handler(key, this.evt_BarUnpressEvt_delegate)) { 
               eventHandlers.RemoveHandler(BarUnpressEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event BarUnpressEvt.</summary>
   public void On_BarUnpressEvt(Efl.Ui.ScrollbarBarUnpressEvt_Args e)
   {
      EventHandler<Efl.Ui.ScrollbarBarUnpressEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ScrollbarBarUnpressEvt_Args>)eventHandlers[BarUnpressEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_BarUnpressEvt_delegate;
   private void on_BarUnpressEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ScrollbarBarUnpressEvt_Args args = new Efl.Ui.ScrollbarBarUnpressEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
      try {
         On_BarUnpressEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object BarDragEvtKey = new object();
   /// <summary>Called when bar is dragged</summary>
   public event EventHandler<Efl.Ui.ScrollbarBarDragEvt_Args> BarDragEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_BarDragEvt_delegate)) {
               eventHandlers.AddHandler(BarDragEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
            if (remove_cpp_event_handler(key, this.evt_BarDragEvt_delegate)) { 
               eventHandlers.RemoveHandler(BarDragEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event BarDragEvt.</summary>
   public void On_BarDragEvt(Efl.Ui.ScrollbarBarDragEvt_Args e)
   {
      EventHandler<Efl.Ui.ScrollbarBarDragEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ScrollbarBarDragEvt_Args>)eventHandlers[BarDragEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_BarDragEvt_delegate;
   private void on_BarDragEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ScrollbarBarDragEvt_Args args = new Efl.Ui.ScrollbarBarDragEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
      try {
         On_BarDragEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object BarSizeChangedEvtKey = new object();
   /// <summary>Called when bar size is changed</summary>
   public event EventHandler BarSizeChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_BarSizeChangedEvt_delegate)) {
               eventHandlers.AddHandler(BarSizeChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_BarSizeChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(BarSizeChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event BarSizeChangedEvt.</summary>
   public void On_BarSizeChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[BarSizeChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_BarSizeChangedEvt_delegate;
   private void on_BarSizeChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_BarSizeChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object BarPosChangedEvtKey = new object();
   /// <summary>Called when bar position is changed</summary>
   public event EventHandler BarPosChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_BarPosChangedEvt_delegate)) {
               eventHandlers.AddHandler(BarPosChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_BarPosChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(BarPosChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event BarPosChangedEvt.</summary>
   public void On_BarPosChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[BarPosChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_BarPosChangedEvt_delegate;
   private void on_BarPosChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_BarPosChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object BarShowEvtKey = new object();
   /// <summary>Callend when bar is shown</summary>
   public event EventHandler<Efl.Ui.ScrollbarBarShowEvt_Args> BarShowEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_BarShowEvt_delegate)) {
               eventHandlers.AddHandler(BarShowEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
            if (remove_cpp_event_handler(key, this.evt_BarShowEvt_delegate)) { 
               eventHandlers.RemoveHandler(BarShowEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event BarShowEvt.</summary>
   public void On_BarShowEvt(Efl.Ui.ScrollbarBarShowEvt_Args e)
   {
      EventHandler<Efl.Ui.ScrollbarBarShowEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ScrollbarBarShowEvt_Args>)eventHandlers[BarShowEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_BarShowEvt_delegate;
   private void on_BarShowEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ScrollbarBarShowEvt_Args args = new Efl.Ui.ScrollbarBarShowEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
      try {
         On_BarShowEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object BarHideEvtKey = new object();
   /// <summary>Called when bar is hidden</summary>
   public event EventHandler<Efl.Ui.ScrollbarBarHideEvt_Args> BarHideEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_BarHideEvt_delegate)) {
               eventHandlers.AddHandler(BarHideEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
            if (remove_cpp_event_handler(key, this.evt_BarHideEvt_delegate)) { 
               eventHandlers.RemoveHandler(BarHideEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event BarHideEvt.</summary>
   public void On_BarHideEvt(Efl.Ui.ScrollbarBarHideEvt_Args e)
   {
      EventHandler<Efl.Ui.ScrollbarBarHideEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ScrollbarBarHideEvt_Args>)eventHandlers[BarHideEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_BarHideEvt_delegate;
   private void on_BarHideEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ScrollbarBarHideEvt_Args args = new Efl.Ui.ScrollbarBarHideEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
      try {
         On_BarHideEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_BarPressEvt_delegate = new Efl.EventCb(on_BarPressEvt_NativeCallback);
      evt_BarUnpressEvt_delegate = new Efl.EventCb(on_BarUnpressEvt_NativeCallback);
      evt_BarDragEvt_delegate = new Efl.EventCb(on_BarDragEvt_NativeCallback);
      evt_BarSizeChangedEvt_delegate = new Efl.EventCb(on_BarSizeChangedEvt_NativeCallback);
      evt_BarPosChangedEvt_delegate = new Efl.EventCb(on_BarPosChangedEvt_NativeCallback);
      evt_BarShowEvt_delegate = new Efl.EventCb(on_BarShowEvt_NativeCallback);
      evt_BarHideEvt_delegate = new Efl.EventCb(on_BarHideEvt_NativeCallback);
   }
   /// <summary>Scrollbar visibility policy</summary>
   /// <param name="hbar">Horizontal scrollbar</param>
   /// <param name="vbar">Vertical scrollbar</param>
   /// <returns></returns>
   public  void GetBarMode( out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar) {
                                           Efl.Ui.ScrollbarNativeInherit.efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate(this.NativeHandle, out hbar,  out vbar);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Scrollbar visibility policy</summary>
   /// <param name="hbar">Horizontal scrollbar</param>
   /// <param name="vbar">Vertical scrollbar</param>
   /// <returns></returns>
   public  void SetBarMode( Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar) {
                                           Efl.Ui.ScrollbarNativeInherit.efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate(this.NativeHandle, hbar,  vbar);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
   /// <param name="width">Value between 0.0 and 1.0</param>
   /// <param name="height">Value between 0.0 and 1.0</param>
   /// <returns></returns>
   public  void GetBarSize( out double width,  out double height) {
                                           Efl.Ui.ScrollbarNativeInherit.efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate(this.NativeHandle, out width,  out height);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
   /// <param name="posx">Value between 0.0 and 1.0</param>
   /// <param name="posy">Value between 0.0 and 1.0</param>
   /// <returns></returns>
   public  void GetBarPosition( out double posx,  out double posy) {
                                           Efl.Ui.ScrollbarNativeInherit.efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate(this.NativeHandle, out posx,  out posy);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
   /// <param name="posx">Value between 0.0 and 1.0</param>
   /// <param name="posy">Value between 0.0 and 1.0</param>
   /// <returns></returns>
   public  void SetBarPosition( double posx,  double posy) {
                                           Efl.Ui.ScrollbarNativeInherit.efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate(this.NativeHandle, posx,  posy);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Update bar visibility.
   /// The object will call this function whenever the bar need to be shown or hidden.</summary>
   /// <returns></returns>
   public  void UpdateBarVisibility() {
       Efl.Ui.ScrollbarNativeInherit.efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
       }
}
public class ScrollbarNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_scrollbar_bar_mode_get_static_delegate == null)
      efl_ui_scrollbar_bar_mode_get_static_delegate = new efl_ui_scrollbar_bar_mode_get_delegate(bar_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_get_static_delegate)});
      if (efl_ui_scrollbar_bar_mode_set_static_delegate == null)
      efl_ui_scrollbar_bar_mode_set_static_delegate = new efl_ui_scrollbar_bar_mode_set_delegate(bar_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_set_static_delegate)});
      if (efl_ui_scrollbar_bar_size_get_static_delegate == null)
      efl_ui_scrollbar_bar_size_get_static_delegate = new efl_ui_scrollbar_bar_size_get_delegate(bar_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_size_get_static_delegate)});
      if (efl_ui_scrollbar_bar_position_get_static_delegate == null)
      efl_ui_scrollbar_bar_position_get_static_delegate = new efl_ui_scrollbar_bar_position_get_delegate(bar_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_get_static_delegate)});
      if (efl_ui_scrollbar_bar_position_set_static_delegate == null)
      efl_ui_scrollbar_bar_position_set_static_delegate = new efl_ui_scrollbar_bar_position_set_delegate(bar_position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_set_static_delegate)});
      if (efl_ui_scrollbar_bar_visibility_update_static_delegate == null)
      efl_ui_scrollbar_bar_visibility_update_static_delegate = new efl_ui_scrollbar_bar_visibility_update_delegate(bar_visibility_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_visibility_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_visibility_update_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.ScrollbarConcrete.efl_ui_scrollbar_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.ScrollbarConcrete.efl_ui_scrollbar_interface_get();
   }


    private delegate  void efl_ui_scrollbar_bar_mode_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.Ui.ScrollbarMode hbar,   out Efl.Ui.ScrollbarMode vbar);


    public delegate  void efl_ui_scrollbar_bar_mode_get_api_delegate(System.IntPtr obj,   out Efl.Ui.ScrollbarMode hbar,   out Efl.Ui.ScrollbarMode vbar);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate> efl_ui_scrollbar_bar_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate>(_Module, "efl_ui_scrollbar_bar_mode_get");
    private static  void bar_mode_get(System.IntPtr obj, System.IntPtr pd,  out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar)
   {
      Eina.Log.Debug("function efl_ui_scrollbar_bar_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           hbar = default(Efl.Ui.ScrollbarMode);      vbar = default(Efl.Ui.ScrollbarMode);                     
         try {
            ((Scrollbar)wrapper).GetBarMode( out hbar,  out vbar);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out hbar,  out vbar);
      }
   }
   private static efl_ui_scrollbar_bar_mode_get_delegate efl_ui_scrollbar_bar_mode_get_static_delegate;


    private delegate  void efl_ui_scrollbar_bar_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ScrollbarMode hbar,   Efl.Ui.ScrollbarMode vbar);


    public delegate  void efl_ui_scrollbar_bar_mode_set_api_delegate(System.IntPtr obj,   Efl.Ui.ScrollbarMode hbar,   Efl.Ui.ScrollbarMode vbar);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate> efl_ui_scrollbar_bar_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate>(_Module, "efl_ui_scrollbar_bar_mode_set");
    private static  void bar_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar)
   {
      Eina.Log.Debug("function efl_ui_scrollbar_bar_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Scrollbar)wrapper).SetBarMode( hbar,  vbar);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hbar,  vbar);
      }
   }
   private static efl_ui_scrollbar_bar_mode_set_delegate efl_ui_scrollbar_bar_mode_set_static_delegate;


    private delegate  void efl_ui_scrollbar_bar_size_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double width,   out double height);


    public delegate  void efl_ui_scrollbar_bar_size_get_api_delegate(System.IntPtr obj,   out double width,   out double height);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate> efl_ui_scrollbar_bar_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate>(_Module, "efl_ui_scrollbar_bar_size_get");
    private static  void bar_size_get(System.IntPtr obj, System.IntPtr pd,  out double width,  out double height)
   {
      Eina.Log.Debug("function efl_ui_scrollbar_bar_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           width = default(double);      height = default(double);                     
         try {
            ((Scrollbar)wrapper).GetBarSize( out width,  out height);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out width,  out height);
      }
   }
   private static efl_ui_scrollbar_bar_size_get_delegate efl_ui_scrollbar_bar_size_get_static_delegate;


    private delegate  void efl_ui_scrollbar_bar_position_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double posx,   out double posy);


    public delegate  void efl_ui_scrollbar_bar_position_get_api_delegate(System.IntPtr obj,   out double posx,   out double posy);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate> efl_ui_scrollbar_bar_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate>(_Module, "efl_ui_scrollbar_bar_position_get");
    private static  void bar_position_get(System.IntPtr obj, System.IntPtr pd,  out double posx,  out double posy)
   {
      Eina.Log.Debug("function efl_ui_scrollbar_bar_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           posx = default(double);      posy = default(double);                     
         try {
            ((Scrollbar)wrapper).GetBarPosition( out posx,  out posy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out posx,  out posy);
      }
   }
   private static efl_ui_scrollbar_bar_position_get_delegate efl_ui_scrollbar_bar_position_get_static_delegate;


    private delegate  void efl_ui_scrollbar_bar_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   double posx,   double posy);


    public delegate  void efl_ui_scrollbar_bar_position_set_api_delegate(System.IntPtr obj,   double posx,   double posy);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate> efl_ui_scrollbar_bar_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate>(_Module, "efl_ui_scrollbar_bar_position_set");
    private static  void bar_position_set(System.IntPtr obj, System.IntPtr pd,  double posx,  double posy)
   {
      Eina.Log.Debug("function efl_ui_scrollbar_bar_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Scrollbar)wrapper).SetBarPosition( posx,  posy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  posx,  posy);
      }
   }
   private static efl_ui_scrollbar_bar_position_set_delegate efl_ui_scrollbar_bar_position_set_static_delegate;


    private delegate  void efl_ui_scrollbar_bar_visibility_update_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_scrollbar_bar_visibility_update_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_visibility_update_api_delegate> efl_ui_scrollbar_bar_visibility_update_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_visibility_update_api_delegate>(_Module, "efl_ui_scrollbar_bar_visibility_update");
    private static  void bar_visibility_update(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollbar_bar_visibility_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Scrollbar)wrapper).UpdateBarVisibility();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_scrollbar_bar_visibility_update_delegate efl_ui_scrollbar_bar_visibility_update_static_delegate;
}
} } 
namespace Efl { namespace Ui { 
/// <summary></summary>
public enum ScrollbarMode
{
/// <summary>Visible if necessary</summary>
Auto = 0,
/// <summary>Always visible</summary>
On = 1,
/// <summary>Always invisible</summary>
Off = 2,
/// <summary>For internal use only</summary>
Last = 3,
}
} } 
namespace Efl { namespace Ui { 
/// <summary></summary>
public enum ScrollbarDirection
{
/// <summary></summary>
Horizontal = 0,
/// <summary></summary>
Vertical = 1,
/// <summary></summary>
Last = 2,
}
} } 
