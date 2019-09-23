#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Text.ChangedUserEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextChangedUserEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>The text object has changed due to user interaction</value>
    public Efl.Ui.TextChangeInfo arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Text.ValidateEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextValidateEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when validating</value>
    public Elm.ValidateContent arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorDownEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextAnchorDownEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called on anchor down</value>
    public Elm.EntryAnchorInfo arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorHoverOpenedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextAnchorHoverOpenedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called when hover opened</value>
    public Elm.EntryAnchorHoverInfo arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorInEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextAnchorInEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called on anchor in</value>
    public Elm.EntryAnchorInfo arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorOutEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextAnchorOutEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Called on anchor out</value>
    public Elm.EntryAnchorInfo arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Text.AnchorUpEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class TextAnchorUpEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>called on anchor up</value>
    public Elm.EntryAnchorInfo arg { get; set; }
}
/// <summary>A flexible text widget which can be static (as a label) or editable by the user (as a text entry). It provides all sorts of editing facilities like automatic scrollbars, virtual keyboard, clipboard, configurable context menus, password mode or autocapitalization, for example.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Text.NativeMethods]
[Efl.Eo.BindingEntity]
public class Text : Efl.Ui.LayoutBase, Efl.IFile, Efl.IText, Efl.ITextFont, Efl.ITextFormat, Efl.ITextInteractive, Efl.ITextMarkup, Efl.ITextStyle, Efl.Access.IText, Efl.Access.Editable.IText, Efl.Input.IClickable, Efl.Ui.ITextSelectable
{
    /// <summary>Pointer to the native class description.</summary>
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

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
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
    public event EventHandler ChangedEvent
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
    /// <summary>Method to raise event ChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnChangedEvent(EventArgs e)
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
    /// <value><see cref="Efl.Ui.TextChangedUserEventArgs"/></value>
    public event EventHandler<Efl.Ui.TextChangedUserEventArgs> ChangedUserEvent
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
                        Efl.Ui.TextChangedUserEventArgs args = new Efl.Ui.TextChangedUserEventArgs();
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
    /// <summary>Method to raise event ChangedUserEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnChangedUserEvent(Efl.Ui.TextChangedUserEventArgs e)
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
    /// <value><see cref="Efl.Ui.TextValidateEventArgs"/></value>
    public event EventHandler<Efl.Ui.TextValidateEventArgs> ValidateEvent
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
                        Efl.Ui.TextValidateEventArgs args = new Efl.Ui.TextValidateEventArgs();
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
    /// <summary>Method to raise event ValidateEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnValidateEvent(Efl.Ui.TextValidateEventArgs e)
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
    public event EventHandler ContextOpenEvent
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
    /// <summary>Method to raise event ContextOpenEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContextOpenEvent(EventArgs e)
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
    public event EventHandler PreeditChangedEvent
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
    /// <summary>Method to raise event PreeditChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPreeditChangedEvent(EventArgs e)
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
    public event EventHandler PressEvent
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
    /// <summary>Method to raise event PressEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPressEvent(EventArgs e)
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
    public event EventHandler RedoRequestEvent
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
    /// <summary>Method to raise event RedoRequestEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnRedoRequestEvent(EventArgs e)
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
    public event EventHandler UndoRequestEvent
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
    /// <summary>Method to raise event UndoRequestEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnUndoRequestEvent(EventArgs e)
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
    public event EventHandler AbortedEvent
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
    /// <summary>Method to raise event AbortedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAbortedEvent(EventArgs e)
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
    /// <value><see cref="Efl.Ui.TextAnchorDownEventArgs"/></value>
    public event EventHandler<Efl.Ui.TextAnchorDownEventArgs> AnchorDownEvent
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
                        Efl.Ui.TextAnchorDownEventArgs args = new Efl.Ui.TextAnchorDownEventArgs();
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
    /// <summary>Method to raise event AnchorDownEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAnchorDownEvent(Efl.Ui.TextAnchorDownEventArgs e)
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
    /// <value><see cref="Efl.Ui.TextAnchorHoverOpenedEventArgs"/></value>
    public event EventHandler<Efl.Ui.TextAnchorHoverOpenedEventArgs> AnchorHoverOpenedEvent
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
                        Efl.Ui.TextAnchorHoverOpenedEventArgs args = new Efl.Ui.TextAnchorHoverOpenedEventArgs();
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
    /// <summary>Method to raise event AnchorHoverOpenedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAnchorHoverOpenedEvent(Efl.Ui.TextAnchorHoverOpenedEventArgs e)
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
    /// <value><see cref="Efl.Ui.TextAnchorInEventArgs"/></value>
    public event EventHandler<Efl.Ui.TextAnchorInEventArgs> AnchorInEvent
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
                        Efl.Ui.TextAnchorInEventArgs args = new Efl.Ui.TextAnchorInEventArgs();
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
    /// <summary>Method to raise event AnchorInEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAnchorInEvent(Efl.Ui.TextAnchorInEventArgs e)
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
    /// <value><see cref="Efl.Ui.TextAnchorOutEventArgs"/></value>
    public event EventHandler<Efl.Ui.TextAnchorOutEventArgs> AnchorOutEvent
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
                        Efl.Ui.TextAnchorOutEventArgs args = new Efl.Ui.TextAnchorOutEventArgs();
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
    /// <summary>Method to raise event AnchorOutEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAnchorOutEvent(Efl.Ui.TextAnchorOutEventArgs e)
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
    /// <value><see cref="Efl.Ui.TextAnchorUpEventArgs"/></value>
    public event EventHandler<Efl.Ui.TextAnchorUpEventArgs> AnchorUpEvent
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
                        Efl.Ui.TextAnchorUpEventArgs args = new Efl.Ui.TextAnchorUpEventArgs();
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
    /// <summary>Method to raise event AnchorUpEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAnchorUpEvent(Efl.Ui.TextAnchorUpEventArgs e)
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
    public event EventHandler CursorChangedManualEvent
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
    /// <summary>Method to raise event CursorChangedManualEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnCursorChangedManualEvent(EventArgs e)
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
    public event EventHandler TextSelectionChangedEvent
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
    /// <summary>Method to raise event TextSelectionChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnTextSelectionChangedEvent(EventArgs e)
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
    public event EventHandler AccessTextCaretMovedEvent
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
    /// <summary>Method to raise event AccessTextCaretMovedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAccessTextCaretMovedEvent(EventArgs e)
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
    /// <value><see cref="Efl.Access.TextAccessTextInsertedEventArgs"/></value>
    public event EventHandler<Efl.Access.TextAccessTextInsertedEventArgs> AccessTextInsertedEvent
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
                        Efl.Access.TextAccessTextInsertedEventArgs args = new Efl.Access.TextAccessTextInsertedEventArgs();
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
    /// <summary>Method to raise event AccessTextInsertedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAccessTextInsertedEvent(Efl.Access.TextAccessTextInsertedEventArgs e)
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
    /// <value><see cref="Efl.Access.TextAccessTextRemovedEventArgs"/></value>
    public event EventHandler<Efl.Access.TextAccessTextRemovedEventArgs> AccessTextRemovedEvent
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
                        Efl.Access.TextAccessTextRemovedEventArgs args = new Efl.Access.TextAccessTextRemovedEventArgs();
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
    /// <summary>Method to raise event AccessTextRemovedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAccessTextRemovedEvent(Efl.Access.TextAccessTextRemovedEventArgs e)
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
    public event EventHandler AccessTextSelectionChangedEvent
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
    /// <summary>Method to raise event AccessTextSelectionChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAccessTextSelectionChangedEvent(EventArgs e)
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
    /// <summary>Called when object is in sequence pressed and unpressed by the primary button</summary>
    /// <value><see cref="Efl.Input.ClickableClickedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableClickedEventArgs> ClickedEvent
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
                        Efl.Input.ClickableClickedEventArgs args = new Efl.Input.ClickableClickedEventArgs();
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

