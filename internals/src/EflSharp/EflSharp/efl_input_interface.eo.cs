#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Input { 
/// <summary>An object implementing this interface can send pointer events.
/// Windows and canvas objects may send input events.
/// 
/// A &quot;pointer&quot; refers to the main pointing device, which could be a mouse, trackpad, finger, pen, etc... In other words, the finger id in any pointer event will always be 0.
/// 
/// A &quot;finger&quot; refers to a single point of input, usually in an absolute coordinates input device, and that can support more than one input position at at time (think multi-touch screens). The first finger (id 0) is sent along with a pointer event, so be careful to not handle those events twice. Note that if the input device can support &quot;hovering&quot;, it is entirely possible to receive move events without down coming first.
/// 
/// A &quot;key&quot; is a key press from a keyboard or equivalent type of input device. Long, repeated, key presses will always happen like this: down...up,down...up,down...up (not down...up or down...down...down...up).
/// 1.19</summary>
[InterfaceNativeInherit]
public interface Interface : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Check if input events from a given seat is enabled.
/// 1.19</summary>
/// <param name="seat">The seat to act on.
/// 1.19</param>
/// <returns><c>true</c> to enable events for a seat or <c>false</c> otherwise.
/// 1.19</returns>
bool GetSeatEventFilter( Efl.Input.Device seat);
   /// <summary>Add or remove a given seat to the filter list. If the filter list is empty this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is in the list.
/// 1.19</summary>
/// <param name="seat">The seat to act on.
/// 1.19</param>
/// <param name="enable"><c>true</c> to enable events for a seat or <c>false</c> otherwise.
/// 1.19</param>
/// <returns></returns>
 void SetSeatEventFilter( Efl.Input.Device seat,  bool enable);
         /// <summary>Main pointer move (current and previous positions are known).
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfacePointerMoveEvt_Args> PointerMoveEvt;
   /// <summary>Main pointer button pressed (button id is known).
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfacePointerDownEvt_Args> PointerDownEvt;
   /// <summary>Main pointer button released (button id is known).
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfacePointerUpEvt_Args> PointerUpEvt;
   /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfacePointerCancelEvt_Args> PointerCancelEvt;
   /// <summary>Pointer entered a window or a widget.
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfacePointerInEvt_Args> PointerInEvt;
   /// <summary>Pointer left a window or a widget.
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfacePointerOutEvt_Args> PointerOutEvt;
   /// <summary>Mouse wheel event.
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfacePointerWheelEvt_Args> PointerWheelEvt;
   /// <summary>Pen or other axis event update.
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfacePointerAxisEvt_Args> PointerAxisEvt;
   /// <summary>Finger moved (current and previous positions are known).
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfaceFingerMoveEvt_Args> FingerMoveEvt;
   /// <summary>Finger pressed (finger id is known).
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfaceFingerDownEvt_Args> FingerDownEvt;
   /// <summary>Finger released (finger id is known).
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfaceFingerUpEvt_Args> FingerUpEvt;
   /// <summary>Keyboard key press.
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfaceKeyDownEvt_Args> KeyDownEvt;
   /// <summary>Keyboard key release.
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfaceKeyUpEvt_Args> KeyUpEvt;
   /// <summary>All input events are on hold or resumed.
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfaceHoldEvt_Args> HoldEvt;
   /// <summary>A focus in event.
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfaceFocusInEvt_Args> FocusInEvt;
   /// <summary>A focus out event.
   /// 1.19</summary>
   event EventHandler<Efl.Input.InterfaceFocusOutEvt_Args> FocusOutEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.PointerMoveEvt"/>.</summary>
