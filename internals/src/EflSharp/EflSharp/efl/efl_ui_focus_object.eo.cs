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

namespace Focus {

/// <summary>Functions of focusable objects.</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.Ui.Focus.ObjectConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IObject : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The geometry (that is, the bounding rectangle) used to calculate the relationship with other objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The geometry to use.</returns>
    Eina.Rect GetFocusGeometry();

    /// <summary>Whether the widget is currently focused or not.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The focused state of the object.</returns>
    bool GetFocus();

    /// <summary>This is the focus manager where this focus object is registered in. The element which is the <c>root</c> of an <see cref="Efl.Ui.Focus.IManager"/> will not have this focus manager as this object, but rather the focus manager where that is registered in.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The manager object.</returns>
    Efl.Ui.Focus.IManager GetFocusManager();

    /// <summary>The logical parent used by this object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The focus parent.</returns>
    Efl.Ui.Focus.IObject GetFocusParent();

    /// <summary>Tells the object that its children will be queried soon by the focus manager. Overwrite this to have a chance to update the order of the children. Deleting items in this call will result in undefined behaviour and may cause your system to crash.</summary>
    /// <since_tizen> 6 </since_tizen>
    void SetupOrder();

    /// <summary>Emitted if the focus state has changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.Focus.ObjectFocusChangedEventArgs"/></value>
    event EventHandler<Efl.Ui.Focus.ObjectFocusChangedEventArgs> FocusChangedEvent;
    /// <summary>Emitted when a new manager is the parent for this object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.Focus.ObjectFocusManagerChangedEventArgs"/></value>
    event EventHandler<Efl.Ui.Focus.ObjectFocusManagerChangedEventArgs> FocusManagerChangedEvent;
    /// <summary>Emitted when a new logical parent should be used.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.Focus.ObjectFocusParentChangedEventArgs"/></value>
    event EventHandler<Efl.Ui.Focus.ObjectFocusParentChangedEventArgs> FocusParentChangedEvent;
    /// <summary>Emitted if child_focus has changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.Focus.ObjectChildFocusChangedEventArgs"/></value>
    event EventHandler<Efl.Ui.Focus.ObjectChildFocusChangedEventArgs> ChildFocusChangedEvent;
    /// <summary>Emitted if focus geometry of this object has changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.Focus.ObjectFocusGeometryChangedEventArgs"/></value>
    event EventHandler<Efl.Ui.Focus.ObjectFocusGeometryChangedEventArgs> FocusGeometryChangedEvent;
    /// <summary>The geometry (that is, the bounding rectangle) used to calculate the relationship with other objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The geometry to use.</value>
    Eina.Rect FocusGeometry {
        get;
    }

    /// <summary>Whether the widget is currently focused or not.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The focused state of the object.</value>
    bool Focus {
        get;
    }

    /// <summary>This is the focus manager where this focus object is registered in. The element which is the <c>root</c> of an <see cref="Efl.Ui.Focus.IManager"/> will not have this focus manager as this object, but rather the focus manager where that is registered in.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The manager object.</value>
    Efl.Ui.Focus.IManager FocusManager {
        get;
    }

    /// <summary>The logical parent used by this object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The focus parent.</value>
    Efl.Ui.Focus.IObject FocusParent {
        get;
    }

}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.IObject.FocusChangedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ObjectFocusChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted if the focus state has changed.</value>
    public bool arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.IObject.FocusManagerChangedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ObjectFocusManagerChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted when a new manager is the parent for this object.</value>
    public Efl.Ui.Focus.IManager arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.IObject.FocusParentChangedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ObjectFocusParentChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted when a new logical parent should be used.</value>
    public Efl.Ui.Focus.IObject arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.IObject.ChildFocusChangedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ObjectChildFocusChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted if child_focus has changed.</value>
    public bool arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.Focus.IObject.FocusGeometryChangedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class ObjectFocusGeometryChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted if focus geometry of this object has changed.</value>
    public Eina.Rect arg { get; set; }
}

