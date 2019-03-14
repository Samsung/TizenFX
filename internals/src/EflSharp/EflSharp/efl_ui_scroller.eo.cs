#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl ui scroller class</summary>
[ScrollerNativeInherit]
public class Scroller : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.Content,Efl.Ui.Scrollable,Efl.Ui.ScrollableInteractive,Efl.Ui.Scrollbar,Efl.Ui.WidgetFocusManager,Efl.Ui.Focus.Manager,Efl.Ui.Focus.ManagerSub
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.ScrollerNativeInherit nativeInherit = new Efl.Ui.ScrollerNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Scroller))
            return Efl.Ui.ScrollerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_scroller_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
   public Scroller(Efl.Object parent
         ,  System.String style = null) :
      base(efl_ui_scroller_class_get(), typeof(Scroller), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(style))
         SetStyle(Efl.Eo.Globals.GetParamHelper(style));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Scroller(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Scroller(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Scroller static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Scroller(obj.NativeHandle);
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
private static object ContentChangedEvtKey = new object();
   /// <summary>Sent after the content is set or unset using the current content object.</summary>
   public event EventHandler<Efl.ContentContentChangedEvt_Args> ContentChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ContentChangedEvt_delegate)) {
               eventHandlers.AddHandler(ContentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ContentChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContentChangedEvt.</summary>
   public void On_ContentChangedEvt(Efl.ContentContentChangedEvt_Args e)
   {
      EventHandler<Efl.ContentContentChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ContentContentChangedEvt_Args>)eventHandlers[ContentChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContentChangedEvt_delegate;
   private void on_ContentChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ContentContentChangedEvt_Args args = new Efl.ContentContentChangedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_ContentChangedEvt(args);
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

private static object RedirectChangedEvtKey = new object();
   /// <summary>Redirect object has changed, the old manager is passed as an event argument.
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ManagerRedirectChangedEvt_Args> RedirectChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_REDIRECT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_RedirectChangedEvt_delegate)) {
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
   /// <summary>After this event, the manager object will calculate relations in the graph. Can be used to add / remove children in a lazy fashion.
   /// 1.20</summary>
   public event EventHandler FlushPreEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_FLUSH_PRE";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_FlushPreEvt_delegate)) {
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
   /// <summary>Cached relationship calculation results have been invalidated.
   /// 1.20</summary>
   public event EventHandler CoordsDirtyEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_COORDS_DIRTY";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_CoordsDirtyEvt_delegate)) {
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

private static object Manager_focusChangedEvtKey = new object();
   /// <summary>The manager_focus property has changed. The previously focused object is passed as an event argument.
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ManagerManager_focusChangedEvt_Args> Manager_focusChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_MANAGER_FOCUS_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_Manager_focusChangedEvt_delegate)) {
               eventHandlers.AddHandler(Manager_focusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_MANAGER_FOCUS_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Manager_focusChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Manager_focusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Manager_focusChangedEvt.</summary>
   public void On_Manager_focusChangedEvt(Efl.Ui.Focus.ManagerManager_focusChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ManagerManager_focusChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ManagerManager_focusChangedEvt_Args>)eventHandlers[Manager_focusChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Manager_focusChangedEvt_delegate;
   private void on_Manager_focusChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ManagerManager_focusChangedEvt_Args args = new Efl.Ui.Focus.ManagerManager_focusChangedEvt_Args();
      args.arg = new Efl.Ui.Focus.ObjectConcrete(evt.Info);
      try {
         On_Manager_focusChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Dirty_logic_freezeChangedEvtKey = new object();
   /// <summary>Called when this focus manager is frozen or thawed, even_info beeing <c>true</c> indicates that it is now frozen, <c>false</c> indicates that it is thawed.
   /// 1.20</summary>
   public event EventHandler<Efl.Ui.Focus.ManagerDirty_logic_freezeChangedEvt_Args> Dirty_logic_freezeChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_DIRTY_LOGIC_FREEZE_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_Dirty_logic_freezeChangedEvt_delegate)) {
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

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ContentChangedEvt_delegate = new Efl.EventCb(on_ContentChangedEvt_NativeCallback);
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
      evt_RedirectChangedEvt_delegate = new Efl.EventCb(on_RedirectChangedEvt_NativeCallback);
      evt_FlushPreEvt_delegate = new Efl.EventCb(on_FlushPreEvt_NativeCallback);
      evt_CoordsDirtyEvt_delegate = new Efl.EventCb(on_CoordsDirtyEvt_NativeCallback);
      evt_Manager_focusChangedEvt_delegate = new Efl.EventCb(on_Manager_focusChangedEvt_NativeCallback);
      evt_Dirty_logic_freezeChangedEvt_delegate = new Efl.EventCb(on_Dirty_logic_freezeChangedEvt_NativeCallback);
   }
   /// <summary>Swallowed sub-object contained in this object.</summary>
   /// <returns>The object to swallow.</returns>
   virtual public Efl.Gfx.Entity GetContent() {
       var _ret_var = Efl.ContentNativeInherit.efl_content_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Swallowed sub-object contained in this object.</summary>
   /// <param name="content">The object to swallow.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool SetContent( Efl.Gfx.Entity content) {
                         var _ret_var = Efl.ContentNativeInherit.efl_content_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), content);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Unswallow the object in the current container and return it.</summary>
   /// <returns>Unswallowed object</returns>
   virtual public Efl.Gfx.Entity UnsetContent() {
       var _ret_var = Efl.ContentNativeInherit.efl_content_unset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
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
   /// <summary>If the widget needs a focus manager, this function will be called.
   /// It can be used and overriden to inject your own manager or set custom options on the focus manager.</summary>
   /// <param name="root">The logical root object for focus.</param>
   /// <returns>The focus manager.</returns>
   virtual public Efl.Ui.Focus.Manager FocusManagerCreate( Efl.Ui.Focus.Object root) {
                         var _ret_var = Efl.Ui.WidgetFocusManagerNativeInherit.efl_ui_widget_focus_manager_create_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), root);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>The element which is currently focused by this manager
   /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next non-logical object is selected instead. If there is no such object, focus does not change.
   /// 1.20</summary>
   /// <returns>Currently focused element.
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Object GetManagerFocus() {
       var _ret_var = Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_focus_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The element which is currently focused by this manager
   /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next non-logical object is selected instead. If there is no such object, focus does not change.
   /// 1.20</summary>
   /// <param name="focus">Currently focused element.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetManagerFocus( Efl.Ui.Focus.Object focus) {
                         Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_focus_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), focus);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Add another manager to serve the move requests.
   /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
   /// 1.20</summary>
   /// <returns>The redirect manager.
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Manager GetRedirect() {
       var _ret_var = Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_redirect_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Add another manager to serve the move requests.
   /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
   /// 1.20</summary>
   /// <param name="redirect">The redirect manager.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetRedirect( Efl.Ui.Focus.Manager redirect) {
                         Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_redirect_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), redirect);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The list of elements which are at the border of the graph.
   /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.Manager.Move"/>
   /// 1.20</summary>
   /// <returns>An iterator over the border objects.
   /// 1.20</returns>
   virtual public Eina.Iterator<Efl.Ui.Focus.Object> GetBorderElements() {
       var _ret_var = Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_border_elements_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Ui.Focus.Object>(_ret_var, false, false);
 }
   /// <summary>Get all elements that are at the border of the viewport
   /// Every element returned by this is located inside the viewport rectangle, but has a right, left, down or up neighbor outside the viewport.
   /// 1.20</summary>
   /// <param name="viewport">The rectangle defining the viewport.
   /// 1.20</param>
   /// <returns>The list of border objects.
   /// 1.20</returns>
   virtual public Eina.Iterator<Efl.Ui.Focus.Object> GetViewportElements( Eina.Rect viewport) {
       var _in_viewport = Eina.Rect_StructConversion.ToInternal(viewport);
                  var _ret_var = Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_viewport_elements_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_viewport);
      Eina.Error.RaiseIfUnhandledException();
                  return new Eina.Iterator<Efl.Ui.Focus.Object>(_ret_var, false, false);
 }
   /// <summary>Root node for all logical subtrees.
   /// This property can only be set once.
   /// 1.20</summary>
   /// <returns>Will be registered into this manager object.
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Object GetRoot() {
       var _ret_var = Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_root_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Root node for all logical subtrees.
   /// This property can only be set once.
   /// 1.20</summary>
   /// <param name="root">Will be registered into this manager object.
   /// 1.20</param>
   /// <returns>If <c>true</c>, this is the root node
   /// 1.20</returns>
   virtual public bool SetRoot( Efl.Ui.Focus.Object root) {
                         var _ret_var = Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_root_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), root);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Move the focus in the given direction.
   /// This call flushes all changes. This means all changes between the last flush and now are computed.
   /// 1.20</summary>
   /// <param name="direction">The direction to move to.
   /// 1.20</param>
   /// <returns>The element which is now focused.
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Object Move( Efl.Ui.Focus.Direction direction) {
                         var _ret_var = Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_move_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), direction);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Return the object in the <c>direction</c> from <c>child</c>.
   /// 1.20</summary>
   /// <param name="direction">Direction to move focus.
   /// 1.20</param>
   /// <param name="child">The child to move from. Pass <c>null</c> to indicate the currently focused child.
   /// 1.20</param>
   /// <param name="logical">Wether you want to have a logical node as result or a non-logical. Note, in a <see cref="Efl.Ui.Focus.Manager.Move"/> call no logical node will get focus.
   /// 1.20</param>
   /// <returns>Object that would receive focus if moved in the given direction.
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Object MoveRequest( Efl.Ui.Focus.Direction direction,  Efl.Ui.Focus.Object child,  bool logical) {
                                                             var _ret_var = Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_request_move_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), direction,  child,  logical);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }
   /// <summary>Return the widget in the direction next.
   /// The returned widget is a child of <c>root</c>. It&apos;s guaranteed that child will not be prepared once again, so you can call this function inside a <see cref="Efl.Ui.Focus.Object.SetupOrder"/> call.
   /// 1.20</summary>
   /// <param name="root">Parent for returned child.
   /// 1.20</param>
   /// <returns>Child of passed parameter.
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Object RequestSubchild( Efl.Ui.Focus.Object root) {
                         var _ret_var = Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_request_subchild_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), root);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>This will fetch the data from a registered node.
   /// Be aware this function will trigger a computation of all dirty nodes.
   /// 1.20</summary>
   /// <param name="child">The child object to inspect.
   /// 1.20</param>
   /// <returns>The list of relations starting from <c>child</c>.
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Relations Fetch( Efl.Ui.Focus.Object child) {
                         var _ret_var = Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_fetch_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), child);
      Eina.Error.RaiseIfUnhandledException();
                  var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.Focus.Relations>(_ret_var);
      Marshal.FreeHGlobal(_ret_var);
      return __ret_tmp;
 }
   /// <summary>Return the last logical object.
   /// The returned object is the last object that would be returned if you start at the root and move the direction into next.
   /// 1.20</summary>
   /// <returns>Last object.
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.ManagerLogicalEndDetail LogicalEnd() {
       var _ret_var = Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_logical_end_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Efl.Ui.Focus.ManagerLogicalEndDetail_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Reset the history stack of this manager object. This means the uppermost element will be unfocused, and all other elements will be removed from the remembered list.
   /// You should focus another element immediately after calling this, in order to always have a focused object.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void ResetHistory() {
       Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_reset_history_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Remove the uppermost history element, and focus the previous one.
   /// If there is an element that was focused before, it will be used. Otherwise, the best fitting element from the registered elements will be focused.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void PopHistoryStack() {
       Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_pop_history_stack_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Called when this manager is set as redirect.
   /// In case that this is called as an result of a move call, <c>direction</c> and <c>entry</c> will be set to the direction of the move call, and the <c>entry</c> object will be set to the object that had this manager as redirect property.
   /// 1.20</summary>
   /// <param name="direction">The direction in which this should be setup.
   /// 1.20</param>
   /// <param name="entry">The object that caused this manager to be redirect.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetupOnFirstTouch( Efl.Ui.Focus.Direction direction,  Efl.Ui.Focus.Object entry) {
                                           Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_setup_on_first_touch_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), direction,  entry);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>This disables the cache invalidation when an object is moved.
   /// Even if an object is moved, the focus manager will not recalculate its relations. This can be used when you know that the set of widgets in the focus manager is moved the same way, so the relations between the widets in the set do not change and the complex calculations can be avoided. Use <see cref="Efl.Ui.Focus.Manager.DirtyLogicUnfreeze"/> to re-enable relationship calculation.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void FreezeDirtyLogic() {
       Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_dirty_logic_freeze_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>This enables the cache invalidation when an object is moved.
   /// This is the counterpart to <see cref="Efl.Ui.Focus.Manager.FreezeDirtyLogic"/>.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void DirtyLogicUnfreeze() {
       Efl.Ui.Focus.ManagerNativeInherit.efl_ui_focus_manager_dirty_logic_unfreeze_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Swallowed sub-object contained in this object.</summary>