                string key = "_EFL_INPUT_EVENT_CLICKED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ClickedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnClickedEvent(Efl.Input.ClickableClickedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_CLICKED";
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
    /// <value><see cref="Efl.Input.ClickableClickedAnyEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableClickedAnyEventArgs> ClickedAnyEvent
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
                        Efl.Input.ClickableClickedAnyEventArgs args = new Efl.Input.ClickableClickedAnyEventArgs();
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

                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ClickedAnyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnClickedAnyEvent(Efl.Input.ClickableClickedAnyEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_CLICKED_ANY";
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
    /// <value><see cref="Efl.Input.ClickablePressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickablePressedEventArgs> PressedEvent
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
                        Efl.Input.ClickablePressedEventArgs args = new Efl.Input.ClickablePressedEventArgs();
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

                string key = "_EFL_INPUT_EVENT_PRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_PRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPressedEvent(Efl.Input.ClickablePressedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_PRESSED";
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
    /// <value><see cref="Efl.Input.ClickableUnpressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableUnpressedEventArgs> UnpressedEvent
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
                        Efl.Input.ClickableUnpressedEventArgs args = new Efl.Input.ClickableUnpressedEventArgs();
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

                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event UnpressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnUnpressedEvent(Efl.Input.ClickableUnpressedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_UNPRESSED";
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
    /// <value><see cref="Efl.Input.ClickableLongpressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableLongpressedEventArgs> LongpressedEvent
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
                        Efl.Input.ClickableLongpressedEventArgs args = new Efl.Input.ClickableLongpressedEventArgs();
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

                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event LongpressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLongpressedEvent(Efl.Input.ClickableLongpressedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_LONGPRESSED";
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
    /// <summary>Called when selection is pasted</summary>
    public event EventHandler SelectionPasteEvent
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
    /// <summary>Method to raise event SelectionPasteEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSelectionPasteEvent(EventArgs e)
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
    public event EventHandler SelectionCopyEvent
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
    /// <summary>Method to raise event SelectionCopyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSelectionCopyEvent(EventArgs e)
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
    public event EventHandler SelectionCutEvent
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
    /// <summary>Method to raise event SelectionCutEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSelectionCutEvent(EventArgs e)
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
    public event EventHandler SelectionStartEvent
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
    /// <summary>Method to raise event SelectionStartEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSelectionStartEvent(EventArgs e)
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
    public event EventHandler SelectionChangedEvent
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
    /// <summary>Method to raise event SelectionChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSelectionChangedEvent(EventArgs e)
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
    public event EventHandler SelectionClearedEvent
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
    /// <summary>Method to raise event SelectionClearedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSelectionClearedEvent(EventArgs e)
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
    /// <summary>Enable or disable scrolling in the widget.
    /// When scrolling is enabled scrollbars will appear if the text does not fit the widget size.</summary>
    /// <returns><c>true</c> to enable scrolling. Default is <c>false</c>.</returns>
    public virtual bool GetScrollable() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_scrollable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enable or disable scrolling in the widget.
    /// When scrolling is enabled scrollbars will appear if the text does not fit the widget size.</summary>
    /// <param name="scroll"><c>true</c> to enable scrolling. Default is <c>false</c>.</param>
    public virtual void SetScrollable(bool scroll) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_scrollable_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scroll);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The attribute to show the input panel in case of only a user&apos;s explicit Mouse Up event. It doesn&apos;t request to show the input panel even though it has focus.</summary>
    /// <returns>If <c>true</c>, the input panel will be shown in case of only Mouse up event. (Focus event will be ignored.)</returns>
    public virtual bool GetInputPanelShowOnDemand() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_show_on_demand_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The attribute to show the input panel in case of only a user&apos;s explicit Mouse Up event. It doesn&apos;t request to show the input panel even though it has focus.</summary>
    /// <param name="ondemand">If <c>true</c>, the input panel will be shown in case of only Mouse up event. (Focus event will be ignored.)</param>
    public virtual void SetInputPanelShowOnDemand(bool ondemand) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_show_on_demand_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ondemand);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This disables the entry&apos;s contextual (longpress) menu.</summary>
    /// <returns>If <c>true</c>, the menu is disabled.</returns>
    public virtual bool GetContextMenuDisabled() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_context_menu_disabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This disables the entry&apos;s contextual (longpress) menu.</summary>
    /// <param name="disabled">If <c>true</c>, the menu is disabled.</param>
    public virtual void SetContextMenuDisabled(bool disabled) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_context_menu_disabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),disabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control pasting of text and images for the widget.
    /// Normally the entry allows both text and images to be pasted.
    /// 
    /// Note: This only changes the behaviour of text.</summary>
    /// <returns>Format for copy &amp; paste.</returns>
    public virtual Efl.Ui.SelectionFormat GetCnpMode() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_cnp_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control pasting of text and images for the widget.
    /// Normally the entry allows both text and images to be pasted.
    /// 
    /// Note: This only changes the behaviour of text.</summary>
    /// <param name="format">Format for copy &amp; paste.</param>
    public virtual void SetCnpMode(Efl.Ui.SelectionFormat format) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_cnp_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),format);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The language mode of the input panel.
    /// This API can be used if you want to show the alphabet keyboard mode.</summary>
    /// <returns>Language to be set to the input panel.</returns>
    public virtual Elm.Input.Panel.Lang GetInputPanelLanguage() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_language_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The language mode of the input panel.
    /// This API can be used if you want to show the alphabet keyboard mode.</summary>
    /// <param name="lang">Language to be set to the input panel.</param>
    public virtual void SetInputPanelLanguage(Elm.Input.Panel.Lang lang) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_language_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),lang);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This disables the entry&apos;s selection handlers.</summary>
    /// <returns>If <c>true</c>, the selection handlers are disabled.</returns>
    public virtual bool GetSelectionHandlerDisabled() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_selection_handler_disabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This disables the entry&apos;s selection handlers.</summary>
    /// <param name="disabled">If <c>true</c>, the selection handlers are disabled.</param>
    public virtual void SetSelectionHandlerDisabled(bool disabled) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_selection_handler_disabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),disabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the input panel layout variation of the entry</summary>
    /// <returns>Layout variation type.</returns>
    public virtual int GetInputPanelLayoutVariation() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_layout_variation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the input panel layout variation of the entry</summary>
    /// <param name="variation">Layout variation type.</param>
    public virtual void SetInputPanelLayoutVariation(int variation) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_layout_variation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),variation);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the autocapitalization type on the immodule.</summary>
    /// <returns>The type of autocapitalization.</returns>
    public virtual Elm.Autocapital.Type GetAutocapitalType() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_autocapital_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the autocapitalization type on the immodule.</summary>
    /// <param name="autocapital_type">The type of autocapitalization.</param>
    public virtual void SetAutocapitalType(Elm.Autocapital.Type autocapital_type) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_autocapital_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),autocapital_type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Sets the entry to password mode.
    /// In password mode entries are implicitly single line and the display of any text inside them is replaced with asterisks (*).</summary>
    /// <returns>If true, password mode is enabled.</returns>
    public virtual bool GetPasswordMode() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_password_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the entry to password mode.
    /// In password mode entries are implicitly single line and the display of any text inside them is replaced with asterisks (*).</summary>
    /// <param name="password">If true, password mode is enabled.</param>
    public virtual void SetPasswordMode(bool password) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_password_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),password);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the return key on the input panel to be disabled.</summary>
    /// <returns>The state to put in in: <c>true</c> for disabled, <c>false</c> for enabled.</returns>
    public virtual bool GetInputPanelReturnKeyDisabled() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_return_key_disabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the return key on the input panel to be disabled.</summary>
    /// <param name="disabled">The state to put in in: <c>true</c> for disabled, <c>false</c> for enabled.</param>
    public virtual void SetInputPanelReturnKeyDisabled(bool disabled) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_return_key_disabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),disabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether the entry should allow predictive text.</summary>
    /// <returns>Whether the entry should allow predictive text.</returns>
    public virtual bool GetPredictionAllow() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_prediction_allow_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether the entry should allow predictive text.</summary>
    /// <param name="prediction">Whether the entry should allow predictive text.</param>
    public virtual void SetPredictionAllow(bool prediction) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_prediction_allow_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),prediction);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Sets the input hint which allows input methods to fine-tune their behavior.</summary>
    /// <returns>Input hint.</returns>
    public virtual Elm.Input.Hints GetInputHint() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_hint_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the input hint which allows input methods to fine-tune their behavior.</summary>
    /// <param name="hints">Input hint.</param>
    public virtual void SetInputHint(Elm.Input.Hints hints) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_hint_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hints);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the input panel layout of the entry.</summary>
    /// <returns>Layout type.</returns>
    public virtual Elm.Input.Panel.Layout GetInputPanelLayout() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_layout_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the input panel layout of the entry.</summary>
    /// <param name="layout">Layout type.</param>
    public virtual void SetInputPanelLayout(Elm.Input.Panel.Layout layout) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_layout_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),layout);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the &quot;return&quot; key type. This type is used to set string or icon on the &quot;return&quot; key of the input panel.
    /// An input panel displays the string or icon associated with this type.</summary>
    /// <returns>The type of &quot;return&quot; key on the input panel.</returns>
    public virtual Elm.Input.Panel.ReturnKey.Type GetInputPanelReturnKeyType() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_return_key_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the &quot;return&quot; key type. This type is used to set string or icon on the &quot;return&quot; key of the input panel.
    /// An input panel displays the string or icon associated with this type.</summary>
    /// <param name="return_key_type">The type of &quot;return&quot; key on the input panel.</param>
    public virtual void SetInputPanelReturnKeyType(Elm.Input.Panel.ReturnKey.Type return_key_type) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_return_key_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),return_key_type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Sets the attribute to show the input panel automatically.</summary>
    /// <returns>If <c>true</c>, the input panel is appeared when entry is clicked or has a focus.</returns>
    public virtual bool GetInputPanelEnabled() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the attribute to show the input panel automatically.</summary>
    /// <param name="enabled">If <c>true</c>, the input panel is appeared when entry is clicked or has a focus.</param>
    public virtual void SetInputPanelEnabled(bool enabled) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether the return key on the input panel is disabled automatically when entry has no text.
    /// If <c>enabled</c> is <c>true</c>, the return key on input panel is disabled when the entry has no text. The return key on the input panel is automatically enabled when the entry has text. The default value is <c>false</c>.</summary>
    /// <param name="enabled">If <c>true</c>, the return key is automatically disabled when the entry has no text.</param>
    public virtual void SetInputPanelReturnKeyAutoenabled(bool enabled) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_return_key_autoenabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The factory that provides item in the text e.g. &quot;emoticon/happy&quot; or &quot;href=file://image.jpg&quot; etc.</summary>
    /// <returns>Factory to create items</returns>
    public virtual Efl.Canvas.ITextFactory GetItemFactory() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_item_factory_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The factory that provides item in the text e.g. &quot;emoticon/happy&quot; or &quot;href=file://image.jpg&quot; etc.</summary>
    /// <param name="item_factory">Factory to create items</param>
    public virtual void SetItemFactory(Efl.Canvas.ITextFactory item_factory) {
                                 Efl.Ui.Text.NativeMethods.efl_ui_text_item_factory_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),item_factory);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Show the input panel (virtual keyboard) based on the input panel property of entry such as layout, autocapital types and so on.
    /// Note that input panel is shown or hidden automatically according to the focus state of entry widget. This API can be used in the case of manually controlling by using <see cref="Efl.Ui.Text.SetInputPanelEnabled"/>(en, <c>false</c>).</summary>
    public virtual void ShowInputPanel() {
         Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_show_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This executes a &quot;copy&quot; action on the selected text in the entry.</summary>
    public virtual void SelectionCopy() {
         Efl.Ui.Text.NativeMethods.efl_ui_text_selection_copy_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This clears and frees the items in a entry&apos;s contextual (longpress) menu.
    /// See also <see cref="Efl.Ui.Text.AddContextMenuItem"/>.</summary>
    public virtual void ClearContextMenu() {
         Efl.Ui.Text.NativeMethods.efl_ui_text_context_menu_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Set the input panel-specific data to deliver to the input panel.
    /// This API is used by applications to deliver specific data to the input panel. The data format MUST be negotiated by both application and the input panel. The size and format of data are defined by the input panel.</summary>
    /// <param name="data">The specific data to be set to the input panel.</param>
    /// <param name="len">The length of data, in bytes, to send to the input panel.</param>
    public virtual void SetInputPanelImdata(System.IntPtr data, int len) {
                                                         Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_imdata_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),data, len);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get the specific data of the current input panel.</summary>
    /// <param name="data">The specific data to be obtained from the input panel.</param>
    /// <param name="len">The length of data.</param>
    public virtual void GetInputPanelImdata(ref System.IntPtr data, out int len) {
                                                         Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_imdata_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref data, out len);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This executes a &quot;paste&quot; action in the entry.</summary>
    public virtual void SelectionPaste() {
         Efl.Ui.Text.NativeMethods.efl_ui_text_selection_paste_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Hide the input panel (virtual keyboard).
    /// Note that input panel is shown or hidden automatically according to the focus state of entry widget. This API can be used in the case of manually controlling by using <see cref="Efl.Ui.Text.SetInputPanelEnabled"/>(en, <c>false</c>)</summary>
    public virtual void HideInputPanel() {
         Efl.Ui.Text.NativeMethods.efl_ui_text_input_panel_hide_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This ends a selection within the entry as though the user had just released the mouse button while making a selection.</summary>
    public virtual void CursorSelectionEnd() {
         Efl.Ui.Text.NativeMethods.efl_ui_text_cursor_selection_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This executes a &quot;cut&quot; action on the selected text in the entry.</summary>
    public virtual void SelectionCut() {
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
    public virtual void AddContextMenuItem(System.String label, System.String icon_file, Elm.Icon.Type icon_type, EvasSmartCb func, System.IntPtr data) {
                                                                                                                                 Efl.Ui.Text.NativeMethods.efl_ui_text_context_menu_item_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),label, icon_file, icon_type, func, data);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Creates and returns a new cursor for the text.</summary>
    /// <returns>Text cursor</returns>
    public virtual Efl.TextCursorCursor NewCursor() {
         var _ret_var = Efl.Ui.Text.NativeMethods.efl_ui_text_cursor_new_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <returns>The handle to the <see cref="Eina.File"/> that will be used</returns>
    public virtual Eina.File GetMmap() {
         var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_mmap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <param name="f">The handle to the <see cref="Eina.File"/> that will be used</param>
    /// <returns>0 on success, error code otherwise</returns>
    public virtual Eina.Error SetMmap(Eina.File f) {
                                 var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_mmap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),f);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <returns>The file path.</returns>
    public virtual System.String GetFile() {
         var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <param name="file">The file path.</param>
    /// <returns>0 on success, error code otherwise</returns>
    public virtual Eina.Error SetFile(System.String file) {
                                 var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),file);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The key which corresponds to the target data within a file.
    /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <returns>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</returns>
    public virtual System.String GetKey() {
         var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_key_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The key which corresponds to the target data within a file.
    /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
    public virtual void SetKey(System.String key) {
                                 Efl.FileConcrete.NativeMethods.efl_file_key_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The load state of the object.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
    public virtual bool GetLoaded() {
         var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_loaded_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="Efl.IFile.File"/> (or <see cref="Efl.IFile.Mmap"/>) and <see cref="Efl.IFile.Key"/> properties.
    /// In the case where <see cref="Efl.IFile.SetFile"/> has been called on an object, this will internally open the file and call <see cref="Efl.IFile.SetMmap"/> on the object using the opened file handle.
    /// 
    /// Calling <see cref="Efl.IFile.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.
    /// (Since EFL 1.22)</summary>
    /// <returns>0 on success, error code otherwise</returns>
    public virtual Eina.Error Load() {
         var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_load_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Perform all necessary operations to unload file data from the object.
    /// In the case where <see cref="Efl.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
    /// 
    /// Calling <see cref="Efl.IFile.Unload"/> on an object which is not currently loaded will have no effect.
    /// (Since EFL 1.22)</summary>
    public virtual void Unload() {
         Efl.FileConcrete.NativeMethods.efl_file_unload_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The text string to be displayed by the given text object.
    /// Do not release (free) the returned value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Text string to display on it.</returns>
    public virtual System.String GetText() {
         var _ret_var = Efl.TextConcrete.NativeMethods.efl_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The text string to be displayed by the given text object.
    /// Do not release (free) the returned value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="text">Text string to display on it.</param>
    public virtual void SetText(System.String text) {
                                 Efl.TextConcrete.NativeMethods.efl_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),text);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The font family, filename and size for a given text object.
    /// This property controls the font name and size of a text object. The font string has to follow fontconfig&apos;s convention for naming fonts, as it&apos;s the underlying library used to query system fonts by Evas (see the fc-list command&apos;s output, on your system, to get an idea). Alternatively, youe can use the full path to a font file.
    /// 
    /// To skip changing font family pass null as font family. To skip changing font size pass 0 as font size.
    /// 
    /// When reading it, the font name string is still owned by Evas and should not be freed. See also <see cref="Efl.ITextFont.FontSource"/>.</summary>
    /// <param name="font">The font family name or filename.</param>
    /// <param name="size">The font size, in points.</param>
    public virtual void GetFont(out System.String font, out Efl.Font.Size size) {
                                                         Efl.TextFontConcrete.NativeMethods.efl_text_font_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out font, out size);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The font family, filename and size for a given text object.
    /// This property controls the font name and size of a text object. The font string has to follow fontconfig&apos;s convention for naming fonts, as it&apos;s the underlying library used to query system fonts by Evas (see the fc-list command&apos;s output, on your system, to get an idea). Alternatively, youe can use the full path to a font file.
    /// 
    /// To skip changing font family pass null as font family. To skip changing font size pass 0 as font size.
    /// 
    /// When reading it, the font name string is still owned by Evas and should not be freed. See also <see cref="Efl.ITextFont.FontSource"/>.</summary>
    /// <param name="font">The font family name or filename.</param>
    /// <param name="size">The font size, in points.</param>
    public virtual void SetFont(System.String font, Efl.Font.Size size) {
                                                         Efl.TextFontConcrete.NativeMethods.efl_text_font_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),font, size);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The font (source) file to be used on a given text object.
    /// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
    /// 
    /// See also <see cref="Efl.ITextFont.GetFont"/>.</summary>
    /// <returns>The font file&apos;s path.</returns>
    public virtual System.String GetFontSource() {
         var _ret_var = Efl.TextFontConcrete.NativeMethods.efl_text_font_source_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The font (source) file to be used on a given text object.
    /// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
    /// 
    /// See also <see cref="Efl.ITextFont.GetFont"/>.</summary>
    /// <param name="font_source">The font file&apos;s path.</param>
    public virtual void SetFontSource(System.String font_source) {
                                 Efl.TextFontConcrete.NativeMethods.efl_text_font_source_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),font_source);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Comma-separated list of font fallbacks
    /// Will be used in case the primary font isn&apos;t available.</summary>
    /// <returns>Font name fallbacks</returns>
    public virtual System.String GetFontFallbacks() {
         var _ret_var = Efl.TextFontConcrete.NativeMethods.efl_text_font_fallbacks_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Comma-separated list of font fallbacks
    /// Will be used in case the primary font isn&apos;t available.</summary>
    /// <param name="font_fallbacks">Font name fallbacks</param>
    public virtual void SetFontFallbacks(System.String font_fallbacks) {
                                 Efl.TextFontConcrete.NativeMethods.efl_text_font_fallbacks_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),font_fallbacks);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Type of weight of the displayed font
    /// Default is <see cref="Efl.TextFontWeight.Normal"/>.</summary>
    /// <returns>Font weight</returns>
    public virtual Efl.TextFontWeight GetFontWeight() {
         var _ret_var = Efl.TextFontConcrete.NativeMethods.efl_text_font_weight_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of weight of the displayed font
    /// Default is <see cref="Efl.TextFontWeight.Normal"/>.</summary>
    /// <param name="font_weight">Font weight</param>
    public virtual void SetFontWeight(Efl.TextFontWeight font_weight) {
                                 Efl.TextFontConcrete.NativeMethods.efl_text_font_weight_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),font_weight);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Type of slant of the displayed font
    /// Default is <see cref="Efl.TextFontSlant.Normal"/>.</summary>
    /// <returns>Font slant</returns>
    public virtual Efl.TextFontSlant GetFontSlant() {
         var _ret_var = Efl.TextFontConcrete.NativeMethods.efl_text_font_slant_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of slant of the displayed font
    /// Default is <see cref="Efl.TextFontSlant.Normal"/>.</summary>
    /// <param name="style">Font slant</param>
    public virtual void SetFontSlant(Efl.TextFontSlant style) {
                                 Efl.TextFontConcrete.NativeMethods.efl_text_font_slant_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),style);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Type of width of the displayed font
    /// Default is <see cref="Efl.TextFontWidth.Normal"/>.</summary>
    /// <returns>Font width</returns>
    public virtual Efl.TextFontWidth GetFontWidth() {
         var _ret_var = Efl.TextFontConcrete.NativeMethods.efl_text_font_width_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of width of the displayed font
    /// Default is <see cref="Efl.TextFontWidth.Normal"/>.</summary>
    /// <param name="width">Font width</param>
    public virtual void SetFontWidth(Efl.TextFontWidth width) {
                                 Efl.TextFontConcrete.NativeMethods.efl_text_font_width_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),width);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specific language of the displayed font
    /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.</summary>
    /// <returns>Language</returns>
    public virtual System.String GetFontLang() {
         var _ret_var = Efl.TextFontConcrete.NativeMethods.efl_text_font_lang_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specific language of the displayed font
    /// This is used to lookup fonts suitable to the specified language, as well as helping the font shaper backend. The language <c>lang</c> can be either a code e.g &quot;en_US&quot;, &quot;auto&quot; to use the system locale, or &quot;none&quot;.</summary>
    /// <param name="lang">Language</param>
    public virtual void SetFontLang(System.String lang) {
                                 Efl.TextFontConcrete.NativeMethods.efl_text_font_lang_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),lang);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
    /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.</summary>
    /// <returns>Scalable</returns>
    public virtual Efl.TextFontBitmapScalable GetFontBitmapScalable() {
         var _ret_var = Efl.TextFontConcrete.NativeMethods.efl_text_font_bitmap_scalable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The bitmap fonts have fixed size glyphs for several available sizes. Basically, it is not scalable. But, it needs to be scalable for some use cases. (ex. colorful emoji fonts)
    /// Default is <see cref="Efl.TextFontBitmapScalable.None"/>.</summary>
    /// <param name="scalable">Scalable</param>
    public virtual void SetFontBitmapScalable(Efl.TextFontBitmapScalable scalable) {
                                 Efl.TextFontConcrete.NativeMethods.efl_text_font_bitmap_scalable_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),scalable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Ellipsis value (number from -1.0 to 1.0)</summary>
    /// <returns>Ellipsis value</returns>
    public virtual double GetEllipsis() {
         var _ret_var = Efl.TextFormatConcrete.NativeMethods.efl_text_ellipsis_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Ellipsis value (number from -1.0 to 1.0)</summary>
    /// <param name="value">Ellipsis value</param>
    public virtual void SetEllipsis(double value) {
                                 Efl.TextFormatConcrete.NativeMethods.efl_text_ellipsis_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Wrap mode for use in the text</summary>
    /// <returns>Wrap mode</returns>
    public virtual Efl.TextFormatWrap GetWrap() {
         var _ret_var = Efl.TextFormatConcrete.NativeMethods.efl_text_wrap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Wrap mode for use in the text</summary>
    /// <param name="wrap">Wrap mode</param>
    public virtual void SetWrap(Efl.TextFormatWrap wrap) {
                                 Efl.TextFormatConcrete.NativeMethods.efl_text_wrap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),wrap);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Multiline is enabled or not</summary>
    /// <returns><c>true</c> if multiline is enabled, <c>false</c> otherwise</returns>
    public virtual bool GetMultiline() {
         var _ret_var = Efl.TextFormatConcrete.NativeMethods.efl_text_multiline_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Multiline is enabled or not</summary>
    /// <param name="enabled"><c>true</c> if multiline is enabled, <c>false</c> otherwise</param>
    public virtual void SetMultiline(bool enabled) {
                                 Efl.TextFormatConcrete.NativeMethods.efl_text_multiline_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Horizontal alignment of text</summary>
    /// <returns>Alignment type</returns>
    public virtual Efl.TextFormatHorizontalAlignmentAutoType GetHalignAutoType() {
         var _ret_var = Efl.TextFormatConcrete.NativeMethods.efl_text_halign_auto_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Horizontal alignment of text</summary>
    /// <param name="value">Alignment type</param>
    public virtual void SetHalignAutoType(Efl.TextFormatHorizontalAlignmentAutoType value) {
                                 Efl.TextFormatConcrete.NativeMethods.efl_text_halign_auto_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Horizontal alignment of text</summary>
    /// <returns>Horizontal alignment value</returns>
    public virtual double GetHalign() {
         var _ret_var = Efl.TextFormatConcrete.NativeMethods.efl_text_halign_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Horizontal alignment of text</summary>
    /// <param name="value">Horizontal alignment value</param>
    public virtual void SetHalign(double value) {
                                 Efl.TextFormatConcrete.NativeMethods.efl_text_halign_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Vertical alignment of text</summary>
    /// <returns>Vertical alignment value</returns>
    public virtual double GetValign() {
         var _ret_var = Efl.TextFormatConcrete.NativeMethods.efl_text_valign_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Vertical alignment of text</summary>
    /// <param name="value">Vertical alignment value</param>
    public virtual void SetValign(double value) {
                                 Efl.TextFormatConcrete.NativeMethods.efl_text_valign_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Minimal line gap (top and bottom) for each line in the text
    /// <c>value</c> is absolute size.</summary>
    /// <returns>Line gap value</returns>
    public virtual double GetLinegap() {
         var _ret_var = Efl.TextFormatConcrete.NativeMethods.efl_text_linegap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Minimal line gap (top and bottom) for each line in the text
    /// <c>value</c> is absolute size.</summary>
    /// <param name="value">Line gap value</param>
    public virtual void SetLinegap(double value) {
                                 Efl.TextFormatConcrete.NativeMethods.efl_text_linegap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Relative line gap (top and bottom) for each line in the text
    /// The original line gap value is multiplied by <c>value</c>.</summary>
    /// <returns>Relative line gap value</returns>
    public virtual double GetLinerelgap() {
         var _ret_var = Efl.TextFormatConcrete.NativeMethods.efl_text_linerelgap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Relative line gap (top and bottom) for each line in the text
    /// The original line gap value is multiplied by <c>value</c>.</summary>
    /// <param name="value">Relative line gap value</param>
    public virtual void SetLinerelgap(double value) {
                                 Efl.TextFormatConcrete.NativeMethods.efl_text_linerelgap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Tabstops value</summary>
    /// <returns>Tapstops value</returns>
    public virtual int GetTabstops() {
         var _ret_var = Efl.TextFormatConcrete.NativeMethods.efl_text_tabstops_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Tabstops value</summary>
    /// <param name="value">Tapstops value</param>
    public virtual void SetTabstops(int value) {
                                 Efl.TextFormatConcrete.NativeMethods.efl_text_tabstops_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether text is a password</summary>
    /// <returns><c>true</c> if the text is a password, <c>false</c> otherwise</returns>
    public virtual bool GetPassword() {
         var _ret_var = Efl.TextFormatConcrete.NativeMethods.efl_text_password_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether text is a password</summary>
    /// <param name="enabled"><c>true</c> if the text is a password, <c>false</c> otherwise</param>
    public virtual void SetPassword(bool enabled) {
                                 Efl.TextFormatConcrete.NativeMethods.efl_text_password_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The character used to replace characters that can&apos;t be displayed
    /// Currently only used to replace characters if <see cref="Efl.ITextFormat.Password"/> is enabled.</summary>
    /// <returns>Replacement character</returns>
    public virtual System.String GetReplacementChar() {
         var _ret_var = Efl.TextFormatConcrete.NativeMethods.efl_text_replacement_char_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The character used to replace characters that can&apos;t be displayed
    /// Currently only used to replace characters if <see cref="Efl.ITextFormat.Password"/> is enabled.</summary>
    /// <param name="repch">Replacement character</param>
    public virtual void SetReplacementChar(System.String repch) {
                                 Efl.TextFormatConcrete.NativeMethods.efl_text_replacement_char_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),repch);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether or not selection is allowed on this object</summary>
    /// <returns><c>true</c> if enabled, <c>false</c> otherwise</returns>
    public virtual bool GetSelectionAllowed() {
         var _ret_var = Efl.TextInteractiveConcrete.NativeMethods.efl_text_interactive_selection_allowed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether or not selection is allowed on this object</summary>
    /// <param name="allowed"><c>true</c> if enabled, <c>false</c> otherwise</param>
    public virtual void SetSelectionAllowed(bool allowed) {
                                 Efl.TextInteractiveConcrete.NativeMethods.efl_text_interactive_selection_allowed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),allowed);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The cursors used for selection handling.
    /// If the cursors are equal there&apos;s no selection.
    /// 
    /// You are allowed to retain and modify them. Modifying them modifies the selection of the object.</summary>
    /// <param name="start">The start of the selection</param>
    /// <param name="end">The end of the selection</param>
    public virtual void GetSelectionCursors(out Efl.TextCursorCursor start, out Efl.TextCursorCursor end) {
                                                         Efl.TextInteractiveConcrete.NativeMethods.efl_text_interactive_selection_cursors_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out start, out end);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Whether the entry is editable.
    /// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
    /// <returns>If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</returns>
    public virtual bool GetEditable() {
         var _ret_var = Efl.TextInteractiveConcrete.NativeMethods.efl_text_interactive_editable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether the entry is editable.
    /// By default text interactives are editable. However setting this property to <c>false</c> will make it so that key input will be disregarded.</summary>
    /// <param name="editable">If <c>true</c>, user input will be inserted in the entry, if not, the entry is read-only and no user input is allowed.</param>
    public virtual void SetEditable(bool editable) {
                                 Efl.TextInteractiveConcrete.NativeMethods.efl_text_interactive_editable_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),editable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Clears the selection.</summary>
    public virtual void SelectNone() {
         Efl.TextInteractiveConcrete.NativeMethods.efl_text_interactive_select_none_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Markup property</summary>
    /// <returns>The markup-text representation set to this text.</returns>
    public virtual System.String GetMarkup() {
         var _ret_var = Efl.TextMarkupConcrete.NativeMethods.efl_text_markup_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Markup property</summary>
    /// <param name="markup">The markup-text representation set to this text.</param>
    public virtual void SetMarkup(System.String markup) {
                                 Efl.TextMarkupConcrete.NativeMethods.efl_text_markup_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),markup);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of text, excluding style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void GetNormalColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_normal_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of text, excluding style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void SetNormalColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_normal_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Enable or disable backing type</summary>
    /// <returns>Backing type</returns>
    public virtual Efl.TextStyleBackingType GetBackingType() {
         var _ret_var = Efl.TextStyleConcrete.NativeMethods.efl_text_backing_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enable or disable backing type</summary>
    /// <param name="type">Backing type</param>
    public virtual void SetBackingType(Efl.TextStyleBackingType type) {
                                 Efl.TextStyleConcrete.NativeMethods.efl_text_backing_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Backing color</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void GetBackingColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_backing_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Backing color</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void SetBackingColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_backing_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Sets an underline style on the text</summary>
    /// <returns>Underline type</returns>
    public virtual Efl.TextStyleUnderlineType GetUnderlineType() {
         var _ret_var = Efl.TextStyleConcrete.NativeMethods.efl_text_underline_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets an underline style on the text</summary>
    /// <param name="type">Underline type</param>
    public virtual void SetUnderlineType(Efl.TextStyleUnderlineType type) {
                                 Efl.TextStyleConcrete.NativeMethods.efl_text_underline_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of normal underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void GetUnderlineColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_underline_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of normal underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void SetUnderlineColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_underline_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Height of underline style</summary>
    /// <returns>Height</returns>
    public virtual double GetUnderlineHeight() {
         var _ret_var = Efl.TextStyleConcrete.NativeMethods.efl_text_underline_height_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Height of underline style</summary>
    /// <param name="height">Height</param>
    public virtual void SetUnderlineHeight(double height) {
                                 Efl.TextStyleConcrete.NativeMethods.efl_text_underline_height_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),height);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of dashed underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void GetUnderlineDashedColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_underline_dashed_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of dashed underline style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void SetUnderlineDashedColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_underline_dashed_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Width of dashed underline style</summary>
    /// <returns>Width</returns>
    public virtual int GetUnderlineDashedWidth() {
         var _ret_var = Efl.TextStyleConcrete.NativeMethods.efl_text_underline_dashed_width_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Width of dashed underline style</summary>
    /// <param name="width">Width</param>
    public virtual void SetUnderlineDashedWidth(int width) {
                                 Efl.TextStyleConcrete.NativeMethods.efl_text_underline_dashed_width_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),width);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gap of dashed underline style</summary>
    /// <returns>Gap</returns>
    public virtual int GetUnderlineDashedGap() {
         var _ret_var = Efl.TextStyleConcrete.NativeMethods.efl_text_underline_dashed_gap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gap of dashed underline style</summary>
    /// <param name="gap">Gap</param>
    public virtual void SetUnderlineDashedGap(int gap) {
                                 Efl.TextStyleConcrete.NativeMethods.efl_text_underline_dashed_gap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),gap);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of underline2 style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void GetUnderline2Color(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_underline2_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of underline2 style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void SetUnderline2Color(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_underline2_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Type of strikethrough style</summary>
    /// <returns>Strikethrough type</returns>
    public virtual Efl.TextStyleStrikethroughType GetStrikethroughType() {
         var _ret_var = Efl.TextStyleConcrete.NativeMethods.efl_text_strikethrough_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of strikethrough style</summary>
    /// <param name="type">Strikethrough type</param>
    public virtual void SetStrikethroughType(Efl.TextStyleStrikethroughType type) {
                                 Efl.TextStyleConcrete.NativeMethods.efl_text_strikethrough_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of strikethrough_style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void GetStrikethroughColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_strikethrough_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of strikethrough_style</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void SetStrikethroughColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_strikethrough_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Type of effect used for the displayed text</summary>
    /// <returns>Effect type</returns>
    public virtual Efl.TextStyleEffectType GetEffectType() {
         var _ret_var = Efl.TextStyleConcrete.NativeMethods.efl_text_effect_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Type of effect used for the displayed text</summary>
    /// <param name="type">Effect type</param>
    public virtual void SetEffectType(Efl.TextStyleEffectType type) {
                                 Efl.TextStyleConcrete.NativeMethods.efl_text_effect_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of outline effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void GetOutlineColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_outline_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of outline effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void SetOutlineColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_outline_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Direction of shadow effect</summary>
    /// <returns>Shadow direction</returns>
    public virtual Efl.TextStyleShadowDirection GetShadowDirection() {
         var _ret_var = Efl.TextStyleConcrete.NativeMethods.efl_text_shadow_direction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Direction of shadow effect</summary>
    /// <param name="type">Shadow direction</param>
    public virtual void SetShadowDirection(Efl.TextStyleShadowDirection type) {
                                 Efl.TextStyleConcrete.NativeMethods.efl_text_shadow_direction_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Color of shadow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void GetShadowColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_shadow_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of shadow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void SetShadowColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_shadow_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void GetGlowColor(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_glow_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Color of glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void SetGlowColor(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_glow_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Second color of the glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void GetGlow2Color(out byte r, out byte g, out byte b, out byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_glow2_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out r, out g, out b, out a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Second color of the glow effect</summary>
    /// <param name="r">Red component</param>
    /// <param name="g">Green component</param>
    /// <param name="b">Blue component</param>
    /// <param name="a">Alpha component</param>
    public virtual void SetGlow2Color(byte r, byte g, byte b, byte a) {
                                                                                                         Efl.TextStyleConcrete.NativeMethods.efl_text_glow2_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),r, g, b, a);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Program that applies a special filter
    /// See <see cref="Efl.Gfx.IFilter"/>.</summary>
    /// <returns>Filter code</returns>
    public virtual System.String GetGfxFilter() {
         var _ret_var = Efl.TextStyleConcrete.NativeMethods.efl_text_gfx_filter_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Program that applies a special filter
    /// See <see cref="Efl.Gfx.IFilter"/>.</summary>
    /// <param name="code">Filter code</param>
    public virtual void SetGfxFilter(System.String code) {
                                 Efl.TextStyleConcrete.NativeMethods.efl_text_gfx_filter_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),code);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets single character present in accessible widget&apos;s text at given offset.</summary>
    /// <param name="offset">Position in text.</param>
    /// <returns>Character at offset. 0 when out-of bounds offset has been given. Codepoints between DC80 and DCFF indicate that string includes invalid UTF8 chars.</returns>
    protected virtual Eina.Unicode GetCharacter(int offset) {
                                 var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_character_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),offset);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Gets string, start and end offset in text according to given initial offset and granularity.</summary>
    /// <param name="granularity">Text granularity</param>
    /// <param name="start_offset">Offset indicating start of string according to given granularity. -1 in case of error.</param>
    /// <param name="end_offset">Offset indicating end of string according to given granularity. -1 in case of error.</param>
    /// <returns>Newly allocated UTF-8 encoded string. Must be free by a user.</returns>
    protected virtual System.String GetString(Efl.Access.TextGranularity granularity, int start_offset, int end_offset) {
                 var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
        var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                                                        var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_string_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),granularity, _in_start_offset, _in_end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Gets text of accessible widget.</summary>
    /// <param name="start_offset">Position in text.</param>
    /// <param name="end_offset">End offset of text.</param>
    /// <returns>UTF-8 encoded text.</returns>
    protected virtual System.String GetAccessText(int start_offset, int end_offset) {
                                                         var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start_offset, end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Gets offset position of caret (cursor)</summary>
    /// <returns>Offset</returns>
    protected virtual int GetCaretOffset() {
         var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_caret_offset_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Caret offset property</summary>
    /// <param name="offset">Offset</param>
    /// <returns><c>true</c> if caret was successfully moved, <c>false</c> otherwise.</returns>
    protected virtual bool SetCaretOffset(int offset) {
                                 var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_caret_offset_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),offset);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Indicate if a text attribute with a given name is set</summary>
    /// <param name="name">Text attribute name</param>
    /// <param name="start_offset">Position in text from which given attribute is set.</param>
    /// <param name="end_offset">Position in text to which given attribute is set.</param>
    /// <param name="value">Value of text attribute. Should be free()</param>
    /// <returns><c>true</c> if attribute name is set, <c>false</c> otherwise</returns>
    protected virtual bool GetAttribute(System.String name, int start_offset, int end_offset, out System.String value) {
                 var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
        var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                                                                                var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_attribute_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name, _in_start_offset, _in_end_offset, out value);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return _ret_var;
 }
    /// <summary>Gets list of all text attributes.</summary>
    /// <param name="start_offset">Start offset</param>
    /// <param name="end_offset">End offset</param>
    /// <returns>List of text attributes</returns>
    protected virtual Eina.List<Efl.Access.TextAttribute> GetTextAttributes(int start_offset, int end_offset) {
         var _in_start_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(start_offset);
        var _in_end_offset = Eina.PrimitiveConversion.ManagedToPointerAlloc(end_offset);
                                        var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_attributes_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_start_offset, _in_end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                        return new Eina.List<Efl.Access.TextAttribute>(_ret_var, true, true);
 }
    /// <summary>Default attributes</summary>
    /// <returns>List of default attributes</returns>
    protected virtual Eina.List<Efl.Access.TextAttribute> GetDefaultAttributes() {
         var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_default_attributes_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Access.TextAttribute>(_ret_var, true, true);
 }
    /// <summary>Character extents</summary>
    /// <param name="offset">Offset</param>
    /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="rect">Extents rectangle</param>
    /// <returns><c>true</c> if character extents, <c>false</c> otherwise</returns>
    protected virtual bool GetCharacterExtents(int offset, bool screen_coords, out Eina.Rect rect) {
                                                 var _out_rect = new Eina.Rect.NativeStruct();
                                var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_character_extents_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),offset, screen_coords, out _out_rect);
        Eina.Error.RaiseIfUnhandledException();
                        rect = _out_rect;
                                return _ret_var;
 }
    /// <summary>Character count</summary>
    /// <returns>Character count</returns>
    protected virtual int GetCharacterCount() {
         var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_character_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Offset at given point</summary>
    /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <returns>Offset</returns>
    protected virtual int GetOffsetAtPoint(bool screen_coords, int x, int y) {
                                                                                 var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_offset_at_point_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),screen_coords, x, y);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Bounded ranges</summary>
    /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="rect">Bounding box</param>
    /// <param name="xclip">xclip</param>
    /// <param name="yclip">yclip</param>
    /// <returns>List of ranges</returns>
    protected virtual Eina.List<Efl.Access.TextRange> GetBoundedRanges(bool screen_coords, Eina.Rect rect, Efl.Access.TextClipType xclip, Efl.Access.TextClipType yclip) {
                 Eina.Rect.NativeStruct _in_rect = rect;
                                                                                        var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_bounded_ranges_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),screen_coords, _in_rect, xclip, yclip);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return new Eina.List<Efl.Access.TextRange>(_ret_var, true, true);
 }
    /// <summary>Range extents</summary>
    /// <param name="screen_coords">If <c>true</c>, x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="start_offset">Start offset</param>
    /// <param name="end_offset">End offset</param>
    /// <param name="rect">Range rectangle</param>
    /// <returns><c>true</c> if range extents, <c>false</c> otherwise</returns>
    protected virtual bool GetRangeExtents(bool screen_coords, int start_offset, int end_offset, out Eina.Rect rect) {
                                                                 var _out_rect = new Eina.Rect.NativeStruct();
                                        var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_range_extents_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),screen_coords, start_offset, end_offset, out _out_rect);
        Eina.Error.RaiseIfUnhandledException();
                                rect = _out_rect;
                                        return _ret_var;
 }
    /// <summary>Selection count property</summary>
    /// <returns>Selection counter</returns>
    protected virtual int GetSelectionsCount() {
         var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_selections_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Selection property</summary>
    /// <param name="selection_number">Selection number for identification</param>
    /// <param name="start_offset">Selection start offset</param>
    /// <param name="end_offset">Selection end offset</param>
    protected virtual void GetAccessSelection(int selection_number, out int start_offset, out int end_offset) {
                                                                                 Efl.Access.TextConcrete.NativeMethods.efl_access_text_access_selection_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),selection_number, out start_offset, out end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Selection property</summary>
    /// <param name="selection_number">Selection number for identification</param>
    /// <param name="start_offset">Selection start offset</param>
    /// <param name="end_offset">Selection end offset</param>
    /// <returns><c>true</c> if selection was set, <c>false</c> otherwise</returns>
    protected virtual bool SetAccessSelection(int selection_number, int start_offset, int end_offset) {
                                                                                 var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_access_selection_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),selection_number, start_offset, end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Add selection</summary>
    /// <param name="start_offset">Start selection from this offset</param>
    /// <param name="end_offset">End selection at this offset</param>
    /// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
    protected virtual bool AddSelection(int start_offset, int end_offset) {
                                                         var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_selection_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start_offset, end_offset);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Remove selection</summary>
    /// <param name="selection_number">Selection number to be removed</param>
    /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
    protected virtual bool SelectionRemove(int selection_number) {
                                 var _ret_var = Efl.Access.TextConcrete.NativeMethods.efl_access_text_selection_remove_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),selection_number);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Editable content property</summary>
    /// <param name="kw_string">Content</param>
    /// <returns><c>true</c> if setting the value succeeded, <c>false</c> otherwise</returns>
    protected virtual bool SetTextContent(System.String kw_string) {
                                 var _ret_var = Efl.Access.Editable.TextConcrete.NativeMethods.efl_access_editable_text_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_string);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Insert text at given position</summary>
    /// <param name="kw_string">String to be inserted</param>
    /// <param name="position">Position to insert string</param>
    /// <returns><c>true</c> if insert succeeded, <c>false</c> otherwise</returns>
    protected virtual bool Insert(System.String kw_string, int position) {
                                                         var _ret_var = Efl.Access.Editable.TextConcrete.NativeMethods.efl_access_editable_text_insert_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_string, position);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Copy text between start and end parameter</summary>
    /// <param name="start">Start position to copy</param>
    /// <param name="end">End position to copy</param>
    /// <returns><c>true</c> if copy succeeded, <c>false</c> otherwise</returns>
    protected virtual bool Copy(int start, int end) {
                                                         var _ret_var = Efl.Access.Editable.TextConcrete.NativeMethods.efl_access_editable_text_copy_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Cut text between start and end parameter</summary>
    /// <param name="start">Start position to cut</param>
    /// <param name="end">End position to cut</param>
    /// <returns><c>true</c> if cut succeeded, <c>false</c> otherwise</returns>
    protected virtual bool Cut(int start, int end) {
                                                         var _ret_var = Efl.Access.Editable.TextConcrete.NativeMethods.efl_access_editable_text_cut_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Delete text between start and end parameter</summary>
    /// <param name="start">Start position to delete</param>
    /// <param name="end">End position to delete</param>
    /// <returns><c>true</c> if delete succeeded, <c>false</c> otherwise</returns>
    protected virtual bool Delete(int start, int end) {
                                                         var _ret_var = Efl.Access.Editable.TextConcrete.NativeMethods.efl_access_editable_text_delete_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start, end);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Paste text at given position</summary>
    /// <param name="position">Position to insert text</param>
    /// <returns><c>true</c> if paste succeeded, <c>false</c> otherwise</returns>
    protected virtual bool Paste(int position) {
                                 var _ret_var = Efl.Access.Editable.TextConcrete.NativeMethods.efl_access_editable_text_paste_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),position);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>This returns true if the given object is currently in event emission</summary>
    public virtual bool GetInteraction() {
         var _ret_var = Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_interaction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Change internal states that a button got pressed.
    /// When the button is already pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    protected virtual void Press(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_press_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Change internal states that a button got unpressed.
    /// When the button is not pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    protected virtual void Unpress(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_unpress_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts the internal state after a press call.
    /// This will stop the timer for longpress and set the state of the clickable mixin back into the unpressed state.</summary>
    protected virtual void ResetButtonState(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_button_state_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts ongoing longpress event.
    /// That is, this will stop the timer for longpress.</summary>
    protected virtual void LongpressAbort(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_longpress_abort_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Enable or disable scrolling in the widget.
    /// When scrolling is enabled scrollbars will appear if the text does not fit the widget size.</summary>
    /// <value><c>true</c> to enable scrolling. Default is <c>false</c>.</value>
    public bool Scrollable {
        get { return GetScrollable(); }
        set { SetScrollable(value); }
    }
    /// <summary>The attribute to show the input panel in case of only a user&apos;s explicit Mouse Up event. It doesn&apos;t request to show the input panel even though it has focus.</summary>
    /// <value>If <c>true</c>, the input panel will be shown in case of only Mouse up event. (Focus event will be ignored.)</value>
    public bool InputPanelShowOnDemand {
        get { return GetInputPanelShowOnDemand(); }
        set { SetInputPanelShowOnDemand(value); }
    }
    /// <summary>This disables the entry&apos;s contextual (longpress) menu.</summary>
    /// <value>If <c>true</c>, the menu is disabled.</value>
    public bool ContextMenuDisabled {
        get { return GetContextMenuDisabled(); }
        set { SetContextMenuDisabled(value); }
    }
    /// <summary>Control pasting of text and images for the widget.
    /// Normally the entry allows both text and images to be pasted.
    /// 
    /// Note: This only changes the behaviour of text.</summary>
    /// <value>Format for copy &amp; paste.</value>
    public Efl.Ui.SelectionFormat CnpMode {
        get { return GetCnpMode(); }
        set { SetCnpMode(value); }
    }
    /// <summary>The language mode of the input panel.
    /// This API can be used if you want to show the alphabet keyboard mode.</summary>
    /// <value>Language to be set to the input panel.</value>
    public Elm.Input.Panel.Lang InputPanelLanguage {
        get { return GetInputPanelLanguage(); }
        set { SetInputPanelLanguage(value); }
    }
    /// <summary>This disables the entry&apos;s selection handlers.</summary>
    /// <value>If <c>true</c>, the selection handlers are disabled.</value>
    public bool SelectionHandlerDisabled {
        get { return GetSelectionHandlerDisabled(); }
        set { SetSelectionHandlerDisabled(value); }
    }
    /// <summary>Set the input panel layout variation of the entry</summary>
    /// <value>Layout variation type.</value>
    public int InputPanelLayoutVariation {
        get { return GetInputPanelLayoutVariation(); }
        set { SetInputPanelLayoutVariation(value); }
    }
    /// <summary>Set the autocapitalization type on the immodule.</summary>
    /// <value>The type of autocapitalization.</value>
    public Elm.Autocapital.Type AutocapitalType {
        get { return GetAutocapitalType(); }
        set { SetAutocapitalType(value); }
    }
    /// <summary>Sets the entry to password mode.
    /// In password mode entries are implicitly single line and the display of any text inside them is replaced with asterisks (*).</summary>
    /// <value>If true, password mode is enabled.</value>
    public bool PasswordMode {
        get { return GetPasswordMode(); }
        set { SetPasswordMode(value); }
    }
    /// <summary>Set the return key on the input panel to be disabled.</summary>
    /// <value>The state to put in in: <c>true</c> for disabled, <c>false</c> for enabled.</value>
    public bool InputPanelReturnKeyDisabled {
        get { return GetInputPanelReturnKeyDisabled(); }
        set { SetInputPanelReturnKeyDisabled(value); }
    }
    /// <summary>Whether the entry should allow predictive text.</summary>
    /// <value>Whether the entry should allow predictive text.</value>
    public bool PredictionAllow {
        get { return GetPredictionAllow(); }
        set { SetPredictionAllow(value); }
    }
    /// <summary>Sets the input hint which allows input methods to fine-tune their behavior.</summary>
    /// <value>Input hint.</value>
    public Elm.Input.Hints InputHint {
        get { return GetInputHint(); }
        set { SetInputHint(value); }
    }
    /// <summary>Set the input panel layout of the entry.</summary>
    /// <value>Layout type.</value>
    public Elm.Input.Panel.Layout InputPanelLayout {
        get { return GetInputPanelLayout(); }
        set { SetInputPanelLayout(value); }
    }
    /// <summary>Set the &quot;return&quot; key type. This type is used to set string or icon on the &quot;return&quot; key of the input panel.
    /// An input panel displays the string or icon associated with this type.</summary>
    /// <value>The type of &quot;return&quot; key on the input panel.</value>
    public Elm.Input.Panel.ReturnKey.Type InputPanelReturnKeyType {
        get { return GetInputPanelReturnKeyType(); }
        set { SetInputPanelReturnKeyType(value); }
    }
    /// <summary>Sets the attribute to show the input panel automatically.</summary>
    /// <value>If <c>true</c>, the input panel is appeared when entry is clicked or has a focus.</value>
    public bool InputPanelEnabled {
        get { return GetInputPanelEnabled(); }
        set { SetInputPanelEnabled(value); }
    }
    /// <summary>Whether the return key on the input panel is disabled automatically when entry has no text.
    /// If <c>enabled</c> is <c>true</c>, the return key on input panel is disabled when the entry has no text. The return key on the input panel is automatically enabled when the entry has text. The default value is <c>false</c>.</summary>
    /// <value>If <c>true</c>, the return key is automatically disabled when the entry has no text.</value>
    public bool InputPanelReturnKeyAutoenabled {
        set { SetInputPanelReturnKeyAutoenabled(value); }
    }
    /// <summary>The factory that provides item in the text e.g. &quot;emoticon/happy&quot; or &quot;href=file://image.jpg&quot; etc.</summary>
    /// <value>Factory to create items</value>
    public Efl.Canvas.ITextFactory ItemFactory {
        get { return GetItemFactory(); }
        set { SetItemFactory(value); }
    }
    /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <value>The handle to the <see cref="Eina.File"/> that will be used</value>
    public Eina.File Mmap {
        get { return GetMmap(); }
        set { SetMmap(value); }
    }
    /// <summary>The file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <value>The file path.</value>
    public System.String File {
        get { return GetFile(); }
        set { SetFile(value); }
    }
    /// <summary>The key which corresponds to the target data within a file.
    /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
    public System.String Key {
        get { return GetKey(); }
        set { SetKey(value); }
    }
    /// <summary>The load state of the object.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if the object is loaded, <c>false</c> otherwise.</value>
    public bool Loaded {
        get { return GetLoaded(); }
    }
    /// <summary>The font family, filename and size for a given text object.
    /// This property controls the font name and size of a text object. The font string has to follow fontconfig&apos;s convention for naming fonts, as it&apos;s the underlying library used to query system fonts by Evas (see the fc-list command&apos;s output, on your system, to get an idea). Alternatively, youe can use the full path to a font file.
    /// 
    /// To skip changing font family pass null as font family. To skip changing font size pass 0 as font size.
    /// 
    /// When reading it, the font name string is still owned by Evas and should not be freed. See also <see cref="Efl.ITextFont.FontSource"/>.</summary>
    /// <value>The font family name or filename.</value>
    public (System.String, Efl.Font.Size) Font {
        get {
            System.String _out_font = default(System.String);
            Efl.Font.Size _out_size = default(Efl.Font.Size);
            GetFont(out _out_font,out _out_size);
            return (_out_font,_out_size);
        }
        set { SetFont( value.Item1,  value.Item2); }
    }
    /// <summary>The font (source) file to be used on a given text object.
    /// This function allows the font file to be explicitly set for a given text object, overriding system lookup, which will first occur in the given file&apos;s contents.
    /// 
    /// See also <see cref="Efl.ITextFont.GetFont"/>.</summary>
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
    /// <summary>The cursors used for selection handling.
    /// If the cursors are equal there&apos;s no selection.
    /// 
    /// You are allowed to retain and modify them. Modifying them modifies the selection of the object.</summary>
    public (Efl.TextCursorCursor, Efl.TextCursorCursor) SelectionCursors {
        get {
            Efl.TextCursorCursor _out_start = default(Efl.TextCursorCursor);
            Efl.TextCursorCursor _out_end = default(Efl.TextCursorCursor);
            GetSelectionCursors(out _out_start,out _out_end);
            return (_out_start,_out_end);
        }
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
    /// <summary>Color of text, excluding style</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) NormalColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetNormalColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetNormalColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Enable or disable backing type</summary>
    /// <value>Backing type</value>
    public Efl.TextStyleBackingType BackingType {
        get { return GetBackingType(); }
        set { SetBackingType(value); }
    }
    /// <summary>Backing color</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) BackingColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetBackingColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetBackingColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Sets an underline style on the text</summary>
    /// <value>Underline type</value>
    public Efl.TextStyleUnderlineType UnderlineType {
        get { return GetUnderlineType(); }
        set { SetUnderlineType(value); }
    }
    /// <summary>Color of normal underline style</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) UnderlineColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetUnderlineColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetUnderlineColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Height of underline style</summary>
    /// <value>Height</value>
    public double UnderlineHeight {
        get { return GetUnderlineHeight(); }
        set { SetUnderlineHeight(value); }
    }
    /// <summary>Color of dashed underline style</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) UnderlineDashedColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetUnderlineDashedColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetUnderlineDashedColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
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
    /// <summary>Color of underline2 style</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) Underline2Color {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetUnderline2Color(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetUnderline2Color( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Type of strikethrough style</summary>
    /// <value>Strikethrough type</value>
    public Efl.TextStyleStrikethroughType StrikethroughType {
        get { return GetStrikethroughType(); }
        set { SetStrikethroughType(value); }
    }
    /// <summary>Color of strikethrough_style</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) StrikethroughColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetStrikethroughColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetStrikethroughColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Type of effect used for the displayed text</summary>
    /// <value>Effect type</value>
    public Efl.TextStyleEffectType EffectType {
        get { return GetEffectType(); }
        set { SetEffectType(value); }
    }
    /// <summary>Color of outline effect</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) OutlineColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetOutlineColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetOutlineColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Direction of shadow effect</summary>
    /// <value>Shadow direction</value>
    public Efl.TextStyleShadowDirection ShadowDirection {
        get { return GetShadowDirection(); }
        set { SetShadowDirection(value); }
    }
    /// <summary>Color of shadow effect</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) ShadowColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetShadowColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetShadowColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Color of glow effect</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) GlowColor {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetGlowColor(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetGlowColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
    }
    /// <summary>Second color of the glow effect</summary>
    /// <value>Red component</value>
    public (byte, byte, byte, byte) Glow2Color {
        get {
            byte _out_r = default(byte);
            byte _out_g = default(byte);
            byte _out_b = default(byte);
            byte _out_a = default(byte);
            GetGlow2Color(out _out_r,out _out_g,out _out_b,out _out_a);
            return (_out_r,_out_g,_out_b,_out_a);
        }
        set { SetGlow2Color( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
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
    protected int CaretOffset {
        get { return GetCaretOffset(); }
        set { SetCaretOffset(value); }
    }
    /// <summary>Default attributes</summary>
    /// <value>List of default attributes</value>
    protected Eina.List<Efl.Access.TextAttribute> DefaultAttributes {
        get { return GetDefaultAttributes(); }
    }
    /// <summary>Character count</summary>
    /// <value>Character count</value>
    protected int CharacterCount {
        get { return GetCharacterCount(); }
    }
    /// <summary>Selection count property</summary>
    /// <value>Selection counter</value>
    protected int SelectionsCount {
        get { return GetSelectionsCount(); }
    }
    /// <summary>Editable content property</summary>
    /// <value>Content</value>
    protected System.String TextContent {
        set { SetTextContent(value); }
    }
    /// <summary>This returns true if the given object is currently in event emission</summary>
    public bool Interaction {
        get { return GetInteraction(); }
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
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
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

            if (efl_input_clickable_press_static_delegate == null)
            {
                efl_input_clickable_press_static_delegate = new efl_input_clickable_press_delegate(press);
            }

            if (methods.FirstOrDefault(m => m.Name == "Press") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_press"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_press_static_delegate) });
            }

            if (efl_input_clickable_unpress_static_delegate == null)
            {
                efl_input_clickable_unpress_static_delegate = new efl_input_clickable_unpress_delegate(unpress);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unpress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_unpress"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_unpress_static_delegate) });
            }

            if (efl_input_clickable_button_state_reset_static_delegate == null)
            {
                efl_input_clickable_button_state_reset_static_delegate = new efl_input_clickable_button_state_reset_delegate(button_state_reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "ResetButtonState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_button_state_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_button_state_reset_static_delegate) });
            }

            if (efl_input_clickable_longpress_abort_static_delegate == null)
            {
                efl_input_clickable_longpress_abort_static_delegate = new efl_input_clickable_longpress_abort_delegate(longpress_abort);
            }

            if (methods.FirstOrDefault(m => m.Name == "LongpressAbort") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_longpress_abort"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_longpress_abort_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
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

        
        private delegate void efl_input_clickable_press_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_press_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_press_api_delegate> efl_input_clickable_press_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_press_api_delegate>(Module, "efl_input_clickable_press");

        private static void press(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_press was called");
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
                efl_input_clickable_press_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_press_delegate efl_input_clickable_press_static_delegate;

        
        private delegate void efl_input_clickable_unpress_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_unpress_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_unpress_api_delegate> efl_input_clickable_unpress_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_unpress_api_delegate>(Module, "efl_input_clickable_unpress");

        private static void unpress(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_unpress was called");
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
                efl_input_clickable_unpress_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_unpress_delegate efl_input_clickable_unpress_static_delegate;

        
        private delegate void efl_input_clickable_button_state_reset_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_button_state_reset_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate> efl_input_clickable_button_state_reset_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate>(Module, "efl_input_clickable_button_state_reset");

        private static void button_state_reset(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_button_state_reset was called");
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
                efl_input_clickable_button_state_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_button_state_reset_delegate efl_input_clickable_button_state_reset_static_delegate;

        
        private delegate void efl_input_clickable_longpress_abort_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_longpress_abort_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate> efl_input_clickable_longpress_abort_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate>(Module, "efl_input_clickable_longpress_abort");

        private static void longpress_abort(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_longpress_abort was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Text)ws.Target).LongpressAbort(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_clickable_longpress_abort_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_longpress_abort_delegate efl_input_clickable_longpress_abort_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiText_ExtensionMethods {
    public static Efl.BindableProperty<bool> Scrollable<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<bool>("scrollable", fac);
    }

    public static Efl.BindableProperty<bool> InputPanelShowOnDemand<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<bool>("input_panel_show_on_demand", fac);
    }

    public static Efl.BindableProperty<bool> ContextMenuDisabled<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<bool>("context_menu_disabled", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.SelectionFormat> CnpMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Efl.Ui.SelectionFormat>("cnp_mode", fac);
    }

    public static Efl.BindableProperty<Elm.Input.Panel.Lang> InputPanelLanguage<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Elm.Input.Panel.Lang>("input_panel_language", fac);
    }

    public static Efl.BindableProperty<bool> SelectionHandlerDisabled<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<bool>("selection_handler_disabled", fac);
    }

    public static Efl.BindableProperty<int> InputPanelLayoutVariation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<int>("input_panel_layout_variation", fac);
    }

    public static Efl.BindableProperty<Elm.Autocapital.Type> AutocapitalType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Elm.Autocapital.Type>("autocapital_type", fac);
    }

    public static Efl.BindableProperty<bool> PasswordMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<bool>("password_mode", fac);
    }

    public static Efl.BindableProperty<bool> InputPanelReturnKeyDisabled<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<bool>("input_panel_return_key_disabled", fac);
    }

    public static Efl.BindableProperty<bool> PredictionAllow<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<bool>("prediction_allow", fac);
    }

    public static Efl.BindableProperty<Elm.Input.Hints> InputHint<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Elm.Input.Hints>("input_hint", fac);
    }

    public static Efl.BindableProperty<Elm.Input.Panel.Layout> InputPanelLayout<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Elm.Input.Panel.Layout>("input_panel_layout", fac);
    }

    public static Efl.BindableProperty<Elm.Input.Panel.ReturnKey.Type> InputPanelReturnKeyType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Elm.Input.Panel.ReturnKey.Type>("input_panel_return_key_type", fac);
    }

    public static Efl.BindableProperty<bool> InputPanelEnabled<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<bool>("input_panel_enabled", fac);
    }

    public static Efl.BindableProperty<bool> InputPanelReturnKeyAutoenabled<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<bool>("input_panel_return_key_autoenabled", fac);
    }

    public static Efl.BindableProperty<Efl.Canvas.ITextFactory> ItemFactory<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Efl.Canvas.ITextFactory>("item_factory", fac);
    }

    public static Efl.BindableProperty<Eina.File> Mmap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Eina.File>("mmap", fac);
    }

    public static Efl.BindableProperty<System.String> File<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<System.String>("file", fac);
    }

    public static Efl.BindableProperty<System.String> Key<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<System.String>("key", fac);
    }

    
    
    
    public static Efl.BindableProperty<System.String> FontSource<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<System.String>("font_source", fac);
    }

    public static Efl.BindableProperty<System.String> FontFallbacks<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<System.String>("font_fallbacks", fac);
    }

    public static Efl.BindableProperty<Efl.TextFontWeight> FontWeight<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Efl.TextFontWeight>("font_weight", fac);
    }

    public static Efl.BindableProperty<Efl.TextFontSlant> FontSlant<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Efl.TextFontSlant>("font_slant", fac);
    }

    public static Efl.BindableProperty<Efl.TextFontWidth> FontWidth<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Efl.TextFontWidth>("font_width", fac);
    }

    public static Efl.BindableProperty<System.String> FontLang<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<System.String>("font_lang", fac);
    }

    public static Efl.BindableProperty<Efl.TextFontBitmapScalable> FontBitmapScalable<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Efl.TextFontBitmapScalable>("font_bitmap_scalable", fac);
    }

    public static Efl.BindableProperty<double> Ellipsis<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<double>("ellipsis", fac);
    }

    public static Efl.BindableProperty<Efl.TextFormatWrap> Wrap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Efl.TextFormatWrap>("wrap", fac);
    }

    public static Efl.BindableProperty<bool> Multiline<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<bool>("multiline", fac);
    }

    public static Efl.BindableProperty<Efl.TextFormatHorizontalAlignmentAutoType> HalignAutoType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Efl.TextFormatHorizontalAlignmentAutoType>("halign_auto_type", fac);
    }

    public static Efl.BindableProperty<double> Halign<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<double>("halign", fac);
    }

    public static Efl.BindableProperty<double> Valign<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<double>("valign", fac);
    }

    public static Efl.BindableProperty<double> Linegap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<double>("linegap", fac);
    }

    public static Efl.BindableProperty<double> Linerelgap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<double>("linerelgap", fac);
    }

    public static Efl.BindableProperty<int> Tabstops<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<int>("tabstops", fac);
    }

    public static Efl.BindableProperty<bool> Password<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<bool>("password", fac);
    }

    public static Efl.BindableProperty<System.String> ReplacementChar<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<System.String>("replacement_char", fac);
    }

    public static Efl.BindableProperty<bool> SelectionAllowed<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<bool>("selection_allowed", fac);
    }

    
    public static Efl.BindableProperty<bool> Editable<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<bool>("editable", fac);
    }

    public static Efl.BindableProperty<System.String> Markup<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<System.String>("markup", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleBackingType> BackingType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Efl.TextStyleBackingType>("backing_type", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleUnderlineType> UnderlineType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Efl.TextStyleUnderlineType>("underline_type", fac);
    }

    
    public static Efl.BindableProperty<double> UnderlineHeight<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<double>("underline_height", fac);
    }

    
    public static Efl.BindableProperty<int> UnderlineDashedWidth<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<int>("underline_dashed_width", fac);
    }

    public static Efl.BindableProperty<int> UnderlineDashedGap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<int>("underline_dashed_gap", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleStrikethroughType> StrikethroughType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Efl.TextStyleStrikethroughType>("strikethrough_type", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleEffectType> EffectType<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Efl.TextStyleEffectType>("effect_type", fac);
    }

    
    public static Efl.BindableProperty<Efl.TextStyleShadowDirection> ShadowDirection<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<Efl.TextStyleShadowDirection>("shadow_direction", fac);
    }

    
    
    
    public static Efl.BindableProperty<System.String> GfxFilter<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<System.String>("gfx_filter", fac);
    }

    
    
    
    public static Efl.BindableProperty<int> CaretOffset<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<int>("caret_offset", fac);
    }

    
    
    
    
    
    
    
    
    
    
    public static Efl.BindableProperty<System.String> TextContent<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Text, T>magic = null) where T : Efl.Ui.Text {
        return new Efl.BindableProperty<System.String>("text_content", fac);
    }

    
}
#pragma warning restore CS1591
#endif