public class InterfacePointerMoveEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.PointerDownEvt"/>.</summary>
public class InterfacePointerDownEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.PointerUpEvt"/>.</summary>
public class InterfacePointerUpEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.PointerCancelEvt"/>.</summary>
public class InterfacePointerCancelEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.PointerInEvt"/>.</summary>
public class InterfacePointerInEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.PointerOutEvt"/>.</summary>
public class InterfacePointerOutEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.PointerWheelEvt"/>.</summary>
public class InterfacePointerWheelEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.PointerAxisEvt"/>.</summary>
public class InterfacePointerAxisEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.FingerMoveEvt"/>.</summary>
public class InterfaceFingerMoveEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.FingerDownEvt"/>.</summary>
public class InterfaceFingerDownEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.FingerUpEvt"/>.</summary>
public class InterfaceFingerUpEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Pointer arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.KeyDownEvt"/>.</summary>
public class InterfaceKeyDownEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Key arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.KeyUpEvt"/>.</summary>
public class InterfaceKeyUpEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Key arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.HoldEvt"/>.</summary>
public class InterfaceHoldEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Hold arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.FocusInEvt"/>.</summary>
public class InterfaceFocusInEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Focus arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Input.Interface.FocusOutEvt"/>.</summary>
public class InterfaceFocusOutEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Input.Focus arg { get; set; }
}
/// <summary>An object implementing this interface can send pointer events.
/// Windows and canvas objects may send input events.
/// 
/// A &quot;pointer&quot; refers to the main pointing device, which could be a mouse, trackpad, finger, pen, etc... In other words, the finger id in any pointer event will always be 0.
/// 
/// A &quot;finger&quot; refers to a single point of input, usually in an absolute coordinates input device, and that can support more than one input position at at time (think multi-touch screens). The first finger (id 0) is sent along with a pointer event, so be careful to not handle those events twice. Note that if the input device can support &quot;hovering&quot;, it is entirely possible to receive move events without down coming first.
/// 
/// A &quot;key&quot; is a key press from a keyboard or equivalent type of input device. Long, repeated, key presses will always happen like this: down...up,down...up,down...up (not down...up or down...down...down...up).
/// 1.19</summary>
sealed public class InterfaceConcrete : 

