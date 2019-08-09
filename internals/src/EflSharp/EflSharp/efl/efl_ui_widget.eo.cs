#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <param name="obj">Canvas object</param>
/// <param name="region">Showed region</param>
[Efl.Eo.BindingEntity]
public delegate void ScrollableOnShowRegion(Efl.Canvas.Object obj, Eina.Rect region);
public delegate void ScrollableOnShowRegionInternal(IntPtr data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object obj,  Eina.Rect.NativeStruct region);
internal class ScrollableOnShowRegionWrapper : IDisposable
{

    private ScrollableOnShowRegionInternal _cb;
    private IntPtr _cb_data;
    private EinaFreeCb _cb_free_cb;

    internal ScrollableOnShowRegionWrapper (ScrollableOnShowRegionInternal _cb, IntPtr _cb_data, EinaFreeCb _cb_free_cb)
    {
        this._cb = _cb;
        this._cb_data = _cb_data;
        this._cb_free_cb = _cb_free_cb;
    }

    ~ScrollableOnShowRegionWrapper()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this._cb_free_cb != null)
        {
            if (disposing)
            {
                this._cb_free_cb(this._cb_data);
            }
            else
            {
                Efl.Eo.Globals.ThreadSafeFreeCbExec(this._cb_free_cb, this._cb_data);
            }
            this._cb_free_cb = null;
            this._cb_data = IntPtr.Zero;
            this._cb = null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    internal void ManagedCb(Efl.Canvas.Object obj,Eina.Rect region)
    {
                Eina.Rect.NativeStruct _in_region = region;
                                        _cb(_cb_data, obj, _in_region);
        Eina.Error.RaiseIfUnhandledException();
                                            }

        internal static void Cb(IntPtr cb_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object obj,  Eina.Rect.NativeStruct region)
    {
        GCHandle handle = GCHandle.FromIntPtr(cb_data);
        ScrollableOnShowRegion cb = (ScrollableOnShowRegion)handle.Target;
                Eina.Rect _in_region = region;
                                            
        try {
            cb(obj, _in_region);
        } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
                                            }
}
}

}

