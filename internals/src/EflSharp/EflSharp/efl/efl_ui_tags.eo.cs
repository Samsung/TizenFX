#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

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
[Efl.Ui.Tags.NativeMethods]
public class Tags : Efl.Ui.LayoutBase, Efl.IText, Efl.Ui.IFormat
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Tags))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_tags_class_get();
    /// <summary>Initializes a new instance of the <see cref="Tags"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Tags(Efl.Object parent
            , System.String style = null) : base(efl_ui_tags_class_get(), typeof(Tags), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Tags"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Tags(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Tags"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Tags(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Called when item was selected</summary>
    public event EventHandler<Efl.Ui.TagsItemSelectedEvt_Args> ItemSelectedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.TagsItemSelectedEvt_Args args = new Efl.Ui.TagsItemSelectedEvt_Args();
                        args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_TAGS_EVENT_ITEM_SELECTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_TAGS_EVENT_ITEM_SELECTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ItemSelectedEvt.</summary>
    public void OnItemSelectedEvt(Efl.Ui.TagsItemSelectedEvt_Args e)
    {
        var key = "_EFL_UI_TAGS_EVENT_ITEM_SELECTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.StringConversion.ManagedStringToNativeUtf8Alloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Eina.MemoryNative.Free(info);
        }
    }
    /// <summary>Called when item was added</summary>
    public event EventHandler<Efl.Ui.TagsItemAddedEvt_Args> ItemAddedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.TagsItemAddedEvt_Args args = new Efl.Ui.TagsItemAddedEvt_Args();
                        args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_TAGS_EVENT_ITEM_ADDED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_TAGS_EVENT_ITEM_ADDED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ItemAddedEvt.</summary>
    public void OnItemAddedEvt(Efl.Ui.TagsItemAddedEvt_Args e)
    {
        var key = "_EFL_UI_TAGS_EVENT_ITEM_ADDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.StringConversion.ManagedStringToNativeUtf8Alloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Eina.MemoryNative.Free(info);
        }
    }
    /// <summary>Called when item was deleted</summary>
    public event EventHandler<Efl.Ui.TagsItemDeletedEvt_Args> ItemDeletedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.TagsItemDeletedEvt_Args args = new Efl.Ui.TagsItemDeletedEvt_Args();
                        args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_TAGS_EVENT_ITEM_DELETED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_TAGS_EVENT_ITEM_DELETED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ItemDeletedEvt.</summary>
    public void OnItemDeletedEvt(Efl.Ui.TagsItemDeletedEvt_Args e)
    {
        var key = "_EFL_UI_TAGS_EVENT_ITEM_DELETED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.StringConversion.ManagedStringToNativeUtf8Alloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Eina.MemoryNative.Free(info);
        }
    }
    /// <summary>Called when item was clicked</summary>
    public event EventHandler<Efl.Ui.TagsItemClickedEvt_Args> ItemClickedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.TagsItemClickedEvt_Args args = new Efl.Ui.TagsItemClickedEvt_Args();
                        args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_TAGS_EVENT_ITEM_CLICKED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_TAGS_EVENT_ITEM_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ItemClickedEvt.</summary>
    public void OnItemClickedEvt(Efl.Ui.TagsItemClickedEvt_Args e)
    {
        var key = "_EFL_UI_TAGS_EVENT_ITEM_CLICKED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.StringConversion.ManagedStringToNativeUtf8Alloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Eina.MemoryNative.Free(info);
        }
    }
    /// <summary>Called when item got a longpress</summary>
    public event EventHandler<Efl.Ui.TagsItemLongpressedEvt_Args> ItemLongpressedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.TagsItemLongpressedEvt_Args args = new Efl.Ui.TagsItemLongpressedEvt_Args();
                        args.arg = Eina.StringConversion.NativeUtf8ToManagedString(evt.Info);
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_TAGS_EVENT_ITEM_LONGPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_TAGS_EVENT_ITEM_LONGPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ItemLongpressedEvt.</summary>
    public void OnItemLongpressedEvt(Efl.Ui.TagsItemLongpressedEvt_Args e)
    {
        var key = "_EFL_UI_TAGS_EVENT_ITEM_LONGPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.StringConversion.ManagedStringToNativeUtf8Alloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Eina.MemoryNative.Free(info);
        }
    }
    /// <summary>Called when expanded</summary>
    public event EventHandler ExpandedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_TAGS_EVENT_EXPANDED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_TAGS_EVENT_EXPANDED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ExpandedEvt.</summary>
    public void OnExpandedEvt(EventArgs e)
    {
        var key = "_EFL_UI_TAGS_EVENT_EXPANDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when contracted</summary>
    public event EventHandler ContractedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        EventArgs args = EventArgs.Empty;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_TAGS_EVENT_CONTRACTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_TAGS_EVENT_CONTRACTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ContractedEvt.</summary>
    public void OnContractedEvt(EventArgs e)
    {
        var key = "_EFL_UI_TAGS_EVENT_CONTRACTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when expanded state changed</summary>
    public event EventHandler<Efl.Ui.TagsExpandStateChangedEvt_Args> ExpandStateChangedEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.TagsExpandStateChangedEvt_Args args = new Efl.Ui.TagsExpandStateChangedEvt_Args();
                        args.arg = Marshal.ReadInt32(evt.Info);
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_TAGS_EVENT_EXPAND_STATE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_TAGS_EVENT_EXPAND_STATE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ExpandStateChangedEvt.</summary>
    public void OnExpandStateChangedEvt(Efl.Ui.TagsExpandStateChangedEvt_Args e)
    {
        var key = "_EFL_UI_TAGS_EVENT_EXPAND_STATE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Control if the tag list is to be editable by the user or not.</summary>
    /// <returns>If <c>true</c>, the user can add/delete tags to the tag list, if not, the tag list is non-editable.</returns>
    virtual public bool GetEditable() {
         var _ret_var = Efl.Ui.Tags.NativeMethods.efl_ui_tags_editable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control if the tag list is to be editable by the user or not.</summary>
    /// <param name="editable">If <c>true</c>, the user can add/delete tags to the tag list, if not, the tag list is non-editable.</param>
    virtual public void SetEditable(bool editable) {
                                 Efl.Ui.Tags.NativeMethods.efl_ui_tags_editable_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),editable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control whether the tag list is expanded or not.
    /// In the expanded state, all tags will be displayed. Otherwise, only a single line of tags will be displayed with a marker to indicate that there is more content.</summary>
    /// <returns>The expanded state. Set this to <c>true</c> to allow multiple lines of tags. Set to <c>false</c> for a single line.</returns>
    virtual public bool GetExpanded() {
         var _ret_var = Efl.Ui.Tags.NativeMethods.efl_ui_tags_expanded_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control whether the tag list is expanded or not.
    /// In the expanded state, all tags will be displayed. Otherwise, only a single line of tags will be displayed with a marker to indicate that there is more content.</summary>
    /// <param name="expanded">The expanded state. Set this to <c>true</c> to allow multiple lines of tags. Set to <c>false</c> for a single line.</param>
    virtual public void SetExpanded(bool expanded) {
                                 Efl.Ui.Tags.NativeMethods.efl_ui_tags_expanded_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),expanded);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>List of tags in the tag list. Tags can be added and removed by the user using the UI, and by the program by modifying this property.</summary>
    /// <returns>The array of items, or NULL if none.</returns>
    virtual public Eina.Array<System.String> GetItems() {
         var _ret_var = Efl.Ui.Tags.NativeMethods.efl_ui_tags_items_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Array<System.String>(_ret_var, false, false);
 }
    /// <summary>List of tags in the tag list. Tags can be added and removed by the user using the UI, and by the program by modifying this property.</summary>
    /// <param name="items">The array of items, or NULL if none.</param>
    virtual public void SetItems(Eina.Array<System.String> items) {
         var _in_items = items.Handle;
                        Efl.Ui.Tags.NativeMethods.efl_ui_tags_items_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_items);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves the text string currently being displayed by the given text object.
    /// Do not free() the return value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Text string to display on it.</returns>
    virtual public System.String GetText() {
         var _ret_var = Efl.ITextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the text string to be displayed by the given text object.
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="text">Text string to display on it.</param>
    virtual public void SetText(System.String text) {
                                 Efl.ITextConcrete.NativeMethods.efl_text_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),text);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the format function pointer to format the string.</summary>
    /// <param name="func">The format function callback</param>
    virtual public void SetFormatCb(Efl.Ui.FormatFuncCb func) {
                         GCHandle func_handle = GCHandle.Alloc(func);
        Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_cb_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),GCHandle.ToIntPtr(func_handle), Efl.Ui.FormatFuncCbWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the format string for a given units label
    /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
    /// 
    /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
    /// <returns>The format string for <c>obj</c>&apos;s units label.</returns>
    virtual public System.String GetFormatString() {
         var _ret_var = Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_string_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the format string for a given units label
    /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
    /// 
    /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
    /// <param name="units">The format string for <c>obj</c>&apos;s units label.</param>
    virtual public void SetFormatString(System.String units) {
                                 Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_string_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),units);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control if the tag list is to be editable by the user or not.</summary>
    /// <value>If <c>true</c>, the user can add/delete tags to the tag list, if not, the tag list is non-editable.</value>
    public bool Editable {
        get { return GetEditable(); }
        set { SetEditable(value); }
    }
    /// <summary>Control whether the tag list is expanded or not.
    /// In the expanded state, all tags will be displayed. Otherwise, only a single line of tags will be displayed with a marker to indicate that there is more content.</summary>
    /// <value>The expanded state. Set this to <c>true</c> to allow multiple lines of tags. Set to <c>false</c> for a single line.</value>
    public bool Expanded {
        get { return GetExpanded(); }
        set { SetExpanded(value); }
    }
    /// <summary>List of tags in the tag list. Tags can be added and removed by the user using the UI, and by the program by modifying this property.</summary>
    /// <value>The array of items, or NULL if none.</value>
    public Eina.Array<System.String> Items {
        get { return GetItems(); }
        set { SetItems(value); }
    }
    /// <summary>Set the format function pointer to format the string.</summary>
    /// <value>The format function callback</value>
    public Efl.Ui.FormatFuncCb FormatCb {
        set { SetFormatCb(value); }
    }
    /// <summary>Control the format string for a given units label
    /// If <c>NULL</c> is passed to <c>format</c>, it will hide <c>obj</c>&apos;s units area completely. If not, it&apos;ll set the &lt;b&gt;format string&lt;/b&gt; for the units label text. The units label is provided as a floating point value, so the units text can display at most one floating point value. Note that the units label is optional. Use a format string such as &quot;%1.2f meters&quot; for example.
    /// 
    /// Note: The default format string is an integer percentage, as in $&quot;%.0f %%&quot;.</summary>
    /// <value>The format string for <c>obj</c>&apos;s units label.</value>
    public System.String FormatString {
        get { return GetFormatString(); }
        set { SetFormatString(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Tags.efl_ui_tags_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_tags_editable_get_static_delegate == null)
            {
                efl_ui_tags_editable_get_static_delegate = new efl_ui_tags_editable_get_delegate(editable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEditable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tags_editable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_editable_get_static_delegate) });
            }

            if (efl_ui_tags_editable_set_static_delegate == null)
            {
                efl_ui_tags_editable_set_static_delegate = new efl_ui_tags_editable_set_delegate(editable_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEditable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tags_editable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_editable_set_static_delegate) });
            }

            if (efl_ui_tags_expanded_get_static_delegate == null)
            {
                efl_ui_tags_expanded_get_static_delegate = new efl_ui_tags_expanded_get_delegate(expanded_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetExpanded") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tags_expanded_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_expanded_get_static_delegate) });
            }

            if (efl_ui_tags_expanded_set_static_delegate == null)
            {
                efl_ui_tags_expanded_set_static_delegate = new efl_ui_tags_expanded_set_delegate(expanded_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetExpanded") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tags_expanded_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_expanded_set_static_delegate) });
            }

            if (efl_ui_tags_items_get_static_delegate == null)
            {
                efl_ui_tags_items_get_static_delegate = new efl_ui_tags_items_get_delegate(items_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetItems") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tags_items_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_items_get_static_delegate) });
            }

            if (efl_ui_tags_items_set_static_delegate == null)
            {
                efl_ui_tags_items_set_static_delegate = new efl_ui_tags_items_set_delegate(items_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetItems") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tags_items_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tags_items_set_static_delegate) });
            }

            if (efl_text_get_static_delegate == null)
            {
                efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate) });
            }

            if (efl_text_set_static_delegate == null)
            {
                efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate) });
            }

            if (efl_ui_format_cb_set_static_delegate == null)
            {
                efl_ui_format_cb_set_static_delegate = new efl_ui_format_cb_set_delegate(format_cb_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFormatCb") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_cb_set_static_delegate) });
            }

            if (efl_ui_format_string_get_static_delegate == null)
            {
                efl_ui_format_string_get_static_delegate = new efl_ui_format_string_get_delegate(format_string_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFormatString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_get_static_delegate) });
            }

            if (efl_ui_format_string_set_static_delegate == null)
            {
                efl_ui_format_string_set_static_delegate = new efl_ui_format_string_set_delegate(format_string_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFormatString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_string_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Tags.efl_ui_tags_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_tags_editable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_tags_editable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_tags_editable_get_api_delegate> efl_ui_tags_editable_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tags_editable_get_api_delegate>(Module, "efl_ui_tags_editable_get");

        private static bool editable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_tags_editable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Tags)ws.Target).GetEditable();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_ui_tags_editable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_tags_editable_get_delegate efl_ui_tags_editable_get_static_delegate;

        
        private delegate void efl_ui_tags_editable_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool editable);

        
        public delegate void efl_ui_tags_editable_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool editable);

        public static Efl.Eo.FunctionWrapper<efl_ui_tags_editable_set_api_delegate> efl_ui_tags_editable_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tags_editable_set_api_delegate>(Module, "efl_ui_tags_editable_set");

        private static void editable_set(System.IntPtr obj, System.IntPtr pd, bool editable)
        {
            Eina.Log.Debug("function efl_ui_tags_editable_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Tags)ws.Target).SetEditable(editable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_tags_editable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), editable);
            }
        }

        private static efl_ui_tags_editable_set_delegate efl_ui_tags_editable_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_tags_expanded_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_tags_expanded_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_tags_expanded_get_api_delegate> efl_ui_tags_expanded_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tags_expanded_get_api_delegate>(Module, "efl_ui_tags_expanded_get");

        private static bool expanded_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_tags_expanded_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Tags)ws.Target).GetExpanded();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_ui_tags_expanded_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_tags_expanded_get_delegate efl_ui_tags_expanded_get_static_delegate;

        
        private delegate void efl_ui_tags_expanded_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool expanded);

        
        public delegate void efl_ui_tags_expanded_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool expanded);

        public static Efl.Eo.FunctionWrapper<efl_ui_tags_expanded_set_api_delegate> efl_ui_tags_expanded_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tags_expanded_set_api_delegate>(Module, "efl_ui_tags_expanded_set");

        private static void expanded_set(System.IntPtr obj, System.IntPtr pd, bool expanded)
        {
            Eina.Log.Debug("function efl_ui_tags_expanded_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Tags)ws.Target).SetExpanded(expanded);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_tags_expanded_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), expanded);
            }
        }

        private static efl_ui_tags_expanded_set_delegate efl_ui_tags_expanded_set_static_delegate;

        
        private delegate System.IntPtr efl_ui_tags_items_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_tags_items_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_tags_items_get_api_delegate> efl_ui_tags_items_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tags_items_get_api_delegate>(Module, "efl_ui_tags_items_get");

        private static System.IntPtr items_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_tags_items_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Array<System.String> _ret_var = default(Eina.Array<System.String>);
                try
                {
                    _ret_var = ((Tags)ws.Target).GetItems();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var.Handle;

            }
            else
            {
                return efl_ui_tags_items_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_tags_items_get_delegate efl_ui_tags_items_get_static_delegate;

        
        private delegate void efl_ui_tags_items_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr items);

        
        public delegate void efl_ui_tags_items_set_api_delegate(System.IntPtr obj,  System.IntPtr items);

        public static Efl.Eo.FunctionWrapper<efl_ui_tags_items_set_api_delegate> efl_ui_tags_items_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tags_items_set_api_delegate>(Module, "efl_ui_tags_items_set");

        private static void items_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr items)
        {
            Eina.Log.Debug("function efl_ui_tags_items_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_items = new Eina.Array<System.String>(items, false, false);
                            
                try
                {
                    ((Tags)ws.Target).SetItems(_in_items);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_tags_items_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), items);
            }
        }

        private static efl_ui_tags_items_set_delegate efl_ui_tags_items_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_get_api_delegate> efl_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_get_api_delegate>(Module, "efl_text_get");

        private static System.String text_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Tags)ws.Target).GetText();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_get_delegate efl_text_get_static_delegate;

        
        private delegate void efl_text_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        
        public delegate void efl_text_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String text);

        public static Efl.Eo.FunctionWrapper<efl_text_set_api_delegate> efl_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_set_api_delegate>(Module, "efl_text_set");

        private static void text_set(System.IntPtr obj, System.IntPtr pd, System.String text)
        {
            Eina.Log.Debug("function efl_text_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Tags)ws.Target).SetText(text);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), text);
            }
        }

        private static efl_text_set_delegate efl_text_set_static_delegate;

        
        private delegate void efl_ui_format_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);

        
        public delegate void efl_ui_format_cb_set_api_delegate(System.IntPtr obj,  IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_cb_set_api_delegate> efl_ui_format_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_cb_set_api_delegate>(Module, "efl_ui_format_cb_set");

        private static void format_cb_set(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, Efl.Ui.FormatFuncCbInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_ui_format_cb_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                            Efl.Ui.FormatFuncCbWrapper func_wrapper = new Efl.Ui.FormatFuncCbWrapper(func, func_data, func_free_cb);
            
                try
                {
                    ((Tags)ws.Target).SetFormatCb(func_wrapper.ManagedCb);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_format_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
            }
        }

        private static efl_ui_format_cb_set_delegate efl_ui_format_cb_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_format_string_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_format_string_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate> efl_ui_format_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate>(Module, "efl_ui_format_string_get");

        private static System.String format_string_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_format_string_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Tags)ws.Target).GetFormatString();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_ui_format_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_format_string_get_delegate efl_ui_format_string_get_static_delegate;

        
        private delegate void efl_ui_format_string_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String units);

        
        public delegate void efl_ui_format_string_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String units);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate> efl_ui_format_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate>(Module, "efl_ui_format_string_set");

        private static void format_string_set(System.IntPtr obj, System.IntPtr pd, System.String units)
        {
            Eina.Log.Debug("function efl_ui_format_string_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Tags)ws.Target).SetFormatString(units);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_format_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), units);
            }
        }

        private static efl_ui_format_string_set_delegate efl_ui_format_string_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

