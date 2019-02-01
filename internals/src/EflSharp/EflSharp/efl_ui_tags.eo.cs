#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ItemSelectedEvt"/>.</summary>
public class TagsItemSelectedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public  System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ItemAddedEvt"/>.</summary>
public class TagsItemAddedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public  System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ItemDeletedEvt"/>.</summary>
public class TagsItemDeletedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public  System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ItemClickedEvt"/>.</summary>
public class TagsItemClickedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public  System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ItemLongpressedEvt"/>.</summary>
public class TagsItemLongpressedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public  System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ExpandStateChangedEvt"/>.</summary>
public class TagsExpandStateChangedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public  int arg { get; set; }
}
/// <summary>Elementary Tags class</summary>
[TagsNativeInherit]
public class Tags : Efl.Ui.Layout, Efl.Eo.IWrapper,Efl.Text,Efl.Ui.Format
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.TagsNativeInherit nativeInherit = new Efl.Ui.TagsNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Tags))
            return Efl.Ui.TagsNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Tags obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_tags_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Tags(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Tags", efl_ui_tags_class_get(), typeof(Tags), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Tags(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Tags(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Tags static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Tags(obj.NativeHandle);
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
private static object ItemSelectedEvtKey = new object();
   /// <summary>Called when item was selected</summary>
   public event EventHandler<Efl.Ui.TagsItemSelectedEvt_Args> ItemSelectedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_ITEM_SELECTED";
            if (add_cpp_event_handler(key, this.evt_ItemSelectedEvt_delegate)) {
               eventHandlers.AddHandler(ItemSelectedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_ITEM_SELECTED";
            if (remove_cpp_event_handler(key, this.evt_ItemSelectedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ItemSelectedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ItemSelectedEvt.</summary>
   public void On_ItemSelectedEvt(Efl.Ui.TagsItemSelectedEvt_Args e)
   {
      EventHandler<Efl.Ui.TagsItemSelectedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.TagsItemSelectedEvt_Args>)eventHandlers[ItemSelectedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ItemSelectedEvt_delegate;
   private void on_ItemSelectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.TagsItemSelectedEvt_Args args = new Efl.Ui.TagsItemSelectedEvt_Args();
      args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
      try {
         On_ItemSelectedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ItemAddedEvtKey = new object();
   /// <summary>Called when item was added</summary>
   public event EventHandler<Efl.Ui.TagsItemAddedEvt_Args> ItemAddedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_ITEM_ADDED";
            if (add_cpp_event_handler(key, this.evt_ItemAddedEvt_delegate)) {
               eventHandlers.AddHandler(ItemAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_ITEM_ADDED";
            if (remove_cpp_event_handler(key, this.evt_ItemAddedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ItemAddedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ItemAddedEvt.</summary>
   public void On_ItemAddedEvt(Efl.Ui.TagsItemAddedEvt_Args e)
   {
      EventHandler<Efl.Ui.TagsItemAddedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.TagsItemAddedEvt_Args>)eventHandlers[ItemAddedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ItemAddedEvt_delegate;
   private void on_ItemAddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.TagsItemAddedEvt_Args args = new Efl.Ui.TagsItemAddedEvt_Args();
      args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
      try {
         On_ItemAddedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ItemDeletedEvtKey = new object();
   /// <summary>Called when item was deleted</summary>
   public event EventHandler<Efl.Ui.TagsItemDeletedEvt_Args> ItemDeletedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_ITEM_DELETED";
            if (add_cpp_event_handler(key, this.evt_ItemDeletedEvt_delegate)) {
               eventHandlers.AddHandler(ItemDeletedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_ITEM_DELETED";
            if (remove_cpp_event_handler(key, this.evt_ItemDeletedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ItemDeletedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ItemDeletedEvt.</summary>
   public void On_ItemDeletedEvt(Efl.Ui.TagsItemDeletedEvt_Args e)
   {
      EventHandler<Efl.Ui.TagsItemDeletedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.TagsItemDeletedEvt_Args>)eventHandlers[ItemDeletedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ItemDeletedEvt_delegate;
   private void on_ItemDeletedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.TagsItemDeletedEvt_Args args = new Efl.Ui.TagsItemDeletedEvt_Args();
      args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
      try {
         On_ItemDeletedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ItemClickedEvtKey = new object();
   /// <summary>Called when item was clicked</summary>
   public event EventHandler<Efl.Ui.TagsItemClickedEvt_Args> ItemClickedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_ITEM_CLICKED";
            if (add_cpp_event_handler(key, this.evt_ItemClickedEvt_delegate)) {
               eventHandlers.AddHandler(ItemClickedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_ITEM_CLICKED";
            if (remove_cpp_event_handler(key, this.evt_ItemClickedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ItemClickedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ItemClickedEvt.</summary>
   public void On_ItemClickedEvt(Efl.Ui.TagsItemClickedEvt_Args e)
   {
      EventHandler<Efl.Ui.TagsItemClickedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.TagsItemClickedEvt_Args>)eventHandlers[ItemClickedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ItemClickedEvt_delegate;
   private void on_ItemClickedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.TagsItemClickedEvt_Args args = new Efl.Ui.TagsItemClickedEvt_Args();
      args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
      try {
         On_ItemClickedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ItemLongpressedEvtKey = new object();
   /// <summary>Called when item got a longpress</summary>
   public event EventHandler<Efl.Ui.TagsItemLongpressedEvt_Args> ItemLongpressedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_ITEM_LONGPRESSED";
            if (add_cpp_event_handler(key, this.evt_ItemLongpressedEvt_delegate)) {
               eventHandlers.AddHandler(ItemLongpressedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_ITEM_LONGPRESSED";
            if (remove_cpp_event_handler(key, this.evt_ItemLongpressedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ItemLongpressedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ItemLongpressedEvt.</summary>
   public void On_ItemLongpressedEvt(Efl.Ui.TagsItemLongpressedEvt_Args e)
   {
      EventHandler<Efl.Ui.TagsItemLongpressedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.TagsItemLongpressedEvt_Args>)eventHandlers[ItemLongpressedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ItemLongpressedEvt_delegate;
   private void on_ItemLongpressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.TagsItemLongpressedEvt_Args args = new Efl.Ui.TagsItemLongpressedEvt_Args();
      args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
      try {
         On_ItemLongpressedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ExpandedEvtKey = new object();
   /// <summary>Called when expanded</summary>
   public event EventHandler ExpandedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_EXPANDED";
            if (add_cpp_event_handler(key, this.evt_ExpandedEvt_delegate)) {
               eventHandlers.AddHandler(ExpandedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_EXPANDED";
            if (remove_cpp_event_handler(key, this.evt_ExpandedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ExpandedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ExpandedEvt.</summary>
   public void On_ExpandedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ExpandedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ExpandedEvt_delegate;
   private void on_ExpandedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ExpandedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ContractedEvtKey = new object();
   /// <summary>Called when contracted</summary>
   public event EventHandler ContractedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_CONTRACTED";
            if (add_cpp_event_handler(key, this.evt_ContractedEvt_delegate)) {
               eventHandlers.AddHandler(ContractedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_CONTRACTED";
            if (remove_cpp_event_handler(key, this.evt_ContractedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContractedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContractedEvt.</summary>
   public void On_ContractedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ContractedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContractedEvt_delegate;
   private void on_ContractedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ContractedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ExpandStateChangedEvtKey = new object();
   /// <summary>Called when expanded state changed</summary>
   public event EventHandler<Efl.Ui.TagsExpandStateChangedEvt_Args> ExpandStateChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_EXPAND_STATE_CHANGED";
            if (add_cpp_event_handler(key, this.evt_ExpandStateChangedEvt_delegate)) {
               eventHandlers.AddHandler(ExpandStateChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_TAGS_EVENT_EXPAND_STATE_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ExpandStateChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ExpandStateChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ExpandStateChangedEvt.</summary>
   public void On_ExpandStateChangedEvt(Efl.Ui.TagsExpandStateChangedEvt_Args e)
   {
      EventHandler<Efl.Ui.TagsExpandStateChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Ui.TagsExpandStateChangedEvt_Args>)eventHandlers[ExpandStateChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ExpandStateChangedEvt_delegate;
   private void on_ExpandStateChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Ui.TagsExpandStateChangedEvt_Args args = new Efl.Ui.TagsExpandStateChangedEvt_Args();
      args.arg = evt.Info.ToInt32();
      try {
         On_ExpandStateChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ItemSelectedEvt_delegate = new Efl.EventCb(on_ItemSelectedEvt_NativeCallback);
      evt_ItemAddedEvt_delegate = new Efl.EventCb(on_ItemAddedEvt_NativeCallback);
      evt_ItemDeletedEvt_delegate = new Efl.EventCb(on_ItemDeletedEvt_NativeCallback);
      evt_ItemClickedEvt_delegate = new Efl.EventCb(on_ItemClickedEvt_NativeCallback);
      evt_ItemLongpressedEvt_delegate = new Efl.EventCb(on_ItemLongpressedEvt_NativeCallback);
      evt_ExpandedEvt_delegate = new Efl.EventCb(on_ExpandedEvt_NativeCallback);
      evt_ContractedEvt_delegate = new Efl.EventCb(on_ContractedEvt_NativeCallback);
      evt_ExpandStateChangedEvt_delegate = new Efl.EventCb(on_ExpandStateChangedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_tags_editable_get(System.IntPtr obj);
   /// <summary>Control if the tags is to be editable or not.</summary>
   /// <returns>If <c>true</c>, user can add/delete item in tags, if not, the tags is non-editable.</returns>
   virtual public bool GetEditable() {
       var _ret_var = efl_ui_tags_editable_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_tags_editable_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool editable);
   /// <summary>Control if the tags is to be editable or not.</summary>
   /// <param name="editable">If <c>true</c>, user can add/delete item in tags, if not, the tags is non-editable.</param>
   /// <returns></returns>
   virtual public  void SetEditable( bool editable) {
                         efl_ui_tags_editable_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  editable);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_tags_expanded_get(System.IntPtr obj);
   /// <summary>Control the tags to expanded state.
   /// In expanded state, the complete entry will be displayed. Otherwise, only single line of the entry will be displayed.</summary>
   /// <returns>The value of expanded state. Set this to <c>true</c> for expanded state. Set this to <c>false</c> for single line state.</returns>
   virtual public bool GetExpanded() {
       var _ret_var = efl_ui_tags_expanded_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_tags_expanded_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool expanded);
   /// <summary>Control the tags to expanded state.
   /// In expanded state, the complete entry will be displayed. Otherwise, only single line of the entry will be displayed.</summary>
   /// <param name="expanded">The value of expanded state. Set this to <c>true</c> for expanded state. Set this to <c>false</c> for single line state.</param>
   /// <returns></returns>
   virtual public  void SetExpanded( bool expanded) {
                         efl_ui_tags_expanded_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  expanded);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  System.IntPtr efl_ui_tags_items_get(System.IntPtr obj);
   /// <summary>Get a list of items in the tags</summary>
   /// <returns>The array of items, or NULL if none</returns>
   virtual public Eina.Array< System.String> GetItems() {
       var _ret_var = efl_ui_tags_items_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Array< System.String>(_ret_var, false, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    protected static extern  void efl_ui_tags_items_set(System.IntPtr obj,    System.IntPtr items);
   /// <summary>Get a list of items in the tags</summary>
   /// <param name="items">The array of items, or NULL if none</param>
   /// <returns></returns>
   virtual public  void SetItems( Eina.Array< System.String> items) {
       var _in_items = items.Handle;
                  efl_ui_tags_items_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_items);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_text_get(System.IntPtr obj);
   /// <summary>Retrieves the text string currently being displayed by the given text object.
   /// Do not free() the return value.
   /// 
   /// See also <see cref="Efl.Text.GetText"/>.</summary>
   /// <returns>Text string to display on it.</returns>
   virtual public  System.String GetText() {
       var _ret_var = efl_text_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_text_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
   /// <summary>Sets the text string to be displayed by the given text object.
   /// See also <see cref="Efl.Text.GetText"/>.</summary>
   /// <param name="text">Text string to display on it.</param>
   /// <returns></returns>
   virtual public  void SetText(  System.String text) {
                         efl_text_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  text);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_format_cb_set(System.IntPtr obj,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);
   /// <summary>Set the format function pointer to format the string.</summary>
   /// <param name="func">The format function callback</param>
   /// <returns></returns>
   virtual public  void SetFormatCb( Efl.Ui.FormatFuncCb func) {
                   GCHandle func_handle = GCHandle.Alloc(func);
      efl_ui_format_cb_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), GCHandle.ToIntPtr(func_handle), Efl.Ui.FormatFuncCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_ui_format_string_get(System.IntPtr obj);
   /// <summary>Control the format string for a given units label
   /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
   /// 
   /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
   /// <returns>The format string for <c>obj</c>&apos;s units label.</returns>
   virtual public  System.String GetFormatString() {
       var _ret_var = efl_ui_format_string_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_format_string_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String units);
   /// <summary>Control the format string for a given units label
   /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
   /// 
   /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
   /// <param name="units">The format string for <c>obj</c>&apos;s units label.</param>
   /// <returns></returns>
   virtual public  void SetFormatString(  System.String units) {
                         efl_ui_format_string_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  units);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control if the tags is to be editable or not.</summary>
   public bool Editable {
      get { return GetEditable(); }
      set { SetEditable( value); }
   }
   /// <summary>Control the tags to expanded state.
/// In expanded state, the complete entry will be displayed. Otherwise, only single line of the entry will be displayed.</summary>
   public bool Expanded {
      get { return GetExpanded(); }
      set { SetExpanded( value); }
   }
   /// <summary>Get a list of items in the tags</summary>
   public Eina.Array< System.String> Items {
      get { return GetItems(); }
      set { SetItems( value); }
   }
   /// <summary>Set the format function pointer to format the string.</summary>
   public Efl.Ui.FormatFuncCb FormatCb {
      set { SetFormatCb( value); }
   }
   /// <summary>Control the format string for a given units label
/// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
/// 
/// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
   public  System.String FormatString {
      get { return GetFormatString(); }
      set { SetFormatString( value); }
   }
}
public class TagsNativeInherit : Efl.Ui.LayoutNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_tags_editable_get_static_delegate = new efl_ui_tags_editable_get_delegate(editable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_tags_editable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_editable_get_static_delegate)});
      efl_ui_tags_editable_set_static_delegate = new efl_ui_tags_editable_set_delegate(editable_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_tags_editable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_editable_set_static_delegate)});
      efl_ui_tags_expanded_get_static_delegate = new efl_ui_tags_expanded_get_delegate(expanded_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_tags_expanded_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_expanded_get_static_delegate)});
      efl_ui_tags_expanded_set_static_delegate = new efl_ui_tags_expanded_set_delegate(expanded_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_tags_expanded_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_expanded_set_static_delegate)});
      efl_ui_tags_items_get_static_delegate = new efl_ui_tags_items_get_delegate(items_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_tags_items_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_items_get_static_delegate)});
      efl_ui_tags_items_set_static_delegate = new efl_ui_tags_items_set_delegate(items_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_tags_items_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_items_set_static_delegate)});
      efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate)});
      efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate)});
      efl_ui_format_cb_set_static_delegate = new efl_ui_format_cb_set_delegate(format_cb_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_format_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_cb_set_static_delegate)});
      efl_ui_format_string_get_static_delegate = new efl_ui_format_string_get_delegate(format_string_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_format_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_get_static_delegate)});
      efl_ui_format_string_set_static_delegate = new efl_ui_format_string_set_delegate(format_string_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_format_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.Tags.efl_ui_tags_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.Tags.efl_ui_tags_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_tags_editable_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_tags_editable_get(System.IntPtr obj);
    private static bool editable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_tags_editable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Tags)wrapper).GetEditable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_tags_editable_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_tags_editable_get_delegate efl_ui_tags_editable_get_static_delegate;


    private delegate  void efl_ui_tags_editable_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool editable);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_tags_editable_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool editable);
    private static  void editable_set(System.IntPtr obj, System.IntPtr pd,  bool editable)
   {
      Eina.Log.Debug("function efl_ui_tags_editable_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Tags)wrapper).SetEditable( editable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_tags_editable_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  editable);
      }
   }
   private efl_ui_tags_editable_set_delegate efl_ui_tags_editable_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_tags_expanded_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_tags_expanded_get(System.IntPtr obj);
    private static bool expanded_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_tags_expanded_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Tags)wrapper).GetExpanded();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_tags_expanded_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_tags_expanded_get_delegate efl_ui_tags_expanded_get_static_delegate;


    private delegate  void efl_ui_tags_expanded_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool expanded);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_tags_expanded_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool expanded);
    private static  void expanded_set(System.IntPtr obj, System.IntPtr pd,  bool expanded)
   {
      Eina.Log.Debug("function efl_ui_tags_expanded_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Tags)wrapper).SetExpanded( expanded);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_tags_expanded_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  expanded);
      }
   }
   private efl_ui_tags_expanded_set_delegate efl_ui_tags_expanded_set_static_delegate;


    private delegate  System.IntPtr efl_ui_tags_items_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  System.IntPtr efl_ui_tags_items_get(System.IntPtr obj);
    private static  System.IntPtr items_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_tags_items_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Array< System.String> _ret_var = default(Eina.Array< System.String>);
         try {
            _ret_var = ((Tags)wrapper).GetItems();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_ui_tags_items_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_tags_items_get_delegate efl_ui_tags_items_get_static_delegate;


    private delegate  void efl_ui_tags_items_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr items);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  private static extern  void efl_ui_tags_items_set(System.IntPtr obj,    System.IntPtr items);
    private static  void items_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr items)
   {
      Eina.Log.Debug("function efl_ui_tags_items_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_items = new Eina.Array< System.String>(items, false, false);
                     
         try {
            ((Tags)wrapper).SetItems( _in_items);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_tags_items_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  items);
      }
   }
   private efl_ui_tags_items_set_delegate efl_ui_tags_items_set_static_delegate;


    private delegate  System.IntPtr efl_text_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_text_get(System.IntPtr obj);
    private static  System.IntPtr text_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_text_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Tags)wrapper).GetText();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Tags)wrapper).cached_strings, _ret_var);
      } else {
         return efl_text_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_text_get_delegate efl_text_get_static_delegate;


    private delegate  void efl_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_text_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String text);
    private static  void text_set(System.IntPtr obj, System.IntPtr pd,   System.String text)
   {
      Eina.Log.Debug("function efl_text_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Tags)wrapper).SetText( text);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_text_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text);
      }
   }
   private efl_text_set_delegate efl_text_set_static_delegate;


    private delegate  void efl_ui_format_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_format_cb_set(System.IntPtr obj,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);
    private static  void format_cb_set(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb)
   {
      Eina.Log.Debug("function efl_ui_format_cb_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                              Efl.Ui.FormatFuncCbWrapper func_wrapper = new Efl.Ui.FormatFuncCbWrapper(func, func_data, func_free_cb);
         
         try {
            ((Tags)wrapper).SetFormatCb( func_wrapper.ManagedCb);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_format_cb_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
      }
   }
   private efl_ui_format_cb_set_delegate efl_ui_format_cb_set_static_delegate;


    private delegate  System.IntPtr efl_ui_format_string_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_ui_format_string_get(System.IntPtr obj);
    private static  System.IntPtr format_string_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_format_string_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Tags)wrapper).GetFormatString();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Tags)wrapper).cached_strings, _ret_var);
      } else {
         return efl_ui_format_string_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_format_string_get_delegate efl_ui_format_string_get_static_delegate;


    private delegate  void efl_ui_format_string_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String units);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_format_string_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String units);
    private static  void format_string_set(System.IntPtr obj, System.IntPtr pd,   System.String units)
   {
      Eina.Log.Debug("function efl_ui_format_string_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Tags)wrapper).SetFormatString( units);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_format_string_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  units);
      }
   }
   private efl_ui_format_string_set_delegate efl_ui_format_string_set_static_delegate;
}
} } 
