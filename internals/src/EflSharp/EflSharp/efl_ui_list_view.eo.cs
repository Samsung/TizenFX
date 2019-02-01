#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemRealizedEvt"/>.</summary>
public class ListViewItemRealizedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.ListViewItemEvent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemUnrealizedEvt"/>.</summary>
public class ListViewItemUnrealizedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.ListViewItemEvent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemFocusedEvt"/>.</summary>
public class ListViewItemFocusedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.ListViewItemEvent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemUnfocusedEvt"/>.</summary>
public class ListViewItemUnfocusedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.ListViewItemEvent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemHighlightedEvt"/>.</summary>
public class ListViewItemHighlightedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.ListViewItemEvent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemUnhighlightedEvt"/>.</summary>
public class ListViewItemUnhighlightedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.ListViewItemEvent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemSelectedEvt"/>.</summary>
public class ListViewItemSelectedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.ListViewItemEvent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemUnselectedEvt"/>.</summary>
public class ListViewItemUnselectedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Ui.ListViewItemEvent arg { get; set; }
}
/// <summary></summary>
[ListViewNativeInherit]
public class ListView : Efl.Ui.Layout, Efl.Eo.IWrapper,Efl.Interface,Efl.Access.Selection,Efl.Ui.Clickable,Efl.Ui.ListViewModel,Efl.Ui.Scrollable,Efl.Ui.ScrollableInteractive,Efl.Ui.Scrollbar,Efl.Ui.Selectable,Efl.Ui.WidgetFocusManager,Efl.Ui.Focus.Composition,Efl.Ui.Focus.Manager,Efl.Ui.Focus.ManagerSub
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.ListViewNativeInherit nativeInherit = new Efl.Ui.ListViewNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (ListView))
            return Efl.Ui.ListViewNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(ListView obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_list_view_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public ListView(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("ListView", efl_ui_list_view_class_get(), typeof(ListView), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected ListView(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public ListView(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static ListView static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new ListView(obj.NativeHandle);
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
private static object ItemRealizedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler<Efl.Ui.ListViewItemRealizedEvt_Args> ItemRealizedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_REALIZED";
            if (add_cpp_event_handler(key, this.evt_ItemRealizedEvt_delegate)) {
               eventHandlers.AddHandler(ItemRealizedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_REALIZED";
            if (remove_cpp_event_handler(key, this.evt_ItemRealizedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ItemRealizedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ItemRealizedEvt.</summary>
   public void On_ItemRealizedEvt(Efl.Ui.ListViewItemRealizedEvt_Args e)
   {
      EventHandler<Efl.Ui.ListViewItemRealizedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ListViewItemRealizedEvt_Args>)eventHandlers[ItemRealizedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ItemRealizedEvt_delegate;
   private void on_ItemRealizedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ListViewItemRealizedEvt_Args args = new Efl.Ui.ListViewItemRealizedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ItemRealizedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ItemUnrealizedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler<Efl.Ui.ListViewItemUnrealizedEvt_Args> ItemUnrealizedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNREALIZED";
            if (add_cpp_event_handler(key, this.evt_ItemUnrealizedEvt_delegate)) {
               eventHandlers.AddHandler(ItemUnrealizedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNREALIZED";
            if (remove_cpp_event_handler(key, this.evt_ItemUnrealizedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ItemUnrealizedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ItemUnrealizedEvt.</summary>
   public void On_ItemUnrealizedEvt(Efl.Ui.ListViewItemUnrealizedEvt_Args e)
   {
      EventHandler<Efl.Ui.ListViewItemUnrealizedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ListViewItemUnrealizedEvt_Args>)eventHandlers[ItemUnrealizedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ItemUnrealizedEvt_delegate;
   private void on_ItemUnrealizedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ListViewItemUnrealizedEvt_Args args = new Efl.Ui.ListViewItemUnrealizedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ItemUnrealizedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ItemFocusedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler<Efl.Ui.ListViewItemFocusedEvt_Args> ItemFocusedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_FOCUSED";
            if (add_cpp_event_handler(key, this.evt_ItemFocusedEvt_delegate)) {
               eventHandlers.AddHandler(ItemFocusedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_FOCUSED";
            if (remove_cpp_event_handler(key, this.evt_ItemFocusedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ItemFocusedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ItemFocusedEvt.</summary>
   public void On_ItemFocusedEvt(Efl.Ui.ListViewItemFocusedEvt_Args e)
   {
      EventHandler<Efl.Ui.ListViewItemFocusedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ListViewItemFocusedEvt_Args>)eventHandlers[ItemFocusedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ItemFocusedEvt_delegate;
   private void on_ItemFocusedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ListViewItemFocusedEvt_Args args = new Efl.Ui.ListViewItemFocusedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ItemFocusedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ItemUnfocusedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler<Efl.Ui.ListViewItemUnfocusedEvt_Args> ItemUnfocusedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNFOCUSED";
            if (add_cpp_event_handler(key, this.evt_ItemUnfocusedEvt_delegate)) {
               eventHandlers.AddHandler(ItemUnfocusedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNFOCUSED";
            if (remove_cpp_event_handler(key, this.evt_ItemUnfocusedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ItemUnfocusedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ItemUnfocusedEvt.</summary>
   public void On_ItemUnfocusedEvt(Efl.Ui.ListViewItemUnfocusedEvt_Args e)
   {
      EventHandler<Efl.Ui.ListViewItemUnfocusedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ListViewItemUnfocusedEvt_Args>)eventHandlers[ItemUnfocusedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ItemUnfocusedEvt_delegate;
   private void on_ItemUnfocusedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ListViewItemUnfocusedEvt_Args args = new Efl.Ui.ListViewItemUnfocusedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ItemUnfocusedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ItemHighlightedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler<Efl.Ui.ListViewItemHighlightedEvt_Args> ItemHighlightedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_HIGHLIGHTED";
            if (add_cpp_event_handler(key, this.evt_ItemHighlightedEvt_delegate)) {
               eventHandlers.AddHandler(ItemHighlightedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_HIGHLIGHTED";
            if (remove_cpp_event_handler(key, this.evt_ItemHighlightedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ItemHighlightedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ItemHighlightedEvt.</summary>
   public void On_ItemHighlightedEvt(Efl.Ui.ListViewItemHighlightedEvt_Args e)
   {
      EventHandler<Efl.Ui.ListViewItemHighlightedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ListViewItemHighlightedEvt_Args>)eventHandlers[ItemHighlightedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ItemHighlightedEvt_delegate;
   private void on_ItemHighlightedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ListViewItemHighlightedEvt_Args args = new Efl.Ui.ListViewItemHighlightedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ItemHighlightedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ItemUnhighlightedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler<Efl.Ui.ListViewItemUnhighlightedEvt_Args> ItemUnhighlightedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNHIGHLIGHTED";
            if (add_cpp_event_handler(key, this.evt_ItemUnhighlightedEvt_delegate)) {
               eventHandlers.AddHandler(ItemUnhighlightedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNHIGHLIGHTED";
            if (remove_cpp_event_handler(key, this.evt_ItemUnhighlightedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ItemUnhighlightedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ItemUnhighlightedEvt.</summary>
   public void On_ItemUnhighlightedEvt(Efl.Ui.ListViewItemUnhighlightedEvt_Args e)
   {
      EventHandler<Efl.Ui.ListViewItemUnhighlightedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ListViewItemUnhighlightedEvt_Args>)eventHandlers[ItemUnhighlightedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ItemUnhighlightedEvt_delegate;
   private void on_ItemUnhighlightedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ListViewItemUnhighlightedEvt_Args args = new Efl.Ui.ListViewItemUnhighlightedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ItemUnhighlightedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ItemSelectedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler<Efl.Ui.ListViewItemSelectedEvt_Args> ItemSelectedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_SELECTED";
            if (add_cpp_event_handler(key, this.evt_ItemSelectedEvt_delegate)) {
               eventHandlers.AddHandler(ItemSelectedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_SELECTED";
            if (remove_cpp_event_handler(key, this.evt_ItemSelectedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ItemSelectedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ItemSelectedEvt.</summary>
   public void On_ItemSelectedEvt(Efl.Ui.ListViewItemSelectedEvt_Args e)
   {
      EventHandler<Efl.Ui.ListViewItemSelectedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ListViewItemSelectedEvt_Args>)eventHandlers[ItemSelectedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ItemSelectedEvt_delegate;
   private void on_ItemSelectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ListViewItemSelectedEvt_Args args = new Efl.Ui.ListViewItemSelectedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ItemSelectedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ItemUnselectedEvtKey = new object();
   /// <summary></summary>
   public event EventHandler<Efl.Ui.ListViewItemUnselectedEvt_Args> ItemUnselectedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNSELECTED";
            if (add_cpp_event_handler(key, this.evt_ItemUnselectedEvt_delegate)) {
               eventHandlers.AddHandler(ItemUnselectedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNSELECTED";
            if (remove_cpp_event_handler(key, this.evt_ItemUnselectedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ItemUnselectedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ItemUnselectedEvt.</summary>
   public void On_ItemUnselectedEvt(Efl.Ui.ListViewItemUnselectedEvt_Args e)
   {
      EventHandler<Efl.Ui.ListViewItemUnselectedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.ListViewItemUnselectedEvt_Args>)eventHandlers[ItemUnselectedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ItemUnselectedEvt_delegate;
   private void on_ItemUnselectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.ListViewItemUnselectedEvt_Args args = new Efl.Ui.ListViewItemUnselectedEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_ItemUnselectedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Efl_Access_Selection_SelectionChangedEvtKey = new object();
   /// <summary>Called when selection has been changed.</summary>
    event EventHandler Efl.Access.Selection.SelectionChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ACCESS_SELECTION_EVENT_SELECTION_CHANGED";
            if (add_cpp_event_handler(key, this.evt_Efl_Access_Selection_SelectionChangedEvt_delegate)) {
               eventHandlers.AddHandler(Efl_Access_Selection_SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ACCESS_SELECTION_EVENT_SELECTION_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Efl_Access_Selection_SelectionChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Efl_Access_Selection_SelectionChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Efl_Access_Selection_SelectionChangedEvt.</summary>
   public void On_Efl_Access_Selection_SelectionChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[Efl_Access_Selection_SelectionChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Efl_Access_Selection_SelectionChangedEvt_delegate;
   private void on_Efl_Access_Selection_SelectionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_Efl_Access_Selection_SelectionChangedEvt(args);
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

private static object ScrollStartEvtKey = new object();
   /// <summary>Called when scroll operation starts</summary>
   public event EventHandler ScrollStartEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_EVENT_SCROLL_START";
            if (add_cpp_event_handler(key, this.evt_ScrollStartEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ScrollEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ScrollStopEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ScrollUpEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ScrollDownEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ScrollLeftEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ScrollRightEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_EdgeUpEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_EdgeDownEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_EdgeLeftEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_EdgeRightEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ScrollAnimStartEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ScrollAnimStopEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ScrollDragStartEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_ScrollDragStopEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_BarPressEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_BarUnpressEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_BarDragEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_BarSizeChangedEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_BarPosChangedEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_BarShowEvt_delegate)) {
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
            if (add_cpp_event_handler(key, this.evt_BarHideEvt_delegate)) {
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

private static object Efl_Ui_Focus_Manager_FocusChangedEvtKey = new object();
   /// <summary>Emitted if the manager has focused an object, the passed focus object is the last focused object
   /// 1.20</summary>
    event EventHandler<Efl.Ui.Focus.ManagerFocusChangedEvt_Args> Efl.Ui.Focus.Manager.FocusChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_FOCUS_CHANGED";
            if (add_cpp_event_handler(key, this.evt_Efl_Ui_Focus_Manager_FocusChangedEvt_delegate)) {
               eventHandlers.AddHandler(Efl_Ui_Focus_Manager_FocusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_FOCUS_MANAGER_EVENT_FOCUS_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_Efl_Ui_Focus_Manager_FocusChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Efl_Ui_Focus_Manager_FocusChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Efl_Ui_Focus_Manager_FocusChangedEvt.</summary>
   public void On_Efl_Ui_Focus_Manager_FocusChangedEvt(Efl.Ui.Focus.ManagerFocusChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.Focus.ManagerFocusChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.Focus.ManagerFocusChangedEvt_Args>)eventHandlers[Efl_Ui_Focus_Manager_FocusChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Efl_Ui_Focus_Manager_FocusChangedEvt_delegate;
   private void on_Efl_Ui_Focus_Manager_FocusChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.Focus.ManagerFocusChangedEvt_Args args = new Efl.Ui.Focus.ManagerFocusChangedEvt_Args();
      args.arg = new Efl.Ui.Focus.ObjectConcrete(evt.Info);
      try {
         On_Efl_Ui_Focus_Manager_FocusChangedEvt(args);
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

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ItemRealizedEvt_delegate = new Efl.EventCb(on_ItemRealizedEvt_NativeCallback);
      evt_ItemUnrealizedEvt_delegate = new Efl.EventCb(on_ItemUnrealizedEvt_NativeCallback);
      evt_ItemFocusedEvt_delegate = new Efl.EventCb(on_ItemFocusedEvt_NativeCallback);
      evt_ItemUnfocusedEvt_delegate = new Efl.EventCb(on_ItemUnfocusedEvt_NativeCallback);
      evt_ItemHighlightedEvt_delegate = new Efl.EventCb(on_ItemHighlightedEvt_NativeCallback);
      evt_ItemUnhighlightedEvt_delegate = new Efl.EventCb(on_ItemUnhighlightedEvt_NativeCallback);
      evt_ItemSelectedEvt_delegate = new Efl.EventCb(on_ItemSelectedEvt_NativeCallback);
      evt_ItemUnselectedEvt_delegate = new Efl.EventCb(on_ItemUnselectedEvt_NativeCallback);
      evt_Efl_Access_Selection_SelectionChangedEvt_delegate = new Efl.EventCb(on_Efl_Access_Selection_SelectionChangedEvt_NativeCallback);
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
      evt_RedirectChangedEvt_delegate = new Efl.EventCb(on_RedirectChangedEvt_NativeCallback);
      evt_FlushPreEvt_delegate = new Efl.EventCb(on_FlushPreEvt_NativeCallback);
      evt_CoordsDirtyEvt_delegate = new Efl.EventCb(on_CoordsDirtyEvt_NativeCallback);
      evt_Efl_Ui_Focus_Manager_FocusChangedEvt_delegate = new Efl.EventCb(on_Efl_Ui_Focus_Manager_FocusChangedEvt_NativeCallback);
      evt_Dirty_logic_freezeChangedEvt_delegate = new Efl.EventCb(on_Dirty_logic_freezeChangedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.ListViewRelayoutConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.ListViewRelayout efl_ui_list_view_relayout_get(System.IntPtr obj);
   /// <summary></summary>
   /// <returns></returns>
   virtual public Efl.Ui.ListViewRelayout GetRelayout() {
       var _ret_var = efl_ui_list_view_relayout_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_list_view_relayout_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.ListViewRelayoutConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.ListViewRelayout kw_object);
   /// <summary></summary>
   /// <param name="kw_object"></param>
   /// <returns></returns>
   virtual public  void SetRelayout( Efl.Ui.ListViewRelayout kw_object) {
                         efl_ui_list_view_relayout_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  kw_object);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_list_view_homogeneous_get(System.IntPtr obj);
   /// <summary>Get whether the homogeneous mode is enabled.</summary>
   /// <returns>Assume the items within the genlist are of the same height and width. Default is <c>false</c>.</returns>
   virtual public bool GetHomogeneous() {
       var _ret_var = efl_ui_list_view_homogeneous_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_list_view_homogeneous_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool homogeneous);
   /// <summary>Enable/disable homogeneous mode.</summary>
   /// <param name="homogeneous">Assume the items within the genlist are of the same height and width. Default is <c>false</c>.</param>
   /// <returns></returns>
   virtual public  void SetHomogeneous( bool homogeneous) {
                         efl_ui_list_view_homogeneous_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  homogeneous);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Elm.Object.SelectMode efl_ui_list_view_select_mode_get(System.IntPtr obj);
   /// <summary>Listview select mode.</summary>
   /// <returns>The select mode.</returns>
   virtual public Elm.Object.SelectMode GetSelectMode() {
       var _ret_var = efl_ui_list_view_select_mode_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_list_view_select_mode_set(System.IntPtr obj,   Elm.Object.SelectMode mode);
   /// <summary>Listview select mode.</summary>
   /// <param name="mode">The select mode.</param>
   /// <returns></returns>
   virtual public  void SetSelectMode( Elm.Object.SelectMode mode) {
                         efl_ui_list_view_select_mode_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  mode);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))] protected static extern  System.String efl_ui_list_view_default_style_get(System.IntPtr obj);
   /// <summary></summary>
   /// <returns></returns>
   virtual public  System.String GetDefaultStyle() {
       var _ret_var = efl_ui_list_view_default_style_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_list_view_default_style_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))]   System.String style);
   /// <summary></summary>
   /// <param name="style"></param>
   /// <returns></returns>
   virtual public  void SetDefaultStyle(  System.String style) {
                         efl_ui_list_view_default_style_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  style);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_list_view_layout_factory_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.FactoryConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Factory factory);
   /// <summary>Listview layout factory set.</summary>
   /// <param name="factory">The factory.</param>
   /// <returns></returns>
   virtual public  void SetLayoutFactory( Efl.Ui.Factory factory) {
                         efl_ui_list_view_layout_factory_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  factory);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  int efl_access_selection_selected_children_count_get(System.IntPtr obj);
   /// <summary>Gets the number of currently selected children</summary>
   /// <returns>Number of currently selected children</returns>
   virtual public  int GetSelectedChildrenCount() {
       var _ret_var = efl_access_selection_selected_children_count_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Object efl_access_selection_selected_child_get(System.IntPtr obj,    int selected_child_index);
   /// <summary>Gets child for given child index</summary>
   /// <param name="selected_child_index">Index of child</param>
   /// <returns>Child object</returns>
   virtual public Efl.Object GetSelectedChild(  int selected_child_index) {
                         var _ret_var = efl_access_selection_selected_child_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  selected_child_index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_selection_child_select(System.IntPtr obj,    int child_index);
   /// <summary>Adds selection for given child index</summary>
   /// <param name="child_index">Index of child</param>
   /// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
   virtual public bool ChildSelect(  int child_index) {
                         var _ret_var = efl_access_selection_child_select((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  child_index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_selection_selected_child_deselect(System.IntPtr obj,    int child_index);
   /// <summary>Removes selection for given child index</summary>
   /// <param name="child_index">Index of child</param>
   /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
   virtual public bool SelectedChildDeselect(  int child_index) {
                         var _ret_var = efl_access_selection_selected_child_deselect((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  child_index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_selection_is_child_selected(System.IntPtr obj,    int child_index);
   /// <summary>Determines if child specified by index is selected</summary>
   /// <param name="child_index">Index of child</param>
   /// <returns><c>true</c> if child is selected, <c>false</c> otherwise</returns>
   virtual public bool IsChildSelected(  int child_index) {
                         var _ret_var = efl_access_selection_is_child_selected((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  child_index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_selection_all_children_select(System.IntPtr obj);
   /// <summary>Adds selection for all children</summary>
   /// <returns><c>true</c> if selection was added to all children, <c>false</c> otherwise</returns>
   virtual public bool AllChildrenSelect() {
       var _ret_var = efl_access_selection_all_children_select((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_selection_clear(System.IntPtr obj);
   /// <summary>Clears the current selection</summary>
   /// <returns><c>true</c> if selection was cleared, <c>false</c> otherwise</returns>
   virtual public bool ClearAccessSelection() {
       var _ret_var = efl_access_selection_clear((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_access_selection_child_deselect(System.IntPtr obj,    int child_index);
   /// <summary>Removes selection for given child index</summary>
   /// <param name="child_index">Index of child</param>
   /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
   virtual public bool ChildDeselect(  int child_index) {
                         var _ret_var = efl_access_selection_child_deselect((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  child_index);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_list_view_model_load_range_set(System.IntPtr obj,    int first,    int count);
   /// <summary></summary>
   /// <param name="first"></param>
   /// <param name="count"></param>
   /// <returns></returns>
   virtual public  void SetLoadRange(  int first,   int count) {
                                           efl_ui_list_view_model_load_range_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  first,  count);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  int efl_ui_list_view_model_size_get(System.IntPtr obj);
   /// <summary></summary>
   /// <returns></returns>
   virtual public  int GetModelSize() {
       var _ret_var = efl_ui_list_view_model_size_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Eina.Size2D_StructInternal efl_ui_list_view_model_min_size_get(System.IntPtr obj);
   /// <summary>Minimal content size.</summary>
   /// <returns></returns>
   virtual public Eina.Size2D GetMinSize() {
       var _ret_var = efl_ui_list_view_model_min_size_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_list_view_model_min_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal min);
   /// <summary>Minimal content size.</summary>
   /// <param name="min"></param>
   /// <returns></returns>
   virtual public  void SetMinSize( Eina.Size2D min) {
       var _in_min = Eina.Size2D_StructConversion.ToInternal(min);
                  efl_ui_list_view_model_min_size_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_min);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_ui_list_view_model_realize(System.IntPtr obj,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
   /// <summary></summary>
   /// <param name="item"></param>
   /// <returns></returns>
   virtual public Efl.Ui.ListViewLayoutItem Realize( ref Efl.Ui.ListViewLayoutItem item) {
       var _in_item = Efl.Ui.ListViewLayoutItem_StructConversion.ToInternal(item);
                  var _ret_var = efl_ui_list_view_model_realize((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  ref _in_item);
      Eina.Error.RaiseIfUnhandledException();
            item = Efl.Ui.ListViewLayoutItem_StructConversion.ToManaged(_in_item);
      var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.ListViewLayoutItem>(_ret_var);
      
      return __ret_tmp;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_list_view_model_unrealize(System.IntPtr obj,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
   /// <summary></summary>
   /// <param name="item"></param>
   /// <returns></returns>
   virtual public  void Unrealize( ref Efl.Ui.ListViewLayoutItem item) {
       var _in_item = Efl.Ui.ListViewLayoutItem_StructConversion.ToInternal(item);
                  efl_ui_list_view_model_unrealize((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  ref _in_item);
      Eina.Error.RaiseIfUnhandledException();
            item = Efl.Ui.ListViewLayoutItem_StructConversion.ToManaged(_in_item);
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Position2D_StructInternal efl_ui_scrollable_content_pos_get(System.IntPtr obj);
   /// <summary>The content position</summary>
   /// <returns>The position is virtual value, (0, 0) starting at the top-left.</returns>
   virtual public Eina.Position2D GetContentPos() {
       var _ret_var = efl_ui_scrollable_content_pos_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollable_content_pos_set(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
   /// <summary>The content position</summary>
   /// <param name="pos">The position is virtual value, (0, 0) starting at the top-left.</param>
   /// <returns></returns>
   virtual public  void SetContentPos( Eina.Position2D pos) {
       var _in_pos = Eina.Position2D_StructConversion.ToInternal(pos);
                  efl_ui_scrollable_content_pos_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Size2D_StructInternal efl_ui_scrollable_content_size_get(System.IntPtr obj);
   /// <summary>The content size</summary>
   /// <returns>The content size in pixels.</returns>
   virtual public Eina.Size2D GetContentSize() {
       var _ret_var = efl_ui_scrollable_content_size_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Rect_StructInternal efl_ui_scrollable_viewport_geometry_get(System.IntPtr obj);
   /// <summary>The viewport geometry</summary>
   /// <returns>It is absolute geometry.</returns>
   virtual public Eina.Rect GetViewportGeometry() {
       var _ret_var = efl_ui_scrollable_viewport_geometry_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollable_bounce_enabled_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool horiz,  [MarshalAs(UnmanagedType.U1)]  out bool vert);
   /// <summary>Bouncing behavior
   /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
   /// <param name="horiz">Horizontal bounce policy.</param>
   /// <param name="vert">Vertical bounce policy.</param>
   /// <returns></returns>
   virtual public  void GetBounceEnabled( out bool horiz,  out bool vert) {
                                           efl_ui_scrollable_bounce_enabled_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out horiz,  out vert);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollable_bounce_enabled_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool horiz,  [MarshalAs(UnmanagedType.U1)]  bool vert);
   /// <summary>Bouncing behavior
   /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
   /// <param name="horiz">Horizontal bounce policy.</param>
   /// <param name="vert">Vertical bounce policy.</param>
   /// <returns></returns>
   virtual public  void SetBounceEnabled( bool horiz,  bool vert) {
                                           efl_ui_scrollable_bounce_enabled_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  horiz,  vert);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_scrollable_scroll_freeze_get(System.IntPtr obj);
   /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.ScrollableInteractive.SetMovementBlock"/>.</summary>
   /// <returns><c>true</c> if freeze, <c>false</c> otherwise</returns>
   virtual public bool GetScrollFreeze() {
       var _ret_var = efl_ui_scrollable_scroll_freeze_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollable_scroll_freeze_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool freeze);
   /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.ScrollableInteractive.SetMovementBlock"/>.</summary>
   /// <param name="freeze"><c>true</c> if freeze, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetScrollFreeze( bool freeze) {
                         efl_ui_scrollable_scroll_freeze_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  freeze);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_scrollable_scroll_hold_get(System.IntPtr obj);
   /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
   /// <returns><c>true</c> if hold, <c>false</c> otherwise</returns>
   virtual public bool GetScrollHold() {
       var _ret_var = efl_ui_scrollable_scroll_hold_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollable_scroll_hold_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool hold);
   /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
   /// <param name="hold"><c>true</c> if hold, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetScrollHold( bool hold) {
                         efl_ui_scrollable_scroll_hold_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  hold);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollable_looping_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool loop_h,  [MarshalAs(UnmanagedType.U1)]  out bool loop_v);
   /// <summary>Controls an infinite loop for a scroller.</summary>
   /// <param name="loop_h">The scrolling horizontal loop</param>
   /// <param name="loop_v">The Scrolling vertical loop</param>
   /// <returns></returns>
   virtual public  void GetLooping( out bool loop_h,  out bool loop_v) {
                                           efl_ui_scrollable_looping_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out loop_h,  out loop_v);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollable_looping_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool loop_h,  [MarshalAs(UnmanagedType.U1)]  bool loop_v);
   /// <summary>Controls an infinite loop for a scroller.</summary>
   /// <param name="loop_h">The scrolling horizontal loop</param>
   /// <param name="loop_v">The Scrolling vertical loop</param>
   /// <returns></returns>
   virtual public  void SetLooping( bool loop_h,  bool loop_v) {
                                           efl_ui_scrollable_looping_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  loop_h,  loop_v);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Ui.ScrollBlock efl_ui_scrollable_movement_block_get(System.IntPtr obj);
   /// <summary>Blocking of scrolling (per axis)
   /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
   /// <returns>Which axis (or axes) to block</returns>
   virtual public Efl.Ui.ScrollBlock GetMovementBlock() {
       var _ret_var = efl_ui_scrollable_movement_block_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollable_movement_block_set(System.IntPtr obj,   Efl.Ui.ScrollBlock block);
   /// <summary>Blocking of scrolling (per axis)
   /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
   /// <param name="block">Which axis (or axes) to block</param>
   /// <returns></returns>
   virtual public  void SetMovementBlock( Efl.Ui.ScrollBlock block) {
                         efl_ui_scrollable_movement_block_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  block);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollable_gravity_get(System.IntPtr obj,   out double x,   out double y);
   /// <summary>Control scrolling gravity on the scrollable
   /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
   /// 
   /// The scroller will adjust the view to glue itself as follows.
   /// 
   /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the rigth edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
   /// 
   /// Default values for x and y are 0.0</summary>
   /// <param name="x">Horizontal scrolling gravity</param>
   /// <param name="y">Vertical scrolling gravity</param>
   /// <returns></returns>
   virtual public  void GetGravity( out double x,  out double y) {
                                           efl_ui_scrollable_gravity_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollable_gravity_set(System.IntPtr obj,   double x,   double y);
   /// <summary>Control scrolling gravity on the scrollable
   /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
   /// 
   /// The scroller will adjust the view to glue itself as follows.
   /// 
   /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the rigth edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
   /// 
   /// Default values for x and y are 0.0</summary>
   /// <param name="x">Horizontal scrolling gravity</param>
   /// <param name="y">Vertical scrolling gravity</param>
   /// <returns></returns>
   virtual public  void SetGravity( double x,  double y) {
                                           efl_ui_scrollable_gravity_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollable_match_content_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool w,  [MarshalAs(UnmanagedType.U1)]  bool h);
   /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
   /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
   /// <param name="w">Whether to limit the minimum horizontal size</param>
   /// <param name="h">Whether to limit the minimum vertical size</param>
   /// <returns></returns>
   virtual public  void SetMatchContent( bool w,  bool h) {
                                           efl_ui_scrollable_match_content_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  w,  h);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollable_scroll(System.IntPtr obj,   Eina.Rect_StructInternal rect,  [MarshalAs(UnmanagedType.U1)]  bool animation);
   /// <summary>Show a specific virtual region within the scroller content object.
   /// This will ensure all (or part if it does not fit) of the designated region in the virtual content object (0, 0 starting at the top-left of the virtual content object) is shown within the scroller. This allows the scroller to &quot;smoothly slide&quot; to this location (if configuration in general calls for transitions). It may not jump immediately to the new location and make take a while and show other content along the way.</summary>
   /// <param name="rect">The position where to scroll. and The size user want to see</param>
   /// <param name="animation">Whether to scroll with animation or not</param>
   /// <returns></returns>
   virtual public  void Scroll( Eina.Rect rect,  bool animation) {
       var _in_rect = Eina.Rect_StructConversion.ToInternal(rect);
                                    efl_ui_scrollable_scroll((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_rect,  animation);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollbar_bar_mode_get(System.IntPtr obj,   out Efl.Ui.ScrollbarMode hbar,   out Efl.Ui.ScrollbarMode vbar);
   /// <summary>Scrollbar visibility policy</summary>
   /// <param name="hbar">Horizontal scrollbar</param>
   /// <param name="vbar">Vertical scrollbar</param>
   /// <returns></returns>
   virtual public  void GetBarMode( out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar) {
                                           efl_ui_scrollbar_bar_mode_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out hbar,  out vbar);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollbar_bar_mode_set(System.IntPtr obj,   Efl.Ui.ScrollbarMode hbar,   Efl.Ui.ScrollbarMode vbar);
   /// <summary>Scrollbar visibility policy</summary>
   /// <param name="hbar">Horizontal scrollbar</param>
   /// <param name="vbar">Vertical scrollbar</param>
   /// <returns></returns>
   virtual public  void SetBarMode( Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar) {
                                           efl_ui_scrollbar_bar_mode_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  hbar,  vbar);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollbar_bar_size_get(System.IntPtr obj,   out double width,   out double height);
   /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
   /// <param name="width">Value between 0.0 and 1.0</param>
   /// <param name="height">Value between 0.0 and 1.0</param>
   /// <returns></returns>
   virtual public  void GetBarSize( out double width,  out double height) {
                                           efl_ui_scrollbar_bar_size_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out width,  out height);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollbar_bar_position_get(System.IntPtr obj,   out double posx,   out double posy);
   /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
   /// <param name="posx">Value between 0.0 and 1.0</param>
   /// <param name="posy">Value between 0.0 and 1.0</param>
   /// <returns></returns>
   virtual public  void GetBarPosition( out double posx,  out double posy) {
                                           efl_ui_scrollbar_bar_position_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out posx,  out posy);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollbar_bar_position_set(System.IntPtr obj,   double posx,   double posy);
   /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
   /// <param name="posx">Value between 0.0 and 1.0</param>
   /// <param name="posy">Value between 0.0 and 1.0</param>
   /// <returns></returns>
   virtual public  void SetBarPosition( double posx,  double posy) {
                                           efl_ui_scrollbar_bar_position_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  posx,  posy);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_scrollbar_bar_visibility_update(System.IntPtr obj);
   /// <summary>Update bar visibility.
   /// The object will call this function whenever the bar need to be shown or hidden.</summary>
   /// <returns></returns>
   virtual public  void UpdateBarVisibility() {
       efl_ui_scrollbar_bar_visibility_update((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Focus.Manager efl_ui_widget_focus_manager_create(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object root);
   /// <summary>If the widget needs a focus manager, this function will be called.
   /// It can be used and overriden to inject your own manager or set custom options on the focus manager.</summary>
   /// <param name="root">The logical root object for focus.</param>
   /// <returns>The focus manager.</returns>
   virtual public Efl.Ui.Focus.Manager FocusManagerCreate( Efl.Ui.Focus.Object root) {
                         var _ret_var = efl_ui_widget_focus_manager_create((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  root);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_ui_focus_composition_elements_get(System.IntPtr obj);
   /// <summary>Set the order of elements that will be used for composition
   /// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
   /// 
   /// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
   /// 
   /// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
   /// 
   /// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
   /// <returns>The order to use</returns>
   virtual public Eina.List<Efl.Gfx.Entity> GetCompositionElements() {
       var _ret_var = efl_ui_focus_composition_elements_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Gfx.Entity>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_composition_elements_set(System.IntPtr obj,    System.IntPtr logical_order);
   /// <summary>Set the order of elements that will be used for composition
   /// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
   /// 
   /// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
   /// 
   /// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
   /// 
   /// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
   /// <param name="logical_order">The order to use</param>
   /// <returns></returns>
   virtual public  void SetCompositionElements( Eina.List<Efl.Gfx.Entity> logical_order) {
       var _in_logical_order = logical_order.Handle;
logical_order.Own = false;
                  efl_ui_focus_composition_elements_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_logical_order);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Focus.Manager efl_ui_focus_composition_custom_manager_get(System.IntPtr obj);
   /// <summary>Register all children in this manager
   /// Set to <c>null</c> to register them in the same manager as the implementor is</summary>
   /// <returns>EFL focus manager</returns>
   virtual public Efl.Ui.Focus.Manager GetCustomManager() {
       var _ret_var = efl_ui_focus_composition_custom_manager_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_composition_custom_manager_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager custom_manager);
   /// <summary>Register all children in this manager
   /// Set to <c>null</c> to register them in the same manager as the implementor is</summary>
   /// <param name="custom_manager">EFL focus manager</param>
   /// <returns></returns>
   virtual public  void SetCustomManager( Efl.Ui.Focus.Manager custom_manager) {
                         efl_ui_focus_composition_custom_manager_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  custom_manager);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_focus_composition_logical_mode_get(System.IntPtr obj);
   /// <summary>Set to true if all children should be registered as logicals</summary>
   /// <returns><c>true</c> or <c>false</c></returns>
   virtual public bool GetLogicalMode() {
       var _ret_var = efl_ui_focus_composition_logical_mode_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_composition_logical_mode_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool logical_mode);
   /// <summary>Set to true if all children should be registered as logicals</summary>
   /// <param name="logical_mode"><c>true</c> or <c>false</c></param>
   /// <returns></returns>
   virtual public  void SetLogicalMode( bool logical_mode) {
                         efl_ui_focus_composition_logical_mode_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  logical_mode);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_composition_dirty(System.IntPtr obj);
   /// <summary>Mark this widget as dirty, the children can be considered to be changed after that call</summary>
   /// <returns></returns>
   virtual public  void Dirty() {
       efl_ui_focus_composition_dirty((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_composition_prepare(System.IntPtr obj);
   /// <summary>A call to prepare the children of this element, called if marked as dirty
   /// You can use this function to call composition_elements.</summary>
   /// <returns></returns>
   virtual public  void Prepare() {
       efl_ui_focus_composition_prepare((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Focus.Object efl_ui_focus_manager_focus_get(System.IntPtr obj);
   /// <summary>The element which is currently focused by this manager
   /// For the case focus is a logical child, then the item will go to the next none logical element. If there is none, focus will stay where it is right now.
   /// 1.20</summary>
   /// <returns>Focused element
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Object GetManagerFocus() {
       var _ret_var = efl_ui_focus_manager_focus_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_manager_focus_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object focus);
   /// <summary>The element which is currently focused by this manager
   /// For the case focus is a logical child, then the item will go to the next none logical element. If there is none, focus will stay where it is right now.
   /// 1.20</summary>
   /// <param name="focus">Focused element
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetManagerFocus( Efl.Ui.Focus.Object focus) {
                         efl_ui_focus_manager_focus_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  focus);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Focus.Manager efl_ui_focus_manager_redirect_get(System.IntPtr obj);
   /// <summary>Add a another manager to serve the move requests.
   /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
   /// 1.20</summary>
   /// <returns>The redirect manager.
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Manager GetRedirect() {
       var _ret_var = efl_ui_focus_manager_redirect_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_manager_redirect_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager redirect);
   /// <summary>Add a another manager to serve the move requests.
   /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
   /// 1.20</summary>
   /// <param name="redirect">The redirect manager.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetRedirect( Efl.Ui.Focus.Manager redirect) {
                         efl_ui_focus_manager_redirect_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  redirect);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_ui_focus_manager_border_elements_get(System.IntPtr obj);
   /// <summary>The list of elements which are at the border of the graph.
   /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.Manager.Move"/>
   /// 1.20</summary>
   /// <returns>An iterator over the border objects.
   /// 1.20</returns>
   virtual public Eina.Iterator<Efl.Ui.Focus.Object> GetBorderElements() {
       var _ret_var = efl_ui_focus_manager_border_elements_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Ui.Focus.Object>(_ret_var, false, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_ui_focus_manager_viewport_elements_get(System.IntPtr obj,   Eina.Rect_StructInternal viewport);
   /// <summary>The list of elements which are at the border of the viewport.
   /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.Manager.Move"/>
   /// 1.20</summary>
   /// <param name="viewport"></param>
   /// <returns></returns>
   virtual public Eina.Iterator<Efl.Ui.Focus.Object> GetViewportElements( Eina.Rect viewport) {
       var _in_viewport = Eina.Rect_StructConversion.ToInternal(viewport);
                  var _ret_var = efl_ui_focus_manager_viewport_elements_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_viewport);
      Eina.Error.RaiseIfUnhandledException();
                  return new Eina.Iterator<Efl.Ui.Focus.Object>(_ret_var, false, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Focus.Object efl_ui_focus_manager_root_get(System.IntPtr obj);
   /// <summary>Root node for all logical subtrees.
   /// This property can only be set once.
   /// 1.20</summary>
   /// <returns>Will be registered into this manager object.
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Object GetRoot() {
       var _ret_var = efl_ui_focus_manager_root_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_focus_manager_root_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object root);
   /// <summary>Root node for all logical subtrees.
   /// This property can only be set once.
   /// 1.20</summary>
   /// <param name="root">Will be registered into this manager object.
   /// 1.20</param>
   /// <returns>If <c>true</c>, this is the root node
   /// 1.20</returns>
   virtual public bool SetRoot( Efl.Ui.Focus.Object root) {
                         var _ret_var = efl_ui_focus_manager_root_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  root);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Focus.Object efl_ui_focus_manager_move(System.IntPtr obj,   Efl.Ui.Focus.Direction direction);
   /// <summary>Move the focus into the given direction.
   /// This call flushes all changes. This means all changes between the last flush and now are computed
   /// 1.20</summary>
   /// <param name="direction">The direction to move to
   /// 1.20</param>
   /// <returns>The element which is now focused
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Object Move( Efl.Ui.Focus.Direction direction) {
                         var _ret_var = efl_ui_focus_manager_move((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  direction);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Focus.Object efl_ui_focus_manager_request_move(System.IntPtr obj,   Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child,  [MarshalAs(UnmanagedType.U1)]  bool logical);
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
   virtual public Efl.Ui.Focus.Object MoveRequest( Efl.Ui.Focus.Direction direction,  Efl.Ui.Focus.Object child,  bool logical) {
                                                             var _ret_var = efl_ui_focus_manager_request_move((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  direction,  child,  logical);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Ui.Focus.Object efl_ui_focus_manager_request_subchild(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child);
   /// <summary>Returns a widget that can receive focus
   /// The returned widget is in a child of the passed param. Its garanteed that child will not be prepared once again, so you can call this function out of a prepare call.
   /// 1.20</summary>
   /// <param name="child">Parent for returned child
   /// 1.20</param>
   /// <returns>Child of passed parameter
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Object RequestSubchild( Efl.Ui.Focus.Object child) {
                         var _ret_var = efl_ui_focus_manager_request_subchild((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  child);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_ui_focus_manager_fetch(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object child);
   /// <summary>This will fetch the data from a registered node.
   /// Be aware this function will trigger all dirty nodes to be computed
   /// 1.20</summary>
   /// <param name="child">The child object to inspect.
   /// 1.20</param>
   /// <returns>The list of relations starting from <c>child</c>.
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.Relations Fetch( Efl.Ui.Focus.Object child) {
                         var _ret_var = efl_ui_focus_manager_fetch((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  child);
      Eina.Error.RaiseIfUnhandledException();
                  var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.Focus.Relations>(_ret_var);
      Marshal.FreeHGlobal(_ret_var);
      return __ret_tmp;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern Efl.Ui.Focus.ManagerLogicalEndDetail_StructInternal efl_ui_focus_manager_logical_end(System.IntPtr obj);
   /// <summary>Return the last logical object.
   /// The returned object is the last object that would be returned if you start at the root and move the direction into next.
   /// 1.20</summary>
   /// <returns>Last object
   /// 1.20</returns>
   virtual public Efl.Ui.Focus.ManagerLogicalEndDetail LogicalEnd() {
       var _ret_var = efl_ui_focus_manager_logical_end((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Efl.Ui.Focus.ManagerLogicalEndDetail_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_manager_reset_history(System.IntPtr obj);
   /// <summary>Reset the history stack of this manager object. This means the most upper element will be unfocused, all other elements will be removed from the remembered before.
   /// To not break the assertion that there should be always a focused element, you should focus a other element immidiatly after calling that.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void ResetHistory() {
       efl_ui_focus_manager_reset_history((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_manager_pop_history_stack(System.IntPtr obj);
   /// <summary>Removes the most upper history element, and move focus on.
   /// If there is a element that was focused before, it will be taken. Otherwise, the best fitting element from the registered elements will be focused.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void PopHistoryStack() {
       efl_ui_focus_manager_pop_history_stack((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_manager_setup_on_first_touch(System.IntPtr obj,   Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object entry);
   /// <summary>Called when this manager is set as redirect
   /// 1.20</summary>
   /// <param name="direction">The direction in which this should be setup
   /// 1.20</param>
   /// <param name="entry">The object that caused this manager to be redirect
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetupOnFirstTouch( Efl.Ui.Focus.Direction direction,  Efl.Ui.Focus.Object entry) {
                                           efl_ui_focus_manager_setup_on_first_touch((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  direction,  entry);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_manager_dirty_logic_freeze(System.IntPtr obj);
   /// <summary>This disables the cache invalidation when a object is moved.
   /// Even the object is moved, the focus manager will not recalculate its relations, this can be used when you know that the set of widgets in the focus manager is equally moved. so the relations between the widets in the set do not change.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void FreezeDirtyLogic() {
       efl_ui_focus_manager_dirty_logic_freeze((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_focus_manager_dirty_logic_unfreeze(System.IntPtr obj);
   /// <summary>This enables the cache invalidation when a object is moved.
   /// This is the counter part to <see cref="Efl.Ui.Focus.Manager.FreezeDirtyLogic"/>
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void DirtyLogicUnfreeze() {
       efl_ui_focus_manager_dirty_logic_unfreeze((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary></summary>
   public Efl.Ui.ListViewRelayout Relayout {
      get { return GetRelayout(); }
      set { SetRelayout( value); }
   }
   /// <summary>Get whether the homogeneous mode is enabled.</summary>
   public bool Homogeneous {
      get { return GetHomogeneous(); }
      set { SetHomogeneous( value); }
   }
   /// <summary>Listview select mode.</summary>
   public Elm.Object.SelectMode SelectMode {
      get { return GetSelectMode(); }
      set { SetSelectMode( value); }
   }
   /// <summary></summary>
   public  System.String DefaultStyle {
      get { return GetDefaultStyle(); }
      set { SetDefaultStyle( value); }
   }
   /// <summary>Listview layout factory set.</summary>
   public Efl.Ui.Factory LayoutFactory {
      set { SetLayoutFactory( value); }
   }
   /// <summary>Gets the number of currently selected children</summary>
   public  int SelectedChildrenCount {
      get { return GetSelectedChildrenCount(); }
   }
   /// <summary></summary>
   public  int ModelSize {
      get { return GetModelSize(); }
   }
   /// <summary>Minimal content size.</summary>
   public Eina.Size2D MinSize {
      get { return GetMinSize(); }
      set { SetMinSize( value); }
   }
   /// <summary>The content position</summary>
   public Eina.Position2D ContentPos {
      get { return GetContentPos(); }
      set { SetContentPos( value); }
   }
   /// <summary>The content size</summary>
   public Eina.Size2D ContentSize {
      get { return GetContentSize(); }
   }
   /// <summary>The viewport geometry</summary>
   public Eina.Rect ViewportGeometry {
      get { return GetViewportGeometry(); }
   }
   /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.ScrollableInteractive.SetMovementBlock"/>.</summary>
   public bool ScrollFreeze {
      get { return GetScrollFreeze(); }
      set { SetScrollFreeze( value); }
   }
   /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
   public bool ScrollHold {
      get { return GetScrollHold(); }
      set { SetScrollHold( value); }
   }
   /// <summary>Blocking of scrolling (per axis)
/// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
   public Efl.Ui.ScrollBlock MovementBlock {
      get { return GetMovementBlock(); }
      set { SetMovementBlock( value); }
   }
   /// <summary>Set the order of elements that will be used for composition
/// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
/// 
/// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
/// 
/// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
/// 
/// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
   public Eina.List<Efl.Gfx.Entity> CompositionElements {
      get { return GetCompositionElements(); }
      set { SetCompositionElements( value); }
   }
   /// <summary>Register all children in this manager
/// Set to <c>null</c> to register them in the same manager as the implementor is</summary>
   public Efl.Ui.Focus.Manager CustomManager {
      get { return GetCustomManager(); }
      set { SetCustomManager( value); }
   }
   /// <summary>Set to true if all children should be registered as logicals</summary>
   public bool LogicalMode {
      get { return GetLogicalMode(); }
      set { SetLogicalMode( value); }
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
public class ListViewNativeInherit : Efl.Ui.LayoutNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_list_view_relayout_get_static_delegate = new efl_ui_list_view_relayout_get_delegate(relayout_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_relayout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_relayout_get_static_delegate)});
      efl_ui_list_view_relayout_set_static_delegate = new efl_ui_list_view_relayout_set_delegate(relayout_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_relayout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_relayout_set_static_delegate)});
      efl_ui_list_view_homogeneous_get_static_delegate = new efl_ui_list_view_homogeneous_get_delegate(homogeneous_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_homogeneous_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_homogeneous_get_static_delegate)});
      efl_ui_list_view_homogeneous_set_static_delegate = new efl_ui_list_view_homogeneous_set_delegate(homogeneous_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_homogeneous_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_homogeneous_set_static_delegate)});
      efl_ui_list_view_select_mode_get_static_delegate = new efl_ui_list_view_select_mode_get_delegate(select_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_select_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_select_mode_get_static_delegate)});
      efl_ui_list_view_select_mode_set_static_delegate = new efl_ui_list_view_select_mode_set_delegate(select_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_select_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_select_mode_set_static_delegate)});
      efl_ui_list_view_default_style_get_static_delegate = new efl_ui_list_view_default_style_get_delegate(default_style_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_default_style_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_default_style_get_static_delegate)});
      efl_ui_list_view_default_style_set_static_delegate = new efl_ui_list_view_default_style_set_delegate(default_style_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_default_style_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_default_style_set_static_delegate)});
      efl_ui_list_view_layout_factory_set_static_delegate = new efl_ui_list_view_layout_factory_set_delegate(layout_factory_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_layout_factory_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_layout_factory_set_static_delegate)});
      efl_access_selection_selected_children_count_get_static_delegate = new efl_access_selection_selected_children_count_get_delegate(selected_children_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_selected_children_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_selected_children_count_get_static_delegate)});
      efl_access_selection_selected_child_get_static_delegate = new efl_access_selection_selected_child_get_delegate(selected_child_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_selected_child_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_selected_child_get_static_delegate)});
      efl_access_selection_child_select_static_delegate = new efl_access_selection_child_select_delegate(child_select);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_child_select"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_child_select_static_delegate)});
      efl_access_selection_selected_child_deselect_static_delegate = new efl_access_selection_selected_child_deselect_delegate(selected_child_deselect);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_selected_child_deselect"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_selected_child_deselect_static_delegate)});
      efl_access_selection_is_child_selected_static_delegate = new efl_access_selection_is_child_selected_delegate(is_child_selected);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_is_child_selected"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_is_child_selected_static_delegate)});
      efl_access_selection_all_children_select_static_delegate = new efl_access_selection_all_children_select_delegate(all_children_select);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_all_children_select"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_all_children_select_static_delegate)});
      efl_access_selection_clear_static_delegate = new efl_access_selection_clear_delegate(access_selection_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_clear_static_delegate)});
      efl_access_selection_child_deselect_static_delegate = new efl_access_selection_child_deselect_delegate(child_deselect);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_access_selection_child_deselect"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_child_deselect_static_delegate)});
      efl_ui_list_view_model_load_range_set_static_delegate = new efl_ui_list_view_model_load_range_set_delegate(load_range_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_model_load_range_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_load_range_set_static_delegate)});
      efl_ui_list_view_model_size_get_static_delegate = new efl_ui_list_view_model_size_get_delegate(model_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_model_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_size_get_static_delegate)});
      efl_ui_list_view_model_min_size_get_static_delegate = new efl_ui_list_view_model_min_size_get_delegate(min_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_model_min_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_min_size_get_static_delegate)});
      efl_ui_list_view_model_min_size_set_static_delegate = new efl_ui_list_view_model_min_size_set_delegate(min_size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_model_min_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_min_size_set_static_delegate)});
      efl_ui_list_view_model_realize_static_delegate = new efl_ui_list_view_model_realize_delegate(realize);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_model_realize"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_realize_static_delegate)});
      efl_ui_list_view_model_unrealize_static_delegate = new efl_ui_list_view_model_unrealize_delegate(unrealize);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_list_view_model_unrealize"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_unrealize_static_delegate)});
      efl_ui_scrollable_content_pos_get_static_delegate = new efl_ui_scrollable_content_pos_get_delegate(content_pos_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_content_pos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_get_static_delegate)});
      efl_ui_scrollable_content_pos_set_static_delegate = new efl_ui_scrollable_content_pos_set_delegate(content_pos_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_content_pos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_set_static_delegate)});
      efl_ui_scrollable_content_size_get_static_delegate = new efl_ui_scrollable_content_size_get_delegate(content_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_content_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_size_get_static_delegate)});
      efl_ui_scrollable_viewport_geometry_get_static_delegate = new efl_ui_scrollable_viewport_geometry_get_delegate(viewport_geometry_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_viewport_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_viewport_geometry_get_static_delegate)});
      efl_ui_scrollable_bounce_enabled_get_static_delegate = new efl_ui_scrollable_bounce_enabled_get_delegate(bounce_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_bounce_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_get_static_delegate)});
      efl_ui_scrollable_bounce_enabled_set_static_delegate = new efl_ui_scrollable_bounce_enabled_set_delegate(bounce_enabled_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_bounce_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_set_static_delegate)});
      efl_ui_scrollable_scroll_freeze_get_static_delegate = new efl_ui_scrollable_scroll_freeze_get_delegate(scroll_freeze_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_scroll_freeze_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_get_static_delegate)});
      efl_ui_scrollable_scroll_freeze_set_static_delegate = new efl_ui_scrollable_scroll_freeze_set_delegate(scroll_freeze_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_scroll_freeze_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_set_static_delegate)});
      efl_ui_scrollable_scroll_hold_get_static_delegate = new efl_ui_scrollable_scroll_hold_get_delegate(scroll_hold_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_scroll_hold_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_get_static_delegate)});
      efl_ui_scrollable_scroll_hold_set_static_delegate = new efl_ui_scrollable_scroll_hold_set_delegate(scroll_hold_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_scroll_hold_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_set_static_delegate)});
      efl_ui_scrollable_looping_get_static_delegate = new efl_ui_scrollable_looping_get_delegate(looping_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_looping_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_get_static_delegate)});
      efl_ui_scrollable_looping_set_static_delegate = new efl_ui_scrollable_looping_set_delegate(looping_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_looping_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_set_static_delegate)});
      efl_ui_scrollable_movement_block_get_static_delegate = new efl_ui_scrollable_movement_block_get_delegate(movement_block_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_movement_block_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_get_static_delegate)});
      efl_ui_scrollable_movement_block_set_static_delegate = new efl_ui_scrollable_movement_block_set_delegate(movement_block_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_movement_block_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_set_static_delegate)});
      efl_ui_scrollable_gravity_get_static_delegate = new efl_ui_scrollable_gravity_get_delegate(gravity_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_gravity_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_get_static_delegate)});
      efl_ui_scrollable_gravity_set_static_delegate = new efl_ui_scrollable_gravity_set_delegate(gravity_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_gravity_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_set_static_delegate)});
      efl_ui_scrollable_match_content_set_static_delegate = new efl_ui_scrollable_match_content_set_delegate(match_content_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_match_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_match_content_set_static_delegate)});
      efl_ui_scrollable_scroll_static_delegate = new efl_ui_scrollable_scroll_delegate(scroll);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollable_scroll"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_static_delegate)});
      efl_ui_scrollbar_bar_mode_get_static_delegate = new efl_ui_scrollbar_bar_mode_get_delegate(bar_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollbar_bar_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_get_static_delegate)});
      efl_ui_scrollbar_bar_mode_set_static_delegate = new efl_ui_scrollbar_bar_mode_set_delegate(bar_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollbar_bar_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_set_static_delegate)});
      efl_ui_scrollbar_bar_size_get_static_delegate = new efl_ui_scrollbar_bar_size_get_delegate(bar_size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollbar_bar_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_size_get_static_delegate)});
      efl_ui_scrollbar_bar_position_get_static_delegate = new efl_ui_scrollbar_bar_position_get_delegate(bar_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollbar_bar_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_get_static_delegate)});
      efl_ui_scrollbar_bar_position_set_static_delegate = new efl_ui_scrollbar_bar_position_set_delegate(bar_position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollbar_bar_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_set_static_delegate)});
      efl_ui_scrollbar_bar_visibility_update_static_delegate = new efl_ui_scrollbar_bar_visibility_update_delegate(bar_visibility_update);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_scrollbar_bar_visibility_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_visibility_update_static_delegate)});
      efl_ui_widget_focus_manager_create_static_delegate = new efl_ui_widget_focus_manager_create_delegate(focus_manager_create);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_widget_focus_manager_create"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_manager_create_static_delegate)});
      efl_ui_focus_composition_elements_get_static_delegate = new efl_ui_focus_composition_elements_get_delegate(composition_elements_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_get_static_delegate)});
      efl_ui_focus_composition_elements_set_static_delegate = new efl_ui_focus_composition_elements_set_delegate(composition_elements_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_elements_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_set_static_delegate)});
      efl_ui_focus_composition_custom_manager_get_static_delegate = new efl_ui_focus_composition_custom_manager_get_delegate(custom_manager_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_custom_manager_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_custom_manager_get_static_delegate)});
      efl_ui_focus_composition_custom_manager_set_static_delegate = new efl_ui_focus_composition_custom_manager_set_delegate(custom_manager_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_custom_manager_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_custom_manager_set_static_delegate)});
      efl_ui_focus_composition_logical_mode_get_static_delegate = new efl_ui_focus_composition_logical_mode_get_delegate(logical_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_logical_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_get_static_delegate)});
      efl_ui_focus_composition_logical_mode_set_static_delegate = new efl_ui_focus_composition_logical_mode_set_delegate(logical_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_logical_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_set_static_delegate)});
      efl_ui_focus_composition_dirty_static_delegate = new efl_ui_focus_composition_dirty_delegate(dirty);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_dirty"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_dirty_static_delegate)});
      efl_ui_focus_composition_prepare_static_delegate = new efl_ui_focus_composition_prepare_delegate(prepare);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_focus_composition_prepare"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_prepare_static_delegate)});
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
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.ListView.efl_ui_list_view_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.ListView.efl_ui_list_view_class_get();
   }


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.ListViewRelayoutConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.ListViewRelayout efl_ui_list_view_relayout_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.ListViewRelayoutConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.ListViewRelayout efl_ui_list_view_relayout_get(System.IntPtr obj);
    private static Efl.Ui.ListViewRelayout relayout_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_list_view_relayout_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.ListViewRelayout _ret_var = default(Efl.Ui.ListViewRelayout);
         try {
            _ret_var = ((ListView)wrapper).GetRelayout();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_list_view_relayout_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_list_view_relayout_get_delegate efl_ui_list_view_relayout_get_static_delegate;


    private delegate  void efl_ui_list_view_relayout_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.ListViewRelayoutConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.ListViewRelayout kw_object);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_relayout_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.ListViewRelayoutConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.ListViewRelayout kw_object);
    private static  void relayout_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ListViewRelayout kw_object)
   {
      Eina.Log.Debug("function efl_ui_list_view_relayout_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ListView)wrapper).SetRelayout( kw_object);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_list_view_relayout_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_object);
      }
   }
   private efl_ui_list_view_relayout_set_delegate efl_ui_list_view_relayout_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_list_view_homogeneous_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_list_view_homogeneous_get(System.IntPtr obj);
    private static bool homogeneous_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_list_view_homogeneous_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ListView)wrapper).GetHomogeneous();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_list_view_homogeneous_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_list_view_homogeneous_get_delegate efl_ui_list_view_homogeneous_get_static_delegate;


    private delegate  void efl_ui_list_view_homogeneous_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool homogeneous);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_homogeneous_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool homogeneous);
    private static  void homogeneous_set(System.IntPtr obj, System.IntPtr pd,  bool homogeneous)
   {
      Eina.Log.Debug("function efl_ui_list_view_homogeneous_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ListView)wrapper).SetHomogeneous( homogeneous);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_list_view_homogeneous_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  homogeneous);
      }
   }
   private efl_ui_list_view_homogeneous_set_delegate efl_ui_list_view_homogeneous_set_static_delegate;


    private delegate Elm.Object.SelectMode efl_ui_list_view_select_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Elm.Object.SelectMode efl_ui_list_view_select_mode_get(System.IntPtr obj);
    private static Elm.Object.SelectMode select_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_list_view_select_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Elm.Object.SelectMode _ret_var = default(Elm.Object.SelectMode);
         try {
            _ret_var = ((ListView)wrapper).GetSelectMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_list_view_select_mode_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_list_view_select_mode_get_delegate efl_ui_list_view_select_mode_get_static_delegate;


    private delegate  void efl_ui_list_view_select_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Elm.Object.SelectMode mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_select_mode_set(System.IntPtr obj,   Elm.Object.SelectMode mode);
    private static  void select_mode_set(System.IntPtr obj, System.IntPtr pd,  Elm.Object.SelectMode mode)
   {
      Eina.Log.Debug("function efl_ui_list_view_select_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ListView)wrapper).SetSelectMode( mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_list_view_select_mode_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode);
      }
   }
   private efl_ui_list_view_select_mode_set_delegate efl_ui_list_view_select_mode_set_static_delegate;


    private delegate  System.IntPtr efl_ui_list_view_default_style_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_list_view_default_style_get(System.IntPtr obj);
    private static  System.IntPtr default_style_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_list_view_default_style_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((ListView)wrapper).GetDefaultStyle();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_stringshare_to_intptr(((ListView)wrapper).cached_stringshares, _ret_var);
      } else {
         return efl_ui_list_view_default_style_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_list_view_default_style_get_delegate efl_ui_list_view_default_style_get_static_delegate;


    private delegate  void efl_ui_list_view_default_style_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))]   System.String style);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_default_style_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))]   System.String style);
    private static  void default_style_set(System.IntPtr obj, System.IntPtr pd,   System.String style)
   {
      Eina.Log.Debug("function efl_ui_list_view_default_style_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ListView)wrapper).SetDefaultStyle( style);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_list_view_default_style_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  style);
      }
   }
   private efl_ui_list_view_default_style_set_delegate efl_ui_list_view_default_style_set_static_delegate;


    private delegate  void efl_ui_list_view_layout_factory_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.FactoryConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Factory factory);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_layout_factory_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.FactoryConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Factory factory);
    private static  void layout_factory_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Factory factory)
   {
      Eina.Log.Debug("function efl_ui_list_view_layout_factory_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ListView)wrapper).SetLayoutFactory( factory);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_list_view_layout_factory_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  factory);
      }
   }
   private efl_ui_list_view_layout_factory_set_delegate efl_ui_list_view_layout_factory_set_static_delegate;


    private delegate  int efl_access_selection_selected_children_count_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_access_selection_selected_children_count_get(System.IntPtr obj);
    private static  int selected_children_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_selection_selected_children_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((ListView)wrapper).GetSelectedChildrenCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_selection_selected_children_count_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_selection_selected_children_count_get_delegate efl_access_selection_selected_children_count_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_access_selection_selected_child_get_delegate(System.IntPtr obj, System.IntPtr pd,    int selected_child_index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_access_selection_selected_child_get(System.IntPtr obj,    int selected_child_index);
    private static Efl.Object selected_child_get(System.IntPtr obj, System.IntPtr pd,   int selected_child_index)
   {
      Eina.Log.Debug("function efl_access_selection_selected_child_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((ListView)wrapper).GetSelectedChild( selected_child_index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_selection_selected_child_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  selected_child_index);
      }
   }
   private efl_access_selection_selected_child_get_delegate efl_access_selection_selected_child_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_selection_child_select_delegate(System.IntPtr obj, System.IntPtr pd,    int child_index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_child_select(System.IntPtr obj,    int child_index);
    private static bool child_select(System.IntPtr obj, System.IntPtr pd,   int child_index)
   {
      Eina.Log.Debug("function efl_access_selection_child_select was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((ListView)wrapper).ChildSelect( child_index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_selection_child_select(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child_index);
      }
   }
   private efl_access_selection_child_select_delegate efl_access_selection_child_select_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_selection_selected_child_deselect_delegate(System.IntPtr obj, System.IntPtr pd,    int child_index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_selected_child_deselect(System.IntPtr obj,    int child_index);
    private static bool selected_child_deselect(System.IntPtr obj, System.IntPtr pd,   int child_index)
   {
      Eina.Log.Debug("function efl_access_selection_selected_child_deselect was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((ListView)wrapper).SelectedChildDeselect( child_index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_selection_selected_child_deselect(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child_index);
      }
   }
   private efl_access_selection_selected_child_deselect_delegate efl_access_selection_selected_child_deselect_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_selection_is_child_selected_delegate(System.IntPtr obj, System.IntPtr pd,    int child_index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_is_child_selected(System.IntPtr obj,    int child_index);
    private static bool is_child_selected(System.IntPtr obj, System.IntPtr pd,   int child_index)
   {
      Eina.Log.Debug("function efl_access_selection_is_child_selected was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((ListView)wrapper).IsChildSelected( child_index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_selection_is_child_selected(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child_index);
      }
   }
   private efl_access_selection_is_child_selected_delegate efl_access_selection_is_child_selected_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_selection_all_children_select_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_all_children_select(System.IntPtr obj);
    private static bool all_children_select(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_selection_all_children_select was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ListView)wrapper).AllChildrenSelect();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_selection_all_children_select(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_selection_all_children_select_delegate efl_access_selection_all_children_select_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_selection_clear_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_clear(System.IntPtr obj);
    private static bool access_selection_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_access_selection_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ListView)wrapper).ClearAccessSelection();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_access_selection_clear(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_access_selection_clear_delegate efl_access_selection_clear_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_access_selection_child_deselect_delegate(System.IntPtr obj, System.IntPtr pd,    int child_index);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_access_selection_child_deselect(System.IntPtr obj,    int child_index);
    private static bool child_deselect(System.IntPtr obj, System.IntPtr pd,   int child_index)
   {
      Eina.Log.Debug("function efl_access_selection_child_deselect was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((ListView)wrapper).ChildDeselect( child_index);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_access_selection_child_deselect(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  child_index);
      }
   }
   private efl_access_selection_child_deselect_delegate efl_access_selection_child_deselect_static_delegate;


    private delegate  void efl_ui_list_view_model_load_range_set_delegate(System.IntPtr obj, System.IntPtr pd,    int first,    int count);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_model_load_range_set(System.IntPtr obj,    int first,    int count);
    private static  void load_range_set(System.IntPtr obj, System.IntPtr pd,   int first,   int count)
   {
      Eina.Log.Debug("function efl_ui_list_view_model_load_range_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ListView)wrapper).SetLoadRange( first,  count);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_list_view_model_load_range_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  first,  count);
      }
   }
   private efl_ui_list_view_model_load_range_set_delegate efl_ui_list_view_model_load_range_set_static_delegate;


    private delegate  int efl_ui_list_view_model_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  int efl_ui_list_view_model_size_get(System.IntPtr obj);
    private static  int model_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_list_view_model_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((ListView)wrapper).GetModelSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_list_view_model_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_list_view_model_size_get_delegate efl_ui_list_view_model_size_get_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_ui_list_view_model_min_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern Eina.Size2D_StructInternal efl_ui_list_view_model_min_size_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal min_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_list_view_model_min_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((ListView)wrapper).GetMinSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_list_view_model_min_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_list_view_model_min_size_get_delegate efl_ui_list_view_model_min_size_get_static_delegate;


    private delegate  void efl_ui_list_view_model_min_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal min);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_model_min_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal min);
    private static  void min_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal min)
   {
      Eina.Log.Debug("function efl_ui_list_view_model_min_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_min = Eina.Size2D_StructConversion.ToManaged(min);
                     
         try {
            ((ListView)wrapper).SetMinSize( _in_min);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_list_view_model_min_size_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  min);
      }
   }
   private efl_ui_list_view_model_min_size_set_delegate efl_ui_list_view_model_min_size_set_static_delegate;


    private delegate  System.IntPtr efl_ui_list_view_model_realize_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_list_view_model_realize(System.IntPtr obj,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
    private static  System.IntPtr realize(System.IntPtr obj, System.IntPtr pd,  ref Efl.Ui.ListViewLayoutItem_StructInternal item)
   {
      Eina.Log.Debug("function efl_ui_list_view_model_realize was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_item = Efl.Ui.ListViewLayoutItem_StructConversion.ToManaged(item);
                     Efl.Ui.ListViewLayoutItem _ret_var = default(Efl.Ui.ListViewLayoutItem);
         try {
            _ret_var = ((ListView)wrapper).Realize( ref _in_item);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            item = Efl.Ui.ListViewLayoutItem_StructConversion.ToInternal(_in_item);
      return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);
      } else {
         return efl_ui_list_view_model_realize(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref item);
      }
   }
   private efl_ui_list_view_model_realize_delegate efl_ui_list_view_model_realize_static_delegate;


    private delegate  void efl_ui_list_view_model_unrealize_delegate(System.IntPtr obj, System.IntPtr pd,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_list_view_model_unrealize(System.IntPtr obj,   ref Efl.Ui.ListViewLayoutItem_StructInternal item);
    private static  void unrealize(System.IntPtr obj, System.IntPtr pd,  ref Efl.Ui.ListViewLayoutItem_StructInternal item)
   {
      Eina.Log.Debug("function efl_ui_list_view_model_unrealize was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_item = Efl.Ui.ListViewLayoutItem_StructConversion.ToManaged(item);
                     
         try {
            ((ListView)wrapper).Unrealize( ref _in_item);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            item = Efl.Ui.ListViewLayoutItem_StructConversion.ToInternal(_in_item);
            } else {
         efl_ui_list_view_model_unrealize(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ref item);
      }
   }
   private efl_ui_list_view_model_unrealize_delegate efl_ui_list_view_model_unrealize_static_delegate;


    private delegate Eina.Position2D_StructInternal efl_ui_scrollable_content_pos_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Position2D_StructInternal efl_ui_scrollable_content_pos_get(System.IntPtr obj);
    private static Eina.Position2D_StructInternal content_pos_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollable_content_pos_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Position2D _ret_var = default(Eina.Position2D);
         try {
            _ret_var = ((ListView)wrapper).GetContentPos();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Position2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_scrollable_content_pos_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_scrollable_content_pos_get_delegate efl_ui_scrollable_content_pos_get_static_delegate;


    private delegate  void efl_ui_scrollable_content_pos_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal pos);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollable_content_pos_set(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
    private static  void content_pos_set(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D_StructInternal pos)
   {
      Eina.Log.Debug("function efl_ui_scrollable_content_pos_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_pos = Eina.Position2D_StructConversion.ToManaged(pos);
                     
         try {
            ((ListView)wrapper).SetContentPos( _in_pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_scrollable_content_pos_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
      }
   }
   private efl_ui_scrollable_content_pos_set_delegate efl_ui_scrollable_content_pos_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_ui_scrollable_content_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_ui_scrollable_content_size_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal content_size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollable_content_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((ListView)wrapper).GetContentSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_scrollable_content_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_scrollable_content_size_get_delegate efl_ui_scrollable_content_size_get_static_delegate;


    private delegate Eina.Rect_StructInternal efl_ui_scrollable_viewport_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Rect_StructInternal efl_ui_scrollable_viewport_geometry_get(System.IntPtr obj);
    private static Eina.Rect_StructInternal viewport_geometry_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollable_viewport_geometry_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((ListView)wrapper).GetViewportGeometry();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_ui_scrollable_viewport_geometry_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_scrollable_viewport_geometry_get_delegate efl_ui_scrollable_viewport_geometry_get_static_delegate;


    private delegate  void efl_ui_scrollable_bounce_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  out bool horiz,  [MarshalAs(UnmanagedType.U1)]  out bool vert);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollable_bounce_enabled_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool horiz,  [MarshalAs(UnmanagedType.U1)]  out bool vert);
    private static  void bounce_enabled_get(System.IntPtr obj, System.IntPtr pd,  out bool horiz,  out bool vert)
   {
      Eina.Log.Debug("function efl_ui_scrollable_bounce_enabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           horiz = default(bool);      vert = default(bool);                     
         try {
            ((ListView)wrapper).GetBounceEnabled( out horiz,  out vert);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_bounce_enabled_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out horiz,  out vert);
      }
   }
   private efl_ui_scrollable_bounce_enabled_get_delegate efl_ui_scrollable_bounce_enabled_get_static_delegate;


    private delegate  void efl_ui_scrollable_bounce_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool horiz,  [MarshalAs(UnmanagedType.U1)]  bool vert);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollable_bounce_enabled_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool horiz,  [MarshalAs(UnmanagedType.U1)]  bool vert);
    private static  void bounce_enabled_set(System.IntPtr obj, System.IntPtr pd,  bool horiz,  bool vert)
   {
      Eina.Log.Debug("function efl_ui_scrollable_bounce_enabled_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ListView)wrapper).SetBounceEnabled( horiz,  vert);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_bounce_enabled_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  horiz,  vert);
      }
   }
   private efl_ui_scrollable_bounce_enabled_set_delegate efl_ui_scrollable_bounce_enabled_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_scrollable_scroll_freeze_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_scrollable_scroll_freeze_get(System.IntPtr obj);
    private static bool scroll_freeze_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollable_scroll_freeze_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ListView)wrapper).GetScrollFreeze();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_scrollable_scroll_freeze_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_scrollable_scroll_freeze_get_delegate efl_ui_scrollable_scroll_freeze_get_static_delegate;


    private delegate  void efl_ui_scrollable_scroll_freeze_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool freeze);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollable_scroll_freeze_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool freeze);
    private static  void scroll_freeze_set(System.IntPtr obj, System.IntPtr pd,  bool freeze)
   {
      Eina.Log.Debug("function efl_ui_scrollable_scroll_freeze_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ListView)wrapper).SetScrollFreeze( freeze);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_scrollable_scroll_freeze_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  freeze);
      }
   }
   private efl_ui_scrollable_scroll_freeze_set_delegate efl_ui_scrollable_scroll_freeze_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_scrollable_scroll_hold_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_scrollable_scroll_hold_get(System.IntPtr obj);
    private static bool scroll_hold_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollable_scroll_hold_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ListView)wrapper).GetScrollHold();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_scrollable_scroll_hold_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_scrollable_scroll_hold_get_delegate efl_ui_scrollable_scroll_hold_get_static_delegate;


    private delegate  void efl_ui_scrollable_scroll_hold_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool hold);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollable_scroll_hold_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool hold);
    private static  void scroll_hold_set(System.IntPtr obj, System.IntPtr pd,  bool hold)
   {
      Eina.Log.Debug("function efl_ui_scrollable_scroll_hold_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ListView)wrapper).SetScrollHold( hold);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_scrollable_scroll_hold_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hold);
      }
   }
   private efl_ui_scrollable_scroll_hold_set_delegate efl_ui_scrollable_scroll_hold_set_static_delegate;


    private delegate  void efl_ui_scrollable_looping_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  out bool loop_h,  [MarshalAs(UnmanagedType.U1)]  out bool loop_v);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollable_looping_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool loop_h,  [MarshalAs(UnmanagedType.U1)]  out bool loop_v);
    private static  void looping_get(System.IntPtr obj, System.IntPtr pd,  out bool loop_h,  out bool loop_v)
   {
      Eina.Log.Debug("function efl_ui_scrollable_looping_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           loop_h = default(bool);      loop_v = default(bool);                     
         try {
            ((ListView)wrapper).GetLooping( out loop_h,  out loop_v);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_looping_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out loop_h,  out loop_v);
      }
   }
   private efl_ui_scrollable_looping_get_delegate efl_ui_scrollable_looping_get_static_delegate;


    private delegate  void efl_ui_scrollable_looping_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool loop_h,  [MarshalAs(UnmanagedType.U1)]  bool loop_v);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollable_looping_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool loop_h,  [MarshalAs(UnmanagedType.U1)]  bool loop_v);
    private static  void looping_set(System.IntPtr obj, System.IntPtr pd,  bool loop_h,  bool loop_v)
   {
      Eina.Log.Debug("function efl_ui_scrollable_looping_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ListView)wrapper).SetLooping( loop_h,  loop_v);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_looping_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  loop_h,  loop_v);
      }
   }
   private efl_ui_scrollable_looping_set_delegate efl_ui_scrollable_looping_set_static_delegate;


    private delegate Efl.Ui.ScrollBlock efl_ui_scrollable_movement_block_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Ui.ScrollBlock efl_ui_scrollable_movement_block_get(System.IntPtr obj);
    private static Efl.Ui.ScrollBlock movement_block_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollable_movement_block_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.ScrollBlock _ret_var = default(Efl.Ui.ScrollBlock);
         try {
            _ret_var = ((ListView)wrapper).GetMovementBlock();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_scrollable_movement_block_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_scrollable_movement_block_get_delegate efl_ui_scrollable_movement_block_get_static_delegate;


    private delegate  void efl_ui_scrollable_movement_block_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ScrollBlock block);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollable_movement_block_set(System.IntPtr obj,   Efl.Ui.ScrollBlock block);
    private static  void movement_block_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ScrollBlock block)
   {
      Eina.Log.Debug("function efl_ui_scrollable_movement_block_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ListView)wrapper).SetMovementBlock( block);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_scrollable_movement_block_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  block);
      }
   }
   private efl_ui_scrollable_movement_block_set_delegate efl_ui_scrollable_movement_block_set_static_delegate;


    private delegate  void efl_ui_scrollable_gravity_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollable_gravity_get(System.IntPtr obj,   out double x,   out double y);
    private static  void gravity_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_ui_scrollable_gravity_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((ListView)wrapper).GetGravity( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_gravity_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_ui_scrollable_gravity_get_delegate efl_ui_scrollable_gravity_get_static_delegate;


    private delegate  void efl_ui_scrollable_gravity_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollable_gravity_set(System.IntPtr obj,   double x,   double y);
    private static  void gravity_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_ui_scrollable_gravity_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ListView)wrapper).SetGravity( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_gravity_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_ui_scrollable_gravity_set_delegate efl_ui_scrollable_gravity_set_static_delegate;


    private delegate  void efl_ui_scrollable_match_content_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool w,  [MarshalAs(UnmanagedType.U1)]  bool h);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollable_match_content_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool w,  [MarshalAs(UnmanagedType.U1)]  bool h);
    private static  void match_content_set(System.IntPtr obj, System.IntPtr pd,  bool w,  bool h)
   {
      Eina.Log.Debug("function efl_ui_scrollable_match_content_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ListView)wrapper).SetMatchContent( w,  h);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_match_content_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  w,  h);
      }
   }
   private efl_ui_scrollable_match_content_set_delegate efl_ui_scrollable_match_content_set_static_delegate;


    private delegate  void efl_ui_scrollable_scroll_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect_StructInternal rect,  [MarshalAs(UnmanagedType.U1)]  bool animation);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollable_scroll(System.IntPtr obj,   Eina.Rect_StructInternal rect,  [MarshalAs(UnmanagedType.U1)]  bool animation);
    private static  void scroll(System.IntPtr obj, System.IntPtr pd,  Eina.Rect_StructInternal rect,  bool animation)
   {
      Eina.Log.Debug("function efl_ui_scrollable_scroll was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_rect = Eina.Rect_StructConversion.ToManaged(rect);
                                       
         try {
            ((ListView)wrapper).Scroll( _in_rect,  animation);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollable_scroll(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rect,  animation);
      }
   }
   private efl_ui_scrollable_scroll_delegate efl_ui_scrollable_scroll_static_delegate;


    private delegate  void efl_ui_scrollbar_bar_mode_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.Ui.ScrollbarMode hbar,   out Efl.Ui.ScrollbarMode vbar);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollbar_bar_mode_get(System.IntPtr obj,   out Efl.Ui.ScrollbarMode hbar,   out Efl.Ui.ScrollbarMode vbar);
    private static  void bar_mode_get(System.IntPtr obj, System.IntPtr pd,  out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar)
   {
      Eina.Log.Debug("function efl_ui_scrollbar_bar_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           hbar = default(Efl.Ui.ScrollbarMode);      vbar = default(Efl.Ui.ScrollbarMode);                     
         try {
            ((ListView)wrapper).GetBarMode( out hbar,  out vbar);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollbar_bar_mode_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out hbar,  out vbar);
      }
   }
   private efl_ui_scrollbar_bar_mode_get_delegate efl_ui_scrollbar_bar_mode_get_static_delegate;


    private delegate  void efl_ui_scrollbar_bar_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ScrollbarMode hbar,   Efl.Ui.ScrollbarMode vbar);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollbar_bar_mode_set(System.IntPtr obj,   Efl.Ui.ScrollbarMode hbar,   Efl.Ui.ScrollbarMode vbar);
    private static  void bar_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar)
   {
      Eina.Log.Debug("function efl_ui_scrollbar_bar_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ListView)wrapper).SetBarMode( hbar,  vbar);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollbar_bar_mode_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hbar,  vbar);
      }
   }
   private efl_ui_scrollbar_bar_mode_set_delegate efl_ui_scrollbar_bar_mode_set_static_delegate;


    private delegate  void efl_ui_scrollbar_bar_size_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double width,   out double height);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollbar_bar_size_get(System.IntPtr obj,   out double width,   out double height);
    private static  void bar_size_get(System.IntPtr obj, System.IntPtr pd,  out double width,  out double height)
   {
      Eina.Log.Debug("function efl_ui_scrollbar_bar_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           width = default(double);      height = default(double);                     
         try {
            ((ListView)wrapper).GetBarSize( out width,  out height);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollbar_bar_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out width,  out height);
      }
   }
   private efl_ui_scrollbar_bar_size_get_delegate efl_ui_scrollbar_bar_size_get_static_delegate;


    private delegate  void efl_ui_scrollbar_bar_position_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double posx,   out double posy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollbar_bar_position_get(System.IntPtr obj,   out double posx,   out double posy);
    private static  void bar_position_get(System.IntPtr obj, System.IntPtr pd,  out double posx,  out double posy)
   {
      Eina.Log.Debug("function efl_ui_scrollbar_bar_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           posx = default(double);      posy = default(double);                     
         try {
            ((ListView)wrapper).GetBarPosition( out posx,  out posy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollbar_bar_position_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out posx,  out posy);
      }
   }
   private efl_ui_scrollbar_bar_position_get_delegate efl_ui_scrollbar_bar_position_get_static_delegate;


    private delegate  void efl_ui_scrollbar_bar_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   double posx,   double posy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollbar_bar_position_set(System.IntPtr obj,   double posx,   double posy);
    private static  void bar_position_set(System.IntPtr obj, System.IntPtr pd,  double posx,  double posy)
   {
      Eina.Log.Debug("function efl_ui_scrollbar_bar_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((ListView)wrapper).SetBarPosition( posx,  posy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_ui_scrollbar_bar_position_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  posx,  posy);
      }
   }
   private efl_ui_scrollbar_bar_position_set_delegate efl_ui_scrollbar_bar_position_set_static_delegate;


    private delegate  void efl_ui_scrollbar_bar_visibility_update_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_scrollbar_bar_visibility_update(System.IntPtr obj);
    private static  void bar_visibility_update(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_scrollbar_bar_visibility_update was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ListView)wrapper).UpdateBarVisibility();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_scrollbar_bar_visibility_update(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_scrollbar_bar_visibility_update_delegate efl_ui_scrollbar_bar_visibility_update_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Manager efl_ui_widget_focus_manager_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object root);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Manager efl_ui_widget_focus_manager_create(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Object root);
    private static Efl.Ui.Focus.Manager focus_manager_create(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Object root)
   {
      Eina.Log.Debug("function efl_ui_widget_focus_manager_create was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Ui.Focus.Manager _ret_var = default(Efl.Ui.Focus.Manager);
         try {
            _ret_var = ((ListView)wrapper).FocusManagerCreate( root);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_widget_focus_manager_create(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  root);
      }
   }
   private efl_ui_widget_focus_manager_create_delegate efl_ui_widget_focus_manager_create_static_delegate;


    private delegate  System.IntPtr efl_ui_focus_composition_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_focus_composition_elements_get(System.IntPtr obj);
    private static  System.IntPtr composition_elements_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_elements_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Gfx.Entity> _ret_var = default(Eina.List<Efl.Gfx.Entity>);
         try {
            _ret_var = ((ListView)wrapper).GetCompositionElements();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_ui_focus_composition_elements_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_elements_get_delegate efl_ui_focus_composition_elements_get_static_delegate;


    private delegate  void efl_ui_focus_composition_elements_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr logical_order);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_elements_set(System.IntPtr obj,    System.IntPtr logical_order);
    private static  void composition_elements_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr logical_order)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_elements_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_logical_order = new Eina.List<Efl.Gfx.Entity>(logical_order, true, false);
                     
         try {
            ((ListView)wrapper).SetCompositionElements( _in_logical_order);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_composition_elements_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  logical_order);
      }
   }
   private efl_ui_focus_composition_elements_set_delegate efl_ui_focus_composition_elements_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Manager efl_ui_focus_composition_custom_manager_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Manager efl_ui_focus_composition_custom_manager_get(System.IntPtr obj);
    private static Efl.Ui.Focus.Manager custom_manager_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_custom_manager_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Manager _ret_var = default(Efl.Ui.Focus.Manager);
         try {
            _ret_var = ((ListView)wrapper).GetCustomManager();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_composition_custom_manager_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_custom_manager_get_delegate efl_ui_focus_composition_custom_manager_get_static_delegate;


    private delegate  void efl_ui_focus_composition_custom_manager_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager custom_manager);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_custom_manager_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ManagerConcrete, Efl.Eo.NonOwnTag>))]  Efl.Ui.Focus.Manager custom_manager);
    private static  void custom_manager_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Manager custom_manager)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_custom_manager_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ListView)wrapper).SetCustomManager( custom_manager);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_composition_custom_manager_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  custom_manager);
      }
   }
   private efl_ui_focus_composition_custom_manager_set_delegate efl_ui_focus_composition_custom_manager_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_composition_logical_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_focus_composition_logical_mode_get(System.IntPtr obj);
    private static bool logical_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((ListView)wrapper).GetLogicalMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_composition_logical_mode_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_logical_mode_get_delegate efl_ui_focus_composition_logical_mode_get_static_delegate;


    private delegate  void efl_ui_focus_composition_logical_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool logical_mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_logical_mode_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool logical_mode);
    private static  void logical_mode_set(System.IntPtr obj, System.IntPtr pd,  bool logical_mode)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((ListView)wrapper).SetLogicalMode( logical_mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_composition_logical_mode_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  logical_mode);
      }
   }
   private efl_ui_focus_composition_logical_mode_set_delegate efl_ui_focus_composition_logical_mode_set_static_delegate;


    private delegate  void efl_ui_focus_composition_dirty_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_dirty(System.IntPtr obj);
    private static  void dirty(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_dirty was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ListView)wrapper).Dirty();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_composition_dirty(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_dirty_delegate efl_ui_focus_composition_dirty_static_delegate;


    private delegate  void efl_ui_focus_composition_prepare_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_focus_composition_prepare(System.IntPtr obj);
    private static  void prepare(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_prepare was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((ListView)wrapper).Prepare();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_composition_prepare(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_focus_composition_prepare_delegate efl_ui_focus_composition_prepare_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Ui.Focus.Object efl_ui_focus_manager_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Ui.Focus.ObjectConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Ui.Focus.Object efl_ui_focus_manager_focus_get(System.IntPtr obj);
    private static Efl.Ui.Focus.Object manager_focus_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_manager_focus_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Focus.Object _ret_var = default(Efl.Ui.Focus.Object);
         try {
            _ret_var = ((ListView)wrapper).GetManagerFocus();
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
            ((ListView)wrapper).SetManagerFocus( focus);
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
            _ret_var = ((ListView)wrapper).GetRedirect();
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
            ((ListView)wrapper).SetRedirect( redirect);
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
            _ret_var = ((ListView)wrapper).GetBorderElements();
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
            _ret_var = ((ListView)wrapper).GetViewportElements( _in_viewport);
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
            _ret_var = ((ListView)wrapper).GetRoot();
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
            _ret_var = ((ListView)wrapper).SetRoot( root);
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
            _ret_var = ((ListView)wrapper).Move( direction);
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
            _ret_var = ((ListView)wrapper).MoveRequest( direction,  child,  logical);
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
            _ret_var = ((ListView)wrapper).RequestSubchild( child);
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
            _ret_var = ((ListView)wrapper).Fetch( child);
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
            _ret_var = ((ListView)wrapper).LogicalEnd();
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
            ((ListView)wrapper).ResetHistory();
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
            ((ListView)wrapper).PopHistoryStack();
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
            ((ListView)wrapper).SetupOnFirstTouch( direction,  entry);
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
            ((ListView)wrapper).FreezeDirtyLogic();
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
            ((ListView)wrapper).DirtyLogicUnfreeze();
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
} } 
namespace Efl { namespace Ui { 
/// <summary></summary>
[StructLayout(LayoutKind.Sequential)]
public struct ListViewItemEvent
{
   /// <summary></summary>
   public Efl.Ui.Layout Layout;
   /// <summary></summary>
   public Efl.Model Child;
   /// <summary></summary>
   public  int Index;
   ///<summary>Constructor for ListViewItemEvent.</summary>
   public ListViewItemEvent(
      Efl.Ui.Layout Layout=default(Efl.Ui.Layout),
      Efl.Model Child=default(Efl.Model),
       int Index=default( int)   )
   {
      this.Layout = Layout;
      this.Child = Child;
      this.Index = Index;
   }
public static implicit operator ListViewItemEvent(IntPtr ptr)
   {
      var tmp = (ListViewItemEvent_StructInternal)Marshal.PtrToStructure(ptr, typeof(ListViewItemEvent_StructInternal));
      return ListViewItemEvent_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct ListViewItemEvent.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ListViewItemEvent_StructInternal
{
///<summary>Internal wrapper for field Layout</summary>
public System.IntPtr Layout;
///<summary>Internal wrapper for field Child</summary>
public System.IntPtr Child;
   
   public  int Index;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator ListViewItemEvent(ListViewItemEvent_StructInternal struct_)
   {
      return ListViewItemEvent_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator ListViewItemEvent_StructInternal(ListViewItemEvent struct_)
   {
      return ListViewItemEvent_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct ListViewItemEvent</summary>
public static class ListViewItemEvent_StructConversion
{
   internal static ListViewItemEvent_StructInternal ToInternal(ListViewItemEvent _external_struct)
   {
      var _internal_struct = new ListViewItemEvent_StructInternal();

      _internal_struct.Layout = _external_struct.Layout.NativeHandle;
      _internal_struct.Child = _external_struct.Child.NativeHandle;
      _internal_struct.Index = _external_struct.Index;

      return _internal_struct;
   }

   internal static ListViewItemEvent ToManaged(ListViewItemEvent_StructInternal _internal_struct)
   {
      var _external_struct = new ListViewItemEvent();


      _external_struct.Layout = (Efl.Ui.Layout) System.Activator.CreateInstance(typeof(Efl.Ui.Layout), new System.Object[] {_internal_struct.Layout});
      Efl.Eo.Globals.efl_ref(_internal_struct.Layout);


      _external_struct.Child = (Efl.ModelConcrete) System.Activator.CreateInstance(typeof(Efl.ModelConcrete), new System.Object[] {_internal_struct.Child});
      Efl.Eo.Globals.efl_ref(_internal_struct.Child);

      _external_struct.Index = _internal_struct.Index;

      return _external_struct;
   }

}
} } 
