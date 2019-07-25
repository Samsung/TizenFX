#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>No description supplied.
/// (Since EFL 1.22)</summary>
[Efl.Ui.IWidgetFocusManagerConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IWidgetFocusManager : 
    Efl.Ui.Focus.IManager ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>If the widget needs a focus manager, this function will be called.
/// It can be used and overriden to inject your own manager or set custom options on the focus manager.
/// (Since EFL 1.22)</summary>
/// <param name="root">The logical root object for focus.</param>
/// <returns>The focus manager.</returns>
Efl.Ui.Focus.IManager FocusManagerCreate(Efl.Ui.Focus.IObject root);
    }
/// <summary>No description supplied.
/// (Since EFL 1.22)</summary>
sealed public class IWidgetFocusManagerConcrete :
    Efl.Eo.EoWrapper
    , IWidgetFocusManager
    , Efl.Ui.Focus.IManager
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IWidgetFocusManagerConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private IWidgetFocusManagerConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_widget_focus_manager_mixin_get();
    /// <summary>Initializes a new instance of the <see cref="IWidgetFocusManager"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IWidgetFocusManagerConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Redirect object has changed, the old manager is passed as an event argument.
    /// (Since EFL 1.22)</summary>
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
    ///<summary>Method to raise event RedirectChangedEvt.</summary>
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
    ///<summary>Method to raise event FlushPreEvt.</summary>
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
    ///<summary>Method to raise event CoordsDirtyEvt.</summary>
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
    ///<summary>Method to raise event ManagerFocusChangedEvt.</summary>
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
    ///<summary>Method to raise event DirtyLogicFreezeChangedEvt.</summary>
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
    /// <summary>If the widget needs a focus manager, this function will be called.
    /// It can be used and overriden to inject your own manager or set custom options on the focus manager.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">The logical root object for focus.</param>
    /// <returns>The focus manager.</returns>
    public Efl.Ui.Focus.IManager FocusManagerCreate(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.IWidgetFocusManagerConcrete.NativeMethods.efl_ui_widget_focus_manager_create_ptr.Value.Delegate(this.NativeHandle,root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The element which is currently focused by this manager
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next non-logical object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <returns>Currently focused element.</returns>
    public Efl.Ui.Focus.IObject GetManagerFocus() {
         var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_focus_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The element which is currently focused by this manager
    /// Use this property to retrieve the object currently being focused, or to set the focus to a new one. When <c>focus</c> is a logical child (which cannot receive focus), the next non-logical object is selected instead. If there is no such object, focus does not change.
    /// (Since EFL 1.22)</summary>
    /// <param name="focus">Currently focused element.</param>
    public void SetManagerFocus(Efl.Ui.Focus.IObject focus) {
                                 Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_focus_set_ptr.Value.Delegate(this.NativeHandle,focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <returns>The redirect manager.</returns>
    public Efl.Ui.Focus.IManager GetRedirect() {
         var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_redirect_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Add another manager to serve the move requests.
    /// If this value is set, all move requests are redirected to this manager object. Set it to <c>null</c> once nothing should be redirected anymore.
    /// (Since EFL 1.22)</summary>
    /// <param name="redirect">The redirect manager.</param>
    public void SetRedirect(Efl.Ui.Focus.IManager redirect) {
                                 Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_redirect_set_ptr.Value.Delegate(this.NativeHandle,redirect);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The list of elements which are at the border of the graph.
    /// This means one of the relations right,left or down,up are not set. This call flushes all changes. See <see cref="Efl.Ui.Focus.IManager.Move"/>
    /// (Since EFL 1.22)</summary>
    /// <returns>An iterator over the border objects.</returns>
    public Eina.Iterator<Efl.Ui.Focus.IObject> GetBorderElements() {
         var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_border_elements_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Ui.Focus.IObject>(_ret_var, false);
 }
    /// <summary>Get all elements that are at the border of the viewport
    /// Every element returned by this is located inside the viewport rectangle, but has a right, left, down or up neighbor outside the viewport.
    /// (Since EFL 1.22)</summary>
    /// <param name="viewport">The rectangle defining the viewport.</param>
    /// <returns>The list of border objects.</returns>
    public Eina.Iterator<Efl.Ui.Focus.IObject> GetViewportElements(Eina.Rect viewport) {
         Eina.Rect.NativeStruct _in_viewport = viewport;
                        var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_viewport_elements_get_ptr.Value.Delegate(this.NativeHandle,_in_viewport);
        Eina.Error.RaiseIfUnhandledException();
                        return new Eina.Iterator<Efl.Ui.Focus.IObject>(_ret_var, false);
 }
    /// <summary>Root node for all logical subtrees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <returns>Will be registered into this manager object.</returns>
    public Efl.Ui.Focus.IObject GetRoot() {
         var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_root_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Root node for all logical subtrees.
    /// This property can only be set once.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">Will be registered into this manager object.</param>
    /// <returns>If <c>true</c>, this is the root node</returns>
    public bool SetRoot(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_root_set_ptr.Value.Delegate(this.NativeHandle,root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Move the focus in the given direction.
    /// This call flushes all changes. This means all changes between the last flush and now are computed.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">The direction to move to.</param>
    /// <returns>The element which is now focused.</returns>
    public Efl.Ui.Focus.IObject Move(Efl.Ui.Focus.Direction direction) {
                                 var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_move_ptr.Value.Delegate(this.NativeHandle,direction);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Return the object in the <c>direction</c> from <c>child</c>.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">Direction to move focus.</param>
    /// <param name="child">The child to move from. Pass <c>null</c> to indicate the currently focused child.</param>
    /// <param name="logical">Wether you want to have a logical node as result or a non-logical. Note, in a <see cref="Efl.Ui.Focus.IManager.Move"/> call no logical node will get focus.</param>
    /// <returns>Object that would receive focus if moved in the given direction.</returns>
    public Efl.Ui.Focus.IObject MoveRequest(Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject child, bool logical) {
                                                                                 var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_request_move_ptr.Value.Delegate(this.NativeHandle,direction, child, logical);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>Return the widget in the direction next.
    /// The returned widget is a child of <c>root</c>. It&apos;s guaranteed that child will not be prepared once again, so you can call this function inside a <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> call.
    /// (Since EFL 1.22)</summary>
    /// <param name="root">Parent for returned child.</param>
    /// <returns>Child of passed parameter.</returns>
    public Efl.Ui.Focus.IObject RequestSubchild(Efl.Ui.Focus.IObject root) {
                                 var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_request_subchild_ptr.Value.Delegate(this.NativeHandle,root);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>This will fetch the data from a registered node.
    /// Be aware this function will trigger a computation of all dirty nodes.
    /// (Since EFL 1.22)</summary>
    /// <param name="child">The child object to inspect.</param>
    /// <returns>The list of relations starting from <c>child</c>.</returns>
    public Efl.Ui.Focus.Relations Fetch(Efl.Ui.Focus.IObject child) {
                                 var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_fetch_ptr.Value.Delegate(this.NativeHandle,child);
        Eina.Error.RaiseIfUnhandledException();
                        var __ret_tmp = Eina.PrimitiveConversion.PointerToManaged<Efl.Ui.Focus.Relations>(_ret_var);
        Marshal.FreeHGlobal(_ret_var);
        return __ret_tmp;
 }
    /// <summary>Return the last logical object.
    /// The returned object is the last object that would be returned if you start at the root and move the direction into next.
    /// (Since EFL 1.22)</summary>
    /// <returns>Last object.</returns>
    public Efl.Ui.Focus.ManagerLogicalEndDetail LogicalEnd() {
         var _ret_var = Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_logical_end_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Reset the history stack of this manager object. This means the uppermost element will be unfocused, and all other elements will be removed from the remembered list.
    /// You should focus another element immediately after calling this, in order to always have a focused object.
    /// (Since EFL 1.22)</summary>
    public void ResetHistory() {
         Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_reset_history_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Remove the uppermost history element, and focus the previous one.
    /// If there is an element that was focused before, it will be used. Otherwise, the best fitting element from the registered elements will be focused.
    /// (Since EFL 1.22)</summary>
    public void PopHistoryStack() {
         Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_pop_history_stack_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Called when this manager is set as redirect.
    /// In case that this is called as an result of a move call, <c>direction</c> and <c>entry</c> will be set to the direction of the move call, and the <c>entry</c> object will be set to the object that had this manager as redirect property.
    /// (Since EFL 1.22)</summary>
    /// <param name="direction">The direction in which this should be setup.</param>
    /// <param name="entry">The object that caused this manager to be redirect.</param>
    public void SetupOnFirstTouch(Efl.Ui.Focus.Direction direction, Efl.Ui.Focus.IObject entry) {
                                                         Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_setup_on_first_touch_ptr.Value.Delegate(this.NativeHandle,direction, entry);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This disables the cache invalidation when an object is moved.
    /// Even if an object is moved, the focus manager will not recalculate its relations. This can be used when you know that the set of widgets in the focus manager is moved the same way, so the relations between the widets in the set do not change and the complex calculations can be avoided. Use <see cref="Efl.Ui.Focus.IManager.DirtyLogicUnfreeze"/> to re-enable relationship calculation.
    /// (Since EFL 1.22)</summary>
    public void FreezeDirtyLogic() {
         Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_dirty_logic_freeze_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This enables the cache invalidation when an object is moved.
    /// This is the counterpart to <see cref="Efl.Ui.Focus.IManager.FreezeDirtyLogic"/>.
    /// (Since EFL 1.22)</summary>
    public void DirtyLogicUnfreeze() {
         Efl.Ui.Focus.IManagerConcrete.NativeMethods.efl_ui_focus_manager_dirty_logic_unfreeze_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
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
        return Efl.Ui.IWidgetFocusManagerConcrete.efl_ui_widget_focus_manager_mixin_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_widget_focus_manager_create_static_delegate == null)
            {
                efl_ui_widget_focus_manager_create_static_delegate = new efl_ui_widget_focus_manager_create_delegate(focus_manager_create);
            }

            if (methods.FirstOrDefault(m => m.Name == "FocusManagerCreate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_widget_focus_manager_create"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_widget_focus_manager_create_static_delegate) });
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

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.IWidgetFocusManagerConcrete.efl_ui_widget_focus_manager_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

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
                    _ret_var = ((IWidgetFocusManager)ws.Target).FocusManagerCreate(root);
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
                    _ret_var = ((IWidgetFocusManager)ws.Target).GetManagerFocus();
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
                    ((IWidgetFocusManager)ws.Target).SetManagerFocus(focus);
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
                    _ret_var = ((IWidgetFocusManager)ws.Target).GetRedirect();
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
                    ((IWidgetFocusManager)ws.Target).SetRedirect(redirect);
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
                    _ret_var = ((IWidgetFocusManager)ws.Target).GetBorderElements();
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
                    _ret_var = ((IWidgetFocusManager)ws.Target).GetViewportElements(_in_viewport);
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
                    _ret_var = ((IWidgetFocusManager)ws.Target).GetRoot();
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
                    _ret_var = ((IWidgetFocusManager)ws.Target).SetRoot(root);
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
                    _ret_var = ((IWidgetFocusManager)ws.Target).Move(direction);
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
                    _ret_var = ((IWidgetFocusManager)ws.Target).MoveRequest(direction, child, logical);
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
                    _ret_var = ((IWidgetFocusManager)ws.Target).RequestSubchild(root);
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
                    _ret_var = ((IWidgetFocusManager)ws.Target).Fetch(child);
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
                    _ret_var = ((IWidgetFocusManager)ws.Target).LogicalEnd();
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
                    ((IWidgetFocusManager)ws.Target).ResetHistory();
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
                    ((IWidgetFocusManager)ws.Target).PopHistoryStack();
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
                    ((IWidgetFocusManager)ws.Target).SetupOnFirstTouch(direction, entry);
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
                    ((IWidgetFocusManager)ws.Target).FreezeDirtyLogic();
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
                    ((IWidgetFocusManager)ws.Target).DirtyLogicUnfreeze();
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

