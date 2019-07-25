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
[Efl.Eo.BindingEntity]
public class TagsItemSelectedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ItemAddedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class TagsItemAddedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ItemDeletedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class TagsItemDeletedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ItemClickedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class TagsItemClickedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ItemLongpressedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class TagsItemLongpressedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public System.String arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Tags.ExpandStateChangedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class TagsExpandStateChangedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public int arg { get; set; }
}
/// <summary>A widget displaying a list of tags. The user can remove tags by clicking on each tag &quot;close&quot; button and add new tags by typing text in the text entry at the end of the list.</summary>
[Efl.Ui.Tags.NativeMethods]
[Efl.Eo.BindingEntity]
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
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Tags(Efl.Object parent
            , System.String style = null) : base(efl_ui_tags_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Tags(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Tags"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Tags(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Tags"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Tags(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when item was selected</summary>
    public event EventHandler<Efl.Ui.TagsItemSelectedEvt_Args> ItemSelectedEvt
    {
        add
        {
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
            lock (eflBindingEventLock)
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
         var _ret_var = Efl.Ui.Tags.NativeMethods.efl_ui_tags_editable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control if the tag list is to be editable by the user or not.</summary>
    /// <param name="editable">If <c>true</c>, the user can add/delete tags to the tag list, if not, the tag list is non-editable.</param>
    virtual public void SetEditable(bool editable) {
                                 Efl.Ui.Tags.NativeMethods.efl_ui_tags_editable_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),editable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control whether the tag list is expanded or not.
    /// In the expanded state, all tags will be displayed. Otherwise, only a single line of tags will be displayed with a marker to indicate that there is more content.</summary>
    /// <returns>The expanded state. Set this to <c>true</c> to allow multiple lines of tags. Set to <c>false</c> for a single line.</returns>
    virtual public bool GetExpanded() {
         var _ret_var = Efl.Ui.Tags.NativeMethods.efl_ui_tags_expanded_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control whether the tag list is expanded or not.
    /// In the expanded state, all tags will be displayed. Otherwise, only a single line of tags will be displayed with a marker to indicate that there is more content.</summary>
    /// <param name="expanded">The expanded state. Set this to <c>true</c> to allow multiple lines of tags. Set to <c>false</c> for a single line.</param>
    virtual public void SetExpanded(bool expanded) {
                                 Efl.Ui.Tags.NativeMethods.efl_ui_tags_expanded_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),expanded);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>List of tags in the tag list. Tags can be added and removed by the user using the UI, and by the program by modifying this property.</summary>
    /// <returns>The array of items, or NULL if none.</returns>
    virtual public Eina.Array<System.String> GetItems() {
         var _ret_var = Efl.Ui.Tags.NativeMethods.efl_ui_tags_items_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Array<System.String>(_ret_var, false, false);
 }
    /// <summary>List of tags in the tag list. Tags can be added and removed by the user using the UI, and by the program by modifying this property.</summary>
    /// <param name="items">The array of items, or NULL if none.</param>
    virtual public void SetItems(Eina.Array<System.String> items) {
         var _in_items = items.Handle;
                        Efl.Ui.Tags.NativeMethods.efl_ui_tags_items_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_items);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves the text string currently being displayed by the given text object.
    /// Do not free() the return value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Text string to display on it.</returns>
    virtual public System.String GetText() {
         var _ret_var = Efl.ITextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the text string to be displayed by the given text object.
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="text">Text string to display on it.</param>
    virtual public void SetText(System.String text) {
                                 Efl.ITextConcrete.NativeMethods.efl_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),text);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
    /// <returns>User-provided formatting function.</returns>
    virtual public Efl.Ui.FormatFunc GetFormatFunc() {
         var _ret_var = Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_func_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
    /// <param name="func">User-provided formatting function.</param>
    virtual public void SetFormatFunc(Efl.Ui.FormatFunc func) {
                         GCHandle func_handle = GCHandle.Alloc(func);
        Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_func_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),GCHandle.ToIntPtr(func_handle), Efl.Ui.FormatFuncWrapper.Cb, Efl.Eo.Globals.free_gchandle);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
    /// <returns>Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</returns>
    virtual public Eina.Accessor<Efl.Ui.FormatValue> GetFormatValues() {
         var _ret_var = Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_values_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Accessor<Efl.Ui.FormatValue>(_ret_var, false);
 }
    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
    /// <param name="values">Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</param>
    virtual public void SetFormatValues(Eina.Accessor<Efl.Ui.FormatValue> values) {
         var _in_values = values.Handle;
                        Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_values_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_values);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A user-provided, string used to format the numerical value.
    /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
    /// 
    /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
    /// 
    /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="Efl.Ui.FormatStringType.Simple"/> for simple numerical values and <see cref="Efl.Ui.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
    /// 
    /// Pass <c>NULL</c> to disable this mechanism.</summary>
    /// <param name="kw_string">Formatting string containing regular characters and format specifiers.</param>
    /// <param name="type">Type of formatting string, which controls how the different format specifiers are to be traslated.</param>
    virtual public void GetFormatString(out System.String kw_string, out Efl.Ui.FormatStringType type) {
                                                         Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_string_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out kw_string, out type);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>A user-provided, string used to format the numerical value.
    /// For example, &quot;%1.2f meters&quot;, &quot;%.0%%&quot; or &quot;%d items&quot;.
    /// 
    /// This is the simplest formatting mechanism, working pretty much like <c>printf</c>.
    /// 
    /// Different format specifiers (the character after the %) are available, depending on the <c>type</c> used. Use <see cref="Efl.Ui.FormatStringType.Simple"/> for simple numerical values and <see cref="Efl.Ui.FormatStringType.Time"/> for time and date values. For instance, %d means &quot;integer&quot; when the first type is used, but it means &quot;day of the month as a decimal number&quot; in the second.
    /// 
    /// Pass <c>NULL</c> to disable this mechanism.</summary>
    /// <param name="kw_string">Formatting string containing regular characters and format specifiers.</param>
    /// <param name="type">Type of formatting string, which controls how the different format specifiers are to be traslated.</param>
    virtual public void SetFormatString(System.String kw_string, Efl.Ui.FormatStringType type) {
                                                         Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_string_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_string, type);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Internal method to be used by widgets including this mixin to perform the conversion from the internal numerical value into the text representation (Users of these widgets do not need to call this method).
    /// <see cref="Efl.Ui.IFormat.GetFormattedValue"/> uses any user-provided mechanism to perform the conversion, according to their priorities, and implements a simple fallback if all mechanisms fail.</summary>
    /// <param name="str">Output formatted string. Its contents will be overwritten by this method.</param>
    /// <param name="value">The <see cref="Eina.Value"/> to convert to text.</param>
    virtual public void GetFormattedValue(Eina.Strbuf str, Eina.Value value) {
                                                         Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_formatted_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),str, value);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Internal method to be used by widgets including this mixin. It can only be used when a <see cref="Efl.Ui.IFormat.GetFormatString"/> has been supplied, and it returns the number of decimal places that the format string will produce for floating point values.
    /// For example, &quot;%.2f&quot; returns 2, and &quot;%d&quot; returns 0;</summary>
    /// <returns>Number of decimal places, or 0 for non-floating point types.</returns>
    virtual public int GetDecimalPlaces() {
         var _ret_var = Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_decimal_places_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Internal method to be implemented by widgets including this mixin.
    /// The mixin will call this method to signal the widget that the formatting has changed and therefore the current value should be converted and rendered again. Widgets must typically call <see cref="Efl.Ui.IFormat.GetFormattedValue"/> and display the returned string. This is something they are already doing (whenever the value changes, for example) so there should be no extra code written to implement this method.</summary>
    virtual public void ApplyFormattedValue() {
         Efl.Ui.IFormatConcrete.NativeMethods.efl_ui_format_apply_formatted_value_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    /// <summary>User-provided function which takes care of converting an <see cref="Eina.Value"/> into a text string. The user is then completely in control of how the string is generated, but it is the most cumbersome method to use. If the conversion fails the other mechanisms will be tried, according to their priorities.</summary>
    /// <value>User-provided formatting function.</value>
    public Efl.Ui.FormatFunc FormatFunc {
        get { return GetFormatFunc(); }
        set { SetFormatFunc(value); }
    }
    /// <summary>User-provided list of values which are to be rendered using specific text strings. This is more convenient to use than <see cref="Efl.Ui.IFormat.FormatFunc"/> and is perfectly suited for cases where the strings make more sense than the numerical values. For example, weekday names (&quot;Monday&quot;, &quot;Tuesday&quot;, ...) are friendlier than numbers 1 to 7. If a value is not found in the list, the other mechanisms will be tried according to their priorities. List members do not need to be in any particular order. They are sorted internally for performance reasons.</summary>
    /// <value>Accessor over a list of value-text pairs. The method will dispose of the accessor, but not of its contents. For convenience, Eina offers a range of helper methods to obtain accessors from Eina.Array, Eina.List or even plain C arrays.</value>
    public Eina.Accessor<Efl.Ui.FormatValue> FormatValues {
        get { return GetFormatValues(); }
        set { SetFormatValues(value); }
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

            if (efl_ui_format_func_get_static_delegate == null)
            {
                efl_ui_format_func_get_static_delegate = new efl_ui_format_func_get_delegate(format_func_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFormatFunc") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_func_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_func_get_static_delegate) });
            }

            if (efl_ui_format_func_set_static_delegate == null)
            {
                efl_ui_format_func_set_static_delegate = new efl_ui_format_func_set_delegate(format_func_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFormatFunc") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_func_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_func_set_static_delegate) });
            }

            if (efl_ui_format_values_get_static_delegate == null)
            {
                efl_ui_format_values_get_static_delegate = new efl_ui_format_values_get_delegate(format_values_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFormatValues") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_values_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_values_get_static_delegate) });
            }

            if (efl_ui_format_values_set_static_delegate == null)
            {
                efl_ui_format_values_set_static_delegate = new efl_ui_format_values_set_delegate(format_values_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFormatValues") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_values_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_values_set_static_delegate) });
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

            if (efl_ui_format_formatted_value_get_static_delegate == null)
            {
                efl_ui_format_formatted_value_get_static_delegate = new efl_ui_format_formatted_value_get_delegate(formatted_value_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFormattedValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_formatted_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_formatted_value_get_static_delegate) });
            }

            if (efl_ui_format_decimal_places_get_static_delegate == null)
            {
                efl_ui_format_decimal_places_get_static_delegate = new efl_ui_format_decimal_places_get_delegate(decimal_places_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDecimalPlaces") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_decimal_places_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_decimal_places_get_static_delegate) });
            }

            if (efl_ui_format_apply_formatted_value_static_delegate == null)
            {
                efl_ui_format_apply_formatted_value_static_delegate = new efl_ui_format_apply_formatted_value_delegate(apply_formatted_value);
            }

            if (methods.FirstOrDefault(m => m.Name == "ApplyFormattedValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_format_apply_formatted_value"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_format_apply_formatted_value_static_delegate) });
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

        
        private delegate Efl.Ui.FormatFunc efl_ui_format_func_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.FormatFunc efl_ui_format_func_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_func_get_api_delegate> efl_ui_format_func_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_func_get_api_delegate>(Module, "efl_ui_format_func_get");

        private static Efl.Ui.FormatFunc format_func_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_format_func_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.FormatFunc _ret_var = default(Efl.Ui.FormatFunc);
                try
                {
                    _ret_var = ((Tags)ws.Target).GetFormatFunc();
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
                return efl_ui_format_func_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_format_func_get_delegate efl_ui_format_func_get_static_delegate;

        
        private delegate void efl_ui_format_func_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr func_data, Efl.Ui.FormatFuncInternal func, EinaFreeCb func_free_cb);

        
        public delegate void efl_ui_format_func_set_api_delegate(System.IntPtr obj,  IntPtr func_data, Efl.Ui.FormatFuncInternal func, EinaFreeCb func_free_cb);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_func_set_api_delegate> efl_ui_format_func_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_func_set_api_delegate>(Module, "efl_ui_format_func_set");

        private static void format_func_set(System.IntPtr obj, System.IntPtr pd, IntPtr func_data, Efl.Ui.FormatFuncInternal func, EinaFreeCb func_free_cb)
        {
            Eina.Log.Debug("function efl_ui_format_func_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                            Efl.Ui.FormatFuncWrapper func_wrapper = new Efl.Ui.FormatFuncWrapper(func, func_data, func_free_cb);
            
                try
                {
                    ((Tags)ws.Target).SetFormatFunc(func_wrapper.ManagedCb);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_format_func_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), func_data, func, func_free_cb);
            }
        }

        private static efl_ui_format_func_set_delegate efl_ui_format_func_set_static_delegate;

        
        private delegate System.IntPtr efl_ui_format_values_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_format_values_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_values_get_api_delegate> efl_ui_format_values_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_values_get_api_delegate>(Module, "efl_ui_format_values_get");

        private static System.IntPtr format_values_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_format_values_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Accessor<Efl.Ui.FormatValue> _ret_var = default(Eina.Accessor<Efl.Ui.FormatValue>);
                try
                {
                    _ret_var = ((Tags)ws.Target).GetFormatValues();
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
                return efl_ui_format_values_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_format_values_get_delegate efl_ui_format_values_get_static_delegate;

        
        private delegate void efl_ui_format_values_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr values);

        
        public delegate void efl_ui_format_values_set_api_delegate(System.IntPtr obj,  System.IntPtr values);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_values_set_api_delegate> efl_ui_format_values_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_values_set_api_delegate>(Module, "efl_ui_format_values_set");

        private static void format_values_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr values)
        {
            Eina.Log.Debug("function efl_ui_format_values_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_values = new Eina.Accessor<Efl.Ui.FormatValue>(values, false);
                            
                try
                {
                    ((Tags)ws.Target).SetFormatValues(_in_values);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_format_values_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), values);
            }
        }

        private static efl_ui_format_values_set_delegate efl_ui_format_values_set_static_delegate;

        
        private delegate void efl_ui_format_string_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String kw_string,  out Efl.Ui.FormatStringType type);

        
        public delegate void efl_ui_format_string_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String kw_string,  out Efl.Ui.FormatStringType type);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate> efl_ui_format_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_get_api_delegate>(Module, "efl_ui_format_string_get");

        private static void format_string_get(System.IntPtr obj, System.IntPtr pd, out System.String kw_string, out Efl.Ui.FormatStringType type)
        {
            Eina.Log.Debug("function efl_ui_format_string_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        System.String _out_kw_string = default(System.String);
        type = default(Efl.Ui.FormatStringType);                            
                try
                {
                    ((Tags)ws.Target).GetFormatString(out _out_kw_string, out type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        kw_string = _out_kw_string;
                                
            }
            else
            {
                efl_ui_format_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out kw_string, out type);
            }
        }

        private static efl_ui_format_string_get_delegate efl_ui_format_string_get_static_delegate;

        
        private delegate void efl_ui_format_string_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string,  Efl.Ui.FormatStringType type);

        
        public delegate void efl_ui_format_string_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string,  Efl.Ui.FormatStringType type);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate> efl_ui_format_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_string_set_api_delegate>(Module, "efl_ui_format_string_set");

        private static void format_string_set(System.IntPtr obj, System.IntPtr pd, System.String kw_string, Efl.Ui.FormatStringType type)
        {
            Eina.Log.Debug("function efl_ui_format_string_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Tags)ws.Target).SetFormatString(kw_string, type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_format_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_string, type);
            }
        }

        private static efl_ui_format_string_set_delegate efl_ui_format_string_set_static_delegate;

        
        private delegate void efl_ui_format_formatted_value_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StrbufKeepOwnershipMarshaler))] Eina.Strbuf str,  Eina.ValueNative value);

        
        public delegate void efl_ui_format_formatted_value_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StrbufKeepOwnershipMarshaler))] Eina.Strbuf str,  Eina.ValueNative value);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_formatted_value_get_api_delegate> efl_ui_format_formatted_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_formatted_value_get_api_delegate>(Module, "efl_ui_format_formatted_value_get");

        private static void formatted_value_get(System.IntPtr obj, System.IntPtr pd, Eina.Strbuf str, Eina.ValueNative value)
        {
            Eina.Log.Debug("function efl_ui_format_formatted_value_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Tags)ws.Target).GetFormattedValue(str, value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_format_formatted_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), str, value);
            }
        }

        private static efl_ui_format_formatted_value_get_delegate efl_ui_format_formatted_value_get_static_delegate;

        
        private delegate int efl_ui_format_decimal_places_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_format_decimal_places_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_decimal_places_get_api_delegate> efl_ui_format_decimal_places_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_decimal_places_get_api_delegate>(Module, "efl_ui_format_decimal_places_get");

        private static int decimal_places_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_format_decimal_places_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Tags)ws.Target).GetDecimalPlaces();
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
                return efl_ui_format_decimal_places_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_format_decimal_places_get_delegate efl_ui_format_decimal_places_get_static_delegate;

        
        private delegate void efl_ui_format_apply_formatted_value_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_format_apply_formatted_value_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_format_apply_formatted_value_api_delegate> efl_ui_format_apply_formatted_value_ptr = new Efl.Eo.FunctionWrapper<efl_ui_format_apply_formatted_value_api_delegate>(Module, "efl_ui_format_apply_formatted_value");

        private static void apply_formatted_value(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_format_apply_formatted_value was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Tags)ws.Target).ApplyFormattedValue();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_format_apply_formatted_value_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_format_apply_formatted_value_delegate efl_ui_format_apply_formatted_value_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

