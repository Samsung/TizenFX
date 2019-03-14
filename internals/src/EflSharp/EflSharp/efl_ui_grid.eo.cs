#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Simple grid widget with Pack interface.</summary>
[GridNativeInherit]
public class Grid : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.Pack,Efl.PackLayout,Efl.PackLinear,Efl.Ui.Clickable,Efl.Ui.Direction,Efl.Ui.MultiSelectable,Efl.Ui.Scrollable,Efl.Ui.ScrollableInteractive,Efl.Ui.Scrollbar,Efl.Ui.Selectable
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.GridNativeInherit nativeInherit = new Efl.Ui.GridNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Grid))
            return Efl.Ui.GridNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_grid_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
   public Grid(Efl.Object parent
         ,  System.String style = null) :
      base(efl_ui_grid_class_get(), typeof(Grid), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(style))
         SetStyle(Efl.Eo.Globals.GetParamHelper(style));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Grid(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Grid(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Grid static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Grid(obj.NativeHandle);
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
private static object LayoutUpdatedEvtKey = new object();
   /// <summary>Sent after the layout was updated.</summary>
   public event EventHandler LayoutUpdatedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_LayoutUpdatedEvt_delegate)) {
               eventHandlers.AddHandler(LayoutUpdatedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
            if (remove_cpp_event_handler(key, this.evt_LayoutUpdatedEvt_delegate)) { 
               eventHandlers.RemoveHandler(LayoutUpdatedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event LayoutUpdatedEvt.</summary>
   public void On_LayoutUpdatedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[LayoutUpdatedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_LayoutUpdatedEvt_delegate;
   private void on_LayoutUpdatedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_LayoutUpdatedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ClickedEvtKey = new object();
   /// <summary>Called when object is clicked</summary>
   public event EventHandler ClickedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ClickedEvt_delegate)) {
               eventHandlers.AddHandler(ClickedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED";
            if (remove_cpp_event_handler(key, this.evt_ClickedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ClickedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ClickedEvt.</summary>
   public void On_ClickedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ClickedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ClickedEvt_delegate;
   private void on_ClickedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ClickedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ClickedDoubleEvtKey = new object();
   /// <summary>Called when object receives a double click</summary>
   public event EventHandler ClickedDoubleEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ClickedDoubleEvt_delegate)) {
               eventHandlers.AddHandler(ClickedDoubleEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
            if (remove_cpp_event_handler(key, this.evt_ClickedDoubleEvt_delegate)) { 
               eventHandlers.RemoveHandler(ClickedDoubleEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ClickedDoubleEvt.</summary>
   public void On_ClickedDoubleEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ClickedDoubleEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ClickedDoubleEvt_delegate;
   private void on_ClickedDoubleEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ClickedDoubleEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ClickedTripleEvtKey = new object();
   /// <summary>Called when object receives a triple click</summary>
   public event EventHandler ClickedTripleEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ClickedTripleEvt_delegate)) {
               eventHandlers.AddHandler(ClickedTripleEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
            if (remove_cpp_event_handler(key, this.evt_ClickedTripleEvt_delegate)) { 
               eventHandlers.RemoveHandler(ClickedTripleEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ClickedTripleEvt.</summary>
   public void On_ClickedTripleEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ClickedTripleEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ClickedTripleEvt_delegate;
   private void on_ClickedTripleEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ClickedTripleEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ClickedRightEvtKey = new object();
   /// <summary>Called when object receives a right click</summary>
   public event EventHandler<Efl.Ui.ClickableClickedRightEvt_Args> ClickedRightEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED_RIGHT";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ClickedRightEvt_delegate)) {
               eventHandlers.AddHandler(ClickedRightEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED_RIGHT";
            if (remove_cpp_event_handler(key, this.evt_ClickedRightEvt_delegate)) { 
               eventHandlers.RemoveHandler(ClickedRightEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ClickedRightEvt.</summary>
   public void On_ClickedRightEvt(Efl.Ui.ClickableClickedRightEvt_Args e)
   {
      EventHandler<Efl.Ui.ClickableClickedRightEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ClickableClickedRightEvt_Args>)eventHandlers[ClickedRightEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ClickedRightEvt_delegate;
   private void on_ClickedRightEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ClickableClickedRightEvt_Args args = new Efl.Ui.ClickableClickedRightEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_ClickedRightEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PressedEvtKey = new object();
   /// <summary>Called when the object is pressed</summary>
   public event EventHandler<Efl.Ui.ClickablePressedEvt_Args> PressedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_PRESSED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_PressedEvt_delegate)) {
               eventHandlers.AddHandler(PressedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_PRESSED";
            if (remove_cpp_event_handler(key, this.evt_PressedEvt_delegate)) { 
               eventHandlers.RemoveHandler(PressedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PressedEvt.</summary>
   public void On_PressedEvt(Efl.Ui.ClickablePressedEvt_Args e)
   {
      EventHandler<Efl.Ui.ClickablePressedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ClickablePressedEvt_Args>)eventHandlers[PressedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PressedEvt_delegate;
   private void on_PressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ClickablePressedEvt_Args args = new Efl.Ui.ClickablePressedEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_PressedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object UnpressedEvtKey = new object();
   /// <summary>Called when the object is no longer pressed</summary>
   public event EventHandler<Efl.Ui.ClickableUnpressedEvt_Args> UnpressedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_UNPRESSED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_UnpressedEvt_delegate)) {
               eventHandlers.AddHandler(UnpressedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_UNPRESSED";
            if (remove_cpp_event_handler(key, this.evt_UnpressedEvt_delegate)) { 
               eventHandlers.RemoveHandler(UnpressedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event UnpressedEvt.</summary>
   public void On_UnpressedEvt(Efl.Ui.ClickableUnpressedEvt_Args e)
   {
      EventHandler<Efl.Ui.ClickableUnpressedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ClickableUnpressedEvt_Args>)eventHandlers[UnpressedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_UnpressedEvt_delegate;
   private void on_UnpressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ClickableUnpressedEvt_Args args = new Efl.Ui.ClickableUnpressedEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_UnpressedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object LongpressedEvtKey = new object();
   /// <summary>Called when the object receives a long press</summary>
   public event EventHandler<Efl.Ui.ClickableLongpressedEvt_Args> LongpressedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_LONGPRESSED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_LongpressedEvt_delegate)) {
               eventHandlers.AddHandler(LongpressedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_LONGPRESSED";
            if (remove_cpp_event_handler(key, this.evt_LongpressedEvt_delegate)) { 
               eventHandlers.RemoveHandler(LongpressedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event LongpressedEvt.</summary>
   public void On_LongpressedEvt(Efl.Ui.ClickableLongpressedEvt_Args e)
   {
      EventHandler<Efl.Ui.ClickableLongpressedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ClickableLongpressedEvt_Args>)eventHandlers[LongpressedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_LongpressedEvt_delegate;
   private void on_LongpressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ClickableLongpressedEvt_Args args = new Efl.Ui.ClickableLongpressedEvt_Args();
      args.arg = new Efl.Object(evt.Info);
      try {
         On_LongpressedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object RepeatedEvtKey = new object();
   /// <summary>Called when the object receives repeated presses/clicks</summary>
   public event EventHandler RepeatedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_REPEATED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_RepeatedEvt_delegate)) {
               eventHandlers.AddHandler(RepeatedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_REPEATED";
            if (remove_cpp_event_handler(key, this.evt_RepeatedEvt_delegate)) { 
               eventHandlers.RemoveHandler(RepeatedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event RepeatedEvt.</summary>
   public void On_RepeatedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[RepeatedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_RepeatedEvt_delegate;
   private void on_RepeatedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_RepeatedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ScrollStartEvtKey = new object();
   /// <summary>Called when scroll operation starts</summary>
   public event EventHandler ScrollStartEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_START";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ScrollStartEvt_delegate)) {
               eventHandlers.AddHandler(ScrollStartEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_START";
            if (remove_cpp_event_handler(key, this.evt_ScrollStartEvt_delegate)) { 
               eventHandlers.RemoveHandler(ScrollStartEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ScrollStartEvt.</summary>
   public void On_ScrollStartEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ScrollStartEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ScrollStartEvt_delegate;
   private void on_ScrollStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ScrollStartEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ScrollEvtKey = new object();
   /// <summary>Called when scrolling</summary>
   public event EventHandler ScrollEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ScrollEvt_delegate)) {
               eventHandlers.AddHandler(ScrollEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL";
            if (remove_cpp_event_handler(key, this.evt_ScrollEvt_delegate)) { 
               eventHandlers.RemoveHandler(ScrollEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ScrollEvt.</summary>
   public void On_ScrollEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ScrollEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ScrollEvt_delegate;
   private void on_ScrollEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ScrollEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ScrollStopEvtKey = new object();
   /// <summary>Called when scroll operation stops</summary>
   public event EventHandler ScrollStopEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_STOP";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ScrollStopEvt_delegate)) {
               eventHandlers.AddHandler(ScrollStopEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_STOP";
            if (remove_cpp_event_handler(key, this.evt_ScrollStopEvt_delegate)) { 
               eventHandlers.RemoveHandler(ScrollStopEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ScrollStopEvt.</summary>
   public void On_ScrollStopEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ScrollStopEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ScrollStopEvt_delegate;
   private void on_ScrollStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ScrollStopEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ScrollUpEvtKey = new object();
   /// <summary>Called when scrolling upwards</summary>
   public event EventHandler ScrollUpEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_UP";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ScrollUpEvt_delegate)) {
               eventHandlers.AddHandler(ScrollUpEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_UP";
            if (remove_cpp_event_handler(key, this.evt_ScrollUpEvt_delegate)) { 
               eventHandlers.RemoveHandler(ScrollUpEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ScrollUpEvt.</summary>
   public void On_ScrollUpEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ScrollUpEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ScrollUpEvt_delegate;
   private void on_ScrollUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ScrollUpEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ScrollDownEvtKey = new object();
   /// <summary>Called when scrolling downwards</summary>
   public event EventHandler ScrollDownEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_DOWN";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ScrollDownEvt_delegate)) {
               eventHandlers.AddHandler(ScrollDownEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_DOWN";
            if (remove_cpp_event_handler(key, this.evt_ScrollDownEvt_delegate)) { 
               eventHandlers.RemoveHandler(ScrollDownEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ScrollDownEvt.</summary>
   public void On_ScrollDownEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ScrollDownEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ScrollDownEvt_delegate;
   private void on_ScrollDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ScrollDownEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ScrollLeftEvtKey = new object();
   /// <summary>Called when scrolling left</summary>
   public event EventHandler ScrollLeftEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_LEFT";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ScrollLeftEvt_delegate)) {
               eventHandlers.AddHandler(ScrollLeftEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_LEFT";
            if (remove_cpp_event_handler(key, this.evt_ScrollLeftEvt_delegate)) { 
               eventHandlers.RemoveHandler(ScrollLeftEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ScrollLeftEvt.</summary>
   public void On_ScrollLeftEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ScrollLeftEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ScrollLeftEvt_delegate;
   private void on_ScrollLeftEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ScrollLeftEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ScrollRightEvtKey = new object();
   /// <summary>Called when scrolling right</summary>
   public event EventHandler ScrollRightEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ScrollRightEvt_delegate)) {
               eventHandlers.AddHandler(ScrollRightEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
            if (remove_cpp_event_handler(key, this.evt_ScrollRightEvt_delegate)) { 
               eventHandlers.RemoveHandler(ScrollRightEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ScrollRightEvt.</summary>
   public void On_ScrollRightEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ScrollRightEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ScrollRightEvt_delegate;
   private void on_ScrollRightEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ScrollRightEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object EdgeUpEvtKey = new object();
   /// <summary>Called when hitting the top edge</summary>
   public event EventHandler EdgeUpEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_EDGE_UP";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_EdgeUpEvt_delegate)) {
               eventHandlers.AddHandler(EdgeUpEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_EDGE_UP";
            if (remove_cpp_event_handler(key, this.evt_EdgeUpEvt_delegate)) { 
               eventHandlers.RemoveHandler(EdgeUpEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event EdgeUpEvt.</summary>
   public void On_EdgeUpEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[EdgeUpEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_EdgeUpEvt_delegate;
   private void on_EdgeUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_EdgeUpEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object EdgeDownEvtKey = new object();
   /// <summary>Called when hitting the bottom edge</summary>
   public event EventHandler EdgeDownEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_EDGE_DOWN";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_EdgeDownEvt_delegate)) {
               eventHandlers.AddHandler(EdgeDownEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_EDGE_DOWN";
            if (remove_cpp_event_handler(key, this.evt_EdgeDownEvt_delegate)) { 
               eventHandlers.RemoveHandler(EdgeDownEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event EdgeDownEvt.</summary>
   public void On_EdgeDownEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[EdgeDownEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_EdgeDownEvt_delegate;
   private void on_EdgeDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_EdgeDownEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object EdgeLeftEvtKey = new object();
   /// <summary>Called when hitting the left edge</summary>
   public event EventHandler EdgeLeftEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_EDGE_LEFT";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_EdgeLeftEvt_delegate)) {
               eventHandlers.AddHandler(EdgeLeftEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_EDGE_LEFT";
            if (remove_cpp_event_handler(key, this.evt_EdgeLeftEvt_delegate)) { 
               eventHandlers.RemoveHandler(EdgeLeftEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event EdgeLeftEvt.</summary>
   public void On_EdgeLeftEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[EdgeLeftEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_EdgeLeftEvt_delegate;
   private void on_EdgeLeftEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_EdgeLeftEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object EdgeRightEvtKey = new object();
   /// <summary>Called when hitting the right edge</summary>
   public event EventHandler EdgeRightEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_EDGE_RIGHT";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_EdgeRightEvt_delegate)) {
               eventHandlers.AddHandler(EdgeRightEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_EDGE_RIGHT";
            if (remove_cpp_event_handler(key, this.evt_EdgeRightEvt_delegate)) { 
               eventHandlers.RemoveHandler(EdgeRightEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event EdgeRightEvt.</summary>
   public void On_EdgeRightEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[EdgeRightEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_EdgeRightEvt_delegate;
   private void on_EdgeRightEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_EdgeRightEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ScrollAnimStartEvtKey = new object();
   /// <summary>Called when scroll animation starts</summary>
   public event EventHandler ScrollAnimStartEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_ANIM_START";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ScrollAnimStartEvt_delegate)) {
               eventHandlers.AddHandler(ScrollAnimStartEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_ANIM_START";
            if (remove_cpp_event_handler(key, this.evt_ScrollAnimStartEvt_delegate)) { 
               eventHandlers.RemoveHandler(ScrollAnimStartEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ScrollAnimStartEvt.</summary>
   public void On_ScrollAnimStartEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ScrollAnimStartEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ScrollAnimStartEvt_delegate;
   private void on_ScrollAnimStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ScrollAnimStartEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ScrollAnimStopEvtKey = new object();
   /// <summary>Called when scroll animation stopps</summary>
   public event EventHandler ScrollAnimStopEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_ANIM_STOP";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ScrollAnimStopEvt_delegate)) {
               eventHandlers.AddHandler(ScrollAnimStopEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_ANIM_STOP";
            if (remove_cpp_event_handler(key, this.evt_ScrollAnimStopEvt_delegate)) { 
               eventHandlers.RemoveHandler(ScrollAnimStopEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ScrollAnimStopEvt.</summary>
   public void On_ScrollAnimStopEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ScrollAnimStopEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ScrollAnimStopEvt_delegate;
   private void on_ScrollAnimStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ScrollAnimStopEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ScrollDragStartEvtKey = new object();
   /// <summary>Called when scroll drag starts</summary>
   public event EventHandler ScrollDragStartEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_DRAG_START";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ScrollDragStartEvt_delegate)) {
               eventHandlers.AddHandler(ScrollDragStartEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_DRAG_START";
            if (remove_cpp_event_handler(key, this.evt_ScrollDragStartEvt_delegate)) { 
               eventHandlers.RemoveHandler(ScrollDragStartEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ScrollDragStartEvt.</summary>
   public void On_ScrollDragStartEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ScrollDragStartEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ScrollDragStartEvt_delegate;
   private void on_ScrollDragStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ScrollDragStartEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ScrollDragStopEvtKey = new object();
   /// <summary>Called when scroll drag stops</summary>
   public event EventHandler ScrollDragStopEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_DRAG_STOP";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ScrollDragStopEvt_delegate)) {
               eventHandlers.AddHandler(ScrollDragStopEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_DRAG_STOP";
            if (remove_cpp_event_handler(key, this.evt_ScrollDragStopEvt_delegate)) { 
               eventHandlers.RemoveHandler(ScrollDragStopEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ScrollDragStopEvt.</summary>
   public void On_ScrollDragStopEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ScrollDragStopEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ScrollDragStopEvt_delegate;
   private void on_ScrollDragStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ScrollDragStopEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
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

private static object SelectedEvtKey = new object();
   /// <summary>Called when selected</summary>
   public event EventHandler SelectedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SelectedEvt_delegate)) {
               eventHandlers.AddHandler(SelectedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTED";
            if (remove_cpp_event_handler(key, this.evt_SelectedEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectedEvt.</summary>
   public void On_SelectedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectedEvt_delegate;
   private void on_SelectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object UnselectedEvtKey = new object();
   /// <summary>Called when no longer selected</summary>
   public event EventHandler UnselectedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_UNSELECTED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_UnselectedEvt_delegate)) {
               eventHandlers.AddHandler(UnselectedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_UNSELECTED";
            if (remove_cpp_event_handler(key, this.evt_UnselectedEvt_delegate)) { 
               eventHandlers.RemoveHandler(UnselectedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event UnselectedEvt.</summary>
   public void On_UnselectedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[UnselectedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_UnselectedEvt_delegate;
   private void on_UnselectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_UnselectedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SelectionPasteEvtKey = new object();
   /// <summary>Called when selection is pasted</summary>
   public event EventHandler SelectionPasteEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_PASTE";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SelectionPasteEvt_delegate)) {
               eventHandlers.AddHandler(SelectionPasteEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_PASTE";
            if (remove_cpp_event_handler(key, this.evt_SelectionPasteEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionPasteEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionPasteEvt.</summary>
   public void On_SelectionPasteEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectionPasteEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionPasteEvt_delegate;
   private void on_SelectionPasteEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectionPasteEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SelectionCopyEvtKey = new object();
   /// <summary>Called when selection is copied</summary>
   public event EventHandler SelectionCopyEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_COPY";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SelectionCopyEvt_delegate)) {
               eventHandlers.AddHandler(SelectionCopyEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_COPY";
            if (remove_cpp_event_handler(key, this.evt_SelectionCopyEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionCopyEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionCopyEvt.</summary>
   public void On_SelectionCopyEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectionCopyEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionCopyEvt_delegate;
   private void on_SelectionCopyEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectionCopyEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SelectionCutEvtKey = new object();
   /// <summary>Called when selection is cut</summary>
   public event EventHandler SelectionCutEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_CUT";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SelectionCutEvt_delegate)) {
               eventHandlers.AddHandler(SelectionCutEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_CUT";
            if (remove_cpp_event_handler(key, this.evt_SelectionCutEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionCutEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionCutEvt.</summary>
   public void On_SelectionCutEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectionCutEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionCutEvt_delegate;
   private void on_SelectionCutEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectionCutEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SelectionStartEvtKey = new object();
   /// <summary>Called at selection start</summary>
   public event EventHandler SelectionStartEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_START";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SelectionStartEvt_delegate)) {
               eventHandlers.AddHandler(SelectionStartEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_START";
            if (remove_cpp_event_handler(key, this.evt_SelectionStartEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionStartEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionStartEvt.</summary>
   public void On_SelectionStartEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectionStartEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionStartEvt_delegate;
   private void on_SelectionStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectionStartEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Efl_Ui_Selectable_SelectionChangedEvtKey = new object();
   /// <summary>Called when selection is changed</summary>
    event EventHandler Efl.Ui.Selectable.SelectionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_Efl_Ui_Selectable_SelectionChangedEvt_delegate)) {
               eventHandlers.AddHandler(Efl_Ui_Selectable_SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Efl_Ui_Selectable_SelectionChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Efl_Ui_Selectable_SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Efl_Ui_Selectable_SelectionChangedEvt.</summary>
   public void On_Efl_Ui_Selectable_SelectionChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[Efl_Ui_Selectable_SelectionChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Efl_Ui_Selectable_SelectionChangedEvt_delegate;
   private void on_Efl_Ui_Selectable_SelectionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_Efl_Ui_Selectable_SelectionChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object SelectionClearedEvtKey = new object();
   /// <summary>Called when selection is cleared</summary>
   public event EventHandler SelectionClearedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_CLEARED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_SelectionClearedEvt_delegate)) {
               eventHandlers.AddHandler(SelectionClearedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTION_CLEARED";
            if (remove_cpp_event_handler(key, this.evt_SelectionClearedEvt_delegate)) { 
               eventHandlers.RemoveHandler(SelectionClearedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event SelectionClearedEvt.</summary>
   public void On_SelectionClearedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[SelectionClearedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_SelectionClearedEvt_delegate;
   private void on_SelectionClearedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_SelectionClearedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_LayoutUpdatedEvt_delegate = new Efl.EventCb(on_LayoutUpdatedEvt_NativeCallback);
      evt_ClickedEvt_delegate = new Efl.EventCb(on_ClickedEvt_NativeCallback);
      evt_ClickedDoubleEvt_delegate = new Efl.EventCb(on_ClickedDoubleEvt_NativeCallback);
      evt_ClickedTripleEvt_delegate = new Efl.EventCb(on_ClickedTripleEvt_NativeCallback);
      evt_ClickedRightEvt_delegate = new Efl.EventCb(on_ClickedRightEvt_NativeCallback);
      evt_PressedEvt_delegate = new Efl.EventCb(on_PressedEvt_NativeCallback);
      evt_UnpressedEvt_delegate = new Efl.EventCb(on_UnpressedEvt_NativeCallback);
      evt_LongpressedEvt_delegate = new Efl.EventCb(on_LongpressedEvt_NativeCallback);
      evt_RepeatedEvt_delegate = new Efl.EventCb(on_RepeatedEvt_NativeCallback);
      evt_ScrollStartEvt_delegate = new Efl.EventCb(on_ScrollStartEvt_NativeCallback);
      evt_ScrollEvt_delegate = new Efl.EventCb(on_ScrollEvt_NativeCallback);
      evt_ScrollStopEvt_delegate = new Efl.EventCb(on_ScrollStopEvt_NativeCallback);
      evt_ScrollUpEvt_delegate = new Efl.EventCb(on_ScrollUpEvt_NativeCallback);
      evt_ScrollDownEvt_delegate = new Efl.EventCb(on_ScrollDownEvt_NativeCallback);
      evt_ScrollLeftEvt_delegate = new Efl.EventCb(on_ScrollLeftEvt_NativeCallback);
      evt_ScrollRightEvt_delegate = new Efl.EventCb(on_ScrollRightEvt_NativeCallback);
      evt_EdgeUpEvt_delegate = new Efl.EventCb(on_EdgeUpEvt_NativeCallback);
      evt_EdgeDownEvt_delegate = new Efl.EventCb(on_EdgeDownEvt_NativeCallback);
      evt_EdgeLeftEvt_delegate = new Efl.EventCb(on_EdgeLeftEvt_NativeCallback);
      evt_EdgeRightEvt_delegate = new Efl.EventCb(on_EdgeRightEvt_NativeCallback);
      evt_ScrollAnimStartEvt_delegate = new Efl.EventCb(on_ScrollAnimStartEvt_NativeCallback);
      evt_ScrollAnimStopEvt_delegate = new Efl.EventCb(on_ScrollAnimStopEvt_NativeCallback);
      evt_ScrollDragStartEvt_delegate = new Efl.EventCb(on_ScrollDragStartEvt_NativeCallback);
      evt_ScrollDragStopEvt_delegate = new Efl.EventCb(on_ScrollDragStopEvt_NativeCallback);
      evt_BarPressEvt_delegate = new Efl.EventCb(on_BarPressEvt_NativeCallback);
      evt_BarUnpressEvt_delegate = new Efl.EventCb(on_BarUnpressEvt_NativeCallback);
      evt_BarDragEvt_delegate = new Efl.EventCb(on_BarDragEvt_NativeCallback);
      evt_BarSizeChangedEvt_delegate = new Efl.EventCb(on_BarSizeChangedEvt_NativeCallback);
      evt_BarPosChangedEvt_delegate = new Efl.EventCb(on_BarPosChangedEvt_NativeCallback);
      evt_BarShowEvt_delegate = new Efl.EventCb(on_BarShowEvt_NativeCallback);
      evt_BarHideEvt_delegate = new Efl.EventCb(on_BarHideEvt_NativeCallback);
      evt_SelectedEvt_delegate = new Efl.EventCb(on_SelectedEvt_NativeCallback);
      evt_UnselectedEvt_delegate = new Efl.EventCb(on_UnselectedEvt_NativeCallback);
      evt_SelectionPasteEvt_delegate = new Efl.EventCb(on_SelectionPasteEvt_NativeCallback);
      evt_SelectionCopyEvt_delegate = new Efl.EventCb(on_SelectionCopyEvt_NativeCallback);
      evt_SelectionCutEvt_delegate = new Efl.EventCb(on_SelectionCutEvt_NativeCallback);
      evt_SelectionStartEvt_delegate = new Efl.EventCb(on_SelectionStartEvt_NativeCallback);
      evt_Efl_Ui_Selectable_SelectionChangedEvt_delegate = new Efl.EventCb(on_Efl_Ui_Selectable_SelectionChangedEvt_NativeCallback);
      evt_SelectionClearedEvt_delegate = new Efl.EventCb(on_SelectionClearedEvt_NativeCallback);
   }
   /// <summary>Property data of item size.</summary>
   /// <returns>last selected item of grid.</returns>
   virtual public Eina.Size2D GetItemSize() {
       var _ret_var = Efl.Ui.GridNativeInherit.efl_ui_grid_item_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Property data of item size.</summary>
   /// <param name="size">last selected item of grid.</param>
   /// <returns></returns>
   virtual public  void SetItemSize( Eina.Size2D size) {
       var _in_size = Eina.Size2D_StructConversion.ToInternal(size);
                  Efl.Ui.GridNativeInherit.efl_ui_grid_item_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_size);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Property data of last selected item.</summary>
   /// <returns>last selected item of grid.</returns>
   virtual public Efl.Ui.GridItem GetLastSelectedItem() {
       var _ret_var = Efl.Ui.GridNativeInherit.efl_ui_grid_last_selected_item_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>scroll move the item to show in the viewport.</summary>
   /// <param name="item">Target item.</param>
   /// <param name="animation">Boolean value for animation of scroll move.</param>
   /// <returns></returns>
   virtual public  void ItemScroll( Efl.Ui.GridItem item,  bool animation) {
                                           Efl.Ui.GridNativeInherit.efl_ui_grid_item_scroll_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), item,  animation);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>scroll move the item to show at the align position of the viewport.</summary>
   /// <param name="item">Target item.</param>
   /// <param name="align">align value in Viewport.</param>
   /// <param name="animation">Boolean value for animation of scroll move.</param>
   /// <returns></returns>
   virtual public  void ItemScrollAlign( Efl.Ui.GridItem item,  double align,  bool animation) {
                                                             Efl.Ui.GridNativeInherit.efl_ui_grid_item_scroll_align_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), item,  align,  animation);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Get the selected items iterator. The iterator sequence will be decided by selection.</summary>
   /// <returns>Iterator covered by selected items list. user have to free the iterator after used.</returns>
   virtual public Eina.Iterator<Efl.Ui.GridItem> GetSelectedItems() {
       var _ret_var = Efl.Ui.GridNativeInherit.efl_ui_grid_selected_items_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Ui.GridItem>(_ret_var, true, false);
 }
   /// <summary>Alignment of the container within its bounds</summary>
   /// <param name="align_horiz">Horizontal alignment</param>
   /// <param name="align_vert">Vertical alignment</param>
   /// <returns></returns>
   virtual public  void GetPackAlign( out double align_horiz,  out double align_vert) {
                                           Efl.PackNativeInherit.efl_pack_align_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out align_horiz,  out align_vert);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Alignment of the container within its bounds</summary>
   /// <param name="align_horiz">Horizontal alignment</param>
   /// <param name="align_vert">Vertical alignment</param>
   /// <returns></returns>
   virtual public  void SetPackAlign( double align_horiz,  double align_vert) {
                                           Efl.PackNativeInherit.efl_pack_align_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), align_horiz,  align_vert);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Padding between items contained in this object.</summary>
   /// <param name="pad_horiz">Horizontal padding</param>
   /// <param name="pad_vert">Vertical padding</param>
   /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void GetPackPadding( out double pad_horiz,  out double pad_vert,  out bool scalable) {
                                                             Efl.PackNativeInherit.efl_pack_padding_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out pad_horiz,  out pad_vert,  out scalable);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Padding between items contained in this object.</summary>
   /// <param name="pad_horiz">Horizontal padding</param>
   /// <param name="pad_vert">Vertical padding</param>
   /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetPackPadding( double pad_horiz,  double pad_vert,  bool scalable) {
                                                             Efl.PackNativeInherit.efl_pack_padding_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), pad_horiz,  pad_vert,  scalable);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Removes all packed contents, and unreferences them.</summary>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool ClearPack() {
       var _ret_var = Efl.PackNativeInherit.efl_pack_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Removes all packed contents, without unreferencing them.
   /// Use with caution.</summary>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool UnpackAll() {
       var _ret_var = Efl.PackNativeInherit.efl_pack_unpack_all_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Removes an existing item from the container, without deleting it.</summary>
   /// <param name="subobj">The unpacked object.</param>
   /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t a child or can&apos;t be removed</returns>
   virtual public bool Unpack( Efl.Gfx.Entity subobj) {
                         var _ret_var = Efl.PackNativeInherit.efl_pack_unpack_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Adds an item to this container.
   /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
   /// 
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">An object to pack.</param>
   /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
   virtual public bool DoPack( Efl.Gfx.Entity subobj) {
                         var _ret_var = Efl.PackNativeInherit.efl_pack_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Requests EFL to call the <see cref="Efl.PackLayout.UpdateLayout"/> method on this object.
   /// This <see cref="Efl.PackLayout.UpdateLayout"/> may be called asynchronously.</summary>
   /// <returns></returns>
   virtual public  void LayoutRequest() {
       Efl.PackLayoutNativeInherit.efl_pack_layout_request_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Implementation of this container&apos;s layout algorithm.
   /// EFL will call this function whenever the contents of this container need to be re-layed out on the canvas.
   /// 
   /// This can be overriden to implement custom layout behaviours.</summary>
   /// <returns></returns>
   virtual public  void UpdateLayout() {
       Efl.PackLayoutNativeInherit.efl_pack_layout_update_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Prepend an object at the beginning of this container.
   /// This is the same as <see cref="Efl.PackLinear.PackAt"/>(<c>subobj</c>, 0).
   /// 
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack.</param>
   /// <returns><c>false</c> if <c>subobj</c> could not be packed</returns>
   virtual public bool PackBegin( Efl.Gfx.Entity subobj) {
                         var _ret_var = Efl.PackLinearNativeInherit.efl_pack_begin_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Append object at the end of this container.
   /// This is the same as <see cref="Efl.PackLinear.PackAt"/>(<c>subobj</c>, -1).
   /// 
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack at the end.</param>
   /// <returns><c>false</c> if <c>subobj</c> could not be packed</returns>
   virtual public bool PackEnd( Efl.Gfx.Entity subobj) {
                         var _ret_var = Efl.PackLinearNativeInherit.efl_pack_end_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Prepend item before other sub object.
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack before <c>existing</c>.</param>
   /// <param name="existing">Item to refer to.</param>
   /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
   virtual public bool PackBefore( Efl.Gfx.Entity subobj,  Efl.Gfx.Entity existing) {
                                           var _ret_var = Efl.PackLinearNativeInherit.efl_pack_before_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj,  existing);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Append item after other sub object.
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack after <c>existing</c>.</param>
   /// <param name="existing">Item to refer to.</param>
   /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
   virtual public bool PackAfter( Efl.Gfx.Entity subobj,  Efl.Gfx.Entity existing) {
                                           var _ret_var = Efl.PackLinearNativeInherit.efl_pack_after_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj,  existing);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Inserts <c>subobj</c> at the specified <c>index</c>.
   /// Valid range: -<c>count</c> to +<c>count</c>. -1 refers to the last element. Out of range indices will trigger an append.
   /// 
   /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.Pack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
   /// <param name="subobj">Item to pack at given index.</param>
   /// <param name="index">A position.</param>
   /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
   virtual public bool PackAt( Efl.Gfx.Entity subobj,   int index) {
                                           var _ret_var = Efl.PackLinearNativeInherit.efl_pack_at_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj,  index);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Content at a given index in this container.
   /// Index -1 refers to the last item. The valid range is -(count - 1) to (count - 1).</summary>
   /// <param name="index">Index number</param>
   /// <returns>The object contained at the given <c>index</c>.</returns>
   virtual public Efl.Gfx.Entity GetPackContent(  int index) {
                         var _ret_var = Efl.PackLinearNativeInherit.efl_pack_content_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get the index of a child in this container.</summary>
   /// <param name="subobj">An object contained in this pack.</param>
   /// <returns>-1 in case of failure, or the index of this item.</returns>
   virtual public  int GetPackIndex( Efl.Gfx.Entity subobj) {
                         var _ret_var = Efl.PackLinearNativeInherit.efl_pack_index_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Pop out item at specified <c>index</c>.
   /// Equivalent to unpack(content_at(<c>index</c>)).</summary>
   /// <param name="index">Index number</param>
   /// <returns>The child item if it could be removed.</returns>
   virtual public Efl.Gfx.Entity PackUnpackAt(  int index) {
                         var _ret_var = Efl.PackLinearNativeInherit.efl_pack_unpack_at_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Control the direction of a given widget.
   /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
   /// 
   /// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
   /// <returns>Direction of the widget.</returns>
   virtual public Efl.Ui.Dir GetDirection() {
       var _ret_var = Efl.Ui.DirectionNativeInherit.efl_ui_direction_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the direction of a given widget.
   /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
   /// 
   /// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
   /// <param name="dir">Direction of the widget.</param>
   /// <returns></returns>
   virtual public  void SetDirection( Efl.Ui.Dir dir) {
                         Efl.Ui.DirectionNativeInherit.efl_ui_direction_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dir);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The mode type for children selection.</summary>
   /// <returns>Type of selection of children</returns>
   virtual public Efl.Ui.SelectMode GetSelectMode() {
       var _ret_var = Efl.Ui.MultiSelectableNativeInherit.efl_ui_select_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The mode type for children selection.</summary>
   /// <param name="mode">Type of selection of children</param>
   /// <returns></returns>
   virtual public  void SetSelectMode( Efl.Ui.SelectMode mode) {
                         Efl.Ui.MultiSelectableNativeInherit.efl_ui_select_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), mode);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The content position</summary>
   /// <returns>The position is virtual value, (0, 0) starting at the top-left.</returns>
   virtual public Eina.Position2D GetContentPos() {
       var _ret_var = Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_content_pos_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>The content position</summary>
   /// <param name="pos">The position is virtual value, (0, 0) starting at the top-left.</param>
   /// <returns></returns>
   virtual public  void SetContentPos( Eina.Position2D pos) {
       var _in_pos = Eina.Position2D_StructConversion.ToInternal(pos);
                  Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_content_pos_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The content size</summary>
   /// <returns>The content size in pixels.</returns>
   virtual public Eina.Size2D GetContentSize() {
       var _ret_var = Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_content_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>The viewport geometry</summary>
   /// <returns>It is absolute geometry.</returns>
   virtual public Eina.Rect GetViewportGeometry() {
       var _ret_var = Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Bouncing behavior
   /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
   /// <param name="horiz">Horizontal bounce policy.</param>
   /// <param name="vert">Vertical bounce policy.</param>
   /// <returns></returns>
   virtual public  void GetBounceEnabled( out bool horiz,  out bool vert) {
                                           Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out horiz,  out vert);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Bouncing behavior
   /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
   /// <param name="horiz">Horizontal bounce policy.</param>
   /// <param name="vert">Vertical bounce policy.</param>
   /// <returns></returns>
   virtual public  void SetBounceEnabled( bool horiz,  bool vert) {
                                           Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), horiz,  vert);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.ScrollableInteractive.SetMovementBlock"/>.</summary>
   /// <returns><c>true</c> if freeze, <c>false</c> otherwise</returns>
   virtual public bool GetScrollFreeze() {
       var _ret_var = Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.ScrollableInteractive.SetMovementBlock"/>.</summary>
   /// <param name="freeze"><c>true</c> if freeze, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetScrollFreeze( bool freeze) {
                         Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), freeze);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
   /// <returns><c>true</c> if hold, <c>false</c> otherwise</returns>
   virtual public bool GetScrollHold() {
       var _ret_var = Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
   /// <param name="hold"><c>true</c> if hold, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetScrollHold( bool hold) {
                         Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), hold);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Controls an infinite loop for a scroller.</summary>
   /// <param name="loop_h">The scrolling horizontal loop</param>
   /// <param name="loop_v">The Scrolling vertical loop</param>
   /// <returns></returns>
   virtual public  void GetLooping( out bool loop_h,  out bool loop_v) {
                                           Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_looping_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out loop_h,  out loop_v);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Controls an infinite loop for a scroller.</summary>
   /// <param name="loop_h">The scrolling horizontal loop</param>
   /// <param name="loop_v">The Scrolling vertical loop</param>
   /// <returns></returns>
   virtual public  void SetLooping( bool loop_h,  bool loop_v) {
                                           Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_looping_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), loop_h,  loop_v);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Blocking of scrolling (per axis)
   /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
   /// <returns>Which axis (or axes) to block</returns>
   virtual public Efl.Ui.ScrollBlock GetMovementBlock() {
       var _ret_var = Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_movement_block_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Blocking of scrolling (per axis)
   /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
   /// <param name="block">Which axis (or axes) to block</param>
   /// <returns></returns>
   virtual public  void SetMovementBlock( Efl.Ui.ScrollBlock block) {
                         Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_movement_block_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), block);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control scrolling gravity on the scrollable
   /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
   /// 
   /// The scroller will adjust the view to glue itself as follows.
   /// 
   /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the right edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
   /// 
   /// Default values for x and y are 0.0</summary>
   /// <param name="x">Horizontal scrolling gravity</param>
   /// <param name="y">Vertical scrolling gravity</param>
   /// <returns></returns>
   virtual public  void GetGravity( out double x,  out double y) {
                                           Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_gravity_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Control scrolling gravity on the scrollable
   /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
   /// 
   /// The scroller will adjust the view to glue itself as follows.
   /// 
   /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the right edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
   /// 
   /// Default values for x and y are 0.0</summary>
   /// <param name="x">Horizontal scrolling gravity</param>
   /// <param name="y">Vertical scrolling gravity</param>
   /// <returns></returns>
   virtual public  void SetGravity( double x,  double y) {
                                           Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_gravity_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
   /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
   /// <param name="w">Whether to limit the minimum horizontal size</param>
   /// <param name="h">Whether to limit the minimum vertical size</param>
   /// <returns></returns>
   virtual public  void SetMatchContent( bool w,  bool h) {
                                           Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_match_content_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), w,  h);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Control the step size
   /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
   /// <returns>The step size in pixels</returns>
   virtual public Eina.Position2D GetStepSize() {
       var _ret_var = Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_step_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Control the step size
   /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
   /// <param name="step">The step size in pixels</param>
   /// <returns></returns>
   virtual public  void SetStepSize( Eina.Position2D step) {
       var _in_step = Eina.Position2D_StructConversion.ToInternal(step);
                  Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_step_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_step);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Show a specific virtual region within the scroller content object.
   /// This will ensure all (or part if it does not fit) of the designated region in the virtual content object (0, 0 starting at the top-left of the virtual content object) is shown within the scroller. This allows the scroller to &quot;smoothly slide&quot; to this location (if configuration in general calls for transitions). It may not jump immediately to the new location and make take a while and show other content along the way.</summary>
   /// <param name="rect">The position where to scroll. and The size user want to see</param>
   /// <param name="animation">Whether to scroll with animation or not</param>
   /// <returns></returns>
   virtual public  void Scroll( Eina.Rect rect,  bool animation) {
       var _in_rect = Eina.Rect_StructConversion.ToInternal(rect);
                                    Efl.Ui.ScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_rect,  animation);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Scrollbar visibility policy</summary>
   /// <param name="hbar">Horizontal scrollbar</param>
   /// <param name="vbar">Vertical scrollbar</param>
   /// <returns></returns>
   virtual public  void GetBarMode( out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar) {
                                           Efl.Ui.ScrollbarNativeInherit.efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out hbar,  out vbar);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Scrollbar visibility policy</summary>
   /// <param name="hbar">Horizontal scrollbar</param>
   /// <param name="vbar">Vertical scrollbar</param>
   /// <returns></returns>
   virtual public  void SetBarMode( Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar) {
                                           Efl.Ui.ScrollbarNativeInherit.efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), hbar,  vbar);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
   /// <param name="width">Value between 0.0 and 1.0</param>
   /// <param name="height">Value between 0.0 and 1.0</param>
   /// <returns></returns>
   virtual public  void GetBarSize( out double width,  out double height) {
                                           Efl.Ui.ScrollbarNativeInherit.efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out width,  out height);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
   /// <param name="posx">Value between 0.0 and 1.0</param>
   /// <param name="posy">Value between 0.0 and 1.0</param>
   /// <returns></returns>
   virtual public  void GetBarPosition( out double posx,  out double posy) {
                                           Efl.Ui.ScrollbarNativeInherit.efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out posx,  out posy);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
   /// <param name="posx">Value between 0.0 and 1.0</param>
   /// <param name="posy">Value between 0.0 and 1.0</param>
   /// <returns></returns>
   virtual public  void SetBarPosition( double posx,  double posy) {
                                           Efl.Ui.ScrollbarNativeInherit.efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), posx,  posy);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Update bar visibility.
   /// The object will call this function whenever the bar need to be shown or hidden.</summary>
   /// <returns></returns>
   virtual public  void UpdateBarVisibility() {
       Efl.Ui.ScrollbarNativeInherit.efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Property data of item size.</summary>
/// <value>last selected item of grid.</value>
   public Eina.Size2D ItemSize {
      get { return GetItemSize(); }
      set { SetItemSize( value); }
   }
   /// <summary>Property data of last selected item.</summary>
/// <value>last selected item of grid.</value>
   public Efl.Ui.GridItem LastSelectedItem {
      get { return GetLastSelectedItem(); }
   }
   /// <summary>Control the direction of a given widget.
/// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
/// 
/// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
/// <value>Direction of the widget.</value>
   public Efl.Ui.Dir Direction {
      get { return GetDirection(); }
      set { SetDirection( value); }
   }
   /// <summary>The mode type for children selection.</summary>
/// <value>Type of selection of children</value>
   public Efl.Ui.SelectMode SelectMode {
      get { return GetSelectMode(); }
      set { SetSelectMode( value); }
   }
   /// <summary>The content position</summary>
/// <value>The position is virtual value, (0, 0) starting at the top-left.</value>
   public Eina.Position2D ContentPos {
      get { return GetContentPos(); }
      set { SetContentPos( value); }
   }
   /// <summary>The content size</summary>
/// <value>The content size in pixels.</value>
   public Eina.Size2D ContentSize {
      get { return GetContentSize(); }
   }
   /// <summary>The viewport geometry</summary>
/// <value>It is absolute geometry.</value>
   public Eina.Rect ViewportGeometry {
      get { return GetViewportGeometry(); }
   }
   /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.ScrollableInteractive.SetMovementBlock"/>.</summary>
/// <value><c>true</c> if freeze, <c>false</c> otherwise</value>
   public bool ScrollFreeze {
      get { return GetScrollFreeze(); }
      set { SetScrollFreeze( value); }
   }
   /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
/// <value><c>true</c> if hold, <c>false</c> otherwise</value>
   public bool ScrollHold {
      get { return GetScrollHold(); }
      set { SetScrollHold( value); }
   }
   /// <summary>Blocking of scrolling (per axis)
/// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
/// <value>Which axis (or axes) to block</value>
   public Efl.Ui.ScrollBlock MovementBlock {
      get { return GetMovementBlock(); }
      set { SetMovementBlock( value); }
   }
   /// <summary>Control the step size
/// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
/// <value>The step size in pixels</value>
   public Eina.Position2D StepSize {
      get { return GetStepSize(); }
      set { SetStepSize( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Grid.efl_ui_grid_class_get();
   }
}
public class GridNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_grid_item_size_get_static_delegate == null)
      efl_ui_grid_item_size_get_static_delegate = new efl_ui_grid_item_size_get_delegate(item_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_grid_item_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_grid_item_size_get_static_delegate)});
      if (efl_ui_grid_item_size_set_static_delegate == null)
      efl_ui_grid_item_size_set_static_delegate = new efl_ui_grid_item_size_set_delegate(item_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_grid_item_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_grid_item_size_set_static_delegate)});
      if (efl_ui_grid_last_selected_item_get_static_delegate == null)
      efl_ui_grid_last_selected_item_get_static_delegate = new efl_ui_grid_last_selected_item_get_delegate(last_selected_item_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_grid_last_selected_item_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_grid_last_selected_item_get_static_delegate)});
      if (efl_ui_grid_item_scroll_static_delegate == null)
      efl_ui_grid_item_scroll_static_delegate = new efl_ui_grid_item_scroll_delegate(item_scroll);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_grid_item_scroll"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_grid_item_scroll_static_delegate)});
      if (efl_ui_grid_item_scroll_align_static_delegate == null)
      efl_ui_grid_item_scroll_align_static_delegate = new efl_ui_grid_item_scroll_align_delegate(item_scroll_align);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_grid_item_scroll_align"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_grid_item_scroll_align_static_delegate)});
      if (efl_ui_grid_selected_items_get_static_delegate == null)
      efl_ui_grid_selected_items_get_static_delegate = new efl_ui_grid_selected_items_get_delegate(selected_items_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_grid_selected_items_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_grid_selected_items_get_static_delegate)});
      if (efl_pack_align_get_static_delegate == null)
      efl_pack_align_get_static_delegate = new efl_pack_align_get_delegate(pack_align_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_align_get_static_delegate)});
      if (efl_pack_align_set_static_delegate == null)
      efl_pack_align_set_static_delegate = new efl_pack_align_set_delegate(pack_align_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_align_set_static_delegate)});
      if (efl_pack_padding_get_static_delegate == null)
      efl_pack_padding_get_static_delegate = new efl_pack_padding_get_delegate(pack_padding_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_padding_get_static_delegate)});
      if (efl_pack_padding_set_static_delegate == null)
      efl_pack_padding_set_static_delegate = new efl_pack_padding_set_delegate(pack_padding_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_padding_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_padding_set_static_delegate)});
      if (efl_pack_clear_static_delegate == null)
      efl_pack_clear_static_delegate = new efl_pack_clear_delegate(pack_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_clear_static_delegate)});
      if (efl_pack_unpack_all_static_delegate == null)
      efl_pack_unpack_all_static_delegate = new efl_pack_unpack_all_delegate(unpack_all);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_unpack_all"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_all_static_delegate)});
      if (efl_pack_unpack_static_delegate == null)
      efl_pack_unpack_static_delegate = new efl_pack_unpack_delegate(unpack);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_unpack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_static_delegate)});
      if (efl_pack_static_delegate == null)
      efl_pack_static_delegate = new efl_pack_delegate(pack);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_static_delegate)});
      if (efl_pack_layout_request_static_delegate == null)
      efl_pack_layout_request_static_delegate = new efl_pack_layout_request_delegate(layout_request);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_layout_request"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_request_static_delegate)});
      if (efl_pack_layout_update_static_delegate == null)
      efl_pack_layout_update_static_delegate = new efl_pack_layout_update_delegate(layout_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_layout_update"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_update_static_delegate)});
      if (efl_pack_begin_static_delegate == null)
      efl_pack_begin_static_delegate = new efl_pack_begin_delegate(pack_begin);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_begin"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_begin_static_delegate)});
      if (efl_pack_end_static_delegate == null)
      efl_pack_end_static_delegate = new efl_pack_end_delegate(pack_end);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_end"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_end_static_delegate)});
      if (efl_pack_before_static_delegate == null)
      efl_pack_before_static_delegate = new efl_pack_before_delegate(pack_before);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_before"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_before_static_delegate)});
      if (efl_pack_after_static_delegate == null)
      efl_pack_after_static_delegate = new efl_pack_after_delegate(pack_after);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_after"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_after_static_delegate)});
      if (efl_pack_at_static_delegate == null)
      efl_pack_at_static_delegate = new efl_pack_at_delegate(pack_at);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_at_static_delegate)});
      if (efl_pack_content_get_static_delegate == null)
      efl_pack_content_get_static_delegate = new efl_pack_content_get_delegate(pack_content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_content_get_static_delegate)});
      if (efl_pack_index_get_static_delegate == null)
      efl_pack_index_get_static_delegate = new efl_pack_index_get_delegate(pack_index_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_index_get_static_delegate)});
      if (efl_pack_unpack_at_static_delegate == null)
      efl_pack_unpack_at_static_delegate = new efl_pack_unpack_at_delegate(pack_unpack_at);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_unpack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_at_static_delegate)});
      if (efl_ui_direction_get_static_delegate == null)
      efl_ui_direction_get_static_delegate = new efl_ui_direction_get_delegate(direction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_get_static_delegate)});
      if (efl_ui_direction_set_static_delegate == null)
      efl_ui_direction_set_static_delegate = new efl_ui_direction_set_delegate(direction_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_set_static_delegate)});
      if (efl_ui_select_mode_get_static_delegate == null)
      efl_ui_select_mode_get_static_delegate = new efl_ui_select_mode_get_delegate(select_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_select_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_mode_get_static_delegate)});
      if (efl_ui_select_mode_set_static_delegate == null)
      efl_ui_select_mode_set_static_delegate = new efl_ui_select_mode_set_delegate(select_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_select_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_mode_set_static_delegate)});
      if (efl_ui_scrollable_content_pos_get_static_delegate == null)
      efl_ui_scrollable_content_pos_get_static_delegate = new efl_ui_scrollable_content_pos_get_delegate(content_pos_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_content_pos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_get_static_delegate)});
      if (efl_ui_scrollable_content_pos_set_static_delegate == null)
      efl_ui_scrollable_content_pos_set_static_delegate = new efl_ui_scrollable_content_pos_set_delegate(content_pos_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_content_pos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_set_static_delegate)});
      if (efl_ui_scrollable_content_size_get_static_delegate == null)
      efl_ui_scrollable_content_size_get_static_delegate = new efl_ui_scrollable_content_size_get_delegate(content_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_content_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_size_get_static_delegate)});
      if (efl_ui_scrollable_viewport_geometry_get_static_delegate == null)
      efl_ui_scrollable_viewport_geometry_get_static_delegate = new efl_ui_scrollable_viewport_geometry_get_delegate(viewport_geometry_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_viewport_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_viewport_geometry_get_static_delegate)});
      if (efl_ui_scrollable_bounce_enabled_get_static_delegate == null)
      efl_ui_scrollable_bounce_enabled_get_static_delegate = new efl_ui_scrollable_bounce_enabled_get_delegate(bounce_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_bounce_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_get_static_delegate)});
      if (efl_ui_scrollable_bounce_enabled_set_static_delegate == null)
      efl_ui_scrollable_bounce_enabled_set_static_delegate = new efl_ui_scrollable_bounce_enabled_set_delegate(bounce_enabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_bounce_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_set_static_delegate)});
      if (efl_ui_scrollable_scroll_freeze_get_static_delegate == null)
      efl_ui_scrollable_scroll_freeze_get_static_delegate = new efl_ui_scrollable_scroll_freeze_get_delegate(scroll_freeze_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll_freeze_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_get_static_delegate)});
      if (efl_ui_scrollable_scroll_freeze_set_static_delegate == null)
      efl_ui_scrollable_scroll_freeze_set_static_delegate = new efl_ui_scrollable_scroll_freeze_set_delegate(scroll_freeze_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll_freeze_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_set_static_delegate)});
      if (efl_ui_scrollable_scroll_hold_get_static_delegate == null)
      efl_ui_scrollable_scroll_hold_get_static_delegate = new efl_ui_scrollable_scroll_hold_get_delegate(scroll_hold_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll_hold_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_get_static_delegate)});
      if (efl_ui_scrollable_scroll_hold_set_static_delegate == null)
      efl_ui_scrollable_scroll_hold_set_static_delegate = new efl_ui_scrollable_scroll_hold_set_delegate(scroll_hold_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll_hold_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_set_static_delegate)});
      if (efl_ui_scrollable_looping_get_static_delegate == null)
      efl_ui_scrollable_looping_get_static_delegate = new efl_ui_scrollable_looping_get_delegate(looping_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_looping_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_get_static_delegate)});
      if (efl_ui_scrollable_looping_set_static_delegate == null)
      efl_ui_scrollable_looping_set_static_delegate = new efl_ui_scrollable_looping_set_delegate(looping_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_looping_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_set_static_delegate)});
      if (efl_ui_scrollable_movement_block_get_static_delegate == null)
      efl_ui_scrollable_movement_block_get_static_delegate = new efl_ui_scrollable_movement_block_get_delegate(movement_block_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_movement_block_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_get_static_delegate)});
      if (efl_ui_scrollable_movement_block_set_static_delegate == null)
      efl_ui_scrollable_movement_block_set_static_delegate = new efl_ui_scrollable_movement_block_set_delegate(movement_block_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_movement_block_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_set_static_delegate)});
      if (efl_ui_scrollable_gravity_get_static_delegate == null)
      efl_ui_scrollable_gravity_get_static_delegate = new efl_ui_scrollable_gravity_get_delegate(gravity_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_gravity_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_get_static_delegate)});
      if (efl_ui_scrollable_gravity_set_static_delegate == null)
      efl_ui_scrollable_gravity_set_static_delegate = new efl_ui_scrollable_gravity_set_delegate(gravity_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_gravity_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_set_static_delegate)});
      if (efl_ui_scrollable_match_content_set_static_delegate == null)
      efl_ui_scrollable_match_content_set_static_delegate = new efl_ui_scrollable_match_content_set_delegate(match_content_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_match_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_match_content_set_static_delegate)});
      if (efl_ui_scrollable_step_size_get_static_delegate == null)
      efl_ui_scrollable_step_size_get_static_delegate = new efl_ui_scrollable_step_size_get_delegate(step_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_step_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_step_size_get_static_delegate)});
      if (efl_ui_scrollable_step_size_set_static_delegate == null)
      efl_ui_scrollable_step_size_set_static_delegate = new efl_ui_scrollable_step_size_set_delegate(step_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_step_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_step_size_set_static_delegate)});
      if (efl_ui_scrollable_scroll_static_delegate == null)
      efl_ui_scrollable_scroll_static_delegate = new efl_ui_scrollable_scroll_delegate(scroll);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_static_delegate)});
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
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Grid.efl_ui_grid_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Grid.efl_ui_grid_class_get();
   }


    private delegate Eina.Size2D_StructInternal efl_ui_grid_item_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_ui_grid_item_size_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_grid_item_size_get_api_delegate> efl_ui_grid_item_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_grid_item_size_get_api_delegate>(_Module, "efl_ui_grid_item_size_get");
    private static Eina.Size2D_StructInternal item_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_grid_item_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Grid)wrapper).GetItemSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_grid_item_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_grid_item_size_get_delegate efl_ui_grid_item_size_get_static_delegate;


    private delegate  void efl_ui_grid_item_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal size);


    public delegate  void efl_ui_grid_item_size_set_api_delegate(System.IntPtr obj,   Eina.Size2D_StructInternal size);
    public static Efl.Eo.FunctionWrapper<efl_ui_grid_item_size_set_api_delegate> efl_ui_grid_item_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_grid_item_size_set_api_delegate>(_Module, "efl_ui_grid_item_size_set");
    private static  void item_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal size)
   {
      Eina.Log.Debug("function efl_ui_grid_item_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_size = Eina.Size2D_StructConversion.ToManaged(size);
                     
         try {
            ((Grid)wrapper).SetItemSize( _in_size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_grid_item_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
      }
   }
   private static efl_ui_grid_item_size_set_delegate efl_ui_grid_item_size_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.GridItem, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.GridItem efl_ui_grid_last_selected_item_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.GridItem, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.GridItem efl_ui_grid_last_selected_item_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_grid_last_selected_item_get_api_delegate> efl_ui_grid_last_selected_item_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_grid_last_selected_item_get_api_delegate>(_Module, "efl_ui_grid_last_selected_item_get");
    private static Efl.Ui.GridItem last_selected_item_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_grid_last_selected_item_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.GridItem _ret_var = default(Efl.Ui.GridItem);
         try {
            _ret_var = ((Grid)wrapper).GetLastSelectedItem();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_grid_last_selected_item_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_grid_last_selected_item_get_delegate efl_ui_grid_last_selected_item_get_static_delegate;


    private delegate  void efl_ui_grid_item_scroll_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.GridItem, Efl.Eo.NonOwnTag>))]  Efl.Ui.GridItem item,  [MarshalAs(UnmanagedType.U1)]  bool animation);


    public delegate  void efl_ui_grid_item_scroll_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.GridItem, Efl.Eo.NonOwnTag>))]  Efl.Ui.GridItem item,  [MarshalAs(UnmanagedType.U1)]  bool animation);
    public static Efl.Eo.FunctionWrapper<efl_ui_grid_item_scroll_api_delegate> efl_ui_grid_item_scroll_ptr = new Efl.Eo.FunctionWrapper<efl_ui_grid_item_scroll_api_delegate>(_Module, "efl_ui_grid_item_scroll");
    private static  void item_scroll(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.GridItem item,  bool animation)
   {
      Eina.Log.Debug("function efl_ui_grid_item_scroll was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Grid)wrapper).ItemScroll( item,  animation);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_grid_item_scroll_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  item,  animation);
      }
   }
   private static efl_ui_grid_item_scroll_delegate efl_ui_grid_item_scroll_static_delegate;


    private delegate  void efl_ui_grid_item_scroll_align_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.GridItem, Efl.Eo.NonOwnTag>))]  Efl.Ui.GridItem item,   double align,  [MarshalAs(UnmanagedType.U1)]  bool animation);


    public delegate  void efl_ui_grid_item_scroll_align_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.GridItem, Efl.Eo.NonOwnTag>))]  Efl.Ui.GridItem item,   double align,  [MarshalAs(UnmanagedType.U1)]  bool animation);
    public static Efl.Eo.FunctionWrapper<efl_ui_grid_item_scroll_align_api_delegate> efl_ui_grid_item_scroll_align_ptr = new Efl.Eo.FunctionWrapper<efl_ui_grid_item_scroll_align_api_delegate>(_Module, "efl_ui_grid_item_scroll_align");
    private static  void item_scroll_align(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.GridItem item,  double align,  bool animation)
   {
      Eina.Log.Debug("function efl_ui_grid_item_scroll_align was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Grid)wrapper).ItemScrollAlign( item,  align,  animation);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_ui_grid_item_scroll_align_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  item,  align,  animation);
      }
   }
   private static efl_ui_grid_item_scroll_align_delegate efl_ui_grid_item_scroll_align_static_delegate;


    private delegate  System.IntPtr efl_ui_grid_selected_items_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_ui_grid_selected_items_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_grid_selected_items_get_api_delegate> efl_ui_grid_selected_items_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_grid_selected_items_get_api_delegate>(_Module, "efl_ui_grid_selected_items_get");
    private static  System.IntPtr selected_items_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_grid_selected_items_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Ui.GridItem> _ret_var = default(Eina.Iterator<Efl.Ui.GridItem>);
         try {
            _ret_var = ((Grid)wrapper).GetSelectedItems();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_ui_grid_selected_items_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_grid_selected_items_get_delegate efl_ui_grid_selected_items_get_static_delegate;


    private delegate  void efl_pack_align_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double align_horiz,   out double align_vert);


    public delegate  void efl_pack_align_get_api_delegate(System.IntPtr obj,   out double align_horiz,   out double align_vert);
    public static Efl.Eo.FunctionWrapper<efl_pack_align_get_api_delegate> efl_pack_align_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_align_get_api_delegate>(_Module, "efl_pack_align_get");
    private static  void pack_align_get(System.IntPtr obj, System.IntPtr pd,  out double align_horiz,  out double align_vert)
   {
      Eina.Log.Debug("function efl_pack_align_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           align_horiz = default(double);      align_vert = default(double);                     
         try {
            ((Grid)wrapper).GetPackAlign( out align_horiz,  out align_vert);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_pack_align_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out align_horiz,  out align_vert);
      }
   }
   private static efl_pack_align_get_delegate efl_pack_align_get_static_delegate;


    private delegate  void efl_pack_align_set_delegate(System.IntPtr obj, System.IntPtr pd,   double align_horiz,   double align_vert);


    public delegate  void efl_pack_align_set_api_delegate(System.IntPtr obj,   double align_horiz,   double align_vert);
    public static Efl.Eo.FunctionWrapper<efl_pack_align_set_api_delegate> efl_pack_align_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_align_set_api_delegate>(_Module, "efl_pack_align_set");
    private static  void pack_align_set(System.IntPtr obj, System.IntPtr pd,  double align_horiz,  double align_vert)
   {
      Eina.Log.Debug("function efl_pack_align_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Grid)wrapper).SetPackAlign( align_horiz,  align_vert);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_pack_align_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  align_horiz,  align_vert);
      }
   }
   private static efl_pack_align_set_delegate efl_pack_align_set_static_delegate;


    private delegate  void efl_pack_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double pad_horiz,   out double pad_vert,  [MarshalAs(UnmanagedType.U1)]  out bool scalable);


    public delegate  void efl_pack_padding_get_api_delegate(System.IntPtr obj,   out double pad_horiz,   out double pad_vert,  [MarshalAs(UnmanagedType.U1)]  out bool scalable);
    public static Efl.Eo.FunctionWrapper<efl_pack_padding_get_api_delegate> efl_pack_padding_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_padding_get_api_delegate>(_Module, "efl_pack_padding_get");
    private static  void pack_padding_get(System.IntPtr obj, System.IntPtr pd,  out double pad_horiz,  out double pad_vert,  out bool scalable)
   {
      Eina.Log.Debug("function efl_pack_padding_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                 pad_horiz = default(double);      pad_vert = default(double);      scalable = default(bool);                           
         try {
            ((Grid)wrapper).GetPackPadding( out pad_horiz,  out pad_vert,  out scalable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_pack_padding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out pad_horiz,  out pad_vert,  out scalable);
      }
   }
   private static efl_pack_padding_get_delegate efl_pack_padding_get_static_delegate;


    private delegate  void efl_pack_padding_set_delegate(System.IntPtr obj, System.IntPtr pd,   double pad_horiz,   double pad_vert,  [MarshalAs(UnmanagedType.U1)]  bool scalable);


    public delegate  void efl_pack_padding_set_api_delegate(System.IntPtr obj,   double pad_horiz,   double pad_vert,  [MarshalAs(UnmanagedType.U1)]  bool scalable);
    public static Efl.Eo.FunctionWrapper<efl_pack_padding_set_api_delegate> efl_pack_padding_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_padding_set_api_delegate>(_Module, "efl_pack_padding_set");
    private static  void pack_padding_set(System.IntPtr obj, System.IntPtr pd,  double pad_horiz,  double pad_vert,  bool scalable)
   {
      Eina.Log.Debug("function efl_pack_padding_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Grid)wrapper).SetPackPadding( pad_horiz,  pad_vert,  scalable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_pack_padding_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pad_horiz,  pad_vert,  scalable);
      }
   }
   private static efl_pack_padding_set_delegate efl_pack_padding_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_clear_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_clear_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate> efl_pack_clear_ptr = new Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate>(_Module, "efl_pack_clear");
    private static bool pack_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Grid)wrapper).ClearPack();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_pack_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_pack_clear_delegate efl_pack_clear_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_unpack_all_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_unpack_all_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_pack_unpack_all_api_delegate> efl_pack_unpack_all_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_all_api_delegate>(_Module, "efl_pack_unpack_all");
    private static bool unpack_all(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_unpack_all was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Grid)wrapper).UnpackAll();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_pack_unpack_all_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_pack_unpack_all_delegate efl_pack_unpack_all_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_unpack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_unpack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    public static Efl.Eo.FunctionWrapper<efl_pack_unpack_api_delegate> efl_pack_unpack_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_api_delegate>(_Module, "efl_pack_unpack");
    private static bool unpack(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack_unpack was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Grid)wrapper).Unpack( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_unpack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private static efl_pack_unpack_delegate efl_pack_unpack_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    public static Efl.Eo.FunctionWrapper<efl_pack_api_delegate> efl_pack_ptr = new Efl.Eo.FunctionWrapper<efl_pack_api_delegate>(_Module, "efl_pack");
    private static bool pack(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Grid)wrapper).DoPack( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private static efl_pack_delegate efl_pack_static_delegate;


    private delegate  void efl_pack_layout_request_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_pack_layout_request_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_pack_layout_request_api_delegate> efl_pack_layout_request_ptr = new Efl.Eo.FunctionWrapper<efl_pack_layout_request_api_delegate>(_Module, "efl_pack_layout_request");
    private static  void layout_request(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_layout_request was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Grid)wrapper).LayoutRequest();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_pack_layout_request_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_pack_layout_request_delegate efl_pack_layout_request_static_delegate;


    private delegate  void efl_pack_layout_update_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_pack_layout_update_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate> efl_pack_layout_update_ptr = new Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate>(_Module, "efl_pack_layout_update");
    private static  void layout_update(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_pack_layout_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Grid)wrapper).UpdateLayout();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_pack_layout_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_pack_layout_update_delegate efl_pack_layout_update_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_begin_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_begin_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    public static Efl.Eo.FunctionWrapper<efl_pack_begin_api_delegate> efl_pack_begin_ptr = new Efl.Eo.FunctionWrapper<efl_pack_begin_api_delegate>(_Module, "efl_pack_begin");
    private static bool pack_begin(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack_begin was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Grid)wrapper).PackBegin( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_begin_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private static efl_pack_begin_delegate efl_pack_begin_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_end_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_end_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    public static Efl.Eo.FunctionWrapper<efl_pack_end_api_delegate> efl_pack_end_ptr = new Efl.Eo.FunctionWrapper<efl_pack_end_api_delegate>(_Module, "efl_pack_end");
    private static bool pack_end(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack_end was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Grid)wrapper).PackEnd( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private static efl_pack_end_delegate efl_pack_end_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_before_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_before_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);
    public static Efl.Eo.FunctionWrapper<efl_pack_before_api_delegate> efl_pack_before_ptr = new Efl.Eo.FunctionWrapper<efl_pack_before_api_delegate>(_Module, "efl_pack_before");
    private static bool pack_before(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj,  Efl.Gfx.Entity existing)
   {
      Eina.Log.Debug("function efl_pack_before was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Grid)wrapper).PackBefore( subobj,  existing);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_pack_before_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  existing);
      }
   }
   private static efl_pack_before_delegate efl_pack_before_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_after_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_after_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity existing);
    public static Efl.Eo.FunctionWrapper<efl_pack_after_api_delegate> efl_pack_after_ptr = new Efl.Eo.FunctionWrapper<efl_pack_after_api_delegate>(_Module, "efl_pack_after");
    private static bool pack_after(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj,  Efl.Gfx.Entity existing)
   {
      Eina.Log.Debug("function efl_pack_after was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Grid)wrapper).PackAfter( subobj,  existing);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_pack_after_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  existing);
      }
   }
   private static efl_pack_after_delegate efl_pack_after_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_at_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj,    int index);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_at_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj,    int index);
    public static Efl.Eo.FunctionWrapper<efl_pack_at_api_delegate> efl_pack_at_ptr = new Efl.Eo.FunctionWrapper<efl_pack_at_api_delegate>(_Module, "efl_pack_at");
    private static bool pack_at(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj,   int index)
   {
      Eina.Log.Debug("function efl_pack_at was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Grid)wrapper).PackAt( subobj,  index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_pack_at_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  index);
      }
   }
   private static efl_pack_at_delegate efl_pack_at_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_pack_content_get_delegate(System.IntPtr obj, System.IntPtr pd,    int index);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_pack_content_get_api_delegate(System.IntPtr obj,    int index);
    public static Efl.Eo.FunctionWrapper<efl_pack_content_get_api_delegate> efl_pack_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_content_get_api_delegate>(_Module, "efl_pack_content_get");
    private static Efl.Gfx.Entity pack_content_get(System.IntPtr obj, System.IntPtr pd,   int index)
   {
      Eina.Log.Debug("function efl_pack_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Grid)wrapper).GetPackContent( index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index);
      }
   }
   private static efl_pack_content_get_delegate efl_pack_content_get_static_delegate;


    private delegate  int efl_pack_index_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);


    public delegate  int efl_pack_index_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity subobj);
    public static Efl.Eo.FunctionWrapper<efl_pack_index_get_api_delegate> efl_pack_index_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_index_get_api_delegate>(_Module, "efl_pack_index_get");
    private static  int pack_index_get(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity subobj)
   {
      Eina.Log.Debug("function efl_pack_index_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     int _ret_var = default( int);
         try {
            _ret_var = ((Grid)wrapper).GetPackIndex( subobj);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_index_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
      }
   }
   private static efl_pack_index_get_delegate efl_pack_index_get_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_pack_unpack_at_delegate(System.IntPtr obj, System.IntPtr pd,    int index);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_pack_unpack_at_api_delegate(System.IntPtr obj,    int index);
    public static Efl.Eo.FunctionWrapper<efl_pack_unpack_at_api_delegate> efl_pack_unpack_at_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_at_api_delegate>(_Module, "efl_pack_unpack_at");
    private static Efl.Gfx.Entity pack_unpack_at(System.IntPtr obj, System.IntPtr pd,   int index)
   {
      Eina.Log.Debug("function efl_pack_unpack_at was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Grid)wrapper).PackUnpackAt( index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_pack_unpack_at_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index);
      }
   }
   private static efl_pack_unpack_at_delegate efl_pack_unpack_at_static_delegate;


    private delegate Efl.Ui.Dir efl_ui_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Ui.Dir efl_ui_direction_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate> efl_ui_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate>(_Module, "efl_ui_direction_get");
    private static Efl.Ui.Dir direction_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_direction_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Dir _ret_var = default(Efl.Ui.Dir);
         try {
            _ret_var = ((Grid)wrapper).GetDirection();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_direction_get_delegate efl_ui_direction_get_static_delegate;


    private delegate  void efl_ui_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir dir);


    public delegate  void efl_ui_direction_set_api_delegate(System.IntPtr obj,   Efl.Ui.Dir dir);
    public static Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate> efl_ui_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate>(_Module, "efl_ui_direction_set");
    private static  void direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir)
   {
      Eina.Log.Debug("function efl_ui_direction_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Grid)wrapper).SetDirection( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private static efl_ui_direction_set_delegate efl_ui_direction_set_static_delegate;


    private delegate Efl.Ui.SelectMode efl_ui_select_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Ui.SelectMode efl_ui_select_mode_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_select_mode_get_api_delegate> efl_ui_select_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_mode_get_api_delegate>(_Module, "efl_ui_select_mode_get");
    private static Efl.Ui.SelectMode select_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_select_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.SelectMode _ret_var = default(Efl.Ui.SelectMode);
         try {
            _ret_var = ((Grid)wrapper).GetSelectMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_select_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_select_mode_get_delegate efl_ui_select_mode_get_static_delegate;


    private delegate  void efl_ui_select_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.SelectMode mode);


    public delegate  void efl_ui_select_mode_set_api_delegate(System.IntPtr obj,   Efl.Ui.SelectMode mode);
    public static Efl.Eo.FunctionWrapper<efl_ui_select_mode_set_api_delegate> efl_ui_select_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_mode_set_api_delegate>(_Module, "efl_ui_select_mode_set");
    private static  void select_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectMode mode)
   {
      Eina.Log.Debug("function efl_ui_select_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Grid)wrapper).SetSelectMode( mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_select_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode);
      }
   }
   private static efl_ui_select_mode_set_delegate efl_ui_select_mode_set_static_delegate;


    private delegate Eina.Position2D_StructInternal efl_ui_scrollable_content_pos_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Position2D_StructInternal efl_ui_scrollable_content_pos_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_get_api_delegate> efl_ui_scrollable_content_pos_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_get_api_delegate>(_Module, "efl_ui_scrollable_content_pos_get");
    private static Eina.Position2D_StructInternal content_pos_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollable_content_pos_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Position2D _ret_var = default(Eina.Position2D);
         try {
            _ret_var = ((Grid)wrapper).GetContentPos();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Position2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_scrollable_content_pos_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_scrollable_content_pos_get_delegate efl_ui_scrollable_content_pos_get_static_delegate;


    private delegate  void efl_ui_scrollable_content_pos_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal pos);


    public delegate  void efl_ui_scrollable_content_pos_set_api_delegate(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_set_api_delegate> efl_ui_scrollable_content_pos_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_set_api_delegate>(_Module, "efl_ui_scrollable_content_pos_set");
    private static  void content_pos_set(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D_StructInternal pos)
   {
      Eina.Log.Debug("function efl_ui_scrollable_content_pos_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_pos = Eina.Position2D_StructConversion.ToManaged(pos);
                     
         try {
            ((Grid)wrapper).SetContentPos( _in_pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_scrollable_content_pos_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
      }
   }
   private static efl_ui_scrollable_content_pos_set_delegate efl_ui_scrollable_content_pos_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_ui_scrollable_content_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Size2D_StructInternal efl_ui_scrollable_content_size_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_size_get_api_delegate> efl_ui_scrollable_content_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_size_get_api_delegate>(_Module, "efl_ui_scrollable_content_size_get");
    private static Eina.Size2D_StructInternal content_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollable_content_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Grid)wrapper).GetContentSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_scrollable_content_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_scrollable_content_size_get_delegate efl_ui_scrollable_content_size_get_static_delegate;


    private delegate Eina.Rect_StructInternal efl_ui_scrollable_viewport_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Rect_StructInternal efl_ui_scrollable_viewport_geometry_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_viewport_geometry_get_api_delegate> efl_ui_scrollable_viewport_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_viewport_geometry_get_api_delegate>(_Module, "efl_ui_scrollable_viewport_geometry_get");
    private static Eina.Rect_StructInternal viewport_geometry_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollable_viewport_geometry_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((Grid)wrapper).GetViewportGeometry();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_scrollable_viewport_geometry_get_delegate efl_ui_scrollable_viewport_geometry_get_static_delegate;


    private delegate  void efl_ui_scrollable_bounce_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  out bool horiz,  [MarshalAs(UnmanagedType.U1)]  out bool vert);


    public delegate  void efl_ui_scrollable_bounce_enabled_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool horiz,  [MarshalAs(UnmanagedType.U1)]  out bool vert);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_get_api_delegate> efl_ui_scrollable_bounce_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_get_api_delegate>(_Module, "efl_ui_scrollable_bounce_enabled_get");
    private static  void bounce_enabled_get(System.IntPtr obj, System.IntPtr pd,  out bool horiz,  out bool vert)
   {
      Eina.Log.Debug("function efl_ui_scrollable_bounce_enabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           horiz = default(bool);      vert = default(bool);                     
         try {
            ((Grid)wrapper).GetBounceEnabled( out horiz,  out vert);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out horiz,  out vert);
      }
   }
   private static efl_ui_scrollable_bounce_enabled_get_delegate efl_ui_scrollable_bounce_enabled_get_static_delegate;


    private delegate  void efl_ui_scrollable_bounce_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool horiz,  [MarshalAs(UnmanagedType.U1)]  bool vert);


    public delegate  void efl_ui_scrollable_bounce_enabled_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool horiz,  [MarshalAs(UnmanagedType.U1)]  bool vert);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_set_api_delegate> efl_ui_scrollable_bounce_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_set_api_delegate>(_Module, "efl_ui_scrollable_bounce_enabled_set");
    private static  void bounce_enabled_set(System.IntPtr obj, System.IntPtr pd,  bool horiz,  bool vert)
   {
      Eina.Log.Debug("function efl_ui_scrollable_bounce_enabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Grid)wrapper).SetBounceEnabled( horiz,  vert);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  horiz,  vert);
      }
   }
   private static efl_ui_scrollable_bounce_enabled_set_delegate efl_ui_scrollable_bounce_enabled_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_scrollable_scroll_freeze_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_scrollable_scroll_freeze_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_get_api_delegate> efl_ui_scrollable_scroll_freeze_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_get_api_delegate>(_Module, "efl_ui_scrollable_scroll_freeze_get");
    private static bool scroll_freeze_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollable_scroll_freeze_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Grid)wrapper).GetScrollFreeze();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_scrollable_scroll_freeze_get_delegate efl_ui_scrollable_scroll_freeze_get_static_delegate;


    private delegate  void efl_ui_scrollable_scroll_freeze_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool freeze);


    public delegate  void efl_ui_scrollable_scroll_freeze_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool freeze);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_set_api_delegate> efl_ui_scrollable_scroll_freeze_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_set_api_delegate>(_Module, "efl_ui_scrollable_scroll_freeze_set");
    private static  void scroll_freeze_set(System.IntPtr obj, System.IntPtr pd,  bool freeze)
   {
      Eina.Log.Debug("function efl_ui_scrollable_scroll_freeze_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Grid)wrapper).SetScrollFreeze( freeze);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  freeze);
      }
   }
   private static efl_ui_scrollable_scroll_freeze_set_delegate efl_ui_scrollable_scroll_freeze_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_scrollable_scroll_hold_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_scrollable_scroll_hold_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_get_api_delegate> efl_ui_scrollable_scroll_hold_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_get_api_delegate>(_Module, "efl_ui_scrollable_scroll_hold_get");
    private static bool scroll_hold_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollable_scroll_hold_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Grid)wrapper).GetScrollHold();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_scrollable_scroll_hold_get_delegate efl_ui_scrollable_scroll_hold_get_static_delegate;


    private delegate  void efl_ui_scrollable_scroll_hold_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool hold);


    public delegate  void efl_ui_scrollable_scroll_hold_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool hold);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_set_api_delegate> efl_ui_scrollable_scroll_hold_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_set_api_delegate>(_Module, "efl_ui_scrollable_scroll_hold_set");
    private static  void scroll_hold_set(System.IntPtr obj, System.IntPtr pd,  bool hold)
   {
      Eina.Log.Debug("function efl_ui_scrollable_scroll_hold_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Grid)wrapper).SetScrollHold( hold);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hold);
      }
   }
   private static efl_ui_scrollable_scroll_hold_set_delegate efl_ui_scrollable_scroll_hold_set_static_delegate;


    private delegate  void efl_ui_scrollable_looping_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  out bool loop_h,  [MarshalAs(UnmanagedType.U1)]  out bool loop_v);


    public delegate  void efl_ui_scrollable_looping_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool loop_h,  [MarshalAs(UnmanagedType.U1)]  out bool loop_v);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_get_api_delegate> efl_ui_scrollable_looping_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_get_api_delegate>(_Module, "efl_ui_scrollable_looping_get");
    private static  void looping_get(System.IntPtr obj, System.IntPtr pd,  out bool loop_h,  out bool loop_v)
   {
      Eina.Log.Debug("function efl_ui_scrollable_looping_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           loop_h = default(bool);      loop_v = default(bool);                     
         try {
            ((Grid)wrapper).GetLooping( out loop_h,  out loop_v);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_looping_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out loop_h,  out loop_v);
      }
   }
   private static efl_ui_scrollable_looping_get_delegate efl_ui_scrollable_looping_get_static_delegate;


    private delegate  void efl_ui_scrollable_looping_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool loop_h,  [MarshalAs(UnmanagedType.U1)]  bool loop_v);


    public delegate  void efl_ui_scrollable_looping_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool loop_h,  [MarshalAs(UnmanagedType.U1)]  bool loop_v);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_set_api_delegate> efl_ui_scrollable_looping_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_set_api_delegate>(_Module, "efl_ui_scrollable_looping_set");
    private static  void looping_set(System.IntPtr obj, System.IntPtr pd,  bool loop_h,  bool loop_v)
   {
      Eina.Log.Debug("function efl_ui_scrollable_looping_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Grid)wrapper).SetLooping( loop_h,  loop_v);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_looping_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  loop_h,  loop_v);
      }
   }
   private static efl_ui_scrollable_looping_set_delegate efl_ui_scrollable_looping_set_static_delegate;


    private delegate Efl.Ui.ScrollBlock efl_ui_scrollable_movement_block_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Ui.ScrollBlock efl_ui_scrollable_movement_block_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_get_api_delegate> efl_ui_scrollable_movement_block_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_get_api_delegate>(_Module, "efl_ui_scrollable_movement_block_get");
    private static Efl.Ui.ScrollBlock movement_block_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollable_movement_block_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.ScrollBlock _ret_var = default(Efl.Ui.ScrollBlock);
         try {
            _ret_var = ((Grid)wrapper).GetMovementBlock();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_scrollable_movement_block_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_scrollable_movement_block_get_delegate efl_ui_scrollable_movement_block_get_static_delegate;


    private delegate  void efl_ui_scrollable_movement_block_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ScrollBlock block);


    public delegate  void efl_ui_scrollable_movement_block_set_api_delegate(System.IntPtr obj,   Efl.Ui.ScrollBlock block);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_set_api_delegate> efl_ui_scrollable_movement_block_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_set_api_delegate>(_Module, "efl_ui_scrollable_movement_block_set");
    private static  void movement_block_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ScrollBlock block)
   {
      Eina.Log.Debug("function efl_ui_scrollable_movement_block_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Grid)wrapper).SetMovementBlock( block);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_scrollable_movement_block_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  block);
      }
   }
   private static efl_ui_scrollable_movement_block_set_delegate efl_ui_scrollable_movement_block_set_static_delegate;


    private delegate  void efl_ui_scrollable_gravity_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);


    public delegate  void efl_ui_scrollable_gravity_get_api_delegate(System.IntPtr obj,   out double x,   out double y);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_get_api_delegate> efl_ui_scrollable_gravity_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_get_api_delegate>(_Module, "efl_ui_scrollable_gravity_get");
    private static  void gravity_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_ui_scrollable_gravity_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((Grid)wrapper).GetGravity( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_gravity_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private static efl_ui_scrollable_gravity_get_delegate efl_ui_scrollable_gravity_get_static_delegate;


    private delegate  void efl_ui_scrollable_gravity_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);


    public delegate  void efl_ui_scrollable_gravity_set_api_delegate(System.IntPtr obj,   double x,   double y);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_set_api_delegate> efl_ui_scrollable_gravity_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_set_api_delegate>(_Module, "efl_ui_scrollable_gravity_set");
    private static  void gravity_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_ui_scrollable_gravity_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Grid)wrapper).SetGravity( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_gravity_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private static efl_ui_scrollable_gravity_set_delegate efl_ui_scrollable_gravity_set_static_delegate;


    private delegate  void efl_ui_scrollable_match_content_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool w,  [MarshalAs(UnmanagedType.U1)]  bool h);


    public delegate  void efl_ui_scrollable_match_content_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool w,  [MarshalAs(UnmanagedType.U1)]  bool h);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_match_content_set_api_delegate> efl_ui_scrollable_match_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_match_content_set_api_delegate>(_Module, "efl_ui_scrollable_match_content_set");
    private static  void match_content_set(System.IntPtr obj, System.IntPtr pd,  bool w,  bool h)
   {
      Eina.Log.Debug("function efl_ui_scrollable_match_content_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Grid)wrapper).SetMatchContent( w,  h);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_match_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  w,  h);
      }
   }
   private static efl_ui_scrollable_match_content_set_delegate efl_ui_scrollable_match_content_set_static_delegate;


    private delegate Eina.Position2D_StructInternal efl_ui_scrollable_step_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Position2D_StructInternal efl_ui_scrollable_step_size_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_get_api_delegate> efl_ui_scrollable_step_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_get_api_delegate>(_Module, "efl_ui_scrollable_step_size_get");
    private static Eina.Position2D_StructInternal step_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollable_step_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Position2D _ret_var = default(Eina.Position2D);
         try {
            _ret_var = ((Grid)wrapper).GetStepSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Position2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_scrollable_step_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_scrollable_step_size_get_delegate efl_ui_scrollable_step_size_get_static_delegate;


    private delegate  void efl_ui_scrollable_step_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal step);


    public delegate  void efl_ui_scrollable_step_size_set_api_delegate(System.IntPtr obj,   Eina.Position2D_StructInternal step);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_set_api_delegate> efl_ui_scrollable_step_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_set_api_delegate>(_Module, "efl_ui_scrollable_step_size_set");
    private static  void step_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D_StructInternal step)
   {
      Eina.Log.Debug("function efl_ui_scrollable_step_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_step = Eina.Position2D_StructConversion.ToManaged(step);
                     
         try {
            ((Grid)wrapper).SetStepSize( _in_step);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_scrollable_step_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  step);
      }
   }
   private static efl_ui_scrollable_step_size_set_delegate efl_ui_scrollable_step_size_set_static_delegate;


    private delegate  void efl_ui_scrollable_scroll_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect_StructInternal rect,  [MarshalAs(UnmanagedType.U1)]  bool animation);


    public delegate  void efl_ui_scrollable_scroll_api_delegate(System.IntPtr obj,   Eina.Rect_StructInternal rect,  [MarshalAs(UnmanagedType.U1)]  bool animation);
    public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_api_delegate> efl_ui_scrollable_scroll_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_api_delegate>(_Module, "efl_ui_scrollable_scroll");
    private static  void scroll(System.IntPtr obj, System.IntPtr pd,  Eina.Rect_StructInternal rect,  bool animation)
   {
      Eina.Log.Debug("function efl_ui_scrollable_scroll was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_rect = Eina.Rect_StructConversion.ToManaged(rect);
                                       
         try {
            ((Grid)wrapper).Scroll( _in_rect,  animation);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_scroll_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rect,  animation);
      }
   }
   private static efl_ui_scrollable_scroll_delegate efl_ui_scrollable_scroll_static_delegate;


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
            ((Grid)wrapper).GetBarMode( out hbar,  out vbar);
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
            ((Grid)wrapper).SetBarMode( hbar,  vbar);
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
            ((Grid)wrapper).GetBarSize( out width,  out height);
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
            ((Grid)wrapper).GetBarPosition( out posx,  out posy);
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
            ((Grid)wrapper).SetBarPosition( posx,  posy);
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
            ((Grid)wrapper).UpdateBarVisibility();
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