namespace Efl {

namespace Ui {

/// <summary>Efl UI widget abstract class
/// (Since EFL 1.22)</summary>
[Efl.Ui.Widget.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class Widget : Efl.Canvas.Group, Efl.IPart, Efl.Access.IAction, Efl.Access.IComponent, Efl.Access.IObject, Efl.Access.Widget.IAction, Efl.Ui.IDnd, Efl.Ui.IL10n, Efl.Ui.IPropertyBind, Efl.Ui.ISelection, Efl.Ui.IView, Efl.Ui.Focus.IObject
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Widget))
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
        efl_ui_widget_class_get();
    /// <summary>Initializes a new instance of the <see cref="Widget"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Widget(Efl.Object parent
            , System.String style = null) : base(efl_ui_widget_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Widget(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Widget"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Widget(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class WidgetRealized : Widget
    {
        private WidgetRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Widget"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Widget(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    public event EventHandler AtspiHighlightedEvt
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

                string key = "_EFL_UI_WIDGET_EVENT_ATSPI_HIGHLIGHTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIDGET_EVENT_ATSPI_HIGHLIGHTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AtspiHighlightedEvt.</summary>
    public void OnAtspiHighlightedEvt(EventArgs e)
    {
        var key = "_EFL_UI_WIDGET_EVENT_ATSPI_HIGHLIGHTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    public event EventHandler AtspiUnhighlightedEvt
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

                string key = "_EFL_UI_WIDGET_EVENT_ATSPI_UNHIGHLIGHTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIDGET_EVENT_ATSPI_UNHIGHLIGHTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AtspiUnhighlightedEvt.</summary>
    public void OnAtspiUnhighlightedEvt(EventArgs e)
    {
        var key = "_EFL_UI_WIDGET_EVENT_ATSPI_UNHIGHLIGHTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when widget language changed
    /// (Since EFL 1.22)</summary>
    public event EventHandler LanguageChangedEvt
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

                string key = "_EFL_UI_WIDGET_EVENT_LANGUAGE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIDGET_EVENT_LANGUAGE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event LanguageChangedEvt.</summary>
    public void OnLanguageChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_WIDGET_EVENT_LANGUAGE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when accessibility changed
    /// (Since EFL 1.22)</summary>
    public event EventHandler AccessChangedEvt
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

                string key = "_EFL_UI_WIDGET_EVENT_ACCESS_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_WIDGET_EVENT_ACCESS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AccessChangedEvt.</summary>
    public void OnAccessChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_WIDGET_EVENT_ACCESS_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when property has changed</summary>
    public event EventHandler<Efl.Access.IObjectPropertyChangedEvt_Args> PropertyChangedEvt
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
                        Efl.Access.IObjectPropertyChangedEvt_Args args = new Efl.Access.IObjectPropertyChangedEvt_Args();
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

                string key = "_EFL_ACCESS_OBJECT_EVENT_PROPERTY_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_PROPERTY_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event PropertyChangedEvt.</summary>
    public void OnPropertyChangedEvt(Efl.Access.IObjectPropertyChangedEvt_Args e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_PROPERTY_CHANGED";
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
    /// <summary>Called when children have changed</summary>
    public event EventHandler<Efl.Access.IObjectChildrenChangedEvt_Args> ChildrenChangedEvt
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
                        Efl.Access.IObjectChildrenChangedEvt_Args args = new Efl.Access.IObjectChildrenChangedEvt_Args();
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

                string key = "_EFL_ACCESS_OBJECT_EVENT_CHILDREN_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_CHILDREN_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChildrenChangedEvt.</summary>
    public void OnChildrenChangedEvt(Efl.Access.IObjectChildrenChangedEvt_Args e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_CHILDREN_CHANGED";
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
    /// <summary>Called when state has changed</summary>
    public event EventHandler<Efl.Access.IObjectStateChangedEvt_Args> StateChangedEvt
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
                        Efl.Access.IObjectStateChangedEvt_Args args = new Efl.Access.IObjectStateChangedEvt_Args();
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

                string key = "_EFL_ACCESS_OBJECT_EVENT_STATE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_STATE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event StateChangedEvt.</summary>
    public void OnStateChangedEvt(Efl.Access.IObjectStateChangedEvt_Args e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_STATE_CHANGED";
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
    /// <summary>Called when boundaries have changed</summary>
    public event EventHandler<Efl.Access.IObjectBoundsChangedEvt_Args> BoundsChangedEvt
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
                        Efl.Access.IObjectBoundsChangedEvt_Args args = new Efl.Access.IObjectBoundsChangedEvt_Args();
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

                string key = "_EFL_ACCESS_OBJECT_EVENT_BOUNDS_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_BOUNDS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event BoundsChangedEvt.</summary>
    public void OnBoundsChangedEvt(Efl.Access.IObjectBoundsChangedEvt_Args e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_BOUNDS_CHANGED";
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
    /// <summary>Called when visibility has changed</summary>
    public event EventHandler VisibleDataChangedEvt
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

                string key = "_EFL_ACCESS_OBJECT_EVENT_VISIBLE_DATA_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_VISIBLE_DATA_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event VisibleDataChangedEvt.</summary>
    public void OnVisibleDataChangedEvt(EventArgs e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_VISIBLE_DATA_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when active state of descendant has changed</summary>
    public event EventHandler<Efl.Access.IObjectActiveDescendantChangedEvt_Args> ActiveDescendantChangedEvt
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
                        Efl.Access.IObjectActiveDescendantChangedEvt_Args args = new Efl.Access.IObjectActiveDescendantChangedEvt_Args();
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

                string key = "_EFL_ACCESS_OBJECT_EVENT_ACTIVE_DESCENDANT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_ACTIVE_DESCENDANT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ActiveDescendantChangedEvt.</summary>
    public void OnActiveDescendantChangedEvt(Efl.Access.IObjectActiveDescendantChangedEvt_Args e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_ACTIVE_DESCENDANT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when item is added</summary>
    public event EventHandler AddedEvt
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

                string key = "_EFL_ACCESS_OBJECT_EVENT_ADDED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_ADDED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event AddedEvt.</summary>
    public void OnAddedEvt(EventArgs e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_ADDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when item is removed</summary>
    public event EventHandler RemovedEvt
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

                string key = "_EFL_ACCESS_OBJECT_EVENT_REMOVED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event RemovedEvt.</summary>
    public void OnRemovedEvt(EventArgs e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    public event EventHandler MoveOutedEvt
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

                string key = "_EFL_ACCESS_OBJECT_EVENT_MOVE_OUTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_OBJECT_EVENT_MOVE_OUTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event MoveOutedEvt.</summary>
    public void OnMoveOutedEvt(EventArgs e)
    {
        var key = "_EFL_ACCESS_OBJECT_EVENT_MOVE_OUTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    public event EventHandler ReadingStateChangedEvt
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

                string key = "_EFL_ACCESS_WIDGET_ACTION_EVENT_READING_STATE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ACCESS_WIDGET_ACTION_EVENT_READING_STATE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ReadingStateChangedEvt.</summary>
    public void OnReadingStateChangedEvt(EventArgs e)
    {
        var key = "_EFL_ACCESS_WIDGET_ACTION_EVENT_READING_STATE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>accept drag data</summary>
    public event EventHandler<Efl.Ui.IDndDragAcceptEvt_Args> DragAcceptEvt
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
                        Efl.Ui.IDndDragAcceptEvt_Args args = new Efl.Ui.IDndDragAcceptEvt_Args();
                        args.arg = (bool)Marshal.PtrToStructure(evt.Info, typeof(bool));
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

                string key = "_EFL_UI_DND_EVENT_DRAG_ACCEPT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_DND_EVENT_DRAG_ACCEPT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragAcceptEvt.</summary>
    public void OnDragAcceptEvt(Efl.Ui.IDndDragAcceptEvt_Args e)
    {
        var key = "_EFL_UI_DND_EVENT_DRAG_ACCEPT";
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
    /// <summary>drag is done (mouse up)</summary>
    public event EventHandler DragDoneEvt
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

                string key = "_EFL_UI_DND_EVENT_DRAG_DONE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_DND_EVENT_DRAG_DONE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragDoneEvt.</summary>
    public void OnDragDoneEvt(EventArgs e)
    {
        var key = "_EFL_UI_DND_EVENT_DRAG_DONE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>called when the drag object enters this object</summary>
    public event EventHandler DragEnterEvt
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

                string key = "_EFL_UI_DND_EVENT_DRAG_ENTER";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_DND_EVENT_DRAG_ENTER";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragEnterEvt.</summary>
    public void OnDragEnterEvt(EventArgs e)
    {
        var key = "_EFL_UI_DND_EVENT_DRAG_ENTER";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>called when the drag object leaves this object</summary>
    public event EventHandler DragLeaveEvt
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

                string key = "_EFL_UI_DND_EVENT_DRAG_LEAVE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_DND_EVENT_DRAG_LEAVE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragLeaveEvt.</summary>
    public void OnDragLeaveEvt(EventArgs e)
    {
        var key = "_EFL_UI_DND_EVENT_DRAG_LEAVE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>called when the drag object changes drag position</summary>
    public event EventHandler<Efl.Ui.IDndDragPosEvt_Args> DragPosEvt
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
                        Efl.Ui.IDndDragPosEvt_Args args = new Efl.Ui.IDndDragPosEvt_Args();
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

                string key = "_EFL_UI_DND_EVENT_DRAG_POS";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_DND_EVENT_DRAG_POS";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragPosEvt.</summary>
    public void OnDragPosEvt(Efl.Ui.IDndDragPosEvt_Args e)
    {
        var key = "_EFL_UI_DND_EVENT_DRAG_POS";
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
    /// <summary>called when the drag object dropped on this object</summary>
    public event EventHandler<Efl.Ui.IDndDragDropEvt_Args> DragDropEvt
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
                        Efl.Ui.IDndDragDropEvt_Args args = new Efl.Ui.IDndDragDropEvt_Args();
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

                string key = "_EFL_UI_DND_EVENT_DRAG_DROP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_DND_EVENT_DRAG_DROP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event DragDropEvt.</summary>
    public void OnDragDropEvt(Efl.Ui.IDndDragDropEvt_Args e)
    {
        var key = "_EFL_UI_DND_EVENT_DRAG_DROP";
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
    /// <summary>Event dispatched when a property on the object has changed due to an user interaction on the object that a model could be interested in.</summary>
    public event EventHandler<Efl.Ui.IPropertyBindPropertiesChangedEvt_Args> PropertiesChangedEvt
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
                        Efl.Ui.IPropertyBindPropertiesChangedEvt_Args args = new Efl.Ui.IPropertyBindPropertiesChangedEvt_Args();
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

                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event PropertiesChangedEvt.</summary>
    public void OnPropertiesChangedEvt(Efl.Ui.IPropertyBindPropertiesChangedEvt_Args e)
    {
        var key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
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
    /// <summary>Event dispatched when a property on the object is bound to a model. This is useful to not overgenerate event.</summary>
    public event EventHandler<Efl.Ui.IPropertyBindPropertyBoundEvt_Args> PropertyBoundEvt
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
                        Efl.Ui.IPropertyBindPropertyBoundEvt_Args args = new Efl.Ui.IPropertyBindPropertyBoundEvt_Args();
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

                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event PropertyBoundEvt.</summary>
    public void OnPropertyBoundEvt(Efl.Ui.IPropertyBindPropertyBoundEvt_Args e)
    {
        var key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
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
    /// <summary>Called when display server&apos;s selection has changed</summary>
    public event EventHandler<Efl.Ui.ISelectionWmSelectionChangedEvt_Args> WmSelectionChangedEvt
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
                        Efl.Ui.ISelectionWmSelectionChangedEvt_Args args = new Efl.Ui.ISelectionWmSelectionChangedEvt_Args();
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

                string key = "_EFL_UI_SELECTION_EVENT_WM_SELECTION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SELECTION_EVENT_WM_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event WmSelectionChangedEvt.</summary>
    public void OnWmSelectionChangedEvt(Efl.Ui.ISelectionWmSelectionChangedEvt_Args e)
    {
        var key = "_EFL_UI_SELECTION_EVENT_WM_SELECTION_CHANGED";
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
    /// <summary>Emitted if the focus state has changed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Ui.Focus.IObjectFocusChangedEvt_Args> FocusChangedEvt
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
                        Efl.Ui.Focus.IObjectFocusChangedEvt_Args args = new Efl.Ui.Focus.IObjectFocusChangedEvt_Args();
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

                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event FocusChangedEvt.</summary>
    public void OnFocusChangedEvt(Efl.Ui.Focus.IObjectFocusChangedEvt_Args e)
    {
        var key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_CHANGED";
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
    /// <summary>Emitted when a new manager is the parent for this object.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Ui.Focus.IObjectFocusManagerChangedEvt_Args> FocusManagerChangedEvt
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
                        Efl.Ui.Focus.IObjectFocusManagerChangedEvt_Args args = new Efl.Ui.Focus.IObjectFocusManagerChangedEvt_Args();
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

                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_MANAGER_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_MANAGER_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event FocusManagerChangedEvt.</summary>
    public void OnFocusManagerChangedEvt(Efl.Ui.Focus.IObjectFocusManagerChangedEvt_Args e)
    {
        var key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_MANAGER_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Emitted when a new logical parent should be used.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Ui.Focus.IObjectFocusParentChangedEvt_Args> FocusParentChangedEvt
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
                        Efl.Ui.Focus.IObjectFocusParentChangedEvt_Args args = new Efl.Ui.Focus.IObjectFocusParentChangedEvt_Args();
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

                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_PARENT_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_PARENT_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event FocusParentChangedEvt.</summary>
    public void OnFocusParentChangedEvt(Efl.Ui.Focus.IObjectFocusParentChangedEvt_Args e)
    {
        var key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_PARENT_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Emitted if child_focus has changed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Ui.Focus.IObjectChildFocusChangedEvt_Args> ChildFocusChangedEvt
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
                        Efl.Ui.Focus.IObjectChildFocusChangedEvt_Args args = new Efl.Ui.Focus.IObjectChildFocusChangedEvt_Args();
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

                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_CHILD_FOCUS_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_CHILD_FOCUS_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event ChildFocusChangedEvt.</summary>
    public void OnChildFocusChangedEvt(Efl.Ui.Focus.IObjectChildFocusChangedEvt_Args e)
    {
        var key = "_EFL_UI_FOCUS_OBJECT_EVENT_CHILD_FOCUS_CHANGED";
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
    /// <summary>Emitted if focus geometry of this object has changed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Ui.Focus.IObjectFocusGeometryChangedEvt_Args> FocusGeometryChangedEvt
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
                        Efl.Ui.Focus.IObjectFocusGeometryChangedEvt_Args args = new Efl.Ui.Focus.IObjectFocusGeometryChangedEvt_Args();
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

                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_GEOMETRY_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_GEOMETRY_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event FocusGeometryChangedEvt.</summary>
    public void OnFocusGeometryChangedEvt(Efl.Ui.Focus.IObjectFocusGeometryChangedEvt_Args e)
    {
        var key = "_EFL_UI_FOCUS_OBJECT_EVENT_FOCUS_GEOMETRY_CHANGED";
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
    public Efl.Ui.WidgetPartBg BackgroundPart
    {
        get
        {
            return GetPart("background") as Efl.Ui.WidgetPartBg;
        }
    }
    public Efl.Ui.WidgetPartShadow ShadowPart
    {
        get
        {
            return GetPart("shadow") as Efl.Ui.WidgetPartShadow;
        }
    }
    /// <summary>Returns the current cursor name.
    /// (Since EFL 1.22)</summary>
    /// <returns>The cursor name, defined either by the display system or the theme.</returns>
    virtual public System.String GetCursor() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_cursor_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets or unsets the current cursor.
    /// If <c>cursor</c> is <c>null</c> this function will reset the cursor to the default one.
    /// (Since EFL 1.22)</summary>
    /// <param name="cursor">The cursor name, defined either by the display system or the theme.</param>
    /// <returns><c>true</c> if successful.</returns>
    virtual public bool SetCursor(System.String cursor) {
                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_cursor_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cursor);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns the current cursor style name.
    /// (Since EFL 1.22)</summary>
    /// <returns>A specific style to use, eg. default, transparent, ....</returns>
    virtual public System.String GetCursorStyle() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_cursor_style_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets a style for the current cursor. Call after <see cref="Efl.Ui.Widget.SetCursor"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="style">A specific style to use, eg. default, transparent, ....</param>
    /// <returns><c>true</c> if successful.</returns>
    virtual public bool SetCursorStyle(System.String style) {
                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_cursor_style_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),style);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns the current state of theme cursors search.
    /// (Since EFL 1.22)</summary>
    /// <returns>Whether to use theme cursors.</returns>
    virtual public bool GetCursorThemeSearchEnabled() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_cursor_theme_search_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enables or disables theme cursors.
    /// (Since EFL 1.22)</summary>
    /// <param name="allow">Whether to use theme cursors.</param>
    /// <returns><c>true</c> if successful.</returns>
    virtual public bool SetCursorThemeSearchEnabled(bool allow) {
                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_cursor_theme_search_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),allow);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Sets the new resize object for this widget.
    /// (Since EFL 1.22)</summary>
    /// <param name="sobj">A canvas object (often a <see cref="Efl.Canvas.Layout"/> object).</param>
    virtual protected void SetResizeObject(Efl.Canvas.Object sobj) {
                                 Efl.Ui.Widget.NativeMethods.efl_ui_widget_resize_object_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),sobj);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Returns whether the widget is disabled.
    /// This will return <c>true</c> if any widget in the parent hierarchy is disabled. Re-enabling that parent may in turn change the disabled state of this widget.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the widget is disabled.</returns>
    virtual public bool GetDisabled() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_disabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Enables or disables this widget.
    /// Disabling a widget will disable all its children recursively, but only this widget will be marked as disabled internally.
    /// (Since EFL 1.22)</summary>
    /// <param name="disabled"><c>true</c> if the widget is disabled.</param>
    virtual public void SetDisabled(bool disabled) {
                                 Efl.Ui.Widget.NativeMethods.efl_ui_widget_disabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),disabled);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Returns the current style of a widget.
    /// (Since EFL 1.22)</summary>
    /// <returns>Name of the style to use. Refer to each widget&apos;s documentation for the available style names, or to the themes in use.</returns>
    virtual public System.String GetStyle() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_style_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Can only be called during construction, before finalize.
    /// (Since EFL 1.22)</summary>
    /// <param name="style">Name of the style to use. Refer to each widget&apos;s documentation for the available style names, or to the themes in use.</param>
    /// <returns>Whether the style was successfully applied or not, see the Efl.Ui.Theme.Apply_Error subset of <see cref="Eina.Error"/> for more information.</returns>
    virtual protected Eina.Error SetStyle(System.String style) {
                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_style_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),style);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The ability for a widget to be focused.
    /// Unfocusable objects do nothing when programmatically focused. The nearest focusable parent object the one really getting focus. Also, when they receive mouse input, they will get the event, but not take away the focus from where it was previously.
    /// 
    /// Note: Objects which are meant to be interacted with by input events are created able to be focused, by default. All the others are not.
    /// 
    /// This property&apos;s default value depends on the widget (eg. a box is not focusable, but a button is).
    /// (Since EFL 1.22)</summary>
    /// <returns>Whether the object is focusable.</returns>
    virtual public bool GetFocusAllow() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_allow_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The ability for a widget to be focused.
    /// Unfocusable objects do nothing when programmatically focused. The nearest focusable parent object the one really getting focus. Also, when they receive mouse input, they will get the event, but not take away the focus from where it was previously.
    /// 
    /// Note: Objects which are meant to be interacted with by input events are created able to be focused, by default. All the others are not.
    /// 
    /// This property&apos;s default value depends on the widget (eg. a box is not focusable, but a button is).
    /// (Since EFL 1.22)</summary>
    /// <param name="can_focus">Whether the object is focusable.</param>
    virtual public void SetFocusAllow(bool can_focus) {
                                 Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_allow_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),can_focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The internal parent of this widget.
    /// <see cref="Efl.Ui.Widget"/> objects have a parent hierarchy that may differ slightly from their <see cref="Efl.Object"/> or <see cref="Efl.Canvas.Object"/> hierarchy. This is meant for internal handling.
    /// (Since EFL 1.22)</summary>
    /// <returns>Widget parent object</returns>
    virtual protected Efl.Ui.Widget GetWidgetParent() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_parent_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The internal parent of this widget.
    /// <see cref="Efl.Ui.Widget"/> objects have a parent hierarchy that may differ slightly from their <see cref="Efl.Object"/> or <see cref="Efl.Canvas.Object"/> hierarchy. This is meant for internal handling.
    /// (Since EFL 1.22)</summary>
    /// <param name="parent">Widget parent object</param>
    virtual protected void SetWidgetParent(Efl.Ui.Widget parent) {
                                 Efl.Ui.Widget.NativeMethods.efl_ui_widget_parent_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),parent);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Accessibility information.
    /// This is a replacement string to be read by the accessibility text-to-speech engine, if accessibility is enabled by configuration. This will take precedence over the default text for this object, which means for instance that the label of a button won&apos;t be read out loud, instead <c>txt</c> will be read out.
    /// (Since EFL 1.22)</summary>
    /// <returns>Accessibility text description.</returns>
    virtual public System.String GetAccessInfo() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_access_info_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Accessibility information.
    /// This is a replacement string to be read by the accessibility text-to-speech engine, if accessibility is enabled by configuration. This will take precedence over the default text for this object, which means for instance that the label of a button won&apos;t be read out loud, instead <c>txt</c> will be read out.
    /// (Since EFL 1.22)</summary>
    /// <param name="txt">Accessibility text description.</param>
    virtual public void SetAccessInfo(System.String txt) {
                                 Efl.Ui.Widget.NativeMethods.efl_ui_widget_access_info_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),txt);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Region of interest inside this widget, that should be given priority to be visible inside a scroller.
    /// When this widget or one of its subwidgets is given focus, this region should be shown, which means any parent scroller should attempt to display the given area of this widget. For instance, an entry given focus should scroll to show the text cursor if that cursor moves. In this example, this region defines the relative geometry of the cursor within the widget.
    /// 
    /// Note: The region is relative to the top-left corner of the widget, i.e. X,Y start from 0,0 to indicate the top-left corner of the widget. W,H must be greater or equal to 1 for this region to be taken into account, otherwise it is ignored.
    /// (Since EFL 1.22)</summary>
    /// <returns>The relative region to show. If width or height is &lt;= 0 it will be ignored, and no action will be taken.</returns>
    virtual protected Eina.Rect GetInterestRegion() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_interest_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This is a read-only property.
    /// (Since EFL 1.22)</summary>
    /// <returns>The rectangle area.</returns>
    virtual protected Eina.Rect GetFocusHighlightGeometry() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_highlight_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Focus order property
    /// (Since EFL 1.22)</summary>
    /// <returns>FIXME</returns>
    virtual public uint GetFocusOrder() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_order_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A custom chain of objects to pass focus.
    /// Note: On focus cycle, only will be evaluated children of this container.
    /// (Since EFL 1.22)</summary>
    /// <returns>Chain of objects</returns>
    virtual public Eina.List<Efl.Canvas.Object> GetFocusCustomChain() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_custom_chain_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Canvas.Object>(_ret_var, false, false);
 }
    /// <summary>This function overwrites any previous custom focus chain within the list of objects. The previous list will be deleted and this list will be managed by elementary. After it is set, don&apos;t modify it.
    /// (Since EFL 1.22)</summary>
    /// <param name="objs">Chain of objects to pass focus</param>
    virtual public void SetFocusCustomChain(Eina.List<Efl.Canvas.Object> objs) {
         var _in_objs = objs.Handle;
                        Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_custom_chain_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_objs);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Current focused object in object tree.
    /// (Since EFL 1.22)</summary>
    /// <returns>Current focused or <c>null</c>, if there is no focused object.</returns>
    virtual public Efl.Canvas.Object GetFocusedObject() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focused_object_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The widget&apos;s focus move policy.
    /// (Since EFL 1.22)</summary>
    /// <returns>Focus move policy</returns>
    virtual public Efl.Ui.Focus.MovePolicy GetFocusMovePolicy() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_move_policy_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The widget&apos;s focus move policy.
    /// (Since EFL 1.22)</summary>
    /// <param name="policy">Focus move policy</param>
    virtual public void SetFocusMovePolicy(Efl.Ui.Focus.MovePolicy policy) {
                                 Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_move_policy_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),policy);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the widget&apos;s focus_move_policy mode setting.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> to follow system focus move policy change, <c>false</c> otherwise</returns>
    virtual public bool GetFocusMovePolicyAutomatic() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_move_policy_automatic_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the widget&apos;s focus_move_policy mode setting.
    /// (Since EFL 1.22)</summary>
    /// <param name="automatic"><c>true</c> to follow system focus move policy change, <c>false</c> otherwise</param>
    virtual public void SetFocusMovePolicyAutomatic(bool automatic) {
                                 Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_move_policy_automatic_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),automatic);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Virtual function handling input events on the widget.
    /// This method should return <c>true</c> if the event has been processed. Only key down, key up and pointer wheel events will be propagated through this function.
    /// 
    /// It is common for the event to be also marked as processed as in <see cref="Efl.Input.IEvent.Processed"/>, if this operation was successful. This makes sure other widgets will not also process this input event.
    /// (Since EFL 1.22)</summary>
    /// <param name="eo_event">EO event struct with an Efl.Input.Event as info.</param>
    /// <param name="source">Source object where the event originated. Often same as this.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual protected bool WidgetInputEventHandler(ref Efl.Event eo_event, Efl.Canvas.Object source) {
         Efl.Event.NativeStruct _in_eo_event = eo_event;
                                                var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_input_event_handler_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ref _in_eo_event, source);
        Eina.Error.RaiseIfUnhandledException();
                        eo_event = _in_eo_event;
                return _ret_var;
 }
    /// <summary>Hook function called when widget is activated through accessibility.
    /// This meant to be overridden by subclasses to support accessibility. This is an unstable API.
    /// (Since EFL 1.22)</summary>
    /// <param name="act">Type of activation.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual protected bool OnAccessActivate(Efl.Ui.Activate act) {
                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_on_access_activate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),act);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Hook function called when accessibility is changed on the widget.
    /// This meant to be overridden by subclasses to support accessibility. This is an unstable API.
    /// (Since EFL 1.22)</summary>
    /// <param name="enable"><c>true</c> if accessibility is enabled.</param>
    virtual protected void UpdateOnAccess(bool enable) {
                                 Efl.Ui.Widget.NativeMethods.efl_ui_widget_on_access_update_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),enable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>&apos;Virtual&apos; function on the widget being set screen reader.
    /// (Since EFL 1.22)</summary>
    virtual public void ScreenReader(bool is_screen_reader) {
                                 Efl.Ui.Widget.NativeMethods.efl_ui_widget_screen_reader_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),is_screen_reader);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>&apos;Virtual&apos; function on the widget being set atspi.
    /// (Since EFL 1.22)</summary>
    virtual public void Atspi(bool is_atspi) {
                                 Efl.Ui.Widget.NativeMethods.efl_ui_widget_atspi_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),is_atspi);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Virtual function customizing sub objects being added.
    /// When a widget is added as a sub-object of another widget (like list elements inside a list container, for example) some of its properties are automatically adapted to the parent&apos;s current values (like focus, access, theme, scale, mirror, scrollable child get, translate, display mode set, tree dump). Override this method if you want to customize differently sub-objects being added to this object.
    /// 
    /// Sub objects can be any canvas object, not necessarily widgets.
    /// 
    /// See also <see cref="Efl.Ui.Widget.WidgetParent"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="sub_obj">Sub object to be added. Not necessarily a widget itself.</param>
    /// <returns>Indicates if the operation succeeded.</returns>
    virtual protected bool AddWidgetSubObject(Efl.Canvas.Object sub_obj) {
                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_sub_object_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),sub_obj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Virtual function customizing sub objects being removed.
    /// When a widget is removed as a sub-object from another widget (<see cref="Efl.IPack.Unpack"/>, <see cref="Efl.IContent.UnsetContent"/>, for example) some of its properties are automatically adjusted.(like focus, access, tree dump) Override this method if you want to customize differently sub-objects being removed to this object.
    /// 
    /// Sub objects can be any canvas object, not necessarily widgets.
    /// 
    /// See also <see cref="Efl.Ui.Widget.WidgetParent"/> and <see cref="Efl.Ui.Widget.AddWidgetSubObject"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="sub_obj">Sub object to be removed. Should be a child of this widget.</param>
    /// <returns>Indicates if the operation succeeded.</returns>
    virtual protected bool DelWidgetSubObject(Efl.Canvas.Object sub_obj) {
                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_sub_object_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),sub_obj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Virtual function called when the widget needs to re-apply its theme.
    /// This may be called when the object is first created, or whenever the widget is modified in any way that may require a reload of the theme. This may include but is not limited to scale, theme, or mirrored mode changes.
    /// 
    /// Note: even widgets not based on layouts may override this method to handle widget updates (scale, mirrored mode, etc...).
    /// (Since EFL 1.22)</summary>
    /// <returns>Indicates success, and if the current theme or default theme was used.</returns>
    virtual protected Eina.Error ThemeApply() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_theme_apply_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Push scroll hold
    /// (Since EFL 1.22)</summary>
    virtual public void PushScrollHold() {
         Efl.Ui.Widget.NativeMethods.efl_ui_widget_scroll_hold_push_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Pop scroller hold
    /// (Since EFL 1.22)</summary>
    virtual public void PopScrollHold() {
         Efl.Ui.Widget.NativeMethods.efl_ui_widget_scroll_hold_pop_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Push scroller freeze
    /// (Since EFL 1.22)</summary>
    virtual public void PushScrollFreeze() {
         Efl.Ui.Widget.NativeMethods.efl_ui_widget_scroll_freeze_push_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Pop scroller freeze
    /// (Since EFL 1.22)</summary>
    virtual public void PopScrollFreeze() {
         Efl.Ui.Widget.NativeMethods.efl_ui_widget_scroll_freeze_pop_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Get the access object of given part of the widget.
    /// (Since EFL 1.18)</summary>
    /// <param name="part">The object&apos;s part name to get access object</param>
    virtual public Efl.Canvas.Object GetPartAccessObject(System.String part) {
                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_part_access_object_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),part);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get newest focus in order
    /// (Since EFL 1.22)</summary>
    /// <param name="newest_focus_order">Newest focus order</param>
    /// <param name="can_focus_only"><c>true</c> only us widgets which can focus, <c>false</c> otherweise</param>
    /// <returns>Handle to focused widget</returns>
    virtual public Efl.Canvas.Object GetNewestFocusOrder(out uint newest_focus_order, bool can_focus_only) {
                                                         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_newest_focus_order_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out newest_focus_order, can_focus_only);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Set the next object with specific focus direction.
    /// (Since EFL 1.8)</summary>
    /// <param name="next">Focus next object</param>
    /// <param name="dir">Focus direction</param>
    virtual public void SetFocusNextObject(Efl.Canvas.Object next, Efl.Ui.Focus.Direction dir) {
                                                         Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_next_object_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),next, dir);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get the next object with specific focus direction.
    /// (Since EFL 1.8)</summary>
    /// <param name="dir">Focus direction</param>
    /// <returns>Focus next object</returns>
    virtual public Efl.Canvas.Object GetFocusNextObject(Efl.Ui.Focus.Direction dir) {
                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_next_object_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dir);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Set the next object item with specific focus direction.
    /// (Since EFL 1.16)</summary>
    /// <param name="next_item">Focus next object item</param>
    /// <param name="dir">Focus direction</param>
    virtual public void SetFocusNextItem(Efl.Ui.Widget next_item, Efl.Ui.Focus.Direction dir) {
                                                         Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_next_item_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),next_item, dir);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Get the next object item with specific focus direction.
    /// (Since EFL 1.16)</summary>
    /// <param name="dir">Focus direction</param>
    /// <returns>Focus next object item</returns>
    virtual public Efl.Ui.Widget GetFocusNextItem(Efl.Ui.Focus.Direction dir) {
                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_next_item_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dir);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Handle focus tree unfocusable
    /// (Since EFL 1.22)</summary>
    virtual public void FocusTreeUnfocusableHandle() {
         Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_tree_unfocusable_handle_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Prepend object to custom focus chain.
    /// Note: If @&quot;relative_child&quot; equal to <c>null</c> or not in custom chain, the object will be added in begin.
    /// 
    /// Note: On focus cycle, only will be evaluated children of this container.
    /// (Since EFL 1.22)</summary>
    /// <param name="child">The child to be added in custom chain.</param>
    /// <param name="relative_child">The relative object to position the child.</param>
    virtual public void FocusCustomChainPrepend(Efl.Canvas.Object child, Efl.Canvas.Object relative_child) {
                                                         Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_custom_chain_prepend_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child, relative_child);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Give focus to next object with specific focus direction in object tree.
    /// (Since EFL 1.22)</summary>
    /// <param name="dir">Direction to move the focus.</param>
    virtual public void FocusCycle(Efl.Ui.Focus.Direction dir) {
                                 Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_cycle_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dir);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>&apos;Virtual&apos; function handling passing focus to sub-objects given a direction, in degrees.
    /// (Since EFL 1.22)</summary>
    /// <param name="kw_base">Base object</param>
    /// <param name="degree">Degree</param>
    /// <param name="direction">Direction</param>
    /// <param name="direction_item">Direction item</param>
    /// <param name="weight">Weight</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool FocusDirection(Efl.Canvas.Object kw_base, double degree, out Efl.Canvas.Object direction, out Efl.Ui.Widget direction_item, out double weight) {
                                                                                                                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_direction_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_base, degree, out direction, out direction_item, out weight);
        Eina.Error.RaiseIfUnhandledException();
                                                                                        return _ret_var;
 }
    /// <summary>&apos;Virtual&apos; function which checks if handling of passing focus to sub-objects is supported by widget.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool IsFocusNextManager() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_next_manager_is_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get focus list direction
    /// (Since EFL 1.22)</summary>
    /// <param name="kw_base">Base object</param>
    /// <param name="items">Item list</param>
    /// <param name="list_data_get">Data get function</param>
    /// <param name="degree">Degree</param>
    /// <param name="direction">Direction</param>
    /// <param name="direction_item">Direction item</param>
    /// <param name="weight">Weight</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool GetFocusListDirection(Efl.Canvas.Object kw_base, Eina.List<Efl.Object> items, System.IntPtr list_data_get, double degree, out Efl.Canvas.Object direction, out Efl.Ui.Widget direction_item, out double weight) {
                 var _in_items = items.Handle;
                                                                                                                                                                var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_list_direction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_base, _in_items, list_data_get, degree, out direction, out direction_item, out weight);
        Eina.Error.RaiseIfUnhandledException();
                                                                                                                        return _ret_var;
 }
    /// <summary>Clear focused object
    /// (Since EFL 1.22)</summary>
    virtual public void ClearFocusedObject() {
         Efl.Ui.Widget.NativeMethods.efl_ui_widget_focused_object_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Go in focus direction
    /// (Since EFL 1.22)</summary>
    /// <param name="degree">Degree</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool FocusDirectionGo(double degree) {
                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_direction_go_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),degree);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get next focus item
    /// (Since EFL 1.22)</summary>
    /// <param name="dir">Focus direction</param>
    /// <param name="next">Next object</param>
    /// <param name="next_item">Next item</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool GetFocusNext(Efl.Ui.Focus.Direction dir, out Efl.Canvas.Object next, out Efl.Ui.Widget next_item) {
                                                                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_next_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dir, out next, out next_item);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Restore the focus state of the sub-tree.
    /// This API will restore the focus state of the sub-tree to the latest state. If a sub-tree is unfocused and wants to get back to the latest focus state, this API will be helpful.
    /// (Since EFL 1.22)</summary>
    virtual public void FocusRestore() {
         Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_restore_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Unset a custom focus chain on a given Elementary widget.
    /// Any focus chain previously set is removed entirely after this call.
    /// (Since EFL 1.22)</summary>
    virtual public void UnsetFocusCustomChain() {
         Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_custom_chain_unset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Steal focus
    /// (Since EFL 1.22)</summary>
    /// <param name="item">Widget to steal focus from</param>
    virtual public void FocusSteal(Efl.Ui.Widget item) {
                                 Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_steal_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),item);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Handle hide focus
    /// (Since EFL 1.22)</summary>
    virtual public void FocusHideHandle() {
         Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_hide_handle_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>&apos;Virtual&apos; function handling passing focus to sub-objects.
    /// (Since EFL 1.22)</summary>
    /// <param name="dir">Focus direction</param>
    /// <param name="next">Next object</param>
    /// <param name="next_item">Next item</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool FocusNext(Efl.Ui.Focus.Direction dir, out Efl.Canvas.Object next, out Efl.Ui.Widget next_item) {
                                                                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_next_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dir, out next, out next_item);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Get next item in focus list
    /// (Since EFL 1.22)</summary>
    /// <param name="items">Item list</param>
    /// <param name="list_data_get">Function type</param>
    /// <param name="dir">Focus direction</param>
    /// <param name="next">Next object</param>
    /// <param name="next_item">Next item</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool GetFocusListNext(Eina.List<Efl.Object> items, System.IntPtr list_data_get, Efl.Ui.Focus.Direction dir, out Efl.Canvas.Object next, out Efl.Ui.Widget next_item) {
         var _in_items = items.Handle;
                                                                                                                        var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_list_next_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_items, list_data_get, dir, out next, out next_item);
        Eina.Error.RaiseIfUnhandledException();
                                                                                        return _ret_var;
 }
    /// <summary>Handle focus mouse up
    /// (Since EFL 1.22)</summary>
    virtual public void FocusMouseUpHandle() {
         Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_mouse_up_handle_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Get focus direction
    /// (Since EFL 1.22)</summary>
    /// <param name="kw_base">Base</param>
    /// <param name="degree">Degree</param>
    /// <param name="direction">Direction</param>
    /// <param name="direction_item">Direction item</param>
    /// <param name="weight">Weight</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool GetFocusDirection(Efl.Canvas.Object kw_base, double degree, out Efl.Canvas.Object direction, out Efl.Ui.Widget direction_item, out double weight) {
                                                                                                                                 var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_direction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_base, degree, out direction, out direction_item, out weight);
        Eina.Error.RaiseIfUnhandledException();
                                                                                        return _ret_var;
 }
    /// <summary>Handle disable widget focus
    /// (Since EFL 1.22)</summary>
    virtual public void FocusDisabledHandle() {
         Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_disabled_handle_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Append object to custom focus chain.
    /// Note: If @&quot;relative_child&quot; equal to <c>null</c> or not in custom chain, the object will be added in end.
    /// 
    /// Note: On focus cycle, only will be evaluated children of this container.
    /// (Since EFL 1.22)</summary>
    /// <param name="child">The child to be added in custom chain.</param>
    /// <param name="relative_child">The relative object to position the child.</param>
    virtual public void AppendFocusCustomChain(Efl.Canvas.Object child, Efl.Canvas.Object relative_child) {
                                                         Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_custom_chain_append_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child, relative_child);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>No description supplied.
    /// (Since EFL 1.18)</summary>
    virtual public void FocusReconfigure() {
         Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_reconfigure_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Virtual function which checks if this widget can handle passing focus to sub-object, in a given direction.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual protected bool IsFocusDirectionManager() {
         var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_direction_manager_is_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Apply a new focus state on the widget.
    /// This method is called internally by <see cref="Efl.Ui.Widget"/>. Override it to change how a widget interacts with its focus manager. If a widget desires to change the applied configuration, it has to modify <c>configured_state</c> in addition to any internal changes.
    /// 
    /// The default implementation (when this method is not overridden) applies <c>configured_state</c> using the <c>manager</c> contained inside.
    /// (Since EFL 1.22)</summary>
    /// <param name="current_state">The current focus configuration of the widget.</param>
    /// <param name="configured_state">The new configuration being set on the widget.</param>
    /// <param name="redirect">A redirect object if there is any</param>
    /// <returns>Returns <c>true</c> if the widget is registered in the focus manager, <c>false</c> if not.</returns>
    virtual protected bool FocusStateApply(Efl.Ui.WidgetFocusState current_state, ref Efl.Ui.WidgetFocusState configured_state, Efl.Ui.Widget redirect) {
         Efl.Ui.WidgetFocusState.NativeStruct _in_current_state = current_state;
                                var _out_configured_state = new Efl.Ui.WidgetFocusState.NativeStruct();
                                        var _ret_var = Efl.Ui.Widget.NativeMethods.efl_ui_widget_focus_state_apply_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_current_state, ref _out_configured_state, redirect);
        Eina.Error.RaiseIfUnhandledException();
                configured_state = _out_configured_state;
                                        return _ret_var;
 }
    /// <summary>Get a proxy object referring to a part of an object.
    /// (Since EFL 1.22)</summary>
    /// <param name="name">The part name.</param>
    /// <returns>A (proxy) object, valid for a single call.</returns>
    virtual public Efl.Object GetPart(System.String name) {
                                 var _ret_var = Efl.IPartConcrete.NativeMethods.efl_part_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Gets action name for given id</summary>
    /// <param name="id">ID to get action name for</param>
    /// <returns>Action name</returns>
    virtual public System.String GetActionName(int id) {
                                 var _ret_var = Efl.Access.IActionConcrete.NativeMethods.efl_access_action_name_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Gets localized action name for given id</summary>
    /// <param name="id">ID to get localized name for</param>
    /// <returns>Localized name</returns>
    virtual public System.String GetActionLocalizedName(int id) {
                                 var _ret_var = Efl.Access.IActionConcrete.NativeMethods.efl_access_action_localized_name_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get list of available widget actions</summary>
    /// <returns>Contains statically allocated strings.</returns>
    virtual public Eina.List<Efl.Access.ActionData> GetActions() {
         var _ret_var = Efl.Access.IActionConcrete.NativeMethods.efl_access_action_actions_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Access.ActionData>(_ret_var, false, false);
 }
    /// <summary>Performs action on given widget.</summary>
    /// <param name="id">ID for widget</param>
    /// <returns><c>true</c> if action was performed, <c>false</c> otherwise</returns>
    virtual public bool ActionDo(int id) {
                                 var _ret_var = Efl.Access.IActionConcrete.NativeMethods.efl_access_action_do_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Gets configured keybinding for specific action and widget.</summary>
    /// <param name="id">ID for widget</param>
    /// <returns>Should be freed by the user.</returns>
    virtual public System.String GetActionKeybinding(int id) {
                                 var _ret_var = Efl.Access.IActionConcrete.NativeMethods.efl_access_action_keybinding_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),id);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
    /// <returns>Z order of component</returns>
    virtual public int GetZOrder() {
         var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_z_order_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Geometry of accessible widget.</summary>
    /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <returns>The geometry.</returns>
    virtual public Eina.Rect GetExtents(bool screen_coords) {
                                 var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_extents_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),screen_coords);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Geometry of accessible widget.</summary>
    /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="rect">The geometry.</param>
    /// <returns><c>true</c> if geometry was set, <c>false</c> otherwise</returns>
    virtual public bool SetExtents(bool screen_coords, Eina.Rect rect) {
                 Eina.Rect.NativeStruct _in_rect = rect;
                                        var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_extents_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),screen_coords, _in_rect);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Position of accessible widget.</summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    virtual public void GetScreenPosition(out int x, out int y) {
                                                         Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_screen_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Position of accessible widget.</summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <returns><c>true</c> if position was set, <c>false</c> otherwise</returns>
    virtual public bool SetScreenPosition(int x, int y) {
                                                         var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_screen_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Gets position of socket offset.</summary>
    virtual public void GetSocketOffset(out int x, out int y) {
                                                         Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_socket_offset_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out x, out y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets position of socket offset.</summary>
    virtual public void SetSocketOffset(int x, int y) {
                                                         Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_socket_offset_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Contains accessible widget</summary>
    /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <returns><c>true</c> if params have been set, <c>false</c> otherwise</returns>
    virtual public bool Contains(bool screen_coords, int x, int y) {
                                                                                 var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_contains_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),screen_coords, x, y);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Focuses accessible widget.</summary>
    /// <returns><c>true</c> if focus grab focus succeed, <c>false</c> otherwise.</returns>
    virtual public bool GrabFocus() {
         var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_focus_grab_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets top component object occupying space at given coordinates.</summary>
    /// <param name="screen_coords">If <c>true</c> x and y values will be relative to screen origin, otherwise relative to canvas</param>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <returns>Top component object at given coordinate</returns>
    virtual public Efl.Object GetAccessibleAtPoint(bool screen_coords, int x, int y) {
                                                                                 var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_accessible_at_point_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),screen_coords, x, y);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Highlights accessible widget. returns true if highlight grab has successed, false otherwise.
    /// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
    virtual public bool GrabHighlight() {
         var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_highlight_grab_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Clears highlight of accessible widget. returns true if clear has successed, false otherwise.
    /// @if MOBILE @since_tizen 4.0 @elseif WEARABLE @since_tizen 3.0 @endif</summary>
    virtual public bool ClearHighlight() {
         var _ret_var = Efl.Access.IComponentConcrete.NativeMethods.efl_access_component_highlight_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets an localized string describing accessible object role name.</summary>
    /// <returns>Localized accessible object role name</returns>
    virtual public System.String GetLocalizedRoleName() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_localized_role_name_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Accessible name of the object.</summary>
    /// <returns>Accessible name</returns>
    virtual public System.String GetI18nName() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_i18n_name_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Accessible name of the object.</summary>
    /// <param name="i18n_name">Accessible name</param>
    virtual public void SetI18nName(System.String i18n_name) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_i18n_name_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),i18n_name);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Sets name information callback about widget.
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <param name="name_cb">reading information callback</param>
    virtual public void SetNameCb(Efl.Access.ReadingInfoCb name_cb, System.IntPtr data) {
                                                         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_name_cb_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),name_cb, data);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Gets an all relations between accessible object and other accessible objects.</summary>
    /// <returns>Accessible relation set</returns>
    virtual public Efl.Access.RelationSet GetRelationSet() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_relation_set_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The role of the object in accessibility domain.</summary>
    /// <returns>Accessible role</returns>
    virtual public Efl.Access.Role GetRole() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_role_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the role of the object in accessibility domain.</summary>
    /// <param name="role">Accessible role</param>
    virtual public void SetRole(Efl.Access.Role role) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_role_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),role);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets object&apos;s accessible parent.</summary>
    /// <returns>Accessible parent</returns>
    virtual public Efl.Access.IObject GetAccessParent() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_access_parent_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets object&apos;s accessible parent.</summary>
    /// <param name="parent">Accessible parent</param>
    virtual public void SetAccessParent(Efl.Access.IObject parent) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_access_parent_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),parent);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Sets contextual information callback about widget.
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <param name="description_cb">The function called to provide the accessible description.</param>
    /// <param name="data">The data passed to @c description_cb.</param>
    virtual public void SetDescriptionCb(Efl.Access.ReadingInfoCb description_cb, System.IntPtr data) {
                                                         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_description_cb_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),description_cb, data);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets gesture callback to give widget.
    /// Warning: Please do not abuse this API. The purpose of this API is to support special application such as screen-reader guidance. Before using this API, please check if there is another way.
    /// 
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    virtual public void SetGestureCb(Efl.Access.GestureCb gesture_cb, System.IntPtr data) {
                                                         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_gesture_cb_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),gesture_cb, data);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Gets object&apos;s accessible children.</summary>
    /// <returns>List of widget&apos;s children</returns>
    virtual public Eina.List<Efl.Access.IObject> GetAccessChildren() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_access_children_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Access.IObject>(_ret_var, true, false);
 }
    /// <summary>Gets human-readable string indentifying object accessibility role.</summary>
    /// <returns>Accessible role name</returns>
    virtual public System.String GetRoleName() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_role_name_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets key-value pairs indentifying object extra attributes. Must be free by a user.</summary>
    /// <returns>List of object attributes, Must be freed by the user</returns>
    virtual public Eina.List<Efl.Access.Attribute> GetAttributes() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_attributes_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Access.Attribute>(_ret_var, true, true);
 }
    /// <summary>Gets reading information types of an accessible object. if no reading information is set, 0 is returned which means all four reading information types will be read on object highlight
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <returns>Reading information types</returns>
    virtual public Efl.Access.ReadingInfoTypeMask GetReadingInfoType() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_reading_info_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets reading information of an accessible object. If set as 0, existing reading info will be deleted and by default all four reading information types like name, role, state and description will be read on object highlight
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <param name="reading_info">Reading information types</param>
    virtual public void SetReadingInfoType(Efl.Access.ReadingInfoTypeMask reading_info) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_reading_info_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),reading_info);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets index of the child in parent&apos;s children list.</summary>
    /// <returns>Index in children list</returns>
    virtual public int GetIndexInParent() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_index_in_parent_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets contextual information about object.</summary>
    /// <returns>Accessible contextual information</returns>
    virtual public System.String GetDescription() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_description_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets widget contextual information.</summary>
    /// <param name="description">Accessible contextual information</param>
    virtual public void SetDescription(System.String description) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_description_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),description);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets set describing object accessible states.</summary>
    /// <returns>Accessible state set</returns>
    virtual public Efl.Access.StateSet GetStateSet() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_state_set_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Gets highlightable of given widget.
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <returns>If @c true, the object is highlightable.</returns>
    virtual public bool GetCanHighlight() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_can_highlight_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets highlightable to given widget.
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <param name="can_highlight">If @c true, the object is highlightable.</param>
    virtual public void SetCanHighlight(bool can_highlight) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_can_highlight_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),can_highlight);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
    /// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
    /// 
    /// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
    /// 
    /// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
    /// <returns>Translation domain</returns>
    virtual public System.String GetTranslationDomain() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_translation_domain_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
    /// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
    /// 
    /// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
    /// 
    /// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
    /// <param name="domain">Translation domain</param>
    virtual public void SetTranslationDomain(System.String domain) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_translation_domain_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),domain);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get root object of accessible object hierarchy</summary>
    /// <returns>Root object</returns>
    public static Efl.Object GetAccessRoot() {
         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_access_root_get_ptr.Value.Delegate();
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Handles gesture on given widget.</summary>
    virtual public bool GestureDo(Efl.Access.GestureInfo gesture_info) {
         Efl.Access.GestureInfo.NativeStruct _in_gesture_info = gesture_info;
                        var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_gesture_do_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_gesture_info);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Add key-value pair identifying object extra attribute
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <param name="key">The string key to give extra information</param>
    /// <param name="value">The string value to give extra information</param>
    virtual public void AppendAttribute(System.String key, System.String value) {
                                                         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_attribute_append_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key, value);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>delete key-value pair identifying object extra attributes when key is given</summary>
    /// <param name="key">The string key to identify the key-value pair</param>
    virtual public void DelAttribute(System.String key) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_attribute_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Removes all attributes in accessible object.</summary>
    virtual public void ClearAttributes() {
         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_attributes_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Register accessibility event listener</summary>
    /// <param name="cb">Callback</param>
    /// <param name="data">Data</param>
    /// <returns>Event handler</returns>
    public static Efl.Access.Event.Handler AddEventHandler(Efl.EventCb cb, System.IntPtr data) {
                                                         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_event_handler_add_ptr.Value.Delegate(cb, data);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Deregister accessibility event listener</summary>
    /// <param name="handler">Event handler</param>
    public static void DelEventHandler(Efl.Access.Event.Handler handler) {
                                 Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_event_handler_del_ptr.Value.Delegate(handler);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Emit event</summary>
    /// <param name="accessible">Accessibility object.</param>
    /// <param name="kw_event">Accessibility event type.</param>
    /// <param name="event_info">Accessibility event details.</param>
    public static void EmitEvent(Efl.Access.IObject accessible, Efl.EventDescription kw_event, System.IntPtr event_info) {
                 var _in_kw_event = Eina.PrimitiveConversion.ManagedToPointerAlloc(kw_event);
                                                                Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_event_emit_ptr.Value.Delegate(accessible, _in_kw_event, event_info);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Defines the relationship between two accessible objects.
    /// Adds a unique relationship between source object and relation_object of a given type.
    /// 
    /// Relationships can be queried by Assistive Technology clients to provide customized feedback, improving overall user experience.
    /// 
    /// Relationship_append API is asymmetric, which means that appending, for example, relation EFL_ACCESS_RELATION_TYPE_FLOWS_TO from object A to B, do NOT append relation EFL_ACCESS_RELATION_TYPE_FLOWS_FROM from object B to object A.</summary>
    /// <param name="type">Relation type</param>
    /// <param name="relation_object">Object to relate to</param>
    /// <returns><c>true</c> if relationship was successfully appended, <c>false</c> otherwise</returns>
    virtual public bool AppendRelationship(Efl.Access.RelationType type, Efl.Access.IObject relation_object) {
                                                         var _ret_var = Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_relationship_append_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type, relation_object);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Removes the relationship between two accessible objects.
    /// If relation_object is NULL function removes all relations of the given type.</summary>
    /// <param name="type">Relation type</param>
    /// <param name="relation_object">Object to remove relation from</param>
    virtual public void RelationshipRemove(Efl.Access.RelationType type, Efl.Access.IObject relation_object) {
                                                         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_relationship_remove_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type, relation_object);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Removes all relationships in accessible object.</summary>
    virtual public void ClearRelationships() {
         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_relationships_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Notifies accessibility clients about current state of the accessible object.
    /// Function limits information broadcast to clients to types specified by state_types_mask parameter.
    /// 
    /// if recursive parameter is set, function will traverse all accessible children and call state_notify function on them.</summary>
    virtual public void StateNotify(Efl.Access.StateSet state_types_mask, bool recursive) {
                                                         Efl.Access.IObjectConcrete.NativeMethods.efl_access_object_state_notify_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),state_types_mask, recursive);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Elementary actions</summary>
    /// <returns>NULL-terminated array of Efl.Access.Action_Data.</returns>
    virtual public Efl.Access.ActionData GetElmActions() {
         var _ret_var = Efl.Access.Widget.IActionConcrete.NativeMethods.efl_access_widget_action_elm_actions_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Start a drag and drop process at the drag side. During dragging, there are three events emitted as belows: - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_ACCEPT - EFL_UI_DND_EVENT_DRAG_DONE</summary>
    /// <param name="format">The data format</param>
    /// <param name="data">The drag data</param>
    /// <param name="action">Action when data is transferred</param>
    /// <param name="icon_func">Function pointer to create icon</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    virtual public void DragStart(Efl.Ui.SelectionFormat format, Eina.Slice data, Efl.Ui.SelectionAction action, Efl.Dnd.DragIconCreate icon_func, uint seat) {
                                                                                                                 GCHandle icon_func_handle = GCHandle.Alloc(icon_func);
                Efl.Ui.IDndConcrete.NativeMethods.efl_ui_dnd_drag_start_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),format, data, action, GCHandle.ToIntPtr(icon_func_handle), Efl.Dnd.DragIconCreateWrapper.Cb, Efl.Eo.Globals.free_gchandle, seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                                         }
    /// <summary>Set the action for the drag</summary>
    /// <param name="action">Drag action</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    virtual public void SetDragAction(Efl.Ui.SelectionAction action, uint seat) {
                                                         Efl.Ui.IDndConcrete.NativeMethods.efl_ui_dnd_drag_action_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),action, seat);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Cancel the on-going drag</summary>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    virtual public void DragCancel(uint seat) {
                                 Efl.Ui.IDndConcrete.NativeMethods.efl_ui_dnd_drag_cancel_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),seat);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Make the current object as drop target. There are four events emitted: - EFL_UI_DND_EVENT_DRAG_ENTER - EFL_UI_DND_EVENT_DRAG_LEAVE - EFL_UI_DND_EVENT_DRAG_POS - EFL_UI_DND_EVENT_DRAG_DROP.</summary>
    /// <param name="format">Accepted data format</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    virtual public void AddDropTarget(Efl.Ui.SelectionFormat format, uint seat) {
                                                         Efl.Ui.IDndConcrete.NativeMethods.efl_ui_dnd_drop_target_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),format, seat);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Delete the dropable status from object</summary>
    /// <param name="format">Accepted data format</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    virtual public void DelDropTarget(Efl.Ui.SelectionFormat format, uint seat) {
                                                         Efl.Ui.IDndConcrete.NativeMethods.efl_ui_dnd_drop_target_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),format, seat);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>A unique string to be translated.
    /// Often this will be a human-readable string (e.g. in English) but it can also be a unique string identifier that must then be translated to the current locale with <c>dgettext</c>() or any similar mechanism.
    /// 
    /// Setting this property will enable translation for this object or part.</summary>
    /// <param name="domain">A translation domain. If <c>null</c> this means the default domain is used.</param>
    /// <returns>This returns the untranslated value of <c>label</c>. The translated string can usually be retrieved with <see cref="Efl.IText.GetText"/>.</returns>
    virtual public System.String GetL10nText(out System.String domain) {
                                 var _ret_var = Efl.Ui.IL10nConcrete.NativeMethods.efl_ui_l10n_text_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out domain);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Sets the new untranslated string and domain for this object.</summary>
    /// <param name="label">A unique (untranslated) string.</param>
    /// <param name="domain">A translation domain. If <c>null</c> this uses the default domain (eg. set by <c>textdomain</c>()).</param>
    virtual public void SetL10nText(System.String label, System.String domain) {
                                                         Efl.Ui.IL10nConcrete.NativeMethods.efl_ui_l10n_text_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),label, domain);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Requests this object to update its text strings for the current locale.
    /// Currently strings are translated with <c>dgettext</c>, so support for this function may depend on the platform. It is up to the application to provide its own translation data.
    /// 
    /// This function is a hook meant to be implemented by any object that supports translation. This can be called whenever a new object is created or when the current locale changes, for instance. This should only trigger further calls to <see cref="Efl.Ui.IL10n.UpdateTranslation"/> to children objects.</summary>
    virtual public void UpdateTranslation() {
         Efl.Ui.IL10nConcrete.NativeMethods.efl_ui_l10n_translation_update_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
    /// <param name="key">key string for bind model property data</param>
    /// <param name="property">Model property name</param>
    /// <returns>0 when it succeed, an error code otherwise.</returns>
    virtual public Eina.Error PropertyBind(System.String key, System.String property) {
                                                         var _ret_var = Efl.Ui.IPropertyBindConcrete.NativeMethods.efl_ui_property_bind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key, property);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Set the selection data to the object</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="format">Selection Format</param>
    /// <param name="data">Selection data</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns>Future for tracking when the selection is lost</returns>
    virtual public  Eina.Future SetSelection(Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Eina.Slice data, uint seat) {
                                                                                                         var _ret_var = Efl.Ui.ISelectionConcrete.NativeMethods.efl_ui_selection_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type, format, data, seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                        return _ret_var;
 }
    /// <summary>Get the data from the object that has selection</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="format">Selection Format</param>
    /// <param name="data_func">Data ready function pointer</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    virtual public void GetSelection(Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Efl.Ui.SelectionDataReady data_func, uint seat) {
                                                                                         GCHandle data_func_handle = GCHandle.Alloc(data_func);
                Efl.Ui.ISelectionConcrete.NativeMethods.efl_ui_selection_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type, format, GCHandle.ToIntPtr(data_func_handle), Efl.Ui.SelectionDataReadyWrapper.Cb, Efl.Eo.Globals.free_gchandle, seat);
        Eina.Error.RaiseIfUnhandledException();
                                                                         }
    /// <summary>Clear the selection data from the object</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    virtual public void ClearSelection(Efl.Ui.SelectionType type, uint seat) {
                                                         Efl.Ui.ISelectionConcrete.NativeMethods.efl_ui_selection_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type, seat);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Determine whether the selection data has owner</summary>
    /// <param name="type">Selection type</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <returns>EINA_TRUE if there is object owns selection, otherwise EINA_FALSE</returns>
    virtual public bool HasOwner(Efl.Ui.SelectionType type, uint seat) {
                                                         var _ret_var = Efl.Ui.ISelectionConcrete.NativeMethods.efl_ui_selection_has_owner_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),type, seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Model that is/will be</summary>
    /// <returns>Efl model</returns>
    virtual public Efl.IModel GetModel() {
         var _ret_var = Efl.Ui.IViewConcrete.NativeMethods.efl_ui_view_model_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Model that is/will be</summary>
    /// <param name="model">Efl model</param>
    virtual public void SetModel(Efl.IModel model) {
                                 Efl.Ui.IViewConcrete.NativeMethods.efl_ui_view_model_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),model);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The geometry (that is, the bounding rectangle) used to calculate the relationship with other objects.
    /// (Since EFL 1.22)</summary>
    /// <returns>The geometry to use.</returns>
    virtual public Eina.Rect GetFocusGeometry() {
         var _ret_var = Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_focus_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Returns whether the widget is currently focused or not.
    /// (Since EFL 1.22)</summary>
    /// <returns>The focused state of the object.</returns>
    virtual public bool GetFocus() {
         var _ret_var = Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_focus_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This is called by the manager and should never be called by anyone else.
    /// The function emits the focus state events, if focus is different to the previous state.
    /// (Since EFL 1.22)</summary>
    /// <param name="focus">The focused state of the object.</param>
    virtual public void SetFocus(bool focus) {
                                 Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_focus_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This is the focus manager where this focus object is registered in. The element which is the <c>root</c> of a Efl.Ui.Focus.Manager will not have this focus manager as this object, but rather the second focus manager where it is registered in.
    /// (Since EFL 1.22)</summary>
    /// <returns>The manager object</returns>
    virtual public Efl.Ui.Focus.IManager GetFocusManager() {
         var _ret_var = Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_focus_manager_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Describes which logical parent is used by this object.
    /// (Since EFL 1.22)</summary>
    /// <returns>The focus parent.</returns>
    virtual public Efl.Ui.Focus.IObject GetFocusParent() {
         var _ret_var = Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_focus_parent_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Indicates if a child of this object has focus set to true.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if a child has focus.</returns>
    virtual public bool GetChildFocus() {
         var _ret_var = Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_child_focus_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Indicates if a child of this object has focus set to true.
    /// (Since EFL 1.22)</summary>
    /// <param name="child_focus"><c>true</c> if a child has focus.</param>
    virtual public void SetChildFocus(bool child_focus) {
                                 Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_child_focus_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),child_focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Tells the object that its children will be queried soon by the focus manager. Overwrite this to update the order of the children. Deleting items in this call will result in undefined behaviour and may cause your system to crash.
    /// (Since EFL 1.22)</summary>
    virtual public void SetupOrder() {
         Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_setup_order_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This is called when <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> is called, but only on the first call, additional recursive calls to <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> will not call this function again.
    /// (Since EFL 1.22)</summary>
    virtual public void SetupOrderNonRecursive() {
         Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_setup_order_non_recursive_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Virtual function handling focus in/out events on the widget
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if this widget can handle focus, <c>false</c> otherwise</returns>
    virtual public bool UpdateOnFocus() {
         var _ret_var = Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_on_focus_update_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Async wrapper for <see cref="SetSelection" />.</summary>
    /// <param name="type">Selection Type</param>
    /// <param name="format">Selection Format</param>
    /// <param name="data">Selection data</param>
    /// <param name="seat">Specified seat for multiple seats case.</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<Eina.Value> SetSelectionAsync(Efl.Ui.SelectionType type,Efl.Ui.SelectionFormat format,Eina.Slice data,uint seat, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = SetSelection( type, format, data, seat);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }

    /// <summary>The cursor to be shown when mouse is over the object
    /// This is the cursor that will be displayed when mouse is over the object. The object can have only one cursor set to it so if <see cref="Efl.Ui.Widget.SetCursor"/> is called twice for an object, the previous set will be unset.
    /// 
    /// If using X cursors, a definition of all the valid cursor names is listed on Elementary_Cursors.h. If an invalid name is set the default cursor will be used.
    /// (Since EFL 1.22)</summary>
    /// <value>The cursor name, defined either by the display system or the theme.</value>
    public System.String Cursor {
        get { return GetCursor(); }
        set { SetCursor(value); }
    }
    /// <summary>A different style for the cursor.
    /// This only makes sense if theme cursors are used. The cursor should be set with <see cref="Efl.Ui.Widget.SetCursor"/> first before setting its style with this property.
    /// (Since EFL 1.22)</summary>
    /// <value>A specific style to use, eg. default, transparent, ....</value>
    public System.String CursorStyle {
        get { return GetCursorStyle(); }
        set { SetCursorStyle(value); }
    }
    /// <summary>Whether the cursor may be looked in the theme or not.
    /// If <c>false</c>, the cursor may only come from the render engine, i.e. from the display manager.
    /// (Since EFL 1.22)</summary>
    /// <value>Whether to use theme cursors.</value>
    public bool CursorThemeSearchEnabled {
        get { return GetCursorThemeSearchEnabled(); }
        set { SetCursorThemeSearchEnabled(value); }
    }
    /// <summary>This is the internal canvas object managed by a widget.
    /// This property is protected as it is meant for widget implementations only, to set and access the internal canvas object. Do use this function unless you&apos;re implementing a widget.
    /// (Since EFL 1.22)</summary>
    /// <value>A canvas object (often a <see cref="Efl.Canvas.Layout"/> object).</value>
    protected Efl.Canvas.Object ResizeObject {
        set { SetResizeObject(value); }
    }
    /// <summary>Whether the widget is enabled (accepts and reacts to user inputs).
    /// The property works counted, this means, whenever n-caller set the value to <c>true</c>, n-caller have to set it to <c>false</c> in order to get it out of the disabled state again.
    /// 
    /// Each widget may handle the disabled state differently, but overall disabled widgets shall not respond to any input events. This is <c>false</c> by default, meaning the widget is enabled.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if the widget is disabled.</value>
    public bool Disabled {
        get { return GetDisabled(); }
        set { SetDisabled(value); }
    }
    /// <summary>The widget style to use.
    /// Styles define different look and feel for widgets, and may provide different parts for layout-based widgets. Styles vary from widget to widget and may be defined by other themes by means of extensions and overlays.
    /// 
    /// The style can only be set before <see cref="Efl.Object.FinalizeAdd"/>, which means at construction time of the object (inside <c>efl_add</c> in C).
    /// (Since EFL 1.22)</summary>
    /// <value>Name of the style to use. Refer to each widget&apos;s documentation for the available style names, or to the themes in use.</value>
    public System.String Style {
        get { return GetStyle(); }
        protected set { SetStyle(value); }
    }
    /// <summary>The ability for a widget to be focused.
    /// Unfocusable objects do nothing when programmatically focused. The nearest focusable parent object the one really getting focus. Also, when they receive mouse input, they will get the event, but not take away the focus from where it was previously.
    /// 
    /// Note: Objects which are meant to be interacted with by input events are created able to be focused, by default. All the others are not.
    /// 
    /// This property&apos;s default value depends on the widget (eg. a box is not focusable, but a button is).
    /// (Since EFL 1.22)</summary>
    /// <value>Whether the object is focusable.</value>
    public bool FocusAllow {
        get { return GetFocusAllow(); }
        set { SetFocusAllow(value); }
    }
    /// <summary>The internal parent of this widget.
    /// <see cref="Efl.Ui.Widget"/> objects have a parent hierarchy that may differ slightly from their <see cref="Efl.Object"/> or <see cref="Efl.Canvas.Object"/> hierarchy. This is meant for internal handling.
    /// (Since EFL 1.22)</summary>
    /// <value>Widget parent object</value>
    protected Efl.Ui.Widget WidgetParent {
        get { return GetWidgetParent(); }
        set { SetWidgetParent(value); }
    }
    /// <summary>Accessibility information.
    /// This is a replacement string to be read by the accessibility text-to-speech engine, if accessibility is enabled by configuration. This will take precedence over the default text for this object, which means for instance that the label of a button won&apos;t be read out loud, instead <c>txt</c> will be read out.
    /// (Since EFL 1.22)</summary>
    /// <value>Accessibility text description.</value>
    public System.String AccessInfo {
        get { return GetAccessInfo(); }
        set { SetAccessInfo(value); }
    }
    /// <summary>Region of interest inside this widget, that should be given priority to be visible inside a scroller.
    /// When this widget or one of its subwidgets is given focus, this region should be shown, which means any parent scroller should attempt to display the given area of this widget. For instance, an entry given focus should scroll to show the text cursor if that cursor moves. In this example, this region defines the relative geometry of the cursor within the widget.
    /// 
    /// Note: The region is relative to the top-left corner of the widget, i.e. X,Y start from 0,0 to indicate the top-left corner of the widget. W,H must be greater or equal to 1 for this region to be taken into account, otherwise it is ignored.
    /// (Since EFL 1.22)</summary>
    /// <value>The relative region to show. If width or height is &lt;= 0 it will be ignored, and no action will be taken.</value>
    protected Eina.Rect InterestRegion {
        get { return GetInterestRegion(); }
    }
    /// <summary>The rectangle region to be highlighted on focus.
    /// This is a rectangle region where the focus highlight should be displayed.
    /// (Since EFL 1.22)</summary>
    /// <value>The rectangle area.</value>
    protected Eina.Rect FocusHighlightGeometry {
        get { return GetFocusHighlightGeometry(); }
    }
    /// <summary>Focus order property
    /// (Since EFL 1.22)</summary>
    /// <value>FIXME</value>
    public uint FocusOrder {
        get { return GetFocusOrder(); }
    }
    /// <summary>A custom chain of objects to pass focus.
    /// Note: On focus cycle, only will be evaluated children of this container.
    /// (Since EFL 1.22)</summary>
    /// <value>Chain of objects to pass focus</value>
    public Eina.List<Efl.Canvas.Object> FocusCustomChain {
        get { return GetFocusCustomChain(); }
        set { SetFocusCustomChain(value); }
    }
    /// <summary>Current focused object in object tree.
    /// (Since EFL 1.22)</summary>
    /// <value>Current focused or <c>null</c>, if there is no focused object.</value>
    public Efl.Canvas.Object FocusedObject {
        get { return GetFocusedObject(); }
    }
    /// <summary>The widget&apos;s focus move policy.
    /// (Since EFL 1.22)</summary>
    /// <value>Focus move policy</value>
    public Efl.Ui.Focus.MovePolicy FocusMovePolicy {
        get { return GetFocusMovePolicy(); }
        set { SetFocusMovePolicy(value); }
    }
    /// <summary>Control the widget&apos;s focus_move_policy mode setting.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> to follow system focus move policy change, <c>false</c> otherwise</value>
    public bool FocusMovePolicyAutomatic {
        get { return GetFocusMovePolicyAutomatic(); }
        set { SetFocusMovePolicyAutomatic(value); }
    }
    /// <summary>Get list of available widget actions</summary>
    /// <value>Contains statically allocated strings.</value>
    public Eina.List<Efl.Access.ActionData> Actions {
        get { return GetActions(); }
    }
    /// <summary>Gets the depth at which the component is shown in relation to other components in the same container.</summary>
    /// <value>Z order of component</value>
    public int ZOrder {
        get { return GetZOrder(); }
    }
    /// <summary>Gets an localized string describing accessible object role name.</summary>
    /// <value>Localized accessible object role name</value>
    public System.String LocalizedRoleName {
        get { return GetLocalizedRoleName(); }
    }
    /// <summary>Accessible name of the object.</summary>
    /// <value>Accessible name</value>
    public System.String I18nName {
        get { return GetI18nName(); }
        set { SetI18nName(value); }
    }
    /// <summary>Gets an all relations between accessible object and other accessible objects.</summary>
    /// <value>Accessible relation set</value>
    public Efl.Access.RelationSet RelationSet {
        get { return GetRelationSet(); }
    }
    /// <summary>The role of the object in accessibility domain.</summary>
    /// <value>Accessible role</value>
    public Efl.Access.Role Role {
        get { return GetRole(); }
        set { SetRole(value); }
    }
    /// <summary>Gets object&apos;s accessible parent.</summary>
    /// <value>Accessible parent</value>
    public Efl.Access.IObject AccessParent {
        get { return GetAccessParent(); }
        set { SetAccessParent(value); }
    }
    /// <summary>Gets object&apos;s accessible children.</summary>
    /// <value>List of widget&apos;s children</value>
    public Eina.List<Efl.Access.IObject> AccessChildren {
        get { return GetAccessChildren(); }
    }
    /// <summary>Gets human-readable string indentifying object accessibility role.</summary>
    /// <value>Accessible role name</value>
    public System.String RoleName {
        get { return GetRoleName(); }
    }
    /// <summary>Gets key-value pairs indentifying object extra attributes. Must be free by a user.</summary>
    /// <value>List of object attributes, Must be freed by the user</value>
    public Eina.List<Efl.Access.Attribute> Attributes {
        get { return GetAttributes(); }
    }
    /// <summary>Gets reading information types of an accessible object. if no reading information is set, 0 is returned which means all four reading information types will be read on object highlight
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <value>Reading information types</value>
    public Efl.Access.ReadingInfoTypeMask ReadingInfoType {
        get { return GetReadingInfoType(); }
        set { SetReadingInfoType(value); }
    }
    /// <summary>Gets index of the child in parent&apos;s children list.</summary>
    /// <value>Index in children list</value>
    public int IndexInParent {
        get { return GetIndexInParent(); }
    }
    /// <summary>Gets contextual information about object.</summary>
    /// <value>Accessible contextual information</value>
    public System.String Description {
        get { return GetDescription(); }
        set { SetDescription(value); }
    }
    /// <summary>Gets set describing object accessible states.</summary>
    /// <value>Accessible state set</value>
    public Efl.Access.StateSet StateSet {
        get { return GetStateSet(); }
    }
    /// <summary>Gets highlightable of given widget.
    /// @if WEARABLE @since_tizen 3.0 @endif</summary>
    /// <value>If @c true, the object is highlightable.</value>
    public bool CanHighlight {
        get { return GetCanHighlight(); }
        set { SetCanHighlight(value); }
    }
    /// <summary>The translation domain of &quot;name&quot; and &quot;description&quot; properties.
    /// Translation domain should be set if the application wants to support i18n for accessibility &quot;name&quot; and &quot;description&quot; properties.
    /// 
    /// When translation domain is set, values of &quot;name&quot; and &quot;description&quot; properties will be translated with the dgettext function using the current translation domain as the &quot;domainname&quot; parameter.
    /// 
    /// It is the application developer&apos;s responsibility to ensure that translation files are loaded and bound to the translation domain when accessibility is enabled.</summary>
    /// <value>Translation domain</value>
    public System.String TranslationDomain {
        get { return GetTranslationDomain(); }
        set { SetTranslationDomain(value); }
    }
    /// <summary>Get root object of accessible object hierarchy</summary>
    /// <value>Root object</value>
    public static Efl.Object AccessRoot {
        get { return GetAccessRoot(); }
    }
    /// <summary>Elementary actions</summary>
    /// <value>NULL-terminated array of Efl.Access.Action_Data.</value>
    public Efl.Access.ActionData ElmActions {
        get { return GetElmActions(); }
    }
    /// <summary>Model that is/will be</summary>
    /// <value>Efl model</value>
    public Efl.IModel Model {
        get { return GetModel(); }
        set { SetModel(value); }
    }
    /// <summary>The geometry (that is, the bounding rectangle) used to calculate the relationship with other objects.
    /// (Since EFL 1.22)</summary>
    /// <value>The geometry to use.</value>
    public Eina.Rect FocusGeometry {
        get { return GetFocusGeometry(); }
    }
    /// <summary>Returns whether the widget is currently focused or not.
    /// (Since EFL 1.22)</summary>
    /// <value>The focused state of the object.</value>
    public bool Focus {
        get { return GetFocus(); }
        set { SetFocus(value); }
    }
    /// <summary>This is the focus manager where this focus object is registered in. The element which is the <c>root</c> of a Efl.Ui.Focus.Manager will not have this focus manager as this object, but rather the second focus manager where it is registered in.
    /// (Since EFL 1.22)</summary>
    /// <value>The manager object</value>
    public Efl.Ui.Focus.IManager FocusManager {
        get { return GetFocusManager(); }
    }
    /// <summary>Describes which logical parent is used by this object.
    /// (Since EFL 1.22)</summary>
    /// <value>The focus parent.</value>
    public Efl.Ui.Focus.IObject FocusParent {
        get { return GetFocusParent(); }
    }
    /// <summary>Indicates if a child of this object has focus set to true.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if a child has focus.</value>
    public bool ChildFocus {
        get { return GetChildFocus(); }
        set { SetChildFocus(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Widget.efl_ui_widget_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Group.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_widget_cursor_get_static_delegate == null)
            {
                efl_ui_widget_cursor_get_static_delegate = new efl_ui_widget_cursor_get_delegate(cursor_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCursor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_cursor_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_cursor_get_static_delegate) });
            }

            if (efl_ui_widget_cursor_set_static_delegate == null)
            {
                efl_ui_widget_cursor_set_static_delegate = new efl_ui_widget_cursor_set_delegate(cursor_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCursor") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_cursor_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_cursor_set_static_delegate) });
            }

            if (efl_ui_widget_cursor_style_get_static_delegate == null)
            {
                efl_ui_widget_cursor_style_get_static_delegate = new efl_ui_widget_cursor_style_get_delegate(cursor_style_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCursorStyle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_cursor_style_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_cursor_style_get_static_delegate) });
            }

            if (efl_ui_widget_cursor_style_set_static_delegate == null)
            {
                efl_ui_widget_cursor_style_set_static_delegate = new efl_ui_widget_cursor_style_set_delegate(cursor_style_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCursorStyle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_cursor_style_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_cursor_style_set_static_delegate) });
            }

            if (efl_ui_widget_cursor_theme_search_enabled_get_static_delegate == null)
            {
                efl_ui_widget_cursor_theme_search_enabled_get_static_delegate = new efl_ui_widget_cursor_theme_search_enabled_get_delegate(cursor_theme_search_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCursorThemeSearchEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_cursor_theme_search_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_cursor_theme_search_enabled_get_static_delegate) });
            }

            if (efl_ui_widget_cursor_theme_search_enabled_set_static_delegate == null)
            {
                efl_ui_widget_cursor_theme_search_enabled_set_static_delegate = new efl_ui_widget_cursor_theme_search_enabled_set_delegate(cursor_theme_search_enabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCursorThemeSearchEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_cursor_theme_search_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_cursor_theme_search_enabled_set_static_delegate) });
            }

            if (efl_ui_widget_resize_object_set_static_delegate == null)
            {
                efl_ui_widget_resize_object_set_static_delegate = new efl_ui_widget_resize_object_set_delegate(resize_object_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetResizeObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_resize_object_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_resize_object_set_static_delegate) });
            }

            if (efl_ui_widget_disabled_get_static_delegate == null)
            {
                efl_ui_widget_disabled_get_static_delegate = new efl_ui_widget_disabled_get_delegate(disabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDisabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_disabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_disabled_get_static_delegate) });
            }

            if (efl_ui_widget_disabled_set_static_delegate == null)
            {
                efl_ui_widget_disabled_set_static_delegate = new efl_ui_widget_disabled_set_delegate(disabled_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDisabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_disabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_disabled_set_static_delegate) });
            }

            if (efl_ui_widget_style_get_static_delegate == null)
            {
                efl_ui_widget_style_get_static_delegate = new efl_ui_widget_style_get_delegate(style_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStyle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_style_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_style_get_static_delegate) });
            }

            if (efl_ui_widget_style_set_static_delegate == null)
            {
                efl_ui_widget_style_set_static_delegate = new efl_ui_widget_style_set_delegate(style_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStyle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_style_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_style_set_static_delegate) });
            }

            if (efl_ui_widget_focus_allow_get_static_delegate == null)
            {
                efl_ui_widget_focus_allow_get_static_delegate = new efl_ui_widget_focus_allow_get_delegate(focus_allow_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusAllow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_allow_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_allow_get_static_delegate) });
            }

            if (efl_ui_widget_focus_allow_set_static_delegate == null)
            {
                efl_ui_widget_focus_allow_set_static_delegate = new efl_ui_widget_focus_allow_set_delegate(focus_allow_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFocusAllow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_allow_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_allow_set_static_delegate) });
            }

            if (efl_ui_widget_parent_get_static_delegate == null)
            {
                efl_ui_widget_parent_get_static_delegate = new efl_ui_widget_parent_get_delegate(widget_parent_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWidgetParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_parent_get_static_delegate) });
            }

            if (efl_ui_widget_parent_set_static_delegate == null)
            {
                efl_ui_widget_parent_set_static_delegate = new efl_ui_widget_parent_set_delegate(widget_parent_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWidgetParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_parent_set_static_delegate) });
            }

            if (efl_ui_widget_access_info_get_static_delegate == null)
            {
                efl_ui_widget_access_info_get_static_delegate = new efl_ui_widget_access_info_get_delegate(access_info_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAccessInfo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_access_info_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_access_info_get_static_delegate) });
            }

            if (efl_ui_widget_access_info_set_static_delegate == null)
            {
                efl_ui_widget_access_info_set_static_delegate = new efl_ui_widget_access_info_set_delegate(access_info_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAccessInfo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_access_info_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_access_info_set_static_delegate) });
            }

            if (efl_ui_widget_interest_region_get_static_delegate == null)
            {
                efl_ui_widget_interest_region_get_static_delegate = new efl_ui_widget_interest_region_get_delegate(interest_region_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInterestRegion") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_interest_region_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_interest_region_get_static_delegate) });
            }

            if (efl_ui_widget_focus_highlight_geometry_get_static_delegate == null)
            {
                efl_ui_widget_focus_highlight_geometry_get_static_delegate = new efl_ui_widget_focus_highlight_geometry_get_delegate(focus_highlight_geometry_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusHighlightGeometry") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_highlight_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_highlight_geometry_get_static_delegate) });
            }

            if (efl_ui_widget_focus_order_get_static_delegate == null)
            {
                efl_ui_widget_focus_order_get_static_delegate = new efl_ui_widget_focus_order_get_delegate(focus_order_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusOrder") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_order_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_order_get_static_delegate) });
            }

            if (efl_ui_widget_focus_custom_chain_get_static_delegate == null)
            {
                efl_ui_widget_focus_custom_chain_get_static_delegate = new efl_ui_widget_focus_custom_chain_get_delegate(focus_custom_chain_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusCustomChain") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_custom_chain_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_custom_chain_get_static_delegate) });
            }

            if (efl_ui_widget_focus_custom_chain_set_static_delegate == null)
            {
                efl_ui_widget_focus_custom_chain_set_static_delegate = new efl_ui_widget_focus_custom_chain_set_delegate(focus_custom_chain_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFocusCustomChain") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_custom_chain_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_custom_chain_set_static_delegate) });
            }

            if (efl_ui_widget_focused_object_get_static_delegate == null)
            {
                efl_ui_widget_focused_object_get_static_delegate = new efl_ui_widget_focused_object_get_delegate(focused_object_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusedObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focused_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focused_object_get_static_delegate) });
            }

            if (efl_ui_widget_focus_move_policy_get_static_delegate == null)
            {
                efl_ui_widget_focus_move_policy_get_static_delegate = new efl_ui_widget_focus_move_policy_get_delegate(focus_move_policy_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusMovePolicy") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_move_policy_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_move_policy_get_static_delegate) });
            }

            if (efl_ui_widget_focus_move_policy_set_static_delegate == null)
            {
                efl_ui_widget_focus_move_policy_set_static_delegate = new efl_ui_widget_focus_move_policy_set_delegate(focus_move_policy_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFocusMovePolicy") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_move_policy_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_move_policy_set_static_delegate) });
            }

            if (efl_ui_widget_focus_move_policy_automatic_get_static_delegate == null)
            {
                efl_ui_widget_focus_move_policy_automatic_get_static_delegate = new efl_ui_widget_focus_move_policy_automatic_get_delegate(focus_move_policy_automatic_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusMovePolicyAutomatic") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_move_policy_automatic_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_move_policy_automatic_get_static_delegate) });
            }

            if (efl_ui_widget_focus_move_policy_automatic_set_static_delegate == null)
            {
                efl_ui_widget_focus_move_policy_automatic_set_static_delegate = new efl_ui_widget_focus_move_policy_automatic_set_delegate(focus_move_policy_automatic_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFocusMovePolicyAutomatic") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_move_policy_automatic_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_move_policy_automatic_set_static_delegate) });
            }

            if (efl_ui_widget_input_event_handler_static_delegate == null)
            {
                efl_ui_widget_input_event_handler_static_delegate = new efl_ui_widget_input_event_handler_delegate(widget_input_event_handler);
            }

            if (methods.FirstOrDefault(m => m.Name == "WidgetInputEventHandler") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_input_event_handler"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_input_event_handler_static_delegate) });
            }

            if (efl_ui_widget_on_access_activate_static_delegate == null)
            {
                efl_ui_widget_on_access_activate_static_delegate = new efl_ui_widget_on_access_activate_delegate(on_access_activate);
            }

            if (methods.FirstOrDefault(m => m.Name == "OnAccessActivate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_on_access_activate"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_on_access_activate_static_delegate) });
            }

            if (efl_ui_widget_on_access_update_static_delegate == null)
            {
                efl_ui_widget_on_access_update_static_delegate = new efl_ui_widget_on_access_update_delegate(on_access_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateOnAccess") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_on_access_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_on_access_update_static_delegate) });
            }

            if (efl_ui_widget_screen_reader_static_delegate == null)
            {
                efl_ui_widget_screen_reader_static_delegate = new efl_ui_widget_screen_reader_delegate(screen_reader);
            }

            if (methods.FirstOrDefault(m => m.Name == "ScreenReader") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_screen_reader"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_screen_reader_static_delegate) });
            }

            if (efl_ui_widget_atspi_static_delegate == null)
            {
                efl_ui_widget_atspi_static_delegate = new efl_ui_widget_atspi_delegate(atspi);
            }

            if (methods.FirstOrDefault(m => m.Name == "Atspi") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_atspi"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_atspi_static_delegate) });
            }

            if (efl_ui_widget_sub_object_add_static_delegate == null)
            {
                efl_ui_widget_sub_object_add_static_delegate = new efl_ui_widget_sub_object_add_delegate(widget_sub_object_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddWidgetSubObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_sub_object_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_sub_object_add_static_delegate) });
            }

            if (efl_ui_widget_sub_object_del_static_delegate == null)
            {
                efl_ui_widget_sub_object_del_static_delegate = new efl_ui_widget_sub_object_del_delegate(widget_sub_object_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelWidgetSubObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_sub_object_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_sub_object_del_static_delegate) });
            }

            if (efl_ui_widget_theme_apply_static_delegate == null)
            {
                efl_ui_widget_theme_apply_static_delegate = new efl_ui_widget_theme_apply_delegate(theme_apply);
            }

            if (methods.FirstOrDefault(m => m.Name == "ThemeApply") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_theme_apply"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_theme_apply_static_delegate) });
            }

            if (efl_ui_widget_scroll_hold_push_static_delegate == null)
            {
                efl_ui_widget_scroll_hold_push_static_delegate = new efl_ui_widget_scroll_hold_push_delegate(scroll_hold_push);
            }

            if (methods.FirstOrDefault(m => m.Name == "PushScrollHold") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_scroll_hold_push"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scroll_hold_push_static_delegate) });
            }

            if (efl_ui_widget_scroll_hold_pop_static_delegate == null)
            {
                efl_ui_widget_scroll_hold_pop_static_delegate = new efl_ui_widget_scroll_hold_pop_delegate(scroll_hold_pop);
            }

            if (methods.FirstOrDefault(m => m.Name == "PopScrollHold") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_scroll_hold_pop"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scroll_hold_pop_static_delegate) });
            }

            if (efl_ui_widget_scroll_freeze_push_static_delegate == null)
            {
                efl_ui_widget_scroll_freeze_push_static_delegate = new efl_ui_widget_scroll_freeze_push_delegate(scroll_freeze_push);
            }

            if (methods.FirstOrDefault(m => m.Name == "PushScrollFreeze") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_scroll_freeze_push"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scroll_freeze_push_static_delegate) });
            }

            if (efl_ui_widget_scroll_freeze_pop_static_delegate == null)
            {
                efl_ui_widget_scroll_freeze_pop_static_delegate = new efl_ui_widget_scroll_freeze_pop_delegate(scroll_freeze_pop);
            }

            if (methods.FirstOrDefault(m => m.Name == "PopScrollFreeze") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_scroll_freeze_pop"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_scroll_freeze_pop_static_delegate) });
            }

            if (efl_ui_widget_part_access_object_get_static_delegate == null)
            {
                efl_ui_widget_part_access_object_get_static_delegate = new efl_ui_widget_part_access_object_get_delegate(part_access_object_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPartAccessObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_part_access_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_part_access_object_get_static_delegate) });
            }

            if (efl_ui_widget_newest_focus_order_get_static_delegate == null)
            {
                efl_ui_widget_newest_focus_order_get_static_delegate = new efl_ui_widget_newest_focus_order_get_delegate(newest_focus_order_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetNewestFocusOrder") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_newest_focus_order_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_newest_focus_order_get_static_delegate) });
            }

            if (efl_ui_widget_focus_next_object_set_static_delegate == null)
            {
                efl_ui_widget_focus_next_object_set_static_delegate = new efl_ui_widget_focus_next_object_set_delegate(focus_next_object_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFocusNextObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_next_object_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_object_set_static_delegate) });
            }

            if (efl_ui_widget_focus_next_object_get_static_delegate == null)
            {
                efl_ui_widget_focus_next_object_get_static_delegate = new efl_ui_widget_focus_next_object_get_delegate(focus_next_object_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusNextObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_next_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_object_get_static_delegate) });
            }

            if (efl_ui_widget_focus_next_item_set_static_delegate == null)
            {
                efl_ui_widget_focus_next_item_set_static_delegate = new efl_ui_widget_focus_next_item_set_delegate(focus_next_item_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFocusNextItem") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_next_item_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_item_set_static_delegate) });
            }

            if (efl_ui_widget_focus_next_item_get_static_delegate == null)
            {
                efl_ui_widget_focus_next_item_get_static_delegate = new efl_ui_widget_focus_next_item_get_delegate(focus_next_item_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusNextItem") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_next_item_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_item_get_static_delegate) });
            }

            if (efl_ui_widget_focus_tree_unfocusable_handle_static_delegate == null)
            {
                efl_ui_widget_focus_tree_unfocusable_handle_static_delegate = new efl_ui_widget_focus_tree_unfocusable_handle_delegate(focus_tree_unfocusable_handle);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusTreeUnfocusableHandle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_tree_unfocusable_handle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_tree_unfocusable_handle_static_delegate) });
            }

            if (efl_ui_widget_focus_custom_chain_prepend_static_delegate == null)
            {
                efl_ui_widget_focus_custom_chain_prepend_static_delegate = new efl_ui_widget_focus_custom_chain_prepend_delegate(focus_custom_chain_prepend);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusCustomChainPrepend") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_custom_chain_prepend"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_custom_chain_prepend_static_delegate) });
            }

            if (efl_ui_widget_focus_cycle_static_delegate == null)
            {
                efl_ui_widget_focus_cycle_static_delegate = new efl_ui_widget_focus_cycle_delegate(focus_cycle);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusCycle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_cycle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_cycle_static_delegate) });
            }

            if (efl_ui_widget_focus_direction_static_delegate == null)
            {
                efl_ui_widget_focus_direction_static_delegate = new efl_ui_widget_focus_direction_delegate(focus_direction);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusDirection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_direction"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_direction_static_delegate) });
            }

            if (efl_ui_widget_focus_next_manager_is_static_delegate == null)
            {
                efl_ui_widget_focus_next_manager_is_static_delegate = new efl_ui_widget_focus_next_manager_is_delegate(focus_next_manager_is);
            }

            if (methods.FirstOrDefault(m => m.Name == "IsFocusNextManager") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_next_manager_is"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_manager_is_static_delegate) });
            }

            if (efl_ui_widget_focus_list_direction_get_static_delegate == null)
            {
                efl_ui_widget_focus_list_direction_get_static_delegate = new efl_ui_widget_focus_list_direction_get_delegate(focus_list_direction_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusListDirection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_list_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_list_direction_get_static_delegate) });
            }

            if (efl_ui_widget_focused_object_clear_static_delegate == null)
            {
                efl_ui_widget_focused_object_clear_static_delegate = new efl_ui_widget_focused_object_clear_delegate(focused_object_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearFocusedObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focused_object_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focused_object_clear_static_delegate) });
            }

            if (efl_ui_widget_focus_direction_go_static_delegate == null)
            {
                efl_ui_widget_focus_direction_go_static_delegate = new efl_ui_widget_focus_direction_go_delegate(focus_direction_go);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusDirectionGo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_direction_go"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_direction_go_static_delegate) });
            }

            if (efl_ui_widget_focus_next_get_static_delegate == null)
            {
                efl_ui_widget_focus_next_get_static_delegate = new efl_ui_widget_focus_next_get_delegate(focus_next_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusNext") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_next_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_get_static_delegate) });
            }

            if (efl_ui_widget_focus_restore_static_delegate == null)
            {
                efl_ui_widget_focus_restore_static_delegate = new efl_ui_widget_focus_restore_delegate(focus_restore);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusRestore") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_restore"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_restore_static_delegate) });
            }

            if (efl_ui_widget_focus_custom_chain_unset_static_delegate == null)
            {
                efl_ui_widget_focus_custom_chain_unset_static_delegate = new efl_ui_widget_focus_custom_chain_unset_delegate(focus_custom_chain_unset);
            }

            if (methods.FirstOrDefault(m => m.Name == "UnsetFocusCustomChain") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_custom_chain_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_custom_chain_unset_static_delegate) });
            }

            if (efl_ui_widget_focus_steal_static_delegate == null)
            {
                efl_ui_widget_focus_steal_static_delegate = new efl_ui_widget_focus_steal_delegate(focus_steal);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusSteal") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_steal"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_steal_static_delegate) });
            }

            if (efl_ui_widget_focus_hide_handle_static_delegate == null)
            {
                efl_ui_widget_focus_hide_handle_static_delegate = new efl_ui_widget_focus_hide_handle_delegate(focus_hide_handle);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusHideHandle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_hide_handle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_hide_handle_static_delegate) });
            }

            if (efl_ui_widget_focus_next_static_delegate == null)
            {
                efl_ui_widget_focus_next_static_delegate = new efl_ui_widget_focus_next_delegate(focus_next);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusNext") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_next"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_next_static_delegate) });
            }

            if (efl_ui_widget_focus_list_next_get_static_delegate == null)
            {
                efl_ui_widget_focus_list_next_get_static_delegate = new efl_ui_widget_focus_list_next_get_delegate(focus_list_next_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusListNext") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_list_next_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_list_next_get_static_delegate) });
            }

            if (efl_ui_widget_focus_mouse_up_handle_static_delegate == null)
            {
                efl_ui_widget_focus_mouse_up_handle_static_delegate = new efl_ui_widget_focus_mouse_up_handle_delegate(focus_mouse_up_handle);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusMouseUpHandle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_mouse_up_handle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_mouse_up_handle_static_delegate) });
            }

            if (efl_ui_widget_focus_direction_get_static_delegate == null)
            {
                efl_ui_widget_focus_direction_get_static_delegate = new efl_ui_widget_focus_direction_get_delegate(focus_direction_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusDirection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_direction_get_static_delegate) });
            }

            if (efl_ui_widget_focus_disabled_handle_static_delegate == null)
            {
                efl_ui_widget_focus_disabled_handle_static_delegate = new efl_ui_widget_focus_disabled_handle_delegate(focus_disabled_handle);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusDisabledHandle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_disabled_handle"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_disabled_handle_static_delegate) });
            }

            if (efl_ui_widget_focus_custom_chain_append_static_delegate == null)
            {
                efl_ui_widget_focus_custom_chain_append_static_delegate = new efl_ui_widget_focus_custom_chain_append_delegate(focus_custom_chain_append);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendFocusCustomChain") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_custom_chain_append"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_custom_chain_append_static_delegate) });
            }

            if (efl_ui_widget_focus_reconfigure_static_delegate == null)
            {
                efl_ui_widget_focus_reconfigure_static_delegate = new efl_ui_widget_focus_reconfigure_delegate(focus_reconfigure);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusReconfigure") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_reconfigure"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_reconfigure_static_delegate) });
            }

            if (efl_ui_widget_focus_direction_manager_is_static_delegate == null)
            {
                efl_ui_widget_focus_direction_manager_is_static_delegate = new efl_ui_widget_focus_direction_manager_is_delegate(focus_direction_manager_is);
            }

            if (methods.FirstOrDefault(m => m.Name == "IsFocusDirectionManager") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_direction_manager_is"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_direction_manager_is_static_delegate) });
            }

            if (efl_ui_widget_focus_state_apply_static_delegate == null)
            {
                efl_ui_widget_focus_state_apply_static_delegate = new efl_ui_widget_focus_state_apply_delegate(focus_state_apply);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusStateApply") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_state_apply"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_state_apply_static_delegate) });
            }

            if (efl_part_get_static_delegate == null)
            {
                efl_part_get_static_delegate = new efl_part_get_delegate(part_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPart") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_part_get"), func = Marshal.GetFunctionPointerForDelegate(efl_part_get_static_delegate) });
            }

            if (efl_access_action_name_get_static_delegate == null)
            {
                efl_access_action_name_get_static_delegate = new efl_access_action_name_get_delegate(action_name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetActionName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_action_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_name_get_static_delegate) });
            }

            if (efl_access_action_localized_name_get_static_delegate == null)
            {
                efl_access_action_localized_name_get_static_delegate = new efl_access_action_localized_name_get_delegate(action_localized_name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetActionLocalizedName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_action_localized_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_localized_name_get_static_delegate) });
            }

            if (efl_access_action_actions_get_static_delegate == null)
            {
                efl_access_action_actions_get_static_delegate = new efl_access_action_actions_get_delegate(actions_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetActions") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_action_actions_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_actions_get_static_delegate) });
            }

            if (efl_access_action_do_static_delegate == null)
            {
                efl_access_action_do_static_delegate = new efl_access_action_do_delegate(action_do);
            }

            if (methods.FirstOrDefault(m => m.Name == "ActionDo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_action_do"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_do_static_delegate) });
            }

            if (efl_access_action_keybinding_get_static_delegate == null)
            {
                efl_access_action_keybinding_get_static_delegate = new efl_access_action_keybinding_get_delegate(action_keybinding_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetActionKeybinding") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_action_keybinding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_action_keybinding_get_static_delegate) });
            }

            if (efl_access_component_z_order_get_static_delegate == null)
            {
                efl_access_component_z_order_get_static_delegate = new efl_access_component_z_order_get_delegate(z_order_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetZOrder") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_z_order_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_z_order_get_static_delegate) });
            }

            if (efl_access_component_extents_get_static_delegate == null)
            {
                efl_access_component_extents_get_static_delegate = new efl_access_component_extents_get_delegate(extents_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetExtents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_extents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_extents_get_static_delegate) });
            }

            if (efl_access_component_extents_set_static_delegate == null)
            {
                efl_access_component_extents_set_static_delegate = new efl_access_component_extents_set_delegate(extents_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetExtents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_extents_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_extents_set_static_delegate) });
            }

            if (efl_access_component_screen_position_get_static_delegate == null)
            {
                efl_access_component_screen_position_get_static_delegate = new efl_access_component_screen_position_get_delegate(screen_position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScreenPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_screen_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_screen_position_get_static_delegate) });
            }

            if (efl_access_component_screen_position_set_static_delegate == null)
            {
                efl_access_component_screen_position_set_static_delegate = new efl_access_component_screen_position_set_delegate(screen_position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScreenPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_screen_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_screen_position_set_static_delegate) });
            }

            if (efl_access_component_socket_offset_get_static_delegate == null)
            {
                efl_access_component_socket_offset_get_static_delegate = new efl_access_component_socket_offset_get_delegate(socket_offset_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSocketOffset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_socket_offset_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_socket_offset_get_static_delegate) });
            }

            if (efl_access_component_socket_offset_set_static_delegate == null)
            {
                efl_access_component_socket_offset_set_static_delegate = new efl_access_component_socket_offset_set_delegate(socket_offset_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSocketOffset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_socket_offset_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_socket_offset_set_static_delegate) });
            }

            if (efl_access_component_contains_static_delegate == null)
            {
                efl_access_component_contains_static_delegate = new efl_access_component_contains_delegate(contains);
            }

            if (methods.FirstOrDefault(m => m.Name == "Contains") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_contains"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_contains_static_delegate) });
            }

            if (efl_access_component_focus_grab_static_delegate == null)
            {
                efl_access_component_focus_grab_static_delegate = new efl_access_component_focus_grab_delegate(focus_grab);
            }

            if (methods.FirstOrDefault(m => m.Name == "GrabFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_focus_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_focus_grab_static_delegate) });
            }

            if (efl_access_component_accessible_at_point_get_static_delegate == null)
            {
                efl_access_component_accessible_at_point_get_static_delegate = new efl_access_component_accessible_at_point_get_delegate(accessible_at_point_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAccessibleAtPoint") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_accessible_at_point_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_accessible_at_point_get_static_delegate) });
            }

            if (efl_access_component_highlight_grab_static_delegate == null)
            {
                efl_access_component_highlight_grab_static_delegate = new efl_access_component_highlight_grab_delegate(highlight_grab);
            }

            if (methods.FirstOrDefault(m => m.Name == "GrabHighlight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_highlight_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_highlight_grab_static_delegate) });
            }

            if (efl_access_component_highlight_clear_static_delegate == null)
            {
                efl_access_component_highlight_clear_static_delegate = new efl_access_component_highlight_clear_delegate(highlight_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearHighlight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_component_highlight_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_component_highlight_clear_static_delegate) });
            }

            if (efl_access_object_localized_role_name_get_static_delegate == null)
            {
                efl_access_object_localized_role_name_get_static_delegate = new efl_access_object_localized_role_name_get_delegate(localized_role_name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLocalizedRoleName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_localized_role_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_localized_role_name_get_static_delegate) });
            }

            if (efl_access_object_i18n_name_get_static_delegate == null)
            {
                efl_access_object_i18n_name_get_static_delegate = new efl_access_object_i18n_name_get_delegate(i18n_name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetI18nName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_i18n_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_i18n_name_get_static_delegate) });
            }

            if (efl_access_object_i18n_name_set_static_delegate == null)
            {
                efl_access_object_i18n_name_set_static_delegate = new efl_access_object_i18n_name_set_delegate(i18n_name_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetI18nName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_i18n_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_i18n_name_set_static_delegate) });
            }

            if (efl_access_object_name_cb_set_static_delegate == null)
            {
                efl_access_object_name_cb_set_static_delegate = new efl_access_object_name_cb_set_delegate(name_cb_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetNameCb") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_name_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_name_cb_set_static_delegate) });
            }

            if (efl_access_object_relation_set_get_static_delegate == null)
            {
                efl_access_object_relation_set_get_static_delegate = new efl_access_object_relation_set_get_delegate(relation_set_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRelationSet") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_relation_set_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relation_set_get_static_delegate) });
            }

            if (efl_access_object_role_get_static_delegate == null)
            {
                efl_access_object_role_get_static_delegate = new efl_access_object_role_get_delegate(role_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRole") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_role_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_get_static_delegate) });
            }

            if (efl_access_object_role_set_static_delegate == null)
            {
                efl_access_object_role_set_static_delegate = new efl_access_object_role_set_delegate(role_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRole") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_role_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_set_static_delegate) });
            }

            if (efl_access_object_access_parent_get_static_delegate == null)
            {
                efl_access_object_access_parent_get_static_delegate = new efl_access_object_access_parent_get_delegate(access_parent_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAccessParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_access_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_parent_get_static_delegate) });
            }

            if (efl_access_object_access_parent_set_static_delegate == null)
            {
                efl_access_object_access_parent_set_static_delegate = new efl_access_object_access_parent_set_delegate(access_parent_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAccessParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_access_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_parent_set_static_delegate) });
            }

            if (efl_access_object_description_cb_set_static_delegate == null)
            {
                efl_access_object_description_cb_set_static_delegate = new efl_access_object_description_cb_set_delegate(description_cb_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDescriptionCb") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_description_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_cb_set_static_delegate) });
            }

            if (efl_access_object_gesture_cb_set_static_delegate == null)
            {
                efl_access_object_gesture_cb_set_static_delegate = new efl_access_object_gesture_cb_set_delegate(gesture_cb_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetGestureCb") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_gesture_cb_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_gesture_cb_set_static_delegate) });
            }

            if (efl_access_object_access_children_get_static_delegate == null)
            {
                efl_access_object_access_children_get_static_delegate = new efl_access_object_access_children_get_delegate(access_children_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAccessChildren") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_access_children_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_access_children_get_static_delegate) });
            }

            if (efl_access_object_role_name_get_static_delegate == null)
            {
                efl_access_object_role_name_get_static_delegate = new efl_access_object_role_name_get_delegate(role_name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRoleName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_role_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_role_name_get_static_delegate) });
            }

            if (efl_access_object_attributes_get_static_delegate == null)
            {
                efl_access_object_attributes_get_static_delegate = new efl_access_object_attributes_get_delegate(attributes_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAttributes") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_attributes_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attributes_get_static_delegate) });
            }

            if (efl_access_object_reading_info_type_get_static_delegate == null)
            {
                efl_access_object_reading_info_type_get_static_delegate = new efl_access_object_reading_info_type_get_delegate(reading_info_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetReadingInfoType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_reading_info_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_reading_info_type_get_static_delegate) });
            }

            if (efl_access_object_reading_info_type_set_static_delegate == null)
            {
                efl_access_object_reading_info_type_set_static_delegate = new efl_access_object_reading_info_type_set_delegate(reading_info_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetReadingInfoType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_reading_info_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_reading_info_type_set_static_delegate) });
            }

            if (efl_access_object_index_in_parent_get_static_delegate == null)
            {
                efl_access_object_index_in_parent_get_static_delegate = new efl_access_object_index_in_parent_get_delegate(index_in_parent_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIndexInParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_index_in_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_index_in_parent_get_static_delegate) });
            }

            if (efl_access_object_description_get_static_delegate == null)
            {
                efl_access_object_description_get_static_delegate = new efl_access_object_description_get_delegate(description_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDescription") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_description_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_get_static_delegate) });
            }

            if (efl_access_object_description_set_static_delegate == null)
            {
                efl_access_object_description_set_static_delegate = new efl_access_object_description_set_delegate(description_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDescription") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_description_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_description_set_static_delegate) });
            }

            if (efl_access_object_state_set_get_static_delegate == null)
            {
                efl_access_object_state_set_get_static_delegate = new efl_access_object_state_set_get_delegate(state_set_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStateSet") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_state_set_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_state_set_get_static_delegate) });
            }

            if (efl_access_object_can_highlight_get_static_delegate == null)
            {
                efl_access_object_can_highlight_get_static_delegate = new efl_access_object_can_highlight_get_delegate(can_highlight_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCanHighlight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_can_highlight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_can_highlight_get_static_delegate) });
            }

            if (efl_access_object_can_highlight_set_static_delegate == null)
            {
                efl_access_object_can_highlight_set_static_delegate = new efl_access_object_can_highlight_set_delegate(can_highlight_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCanHighlight") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_can_highlight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_can_highlight_set_static_delegate) });
            }

            if (efl_access_object_translation_domain_get_static_delegate == null)
            {
                efl_access_object_translation_domain_get_static_delegate = new efl_access_object_translation_domain_get_delegate(translation_domain_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTranslationDomain") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_translation_domain_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_translation_domain_get_static_delegate) });
            }

            if (efl_access_object_translation_domain_set_static_delegate == null)
            {
                efl_access_object_translation_domain_set_static_delegate = new efl_access_object_translation_domain_set_delegate(translation_domain_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTranslationDomain") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_translation_domain_set"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_translation_domain_set_static_delegate) });
            }

            if (efl_access_object_gesture_do_static_delegate == null)
            {
                efl_access_object_gesture_do_static_delegate = new efl_access_object_gesture_do_delegate(gesture_do);
            }

            if (methods.FirstOrDefault(m => m.Name == "GestureDo") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_gesture_do"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_gesture_do_static_delegate) });
            }

            if (efl_access_object_attribute_append_static_delegate == null)
            {
                efl_access_object_attribute_append_static_delegate = new efl_access_object_attribute_append_delegate(attribute_append);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendAttribute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_attribute_append"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attribute_append_static_delegate) });
            }

            if (efl_access_object_attribute_del_static_delegate == null)
            {
                efl_access_object_attribute_del_static_delegate = new efl_access_object_attribute_del_delegate(attribute_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelAttribute") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_attribute_del"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attribute_del_static_delegate) });
            }

            if (efl_access_object_attributes_clear_static_delegate == null)
            {
                efl_access_object_attributes_clear_static_delegate = new efl_access_object_attributes_clear_delegate(attributes_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearAttributes") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_attributes_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_attributes_clear_static_delegate) });
            }

            if (efl_access_object_relationship_append_static_delegate == null)
            {
                efl_access_object_relationship_append_static_delegate = new efl_access_object_relationship_append_delegate(relationship_append);
            }

            if (methods.FirstOrDefault(m => m.Name == "AppendRelationship") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_relationship_append"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationship_append_static_delegate) });
            }

            if (efl_access_object_relationship_remove_static_delegate == null)
            {
                efl_access_object_relationship_remove_static_delegate = new efl_access_object_relationship_remove_delegate(relationship_remove);
            }

            if (methods.FirstOrDefault(m => m.Name == "RelationshipRemove") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_relationship_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationship_remove_static_delegate) });
            }

            if (efl_access_object_relationships_clear_static_delegate == null)
            {
                efl_access_object_relationships_clear_static_delegate = new efl_access_object_relationships_clear_delegate(relationships_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearRelationships") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_relationships_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_relationships_clear_static_delegate) });
            }

            if (efl_access_object_state_notify_static_delegate == null)
            {
                efl_access_object_state_notify_static_delegate = new efl_access_object_state_notify_delegate(state_notify);
            }

            if (methods.FirstOrDefault(m => m.Name == "StateNotify") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_object_state_notify"), func = Marshal.GetFunctionPointerForDelegate(efl_access_object_state_notify_static_delegate) });
            }

            if (efl_access_widget_action_elm_actions_get_static_delegate == null)
            {
                efl_access_widget_action_elm_actions_get_static_delegate = new efl_access_widget_action_elm_actions_get_delegate(elm_actions_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetElmActions") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_access_widget_action_elm_actions_get"), func = Marshal.GetFunctionPointerForDelegate(efl_access_widget_action_elm_actions_get_static_delegate) });
            }

            if (efl_ui_dnd_drag_start_static_delegate == null)
            {
                efl_ui_dnd_drag_start_static_delegate = new efl_ui_dnd_drag_start_delegate(drag_start);
            }

            if (methods.FirstOrDefault(m => m.Name == "DragStart") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_drag_start"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drag_start_static_delegate) });
            }

            if (efl_ui_dnd_drag_action_set_static_delegate == null)
            {
                efl_ui_dnd_drag_action_set_static_delegate = new efl_ui_dnd_drag_action_set_delegate(drag_action_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDragAction") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_drag_action_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drag_action_set_static_delegate) });
            }

            if (efl_ui_dnd_drag_cancel_static_delegate == null)
            {
                efl_ui_dnd_drag_cancel_static_delegate = new efl_ui_dnd_drag_cancel_delegate(drag_cancel);
            }

            if (methods.FirstOrDefault(m => m.Name == "DragCancel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_drag_cancel"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drag_cancel_static_delegate) });
            }

            if (efl_ui_dnd_drop_target_add_static_delegate == null)
            {
                efl_ui_dnd_drop_target_add_static_delegate = new efl_ui_dnd_drop_target_add_delegate(drop_target_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddDropTarget") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_drop_target_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drop_target_add_static_delegate) });
            }

            if (efl_ui_dnd_drop_target_del_static_delegate == null)
            {
                efl_ui_dnd_drop_target_del_static_delegate = new efl_ui_dnd_drop_target_del_delegate(drop_target_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelDropTarget") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_dnd_drop_target_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_dnd_drop_target_del_static_delegate) });
            }

            if (efl_ui_l10n_text_get_static_delegate == null)
            {
                efl_ui_l10n_text_get_static_delegate = new efl_ui_l10n_text_get_delegate(l10n_text_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetL10nText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_l10n_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_l10n_text_get_static_delegate) });
            }

            if (efl_ui_l10n_text_set_static_delegate == null)
            {
                efl_ui_l10n_text_set_static_delegate = new efl_ui_l10n_text_set_delegate(l10n_text_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetL10nText") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_l10n_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_l10n_text_set_static_delegate) });
            }

            if (efl_ui_l10n_translation_update_static_delegate == null)
            {
                efl_ui_l10n_translation_update_static_delegate = new efl_ui_l10n_translation_update_delegate(translation_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateTranslation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_l10n_translation_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_l10n_translation_update_static_delegate) });
            }

            if (efl_ui_property_bind_static_delegate == null)
            {
                efl_ui_property_bind_static_delegate = new efl_ui_property_bind_delegate(property_bind);
            }

            if (methods.FirstOrDefault(m => m.Name == "PropertyBind") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_property_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_property_bind_static_delegate) });
            }

            if (efl_ui_selection_set_static_delegate == null)
            {
                efl_ui_selection_set_static_delegate = new efl_ui_selection_set_delegate(selection_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selection_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_set_static_delegate) });
            }

            if (efl_ui_selection_get_static_delegate == null)
            {
                efl_ui_selection_get_static_delegate = new efl_ui_selection_get_delegate(selection_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selection_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_get_static_delegate) });
            }

            if (efl_ui_selection_clear_static_delegate == null)
            {
                efl_ui_selection_clear_static_delegate = new efl_ui_selection_clear_delegate(selection_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearSelection") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selection_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_clear_static_delegate) });
            }

            if (efl_ui_selection_has_owner_static_delegate == null)
            {
                efl_ui_selection_has_owner_static_delegate = new efl_ui_selection_has_owner_delegate(has_owner);
            }

            if (methods.FirstOrDefault(m => m.Name == "HasOwner") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selection_has_owner"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selection_has_owner_static_delegate) });
            }

            if (efl_ui_view_model_get_static_delegate == null)
            {
                efl_ui_view_model_get_static_delegate = new efl_ui_view_model_get_delegate(model_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetModel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_view_model_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_get_static_delegate) });
            }

            if (efl_ui_view_model_set_static_delegate == null)
            {
                efl_ui_view_model_set_static_delegate = new efl_ui_view_model_set_delegate(model_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetModel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_view_model_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_set_static_delegate) });
            }

            if (efl_ui_focus_object_focus_geometry_get_static_delegate == null)
            {
                efl_ui_focus_object_focus_geometry_get_static_delegate = new efl_ui_focus_object_focus_geometry_get_delegate(focus_geometry_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusGeometry") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_object_focus_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_geometry_get_static_delegate) });
            }

            if (efl_ui_focus_object_focus_get_static_delegate == null)
            {
                efl_ui_focus_object_focus_get_static_delegate = new efl_ui_focus_object_focus_get_delegate(focus_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_object_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_get_static_delegate) });
            }

            if (efl_ui_focus_object_focus_set_static_delegate == null)
            {
                efl_ui_focus_object_focus_set_static_delegate = new efl_ui_focus_object_focus_set_delegate(focus_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_object_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_set_static_delegate) });
            }

            if (efl_ui_focus_object_focus_manager_get_static_delegate == null)
            {
                efl_ui_focus_object_focus_manager_get_static_delegate = new efl_ui_focus_object_focus_manager_get_delegate(focus_manager_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusManager") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_object_focus_manager_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_manager_get_static_delegate) });
            }

            if (efl_ui_focus_object_focus_parent_get_static_delegate == null)
            {
                efl_ui_focus_object_focus_parent_get_static_delegate = new efl_ui_focus_object_focus_parent_get_delegate(focus_parent_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFocusParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_object_focus_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_focus_parent_get_static_delegate) });
            }

            if (efl_ui_focus_object_child_focus_get_static_delegate == null)
            {
                efl_ui_focus_object_child_focus_get_static_delegate = new efl_ui_focus_object_child_focus_get_delegate(child_focus_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetChildFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_object_child_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_child_focus_get_static_delegate) });
            }

            if (efl_ui_focus_object_child_focus_set_static_delegate == null)
            {
                efl_ui_focus_object_child_focus_set_static_delegate = new efl_ui_focus_object_child_focus_set_delegate(child_focus_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetChildFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_object_child_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_child_focus_set_static_delegate) });
            }

            if (efl_ui_focus_object_setup_order_static_delegate == null)
            {
                efl_ui_focus_object_setup_order_static_delegate = new efl_ui_focus_object_setup_order_delegate(setup_order);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetupOrder") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_object_setup_order"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_setup_order_static_delegate) });
            }

            if (efl_ui_focus_object_setup_order_non_recursive_static_delegate == null)
            {
                efl_ui_focus_object_setup_order_non_recursive_static_delegate = new efl_ui_focus_object_setup_order_non_recursive_delegate(setup_order_non_recursive);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetupOrderNonRecursive") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_object_setup_order_non_recursive"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_setup_order_non_recursive_static_delegate) });
            }

            if (efl_ui_focus_object_on_focus_update_static_delegate == null)
            {
                efl_ui_focus_object_on_focus_update_static_delegate = new efl_ui_focus_object_on_focus_update_delegate(on_focus_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateOnFocus") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_object_on_focus_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_on_focus_update_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Widget.efl_ui_widget_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_widget_cursor_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_widget_cursor_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_cursor_get_api_delegate> efl_ui_widget_cursor_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_cursor_get_api_delegate>(Module, "efl_ui_widget_cursor_get");

        private static System.String cursor_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_cursor_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetCursor();
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
                return efl_ui_widget_cursor_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_cursor_get_delegate efl_ui_widget_cursor_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_cursor_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String cursor);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_cursor_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String cursor);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_cursor_set_api_delegate> efl_ui_widget_cursor_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_cursor_set_api_delegate>(Module, "efl_ui_widget_cursor_set");

        private static bool cursor_set(System.IntPtr obj, System.IntPtr pd, System.String cursor)
        {
            Eina.Log.Debug("function efl_ui_widget_cursor_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).SetCursor(cursor);
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
                return efl_ui_widget_cursor_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cursor);
            }
        }

        private static efl_ui_widget_cursor_set_delegate efl_ui_widget_cursor_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_widget_cursor_style_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_widget_cursor_style_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_cursor_style_get_api_delegate> efl_ui_widget_cursor_style_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_cursor_style_get_api_delegate>(Module, "efl_ui_widget_cursor_style_get");

        private static System.String cursor_style_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_cursor_style_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetCursorStyle();
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
                return efl_ui_widget_cursor_style_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_cursor_style_get_delegate efl_ui_widget_cursor_style_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_cursor_style_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String style);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_cursor_style_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String style);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_cursor_style_set_api_delegate> efl_ui_widget_cursor_style_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_cursor_style_set_api_delegate>(Module, "efl_ui_widget_cursor_style_set");

        private static bool cursor_style_set(System.IntPtr obj, System.IntPtr pd, System.String style)
        {
            Eina.Log.Debug("function efl_ui_widget_cursor_style_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).SetCursorStyle(style);
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
                return efl_ui_widget_cursor_style_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), style);
            }
        }

        private static efl_ui_widget_cursor_style_set_delegate efl_ui_widget_cursor_style_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_cursor_theme_search_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_cursor_theme_search_enabled_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_cursor_theme_search_enabled_get_api_delegate> efl_ui_widget_cursor_theme_search_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_cursor_theme_search_enabled_get_api_delegate>(Module, "efl_ui_widget_cursor_theme_search_enabled_get");

        private static bool cursor_theme_search_enabled_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_cursor_theme_search_enabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetCursorThemeSearchEnabled();
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
                return efl_ui_widget_cursor_theme_search_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_cursor_theme_search_enabled_get_delegate efl_ui_widget_cursor_theme_search_enabled_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_cursor_theme_search_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool allow);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_cursor_theme_search_enabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool allow);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_cursor_theme_search_enabled_set_api_delegate> efl_ui_widget_cursor_theme_search_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_cursor_theme_search_enabled_set_api_delegate>(Module, "efl_ui_widget_cursor_theme_search_enabled_set");

        private static bool cursor_theme_search_enabled_set(System.IntPtr obj, System.IntPtr pd, bool allow)
        {
            Eina.Log.Debug("function efl_ui_widget_cursor_theme_search_enabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).SetCursorThemeSearchEnabled(allow);
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
                return efl_ui_widget_cursor_theme_search_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), allow);
            }
        }

        private static efl_ui_widget_cursor_theme_search_enabled_set_delegate efl_ui_widget_cursor_theme_search_enabled_set_static_delegate;

        
        private delegate void efl_ui_widget_resize_object_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object sobj);

        
        public delegate void efl_ui_widget_resize_object_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object sobj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_resize_object_set_api_delegate> efl_ui_widget_resize_object_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_resize_object_set_api_delegate>(Module, "efl_ui_widget_resize_object_set");

        private static void resize_object_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object sobj)
        {
            Eina.Log.Debug("function efl_ui_widget_resize_object_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetResizeObject(sobj);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_resize_object_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sobj);
            }
        }

        private static efl_ui_widget_resize_object_set_delegate efl_ui_widget_resize_object_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_disabled_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_disabled_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_disabled_get_api_delegate> efl_ui_widget_disabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_disabled_get_api_delegate>(Module, "efl_ui_widget_disabled_get");

        private static bool disabled_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_disabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetDisabled();
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
                return efl_ui_widget_disabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_disabled_get_delegate efl_ui_widget_disabled_get_static_delegate;

        
        private delegate void efl_ui_widget_disabled_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool disabled);

        
        public delegate void efl_ui_widget_disabled_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool disabled);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_disabled_set_api_delegate> efl_ui_widget_disabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_disabled_set_api_delegate>(Module, "efl_ui_widget_disabled_set");

        private static void disabled_set(System.IntPtr obj, System.IntPtr pd, bool disabled)
        {
            Eina.Log.Debug("function efl_ui_widget_disabled_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetDisabled(disabled);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_disabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), disabled);
            }
        }

        private static efl_ui_widget_disabled_set_delegate efl_ui_widget_disabled_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_widget_style_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_widget_style_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_style_get_api_delegate> efl_ui_widget_style_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_style_get_api_delegate>(Module, "efl_ui_widget_style_get");

        private static System.String style_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_style_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetStyle();
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
                return efl_ui_widget_style_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_style_get_delegate efl_ui_widget_style_get_static_delegate;

        
        private delegate Eina.Error efl_ui_widget_style_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String style);

        
        public delegate Eina.Error efl_ui_widget_style_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String style);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_style_set_api_delegate> efl_ui_widget_style_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_style_set_api_delegate>(Module, "efl_ui_widget_style_set");

        private static Eina.Error style_set(System.IntPtr obj, System.IntPtr pd, System.String style)
        {
            Eina.Log.Debug("function efl_ui_widget_style_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((Widget)ws.Target).SetStyle(style);
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
                return efl_ui_widget_style_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), style);
            }
        }

        private static efl_ui_widget_style_set_delegate efl_ui_widget_style_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_focus_allow_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_focus_allow_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_allow_get_api_delegate> efl_ui_widget_focus_allow_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_allow_get_api_delegate>(Module, "efl_ui_widget_focus_allow_get");

        private static bool focus_allow_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_allow_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusAllow();
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
                return efl_ui_widget_focus_allow_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_allow_get_delegate efl_ui_widget_focus_allow_get_static_delegate;

        
        private delegate void efl_ui_widget_focus_allow_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool can_focus);

        
        public delegate void efl_ui_widget_focus_allow_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool can_focus);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_allow_set_api_delegate> efl_ui_widget_focus_allow_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_allow_set_api_delegate>(Module, "efl_ui_widget_focus_allow_set");

        private static void focus_allow_set(System.IntPtr obj, System.IntPtr pd, bool can_focus)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_allow_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetFocusAllow(can_focus);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_focus_allow_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), can_focus);
            }
        }

        private static efl_ui_widget_focus_allow_set_delegate efl_ui_widget_focus_allow_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Widget efl_ui_widget_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Widget efl_ui_widget_parent_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_parent_get_api_delegate> efl_ui_widget_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_parent_get_api_delegate>(Module, "efl_ui_widget_parent_get");

        private static Efl.Ui.Widget widget_parent_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_parent_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.Widget _ret_var = default(Efl.Ui.Widget);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetWidgetParent();
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
                return efl_ui_widget_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_parent_get_delegate efl_ui_widget_parent_get_static_delegate;

        
        private delegate void efl_ui_widget_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Widget parent);

        
        public delegate void efl_ui_widget_parent_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Widget parent);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_parent_set_api_delegate> efl_ui_widget_parent_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_parent_set_api_delegate>(Module, "efl_ui_widget_parent_set");

        private static void widget_parent_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Widget parent)
        {
            Eina.Log.Debug("function efl_ui_widget_parent_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetWidgetParent(parent);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_parent_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), parent);
            }
        }

        private static efl_ui_widget_parent_set_delegate efl_ui_widget_parent_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_widget_access_info_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_widget_access_info_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_access_info_get_api_delegate> efl_ui_widget_access_info_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_access_info_get_api_delegate>(Module, "efl_ui_widget_access_info_get");

        private static System.String access_info_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_access_info_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetAccessInfo();
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
                return efl_ui_widget_access_info_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_access_info_get_delegate efl_ui_widget_access_info_get_static_delegate;

        
        private delegate void efl_ui_widget_access_info_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String txt);

        
        public delegate void efl_ui_widget_access_info_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String txt);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_access_info_set_api_delegate> efl_ui_widget_access_info_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_access_info_set_api_delegate>(Module, "efl_ui_widget_access_info_set");

        private static void access_info_set(System.IntPtr obj, System.IntPtr pd, System.String txt)
        {
            Eina.Log.Debug("function efl_ui_widget_access_info_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetAccessInfo(txt);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_access_info_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), txt);
            }
        }

        private static efl_ui_widget_access_info_set_delegate efl_ui_widget_access_info_set_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_ui_widget_interest_region_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_ui_widget_interest_region_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_interest_region_get_api_delegate> efl_ui_widget_interest_region_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_interest_region_get_api_delegate>(Module, "efl_ui_widget_interest_region_get");

        private static Eina.Rect.NativeStruct interest_region_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_interest_region_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetInterestRegion();
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
                return efl_ui_widget_interest_region_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_interest_region_get_delegate efl_ui_widget_interest_region_get_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_ui_widget_focus_highlight_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_ui_widget_focus_highlight_geometry_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_highlight_geometry_get_api_delegate> efl_ui_widget_focus_highlight_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_highlight_geometry_get_api_delegate>(Module, "efl_ui_widget_focus_highlight_geometry_get");

        private static Eina.Rect.NativeStruct focus_highlight_geometry_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_highlight_geometry_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusHighlightGeometry();
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
                return efl_ui_widget_focus_highlight_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_highlight_geometry_get_delegate efl_ui_widget_focus_highlight_geometry_get_static_delegate;

        
        private delegate uint efl_ui_widget_focus_order_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_ui_widget_focus_order_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_order_get_api_delegate> efl_ui_widget_focus_order_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_order_get_api_delegate>(Module, "efl_ui_widget_focus_order_get");

        private static uint focus_order_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_order_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusOrder();
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
                return efl_ui_widget_focus_order_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_order_get_delegate efl_ui_widget_focus_order_get_static_delegate;

        
        private delegate System.IntPtr efl_ui_widget_focus_custom_chain_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_widget_focus_custom_chain_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_custom_chain_get_api_delegate> efl_ui_widget_focus_custom_chain_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_custom_chain_get_api_delegate>(Module, "efl_ui_widget_focus_custom_chain_get");

        private static System.IntPtr focus_custom_chain_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_custom_chain_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.List<Efl.Canvas.Object> _ret_var = default(Eina.List<Efl.Canvas.Object>);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusCustomChain();
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
                return efl_ui_widget_focus_custom_chain_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_custom_chain_get_delegate efl_ui_widget_focus_custom_chain_get_static_delegate;

        
        private delegate void efl_ui_widget_focus_custom_chain_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr objs);

        
        public delegate void efl_ui_widget_focus_custom_chain_set_api_delegate(System.IntPtr obj,  System.IntPtr objs);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_custom_chain_set_api_delegate> efl_ui_widget_focus_custom_chain_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_custom_chain_set_api_delegate>(Module, "efl_ui_widget_focus_custom_chain_set");

        private static void focus_custom_chain_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr objs)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_custom_chain_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_objs = new Eina.List<Efl.Canvas.Object>(objs, false, false);
                            
                try
                {
                    ((Widget)ws.Target).SetFocusCustomChain(_in_objs);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_focus_custom_chain_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), objs);
            }
        }

        private static efl_ui_widget_focus_custom_chain_set_delegate efl_ui_widget_focus_custom_chain_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_ui_widget_focused_object_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_ui_widget_focused_object_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focused_object_get_api_delegate> efl_ui_widget_focused_object_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focused_object_get_api_delegate>(Module, "efl_ui_widget_focused_object_get");

        private static Efl.Canvas.Object focused_object_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focused_object_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusedObject();
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
                return efl_ui_widget_focused_object_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focused_object_get_delegate efl_ui_widget_focused_object_get_static_delegate;

        
        private delegate Efl.Ui.Focus.MovePolicy efl_ui_widget_focus_move_policy_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.Focus.MovePolicy efl_ui_widget_focus_move_policy_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_move_policy_get_api_delegate> efl_ui_widget_focus_move_policy_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_move_policy_get_api_delegate>(Module, "efl_ui_widget_focus_move_policy_get");

        private static Efl.Ui.Focus.MovePolicy focus_move_policy_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_move_policy_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.Focus.MovePolicy _ret_var = default(Efl.Ui.Focus.MovePolicy);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusMovePolicy();
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
                return efl_ui_widget_focus_move_policy_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_move_policy_get_delegate efl_ui_widget_focus_move_policy_get_static_delegate;

        
        private delegate void efl_ui_widget_focus_move_policy_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.MovePolicy policy);

        
        public delegate void efl_ui_widget_focus_move_policy_set_api_delegate(System.IntPtr obj,  Efl.Ui.Focus.MovePolicy policy);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_move_policy_set_api_delegate> efl_ui_widget_focus_move_policy_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_move_policy_set_api_delegate>(Module, "efl_ui_widget_focus_move_policy_set");

        private static void focus_move_policy_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.MovePolicy policy)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_move_policy_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetFocusMovePolicy(policy);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_focus_move_policy_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), policy);
            }
        }

        private static efl_ui_widget_focus_move_policy_set_delegate efl_ui_widget_focus_move_policy_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_focus_move_policy_automatic_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_focus_move_policy_automatic_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_move_policy_automatic_get_api_delegate> efl_ui_widget_focus_move_policy_automatic_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_move_policy_automatic_get_api_delegate>(Module, "efl_ui_widget_focus_move_policy_automatic_get");

        private static bool focus_move_policy_automatic_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_move_policy_automatic_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusMovePolicyAutomatic();
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
                return efl_ui_widget_focus_move_policy_automatic_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_move_policy_automatic_get_delegate efl_ui_widget_focus_move_policy_automatic_get_static_delegate;

        
        private delegate void efl_ui_widget_focus_move_policy_automatic_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool automatic);

        
        public delegate void efl_ui_widget_focus_move_policy_automatic_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool automatic);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_move_policy_automatic_set_api_delegate> efl_ui_widget_focus_move_policy_automatic_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_move_policy_automatic_set_api_delegate>(Module, "efl_ui_widget_focus_move_policy_automatic_set");

        private static void focus_move_policy_automatic_set(System.IntPtr obj, System.IntPtr pd, bool automatic)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_move_policy_automatic_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetFocusMovePolicyAutomatic(automatic);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_focus_move_policy_automatic_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), automatic);
            }
        }

        private static efl_ui_widget_focus_move_policy_automatic_set_delegate efl_ui_widget_focus_move_policy_automatic_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_input_event_handler_delegate(System.IntPtr obj, System.IntPtr pd,  ref Efl.Event.NativeStruct eo_event, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object source);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_input_event_handler_api_delegate(System.IntPtr obj,  ref Efl.Event.NativeStruct eo_event, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object source);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_input_event_handler_api_delegate> efl_ui_widget_input_event_handler_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_input_event_handler_api_delegate>(Module, "efl_ui_widget_input_event_handler");

        private static bool widget_input_event_handler(System.IntPtr obj, System.IntPtr pd, ref Efl.Event.NativeStruct eo_event, Efl.Canvas.Object source)
        {
            Eina.Log.Debug("function efl_ui_widget_input_event_handler was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Event _in_eo_event = eo_event;
                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).WidgetInputEventHandler(ref _in_eo_event, source);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        eo_event = _in_eo_event;
                return _ret_var;

            }
            else
            {
                return efl_ui_widget_input_event_handler_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ref eo_event, source);
            }
        }

        private static efl_ui_widget_input_event_handler_delegate efl_ui_widget_input_event_handler_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_on_access_activate_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Activate act);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_on_access_activate_api_delegate(System.IntPtr obj,  Efl.Ui.Activate act);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_on_access_activate_api_delegate> efl_ui_widget_on_access_activate_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_on_access_activate_api_delegate>(Module, "efl_ui_widget_on_access_activate");

        private static bool on_access_activate(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Activate act)
        {
            Eina.Log.Debug("function efl_ui_widget_on_access_activate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).OnAccessActivate(act);
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
                return efl_ui_widget_on_access_activate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), act);
            }
        }

        private static efl_ui_widget_on_access_activate_delegate efl_ui_widget_on_access_activate_static_delegate;

        
        private delegate void efl_ui_widget_on_access_update_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

        
        public delegate void efl_ui_widget_on_access_update_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_on_access_update_api_delegate> efl_ui_widget_on_access_update_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_on_access_update_api_delegate>(Module, "efl_ui_widget_on_access_update");

        private static void on_access_update(System.IntPtr obj, System.IntPtr pd, bool enable)
        {
            Eina.Log.Debug("function efl_ui_widget_on_access_update was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).UpdateOnAccess(enable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_on_access_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), enable);
            }
        }

        private static efl_ui_widget_on_access_update_delegate efl_ui_widget_on_access_update_static_delegate;

        
        private delegate void efl_ui_widget_screen_reader_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool is_screen_reader);

        
        public delegate void efl_ui_widget_screen_reader_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool is_screen_reader);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_screen_reader_api_delegate> efl_ui_widget_screen_reader_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_screen_reader_api_delegate>(Module, "efl_ui_widget_screen_reader");

        private static void screen_reader(System.IntPtr obj, System.IntPtr pd, bool is_screen_reader)
        {
            Eina.Log.Debug("function efl_ui_widget_screen_reader was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).ScreenReader(is_screen_reader);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_screen_reader_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), is_screen_reader);
            }
        }

        private static efl_ui_widget_screen_reader_delegate efl_ui_widget_screen_reader_static_delegate;

        
        private delegate void efl_ui_widget_atspi_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool is_atspi);

        
        public delegate void efl_ui_widget_atspi_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool is_atspi);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_atspi_api_delegate> efl_ui_widget_atspi_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_atspi_api_delegate>(Module, "efl_ui_widget_atspi");

        private static void atspi(System.IntPtr obj, System.IntPtr pd, bool is_atspi)
        {
            Eina.Log.Debug("function efl_ui_widget_atspi was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).Atspi(is_atspi);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_atspi_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), is_atspi);
            }
        }

        private static efl_ui_widget_atspi_delegate efl_ui_widget_atspi_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_sub_object_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object sub_obj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_sub_object_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object sub_obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_sub_object_add_api_delegate> efl_ui_widget_sub_object_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_sub_object_add_api_delegate>(Module, "efl_ui_widget_sub_object_add");

        private static bool widget_sub_object_add(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object sub_obj)
        {
            Eina.Log.Debug("function efl_ui_widget_sub_object_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).AddWidgetSubObject(sub_obj);
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
                return efl_ui_widget_sub_object_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sub_obj);
            }
        }

        private static efl_ui_widget_sub_object_add_delegate efl_ui_widget_sub_object_add_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_sub_object_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object sub_obj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_sub_object_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object sub_obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_sub_object_del_api_delegate> efl_ui_widget_sub_object_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_sub_object_del_api_delegate>(Module, "efl_ui_widget_sub_object_del");

        private static bool widget_sub_object_del(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object sub_obj)
        {
            Eina.Log.Debug("function efl_ui_widget_sub_object_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).DelWidgetSubObject(sub_obj);
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
                return efl_ui_widget_sub_object_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sub_obj);
            }
        }

        private static efl_ui_widget_sub_object_del_delegate efl_ui_widget_sub_object_del_static_delegate;

        
        private delegate Eina.Error efl_ui_widget_theme_apply_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Error efl_ui_widget_theme_apply_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_theme_apply_api_delegate> efl_ui_widget_theme_apply_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_theme_apply_api_delegate>(Module, "efl_ui_widget_theme_apply");

        private static Eina.Error theme_apply(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_theme_apply was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((Widget)ws.Target).ThemeApply();
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
                return efl_ui_widget_theme_apply_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_theme_apply_delegate efl_ui_widget_theme_apply_static_delegate;

        
        private delegate void efl_ui_widget_scroll_hold_push_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_widget_scroll_hold_push_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_scroll_hold_push_api_delegate> efl_ui_widget_scroll_hold_push_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_scroll_hold_push_api_delegate>(Module, "efl_ui_widget_scroll_hold_push");

        private static void scroll_hold_push(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_scroll_hold_push was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).PushScrollHold();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_widget_scroll_hold_push_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_scroll_hold_push_delegate efl_ui_widget_scroll_hold_push_static_delegate;

        
        private delegate void efl_ui_widget_scroll_hold_pop_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_widget_scroll_hold_pop_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_scroll_hold_pop_api_delegate> efl_ui_widget_scroll_hold_pop_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_scroll_hold_pop_api_delegate>(Module, "efl_ui_widget_scroll_hold_pop");

        private static void scroll_hold_pop(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_scroll_hold_pop was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).PopScrollHold();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_widget_scroll_hold_pop_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_scroll_hold_pop_delegate efl_ui_widget_scroll_hold_pop_static_delegate;

        
        private delegate void efl_ui_widget_scroll_freeze_push_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_widget_scroll_freeze_push_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_scroll_freeze_push_api_delegate> efl_ui_widget_scroll_freeze_push_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_scroll_freeze_push_api_delegate>(Module, "efl_ui_widget_scroll_freeze_push");

        private static void scroll_freeze_push(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_scroll_freeze_push was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).PushScrollFreeze();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_widget_scroll_freeze_push_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_scroll_freeze_push_delegate efl_ui_widget_scroll_freeze_push_static_delegate;

        
        private delegate void efl_ui_widget_scroll_freeze_pop_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_widget_scroll_freeze_pop_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_scroll_freeze_pop_api_delegate> efl_ui_widget_scroll_freeze_pop_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_scroll_freeze_pop_api_delegate>(Module, "efl_ui_widget_scroll_freeze_pop");

        private static void scroll_freeze_pop(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_scroll_freeze_pop was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).PopScrollFreeze();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_widget_scroll_freeze_pop_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_scroll_freeze_pop_delegate efl_ui_widget_scroll_freeze_pop_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_ui_widget_part_access_object_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String part);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_ui_widget_part_access_object_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String part);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_part_access_object_get_api_delegate> efl_ui_widget_part_access_object_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_part_access_object_get_api_delegate>(Module, "efl_ui_widget_part_access_object_get");

        private static Efl.Canvas.Object part_access_object_get(System.IntPtr obj, System.IntPtr pd, System.String part)
        {
            Eina.Log.Debug("function efl_ui_widget_part_access_object_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetPartAccessObject(part);
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
                return efl_ui_widget_part_access_object_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), part);
            }
        }

        private static efl_ui_widget_part_access_object_get_delegate efl_ui_widget_part_access_object_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_ui_widget_newest_focus_order_get_delegate(System.IntPtr obj, System.IntPtr pd,  out uint newest_focus_order, [MarshalAs(UnmanagedType.U1)] bool can_focus_only);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_ui_widget_newest_focus_order_get_api_delegate(System.IntPtr obj,  out uint newest_focus_order, [MarshalAs(UnmanagedType.U1)] bool can_focus_only);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_newest_focus_order_get_api_delegate> efl_ui_widget_newest_focus_order_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_newest_focus_order_get_api_delegate>(Module, "efl_ui_widget_newest_focus_order_get");

        private static Efl.Canvas.Object newest_focus_order_get(System.IntPtr obj, System.IntPtr pd, out uint newest_focus_order, bool can_focus_only)
        {
            Eina.Log.Debug("function efl_ui_widget_newest_focus_order_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        newest_focus_order = default(uint);                                    Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetNewestFocusOrder(out newest_focus_order, can_focus_only);
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
                return efl_ui_widget_newest_focus_order_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out newest_focus_order, can_focus_only);
            }
        }

        private static efl_ui_widget_newest_focus_order_get_delegate efl_ui_widget_newest_focus_order_get_static_delegate;

        
        private delegate void efl_ui_widget_focus_next_object_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object next,  Efl.Ui.Focus.Direction dir);

        
        public delegate void efl_ui_widget_focus_next_object_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object next,  Efl.Ui.Focus.Direction dir);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_object_set_api_delegate> efl_ui_widget_focus_next_object_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_object_set_api_delegate>(Module, "efl_ui_widget_focus_next_object_set");

        private static void focus_next_object_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object next, Efl.Ui.Focus.Direction dir)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_next_object_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).SetFocusNextObject(next, dir);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_widget_focus_next_object_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), next, dir);
            }
        }

        private static efl_ui_widget_focus_next_object_set_delegate efl_ui_widget_focus_next_object_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_ui_widget_focus_next_object_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction dir);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_ui_widget_focus_next_object_get_api_delegate(System.IntPtr obj,  Efl.Ui.Focus.Direction dir);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_object_get_api_delegate> efl_ui_widget_focus_next_object_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_object_get_api_delegate>(Module, "efl_ui_widget_focus_next_object_get");

        private static Efl.Canvas.Object focus_next_object_get(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.Direction dir)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_next_object_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusNextObject(dir);
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
                return efl_ui_widget_focus_next_object_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir);
            }
        }

        private static efl_ui_widget_focus_next_object_get_delegate efl_ui_widget_focus_next_object_get_static_delegate;

        
        private delegate void efl_ui_widget_focus_next_item_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Widget next_item,  Efl.Ui.Focus.Direction dir);

        
        public delegate void efl_ui_widget_focus_next_item_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Widget next_item,  Efl.Ui.Focus.Direction dir);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_item_set_api_delegate> efl_ui_widget_focus_next_item_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_item_set_api_delegate>(Module, "efl_ui_widget_focus_next_item_set");

        private static void focus_next_item_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Widget next_item, Efl.Ui.Focus.Direction dir)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_next_item_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).SetFocusNextItem(next_item, dir);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_widget_focus_next_item_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), next_item, dir);
            }
        }

        private static efl_ui_widget_focus_next_item_set_delegate efl_ui_widget_focus_next_item_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Widget efl_ui_widget_focus_next_item_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction dir);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Widget efl_ui_widget_focus_next_item_get_api_delegate(System.IntPtr obj,  Efl.Ui.Focus.Direction dir);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_item_get_api_delegate> efl_ui_widget_focus_next_item_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_item_get_api_delegate>(Module, "efl_ui_widget_focus_next_item_get");

        private static Efl.Ui.Widget focus_next_item_get(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.Direction dir)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_next_item_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Ui.Widget _ret_var = default(Efl.Ui.Widget);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusNextItem(dir);
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
                return efl_ui_widget_focus_next_item_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir);
            }
        }

        private static efl_ui_widget_focus_next_item_get_delegate efl_ui_widget_focus_next_item_get_static_delegate;

        
        private delegate void efl_ui_widget_focus_tree_unfocusable_handle_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_widget_focus_tree_unfocusable_handle_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_tree_unfocusable_handle_api_delegate> efl_ui_widget_focus_tree_unfocusable_handle_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_tree_unfocusable_handle_api_delegate>(Module, "efl_ui_widget_focus_tree_unfocusable_handle");

        private static void focus_tree_unfocusable_handle(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_tree_unfocusable_handle was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).FocusTreeUnfocusableHandle();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_widget_focus_tree_unfocusable_handle_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_tree_unfocusable_handle_delegate efl_ui_widget_focus_tree_unfocusable_handle_static_delegate;

        
        private delegate void efl_ui_widget_focus_custom_chain_prepend_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object relative_child);

        
        public delegate void efl_ui_widget_focus_custom_chain_prepend_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object relative_child);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_custom_chain_prepend_api_delegate> efl_ui_widget_focus_custom_chain_prepend_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_custom_chain_prepend_api_delegate>(Module, "efl_ui_widget_focus_custom_chain_prepend");

        private static void focus_custom_chain_prepend(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object child, Efl.Canvas.Object relative_child)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_custom_chain_prepend was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).FocusCustomChainPrepend(child, relative_child);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_widget_focus_custom_chain_prepend_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child, relative_child);
            }
        }

        private static efl_ui_widget_focus_custom_chain_prepend_delegate efl_ui_widget_focus_custom_chain_prepend_static_delegate;

        
        private delegate void efl_ui_widget_focus_cycle_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction dir);

        
        public delegate void efl_ui_widget_focus_cycle_api_delegate(System.IntPtr obj,  Efl.Ui.Focus.Direction dir);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_cycle_api_delegate> efl_ui_widget_focus_cycle_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_cycle_api_delegate>(Module, "efl_ui_widget_focus_cycle");

        private static void focus_cycle(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.Direction dir)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_cycle was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).FocusCycle(dir);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_focus_cycle_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir);
            }
        }

        private static efl_ui_widget_focus_cycle_delegate efl_ui_widget_focus_cycle_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_focus_direction_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object kw_base,  double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Ui.Widget direction_item,  out double weight);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_focus_direction_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object kw_base,  double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Ui.Widget direction_item,  out double weight);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_direction_api_delegate> efl_ui_widget_focus_direction_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_direction_api_delegate>(Module, "efl_ui_widget_focus_direction");

        private static bool focus_direction(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object kw_base, double degree, out Efl.Canvas.Object direction, out Efl.Ui.Widget direction_item, out double weight)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_direction was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                direction = default(Efl.Canvas.Object);        direction_item = default(Efl.Ui.Widget);        weight = default(double);                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).FocusDirection(kw_base, degree, out direction, out direction_item, out weight);
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
                return efl_ui_widget_focus_direction_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_base, degree, out direction, out direction_item, out weight);
            }
        }

        private static efl_ui_widget_focus_direction_delegate efl_ui_widget_focus_direction_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_focus_next_manager_is_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_focus_next_manager_is_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_manager_is_api_delegate> efl_ui_widget_focus_next_manager_is_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_manager_is_api_delegate>(Module, "efl_ui_widget_focus_next_manager_is");

        private static bool focus_next_manager_is(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_next_manager_is was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).IsFocusNextManager();
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
                return efl_ui_widget_focus_next_manager_is_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_next_manager_is_delegate efl_ui_widget_focus_next_manager_is_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_focus_list_direction_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object kw_base,  System.IntPtr items,  System.IntPtr list_data_get,  double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Ui.Widget direction_item,  out double weight);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_focus_list_direction_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object kw_base,  System.IntPtr items,  System.IntPtr list_data_get,  double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Ui.Widget direction_item,  out double weight);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_list_direction_get_api_delegate> efl_ui_widget_focus_list_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_list_direction_get_api_delegate>(Module, "efl_ui_widget_focus_list_direction_get");

        private static bool focus_list_direction_get(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object kw_base, System.IntPtr items, System.IntPtr list_data_get, double degree, out Efl.Canvas.Object direction, out Efl.Ui.Widget direction_item, out double weight)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_list_direction_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_items = new Eina.List<Efl.Object>(items, false, false);
                                                                                direction = default(Efl.Canvas.Object);        direction_item = default(Efl.Ui.Widget);        weight = default(double);                                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusListDirection(kw_base, _in_items, list_data_get, degree, out direction, out direction_item, out weight);
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
                return efl_ui_widget_focus_list_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_base, items, list_data_get, degree, out direction, out direction_item, out weight);
            }
        }

        private static efl_ui_widget_focus_list_direction_get_delegate efl_ui_widget_focus_list_direction_get_static_delegate;

        
        private delegate void efl_ui_widget_focused_object_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_widget_focused_object_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focused_object_clear_api_delegate> efl_ui_widget_focused_object_clear_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focused_object_clear_api_delegate>(Module, "efl_ui_widget_focused_object_clear");

        private static void focused_object_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focused_object_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).ClearFocusedObject();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_widget_focused_object_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focused_object_clear_delegate efl_ui_widget_focused_object_clear_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_focus_direction_go_delegate(System.IntPtr obj, System.IntPtr pd,  double degree);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_focus_direction_go_api_delegate(System.IntPtr obj,  double degree);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_direction_go_api_delegate> efl_ui_widget_focus_direction_go_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_direction_go_api_delegate>(Module, "efl_ui_widget_focus_direction_go");

        private static bool focus_direction_go(System.IntPtr obj, System.IntPtr pd, double degree)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_direction_go was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).FocusDirectionGo(degree);
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
                return efl_ui_widget_focus_direction_go_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), degree);
            }
        }

        private static efl_ui_widget_focus_direction_go_delegate efl_ui_widget_focus_direction_go_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_focus_next_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Ui.Widget next_item);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_focus_next_get_api_delegate(System.IntPtr obj,  Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Ui.Widget next_item);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_get_api_delegate> efl_ui_widget_focus_next_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_get_api_delegate>(Module, "efl_ui_widget_focus_next_get");

        private static bool focus_next_get(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.Direction dir, out Efl.Canvas.Object next, out Efl.Ui.Widget next_item)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_next_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        next = default(Efl.Canvas.Object);        next_item = default(Efl.Ui.Widget);                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusNext(dir, out next, out next_item);
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
                return efl_ui_widget_focus_next_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir, out next, out next_item);
            }
        }

        private static efl_ui_widget_focus_next_get_delegate efl_ui_widget_focus_next_get_static_delegate;

        
        private delegate void efl_ui_widget_focus_restore_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_widget_focus_restore_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_restore_api_delegate> efl_ui_widget_focus_restore_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_restore_api_delegate>(Module, "efl_ui_widget_focus_restore");

        private static void focus_restore(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_restore was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).FocusRestore();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_widget_focus_restore_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_restore_delegate efl_ui_widget_focus_restore_static_delegate;

        
        private delegate void efl_ui_widget_focus_custom_chain_unset_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_widget_focus_custom_chain_unset_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_custom_chain_unset_api_delegate> efl_ui_widget_focus_custom_chain_unset_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_custom_chain_unset_api_delegate>(Module, "efl_ui_widget_focus_custom_chain_unset");

        private static void focus_custom_chain_unset(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_custom_chain_unset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).UnsetFocusCustomChain();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_widget_focus_custom_chain_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_custom_chain_unset_delegate efl_ui_widget_focus_custom_chain_unset_static_delegate;

        
        private delegate void efl_ui_widget_focus_steal_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Widget item);

        
        public delegate void efl_ui_widget_focus_steal_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Widget item);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_steal_api_delegate> efl_ui_widget_focus_steal_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_steal_api_delegate>(Module, "efl_ui_widget_focus_steal");

        private static void focus_steal(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Widget item)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_steal was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).FocusSteal(item);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_widget_focus_steal_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), item);
            }
        }

        private static efl_ui_widget_focus_steal_delegate efl_ui_widget_focus_steal_static_delegate;

        
        private delegate void efl_ui_widget_focus_hide_handle_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_widget_focus_hide_handle_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_hide_handle_api_delegate> efl_ui_widget_focus_hide_handle_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_hide_handle_api_delegate>(Module, "efl_ui_widget_focus_hide_handle");

        private static void focus_hide_handle(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_hide_handle was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).FocusHideHandle();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_widget_focus_hide_handle_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_hide_handle_delegate efl_ui_widget_focus_hide_handle_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_focus_next_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Ui.Widget next_item);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_focus_next_api_delegate(System.IntPtr obj,  Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Ui.Widget next_item);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_api_delegate> efl_ui_widget_focus_next_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_next_api_delegate>(Module, "efl_ui_widget_focus_next");

        private static bool focus_next(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Focus.Direction dir, out Efl.Canvas.Object next, out Efl.Ui.Widget next_item)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_next was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        next = default(Efl.Canvas.Object);        next_item = default(Efl.Ui.Widget);                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).FocusNext(dir, out next, out next_item);
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
                return efl_ui_widget_focus_next_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir, out next, out next_item);
            }
        }

        private static efl_ui_widget_focus_next_delegate efl_ui_widget_focus_next_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_focus_list_next_get_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr items,  System.IntPtr list_data_get,  Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Ui.Widget next_item);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_focus_list_next_get_api_delegate(System.IntPtr obj,  System.IntPtr items,  System.IntPtr list_data_get,  Efl.Ui.Focus.Direction dir, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object next, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Ui.Widget next_item);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_list_next_get_api_delegate> efl_ui_widget_focus_list_next_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_list_next_get_api_delegate>(Module, "efl_ui_widget_focus_list_next_get");

        private static bool focus_list_next_get(System.IntPtr obj, System.IntPtr pd, System.IntPtr items, System.IntPtr list_data_get, Efl.Ui.Focus.Direction dir, out Efl.Canvas.Object next, out Efl.Ui.Widget next_item)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_list_next_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_items = new Eina.List<Efl.Object>(items, false, false);
                                                                next = default(Efl.Canvas.Object);        next_item = default(Efl.Ui.Widget);                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusListNext(_in_items, list_data_get, dir, out next, out next_item);
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
                return efl_ui_widget_focus_list_next_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), items, list_data_get, dir, out next, out next_item);
            }
        }

        private static efl_ui_widget_focus_list_next_get_delegate efl_ui_widget_focus_list_next_get_static_delegate;

        
        private delegate void efl_ui_widget_focus_mouse_up_handle_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_widget_focus_mouse_up_handle_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_mouse_up_handle_api_delegate> efl_ui_widget_focus_mouse_up_handle_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_mouse_up_handle_api_delegate>(Module, "efl_ui_widget_focus_mouse_up_handle");

        private static void focus_mouse_up_handle(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_mouse_up_handle was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).FocusMouseUpHandle();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_widget_focus_mouse_up_handle_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_mouse_up_handle_delegate efl_ui_widget_focus_mouse_up_handle_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_focus_direction_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object kw_base,  double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Ui.Widget direction_item,  out double weight);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_focus_direction_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object kw_base,  double degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Canvas.Object direction, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] out Efl.Ui.Widget direction_item,  out double weight);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_direction_get_api_delegate> efl_ui_widget_focus_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_direction_get_api_delegate>(Module, "efl_ui_widget_focus_direction_get");

        private static bool focus_direction_get(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object kw_base, double degree, out Efl.Canvas.Object direction, out Efl.Ui.Widget direction_item, out double weight)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_direction_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                direction = default(Efl.Canvas.Object);        direction_item = default(Efl.Ui.Widget);        weight = default(double);                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusDirection(kw_base, degree, out direction, out direction_item, out weight);
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
                return efl_ui_widget_focus_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_base, degree, out direction, out direction_item, out weight);
            }
        }

        private static efl_ui_widget_focus_direction_get_delegate efl_ui_widget_focus_direction_get_static_delegate;

        
        private delegate void efl_ui_widget_focus_disabled_handle_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_widget_focus_disabled_handle_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_disabled_handle_api_delegate> efl_ui_widget_focus_disabled_handle_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_disabled_handle_api_delegate>(Module, "efl_ui_widget_focus_disabled_handle");

        private static void focus_disabled_handle(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_disabled_handle was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).FocusDisabledHandle();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_widget_focus_disabled_handle_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_disabled_handle_delegate efl_ui_widget_focus_disabled_handle_static_delegate;

        
        private delegate void efl_ui_widget_focus_custom_chain_append_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object relative_child);

        
        public delegate void efl_ui_widget_focus_custom_chain_append_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object child, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object relative_child);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_custom_chain_append_api_delegate> efl_ui_widget_focus_custom_chain_append_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_custom_chain_append_api_delegate>(Module, "efl_ui_widget_focus_custom_chain_append");

        private static void focus_custom_chain_append(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object child, Efl.Canvas.Object relative_child)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_custom_chain_append was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).AppendFocusCustomChain(child, relative_child);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_widget_focus_custom_chain_append_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child, relative_child);
            }
        }

        private static efl_ui_widget_focus_custom_chain_append_delegate efl_ui_widget_focus_custom_chain_append_static_delegate;

        
        private delegate void efl_ui_widget_focus_reconfigure_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_widget_focus_reconfigure_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_reconfigure_api_delegate> efl_ui_widget_focus_reconfigure_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_reconfigure_api_delegate>(Module, "efl_ui_widget_focus_reconfigure");

        private static void focus_reconfigure(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_reconfigure was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).FocusReconfigure();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_widget_focus_reconfigure_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_reconfigure_delegate efl_ui_widget_focus_reconfigure_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_focus_direction_manager_is_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_focus_direction_manager_is_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_direction_manager_is_api_delegate> efl_ui_widget_focus_direction_manager_is_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_direction_manager_is_api_delegate>(Module, "efl_ui_widget_focus_direction_manager_is");

        private static bool focus_direction_manager_is(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_direction_manager_is was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).IsFocusDirectionManager();
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
                return efl_ui_widget_focus_direction_manager_is_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_widget_focus_direction_manager_is_delegate efl_ui_widget_focus_direction_manager_is_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_widget_focus_state_apply_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.WidgetFocusState.NativeStruct current_state,  ref Efl.Ui.WidgetFocusState.NativeStruct configured_state, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Widget redirect);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_widget_focus_state_apply_api_delegate(System.IntPtr obj,  Efl.Ui.WidgetFocusState.NativeStruct current_state,  ref Efl.Ui.WidgetFocusState.NativeStruct configured_state, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Widget redirect);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_state_apply_api_delegate> efl_ui_widget_focus_state_apply_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_state_apply_api_delegate>(Module, "efl_ui_widget_focus_state_apply");

        private static bool focus_state_apply(System.IntPtr obj, System.IntPtr pd, Efl.Ui.WidgetFocusState.NativeStruct current_state, ref Efl.Ui.WidgetFocusState.NativeStruct configured_state, Efl.Ui.Widget redirect)
        {
            Eina.Log.Debug("function efl_ui_widget_focus_state_apply was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Ui.WidgetFocusState _in_current_state = current_state;
                                Efl.Ui.WidgetFocusState _out_configured_state = default(Efl.Ui.WidgetFocusState);
                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).FocusStateApply(_in_current_state, ref _out_configured_state, redirect);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                configured_state = _out_configured_state;
                                        return _ret_var;

            }
            else
            {
                return efl_ui_widget_focus_state_apply_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), current_state, ref configured_state, redirect);
            }
        }

        private static efl_ui_widget_focus_state_apply_delegate efl_ui_widget_focus_state_apply_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_part_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_part_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String name);

        public static Efl.Eo.FunctionWrapper<efl_part_get_api_delegate> efl_part_get_ptr = new Efl.Eo.FunctionWrapper<efl_part_get_api_delegate>(Module, "efl_part_get");

        private static Efl.Object part_get(System.IntPtr obj, System.IntPtr pd, System.String name)
        {
            Eina.Log.Debug("function efl_part_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetPart(name);
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
                return efl_part_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name);
            }
        }

        private static efl_part_get_delegate efl_part_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_action_name_get_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_action_name_get_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_access_action_name_get_api_delegate> efl_access_action_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_name_get_api_delegate>(Module, "efl_access_action_name_get");

        private static System.String action_name_get(System.IntPtr obj, System.IntPtr pd, int id)
        {
            Eina.Log.Debug("function efl_access_action_name_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetActionName(id);
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
                return efl_access_action_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), id);
            }
        }

        private static efl_access_action_name_get_delegate efl_access_action_name_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_action_localized_name_get_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_action_localized_name_get_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_access_action_localized_name_get_api_delegate> efl_access_action_localized_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_localized_name_get_api_delegate>(Module, "efl_access_action_localized_name_get");

        private static System.String action_localized_name_get(System.IntPtr obj, System.IntPtr pd, int id)
        {
            Eina.Log.Debug("function efl_access_action_localized_name_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetActionLocalizedName(id);
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
                return efl_access_action_localized_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), id);
            }
        }

        private static efl_access_action_localized_name_get_delegate efl_access_action_localized_name_get_static_delegate;

        
        private delegate System.IntPtr efl_access_action_actions_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_access_action_actions_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_action_actions_get_api_delegate> efl_access_action_actions_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_actions_get_api_delegate>(Module, "efl_access_action_actions_get");

        private static System.IntPtr actions_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_action_actions_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.List<Efl.Access.ActionData> _ret_var = default(Eina.List<Efl.Access.ActionData>);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetActions();
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
                return efl_access_action_actions_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_action_actions_get_delegate efl_access_action_actions_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_action_do_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_action_do_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_access_action_do_api_delegate> efl_access_action_do_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_do_api_delegate>(Module, "efl_access_action_do");

        private static bool action_do(System.IntPtr obj, System.IntPtr pd, int id)
        {
            Eina.Log.Debug("function efl_access_action_do was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).ActionDo(id);
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
                return efl_access_action_do_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), id);
            }
        }

        private static efl_access_action_do_delegate efl_access_action_do_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        private delegate System.String efl_access_action_keybinding_get_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringPassOwnershipMarshaler))]
        public delegate System.String efl_access_action_keybinding_get_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_access_action_keybinding_get_api_delegate> efl_access_action_keybinding_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_action_keybinding_get_api_delegate>(Module, "efl_access_action_keybinding_get");

        private static System.String action_keybinding_get(System.IntPtr obj, System.IntPtr pd, int id)
        {
            Eina.Log.Debug("function efl_access_action_keybinding_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetActionKeybinding(id);
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
                return efl_access_action_keybinding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), id);
            }
        }

        private static efl_access_action_keybinding_get_delegate efl_access_action_keybinding_get_static_delegate;

        
        private delegate int efl_access_component_z_order_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_access_component_z_order_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_component_z_order_get_api_delegate> efl_access_component_z_order_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_z_order_get_api_delegate>(Module, "efl_access_component_z_order_get");

        private static int z_order_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_component_z_order_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetZOrder();
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
                return efl_access_component_z_order_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_component_z_order_get_delegate efl_access_component_z_order_get_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_access_component_extents_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords);

        
        public delegate Eina.Rect.NativeStruct efl_access_component_extents_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords);

        public static Efl.Eo.FunctionWrapper<efl_access_component_extents_get_api_delegate> efl_access_component_extents_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_extents_get_api_delegate>(Module, "efl_access_component_extents_get");

        private static Eina.Rect.NativeStruct extents_get(System.IntPtr obj, System.IntPtr pd, bool screen_coords)
        {
            Eina.Log.Debug("function efl_access_component_extents_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetExtents(screen_coords);
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
                return efl_access_component_extents_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), screen_coords);
            }
        }

        private static efl_access_component_extents_get_delegate efl_access_component_extents_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_component_extents_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  Eina.Rect.NativeStruct rect);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_component_extents_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  Eina.Rect.NativeStruct rect);

        public static Efl.Eo.FunctionWrapper<efl_access_component_extents_set_api_delegate> efl_access_component_extents_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_extents_set_api_delegate>(Module, "efl_access_component_extents_set");

        private static bool extents_set(System.IntPtr obj, System.IntPtr pd, bool screen_coords, Eina.Rect.NativeStruct rect)
        {
            Eina.Log.Debug("function efl_access_component_extents_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Rect _in_rect = rect;
                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).SetExtents(screen_coords, _in_rect);
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
                return efl_access_component_extents_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), screen_coords, rect);
            }
        }

        private static efl_access_component_extents_set_delegate efl_access_component_extents_set_static_delegate;

        
        private delegate void efl_access_component_screen_position_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int x,  out int y);

        
        public delegate void efl_access_component_screen_position_get_api_delegate(System.IntPtr obj,  out int x,  out int y);

        public static Efl.Eo.FunctionWrapper<efl_access_component_screen_position_get_api_delegate> efl_access_component_screen_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_screen_position_get_api_delegate>(Module, "efl_access_component_screen_position_get");

        private static void screen_position_get(System.IntPtr obj, System.IntPtr pd, out int x, out int y)
        {
            Eina.Log.Debug("function efl_access_component_screen_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(int);        y = default(int);                            
                try
                {
                    ((Widget)ws.Target).GetScreenPosition(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_component_screen_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_access_component_screen_position_get_delegate efl_access_component_screen_position_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_component_screen_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  int x,  int y);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_component_screen_position_set_api_delegate(System.IntPtr obj,  int x,  int y);

        public static Efl.Eo.FunctionWrapper<efl_access_component_screen_position_set_api_delegate> efl_access_component_screen_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_screen_position_set_api_delegate>(Module, "efl_access_component_screen_position_set");

        private static bool screen_position_set(System.IntPtr obj, System.IntPtr pd, int x, int y)
        {
            Eina.Log.Debug("function efl_access_component_screen_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).SetScreenPosition(x, y);
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
                return efl_access_component_screen_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_access_component_screen_position_set_delegate efl_access_component_screen_position_set_static_delegate;

        
        private delegate void efl_access_component_socket_offset_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int x,  out int y);

        
        public delegate void efl_access_component_socket_offset_get_api_delegate(System.IntPtr obj,  out int x,  out int y);

        public static Efl.Eo.FunctionWrapper<efl_access_component_socket_offset_get_api_delegate> efl_access_component_socket_offset_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_socket_offset_get_api_delegate>(Module, "efl_access_component_socket_offset_get");

        private static void socket_offset_get(System.IntPtr obj, System.IntPtr pd, out int x, out int y)
        {
            Eina.Log.Debug("function efl_access_component_socket_offset_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        x = default(int);        y = default(int);                            
                try
                {
                    ((Widget)ws.Target).GetSocketOffset(out x, out y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_component_socket_offset_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out x, out y);
            }
        }

        private static efl_access_component_socket_offset_get_delegate efl_access_component_socket_offset_get_static_delegate;

        
        private delegate void efl_access_component_socket_offset_set_delegate(System.IntPtr obj, System.IntPtr pd,  int x,  int y);

        
        public delegate void efl_access_component_socket_offset_set_api_delegate(System.IntPtr obj,  int x,  int y);

        public static Efl.Eo.FunctionWrapper<efl_access_component_socket_offset_set_api_delegate> efl_access_component_socket_offset_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_socket_offset_set_api_delegate>(Module, "efl_access_component_socket_offset_set");

        private static void socket_offset_set(System.IntPtr obj, System.IntPtr pd, int x, int y)
        {
            Eina.Log.Debug("function efl_access_component_socket_offset_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).SetSocketOffset(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_component_socket_offset_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_access_component_socket_offset_set_delegate efl_access_component_socket_offset_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_component_contains_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int x,  int y);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_component_contains_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int x,  int y);

        public static Efl.Eo.FunctionWrapper<efl_access_component_contains_api_delegate> efl_access_component_contains_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_contains_api_delegate>(Module, "efl_access_component_contains");

        private static bool contains(System.IntPtr obj, System.IntPtr pd, bool screen_coords, int x, int y)
        {
            Eina.Log.Debug("function efl_access_component_contains was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).Contains(screen_coords, x, y);
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
                return efl_access_component_contains_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), screen_coords, x, y);
            }
        }

        private static efl_access_component_contains_delegate efl_access_component_contains_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_component_focus_grab_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_component_focus_grab_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_component_focus_grab_api_delegate> efl_access_component_focus_grab_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_focus_grab_api_delegate>(Module, "efl_access_component_focus_grab");

        private static bool focus_grab(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_component_focus_grab was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GrabFocus();
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
                return efl_access_component_focus_grab_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_component_focus_grab_delegate efl_access_component_focus_grab_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_access_component_accessible_at_point_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int x,  int y);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_access_component_accessible_at_point_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool screen_coords,  int x,  int y);

        public static Efl.Eo.FunctionWrapper<efl_access_component_accessible_at_point_get_api_delegate> efl_access_component_accessible_at_point_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_accessible_at_point_get_api_delegate>(Module, "efl_access_component_accessible_at_point_get");

        private static Efl.Object accessible_at_point_get(System.IntPtr obj, System.IntPtr pd, bool screen_coords, int x, int y)
        {
            Eina.Log.Debug("function efl_access_component_accessible_at_point_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetAccessibleAtPoint(screen_coords, x, y);
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
                return efl_access_component_accessible_at_point_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), screen_coords, x, y);
            }
        }

        private static efl_access_component_accessible_at_point_get_delegate efl_access_component_accessible_at_point_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_component_highlight_grab_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_component_highlight_grab_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_component_highlight_grab_api_delegate> efl_access_component_highlight_grab_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_highlight_grab_api_delegate>(Module, "efl_access_component_highlight_grab");

        private static bool highlight_grab(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_component_highlight_grab was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GrabHighlight();
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
                return efl_access_component_highlight_grab_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_component_highlight_grab_delegate efl_access_component_highlight_grab_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_component_highlight_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_component_highlight_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_component_highlight_clear_api_delegate> efl_access_component_highlight_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_component_highlight_clear_api_delegate>(Module, "efl_access_component_highlight_clear");

        private static bool highlight_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_component_highlight_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).ClearHighlight();
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
                return efl_access_component_highlight_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_component_highlight_clear_delegate efl_access_component_highlight_clear_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_object_localized_role_name_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_object_localized_role_name_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_localized_role_name_get_api_delegate> efl_access_object_localized_role_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_localized_role_name_get_api_delegate>(Module, "efl_access_object_localized_role_name_get");

        private static System.String localized_role_name_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_localized_role_name_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetLocalizedRoleName();
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
                return efl_access_object_localized_role_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_localized_role_name_get_delegate efl_access_object_localized_role_name_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_object_i18n_name_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_object_i18n_name_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_get_api_delegate> efl_access_object_i18n_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_get_api_delegate>(Module, "efl_access_object_i18n_name_get");

        private static System.String i18n_name_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_i18n_name_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetI18nName();
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
                return efl_access_object_i18n_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_i18n_name_get_delegate efl_access_object_i18n_name_get_static_delegate;

        
        private delegate void efl_access_object_i18n_name_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String i18n_name);

        
        public delegate void efl_access_object_i18n_name_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String i18n_name);

        public static Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_set_api_delegate> efl_access_object_i18n_name_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_i18n_name_set_api_delegate>(Module, "efl_access_object_i18n_name_set");

        private static void i18n_name_set(System.IntPtr obj, System.IntPtr pd, System.String i18n_name)
        {
            Eina.Log.Debug("function efl_access_object_i18n_name_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetI18nName(i18n_name);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_i18n_name_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), i18n_name);
            }
        }

        private static efl_access_object_i18n_name_set_delegate efl_access_object_i18n_name_set_static_delegate;

        
        private delegate void efl_access_object_name_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoCb name_cb,  System.IntPtr data);

        
        public delegate void efl_access_object_name_cb_set_api_delegate(System.IntPtr obj,  Efl.Access.ReadingInfoCb name_cb,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_access_object_name_cb_set_api_delegate> efl_access_object_name_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_name_cb_set_api_delegate>(Module, "efl_access_object_name_cb_set");

        private static void name_cb_set(System.IntPtr obj, System.IntPtr pd, Efl.Access.ReadingInfoCb name_cb, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_access_object_name_cb_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).SetNameCb(name_cb, data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_object_name_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), name_cb, data);
            }
        }

        private static efl_access_object_name_cb_set_delegate efl_access_object_name_cb_set_static_delegate;

        
        private delegate Efl.Access.RelationSet efl_access_object_relation_set_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Access.RelationSet efl_access_object_relation_set_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_relation_set_get_api_delegate> efl_access_object_relation_set_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relation_set_get_api_delegate>(Module, "efl_access_object_relation_set_get");

        private static Efl.Access.RelationSet relation_set_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_relation_set_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Access.RelationSet _ret_var = default(Efl.Access.RelationSet);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetRelationSet();
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
                return efl_access_object_relation_set_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_relation_set_get_delegate efl_access_object_relation_set_get_static_delegate;

        
        private delegate Efl.Access.Role efl_access_object_role_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Access.Role efl_access_object_role_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_role_get_api_delegate> efl_access_object_role_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_role_get_api_delegate>(Module, "efl_access_object_role_get");

        private static Efl.Access.Role role_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_role_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Access.Role _ret_var = default(Efl.Access.Role);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetRole();
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
                return efl_access_object_role_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_role_get_delegate efl_access_object_role_get_static_delegate;

        
        private delegate void efl_access_object_role_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.Role role);

        
        public delegate void efl_access_object_role_set_api_delegate(System.IntPtr obj,  Efl.Access.Role role);

        public static Efl.Eo.FunctionWrapper<efl_access_object_role_set_api_delegate> efl_access_object_role_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_role_set_api_delegate>(Module, "efl_access_object_role_set");

        private static void role_set(System.IntPtr obj, System.IntPtr pd, Efl.Access.Role role)
        {
            Eina.Log.Debug("function efl_access_object_role_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetRole(role);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_role_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), role);
            }
        }

        private static efl_access_object_role_set_delegate efl_access_object_role_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Access.IObject efl_access_object_access_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Access.IObject efl_access_object_access_parent_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_access_parent_get_api_delegate> efl_access_object_access_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_parent_get_api_delegate>(Module, "efl_access_object_access_parent_get");

        private static Efl.Access.IObject access_parent_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_access_parent_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Access.IObject _ret_var = default(Efl.Access.IObject);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetAccessParent();
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
                return efl_access_object_access_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_access_parent_get_delegate efl_access_object_access_parent_get_static_delegate;

        
        private delegate void efl_access_object_access_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject parent);

        
        public delegate void efl_access_object_access_parent_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject parent);

        public static Efl.Eo.FunctionWrapper<efl_access_object_access_parent_set_api_delegate> efl_access_object_access_parent_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_parent_set_api_delegate>(Module, "efl_access_object_access_parent_set");

        private static void access_parent_set(System.IntPtr obj, System.IntPtr pd, Efl.Access.IObject parent)
        {
            Eina.Log.Debug("function efl_access_object_access_parent_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetAccessParent(parent);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_access_parent_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), parent);
            }
        }

        private static efl_access_object_access_parent_set_delegate efl_access_object_access_parent_set_static_delegate;

        
        private delegate void efl_access_object_description_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoCb description_cb,  System.IntPtr data);

        
        public delegate void efl_access_object_description_cb_set_api_delegate(System.IntPtr obj,  Efl.Access.ReadingInfoCb description_cb,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_access_object_description_cb_set_api_delegate> efl_access_object_description_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_description_cb_set_api_delegate>(Module, "efl_access_object_description_cb_set");

        private static void description_cb_set(System.IntPtr obj, System.IntPtr pd, Efl.Access.ReadingInfoCb description_cb, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_access_object_description_cb_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).SetDescriptionCb(description_cb, data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_object_description_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), description_cb, data);
            }
        }

        private static efl_access_object_description_cb_set_delegate efl_access_object_description_cb_set_static_delegate;

        
        private delegate void efl_access_object_gesture_cb_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.GestureCb gesture_cb,  System.IntPtr data);

        
        public delegate void efl_access_object_gesture_cb_set_api_delegate(System.IntPtr obj,  Efl.Access.GestureCb gesture_cb,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_access_object_gesture_cb_set_api_delegate> efl_access_object_gesture_cb_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_gesture_cb_set_api_delegate>(Module, "efl_access_object_gesture_cb_set");

        private static void gesture_cb_set(System.IntPtr obj, System.IntPtr pd, Efl.Access.GestureCb gesture_cb, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_access_object_gesture_cb_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).SetGestureCb(gesture_cb, data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_object_gesture_cb_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), gesture_cb, data);
            }
        }

        private static efl_access_object_gesture_cb_set_delegate efl_access_object_gesture_cb_set_static_delegate;

        
        private delegate System.IntPtr efl_access_object_access_children_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_access_object_access_children_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_access_children_get_api_delegate> efl_access_object_access_children_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_children_get_api_delegate>(Module, "efl_access_object_access_children_get");

        private static System.IntPtr access_children_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_access_children_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.List<Efl.Access.IObject> _ret_var = default(Eina.List<Efl.Access.IObject>);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetAccessChildren();
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
                return efl_access_object_access_children_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_access_children_get_delegate efl_access_object_access_children_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_object_role_name_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_object_role_name_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_role_name_get_api_delegate> efl_access_object_role_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_role_name_get_api_delegate>(Module, "efl_access_object_role_name_get");

        private static System.String role_name_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_role_name_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetRoleName();
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
                return efl_access_object_role_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_role_name_get_delegate efl_access_object_role_name_get_static_delegate;

        
        private delegate System.IntPtr efl_access_object_attributes_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_access_object_attributes_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_attributes_get_api_delegate> efl_access_object_attributes_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attributes_get_api_delegate>(Module, "efl_access_object_attributes_get");

        private static System.IntPtr attributes_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_attributes_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.List<Efl.Access.Attribute> _ret_var = default(Eina.List<Efl.Access.Attribute>);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetAttributes();
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
                return efl_access_object_attributes_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_attributes_get_delegate efl_access_object_attributes_get_static_delegate;

        
        private delegate Efl.Access.ReadingInfoTypeMask efl_access_object_reading_info_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Access.ReadingInfoTypeMask efl_access_object_reading_info_type_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_get_api_delegate> efl_access_object_reading_info_type_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_get_api_delegate>(Module, "efl_access_object_reading_info_type_get");

        private static Efl.Access.ReadingInfoTypeMask reading_info_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_reading_info_type_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Access.ReadingInfoTypeMask _ret_var = default(Efl.Access.ReadingInfoTypeMask);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetReadingInfoType();
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
                return efl_access_object_reading_info_type_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_reading_info_type_get_delegate efl_access_object_reading_info_type_get_static_delegate;

        
        private delegate void efl_access_object_reading_info_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.ReadingInfoTypeMask reading_info);

        
        public delegate void efl_access_object_reading_info_type_set_api_delegate(System.IntPtr obj,  Efl.Access.ReadingInfoTypeMask reading_info);

        public static Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_set_api_delegate> efl_access_object_reading_info_type_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_reading_info_type_set_api_delegate>(Module, "efl_access_object_reading_info_type_set");

        private static void reading_info_type_set(System.IntPtr obj, System.IntPtr pd, Efl.Access.ReadingInfoTypeMask reading_info)
        {
            Eina.Log.Debug("function efl_access_object_reading_info_type_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetReadingInfoType(reading_info);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_reading_info_type_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), reading_info);
            }
        }

        private static efl_access_object_reading_info_type_set_delegate efl_access_object_reading_info_type_set_static_delegate;

        
        private delegate int efl_access_object_index_in_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_access_object_index_in_parent_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_index_in_parent_get_api_delegate> efl_access_object_index_in_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_index_in_parent_get_api_delegate>(Module, "efl_access_object_index_in_parent_get");

        private static int index_in_parent_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_index_in_parent_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetIndexInParent();
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
                return efl_access_object_index_in_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_index_in_parent_get_delegate efl_access_object_index_in_parent_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_object_description_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_object_description_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_description_get_api_delegate> efl_access_object_description_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_description_get_api_delegate>(Module, "efl_access_object_description_get");

        private static System.String description_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_description_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetDescription();
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
                return efl_access_object_description_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_description_get_delegate efl_access_object_description_get_static_delegate;

        
        private delegate void efl_access_object_description_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String description);

        
        public delegate void efl_access_object_description_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String description);

        public static Efl.Eo.FunctionWrapper<efl_access_object_description_set_api_delegate> efl_access_object_description_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_description_set_api_delegate>(Module, "efl_access_object_description_set");

        private static void description_set(System.IntPtr obj, System.IntPtr pd, System.String description)
        {
            Eina.Log.Debug("function efl_access_object_description_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetDescription(description);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_description_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), description);
            }
        }

        private static efl_access_object_description_set_delegate efl_access_object_description_set_static_delegate;

        
        private delegate Efl.Access.StateSet efl_access_object_state_set_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Access.StateSet efl_access_object_state_set_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_state_set_get_api_delegate> efl_access_object_state_set_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_state_set_get_api_delegate>(Module, "efl_access_object_state_set_get");

        private static Efl.Access.StateSet state_set_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_state_set_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Access.StateSet _ret_var = default(Efl.Access.StateSet);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetStateSet();
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
                return efl_access_object_state_set_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_state_set_get_delegate efl_access_object_state_set_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_object_can_highlight_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_object_can_highlight_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_get_api_delegate> efl_access_object_can_highlight_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_get_api_delegate>(Module, "efl_access_object_can_highlight_get");

        private static bool can_highlight_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_can_highlight_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetCanHighlight();
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
                return efl_access_object_can_highlight_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_can_highlight_get_delegate efl_access_object_can_highlight_get_static_delegate;

        
        private delegate void efl_access_object_can_highlight_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool can_highlight);

        
        public delegate void efl_access_object_can_highlight_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool can_highlight);

        public static Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_set_api_delegate> efl_access_object_can_highlight_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_can_highlight_set_api_delegate>(Module, "efl_access_object_can_highlight_set");

        private static void can_highlight_set(System.IntPtr obj, System.IntPtr pd, bool can_highlight)
        {
            Eina.Log.Debug("function efl_access_object_can_highlight_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetCanHighlight(can_highlight);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_can_highlight_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), can_highlight);
            }
        }

        private static efl_access_object_can_highlight_set_delegate efl_access_object_can_highlight_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_access_object_translation_domain_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_access_object_translation_domain_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_get_api_delegate> efl_access_object_translation_domain_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_get_api_delegate>(Module, "efl_access_object_translation_domain_get");

        private static System.String translation_domain_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_translation_domain_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetTranslationDomain();
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
                return efl_access_object_translation_domain_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_translation_domain_get_delegate efl_access_object_translation_domain_get_static_delegate;

        
        private delegate void efl_access_object_translation_domain_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String domain);

        
        public delegate void efl_access_object_translation_domain_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String domain);

        public static Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_set_api_delegate> efl_access_object_translation_domain_set_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_translation_domain_set_api_delegate>(Module, "efl_access_object_translation_domain_set");

        private static void translation_domain_set(System.IntPtr obj, System.IntPtr pd, System.String domain)
        {
            Eina.Log.Debug("function efl_access_object_translation_domain_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetTranslationDomain(domain);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_translation_domain_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), domain);
            }
        }

        private static efl_access_object_translation_domain_set_delegate efl_access_object_translation_domain_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_access_object_access_root_get_delegate();

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_access_object_access_root_get_api_delegate();

        public static Efl.Eo.FunctionWrapper<efl_access_object_access_root_get_api_delegate> efl_access_object_access_root_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_access_root_get_api_delegate>(Module, "efl_access_object_access_root_get");

        private static Efl.Object access_root_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_access_root_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = Widget.GetAccessRoot();
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
                return efl_access_object_access_root_get_ptr.Value.Delegate();
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_object_gesture_do_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.GestureInfo.NativeStruct gesture_info);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_object_gesture_do_api_delegate(System.IntPtr obj,  Efl.Access.GestureInfo.NativeStruct gesture_info);

        public static Efl.Eo.FunctionWrapper<efl_access_object_gesture_do_api_delegate> efl_access_object_gesture_do_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_gesture_do_api_delegate>(Module, "efl_access_object_gesture_do");

        private static bool gesture_do(System.IntPtr obj, System.IntPtr pd, Efl.Access.GestureInfo.NativeStruct gesture_info)
        {
            Eina.Log.Debug("function efl_access_object_gesture_do was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Efl.Access.GestureInfo _in_gesture_info = gesture_info;
                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GestureDo(_in_gesture_info);
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
                return efl_access_object_gesture_do_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), gesture_info);
            }
        }

        private static efl_access_object_gesture_do_delegate efl_access_object_gesture_do_static_delegate;

        
        private delegate void efl_access_object_attribute_append_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String value);

        
        public delegate void efl_access_object_attribute_append_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String value);

        public static Efl.Eo.FunctionWrapper<efl_access_object_attribute_append_api_delegate> efl_access_object_attribute_append_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attribute_append_api_delegate>(Module, "efl_access_object_attribute_append");

        private static void attribute_append(System.IntPtr obj, System.IntPtr pd, System.String key, System.String value)
        {
            Eina.Log.Debug("function efl_access_object_attribute_append was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).AppendAttribute(key, value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_object_attribute_append_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key, value);
            }
        }

        private static efl_access_object_attribute_append_delegate efl_access_object_attribute_append_static_delegate;

        
        private delegate void efl_access_object_attribute_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        
        public delegate void efl_access_object_attribute_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_access_object_attribute_del_api_delegate> efl_access_object_attribute_del_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attribute_del_api_delegate>(Module, "efl_access_object_attribute_del");

        private static void attribute_del(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            Eina.Log.Debug("function efl_access_object_attribute_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).DelAttribute(key);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_attribute_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_access_object_attribute_del_delegate efl_access_object_attribute_del_static_delegate;

        
        private delegate void efl_access_object_attributes_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_access_object_attributes_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_attributes_clear_api_delegate> efl_access_object_attributes_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_attributes_clear_api_delegate>(Module, "efl_access_object_attributes_clear");

        private static void attributes_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_attributes_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).ClearAttributes();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_access_object_attributes_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_attributes_clear_delegate efl_access_object_attributes_clear_static_delegate;

        
        private delegate Efl.Access.Event.Handler efl_access_object_event_handler_add_delegate( Efl.EventCb cb,  System.IntPtr data);

        
        public delegate Efl.Access.Event.Handler efl_access_object_event_handler_add_api_delegate( Efl.EventCb cb,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_access_object_event_handler_add_api_delegate> efl_access_object_event_handler_add_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_event_handler_add_api_delegate>(Module, "efl_access_object_event_handler_add");

        private static Efl.Access.Event.Handler event_handler_add(System.IntPtr obj, System.IntPtr pd, Efl.EventCb cb, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_access_object_event_handler_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            Efl.Access.Event.Handler _ret_var = default(Efl.Access.Event.Handler);
                try
                {
                    _ret_var = Widget.AddEventHandler(cb, data);
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
                return efl_access_object_event_handler_add_ptr.Value.Delegate(cb, data);
            }
        }

        
        private delegate void efl_access_object_event_handler_del_delegate( Efl.Access.Event.Handler handler);

        
        public delegate void efl_access_object_event_handler_del_api_delegate( Efl.Access.Event.Handler handler);

        public static Efl.Eo.FunctionWrapper<efl_access_object_event_handler_del_api_delegate> efl_access_object_event_handler_del_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_event_handler_del_api_delegate>(Module, "efl_access_object_event_handler_del");

        private static void event_handler_del(System.IntPtr obj, System.IntPtr pd, Efl.Access.Event.Handler handler)
        {
            Eina.Log.Debug("function efl_access_object_event_handler_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    Widget.DelEventHandler(handler);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_access_object_event_handler_del_ptr.Value.Delegate(handler);
            }
        }

        
        private delegate void efl_access_object_event_emit_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject accessible,  System.IntPtr kw_event,  System.IntPtr event_info);

        
        public delegate void efl_access_object_event_emit_api_delegate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject accessible,  System.IntPtr kw_event,  System.IntPtr event_info);

        public static Efl.Eo.FunctionWrapper<efl_access_object_event_emit_api_delegate> efl_access_object_event_emit_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_event_emit_api_delegate>(Module, "efl_access_object_event_emit");

        private static void event_emit(System.IntPtr obj, System.IntPtr pd, Efl.Access.IObject accessible, System.IntPtr kw_event, System.IntPtr event_info)
        {
            Eina.Log.Debug("function efl_access_object_event_emit was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_kw_event = Eina.PrimitiveConversion.PointerToManaged<Efl.EventDescription>(kw_event);
                                                                    
                try
                {
                    Widget.EmitEvent(accessible, _in_kw_event, event_info);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_access_object_event_emit_ptr.Value.Delegate(accessible, kw_event, event_info);
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_access_object_relationship_append_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject relation_object);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_access_object_relationship_append_api_delegate(System.IntPtr obj,  Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject relation_object);

        public static Efl.Eo.FunctionWrapper<efl_access_object_relationship_append_api_delegate> efl_access_object_relationship_append_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relationship_append_api_delegate>(Module, "efl_access_object_relationship_append");

        private static bool relationship_append(System.IntPtr obj, System.IntPtr pd, Efl.Access.RelationType type, Efl.Access.IObject relation_object)
        {
            Eina.Log.Debug("function efl_access_object_relationship_append was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).AppendRelationship(type, relation_object);
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
                return efl_access_object_relationship_append_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type, relation_object);
            }
        }

        private static efl_access_object_relationship_append_delegate efl_access_object_relationship_append_static_delegate;

        
        private delegate void efl_access_object_relationship_remove_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject relation_object);

        
        public delegate void efl_access_object_relationship_remove_api_delegate(System.IntPtr obj,  Efl.Access.RelationType type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Access.IObject relation_object);

        public static Efl.Eo.FunctionWrapper<efl_access_object_relationship_remove_api_delegate> efl_access_object_relationship_remove_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relationship_remove_api_delegate>(Module, "efl_access_object_relationship_remove");

        private static void relationship_remove(System.IntPtr obj, System.IntPtr pd, Efl.Access.RelationType type, Efl.Access.IObject relation_object)
        {
            Eina.Log.Debug("function efl_access_object_relationship_remove was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).RelationshipRemove(type, relation_object);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_object_relationship_remove_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type, relation_object);
            }
        }

        private static efl_access_object_relationship_remove_delegate efl_access_object_relationship_remove_static_delegate;

        
        private delegate void efl_access_object_relationships_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_access_object_relationships_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_object_relationships_clear_api_delegate> efl_access_object_relationships_clear_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_relationships_clear_api_delegate>(Module, "efl_access_object_relationships_clear");

        private static void relationships_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_object_relationships_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).ClearRelationships();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_access_object_relationships_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_object_relationships_clear_delegate efl_access_object_relationships_clear_static_delegate;

        
        private delegate void efl_access_object_state_notify_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Access.StateSet state_types_mask, [MarshalAs(UnmanagedType.U1)] bool recursive);

        
        public delegate void efl_access_object_state_notify_api_delegate(System.IntPtr obj,  Efl.Access.StateSet state_types_mask, [MarshalAs(UnmanagedType.U1)] bool recursive);

        public static Efl.Eo.FunctionWrapper<efl_access_object_state_notify_api_delegate> efl_access_object_state_notify_ptr = new Efl.Eo.FunctionWrapper<efl_access_object_state_notify_api_delegate>(Module, "efl_access_object_state_notify");

        private static void state_notify(System.IntPtr obj, System.IntPtr pd, Efl.Access.StateSet state_types_mask, bool recursive)
        {
            Eina.Log.Debug("function efl_access_object_state_notify was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).StateNotify(state_types_mask, recursive);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_access_object_state_notify_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), state_types_mask, recursive);
            }
        }

        private static efl_access_object_state_notify_delegate efl_access_object_state_notify_static_delegate;

        
        private delegate Efl.Access.ActionData efl_access_widget_action_elm_actions_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Access.ActionData efl_access_widget_action_elm_actions_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_access_widget_action_elm_actions_get_api_delegate> efl_access_widget_action_elm_actions_get_ptr = new Efl.Eo.FunctionWrapper<efl_access_widget_action_elm_actions_get_api_delegate>(Module, "efl_access_widget_action_elm_actions_get");

        private static Efl.Access.ActionData elm_actions_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_access_widget_action_elm_actions_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Access.ActionData _ret_var = default(Efl.Access.ActionData);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetElmActions();
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
                return efl_access_widget_action_elm_actions_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_access_widget_action_elm_actions_get_delegate efl_access_widget_action_elm_actions_get_static_delegate;

        
        private delegate void efl_ui_dnd_drag_start_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  Efl.Ui.SelectionAction action,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,  uint seat);

        
        public delegate void efl_ui_dnd_drag_start_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  Efl.Ui.SelectionAction action,  IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_start_api_delegate> efl_ui_dnd_drag_start_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_start_api_delegate>(Module, "efl_ui_dnd_drag_start");

        private static void drag_start(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionFormat format, Eina.Slice data, Efl.Ui.SelectionAction action, IntPtr icon_func_data, Efl.Dnd.DragIconCreateInternal icon_func, EinaFreeCb icon_func_free_cb, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_drag_start was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                    Efl.Dnd.DragIconCreateWrapper icon_func_wrapper = new Efl.Dnd.DragIconCreateWrapper(icon_func, icon_func_data, icon_func_free_cb);
                    
                try
                {
                    ((Widget)ws.Target).DragStart(format, data, action, icon_func_wrapper.ManagedCb, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                                        
            }
            else
            {
                efl_ui_dnd_drag_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), format, data, action, icon_func_data, icon_func, icon_func_free_cb, seat);
            }
        }

        private static efl_ui_dnd_drag_start_delegate efl_ui_dnd_drag_start_static_delegate;

        
        private delegate void efl_ui_dnd_drag_action_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionAction action,  uint seat);

        
        public delegate void efl_ui_dnd_drag_action_set_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionAction action,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_action_set_api_delegate> efl_ui_dnd_drag_action_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_action_set_api_delegate>(Module, "efl_ui_dnd_drag_action_set");

        private static void drag_action_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionAction action, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_drag_action_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).SetDragAction(action, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_dnd_drag_action_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), action, seat);
            }
        }

        private static efl_ui_dnd_drag_action_set_delegate efl_ui_dnd_drag_action_set_static_delegate;

        
        private delegate void efl_ui_dnd_drag_cancel_delegate(System.IntPtr obj, System.IntPtr pd,  uint seat);

        
        public delegate void efl_ui_dnd_drag_cancel_api_delegate(System.IntPtr obj,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_cancel_api_delegate> efl_ui_dnd_drag_cancel_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drag_cancel_api_delegate>(Module, "efl_ui_dnd_drag_cancel");

        private static void drag_cancel(System.IntPtr obj, System.IntPtr pd, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_drag_cancel was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).DragCancel(seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_dnd_drag_cancel_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), seat);
            }
        }

        private static efl_ui_dnd_drag_cancel_delegate efl_ui_dnd_drag_cancel_static_delegate;

        
        private delegate void efl_ui_dnd_drop_target_add_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format,  uint seat);

        
        public delegate void efl_ui_dnd_drop_target_add_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionFormat format,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drop_target_add_api_delegate> efl_ui_dnd_drop_target_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drop_target_add_api_delegate>(Module, "efl_ui_dnd_drop_target_add");

        private static void drop_target_add(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionFormat format, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_drop_target_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).AddDropTarget(format, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_dnd_drop_target_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), format, seat);
            }
        }

        private static efl_ui_dnd_drop_target_add_delegate efl_ui_dnd_drop_target_add_static_delegate;

        
        private delegate void efl_ui_dnd_drop_target_del_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionFormat format,  uint seat);

        
        public delegate void efl_ui_dnd_drop_target_del_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionFormat format,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_dnd_drop_target_del_api_delegate> efl_ui_dnd_drop_target_del_ptr = new Efl.Eo.FunctionWrapper<efl_ui_dnd_drop_target_del_api_delegate>(Module, "efl_ui_dnd_drop_target_del");

        private static void drop_target_del(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionFormat format, uint seat)
        {
            Eina.Log.Debug("function efl_ui_dnd_drop_target_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).DelDropTarget(format, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_dnd_drop_target_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), format, seat);
            }
        }

        private static efl_ui_dnd_drop_target_del_delegate efl_ui_dnd_drop_target_del_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_l10n_text_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String domain);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_l10n_text_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] out System.String domain);

        public static Efl.Eo.FunctionWrapper<efl_ui_l10n_text_get_api_delegate> efl_ui_l10n_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_l10n_text_get_api_delegate>(Module, "efl_ui_l10n_text_get");

        private static System.String l10n_text_get(System.IntPtr obj, System.IntPtr pd, out System.String domain)
        {
            Eina.Log.Debug("function efl_ui_l10n_text_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _out_domain = default(System.String);
                    System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetL10nText(out _out_domain);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        domain = _out_domain;
                return _ret_var;

            }
            else
            {
                return efl_ui_l10n_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out domain);
            }
        }

        private static efl_ui_l10n_text_get_delegate efl_ui_l10n_text_get_static_delegate;

        
        private delegate void efl_ui_l10n_text_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String domain);

        
        public delegate void efl_ui_l10n_text_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String domain);

        public static Efl.Eo.FunctionWrapper<efl_ui_l10n_text_set_api_delegate> efl_ui_l10n_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_l10n_text_set_api_delegate>(Module, "efl_ui_l10n_text_set");

        private static void l10n_text_set(System.IntPtr obj, System.IntPtr pd, System.String label, System.String domain)
        {
            Eina.Log.Debug("function efl_ui_l10n_text_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).SetL10nText(label, domain);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_l10n_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), label, domain);
            }
        }

        private static efl_ui_l10n_text_set_delegate efl_ui_l10n_text_set_static_delegate;

        
        private delegate void efl_ui_l10n_translation_update_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_l10n_translation_update_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_l10n_translation_update_api_delegate> efl_ui_l10n_translation_update_ptr = new Efl.Eo.FunctionWrapper<efl_ui_l10n_translation_update_api_delegate>(Module, "efl_ui_l10n_translation_update");

        private static void translation_update(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_l10n_translation_update was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).UpdateTranslation();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_l10n_translation_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_l10n_translation_update_delegate efl_ui_l10n_translation_update_static_delegate;

        
        private delegate Eina.Error efl_ui_property_bind_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property);

        
        public delegate Eina.Error efl_ui_property_bind_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String property);

        public static Efl.Eo.FunctionWrapper<efl_ui_property_bind_api_delegate> efl_ui_property_bind_ptr = new Efl.Eo.FunctionWrapper<efl_ui_property_bind_api_delegate>(Module, "efl_ui_property_bind");

        private static Eina.Error property_bind(System.IntPtr obj, System.IntPtr pd, System.String key, System.String property)
        {
            Eina.Log.Debug("function efl_ui_property_bind was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((Widget)ws.Target).PropertyBind(key, property);
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
                return efl_ui_property_bind_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key, property);
            }
        }

        private static efl_ui_property_bind_delegate efl_ui_property_bind_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_ui_selection_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  uint seat);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_ui_selection_set_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  Eina.Slice data,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_selection_set_api_delegate> efl_ui_selection_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_set_api_delegate>(Module, "efl_ui_selection_set");

        private static  Eina.Future selection_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, Eina.Slice data, uint seat)
        {
            Eina.Log.Debug("function efl_ui_selection_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                             Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((Widget)ws.Target).SetSelection(type, format, data, seat);
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
                return efl_ui_selection_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type, format, data, seat);
            }
        }

        private static efl_ui_selection_set_delegate efl_ui_selection_set_static_delegate;

        
        private delegate void efl_ui_selection_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,  uint seat);

        
        public delegate void efl_ui_selection_get_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionType type,  Efl.Ui.SelectionFormat format,  IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_selection_get_api_delegate> efl_ui_selection_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_get_api_delegate>(Module, "efl_ui_selection_get");

        private static void selection_get(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionType type, Efl.Ui.SelectionFormat format, IntPtr data_func_data, Efl.Ui.SelectionDataReadyInternal data_func, EinaFreeCb data_func_free_cb, uint seat)
        {
            Eina.Log.Debug("function efl_ui_selection_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                            Efl.Ui.SelectionDataReadyWrapper data_func_wrapper = new Efl.Ui.SelectionDataReadyWrapper(data_func, data_func_data, data_func_free_cb);
                    
                try
                {
                    ((Widget)ws.Target).GetSelection(type, format, data_func_wrapper.ManagedCb, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                                        
            }
            else
            {
                efl_ui_selection_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type, format, data_func_data, data_func, data_func_free_cb, seat);
            }
        }

        private static efl_ui_selection_get_delegate efl_ui_selection_get_static_delegate;

        
        private delegate void efl_ui_selection_clear_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  uint seat);

        
        public delegate void efl_ui_selection_clear_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionType type,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_selection_clear_api_delegate> efl_ui_selection_clear_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_clear_api_delegate>(Module, "efl_ui_selection_clear");

        private static void selection_clear(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionType type, uint seat)
        {
            Eina.Log.Debug("function efl_ui_selection_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Widget)ws.Target).ClearSelection(type, seat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_selection_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type, seat);
            }
        }

        private static efl_ui_selection_clear_delegate efl_ui_selection_clear_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_selection_has_owner_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectionType type,  uint seat);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_selection_has_owner_api_delegate(System.IntPtr obj,  Efl.Ui.SelectionType type,  uint seat);

        public static Efl.Eo.FunctionWrapper<efl_ui_selection_has_owner_api_delegate> efl_ui_selection_has_owner_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selection_has_owner_api_delegate>(Module, "efl_ui_selection_has_owner");

        private static bool has_owner(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectionType type, uint seat)
        {
            Eina.Log.Debug("function efl_ui_selection_has_owner was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).HasOwner(type, seat);
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
                return efl_ui_selection_has_owner_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), type, seat);
            }
        }

        private static efl_ui_selection_has_owner_delegate efl_ui_selection_has_owner_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.IModel efl_ui_view_model_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.IModel efl_ui_view_model_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_view_model_get_api_delegate> efl_ui_view_model_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_view_model_get_api_delegate>(Module, "efl_ui_view_model_get");

        private static Efl.IModel model_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_view_model_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.IModel _ret_var = default(Efl.IModel);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetModel();
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
                return efl_ui_view_model_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_view_model_get_delegate efl_ui_view_model_get_static_delegate;

        
        private delegate void efl_ui_view_model_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IModel model);

        
        public delegate void efl_ui_view_model_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IModel model);

        public static Efl.Eo.FunctionWrapper<efl_ui_view_model_set_api_delegate> efl_ui_view_model_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_view_model_set_api_delegate>(Module, "efl_ui_view_model_set");

        private static void model_set(System.IntPtr obj, System.IntPtr pd, Efl.IModel model)
        {
            Eina.Log.Debug("function efl_ui_view_model_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetModel(model);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_view_model_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), model);
            }
        }

        private static efl_ui_view_model_set_delegate efl_ui_view_model_set_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_ui_focus_object_focus_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_ui_focus_object_focus_geometry_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_geometry_get_api_delegate> efl_ui_focus_object_focus_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_geometry_get_api_delegate>(Module, "efl_ui_focus_object_focus_geometry_get");

        private static Eina.Rect.NativeStruct focus_geometry_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_object_focus_geometry_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusGeometry();
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
                return efl_ui_focus_object_focus_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_object_focus_geometry_get_delegate efl_ui_focus_object_focus_geometry_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_focus_object_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_focus_object_focus_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_get_api_delegate> efl_ui_focus_object_focus_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_get_api_delegate>(Module, "efl_ui_focus_object_focus_get");

        private static bool focus_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_object_focus_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocus();
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
                return efl_ui_focus_object_focus_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_object_focus_get_delegate efl_ui_focus_object_focus_get_static_delegate;

        
        private delegate void efl_ui_focus_object_focus_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool focus);

        
        public delegate void efl_ui_focus_object_focus_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool focus);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_set_api_delegate> efl_ui_focus_object_focus_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_set_api_delegate>(Module, "efl_ui_focus_object_focus_set");

        private static void focus_set(System.IntPtr obj, System.IntPtr pd, bool focus)
        {
            Eina.Log.Debug("function efl_ui_focus_object_focus_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetFocus(focus);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_object_focus_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), focus);
            }
        }

        private static efl_ui_focus_object_focus_set_delegate efl_ui_focus_object_focus_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Focus.IManager efl_ui_focus_object_focus_manager_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Focus.IManager efl_ui_focus_object_focus_manager_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_manager_get_api_delegate> efl_ui_focus_object_focus_manager_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_manager_get_api_delegate>(Module, "efl_ui_focus_object_focus_manager_get");

        private static Efl.Ui.Focus.IManager focus_manager_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_object_focus_manager_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.Focus.IManager _ret_var = default(Efl.Ui.Focus.IManager);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusManager();
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
                return efl_ui_focus_object_focus_manager_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_object_focus_manager_get_delegate efl_ui_focus_object_focus_manager_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Focus.IObject efl_ui_focus_object_focus_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Focus.IObject efl_ui_focus_object_focus_parent_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_parent_get_api_delegate> efl_ui_focus_object_focus_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_focus_parent_get_api_delegate>(Module, "efl_ui_focus_object_focus_parent_get");

        private static Efl.Ui.Focus.IObject focus_parent_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_object_focus_parent_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.Focus.IObject _ret_var = default(Efl.Ui.Focus.IObject);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetFocusParent();
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
                return efl_ui_focus_object_focus_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_object_focus_parent_get_delegate efl_ui_focus_object_focus_parent_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_focus_object_child_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_focus_object_child_focus_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_get_api_delegate> efl_ui_focus_object_child_focus_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_get_api_delegate>(Module, "efl_ui_focus_object_child_focus_get");

        private static bool child_focus_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_object_child_focus_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).GetChildFocus();
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
                return efl_ui_focus_object_child_focus_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_object_child_focus_get_delegate efl_ui_focus_object_child_focus_get_static_delegate;

        
        private delegate void efl_ui_focus_object_child_focus_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool child_focus);

        
        public delegate void efl_ui_focus_object_child_focus_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool child_focus);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_set_api_delegate> efl_ui_focus_object_child_focus_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_set_api_delegate>(Module, "efl_ui_focus_object_child_focus_set");

        private static void child_focus_set(System.IntPtr obj, System.IntPtr pd, bool child_focus)
        {
            Eina.Log.Debug("function efl_ui_focus_object_child_focus_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Widget)ws.Target).SetChildFocus(child_focus);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_object_child_focus_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), child_focus);
            }
        }

        private static efl_ui_focus_object_child_focus_set_delegate efl_ui_focus_object_child_focus_set_static_delegate;

        
        private delegate void efl_ui_focus_object_setup_order_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_object_setup_order_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_setup_order_api_delegate> efl_ui_focus_object_setup_order_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_setup_order_api_delegate>(Module, "efl_ui_focus_object_setup_order");

        private static void setup_order(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_object_setup_order was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).SetupOrder();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_focus_object_setup_order_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_object_setup_order_delegate efl_ui_focus_object_setup_order_static_delegate;

        
        private delegate void efl_ui_focus_object_setup_order_non_recursive_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_object_setup_order_non_recursive_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_setup_order_non_recursive_api_delegate> efl_ui_focus_object_setup_order_non_recursive_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_setup_order_non_recursive_api_delegate>(Module, "efl_ui_focus_object_setup_order_non_recursive");

        private static void setup_order_non_recursive(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_object_setup_order_non_recursive was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Widget)ws.Target).SetupOrderNonRecursive();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_focus_object_setup_order_non_recursive_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_object_setup_order_non_recursive_delegate efl_ui_focus_object_setup_order_non_recursive_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_focus_object_on_focus_update_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_focus_object_on_focus_update_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_on_focus_update_api_delegate> efl_ui_focus_object_on_focus_update_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_on_focus_update_api_delegate>(Module, "efl_ui_focus_object_on_focus_update");

        private static bool on_focus_update(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_object_on_focus_update was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Widget)ws.Target).UpdateOnFocus();
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
                return efl_ui_focus_object_on_focus_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_object_on_focus_update_delegate efl_ui_focus_object_on_focus_update_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