/// <summary>Functions of focusable objects.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class ObjectConcrete :
    Efl.Eo.EoWrapper
    , IObject
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(ObjectConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private ObjectConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_focus_object_mixin_get();

    /// <summary>Initializes a new instance of the <see cref="IObject"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private ObjectConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Emitted if the focus state has changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.Focus.ObjectFocusChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ObjectFocusChangedEventArgs> FocusChangedEvent
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
                        Efl.Ui.Focus.ObjectFocusChangedEventArgs args = new Efl.Ui.Focus.ObjectFocusChangedEventArgs();
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

    /// <summary>Method to raise event FocusChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFocusChangedEvent(Efl.Ui.Focus.ObjectFocusChangedEventArgs e)
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

    /// <summary>Emitted when a new manager is the parent for this object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.Focus.ObjectFocusManagerChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ObjectFocusManagerChangedEventArgs> FocusManagerChangedEvent
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
                        Efl.Ui.Focus.ObjectFocusManagerChangedEventArgs args = new Efl.Ui.Focus.ObjectFocusManagerChangedEventArgs();
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

    /// <summary>Method to raise event FocusManagerChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFocusManagerChangedEvent(Efl.Ui.Focus.ObjectFocusManagerChangedEventArgs e)
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

    /// <summary>Emitted when a new logical parent should be used.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.Focus.ObjectFocusParentChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ObjectFocusParentChangedEventArgs> FocusParentChangedEvent
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
                        Efl.Ui.Focus.ObjectFocusParentChangedEventArgs args = new Efl.Ui.Focus.ObjectFocusParentChangedEventArgs();
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

    /// <summary>Method to raise event FocusParentChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFocusParentChangedEvent(Efl.Ui.Focus.ObjectFocusParentChangedEventArgs e)
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

    /// <summary>Emitted if child_focus has changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.Focus.ObjectChildFocusChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ObjectChildFocusChangedEventArgs> ChildFocusChangedEvent
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
                        Efl.Ui.Focus.ObjectChildFocusChangedEventArgs args = new Efl.Ui.Focus.ObjectChildFocusChangedEventArgs();
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

    /// <summary>Method to raise event ChildFocusChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnChildFocusChangedEvent(Efl.Ui.Focus.ObjectChildFocusChangedEventArgs e)
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

    /// <summary>Emitted if focus geometry of this object has changed.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="Efl.Ui.Focus.ObjectFocusGeometryChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.Focus.ObjectFocusGeometryChangedEventArgs> FocusGeometryChangedEvent
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
                        Efl.Ui.Focus.ObjectFocusGeometryChangedEventArgs args = new Efl.Ui.Focus.ObjectFocusGeometryChangedEventArgs();
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

    /// <summary>Method to raise event FocusGeometryChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnFocusGeometryChangedEvent(Efl.Ui.Focus.ObjectFocusGeometryChangedEventArgs e)
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


#pragma warning disable CS0628
    /// <summary>The geometry (that is, the bounding rectangle) used to calculate the relationship with other objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The geometry to use.</returns>
    public Eina.Rect GetFocusGeometry() {
        var _ret_var = Efl.Ui.Focus.ObjectConcrete.NativeMethods.efl_ui_focus_object_focus_geometry_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Whether the widget is currently focused or not.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The focused state of the object.</returns>
    public bool GetFocus() {
        var _ret_var = Efl.Ui.Focus.ObjectConcrete.NativeMethods.efl_ui_focus_object_focus_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>This is called by the manager and should never be called by anyone else.
    /// The function emits the focus state events, if focus is different to the previous state.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="focus">The focused state of the object.</param>
    protected void SetFocus(bool focus) {
        Efl.Ui.Focus.ObjectConcrete.NativeMethods.efl_ui_focus_object_focus_set_ptr.Value.Delegate(this.NativeHandle,focus);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This is the focus manager where this focus object is registered in. The element which is the <c>root</c> of an <see cref="Efl.Ui.Focus.IManager"/> will not have this focus manager as this object, but rather the focus manager where that is registered in.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The manager object.</returns>
    public Efl.Ui.Focus.IManager GetFocusManager() {
        var _ret_var = Efl.Ui.Focus.ObjectConcrete.NativeMethods.efl_ui_focus_object_focus_manager_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The logical parent used by this object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The focus parent.</returns>
    public Efl.Ui.Focus.IObject GetFocusParent() {
        var _ret_var = Efl.Ui.Focus.ObjectConcrete.NativeMethods.efl_ui_focus_object_focus_parent_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Indicates if a child of this object has focus set to true.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if a child has focus.</returns>
    protected bool GetChildFocus() {
        var _ret_var = Efl.Ui.Focus.ObjectConcrete.NativeMethods.efl_ui_focus_object_child_focus_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Indicates if a child of this object has focus set to true.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="child_focus"><c>true</c> if a child has focus.</param>
    protected void SetChildFocus(bool child_focus) {
        Efl.Ui.Focus.ObjectConcrete.NativeMethods.efl_ui_focus_object_child_focus_set_ptr.Value.Delegate(this.NativeHandle,child_focus);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Tells the object that its children will be queried soon by the focus manager. Overwrite this to have a chance to update the order of the children. Deleting items in this call will result in undefined behaviour and may cause your system to crash.</summary>
    /// <since_tizen> 6 </since_tizen>
    public void SetupOrder() {
        Efl.Ui.Focus.ObjectConcrete.NativeMethods.efl_ui_focus_object_setup_order_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This is called when <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> is called, but only on the first call, additional recursive calls to <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> will not call this function again.</summary>
    /// <since_tizen> 6 </since_tizen>
    protected void SetupOrderNonRecursive() {
        Efl.Ui.Focus.ObjectConcrete.NativeMethods.efl_ui_focus_object_setup_order_non_recursive_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Virtual function handling focus in/out events on the widget.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if this widget can handle focus, <c>false</c> otherwise.</returns>
    protected bool UpdateOnFocus() {
        var _ret_var = Efl.Ui.Focus.ObjectConcrete.NativeMethods.efl_ui_focus_object_on_focus_update_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The geometry (that is, the bounding rectangle) used to calculate the relationship with other objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The geometry to use.</value>
    public Eina.Rect FocusGeometry {
        get { return GetFocusGeometry(); }
    }

    /// <summary>Whether the widget is currently focused or not.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The focused state of the object.</value>
    public bool Focus {
        get { return GetFocus(); }
        protected set { SetFocus(value); }
    }

    /// <summary>This is the focus manager where this focus object is registered in. The element which is the <c>root</c> of an <see cref="Efl.Ui.Focus.IManager"/> will not have this focus manager as this object, but rather the focus manager where that is registered in.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The manager object.</value>
    public Efl.Ui.Focus.IManager FocusManager {
        get { return GetFocusManager(); }
    }

    /// <summary>The logical parent used by this object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The focus parent.</value>
    public Efl.Ui.Focus.IObject FocusParent {
        get { return GetFocusParent(); }
    }

    /// <summary>Indicates if a child of this object has focus set to true.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if a child has focus.</value>
    protected bool ChildFocus {
        get { return GetChildFocus(); }
        set { SetChildFocus(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

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

            if (efl_ui_focus_object_setup_order_static_delegate == null)
            {
                efl_ui_focus_object_setup_order_static_delegate = new efl_ui_focus_object_setup_order_delegate(setup_order);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetupOrder") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_object_setup_order"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_object_setup_order_static_delegate) });
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
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Focus.ObjectConcrete.efl_ui_focus_object_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
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
                    _ret_var = ((IObject)ws.Target).GetFocusGeometry();
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
                    _ret_var = ((IObject)ws.Target).GetFocus();
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
                    _ret_var = ((IObject)ws.Target).GetFocusManager();
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
                    _ret_var = ((IObject)ws.Target).GetFocusParent();
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

        
        private delegate void efl_ui_focus_object_child_focus_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool child_focus);

        
        public delegate void efl_ui_focus_object_child_focus_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool child_focus);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_set_api_delegate> efl_ui_focus_object_child_focus_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_child_focus_set_api_delegate>(Module, "efl_ui_focus_object_child_focus_set");

        
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
                    ((IObject)ws.Target).SetupOrder();
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

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_focus_object_on_focus_update_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_focus_object_on_focus_update_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_object_on_focus_update_api_delegate> efl_ui_focus_object_on_focus_update_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_object_on_focus_update_api_delegate>(Module, "efl_ui_focus_object_on_focus_update");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Ui_FocusObjectConcrete_ExtensionMethods {
    public static Efl.BindableProperty<bool> Focus<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Focus.IObject, T>magic = null) where T : Efl.Ui.Focus.IObject {
        return new Efl.BindableProperty<bool>("focus", fac);
    }

    public static Efl.BindableProperty<bool> ChildFocus<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Focus.IObject, T>magic = null) where T : Efl.Ui.Focus.IObject {
        return new Efl.BindableProperty<bool>("child_focus", fac);
    }

}
#pragma warning restore CS1591
#endif
