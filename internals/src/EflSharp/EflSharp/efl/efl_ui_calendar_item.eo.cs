#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>EFL UI Calendar Item class</summary>
[Efl.Ui.CalendarItem.NativeMethods]
public class CalendarItem : Efl.Object, Efl.Ui.Focus.IObject
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(CalendarItem))
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
        efl_ui_calendar_item_class_get();
    /// <summary>Initializes a new instance of the <see cref="CalendarItem"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public CalendarItem(Efl.Object parent= null
            ) : base(efl_ui_calendar_item_class_get(), typeof(CalendarItem), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="CalendarItem"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected CalendarItem(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="CalendarItem"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected CalendarItem(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Emitted if the focus state has changed.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Ui.Focus.IObjectFocusChangedEvt_Args> FocusChangedEvt
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
            lock (eventLock)
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
            lock (eventLock)
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
            lock (eventLock)
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
            lock (eventLock)
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
            lock (eventLock)
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
            lock (eventLock)
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
            lock (eventLock)
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
            lock (eventLock)
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
            lock (eventLock)
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
    /// <summary>Day number</summary>
    /// <returns>Day number</returns>
    virtual public int GetDayNumber() {
         var _ret_var = Efl.Ui.CalendarItem.NativeMethods.efl_ui_calendar_item_day_number_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Day number</summary>
    /// <param name="i">Day number</param>
    virtual public void SetDayNumber(int i) {
                                 Efl.Ui.CalendarItem.NativeMethods.efl_ui_calendar_item_day_number_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),i);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The geometry (that is, the bounding rectangle) used to calculate the relationship with other objects.
    /// (Since EFL 1.22)</summary>
    /// <returns>The geometry to use.</returns>
    virtual public Eina.Rect GetFocusGeometry() {
         var _ret_var = Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_focus_geometry_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Returns whether the widget is currently focused or not.
    /// (Since EFL 1.22)</summary>
    /// <returns>The focused state of the object.</returns>
    virtual public bool GetFocus() {
         var _ret_var = Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_focus_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This is called by the manager and should never be called by anyone else.
    /// The function emits the focus state events, if focus is different to the previous state.
    /// (Since EFL 1.22)</summary>
    /// <param name="focus">The focused state of the object.</param>
    virtual public void SetFocus(bool focus) {
                                 Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_focus_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This is the focus manager where this focus object is registered in. The element which is the <c>root</c> of a Efl.Ui.Focus.Manager will not have this focus manager as this object, but rather the second focus manager where it is registered in.
    /// (Since EFL 1.22)</summary>
    /// <returns>The manager object</returns>
    virtual public Efl.Ui.Focus.IManager GetFocusManager() {
         var _ret_var = Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_focus_manager_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Describes which logical parent is used by this object.
    /// (Since EFL 1.22)</summary>
    /// <returns>The focus parent.</returns>
    virtual public Efl.Ui.Focus.IObject GetFocusParent() {
         var _ret_var = Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_focus_parent_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Indicates if a child of this object has focus set to true.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if a child has focus.</returns>
    virtual public bool GetChildFocus() {
         var _ret_var = Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_child_focus_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Indicates if a child of this object has focus set to true.
    /// (Since EFL 1.22)</summary>
    /// <param name="child_focus"><c>true</c> if a child has focus.</param>
    virtual public void SetChildFocus(bool child_focus) {
                                 Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_child_focus_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),child_focus);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Tells the object that its children will be queried soon by the focus manager. Overwrite this to update the order of the children. Deleting items in this call will result in undefined behaviour and may cause your system to crash.
    /// (Since EFL 1.22)</summary>
    virtual public void SetupOrder() {
         Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_setup_order_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This is called when <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> is called, but only on the first call, additional recursive calls to <see cref="Efl.Ui.Focus.IObject.SetupOrder"/> will not call this function again.
    /// (Since EFL 1.22)</summary>
    virtual public void SetupOrderNonRecursive() {
         Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_setup_order_non_recursive_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Virtual function handling focus in/out events on the widget
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if this widget can handle focus, <c>false</c> otherwise</returns>
    virtual public bool UpdateOnFocus() {
         var _ret_var = Efl.Ui.Focus.IObjectConcrete.NativeMethods.efl_ui_focus_object_on_focus_update_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Day number</summary>
    /// <value>Day number</value>
    public int DayNumber {
        get { return GetDayNumber(); }
        set { SetDayNumber(value); }
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
        return Efl.Ui.CalendarItem.efl_ui_calendar_item_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_calendar_item_day_number_get_static_delegate == null)
            {
                efl_ui_calendar_item_day_number_get_static_delegate = new efl_ui_calendar_item_day_number_get_delegate(day_number_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDayNumber") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_calendar_item_day_number_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_item_day_number_get_static_delegate) });
            }

            if (efl_ui_calendar_item_day_number_set_static_delegate == null)
            {
                efl_ui_calendar_item_day_number_set_static_delegate = new efl_ui_calendar_item_day_number_set_delegate(day_number_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDayNumber") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_calendar_item_day_number_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_calendar_item_day_number_set_static_delegate) });
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
            return Efl.Ui.CalendarItem.efl_ui_calendar_item_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate int efl_ui_calendar_item_day_number_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_calendar_item_day_number_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_calendar_item_day_number_get_api_delegate> efl_ui_calendar_item_day_number_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_item_day_number_get_api_delegate>(Module, "efl_ui_calendar_item_day_number_get");

        private static int day_number_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_calendar_item_day_number_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((CalendarItem)ws.Target).GetDayNumber();
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
                return efl_ui_calendar_item_day_number_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_calendar_item_day_number_get_delegate efl_ui_calendar_item_day_number_get_static_delegate;

        
        private delegate void efl_ui_calendar_item_day_number_set_delegate(System.IntPtr obj, System.IntPtr pd,  int i);

        
        public delegate void efl_ui_calendar_item_day_number_set_api_delegate(System.IntPtr obj,  int i);

        public static Efl.Eo.FunctionWrapper<efl_ui_calendar_item_day_number_set_api_delegate> efl_ui_calendar_item_day_number_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_calendar_item_day_number_set_api_delegate>(Module, "efl_ui_calendar_item_day_number_set");

        private static void day_number_set(System.IntPtr obj, System.IntPtr pd, int i)
        {
            Eina.Log.Debug("function efl_ui_calendar_item_day_number_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((CalendarItem)ws.Target).SetDayNumber(i);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_calendar_item_day_number_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), i);
            }
        }

        private static efl_ui_calendar_item_day_number_set_delegate efl_ui_calendar_item_day_number_set_static_delegate;

        
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
                    _ret_var = ((CalendarItem)ws.Target).GetFocusGeometry();
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
                    _ret_var = ((CalendarItem)ws.Target).GetFocus();
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
                    ((CalendarItem)ws.Target).SetFocus(focus);
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
                    _ret_var = ((CalendarItem)ws.Target).GetFocusManager();
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
                    _ret_var = ((CalendarItem)ws.Target).GetFocusParent();
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
                    _ret_var = ((CalendarItem)ws.Target).GetChildFocus();
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
                    ((CalendarItem)ws.Target).SetChildFocus(child_focus);
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
                    ((CalendarItem)ws.Target).SetupOrder();
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
                    ((CalendarItem)ws.Target).SetupOrderNonRecursive();
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
                    _ret_var = ((CalendarItem)ws.Target).UpdateOnFocus();
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

