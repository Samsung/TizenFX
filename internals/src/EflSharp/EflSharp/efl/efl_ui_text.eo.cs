#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.ChangedUserEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextChangedUserEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.Ui.TextChangeInfo arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.ValidateEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextValidateEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Elm.ValidateContent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorDownEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextAnchorDownEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Elm.EntryAnchorInfo arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorHoverOpenedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextAnchorHoverOpenedEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Elm.EntryAnchorHoverInfo arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorInEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextAnchorInEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Elm.EntryAnchorInfo arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorOutEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextAnchorOutEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Elm.EntryAnchorInfo arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorUpEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextAnchorUpEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Elm.EntryAnchorInfo arg { get; set; }
}
/// <summary>Efl UI text class</summary>
[Efl.Ui.Text.NativeMethods]
[Efl.Eo.BindingEntity]
public class Text : Efl.Ui.LayoutBase, Efl.IFile, Efl.IText, Efl.ITextFont, Efl.ITextFormat, Efl.ITextInteractive, Efl.ITextMarkup, Efl.ITextStyle, Efl.Access.IText, Efl.Access.Editable.IText, Efl.Ui.IClickable, Efl.Ui.ISelectable
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Text))
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
        efl_ui_text_class_get();
    /// <summary>Initializes a new instance of the <see cref="Text"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Text(Efl.Object parent
            , System.String style = null) : base(efl_ui_text_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Text(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Text"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Text(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Text"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Text(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when entry changes</summary>
    public event EventHandler ChangedEvt
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

                string key = "_EFL_UI_TEXT_EVENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChangedEvt.</summary>
    public void OnChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_TEXT_EVENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>The text object has changed due to user interaction</summary>
    public event EventHandler<Efl.Ui.TextChangedUserEvt_Args> ChangedUserEvt
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
                        Efl.Ui.TextChangedUserEvt_Args args = new Efl.Ui.TextChangedUserEvt_Args();
                        args.arg =  evt.Info;
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

                string key = "_EFL_UI_TEXT_EVENT_CHANGED_USER";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_CHANGED_USER";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChangedUserEvt.</summary>
    public void OnChangedUserEvt(Efl.Ui.TextChangedUserEvt_Args e)
    {
        var key = "_EFL_UI_TEXT_EVENT_CHANGED_USER";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when validating</summary>
    public event EventHandler<Efl.Ui.TextValidateEvt_Args> ValidateEvt
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
                        Efl.Ui.TextValidateEvt_Args args = new Efl.Ui.TextValidateEvt_Args();
                        args.arg =  (Elm.ValidateContent)evt.Info;
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

                string key = "_EFL_UI_TEXT_EVENT_VALIDATE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_VALIDATE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ValidateEvt.</summary>
    public void OnValidateEvt(Efl.Ui.TextValidateEvt_Args e)
    {
        var key = "_EFL_UI_TEXT_EVENT_VALIDATE";
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
    /// <summary>Called when context menu was opened</summary>
    public event EventHandler ContextOpenEvt
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

                string key = "_EFL_UI_TEXT_EVENT_CONTEXT_OPEN";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_CONTEXT_OPEN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ContextOpenEvt.</summary>
    public void OnContextOpenEvt(EventArgs e)
    {
        var key = "_EFL_UI_TEXT_EVENT_CONTEXT_OPEN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when entry preedit changed</summary>
    public event EventHandler PreeditChangedEvt
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

                string key = "_EFL_UI_TEXT_EVENT_PREEDIT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_PREEDIT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event PreeditChangedEvt.</summary>
    public void OnPreeditChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_TEXT_EVENT_PREEDIT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when entry pressed</summary>
    public event EventHandler PressEvt
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

                string key = "_EFL_UI_TEXT_EVENT_PRESS";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_PRESS";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event PressEvt.</summary>
    public void OnPressEvt(EventArgs e)
    {
        var key = "_EFL_UI_TEXT_EVENT_PRESS";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when redo is requested</summary>
    public event EventHandler RedoRequestEvt
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

                string key = "_EFL_UI_TEXT_EVENT_REDO_REQUEST";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_REDO_REQUEST";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event RedoRequestEvt.</summary>
    public void OnRedoRequestEvt(EventArgs e)
    {
        var key = "_EFL_UI_TEXT_EVENT_REDO_REQUEST";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when undo is requested</summary>
    public event EventHandler UndoRequestEvt
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

                string key = "_EFL_UI_TEXT_EVENT_UNDO_REQUEST";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_UNDO_REQUEST";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event UndoRequestEvt.</summary>
    public void OnUndoRequestEvt(EventArgs e)
    {
        var key = "_EFL_UI_TEXT_EVENT_UNDO_REQUEST";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when entry is aborted</summary>
    public event EventHandler AbortedEvt
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

                string key = "_EFL_UI_TEXT_EVENT_ABORTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_ABORTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AbortedEvt.</summary>
    public void OnAbortedEvt(EventArgs e)
    {
        var key = "_EFL_UI_TEXT_EVENT_ABORTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called on anchor down</summary>
    public event EventHandler<Efl.Ui.TextAnchorDownEvt_Args> AnchorDownEvt
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
                        Efl.Ui.TextAnchorDownEvt_Args args = new Efl.Ui.TextAnchorDownEvt_Args();
                        args.arg =  (Elm.EntryAnchorInfo)evt.Info;
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

                string key = "_EFL_UI_TEXT_EVENT_ANCHOR_DOWN";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_ANCHOR_DOWN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AnchorDownEvt.</summary>
    public void OnAnchorDownEvt(Efl.Ui.TextAnchorDownEvt_Args e)
    {
        var key = "_EFL_UI_TEXT_EVENT_ANCHOR_DOWN";
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
    /// <summary>Called when hover opened</summary>
    public event EventHandler<Efl.Ui.TextAnchorHoverOpenedEvt_Args> AnchorHoverOpenedEvt
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
                        Efl.Ui.TextAnchorHoverOpenedEvt_Args args = new Efl.Ui.TextAnchorHoverOpenedEvt_Args();
                        args.arg =  (Elm.EntryAnchorHoverInfo)evt.Info;
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

                string key = "_EFL_UI_TEXT_EVENT_ANCHOR_HOVER_OPENED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_ANCHOR_HOVER_OPENED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AnchorHoverOpenedEvt.</summary>
    public void OnAnchorHoverOpenedEvt(Efl.Ui.TextAnchorHoverOpenedEvt_Args e)
    {
        var key = "_EFL_UI_TEXT_EVENT_ANCHOR_HOVER_OPENED";
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
    /// <summary>Called on anchor in</summary>
    public event EventHandler<Efl.Ui.TextAnchorInEvt_Args> AnchorInEvt
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
                        Efl.Ui.TextAnchorInEvt_Args args = new Efl.Ui.TextAnchorInEvt_Args();
                        args.arg =  (Elm.EntryAnchorInfo)evt.Info;
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

                string key = "_EFL_UI_TEXT_EVENT_ANCHOR_IN";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_ANCHOR_IN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AnchorInEvt.</summary>
    public void OnAnchorInEvt(Efl.Ui.TextAnchorInEvt_Args e)
    {
        var key = "_EFL_UI_TEXT_EVENT_ANCHOR_IN";
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
    /// <summary>Called on anchor out</summary>
    public event EventHandler<Efl.Ui.TextAnchorOutEvt_Args> AnchorOutEvt
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
                        Efl.Ui.TextAnchorOutEvt_Args args = new Efl.Ui.TextAnchorOutEvt_Args();
                        args.arg =  (Elm.EntryAnchorInfo)evt.Info;
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

                string key = "_EFL_UI_TEXT_EVENT_ANCHOR_OUT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_ANCHOR_OUT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AnchorOutEvt.</summary>
    public void OnAnchorOutEvt(Efl.Ui.TextAnchorOutEvt_Args e)
    {
        var key = "_EFL_UI_TEXT_EVENT_ANCHOR_OUT";
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
    /// <summary>called on anchor up</summary>
    public event EventHandler<Efl.Ui.TextAnchorUpEvt_Args> AnchorUpEvt
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
                        Efl.Ui.TextAnchorUpEvt_Args args = new Efl.Ui.TextAnchorUpEvt_Args();
                        args.arg =  (Elm.EntryAnchorInfo)evt.Info;
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

                string key = "_EFL_UI_TEXT_EVENT_ANCHOR_UP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_ANCHOR_UP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AnchorUpEvt.</summary>
    public void OnAnchorUpEvt(Efl.Ui.TextAnchorUpEvt_Args e)
    {
        var key = "_EFL_UI_TEXT_EVENT_ANCHOR_UP";
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
    /// <summary>Called on manual cursor change</summary>
    public event EventHandler CursorChangedManualEvt
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

                string key = "_EFL_UI_TEXT_EVENT_CURSOR_CHANGED_MANUAL";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_TEXT_EVENT_CURSOR_CHANGED_MANUAL";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event CursorChangedManualEvt.</summary>
    public void OnCursorChangedManualEvt(EventArgs e)
    {
        var key = "_EFL_UI_TEXT_EVENT_CURSOR_CHANGED_MANUAL";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>The selection on the object has changed. Query using <see cref="Efl.ITextInteractive.GetSelectionCursors"/></summary>
    public event EventHandler TextSelectionChangedEvt
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

                string key = "_EFL_TEXT_INTERACTIVE_EVENT_TEXT_SELECTION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_TEXT_INTERACTIVE_EVENT_TEXT_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event TextSelectionChangedEvt.</summary>
    public void OnTextSelectionChangedEvt(EventArgs e)
    {
        var key = "_EFL_TEXT_INTERACTIVE_EVENT_TEXT_SELECTION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Caret moved</summary>
    public event EventHandler AccessTextCaretMovedEvt
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

                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_CARET_MOVED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_CARET_MOVED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AccessTextCaretMovedEvt.</summary>
    public void OnAccessTextCaretMovedEvt(EventArgs e)
    {
        var key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_CARET_MOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Text was inserted</summary>
    public event EventHandler<Efl.Access.ITextAccessTextInsertedEvt_Args> AccessTextInsertedEvt
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
                        Efl.Access.ITextAccessTextInsertedEvt_Args args = new Efl.Access.ITextAccessTextInsertedEvt_Args();
                        args.arg =  evt.Info;
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

                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_INSERTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_INSERTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AccessTextInsertedEvt.</summary>
    public void OnAccessTextInsertedEvt(Efl.Access.ITextAccessTextInsertedEvt_Args e)
    {
        var key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_INSERTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Text was removed</summary>
    public event EventHandler<Efl.Access.ITextAccessTextRemovedEvt_Args> AccessTextRemovedEvt
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
                        Efl.Access.ITextAccessTextRemovedEvt_Args args = new Efl.Access.ITextAccessTextRemovedEvt_Args();
                        args.arg =  evt.Info;
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

                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_REMOVED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AccessTextRemovedEvt.</summary>
    public void OnAccessTextRemovedEvt(Efl.Access.ITextAccessTextRemovedEvt_Args e)
    {
        var key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Text selection has changed</summary>
    public event EventHandler AccessTextSelectionChangedEvt
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

                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_SELECTION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AccessTextSelectionChangedEvt.</summary>
    public void OnAccessTextSelectionChangedEvt(EventArgs e)
    {
        var key = "_EFL_ACCESS_TEXT_EVENT_ACCESS_TEXT_SELECTION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when object is in sequence pressed and unpressed, by the primary button</summary>
    public event EventHandler<Efl.Ui.IClickableClickedEvt_Args> ClickedEvt
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
                        Efl.Ui.IClickableClickedEvt_Args args = new Efl.Ui.IClickableClickedEvt_Args();
                        args.arg =  evt.Info;
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

                string key = "_EFL_UI_EVENT_CLICKED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedEvt.</summary>
    public void OnClickedEvt(Efl.Ui.IClickableClickedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_CLICKED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</summary>
    public event EventHandler<Efl.Ui.IClickableClickedAnyEvt_Args> ClickedAnyEvt
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
                        Efl.Ui.IClickableClickedAnyEvt_Args args = new Efl.Ui.IClickableClickedAnyEvt_Args();
                        args.arg =  evt.Info;
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

                string key = "_EFL_UI_EVENT_CLICKED_ANY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED_ANY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedAnyEvt.</summary>
    public void OnClickedAnyEvt(Efl.Ui.IClickableClickedAnyEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_CLICKED_ANY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when the object is pressed, event_info is the button that got pressed</summary>
    public event EventHandler<Efl.Ui.IClickablePressedEvt_Args> PressedEvt
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
                        Efl.Ui.IClickablePressedEvt_Args args = new Efl.Ui.IClickablePressedEvt_Args();
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

                string key = "_EFL_UI_EVENT_PRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_PRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event PressedEvt.</summary>
    public void OnPressedEvt(Efl.Ui.IClickablePressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_PRESSED";
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
    /// <summary>Called when the object is no longer pressed, event_info is the button that got pressed</summary>
    public event EventHandler<Efl.Ui.IClickableUnpressedEvt_Args> UnpressedEvt
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
                        Efl.Ui.IClickableUnpressedEvt_Args args = new Efl.Ui.IClickableUnpressedEvt_Args();
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

                string key = "_EFL_UI_EVENT_UNPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_UNPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event UnpressedEvt.</summary>
    public void OnUnpressedEvt(Efl.Ui.IClickableUnpressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_UNPRESSED";
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
    /// <summary>Called when the object receives a long press, event_info is the button that got pressed</summary>
    public event EventHandler<Efl.Ui.IClickableLongpressedEvt_Args> LongpressedEvt
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
                        Efl.Ui.IClickableLongpressedEvt_Args args = new Efl.Ui.IClickableLongpressedEvt_Args();
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

                string key = "_EFL_UI_EVENT_LONGPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_LONGPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event LongpressedEvt.</summary>
    public void OnLongpressedEvt(Efl.Ui.IClickableLongpressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_LONGPRESSED";
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
    /// <summary>Called when selected</summary>
    public event EventHandler<Efl.Ui.ISelectableItemSelectedEvt_Args> ItemSelectedEvt
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
                        Efl.Ui.ISelectableItemSelectedEvt_Args args = new Efl.Ui.ISelectableItemSelectedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_ITEM_SELECTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ITEM_SELECTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ItemSelectedEvt.</summary>
    public void OnItemSelectedEvt(Efl.Ui.ISelectableItemSelectedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_ITEM_SELECTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when no longer selected</summary>
    public event EventHandler<Efl.Ui.ISelectableItemUnselectedEvt_Args> ItemUnselectedEvt
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
                        Efl.Ui.ISelectableItemUnselectedEvt_Args args = new Efl.Ui.ISelectableItemUnselectedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
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

                string key = "_EFL_UI_EVENT_ITEM_UNSELECTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_ITEM_UNSELECTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ItemUnselectedEvt.</summary>
    public void OnItemUnselectedEvt(Efl.Ui.ISelectableItemUnselectedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_ITEM_UNSELECTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when selection is pasted</summary>
    public event EventHandler SelectionPasteEvt
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

                string key = "_EFL_UI_EVENT_SELECTION_PASTE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTION_PASTE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event SelectionPasteEvt.</summary>
    public void OnSelectionPasteEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SELECTION_PASTE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when selection is copied</summary>
    public event EventHandler SelectionCopyEvt
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

                string key = "_EFL_UI_EVENT_SELECTION_COPY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTION_COPY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event SelectionCopyEvt.</summary>
    public void OnSelectionCopyEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SELECTION_COPY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when selection is cut</summary>
    public event EventHandler SelectionCutEvt
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

                string key = "_EFL_UI_EVENT_SELECTION_CUT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTION_CUT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event SelectionCutEvt.</summary>
    public void OnSelectionCutEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SELECTION_CUT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called at selection start</summary>
    public event EventHandler SelectionStartEvt
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

                string key = "_EFL_UI_EVENT_SELECTION_START";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTION_START";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event SelectionStartEvt.</summary>
    public void OnSelectionStartEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SELECTION_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when selection is changed</summary>
    public event EventHandler SelectionChangedEvt
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

                string key = "_EFL_UI_EVENT_SELECTION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event SelectionChangedEvt.</summary>
    public void OnSelectionChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SELECTION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when selection is cleared</summary>
    public event EventHandler SelectionClearedEvt
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

                string key = "_EFL_UI_EVENT_SELECTION_CLEARED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTION_CLEARED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event SelectionClearedEvt.</summary>
    public void OnSelectionClearedEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SELECTION_CLEARED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Get the scrollable state of the entry
    /// Normally the entry is not scrollable. This gets the scrollable state of the entry.</summary>
    /// <returns><c>true</c> if it is to be scrollable, <c>false</c> otherwise.</returns>
    virtual public bool GetScrollable() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_scrollable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enable or disable scrolling in entry
    /// Normally the entry is not scrollable unless you enable it with this call.</summary>
    /// <param name="scroll"><c>true</c> if it is to be scrollable, <c>false</c> otherwise.</param>
    virtual public void SetScrollable(bool scroll) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_scrollable_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scroll);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the attribute to show the input panel in case of only an user&apos;s explicit Mouse Up event.</summary>
    /// <returns>If <c>true</c>, the input panel will be shown in case of only Mouse up event. (Focus event will be ignored.)</returns>
    virtual public bool GetInputPanelShowOnDemand() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_show_on_demand_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the attribute to show the input panel in case of only a user&apos;s explicit Mouse Up event. It doesn&apos;t request to show the input panel even though it has focus.</summary>
    /// <param name="ondemand">If <c>true</c>, the input panel will be shown in case of only Mouse up event. (Focus event will be ignored.)</param>
    virtual public void SetInputPanelShowOnDemand(bool ondemand) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_show_on_demand_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ondemand);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This returns whether the entry&apos;s contextual (longpress) menu is disabled.</summary>
    /// <returns>If <c>true</c>, the menu is disabled.</returns>
    virtual public bool GetContextMenuDisabled() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_context_menu_disabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This disables the entry&apos;s contextual (longpress) menu.</summary>
    /// <param name="disabled">If <c>true</c>, the menu is disabled.</param>
    virtual public void SetContextMenuDisabled(bool disabled) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_context_menu_disabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),disabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Getting elm_entry text paste/drop mode.
    /// Normally the entry allows both text and images to be pasted. This gets the copy &amp; paste mode of the entry.</summary>
    /// <returns>Format for copy &amp; paste.</returns>
    virtual public Efl.Ui.SelectionFormat GetCnpMode() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_cnp_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control pasting of text and images for the widget.
    /// Normally the entry allows both text and images to be pasted. By setting cnp_mode to be #ELM_CNP_MODE_NO_IMAGE this prevents images from being copied or pasted. By setting cnp_mode to be #ELM_CNP_MODE_PLAINTEXT this remove all tags in text .
    /// 
    /// Note: This only changes the behaviour of text.</summary>
    /// <param name="format">Format for copy &amp; paste.</param>
    virtual public void SetCnpMode(Efl.Ui.SelectionFormat format) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_cnp_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),format);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the language mode of the input panel.</summary>
    /// <returns>Language to be set to the input panel.</returns>
    virtual public Elm.Input.Panel.Lang GetInputPanelLanguage() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_language_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the language mode of the input panel.
    /// This API can be used if you want to show the alphabet keyboard mode.</summary>
    /// <param name="lang">Language to be set to the input panel.</param>
    virtual public void SetInputPanelLanguage(Elm.Input.Panel.Lang lang) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_language_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),lang);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This returns whether the entry&apos;s selection handlers are disabled.</summary>
    /// <returns>If <c>true</c>, the selection handlers are disabled.</returns>
    virtual public bool GetSelectionHandlerDisabled() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_selection_handler_disabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This disables the entry&apos;s selection handlers.</summary>
    /// <param name="disabled">If <c>true</c>, the selection handlers are disabled.</param>
    virtual public void SetSelectionHandlerDisabled(bool disabled) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_selection_handler_disabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),disabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the input panel layout variation of the entry</summary>
    /// <returns>Layout variation type.</returns>
    virtual public int GetInputPanelLayoutVariation() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_layout_variation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the input panel layout variation of the entry</summary>
    /// <param name="variation">Layout variation type.</param>
    virtual public void SetInputPanelLayoutVariation(int variation) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_layout_variation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),variation);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the autocapitalization type on the immodule.</summary>
    /// <returns>The type of autocapitalization.</returns>
    virtual public Elm.Autocapital.Type GetAutocapitalType() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_autocapital_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the autocapitalization type on the immodule.</summary>
    /// <param name="autocapital_type">The type of autocapitalization.</param>
    virtual public void SetAutocapitalType(Elm.Autocapital.Type autocapital_type) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_autocapital_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),autocapital_type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get whether the entry is set to password mode.</summary>
    /// <returns>If true, password mode is enabled.</returns>
    virtual public bool GetPasswordMode() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_password_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the entry to password mode.
    /// In password mode entries are implicitly single line and the display of any text inside them is replaced with asterisks (*).</summary>
    /// <param name="password">If true, password mode is enabled.</param>
    virtual public void SetPasswordMode(bool password) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_password_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),password);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get whether the return key on the input panel should be disabled or not.</summary>
    /// <returns>The state to put in in: <c>true</c> for disabled, <c>false</c> for enabled.</returns>
    virtual public bool GetInputPanelReturnKeyDisabled() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_return_key_disabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the return key on the input panel to be disabled.</summary>
    /// <param name="disabled">The state to put in in: <c>true</c> for disabled, <c>false</c> for enabled.</param>
    virtual public void SetInputPanelReturnKeyDisabled(bool disabled) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_return_key_disabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),disabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get whether the entry allows predictive text.</summary>
    /// <returns>Whether the entry should allow predictive text.</returns>
    virtual public bool GetPredictionAllow() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_prediction_allow_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set whether the entry should allow predictive text.</summary>
    /// <param name="prediction">Whether the entry should allow predictive text.</param>
    virtual public void SetPredictionAllow(bool prediction) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_prediction_allow_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),prediction);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the value of input hint.</summary>
    /// <returns>Input hint.</returns>
    virtual public Elm.Input.Hints GetInputHint() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_hint_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the input hint which allows input methods to fine-tune their behavior.</summary>
    /// <param name="hints">Input hint.</param>
    virtual public void SetInputHint(Elm.Input.Hints hints) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_hint_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hints);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the input panel layout of the entry.</summary>
    /// <returns>Layout type.</returns>
    virtual public Elm.Input.Panel.Layout GetInputPanelLayout() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_layout_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the input panel layout of the entry.</summary>
    /// <param name="layout">Layout type.</param>
    virtual public void SetInputPanelLayout(Elm.Input.Panel.Layout layout) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_layout_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),layout);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the &quot;return&quot; key type.</summary>
    /// <returns>The type of &quot;return&quot; key on the input panel.</returns>
    virtual public Elm.Input.Panel.ReturnKey.Type GetInputPanelReturnKeyType() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_return_key_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the &quot;return&quot; key type. This type is used to set string or icon on the &quot;return&quot; key of the input panel.
    /// An input panel displays the string or icon associated with this type.</summary>
    /// <param name="return_key_type">The type of &quot;return&quot; key on the input panel.</param>
    virtual public void SetInputPanelReturnKeyType(Elm.Input.Panel.ReturnKey.Type return_key_type) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_return_key_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),return_key_type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the attribute to show the input panel automatically.</summary>
    /// <returns>If <c>true</c>, the input panel is appeared when entry is clicked or has a focus.</returns>
    virtual public bool GetInputPanelEnabled() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the attribute to show the input panel automatically.</summary>
    /// <param name="enabled">If <c>true</c>, the input panel is appeared when entry is clicked or has a focus.</param>
    virtual public void SetInputPanelEnabled(bool enabled) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set whether the return key on the input panel is disabled automatically when entry has no text.
    /// If <c>enabled</c> is <c>true</c>, the return key on input panel is disabled when the entry has no text. The return key on the input panel is automatically enabled when the entry has text. The default value is <c>false</c>.</summary>
    /// <param name="enabled">If <c>enabled</c> is <c>true</c>, the return key is automatically disabled when the entry has no text.</param>
    virtual public void SetInputPanelReturnKeyAutoenabled(bool enabled) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_return_key_autoenabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The factory that provides item in the text e.g. &quot;emoticon/happy&quot; or &quot;href=file://image.jpg&quot; etc.</summary>
    /// <returns>Factory to create items</returns>
    virtual public Efl.Canvas.ITextFactory GetItemFactory() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_item_factory_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The factory that provides item in the text e.g. &quot;emoticon/happy&quot; or &quot;href=file://image.jpg&quot; etc.</summary>
    /// <param name="item_factory">Factory to create items</param>
    virtual public void SetItemFactory(Efl.Canvas.ITextFactory item_factory) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_item_factory_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),item_factory);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Show the input panel (virtual keyboard) based on the input panel property of entry such as layout, autocapital types and so on.
    /// Note that input panel is shown or hidden automatically according to the focus state of entry widget. This API can be used in the case of manually controlling by using <see cref="Efl.Ui.Text.SetInputPanelEnabled"/>(en, <c>false</c>).</summary>
    virtual public void ShowInputPanel() {
         Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_show_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This executes a &quot;copy&quot; action on the selected text in the entry.</summary>
    virtual public void SelectionCopy() {
         Efl.Ui.Text.NativeMethods.efl_ui_text_selection_copy_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This clears and frees the items in a entry&apos;s contextual (longpress) menu.
    /// See also <see cref="Efl.Ui.Text.AddContextMenuItem"/>.</summary>
    virtual public void ClearContextMenu() {
         Efl.Ui.Text.NativeMethods.efl_ui_text_context_menu_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Set the input panel-specific data to deliver to the input panel.
    /// This API is used by applications to deliver specific data to the input panel. The data format MUST be negotiated by both application and the input panel. The size and format of data are defined by the input panel.</summary>
    /// <param name="data">The specific data to be set to the input panel.</param>
    /// <param name="len">The length of data, in bytes, to send to the input panel.</param>
    virtual public void SetInputPanelImdata(System.IntPtr data, int len) {
                                                         Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_imdata_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),data, len);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get the specific data of the current input panel.</summary>
    /// <param name="data">The specific data to be obtained from the input panel.</param>
    /// <param name="len">The length of data.</param>
    virtual public void GetInputPanelImdata(ref System.IntPtr data, out int len) {
                                                         Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_imdata_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref data, out len);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This executes a &quot;paste&quot; action in the entry.</summary>
    virtual public void SelectionPaste() {
         Efl.Ui.Text.NativeMethods.efl_ui_text_selection_paste_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Hide the input panel (virtual keyboard).
    /// Note that input panel is shown or hidden automatically according to the focus state of entry widget. This API can be used in the case of manually controlling by using <see cref="Efl.Ui.Text.SetInputPanelEnabled"/>(en, <c>false</c>)</summary>
    virtual public void HideInputPanel() {
         Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_hide_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This ends a selection within the entry as though the user had just released the mouse button while making a selection.</summary>
    virtual public void CursorSelectionEnd() {
         Efl.Ui.Text.NativeMethods.efl_ui_text_cursor_selection_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This executes a &quot;cut&quot; action on the selected text in the entry.</summary>
    virtual public void SelectionCut() {
         Efl.Ui.Text.NativeMethods.efl_ui_text_selection_cut_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This adds an item to the entry&apos;s contextual menu.
    /// A longpress on an entry will make the contextual menu show up unless this has been disabled with <see cref="Efl.Ui.Text.SetContextMenuDisabled"/>. By default this menu provides a few options like enabling selection mode, which is useful on embedded devices that need to be explicit about it. When a selection exists it also shows the copy and cut actions.
    /// 
    /// With this function, developers can add other options to this menu to perform any action they deem necessary.</summary>
    /// <param name="label">The item&apos;s text label.</param>
    /// <param name="icon_file">The item&apos;s icon file.</param>
    /// <param name="icon_type">The item&apos;s icon type.</param>
    /// <param name="func">The callback to execute when the item is clicked.</param>
    /// <param name="data">The data to associate with the item for related functions.</param>
    virtual public void AddContextMenuItem(System.String label, System.String icon_file, Elm.Icon.Type icon_type, EvasSmartCb func, System.IntPtr data) {
                                                                                                                                 Efl.Ui.Text.NativeMethods.efl_ui_text_context_menu_item_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),label, icon_file, icon_type, func, data);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Creates and returns a new cursor for the text.</summary>
    /// <returns>Text cursor</returns>
    virtual public Efl.TextCursorCursor NewCursor() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_cursor_new_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// (Since EFL 1.22)</summary>
    /// <returns>The handle to the <see cref="Eina.File"/> that will be used</returns>
    virtual public Eina.File GetMmap() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_mmap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <param name="f">The handle to the <see cref="Eina.File"/> that will be used</param>
    /// <returns>0 on success, error code otherwise</returns>
    virtual public Eina.Error SetMmap(Eina.File f) {
                                 var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_mmap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),f);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Retrieve the file path from where an object is to fetch the data.
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <returns>The file path.</returns>
    virtual public System.String GetFile() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <param name="file">The file path.</param>
    /// <returns>0 on success, error code otherwise</returns>
    virtual public Eina.Error SetFile(System.String file) {
                                 var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),file);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the previously-set key which corresponds to the target data within a file.
    /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <returns>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</returns>
    virtual public System.String GetKey() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_key_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the key which corresponds to the target data within a file.
    /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.
    /// (Since EFL 1.22)</summary>
    /// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
    virtual public void SetKey(System.String key) {
                                 Efl.IFileConcrete.NativeMethods.efl_file_key_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the load state of the object.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
    virtual public bool GetLoaded() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_loaded_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="Efl.IFile.File"/> (or <see cref="Efl.IFile.Mmap"/>) and <see cref="Efl.IFile.Key"/> properties.
    /// In the case where <see cref="Efl.IFile.SetFile"/> has been called on an object, this will internally open the file and call <see cref="Efl.IFile.SetMmap"/> on the object using the opened file handle.
    /// 
    /// Calling <see cref="Efl.IFile.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.
    /// (Since EFL 1.22)</summary>
    /// <returns>0 on success, error code otherwise</returns>
    virtual public Eina.Error Load() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_load_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Perform all necessary operations to unload file data from the object.
    /// In the case where <see cref="Efl.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
    /// 
    /// Calling <see cref="Efl.IFile.Unload"/> on an object which is not currently loaded will have no effect.
    /// (Since EFL 1.22)</summary>
    virtual public void Unload() {
         Efl.IFileConcrete.NativeMethods.efl_file_unload_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    /// <summary>Retrieve the font family and size in use on a given text object.
    /// This function allows the font name and size of a text object to be queried. Remember that the font name string is still owned by Evas and should not have free() called on it by the caller of the function.
    /// 
    /// See also <see cref="Efl.ITextFont.GetFont"/>.</summary>
    /// <param name="font">The font family name or filename.</param>
    /// <param name="size">The font size, in points.</param>
    virtual public void GetFont(out System.String font, out Efl.Font.Size size) {
                                                         Efl.ITextFontConcrete.NativeMethods.efl_text_font_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out font, out size);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Set the font family, filename and size for a given text object.
    /// This function allows the font name and size of a text object to be set. The font string has to follow fontconfig&apos;s convention for naming fonts, as it&apos;s the underlying library used to query system fonts by Evas (see the fc-list command&apos;s output, on your system, to get an idea). Alternatively, youe can use the full path to a font file.
    /// 
    /// See also <see cref="Efl.ITextFont.GetFont"/>, <see cref="Efl.ITextFont.GetFontSource"/>.</summary>
    /// <param name="font">The font family name or filename.</param>
    /// <param name="size">The font size, in points.</param>
    virtual public void SetFont(System.String font, Efl.Font.Size size) {
                                                         Efl.ITextFontConcrete.NativeMethods.efl_text_font_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),font, size);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get the font file&apos;s path which is being used on a given text object.
    /// See <see cref="Efl.ITextFont.GetFont"/> for more details.</summary>
    /// <returns>The font file&apos;s path.</returns>
    virtual public System.String GetFontSource() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_source_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the font (source) file to be used on a given text object.
    /// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
    /// 
    /// See also <see cref="Efl.ITextFont.GetFont"/>.</summary>
    /// <param name="font_source">The font file&apos;s path.</param>
    virtual public void SetFontSource(System.String font_source) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_source_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),font_source);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Comma-separated list of font fallbacks
    /// Will be used in case the primary font isn&apos;t available.</summary>
    /// <returns>Font name fallbacks</returns>
    virtual public System.String GetFontFallbacks() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_fallbacks_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Comma-separated list of font fallbacks
    /// Will be used in case the primary font isn&apos;t available.</summary>
    /// <param name="font_fallbacks">Font name fallbacks</param>
    virtual public void SetFontFallbacks(System.String font_fallbacks) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_fallbacks_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),font_fallbacks);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Type of weight of the displayed font
    /// Default is <see cref="Efl.TextFontWeight.Normal"/>.</summary>
    /// <returns>Font weight</returns>
    virtual public Efl.TextFontWeight GetFontWeight() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_weight_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of weight of the displayed font
    /// Default is <see cref="Efl.TextFontWeight.Normal"/>.</summary>
    /// <param name="font_weight">Font weight</param>
    virtual public void SetFontWeight(Efl.TextFontWeight font_weight) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_weight_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),font_weight);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Type of slant of the displayed font
    /// Default is <see cref="Efl.TextFontSlant.Normal"/>.</summary>
    /// <returns>Font slant</returns>
    virtual public Efl.TextFontSlant GetFontSlant() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_slant_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of slant of the displayed font
    /// Default is <see cref="Efl.TextFontSlant.Normal"/>.</summary>
    /// <param name="style">Font slant</param>
    virtual public void SetFontSlant(Efl.TextFontSlant style) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_slant_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),style);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Type of width of the displayed font
    /// Default is <see cref="Efl.TextFontWidth.Normal"/>.</summary>
    /// <returns>Font width</returns>
    virtual public Efl.TextFontWidth GetFontWidth() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_width_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of width of the displayed font
    /// Default is <see cref="Efl.TextFontWidth.Normal"/>.</summary>
    /// <param name="width">Font width</param>
    virtual public void SetFontWidth(Efl.TextFontWidth width) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_width_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),width);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specific language of the displayed font
    /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.</summary>
    /// <returns>Language</returns>
    virtual public System.String GetFontLang() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_lang_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specific language of the displayed font
    /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.</summary>
    /// <param name="lang">Language</param>
    virtual public void SetFontLang(System.String lang) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_lang_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),lang);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
    /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.</summary>
    /// <returns>Scalable</returns>
    virtual public Efl.TextFontBitmapScalable GetFontBitmapScalable() {
         var _ret_var = Efl.ITextFontConcrete.NativeMethods.efl_text_font_bitmap_scalable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
    /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.</summary>
    /// <param name="scalable">Scalable</param>
    virtual public void SetFontBitmapScalable(Efl.TextFontBitmapScalable scalable) {
                                 Efl.ITextFontConcrete.NativeMethods.efl_text_font_bitmap_scalable_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scalable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Ellipsis value (number from -1.0 to 1.0)</summary>
    /// <returns>Ellipsis value</returns>
    virtual public double GetEllipsis() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_ellipsis_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Ellipsis value (number from -1.0 to 1.0)</summary>
    /// <param name="value">Ellipsis value</param>
    virtual public void SetEllipsis(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_ellipsis_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Wrap mode for use in the text</summary>
    /// <returns>Wrap mode</returns>
    virtual public Efl.TextFormatWrap GetWrap() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_wrap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Wrap mode for use in the text</summary>
    /// <param name="wrap">Wrap mode</param>
    virtual public void SetWrap(Efl.TextFormatWrap wrap) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_wrap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),wrap);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Multiline is enabled or not</summary>
    /// <returns><c>true</c> if multiline is enabled, <c>false</c> otherwise</returns>
    virtual public bool GetMultiline() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_multiline_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Multiline is enabled or not</summary>
    /// <param name="enabled"><c>true</c> if multiline is enabled, <c>false</c> otherwise</param>
    virtual public void SetMultiline(bool enabled) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_multiline_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Horizontal alignment of text</summary>
    /// <returns>Alignment type</returns>
    virtual public Efl.TextFormatHorizontalAlignmentAutoType GetHalignAutoType() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_halign_auto_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Horizontal alignment of text</summary>
    /// <param name="value">Alignment type</param>
    virtual public void SetHalignAutoType(Efl.TextFormatHorizontalAlignmentAutoType value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_halign_auto_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Horizontal alignment of text</summary>
    /// <returns>Horizontal alignment value</returns>
    virtual public double GetHalign() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_halign_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Horizontal alignment of text</summary>
    /// <param name="value">Horizontal alignment value</param>
    virtual public void SetHalign(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_halign_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Vertical alignment of text</summary>
    /// <returns>Vertical alignment value</returns>
    virtual public double GetValign() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_valign_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Vertical alignment of text</summary>
    /// <param name="value">Vertical alignment value</param>
    virtual public void SetValign(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_valign_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Minimal line gap (top and bottom) for each line in the text
    /// <c>value</c> is absolute size.</summary>
    /// <returns>Line gap value</returns>
    virtual public double GetLinegap() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_linegap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Minimal line gap (top and bottom) for each line in the text
    /// <c>value</c> is absolute size.</summary>
    /// <param name="value">Line gap value</param>
    virtual public void SetLinegap(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_linegap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Relative line gap (top and bottom) for each line in the text
    /// The original line gap value is multiplied by <c>value</c>.</summary>
    /// <returns>Relative line gap value</returns>
    virtual public double GetLinerelgap() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_linerelgap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Relative line gap (top and bottom) for each line in the text
    /// The original line gap value is multiplied by <c>value</c>.</summary>
    /// <param name="value">Relative line gap value</param>
    virtual public void SetLinerelgap(double value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_linerelgap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Tabstops value</summary>
    /// <returns>Tapstops value</returns>
    virtual public int GetTabstops() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_tabstops_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Tabstops value</summary>
    /// <param name="value">Tapstops value</param>
    virtual public void SetTabstops(int value) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_tabstops_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether text is a password</summary>
    /// <returns><c>true</c> if the text is a password, <c>false</c> otherwise</returns>
    virtual public bool GetPassword() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_password_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether text is a password</summary>
    /// <param name="enabled"><c>true</c> if the text is a password, <c>false</c> otherwise</param>
    virtual public void SetPassword(bool enabled) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_password_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The character used to replace characters that can&apos;t be displayed
    /// Currently only used to replace characters if <see cref="Efl.ITextFormat.Password"/> is enabled.</summary>
    /// <returns>Replacement character</returns>
    virtual public System.String GetReplacementChar() {
         var _ret_var = Efl.ITextFormatConcrete.NativeMethods.efl_text_replacement_char_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The character used to replace characters that can&apos;t be displayed
    /// Currently only used to replace characters if <see cref="Efl.ITextFormat.Password"/> is enabled.</summary>
    /// <param name="repch">Replacement character</param>
    virtual public void SetReplacementChar(System.String repch) {
                                 Efl.ITextFormatConcrete.NativeMethods.efl_text_replacement_char_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),repch);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether or not selection is allowed on this object</summary>
    /// <returns><c>true</c> if enabled, <c>false</c> otherwise</returns>
    virtual public bool GetSelectionAllowed() {
         var _ret_var = Efl.ITextInteractiveConcrete.NativeMethods.efl_text_interactive_selection_allowed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether or not selection is allowed on this object</summary>
    /// <param name="allowed"><c>true</c> if enabled, <c>false</c> otherwise</param>
    virtual public void SetSelectionAllowed(bool allowed) {
                                 Efl.ITextInteractiveConcrete.NativeMethods.efl_text_interactive_selection_allowed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),allowed);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The cursors used for selection handling.
    /// If the cursors are equal there&apos;s no selection.
    /// 
    /// You are allowed to retain and modify them. Modifying them modifies the selection of the object.</summary>
    /// <param name="start">The start of the selection</param>
    /// <param name="end">The end of the selection</param>
    virtual public void GetSelectionCursors(out Efl.TextCursorCursor start, out Efl.TextCursorCursor end) {
                                                         Efl.ITextInteractiveConcrete.NativeMethods.efl_text_interactive_selection_cursors_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out start, out end);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Whether the entry is editable.
    /// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
    /// <returns>If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</returns>
    virtual public bool GetEditable() {
         var _ret_var = Efl.ITextInteractiveConcrete.NativeMethods.efl_text_interactive_editable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether the entry is editable.
    /// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
    /// <param name="editable">If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</param>
    virtual public void SetEditable(bool editable) {
                                 Efl.ITextInteractiveConcrete.NativeMethods.efl_text_interactive_editable_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),editable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Clears the selection.</summary>
    virtual public void SelectNone() {
         Efl.ITextInteractiveConcrete.NativeMethods.efl_text_interactive_select_none_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Markup property</summary>
    /// <returns>The markup-text representation set to this text.</returns>
    virtual public System.String GetMarkup() {
         var _ret_var = Efl.ITextMarkupConcrete.NativeMethods.efl_text_markup_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Markup property</summary>
    /// <param name="markup">The markup-text representation set to this text.</param>
    virtual public void SetMarkup(System.String markup) {
                                 Efl.ITextMarkupConcrete.NativeMethods.efl_text_markup_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),markup);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of text, excluding style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetNormalColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_normal_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of text, excluding style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetNormalColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_normal_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Enable or disable backing type</summary>
    /// <returns>Backing type</returns>
    virtual public Efl.TextStyleBackingType GetBackingType() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_backing_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enable or disable backing type</summary>
    /// <param name="type">Backing type</param>
    virtual public void SetBackingType(Efl.TextStyleBackingType type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_backing_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Backing color</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetBackingColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_backing_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Backing color</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetBackingColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_backing_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Sets an underline style on the text</summary>
    /// <returns>Underline type</returns>
    virtual public Efl.TextStyleUnderlineType GetUnderlineType() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets an underline style on the text</summary>
    /// <param name="type">Underline type</param>
    virtual public void SetUnderlineType(Efl.TextStyleUnderlineType type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of normal underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetUnderlineColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of normal underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetUnderlineColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Height of underline style</summary>
    /// <returns>Height</returns>
    virtual public double GetUnderlineHeight() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_height_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Height of underline style</summary>
    /// <param name="height">Height</param>
    virtual public void SetUnderlineHeight(double height) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_height_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),height);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of dashed underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetUnderlineDashedColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of dashed underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetUnderlineDashedColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Width of dashed underline style</summary>
    /// <returns>Width</returns>
    virtual public int GetUnderlineDashedWidth() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_width_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Width of dashed underline style</summary>
    /// <param name="width">Width</param>
    virtual public void SetUnderlineDashedWidth(int width) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_width_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),width);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gap of dashed underline style</summary>
    /// <returns>Gap</returns>
    virtual public int GetUnderlineDashedGap() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_gap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gap of dashed underline style</summary>
    /// <param name="gap">Gap</param>
    virtual public void SetUnderlineDashedGap(int gap) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_underline_dashed_gap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),gap);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of underline2 style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetUnderline2Color(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline2_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of underline2 style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetUnderline2Color(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_underline2_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Type of strikethrough style</summary>
    /// <returns>Strikethrough type</returns>
    virtual public Efl.TextStyleStrikethroughType GetStrikethroughType() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_strikethrough_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of strikethrough style</summary>
    /// <param name="type">Strikethrough type</param>
    virtual public void SetStrikethroughType(Efl.TextStyleStrikethroughType type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_strikethrough_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of strikethrough_style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetStrikethroughColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_strikethrough_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of strikethrough_style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetStrikethroughColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_strikethrough_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Type of effect used for the displayed text</summary>
    /// <returns>Effect type</returns>
    virtual public Efl.TextStyleEffectType GetEffectType() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_effect_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of effect used for the displayed text</summary>
    /// <param name="type">Effect type</param>
    virtual public void SetEffectType(Efl.TextStyleEffectType type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_effect_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of outline effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetOutlineColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_outline_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of outline effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetOutlineColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_outline_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Direction of shadow effect</summary>
    /// <returns>Shadow direction</returns>
    virtual public Efl.TextStyleShadowDirection GetShadowDirection() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_shadow_direction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Direction of shadow effect</summary>
    /// <param name="type">Shadow direction</param>
    virtual public void SetShadowDirection(Efl.TextStyleShadowDirection type) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_shadow_direction_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of shadow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetShadowColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_shadow_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of shadow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetShadowColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_shadow_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetGlowColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_glow_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetGlowColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_glow_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Second color of the glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void GetGlow2Color(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_glow2_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Second color of the glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    virtual public void SetGlow2Color(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.ITextStyleConcrete.NativeMethods.efl_text_glow2_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Program that applies a special filter
    /// See <see cref="Efl.Gfx.IFilter"/>.</summary>
    /// <returns>Filter code</returns>
    virtual public System.String GetGfxFilter() {
         var _ret_var = Efl.ITextStyleConcrete.NativeMethods.efl_text_gfx_filter_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Program that applies a special filter
    /// See <see cref="Efl.Gfx.IFilter"/>.</summary>
    /// <param name="code">Filter code</param>
    virtual public void SetGfxFilter(System.String code) {
                                 Efl.ITextStyleConcrete.NativeMethods.efl_text_gfx_filter_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),code);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets single character present in accessible widget&apos;s text at given offset.</summary>
    /// <param name="offset">Position in text.</param>
    /// <returns>Character at offset. 0 when out-of bounds offset has been given. Codepoints between DC80 and DCFF indicates that string includes invalid UTF8 chars.</returns>
    virtual public Eina.Unicode GetCharacter(int offset) {
                                 var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_character_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),offset);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Gets string, start and end offset in text according to given initial offset and granularity.</summary>
    /// <param name="granularity">Text granularity</param>
    /// <param name="start_offset">Offset indicating start of string according to given granularity.  -1 in case of error.</param>
    /// <param name="end_offset">Offset indicating end of string according to given granularity. -1 in case of error.</param>
    /// <returns>Newly allocated UTF-8 encoded string. Must be free by a user.</returns>
    virtual public System.String GetString(Efl.Access.TextGranularity granularity, int start_offset, int end_offset) {
                 var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
        var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                                                        var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_string_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),granularity, _in_start_offset, _in_end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Gets text of accessible widget.</summary>
    /// <param name="start_offset">Position in text.</param>
    /// <param name="end_offset">End offset of text.</param>
    /// <returns>UTF-8 encoded text.</returns>
    virtual public System.String GetAccessText(int start_offset, int end_offset) {
                                                         var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start_offset, end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Gets offset position of caret (cursor)</summary>
    /// <returns>Offset</returns>
    virtual public int GetCaretOffset() {
         var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_caret_offset_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Caret offset property</summary>
    /// <param name="offset">Offset</param>
    /// <returns><c>true</c> if caret was successfully moved, <c>false</c> otherwise.</returns>
    virtual public bool SetCaretOffset(int offset) {
                                 var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_caret_offset_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),offset);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Indicate if a text attribute with a given name is set</summary>
    /// <param name="name">Text attribute name</param>
    /// <param name="start_offset">Position in text from which given attribute is set.</param>
    /// <param name="end_offset">Position in text to which given attribute is set.</param>
    /// <param name="value">Value of text attribute. Should be free()</param>
    /// <returns><c>true</c> if attribute name is set, <c>false</c> otherwise</returns>
    virtual public bool GetAttribute(System.String name, int start_offset, int end_offset, out System.String value) {
                 var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
        var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                                                                                var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_attribute_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, _in_start_offset, _in_end_offset, out value);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return _ret_var;
 }
    /// <summary>Gets list of all text attributes.</summary>
    /// <param name="start_offset">Start offset</param>
    /// <param name="end_offset">End offset</param>
    /// <returns>List of text attributes</returns>
    virtual public Eina.List<Efl.Access.TextAttribute> GetTextAttributes(int start_offset, int end_offset) {
         var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
        var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                                        var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_attributes_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_start_offset, _in_end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                        return new Eina.List<Efl.Access.TextAttribute>(_ret_var, true, true);
 }
    /// <summary>Default attributes</summary>
    /// <returns>List of default attributes</returns>
    virtual public Eina.List<Efl.Access.TextAttribute> GetDefaultAttributes() {
         var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_default_attributes_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Access.TextAttribute>(_ret_var, true, true);
 }
    /// <summary>Character extents</summary>
    /// <param name="offset">Offset</param>
    /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="rect">Extents rectangle</param>
    /// <returns><c>true</c> if character extents, <c>false</c> otherwise</returns>
    virtual public bool GetCharacterExtents(int offset, bool screen_coords, out Eina.Rect rect) {
                                                 var _out_rect = new Eina.Rect.NativeStruct();
                                var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_character_extents_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),offset, screen_coords, out _out_rect);
        Eina.Error.RaiseIfUnhandledException();
                        rect = _out_rect;
                                return _ret_var;
 }
    /// <summary>Character count</summary>
    /// <returns>Character count</returns>
    virtual public int GetCharacterCount() {
         var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_character_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Offset at given point</summary>
    /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <returns>Offset</returns>
    virtual public int GetOffsetAtPoint(bool screen_coords, int x, int y) {
                                                                                 var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_offset_at_point_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),screen_coords, x, y);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Bounded ranges</summary>
    /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="rect">Bounding box</param>
    /// <param name="xclip">xclip</param>
    /// <param name="yclip">yclip</param>
    /// <returns>List of ranges</returns>
    virtual public Eina.List<Efl.Access.TextRange> GetBoundedRanges(bool screen_coords, Eina.Rect rect, Efl.Access.TextClipType xclip, Efl.Access.TextClipType yclip) {
                 Eina.Rect.NativeStruct _in_rect = rect;
                                                                                        var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_bounded_ranges_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),screen_coords, _in_rect, xclip, yclip);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return new Eina.List<Efl.Access.TextRange>(_ret_var, true, true);
 }
    /// <summary>Range extents</summary>
    /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="start_offset">Start offset</param>
    /// <param name="end_offset">End offset</param>
    /// <param name="rect">Range rectangle</param>
    /// <returns><c>true</c> if range extents, <c>false</c> otherwise</returns>
    virtual public bool GetRangeExtents(bool screen_coords, int start_offset, int end_offset, out Eina.Rect rect) {
                                                                 var _out_rect = new Eina.Rect.NativeStruct();
                                        var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_range_extents_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),screen_coords, start_offset, end_offset, out _out_rect);
        Eina.Error.RaiseIfUnhandledException();
                                rect = _out_rect;
                                        return _ret_var;
 }
    /// <summary>Selection count property</summary>
    /// <returns>Selection counter</returns>
    virtual public int GetSelectionsCount() {
         var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_selections_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Selection property</summary>
    /// <param name="selection_number">Selection number for identification</param>
    /// <param name="start_offset">Selection start offset</param>
    /// <param name="end_offset">Selection end offset</param>
    virtual public void GetAccessSelection(int selection_number, out int start_offset, out int end_offset) {
                                                                                 Efl.Access.ITextConcrete.NativeMethods.efl_access_text_access_selection_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),selection_number, out start_offset, out end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Selection property</summary>
    /// <param name="selection_number">Selection number for identification</param>
    /// <param name="start_offset">Selection start offset</param>
    /// <param name="end_offset">Selection end offset</param>
    /// <returns><c>true</c> if selection was set, <c>false</c> otherwise</returns>
    virtual public bool SetAccessSelection(int selection_number, int start_offset, int end_offset) {
                                                                                 var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_access_selection_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),selection_number, start_offset, end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Add selection</summary>
    /// <param name="start_offset">Start selection from this offset</param>
    /// <param name="end_offset">End selection at this offset</param>
    /// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
    virtual public bool AddSelection(int start_offset, int end_offset) {
                                                         var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_selection_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start_offset, end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Remove selection</summary>
    /// <param name="selection_number">Selection number to be removed</param>
    /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
    virtual public bool SelectionRemove(int selection_number) {
                                 var _ret_var = Efl.Access.ITextConcrete.NativeMethods.efl_access_text_selection_remove_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),selection_number);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Editable content property</summary>
    /// <param name="kw_string">Content</param>
    /// <returns><c>true</c> if setting the value succeeded, <c>false</c> otherwise</returns>
    virtual public bool SetTextContent(System.String kw_string) {
                                 var _ret_var = Efl.Access.Editable.ITextConcrete.NativeMethods.efl_access_editable_text_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_string);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Insert text at given position</summary>
    /// <param name="kw_string">String to be inserted</param>
    /// <param name="position">Position to insert string</param>
    /// <returns><c>true</c> if insert succeeded, <c>false</c> otherwise</returns>
    virtual public bool Insert(System.String kw_string, int position) {
                                                         var _ret_var = Efl.Access.Editable.ITextConcrete.NativeMethods.efl_access_editable_text_insert_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_string, position);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Copy text between start and end parameter</summary>
    /// <param name="start">Start position to copy</param>
    /// <param name="end">End position to copy</param>
    /// <returns><c>true</c> if copy succeeded, <c>false</c> otherwise</returns>
    virtual public bool Copy(int start, int end) {
                                                         var _ret_var = Efl.Access.Editable.ITextConcrete.NativeMethods.efl_access_editable_text_copy_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Cut text between start and end parameter</summary>
    /// <param name="start">Start position to cut</param>
    /// <param name="end">End position to cut</param>
    /// <returns><c>true</c> if cut succeeded, <c>false</c> otherwise</returns>
    virtual public bool Cut(int start, int end) {
                                                         var _ret_var = Efl.Access.Editable.ITextConcrete.NativeMethods.efl_access_editable_text_cut_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Delete text between start and end parameter</summary>
    /// <param name="start">Start position to delete</param>
    /// <param name="end">End position to delete</param>
    /// <returns><c>true</c> if delete succeeded, <c>false</c> otherwise</returns>
    virtual public bool Delete(int start, int end) {
                                                         var _ret_var = Efl.Access.Editable.ITextConcrete.NativeMethods.efl_access_editable_text_delete_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Paste text at given position</summary>
    /// <param name="position">Position to insert text</param>
    /// <returns><c>true</c> if paste succeeded, <c>false</c> otherwise</returns>
    virtual public bool Paste(int position) {
                                 var _ret_var = Efl.Access.Editable.ITextConcrete.NativeMethods.efl_access_editable_text_paste_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),position);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Change internal states that a button got pressed.
    /// When the button is already pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    virtual public void Press(uint button) {
                                 Efl.Ui.IClickableConcrete.NativeMethods.efl_ui_clickable_press_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Change internal states that a button got unpressed.
    /// When the button is not pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    virtual public void Unpress(uint button) {
                                 Efl.Ui.IClickableConcrete.NativeMethods.efl_ui_clickable_unpress_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts the internal state after a press call.
    /// This will stop the timer for longpress. And set the state of the clickable mixin back into the unpressed state.</summary>
    virtual public void ResetButtonState(uint button) {
                                 Efl.Ui.IClickableConcrete.NativeMethods.efl_ui_clickable_button_state_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the scrollable state of the entry
    /// Normally the entry is not scrollable. This gets the scrollable state of the entry.</summary>
    /// <value><c>true</c> if it is to be scrollable, <c>false</c> otherwise.</value>
    public bool Scrollable {
        get { return GetScrollable(); }
        set { SetScrollable(value); }
    }
    /// <summary>Get the attribute to show the input panel in case of only an user&apos;s explicit Mouse Up event.</summary>
    /// <value>If <c>true</c>, the input panel will be shown in case of only Mouse up event. (Focus event will be ignored.)</value>
    public bool InputPanelShowOnDemand {
        get { return GetInputPanelShowOnDemand(); }
        set { SetInputPanelShowOnDemand(value); }
    }
    /// <summary>This returns whether the entry&apos;s contextual (longpress) menu is disabled.</summary>
    /// <value>If <c>true</c>, the menu is disabled.</value>
    public bool ContextMenuDisabled {
        get { return GetContextMenuDisabled(); }
        set { SetContextMenuDisabled(value); }
    }
    /// <summary>Getting elm_entry text paste/drop mode.
    /// Normally the entry allows both text and images to be pasted. This gets the copy &amp; paste mode of the entry.</summary>
    /// <value>Format for copy &amp; paste.</value>
    public Efl.Ui.SelectionFormat CnpMode {
        get { return GetCnpMode(); }
        set { SetCnpMode(value); }
    }
    /// <summary>Get the language mode of the input panel.</summary>
    /// <value>Language to be set to the input panel.</value>
    public Elm.Input.Panel.Lang InputPanelLanguage {
        get { return GetInputPanelLanguage(); }
        set { SetInputPanelLanguage(value); }
    }
    /// <summary>This returns whether the entry&apos;s selection handlers are disabled.</summary>
    /// <value>If <c>true</c>, the selection handlers are disabled.</value>
    public bool SelectionHandlerDisabled {
        get { return GetSelectionHandlerDisabled(); }
        set { SetSelectionHandlerDisabled(value); }
    }
    /// <summary>Get the input panel layout variation of the entry</summary>
    /// <value>Layout variation type.</value>
    public int InputPanelLayoutVariation {
        get { return GetInputPanelLayoutVariation(); }
        set { SetInputPanelLayoutVariation(value); }
    }
    /// <summary>Get the autocapitalization type on the immodule.</summary>
    /// <value>The type of autocapitalization.</value>
    public Elm.Autocapital.Type AutocapitalType {
        get { return GetAutocapitalType(); }
        set { SetAutocapitalType(value); }
    }
    /// <summary>Get whether the entry is set to password mode.</summary>
    /// <value>If true, password mode is enabled.</value>
    public bool PasswordMode {
        get { return GetPasswordMode(); }
        set { SetPasswordMode(value); }
    }
    /// <summary>Get whether the return key on the input panel should be disabled or not.</summary>
    /// <value>The state to put in in: <c>true</c> for disabled, <c>false</c> for enabled.</value>
    public bool InputPanelReturnKeyDisabled {
        get { return GetInputPanelReturnKeyDisabled(); }
        set { SetInputPanelReturnKeyDisabled(value); }
    }
    /// <summary>Get whether the entry allows predictive text.</summary>
    /// <value>Whether the entry should allow predictive text.</value>
    public bool PredictionAllow {
        get { return GetPredictionAllow(); }
        set { SetPredictionAllow(value); }
    }
    /// <summary>Gets the value of input hint.</summary>
    /// <value>Input hint.</value>
    public Elm.Input.Hints InputHint {
        get { return GetInputHint(); }
        set { SetInputHint(value); }
    }
    /// <summary>Get the input panel layout of the entry.</summary>
    /// <value>Layout type.</value>
    public Elm.Input.Panel.Layout InputPanelLayout {
        get { return GetInputPanelLayout(); }
        set { SetInputPanelLayout(value); }
    }
    /// <summary>Get the &quot;return&quot; key type.</summary>
    /// <value>The type of &quot;return&quot; key on the input panel.</value>
    public Elm.Input.Panel.ReturnKey.Type InputPanelReturnKeyType {
        get { return GetInputPanelReturnKeyType(); }
        set { SetInputPanelReturnKeyType(value); }
    }
    /// <summary>Get the attribute to show the input panel automatically.</summary>
    /// <value>If <c>true</c>, the input panel is appeared when entry is clicked or has a focus.</value>
    public bool InputPanelEnabled {
        get { return GetInputPanelEnabled(); }
        set { SetInputPanelEnabled(value); }
    }
    /// <summary>Set whether the return key on the input panel is disabled automatically when entry has no text.
    /// If <c>enabled</c> is <c>true</c>, the return key on input panel is disabled when the entry has no text. The return key on the input panel is automatically enabled when the entry has text. The default value is <c>false</c>.</summary>
    /// <value>If <c>enabled</c> is <c>true</c>, the return key is automatically disabled when the entry has no text.</value>
    public bool InputPanelReturnKeyAutoenabled {
        set { SetInputPanelReturnKeyAutoenabled(value); }
    }
    /// <summary>The factory that provides item in the text e.g. &quot;emoticon/happy&quot; or &quot;href=file://image.jpg&quot; etc.</summary>
    /// <value>Factory to create items</value>
    public Efl.Canvas.ITextFactory ItemFactory {
        get { return GetItemFactory(); }
        set { SetItemFactory(value); }
    }
    /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// (Since EFL 1.22)</summary>
    /// <value>The handle to the <see cref="Eina.File"/> that will be used</value>
    public Eina.File Mmap {
        get { return GetMmap(); }
        set { SetMmap(value); }
    }
    /// <summary>Retrieve the file path from where an object is to fetch the data.
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <value>The file path.</value>
    public System.String File {
        get { return GetFile(); }
        set { SetFile(value); }
    }
    /// <summary>Get the previously-set key which corresponds to the target data within a file.
    /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
    public System.String Key {
        get { return GetKey(); }
        set { SetKey(value); }
    }
    /// <summary>Get the load state of the object.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if the object is loaded, <c>false</c> otherwise.</value>
    public bool Loaded {
        get { return GetLoaded(); }
    }
    /// <summary>Get the font file&apos;s path which is being used on a given text object.
    /// See <see cref="Efl.ITextFont.GetFont"/> for more details.</summary>
    /// <value>The font file&apos;s path.</value>
    public System.String FontSource {
        get { return GetFontSource(); }
        set { SetFontSource(value); }
    }
    /// <summary>Comma-separated list of font fallbacks
    /// Will be used in case the primary font isn&apos;t available.</summary>
    /// <value>Font name fallbacks</value>
    public System.String FontFallbacks {
        get { return GetFontFallbacks(); }
        set { SetFontFallbacks(value); }
    }
    /// <summary>Type of weight of the displayed font
    /// Default is <see cref="Efl.TextFontWeight.Normal"/>.</summary>
    /// <value>Font weight</value>
    public Efl.TextFontWeight FontWeight {
        get { return GetFontWeight(); }
        set { SetFontWeight(value); }
    }
    /// <summary>Type of slant of the displayed font
    /// Default is <see cref="Efl.TextFontSlant.Normal"/>.</summary>
    /// <value>Font slant</value>
    public Efl.TextFontSlant FontSlant {
        get { return GetFontSlant(); }
        set { SetFontSlant(value); }
    }
    /// <summary>Type of width of the displayed font
    /// Default is <see cref="Efl.TextFontWidth.Normal"/>.</summary>
    /// <value>Font width</value>
    public Efl.TextFontWidth FontWidth {
        get { return GetFontWidth(); }
        set { SetFontWidth(value); }
    }
    /// <summary>Specific language of the displayed font
    /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.</summary>
    /// <value>Language</value>
    public System.String FontLang {
        get { return GetFontLang(); }
        set { SetFontLang(value); }
    }
    /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
    /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.</summary>
    /// <value>Scalable</value>
    public Efl.TextFontBitmapScalable FontBitmapScalable {
        get { return GetFontBitmapScalable(); }
        set { SetFontBitmapScalable(value); }
    }
    /// <summary>Ellipsis value (number from -1.0 to 1.0)</summary>
    /// <value>Ellipsis value</value>
    public double Ellipsis {
        get { return GetEllipsis(); }
        set { SetEllipsis(value); }
    }
    /// <summary>Wrap mode for use in the text</summary>
    /// <value>Wrap mode</value>
    public Efl.TextFormatWrap Wrap {
        get { return GetWrap(); }
        set { SetWrap(value); }
    }
    /// <summary>Multiline is enabled or not</summary>
    /// <value><c>true</c> if multiline is enabled, <c>false</c> otherwise</value>
    public bool Multiline {
        get { return GetMultiline(); }
        set { SetMultiline(value); }
    }
    /// <summary>Horizontal alignment of text</summary>
    /// <value>Alignment type</value>
    public Efl.TextFormatHorizontalAlignmentAutoType HalignAutoType {
        get { return GetHalignAutoType(); }
        set { SetHalignAutoType(value); }
    }
    /// <summary>Horizontal alignment of text</summary>
    /// <value>Horizontal alignment value</value>
    public double Halign {
        get { return GetHalign(); }
        set { SetHalign(value); }
    }
    /// <summary>Vertical alignment of text</summary>
    /// <value>Vertical alignment value</value>
    public double Valign {
        get { return GetValign(); }
        set { SetValign(value); }
    }
    /// <summary>Minimal line gap (top and bottom) for each line in the text
    /// <c>value</c> is absolute size.</summary>
    /// <value>Line gap value</value>
    public double Linegap {
        get { return GetLinegap(); }
        set { SetLinegap(value); }
    }
    /// <summary>Relative line gap (top and bottom) for each line in the text
    /// The original line gap value is multiplied by <c>value</c>.</summary>
    /// <value>Relative line gap value</value>
    public double Linerelgap {
        get { return GetLinerelgap(); }
        set { SetLinerelgap(value); }
    }
    /// <summary>Tabstops value</summary>
    /// <value>Tapstops value</value>
    public int Tabstops {
        get { return GetTabstops(); }
        set { SetTabstops(value); }
    }
    /// <summary>Whether text is a password</summary>
    /// <value><c>true</c> if the text is a password, <c>false</c> otherwise</value>
    public bool Password {
        get { return GetPassword(); }
        set { SetPassword(value); }
    }
    /// <summary>The character used to replace characters that can&apos;t be displayed
    /// Currently only used to replace characters if <see cref="Efl.ITextFormat.Password"/> is enabled.</summary>
    /// <value>Replacement character</value>
    public System.String ReplacementChar {
        get { return GetReplacementChar(); }
        set { SetReplacementChar(value); }
    }
    /// <summary>Whether or not selection is allowed on this object</summary>
    /// <value><c>true</c> if enabled, <c>false</c> otherwise</value>
    public bool SelectionAllowed {
        get { return GetSelectionAllowed(); }
        set { SetSelectionAllowed(value); }
    }
    /// <summary>Whether the entry is editable.
    /// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
    /// <value>If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</value>
    public bool Editable {
        get { return GetEditable(); }
        set { SetEditable(value); }
    }
    /// <summary>Markup property</summary>
    /// <value>The markup-text representation set to this text.</value>
    public System.String Markup {
        get { return GetMarkup(); }
        set { SetMarkup(value); }
    }
    /// <summary>Enable or disable backing type</summary>
    /// <value>Backing type</value>
    public Efl.TextStyleBackingType BackingType {
        get { return GetBackingType(); }
        set { SetBackingType(value); }
    }
    /// <summary>Sets an underline style on the text</summary>
    /// <value>Underline type</value>
    public Efl.TextStyleUnderlineType UnderlineType {
        get { return GetUnderlineType(); }
        set { SetUnderlineType(value); }
    }
    /// <summary>Height of underline style</summary>
    /// <value>Height</value>
    public double UnderlineHeight {
        get { return GetUnderlineHeight(); }
        set { SetUnderlineHeight(value); }
    }
    /// <summary>Width of dashed underline style</summary>
    /// <value>Width</value>
    public int UnderlineDashedWidth {
        get { return GetUnderlineDashedWidth(); }
        set { SetUnderlineDashedWidth(value); }
    }
    /// <summary>Gap of dashed underline style</summary>
    /// <value>Gap</value>
    public int UnderlineDashedGap {
        get { return GetUnderlineDashedGap(); }
        set { SetUnderlineDashedGap(value); }
    }
    /// <summary>Type of strikethrough style</summary>
    /// <value>Strikethrough type</value>
    public Efl.TextStyleStrikethroughType StrikethroughType {
        get { return GetStrikethroughType(); }
        set { SetStrikethroughType(value); }
    }
    /// <summary>Type of effect used for the displayed text</summary>
    /// <value>Effect type</value>
    public Efl.TextStyleEffectType EffectType {
        get { return GetEffectType(); }
        set { SetEffectType(value); }
    }
    /// <summary>Direction of shadow effect</summary>
    /// <value>Shadow direction</value>
    public Efl.TextStyleShadowDirection ShadowDirection {
        get { return GetShadowDirection(); }
        set { SetShadowDirection(value); }
    }
    /// <summary>Program that applies a special filter
    /// See <see cref="Efl.Gfx.IFilter"/>.</summary>
    /// <value>Filter code</value>
    public System.String GfxFilter {
        get { return GetGfxFilter(); }
        set { SetGfxFilter(value); }
    }
    /// <summary>Caret offset property</summary>
    /// <value>Offset</value>
    public int CaretOffset {
        get { return GetCaretOffset(); }
        set { SetCaretOffset(value); }
    }
    /// <summary>Default attributes</summary>
    /// <value>List of default attributes</value>
    public Eina.List<Efl.Access.TextAttribute> DefaultAttributes {
        get { return GetDefaultAttributes(); }
    }
    /// <summary>Character count</summary>
    /// <value>Character count</value>
    public int CharacterCount {
        get { return GetCharacterCount(); }
    }
    /// <summary>Selection count property</summary>
    /// <value>Selection counter</value>
    public int SelectionsCount {
        get { return GetSelectionsCount(); }
    }
    /// <summary>Editable content property</summary>
    /// <value>Content</value>
    public System.String TextContent {
        set { SetTextContent(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Text.efl_ui_text_class_get();
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

            if (efl_ui_text_scrollable_get_static_delegate == null)
            {
                efl_ui_text_scrollable_get_static_delegate = new efl_ui_text_scrollable_get_delegate(scrollable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScrollable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_scrollable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_scrollable_get_static_delegate) });
            }

            if (efl_ui_text_scrollable_set_static_delegate == null)
            {
                efl_ui_text_scrollable_set_static_delegate = new efl_ui_text_scrollable_set_delegate(scrollable_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScrollable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_scrollable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_scrollable_set_static_delegate) });
            }

            if (efl_ui_text_input_panel_show_on_demand_get_static_delegate == null)
            {
                efl_ui_text_input_panel_show_on_demand_get_static_delegate = new efl_ui_text_input_panel_show_on_demand_get_delegate(input_panel_show_on_demand_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInputPanelShowOnDemand") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_show_on_demand_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_show_on_demand_get_static_delegate) });
            }

            if (efl_ui_text_input_panel_show_on_demand_set_static_delegate == null)
            {
                efl_ui_text_input_panel_show_on_demand_set_static_delegate = new efl_ui_text_input_panel_show_on_demand_set_delegate(input_panel_show_on_demand_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInputPanelShowOnDemand") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_show_on_demand_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_show_on_demand_set_static_delegate) });
            }

            if (efl_ui_text_context_menu_disabled_get_static_delegate == null)
            {
                efl_ui_text_context_menu_disabled_get_static_delegate = new efl_ui_text_context_menu_disabled_get_delegate(context_menu_disabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContextMenuDisabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_context_menu_disabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_context_menu_disabled_get_static_delegate) });
            }

            if (efl_ui_text_context_menu_disabled_set_static_delegate == null)
            {
                efl_ui_text_context_menu_disabled_set_static_delegate = new efl_ui_text_context_menu_disabled_set_delegate(context_menu_disabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetContextMenuDisabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_context_menu_disabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_context_menu_disabled_set_static_delegate) });
            }

            if (efl_ui_text_cnp_mode_get_static_delegate == null)
            {
                efl_ui_text_cnp_mode_get_static_delegate = new efl_ui_text_cnp_mode_get_delegate(cnp_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCnpMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_cnp_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_cnp_mode_get_static_delegate) });
            }

            if (efl_ui_text_cnp_mode_set_static_delegate == null)
            {
                efl_ui_text_cnp_mode_set_static_delegate = new efl_ui_text_cnp_mode_set_delegate(cnp_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCnpMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_cnp_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_cnp_mode_set_static_delegate) });
            }

            if (efl_ui_text_input_panel_language_get_static_delegate == null)
            {
                efl_ui_text_input_panel_language_get_static_delegate = new efl_ui_text_input_panel_language_get_delegate(input_panel_language_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInputPanelLanguage") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_language_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_language_get_static_delegate) });
            }

            if (efl_ui_text_input_panel_language_set_static_delegate == null)
            {
                efl_ui_text_input_panel_language_set_static_delegate = new efl_ui_text_input_panel_language_set_delegate(input_panel_language_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInputPanelLanguage") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_language_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_language_set_static_delegate) });
            }

            if (efl_ui_text_selection_handler_disabled_get_static_delegate == null)
            {
                efl_ui_text_selection_handler_disabled_get_static_delegate = new efl_ui_text_selection_handler_disabled_get_delegate(selection_handler_disabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectionHandlerDisabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_selection_handler_disabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_selection_handler_disabled_get_static_delegate) });
            }

            if (efl_ui_text_selection_handler_disabled_set_static_delegate == null)
            {
                efl_ui_text_selection_handler_disabled_set_static_delegate = new efl_ui_text_selection_handler_disabled_set_delegate(selection_handler_disabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelectionHandlerDisabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_selection_handler_disabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_selection_handler_disabled_set_static_delegate) });
            }

            if (efl_ui_text_input_panel_layout_variation_get_static_delegate == null)
            {
                efl_ui_text_input_panel_layout_variation_get_static_delegate = new efl_ui_text_input_panel_layout_variation_get_delegate(input_panel_layout_variation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInputPanelLayoutVariation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_layout_variation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_layout_variation_get_static_delegate) });
            }

            if (efl_ui_text_input_panel_layout_variation_set_static_delegate == null)
            {
                efl_ui_text_input_panel_layout_variation_set_static_delegate = new efl_ui_text_input_panel_layout_variation_set_delegate(input_panel_layout_variation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInputPanelLayoutVariation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_layout_variation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_layout_variation_set_static_delegate) });
            }

            if (efl_ui_text_autocapital_type_get_static_delegate == null)
            {
                efl_ui_text_autocapital_type_get_static_delegate = new efl_ui_text_autocapital_type_get_delegate(autocapital_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAutocapitalType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_autocapital_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_autocapital_type_get_static_delegate) });
            }

            if (efl_ui_text_autocapital_type_set_static_delegate == null)
            {
                efl_ui_text_autocapital_type_set_static_delegate = new efl_ui_text_autocapital_type_set_delegate(autocapital_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAutocapitalType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_autocapital_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_autocapital_type_set_static_delegate) });
            }

            if (efl_ui_text_password_mode_get_static_delegate == null)
            {
                efl_ui_text_password_mode_get_static_delegate = new efl_ui_text_password_mode_get_delegate(password_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPasswordMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_password_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_password_mode_get_static_delegate) });
            }

            if (efl_ui_text_password_mode_set_static_delegate == null)
            {
                efl_ui_text_password_mode_set_static_delegate = new efl_ui_text_password_mode_set_delegate(password_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPasswordMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_password_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_password_mode_set_static_delegate) });
            }

            if (efl_ui_text_input_panel_return_key_disabled_get_static_delegate == null)
            {
                efl_ui_text_input_panel_return_key_disabled_get_static_delegate = new efl_ui_text_input_panel_return_key_disabled_get_delegate(input_panel_return_key_disabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInputPanelReturnKeyDisabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_return_key_disabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_return_key_disabled_get_static_delegate) });
            }

            if (efl_ui_text_input_panel_return_key_disabled_set_static_delegate == null)
            {
                efl_ui_text_input_panel_return_key_disabled_set_static_delegate = new efl_ui_text_input_panel_return_key_disabled_set_delegate(input_panel_return_key_disabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInputPanelReturnKeyDisabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_return_key_disabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_return_key_disabled_set_static_delegate) });
            }

            if (efl_ui_text_prediction_allow_get_static_delegate == null)
            {
                efl_ui_text_prediction_allow_get_static_delegate = new efl_ui_text_prediction_allow_get_delegate(prediction_allow_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPredictionAllow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_prediction_allow_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_prediction_allow_get_static_delegate) });
            }

            if (efl_ui_text_prediction_allow_set_static_delegate == null)
            {
                efl_ui_text_prediction_allow_set_static_delegate = new efl_ui_text_prediction_allow_set_delegate(prediction_allow_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPredictionAllow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_prediction_allow_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_prediction_allow_set_static_delegate) });
            }

            if (efl_ui_text_input_hint_get_static_delegate == null)
            {
                efl_ui_text_input_hint_get_static_delegate = new efl_ui_text_input_hint_get_delegate(input_hint_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInputHint") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_hint_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_hint_get_static_delegate) });
            }

            if (efl_ui_text_input_hint_set_static_delegate == null)
            {
                efl_ui_text_input_hint_set_static_delegate = new efl_ui_text_input_hint_set_delegate(input_hint_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInputHint") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_hint_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_hint_set_static_delegate) });
            }

            if (efl_ui_text_input_panel_layout_get_static_delegate == null)
            {
                efl_ui_text_input_panel_layout_get_static_delegate = new efl_ui_text_input_panel_layout_get_delegate(input_panel_layout_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInputPanelLayout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_layout_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_layout_get_static_delegate) });
            }

            if (efl_ui_text_input_panel_layout_set_static_delegate == null)
            {
                efl_ui_text_input_panel_layout_set_static_delegate = new efl_ui_text_input_panel_layout_set_delegate(input_panel_layout_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInputPanelLayout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_layout_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_layout_set_static_delegate) });
            }

            if (efl_ui_text_input_panel_return_key_type_get_static_delegate == null)
            {
                efl_ui_text_input_panel_return_key_type_get_static_delegate = new efl_ui_text_input_panel_return_key_type_get_delegate(input_panel_return_key_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInputPanelReturnKeyType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_return_key_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_return_key_type_get_static_delegate) });
            }

            if (efl_ui_text_input_panel_return_key_type_set_static_delegate == null)
            {
                efl_ui_text_input_panel_return_key_type_set_static_delegate = new efl_ui_text_input_panel_return_key_type_set_delegate(input_panel_return_key_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInputPanelReturnKeyType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_return_key_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_return_key_type_set_static_delegate) });
            }

            if (efl_ui_text_input_panel_enabled_get_static_delegate == null)
            {
                efl_ui_text_input_panel_enabled_get_static_delegate = new efl_ui_text_input_panel_enabled_get_delegate(input_panel_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInputPanelEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_enabled_get_static_delegate) });
            }

            if (efl_ui_text_input_panel_enabled_set_static_delegate == null)
            {
                efl_ui_text_input_panel_enabled_set_static_delegate = new efl_ui_text_input_panel_enabled_set_delegate(input_panel_enabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInputPanelEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_enabled_set_static_delegate) });
            }

            if (efl_ui_text_input_panel_return_key_autoenabled_set_static_delegate == null)
            {
                efl_ui_text_input_panel_return_key_autoenabled_set_static_delegate = new efl_ui_text_input_panel_return_key_autoenabled_set_delegate(input_panel_return_key_autoenabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInputPanelReturnKeyAutoenabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_return_key_autoenabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_return_key_autoenabled_set_static_delegate) });
            }

            if (efl_ui_text_item_factory_get_static_delegate == null)
            {
                efl_ui_text_item_factory_get_static_delegate = new efl_ui_text_item_factory_get_delegate(item_factory_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetItemFactory") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_item_factory_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_item_factory_get_static_delegate) });
            }

            if (efl_ui_text_item_factory_set_static_delegate == null)
            {
                efl_ui_text_item_factory_set_static_delegate = new efl_ui_text_item_factory_set_delegate(item_factory_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetItemFactory") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_item_factory_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_item_factory_set_static_delegate) });
            }

            if (efl_ui_text_input_panel_show_static_delegate == null)
            {
                efl_ui_text_input_panel_show_static_delegate = new efl_ui_text_input_panel_show_delegate(input_panel_show);
            }

            if (methods.FirstOrDefault(m => m.Name == "ShowInputPanel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_show"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_show_static_delegate) });
            }

            if (efl_ui_text_selection_copy_static_delegate == null)
            {
                efl_ui_text_selection_copy_static_delegate = new efl_ui_text_selection_copy_delegate(selection_copy);
            }

            if (methods.FirstOrDefault(m => m.Name == "SelectionCopy") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_selection_copy"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_selection_copy_static_delegate) });
            }

            if (efl_ui_text_context_menu_clear_static_delegate == null)
            {
                efl_ui_text_context_menu_clear_static_delegate = new efl_ui_text_context_menu_clear_delegate(context_menu_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearContextMenu") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_context_menu_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_context_menu_clear_static_delegate) });
            }

            if (efl_ui_text_input_panel_imdata_set_static_delegate == null)
            {
                efl_ui_text_input_panel_imdata_set_static_delegate = new efl_ui_text_input_panel_imdata_set_delegate(input_panel_imdata_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInputPanelImdata") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_imdata_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_imdata_set_static_delegate) });
            }

            if (efl_ui_text_input_panel_imdata_get_static_delegate == null)
            {
                efl_ui_text_input_panel_imdata_get_static_delegate = new efl_ui_text_input_panel_imdata_get_delegate(input_panel_imdata_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInputPanelImdata") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_imdata_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_imdata_get_static_delegate) });
            }

            if (efl_ui_text_selection_paste_static_delegate == null)
            {
                efl_ui_text_selection_paste_static_delegate = new efl_ui_text_selection_paste_delegate(selection_paste);
            }

            if (methods.FirstOrDefault(m => m.Name == "SelectionPaste") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_selection_paste"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_selection_paste_static_delegate) });
            }

            if (efl_ui_text_input_panel_hide_static_delegate == null)
            {
                efl_ui_text_input_panel_hide_static_delegate = new efl_ui_text_input_panel_hide_delegate(input_panel_hide);
            }

            if (methods.FirstOrDefault(m => m.Name == "HideInputPanel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_input_panel_hide"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_input_panel_hide_static_delegate) });
            }

            if (efl_ui_text_cursor_selection_end_static_delegate == null)
            {
                efl_ui_text_cursor_selection_end_static_delegate = new efl_ui_text_cursor_selection_end_delegate(cursor_selection_end);
            }

            if (methods.FirstOrDefault(m => m.Name == "CursorSelectionEnd") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_cursor_selection_end"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_cursor_selection_end_static_delegate) });
            }

            if (efl_ui_text_selection_cut_static_delegate == null)
            {
                efl_ui_text_selection_cut_static_delegate = new efl_ui_text_selection_cut_delegate(selection_cut);
            }

            if (methods.FirstOrDefault(m => m.Name == "SelectionCut") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_selection_cut"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_selection_cut_static_delegate) });
            }

            if (efl_ui_text_context_menu_item_add_static_delegate == null)
            {
                efl_ui_text_context_menu_item_add_static_delegate = new efl_ui_text_context_menu_item_add_delegate(context_menu_item_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddContextMenuItem") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_context_menu_item_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_context_menu_item_add_static_delegate) });
            }

            if (efl_ui_text_cursor_new_static_delegate == null)
            {
                efl_ui_text_cursor_new_static_delegate = new efl_ui_text_cursor_new_delegate(cursor_new);
            }

            if (methods.FirstOrDefault(m => m.Name == "NewCursor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_text_cursor_new"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_cursor_new_static_delegate) });
            }

            if (efl_file_mmap_get_static_delegate == null)
            {
                efl_file_mmap_get_static_delegate = new efl_file_mmap_get_delegate(mmap_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMmap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_mmap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_get_static_delegate) });
            }

            if (efl_file_mmap_set_static_delegate == null)
            {
                efl_file_mmap_set_static_delegate = new efl_file_mmap_set_delegate(mmap_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMmap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_mmap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_set_static_delegate) });
            }

            if (efl_file_get_static_delegate == null)
            {
                efl_file_get_static_delegate = new efl_file_get_delegate(file_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFile") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_get_static_delegate) });
            }

            if (efl_file_set_static_delegate == null)
            {
                efl_file_set_static_delegate = new efl_file_set_delegate(file_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFile") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_set_static_delegate) });
            }

            if (efl_file_key_get_static_delegate == null)
            {
                efl_file_key_get_static_delegate = new efl_file_key_get_delegate(key_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetKey") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_key_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_get_static_delegate) });
            }

            if (efl_file_key_set_static_delegate == null)
            {
                efl_file_key_set_static_delegate = new efl_file_key_set_delegate(key_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetKey") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_key_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_set_static_delegate) });
            }

            if (efl_file_loaded_get_static_delegate == null)
            {
                efl_file_loaded_get_static_delegate = new efl_file_loaded_get_delegate(loaded_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoaded") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_loaded_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_loaded_get_static_delegate) });
            }

            if (efl_file_load_static_delegate == null)
            {
                efl_file_load_static_delegate = new efl_file_load_delegate(load);
            }

            if (methods.FirstOrDefault(m => m.Name == "Load") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_load"), func = Marshal.GetFunctionPointerForDelegate(efl_file_load_static_delegate) });
            }

            if (efl_file_unload_static_delegate == null)
            {
                efl_file_unload_static_delegate = new efl_file_unload_delegate(unload);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unload") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_unload"), func = Marshal.GetFunctionPointerForDelegate(efl_file_unload_static_delegate) });
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

            if (efl_text_font_get_static_delegate == null)
            {
                efl_text_font_get_static_delegate = new efl_text_font_get_delegate(font_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFont") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_get_static_delegate) });
            }

            if (efl_text_font_set_static_delegate == null)
            {
                efl_text_font_set_static_delegate = new efl_text_font_set_delegate(font_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFont") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_set_static_delegate) });
            }

            if (efl_text_font_source_get_static_delegate == null)
            {
                efl_text_font_source_get_static_delegate = new efl_text_font_source_get_delegate(font_source_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_get_static_delegate) });
            }

            if (efl_text_font_source_set_static_delegate == null)
            {
                efl_text_font_source_set_static_delegate = new efl_text_font_source_set_delegate(font_source_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_source_set_static_delegate) });
            }

            if (efl_text_font_fallbacks_get_static_delegate == null)
            {
                efl_text_font_fallbacks_get_static_delegate = new efl_text_font_fallbacks_get_delegate(font_fallbacks_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontFallbacks") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_fallbacks_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_get_static_delegate) });
            }

            if (efl_text_font_fallbacks_set_static_delegate == null)
            {
                efl_text_font_fallbacks_set_static_delegate = new efl_text_font_fallbacks_set_delegate(font_fallbacks_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontFallbacks") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_fallbacks_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_fallbacks_set_static_delegate) });
            }

            if (efl_text_font_weight_get_static_delegate == null)
            {
                efl_text_font_weight_get_static_delegate = new efl_text_font_weight_get_delegate(font_weight_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontWeight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_weight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_get_static_delegate) });
            }

            if (efl_text_font_weight_set_static_delegate == null)
            {
                efl_text_font_weight_set_static_delegate = new efl_text_font_weight_set_delegate(font_weight_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontWeight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_weight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_weight_set_static_delegate) });
            }

            if (efl_text_font_slant_get_static_delegate == null)
            {
                efl_text_font_slant_get_static_delegate = new efl_text_font_slant_get_delegate(font_slant_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontSlant") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_slant_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_get_static_delegate) });
            }

            if (efl_text_font_slant_set_static_delegate == null)
            {
                efl_text_font_slant_set_static_delegate = new efl_text_font_slant_set_delegate(font_slant_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontSlant") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_slant_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_slant_set_static_delegate) });
            }

            if (efl_text_font_width_get_static_delegate == null)
            {
                efl_text_font_width_get_static_delegate = new efl_text_font_width_get_delegate(font_width_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontWidth") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_get_static_delegate) });
            }

            if (efl_text_font_width_set_static_delegate == null)
            {
                efl_text_font_width_set_static_delegate = new efl_text_font_width_set_delegate(font_width_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontWidth") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_width_set_static_delegate) });
            }

            if (efl_text_font_lang_get_static_delegate == null)
            {
                efl_text_font_lang_get_static_delegate = new efl_text_font_lang_get_delegate(font_lang_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontLang") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_lang_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_get_static_delegate) });
            }

            if (efl_text_font_lang_set_static_delegate == null)
            {
                efl_text_font_lang_set_static_delegate = new efl_text_font_lang_set_delegate(font_lang_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontLang") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_lang_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_lang_set_static_delegate) });
            }

            if (efl_text_font_bitmap_scalable_get_static_delegate == null)
            {
                efl_text_font_bitmap_scalable_get_static_delegate = new efl_text_font_bitmap_scalable_get_delegate(font_bitmap_scalable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFontBitmapScalable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_bitmap_scalable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_get_static_delegate) });
            }

            if (efl_text_font_bitmap_scalable_set_static_delegate == null)
            {
                efl_text_font_bitmap_scalable_set_static_delegate = new efl_text_font_bitmap_scalable_set_delegate(font_bitmap_scalable_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFontBitmapScalable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_font_bitmap_scalable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_font_bitmap_scalable_set_static_delegate) });
            }

            if (efl_text_ellipsis_get_static_delegate == null)
            {
                efl_text_ellipsis_get_static_delegate = new efl_text_ellipsis_get_delegate(ellipsis_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEllipsis") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_ellipsis_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_get_static_delegate) });
            }

            if (efl_text_ellipsis_set_static_delegate == null)
            {
                efl_text_ellipsis_set_static_delegate = new efl_text_ellipsis_set_delegate(ellipsis_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEllipsis") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_ellipsis_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_ellipsis_set_static_delegate) });
            }

            if (efl_text_wrap_get_static_delegate == null)
            {
                efl_text_wrap_get_static_delegate = new efl_text_wrap_get_delegate(wrap_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWrap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_wrap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_get_static_delegate) });
            }

            if (efl_text_wrap_set_static_delegate == null)
            {
                efl_text_wrap_set_static_delegate = new efl_text_wrap_set_delegate(wrap_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWrap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_wrap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_wrap_set_static_delegate) });
            }

            if (efl_text_multiline_get_static_delegate == null)
            {
                efl_text_multiline_get_static_delegate = new efl_text_multiline_get_delegate(multiline_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMultiline") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_multiline_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_get_static_delegate) });
            }

            if (efl_text_multiline_set_static_delegate == null)
            {
                efl_text_multiline_set_static_delegate = new efl_text_multiline_set_delegate(multiline_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMultiline") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_multiline_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_multiline_set_static_delegate) });
            }

            if (efl_text_halign_auto_type_get_static_delegate == null)
            {
                efl_text_halign_auto_type_get_static_delegate = new efl_text_halign_auto_type_get_delegate(halign_auto_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHalignAutoType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_halign_auto_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_auto_type_get_static_delegate) });
            }

            if (efl_text_halign_auto_type_set_static_delegate == null)
            {
                efl_text_halign_auto_type_set_static_delegate = new efl_text_halign_auto_type_set_delegate(halign_auto_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHalignAutoType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_halign_auto_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_auto_type_set_static_delegate) });
            }

            if (efl_text_halign_get_static_delegate == null)
            {
                efl_text_halign_get_static_delegate = new efl_text_halign_get_delegate(halign_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHalign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_halign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_get_static_delegate) });
            }

            if (efl_text_halign_set_static_delegate == null)
            {
                efl_text_halign_set_static_delegate = new efl_text_halign_set_delegate(halign_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHalign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_halign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_halign_set_static_delegate) });
            }

            if (efl_text_valign_get_static_delegate == null)
            {
                efl_text_valign_get_static_delegate = new efl_text_valign_get_delegate(valign_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetValign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_valign_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_valign_get_static_delegate) });
            }

            if (efl_text_valign_set_static_delegate == null)
            {
                efl_text_valign_set_static_delegate = new efl_text_valign_set_delegate(valign_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetValign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_valign_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_valign_set_static_delegate) });
            }

            if (efl_text_linegap_get_static_delegate == null)
            {
                efl_text_linegap_get_static_delegate = new efl_text_linegap_get_delegate(linegap_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLinegap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_linegap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linegap_get_static_delegate) });
            }

            if (efl_text_linegap_set_static_delegate == null)
            {
                efl_text_linegap_set_static_delegate = new efl_text_linegap_set_delegate(linegap_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLinegap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_linegap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linegap_set_static_delegate) });
            }

            if (efl_text_linerelgap_get_static_delegate == null)
            {
                efl_text_linerelgap_get_static_delegate = new efl_text_linerelgap_get_delegate(linerelgap_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLinerelgap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_linerelgap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linerelgap_get_static_delegate) });
            }

            if (efl_text_linerelgap_set_static_delegate == null)
            {
                efl_text_linerelgap_set_static_delegate = new efl_text_linerelgap_set_delegate(linerelgap_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLinerelgap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_linerelgap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_linerelgap_set_static_delegate) });
            }

            if (efl_text_tabstops_get_static_delegate == null)
            {
                efl_text_tabstops_get_static_delegate = new efl_text_tabstops_get_delegate(tabstops_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTabstops") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_tabstops_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tabstops_get_static_delegate) });
            }

            if (efl_text_tabstops_set_static_delegate == null)
            {
                efl_text_tabstops_set_static_delegate = new efl_text_tabstops_set_delegate(tabstops_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTabstops") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_tabstops_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_tabstops_set_static_delegate) });
            }

            if (efl_text_password_get_static_delegate == null)
            {
                efl_text_password_get_static_delegate = new efl_text_password_get_delegate(password_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPassword") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_password_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_get_static_delegate) });
            }

            if (efl_text_password_set_static_delegate == null)
            {
                efl_text_password_set_static_delegate = new efl_text_password_set_delegate(password_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPassword") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_password_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_password_set_static_delegate) });
            }

            if (efl_text_replacement_char_get_static_delegate == null)
            {
                efl_text_replacement_char_get_static_delegate = new efl_text_replacement_char_get_delegate(replacement_char_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetReplacementChar") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_replacement_char_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_get_static_delegate) });
            }

            if (efl_text_replacement_char_set_static_delegate == null)
            {
                efl_text_replacement_char_set_static_delegate = new efl_text_replacement_char_set_delegate(replacement_char_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetReplacementChar") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_replacement_char_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_replacement_char_set_static_delegate) });
            }

            if (efl_text_interactive_selection_allowed_get_static_delegate == null)
            {
                efl_text_interactive_selection_allowed_get_static_delegate = new efl_text_interactive_selection_allowed_get_delegate(selection_allowed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectionAllowed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_selection_allowed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_allowed_get_static_delegate) });
            }

            if (efl_text_interactive_selection_allowed_set_static_delegate == null)
            {
                efl_text_interactive_selection_allowed_set_static_delegate = new efl_text_interactive_selection_allowed_set_delegate(selection_allowed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelectionAllowed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_selection_allowed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_allowed_set_static_delegate) });
            }

            if (efl_text_interactive_selection_cursors_get_static_delegate == null)
            {
                efl_text_interactive_selection_cursors_get_static_delegate = new efl_text_interactive_selection_cursors_get_delegate(selection_cursors_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectionCursors") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_selection_cursors_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_selection_cursors_get_static_delegate) });
            }

            if (efl_text_interactive_editable_get_static_delegate == null)
            {
                efl_text_interactive_editable_get_static_delegate = new efl_text_interactive_editable_get_delegate(editable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEditable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_editable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_editable_get_static_delegate) });
            }

            if (efl_text_interactive_editable_set_static_delegate == null)
            {
                efl_text_interactive_editable_set_static_delegate = new efl_text_interactive_editable_set_delegate(editable_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEditable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_editable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_editable_set_static_delegate) });
            }

            if (efl_text_interactive_select_none_static_delegate == null)
            {
                efl_text_interactive_select_none_static_delegate = new efl_text_interactive_select_none_delegate(select_none);
            }

            if (methods.FirstOrDefault(m => m.Name == "SelectNone") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_interactive_select_none"), func = Marshal.GetFunctionPointerForDelegate(efl_text_interactive_select_none_static_delegate) });
            }

            if (efl_text_markup_get_static_delegate == null)
            {
                efl_text_markup_get_static_delegate = new efl_text_markup_get_delegate(markup_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMarkup") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_markup_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_get_static_delegate) });
            }

            if (efl_text_markup_set_static_delegate == null)
            {
                efl_text_markup_set_static_delegate = new efl_text_markup_set_delegate(markup_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMarkup") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_markup_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_markup_set_static_delegate) });
            }

            if (efl_text_normal_color_get_static_delegate == null)
            {
                efl_text_normal_color_get_static_delegate = new efl_text_normal_color_get_delegate(normal_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetNormalColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_normal_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_normal_color_get_static_delegate) });
            }

            if (efl_text_normal_color_set_static_delegate == null)
            {
                efl_text_normal_color_set_static_delegate = new efl_text_normal_color_set_delegate(normal_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetNormalColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_normal_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_normal_color_set_static_delegate) });
            }

            if (efl_text_backing_type_get_static_delegate == null)
            {
                efl_text_backing_type_get_static_delegate = new efl_text_backing_type_get_delegate(backing_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBackingType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_backing_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_type_get_static_delegate) });
            }

            if (efl_text_backing_type_set_static_delegate == null)
            {
                efl_text_backing_type_set_static_delegate = new efl_text_backing_type_set_delegate(backing_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBackingType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_backing_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_type_set_static_delegate) });
            }

            if (efl_text_backing_color_get_static_delegate == null)
            {
                efl_text_backing_color_get_static_delegate = new efl_text_backing_color_get_delegate(backing_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBackingColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_backing_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_color_get_static_delegate) });
            }

            if (efl_text_backing_color_set_static_delegate == null)
            {
                efl_text_backing_color_set_static_delegate = new efl_text_backing_color_set_delegate(backing_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBackingColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_backing_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_backing_color_set_static_delegate) });
            }

            if (efl_text_underline_type_get_static_delegate == null)
            {
                efl_text_underline_type_get_static_delegate = new efl_text_underline_type_get_delegate(underline_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderlineType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_get_static_delegate) });
            }

            if (efl_text_underline_type_set_static_delegate == null)
            {
                efl_text_underline_type_set_static_delegate = new efl_text_underline_type_set_delegate(underline_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderlineType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_type_set_static_delegate) });
            }

            if (efl_text_underline_color_get_static_delegate == null)
            {
                efl_text_underline_color_get_static_delegate = new efl_text_underline_color_get_delegate(underline_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderlineColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_get_static_delegate) });
            }

            if (efl_text_underline_color_set_static_delegate == null)
            {
                efl_text_underline_color_set_static_delegate = new efl_text_underline_color_set_delegate(underline_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderlineColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_color_set_static_delegate) });
            }

            if (efl_text_underline_height_get_static_delegate == null)
            {
                efl_text_underline_height_get_static_delegate = new efl_text_underline_height_get_delegate(underline_height_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderlineHeight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_height_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_get_static_delegate) });
            }

            if (efl_text_underline_height_set_static_delegate == null)
            {
                efl_text_underline_height_set_static_delegate = new efl_text_underline_height_set_delegate(underline_height_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderlineHeight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_height_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_height_set_static_delegate) });
            }

            if (efl_text_underline_dashed_color_get_static_delegate == null)
            {
                efl_text_underline_dashed_color_get_static_delegate = new efl_text_underline_dashed_color_get_delegate(underline_dashed_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderlineDashedColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_get_static_delegate) });
            }

            if (efl_text_underline_dashed_color_set_static_delegate == null)
            {
                efl_text_underline_dashed_color_set_static_delegate = new efl_text_underline_dashed_color_set_delegate(underline_dashed_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderlineDashedColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_color_set_static_delegate) });
            }

            if (efl_text_underline_dashed_width_get_static_delegate == null)
            {
                efl_text_underline_dashed_width_get_static_delegate = new efl_text_underline_dashed_width_get_delegate(underline_dashed_width_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderlineDashedWidth") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_width_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_get_static_delegate) });
            }

            if (efl_text_underline_dashed_width_set_static_delegate == null)
            {
                efl_text_underline_dashed_width_set_static_delegate = new efl_text_underline_dashed_width_set_delegate(underline_dashed_width_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderlineDashedWidth") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_width_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_width_set_static_delegate) });
            }

            if (efl_text_underline_dashed_gap_get_static_delegate == null)
            {
                efl_text_underline_dashed_gap_get_static_delegate = new efl_text_underline_dashed_gap_get_delegate(underline_dashed_gap_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderlineDashedGap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_gap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_get_static_delegate) });
            }

            if (efl_text_underline_dashed_gap_set_static_delegate == null)
            {
                efl_text_underline_dashed_gap_set_static_delegate = new efl_text_underline_dashed_gap_set_delegate(underline_dashed_gap_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderlineDashedGap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline_dashed_gap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline_dashed_gap_set_static_delegate) });
            }

            if (efl_text_underline2_color_get_static_delegate == null)
            {
                efl_text_underline2_color_get_static_delegate = new efl_text_underline2_color_get_delegate(underline2_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetUnderline2Color") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline2_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline2_color_get_static_delegate) });
            }

            if (efl_text_underline2_color_set_static_delegate == null)
            {
                efl_text_underline2_color_set_static_delegate = new efl_text_underline2_color_set_delegate(underline2_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetUnderline2Color") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_underline2_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_underline2_color_set_static_delegate) });
            }

            if (efl_text_strikethrough_type_get_static_delegate == null)
            {
                efl_text_strikethrough_type_get_static_delegate = new efl_text_strikethrough_type_get_delegate(strikethrough_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStrikethroughType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_strikethrough_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_get_static_delegate) });
            }

            if (efl_text_strikethrough_type_set_static_delegate == null)
            {
                efl_text_strikethrough_type_set_static_delegate = new efl_text_strikethrough_type_set_delegate(strikethrough_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStrikethroughType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_strikethrough_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_type_set_static_delegate) });
            }

            if (efl_text_strikethrough_color_get_static_delegate == null)
            {
                efl_text_strikethrough_color_get_static_delegate = new efl_text_strikethrough_color_get_delegate(strikethrough_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStrikethroughColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_strikethrough_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_get_static_delegate) });
            }

            if (efl_text_strikethrough_color_set_static_delegate == null)
            {
                efl_text_strikethrough_color_set_static_delegate = new efl_text_strikethrough_color_set_delegate(strikethrough_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStrikethroughColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_strikethrough_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_strikethrough_color_set_static_delegate) });
            }

            if (efl_text_effect_type_get_static_delegate == null)
            {
                efl_text_effect_type_get_static_delegate = new efl_text_effect_type_get_delegate(effect_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEffectType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_effect_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_get_static_delegate) });
            }

            if (efl_text_effect_type_set_static_delegate == null)
            {
                efl_text_effect_type_set_static_delegate = new efl_text_effect_type_set_delegate(effect_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEffectType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_effect_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_effect_type_set_static_delegate) });
            }

            if (efl_text_outline_color_get_static_delegate == null)
            {
                efl_text_outline_color_get_static_delegate = new efl_text_outline_color_get_delegate(outline_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetOutlineColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_outline_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_get_static_delegate) });
            }

            if (efl_text_outline_color_set_static_delegate == null)
            {
                efl_text_outline_color_set_static_delegate = new efl_text_outline_color_set_delegate(outline_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetOutlineColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_outline_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_outline_color_set_static_delegate) });
            }

            if (efl_text_shadow_direction_get_static_delegate == null)
            {
                efl_text_shadow_direction_get_static_delegate = new efl_text_shadow_direction_get_delegate(shadow_direction_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetShadowDirection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_shadow_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_get_static_delegate) });
            }

            if (efl_text_shadow_direction_set_static_delegate == null)
            {
                efl_text_shadow_direction_set_static_delegate = new efl_text_shadow_direction_set_delegate(shadow_direction_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetShadowDirection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_shadow_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_direction_set_static_delegate) });
            }

            if (efl_text_shadow_color_get_static_delegate == null)
            {
                efl_text_shadow_color_get_static_delegate = new efl_text_shadow_color_get_delegate(shadow_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetShadowColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_shadow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_get_static_delegate) });
            }

            if (efl_text_shadow_color_set_static_delegate == null)
            {
                efl_text_shadow_color_set_static_delegate = new efl_text_shadow_color_set_delegate(shadow_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetShadowColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_shadow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_shadow_color_set_static_delegate) });
            }

            if (efl_text_glow_color_get_static_delegate == null)
            {
                efl_text_glow_color_get_static_delegate = new efl_text_glow_color_get_delegate(glow_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGlowColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_glow_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_get_static_delegate) });
            }

            if (efl_text_glow_color_set_static_delegate == null)
            {
                efl_text_glow_color_set_static_delegate = new efl_text_glow_color_set_delegate(glow_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGlowColor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_glow_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow_color_set_static_delegate) });
            }

            if (efl_text_glow2_color_get_static_delegate == null)
            {
                efl_text_glow2_color_get_static_delegate = new efl_text_glow2_color_get_delegate(glow2_color_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGlow2Color") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_glow2_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow2_color_get_static_delegate) });
            }

            if (efl_text_glow2_color_set_static_delegate == null)
            {
                efl_text_glow2_color_set_static_delegate = new efl_text_glow2_color_set_delegate(glow2_color_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGlow2Color") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_glow2_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_glow2_color_set_static_delegate) });
            }

            if (efl_text_gfx_filter_get_static_delegate == null)
            {
                efl_text_gfx_filter_get_static_delegate = new efl_text_gfx_filter_get_delegate(gfx_filter_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGfxFilter") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_gfx_filter_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_get_static_delegate) });
            }

            if (efl_text_gfx_filter_set_static_delegate == null)
            {
                efl_text_gfx_filter_set_static_delegate = new efl_text_gfx_filter_set_delegate(gfx_filter_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGfxFilter") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_text_gfx_filter_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_gfx_filter_set_static_delegate) });
            }

            if (efl_access_text_character_get_static_delegate == null)
            {
                efl_access_text_character_get_static_delegate = new efl_access_text_character_get_delegate(character_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCharacter") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_character_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_character_get_static_delegate) });
            }

            if (efl_access_text_string_get_static_delegate == null)
            {
                efl_access_text_string_get_static_delegate = new efl_access_text_string_get_delegate(string_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_string_get_static_delegate) });
            }

            if (efl_access_text_get_static_delegate == null)
            {
                efl_access_text_get_static_delegate = new efl_access_text_get_delegate(access_text_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAccessText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_get_static_delegate) });
            }

            if (efl_access_text_caret_offset_get_static_delegate == null)
            {
                efl_access_text_caret_offset_get_static_delegate = new efl_access_text_caret_offset_get_delegate(caret_offset_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCaretOffset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_caret_offset_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_caret_offset_get_static_delegate) });
            }

            if (efl_access_text_caret_offset_set_static_delegate == null)
            {
                efl_access_text_caret_offset_set_static_delegate = new efl_access_text_caret_offset_set_delegate(caret_offset_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCaretOffset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_caret_offset_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_caret_offset_set_static_delegate) });
            }

            if (efl_access_text_attribute_get_static_delegate == null)
            {
                efl_access_text_attribute_get_static_delegate = new efl_access_text_attribute_get_delegate(attribute_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAttribute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_attribute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_attribute_get_static_delegate) });
            }

            if (efl_access_text_attributes_get_static_delegate == null)
            {
                efl_access_text_attributes_get_static_delegate = new efl_access_text_attributes_get_delegate(text_attributes_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTextAttributes") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_attributes_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_attributes_get_static_delegate) });
            }

            if (efl_access_text_default_attributes_get_static_delegate == null)
            {
                efl_access_text_default_attributes_get_static_delegate = new efl_access_text_default_attributes_get_delegate(default_attributes_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDefaultAttributes") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_default_attributes_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_default_attributes_get_static_delegate) });
            }

            if (efl_access_text_character_extents_get_static_delegate == null)
            {
                efl_access_text_character_extents_get_static_delegate = new efl_access_text_character_extents_get_delegate(character_extents_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCharacterExtents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_character_extents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_character_extents_get_static_delegate) });
            }

            if (efl_access_text_character_count_get_static_delegate == null)
            {
                efl_access_text_character_count_get_static_delegate = new efl_access_text_character_count_get_delegate(character_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCharacterCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_character_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_character_count_get_static_delegate) });
            }

            if (efl_access_text_offset_at_point_get_static_delegate == null)
            {
                efl_access_text_offset_at_point_get_static_delegate = new efl_access_text_offset_at_point_get_delegate(offset_at_point_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetOffsetAtPoint") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_offset_at_point_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_offset_at_point_get_static_delegate) });
            }

            if (efl_access_text_bounded_ranges_get_static_delegate == null)
            {
                efl_access_text_bounded_ranges_get_static_delegate = new efl_access_text_bounded_ranges_get_delegate(bounded_ranges_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBoundedRanges") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_bounded_ranges_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_bounded_ranges_get_static_delegate) });
            }

            if (efl_access_text_range_extents_get_static_delegate == null)
            {
                efl_access_text_range_extents_get_static_delegate = new efl_access_text_range_extents_get_delegate(range_extents_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRangeExtents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_range_extents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_range_extents_get_static_delegate) });
            }

            if (efl_access_text_selections_count_get_static_delegate == null)
            {
                efl_access_text_selections_count_get_static_delegate = new efl_access_text_selections_count_get_delegate(selections_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectionsCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_selections_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_selections_count_get_static_delegate) });
            }

            if (efl_access_text_access_selection_get_static_delegate == null)
            {
                efl_access_text_access_selection_get_static_delegate = new efl_access_text_access_selection_get_delegate(access_selection_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAccessSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_access_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_access_selection_get_static_delegate) });
            }

            if (efl_access_text_access_selection_set_static_delegate == null)
            {
                efl_access_text_access_selection_set_static_delegate = new efl_access_text_access_selection_set_delegate(access_selection_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAccessSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_access_selection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_access_selection_set_static_delegate) });
            }

            if (efl_access_text_selection_add_static_delegate == null)
            {
                efl_access_text_selection_add_static_delegate = new efl_access_text_selection_add_delegate(selection_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_selection_add"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_selection_add_static_delegate) });
            }

            if (efl_access_text_selection_remove_static_delegate == null)
            {
                efl_access_text_selection_remove_static_delegate = new efl_access_text_selection_remove_delegate(selection_remove);
            }

            if (methods.FirstOrDefault(m => m.Name == "SelectionRemove") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_text_selection_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_access_text_selection_remove_static_delegate) });
            }

            if (efl_access_editable_text_content_set_static_delegate == null)
            {
                efl_access_editable_text_content_set_static_delegate = new efl_access_editable_text_content_set_delegate(text_content_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTextContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_editable_text_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_content_set_static_delegate) });
            }

            if (efl_access_editable_text_insert_static_delegate == null)
            {
                efl_access_editable_text_insert_static_delegate = new efl_access_editable_text_insert_delegate(insert);
            }

            if (methods.FirstOrDefault(m => m.Name == "Insert") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_editable_text_insert"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_insert_static_delegate) });
            }

            if (efl_access_editable_text_copy_static_delegate == null)
            {
                efl_access_editable_text_copy_static_delegate = new efl_access_editable_text_copy_delegate(copy);
            }

            if (methods.FirstOrDefault(m => m.Name == "Copy") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_editable_text_copy"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_copy_static_delegate) });
            }

            if (efl_access_editable_text_cut_static_delegate == null)
            {
                efl_access_editable_text_cut_static_delegate = new efl_access_editable_text_cut_delegate(cut);
            }

            if (methods.FirstOrDefault(m => m.Name == "Cut") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_editable_text_cut"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_cut_static_delegate) });
            }

            if (efl_access_editable_text_delete_static_delegate == null)
            {
                efl_access_editable_text_delete_static_delegate = new efl_access_editable_text_delete_delegate(kw_delete);
            }

            if (methods.FirstOrDefault(m => m.Name == "Delete") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_editable_text_delete"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_delete_static_delegate) });
            }

            if (efl_access_editable_text_paste_static_delegate == null)
            {
                efl_access_editable_text_paste_static_delegate = new efl_access_editable_text_paste_delegate(paste);
            }

            if (methods.FirstOrDefault(m => m.Name == "Paste") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_editable_text_paste"), func = Marshal.GetFunctionPointerForDelegate(efl_access_editable_text_paste_static_delegate) });
            }

            if (efl_ui_clickable_press_static_delegate == null)
            {
                efl_ui_clickable_press_static_delegate = new efl_ui_clickable_press_delegate(press);
            }

            if (methods.FirstOrDefault(m => m.Name == "Press") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clickable_press"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clickable_press_static_delegate) });
            }

            if (efl_ui_clickable_unpress_static_delegate == null)
            {
                efl_ui_clickable_unpress_static_delegate = new efl_ui_clickable_unpress_delegate(unpress);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unpress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clickable_unpress"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clickable_unpress_static_delegate) });
            }

            if (efl_ui_clickable_button_state_reset_static_delegate == null)
            {
                efl_ui_clickable_button_state_reset_static_delegate = new efl_ui_clickable_button_state_reset_delegate(button_state_reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "ResetButtonState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_clickable_button_state_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_clickable_button_state_reset_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Text.efl_ui_text_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_text_scrollable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_text_scrollable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_scrollable_get_api_delegate> efl_ui_text_scrollable_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_scrollable_get_api_delegate>(Module, "efl_ui_text_scrollable_get");

        private static bool scrollable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_scrollable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetScrollable();
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
                return efl_ui_text_scrollable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_scrollable_get_delegate efl_ui_text_scrollable_get_static_delegate;

        
        private delegate void efl_ui_text_scrollable_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool scroll);

        
        public delegate void efl_ui_text_scrollable_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool scroll);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_scrollable_set_api_delegate> efl_ui_text_scrollable_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_scrollable_set_api_delegate>(Module, "efl_ui_text_scrollable_set");

        private static void scrollable_set(System.IntPtr obj, System.IntPtr pd, bool scroll)
        {
            Eina.Log.Debug("function efl_ui_text_scrollable_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetScrollable(scroll);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_scrollable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), scroll);
            }
        }

        private static efl_ui_text_scrollable_set_delegate efl_ui_text_scrollable_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_text_input_panel_show_on_demand_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_text_input_panel_show_on_demand_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_show_on_demand_get_api_delegate> efl_ui_text_input_panel_show_on_demand_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_show_on_demand_get_api_delegate>(Module, "efl_ui_text_input_panel_show_on_demand_get");

        private static bool input_panel_show_on_demand_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_show_on_demand_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetInputPanelShowOnDemand();
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
                return efl_ui_text_input_panel_show_on_demand_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_input_panel_show_on_demand_get_delegate efl_ui_text_input_panel_show_on_demand_get_static_delegate;

        
        private delegate void efl_ui_text_input_panel_show_on_demand_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool ondemand);

        
        public delegate void efl_ui_text_input_panel_show_on_demand_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool ondemand);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_show_on_demand_set_api_delegate> efl_ui_text_input_panel_show_on_demand_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_show_on_demand_set_api_delegate>(Module, "efl_ui_text_input_panel_show_on_demand_set");

        private static void input_panel_show_on_demand_set(System.IntPtr obj, System.IntPtr pd, bool ondemand)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_show_on_demand_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetInputPanelShowOnDemand(ondemand);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_input_panel_show_on_demand_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ondemand);
            }
        }

        private static efl_ui_text_input_panel_show_on_demand_set_delegate efl_ui_text_input_panel_show_on_demand_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_text_context_menu_disabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_text_context_menu_disabled_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_disabled_get_api_delegate> efl_ui_text_context_menu_disabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_disabled_get_api_delegate>(Module, "efl_ui_text_context_menu_disabled_get");

        private static bool context_menu_disabled_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_context_menu_disabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetContextMenuDisabled();
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
                return efl_ui_text_context_menu_disabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_context_menu_disabled_get_delegate efl_ui_text_context_menu_disabled_get_static_delegate;

        
        private delegate void efl_ui_text_context_menu_disabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool disabled);

        
        public delegate void efl_ui_text_context_menu_disabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool disabled);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_disabled_set_api_delegate> efl_ui_text_context_menu_disabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_disabled_set_api_delegate>(Module, "efl_ui_text_context_menu_disabled_set");

        private static void context_menu_disabled_set(System.IntPtr obj, System.IntPtr pd, bool disabled)
        {
            Eina.Log.Debug("function efl_ui_text_context_menu_disabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetContextMenuDisabled(disabled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_context_menu_disabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), disabled);
            }
        }

        private static efl_ui_text_context_menu_disabled_set_delegate efl_ui_text_context_menu_disabled_set_static_delegate;

        
        private delegate Efl.Ui.SelectionFormat efl_ui_text_cnp_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.SelectionFormat efl_ui_text_cnp_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_cnp_mode_get_api_delegate> efl_ui_text_cnp_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_cnp_mode_get_api_delegate>(Module, "efl_ui_text_cnp_mode_get");

        private static Efl.Ui.SelectionFormat cnp_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_cnp_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.SelectionFormat _ret_var = default(Efl.Ui.SelectionFormat);
                try
                {
                    _ret_var = ((Text)ws.Target).GetCnpMode();
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
                return efl_ui_text_cnp_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_cnp_mode_get_delegate efl_ui_text_cnp_mode_get_static_delegate;

        
        private delegate void efl_ui_text_cnp_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format);

        
        public delegate void efl_ui_text_cnp_mode_set_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionFormat format);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_cnp_mode_set_api_delegate> efl_ui_text_cnp_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_cnp_mode_set_api_delegate>(Module, "efl_ui_text_cnp_mode_set");

        private static void cnp_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionFormat format)
        {
            Eina.Log.Debug("function efl_ui_text_cnp_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetCnpMode(format);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_cnp_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), format);
            }
        }

        private static efl_ui_text_cnp_mode_set_delegate efl_ui_text_cnp_mode_set_static_delegate;

        
        private delegate Elm.Input.Panel.Lang efl_ui_text_input_panel_language_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Elm.Input.Panel.Lang efl_ui_text_input_panel_language_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_language_get_api_delegate> efl_ui_text_input_panel_language_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_language_get_api_delegate>(Module, "efl_ui_text_input_panel_language_get");

        private static Elm.Input.Panel.Lang input_panel_language_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_language_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Elm.Input.Panel.Lang _ret_var = default(Elm.Input.Panel.Lang);
                try
                {
                    _ret_var = ((Text)ws.Target).GetInputPanelLanguage();
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
                return efl_ui_text_input_panel_language_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_input_panel_language_get_delegate efl_ui_text_input_panel_language_get_static_delegate;

        
        private delegate void efl_ui_text_input_panel_language_set_delegate(System.IntPtr obj, System.IntPtr pd,  Elm.Input.Panel.Lang lang);

        
        public delegate void efl_ui_text_input_panel_language_set_api_delegate(System.IntPtr obj,  Elm.Input.Panel.Lang lang);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_language_set_api_delegate> efl_ui_text_input_panel_language_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_language_set_api_delegate>(Module, "efl_ui_text_input_panel_language_set");

        private static void input_panel_language_set(System.IntPtr obj, System.IntPtr pd, Elm.Input.Panel.Lang lang)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_language_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetInputPanelLanguage(lang);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_input_panel_language_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), lang);
            }
        }

        private static efl_ui_text_input_panel_language_set_delegate efl_ui_text_input_panel_language_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_text_selection_handler_disabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_text_selection_handler_disabled_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_selection_handler_disabled_get_api_delegate> efl_ui_text_selection_handler_disabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_selection_handler_disabled_get_api_delegate>(Module, "efl_ui_text_selection_handler_disabled_get");

        private static bool selection_handler_disabled_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_selection_handler_disabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetSelectionHandlerDisabled();
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
                return efl_ui_text_selection_handler_disabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_selection_handler_disabled_get_delegate efl_ui_text_selection_handler_disabled_get_static_delegate;

        
        private delegate void efl_ui_text_selection_handler_disabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool disabled);

        
        public delegate void efl_ui_text_selection_handler_disabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool disabled);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_selection_handler_disabled_set_api_delegate> efl_ui_text_selection_handler_disabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_selection_handler_disabled_set_api_delegate>(Module, "efl_ui_text_selection_handler_disabled_set");

        private static void selection_handler_disabled_set(System.IntPtr obj, System.IntPtr pd, bool disabled)
        {
            Eina.Log.Debug("function efl_ui_text_selection_handler_disabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetSelectionHandlerDisabled(disabled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_selection_handler_disabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), disabled);
            }
        }

        private static efl_ui_text_selection_handler_disabled_set_delegate efl_ui_text_selection_handler_disabled_set_static_delegate;

        
        private delegate int efl_ui_text_input_panel_layout_variation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_text_input_panel_layout_variation_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_variation_get_api_delegate> efl_ui_text_input_panel_layout_variation_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_variation_get_api_delegate>(Module, "efl_ui_text_input_panel_layout_variation_get");

        private static int input_panel_layout_variation_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_layout_variation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).GetInputPanelLayoutVariation();
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
                return efl_ui_text_input_panel_layout_variation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_input_panel_layout_variation_get_delegate efl_ui_text_input_panel_layout_variation_get_static_delegate;

        
        private delegate void efl_ui_text_input_panel_layout_variation_set_delegate(System.IntPtr obj, System.IntPtr pd,  int variation);

        
        public delegate void efl_ui_text_input_panel_layout_variation_set_api_delegate(System.IntPtr obj,  int variation);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_variation_set_api_delegate> efl_ui_text_input_panel_layout_variation_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_variation_set_api_delegate>(Module, "efl_ui_text_input_panel_layout_variation_set");

        private static void input_panel_layout_variation_set(System.IntPtr obj, System.IntPtr pd, int variation)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_layout_variation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetInputPanelLayoutVariation(variation);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_input_panel_layout_variation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), variation);
            }
        }

        private static efl_ui_text_input_panel_layout_variation_set_delegate efl_ui_text_input_panel_layout_variation_set_static_delegate;

        
        private delegate Elm.Autocapital.Type efl_ui_text_autocapital_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Elm.Autocapital.Type efl_ui_text_autocapital_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_autocapital_type_get_api_delegate> efl_ui_text_autocapital_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_autocapital_type_get_api_delegate>(Module, "efl_ui_text_autocapital_type_get");

        private static Elm.Autocapital.Type autocapital_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_autocapital_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Elm.Autocapital.Type _ret_var = default(Elm.Autocapital.Type);
                try
                {
                    _ret_var = ((Text)ws.Target).GetAutocapitalType();
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
                return efl_ui_text_autocapital_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_autocapital_type_get_delegate efl_ui_text_autocapital_type_get_static_delegate;

        
        private delegate void efl_ui_text_autocapital_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Elm.Autocapital.Type autocapital_type);

        
        public delegate void efl_ui_text_autocapital_type_set_api_delegate(System.IntPtr obj,  Elm.Autocapital.Type autocapital_type);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_autocapital_type_set_api_delegate> efl_ui_text_autocapital_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_autocapital_type_set_api_delegate>(Module, "efl_ui_text_autocapital_type_set");

        private static void autocapital_type_set(System.IntPtr obj, System.IntPtr pd, Elm.Autocapital.Type autocapital_type)
        {
            Eina.Log.Debug("function efl_ui_text_autocapital_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetAutocapitalType(autocapital_type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_autocapital_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), autocapital_type);
            }
        }

        private static efl_ui_text_autocapital_type_set_delegate efl_ui_text_autocapital_type_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_text_password_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_text_password_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_password_mode_get_api_delegate> efl_ui_text_password_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_password_mode_get_api_delegate>(Module, "efl_ui_text_password_mode_get");

        private static bool password_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_password_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetPasswordMode();
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
                return efl_ui_text_password_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_password_mode_get_delegate efl_ui_text_password_mode_get_static_delegate;

        
        private delegate void efl_ui_text_password_mode_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool password);

        
        public delegate void efl_ui_text_password_mode_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool password);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_password_mode_set_api_delegate> efl_ui_text_password_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_password_mode_set_api_delegate>(Module, "efl_ui_text_password_mode_set");

        private static void password_mode_set(System.IntPtr obj, System.IntPtr pd, bool password)
        {
            Eina.Log.Debug("function efl_ui_text_password_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetPasswordMode(password);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_password_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), password);
            }
        }

        private static efl_ui_text_password_mode_set_delegate efl_ui_text_password_mode_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_text_input_panel_return_key_disabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_text_input_panel_return_key_disabled_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_disabled_get_api_delegate> efl_ui_text_input_panel_return_key_disabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_disabled_get_api_delegate>(Module, "efl_ui_text_input_panel_return_key_disabled_get");

        private static bool input_panel_return_key_disabled_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_return_key_disabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetInputPanelReturnKeyDisabled();
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
                return efl_ui_text_input_panel_return_key_disabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_input_panel_return_key_disabled_get_delegate efl_ui_text_input_panel_return_key_disabled_get_static_delegate;

        
        private delegate void efl_ui_text_input_panel_return_key_disabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool disabled);

        
        public delegate void efl_ui_text_input_panel_return_key_disabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool disabled);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_disabled_set_api_delegate> efl_ui_text_input_panel_return_key_disabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_disabled_set_api_delegate>(Module, "efl_ui_text_input_panel_return_key_disabled_set");

        private static void input_panel_return_key_disabled_set(System.IntPtr obj, System.IntPtr pd, bool disabled)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_return_key_disabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetInputPanelReturnKeyDisabled(disabled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_input_panel_return_key_disabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), disabled);
            }
        }

        private static efl_ui_text_input_panel_return_key_disabled_set_delegate efl_ui_text_input_panel_return_key_disabled_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_text_prediction_allow_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_text_prediction_allow_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_prediction_allow_get_api_delegate> efl_ui_text_prediction_allow_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_prediction_allow_get_api_delegate>(Module, "efl_ui_text_prediction_allow_get");

        private static bool prediction_allow_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_prediction_allow_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetPredictionAllow();
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
                return efl_ui_text_prediction_allow_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_prediction_allow_get_delegate efl_ui_text_prediction_allow_get_static_delegate;

        
        private delegate void efl_ui_text_prediction_allow_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool prediction);

        
        public delegate void efl_ui_text_prediction_allow_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool prediction);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_prediction_allow_set_api_delegate> efl_ui_text_prediction_allow_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_prediction_allow_set_api_delegate>(Module, "efl_ui_text_prediction_allow_set");

        private static void prediction_allow_set(System.IntPtr obj, System.IntPtr pd, bool prediction)
        {
            Eina.Log.Debug("function efl_ui_text_prediction_allow_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetPredictionAllow(prediction);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_prediction_allow_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), prediction);
            }
        }

        private static efl_ui_text_prediction_allow_set_delegate efl_ui_text_prediction_allow_set_static_delegate;

        
        private delegate Elm.Input.Hints efl_ui_text_input_hint_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Elm.Input.Hints efl_ui_text_input_hint_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_hint_get_api_delegate> efl_ui_text_input_hint_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_hint_get_api_delegate>(Module, "efl_ui_text_input_hint_get");

        private static Elm.Input.Hints input_hint_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_input_hint_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Elm.Input.Hints _ret_var = default(Elm.Input.Hints);
                try
                {
                    _ret_var = ((Text)ws.Target).GetInputHint();
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
                return efl_ui_text_input_hint_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_input_hint_get_delegate efl_ui_text_input_hint_get_static_delegate;

        
        private delegate void efl_ui_text_input_hint_set_delegate(System.IntPtr obj, System.IntPtr pd,  Elm.Input.Hints hints);

        
        public delegate void efl_ui_text_input_hint_set_api_delegate(System.IntPtr obj,  Elm.Input.Hints hints);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_hint_set_api_delegate> efl_ui_text_input_hint_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_hint_set_api_delegate>(Module, "efl_ui_text_input_hint_set");

        private static void input_hint_set(System.IntPtr obj, System.IntPtr pd, Elm.Input.Hints hints)
        {
            Eina.Log.Debug("function efl_ui_text_input_hint_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetInputHint(hints);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_input_hint_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), hints);
            }
        }

        private static efl_ui_text_input_hint_set_delegate efl_ui_text_input_hint_set_static_delegate;

        
        private delegate Elm.Input.Panel.Layout efl_ui_text_input_panel_layout_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Elm.Input.Panel.Layout efl_ui_text_input_panel_layout_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_get_api_delegate> efl_ui_text_input_panel_layout_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_get_api_delegate>(Module, "efl_ui_text_input_panel_layout_get");

        private static Elm.Input.Panel.Layout input_panel_layout_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_layout_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Elm.Input.Panel.Layout _ret_var = default(Elm.Input.Panel.Layout);
                try
                {
                    _ret_var = ((Text)ws.Target).GetInputPanelLayout();
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
                return efl_ui_text_input_panel_layout_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_input_panel_layout_get_delegate efl_ui_text_input_panel_layout_get_static_delegate;

        
        private delegate void efl_ui_text_input_panel_layout_set_delegate(System.IntPtr obj, System.IntPtr pd,  Elm.Input.Panel.Layout layout);

        
        public delegate void efl_ui_text_input_panel_layout_set_api_delegate(System.IntPtr obj,  Elm.Input.Panel.Layout layout);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_set_api_delegate> efl_ui_text_input_panel_layout_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_layout_set_api_delegate>(Module, "efl_ui_text_input_panel_layout_set");

        private static void input_panel_layout_set(System.IntPtr obj, System.IntPtr pd, Elm.Input.Panel.Layout layout)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_layout_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetInputPanelLayout(layout);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_input_panel_layout_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), layout);
            }
        }

        private static efl_ui_text_input_panel_layout_set_delegate efl_ui_text_input_panel_layout_set_static_delegate;

        
        private delegate Elm.Input.Panel.ReturnKey.Type efl_ui_text_input_panel_return_key_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Elm.Input.Panel.ReturnKey.Type efl_ui_text_input_panel_return_key_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_type_get_api_delegate> efl_ui_text_input_panel_return_key_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_type_get_api_delegate>(Module, "efl_ui_text_input_panel_return_key_type_get");

        private static Elm.Input.Panel.ReturnKey.Type input_panel_return_key_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_return_key_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Elm.Input.Panel.ReturnKey.Type _ret_var = default(Elm.Input.Panel.ReturnKey.Type);
                try
                {
                    _ret_var = ((Text)ws.Target).GetInputPanelReturnKeyType();
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
                return efl_ui_text_input_panel_return_key_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_input_panel_return_key_type_get_delegate efl_ui_text_input_panel_return_key_type_get_static_delegate;

        
        private delegate void efl_ui_text_input_panel_return_key_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Elm.Input.Panel.ReturnKey.Type return_key_type);

        
        public delegate void efl_ui_text_input_panel_return_key_type_set_api_delegate(System.IntPtr obj,  Elm.Input.Panel.ReturnKey.Type return_key_type);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_type_set_api_delegate> efl_ui_text_input_panel_return_key_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_type_set_api_delegate>(Module, "efl_ui_text_input_panel_return_key_type_set");

        private static void input_panel_return_key_type_set(System.IntPtr obj, System.IntPtr pd, Elm.Input.Panel.ReturnKey.Type return_key_type)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_return_key_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetInputPanelReturnKeyType(return_key_type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_input_panel_return_key_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), return_key_type);
            }
        }

        private static efl_ui_text_input_panel_return_key_type_set_delegate efl_ui_text_input_panel_return_key_type_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_text_input_panel_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_text_input_panel_enabled_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_enabled_get_api_delegate> efl_ui_text_input_panel_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_enabled_get_api_delegate>(Module, "efl_ui_text_input_panel_enabled_get");

        private static bool input_panel_enabled_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_enabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetInputPanelEnabled();
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
                return efl_ui_text_input_panel_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_input_panel_enabled_get_delegate efl_ui_text_input_panel_enabled_get_static_delegate;

        
        private delegate void efl_ui_text_input_panel_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enabled);

        
        public delegate void efl_ui_text_input_panel_enabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enabled);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_enabled_set_api_delegate> efl_ui_text_input_panel_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_enabled_set_api_delegate>(Module, "efl_ui_text_input_panel_enabled_set");

        private static void input_panel_enabled_set(System.IntPtr obj, System.IntPtr pd, bool enabled)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_enabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetInputPanelEnabled(enabled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_input_panel_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enabled);
            }
        }

        private static efl_ui_text_input_panel_enabled_set_delegate efl_ui_text_input_panel_enabled_set_static_delegate;

        
        private delegate void efl_ui_text_input_panel_return_key_autoenabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enabled);

        
        public delegate void efl_ui_text_input_panel_return_key_autoenabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enabled);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_autoenabled_set_api_delegate> efl_ui_text_input_panel_return_key_autoenabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_return_key_autoenabled_set_api_delegate>(Module, "efl_ui_text_input_panel_return_key_autoenabled_set");

        private static void input_panel_return_key_autoenabled_set(System.IntPtr obj, System.IntPtr pd, bool enabled)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_return_key_autoenabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetInputPanelReturnKeyAutoenabled(enabled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_input_panel_return_key_autoenabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enabled);
            }
        }

        private static efl_ui_text_input_panel_return_key_autoenabled_set_delegate efl_ui_text_input_panel_return_key_autoenabled_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.ITextFactory efl_ui_text_item_factory_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.ITextFactory efl_ui_text_item_factory_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_item_factory_get_api_delegate> efl_ui_text_item_factory_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_item_factory_get_api_delegate>(Module, "efl_ui_text_item_factory_get");

        private static Efl.Canvas.ITextFactory item_factory_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_item_factory_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.ITextFactory _ret_var = default(Efl.Canvas.ITextFactory);
                try
                {
                    _ret_var = ((Text)ws.Target).GetItemFactory();
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
                return efl_ui_text_item_factory_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_item_factory_get_delegate efl_ui_text_item_factory_get_static_delegate;

        
        private delegate void efl_ui_text_item_factory_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.ITextFactory item_factory);

        
        public delegate void efl_ui_text_item_factory_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.ITextFactory item_factory);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_item_factory_set_api_delegate> efl_ui_text_item_factory_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_item_factory_set_api_delegate>(Module, "efl_ui_text_item_factory_set");

        private static void item_factory_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.ITextFactory item_factory)
        {
            Eina.Log.Debug("function efl_ui_text_item_factory_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetItemFactory(item_factory);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_text_item_factory_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), item_factory);
            }
        }

        private static efl_ui_text_item_factory_set_delegate efl_ui_text_item_factory_set_static_delegate;

        
        private delegate void efl_ui_text_input_panel_show_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_text_input_panel_show_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_show_api_delegate> efl_ui_text_input_panel_show_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_show_api_delegate>(Module, "efl_ui_text_input_panel_show");

        private static void input_panel_show(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_show was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Text)ws.Target).ShowInputPanel();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_text_input_panel_show_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_input_panel_show_delegate efl_ui_text_input_panel_show_static_delegate;

        
        private delegate void efl_ui_text_selection_copy_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_text_selection_copy_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_selection_copy_api_delegate> efl_ui_text_selection_copy_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_selection_copy_api_delegate>(Module, "efl_ui_text_selection_copy");

        private static void selection_copy(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_selection_copy was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Text)ws.Target).SelectionCopy();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_text_selection_copy_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_selection_copy_delegate efl_ui_text_selection_copy_static_delegate;

        
        private delegate void efl_ui_text_context_menu_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_text_context_menu_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_clear_api_delegate> efl_ui_text_context_menu_clear_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_clear_api_delegate>(Module, "efl_ui_text_context_menu_clear");

        private static void context_menu_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_context_menu_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Text)ws.Target).ClearContextMenu();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_text_context_menu_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_context_menu_clear_delegate efl_ui_text_context_menu_clear_static_delegate;

        
        private delegate void efl_ui_text_input_panel_imdata_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr data,  int len);

        
        public delegate void efl_ui_text_input_panel_imdata_set_api_delegate(System.IntPtr obj,  System.IntPtr data,  int len);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_imdata_set_api_delegate> efl_ui_text_input_panel_imdata_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_imdata_set_api_delegate>(Module, "efl_ui_text_input_panel_imdata_set");

        private static void input_panel_imdata_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr data, int len)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_imdata_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Text)ws.Target).SetInputPanelImdata(data, len);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_text_input_panel_imdata_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), data, len);
            }
        }

        private static efl_ui_text_input_panel_imdata_set_delegate efl_ui_text_input_panel_imdata_set_static_delegate;

        
        private delegate void efl_ui_text_input_panel_imdata_get_delegate(System.IntPtr obj, System.IntPtr pd,  ref System.IntPtr data,  out int len);

        
        public delegate void efl_ui_text_input_panel_imdata_get_api_delegate(System.IntPtr obj,  ref System.IntPtr data,  out int len);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_imdata_get_api_delegate> efl_ui_text_input_panel_imdata_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_imdata_get_api_delegate>(Module, "efl_ui_text_input_panel_imdata_get");

        private static void input_panel_imdata_get(System.IntPtr obj, System.IntPtr pd, ref System.IntPtr data, out int len)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_imdata_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                len = default(int);                            
                try
                {
                    ((Text)ws.Target).GetInputPanelImdata(ref data, out len);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_text_input_panel_imdata_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref data, out len);
            }
        }

        private static efl_ui_text_input_panel_imdata_get_delegate efl_ui_text_input_panel_imdata_get_static_delegate;

        
        private delegate void efl_ui_text_selection_paste_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_text_selection_paste_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_selection_paste_api_delegate> efl_ui_text_selection_paste_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_selection_paste_api_delegate>(Module, "efl_ui_text_selection_paste");

        private static void selection_paste(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_selection_paste was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Text)ws.Target).SelectionPaste();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_text_selection_paste_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_selection_paste_delegate efl_ui_text_selection_paste_static_delegate;

        
        private delegate void efl_ui_text_input_panel_hide_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_text_input_panel_hide_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_hide_api_delegate> efl_ui_text_input_panel_hide_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_input_panel_hide_api_delegate>(Module, "efl_ui_text_input_panel_hide");

        private static void input_panel_hide(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_input_panel_hide was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Text)ws.Target).HideInputPanel();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_text_input_panel_hide_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_input_panel_hide_delegate efl_ui_text_input_panel_hide_static_delegate;

        
        private delegate void efl_ui_text_cursor_selection_end_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_text_cursor_selection_end_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_cursor_selection_end_api_delegate> efl_ui_text_cursor_selection_end_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_cursor_selection_end_api_delegate>(Module, "efl_ui_text_cursor_selection_end");

        private static void cursor_selection_end(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_cursor_selection_end was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Text)ws.Target).CursorSelectionEnd();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_text_cursor_selection_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_cursor_selection_end_delegate efl_ui_text_cursor_selection_end_static_delegate;

        
        private delegate void efl_ui_text_selection_cut_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_text_selection_cut_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_selection_cut_api_delegate> efl_ui_text_selection_cut_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_selection_cut_api_delegate>(Module, "efl_ui_text_selection_cut");

        private static void selection_cut(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_selection_cut was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Text)ws.Target).SelectionCut();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_text_selection_cut_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_selection_cut_delegate efl_ui_text_selection_cut_static_delegate;

        
        private delegate void efl_ui_text_context_menu_item_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String icon_file,  Elm.Icon.Type icon_type,  EvasSmartCb func,  System.IntPtr data);

        
        public delegate void efl_ui_text_context_menu_item_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String icon_file,  Elm.Icon.Type icon_type,  EvasSmartCb func,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_item_add_api_delegate> efl_ui_text_context_menu_item_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_context_menu_item_add_api_delegate>(Module, "efl_ui_text_context_menu_item_add");

        private static void context_menu_item_add(System.IntPtr obj, System.IntPtr pd, System.String label, System.String icon_file, Elm.Icon.Type icon_type, EvasSmartCb func, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_ui_text_context_menu_item_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                    
                try
                {
                    ((Text)ws.Target).AddContextMenuItem(label, icon_file, icon_type, func, data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_ui_text_context_menu_item_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), label, icon_file, icon_type, func, data);
            }
        }

        private static efl_ui_text_context_menu_item_add_delegate efl_ui_text_context_menu_item_add_static_delegate;

        
        private delegate Efl.TextCursorCursor efl_ui_text_cursor_new_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextCursorCursor efl_ui_text_cursor_new_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_text_cursor_new_api_delegate> efl_ui_text_cursor_new_ptr = new Efl.Eo.FunctionWrapper<efl_ui_text_cursor_new_api_delegate>(Module, "efl_ui_text_cursor_new");

        private static Efl.TextCursorCursor cursor_new(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_text_cursor_new was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextCursorCursor _ret_var = default(Efl.TextCursorCursor);
                try
                {
                    _ret_var = ((Text)ws.Target).NewCursor();
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
                return efl_ui_text_cursor_new_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_text_cursor_new_delegate efl_ui_text_cursor_new_static_delegate;

        
        private delegate Eina.File efl_file_mmap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.File efl_file_mmap_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate> efl_file_mmap_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate>(Module, "efl_file_mmap_get");

        private static Eina.File mmap_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_mmap_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.File _ret_var = default(Eina.File);
                try
                {
                    _ret_var = ((Text)ws.Target).GetMmap();
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
                return efl_file_mmap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_mmap_get_delegate efl_file_mmap_get_static_delegate;

        
        private delegate Eina.Error efl_file_mmap_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.File f);

        
        public delegate Eina.Error efl_file_mmap_set_api_delegate(System.IntPtr obj,  Eina.File f);

        public static Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate> efl_file_mmap_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate>(Module, "efl_file_mmap_set");

        private static Eina.Error mmap_set(System.IntPtr obj, System.IntPtr pd, Eina.File f)
        {
            Eina.Log.Debug("function efl_file_mmap_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((Text)ws.Target).SetMmap(f);
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
                return efl_file_mmap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), f);
            }
        }

        private static efl_file_mmap_set_delegate efl_file_mmap_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_file_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_file_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_get_api_delegate> efl_file_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_get_api_delegate>(Module, "efl_file_get");

        private static System.String file_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFile();
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
                return efl_file_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_get_delegate efl_file_get_static_delegate;

        
        private delegate Eina.Error efl_file_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String file);

        
        public delegate Eina.Error efl_file_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String file);

        public static Efl.Eo.FunctionWrapper<efl_file_set_api_delegate> efl_file_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_set_api_delegate>(Module, "efl_file_set");

        private static Eina.Error file_set(System.IntPtr obj, System.IntPtr pd, System.String file)
        {
            Eina.Log.Debug("function efl_file_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((Text)ws.Target).SetFile(file);
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
                return efl_file_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), file);
            }
        }

        private static efl_file_set_delegate efl_file_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_file_key_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_file_key_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate> efl_file_key_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate>(Module, "efl_file_key_get");

        private static System.String key_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_key_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetKey();
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
                return efl_file_key_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_key_get_delegate efl_file_key_get_static_delegate;

        
        private delegate void efl_file_key_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        
        public delegate void efl_file_key_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate> efl_file_key_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate>(Module, "efl_file_key_set");

        private static void key_set(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            Eina.Log.Debug("function efl_file_key_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetKey(key);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_file_key_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_file_key_set_delegate efl_file_key_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_file_loaded_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_file_loaded_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate> efl_file_loaded_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate>(Module, "efl_file_loaded_get");

        private static bool loaded_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_loaded_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetLoaded();
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
                return efl_file_loaded_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_loaded_get_delegate efl_file_loaded_get_static_delegate;

        
        private delegate Eina.Error efl_file_load_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Error efl_file_load_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_load_api_delegate> efl_file_load_ptr = new Efl.Eo.FunctionWrapper<efl_file_load_api_delegate>(Module, "efl_file_load");

        private static Eina.Error load(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_load was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((Text)ws.Target).Load();
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
                return efl_file_load_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_load_delegate efl_file_load_static_delegate;

        
        private delegate void efl_file_unload_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_file_unload_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate> efl_file_unload_ptr = new Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate>(Module, "efl_file_unload");

        private static void unload(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_unload was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Text)ws.Target).Unload();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_file_unload_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_unload_delegate efl_file_unload_static_delegate;

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
                    _ret_var = ((Text)ws.Target).GetText();
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
                    ((Text)ws.Target).SetText(text);
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

        
        private delegate void efl_text_font_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String font,  out Efl.Font.Size size);

        
        public delegate void efl_text_font_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String font,  out Efl.Font.Size size);

        public static Efl.Eo.FunctionWrapper<efl_text_font_get_api_delegate> efl_text_font_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_get_api_delegate>(Module, "efl_text_font_get");

        private static void font_get(System.IntPtr obj, System.IntPtr pd, out System.String font, out Efl.Font.Size size)
        {
            Eina.Log.Debug("function efl_text_font_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        System.String _out_font = default(System.String);
        size = default(Efl.Font.Size);                            
                try
                {
                    ((Text)ws.Target).GetFont(out _out_font, out size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        font = _out_font;
                                
            }
            else
            {
                efl_text_font_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out font, out size);
            }
        }

        private static efl_text_font_get_delegate efl_text_font_get_static_delegate;

        
        private delegate void efl_text_font_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font,  Efl.Font.Size size);

        
        public delegate void efl_text_font_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font,  Efl.Font.Size size);

        public static Efl.Eo.FunctionWrapper<efl_text_font_set_api_delegate> efl_text_font_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_set_api_delegate>(Module, "efl_text_font_set");

        private static void font_set(System.IntPtr obj, System.IntPtr pd, System.String font, Efl.Font.Size size)
        {
            Eina.Log.Debug("function efl_text_font_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Text)ws.Target).SetFont(font, size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_text_font_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), font, size);
            }
        }

        private static efl_text_font_set_delegate efl_text_font_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_font_source_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_font_source_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_source_get_api_delegate> efl_text_font_source_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_source_get_api_delegate>(Module, "efl_text_font_source_get");

        private static System.String font_source_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_source_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontSource();
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
                return efl_text_font_source_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_source_get_delegate efl_text_font_source_get_static_delegate;

        
        private delegate void efl_text_font_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font_source);

        
        public delegate void efl_text_font_source_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font_source);

        public static Efl.Eo.FunctionWrapper<efl_text_font_source_set_api_delegate> efl_text_font_source_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_source_set_api_delegate>(Module, "efl_text_font_source_set");

        private static void font_source_set(System.IntPtr obj, System.IntPtr pd, System.String font_source)
        {
            Eina.Log.Debug("function efl_text_font_source_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontSource(font_source);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_source_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), font_source);
            }
        }

        private static efl_text_font_source_set_delegate efl_text_font_source_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_font_fallbacks_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_font_fallbacks_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_get_api_delegate> efl_text_font_fallbacks_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_get_api_delegate>(Module, "efl_text_font_fallbacks_get");

        private static System.String font_fallbacks_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_fallbacks_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontFallbacks();
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
                return efl_text_font_fallbacks_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_fallbacks_get_delegate efl_text_font_fallbacks_get_static_delegate;

        
        private delegate void efl_text_font_fallbacks_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font_fallbacks);

        
        public delegate void efl_text_font_fallbacks_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String font_fallbacks);

        public static Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_set_api_delegate> efl_text_font_fallbacks_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_fallbacks_set_api_delegate>(Module, "efl_text_font_fallbacks_set");

        private static void font_fallbacks_set(System.IntPtr obj, System.IntPtr pd, System.String font_fallbacks)
        {
            Eina.Log.Debug("function efl_text_font_fallbacks_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontFallbacks(font_fallbacks);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_fallbacks_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), font_fallbacks);
            }
        }

        private static efl_text_font_fallbacks_set_delegate efl_text_font_fallbacks_set_static_delegate;

        
        private delegate Efl.TextFontWeight efl_text_font_weight_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextFontWeight efl_text_font_weight_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_weight_get_api_delegate> efl_text_font_weight_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_weight_get_api_delegate>(Module, "efl_text_font_weight_get");

        private static Efl.TextFontWeight font_weight_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_weight_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextFontWeight _ret_var = default(Efl.TextFontWeight);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontWeight();
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
                return efl_text_font_weight_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_weight_get_delegate efl_text_font_weight_get_static_delegate;

        
        private delegate void efl_text_font_weight_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontWeight font_weight);

        
        public delegate void efl_text_font_weight_set_api_delegate(System.IntPtr obj,  Efl.TextFontWeight font_weight);

        public static Efl.Eo.FunctionWrapper<efl_text_font_weight_set_api_delegate> efl_text_font_weight_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_weight_set_api_delegate>(Module, "efl_text_font_weight_set");

        private static void font_weight_set(System.IntPtr obj, System.IntPtr pd, Efl.TextFontWeight font_weight)
        {
            Eina.Log.Debug("function efl_text_font_weight_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontWeight(font_weight);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_weight_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), font_weight);
            }
        }

        private static efl_text_font_weight_set_delegate efl_text_font_weight_set_static_delegate;

        
        private delegate Efl.TextFontSlant efl_text_font_slant_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextFontSlant efl_text_font_slant_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_slant_get_api_delegate> efl_text_font_slant_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_slant_get_api_delegate>(Module, "efl_text_font_slant_get");

        private static Efl.TextFontSlant font_slant_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_slant_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextFontSlant _ret_var = default(Efl.TextFontSlant);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontSlant();
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
                return efl_text_font_slant_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_slant_get_delegate efl_text_font_slant_get_static_delegate;

        
        private delegate void efl_text_font_slant_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontSlant style);

        
        public delegate void efl_text_font_slant_set_api_delegate(System.IntPtr obj,  Efl.TextFontSlant style);

        public static Efl.Eo.FunctionWrapper<efl_text_font_slant_set_api_delegate> efl_text_font_slant_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_slant_set_api_delegate>(Module, "efl_text_font_slant_set");

        private static void font_slant_set(System.IntPtr obj, System.IntPtr pd, Efl.TextFontSlant style)
        {
            Eina.Log.Debug("function efl_text_font_slant_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontSlant(style);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_slant_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), style);
            }
        }

        private static efl_text_font_slant_set_delegate efl_text_font_slant_set_static_delegate;

        
        private delegate Efl.TextFontWidth efl_text_font_width_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextFontWidth efl_text_font_width_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_width_get_api_delegate> efl_text_font_width_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_width_get_api_delegate>(Module, "efl_text_font_width_get");

        private static Efl.TextFontWidth font_width_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_width_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextFontWidth _ret_var = default(Efl.TextFontWidth);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontWidth();
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
                return efl_text_font_width_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_width_get_delegate efl_text_font_width_get_static_delegate;

        
        private delegate void efl_text_font_width_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontWidth width);

        
        public delegate void efl_text_font_width_set_api_delegate(System.IntPtr obj,  Efl.TextFontWidth width);

        public static Efl.Eo.FunctionWrapper<efl_text_font_width_set_api_delegate> efl_text_font_width_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_width_set_api_delegate>(Module, "efl_text_font_width_set");

        private static void font_width_set(System.IntPtr obj, System.IntPtr pd, Efl.TextFontWidth width)
        {
            Eina.Log.Debug("function efl_text_font_width_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontWidth(width);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_width_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), width);
            }
        }

        private static efl_text_font_width_set_delegate efl_text_font_width_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_font_lang_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_font_lang_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_lang_get_api_delegate> efl_text_font_lang_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_lang_get_api_delegate>(Module, "efl_text_font_lang_get");

        private static System.String font_lang_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_lang_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontLang();
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
                return efl_text_font_lang_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_lang_get_delegate efl_text_font_lang_get_static_delegate;

        
        private delegate void efl_text_font_lang_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String lang);

        
        public delegate void efl_text_font_lang_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String lang);

        public static Efl.Eo.FunctionWrapper<efl_text_font_lang_set_api_delegate> efl_text_font_lang_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_lang_set_api_delegate>(Module, "efl_text_font_lang_set");

        private static void font_lang_set(System.IntPtr obj, System.IntPtr pd, System.String lang)
        {
            Eina.Log.Debug("function efl_text_font_lang_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontLang(lang);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_lang_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), lang);
            }
        }

        private static efl_text_font_lang_set_delegate efl_text_font_lang_set_static_delegate;

        
        private delegate Efl.TextFontBitmapScalable efl_text_font_bitmap_scalable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextFontBitmapScalable efl_text_font_bitmap_scalable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_get_api_delegate> efl_text_font_bitmap_scalable_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_get_api_delegate>(Module, "efl_text_font_bitmap_scalable_get");

        private static Efl.TextFontBitmapScalable font_bitmap_scalable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_font_bitmap_scalable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextFontBitmapScalable _ret_var = default(Efl.TextFontBitmapScalable);
                try
                {
                    _ret_var = ((Text)ws.Target).GetFontBitmapScalable();
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
                return efl_text_font_bitmap_scalable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_font_bitmap_scalable_get_delegate efl_text_font_bitmap_scalable_get_static_delegate;

        
        private delegate void efl_text_font_bitmap_scalable_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextFontBitmapScalable scalable);

        
        public delegate void efl_text_font_bitmap_scalable_set_api_delegate(System.IntPtr obj,  Efl.TextFontBitmapScalable scalable);

        public static Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_set_api_delegate> efl_text_font_bitmap_scalable_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_font_bitmap_scalable_set_api_delegate>(Module, "efl_text_font_bitmap_scalable_set");

        private static void font_bitmap_scalable_set(System.IntPtr obj, System.IntPtr pd, Efl.TextFontBitmapScalable scalable)
        {
            Eina.Log.Debug("function efl_text_font_bitmap_scalable_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetFontBitmapScalable(scalable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_font_bitmap_scalable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), scalable);
            }
        }

        private static efl_text_font_bitmap_scalable_set_delegate efl_text_font_bitmap_scalable_set_static_delegate;

        
        private delegate double efl_text_ellipsis_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_text_ellipsis_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_ellipsis_get_api_delegate> efl_text_ellipsis_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_ellipsis_get_api_delegate>(Module, "efl_text_ellipsis_get");

        private static double ellipsis_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_ellipsis_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Text)ws.Target).GetEllipsis();
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
                return efl_text_ellipsis_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_ellipsis_get_delegate efl_text_ellipsis_get_static_delegate;

        
        private delegate void efl_text_ellipsis_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        public delegate void efl_text_ellipsis_set_api_delegate(System.IntPtr obj,  double value);

        public static Efl.Eo.FunctionWrapper<efl_text_ellipsis_set_api_delegate> efl_text_ellipsis_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_ellipsis_set_api_delegate>(Module, "efl_text_ellipsis_set");

        private static void ellipsis_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            Eina.Log.Debug("function efl_text_ellipsis_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetEllipsis(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_ellipsis_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_ellipsis_set_delegate efl_text_ellipsis_set_static_delegate;

        
        private delegate Efl.TextFormatWrap efl_text_wrap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextFormatWrap efl_text_wrap_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_wrap_get_api_delegate> efl_text_wrap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_wrap_get_api_delegate>(Module, "efl_text_wrap_get");

        private static Efl.TextFormatWrap wrap_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_wrap_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextFormatWrap _ret_var = default(Efl.TextFormatWrap);
                try
                {
                    _ret_var = ((Text)ws.Target).GetWrap();
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
                return efl_text_wrap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_wrap_get_delegate efl_text_wrap_get_static_delegate;

        
        private delegate void efl_text_wrap_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextFormatWrap wrap);

        
        public delegate void efl_text_wrap_set_api_delegate(System.IntPtr obj,  Efl.TextFormatWrap wrap);

        public static Efl.Eo.FunctionWrapper<efl_text_wrap_set_api_delegate> efl_text_wrap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_wrap_set_api_delegate>(Module, "efl_text_wrap_set");

        private static void wrap_set(System.IntPtr obj, System.IntPtr pd, Efl.TextFormatWrap wrap)
        {
            Eina.Log.Debug("function efl_text_wrap_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetWrap(wrap);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_wrap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), wrap);
            }
        }

        private static efl_text_wrap_set_delegate efl_text_wrap_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_multiline_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_multiline_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_multiline_get_api_delegate> efl_text_multiline_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_multiline_get_api_delegate>(Module, "efl_text_multiline_get");

        private static bool multiline_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_multiline_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetMultiline();
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
                return efl_text_multiline_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_multiline_get_delegate efl_text_multiline_get_static_delegate;

        
        private delegate void efl_text_multiline_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enabled);

        
        public delegate void efl_text_multiline_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enabled);

        public static Efl.Eo.FunctionWrapper<efl_text_multiline_set_api_delegate> efl_text_multiline_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_multiline_set_api_delegate>(Module, "efl_text_multiline_set");

        private static void multiline_set(System.IntPtr obj, System.IntPtr pd, bool enabled)
        {
            Eina.Log.Debug("function efl_text_multiline_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetMultiline(enabled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_multiline_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enabled);
            }
        }

        private static efl_text_multiline_set_delegate efl_text_multiline_set_static_delegate;

        
        private delegate Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextFormatHorizontalAlignmentAutoType efl_text_halign_auto_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_get_api_delegate> efl_text_halign_auto_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_get_api_delegate>(Module, "efl_text_halign_auto_type_get");

        private static Efl.TextFormatHorizontalAlignmentAutoType halign_auto_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_halign_auto_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextFormatHorizontalAlignmentAutoType _ret_var = default(Efl.TextFormatHorizontalAlignmentAutoType);
                try
                {
                    _ret_var = ((Text)ws.Target).GetHalignAutoType();
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
                return efl_text_halign_auto_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_halign_auto_type_get_delegate efl_text_halign_auto_type_get_static_delegate;

        
        private delegate void efl_text_halign_auto_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextFormatHorizontalAlignmentAutoType value);

        
        public delegate void efl_text_halign_auto_type_set_api_delegate(System.IntPtr obj,  Efl.TextFormatHorizontalAlignmentAutoType value);

        public static Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_set_api_delegate> efl_text_halign_auto_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_auto_type_set_api_delegate>(Module, "efl_text_halign_auto_type_set");

        private static void halign_auto_type_set(System.IntPtr obj, System.IntPtr pd, Efl.TextFormatHorizontalAlignmentAutoType value)
        {
            Eina.Log.Debug("function efl_text_halign_auto_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetHalignAutoType(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_halign_auto_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_halign_auto_type_set_delegate efl_text_halign_auto_type_set_static_delegate;

        
        private delegate double efl_text_halign_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_text_halign_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_halign_get_api_delegate> efl_text_halign_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_get_api_delegate>(Module, "efl_text_halign_get");

        private static double halign_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_halign_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Text)ws.Target).GetHalign();
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
                return efl_text_halign_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_halign_get_delegate efl_text_halign_get_static_delegate;

        
        private delegate void efl_text_halign_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        public delegate void efl_text_halign_set_api_delegate(System.IntPtr obj,  double value);

        public static Efl.Eo.FunctionWrapper<efl_text_halign_set_api_delegate> efl_text_halign_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_halign_set_api_delegate>(Module, "efl_text_halign_set");

        private static void halign_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            Eina.Log.Debug("function efl_text_halign_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetHalign(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_halign_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_halign_set_delegate efl_text_halign_set_static_delegate;

        
        private delegate double efl_text_valign_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_text_valign_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_valign_get_api_delegate> efl_text_valign_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_valign_get_api_delegate>(Module, "efl_text_valign_get");

        private static double valign_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_valign_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Text)ws.Target).GetValign();
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
                return efl_text_valign_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_valign_get_delegate efl_text_valign_get_static_delegate;

        
        private delegate void efl_text_valign_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        public delegate void efl_text_valign_set_api_delegate(System.IntPtr obj,  double value);

        public static Efl.Eo.FunctionWrapper<efl_text_valign_set_api_delegate> efl_text_valign_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_valign_set_api_delegate>(Module, "efl_text_valign_set");

        private static void valign_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            Eina.Log.Debug("function efl_text_valign_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetValign(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_valign_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_valign_set_delegate efl_text_valign_set_static_delegate;

        
        private delegate double efl_text_linegap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_text_linegap_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_linegap_get_api_delegate> efl_text_linegap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_linegap_get_api_delegate>(Module, "efl_text_linegap_get");

        private static double linegap_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_linegap_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Text)ws.Target).GetLinegap();
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
                return efl_text_linegap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_linegap_get_delegate efl_text_linegap_get_static_delegate;

        
        private delegate void efl_text_linegap_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        public delegate void efl_text_linegap_set_api_delegate(System.IntPtr obj,  double value);

        public static Efl.Eo.FunctionWrapper<efl_text_linegap_set_api_delegate> efl_text_linegap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_linegap_set_api_delegate>(Module, "efl_text_linegap_set");

        private static void linegap_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            Eina.Log.Debug("function efl_text_linegap_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetLinegap(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_linegap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_linegap_set_delegate efl_text_linegap_set_static_delegate;

        
        private delegate double efl_text_linerelgap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_text_linerelgap_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_linerelgap_get_api_delegate> efl_text_linerelgap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_linerelgap_get_api_delegate>(Module, "efl_text_linerelgap_get");

        private static double linerelgap_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_linerelgap_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Text)ws.Target).GetLinerelgap();
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
                return efl_text_linerelgap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_linerelgap_get_delegate efl_text_linerelgap_get_static_delegate;

        
        private delegate void efl_text_linerelgap_set_delegate(System.IntPtr obj, System.IntPtr pd,  double value);

        
        public delegate void efl_text_linerelgap_set_api_delegate(System.IntPtr obj,  double value);

        public static Efl.Eo.FunctionWrapper<efl_text_linerelgap_set_api_delegate> efl_text_linerelgap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_linerelgap_set_api_delegate>(Module, "efl_text_linerelgap_set");

        private static void linerelgap_set(System.IntPtr obj, System.IntPtr pd, double value)
        {
            Eina.Log.Debug("function efl_text_linerelgap_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetLinerelgap(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_linerelgap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_linerelgap_set_delegate efl_text_linerelgap_set_static_delegate;

        
        private delegate int efl_text_tabstops_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_text_tabstops_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_tabstops_get_api_delegate> efl_text_tabstops_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_tabstops_get_api_delegate>(Module, "efl_text_tabstops_get");

        private static int tabstops_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_tabstops_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).GetTabstops();
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
                return efl_text_tabstops_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_tabstops_get_delegate efl_text_tabstops_get_static_delegate;

        
        private delegate void efl_text_tabstops_set_delegate(System.IntPtr obj, System.IntPtr pd,  int value);

        
        public delegate void efl_text_tabstops_set_api_delegate(System.IntPtr obj,  int value);

        public static Efl.Eo.FunctionWrapper<efl_text_tabstops_set_api_delegate> efl_text_tabstops_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_tabstops_set_api_delegate>(Module, "efl_text_tabstops_set");

        private static void tabstops_set(System.IntPtr obj, System.IntPtr pd, int value)
        {
            Eina.Log.Debug("function efl_text_tabstops_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetTabstops(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_tabstops_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_text_tabstops_set_delegate efl_text_tabstops_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_password_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_password_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_password_get_api_delegate> efl_text_password_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_password_get_api_delegate>(Module, "efl_text_password_get");

        private static bool password_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_password_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetPassword();
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
                return efl_text_password_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_password_get_delegate efl_text_password_get_static_delegate;

        
        private delegate void efl_text_password_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enabled);

        
        public delegate void efl_text_password_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enabled);

        public static Efl.Eo.FunctionWrapper<efl_text_password_set_api_delegate> efl_text_password_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_password_set_api_delegate>(Module, "efl_text_password_set");

        private static void password_set(System.IntPtr obj, System.IntPtr pd, bool enabled)
        {
            Eina.Log.Debug("function efl_text_password_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetPassword(enabled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_password_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enabled);
            }
        }

        private static efl_text_password_set_delegate efl_text_password_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_replacement_char_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_replacement_char_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_replacement_char_get_api_delegate> efl_text_replacement_char_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_replacement_char_get_api_delegate>(Module, "efl_text_replacement_char_get");

        private static System.String replacement_char_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_replacement_char_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetReplacementChar();
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
                return efl_text_replacement_char_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_replacement_char_get_delegate efl_text_replacement_char_get_static_delegate;

        
        private delegate void efl_text_replacement_char_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String repch);

        
        public delegate void efl_text_replacement_char_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String repch);

        public static Efl.Eo.FunctionWrapper<efl_text_replacement_char_set_api_delegate> efl_text_replacement_char_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_replacement_char_set_api_delegate>(Module, "efl_text_replacement_char_set");

        private static void replacement_char_set(System.IntPtr obj, System.IntPtr pd, System.String repch)
        {
            Eina.Log.Debug("function efl_text_replacement_char_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetReplacementChar(repch);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_replacement_char_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), repch);
            }
        }

        private static efl_text_replacement_char_set_delegate efl_text_replacement_char_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_interactive_selection_allowed_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_interactive_selection_allowed_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_get_api_delegate> efl_text_interactive_selection_allowed_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_get_api_delegate>(Module, "efl_text_interactive_selection_allowed_get");

        private static bool selection_allowed_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_interactive_selection_allowed_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetSelectionAllowed();
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
                return efl_text_interactive_selection_allowed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_interactive_selection_allowed_get_delegate efl_text_interactive_selection_allowed_get_static_delegate;

        
        private delegate void efl_text_interactive_selection_allowed_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool allowed);

        
        public delegate void efl_text_interactive_selection_allowed_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool allowed);

        public static Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_set_api_delegate> efl_text_interactive_selection_allowed_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_selection_allowed_set_api_delegate>(Module, "efl_text_interactive_selection_allowed_set");

        private static void selection_allowed_set(System.IntPtr obj, System.IntPtr pd, bool allowed)
        {
            Eina.Log.Debug("function efl_text_interactive_selection_allowed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetSelectionAllowed(allowed);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_interactive_selection_allowed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), allowed);
            }
        }

        private static efl_text_interactive_selection_allowed_set_delegate efl_text_interactive_selection_allowed_set_static_delegate;

        
        private delegate void efl_text_interactive_selection_cursors_get_delegate(System.IntPtr obj, System.IntPtr pd,  out Efl.TextCursorCursor start,  out Efl.TextCursorCursor end);

        
        public delegate void efl_text_interactive_selection_cursors_get_api_delegate(System.IntPtr obj,  out Efl.TextCursorCursor start,  out Efl.TextCursorCursor end);

        public static Efl.Eo.FunctionWrapper<efl_text_interactive_selection_cursors_get_api_delegate> efl_text_interactive_selection_cursors_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_selection_cursors_get_api_delegate>(Module, "efl_text_interactive_selection_cursors_get");

        private static void selection_cursors_get(System.IntPtr obj, System.IntPtr pd, out Efl.TextCursorCursor start, out Efl.TextCursorCursor end)
        {
            Eina.Log.Debug("function efl_text_interactive_selection_cursors_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        start = default(Efl.TextCursorCursor);        end = default(Efl.TextCursorCursor);                            
                try
                {
                    ((Text)ws.Target).GetSelectionCursors(out start, out end);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_text_interactive_selection_cursors_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out start, out end);
            }
        }

        private static efl_text_interactive_selection_cursors_get_delegate efl_text_interactive_selection_cursors_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_text_interactive_editable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_text_interactive_editable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_interactive_editable_get_api_delegate> efl_text_interactive_editable_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_editable_get_api_delegate>(Module, "efl_text_interactive_editable_get");

        private static bool editable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_interactive_editable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetEditable();
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
                return efl_text_interactive_editable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_interactive_editable_get_delegate efl_text_interactive_editable_get_static_delegate;

        
        private delegate void efl_text_interactive_editable_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool editable);

        
        public delegate void efl_text_interactive_editable_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool editable);

        public static Efl.Eo.FunctionWrapper<efl_text_interactive_editable_set_api_delegate> efl_text_interactive_editable_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_editable_set_api_delegate>(Module, "efl_text_interactive_editable_set");

        private static void editable_set(System.IntPtr obj, System.IntPtr pd, bool editable)
        {
            Eina.Log.Debug("function efl_text_interactive_editable_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetEditable(editable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_interactive_editable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), editable);
            }
        }

        private static efl_text_interactive_editable_set_delegate efl_text_interactive_editable_set_static_delegate;

        
        private delegate void efl_text_interactive_select_none_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_text_interactive_select_none_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_interactive_select_none_api_delegate> efl_text_interactive_select_none_ptr = new Efl.Eo.FunctionWrapper<efl_text_interactive_select_none_api_delegate>(Module, "efl_text_interactive_select_none");

        private static void select_none(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_interactive_select_none was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Text)ws.Target).SelectNone();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_text_interactive_select_none_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_interactive_select_none_delegate efl_text_interactive_select_none_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_markup_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_markup_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_markup_get_api_delegate> efl_text_markup_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_get_api_delegate>(Module, "efl_text_markup_get");

        private static System.String markup_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_markup_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetMarkup();
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
                return efl_text_markup_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_markup_get_delegate efl_text_markup_get_static_delegate;

        
        private delegate void efl_text_markup_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String markup);

        
        public delegate void efl_text_markup_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String markup);

        public static Efl.Eo.FunctionWrapper<efl_text_markup_set_api_delegate> efl_text_markup_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_markup_set_api_delegate>(Module, "efl_text_markup_set");

        private static void markup_set(System.IntPtr obj, System.IntPtr pd, System.String markup)
        {
            Eina.Log.Debug("function efl_text_markup_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetMarkup(markup);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_markup_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), markup);
            }
        }

        private static efl_text_markup_set_delegate efl_text_markup_set_static_delegate;

        
        private delegate void efl_text_normal_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_normal_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_normal_color_get_api_delegate> efl_text_normal_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_normal_color_get_api_delegate>(Module, "efl_text_normal_color_get");

        private static void normal_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_normal_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetNormalColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_normal_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_normal_color_get_delegate efl_text_normal_color_get_static_delegate;

        
        private delegate void efl_text_normal_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_normal_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_normal_color_set_api_delegate> efl_text_normal_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_normal_color_set_api_delegate>(Module, "efl_text_normal_color_set");

        private static void normal_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_normal_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetNormalColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_normal_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_normal_color_set_delegate efl_text_normal_color_set_static_delegate;

        
        private delegate Efl.TextStyleBackingType efl_text_backing_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextStyleBackingType efl_text_backing_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_backing_type_get_api_delegate> efl_text_backing_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_type_get_api_delegate>(Module, "efl_text_backing_type_get");

        private static Efl.TextStyleBackingType backing_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_backing_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextStyleBackingType _ret_var = default(Efl.TextStyleBackingType);
                try
                {
                    _ret_var = ((Text)ws.Target).GetBackingType();
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
                return efl_text_backing_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_backing_type_get_delegate efl_text_backing_type_get_static_delegate;

        
        private delegate void efl_text_backing_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleBackingType type);

        
        public delegate void efl_text_backing_type_set_api_delegate(System.IntPtr obj,  Efl.TextStyleBackingType type);

        public static Efl.Eo.FunctionWrapper<efl_text_backing_type_set_api_delegate> efl_text_backing_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_type_set_api_delegate>(Module, "efl_text_backing_type_set");

        private static void backing_type_set(System.IntPtr obj, System.IntPtr pd, Efl.TextStyleBackingType type)
        {
            Eina.Log.Debug("function efl_text_backing_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetBackingType(type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_backing_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type);
            }
        }

        private static efl_text_backing_type_set_delegate efl_text_backing_type_set_static_delegate;

        
        private delegate void efl_text_backing_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_backing_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_backing_color_get_api_delegate> efl_text_backing_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_color_get_api_delegate>(Module, "efl_text_backing_color_get");

        private static void backing_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_backing_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetBackingColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_backing_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_backing_color_get_delegate efl_text_backing_color_get_static_delegate;

        
        private delegate void efl_text_backing_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_backing_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_backing_color_set_api_delegate> efl_text_backing_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_backing_color_set_api_delegate>(Module, "efl_text_backing_color_set");

        private static void backing_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_backing_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetBackingColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_backing_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_backing_color_set_delegate efl_text_backing_color_set_static_delegate;

        
        private delegate Efl.TextStyleUnderlineType efl_text_underline_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextStyleUnderlineType efl_text_underline_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_type_get_api_delegate> efl_text_underline_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_type_get_api_delegate>(Module, "efl_text_underline_type_get");

        private static Efl.TextStyleUnderlineType underline_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_underline_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextStyleUnderlineType _ret_var = default(Efl.TextStyleUnderlineType);
                try
                {
                    _ret_var = ((Text)ws.Target).GetUnderlineType();
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
                return efl_text_underline_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_underline_type_get_delegate efl_text_underline_type_get_static_delegate;

        
        private delegate void efl_text_underline_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleUnderlineType type);

        
        public delegate void efl_text_underline_type_set_api_delegate(System.IntPtr obj,  Efl.TextStyleUnderlineType type);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_type_set_api_delegate> efl_text_underline_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_type_set_api_delegate>(Module, "efl_text_underline_type_set");

        private static void underline_type_set(System.IntPtr obj, System.IntPtr pd, Efl.TextStyleUnderlineType type)
        {
            Eina.Log.Debug("function efl_text_underline_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetUnderlineType(type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_underline_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type);
            }
        }

        private static efl_text_underline_type_set_delegate efl_text_underline_type_set_static_delegate;

        
        private delegate void efl_text_underline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_underline_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_color_get_api_delegate> efl_text_underline_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_color_get_api_delegate>(Module, "efl_text_underline_color_get");

        private static void underline_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_underline_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetUnderlineColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_underline_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_underline_color_get_delegate efl_text_underline_color_get_static_delegate;

        
        private delegate void efl_text_underline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_underline_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_color_set_api_delegate> efl_text_underline_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_color_set_api_delegate>(Module, "efl_text_underline_color_set");

        private static void underline_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_underline_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetUnderlineColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_underline_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_underline_color_set_delegate efl_text_underline_color_set_static_delegate;

        
        private delegate double efl_text_underline_height_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_text_underline_height_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_height_get_api_delegate> efl_text_underline_height_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_height_get_api_delegate>(Module, "efl_text_underline_height_get");

        private static double underline_height_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_underline_height_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Text)ws.Target).GetUnderlineHeight();
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
                return efl_text_underline_height_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_underline_height_get_delegate efl_text_underline_height_get_static_delegate;

        
        private delegate void efl_text_underline_height_set_delegate(System.IntPtr obj, System.IntPtr pd,  double height);

        
        public delegate void efl_text_underline_height_set_api_delegate(System.IntPtr obj,  double height);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_height_set_api_delegate> efl_text_underline_height_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_height_set_api_delegate>(Module, "efl_text_underline_height_set");

        private static void underline_height_set(System.IntPtr obj, System.IntPtr pd, double height)
        {
            Eina.Log.Debug("function efl_text_underline_height_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetUnderlineHeight(height);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_underline_height_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), height);
            }
        }

        private static efl_text_underline_height_set_delegate efl_text_underline_height_set_static_delegate;

        
        private delegate void efl_text_underline_dashed_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_underline_dashed_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_get_api_delegate> efl_text_underline_dashed_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_get_api_delegate>(Module, "efl_text_underline_dashed_color_get");

        private static void underline_dashed_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_underline_dashed_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetUnderlineDashedColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_underline_dashed_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_underline_dashed_color_get_delegate efl_text_underline_dashed_color_get_static_delegate;

        
        private delegate void efl_text_underline_dashed_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_underline_dashed_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_set_api_delegate> efl_text_underline_dashed_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_color_set_api_delegate>(Module, "efl_text_underline_dashed_color_set");

        private static void underline_dashed_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_underline_dashed_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetUnderlineDashedColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_underline_dashed_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_underline_dashed_color_set_delegate efl_text_underline_dashed_color_set_static_delegate;

        
        private delegate int efl_text_underline_dashed_width_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_text_underline_dashed_width_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_get_api_delegate> efl_text_underline_dashed_width_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_get_api_delegate>(Module, "efl_text_underline_dashed_width_get");

        private static int underline_dashed_width_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_underline_dashed_width_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).GetUnderlineDashedWidth();
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
                return efl_text_underline_dashed_width_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_underline_dashed_width_get_delegate efl_text_underline_dashed_width_get_static_delegate;

        
        private delegate void efl_text_underline_dashed_width_set_delegate(System.IntPtr obj, System.IntPtr pd,  int width);

        
        public delegate void efl_text_underline_dashed_width_set_api_delegate(System.IntPtr obj,  int width);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_set_api_delegate> efl_text_underline_dashed_width_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_width_set_api_delegate>(Module, "efl_text_underline_dashed_width_set");

        private static void underline_dashed_width_set(System.IntPtr obj, System.IntPtr pd, int width)
        {
            Eina.Log.Debug("function efl_text_underline_dashed_width_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetUnderlineDashedWidth(width);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_underline_dashed_width_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), width);
            }
        }

        private static efl_text_underline_dashed_width_set_delegate efl_text_underline_dashed_width_set_static_delegate;

        
        private delegate int efl_text_underline_dashed_gap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_text_underline_dashed_gap_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_get_api_delegate> efl_text_underline_dashed_gap_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_get_api_delegate>(Module, "efl_text_underline_dashed_gap_get");

        private static int underline_dashed_gap_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_underline_dashed_gap_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).GetUnderlineDashedGap();
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
                return efl_text_underline_dashed_gap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_underline_dashed_gap_get_delegate efl_text_underline_dashed_gap_get_static_delegate;

        
        private delegate void efl_text_underline_dashed_gap_set_delegate(System.IntPtr obj, System.IntPtr pd,  int gap);

        
        public delegate void efl_text_underline_dashed_gap_set_api_delegate(System.IntPtr obj,  int gap);

        public static Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_set_api_delegate> efl_text_underline_dashed_gap_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline_dashed_gap_set_api_delegate>(Module, "efl_text_underline_dashed_gap_set");

        private static void underline_dashed_gap_set(System.IntPtr obj, System.IntPtr pd, int gap)
        {
            Eina.Log.Debug("function efl_text_underline_dashed_gap_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetUnderlineDashedGap(gap);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_underline_dashed_gap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), gap);
            }
        }

        private static efl_text_underline_dashed_gap_set_delegate efl_text_underline_dashed_gap_set_static_delegate;

        
        private delegate void efl_text_underline2_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_underline2_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_underline2_color_get_api_delegate> efl_text_underline2_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline2_color_get_api_delegate>(Module, "efl_text_underline2_color_get");

        private static void underline2_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_underline2_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetUnderline2Color(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_underline2_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_underline2_color_get_delegate efl_text_underline2_color_get_static_delegate;

        
        private delegate void efl_text_underline2_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_underline2_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_underline2_color_set_api_delegate> efl_text_underline2_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_underline2_color_set_api_delegate>(Module, "efl_text_underline2_color_set");

        private static void underline2_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_underline2_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetUnderline2Color(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_underline2_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_underline2_color_set_delegate efl_text_underline2_color_set_static_delegate;

        
        private delegate Efl.TextStyleStrikethroughType efl_text_strikethrough_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextStyleStrikethroughType efl_text_strikethrough_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_get_api_delegate> efl_text_strikethrough_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_get_api_delegate>(Module, "efl_text_strikethrough_type_get");

        private static Efl.TextStyleStrikethroughType strikethrough_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_strikethrough_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextStyleStrikethroughType _ret_var = default(Efl.TextStyleStrikethroughType);
                try
                {
                    _ret_var = ((Text)ws.Target).GetStrikethroughType();
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
                return efl_text_strikethrough_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_strikethrough_type_get_delegate efl_text_strikethrough_type_get_static_delegate;

        
        private delegate void efl_text_strikethrough_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleStrikethroughType type);

        
        public delegate void efl_text_strikethrough_type_set_api_delegate(System.IntPtr obj,  Efl.TextStyleStrikethroughType type);

        public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_set_api_delegate> efl_text_strikethrough_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_type_set_api_delegate>(Module, "efl_text_strikethrough_type_set");

        private static void strikethrough_type_set(System.IntPtr obj, System.IntPtr pd, Efl.TextStyleStrikethroughType type)
        {
            Eina.Log.Debug("function efl_text_strikethrough_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetStrikethroughType(type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_strikethrough_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type);
            }
        }

        private static efl_text_strikethrough_type_set_delegate efl_text_strikethrough_type_set_static_delegate;

        
        private delegate void efl_text_strikethrough_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_strikethrough_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_get_api_delegate> efl_text_strikethrough_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_get_api_delegate>(Module, "efl_text_strikethrough_color_get");

        private static void strikethrough_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_strikethrough_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetStrikethroughColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_strikethrough_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_strikethrough_color_get_delegate efl_text_strikethrough_color_get_static_delegate;

        
        private delegate void efl_text_strikethrough_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_strikethrough_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_set_api_delegate> efl_text_strikethrough_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_strikethrough_color_set_api_delegate>(Module, "efl_text_strikethrough_color_set");

        private static void strikethrough_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_strikethrough_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetStrikethroughColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_strikethrough_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_strikethrough_color_set_delegate efl_text_strikethrough_color_set_static_delegate;

        
        private delegate Efl.TextStyleEffectType efl_text_effect_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextStyleEffectType efl_text_effect_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_effect_type_get_api_delegate> efl_text_effect_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_effect_type_get_api_delegate>(Module, "efl_text_effect_type_get");

        private static Efl.TextStyleEffectType effect_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_effect_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextStyleEffectType _ret_var = default(Efl.TextStyleEffectType);
                try
                {
                    _ret_var = ((Text)ws.Target).GetEffectType();
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
                return efl_text_effect_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_effect_type_get_delegate efl_text_effect_type_get_static_delegate;

        
        private delegate void efl_text_effect_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleEffectType type);

        
        public delegate void efl_text_effect_type_set_api_delegate(System.IntPtr obj,  Efl.TextStyleEffectType type);

        public static Efl.Eo.FunctionWrapper<efl_text_effect_type_set_api_delegate> efl_text_effect_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_effect_type_set_api_delegate>(Module, "efl_text_effect_type_set");

        private static void effect_type_set(System.IntPtr obj, System.IntPtr pd, Efl.TextStyleEffectType type)
        {
            Eina.Log.Debug("function efl_text_effect_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetEffectType(type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_effect_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type);
            }
        }

        private static efl_text_effect_type_set_delegate efl_text_effect_type_set_static_delegate;

        
        private delegate void efl_text_outline_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_outline_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_outline_color_get_api_delegate> efl_text_outline_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_outline_color_get_api_delegate>(Module, "efl_text_outline_color_get");

        private static void outline_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_outline_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetOutlineColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_outline_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_outline_color_get_delegate efl_text_outline_color_get_static_delegate;

        
        private delegate void efl_text_outline_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_outline_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_outline_color_set_api_delegate> efl_text_outline_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_outline_color_set_api_delegate>(Module, "efl_text_outline_color_set");

        private static void outline_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_outline_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetOutlineColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_outline_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_outline_color_set_delegate efl_text_outline_color_set_static_delegate;

        
        private delegate Efl.TextStyleShadowDirection efl_text_shadow_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.TextStyleShadowDirection efl_text_shadow_direction_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_shadow_direction_get_api_delegate> efl_text_shadow_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_direction_get_api_delegate>(Module, "efl_text_shadow_direction_get");

        private static Efl.TextStyleShadowDirection shadow_direction_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_shadow_direction_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.TextStyleShadowDirection _ret_var = default(Efl.TextStyleShadowDirection);
                try
                {
                    _ret_var = ((Text)ws.Target).GetShadowDirection();
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
                return efl_text_shadow_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_shadow_direction_get_delegate efl_text_shadow_direction_get_static_delegate;

        
        private delegate void efl_text_shadow_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.TextStyleShadowDirection type);

        
        public delegate void efl_text_shadow_direction_set_api_delegate(System.IntPtr obj,  Efl.TextStyleShadowDirection type);

        public static Efl.Eo.FunctionWrapper<efl_text_shadow_direction_set_api_delegate> efl_text_shadow_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_direction_set_api_delegate>(Module, "efl_text_shadow_direction_set");

        private static void shadow_direction_set(System.IntPtr obj, System.IntPtr pd, Efl.TextStyleShadowDirection type)
        {
            Eina.Log.Debug("function efl_text_shadow_direction_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetShadowDirection(type);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_shadow_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type);
            }
        }

        private static efl_text_shadow_direction_set_delegate efl_text_shadow_direction_set_static_delegate;

        
        private delegate void efl_text_shadow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_shadow_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_shadow_color_get_api_delegate> efl_text_shadow_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_color_get_api_delegate>(Module, "efl_text_shadow_color_get");

        private static void shadow_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_shadow_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetShadowColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_shadow_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_shadow_color_get_delegate efl_text_shadow_color_get_static_delegate;

        
        private delegate void efl_text_shadow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_shadow_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_shadow_color_set_api_delegate> efl_text_shadow_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_shadow_color_set_api_delegate>(Module, "efl_text_shadow_color_set");

        private static void shadow_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_shadow_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetShadowColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_shadow_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_shadow_color_set_delegate efl_text_shadow_color_set_static_delegate;

        
        private delegate void efl_text_glow_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_glow_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_glow_color_get_api_delegate> efl_text_glow_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow_color_get_api_delegate>(Module, "efl_text_glow_color_get");

        private static void glow_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_glow_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetGlowColor(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_glow_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_glow_color_get_delegate efl_text_glow_color_get_static_delegate;

        
        private delegate void efl_text_glow_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_glow_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_glow_color_set_api_delegate> efl_text_glow_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow_color_set_api_delegate>(Module, "efl_text_glow_color_set");

        private static void glow_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_glow_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetGlowColor(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_glow_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_glow_color_set_delegate efl_text_glow_color_set_static_delegate;

        
        private delegate void efl_text_glow2_color_get_delegate(System.IntPtr obj, System.IntPtr pd,  out byte r,  out byte g,  out byte b,  out byte a);

        
        public delegate void efl_text_glow2_color_get_api_delegate(System.IntPtr obj,  out byte r,  out byte g,  out byte b,  out byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_glow2_color_get_api_delegate> efl_text_glow2_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow2_color_get_api_delegate>(Module, "efl_text_glow2_color_get");

        private static void glow2_color_get(System.IntPtr obj, System.IntPtr pd, out byte r, out byte g, out byte b, out byte a)
        {
            Eina.Log.Debug("function efl_text_glow2_color_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        r = default(byte);        g = default(byte);        b = default(byte);        a = default(byte);                                            
                try
                {
                    ((Text)ws.Target).GetGlow2Color(out r, out g, out b, out a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_glow2_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out r, out g, out b, out a);
            }
        }

        private static efl_text_glow2_color_get_delegate efl_text_glow2_color_get_static_delegate;

        
        private delegate void efl_text_glow2_color_set_delegate(System.IntPtr obj, System.IntPtr pd,  byte r,  byte g,  byte b,  byte a);

        
        public delegate void efl_text_glow2_color_set_api_delegate(System.IntPtr obj,  byte r,  byte g,  byte b,  byte a);

        public static Efl.Eo.FunctionWrapper<efl_text_glow2_color_set_api_delegate> efl_text_glow2_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_glow2_color_set_api_delegate>(Module, "efl_text_glow2_color_set");

        private static void glow2_color_set(System.IntPtr obj, System.IntPtr pd, byte r, byte g, byte b, byte a)
        {
            Eina.Log.Debug("function efl_text_glow2_color_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                            
                try
                {
                    ((Text)ws.Target).SetGlow2Color(r, g, b, a);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_text_glow2_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), r, g, b, a);
            }
        }

        private static efl_text_glow2_color_set_delegate efl_text_glow2_color_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_text_gfx_filter_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_text_gfx_filter_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_text_gfx_filter_get_api_delegate> efl_text_gfx_filter_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_gfx_filter_get_api_delegate>(Module, "efl_text_gfx_filter_get");

        private static System.String gfx_filter_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_text_gfx_filter_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetGfxFilter();
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
                return efl_text_gfx_filter_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_text_gfx_filter_get_delegate efl_text_gfx_filter_get_static_delegate;

        
        private delegate void efl_text_gfx_filter_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String code);

        
        public delegate void efl_text_gfx_filter_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String code);

        public static Efl.Eo.FunctionWrapper<efl_text_gfx_filter_set_api_delegate> efl_text_gfx_filter_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_gfx_filter_set_api_delegate>(Module, "efl_text_gfx_filter_set");

        private static void gfx_filter_set(System.IntPtr obj, System.IntPtr pd, System.String code)
        {
            Eina.Log.Debug("function efl_text_gfx_filter_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).SetGfxFilter(code);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_text_gfx_filter_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), code);
            }
        }

        private static efl_text_gfx_filter_set_delegate efl_text_gfx_filter_set_static_delegate;

        
        private delegate Eina.Unicode efl_access_text_character_get_delegate(System.IntPtr obj, System.IntPtr pd,  int offset);

        
        public delegate Eina.Unicode efl_access_text_character_get_api_delegate(System.IntPtr obj,  int offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_character_get_api_delegate> efl_access_text_character_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_character_get_api_delegate>(Module, "efl_access_text_character_get");

        private static Eina.Unicode character_get(System.IntPtr obj, System.IntPtr pd, int offset)
        {
            Eina.Log.Debug("function efl_access_text_character_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Unicode _ret_var = default(Eina.Unicode);
                try
                {
                    _ret_var = ((Text)ws.Target).GetCharacter(offset);
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
                return efl_access_text_character_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), offset);
            }
        }

        private static efl_access_text_character_get_delegate efl_access_text_character_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        private delegate System.String efl_access_text_string_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.TextGranularity granularity,  System.IntPtr start_offset,  System.IntPtr end_offset);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        public delegate System.String efl_access_text_string_get_api_delegate(System.IntPtr obj,  Efl.Access.TextGranularity granularity,  System.IntPtr start_offset,  System.IntPtr end_offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_string_get_api_delegate> efl_access_text_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_string_get_api_delegate>(Module, "efl_access_text_string_get");

        private static System.String string_get(System.IntPtr obj, System.IntPtr pd, Efl.Access.TextGranularity granularity, System.IntPtr start_offset, System.IntPtr end_offset)
        {
            Eina.Log.Debug("function efl_access_text_string_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_start_offset = Eina.PrimitiveConversion.PointerToManaged<int>(start_offset);
        var _in_end_offset = Eina.PrimitiveConversion.PointerToManaged<int>(end_offset);
                                                            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetString(granularity, _in_start_offset, _in_end_offset);
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
                return efl_access_text_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), granularity, start_offset, end_offset);
            }
        }

        private static efl_access_text_string_get_delegate efl_access_text_string_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        private delegate System.String efl_access_text_get_delegate(System.IntPtr obj, System.IntPtr pd,  int start_offset,  int end_offset);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        public delegate System.String efl_access_text_get_api_delegate(System.IntPtr obj,  int start_offset,  int end_offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_get_api_delegate> efl_access_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_get_api_delegate>(Module, "efl_access_text_get");

        private static System.String access_text_get(System.IntPtr obj, System.IntPtr pd, int start_offset, int end_offset)
        {
            Eina.Log.Debug("function efl_access_text_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Text)ws.Target).GetAccessText(start_offset, end_offset);
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
                return efl_access_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start_offset, end_offset);
            }
        }

        private static efl_access_text_get_delegate efl_access_text_get_static_delegate;

        
        private delegate int efl_access_text_caret_offset_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_access_text_caret_offset_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_get_api_delegate> efl_access_text_caret_offset_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_get_api_delegate>(Module, "efl_access_text_caret_offset_get");

        private static int caret_offset_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_text_caret_offset_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).GetCaretOffset();
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
                return efl_access_text_caret_offset_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_text_caret_offset_get_delegate efl_access_text_caret_offset_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_caret_offset_set_delegate(System.IntPtr obj, System.IntPtr pd,  int offset);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_caret_offset_set_api_delegate(System.IntPtr obj,  int offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_set_api_delegate> efl_access_text_caret_offset_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_caret_offset_set_api_delegate>(Module, "efl_access_text_caret_offset_set");

        private static bool caret_offset_set(System.IntPtr obj, System.IntPtr pd, int offset)
        {
            Eina.Log.Debug("function efl_access_text_caret_offset_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).SetCaretOffset(offset);
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
                return efl_access_text_caret_offset_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), offset);
            }
        }

        private static efl_access_text_caret_offset_set_delegate efl_access_text_caret_offset_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_attribute_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name,  System.IntPtr start_offset,  System.IntPtr end_offset, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] out System.String value);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_attribute_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name,  System.IntPtr start_offset,  System.IntPtr end_offset, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))] out System.String value);

        public static Efl.Eo.FunctionWrapper<efl_access_text_attribute_get_api_delegate> efl_access_text_attribute_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_attribute_get_api_delegate>(Module, "efl_access_text_attribute_get");

        private static bool attribute_get(System.IntPtr obj, System.IntPtr pd, System.String name, System.IntPtr start_offset, System.IntPtr end_offset, out System.String value)
        {
            Eina.Log.Debug("function efl_access_text_attribute_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_start_offset = Eina.PrimitiveConversion.PointerToManaged<int>(start_offset);
        var _in_end_offset = Eina.PrimitiveConversion.PointerToManaged<int>(end_offset);
                                        value = default(System.String);                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetAttribute(name, _in_start_offset, _in_end_offset, out value);
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
                return efl_access_text_attribute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name, start_offset, end_offset, out value);
            }
        }

        private static efl_access_text_attribute_get_delegate efl_access_text_attribute_get_static_delegate;

        
        private delegate System.IntPtr efl_access_text_attributes_get_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr start_offset,  System.IntPtr end_offset);

        
        public delegate System.IntPtr efl_access_text_attributes_get_api_delegate(System.IntPtr obj,  System.IntPtr start_offset,  System.IntPtr end_offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_attributes_get_api_delegate> efl_access_text_attributes_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_attributes_get_api_delegate>(Module, "efl_access_text_attributes_get");

        private static System.IntPtr text_attributes_get(System.IntPtr obj, System.IntPtr pd, System.IntPtr start_offset, System.IntPtr end_offset)
        {
            Eina.Log.Debug("function efl_access_text_attributes_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_start_offset = Eina.PrimitiveConversion.PointerToManaged<int>(start_offset);
        var _in_end_offset = Eina.PrimitiveConversion.PointerToManaged<int>(end_offset);
                                            Eina.List<Efl.Access.TextAttribute> _ret_var = default(Eina.List<Efl.Access.TextAttribute>);
                try
                {
                    _ret_var = ((Text)ws.Target).GetTextAttributes(_in_start_offset, _in_end_offset);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        _ret_var.Own = false; _ret_var.OwnContent = false; return _ret_var.Handle;

            }
            else
            {
                return efl_access_text_attributes_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start_offset, end_offset);
            }
        }

        private static efl_access_text_attributes_get_delegate efl_access_text_attributes_get_static_delegate;

        
        private delegate System.IntPtr efl_access_text_default_attributes_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_access_text_default_attributes_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_text_default_attributes_get_api_delegate> efl_access_text_default_attributes_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_default_attributes_get_api_delegate>(Module, "efl_access_text_default_attributes_get");

        private static System.IntPtr default_attributes_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_text_default_attributes_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.List<Efl.Access.TextAttribute> _ret_var = default(Eina.List<Efl.Access.TextAttribute>);
                try
                {
                    _ret_var = ((Text)ws.Target).GetDefaultAttributes();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        _ret_var.Own = false; _ret_var.OwnContent = false; return _ret_var.Handle;

            }
            else
            {
                return efl_access_text_default_attributes_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_text_default_attributes_get_delegate efl_access_text_default_attributes_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_character_extents_get_delegate(System.IntPtr obj, System.IntPtr pd,  int offset, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  out Eina.Rect.NativeStruct rect);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_character_extents_get_api_delegate(System.IntPtr obj,  int offset, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  out Eina.Rect.NativeStruct rect);

        public static Efl.Eo.FunctionWrapper<efl_access_text_character_extents_get_api_delegate> efl_access_text_character_extents_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_character_extents_get_api_delegate>(Module, "efl_access_text_character_extents_get");

        private static bool character_extents_get(System.IntPtr obj, System.IntPtr pd, int offset, bool screen_coords, out Eina.Rect.NativeStruct rect)
        {
            Eina.Log.Debug("function efl_access_text_character_extents_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                Eina.Rect _out_rect = default(Eina.Rect);
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetCharacterExtents(offset, screen_coords, out _out_rect);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        rect = _out_rect;
                                return _ret_var;

            }
            else
            {
                return efl_access_text_character_extents_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), offset, screen_coords, out rect);
            }
        }

        private static efl_access_text_character_extents_get_delegate efl_access_text_character_extents_get_static_delegate;

        
        private delegate int efl_access_text_character_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_access_text_character_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_text_character_count_get_api_delegate> efl_access_text_character_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_character_count_get_api_delegate>(Module, "efl_access_text_character_count_get");

        private static int character_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_text_character_count_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).GetCharacterCount();
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
                return efl_access_text_character_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_text_character_count_get_delegate efl_access_text_character_count_get_static_delegate;

        
        private delegate int efl_access_text_offset_at_point_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int x,  int y);

        
        public delegate int efl_access_text_offset_at_point_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int x,  int y);

        public static Efl.Eo.FunctionWrapper<efl_access_text_offset_at_point_get_api_delegate> efl_access_text_offset_at_point_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_offset_at_point_get_api_delegate>(Module, "efl_access_text_offset_at_point_get");

        private static int offset_at_point_get(System.IntPtr obj, System.IntPtr pd, bool screen_coords, int x, int y)
        {
            Eina.Log.Debug("function efl_access_text_offset_at_point_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).GetOffsetAtPoint(screen_coords, x, y);
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
                return efl_access_text_offset_at_point_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), screen_coords, x, y);
            }
        }

        private static efl_access_text_offset_at_point_get_delegate efl_access_text_offset_at_point_get_static_delegate;

        
        private delegate System.IntPtr efl_access_text_bounded_ranges_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  Eina.Rect.NativeStruct rect,  Efl.Access.TextClipType xclip,  Efl.Access.TextClipType yclip);

        
        public delegate System.IntPtr efl_access_text_bounded_ranges_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  Eina.Rect.NativeStruct rect,  Efl.Access.TextClipType xclip,  Efl.Access.TextClipType yclip);

        public static Efl.Eo.FunctionWrapper<efl_access_text_bounded_ranges_get_api_delegate> efl_access_text_bounded_ranges_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_bounded_ranges_get_api_delegate>(Module, "efl_access_text_bounded_ranges_get");

        private static System.IntPtr bounded_ranges_get(System.IntPtr obj, System.IntPtr pd, bool screen_coords, Eina.Rect.NativeStruct rect, Efl.Access.TextClipType xclip, Efl.Access.TextClipType yclip)
        {
            Eina.Log.Debug("function efl_access_text_bounded_ranges_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Rect _in_rect = rect;
                                                                                            Eina.List<Efl.Access.TextRange> _ret_var = default(Eina.List<Efl.Access.TextRange>);
                try
                {
                    _ret_var = ((Text)ws.Target).GetBoundedRanges(screen_coords, _in_rect, xclip, yclip);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        _ret_var.Own = false; _ret_var.OwnContent = false; return _ret_var.Handle;

            }
            else
            {
                return efl_access_text_bounded_ranges_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), screen_coords, rect, xclip, yclip);
            }
        }

        private static efl_access_text_bounded_ranges_get_delegate efl_access_text_bounded_ranges_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_range_extents_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int start_offset,  int end_offset,  out Eina.Rect.NativeStruct rect);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_range_extents_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int start_offset,  int end_offset,  out Eina.Rect.NativeStruct rect);

        public static Efl.Eo.FunctionWrapper<efl_access_text_range_extents_get_api_delegate> efl_access_text_range_extents_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_range_extents_get_api_delegate>(Module, "efl_access_text_range_extents_get");

        private static bool range_extents_get(System.IntPtr obj, System.IntPtr pd, bool screen_coords, int start_offset, int end_offset, out Eina.Rect.NativeStruct rect)
        {
            Eina.Log.Debug("function efl_access_text_range_extents_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                Eina.Rect _out_rect = default(Eina.Rect);
                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).GetRangeExtents(screen_coords, start_offset, end_offset, out _out_rect);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                rect = _out_rect;
                                        return _ret_var;

            }
            else
            {
                return efl_access_text_range_extents_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), screen_coords, start_offset, end_offset, out rect);
            }
        }

        private static efl_access_text_range_extents_get_delegate efl_access_text_range_extents_get_static_delegate;

        
        private delegate int efl_access_text_selections_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_access_text_selections_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_text_selections_count_get_api_delegate> efl_access_text_selections_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_selections_count_get_api_delegate>(Module, "efl_access_text_selections_count_get");

        private static int selections_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_text_selections_count_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Text)ws.Target).GetSelectionsCount();
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
                return efl_access_text_selections_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_text_selections_count_get_delegate efl_access_text_selections_count_get_static_delegate;

        
        private delegate void efl_access_text_access_selection_get_delegate(System.IntPtr obj, System.IntPtr pd,  int selection_number,  out int start_offset,  out int end_offset);

        
        public delegate void efl_access_text_access_selection_get_api_delegate(System.IntPtr obj,  int selection_number,  out int start_offset,  out int end_offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_access_selection_get_api_delegate> efl_access_text_access_selection_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_access_selection_get_api_delegate>(Module, "efl_access_text_access_selection_get");

        private static void access_selection_get(System.IntPtr obj, System.IntPtr pd, int selection_number, out int start_offset, out int end_offset)
        {
            Eina.Log.Debug("function efl_access_text_access_selection_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        start_offset = default(int);        end_offset = default(int);                                    
                try
                {
                    ((Text)ws.Target).GetAccessSelection(selection_number, out start_offset, out end_offset);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_access_text_access_selection_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), selection_number, out start_offset, out end_offset);
            }
        }

        private static efl_access_text_access_selection_get_delegate efl_access_text_access_selection_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_access_selection_set_delegate(System.IntPtr obj, System.IntPtr pd,  int selection_number,  int start_offset,  int end_offset);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_access_selection_set_api_delegate(System.IntPtr obj,  int selection_number,  int start_offset,  int end_offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_access_selection_set_api_delegate> efl_access_text_access_selection_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_access_selection_set_api_delegate>(Module, "efl_access_text_access_selection_set");

        private static bool access_selection_set(System.IntPtr obj, System.IntPtr pd, int selection_number, int start_offset, int end_offset)
        {
            Eina.Log.Debug("function efl_access_text_access_selection_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).SetAccessSelection(selection_number, start_offset, end_offset);
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
                return efl_access_text_access_selection_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), selection_number, start_offset, end_offset);
            }
        }

        private static efl_access_text_access_selection_set_delegate efl_access_text_access_selection_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_selection_add_delegate(System.IntPtr obj, System.IntPtr pd,  int start_offset,  int end_offset);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_selection_add_api_delegate(System.IntPtr obj,  int start_offset,  int end_offset);

        public static Efl.Eo.FunctionWrapper<efl_access_text_selection_add_api_delegate> efl_access_text_selection_add_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_selection_add_api_delegate>(Module, "efl_access_text_selection_add");

        private static bool selection_add(System.IntPtr obj, System.IntPtr pd, int start_offset, int end_offset)
        {
            Eina.Log.Debug("function efl_access_text_selection_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).AddSelection(start_offset, end_offset);
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
                return efl_access_text_selection_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start_offset, end_offset);
            }
        }

        private static efl_access_text_selection_add_delegate efl_access_text_selection_add_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_text_selection_remove_delegate(System.IntPtr obj, System.IntPtr pd,  int selection_number);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_text_selection_remove_api_delegate(System.IntPtr obj,  int selection_number);

        public static Efl.Eo.FunctionWrapper<efl_access_text_selection_remove_api_delegate> efl_access_text_selection_remove_ptr = new Efl.Eo.FunctionWrapper<efl_access_text_selection_remove_api_delegate>(Module, "efl_access_text_selection_remove");

        private static bool selection_remove(System.IntPtr obj, System.IntPtr pd, int selection_number)
        {
            Eina.Log.Debug("function efl_access_text_selection_remove was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).SelectionRemove(selection_number);
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
                return efl_access_text_selection_remove_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), selection_number);
            }
        }

        private static efl_access_text_selection_remove_delegate efl_access_text_selection_remove_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_content_set_api_delegate> efl_access_editable_text_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_content_set_api_delegate>(Module, "efl_access_editable_text_content_set");

        private static bool text_content_set(System.IntPtr obj, System.IntPtr pd, System.String kw_string)
        {
            Eina.Log.Debug("function efl_access_editable_text_content_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).SetTextContent(kw_string);
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
                return efl_access_editable_text_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_string);
            }
        }

        private static efl_access_editable_text_content_set_delegate efl_access_editable_text_content_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_insert_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string,  int position);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_insert_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String kw_string,  int position);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_insert_api_delegate> efl_access_editable_text_insert_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_insert_api_delegate>(Module, "efl_access_editable_text_insert");

        private static bool insert(System.IntPtr obj, System.IntPtr pd, System.String kw_string, int position)
        {
            Eina.Log.Debug("function efl_access_editable_text_insert was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).Insert(kw_string, position);
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
                return efl_access_editable_text_insert_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_string, position);
            }
        }

        private static efl_access_editable_text_insert_delegate efl_access_editable_text_insert_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_copy_delegate(System.IntPtr obj, System.IntPtr pd,  int start,  int end);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_copy_api_delegate(System.IntPtr obj,  int start,  int end);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_copy_api_delegate> efl_access_editable_text_copy_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_copy_api_delegate>(Module, "efl_access_editable_text_copy");

        private static bool copy(System.IntPtr obj, System.IntPtr pd, int start, int end)
        {
            Eina.Log.Debug("function efl_access_editable_text_copy was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).Copy(start, end);
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
                return efl_access_editable_text_copy_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, end);
            }
        }

        private static efl_access_editable_text_copy_delegate efl_access_editable_text_copy_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_cut_delegate(System.IntPtr obj, System.IntPtr pd,  int start,  int end);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_cut_api_delegate(System.IntPtr obj,  int start,  int end);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_cut_api_delegate> efl_access_editable_text_cut_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_cut_api_delegate>(Module, "efl_access_editable_text_cut");

        private static bool cut(System.IntPtr obj, System.IntPtr pd, int start, int end)
        {
            Eina.Log.Debug("function efl_access_editable_text_cut was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).Cut(start, end);
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
                return efl_access_editable_text_cut_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, end);
            }
        }

        private static efl_access_editable_text_cut_delegate efl_access_editable_text_cut_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_delete_delegate(System.IntPtr obj, System.IntPtr pd,  int start,  int end);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_delete_api_delegate(System.IntPtr obj,  int start,  int end);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_delete_api_delegate> efl_access_editable_text_delete_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_delete_api_delegate>(Module, "efl_access_editable_text_delete");

        private static bool kw_delete(System.IntPtr obj, System.IntPtr pd, int start, int end)
        {
            Eina.Log.Debug("function efl_access_editable_text_delete was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).Delete(start, end);
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
                return efl_access_editable_text_delete_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start, end);
            }
        }

        private static efl_access_editable_text_delete_delegate efl_access_editable_text_delete_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_editable_text_paste_delegate(System.IntPtr obj, System.IntPtr pd,  int position);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_editable_text_paste_api_delegate(System.IntPtr obj,  int position);

        public static Efl.Eo.FunctionWrapper<efl_access_editable_text_paste_api_delegate> efl_access_editable_text_paste_ptr = new Efl.Eo.FunctionWrapper<efl_access_editable_text_paste_api_delegate>(Module, "efl_access_editable_text_paste");

        private static bool paste(System.IntPtr obj, System.IntPtr pd, int position)
        {
            Eina.Log.Debug("function efl_access_editable_text_paste was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Text)ws.Target).Paste(position);
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
                return efl_access_editable_text_paste_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), position);
            }
        }

        private static efl_access_editable_text_paste_delegate efl_access_editable_text_paste_static_delegate;

        
        private delegate void efl_ui_clickable_press_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_ui_clickable_press_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_ui_clickable_press_api_delegate> efl_ui_clickable_press_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clickable_press_api_delegate>(Module, "efl_ui_clickable_press");

        private static void press(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_ui_clickable_press was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).Press(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clickable_press_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_ui_clickable_press_delegate efl_ui_clickable_press_static_delegate;

        
        private delegate void efl_ui_clickable_unpress_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_ui_clickable_unpress_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_ui_clickable_unpress_api_delegate> efl_ui_clickable_unpress_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clickable_unpress_api_delegate>(Module, "efl_ui_clickable_unpress");

        private static void unpress(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_ui_clickable_unpress was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).Unpress(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clickable_unpress_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_ui_clickable_unpress_delegate efl_ui_clickable_unpress_static_delegate;

        
        private delegate void efl_ui_clickable_button_state_reset_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_ui_clickable_button_state_reset_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_ui_clickable_button_state_reset_api_delegate> efl_ui_clickable_button_state_reset_ptr = new Efl.Eo.FunctionWrapper<efl_ui_clickable_button_state_reset_api_delegate>(Module, "efl_ui_clickable_button_state_reset");

        private static void button_state_reset(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_ui_clickable_button_state_reset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).ResetButtonState(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_clickable_button_state_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_ui_clickable_button_state_reset_delegate efl_ui_clickable_button_state_reset_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