Interface
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (InterfaceConcrete))
            return Efl.Input.InterfaceNativeInherit.GetEflClassStatic();
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_input_interface_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public InterfaceConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~InterfaceConcrete()
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
   public static InterfaceConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new InterfaceConcrete(obj.NativeHandle);
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
         IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
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
private static object PointerMoveEvtKey = new object();
   /// <summary>Main pointer move (current and previous positions are known).
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerMoveEvt_Args> PointerMoveEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_MOVE";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerMoveEvt_delegate)) {
               eventHandlers.AddHandler(PointerMoveEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_MOVE";
            if (remove_cpp_event_handler(key, this.evt_PointerMoveEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerMoveEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerMoveEvt.</summary>
   public void On_PointerMoveEvt(Efl.Input.InterfacePointerMoveEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerMoveEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerMoveEvt_Args>)eventHandlers[PointerMoveEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerMoveEvt_delegate;
   private void on_PointerMoveEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerMoveEvt_Args args = new Efl.Input.InterfacePointerMoveEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerMoveEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerDownEvtKey = new object();
   /// <summary>Main pointer button pressed (button id is known).
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerDownEvt_Args> PointerDownEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_DOWN";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerDownEvt_delegate)) {
               eventHandlers.AddHandler(PointerDownEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_DOWN";
            if (remove_cpp_event_handler(key, this.evt_PointerDownEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerDownEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerDownEvt.</summary>
   public void On_PointerDownEvt(Efl.Input.InterfacePointerDownEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerDownEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerDownEvt_Args>)eventHandlers[PointerDownEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerDownEvt_delegate;
   private void on_PointerDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerDownEvt_Args args = new Efl.Input.InterfacePointerDownEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerDownEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerUpEvtKey = new object();
   /// <summary>Main pointer button released (button id is known).
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerUpEvt_Args> PointerUpEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_UP";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerUpEvt_delegate)) {
               eventHandlers.AddHandler(PointerUpEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_UP";
            if (remove_cpp_event_handler(key, this.evt_PointerUpEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerUpEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerUpEvt.</summary>
   public void On_PointerUpEvt(Efl.Input.InterfacePointerUpEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerUpEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerUpEvt_Args>)eventHandlers[PointerUpEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerUpEvt_delegate;
   private void on_PointerUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerUpEvt_Args args = new Efl.Input.InterfacePointerUpEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerUpEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerCancelEvtKey = new object();
   /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerCancelEvt_Args> PointerCancelEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_CANCEL";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerCancelEvt_delegate)) {
               eventHandlers.AddHandler(PointerCancelEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_CANCEL";
            if (remove_cpp_event_handler(key, this.evt_PointerCancelEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerCancelEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerCancelEvt.</summary>
   public void On_PointerCancelEvt(Efl.Input.InterfacePointerCancelEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerCancelEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerCancelEvt_Args>)eventHandlers[PointerCancelEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerCancelEvt_delegate;
   private void on_PointerCancelEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerCancelEvt_Args args = new Efl.Input.InterfacePointerCancelEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerCancelEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerInEvtKey = new object();
   /// <summary>Pointer entered a window or a widget.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerInEvt_Args> PointerInEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_IN";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerInEvt_delegate)) {
               eventHandlers.AddHandler(PointerInEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_IN";
            if (remove_cpp_event_handler(key, this.evt_PointerInEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerInEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerInEvt.</summary>
   public void On_PointerInEvt(Efl.Input.InterfacePointerInEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerInEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerInEvt_Args>)eventHandlers[PointerInEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerInEvt_delegate;
   private void on_PointerInEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerInEvt_Args args = new Efl.Input.InterfacePointerInEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerInEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerOutEvtKey = new object();
   /// <summary>Pointer left a window or a widget.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerOutEvt_Args> PointerOutEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_OUT";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerOutEvt_delegate)) {
               eventHandlers.AddHandler(PointerOutEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_OUT";
            if (remove_cpp_event_handler(key, this.evt_PointerOutEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerOutEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerOutEvt.</summary>
   public void On_PointerOutEvt(Efl.Input.InterfacePointerOutEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerOutEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerOutEvt_Args>)eventHandlers[PointerOutEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerOutEvt_delegate;
   private void on_PointerOutEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerOutEvt_Args args = new Efl.Input.InterfacePointerOutEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerOutEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerWheelEvtKey = new object();
   /// <summary>Mouse wheel event.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerWheelEvt_Args> PointerWheelEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_WHEEL";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerWheelEvt_delegate)) {
               eventHandlers.AddHandler(PointerWheelEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_WHEEL";
            if (remove_cpp_event_handler(key, this.evt_PointerWheelEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerWheelEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerWheelEvt.</summary>
   public void On_PointerWheelEvt(Efl.Input.InterfacePointerWheelEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerWheelEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerWheelEvt_Args>)eventHandlers[PointerWheelEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerWheelEvt_delegate;
   private void on_PointerWheelEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerWheelEvt_Args args = new Efl.Input.InterfacePointerWheelEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerWheelEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerAxisEvtKey = new object();
   /// <summary>Pen or other axis event update.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerAxisEvt_Args> PointerAxisEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_AXIS";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_PointerAxisEvt_delegate)) {
               eventHandlers.AddHandler(PointerAxisEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_AXIS";
            if (remove_cpp_event_handler(key, this.evt_PointerAxisEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerAxisEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerAxisEvt.</summary>
   public void On_PointerAxisEvt(Efl.Input.InterfacePointerAxisEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerAxisEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerAxisEvt_Args>)eventHandlers[PointerAxisEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerAxisEvt_delegate;
   private void on_PointerAxisEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerAxisEvt_Args args = new Efl.Input.InterfacePointerAxisEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerAxisEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object FingerMoveEvtKey = new object();
   /// <summary>Finger moved (current and previous positions are known).
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceFingerMoveEvt_Args> FingerMoveEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_FINGER_MOVE";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_FingerMoveEvt_delegate)) {
               eventHandlers.AddHandler(FingerMoveEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_FINGER_MOVE";
            if (remove_cpp_event_handler(key, this.evt_FingerMoveEvt_delegate)) { 
               eventHandlers.RemoveHandler(FingerMoveEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FingerMoveEvt.</summary>
   public void On_FingerMoveEvt(Efl.Input.InterfaceFingerMoveEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceFingerMoveEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceFingerMoveEvt_Args>)eventHandlers[FingerMoveEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FingerMoveEvt_delegate;
   private void on_FingerMoveEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceFingerMoveEvt_Args args = new Efl.Input.InterfaceFingerMoveEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_FingerMoveEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object FingerDownEvtKey = new object();
   /// <summary>Finger pressed (finger id is known).
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceFingerDownEvt_Args> FingerDownEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_FINGER_DOWN";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_FingerDownEvt_delegate)) {
               eventHandlers.AddHandler(FingerDownEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_FINGER_DOWN";
            if (remove_cpp_event_handler(key, this.evt_FingerDownEvt_delegate)) { 
               eventHandlers.RemoveHandler(FingerDownEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FingerDownEvt.</summary>
   public void On_FingerDownEvt(Efl.Input.InterfaceFingerDownEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceFingerDownEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceFingerDownEvt_Args>)eventHandlers[FingerDownEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FingerDownEvt_delegate;
   private void on_FingerDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceFingerDownEvt_Args args = new Efl.Input.InterfaceFingerDownEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_FingerDownEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object FingerUpEvtKey = new object();
   /// <summary>Finger released (finger id is known).
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceFingerUpEvt_Args> FingerUpEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_FINGER_UP";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_FingerUpEvt_delegate)) {
               eventHandlers.AddHandler(FingerUpEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_FINGER_UP";
            if (remove_cpp_event_handler(key, this.evt_FingerUpEvt_delegate)) { 
               eventHandlers.RemoveHandler(FingerUpEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FingerUpEvt.</summary>
   public void On_FingerUpEvt(Efl.Input.InterfaceFingerUpEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceFingerUpEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceFingerUpEvt_Args>)eventHandlers[FingerUpEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FingerUpEvt_delegate;
   private void on_FingerUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceFingerUpEvt_Args args = new Efl.Input.InterfaceFingerUpEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_FingerUpEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object KeyDownEvtKey = new object();
   /// <summary>Keyboard key press.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceKeyDownEvt_Args> KeyDownEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_KEY_DOWN";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_KeyDownEvt_delegate)) {
               eventHandlers.AddHandler(KeyDownEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_KEY_DOWN";
            if (remove_cpp_event_handler(key, this.evt_KeyDownEvt_delegate)) { 
               eventHandlers.RemoveHandler(KeyDownEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event KeyDownEvt.</summary>
   public void On_KeyDownEvt(Efl.Input.InterfaceKeyDownEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceKeyDownEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceKeyDownEvt_Args>)eventHandlers[KeyDownEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_KeyDownEvt_delegate;
   private void on_KeyDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceKeyDownEvt_Args args = new Efl.Input.InterfaceKeyDownEvt_Args();
      args.arg = new Efl.Input.Key(evt.Info);
      try {
         On_KeyDownEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object KeyUpEvtKey = new object();
   /// <summary>Keyboard key release.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceKeyUpEvt_Args> KeyUpEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_KEY_UP";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_KeyUpEvt_delegate)) {
               eventHandlers.AddHandler(KeyUpEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_KEY_UP";
            if (remove_cpp_event_handler(key, this.evt_KeyUpEvt_delegate)) { 
               eventHandlers.RemoveHandler(KeyUpEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event KeyUpEvt.</summary>
   public void On_KeyUpEvt(Efl.Input.InterfaceKeyUpEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceKeyUpEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceKeyUpEvt_Args>)eventHandlers[KeyUpEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_KeyUpEvt_delegate;
   private void on_KeyUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceKeyUpEvt_Args args = new Efl.Input.InterfaceKeyUpEvt_Args();
      args.arg = new Efl.Input.Key(evt.Info);
      try {
         On_KeyUpEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object HoldEvtKey = new object();
   /// <summary>All input events are on hold or resumed.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceHoldEvt_Args> HoldEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_HOLD";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_HoldEvt_delegate)) {
               eventHandlers.AddHandler(HoldEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_HOLD";
            if (remove_cpp_event_handler(key, this.evt_HoldEvt_delegate)) { 
               eventHandlers.RemoveHandler(HoldEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event HoldEvt.</summary>
   public void On_HoldEvt(Efl.Input.InterfaceHoldEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceHoldEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceHoldEvt_Args>)eventHandlers[HoldEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_HoldEvt_delegate;
   private void on_HoldEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceHoldEvt_Args args = new Efl.Input.InterfaceHoldEvt_Args();
      args.arg = new Efl.Input.Hold(evt.Info);
      try {
         On_HoldEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object FocusInEvtKey = new object();
   /// <summary>A focus in event.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceFocusInEvt_Args> FocusInEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_FOCUS_IN";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_FocusInEvt_delegate)) {
               eventHandlers.AddHandler(FocusInEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_FOCUS_IN";
            if (remove_cpp_event_handler(key, this.evt_FocusInEvt_delegate)) { 
               eventHandlers.RemoveHandler(FocusInEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FocusInEvt.</summary>
   public void On_FocusInEvt(Efl.Input.InterfaceFocusInEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceFocusInEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceFocusInEvt_Args>)eventHandlers[FocusInEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FocusInEvt_delegate;
   private void on_FocusInEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceFocusInEvt_Args args = new Efl.Input.InterfaceFocusInEvt_Args();
      args.arg = new Efl.Input.Focus(evt.Info);
      try {
         On_FocusInEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object FocusOutEvtKey = new object();
   /// <summary>A focus out event.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceFocusOutEvt_Args> FocusOutEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_FOCUS_OUT";
            if (add_cpp_event_handler(efl.Libs.Evas, key, this.evt_FocusOutEvt_delegate)) {
               eventHandlers.AddHandler(FocusOutEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_FOCUS_OUT";
            if (remove_cpp_event_handler(key, this.evt_FocusOutEvt_delegate)) { 
               eventHandlers.RemoveHandler(FocusOutEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FocusOutEvt.</summary>
   public void On_FocusOutEvt(Efl.Input.InterfaceFocusOutEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceFocusOutEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceFocusOutEvt_Args>)eventHandlers[FocusOutEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FocusOutEvt_delegate;
   private void on_FocusOutEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceFocusOutEvt_Args args = new Efl.Input.InterfaceFocusOutEvt_Args();
      args.arg = new Efl.Input.Focus(evt.Info);
      try {
         On_FocusOutEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_PointerMoveEvt_delegate = new Efl.EventCb(on_PointerMoveEvt_NativeCallback);
      evt_PointerDownEvt_delegate = new Efl.EventCb(on_PointerDownEvt_NativeCallback);
      evt_PointerUpEvt_delegate = new Efl.EventCb(on_PointerUpEvt_NativeCallback);
      evt_PointerCancelEvt_delegate = new Efl.EventCb(on_PointerCancelEvt_NativeCallback);
      evt_PointerInEvt_delegate = new Efl.EventCb(on_PointerInEvt_NativeCallback);
      evt_PointerOutEvt_delegate = new Efl.EventCb(on_PointerOutEvt_NativeCallback);
      evt_PointerWheelEvt_delegate = new Efl.EventCb(on_PointerWheelEvt_NativeCallback);
      evt_PointerAxisEvt_delegate = new Efl.EventCb(on_PointerAxisEvt_NativeCallback);
      evt_FingerMoveEvt_delegate = new Efl.EventCb(on_FingerMoveEvt_NativeCallback);
      evt_FingerDownEvt_delegate = new Efl.EventCb(on_FingerDownEvt_NativeCallback);
      evt_FingerUpEvt_delegate = new Efl.EventCb(on_FingerUpEvt_NativeCallback);
      evt_KeyDownEvt_delegate = new Efl.EventCb(on_KeyDownEvt_NativeCallback);
      evt_KeyUpEvt_delegate = new Efl.EventCb(on_KeyUpEvt_NativeCallback);
      evt_HoldEvt_delegate = new Efl.EventCb(on_HoldEvt_NativeCallback);
      evt_FocusInEvt_delegate = new Efl.EventCb(on_FocusInEvt_NativeCallback);
      evt_FocusOutEvt_delegate = new Efl.EventCb(on_FocusOutEvt_NativeCallback);
   }
   /// <summary>Check if input events from a given seat is enabled.
   /// 1.19</summary>
   /// <param name="seat">The seat to act on.
   /// 1.19</param>
   /// <returns><c>true</c> to enable events for a seat or <c>false</c> otherwise.
   /// 1.19</returns>
   public bool GetSeatEventFilter( Efl.Input.Device seat) {
                         var _ret_var = Efl.Input.InterfaceNativeInherit.efl_input_seat_event_filter_get_ptr.Value.Delegate(this.NativeHandle, seat);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Add or remove a given seat to the filter list. If the filter list is empty this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is in the list.
   /// 1.19</summary>
   /// <param name="seat">The seat to act on.
   /// 1.19</param>
   /// <param name="enable"><c>true</c> to enable events for a seat or <c>false</c> otherwise.
   /// 1.19</param>
   /// <returns></returns>
   public  void SetSeatEventFilter( Efl.Input.Device seat,  bool enable) {
                                           Efl.Input.InterfaceNativeInherit.efl_input_seat_event_filter_set_ptr.Value.Delegate(this.NativeHandle, seat,  enable);
      Eina.Error.RaiseIfUnhandledException();
                               }
}
public class InterfaceNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_input_seat_event_filter_get_static_delegate == null)
      efl_input_seat_event_filter_get_static_delegate = new efl_input_seat_event_filter_get_delegate(seat_event_filter_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_seat_event_filter_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_seat_event_filter_get_static_delegate)});
      if (efl_input_seat_event_filter_set_static_delegate == null)
      efl_input_seat_event_filter_set_static_delegate = new efl_input_seat_event_filter_set_delegate(seat_event_filter_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_seat_event_filter_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_seat_event_filter_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Input.InterfaceConcrete.efl_input_interface_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Input.InterfaceConcrete.efl_input_interface_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_seat_event_filter_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_seat_event_filter_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    public static Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_get_api_delegate> efl_input_seat_event_filter_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_get_api_delegate>(_Module, "efl_input_seat_event_filter_get");
    private static bool seat_event_filter_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device seat)
   {
      Eina.Log.Debug("function efl_input_seat_event_filter_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Interface)wrapper).GetSeatEventFilter( seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_input_seat_event_filter_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private static efl_input_seat_event_filter_get_delegate efl_input_seat_event_filter_get_static_delegate;


    private delegate  void efl_input_seat_event_filter_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat,  [MarshalAs(UnmanagedType.U1)]  bool enable);


    public delegate  void efl_input_seat_event_filter_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat,  [MarshalAs(UnmanagedType.U1)]  bool enable);
    public static Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_set_api_delegate> efl_input_seat_event_filter_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_seat_event_filter_set_api_delegate>(_Module, "efl_input_seat_event_filter_set");
    private static  void seat_event_filter_set(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device seat,  bool enable)
   {
      Eina.Log.Debug("function efl_input_seat_event_filter_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Interface)wrapper).SetSeatEventFilter( seat,  enable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_input_seat_event_filter_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat,  enable);
      }
   }
   private static efl_input_seat_event_filter_set_delegate efl_input_seat_event_filter_set_static_delegate;
}
} } 
