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

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemRealizedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ListViewItemRealizedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Ui.ListViewItemEvent arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemUnrealizedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ListViewItemUnrealizedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Ui.ListViewItemEvent arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemFocusedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ListViewItemFocusedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Ui.ListViewItemEvent arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemUnfocusedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ListViewItemUnfocusedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Ui.ListViewItemEvent arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemHighlightedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ListViewItemHighlightedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Ui.ListViewItemEvent arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemUnhighlightedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ListViewItemUnhighlightedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Ui.ListViewItemEvent arg { get; set; }
}
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.ListView.NativeMethods]
[Efl.Eo.BindingEntity]
public class ListView : Efl.Ui.LayoutBase, Efl.Access.ISelection, Efl.Ui.IContainerSelectable, Efl.Ui.IListViewModel, Efl.Ui.IScrollable, Efl.Ui.IScrollableInteractive, Efl.Ui.IScrollbar, Efl.Ui.IWidgetFocusManager, Efl.Ui.Focus.IComposition, Efl.Ui.Focus.IManager, Efl.Ui.Focus.IManagerSub
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ListView))
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
        efl_ui_list_view_class_get();
    /// <summary>Initializes a new instance of the <see cref="ListView"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public ListView(Efl.Object parent
            , System.String style = null) : base(efl_ui_list_view_class_get(), parent)
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
    protected ListView(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ListView"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected ListView(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="ListView"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected ListView(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <value><see cref="Efl.Ui.ListViewItemRealizedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ListViewItemRealizedEventArgs> ItemRealizedEvent
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
                        Efl.Ui.ListViewItemRealizedEventArgs args = new Efl.Ui.ListViewItemRealizedEventArgs();
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

                string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_REALIZED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_REALIZED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ItemRealizedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemRealizedEvent(Efl.Ui.ListViewItemRealizedEventArgs e)
    {
        var key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_REALIZED";
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
    /// <value><see cref="Efl.Ui.ListViewItemUnrealizedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ListViewItemUnrealizedEventArgs> ItemUnrealizedEvent
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
                        Efl.Ui.ListViewItemUnrealizedEventArgs args = new Efl.Ui.ListViewItemUnrealizedEventArgs();
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

                string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNREALIZED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNREALIZED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ItemUnrealizedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemUnrealizedEvent(Efl.Ui.ListViewItemUnrealizedEventArgs e)
    {
        var key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNREALIZED";
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
    /// <value><see cref="Efl.Ui.ListViewItemFocusedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ListViewItemFocusedEventArgs> ItemFocusedEvent
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
                        Efl.Ui.ListViewItemFocusedEventArgs args = new Efl.Ui.ListViewItemFocusedEventArgs();
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

                string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_FOCUSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_FOCUSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ItemFocusedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemFocusedEvent(Efl.Ui.ListViewItemFocusedEventArgs e)
    {
        var key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_FOCUSED";
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
    /// <value><see cref="Efl.Ui.ListViewItemUnfocusedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ListViewItemUnfocusedEventArgs> ItemUnfocusedEvent
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
                        Efl.Ui.ListViewItemUnfocusedEventArgs args = new Efl.Ui.ListViewItemUnfocusedEventArgs();
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

                string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNFOCUSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNFOCUSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ItemUnfocusedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemUnfocusedEvent(Efl.Ui.ListViewItemUnfocusedEventArgs e)
    {
        var key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNFOCUSED";
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
    /// <value><see cref="Efl.Ui.ListViewItemHighlightedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ListViewItemHighlightedEventArgs> ItemHighlightedEvent
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
                        Efl.Ui.ListViewItemHighlightedEventArgs args = new Efl.Ui.ListViewItemHighlightedEventArgs();
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

                string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_HIGHLIGHTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_HIGHLIGHTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ItemHighlightedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemHighlightedEvent(Efl.Ui.ListViewItemHighlightedEventArgs e)
    {
        var key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_HIGHLIGHTED";
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
    /// <value><see cref="Efl.Ui.ListViewItemUnhighlightedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ListViewItemUnhighlightedEventArgs> ItemUnhighlightedEvent
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
                        Efl.Ui.ListViewItemUnhighlightedEventArgs args = new Efl.Ui.ListViewItemUnhighlightedEventArgs();
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

                string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNHIGHLIGHTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNHIGHLIGHTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ItemUnhighlightedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemUnhighlightedEvent(Efl.Ui.ListViewItemUnhighlightedEventArgs e)
    {
        var key = "_EFL_UI_LIST_VIEW_EVENT_ITEM_UNHIGHLIGHTED";
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
    /// <summary>Called when selection has been changed.</summary>
    public event EventHandler AccessSelectionChangedEvent
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

                string key = "_EFL_ACCESS_SELECTION_EVENT_ACCESS_SELECTION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_SELECTION_EVENT_ACCESS_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event AccessSelectionChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnAccessSelectionChangedEvent(EventArgs e)
    {
        var key = "_EFL_ACCESS_SELECTION_EVENT_ACCESS_SELECTION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when selected</summary>
    /// <value><see cref="Efl.Ui.ContainerSelectableItemSelectedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ContainerSelectableItemSelectedEventArgs> ItemSelectedEvent
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
                        Efl.Ui.ContainerSelectableItemSelectedEventArgs args = new Efl.Ui.ContainerSelectableItemSelectedEventArgs();
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
    /// <summary>Method to raise event ItemSelectedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemSelectedEvent(Efl.Ui.ContainerSelectableItemSelectedEventArgs e)
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
    /// <value><see cref="Efl.Ui.ContainerSelectableItemUnselectedEventArgs"/></value>
    public event EventHandler<Efl.Ui.ContainerSelectableItemUnselectedEventArgs> ItemUnselectedEvent
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
                        Efl.Ui.ContainerSelectableItemUnselectedEventArgs args = new Efl.Ui.ContainerSelectableItemUnselectedEventArgs();
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
    /// <summary>Method to raise event ItemUnselectedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnItemUnselectedEvent(Efl.Ui.ContainerSelectableItemUnselectedEventArgs e)
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
    /// <summary>Called when scroll operation starts</summary>
    public event EventHandler ScrollStartedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_STARTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_STARTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollStartedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollStartedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_STARTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling</summary>
    public event EventHandler ScrollChangedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll operation finishes</summary>
    public event EventHandler ScrollFinishedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_FINISHED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_FINISHED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollFinishedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollFinishedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_FINISHED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling upwards</summary>
    public event EventHandler ScrollUpEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_UP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_UP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollUpEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollUpEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_UP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling downwards</summary>
    public event EventHandler ScrollDownEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_DOWN";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_DOWN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollDownEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollDownEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_DOWN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling left</summary>
    public event EventHandler ScrollLeftEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_LEFT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_LEFT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollLeftEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollLeftEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_LEFT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling right</summary>
    public event EventHandler ScrollRightEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollRightEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollRightEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_RIGHT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when hitting the top edge</summary>
    public event EventHandler EdgeUpEvent
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

                string key = "_EFL_UI_EVENT_EDGE_UP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_EDGE_UP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event EdgeUpEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnEdgeUpEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_EDGE_UP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when hitting the bottom edge</summary>
    public event EventHandler EdgeDownEvent
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

                string key = "_EFL_UI_EVENT_EDGE_DOWN";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_EDGE_DOWN";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event EdgeDownEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnEdgeDownEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_EDGE_DOWN";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when hitting the left edge</summary>
    public event EventHandler EdgeLeftEvent
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

                string key = "_EFL_UI_EVENT_EDGE_LEFT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_EDGE_LEFT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event EdgeLeftEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnEdgeLeftEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_EDGE_LEFT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when hitting the right edge</summary>
    public event EventHandler EdgeRightEvent
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

                string key = "_EFL_UI_EVENT_EDGE_RIGHT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_EDGE_RIGHT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event EdgeRightEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnEdgeRightEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_EDGE_RIGHT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll animation starts</summary>
    public event EventHandler ScrollAnimStartedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STARTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STARTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollAnimStartedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollAnimStartedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_ANIM_STARTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll animation finishes</summary>
    public event EventHandler ScrollAnimFinishedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_ANIM_FINISHED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_FINISHED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollAnimFinishedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollAnimFinishedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_ANIM_FINISHED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll drag starts</summary>
    public event EventHandler ScrollDragStartedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STARTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STARTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollDragStartedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollDragStartedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_DRAG_STARTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll drag finishes</summary>
    public event EventHandler ScrollDragFinishedEvent
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

                string key = "_EFL_UI_EVENT_SCROLL_DRAG_FINISHED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_FINISHED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollDragFinishedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnScrollDragFinishedEvent(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_DRAG_FINISHED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when bar is pressed.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarPressEventArgs"/></value>
    public event EventHandler<Efl.Ui.ScrollbarBarPressEventArgs> BarPressEvent
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
                        Efl.Ui.ScrollbarBarPressEventArgs args = new Efl.Ui.ScrollbarBarPressEventArgs();
                        args.arg =  (Efl.Ui.LayoutOrientation)evt.Info;
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarPressEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarPressEvent(Efl.Ui.ScrollbarBarPressEventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
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
    /// <summary>Called when bar is unpressed.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarUnpressEventArgs"/></value>
    public event EventHandler<Efl.Ui.ScrollbarBarUnpressEventArgs> BarUnpressEvent
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
                        Efl.Ui.ScrollbarBarUnpressEventArgs args = new Efl.Ui.ScrollbarBarUnpressEventArgs();
                        args.arg =  (Efl.Ui.LayoutOrientation)evt.Info;
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarUnpressEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarUnpressEvent(Efl.Ui.ScrollbarBarUnpressEventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
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
    /// <summary>Called when bar is dragged.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarDragEventArgs"/></value>
    public event EventHandler<Efl.Ui.ScrollbarBarDragEventArgs> BarDragEvent
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
                        Efl.Ui.ScrollbarBarDragEventArgs args = new Efl.Ui.ScrollbarBarDragEventArgs();
                        args.arg =  (Efl.Ui.LayoutOrientation)evt.Info;
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarDragEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarDragEvent(Efl.Ui.ScrollbarBarDragEventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
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
    /// <summary>Called when bar size is changed.</summary>
    public event EventHandler BarSizeChangedEvent
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarSizeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarSizeChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when bar position is changed.</summary>
    public event EventHandler BarPosChangedEvent
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarPosChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarPosChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Callend when bar is shown.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarShowEventArgs"/></value>
    public event EventHandler<Efl.Ui.ScrollbarBarShowEventArgs> BarShowEvent
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
                        Efl.Ui.ScrollbarBarShowEventArgs args = new Efl.Ui.ScrollbarBarShowEventArgs();
                        args.arg =  (Efl.Ui.LayoutOrientation)evt.Info;
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarShowEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarShowEvent(Efl.Ui.ScrollbarBarShowEventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
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
    /// <summary>Called when bar is hidden.</summary>
    /// <value><see cref="Efl.Ui.ScrollbarBarHideEventArgs"/></value>
    public event EventHandler<Efl.Ui.ScrollbarBarHideEventArgs> BarHideEvent
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
                        Efl.Ui.ScrollbarBarHideEventArgs args = new Efl.Ui.ScrollbarBarHideEventArgs();
                        args.arg =  (Efl.Ui.LayoutOrientation)evt.Info;
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

                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event BarHideEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnBarHideEvent(Efl.Ui.ScrollbarBarHideEventArgs e)
    {
        var key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
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
    /// <summary>Redirect object has changed, the old manager is passed as an event argument.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Ui.Focus.ManagerRedirectChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ManagerRedirectChangedEventArgs> RedirectChangedEvent
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
                        Efl.Ui.Focus.ManagerRedirectChangedEventArgs args = new Efl.Ui.Focus.ManagerRedirectChangedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Ui.Focus.ManagerConcrete);
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_REDIRECT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_REDIRECT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event RedirectChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnRedirectChangedEvent(Efl.Ui.Focus.ManagerRedirectChangedEventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_REDIRECT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>After this event, the manager object will calculate relations in the graph. Can be used to add / remove children in a lazy fashion.
    /// (Since EFL 1.22)</summary>
    public event EventHandler FlushPreEvent
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_FLUSH_PRE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_FLUSH_PRE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event FlushPreEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFlushPreEvent(EventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_FLUSH_PRE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Cached relationship calculation results have been invalidated.
    /// (Since EFL 1.22)</summary>
    public event EventHandler CoordsDirtyEvent
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_COORDS_DIRTY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_COORDS_DIRTY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event CoordsDirtyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnCoordsDirtyEvent(EventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_COORDS_DIRTY";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>The manager_focus property has changed. The previously focused object is passed as an event argument.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs> ManagerFocusChangedEvent
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
                        Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs args = new Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Ui.Focus.ObjectConcrete);
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_MANAGER_FOCUS_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_MANAGER_FOCUS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ManagerFocusChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnManagerFocusChangedEvent(Efl.Ui.Focus.ManagerManagerFocusChangedEventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_MANAGER_FOCUS_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when this focus manager is frozen or thawed, even_info being <c>true</c> indicates that it is now frozen, <c>false</c> indicates that it is thawed.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs> DirtyLogicFreezeChangedEvent
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
                        Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs args = new Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs();
                        args.arg = Marshal.ReadByte(evt.Info) != 0;
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

                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_DIRTY_LOGIC_FREEZE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_MANAGER_EVENT_DIRTY_LOGIC_FREEZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event DirtyLogicFreezeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnDirtyLogicFreezeChangedEvent(Efl.Ui.Focus.ManagerDirtyLogicFreezeChangedEventArgs e)
    {
        var key = "_EFL_UI_FOCUS_MANAGER_EVENT_DIRTY_LOGIC_FREEZE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg ? (byte) 1 : (byte) 0);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>When in homogeneous mode, all items have the same height and width. Otherwise, each item&apos;s size is respected.</summary>
    /// <returns>Homogeneous mode setting. Default is <c>false</c>.</returns>
    public virtual bool GetHomogeneous() {
         var _ret_var = Efl.Ui.ListView.NativeMethods.efl_ui_list_view_homogeneous_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>When in homogeneous mode, all items have the same height and width. Otherwise, each item&apos;s size is respected.</summary>
    /// <param name="homogeneous">Homogeneous mode setting. Default is <c>false</c>.</param>
    public virtual void SetHomogeneous(bool homogeneous) {
                                 Efl.Ui.ListView.NativeMethods.efl_ui_list_view_homogeneous_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),homogeneous);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Listview select mode.</summary>
    /// <returns>The select mode.</returns>
    public virtual Elm.Object.SelectMode GetSelectMode() {
         var _ret_var = Efl.Ui.ListView.NativeMethods.efl_ui_list_view_select_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Listview select mode.</summary>
    /// <param name="mode">The select mode.</param>
    public virtual void SetSelectMode(Elm.Object.SelectMode mode) {
                                 Efl.Ui.ListView.NativeMethods.efl_ui_list_view_select_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>TBD</summary>
    /// <returns>TBD</returns>
    public virtual System.String GetDefaultStyle() {
         var _ret_var = Efl.Ui.ListView.NativeMethods.efl_ui_list_view_default_style_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>TBD</summary>
    /// <param name="style">TBD</param>
    public virtual void SetDefaultStyle(System.String style) {
                                 Efl.Ui.ListView.NativeMethods.efl_ui_list_view_default_style_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),style);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Listview layout factory set.</summary>
    /// <param name="factory">The factory.</param>
    public virtual void SetLayoutFactory(Efl.Ui.IFactory factory) {
                                 Efl.Ui.ListView.NativeMethods.efl_ui_list_view_layout_factory_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),factory);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the number of currently selected children</summary>
    /// <returns>Number of currently selected children</returns>
    protected virtual int GetSelectedChildrenCount() {
         var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_selected_children_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets child for given child index</summary>
    /// <param name="selected_child_index">Index of child</param>
    /// <returns>Child object</returns>
    protected virtual Efl.Object GetSelectedChild(int selected_child_index) {
                                 var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_selected_child_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),selected_child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds selection for given child index</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
    protected virtual bool ChildSelect(int child_index) {
                                 var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_child_select_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Removes selection for given child index</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
    protected virtual bool SelectedChildDeselect(int child_index) {
                                 var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_selected_child_deselect_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Determines if child specified by index is selected</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if child is selected, <c>false</c> otherwise</returns>
    protected virtual bool IsChildSelected(int child_index) {
                                 var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_is_child_selected_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds selection for all children</summary>
    /// <returns><c>true</c> if selection was added to all children, <c>false</c> otherwise</returns>
    protected virtual bool AllChildrenSelect() {
         var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_all_children_select_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Clears the current selection</summary>
    /// <returns><c>true</c> if selection was cleared, <c>false</c> otherwise</returns>
    protected virtual bool ClearAccessSelection() {
         var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes selection for given child index</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
    protected virtual bool ChildDeselect(int child_index) {
                                 var _ret_var = Efl.Access.SelectionConcrete.NativeMethods.efl_access_selection_child_deselect_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    public virtual void SetLoadRange(int first, int count) {
                                                         Efl.Ui.ListViewModelConcrete.NativeMethods.efl_ui_list_view_model_load_range_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),first, count);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    public virtual int GetModelSize() {
         var _ret_var = Efl.Ui.ListViewModelConcrete.NativeMethods.efl_ui_list_view_model_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Minimal content size.</summary>
    public virtual Eina.Size2D GetMinSize() {
         var _ret_var = Efl.Ui.ListViewModelConcrete.NativeMethods.efl_ui_list_view_model_min_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Minimal content size.</summary>
    public virtual void SetMinSize(Eina.Size2D min) {
         Eina.Size2D.NativeStruct _in_min = min;
                        Efl.Ui.ListViewModelConcrete.NativeMethods.efl_ui_list_view_model_min_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_min);
        Eina.Error.RaiseIfUnhandledException();
                         }
    public virtual Efl.Ui.ListViewLayoutItem Realize(ref Efl.Ui.ListViewLayoutItem item) {
         Efl.Ui.ListViewLayoutItem.NativeStruct _in_item = item;
                        var _ret_var = Efl.Ui.ListViewModelConcrete.NativeMethods.efl_ui_list_view_model_realize_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref _in_item);
        Eina.Error.RaiseIfUnhandledException();
                item = _in_item;
        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.ListViewLayoutItem>(_ret_var);
        
        return __ret_tmp;
 }
    public virtual void Unrealize(ref Efl.Ui.ListViewLayoutItem item) {
         Efl.Ui.ListViewLayoutItem.NativeStruct _in_item = item;
                        Efl.Ui.ListViewModelConcrete.NativeMethods.efl_ui_list_view_model_unrealize_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref _in_item);
        Eina.Error.RaiseIfUnhandledException();
                item = _in_item;
         }
    /// <summary>The content position</summary>
    /// <returns>The position is virtual value, (0, 0) starting at the top-left.</returns>
    public virtual Eina.Position2D GetContentPos() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_content_pos_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The content position</summary>
    /// <param name="pos">The position is virtual value, (0, 0) starting at the top-left.</param>
    public virtual void SetContentPos(Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_content_pos_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The content size</summary>
    /// <returns>The content size in pixels.</returns>
    public virtual Eina.Size2D GetContentSize() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_content_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The viewport geometry</summary>
    /// <returns>It is absolute geometry.</returns>
    public virtual Eina.Rect GetViewportGeometry() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    public virtual void GetBounceEnabled(out bool horiz, out bool vert) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out horiz, out vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    public virtual void SetBounceEnabled(bool horiz, bool vert) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),horiz, vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike <see cref="Efl.Ui.IScrollableInteractive.MovementBlock"/>, this function freezes bidirectionally. If you want to freeze in only one direction, see <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <returns><c>true</c> if freeze, <c>false</c> otherwise</returns>
    public virtual bool GetScrollFreeze() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike <see cref="Efl.Ui.IScrollableInteractive.MovementBlock"/>, this function freezes bidirectionally. If you want to freeze in only one direction, see <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <param name="freeze"><c>true</c> if freeze, <c>false</c> otherwise</param>
    public virtual void SetScrollFreeze(bool freeze) {
                                 Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),freeze);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <returns><c>true</c> if hold, <c>false</c> otherwise</returns>
    public virtual bool GetScrollHold() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <param name="hold"><c>true</c> if hold, <c>false</c> otherwise</param>
    public virtual void SetScrollHold(bool hold) {
                                 Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hold);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    public virtual void GetLooping(out bool loop_h, out bool loop_v) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_looping_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out loop_h, out loop_v);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    public virtual void SetLooping(bool loop_h, bool loop_v) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_looping_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),loop_h, loop_v);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <returns>Which axis (or axes) to block</returns>
    public virtual Efl.Ui.LayoutOrientation GetMovementBlock() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_movement_block_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <param name="block">Which axis (or axes) to block</param>
    public virtual void SetMovementBlock(Efl.Ui.LayoutOrientation block) {
                                 Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_movement_block_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),block);
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
    public virtual void GetGravity(out double x, out double y) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_gravity_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
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
    public virtual void SetGravity(double x, double y) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_gravity_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
    /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
    /// <param name="w">Whether to limit the minimum horizontal size</param>
    /// <param name="h">Whether to limit the minimum vertical size</param>
    public virtual void SetMatchContent(bool w, bool h) {
                                                         Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_match_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),w, h);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <returns>The step size in pixels</returns>
    public virtual Eina.Position2D GetStepSize() {
         var _ret_var = Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_step_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <param name="step">The step size in pixels</param>
    public virtual void SetStepSize(Eina.Position2D step) {
         Eina.Position2D.NativeStruct _in_step = step;
                        Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_step_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_step);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Show a specific virtual region within the scroller content object.
    /// This will ensure all (or part if it does not fit) of the designated region in the virtual content object (0, 0 starting at the top-left of the virtual content object) is shown within the scroller. This allows the scroller to &quot;smoothly slide&quot; to this location (if configuration in general calls for transitions). It may not jump immediately to the new location and make take a while and show other content along the way.</summary>
    /// <param name="rect">The position where to scroll. and The size user want to see</param>
    /// <param name="animation">Whether to scroll with animation or not</param>
    public virtual void Scroll(Eina.Rect rect, bool animation) {
         Eina.Rect.NativeStruct _in_rect = rect;
                                                Efl.Ui.ScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_rect, animation);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar.</param>
    /// <param name="vbar">Vertical scrollbar.</param>
    public virtual void GetBarMode(out Efl.Ui.ScrollbarMode hbar, out Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out hbar, out vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar.</param>
    /// <param name="vbar">Vertical scrollbar.</param>
    public virtual void SetBarMode(Efl.Ui.ScrollbarMode hbar, Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hbar, vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
    /// <param name="width">Value between 0.0 and 1.0.</param>
    /// <param name="height">Value between 0.0 and 1.0.</param>
    public virtual void GetBarSize(out double width, out double height) {
                                                         Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out width, out height);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0.</param>
    /// <param name="posy">Value between 0.0 and 1.0.</param>
    public virtual void GetBarPosition(out double posx, out double posy) {
                                                         Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out posx, out posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0.</param>
    /// <param name="posy">Value between 0.0 and 1.0.</param>
    public virtual void SetBarPosition(double posx, double posy) {
                                                         Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),posx, posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Update bar visibility.
    /// The object will call this function whenever the bar needs to be shown or hidden.</summary>
    protected virtual void UpdateBarVisibility() {
         Efl.Ui.ScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>If the widget needs a focus manager, this function will be called.
    /// It can be used and overridden to inject your own manager or set custom options on the focus manager.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">The logical root object for focus.</param>
    /// <returns>The focus manager.</returns>
    protected virtual Efl.Ui.Focus.IManager FocusManagerCreate(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.WidgetFocusManagerConcrete.NativeMethods.efl_ui_widget_focus_manager_create_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Set the order of elements that will be used for composition
    /// Elements of the list can be either an <see cref="Efl.Ui.Widget"/>, an <see cref="Efl.Ui.Focus.IObject"/> or an <see cref="Efl.Gfx.IEntity"/>.
    /// 
    /// If the element is an <see cref="Efl.Ui.Widget"/> nothing is done and the widget is simply part of the order.
    /// 
    /// If the element is an <see cref="Efl.Ui.Focus.IObject"/>, then the mixin will take care of registering the element.
    /// 
    /// If the element is an <see cref="Efl.Gfx.IEntity"/>, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.</summary>
    /// <returns>The order to use</returns>
    protected virtual Eina.List<Efl.Gfx.IEntity> GetCompositionElements() {
         var _ret_var = Efl.Ui.Focus.CompositionConcrete.NativeMethods.efl_ui_focus_composition_elements_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Gfx.IEntity>(_ret_var, true, false);
 }
    /// <summary>Set the order of elements that will be used for composition
    /// Elements of the list can be either an <see cref="Efl.Ui.Widget"/>, an <see cref="Efl.Ui.Focus.IObject"/> or an <see cref="Efl.Gfx.IEntity"/>.
    /// 
    /// If the element is an <see cref="Efl.Ui.Widget"/> nothing is done and the widget is simply part of the order.
    /// 
    /// If the element is an <see cref="Efl.Ui.Focus.IObject"/>, then the mixin will take care of registering the element.
    /// 
    /// If the element is an <see cref="Efl.Gfx.IEntity"/>, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.</summary>
    /// <param name="logical_order">The order to use</param>
    protected virtual void SetCompositionElements(Eina.List<Efl.Gfx.IEntity> logical_order) {
         var _in_logical_order = logical_order.Handle;
logical_order.Own = false;
                        Efl.Ui.Focus.CompositionConcrete.NativeMethods.efl_ui_focus_composition_elements_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_logical_order);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <returns><c>true</c> or <c>false</c></returns>
    protected virtual bool GetLogicalMode() {
         var _ret_var = Efl.Ui.Focus.CompositionConcrete.NativeMethods.efl_ui_focus_composition_logical_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <param name="logical_mode"><c>true</c> or <c>false</c></param>
    protected virtual void SetLogicalMode(bool logical_mode) {
                                 Efl.Ui.Focus.CompositionConcrete.NativeMethods.efl_ui_focus_composition_logical_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),logical_mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Mark this widget as dirty, the children can be considered to be changed after that call</summary>
    protected virtual void Dirty() {
         Efl.Ui.Focus.CompositionConcrete.NativeMethods.efl_ui_focus_composition_dirty_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>A call to prepare the children of this element, called if marked as dirty
    /// You can use this function to call composition_elements.</summary>
    protected virtual void Prepare() {
         Efl.Ui.Focus.CompositionConcrete.NativeMethods.efl_ui_focus_composition_prepare_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The element which is currently focused by this manager.
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next regular object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <returns>Currently focused element.</returns>
    public virtual Efl.Ui.Focus.IObject GetManagerFocus() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_focus_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The element which is currently focused by this manager.
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next regular object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <param name="focus">Currently focused element.</param>
    public virtual void SetManagerFocus(Efl.Ui.Focus.IObject focus) {
                                 Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_focus_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <returns>The new focus manager.</returns>
    public virtual Efl.Ui.Focus.IManager GetRedirect() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_redirect_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <param name="redirect">The new focus manager.</param>
    public virtual void SetRedirect(Efl.Ui.Focus.IManager redirect) {
                                 Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_redirect_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),redirect);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Elements which are at the border of the graph.
    /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.IManager.Move"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>An iterator over the border objects.</returns>
    public virtual Eina.Iterator<Efl.Ui.Focus.IObject> GetBorderElements() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_border_elements_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Ui.Focus.IObject>(_ret_var, false);
 }
    /// <summary>Elements that are at the border of the viewport
    /// Every element returned by this is located inside the viewport rectangle, but has a right, left, down or up neighbor outside the viewport.
    /// (Since EFL 1.22)</summary>
    /// <param name="viewport">The rectangle defining the viewport.</param>
    /// <returns>An iterator over the viewport border objects.</returns>
    public virtual Eina.Iterator<Efl.Ui.Focus.IObject> GetViewportElements(Eina.Rect viewport) {
         Eina.Rect.NativeStruct _in_viewport = viewport;
                        var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_viewport_elements_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_viewport);
        Eina.Error.RaiseIfUnhandledException();
                        return new Eina.Iterator<Efl.Ui.Focus.IObject>(_ret_var, false);
 }
    /// <summary>Root node for all logical sub-trees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <returns>Object to register as the root of this manager object.</returns>
    public virtual Efl.Ui.Focus.IObject GetRoot() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_root_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Root node for all logical sub-trees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">Object to register as the root of this manager object.</param>
    /// <returns><c>true</c> on success, <c>false</c> if it had already been set.</returns>
    public virtual bool SetRoot(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_root_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Moves the focus in the given direction to the next regular widget.
    /// This call flushes all changes. This means all changes since last flush are computed.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">The direction to move to.</param>
    /// <returns>The element which is now focused.</returns>
    public virtual Efl.Ui.Focus.IObject Move(Efl.Ui.Focus.Direction direction) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_move_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),direction);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns the object in the <c>direction</c> from <c>child</c>.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">Direction to move focus.</param>
    /// <param name="child">The child to move from. Pass <c>null</c> to indicate the currently focused child.</param>
    /// <param name="logical">Wether you want to have a logical node as result or a regular. Note that in a <see cref="Efl.Ui.Focus.IManager.Move"/> call logical nodes will not get focus.</param>
    /// <returns>Object that would receive focus if moved in the given direction.</returns>
    public virtual Efl.Ui.Focus.IObject MoveRequest(Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject child, bool logical) {
                                                                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_request_move_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),direction, child, logical);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Returns the widget in the direction next.
    /// The returned widget is a child of <c>root</c>. It&apos;s guaranteed that child will not be prepared again, so you can call this function inside a <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> call.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">Parent for returned child.</param>
    /// <returns>Child of passed parameter.</returns>
    public virtual Efl.Ui.Focus.IObject RequestSubchild(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_request_subchild_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Fetches the data from a registered node.
    /// Note: This function triggers a computation of all dirty nodes.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="child">The child object to inspect.</param>
    /// <returns>The list of relations starting from <c>child</c>.</returns>
    public virtual Efl.Ui.Focus.Relations Fetch(Efl.Ui.Focus.IObject child) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_fetch_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child);
        Eina.Error.RaiseIfUnhandledException();
                        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.Focus.Relations>(_ret_var);
        Marshal.FreeHGlobal(_ret_var);
        return __ret_tmp;
 }
    /// <summary>Returns the last logical object.
    /// The returned object is the last object that would be returned if you start at the root and move in the &quot;next&quot; direction.
    /// (Since EFL 1.22)</summary>
    /// <returns>Last object.</returns>
    public virtual Efl.Ui.Focus.ManagerLogicalEndDetail LogicalEnd() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_logical_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Resets the history stack of this manager object. This means the uppermost element will be unfocused, and all other elements will be removed from the remembered list.
    /// You should focus another element immediately after calling this, in order to always have a focused object.
    /// (Since EFL 1.22)</summary>
    public virtual void ResetHistory() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_reset_history_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Removes the uppermost history element, and focuses the previous one.
    /// If there is an element that was focused before, it will be used. Otherwise, the best fitting element from the registered elements will be focused.
    /// (Since EFL 1.22)</summary>
    public virtual void PopHistoryStack() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_pop_history_stack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Called when this manager is set as redirect.
    /// In case that this is called as a result of a move call, <c>direction</c> and <c>entry</c> will be set to the direction of the move call, and the <c>entry</c> object will be set to the object that had this manager as redirect property.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">The direction in which this should be setup.</param>
    /// <param name="entry">The object that caused this manager to be redirect.</param>
    public virtual void SetupOnFirstTouch(Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject entry) {
                                                         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_setup_on_first_touch_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),direction, entry);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Disables the cache invalidation when an object is moved.
    /// Even if an object is moved, the focus manager will not recalculate its relations. This can be used when you know that the set of widgets in the focus manager is moved the same way, so the relations between the widgets in the set do not change and complex calculations can be avoided. Use <see cref="Efl.Ui.Focus.IManager.DirtyLogicUnfreeze"/> to re-enable relationship calculation.
    /// (Since EFL 1.22)</summary>
    public virtual void FreezeDirtyLogic() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_dirty_logic_freeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Enables the cache invalidation when an object is moved.
    /// This is the counterpart to <see cref="Efl.Ui.Focus.IManager.FreezeDirtyLogic"/>.
    /// (Since EFL 1.22)</summary>
    public virtual void DirtyLogicUnfreeze() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_dirty_logic_unfreeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>When in homogeneous mode, all items have the same height and width. Otherwise, each item&apos;s size is respected.</summary>
    /// <value>Homogeneous mode setting. Default is <c>false</c>.</value>
    public bool Homogeneous {
        get { return GetHomogeneous(); }
        set { SetHomogeneous(value); }
    }
    /// <summary>Listview select mode.</summary>
    /// <value>The select mode.</value>
    public Elm.Object.SelectMode SelectMode {
        get { return GetSelectMode(); }
        set { SetSelectMode(value); }
    }
    /// <summary>TBD</summary>
    /// <value>TBD</value>
    public System.String DefaultStyle {
        get { return GetDefaultStyle(); }
        set { SetDefaultStyle(value); }
    }
    /// <summary>Listview layout factory set.</summary>
    /// <value>The factory.</value>
    public Efl.Ui.IFactory LayoutFactory {
        set { SetLayoutFactory(value); }
    }
    /// <summary>Gets the number of currently selected children</summary>
    /// <value>Number of currently selected children</value>
    protected int SelectedChildrenCount {
        get { return GetSelectedChildrenCount(); }
    }
    public (int, int) LoadRange {
        set { SetLoadRange( value.Item1,  value.Item2); }
    }
    public int ModelSize {
        get { return GetModelSize(); }
    }
    /// <summary>Minimal content size.</summary>
    public Eina.Size2D MinSize {
        get { return GetMinSize(); }
        set { SetMinSize(value); }
    }
    /// <summary>The content position</summary>
    /// <value>The position is virtual value, (0, 0) starting at the top-left.</value>
    public Eina.Position2D ContentPos {
        get { return GetContentPos(); }
        set { SetContentPos(value); }
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
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <value>Horizontal bounce policy.</value>
    public (bool, bool) BounceEnabled {
        get {
            bool _out_horiz = default(bool);
            bool _out_vert = default(bool);
            GetBounceEnabled(out _out_horiz,out _out_vert);
            return (_out_horiz,_out_vert);
        }
        set { SetBounceEnabled( value.Item1,  value.Item2); }
    }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike <see cref="Efl.Ui.IScrollableInteractive.MovementBlock"/>, this function freezes bidirectionally. If you want to freeze in only one direction, see <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <value><c>true</c> if freeze, <c>false</c> otherwise</value>
    public bool ScrollFreeze {
        get { return GetScrollFreeze(); }
        set { SetScrollFreeze(value); }
    }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <value><c>true</c> if hold, <c>false</c> otherwise</value>
    public bool ScrollHold {
        get { return GetScrollHold(); }
        set { SetScrollHold(value); }
    }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <value>The scrolling horizontal loop</value>
    public (bool, bool) Looping {
        get {
            bool _out_loop_h = default(bool);
            bool _out_loop_v = default(bool);
            GetLooping(out _out_loop_h,out _out_loop_v);
            return (_out_loop_h,_out_loop_v);
        }
        set { SetLooping( value.Item1,  value.Item2); }
    }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <value>Which axis (or axes) to block</value>
    public Efl.Ui.LayoutOrientation MovementBlock {
        get { return GetMovementBlock(); }
        set { SetMovementBlock(value); }
    }
    /// <summary>Control scrolling gravity on the scrollable
    /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
    /// 
    /// The scroller will adjust the view to glue itself as follows.
    /// 
    /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the right edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
    /// 
    /// Default values for x and y are 0.0</summary>
    /// <value>Horizontal scrolling gravity</value>
    public (double, double) Gravity {
        get {
            double _out_x = default(double);
            double _out_y = default(double);
            GetGravity(out _out_x,out _out_y);
            return (_out_x,_out_y);
        }
        set { SetGravity( value.Item1,  value.Item2); }
    }
    /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
    /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
    /// <value>Whether to limit the minimum horizontal size</value>
    public (bool, bool) MatchContent {
        set { SetMatchContent( value.Item1,  value.Item2); }
    }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <value>The step size in pixels</value>
    public Eina.Position2D StepSize {
        get { return GetStepSize(); }
        set { SetStepSize(value); }
    }
    /// <summary>Scrollbar visibility policy</summary>
    /// <value>Horizontal scrollbar.</value>
    public (Efl.Ui.ScrollbarMode, Efl.Ui.ScrollbarMode) BarMode {
        get {
            Efl.Ui.ScrollbarMode _out_hbar = default(Efl.Ui.ScrollbarMode);
            Efl.Ui.ScrollbarMode _out_vbar = default(Efl.Ui.ScrollbarMode);
            GetBarMode(out _out_hbar,out _out_vbar);
            return (_out_hbar,_out_vbar);
        }
        set { SetBarMode( value.Item1,  value.Item2); }
    }
    /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
    public (double, double) BarSize {
        get {
            double _out_width = default(double);
            double _out_height = default(double);
            GetBarSize(out _out_width,out _out_height);
            return (_out_width,_out_height);
        }
    }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <value>Value between 0.0 and 1.0.</value>
    public (double, double) BarPosition {
        get {
            double _out_posx = default(double);
            double _out_posy = default(double);
            GetBarPosition(out _out_posx,out _out_posy);
            return (_out_posx,_out_posy);
        }
        set { SetBarPosition( value.Item1,  value.Item2); }
    }
    /// <summary>Set the order of elements that will be used for composition
    /// Elements of the list can be either an <see cref="Efl.Ui.Widget"/>, an <see cref="Efl.Ui.Focus.IObject"/> or an <see cref="Efl.Gfx.IEntity"/>.
    /// 
    /// If the element is an <see cref="Efl.Ui.Widget"/> nothing is done and the widget is simply part of the order.
    /// 
    /// If the element is an <see cref="Efl.Ui.Focus.IObject"/>, then the mixin will take care of registering the element.
    /// 
    /// If the element is an <see cref="Efl.Gfx.IEntity"/>, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.</summary>
    /// <value>The order to use</value>
    protected Eina.List<Efl.Gfx.IEntity> CompositionElements {
        get { return GetCompositionElements(); }
        set { SetCompositionElements(value); }
    }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <value><c>true</c> or <c>false</c></value>
    protected bool LogicalMode {
        get { return GetLogicalMode(); }
        set { SetLogicalMode(value); }
    }
    /// <summary>The element which is currently focused by this manager.
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next regular object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <value>Currently focused element.</value>
    public Efl.Ui.Focus.IObject ManagerFocus {
        get { return GetManagerFocus(); }
        set { SetManagerFocus(value); }
    }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <value>The new focus manager.</value>
    public Efl.Ui.Focus.IManager Redirect {
        get { return GetRedirect(); }
        set { SetRedirect(value); }
    }
    /// <summary>Elements which are at the border of the graph.
    /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.IManager.Move"/>.
    /// (Since EFL 1.22)</summary>
    /// <value>An iterator over the border objects.</value>
    public Eina.Iterator<Efl.Ui.Focus.IObject> BorderElements {
        get { return GetBorderElements(); }
    }
    /// <summary>Root node for all logical sub-trees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <value>Object to register as the root of this manager object.</value>
    public Efl.Ui.Focus.IObject Root {
        get { return GetRoot(); }
        set { SetRoot(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.ListView.efl_ui_list_view_class_get();
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

            if (efl_ui_list_view_homogeneous_get_static_delegate == null)
            {
                efl_ui_list_view_homogeneous_get_static_delegate = new efl_ui_list_view_homogeneous_get_delegate(homogeneous_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHomogeneous") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_homogeneous_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_homogeneous_get_static_delegate) });
            }

            if (efl_ui_list_view_homogeneous_set_static_delegate == null)
            {
                efl_ui_list_view_homogeneous_set_static_delegate = new efl_ui_list_view_homogeneous_set_delegate(homogeneous_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHomogeneous") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_homogeneous_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_homogeneous_set_static_delegate) });
            }

            if (efl_ui_list_view_select_mode_get_static_delegate == null)
            {
                efl_ui_list_view_select_mode_get_static_delegate = new efl_ui_list_view_select_mode_get_delegate(select_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_select_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_select_mode_get_static_delegate) });
            }

            if (efl_ui_list_view_select_mode_set_static_delegate == null)
            {
                efl_ui_list_view_select_mode_set_static_delegate = new efl_ui_list_view_select_mode_set_delegate(select_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelectMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_select_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_select_mode_set_static_delegate) });
            }

            if (efl_ui_list_view_default_style_get_static_delegate == null)
            {
                efl_ui_list_view_default_style_get_static_delegate = new efl_ui_list_view_default_style_get_delegate(default_style_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDefaultStyle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_default_style_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_default_style_get_static_delegate) });
            }

            if (efl_ui_list_view_default_style_set_static_delegate == null)
            {
                efl_ui_list_view_default_style_set_static_delegate = new efl_ui_list_view_default_style_set_delegate(default_style_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDefaultStyle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_default_style_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_default_style_set_static_delegate) });
            }

            if (efl_ui_list_view_layout_factory_set_static_delegate == null)
            {
                efl_ui_list_view_layout_factory_set_static_delegate = new efl_ui_list_view_layout_factory_set_delegate(layout_factory_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLayoutFactory") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_layout_factory_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_layout_factory_set_static_delegate) });
            }

            if (efl_access_selection_selected_children_count_get_static_delegate == null)
            {
                efl_access_selection_selected_children_count_get_static_delegate = new efl_access_selection_selected_children_count_get_delegate(selected_children_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectedChildrenCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_selected_children_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_selected_children_count_get_static_delegate) });
            }

            if (efl_access_selection_selected_child_get_static_delegate == null)
            {
                efl_access_selection_selected_child_get_static_delegate = new efl_access_selection_selected_child_get_delegate(selected_child_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectedChild") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_selected_child_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_selected_child_get_static_delegate) });
            }

            if (efl_access_selection_child_select_static_delegate == null)
            {
                efl_access_selection_child_select_static_delegate = new efl_access_selection_child_select_delegate(child_select);
            }

            if (methods.FirstOrDefault(m => m.Name == "ChildSelect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_child_select"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_child_select_static_delegate) });
            }

            if (efl_access_selection_selected_child_deselect_static_delegate == null)
            {
                efl_access_selection_selected_child_deselect_static_delegate = new efl_access_selection_selected_child_deselect_delegate(selected_child_deselect);
            }

            if (methods.FirstOrDefault(m => m.Name == "SelectedChildDeselect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_selected_child_deselect"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_selected_child_deselect_static_delegate) });
            }

            if (efl_access_selection_is_child_selected_static_delegate == null)
            {
                efl_access_selection_is_child_selected_static_delegate = new efl_access_selection_is_child_selected_delegate(is_child_selected);
            }

            if (methods.FirstOrDefault(m => m.Name == "IsChildSelected") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_is_child_selected"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_is_child_selected_static_delegate) });
            }

            if (efl_access_selection_all_children_select_static_delegate == null)
            {
                efl_access_selection_all_children_select_static_delegate = new efl_access_selection_all_children_select_delegate(all_children_select);
            }

            if (methods.FirstOrDefault(m => m.Name == "AllChildrenSelect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_all_children_select"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_all_children_select_static_delegate) });
            }

            if (efl_access_selection_clear_static_delegate == null)
            {
                efl_access_selection_clear_static_delegate = new efl_access_selection_clear_delegate(access_selection_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearAccessSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_clear_static_delegate) });
            }

            if (efl_access_selection_child_deselect_static_delegate == null)
            {
                efl_access_selection_child_deselect_static_delegate = new efl_access_selection_child_deselect_delegate(child_deselect);
            }

            if (methods.FirstOrDefault(m => m.Name == "ChildDeselect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_selection_child_deselect"), func = Marshal.GetFunctionPointerForDelegate(efl_access_selection_child_deselect_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_visibility_update_static_delegate == null)
            {
                efl_ui_scrollbar_bar_visibility_update_static_delegate = new efl_ui_scrollbar_bar_visibility_update_delegate(bar_visibility_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateBarVisibility") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_visibility_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_visibility_update_static_delegate) });
            }

            if (efl_ui_widget_focus_manager_create_static_delegate == null)
            {
                efl_ui_widget_focus_manager_create_static_delegate = new efl_ui_widget_focus_manager_create_delegate(focus_manager_create);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusManagerCreate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_manager_create"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_manager_create_static_delegate) });
            }

            if (efl_ui_focus_composition_elements_get_static_delegate == null)
            {
                efl_ui_focus_composition_elements_get_static_delegate = new efl_ui_focus_composition_elements_get_delegate(composition_elements_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCompositionElements") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_get_static_delegate) });
            }

            if (efl_ui_focus_composition_elements_set_static_delegate == null)
            {
                efl_ui_focus_composition_elements_set_static_delegate = new efl_ui_focus_composition_elements_set_delegate(composition_elements_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCompositionElements") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_elements_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_set_static_delegate) });
            }

            if (efl_ui_focus_composition_logical_mode_get_static_delegate == null)
            {
                efl_ui_focus_composition_logical_mode_get_static_delegate = new efl_ui_focus_composition_logical_mode_get_delegate(logical_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLogicalMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_logical_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_get_static_delegate) });
            }

            if (efl_ui_focus_composition_logical_mode_set_static_delegate == null)
            {
                efl_ui_focus_composition_logical_mode_set_static_delegate = new efl_ui_focus_composition_logical_mode_set_delegate(logical_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLogicalMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_logical_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_set_static_delegate) });
            }

            if (efl_ui_focus_composition_dirty_static_delegate == null)
            {
                efl_ui_focus_composition_dirty_static_delegate = new efl_ui_focus_composition_dirty_delegate(dirty);
            }

            if (methods.FirstOrDefault(m => m.Name == "Dirty") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_dirty"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_dirty_static_delegate) });
            }

            if (efl_ui_focus_composition_prepare_static_delegate == null)
            {
                efl_ui_focus_composition_prepare_static_delegate = new efl_ui_focus_composition_prepare_delegate(prepare);
            }

            if (methods.FirstOrDefault(m => m.Name == "Prepare") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_prepare"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_prepare_static_delegate) });
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
            return Efl.Ui.ListView.efl_ui_list_view_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_list_view_homogeneous_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_list_view_homogeneous_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_homogeneous_get_api_delegate> efl_ui_list_view_homogeneous_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_homogeneous_get_api_delegate>(Module, "efl_ui_list_view_homogeneous_get");

        private static bool homogeneous_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_list_view_homogeneous_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetHomogeneous();
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
                return efl_ui_list_view_homogeneous_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_list_view_homogeneous_get_delegate efl_ui_list_view_homogeneous_get_static_delegate;

        
        private delegate void efl_ui_list_view_homogeneous_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool homogeneous);

        
        public delegate void efl_ui_list_view_homogeneous_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool homogeneous);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_homogeneous_set_api_delegate> efl_ui_list_view_homogeneous_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_homogeneous_set_api_delegate>(Module, "efl_ui_list_view_homogeneous_set");

        private static void homogeneous_set(System.IntPtr obj, System.IntPtr pd, bool homogeneous)
        {
            Eina.Log.Debug("function efl_ui_list_view_homogeneous_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ListView)ws.Target).SetHomogeneous(homogeneous);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_list_view_homogeneous_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), homogeneous);
            }
        }

        private static efl_ui_list_view_homogeneous_set_delegate efl_ui_list_view_homogeneous_set_static_delegate;

        
        private delegate Elm.Object.SelectMode efl_ui_list_view_select_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Elm.Object.SelectMode efl_ui_list_view_select_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_select_mode_get_api_delegate> efl_ui_list_view_select_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_select_mode_get_api_delegate>(Module, "efl_ui_list_view_select_mode_get");

        private static Elm.Object.SelectMode select_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_list_view_select_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Elm.Object.SelectMode _ret_var = default(Elm.Object.SelectMode);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetSelectMode();
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
                return efl_ui_list_view_select_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_list_view_select_mode_get_delegate efl_ui_list_view_select_mode_get_static_delegate;

        
        private delegate void efl_ui_list_view_select_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Elm.Object.SelectMode mode);

        
        public delegate void efl_ui_list_view_select_mode_set_api_delegate(System.IntPtr obj,  Elm.Object.SelectMode mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_select_mode_set_api_delegate> efl_ui_list_view_select_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_select_mode_set_api_delegate>(Module, "efl_ui_list_view_select_mode_set");

        private static void select_mode_set(System.IntPtr obj, System.IntPtr pd, Elm.Object.SelectMode mode)
        {
            Eina.Log.Debug("function efl_ui_list_view_select_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ListView)ws.Target).SetSelectMode(mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_list_view_select_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode);
            }
        }

        private static efl_ui_list_view_select_mode_set_delegate efl_ui_list_view_select_mode_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_list_view_default_style_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_list_view_default_style_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_default_style_get_api_delegate> efl_ui_list_view_default_style_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_default_style_get_api_delegate>(Module, "efl_ui_list_view_default_style_get");

        private static System.String default_style_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_list_view_default_style_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetDefaultStyle();
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
                return efl_ui_list_view_default_style_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_list_view_default_style_get_delegate efl_ui_list_view_default_style_get_static_delegate;

        
        private delegate void efl_ui_list_view_default_style_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))] System.String style);

        
        public delegate void efl_ui_list_view_default_style_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringshareKeepOwnershipMarshaler))] System.String style);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_default_style_set_api_delegate> efl_ui_list_view_default_style_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_default_style_set_api_delegate>(Module, "efl_ui_list_view_default_style_set");

        private static void default_style_set(System.IntPtr obj, System.IntPtr pd, System.String style)
        {
            Eina.Log.Debug("function efl_ui_list_view_default_style_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ListView)ws.Target).SetDefaultStyle(style);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_list_view_default_style_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), style);
            }
        }

        private static efl_ui_list_view_default_style_set_delegate efl_ui_list_view_default_style_set_static_delegate;

        
        private delegate void efl_ui_list_view_layout_factory_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.IFactory factory);

        
        public delegate void efl_ui_list_view_layout_factory_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.IFactory factory);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_layout_factory_set_api_delegate> efl_ui_list_view_layout_factory_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_layout_factory_set_api_delegate>(Module, "efl_ui_list_view_layout_factory_set");

        private static void layout_factory_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.IFactory factory)
        {
            Eina.Log.Debug("function efl_ui_list_view_layout_factory_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ListView)ws.Target).SetLayoutFactory(factory);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_list_view_layout_factory_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), factory);
            }
        }

        private static efl_ui_list_view_layout_factory_set_delegate efl_ui_list_view_layout_factory_set_static_delegate;

        
        private delegate int efl_access_selection_selected_children_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_access_selection_selected_children_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_selected_children_count_get_api_delegate> efl_access_selection_selected_children_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_selected_children_count_get_api_delegate>(Module, "efl_access_selection_selected_children_count_get");

        private static int selected_children_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_selection_selected_children_count_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetSelectedChildrenCount();
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
                return efl_access_selection_selected_children_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_selection_selected_children_count_get_delegate efl_access_selection_selected_children_count_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_access_selection_selected_child_get_delegate(System.IntPtr obj, System.IntPtr pd,  int selected_child_index);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_access_selection_selected_child_get_api_delegate(System.IntPtr obj,  int selected_child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_selected_child_get_api_delegate> efl_access_selection_selected_child_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_selected_child_get_api_delegate>(Module, "efl_access_selection_selected_child_get");

        private static Efl.Object selected_child_get(System.IntPtr obj, System.IntPtr pd, int selected_child_index)
        {
            Eina.Log.Debug("function efl_access_selection_selected_child_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetSelectedChild(selected_child_index);
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
                return efl_access_selection_selected_child_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), selected_child_index);
            }
        }

        private static efl_access_selection_selected_child_get_delegate efl_access_selection_selected_child_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_child_select_delegate(System.IntPtr obj, System.IntPtr pd,  int child_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_child_select_api_delegate(System.IntPtr obj,  int child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_child_select_api_delegate> efl_access_selection_child_select_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_child_select_api_delegate>(Module, "efl_access_selection_child_select");

        private static bool child_select(System.IntPtr obj, System.IntPtr pd, int child_index)
        {
            Eina.Log.Debug("function efl_access_selection_child_select was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ListView)ws.Target).ChildSelect(child_index);
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
                return efl_access_selection_child_select_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child_index);
            }
        }

        private static efl_access_selection_child_select_delegate efl_access_selection_child_select_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_selected_child_deselect_delegate(System.IntPtr obj, System.IntPtr pd,  int child_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_selected_child_deselect_api_delegate(System.IntPtr obj,  int child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_selected_child_deselect_api_delegate> efl_access_selection_selected_child_deselect_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_selected_child_deselect_api_delegate>(Module, "efl_access_selection_selected_child_deselect");

        private static bool selected_child_deselect(System.IntPtr obj, System.IntPtr pd, int child_index)
        {
            Eina.Log.Debug("function efl_access_selection_selected_child_deselect was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ListView)ws.Target).SelectedChildDeselect(child_index);
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
                return efl_access_selection_selected_child_deselect_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child_index);
            }
        }

        private static efl_access_selection_selected_child_deselect_delegate efl_access_selection_selected_child_deselect_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_is_child_selected_delegate(System.IntPtr obj, System.IntPtr pd,  int child_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_is_child_selected_api_delegate(System.IntPtr obj,  int child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_is_child_selected_api_delegate> efl_access_selection_is_child_selected_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_is_child_selected_api_delegate>(Module, "efl_access_selection_is_child_selected");

        private static bool is_child_selected(System.IntPtr obj, System.IntPtr pd, int child_index)
        {
            Eina.Log.Debug("function efl_access_selection_is_child_selected was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ListView)ws.Target).IsChildSelected(child_index);
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
                return efl_access_selection_is_child_selected_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child_index);
            }
        }

        private static efl_access_selection_is_child_selected_delegate efl_access_selection_is_child_selected_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_all_children_select_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_all_children_select_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_all_children_select_api_delegate> efl_access_selection_all_children_select_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_all_children_select_api_delegate>(Module, "efl_access_selection_all_children_select");

        private static bool all_children_select(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_selection_all_children_select was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ListView)ws.Target).AllChildrenSelect();
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
                return efl_access_selection_all_children_select_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_selection_all_children_select_delegate efl_access_selection_all_children_select_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_clear_api_delegate> efl_access_selection_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_clear_api_delegate>(Module, "efl_access_selection_clear");

        private static bool access_selection_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_selection_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ListView)ws.Target).ClearAccessSelection();
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
                return efl_access_selection_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_selection_clear_delegate efl_access_selection_clear_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_selection_child_deselect_delegate(System.IntPtr obj, System.IntPtr pd,  int child_index);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_selection_child_deselect_api_delegate(System.IntPtr obj,  int child_index);

        public static Efl.Eo.FunctionWrapper<efl_access_selection_child_deselect_api_delegate> efl_access_selection_child_deselect_ptr = new Efl.Eo.FunctionWrapper<efl_access_selection_child_deselect_api_delegate>(Module, "efl_access_selection_child_deselect");

        private static bool child_deselect(System.IntPtr obj, System.IntPtr pd, int child_index)
        {
            Eina.Log.Debug("function efl_access_selection_child_deselect was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ListView)ws.Target).ChildDeselect(child_index);
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
                return efl_access_selection_child_deselect_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child_index);
            }
        }

        private static efl_access_selection_child_deselect_delegate efl_access_selection_child_deselect_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_visibility_update_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_scrollbar_bar_visibility_update_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_visibility_update_api_delegate> efl_ui_scrollbar_bar_visibility_update_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_visibility_update_api_delegate>(Module, "efl_ui_scrollbar_bar_visibility_update");

        private static void bar_visibility_update(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollbar_bar_visibility_update was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((ListView)ws.Target).UpdateBarVisibility();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollbar_bar_visibility_update_delegate efl_ui_scrollbar_bar_visibility_update_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Focus.IManager efl_ui_widget_focus_manager_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject root);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Focus.IManager efl_ui_widget_focus_manager_create_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject root);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_manager_create_api_delegate> efl_ui_widget_focus_manager_create_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_manager_create_api_delegate>(Module, "efl_ui_widget_focus_manager_create");

        private static Efl.Ui.Focus.IManager focus_manager_create(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.IObject root)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_manager_create was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Ui.Focus.IManager _ret_var = default(Efl.Ui.Focus.IManager);
                try
                {
                    _ret_var = ((ListView)ws.Target).FocusManagerCreate(root);
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
                return efl_ui_widget_focus_manager_create_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), root);
            }
        }

        private static efl_ui_widget_focus_manager_create_delegate efl_ui_widget_focus_manager_create_static_delegate;

        
        private delegate System.IntPtr efl_ui_focus_composition_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_focus_composition_elements_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_get_api_delegate> efl_ui_focus_composition_elements_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_get_api_delegate>(Module, "efl_ui_focus_composition_elements_get");

        private static System.IntPtr composition_elements_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_elements_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.List<Efl.Gfx.IEntity> _ret_var = default(Eina.List<Efl.Gfx.IEntity>);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetCompositionElements();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_ui_focus_composition_elements_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_composition_elements_get_delegate efl_ui_focus_composition_elements_get_static_delegate;

        
        private delegate void efl_ui_focus_composition_elements_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr logical_order);

        
        public delegate void efl_ui_focus_composition_elements_set_api_delegate(System.IntPtr obj,  System.IntPtr logical_order);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_set_api_delegate> efl_ui_focus_composition_elements_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_set_api_delegate>(Module, "efl_ui_focus_composition_elements_set");

        private static void composition_elements_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr logical_order)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_elements_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_logical_order = new Eina.List<Efl.Gfx.IEntity>(logical_order, true, false);
                            
                try
                {
                    ((ListView)ws.Target).SetCompositionElements(_in_logical_order);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_composition_elements_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), logical_order);
            }
        }

        private static efl_ui_focus_composition_elements_set_delegate efl_ui_focus_composition_elements_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_focus_composition_logical_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_focus_composition_logical_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_get_api_delegate> efl_ui_focus_composition_logical_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_get_api_delegate>(Module, "efl_ui_focus_composition_logical_mode_get");

        private static bool logical_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetLogicalMode();
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
                return efl_ui_focus_composition_logical_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_composition_logical_mode_get_delegate efl_ui_focus_composition_logical_mode_get_static_delegate;

        
        private delegate void efl_ui_focus_composition_logical_mode_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool logical_mode);

        
        public delegate void efl_ui_focus_composition_logical_mode_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool logical_mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_set_api_delegate> efl_ui_focus_composition_logical_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_set_api_delegate>(Module, "efl_ui_focus_composition_logical_mode_set");

        private static void logical_mode_set(System.IntPtr obj, System.IntPtr pd, bool logical_mode)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ListView)ws.Target).SetLogicalMode(logical_mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_composition_logical_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), logical_mode);
            }
        }

        private static efl_ui_focus_composition_logical_mode_set_delegate efl_ui_focus_composition_logical_mode_set_static_delegate;

        
        private delegate void efl_ui_focus_composition_dirty_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_composition_dirty_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_dirty_api_delegate> efl_ui_focus_composition_dirty_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_dirty_api_delegate>(Module, "efl_ui_focus_composition_dirty");

        private static void dirty(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_dirty was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((ListView)ws.Target).Dirty();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_focus_composition_dirty_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_composition_dirty_delegate efl_ui_focus_composition_dirty_static_delegate;

        
        private delegate void efl_ui_focus_composition_prepare_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_composition_prepare_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_prepare_api_delegate> efl_ui_focus_composition_prepare_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_prepare_api_delegate>(Module, "efl_ui_focus_composition_prepare");

        private static void prepare(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_prepare was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((ListView)ws.Target).Prepare();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_focus_composition_prepare_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_composition_prepare_delegate efl_ui_focus_composition_prepare_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiListView_ExtensionMethods {
    public static Efl.BindableProperty<bool> Homogeneous<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<bool>("homogeneous", fac);
    }

    public static Efl.BindableProperty<Elm.Object.SelectMode> SelectMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<Elm.Object.SelectMode>("select_mode", fac);
    }

    public static Efl.BindableProperty<System.String> DefaultStyle<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<System.String>("default_style", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.IFactory> LayoutFactory<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<Efl.Ui.IFactory>("layout_factory", fac);
    }

    
    
    
    
    public static Efl.BindableProperty<Eina.Size2D> MinSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<Eina.Size2D>("min_size", fac);
    }

    public static Efl.BindableProperty<Eina.Position2D> ContentPos<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<Eina.Position2D>("content_pos", fac);
    }

    
    
    
    public static Efl.BindableProperty<bool> ScrollFreeze<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<bool>("scroll_freeze", fac);
    }

    public static Efl.BindableProperty<bool> ScrollHold<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<bool>("scroll_hold", fac);
    }

    
    public static Efl.BindableProperty<Efl.Ui.LayoutOrientation> MovementBlock<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<Efl.Ui.LayoutOrientation>("movement_block", fac);
    }

    
    
    public static Efl.BindableProperty<Eina.Position2D> StepSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<Eina.Position2D>("step_size", fac);
    }

    
    
    
    public static Efl.BindableProperty<Eina.List<Efl.Gfx.IEntity>> CompositionElements<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<Eina.List<Efl.Gfx.IEntity>>("composition_elements", fac);
    }

    public static Efl.BindableProperty<bool> LogicalMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<bool>("logical_mode", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.Focus.IObject> ManagerFocus<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<Efl.Ui.Focus.IObject>("manager_focus", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.Focus.IManager> Redirect<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<Efl.Ui.Focus.IManager>("redirect", fac);
    }

    
    
    public static Efl.BindableProperty<Efl.Ui.Focus.IObject> Root<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<Efl.Ui.Focus.IObject>("root", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>Information related to item events.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ListViewItemEvent
{
    /// <summary>TBD</summary>
    public Efl.Ui.Layout Layout;
    /// <summary>TBD</summary>
    public Efl.IModel Child;
    /// <summary>TBD</summary>
    public int Index;
    /// <summary>Constructor for ListViewItemEvent.</summary>
    /// <param name="Layout">TBD</param>
    /// <param name="Child">TBD</param>
    /// <param name="Index">TBD</param>
    public ListViewItemEvent(
        Efl.Ui.Layout Layout = default(Efl.Ui.Layout),
        Efl.IModel Child = default(Efl.IModel),
        int Index = default(int)    )
    {
        this.Layout = Layout;
        this.Child = Child;
        this.Index = Index;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ListViewItemEvent(IntPtr ptr)
    {
        var tmp = (ListViewItemEvent.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ListViewItemEvent.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ListViewItemEvent.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        /// <summary>Internal wrapper for field Layout</summary>
        public System.IntPtr Layout;
        /// <summary>Internal wrapper for field Child</summary>
        public System.IntPtr Child;
        
        public int Index;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ListViewItemEvent.NativeStruct(ListViewItemEvent _external_struct)
        {
            var _internal_struct = new ListViewItemEvent.NativeStruct();
            _internal_struct.Layout = _external_struct.Layout?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Child = _external_struct.Child?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Index = _external_struct.Index;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ListViewItemEvent(ListViewItemEvent.NativeStruct _internal_struct)
        {
            var _external_struct = new ListViewItemEvent();

            _external_struct.Layout = (Efl.Ui.Layout) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Layout);

            _external_struct.Child = (Efl.ModelConcrete) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Child);
            _external_struct.Index = _internal_struct.Index;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

