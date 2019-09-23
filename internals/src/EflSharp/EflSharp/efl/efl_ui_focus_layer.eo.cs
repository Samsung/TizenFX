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

/// <summary>This defines the widget as a focus layer.
/// A focus layer is the uppermost widget which receives input and handles all focus related events for as long as it exists and is visible. It&apos;s not possible to escape this layer with focus movements.
/// 
/// Once the object is hidden or destroyed the focus will go back to the main window, where it was before.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Focus.LayerConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface ILayer : 
    Efl.Ui.IWidgetFocusManager ,
    Efl.Eo.IWrapper, IDisposable
{
                                }
/// <summary>This defines the widget as a focus layer.
/// A focus layer is the uppermost widget which receives input and handles all focus related events for as long as it exists and is visible. It&apos;s not possible to escape this layer with focus movements.
/// 
/// Once the object is hidden or destroyed the focus will go back to the main window, where it was before.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class LayerConcrete :
    Efl.Eo.EoWrapper
    , ILayer
    , Efl.Ui.IWidgetFocusManager, Efl.Ui.Focus.IManager
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(LayerConcrete))
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
    private LayerConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_focus_layer_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="ILayer"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private LayerConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
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
#pragma warning disable CS0628
    /// <summary>Whether the focus layer is enabled. This can be handled automatically through <see cref="Efl.Gfx.IEntity.Visible"/> and Efl.Ui.Focus.Layer.behaviour.</summary>
    /// <returns><c>true</c> to set enable.</returns>
    protected bool GetEnable() {
         var _ret_var = Efl.Ui.Focus.LayerConcrete.NativeMethods.efl_ui_focus_layer_enable_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether the focus layer is enabled. This can be handled automatically through <see cref="Efl.Gfx.IEntity.Visible"/> and Efl.Ui.Focus.Layer.behaviour.</summary>
    /// <param name="v"><c>true</c> to set enable.</param>
    protected void SetEnable(bool v) {
                                 Efl.Ui.Focus.LayerConcrete.NativeMethods.efl_ui_focus_layer_enable_set_ptr.Value.Delegate(this.NativeHandle,v);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Sets the behaviour of the focus layer.</summary>
    /// <param name="enable_on_visible"><c>true</c> means layer will enable itself once the widget becomes visible</param>
    /// <param name="cycle">If <c>true</c> the focus will cycle (from last object to first, and vice versa) in the layer.</param>
    protected void GetBehaviour(out bool enable_on_visible, out bool cycle) {
                                                         Efl.Ui.Focus.LayerConcrete.NativeMethods.efl_ui_focus_layer_behaviour_get_ptr.Value.Delegate(this.NativeHandle,out enable_on_visible, out cycle);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Sets the behaviour of the focus layer.</summary>
    /// <param name="enable_on_visible"><c>true</c> means layer will enable itself once the widget becomes visible</param>
    /// <param name="cycle">If <c>true</c> the focus will cycle (from last object to first, and vice versa) in the layer.</param>
    protected void SetBehaviour(bool enable_on_visible, bool cycle) {
                                                         Efl.Ui.Focus.LayerConcrete.NativeMethods.efl_ui_focus_layer_behaviour_set_ptr.Value.Delegate(this.NativeHandle,enable_on_visible, cycle);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>If the widget needs a focus manager, this function will be called.
    /// It can be used and overridden to inject your own manager or set custom options on the focus manager.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">The logical root object for focus.</param>
    /// <returns>The focus manager.</returns>
    protected Efl.Ui.Focus.IManager FocusManagerCreate(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.WidgetFocusManagerConcrete.NativeMethods.efl_ui_widget_focus_manager_create_ptr.Value.Delegate(this.NativeHandle,root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The element which is currently focused by this manager.
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next regular object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <returns>Currently focused element.</returns>
    public Efl.Ui.Focus.IObject GetManagerFocus() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_focus_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The element which is currently focused by this manager.
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next regular object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <param name="focus">Currently focused element.</param>
    public void SetManagerFocus(Efl.Ui.Focus.IObject focus) {
                                 Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_focus_set_ptr.Value.Delegate(this.NativeHandle,focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <returns>The new focus manager.</returns>
    public Efl.Ui.Focus.IManager GetRedirect() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_redirect_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <param name="redirect">The new focus manager.</param>
    public void SetRedirect(Efl.Ui.Focus.IManager redirect) {
                                 Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_redirect_set_ptr.Value.Delegate(this.NativeHandle,redirect);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Elements which are at the border of the graph.
    /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.IManager.Move"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>An iterator over the border objects.</returns>
    public Eina.Iterator<Efl.Ui.Focus.IObject> GetBorderElements() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_border_elements_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Ui.Focus.IObject>(_ret_var, false);
 }
    /// <summary>Elements that are at the border of the viewport
    /// Every element returned by this is located inside the viewport rectangle, but has a right, left, down or up neighbor outside the viewport.
    /// (Since EFL 1.22)</summary>
    /// <param name="viewport">The rectangle defining the viewport.</param>
    /// <returns>An iterator over the viewport border objects.</returns>
    public Eina.Iterator<Efl.Ui.Focus.IObject> GetViewportElements(Eina.Rect viewport) {
         Eina.Rect.NativeStruct _in_viewport = viewport;
                        var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_viewport_elements_get_ptr.Value.Delegate(this.NativeHandle,_in_viewport);
        Eina.Error.RaiseIfUnhandledException();
                        return new Eina.Iterator<Efl.Ui.Focus.IObject>(_ret_var, false);
 }
    /// <summary>Root node for all logical sub-trees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <returns>Object to register as the root of this manager object.</returns>
    public Efl.Ui.Focus.IObject GetRoot() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_root_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Root node for all logical sub-trees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">Object to register as the root of this manager object.</param>
    /// <returns><c>true</c> on success, <c>false</c> if it had already been set.</returns>
    public bool SetRoot(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_root_set_ptr.Value.Delegate(this.NativeHandle,root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Moves the focus in the given direction to the next regular widget.
    /// This call flushes all changes. This means all changes since last flush are computed.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">The direction to move to.</param>
    /// <returns>The element which is now focused.</returns>
    public Efl.Ui.Focus.IObject Move(Efl.Ui.Focus.Direction direction) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_move_ptr.Value.Delegate(this.NativeHandle,direction);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Returns the object in the <c>direction</c> from <c>child</c>.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">Direction to move focus.</param>
    /// <param name="child">The child to move from. Pass <c>null</c> to indicate the currently focused child.</param>
    /// <param name="logical">Wether you want to have a logical node as result or a regular. Note that in a <see cref="Efl.Ui.Focus.IManager.Move"/> call logical nodes will not get focus.</param>
    /// <returns>Object that would receive focus if moved in the given direction.</returns>
    public Efl.Ui.Focus.IObject MoveRequest(Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject child, bool logical) {
                                                                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_request_move_ptr.Value.Delegate(this.NativeHandle,direction, child, logical);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Returns the widget in the direction next.
    /// The returned widget is a child of <c>root</c>. It&apos;s guaranteed that child will not be prepared again, so you can call this function inside a <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> call.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">Parent for returned child.</param>
    /// <returns>Child of passed parameter.</returns>
    public Efl.Ui.Focus.IObject RequestSubchild(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_request_subchild_ptr.Value.Delegate(this.NativeHandle,root);
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
    public Efl.Ui.Focus.Relations Fetch(Efl.Ui.Focus.IObject child) {
                                 var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_fetch_ptr.Value.Delegate(this.NativeHandle,child);
        Eina.Error.RaiseIfUnhandledException();
                        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.Focus.Relations>(_ret_var);
        Marshal.FreeHGlobal(_ret_var);
        return __ret_tmp;
 }
    /// <summary>Returns the last logical object.
    /// The returned object is the last object that would be returned if you start at the root and move in the &quot;next&quot; direction.
    /// (Since EFL 1.22)</summary>
    /// <returns>Last object.</returns>
    public Efl.Ui.Focus.ManagerLogicalEndDetail LogicalEnd() {
         var _ret_var = Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_logical_end_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Resets the history stack of this manager object. This means the uppermost element will be unfocused, and all other elements will be removed from the remembered list.
    /// You should focus another element immediately after calling this, in order to always have a focused object.
    /// (Since EFL 1.22)</summary>
    public void ResetHistory() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_reset_history_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Removes the uppermost history element, and focuses the previous one.
    /// If there is an element that was focused before, it will be used. Otherwise, the best fitting element from the registered elements will be focused.
    /// (Since EFL 1.22)</summary>
    public void PopHistoryStack() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_pop_history_stack_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Called when this manager is set as redirect.
    /// In case that this is called as a result of a move call, <c>direction</c> and <c>entry</c> will be set to the direction of the move call, and the <c>entry</c> object will be set to the object that had this manager as redirect property.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">The direction in which this should be setup.</param>
    /// <param name="entry">The object that caused this manager to be redirect.</param>
    public void SetupOnFirstTouch(Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject entry) {
                                                         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_setup_on_first_touch_ptr.Value.Delegate(this.NativeHandle,direction, entry);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Disables the cache invalidation when an object is moved.
    /// Even if an object is moved, the focus manager will not recalculate its relations. This can be used when you know that the set of widgets in the focus manager is moved the same way, so the relations between the widgets in the set do not change and complex calculations can be avoided. Use <see cref="Efl.Ui.Focus.IManager.DirtyLogicUnfreeze"/> to re-enable relationship calculation.
    /// (Since EFL 1.22)</summary>
    public void FreezeDirtyLogic() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_dirty_logic_freeze_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Enables the cache invalidation when an object is moved.
    /// This is the counterpart to <see cref="Efl.Ui.Focus.IManager.FreezeDirtyLogic"/>.
    /// (Since EFL 1.22)</summary>
    public void DirtyLogicUnfreeze() {
         Efl.Ui.Focus.ManagerConcrete.NativeMethods.efl_ui_focus_manager_dirty_logic_unfreeze_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Whether the focus layer is enabled. This can be handled automatically through <see cref="Efl.Gfx.IEntity.Visible"/> and Efl.Ui.Focus.Layer.behaviour.</summary>
    /// <value><c>true</c> to set enable.</value>
    protected bool Enable {
        get { return GetEnable(); }
        set { SetEnable(value); }
    }
    /// <summary>Sets the behaviour of the focus layer.</summary>
    /// <value><c>true</c> means layer will enable itself once the widget becomes visible</value>
    protected (bool, bool) Behaviour {
        get {
            bool _out_enable_on_visible = default(bool);
            bool _out_cycle = default(bool);
            GetBehaviour(out _out_enable_on_visible,out _out_cycle);
            return (_out_enable_on_visible,_out_cycle);
        }
        set { SetBehaviour( value.Item1,  value.Item2); }
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
#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Focus.LayerConcrete.efl_ui_focus_layer_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
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
            return Efl.Ui.Focus.LayerConcrete.efl_ui_focus_layer_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_focus_layer_enable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_focus_layer_enable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_layer_enable_get_api_delegate> efl_ui_focus_layer_enable_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_layer_enable_get_api_delegate>(Module, "efl_ui_focus_layer_enable_get");

        
        private delegate void efl_ui_focus_layer_enable_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool v);

        
        public delegate void efl_ui_focus_layer_enable_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool v);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_layer_enable_set_api_delegate> efl_ui_focus_layer_enable_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_layer_enable_set_api_delegate>(Module, "efl_ui_focus_layer_enable_set");

        
        private delegate void efl_ui_focus_layer_behaviour_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool enable_on_visible, [MarshalAs(UnmanagedType.U1)] out bool cycle);

        
        public delegate void efl_ui_focus_layer_behaviour_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool enable_on_visible, [MarshalAs(UnmanagedType.U1)] out bool cycle);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_layer_behaviour_get_api_delegate> efl_ui_focus_layer_behaviour_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_layer_behaviour_get_api_delegate>(Module, "efl_ui_focus_layer_behaviour_get");

        
        private delegate void efl_ui_focus_layer_behaviour_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable_on_visible, [MarshalAs(UnmanagedType.U1)] bool cycle);

        
        public delegate void efl_ui_focus_layer_behaviour_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable_on_visible, [MarshalAs(UnmanagedType.U1)] bool cycle);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_layer_behaviour_set_api_delegate> efl_ui_focus_layer_behaviour_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_layer_behaviour_set_api_delegate>(Module, "efl_ui_focus_layer_behaviour_set");

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Focus.IManager efl_ui_widget_focus_manager_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject root);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Focus.IManager efl_ui_widget_focus_manager_create_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Focus.IObject root);

        public static Efl.Eo.FunctionWrapper<efl_ui_widget_focus_manager_create_api_delegate> efl_ui_widget_focus_manager_create_ptr = new Efl.Eo.FunctionWrapper<efl_ui_widget_focus_manager_create_api_delegate>(Module, "efl_ui_widget_focus_manager_create");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Ui_FocusLayerConcrete_ExtensionMethods {
    public static Efl.BindableProperty<bool> Enable<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Focus.ILayer, T>magic = null) where T : Efl.Ui.Focus.ILayer {
        return new Efl.BindableProperty<bool>("enable", fac);
    }

    
    public static Efl.BindableProperty<Efl.Ui.Focus.IObject> ManagerFocus<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Focus.ILayer, T>magic = null) where T : Efl.Ui.Focus.ILayer {
        return new Efl.BindableProperty<Efl.Ui.Focus.IObject>("manager_focus", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.Focus.IManager> Redirect<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Focus.ILayer, T>magic = null) where T : Efl.Ui.Focus.ILayer {
        return new Efl.BindableProperty<Efl.Ui.Focus.IManager>("redirect", fac);
    }

    
    
    public static Efl.BindableProperty<Efl.Ui.Focus.IObject> Root<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Focus.ILayer, T>magic = null) where T : Efl.Ui.Focus.ILayer {
        return new Efl.BindableProperty<Efl.Ui.Focus.IObject>("root", fac);
    }

}
#pragma warning restore CS1591
#endif
