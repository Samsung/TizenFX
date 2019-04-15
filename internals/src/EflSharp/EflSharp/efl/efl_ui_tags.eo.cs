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
    public System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ItemAddedEvt"/>.</summary>
public class TagsItemAddedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ItemDeletedEvt"/>.</summary>
public class TagsItemDeletedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ItemClickedEvt"/>.</summary>
public class TagsItemClickedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ItemLongpressedEvt"/>.</summary>
public class TagsItemLongpressedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ExpandStateChangedEvt"/>.</summary>
public class TagsExpandStateChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public int arg { get; set; }
}
/// <summary>A widget displaying a list of tags. The user can remove tags by clicking on each tag &quot;close&quot; button and add new tags by typing text in the text entry at the end of the list.</summary>
[TagsNativeInherit]
public class Tags : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.IText,Efl.Ui.IFormat
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Tags))
                return Efl.Ui.TagsNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_tags_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Tags(Efl.Object parent
            , System.String style = null) :
        base(efl_ui_tags_class_get(), typeof(Tags), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Tags(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Tags(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_ItemSelectedEvt_delegate)) {
                    eventHandlers.AddHandler(ItemSelectedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_TAGS_EVENT_ITEM_SELECTED";
                if (RemoveNativeEventHandler(key, this.evt_ItemSelectedEvt_delegate)) { 
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
    private void on_ItemSelectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
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
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_ItemAddedEvt_delegate)) {
                    eventHandlers.AddHandler(ItemAddedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_TAGS_EVENT_ITEM_ADDED";
                if (RemoveNativeEventHandler(key, this.evt_ItemAddedEvt_delegate)) { 
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
    private void on_ItemAddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
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
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_ItemDeletedEvt_delegate)) {
                    eventHandlers.AddHandler(ItemDeletedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_TAGS_EVENT_ITEM_DELETED";
                if (RemoveNativeEventHandler(key, this.evt_ItemDeletedEvt_delegate)) { 
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
    private void on_ItemDeletedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
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
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_ItemClickedEvt_delegate)) {
                    eventHandlers.AddHandler(ItemClickedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_TAGS_EVENT_ITEM_CLICKED";
                if (RemoveNativeEventHandler(key, this.evt_ItemClickedEvt_delegate)) { 
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
    private void on_ItemClickedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
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
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_ItemLongpressedEvt_delegate)) {
                    eventHandlers.AddHandler(ItemLongpressedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_TAGS_EVENT_ITEM_LONGPRESSED";
                if (RemoveNativeEventHandler(key, this.evt_ItemLongpressedEvt_delegate)) { 
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
    private void on_ItemLongpressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
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
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_ExpandedEvt_delegate)) {
                    eventHandlers.AddHandler(ExpandedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_TAGS_EVENT_EXPANDED";
                if (RemoveNativeEventHandler(key, this.evt_ExpandedEvt_delegate)) { 
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
    private void on_ExpandedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
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
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_ContractedEvt_delegate)) {
                    eventHandlers.AddHandler(ContractedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_TAGS_EVENT_CONTRACTED";
                if (RemoveNativeEventHandler(key, this.evt_ContractedEvt_delegate)) { 
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
    private void on_ContractedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
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
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_ExpandStateChangedEvt_delegate)) {
                    eventHandlers.AddHandler(ExpandStateChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_TAGS_EVENT_EXPAND_STATE_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_ExpandStateChangedEvt_delegate)) { 
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
    private void on_ExpandStateChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
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

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_ItemSelectedEvt_delegate = new Efl.EventCb(on_ItemSelectedEvt_NativeCallback);
        evt_ItemAddedEvt_delegate = new Efl.EventCb(on_ItemAddedEvt_NativeCallback);
        evt_ItemDeletedEvt_delegate = new Efl.EventCb(on_ItemDeletedEvt_NativeCallback);
        evt_ItemClickedEvt_delegate = new Efl.EventCb(on_ItemClickedEvt_NativeCallback);
        evt_ItemLongpressedEvt_delegate = new Efl.EventCb(on_ItemLongpressedEvt_NativeCallback);
        evt_ExpandedEvt_delegate = new Efl.EventCb(on_ExpandedEvt_NativeCallback);
        evt_ContractedEvt_delegate = new Efl.EventCb(on_ContractedEvt_NativeCallback);
        evt_ExpandStateChangedEvt_delegate = new Efl.EventCb(on_ExpandStateChangedEvt_NativeCallback);
    }
    /// <summary>Control if the tag list is to be editable by the user or not.</summary>
    /// <returns>If <c>true</c>, the user can add/delete tags to the tag list, if not, the tag list is non-editable.</returns>
    virtual public bool GetEditable() {
         var _ret_var = Efl.Ui.TagsNativeInherit.efl_ui_tags_editable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control if the tag list is to be editable by the user or not.</summary>
    /// <param name="editable">If <c>true</c>, the user can add/delete tags to the tag list, if not, the tag list is non-editable.</param>
    /// <returns></returns>
    virtual public void SetEditable( bool editable) {
                                 Efl.Ui.TagsNativeInherit.efl_ui_tags_editable_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), editable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control whether the tag list is expanded or not.
    /// In the expanded state, all tags will be displayed. Otherwise, only a single line of tags will be displayed with a marker to indicate that there is more content.</summary>
    /// <returns>The expanded state. Set this to <c>true</c> to allow multiple lines of tags. Set to <c>false</c> for a single line.</returns>
    virtual public bool GetExpanded() {
         var _ret_var = Efl.Ui.TagsNativeInherit.efl_ui_tags_expanded_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control whether the tag list is expanded or not.
    /// In the expanded state, all tags will be displayed. Otherwise, only a single line of tags will be displayed with a marker to indicate that there is more content.</summary>
    /// <param name="expanded">The expanded state. Set this to <c>true</c> to allow multiple lines of tags. Set to <c>false</c> for a single line.</param>
    /// <returns></returns>
    virtual public void SetExpanded( bool expanded) {
                                 Efl.Ui.TagsNativeInherit.efl_ui_tags_expanded_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), expanded);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>List of tags in the tag list. Tags can be added and removed by the user using the UI, and by the program by modifying this property.</summary>
    /// <returns>The array of items, or NULL if none.</returns>
    virtual public Eina.Array<System.String> GetItems() {
         var _ret_var = Efl.Ui.TagsNativeInherit.efl_ui_tags_items_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Array<System.String>(_ret_var, false, false);
 }
    /// <summary>List of tags in the tag list. Tags can be added and removed by the user using the UI, and by the program by modifying this property.</summary>
    /// <param name="items">The array of items, or NULL if none.</param>
    /// <returns></returns>
    virtual public void SetItems( Eina.Array<System.String> items) {
         var _in_items = items.Handle;
                        Efl.Ui.TagsNativeInherit.efl_ui_tags_items_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_items);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves the text string currently being displayed by the given text object.
    /// Do not free() the return value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Text string to display on it.</returns>
    virtual public System.String GetText() {
         var _ret_var = Efl.ITextNativeInherit.efl_text_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the text string to be displayed by the given text object.
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="text">Text string to display on it.</param>
    /// <returns></returns>
    virtual public void SetText( System.String text) {
                                 Efl.ITextNativeInherit.efl_text_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), text);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the format function pointer to format the string.</summary>
    /// <param name="func">The format function callback</param>
    /// <returns></returns>
    virtual public void SetFormatCb( Efl.Ui.FormatFuncCb func) {
                         GCHandle func_handle = GCHandle.Alloc(func);
        Efl.Ui.IFormatNativeInherit.efl_ui_format_cb_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),GCHandle.ToIntPtr(func_handle), Efl.Ui.FormatFuncCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the format string for a given units label
    /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
    /// 
    /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
    /// <returns>The format string for <c>obj</c>&apos;s units label.</returns>
    virtual public System.String GetFormatString() {
         var _ret_var = Efl.Ui.IFormatNativeInherit.efl_ui_format_string_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the format string for a given units label
    /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
    /// 
    /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
    /// <param name="units">The format string for <c>obj</c>&apos;s units label.</param>
    /// <returns></returns>
    virtual public void SetFormatString( System.String units) {
                                 Efl.Ui.IFormatNativeInherit.efl_ui_format_string_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), units);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control if the tag list is to be editable by the user or not.</summary>
/// <value>If <c>true</c>, the user can add/delete tags to the tag list, if not, the tag list is non-editable.</value>
    public bool Editable {
        get { return GetEditable(); }
        set { SetEditable( value); }
    }
    /// <summary>Control whether the tag list is expanded or not.
/// In the expanded state, all tags will be displayed. Otherwise, only a single line of tags will be displayed with a marker to indicate that there is more content.</summary>
/// <value>The expanded state. Set this to <c>true</c> to allow multiple lines of tags. Set to <c>false</c> for a single line.</value>
    public bool Expanded {
        get { return GetExpanded(); }
        set { SetExpanded( value); }
    }
    /// <summary>List of tags in the tag list. Tags can be added and removed by the user using the UI, and by the program by modifying this property.</summary>
/// <value>The array of items, or NULL if none.</value>
    public Eina.Array<System.String> Items {
        get { return GetItems(); }
        set { SetItems( value); }
    }
    /// <summary>Set the format function pointer to format the string.</summary>
/// <value>The format function callback</value>
    public Efl.Ui.FormatFuncCb FormatCb {
        set { SetFormatCb( value); }
    }
    /// <summary>Control the format string for a given units label
/// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
/// 
/// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
/// <value>The format string for <c>obj</c>&apos;s units label.</value>
    public System.String FormatString {
        get { return GetFormatString(); }
        set { SetFormatString( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Tags.efl_ui_tags_class_get();
    }
}
public class TagsNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_tags_editable_get_static_delegate == null)
            efl_ui_tags_editable_get_static_delegate = new efl_ui_tags_editable_get_delegate(editable_get);
        if (methods.FirstOrDefault(m => m.Name == "GetEditable") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tags_editable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_editable_get_static_delegate)});
        if (efl_ui_tags_editable_set_static_delegate == null)
            efl_ui_tags_editable_set_static_delegate = new efl_ui_tags_editable_set_delegate(editable_set);
        if (methods.FirstOrDefault(m => m.Name == "SetEditable") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tags_editable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_editable_set_static_delegate)});
        if (efl_ui_tags_expanded_get_static_delegate == null)
            efl_ui_tags_expanded_get_static_delegate = new efl_ui_tags_expanded_get_delegate(expanded_get);
        if (methods.FirstOrDefault(m => m.Name == "GetExpanded") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tags_expanded_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_expanded_get_static_delegate)});
        if (efl_ui_tags_expanded_set_static_delegate == null)
            efl_ui_tags_expanded_set_static_delegate = new efl_ui_tags_expanded_set_delegate(expanded_set);
        if (methods.FirstOrDefault(m => m.Name == "SetExpanded") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tags_expanded_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_expanded_set_static_delegate)});
        if (efl_ui_tags_items_get_static_delegate == null)
            efl_ui_tags_items_get_static_delegate = new efl_ui_tags_items_get_delegate(items_get);
        if (methods.FirstOrDefault(m => m.Name == "GetItems") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tags_items_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_items_get_static_delegate)});
        if (efl_ui_tags_items_set_static_delegate == null)
            efl_ui_tags_items_set_static_delegate = new efl_ui_tags_items_set_delegate(items_set);
        if (methods.FirstOrDefault(m => m.Name == "SetItems") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tags_items_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_items_set_static_delegate)});
        if (efl_text_get_static_delegate == null)
            efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
        if (methods.FirstOrDefault(m => m.Name == "GetText") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate)});
        if (efl_text_set_static_delegate == null)
            efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
        if (methods.FirstOrDefault(m => m.Name == "SetText") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate)});
        if (efl_ui_format_cb_set_static_delegate == null)
            efl_ui_format_cb_set_static_delegate = new efl_ui_format_cb_set_delegate(format_cb_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFormatCb") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_format_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_cb_set_static_delegate)});
        if (efl_ui_format_string_get_static_delegate == null)
            efl_ui_format_string_get_static_delegate = new efl_ui_format_string_get_delegate(format_string_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFormatString") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_format_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_get_static_delegate)});
        if (efl_ui_format_string_set_static_delegate == null)
            efl_ui_format_string_set_static_delegate = new efl_ui_format_string_set_delegate(format_string_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFormatString") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_format_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_set_static_delegate)});
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


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_tags_editable_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_tags_editable_get_api_delegate> efl_ui_tags_editable_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tags_editable_get_api_delegate>(_Module, "efl_ui_tags_editable_get");
     private static bool editable_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_tags_editable_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
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
            return efl_ui_tags_editable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_tags_editable_get_delegate efl_ui_tags_editable_get_static_delegate;


     private delegate void efl_ui_tags_editable_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool editable);


     public delegate void efl_ui_tags_editable_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool editable);
     public static Efl.Eo.FunctionWrapper<efl_ui_tags_editable_set_api_delegate> efl_ui_tags_editable_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tags_editable_set_api_delegate>(_Module, "efl_ui_tags_editable_set");
     private static void editable_set(System.IntPtr obj, System.IntPtr pd,  bool editable)
    {
        Eina.Log.Debug("function efl_ui_tags_editable_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Tags)wrapper).SetEditable( editable);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_tags_editable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  editable);
        }
    }
    private static efl_ui_tags_editable_set_delegate efl_ui_tags_editable_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_tags_expanded_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_tags_expanded_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_tags_expanded_get_api_delegate> efl_ui_tags_expanded_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tags_expanded_get_api_delegate>(_Module, "efl_ui_tags_expanded_get");
     private static bool expanded_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_tags_expanded_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
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
            return efl_ui_tags_expanded_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_tags_expanded_get_delegate efl_ui_tags_expanded_get_static_delegate;


     private delegate void efl_ui_tags_expanded_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool expanded);


     public delegate void efl_ui_tags_expanded_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool expanded);
     public static Efl.Eo.FunctionWrapper<efl_ui_tags_expanded_set_api_delegate> efl_ui_tags_expanded_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tags_expanded_set_api_delegate>(_Module, "efl_ui_tags_expanded_set");
     private static void expanded_set(System.IntPtr obj, System.IntPtr pd,  bool expanded)
    {
        Eina.Log.Debug("function efl_ui_tags_expanded_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Tags)wrapper).SetExpanded( expanded);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_tags_expanded_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  expanded);
        }
    }
    private static efl_ui_tags_expanded_set_delegate efl_ui_tags_expanded_set_static_delegate;


     private delegate System.IntPtr efl_ui_tags_items_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate System.IntPtr efl_ui_tags_items_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_tags_items_get_api_delegate> efl_ui_tags_items_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tags_items_get_api_delegate>(_Module, "efl_ui_tags_items_get");
     private static System.IntPtr items_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_tags_items_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Array<System.String> _ret_var = default(Eina.Array<System.String>);
            try {
                _ret_var = ((Tags)wrapper).GetItems();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var.Handle;
        } else {
            return efl_ui_tags_items_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_tags_items_get_delegate efl_ui_tags_items_get_static_delegate;


     private delegate void efl_ui_tags_items_set_delegate(System.IntPtr obj, System.IntPtr pd,   System.IntPtr items);


     public delegate void efl_ui_tags_items_set_api_delegate(System.IntPtr obj,   System.IntPtr items);
     public static Efl.Eo.FunctionWrapper<efl_ui_tags_items_set_api_delegate> efl_ui_tags_items_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tags_items_set_api_delegate>(_Module, "efl_ui_tags_items_set");
     private static void items_set(System.IntPtr obj, System.IntPtr pd,  System.IntPtr items)
    {
        Eina.Log.Debug("function efl_ui_tags_items_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    var _in_items = new Eina.Array<System.String>(items, false, false);
                            
            try {
                ((Tags)wrapper).SetItems( _in_items);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_tags_items_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  items);
        }
    }
    private static efl_ui_tags_items_set_delegate efl_ui_tags_items_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_text_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_text_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_text_get_api_delegate> efl_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_get_api_delegate>(_Module, "efl_text_get");
     private static System.String text_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_text_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Tags)wrapper).GetText();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_text_get_delegate efl_text_get_static_delegate;


     private delegate void efl_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text);


     public delegate void efl_text_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text);
     public static Efl.Eo.FunctionWrapper<efl_text_set_api_delegate> efl_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_set_api_delegate>(_Module, "efl_text_set");
     private static void text_set(System.IntPtr obj, System.IntPtr pd,  System.String text)
    {
        Eina.Log.Debug("function efl_text_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Tags)wrapper).SetText( text);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text);
        }
    }
    private static efl_text_set_delegate efl_text_set_static_delegate;


     private delegate void efl_ui_format_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);


     public delegate void efl_ui_format_cb_set_api_delegate(System.IntPtr obj,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);
     public static Efl.Eo.FunctionWrapper<efl_ui_format_cb_set_api_delegate> efl_ui_format_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_cb_set_api_delegate>(_Module, "efl_ui_format_cb_set");
     private static void format_cb_set(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb)
    {
        Eina.Log.Debug("function efl_ui_format_cb_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                        Efl.Ui.FormatFuncCbWrapper func_wrapper = new Efl.Ui.FormatFuncCbWrapper(func, func_data, func_free_cb);
            
            try {
                ((Tags)wrapper).SetFormatCb( func_wrapper.ManagedCb);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_format_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
        }
    }
    private static efl_ui_format_cb_set_delegate efl_ui_format_cb_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_ui_format_string_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_ui_format_string_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate> efl_ui_format_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate>(_Module, "efl_ui_format_string_get");
     private static System.String format_string_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_format_string_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Tags)wrapper).GetFormatString();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_format_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_format_string_get_delegate efl_ui_format_string_get_static_delegate;


     private delegate void efl_ui_format_string_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String units);


     public delegate void efl_ui_format_string_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String units);
     public static Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate> efl_ui_format_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate>(_Module, "efl_ui_format_string_set");
     private static void format_string_set(System.IntPtr obj, System.IntPtr pd,  System.String units)
    {
        Eina.Log.Debug("function efl_ui_format_string_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Tags)wrapper).SetFormatString( units);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_format_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  units);
        }
    }
    private static efl_ui_format_string_set_delegate efl_ui_format_string_set_static_delegate;
}
} } 