/// <value>The object to swallow.</value>
   public Efl.Gfx.Entity Content {
      get { return GetContent(); }
      set { SetContent( value); }
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
   /// <summary>The element which is currently focused by this manager
/// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next non-logical object is selected instead. If there is no such object, focus does not change.
/// 1.20</summary>
/// <value>Currently focused element.
/// 1.20</value>
   public Efl.Ui.Focus.Object ManagerFocus {
      get { return GetManagerFocus(); }
      set { SetManagerFocus( value); }
   }
   /// <summary>Add another manager to serve the move requests.
/// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
/// 1.20</summary>
/// <value>The redirect manager.
/// 1.20</value>
   public Efl.Ui.Focus.Manager Redirect {
      get { return GetRedirect(); }
      set { SetRedirect( value); }
   }
   /// <summary>The list of elements which are at the border of the graph.
/// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.Manager.Move"/>
/// 1.20</summary>
/// <value>An iterator over the border objects.
/// 1.20</value>
   public Eina.Iterator<Efl.Ui.Focus.Object> BorderElements {
      get { return GetBorderElements(); }
   }
   /// <summary>Root node for all logical subtrees.
/// This property can only be set once.
/// 1.20</summary>
/// <value>Will be registered into this manager object.
/// 1.20</value>
   public Efl.Ui.Focus.Object Root {
      get { return GetRoot(); }
      set { SetRoot( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Scroller.efl_ui_scroller_class_get();
   }
}
public class ScrollerNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_content_get_static_delegate == null)
      efl_content_get_static_delegate = new efl_content_get_delegate(content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_content_get_static_delegate)});
      if (efl_content_set_static_delegate == null)
      efl_content_set_static_delegate = new efl_content_set_delegate(content_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_content_set_static_delegate)});
      if (efl_content_unset_static_delegate == null)
      efl_content_unset_static_delegate = new efl_content_unset_delegate(content_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_content_unset_static_delegate)});
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
      if (efl_ui_widget_focus_manager_create_static_delegate == null)
      efl_ui_widget_focus_manager_create_static_delegate = new efl_ui_widget_focus_manager_create_delegate(focus_manager_create);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_widget_focus_manager_create"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_manager_create_static_delegate)});
      if (efl_ui_focus_manager_focus_get_static_delegate == null)
      efl_ui_focus_manager_focus_get_static_delegate = new efl_ui_focus_manager_focus_get_delegate(manager_focus_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_focus_get_static_delegate)});
      if (efl_ui_focus_manager_focus_set_static_delegate == null)
      efl_ui_focus_manager_focus_set_static_delegate = new efl_ui_focus_manager_focus_set_delegate(manager_focus_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_focus_set_static_delegate)});
      if (efl_ui_focus_manager_redirect_get_static_delegate == null)
      efl_ui_focus_manager_redirect_get_static_delegate = new efl_ui_focus_manager_redirect_get_delegate(redirect_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_redirect_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_redirect_get_static_delegate)});
      if (efl_ui_focus_manager_redirect_set_static_delegate == null)
      efl_ui_focus_manager_redirect_set_static_delegate = new efl_ui_focus_manager_redirect_set_delegate(redirect_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_redirect_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_redirect_set_static_delegate)});
      if (efl_ui_focus_manager_border_elements_get_static_delegate == null)
      efl_ui_focus_manager_border_elements_get_static_delegate = new efl_ui_focus_manager_border_elements_get_delegate(border_elements_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_border_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_border_elements_get_static_delegate)});
      if (efl_ui_focus_manager_viewport_elements_get_static_delegate == null)
      efl_ui_focus_manager_viewport_elements_get_static_delegate = new efl_ui_focus_manager_viewport_elements_get_delegate(viewport_elements_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_viewport_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_viewport_elements_get_static_delegate)});
      if (efl_ui_focus_manager_root_get_static_delegate == null)
      efl_ui_focus_manager_root_get_static_delegate = new efl_ui_focus_manager_root_get_delegate(root_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_root_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_root_get_static_delegate)});
      if (efl_ui_focus_manager_root_set_static_delegate == null)
      efl_ui_focus_manager_root_set_static_delegate = new efl_ui_focus_manager_root_set_delegate(root_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_root_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_root_set_static_delegate)});
      if (efl_ui_focus_manager_move_static_delegate == null)
      efl_ui_focus_manager_move_static_delegate = new efl_ui_focus_manager_move_delegate(move);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_move"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_move_static_delegate)});
      if (efl_ui_focus_manager_request_move_static_delegate == null)
      efl_ui_focus_manager_request_move_static_delegate = new efl_ui_focus_manager_request_move_delegate(request_move);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_request_move"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_request_move_static_delegate)});
      if (efl_ui_focus_manager_request_subchild_static_delegate == null)
      efl_ui_focus_manager_request_subchild_static_delegate = new efl_ui_focus_manager_request_subchild_delegate(request_subchild);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_request_subchild"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_request_subchild_static_delegate)});
      if (efl_ui_focus_manager_fetch_static_delegate == null)
      efl_ui_focus_manager_fetch_static_delegate = new efl_ui_focus_manager_fetch_delegate(fetch);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_fetch"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_fetch_static_delegate)});
      if (efl_ui_focus_manager_logical_end_static_delegate == null)
      efl_ui_focus_manager_logical_end_static_delegate = new efl_ui_focus_manager_logical_end_delegate(logical_end);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_logical_end"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_logical_end_static_delegate)});
      if (efl_ui_focus_manager_reset_history_static_delegate == null)
      efl_ui_focus_manager_reset_history_static_delegate = new efl_ui_focus_manager_reset_history_delegate(reset_history);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_reset_history"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_reset_history_static_delegate)});
      if (efl_ui_focus_manager_pop_history_stack_static_delegate == null)
      efl_ui_focus_manager_pop_history_stack_static_delegate = new efl_ui_focus_manager_pop_history_stack_delegate(pop_history_stack);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_pop_history_stack"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_pop_history_stack_static_delegate)});
      if (efl_ui_focus_manager_setup_on_first_touch_static_delegate == null)
      efl_ui_focus_manager_setup_on_first_touch_static_delegate = new efl_ui_focus_manager_setup_on_first_touch_delegate(setup_on_first_touch);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_setup_on_first_touch"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_setup_on_first_touch_static_delegate)});
      if (efl_ui_focus_manager_dirty_logic_freeze_static_delegate == null)
      efl_ui_focus_manager_dirty_logic_freeze_static_delegate = new efl_ui_focus_manager_dirty_logic_freeze_delegate(dirty_logic_freeze);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_dirty_logic_freeze"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_dirty_logic_freeze_static_delegate)});
      if (efl_ui_focus_manager_dirty_logic_unfreeze_static_delegate == null)
      efl_ui_focus_manager_dirty_logic_unfreeze_static_delegate = new efl_ui_focus_manager_dirty_logic_unfreeze_delegate(dirty_logic_unfreeze);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_manager_dirty_logic_unfreeze"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_dirty_logic_unfreeze_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Scroller.efl_ui_scroller_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Scroller.efl_ui_scroller_class_get();
   }


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_content_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_content_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_content_get_api_delegate> efl_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_content_get_api_delegate>(_Module, "efl_content_get");
    private static Efl.Gfx.Entity content_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Scroller)wrapper).GetContent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_content_get_delegate efl_content_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
    public static Efl.Eo.FunctionWrapper<efl_content_set_api_delegate> efl_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_content_set_api_delegate>(_Module, "efl_content_set");
    private static bool content_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity content)
   {
      Eina.Log.Debug("function efl_content_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Scroller)wrapper).SetContent( content);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  content);
      }
   }
   private static efl_content_set_delegate efl_content_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_content_unset_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_content_unset_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate> efl_content_unset_ptr = new Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate>(_Module, "efl_content_unset");
    private static Efl.Gfx.Entity content_unset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_unset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((Scroller)wrapper).UnsetContent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_content_unset_delegate efl_content_unset_static_delegate;


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
            _ret_var = ((Scroller)wrapper).GetContentPos();
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
            ((Scroller)wrapper).SetContentPos( _in_pos);
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
            _ret_var = ((Scroller)wrapper).GetContentSize();
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
            _ret_var = ((Scroller)wrapper).GetViewportGeometry();
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
            ((Scroller)wrapper).GetBounceEnabled( out horiz,  out vert);
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
            ((Scroller)wrapper).SetBounceEnabled( horiz,  vert);
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
            _ret_var = ((Scroller)wrapper).GetScrollFreeze();
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
            ((Scroller)wrapper).SetScrollFreeze( freeze);
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
            _ret_var = ((Scroller)wrapper).GetScrollHold();
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
            ((Scroller)wrapper).SetScrollHold( hold);
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
            ((Scroller)wrapper).GetLooping( out loop_h,  out loop_v);
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
            ((Scroller)wrapper).SetLooping( loop_h,  loop_v);
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
            _ret_var = ((Scroller)wrapper).GetMovementBlock();
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
            ((Scroller)wrapper).SetMovementBlock( block);
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
            ((Scroller)wrapper).GetGravity( out x,  out y);
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
            ((Scroller)wrapper).SetGravity( x,  y);
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
            ((Scroller)wrapper).SetMatchContent( w,  h);
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
            _ret_var = ((Scroller)wrapper).GetStepSize();
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
            ((Scroller)wrapper).SetStepSize( _in_step);
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
            ((Scroller)wrapper).Scroll( _in_rect,  animation);
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
            ((Scroller)wrapper).GetBarMode( out hbar,  out vbar);
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
            ((Scroller)wrapper).SetBarMode( hbar,  vbar);
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
            ((Scroller)wrapper).GetBarSize( out width,  out height);
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
            ((Scroller)wrapper).GetBarPosition( out posx,  out posy);
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
            ((Scroller)wrapper).SetBarPosition( posx,  posy);
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
            ((Scroller)wrapper).UpdateBarVisibility();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_scrollbar_bar_visibility_update_delegate efl_ui_scrollbar_bar_visibility_update_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Manager efl_ui_widget_focus_manager_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object root);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.Manager efl_ui_widget_focus_manager_create_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object root);
    public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_manager_create_api_delegate> efl_ui_widget_focus_manager_create_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_manager_create_api_delegate>(_Module, "efl_ui_widget_focus_manager_create");
    private static Efl.Ui.Focus.Manager focus_manager_create(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Object root)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_manager_create was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Ui.Focus.Manager _ret_var = default(Efl.Ui.Focus.Manager);
         try {
            _ret_var = ((Scroller)wrapper).FocusManagerCreate( root);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_widget_focus_manager_create_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  root);
      }
   }
   private static efl_ui_widget_focus_manager_create_delegate efl_ui_widget_focus_manager_create_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_manager_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.Object efl_ui_focus_manager_focus_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_focus_get_api_delegate> efl_ui_focus_manager_focus_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_focus_get_api_delegate>(_Module, "efl_ui_focus_manager_focus_get");
    private static Efl.Ui.Focus.Object manager_focus_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_focus_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Object _ret_var = default(Efl.Ui.Focus.Object);
         try {
            _ret_var = ((Scroller)wrapper).GetManagerFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_manager_focus_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_manager_focus_get_delegate efl_ui_focus_manager_focus_get_static_delegate;


    private delegate  void efl_ui_focus_manager_focus_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object focus);


    public delegate  void efl_ui_focus_manager_focus_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object focus);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_focus_set_api_delegate> efl_ui_focus_manager_focus_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_focus_set_api_delegate>(_Module, "efl_ui_focus_manager_focus_set");
    private static  void manager_focus_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Object focus)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_focus_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Scroller)wrapper).SetManagerFocus( focus);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_manager_focus_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  focus);
      }
   }
   private static efl_ui_focus_manager_focus_set_delegate efl_ui_focus_manager_focus_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Manager efl_ui_focus_manager_redirect_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.Manager efl_ui_focus_manager_redirect_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_redirect_get_api_delegate> efl_ui_focus_manager_redirect_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_redirect_get_api_delegate>(_Module, "efl_ui_focus_manager_redirect_get");
    private static Efl.Ui.Focus.Manager redirect_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_redirect_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Manager _ret_var = default(Efl.Ui.Focus.Manager);
         try {
            _ret_var = ((Scroller)wrapper).GetRedirect();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_manager_redirect_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_manager_redirect_get_delegate efl_ui_focus_manager_redirect_get_static_delegate;


    private delegate  void efl_ui_focus_manager_redirect_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager redirect);


    public delegate  void efl_ui_focus_manager_redirect_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager redirect);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_redirect_set_api_delegate> efl_ui_focus_manager_redirect_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_redirect_set_api_delegate>(_Module, "efl_ui_focus_manager_redirect_set");
    private static  void redirect_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Manager redirect)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_redirect_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Scroller)wrapper).SetRedirect( redirect);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_manager_redirect_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  redirect);
      }
   }
   private static efl_ui_focus_manager_redirect_set_delegate efl_ui_focus_manager_redirect_set_static_delegate;


    private delegate  System.IntPtr efl_ui_focus_manager_border_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_ui_focus_manager_border_elements_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_border_elements_get_api_delegate> efl_ui_focus_manager_border_elements_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_border_elements_get_api_delegate>(_Module, "efl_ui_focus_manager_border_elements_get");
    private static  System.IntPtr border_elements_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_border_elements_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Ui.Focus.Object> _ret_var = default(Eina.Iterator<Efl.Ui.Focus.Object>);
         try {
            _ret_var = ((Scroller)wrapper).GetBorderElements();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_ui_focus_manager_border_elements_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_manager_border_elements_get_delegate efl_ui_focus_manager_border_elements_get_static_delegate;


    private delegate  System.IntPtr efl_ui_focus_manager_viewport_elements_get_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect_StructInternal viewport);


    public delegate  System.IntPtr efl_ui_focus_manager_viewport_elements_get_api_delegate(System.IntPtr obj,   Eina.Rect_StructInternal viewport);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_viewport_elements_get_api_delegate> efl_ui_focus_manager_viewport_elements_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_viewport_elements_get_api_delegate>(_Module, "efl_ui_focus_manager_viewport_elements_get");
    private static  System.IntPtr viewport_elements_get(System.IntPtr obj, System.IntPtr pd,  Eina.Rect_StructInternal viewport)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_viewport_elements_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_viewport = Eina.Rect_StructConversion.ToManaged(viewport);
                     Eina.Iterator<Efl.Ui.Focus.Object> _ret_var = default(Eina.Iterator<Efl.Ui.Focus.Object>);
         try {
            _ret_var = ((Scroller)wrapper).GetViewportElements( _in_viewport);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var.Handle;
      } else {
         return efl_ui_focus_manager_viewport_elements_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  viewport);
      }
   }
   private static efl_ui_focus_manager_viewport_elements_get_delegate efl_ui_focus_manager_viewport_elements_get_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_manager_root_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.Object efl_ui_focus_manager_root_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_root_get_api_delegate> efl_ui_focus_manager_root_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_root_get_api_delegate>(_Module, "efl_ui_focus_manager_root_get");
    private static Efl.Ui.Focus.Object root_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_root_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Object _ret_var = default(Efl.Ui.Focus.Object);
         try {
            _ret_var = ((Scroller)wrapper).GetRoot();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_manager_root_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_manager_root_get_delegate efl_ui_focus_manager_root_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_manager_root_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object root);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_focus_manager_root_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object root);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_root_set_api_delegate> efl_ui_focus_manager_root_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_root_set_api_delegate>(_Module, "efl_ui_focus_manager_root_set");
    private static bool root_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Object root)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_root_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Scroller)wrapper).SetRoot( root);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_focus_manager_root_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  root);
      }
   }
   private static efl_ui_focus_manager_root_set_delegate efl_ui_focus_manager_root_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_manager_move_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.Direction direction);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.Object efl_ui_focus_manager_move_api_delegate(System.IntPtr obj,   Efl.Ui.Focus.Direction direction);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_move_api_delegate> efl_ui_focus_manager_move_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_move_api_delegate>(_Module, "efl_ui_focus_manager_move");
    private static Efl.Ui.Focus.Object move(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction direction)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_move was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Ui.Focus.Object _ret_var = default(Efl.Ui.Focus.Object);
         try {
            _ret_var = ((Scroller)wrapper).Move( direction);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_focus_manager_move_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  direction);
      }
   }
   private static efl_ui_focus_manager_move_delegate efl_ui_focus_manager_move_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_manager_request_move_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child,  [MarshalAs(UnmanagedType.U1)]  bool logical);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.Object efl_ui_focus_manager_request_move_api_delegate(System.IntPtr obj,   Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child,  [MarshalAs(UnmanagedType.U1)]  bool logical);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_request_move_api_delegate> efl_ui_focus_manager_request_move_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_request_move_api_delegate>(_Module, "efl_ui_focus_manager_request_move");
    private static Efl.Ui.Focus.Object request_move(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction direction,  Efl.Ui.Focus.Object child,  bool logical)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_request_move was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        Efl.Ui.Focus.Object _ret_var = default(Efl.Ui.Focus.Object);
         try {
            _ret_var = ((Scroller)wrapper).MoveRequest( direction,  child,  logical);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_ui_focus_manager_request_move_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  direction,  child,  logical);
      }
   }
   private static efl_ui_focus_manager_request_move_delegate efl_ui_focus_manager_request_move_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_manager_request_subchild_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object root);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Ui.Focus.Object efl_ui_focus_manager_request_subchild_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object root);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_request_subchild_api_delegate> efl_ui_focus_manager_request_subchild_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_request_subchild_api_delegate>(_Module, "efl_ui_focus_manager_request_subchild");
    private static Efl.Ui.Focus.Object request_subchild(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Object root)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_request_subchild was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Ui.Focus.Object _ret_var = default(Efl.Ui.Focus.Object);
         try {
            _ret_var = ((Scroller)wrapper).RequestSubchild( root);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_focus_manager_request_subchild_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  root);
      }
   }
   private static efl_ui_focus_manager_request_subchild_delegate efl_ui_focus_manager_request_subchild_static_delegate;


    private delegate  System.IntPtr efl_ui_focus_manager_fetch_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child);


    public delegate  System.IntPtr efl_ui_focus_manager_fetch_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_fetch_api_delegate> efl_ui_focus_manager_fetch_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_fetch_api_delegate>(_Module, "efl_ui_focus_manager_fetch");
    private static  System.IntPtr fetch(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Object child)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_fetch was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Ui.Focus.Relations _ret_var = default(Efl.Ui.Focus.Relations);
         try {
            _ret_var = ((Scroller)wrapper).Fetch( child);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);
      } else {
         return efl_ui_focus_manager_fetch_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child);
      }
   }
   private static efl_ui_focus_manager_fetch_delegate efl_ui_focus_manager_fetch_static_delegate;


    private delegate Efl.Ui.Focus.ManagerLogicalEndDetail_StructInternal efl_ui_focus_manager_logical_end_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Ui.Focus.ManagerLogicalEndDetail_StructInternal efl_ui_focus_manager_logical_end_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_logical_end_api_delegate> efl_ui_focus_manager_logical_end_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_logical_end_api_delegate>(_Module, "efl_ui_focus_manager_logical_end");
    private static Efl.Ui.Focus.ManagerLogicalEndDetail_StructInternal logical_end(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_logical_end was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.ManagerLogicalEndDetail _ret_var = default(Efl.Ui.Focus.ManagerLogicalEndDetail);
         try {
            _ret_var = ((Scroller)wrapper).LogicalEnd();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Ui.Focus.ManagerLogicalEndDetail_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_focus_manager_logical_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_manager_logical_end_delegate efl_ui_focus_manager_logical_end_static_delegate;


    private delegate  void efl_ui_focus_manager_reset_history_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_focus_manager_reset_history_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_reset_history_api_delegate> efl_ui_focus_manager_reset_history_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_reset_history_api_delegate>(_Module, "efl_ui_focus_manager_reset_history");
    private static  void reset_history(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_reset_history was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Scroller)wrapper).ResetHistory();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_manager_reset_history_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_manager_reset_history_delegate efl_ui_focus_manager_reset_history_static_delegate;


    private delegate  void efl_ui_focus_manager_pop_history_stack_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_focus_manager_pop_history_stack_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_pop_history_stack_api_delegate> efl_ui_focus_manager_pop_history_stack_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_pop_history_stack_api_delegate>(_Module, "efl_ui_focus_manager_pop_history_stack");
    private static  void pop_history_stack(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_pop_history_stack was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Scroller)wrapper).PopHistoryStack();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_manager_pop_history_stack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_manager_pop_history_stack_delegate efl_ui_focus_manager_pop_history_stack_static_delegate;


    private delegate  void efl_ui_focus_manager_setup_on_first_touch_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object entry);


    public delegate  void efl_ui_focus_manager_setup_on_first_touch_api_delegate(System.IntPtr obj,   Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object entry);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_setup_on_first_touch_api_delegate> efl_ui_focus_manager_setup_on_first_touch_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_setup_on_first_touch_api_delegate>(_Module, "efl_ui_focus_manager_setup_on_first_touch");
    private static  void setup_on_first_touch(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction direction,  Efl.Ui.Focus.Object entry)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_setup_on_first_touch was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Scroller)wrapper).SetupOnFirstTouch( direction,  entry);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_focus_manager_setup_on_first_touch_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  direction,  entry);
      }
   }
   private static efl_ui_focus_manager_setup_on_first_touch_delegate efl_ui_focus_manager_setup_on_first_touch_static_delegate;


    private delegate  void efl_ui_focus_manager_dirty_logic_freeze_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_focus_manager_dirty_logic_freeze_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_dirty_logic_freeze_api_delegate> efl_ui_focus_manager_dirty_logic_freeze_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_dirty_logic_freeze_api_delegate>(_Module, "efl_ui_focus_manager_dirty_logic_freeze");
    private static  void dirty_logic_freeze(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_dirty_logic_freeze was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Scroller)wrapper).FreezeDirtyLogic();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_manager_dirty_logic_freeze_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_manager_dirty_logic_freeze_delegate efl_ui_focus_manager_dirty_logic_freeze_static_delegate;


    private delegate  void efl_ui_focus_manager_dirty_logic_unfreeze_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_focus_manager_dirty_logic_unfreeze_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_dirty_logic_unfreeze_api_delegate> efl_ui_focus_manager_dirty_logic_unfreeze_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_dirty_logic_unfreeze_api_delegate>(_Module, "efl_ui_focus_manager_dirty_logic_unfreeze");
    private static  void dirty_logic_unfreeze(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_dirty_logic_unfreeze was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Scroller)wrapper).DirtyLogicUnfreeze();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_manager_dirty_logic_unfreeze_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_manager_dirty_logic_unfreeze_delegate efl_ui_focus_manager_dirty_logic_unfreeze_static_delegate;
}
} } 
