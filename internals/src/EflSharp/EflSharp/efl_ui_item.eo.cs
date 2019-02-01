#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Item abstract class for pack widget. All item have to be inherited from this class.</summary>
[ItemNativeInherit]
public class Item : Efl.Ui.Layout, Efl.Eo.IWrapper,Efl.Ui.Clickable,Efl.Ui.Selectable
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.ItemNativeInherit nativeInherit = new Efl.Ui.ItemNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Item))
            return Efl.Ui.ItemNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Item obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_item_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Item(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Item", efl_ui_item_class_get(), typeof(Item), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Item(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Item(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Item static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Item(obj.NativeHandle);
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
private static object ClickedEvtKey = new object();
   /// <summary>Called when object is clicked</summary>
   public event EventHandler ClickedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_CLICKED";
            if (add_cpp_event_handler(key, this.evt_ClickedEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ClickedDoubleEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ClickedTripleEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ClickedRightEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_PressedEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_UnpressedEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_LongpressedEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_RepeatedEvt_delegate)) {
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

private static object SelectedEvtKey = new object();
   /// <summary>Called when selected</summary>
   public event EventHandler SelectedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SELECTED";
            if (add_cpp_event_handler(key, this.evt_SelectedEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_UnselectedEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_SelectionPasteEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_SelectionCopyEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_SelectionCutEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_SelectionStartEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_Efl_Ui_Selectable_SelectionChangedEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_SelectionClearedEvt_delegate)) {
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
      evt_ClickedEvt_delegate = new Efl.EventCb(on_ClickedEvt_NativeCallback);
      evt_ClickedDoubleEvt_delegate = new Efl.EventCb(on_ClickedDoubleEvt_NativeCallback);
      evt_ClickedTripleEvt_delegate = new Efl.EventCb(on_ClickedTripleEvt_NativeCallback);
      evt_ClickedRightEvt_delegate = new Efl.EventCb(on_ClickedRightEvt_NativeCallback);
      evt_PressedEvt_delegate = new Efl.EventCb(on_PressedEvt_NativeCallback);
      evt_UnpressedEvt_delegate = new Efl.EventCb(on_UnpressedEvt_NativeCallback);
      evt_LongpressedEvt_delegate = new Efl.EventCb(on_LongpressedEvt_NativeCallback);
      evt_RepeatedEvt_delegate = new Efl.EventCb(on_RepeatedEvt_NativeCallback);
      evt_SelectedEvt_delegate = new Efl.EventCb(on_SelectedEvt_NativeCallback);
      evt_UnselectedEvt_delegate = new Efl.EventCb(on_UnselectedEvt_NativeCallback);
      evt_SelectionPasteEvt_delegate = new Efl.EventCb(on_SelectionPasteEvt_NativeCallback);
      evt_SelectionCopyEvt_delegate = new Efl.EventCb(on_SelectionCopyEvt_NativeCallback);
      evt_SelectionCutEvt_delegate = new Efl.EventCb(on_SelectionCutEvt_NativeCallback);
      evt_SelectionStartEvt_delegate = new Efl.EventCb(on_SelectionStartEvt_NativeCallback);
      evt_Efl_Ui_Selectable_SelectionChangedEvt_delegate = new Efl.EventCb(on_Efl_Ui_Selectable_SelectionChangedEvt_NativeCallback);
      evt_SelectionClearedEvt_delegate = new Efl.EventCb(on_SelectionClearedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  int efl_ui_item_index_get(System.IntPtr obj);
   /// <summary>index number of item from their parent object.</summary>
   /// <returns></returns>
   virtual public  int GetIndex() {
       var _ret_var = efl_ui_item_index_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_item_selected_get(System.IntPtr obj);
   /// <summary>Select property for item object. Item can be selected by user mouse/key input also</summary>
   /// <returns></returns>
   virtual public bool GetSelected() {
       var _ret_var = efl_ui_item_selected_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_item_selected_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool select);
   /// <summary>Select property for item object. Item can be selected by user mouse/key input also</summary>
   /// <param name="select"></param>
   /// <returns></returns>
   virtual public  void SetSelected( bool select) {
                         efl_ui_item_selected_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  select);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>index number of item from their parent object.</summary>
   public  int Index {
      get { return GetIndex(); }
   }
   /// <summary>Select property for item object. Item can be selected by user mouse/key input also</summary>
   public bool Selected {
      get { return GetSelected(); }
      set { SetSelected( value); }
   }
}
public class ItemNativeInherit : Efl.Ui.LayoutNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_item_index_get_static_delegate = new efl_ui_item_index_get_delegate(index_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_item_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_index_get_static_delegate)});
      efl_ui_item_selected_get_static_delegate = new efl_ui_item_selected_get_delegate(selected_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_item_selected_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_selected_get_static_delegate)});
      efl_ui_item_selected_set_static_delegate = new efl_ui_item_selected_set_delegate(selected_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_item_selected_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_selected_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Item.efl_ui_item_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Item.efl_ui_item_class_get();
   }


    private delegate  int efl_ui_item_index_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_ui_item_index_get(System.IntPtr obj);
    private static  int index_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_item_index_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Item)wrapper).GetIndex();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_item_index_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_item_index_get_delegate efl_ui_item_index_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_item_selected_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_item_selected_get(System.IntPtr obj);
    private static bool selected_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_item_selected_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Item)wrapper).GetSelected();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_item_selected_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_item_selected_get_delegate efl_ui_item_selected_get_static_delegate;


    private delegate  void efl_ui_item_selected_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool select);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_item_selected_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool select);
    private static  void selected_set(System.IntPtr obj, System.IntPtr pd,  bool select)
   {
      Eina.Log.Debug("function efl_ui_item_selected_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Item)wrapper).SetSelected( select);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_item_selected_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  select);
      }
   }
   private efl_ui_item_selected_set_delegate efl_ui_item_selected_set_static_delegate;
}
} } 
