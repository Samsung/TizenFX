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

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemRealizedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ListViewItemRealizedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Ui.ListViewItemEvent arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemUnrealizedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ListViewItemUnrealizedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Ui.ListViewItemEvent arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemFocusedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ListViewItemFocusedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Ui.ListViewItemEvent arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemUnfocusedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ListViewItemUnfocusedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Ui.ListViewItemEvent arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemHighlightedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ListViewItemHighlightedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Ui.ListViewItemEvent arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.ListView.ItemUnhighlightedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class ListViewItemUnhighlightedEvt_Args : EventArgs {
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

    /// <value><see cref="Efl.Ui.ListViewItemRealizedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.ListViewItemRealizedEvt_Args> ItemRealizedEvt
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
                        Efl.Ui.ListViewItemRealizedEvt_Args args = new Efl.Ui.ListViewItemRealizedEvt_Args();
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
    /// <summary>Method to raise event ItemRealizedEvt.</summary>
    public void OnItemRealizedEvt(Efl.Ui.ListViewItemRealizedEvt_Args e)
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
    /// <value><see cref="Efl.Ui.ListViewItemUnrealizedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.ListViewItemUnrealizedEvt_Args> ItemUnrealizedEvt
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
                        Efl.Ui.ListViewItemUnrealizedEvt_Args args = new Efl.Ui.ListViewItemUnrealizedEvt_Args();
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
    /// <summary>Method to raise event ItemUnrealizedEvt.</summary>
    public void OnItemUnrealizedEvt(Efl.Ui.ListViewItemUnrealizedEvt_Args e)
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
    /// <value><see cref="Efl.Ui.ListViewItemFocusedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.ListViewItemFocusedEvt_Args> ItemFocusedEvt
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
                        Efl.Ui.ListViewItemFocusedEvt_Args args = new Efl.Ui.ListViewItemFocusedEvt_Args();
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
    /// <summary>Method to raise event ItemFocusedEvt.</summary>
    public void OnItemFocusedEvt(Efl.Ui.ListViewItemFocusedEvt_Args e)
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
    /// <value><see cref="Efl.Ui.ListViewItemUnfocusedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.ListViewItemUnfocusedEvt_Args> ItemUnfocusedEvt
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
                        Efl.Ui.ListViewItemUnfocusedEvt_Args args = new Efl.Ui.ListViewItemUnfocusedEvt_Args();
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
    /// <summary>Method to raise event ItemUnfocusedEvt.</summary>
    public void OnItemUnfocusedEvt(Efl.Ui.ListViewItemUnfocusedEvt_Args e)
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
    /// <value><see cref="Efl.Ui.ListViewItemHighlightedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.ListViewItemHighlightedEvt_Args> ItemHighlightedEvt
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
                        Efl.Ui.ListViewItemHighlightedEvt_Args args = new Efl.Ui.ListViewItemHighlightedEvt_Args();
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
    /// <summary>Method to raise event ItemHighlightedEvt.</summary>
    public void OnItemHighlightedEvt(Efl.Ui.ListViewItemHighlightedEvt_Args e)
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
    /// <value><see cref="Efl.Ui.ListViewItemUnhighlightedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.ListViewItemUnhighlightedEvt_Args> ItemUnhighlightedEvt
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
                        Efl.Ui.ListViewItemUnhighlightedEvt_Args args = new Efl.Ui.ListViewItemUnhighlightedEvt_Args();
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
    /// <summary>Method to raise event ItemUnhighlightedEvt.</summary>
    public void OnItemUnhighlightedEvt(Efl.Ui.ListViewItemUnhighlightedEvt_Args e)
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
    public event EventHandler AccessSelectionChangedEvt
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
    /// <summary>Method to raise event AccessSelectionChangedEvt.</summary>
    public void OnAccessSelectionChangedEvt(EventArgs e)
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
    /// <value><see cref="Efl.Ui.IContainerSelectableItemSelectedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IContainerSelectableItemSelectedEvt_Args> ItemSelectedEvt
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
                        Efl.Ui.IContainerSelectableItemSelectedEvt_Args args = new Efl.Ui.IContainerSelectableItemSelectedEvt_Args();
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
    /// <summary>Method to raise event ItemSelectedEvt.</summary>
    public void OnItemSelectedEvt(Efl.Ui.IContainerSelectableItemSelectedEvt_Args e)
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
    /// <value><see cref="Efl.Ui.IContainerSelectableItemUnselectedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IContainerSelectableItemUnselectedEvt_Args> ItemUnselectedEvt
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
                        Efl.Ui.IContainerSelectableItemUnselectedEvt_Args args = new Efl.Ui.IContainerSelectableItemUnselectedEvt_Args();
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
    /// <summary>Method to raise event ItemUnselectedEvt.</summary>
    public void OnItemUnselectedEvt(Efl.Ui.IContainerSelectableItemUnselectedEvt_Args e)
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
    public event EventHandler ScrollStartEvt
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

                string key = "_EFL_UI_EVENT_SCROLL_START";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_START";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollStartEvt.</summary>
    public void OnScrollStartEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling</summary>
    public event EventHandler ScrollEvt
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

                string key = "_EFL_UI_EVENT_SCROLL";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollEvt.</summary>
    public void OnScrollEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll operation stops</summary>
    public event EventHandler ScrollStopEvt
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

                string key = "_EFL_UI_EVENT_SCROLL_STOP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_STOP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollStopEvt.</summary>
    public void OnScrollStopEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_STOP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scrolling upwards</summary>
    public event EventHandler ScrollUpEvt
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
    /// <summary>Method to raise event ScrollUpEvt.</summary>
    public void OnScrollUpEvt(EventArgs e)
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
    public event EventHandler ScrollDownEvt
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
    /// <summary>Method to raise event ScrollDownEvt.</summary>
    public void OnScrollDownEvt(EventArgs e)
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
    public event EventHandler ScrollLeftEvt
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
    /// <summary>Method to raise event ScrollLeftEvt.</summary>
    public void OnScrollLeftEvt(EventArgs e)
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
    public event EventHandler ScrollRightEvt
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
    /// <summary>Method to raise event ScrollRightEvt.</summary>
    public void OnScrollRightEvt(EventArgs e)
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
    public event EventHandler EdgeUpEvt
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
    /// <summary>Method to raise event EdgeUpEvt.</summary>
    public void OnEdgeUpEvt(EventArgs e)
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
    public event EventHandler EdgeDownEvt
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
    /// <summary>Method to raise event EdgeDownEvt.</summary>
    public void OnEdgeDownEvt(EventArgs e)
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
    public event EventHandler EdgeLeftEvt
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
    /// <summary>Method to raise event EdgeLeftEvt.</summary>
    public void OnEdgeLeftEvt(EventArgs e)
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
    public event EventHandler EdgeRightEvt
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
    /// <summary>Method to raise event EdgeRightEvt.</summary>
    public void OnEdgeRightEvt(EventArgs e)
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
    public event EventHandler ScrollAnimStartEvt
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

                string key = "_EFL_UI_EVENT_SCROLL_ANIM_START";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_START";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollAnimStartEvt.</summary>
    public void OnScrollAnimStartEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_ANIM_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll animation stopps</summary>
    public event EventHandler ScrollAnimStopEvt
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

                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STOP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STOP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollAnimStopEvt.</summary>
    public void OnScrollAnimStopEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_ANIM_STOP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll drag starts</summary>
    public event EventHandler ScrollDragStartEvt
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

                string key = "_EFL_UI_EVENT_SCROLL_DRAG_START";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_START";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollDragStartEvt.</summary>
    public void OnScrollDragStartEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_DRAG_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when scroll drag stops</summary>
    public event EventHandler ScrollDragStopEvt
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

                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STOP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STOP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ScrollDragStopEvt.</summary>
    public void OnScrollDragStopEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_SCROLL_DRAG_STOP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when bar is pressed.</summary>
    /// <value><see cref="Efl.Ui.IScrollbarBarPressEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IScrollbarBarPressEvt_Args> BarPressEvt
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
                        Efl.Ui.IScrollbarBarPressEvt_Args args = new Efl.Ui.IScrollbarBarPressEvt_Args();
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
    /// <summary>Method to raise event BarPressEvt.</summary>
    public void OnBarPressEvt(Efl.Ui.IScrollbarBarPressEvt_Args e)
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
    /// <value><see cref="Efl.Ui.IScrollbarBarUnpressEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IScrollbarBarUnpressEvt_Args> BarUnpressEvt
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
                        Efl.Ui.IScrollbarBarUnpressEvt_Args args = new Efl.Ui.IScrollbarBarUnpressEvt_Args();
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
    /// <summary>Method to raise event BarUnpressEvt.</summary>
    public void OnBarUnpressEvt(Efl.Ui.IScrollbarBarUnpressEvt_Args e)
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
    /// <value><see cref="Efl.Ui.IScrollbarBarDragEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IScrollbarBarDragEvt_Args> BarDragEvt
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
                        Efl.Ui.IScrollbarBarDragEvt_Args args = new Efl.Ui.IScrollbarBarDragEvt_Args();
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
    /// <summary>Method to raise event BarDragEvt.</summary>
    public void OnBarDragEvt(Efl.Ui.IScrollbarBarDragEvt_Args e)
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
    public event EventHandler BarSizeChangedEvt
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
    /// <summary>Method to raise event BarSizeChangedEvt.</summary>
    public void OnBarSizeChangedEvt(EventArgs e)
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
    public event EventHandler BarPosChangedEvt
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
    /// <summary>Method to raise event BarPosChangedEvt.</summary>
    public void OnBarPosChangedEvt(EventArgs e)
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
    /// <value><see cref="Efl.Ui.IScrollbarBarShowEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IScrollbarBarShowEvt_Args> BarShowEvt
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
                        Efl.Ui.IScrollbarBarShowEvt_Args args = new Efl.Ui.IScrollbarBarShowEvt_Args();
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
    /// <summary>Method to raise event BarShowEvt.</summary>
    public void OnBarShowEvt(Efl.Ui.IScrollbarBarShowEvt_Args e)
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
    /// <value><see cref="Efl.Ui.IScrollbarBarHideEvt_Args"/></value>
    public event EventHandler<Efl.Ui.IScrollbarBarHideEvt_Args> BarHideEvt
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
                        Efl.Ui.IScrollbarBarHideEvt_Args args = new Efl.Ui.IScrollbarBarHideEvt_Args();
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
    /// <summary>Method to raise event BarHideEvt.</summary>
    public void OnBarHideEvt(Efl.Ui.IScrollbarBarHideEvt_Args e)
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
    /// <value><see cref="Efl.Ui.Focus.IManagerRedirectChangedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.Focus.IManagerRedirectChangedEvt_Args> RedirectChangedEvt
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
                        Efl.Ui.Focus.IManagerRedirectChangedEvt_Args args = new Efl.Ui.Focus.IManagerRedirectChangedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Ui.Focus.IManagerConcrete);
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
    /// <summary>Method to raise event RedirectChangedEvt.</summary>
    public void OnRedirectChangedEvt(Efl.Ui.Focus.IManagerRedirectChangedEvt_Args e)
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
    public event EventHandler FlushPreEvt
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
    /// <summary>Method to raise event FlushPreEvt.</summary>
    public void OnFlushPreEvt(EventArgs e)
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
    public event EventHandler CoordsDirtyEvt
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
    /// <summary>Method to raise event CoordsDirtyEvt.</summary>
    public void OnCoordsDirtyEvt(EventArgs e)
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
    /// <value><see cref="Efl.Ui.Focus.IManagerManagerFocusChangedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.Focus.IManagerManagerFocusChangedEvt_Args> ManagerFocusChangedEvt
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
                        Efl.Ui.Focus.IManagerManagerFocusChangedEvt_Args args = new Efl.Ui.Focus.IManagerManagerFocusChangedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Ui.Focus.IObjectConcrete);
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
    /// <summary>Method to raise event ManagerFocusChangedEvt.</summary>
    public void OnManagerFocusChangedEvt(Efl.Ui.Focus.IManagerManagerFocusChangedEvt_Args e)
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
    /// <value><see cref="Efl.Ui.Focus.IManagerDirtyLogicFreezeChangedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.Focus.IManagerDirtyLogicFreezeChangedEvt_Args> DirtyLogicFreezeChangedEvt
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
                        Efl.Ui.Focus.IManagerDirtyLogicFreezeChangedEvt_Args args = new Efl.Ui.Focus.IManagerDirtyLogicFreezeChangedEvt_Args();
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
    /// <summary>Method to raise event DirtyLogicFreezeChangedEvt.</summary>
    public void OnDirtyLogicFreezeChangedEvt(Efl.Ui.Focus.IManagerDirtyLogicFreezeChangedEvt_Args e)
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
    virtual public bool GetHomogeneous() {
         var _ret_var = Efl.Ui.ListView.NativeMethods.efl_ui_list_view_homogeneous_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>When in homogeneous mode, all items have the same height and width. Otherwise, each item&apos;s size is respected.</summary>
    /// <param name="homogeneous">Homogeneous mode setting. Default is <c>false</c>.</param>
    virtual public void SetHomogeneous(bool homogeneous) {
                                 Efl.Ui.ListView.NativeMethods.efl_ui_list_view_homogeneous_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),homogeneous);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Listview select mode.</summary>
    /// <returns>The select mode.</returns>
    virtual public Elm.Object.SelectMode GetSelectMode() {
         var _ret_var = Efl.Ui.ListView.NativeMethods.efl_ui_list_view_select_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Listview select mode.</summary>
    /// <param name="mode">The select mode.</param>
    virtual public void SetSelectMode(Elm.Object.SelectMode mode) {
                                 Efl.Ui.ListView.NativeMethods.efl_ui_list_view_select_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>TBD</summary>
    /// <returns>TBD</returns>
    virtual public System.String GetDefaultStyle() {
         var _ret_var = Efl.Ui.ListView.NativeMethods.efl_ui_list_view_default_style_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>TBD</summary>
    /// <param name="style">TBD</param>
    virtual public void SetDefaultStyle(System.String style) {
                                 Efl.Ui.ListView.NativeMethods.efl_ui_list_view_default_style_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),style);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Listview layout factory set.</summary>
    /// <param name="factory">The factory.</param>
    virtual public void SetLayoutFactory(Efl.Ui.IFactory factory) {
                                 Efl.Ui.ListView.NativeMethods.efl_ui_list_view_layout_factory_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),factory);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the number of currently selected children</summary>
    /// <returns>Number of currently selected children</returns>
    virtual public int GetSelectedChildrenCount() {
         var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_selected_children_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets child for given child index</summary>
    /// <param name="selected_child_index">Index of child</param>
    /// <returns>Child object</returns>
    virtual public Efl.Object GetSelectedChild(int selected_child_index) {
                                 var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_selected_child_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),selected_child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds selection for given child index</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if selection was added, <c>false</c> otherwise</returns>
    virtual public bool ChildSelect(int child_index) {
                                 var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_child_select_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Removes selection for given child index</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
    virtual public bool SelectedChildDeselect(int child_index) {
                                 var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_selected_child_deselect_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Determines if child specified by index is selected</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if child is selected, <c>false</c> otherwise</returns>
    virtual public bool IsChildSelected(int child_index) {
                                 var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_is_child_selected_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds selection for all children</summary>
    /// <returns><c>true</c> if selection was added to all children, <c>false</c> otherwise</returns>
    virtual public bool AllChildrenSelect() {
         var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_all_children_select_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Clears the current selection</summary>
    /// <returns><c>true</c> if selection was cleared, <c>false</c> otherwise</returns>
    virtual public bool ClearAccessSelection() {
         var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes selection for given child index</summary>
    /// <param name="child_index">Index of child</param>
    /// <returns><c>true</c> if selection was removed, <c>false</c> otherwise</returns>
    virtual public bool ChildDeselect(int child_index) {
                                 var _ret_var = Efl.Access.ISelectionConcrete.NativeMethods.efl_access_selection_child_deselect_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child_index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    virtual public void SetLoadRange(int first, int count) {
                                                         Efl.Ui.IListViewModelConcrete.NativeMethods.efl_ui_list_view_model_load_range_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),first, count);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    virtual public int GetModelSize() {
         var _ret_var = Efl.Ui.IListViewModelConcrete.NativeMethods.efl_ui_list_view_model_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Minimal content size.</summary>
    virtual public Eina.Size2D GetMinSize() {
         var _ret_var = Efl.Ui.IListViewModelConcrete.NativeMethods.efl_ui_list_view_model_min_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Minimal content size.</summary>
    virtual public void SetMinSize(Eina.Size2D min) {
         Eina.Size2D.NativeStruct _in_min = min;
                        Efl.Ui.IListViewModelConcrete.NativeMethods.efl_ui_list_view_model_min_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_min);
        Eina.Error.RaiseIfUnhandledException();
                         }
    virtual public Efl.Ui.ListViewLayoutItem Realize(ref Efl.Ui.ListViewLayoutItem item) {
         Efl.Ui.ListViewLayoutItem.NativeStruct _in_item = item;
                        var _ret_var = Efl.Ui.IListViewModelConcrete.NativeMethods.efl_ui_list_view_model_realize_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref _in_item);
        Eina.Error.RaiseIfUnhandledException();
                item = _in_item;
        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.ListViewLayoutItem>(_ret_var);
        
        return __ret_tmp;
 }
    virtual public void Unrealize(ref Efl.Ui.ListViewLayoutItem item) {
         Efl.Ui.ListViewLayoutItem.NativeStruct _in_item = item;
                        Efl.Ui.IListViewModelConcrete.NativeMethods.efl_ui_list_view_model_unrealize_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref _in_item);
        Eina.Error.RaiseIfUnhandledException();
                item = _in_item;
         }
    /// <summary>The content position</summary>
    /// <returns>The position is virtual value, (0, 0) starting at the top-left.</returns>
    virtual public Eina.Position2D GetContentPos() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_content_pos_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The content position</summary>
    /// <param name="pos">The position is virtual value, (0, 0) starting at the top-left.</param>
    virtual public void SetContentPos(Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_content_pos_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The content size</summary>
    /// <returns>The content size in pixels.</returns>
    virtual public Eina.Size2D GetContentSize() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_content_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The viewport geometry</summary>
    /// <returns>It is absolute geometry.</returns>
    virtual public Eina.Rect GetViewportGeometry() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    virtual public void GetBounceEnabled(out bool horiz, out bool vert) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out horiz, out vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    virtual public void SetBounceEnabled(bool horiz, bool vert) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),horiz, vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <returns><c>true</c> if freeze, <c>false</c> otherwise</returns>
    virtual public bool GetScrollFreeze() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <param name="freeze"><c>true</c> if freeze, <c>false</c> otherwise</param>
    virtual public void SetScrollFreeze(bool freeze) {
                                 Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),freeze);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <returns><c>true</c> if hold, <c>false</c> otherwise</returns>
    virtual public bool GetScrollHold() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <param name="hold"><c>true</c> if hold, <c>false</c> otherwise</param>
    virtual public void SetScrollHold(bool hold) {
                                 Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hold);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    virtual public void GetLooping(out bool loop_h, out bool loop_v) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_looping_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out loop_h, out loop_v);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    virtual public void SetLooping(bool loop_h, bool loop_v) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_looping_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),loop_h, loop_v);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <returns>Which axis (or axes) to block</returns>
    virtual public Efl.Ui.ScrollBlock GetMovementBlock() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_movement_block_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <param name="block">Which axis (or axes) to block</param>
    virtual public void SetMovementBlock(Efl.Ui.ScrollBlock block) {
                                 Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_movement_block_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),block);
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
    virtual public void GetGravity(out double x, out double y) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_gravity_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
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
    virtual public void SetGravity(double x, double y) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_gravity_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
    /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
    /// <param name="w">Whether to limit the minimum horizontal size</param>
    /// <param name="h">Whether to limit the minimum vertical size</param>
    virtual public void SetMatchContent(bool w, bool h) {
                                                         Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_match_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),w, h);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <returns>The step size in pixels</returns>
    virtual public Eina.Position2D GetStepSize() {
         var _ret_var = Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_step_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <param name="step">The step size in pixels</param>
    virtual public void SetStepSize(Eina.Position2D step) {
         Eina.Position2D.NativeStruct _in_step = step;
                        Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_step_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_step);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Show a specific virtual region within the scroller content object.
    /// This will ensure all (or part if it does not fit) of the designated region in the virtual content object (0, 0 starting at the top-left of the virtual content object) is shown within the scroller. This allows the scroller to &quot;smoothly slide&quot; to this location (if configuration in general calls for transitions). It may not jump immediately to the new location and make take a while and show other content along the way.</summary>
    /// <param name="rect">The position where to scroll. and The size user want to see</param>
    /// <param name="animation">Whether to scroll with animation or not</param>
    virtual public void Scroll(Eina.Rect rect, bool animation) {
         Eina.Rect.NativeStruct _in_rect = rect;
                                                Efl.Ui.IScrollableInteractiveConcrete.NativeMethods.efl_ui_scrollable_scroll_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_rect, animation);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar.</param>
    /// <param name="vbar">Vertical scrollbar.</param>
    virtual public void GetBarMode(out Efl.Ui.ScrollbarMode hbar, out Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out hbar, out vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar.</param>
    /// <param name="vbar">Vertical scrollbar.</param>
    virtual public void SetBarMode(Efl.Ui.ScrollbarMode hbar, Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),hbar, vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
    /// <param name="width">Value between 0.0 and 1.0.</param>
    /// <param name="height">Value between 0.0 and 1.0.</param>
    virtual public void GetBarSize(out double width, out double height) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out width, out height);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0.</param>
    /// <param name="posy">Value between 0.0 and 1.0.</param>
    virtual public void GetBarPosition(out double posx, out double posy) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out posx, out posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0.</param>
    /// <param name="posy">Value between 0.0 and 1.0.</param>
    virtual public void SetBarPosition(double posx, double posy) {
                                                         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),posx, posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Update bar visibility.
    /// The object will call this function whenever the bar needs to be shown or hidden.</summary>
    virtual public void UpdateBarVisibility() {
         Efl.Ui.IScrollbarConcrete.NativeMethods.efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>If the widget needs a focus manager, this function will be called.
    /// It can be used and overriden to inject your own manager or set custom options on the focus manager.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">The logical root object for focus.</param>
    /// <returns>The focus manager.</returns>
    virtual public Efl.Ui.Focus.IManager FocusManagerCreate(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.IWidgetFocusManagerConcrete.NativeMethods.efl_ui_widget_focus_manager_create_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Set the order of elements that will be used for composition
    /// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
    /// 
    /// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
    /// 
    /// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
    /// 
    /// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
    /// <returns>The order to use</returns>
    virtual public Eina.List<Efl.Gfx.IEntity> GetCompositionElements() {
         var _ret_var = Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_elements_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Gfx.IEntity>(_ret_var, true, false);
 }
    /// <summary>Set the order of elements that will be used for composition
    /// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
    /// 
    /// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
    /// 
    /// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
    /// 
    /// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
    /// <param name="logical_order">The order to use</param>
    virtual public void SetCompositionElements(Eina.List<Efl.Gfx.IEntity> logical_order) {
         var _in_logical_order = logical_order.Handle;
logical_order.Own = false;
                        Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_elements_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_logical_order);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <returns><c>true</c> or <c>false</c></returns>
    virtual public bool GetLogicalMode() {
         var _ret_var = Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_logical_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <param name="logical_mode"><c>true</c> or <c>false</c></param>
    virtual public void SetLogicalMode(bool logical_mode) {
                                 Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_logical_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),logical_mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Mark this widget as dirty, the children can be considered to be changed after that call</summary>
    virtual public void Dirty() {
         Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_dirty_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>A call to prepare the children of this element, called if marked as dirty
    /// You can use this function to call composition_elements.</summary>
    virtual public void Prepare() {
         Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_prepare_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The element which is currently focused by this manager
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next non-logical object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <returns>Currently focused element.</returns>
    virtual public Efl.Ui.Focus.IObject GetManagerFocus() {
         var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_focus_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The element which is currently focused by this manager
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next non-logical object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <param name="focus">Currently focused element.</param>
    virtual public void SetManagerFocus(Efl.Ui.Focus.IObject focus) {
                                 Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_focus_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <returns>The redirect manager.</returns>
    virtual public Efl.Ui.Focus.IManager GetRedirect() {
         var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_redirect_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <param name="redirect">The redirect manager.</param>
    virtual public void SetRedirect(Efl.Ui.Focus.IManager redirect) {
                                 Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_redirect_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),redirect);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The list of elements which are at the border of the graph.
    /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.IManager.Move"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>An iterator over the border objects.</returns>
    virtual public Eina.Iterator<Efl.Ui.Focus.IObject> GetBorderElements() {
         var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_border_elements_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Ui.Focus.IObject>(_ret_var, false);
 }
    /// <summary>Get all elements that are at the border of the viewport
    /// Every element returned by this is located inside the viewport rectangle, but has a right, left, down or up neighbor outside the viewport.
    /// (Since EFL 1.22)</summary>
    /// <param name="viewport">The rectangle defining the viewport.</param>
    /// <returns>The list of border objects.</returns>
    virtual public Eina.Iterator<Efl.Ui.Focus.IObject> GetViewportElements(Eina.Rect viewport) {
         Eina.Rect.NativeStruct _in_viewport = viewport;
                        var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_viewport_elements_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_viewport);
        Eina.Error.RaiseIfUnhandledException();
                        return new Eina.Iterator<Efl.Ui.Focus.IObject>(_ret_var, false);
 }
    /// <summary>Root node for all logical subtrees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <returns>Will be registered into this manager object.</returns>
    virtual public Efl.Ui.Focus.IObject GetRoot() {
         var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_root_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Root node for all logical subtrees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">Will be registered into this manager object.</param>
    /// <returns>If <c>true</c>, this is the root node</returns>
    virtual public bool SetRoot(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_root_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Move the focus in the given direction.
    /// This call flushes all changes. This means all changes between the last flush and now are computed.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">The direction to move to.</param>
    /// <returns>The element which is now focused.</returns>
    virtual public Efl.Ui.Focus.IObject Move(Efl.Ui.Focus.Direction direction) {
                                 var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_move_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),direction);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Return the object in the <c>direction</c> from <c>child</c>.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">Direction to move focus.</param>
    /// <param name="child">The child to move from. Pass <c>null</c> to indicate the currently focused child.</param>
    /// <param name="logical">Wether you want to have a logical node as result or a non-logical. Note, in a <see cref="Efl.Ui.Focus.IManager.Move"/> call no logical node will get focus.</param>
    /// <returns>Object that would receive focus if moved in the given direction.</returns>
    virtual public Efl.Ui.Focus.IObject MoveRequest(Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject child, bool logical) {
                                                                                 var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_request_move_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),direction, child, logical);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Return the widget in the direction next.
    /// The returned widget is a child of <c>root</c>. It&apos;s guaranteed that child will not be prepared once again, so you can call this function inside a <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> call.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">Parent for returned child.</param>
    /// <returns>Child of passed parameter.</returns>
    virtual public Efl.Ui.Focus.IObject RequestSubchild(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_request_subchild_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>This will fetch the data from a registered node.
    /// Be aware this function will trigger a computation of all dirty nodes.
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="child">The child object to inspect.</param>
    /// <returns>The list of relations starting from <c>child</c>.</returns>
    virtual public Efl.Ui.Focus.Relations Fetch(Efl.Ui.Focus.IObject child) {
                                 var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_fetch_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child);
        Eina.Error.RaiseIfUnhandledException();
                        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.Focus.Relations>(_ret_var);
        Marshal.FreeHGlobal(_ret_var);
        return __ret_tmp;
 }
    /// <summary>Return the last logical object.
    /// The returned object is the last object that would be returned if you start at the root and move the direction into next.
    /// (Since EFL 1.22)</summary>
    /// <returns>Last object.</returns>
    virtual public Efl.Ui.Focus.ManagerLogicalEndDetail LogicalEnd() {
         var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_logical_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Reset the history stack of this manager object. This means the uppermost element will be unfocused, and all other elements will be removed from the remembered list.
    /// You should focus another element immediately after calling this, in order to always have a focused object.
    /// (Since EFL 1.22)</summary>
    virtual public void ResetHistory() {
         Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_reset_history_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Remove the uppermost history element, and focus the previous one.
    /// If there is an element that was focused before, it will be used. Otherwise, the best fitting element from the registered elements will be focused.
    /// (Since EFL 1.22)</summary>
    virtual public void PopHistoryStack() {
         Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_pop_history_stack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Called when this manager is set as redirect.
    /// In case that this is called as an result of a move call, <c>direction</c> and <c>entry</c> will be set to the direction of the move call, and the <c>entry</c> object will be set to the object that had this manager as redirect property.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">The direction in which this should be setup.</param>
    /// <param name="entry">The object that caused this manager to be redirect.</param>
    virtual public void SetupOnFirstTouch(Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject entry) {
                                                         Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_setup_on_first_touch_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),direction, entry);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This disables the cache invalidation when an object is moved.
    /// Even if an object is moved, the focus manager will not recalculate its relations. This can be used when you know that the set of widgets in the focus manager is moved the same way, so the relations between the widets in the set do not change and the complex calculations can be avoided. Use <see cref="Efl.Ui.Focus.IManager.DirtyLogicUnfreeze"/> to re-enable relationship calculation.
    /// (Since EFL 1.22)</summary>
    virtual public void FreezeDirtyLogic() {
         Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_dirty_logic_freeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This enables the cache invalidation when an object is moved.
    /// This is the counterpart to <see cref="Efl.Ui.Focus.IManager.FreezeDirtyLogic"/>.
    /// (Since EFL 1.22)</summary>
    virtual public void DirtyLogicUnfreeze() {
         Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_dirty_logic_unfreeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
    public int SelectedChildrenCount {
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
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
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
    public Efl.Ui.ScrollBlock MovementBlock {
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
    /// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
    /// 
    /// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
    /// 
    /// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
    /// 
    /// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
    /// <value>The order to use</value>
    public Eina.List<Efl.Gfx.IEntity> CompositionElements {
        get { return GetCompositionElements(); }
        set { SetCompositionElements(value); }
    }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <value><c>true</c> or <c>false</c></value>
    public bool LogicalMode {
        get { return GetLogicalMode(); }
        set { SetLogicalMode(value); }
    }
    /// <summary>The element which is currently focused by this manager
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next non-logical object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <value>Currently focused element.</value>
    public Efl.Ui.Focus.IObject ManagerFocus {
        get { return GetManagerFocus(); }
        set { SetManagerFocus(value); }
    }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <value>The redirect manager.</value>
    public Efl.Ui.Focus.IManager Redirect {
        get { return GetRedirect(); }
        set { SetRedirect(value); }
    }
    /// <summary>The list of elements which are at the border of the graph.
    /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.IManager.Move"/>
    /// (Since EFL 1.22)</summary>
    /// <value>An iterator over the border objects.</value>
    public Eina.Iterator<Efl.Ui.Focus.IObject> BorderElements {
        get { return GetBorderElements(); }
    }
    /// <summary>Root node for all logical subtrees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <value>Will be registered into this manager object.</value>
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
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
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

            if (efl_ui_list_view_model_load_range_set_static_delegate == null)
            {
                efl_ui_list_view_model_load_range_set_static_delegate = new efl_ui_list_view_model_load_range_set_delegate(load_range_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLoadRange") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_model_load_range_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_load_range_set_static_delegate) });
            }

            if (efl_ui_list_view_model_size_get_static_delegate == null)
            {
                efl_ui_list_view_model_size_get_static_delegate = new efl_ui_list_view_model_size_get_delegate(model_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetModelSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_model_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_size_get_static_delegate) });
            }

            if (efl_ui_list_view_model_min_size_get_static_delegate == null)
            {
                efl_ui_list_view_model_min_size_get_static_delegate = new efl_ui_list_view_model_min_size_get_delegate(min_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMinSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_model_min_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_min_size_get_static_delegate) });
            }

            if (efl_ui_list_view_model_min_size_set_static_delegate == null)
            {
                efl_ui_list_view_model_min_size_set_static_delegate = new efl_ui_list_view_model_min_size_set_delegate(min_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMinSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_model_min_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_min_size_set_static_delegate) });
            }

            if (efl_ui_list_view_model_realize_static_delegate == null)
            {
                efl_ui_list_view_model_realize_static_delegate = new efl_ui_list_view_model_realize_delegate(realize);
            }

            if (methods.FirstOrDefault(m => m.Name == "Realize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_model_realize"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_realize_static_delegate) });
            }

            if (efl_ui_list_view_model_unrealize_static_delegate == null)
            {
                efl_ui_list_view_model_unrealize_static_delegate = new efl_ui_list_view_model_unrealize_delegate(unrealize);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unrealize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_list_view_model_unrealize"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_list_view_model_unrealize_static_delegate) });
            }

            if (efl_ui_scrollable_content_pos_get_static_delegate == null)
            {
                efl_ui_scrollable_content_pos_get_static_delegate = new efl_ui_scrollable_content_pos_get_delegate(content_pos_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContentPos") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_content_pos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_get_static_delegate) });
            }

            if (efl_ui_scrollable_content_pos_set_static_delegate == null)
            {
                efl_ui_scrollable_content_pos_set_static_delegate = new efl_ui_scrollable_content_pos_set_delegate(content_pos_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetContentPos") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_content_pos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_set_static_delegate) });
            }

            if (efl_ui_scrollable_content_size_get_static_delegate == null)
            {
                efl_ui_scrollable_content_size_get_static_delegate = new efl_ui_scrollable_content_size_get_delegate(content_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContentSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_content_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_size_get_static_delegate) });
            }

            if (efl_ui_scrollable_viewport_geometry_get_static_delegate == null)
            {
                efl_ui_scrollable_viewport_geometry_get_static_delegate = new efl_ui_scrollable_viewport_geometry_get_delegate(viewport_geometry_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetViewportGeometry") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_viewport_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_viewport_geometry_get_static_delegate) });
            }

            if (efl_ui_scrollable_bounce_enabled_get_static_delegate == null)
            {
                efl_ui_scrollable_bounce_enabled_get_static_delegate = new efl_ui_scrollable_bounce_enabled_get_delegate(bounce_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBounceEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_bounce_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_get_static_delegate) });
            }

            if (efl_ui_scrollable_bounce_enabled_set_static_delegate == null)
            {
                efl_ui_scrollable_bounce_enabled_set_static_delegate = new efl_ui_scrollable_bounce_enabled_set_delegate(bounce_enabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBounceEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_bounce_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_set_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_freeze_get_static_delegate == null)
            {
                efl_ui_scrollable_scroll_freeze_get_static_delegate = new efl_ui_scrollable_scroll_freeze_get_delegate(scroll_freeze_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScrollFreeze") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll_freeze_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_get_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_freeze_set_static_delegate == null)
            {
                efl_ui_scrollable_scroll_freeze_set_static_delegate = new efl_ui_scrollable_scroll_freeze_set_delegate(scroll_freeze_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScrollFreeze") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll_freeze_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_set_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_hold_get_static_delegate == null)
            {
                efl_ui_scrollable_scroll_hold_get_static_delegate = new efl_ui_scrollable_scroll_hold_get_delegate(scroll_hold_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScrollHold") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll_hold_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_get_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_hold_set_static_delegate == null)
            {
                efl_ui_scrollable_scroll_hold_set_static_delegate = new efl_ui_scrollable_scroll_hold_set_delegate(scroll_hold_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScrollHold") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll_hold_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_set_static_delegate) });
            }

            if (efl_ui_scrollable_looping_get_static_delegate == null)
            {
                efl_ui_scrollable_looping_get_static_delegate = new efl_ui_scrollable_looping_get_delegate(looping_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLooping") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_looping_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_get_static_delegate) });
            }

            if (efl_ui_scrollable_looping_set_static_delegate == null)
            {
                efl_ui_scrollable_looping_set_static_delegate = new efl_ui_scrollable_looping_set_delegate(looping_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLooping") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_looping_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_set_static_delegate) });
            }

            if (efl_ui_scrollable_movement_block_get_static_delegate == null)
            {
                efl_ui_scrollable_movement_block_get_static_delegate = new efl_ui_scrollable_movement_block_get_delegate(movement_block_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMovementBlock") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_movement_block_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_get_static_delegate) });
            }

            if (efl_ui_scrollable_movement_block_set_static_delegate == null)
            {
                efl_ui_scrollable_movement_block_set_static_delegate = new efl_ui_scrollable_movement_block_set_delegate(movement_block_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMovementBlock") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_movement_block_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_set_static_delegate) });
            }

            if (efl_ui_scrollable_gravity_get_static_delegate == null)
            {
                efl_ui_scrollable_gravity_get_static_delegate = new efl_ui_scrollable_gravity_get_delegate(gravity_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetGravity") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_gravity_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_get_static_delegate) });
            }

            if (efl_ui_scrollable_gravity_set_static_delegate == null)
            {
                efl_ui_scrollable_gravity_set_static_delegate = new efl_ui_scrollable_gravity_set_delegate(gravity_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGravity") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_gravity_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_set_static_delegate) });
            }

            if (efl_ui_scrollable_match_content_set_static_delegate == null)
            {
                efl_ui_scrollable_match_content_set_static_delegate = new efl_ui_scrollable_match_content_set_delegate(match_content_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMatchContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_match_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_match_content_set_static_delegate) });
            }

            if (efl_ui_scrollable_step_size_get_static_delegate == null)
            {
                efl_ui_scrollable_step_size_get_static_delegate = new efl_ui_scrollable_step_size_get_delegate(step_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStepSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_step_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_step_size_get_static_delegate) });
            }

            if (efl_ui_scrollable_step_size_set_static_delegate == null)
            {
                efl_ui_scrollable_step_size_set_static_delegate = new efl_ui_scrollable_step_size_set_delegate(step_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStepSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_step_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_step_size_set_static_delegate) });
            }

            if (efl_ui_scrollable_scroll_static_delegate == null)
            {
                efl_ui_scrollable_scroll_static_delegate = new efl_ui_scrollable_scroll_delegate(scroll);
            }

            if (methods.FirstOrDefault(m => m.Name == "Scroll") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollable_scroll"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_mode_get_static_delegate == null)
            {
                efl_ui_scrollbar_bar_mode_get_static_delegate = new efl_ui_scrollbar_bar_mode_get_delegate(bar_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBarMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_get_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_mode_set_static_delegate == null)
            {
                efl_ui_scrollbar_bar_mode_set_static_delegate = new efl_ui_scrollbar_bar_mode_set_delegate(bar_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBarMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_set_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_size_get_static_delegate == null)
            {
                efl_ui_scrollbar_bar_size_get_static_delegate = new efl_ui_scrollbar_bar_size_get_delegate(bar_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBarSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_size_get_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_position_get_static_delegate == null)
            {
                efl_ui_scrollbar_bar_position_get_static_delegate = new efl_ui_scrollbar_bar_position_get_delegate(bar_position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBarPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_get_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_position_set_static_delegate == null)
            {
                efl_ui_scrollbar_bar_position_set_static_delegate = new efl_ui_scrollbar_bar_position_set_delegate(bar_position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetBarPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_set_static_delegate) });
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

            if (efl_ui_focus_manager_focus_get_static_delegate == null)
            {
                efl_ui_focus_manager_focus_get_static_delegate = new efl_ui_focus_manager_focus_get_delegate(manager_focus_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetManagerFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_focus_get_static_delegate) });
            }

            if (efl_ui_focus_manager_focus_set_static_delegate == null)
            {
                efl_ui_focus_manager_focus_set_static_delegate = new efl_ui_focus_manager_focus_set_delegate(manager_focus_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetManagerFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_focus_set_static_delegate) });
            }

            if (efl_ui_focus_manager_redirect_get_static_delegate == null)
            {
                efl_ui_focus_manager_redirect_get_static_delegate = new efl_ui_focus_manager_redirect_get_delegate(redirect_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRedirect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_redirect_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_redirect_get_static_delegate) });
            }

            if (efl_ui_focus_manager_redirect_set_static_delegate == null)
            {
                efl_ui_focus_manager_redirect_set_static_delegate = new efl_ui_focus_manager_redirect_set_delegate(redirect_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRedirect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_redirect_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_redirect_set_static_delegate) });
            }

            if (efl_ui_focus_manager_border_elements_get_static_delegate == null)
            {
                efl_ui_focus_manager_border_elements_get_static_delegate = new efl_ui_focus_manager_border_elements_get_delegate(border_elements_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetBorderElements") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_border_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_border_elements_get_static_delegate) });
            }

            if (efl_ui_focus_manager_viewport_elements_get_static_delegate == null)
            {
                efl_ui_focus_manager_viewport_elements_get_static_delegate = new efl_ui_focus_manager_viewport_elements_get_delegate(viewport_elements_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetViewportElements") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_viewport_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_viewport_elements_get_static_delegate) });
            }

            if (efl_ui_focus_manager_root_get_static_delegate == null)
            {
                efl_ui_focus_manager_root_get_static_delegate = new efl_ui_focus_manager_root_get_delegate(root_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRoot") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_root_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_root_get_static_delegate) });
            }

            if (efl_ui_focus_manager_root_set_static_delegate == null)
            {
                efl_ui_focus_manager_root_set_static_delegate = new efl_ui_focus_manager_root_set_delegate(root_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRoot") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_root_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_root_set_static_delegate) });
            }

            if (efl_ui_focus_manager_move_static_delegate == null)
            {
                efl_ui_focus_manager_move_static_delegate = new efl_ui_focus_manager_move_delegate(move);
            }

            if (methods.FirstOrDefault(m => m.Name == "Move") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_move"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_move_static_delegate) });
            }

            if (efl_ui_focus_manager_request_move_static_delegate == null)
            {
                efl_ui_focus_manager_request_move_static_delegate = new efl_ui_focus_manager_request_move_delegate(request_move);
            }

            if (methods.FirstOrDefault(m => m.Name == "MoveRequest") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_request_move"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_request_move_static_delegate) });
            }

            if (efl_ui_focus_manager_request_subchild_static_delegate == null)
            {
                efl_ui_focus_manager_request_subchild_static_delegate = new efl_ui_focus_manager_request_subchild_delegate(request_subchild);
            }

            if (methods.FirstOrDefault(m => m.Name == "RequestSubchild") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_request_subchild"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_request_subchild_static_delegate) });
            }

            if (efl_ui_focus_manager_fetch_static_delegate == null)
            {
                efl_ui_focus_manager_fetch_static_delegate = new efl_ui_focus_manager_fetch_delegate(fetch);
            }

            if (methods.FirstOrDefault(m => m.Name == "Fetch") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_fetch"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_fetch_static_delegate) });
            }

            if (efl_ui_focus_manager_logical_end_static_delegate == null)
            {
                efl_ui_focus_manager_logical_end_static_delegate = new efl_ui_focus_manager_logical_end_delegate(logical_end);
            }

            if (methods.FirstOrDefault(m => m.Name == "LogicalEnd") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_logical_end"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_logical_end_static_delegate) });
            }

            if (efl_ui_focus_manager_reset_history_static_delegate == null)
            {
                efl_ui_focus_manager_reset_history_static_delegate = new efl_ui_focus_manager_reset_history_delegate(reset_history);
            }

            if (methods.FirstOrDefault(m => m.Name == "ResetHistory") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_reset_history"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_reset_history_static_delegate) });
            }

            if (efl_ui_focus_manager_pop_history_stack_static_delegate == null)
            {
                efl_ui_focus_manager_pop_history_stack_static_delegate = new efl_ui_focus_manager_pop_history_stack_delegate(pop_history_stack);
            }

            if (methods.FirstOrDefault(m => m.Name == "PopHistoryStack") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_pop_history_stack"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_pop_history_stack_static_delegate) });
            }

            if (efl_ui_focus_manager_setup_on_first_touch_static_delegate == null)
            {
                efl_ui_focus_manager_setup_on_first_touch_static_delegate = new efl_ui_focus_manager_setup_on_first_touch_delegate(setup_on_first_touch);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetupOnFirstTouch") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_setup_on_first_touch"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_setup_on_first_touch_static_delegate) });
            }

            if (efl_ui_focus_manager_dirty_logic_freeze_static_delegate == null)
            {
                efl_ui_focus_manager_dirty_logic_freeze_static_delegate = new efl_ui_focus_manager_dirty_logic_freeze_delegate(dirty_logic_freeze);
            }

            if (methods.FirstOrDefault(m => m.Name == "FreezeDirtyLogic") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_dirty_logic_freeze"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_dirty_logic_freeze_static_delegate) });
            }

            if (efl_ui_focus_manager_dirty_logic_unfreeze_static_delegate == null)
            {
                efl_ui_focus_manager_dirty_logic_unfreeze_static_delegate = new efl_ui_focus_manager_dirty_logic_unfreeze_delegate(dirty_logic_unfreeze);
            }

            if (methods.FirstOrDefault(m => m.Name == "DirtyLogicUnfreeze") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_manager_dirty_logic_unfreeze"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_manager_dirty_logic_unfreeze_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
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

        
        private delegate void efl_ui_list_view_model_load_range_set_delegate(System.IntPtr obj, System.IntPtr pd,  int first,  int count);

        
        public delegate void efl_ui_list_view_model_load_range_set_api_delegate(System.IntPtr obj,  int first,  int count);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_load_range_set_api_delegate> efl_ui_list_view_model_load_range_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_load_range_set_api_delegate>(Module, "efl_ui_list_view_model_load_range_set");

        private static void load_range_set(System.IntPtr obj, System.IntPtr pd, int first, int count)
        {
            Eina.Log.Debug("function efl_ui_list_view_model_load_range_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ListView)ws.Target).SetLoadRange(first, count);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_list_view_model_load_range_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), first, count);
            }
        }

        private static efl_ui_list_view_model_load_range_set_delegate efl_ui_list_view_model_load_range_set_static_delegate;

        
        private delegate int efl_ui_list_view_model_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_list_view_model_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_size_get_api_delegate> efl_ui_list_view_model_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_size_get_api_delegate>(Module, "efl_ui_list_view_model_size_get");

        private static int model_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_list_view_model_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetModelSize();
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
                return efl_ui_list_view_model_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_list_view_model_size_get_delegate efl_ui_list_view_model_size_get_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_ui_list_view_model_min_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_ui_list_view_model_min_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_min_size_get_api_delegate> efl_ui_list_view_model_min_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_min_size_get_api_delegate>(Module, "efl_ui_list_view_model_min_size_get");

        private static Eina.Size2D.NativeStruct min_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_list_view_model_min_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetMinSize();
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
                return efl_ui_list_view_model_min_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_list_view_model_min_size_get_delegate efl_ui_list_view_model_min_size_get_static_delegate;

        
        private delegate void efl_ui_list_view_model_min_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct min);

        
        public delegate void efl_ui_list_view_model_min_size_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct min);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_min_size_set_api_delegate> efl_ui_list_view_model_min_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_min_size_set_api_delegate>(Module, "efl_ui_list_view_model_min_size_set");

        private static void min_size_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct min)
        {
            Eina.Log.Debug("function efl_ui_list_view_model_min_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_min = min;
                            
                try
                {
                    ((ListView)ws.Target).SetMinSize(_in_min);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_list_view_model_min_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), min);
            }
        }

        private static efl_ui_list_view_model_min_size_set_delegate efl_ui_list_view_model_min_size_set_static_delegate;

        
        private delegate System.IntPtr efl_ui_list_view_model_realize_delegate(System.IntPtr obj, System.IntPtr pd,  ref Efl.Ui.ListViewLayoutItem.NativeStruct item);

        
        public delegate System.IntPtr efl_ui_list_view_model_realize_api_delegate(System.IntPtr obj,  ref Efl.Ui.ListViewLayoutItem.NativeStruct item);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_realize_api_delegate> efl_ui_list_view_model_realize_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_realize_api_delegate>(Module, "efl_ui_list_view_model_realize");

        private static System.IntPtr realize(System.IntPtr obj, System.IntPtr pd, ref Efl.Ui.ListViewLayoutItem.NativeStruct item)
        {
            Eina.Log.Debug("function efl_ui_list_view_model_realize was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Ui.ListViewLayoutItem _in_item = item;
                            Efl.Ui.ListViewLayoutItem _ret_var = default(Efl.Ui.ListViewLayoutItem);
                try
                {
                    _ret_var = ((ListView)ws.Target).Realize(ref _in_item);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                item = _in_item;
        return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);

            }
            else
            {
                return efl_ui_list_view_model_realize_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref item);
            }
        }

        private static efl_ui_list_view_model_realize_delegate efl_ui_list_view_model_realize_static_delegate;

        
        private delegate void efl_ui_list_view_model_unrealize_delegate(System.IntPtr obj, System.IntPtr pd,  ref Efl.Ui.ListViewLayoutItem.NativeStruct item);

        
        public delegate void efl_ui_list_view_model_unrealize_api_delegate(System.IntPtr obj,  ref Efl.Ui.ListViewLayoutItem.NativeStruct item);

        public static Efl.Eo.FunctionWrapper<efl_ui_list_view_model_unrealize_api_delegate> efl_ui_list_view_model_unrealize_ptr = new Efl.Eo.FunctionWrapper<efl_ui_list_view_model_unrealize_api_delegate>(Module, "efl_ui_list_view_model_unrealize");

        private static void unrealize(System.IntPtr obj, System.IntPtr pd, ref Efl.Ui.ListViewLayoutItem.NativeStruct item)
        {
            Eina.Log.Debug("function efl_ui_list_view_model_unrealize was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Ui.ListViewLayoutItem _in_item = item;
                            
                try
                {
                    ((ListView)ws.Target).Unrealize(ref _in_item);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                item = _in_item;
        
            }
            else
            {
                efl_ui_list_view_model_unrealize_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref item);
            }
        }

        private static efl_ui_list_view_model_unrealize_delegate efl_ui_list_view_model_unrealize_static_delegate;

        
        private delegate Eina.Position2D.NativeStruct efl_ui_scrollable_content_pos_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Position2D.NativeStruct efl_ui_scrollable_content_pos_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_get_api_delegate> efl_ui_scrollable_content_pos_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_get_api_delegate>(Module, "efl_ui_scrollable_content_pos_get");

        private static Eina.Position2D.NativeStruct content_pos_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_content_pos_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Position2D _ret_var = default(Eina.Position2D);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetContentPos();
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
                return efl_ui_scrollable_content_pos_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_content_pos_get_delegate efl_ui_scrollable_content_pos_get_static_delegate;

        
        private delegate void efl_ui_scrollable_content_pos_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos);

        
        public delegate void efl_ui_scrollable_content_pos_set_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct pos);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_set_api_delegate> efl_ui_scrollable_content_pos_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_set_api_delegate>(Module, "efl_ui_scrollable_content_pos_set");

        private static void content_pos_set(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct pos)
        {
            Eina.Log.Debug("function efl_ui_scrollable_content_pos_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Position2D _in_pos = pos;
                            
                try
                {
                    ((ListView)ws.Target).SetContentPos(_in_pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_scrollable_content_pos_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_ui_scrollable_content_pos_set_delegate efl_ui_scrollable_content_pos_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_ui_scrollable_content_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_ui_scrollable_content_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_size_get_api_delegate> efl_ui_scrollable_content_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_size_get_api_delegate>(Module, "efl_ui_scrollable_content_size_get");

        private static Eina.Size2D.NativeStruct content_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_content_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetContentSize();
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
                return efl_ui_scrollable_content_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_content_size_get_delegate efl_ui_scrollable_content_size_get_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_ui_scrollable_viewport_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_ui_scrollable_viewport_geometry_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_viewport_geometry_get_api_delegate> efl_ui_scrollable_viewport_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_viewport_geometry_get_api_delegate>(Module, "efl_ui_scrollable_viewport_geometry_get");

        private static Eina.Rect.NativeStruct viewport_geometry_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_viewport_geometry_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetViewportGeometry();
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
                return efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_viewport_geometry_get_delegate efl_ui_scrollable_viewport_geometry_get_static_delegate;

        
        private delegate void efl_ui_scrollable_bounce_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool horiz, [MarshalAs(UnmanagedType.U1)] out bool vert);

        
        public delegate void efl_ui_scrollable_bounce_enabled_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool horiz, [MarshalAs(UnmanagedType.U1)] out bool vert);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_get_api_delegate> efl_ui_scrollable_bounce_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_get_api_delegate>(Module, "efl_ui_scrollable_bounce_enabled_get");

        private static void bounce_enabled_get(System.IntPtr obj, System.IntPtr pd, out bool horiz, out bool vert)
        {
            Eina.Log.Debug("function efl_ui_scrollable_bounce_enabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        horiz = default(bool);        vert = default(bool);                            
                try
                {
                    ((ListView)ws.Target).GetBounceEnabled(out horiz, out vert);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out horiz, out vert);
            }
        }

        private static efl_ui_scrollable_bounce_enabled_get_delegate efl_ui_scrollable_bounce_enabled_get_static_delegate;

        
        private delegate void efl_ui_scrollable_bounce_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool horiz, [MarshalAs(UnmanagedType.U1)] bool vert);

        
        public delegate void efl_ui_scrollable_bounce_enabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool horiz, [MarshalAs(UnmanagedType.U1)] bool vert);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_set_api_delegate> efl_ui_scrollable_bounce_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_set_api_delegate>(Module, "efl_ui_scrollable_bounce_enabled_set");

        private static void bounce_enabled_set(System.IntPtr obj, System.IntPtr pd, bool horiz, bool vert)
        {
            Eina.Log.Debug("function efl_ui_scrollable_bounce_enabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ListView)ws.Target).SetBounceEnabled(horiz, vert);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), horiz, vert);
            }
        }

        private static efl_ui_scrollable_bounce_enabled_set_delegate efl_ui_scrollable_bounce_enabled_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_scrollable_scroll_freeze_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_scrollable_scroll_freeze_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_get_api_delegate> efl_ui_scrollable_scroll_freeze_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_get_api_delegate>(Module, "efl_ui_scrollable_scroll_freeze_get");

        private static bool scroll_freeze_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_scroll_freeze_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetScrollFreeze();
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
                return efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_scroll_freeze_get_delegate efl_ui_scrollable_scroll_freeze_get_static_delegate;

        
        private delegate void efl_ui_scrollable_scroll_freeze_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool freeze);

        
        public delegate void efl_ui_scrollable_scroll_freeze_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool freeze);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_set_api_delegate> efl_ui_scrollable_scroll_freeze_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_set_api_delegate>(Module, "efl_ui_scrollable_scroll_freeze_set");

        private static void scroll_freeze_set(System.IntPtr obj, System.IntPtr pd, bool freeze)
        {
            Eina.Log.Debug("function efl_ui_scrollable_scroll_freeze_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ListView)ws.Target).SetScrollFreeze(freeze);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), freeze);
            }
        }

        private static efl_ui_scrollable_scroll_freeze_set_delegate efl_ui_scrollable_scroll_freeze_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_scrollable_scroll_hold_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_scrollable_scroll_hold_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_get_api_delegate> efl_ui_scrollable_scroll_hold_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_get_api_delegate>(Module, "efl_ui_scrollable_scroll_hold_get");

        private static bool scroll_hold_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_scroll_hold_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetScrollHold();
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
                return efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_scroll_hold_get_delegate efl_ui_scrollable_scroll_hold_get_static_delegate;

        
        private delegate void efl_ui_scrollable_scroll_hold_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool hold);

        
        public delegate void efl_ui_scrollable_scroll_hold_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool hold);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_set_api_delegate> efl_ui_scrollable_scroll_hold_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_set_api_delegate>(Module, "efl_ui_scrollable_scroll_hold_set");

        private static void scroll_hold_set(System.IntPtr obj, System.IntPtr pd, bool hold)
        {
            Eina.Log.Debug("function efl_ui_scrollable_scroll_hold_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ListView)ws.Target).SetScrollHold(hold);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), hold);
            }
        }

        private static efl_ui_scrollable_scroll_hold_set_delegate efl_ui_scrollable_scroll_hold_set_static_delegate;

        
        private delegate void efl_ui_scrollable_looping_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool loop_h, [MarshalAs(UnmanagedType.U1)] out bool loop_v);

        
        public delegate void efl_ui_scrollable_looping_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool loop_h, [MarshalAs(UnmanagedType.U1)] out bool loop_v);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_get_api_delegate> efl_ui_scrollable_looping_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_get_api_delegate>(Module, "efl_ui_scrollable_looping_get");

        private static void looping_get(System.IntPtr obj, System.IntPtr pd, out bool loop_h, out bool loop_v)
        {
            Eina.Log.Debug("function efl_ui_scrollable_looping_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        loop_h = default(bool);        loop_v = default(bool);                            
                try
                {
                    ((ListView)ws.Target).GetLooping(out loop_h, out loop_v);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_looping_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out loop_h, out loop_v);
            }
        }

        private static efl_ui_scrollable_looping_get_delegate efl_ui_scrollable_looping_get_static_delegate;

        
        private delegate void efl_ui_scrollable_looping_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool loop_h, [MarshalAs(UnmanagedType.U1)] bool loop_v);

        
        public delegate void efl_ui_scrollable_looping_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool loop_h, [MarshalAs(UnmanagedType.U1)] bool loop_v);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_set_api_delegate> efl_ui_scrollable_looping_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_set_api_delegate>(Module, "efl_ui_scrollable_looping_set");

        private static void looping_set(System.IntPtr obj, System.IntPtr pd, bool loop_h, bool loop_v)
        {
            Eina.Log.Debug("function efl_ui_scrollable_looping_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ListView)ws.Target).SetLooping(loop_h, loop_v);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_looping_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), loop_h, loop_v);
            }
        }

        private static efl_ui_scrollable_looping_set_delegate efl_ui_scrollable_looping_set_static_delegate;

        
        private delegate Efl.Ui.ScrollBlock efl_ui_scrollable_movement_block_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.ScrollBlock efl_ui_scrollable_movement_block_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_get_api_delegate> efl_ui_scrollable_movement_block_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_get_api_delegate>(Module, "efl_ui_scrollable_movement_block_get");

        private static Efl.Ui.ScrollBlock movement_block_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_movement_block_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.ScrollBlock _ret_var = default(Efl.Ui.ScrollBlock);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetMovementBlock();
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
                return efl_ui_scrollable_movement_block_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_movement_block_get_delegate efl_ui_scrollable_movement_block_get_static_delegate;

        
        private delegate void efl_ui_scrollable_movement_block_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ScrollBlock block);

        
        public delegate void efl_ui_scrollable_movement_block_set_api_delegate(System.IntPtr obj,  Efl.Ui.ScrollBlock block);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_set_api_delegate> efl_ui_scrollable_movement_block_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_set_api_delegate>(Module, "efl_ui_scrollable_movement_block_set");

        private static void movement_block_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ScrollBlock block)
        {
            Eina.Log.Debug("function efl_ui_scrollable_movement_block_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ListView)ws.Target).SetMovementBlock(block);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_scrollable_movement_block_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), block);
            }
        }

        private static efl_ui_scrollable_movement_block_set_delegate efl_ui_scrollable_movement_block_set_static_delegate;

        
        private delegate void efl_ui_scrollable_gravity_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y);

        
        public delegate void efl_ui_scrollable_gravity_get_api_delegate(System.IntPtr obj,  out double x,  out double y);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_get_api_delegate> efl_ui_scrollable_gravity_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_get_api_delegate>(Module, "efl_ui_scrollable_gravity_get");

        private static void gravity_get(System.IntPtr obj, System.IntPtr pd, out double x, out double y)
        {
            Eina.Log.Debug("function efl_ui_scrollable_gravity_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(double);        y = default(double);                            
                try
                {
                    ((ListView)ws.Target).GetGravity(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_gravity_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_ui_scrollable_gravity_get_delegate efl_ui_scrollable_gravity_get_static_delegate;

        
        private delegate void efl_ui_scrollable_gravity_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_ui_scrollable_gravity_set_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_set_api_delegate> efl_ui_scrollable_gravity_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_set_api_delegate>(Module, "efl_ui_scrollable_gravity_set");

        private static void gravity_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_ui_scrollable_gravity_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ListView)ws.Target).SetGravity(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_gravity_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_ui_scrollable_gravity_set_delegate efl_ui_scrollable_gravity_set_static_delegate;

        
        private delegate void efl_ui_scrollable_match_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool w, [MarshalAs(UnmanagedType.U1)] bool h);

        
        public delegate void efl_ui_scrollable_match_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool w, [MarshalAs(UnmanagedType.U1)] bool h);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_match_content_set_api_delegate> efl_ui_scrollable_match_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_match_content_set_api_delegate>(Module, "efl_ui_scrollable_match_content_set");

        private static void match_content_set(System.IntPtr obj, System.IntPtr pd, bool w, bool h)
        {
            Eina.Log.Debug("function efl_ui_scrollable_match_content_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ListView)ws.Target).SetMatchContent(w, h);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_match_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), w, h);
            }
        }

        private static efl_ui_scrollable_match_content_set_delegate efl_ui_scrollable_match_content_set_static_delegate;

        
        private delegate Eina.Position2D.NativeStruct efl_ui_scrollable_step_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Position2D.NativeStruct efl_ui_scrollable_step_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_get_api_delegate> efl_ui_scrollable_step_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_get_api_delegate>(Module, "efl_ui_scrollable_step_size_get");

        private static Eina.Position2D.NativeStruct step_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_scrollable_step_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Position2D _ret_var = default(Eina.Position2D);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetStepSize();
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
                return efl_ui_scrollable_step_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_scrollable_step_size_get_delegate efl_ui_scrollable_step_size_get_static_delegate;

        
        private delegate void efl_ui_scrollable_step_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct step);

        
        public delegate void efl_ui_scrollable_step_size_set_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct step);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_set_api_delegate> efl_ui_scrollable_step_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_set_api_delegate>(Module, "efl_ui_scrollable_step_size_set");

        private static void step_size_set(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct step)
        {
            Eina.Log.Debug("function efl_ui_scrollable_step_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Position2D _in_step = step;
                            
                try
                {
                    ((ListView)ws.Target).SetStepSize(_in_step);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_scrollable_step_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), step);
            }
        }

        private static efl_ui_scrollable_step_size_set_delegate efl_ui_scrollable_step_size_set_static_delegate;

        
        private delegate void efl_ui_scrollable_scroll_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct rect, [MarshalAs(UnmanagedType.U1)] bool animation);

        
        public delegate void efl_ui_scrollable_scroll_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct rect, [MarshalAs(UnmanagedType.U1)] bool animation);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_api_delegate> efl_ui_scrollable_scroll_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_api_delegate>(Module, "efl_ui_scrollable_scroll");

        private static void scroll(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct rect, bool animation)
        {
            Eina.Log.Debug("function efl_ui_scrollable_scroll was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Rect _in_rect = rect;
                                                    
                try
                {
                    ((ListView)ws.Target).Scroll(_in_rect, animation);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollable_scroll_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), rect, animation);
            }
        }

        private static efl_ui_scrollable_scroll_delegate efl_ui_scrollable_scroll_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_mode_get_delegate(System.IntPtr obj, System.IntPtr pd,  out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar);

        
        public delegate void efl_ui_scrollbar_bar_mode_get_api_delegate(System.IntPtr obj,  out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate> efl_ui_scrollbar_bar_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate>(Module, "efl_ui_scrollbar_bar_mode_get");

        private static void bar_mode_get(System.IntPtr obj, System.IntPtr pd, out Efl.Ui.ScrollbarMode hbar, out Efl.Ui.ScrollbarMode vbar)
        {
            Eina.Log.Debug("function efl_ui_scrollbar_bar_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        hbar = default(Efl.Ui.ScrollbarMode);        vbar = default(Efl.Ui.ScrollbarMode);                            
                try
                {
                    ((ListView)ws.Target).GetBarMode(out hbar, out vbar);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out hbar, out vbar);
            }
        }

        private static efl_ui_scrollbar_bar_mode_get_delegate efl_ui_scrollbar_bar_mode_get_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar);

        
        public delegate void efl_ui_scrollbar_bar_mode_set_api_delegate(System.IntPtr obj,  Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate> efl_ui_scrollbar_bar_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate>(Module, "efl_ui_scrollbar_bar_mode_set");

        private static void bar_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ScrollbarMode hbar, Efl.Ui.ScrollbarMode vbar)
        {
            Eina.Log.Debug("function efl_ui_scrollbar_bar_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ListView)ws.Target).SetBarMode(hbar, vbar);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), hbar, vbar);
            }
        }

        private static efl_ui_scrollbar_bar_mode_set_delegate efl_ui_scrollbar_bar_mode_set_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_size_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double width,  out double height);

        
        public delegate void efl_ui_scrollbar_bar_size_get_api_delegate(System.IntPtr obj,  out double width,  out double height);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate> efl_ui_scrollbar_bar_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate>(Module, "efl_ui_scrollbar_bar_size_get");

        private static void bar_size_get(System.IntPtr obj, System.IntPtr pd, out double width, out double height)
        {
            Eina.Log.Debug("function efl_ui_scrollbar_bar_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        width = default(double);        height = default(double);                            
                try
                {
                    ((ListView)ws.Target).GetBarSize(out width, out height);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out width, out height);
            }
        }

        private static efl_ui_scrollbar_bar_size_get_delegate efl_ui_scrollbar_bar_size_get_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_position_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double posx,  out double posy);

        
        public delegate void efl_ui_scrollbar_bar_position_get_api_delegate(System.IntPtr obj,  out double posx,  out double posy);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate> efl_ui_scrollbar_bar_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate>(Module, "efl_ui_scrollbar_bar_position_get");

        private static void bar_position_get(System.IntPtr obj, System.IntPtr pd, out double posx, out double posy)
        {
            Eina.Log.Debug("function efl_ui_scrollbar_bar_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        posx = default(double);        posy = default(double);                            
                try
                {
                    ((ListView)ws.Target).GetBarPosition(out posx, out posy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out posx, out posy);
            }
        }

        private static efl_ui_scrollbar_bar_position_get_delegate efl_ui_scrollbar_bar_position_get_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  double posx,  double posy);

        
        public delegate void efl_ui_scrollbar_bar_position_set_api_delegate(System.IntPtr obj,  double posx,  double posy);

        public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate> efl_ui_scrollbar_bar_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate>(Module, "efl_ui_scrollbar_bar_position_set");

        private static void bar_position_set(System.IntPtr obj, System.IntPtr pd, double posx, double posy)
        {
            Eina.Log.Debug("function efl_ui_scrollbar_bar_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ListView)ws.Target).SetBarPosition(posx, posy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), posx, posy);
            }
        }

        private static efl_ui_scrollbar_bar_position_set_delegate efl_ui_scrollbar_bar_position_set_static_delegate;

        
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

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Focus.IObject efl_ui_focus_manager_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Focus.IObject efl_ui_focus_manager_focus_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_focus_get_api_delegate> efl_ui_focus_manager_focus_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_focus_get_api_delegate>(Module, "efl_ui_focus_manager_focus_get");

        private static Efl.Ui.Focus.IObject manager_focus_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_focus_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.Focus.IObject _ret_var = default(Efl.Ui.Focus.IObject);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetManagerFocus();
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
                return efl_ui_focus_manager_focus_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_manager_focus_get_delegate efl_ui_focus_manager_focus_get_static_delegate;

        
        private delegate void efl_ui_focus_manager_focus_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject focus);

        
        public delegate void efl_ui_focus_manager_focus_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject focus);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_focus_set_api_delegate> efl_ui_focus_manager_focus_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_focus_set_api_delegate>(Module, "efl_ui_focus_manager_focus_set");

        private static void manager_focus_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.IObject focus)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_focus_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ListView)ws.Target).SetManagerFocus(focus);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_manager_focus_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), focus);
            }
        }

        private static efl_ui_focus_manager_focus_set_delegate efl_ui_focus_manager_focus_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Focus.IManager efl_ui_focus_manager_redirect_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Focus.IManager efl_ui_focus_manager_redirect_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_redirect_get_api_delegate> efl_ui_focus_manager_redirect_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_redirect_get_api_delegate>(Module, "efl_ui_focus_manager_redirect_get");

        private static Efl.Ui.Focus.IManager redirect_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_redirect_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.Focus.IManager _ret_var = default(Efl.Ui.Focus.IManager);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetRedirect();
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
                return efl_ui_focus_manager_redirect_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_manager_redirect_get_delegate efl_ui_focus_manager_redirect_get_static_delegate;

        
        private delegate void efl_ui_focus_manager_redirect_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IManager redirect);

        
        public delegate void efl_ui_focus_manager_redirect_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IManager redirect);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_redirect_set_api_delegate> efl_ui_focus_manager_redirect_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_redirect_set_api_delegate>(Module, "efl_ui_focus_manager_redirect_set");

        private static void redirect_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.IManager redirect)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_redirect_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((ListView)ws.Target).SetRedirect(redirect);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_manager_redirect_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), redirect);
            }
        }

        private static efl_ui_focus_manager_redirect_set_delegate efl_ui_focus_manager_redirect_set_static_delegate;

        
        private delegate System.IntPtr efl_ui_focus_manager_border_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_focus_manager_border_elements_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_border_elements_get_api_delegate> efl_ui_focus_manager_border_elements_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_border_elements_get_api_delegate>(Module, "efl_ui_focus_manager_border_elements_get");

        private static System.IntPtr border_elements_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_border_elements_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Iterator<Efl.Ui.Focus.IObject> _ret_var = default(Eina.Iterator<Efl.Ui.Focus.IObject>);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetBorderElements();
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
                return efl_ui_focus_manager_border_elements_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_manager_border_elements_get_delegate efl_ui_focus_manager_border_elements_get_static_delegate;

        
        private delegate System.IntPtr efl_ui_focus_manager_viewport_elements_get_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct viewport);

        
        public delegate System.IntPtr efl_ui_focus_manager_viewport_elements_get_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct viewport);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_viewport_elements_get_api_delegate> efl_ui_focus_manager_viewport_elements_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_viewport_elements_get_api_delegate>(Module, "efl_ui_focus_manager_viewport_elements_get");

        private static System.IntPtr viewport_elements_get(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct viewport)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_viewport_elements_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Rect _in_viewport = viewport;
                            Eina.Iterator<Efl.Ui.Focus.IObject> _ret_var = default(Eina.Iterator<Efl.Ui.Focus.IObject>);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetViewportElements(_in_viewport);
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
                return efl_ui_focus_manager_viewport_elements_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), viewport);
            }
        }

        private static efl_ui_focus_manager_viewport_elements_get_delegate efl_ui_focus_manager_viewport_elements_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Focus.IObject efl_ui_focus_manager_root_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Focus.IObject efl_ui_focus_manager_root_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_root_get_api_delegate> efl_ui_focus_manager_root_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_root_get_api_delegate>(Module, "efl_ui_focus_manager_root_get");

        private static Efl.Ui.Focus.IObject root_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_root_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.Focus.IObject _ret_var = default(Efl.Ui.Focus.IObject);
                try
                {
                    _ret_var = ((ListView)ws.Target).GetRoot();
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
                return efl_ui_focus_manager_root_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_manager_root_get_delegate efl_ui_focus_manager_root_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_focus_manager_root_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject root);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_focus_manager_root_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject root);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_root_set_api_delegate> efl_ui_focus_manager_root_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_root_set_api_delegate>(Module, "efl_ui_focus_manager_root_set");

        private static bool root_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.IObject root)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_root_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((ListView)ws.Target).SetRoot(root);
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
                return efl_ui_focus_manager_root_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), root);
            }
        }

        private static efl_ui_focus_manager_root_set_delegate efl_ui_focus_manager_root_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Focus.IObject efl_ui_focus_manager_move_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction direction);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Focus.IObject efl_ui_focus_manager_move_api_delegate(System.IntPtr obj,  Efl.Ui.Focus.Direction direction);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_move_api_delegate> efl_ui_focus_manager_move_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_move_api_delegate>(Module, "efl_ui_focus_manager_move");

        private static Efl.Ui.Focus.IObject move(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.Direction direction)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_move was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Ui.Focus.IObject _ret_var = default(Efl.Ui.Focus.IObject);
                try
                {
                    _ret_var = ((ListView)ws.Target).Move(direction);
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
                return efl_ui_focus_manager_move_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), direction);
            }
        }

        private static efl_ui_focus_manager_move_delegate efl_ui_focus_manager_move_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Focus.IObject efl_ui_focus_manager_request_move_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject child, [MarshalAs(UnmanagedType.U1)] bool logical);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Focus.IObject efl_ui_focus_manager_request_move_api_delegate(System.IntPtr obj,  Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject child, [MarshalAs(UnmanagedType.U1)] bool logical);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_request_move_api_delegate> efl_ui_focus_manager_request_move_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_request_move_api_delegate>(Module, "efl_ui_focus_manager_request_move");

        private static Efl.Ui.Focus.IObject request_move(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject child, bool logical)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_request_move was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    Efl.Ui.Focus.IObject _ret_var = default(Efl.Ui.Focus.IObject);
                try
                {
                    _ret_var = ((ListView)ws.Target).MoveRequest(direction, child, logical);
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
                return efl_ui_focus_manager_request_move_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), direction, child, logical);
            }
        }

        private static efl_ui_focus_manager_request_move_delegate efl_ui_focus_manager_request_move_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Focus.IObject efl_ui_focus_manager_request_subchild_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject root);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Focus.IObject efl_ui_focus_manager_request_subchild_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject root);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_request_subchild_api_delegate> efl_ui_focus_manager_request_subchild_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_request_subchild_api_delegate>(Module, "efl_ui_focus_manager_request_subchild");

        private static Efl.Ui.Focus.IObject request_subchild(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.IObject root)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_request_subchild was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Ui.Focus.IObject _ret_var = default(Efl.Ui.Focus.IObject);
                try
                {
                    _ret_var = ((ListView)ws.Target).RequestSubchild(root);
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
                return efl_ui_focus_manager_request_subchild_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), root);
            }
        }

        private static efl_ui_focus_manager_request_subchild_delegate efl_ui_focus_manager_request_subchild_static_delegate;

        
        private delegate System.IntPtr efl_ui_focus_manager_fetch_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject child);

        
        public delegate System.IntPtr efl_ui_focus_manager_fetch_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject child);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_fetch_api_delegate> efl_ui_focus_manager_fetch_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_fetch_api_delegate>(Module, "efl_ui_focus_manager_fetch");

        private static System.IntPtr fetch(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.IObject child)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_fetch was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Ui.Focus.Relations _ret_var = default(Efl.Ui.Focus.Relations);
                try
                {
                    _ret_var = ((ListView)ws.Target).Fetch(child);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        return Eina.PrimitiveConversion.ManagedToPointerAlloc(_ret_var);

            }
            else
            {
                return efl_ui_focus_manager_fetch_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child);
            }
        }

        private static efl_ui_focus_manager_fetch_delegate efl_ui_focus_manager_fetch_static_delegate;

        
        private delegate Efl.Ui.Focus.ManagerLogicalEndDetail.NativeStruct efl_ui_focus_manager_logical_end_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.Focus.ManagerLogicalEndDetail.NativeStruct efl_ui_focus_manager_logical_end_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_logical_end_api_delegate> efl_ui_focus_manager_logical_end_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_logical_end_api_delegate>(Module, "efl_ui_focus_manager_logical_end");

        private static Efl.Ui.Focus.ManagerLogicalEndDetail.NativeStruct logical_end(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_logical_end was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.Focus.ManagerLogicalEndDetail _ret_var = default(Efl.Ui.Focus.ManagerLogicalEndDetail);
                try
                {
                    _ret_var = ((ListView)ws.Target).LogicalEnd();
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
                return efl_ui_focus_manager_logical_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_manager_logical_end_delegate efl_ui_focus_manager_logical_end_static_delegate;

        
        private delegate void efl_ui_focus_manager_reset_history_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_manager_reset_history_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_reset_history_api_delegate> efl_ui_focus_manager_reset_history_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_reset_history_api_delegate>(Module, "efl_ui_focus_manager_reset_history");

        private static void reset_history(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_reset_history was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((ListView)ws.Target).ResetHistory();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_focus_manager_reset_history_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_manager_reset_history_delegate efl_ui_focus_manager_reset_history_static_delegate;

        
        private delegate void efl_ui_focus_manager_pop_history_stack_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_manager_pop_history_stack_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_pop_history_stack_api_delegate> efl_ui_focus_manager_pop_history_stack_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_pop_history_stack_api_delegate>(Module, "efl_ui_focus_manager_pop_history_stack");

        private static void pop_history_stack(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_pop_history_stack was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((ListView)ws.Target).PopHistoryStack();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_focus_manager_pop_history_stack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_manager_pop_history_stack_delegate efl_ui_focus_manager_pop_history_stack_static_delegate;

        
        private delegate void efl_ui_focus_manager_setup_on_first_touch_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject entry);

        
        public delegate void efl_ui_focus_manager_setup_on_first_touch_api_delegate(System.IntPtr obj,  Efl.Ui.Focus.Direction direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject entry);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_setup_on_first_touch_api_delegate> efl_ui_focus_manager_setup_on_first_touch_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_setup_on_first_touch_api_delegate>(Module, "efl_ui_focus_manager_setup_on_first_touch");

        private static void setup_on_first_touch(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject entry)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_setup_on_first_touch was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((ListView)ws.Target).SetupOnFirstTouch(direction, entry);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_focus_manager_setup_on_first_touch_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), direction, entry);
            }
        }

        private static efl_ui_focus_manager_setup_on_first_touch_delegate efl_ui_focus_manager_setup_on_first_touch_static_delegate;

        
        private delegate void efl_ui_focus_manager_dirty_logic_freeze_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_manager_dirty_logic_freeze_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_dirty_logic_freeze_api_delegate> efl_ui_focus_manager_dirty_logic_freeze_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_dirty_logic_freeze_api_delegate>(Module, "efl_ui_focus_manager_dirty_logic_freeze");

        private static void dirty_logic_freeze(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_dirty_logic_freeze was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((ListView)ws.Target).FreezeDirtyLogic();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_focus_manager_dirty_logic_freeze_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_manager_dirty_logic_freeze_delegate efl_ui_focus_manager_dirty_logic_freeze_static_delegate;

        
        private delegate void efl_ui_focus_manager_dirty_logic_unfreeze_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_manager_dirty_logic_unfreeze_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_manager_dirty_logic_unfreeze_api_delegate> efl_ui_focus_manager_dirty_logic_unfreeze_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_manager_dirty_logic_unfreeze_api_delegate>(Module, "efl_ui_focus_manager_dirty_logic_unfreeze");

        private static void dirty_logic_unfreeze(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_manager_dirty_logic_unfreeze was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((ListView)ws.Target).DirtyLogicUnfreeze();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_focus_manager_dirty_logic_unfreeze_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_manager_dirty_logic_unfreeze_delegate efl_ui_focus_manager_dirty_logic_unfreeze_static_delegate;

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

    
    public static Efl.BindableProperty<Efl.Ui.ScrollBlock> MovementBlock<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.ListView, T>magic = null) where T : Efl.Ui.ListView {
        return new Efl.BindableProperty<Efl.Ui.ScrollBlock>("movement_block", fac);
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
    /// <param name="Layout">TBD</param>;
    /// <param name="Child">TBD</param>;
    /// <param name="Index">TBD</param>;
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

            _external_struct.Child = (Efl.IModelConcrete) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Child);
            _external_struct.Index = _internal_struct.Index;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