namespace Efl {

namespace Ui {

/// <summary>All relevant fields needed for the current state of focus registration
/// (Since EFL 1.22)</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct WidgetFocusState
{
    /// <summary>The manager where the widget is registered in</summary>
    public Efl.Ui.Focus.IManager Manager;
    /// <summary>The parent the widget is using as logical parent</summary>
    public Efl.Ui.Focus.IObject Parent;
    /// <summary><c>true</c> if this is registered as logical currently</summary>
    public bool Logical;
    ///<summary>Constructor for WidgetFocusState.</summary>
    public WidgetFocusState(
        Efl.Ui.Focus.IManager Manager = default(Efl.Ui.Focus.IManager),
        Efl.Ui.Focus.IObject Parent = default(Efl.Ui.Focus.IObject),
        bool Logical = default(bool)    )
    {
        this.Manager = Manager;
        this.Parent = Parent;
        this.Logical = Logical;
    }

    ///<summary>Implicit conversion to the managed representation from a native pointer.</summary>
    ///<param name="ptr">Native pointer to be converted.</param>
    public static implicit operator WidgetFocusState(IntPtr ptr)
    {
        var tmp = (WidgetFocusState.NativeStruct)Marshal.PtrToStructure(ptr, typeof(WidgetFocusState.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    ///<summary>Internal wrapper for struct WidgetFocusState.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        ///<summary>Internal wrapper for field Manager</summary>
        public System.IntPtr Manager;
        ///<summary>Internal wrapper for field Parent</summary>
        public System.IntPtr Parent;
        ///<summary>Internal wrapper for field Logical</summary>
        public System.Byte Logical;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator WidgetFocusState.NativeStruct(WidgetFocusState _external_struct)
        {
            var _internal_struct = new WidgetFocusState.NativeStruct();
            _internal_struct.Manager = _external_struct.Manager?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Parent = _external_struct.Parent?.NativeHandle ?? System.IntPtr.Zero;
            _internal_struct.Logical = _external_struct.Logical ? (byte)1 : (byte)0;
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator WidgetFocusState(WidgetFocusState.NativeStruct _internal_struct)
        {
            var _external_struct = new WidgetFocusState();

            _external_struct.Manager = (Efl.Ui.Focus.IManagerConcrete) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Manager);

            _external_struct.Parent = (Efl.Ui.Focus.IObjectConcrete) Efl.Eo.Globals.CreateWrapperFor(_internal_struct.Parent);
            _external_struct.Logical = _internal_struct.Logical != 0;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

