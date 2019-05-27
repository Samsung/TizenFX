#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Tab Bar class</summary>
[Efl.Ui.TabBar.NativeMethods]
public class TabBar : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.Ui.IClickable
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(TabBar))
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
        efl_ui_tab_bar_class_get();
    /// <summary>Initializes a new instance of the <see cref="TabBar"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public TabBar(Efl.Object parent
            , System.String style = null) : base(efl_ui_tab_bar_class_get(), typeof(TabBar), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="TabBar"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected TabBar(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="TabBar"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected TabBar(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    /// <summary>Called when object is clicked</summary>
    public event EventHandler ClickedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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

                string key = "_EFL_UI_EVENT_CLICKED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedEvt.</summary>
    public void OnClickedEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_CLICKED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when object receives a double click</summary>
    public event EventHandler ClickedDoubleEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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

                string key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedDoubleEvt.</summary>
    public void OnClickedDoubleEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when object receives a triple click</summary>
    public event EventHandler ClickedTripleEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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

                string key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedTripleEvt.</summary>
    public void OnClickedTripleEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when object receives a right click</summary>
    public event EventHandler<Efl.Ui.IClickableClickedRightEvt_Args> ClickedRightEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Ui.IClickableClickedRightEvt_Args args = new Efl.Ui.IClickableClickedRightEvt_Args();
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

                string key = "_EFL_UI_EVENT_CLICKED_RIGHT";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_CLICKED_RIGHT";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event ClickedRightEvt.</summary>
    public void OnClickedRightEvt(Efl.Ui.IClickableClickedRightEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_CLICKED_RIGHT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when the object is pressed</summary>
    public event EventHandler<Efl.Ui.IClickablePressedEvt_Args> PressedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Ui.IClickablePressedEvt_Args args = new Efl.Ui.IClickablePressedEvt_Args();
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

                string key = "_EFL_UI_EVENT_PRESSED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_PRESSED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event PressedEvt.</summary>
    public void OnPressedEvt(Efl.Ui.IClickablePressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_PRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when the object is no longer pressed</summary>
    public event EventHandler<Efl.Ui.IClickableUnpressedEvt_Args> UnpressedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Ui.IClickableUnpressedEvt_Args args = new Efl.Ui.IClickableUnpressedEvt_Args();
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

                string key = "_EFL_UI_EVENT_UNPRESSED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_UNPRESSED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event UnpressedEvt.</summary>
    public void OnUnpressedEvt(Efl.Ui.IClickableUnpressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_UNPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when the object receives a long press</summary>
    public event EventHandler<Efl.Ui.IClickableLongpressedEvt_Args> LongpressedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.Ui.IClickableLongpressedEvt_Args args = new Efl.Ui.IClickableLongpressedEvt_Args();
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

                string key = "_EFL_UI_EVENT_LONGPRESSED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_LONGPRESSED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event LongpressedEvt.</summary>
    public void OnLongpressedEvt(Efl.Ui.IClickableLongpressedEvt_Args e)
    {
        var key = "_EFL_UI_EVENT_LONGPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Called when the object receives repeated presses/clicks</summary>
    public event EventHandler RepeatedEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
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

                string key = "_EFL_UI_EVENT_REPEATED";
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_EVENT_REPEATED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    ///<summary>Method to raise event RepeatedEvt.</summary>
    public void OnRepeatedEvt(EventArgs e)
    {
        var key = "_EFL_UI_EVENT_REPEATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    virtual public int GetCurrentTab() {
         var _ret_var = Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_current_tab_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    virtual public void SetCurrentTab(int index) {
                                 Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_current_tab_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),index);
        Eina.Error.RaiseIfUnhandledException();
                         }
    virtual public uint TabCount() {
         var _ret_var = Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_tab_count_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    virtual public void AddTab(int index, System.String label, System.String icon) {
                                                                                 Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_tab_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),index, label, icon);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    virtual public void TabRemove(int index) {
                                 Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_tab_remove_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),index);
        Eina.Error.RaiseIfUnhandledException();
                         }
    virtual public void SetTabLabel(int index, System.String label) {
                                                         Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_tab_label_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),index, label);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    virtual public void SetTabIcon(int index, System.String icon) {
                                                         Efl.Ui.TabBar.NativeMethods.efl_ui_tab_bar_tab_icon_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),index, icon);
        Eina.Error.RaiseIfUnhandledException();
                                         }
        public int CurrentTab {
        get { return GetCurrentTab(); }
        set { SetCurrentTab(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.TabBar.efl_ui_tab_bar_class_get();
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

            if (efl_ui_tab_bar_current_tab_get_static_delegate == null)
            {
                efl_ui_tab_bar_current_tab_get_static_delegate = new efl_ui_tab_bar_current_tab_get_delegate(current_tab_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCurrentTab") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_current_tab_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_current_tab_get_static_delegate) });
            }

            if (efl_ui_tab_bar_current_tab_set_static_delegate == null)
            {
                efl_ui_tab_bar_current_tab_set_static_delegate = new efl_ui_tab_bar_current_tab_set_delegate(current_tab_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCurrentTab") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_current_tab_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_current_tab_set_static_delegate) });
            }

            if (efl_ui_tab_bar_tab_count_static_delegate == null)
            {
                efl_ui_tab_bar_tab_count_static_delegate = new efl_ui_tab_bar_tab_count_delegate(tab_count);
            }

            if (methods.FirstOrDefault(m => m.Name == "TabCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_tab_count"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_count_static_delegate) });
            }

            if (efl_ui_tab_bar_tab_add_static_delegate == null)
            {
                efl_ui_tab_bar_tab_add_static_delegate = new efl_ui_tab_bar_tab_add_delegate(tab_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddTab") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_tab_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_add_static_delegate) });
            }

            if (efl_ui_tab_bar_tab_remove_static_delegate == null)
            {
                efl_ui_tab_bar_tab_remove_static_delegate = new efl_ui_tab_bar_tab_remove_delegate(tab_remove);
            }

            if (methods.FirstOrDefault(m => m.Name == "TabRemove") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_tab_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_remove_static_delegate) });
            }

            if (efl_ui_tab_bar_tab_label_set_static_delegate == null)
            {
                efl_ui_tab_bar_tab_label_set_static_delegate = new efl_ui_tab_bar_tab_label_set_delegate(tab_label_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTabLabel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_tab_label_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_label_set_static_delegate) });
            }

            if (efl_ui_tab_bar_tab_icon_set_static_delegate == null)
            {
                efl_ui_tab_bar_tab_icon_set_static_delegate = new efl_ui_tab_bar_tab_icon_set_delegate(tab_icon_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTabIcon") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_tab_bar_tab_icon_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_icon_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.TabBar.efl_ui_tab_bar_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate int efl_ui_tab_bar_current_tab_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_tab_bar_current_tab_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_current_tab_get_api_delegate> efl_ui_tab_bar_current_tab_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_current_tab_get_api_delegate>(Module, "efl_ui_tab_bar_current_tab_get");

        private static int current_tab_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_current_tab_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((TabBar)wrapper).GetCurrentTab();
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
                return efl_ui_tab_bar_current_tab_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_tab_bar_current_tab_get_delegate efl_ui_tab_bar_current_tab_get_static_delegate;

        
        private delegate void efl_ui_tab_bar_current_tab_set_delegate(System.IntPtr obj, System.IntPtr pd,  int index);

        
        public delegate void efl_ui_tab_bar_current_tab_set_api_delegate(System.IntPtr obj,  int index);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_current_tab_set_api_delegate> efl_ui_tab_bar_current_tab_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_current_tab_set_api_delegate>(Module, "efl_ui_tab_bar_current_tab_set");

        private static void current_tab_set(System.IntPtr obj, System.IntPtr pd, int index)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_current_tab_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((TabBar)wrapper).SetCurrentTab(index);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_tab_bar_current_tab_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index);
            }
        }

        private static efl_ui_tab_bar_current_tab_set_delegate efl_ui_tab_bar_current_tab_set_static_delegate;

        
        private delegate uint efl_ui_tab_bar_tab_count_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_ui_tab_bar_tab_count_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_count_api_delegate> efl_ui_tab_bar_tab_count_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_count_api_delegate>(Module, "efl_ui_tab_bar_tab_count");

        private static uint tab_count(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_tab_count was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((TabBar)wrapper).TabCount();
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
                return efl_ui_tab_bar_tab_count_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_tab_bar_tab_count_delegate efl_ui_tab_bar_tab_count_static_delegate;

        
        private delegate void efl_ui_tab_bar_tab_add_delegate(System.IntPtr obj, System.IntPtr pd,  int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String icon);

        
        public delegate void efl_ui_tab_bar_tab_add_api_delegate(System.IntPtr obj,  int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String icon);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_add_api_delegate> efl_ui_tab_bar_tab_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_add_api_delegate>(Module, "efl_ui_tab_bar_tab_add");

        private static void tab_add(System.IntPtr obj, System.IntPtr pd, int index, System.String label, System.String icon)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_tab_add was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                                                    
                try
                {
                    ((TabBar)wrapper).AddTab(index, label, icon);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_tab_bar_tab_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index, label, icon);
            }
        }

        private static efl_ui_tab_bar_tab_add_delegate efl_ui_tab_bar_tab_add_static_delegate;

        
        private delegate void efl_ui_tab_bar_tab_remove_delegate(System.IntPtr obj, System.IntPtr pd,  int index);

        
        public delegate void efl_ui_tab_bar_tab_remove_api_delegate(System.IntPtr obj,  int index);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_remove_api_delegate> efl_ui_tab_bar_tab_remove_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_remove_api_delegate>(Module, "efl_ui_tab_bar_tab_remove");

        private static void tab_remove(System.IntPtr obj, System.IntPtr pd, int index)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_tab_remove was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((TabBar)wrapper).TabRemove(index);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_tab_bar_tab_remove_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index);
            }
        }

        private static efl_ui_tab_bar_tab_remove_delegate efl_ui_tab_bar_tab_remove_static_delegate;

        
        private delegate void efl_ui_tab_bar_tab_label_set_delegate(System.IntPtr obj, System.IntPtr pd,  int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label);

        
        public delegate void efl_ui_tab_bar_tab_label_set_api_delegate(System.IntPtr obj,  int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String label);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_label_set_api_delegate> efl_ui_tab_bar_tab_label_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_label_set_api_delegate>(Module, "efl_ui_tab_bar_tab_label_set");

        private static void tab_label_set(System.IntPtr obj, System.IntPtr pd, int index, System.String label)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_tab_label_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((TabBar)wrapper).SetTabLabel(index, label);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_tab_bar_tab_label_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index, label);
            }
        }

        private static efl_ui_tab_bar_tab_label_set_delegate efl_ui_tab_bar_tab_label_set_static_delegate;

        
        private delegate void efl_ui_tab_bar_tab_icon_set_delegate(System.IntPtr obj, System.IntPtr pd,  int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String icon);

        
        public delegate void efl_ui_tab_bar_tab_icon_set_api_delegate(System.IntPtr obj,  int index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String icon);

        public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_icon_set_api_delegate> efl_ui_tab_bar_tab_icon_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_icon_set_api_delegate>(Module, "efl_ui_tab_bar_tab_icon_set");

        private static void tab_icon_set(System.IntPtr obj, System.IntPtr pd, int index, System.String icon)
        {
            Eina.Log.Debug("function efl_ui_tab_bar_tab_icon_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            
                try
                {
                    ((TabBar)wrapper).SetTabIcon(index, icon);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_tab_bar_tab_icon_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), index, icon);
            }
        }

        private static efl_ui_tab_bar_tab_icon_set_delegate efl_ui_tab_bar_tab_icon_set_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

