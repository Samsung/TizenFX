#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Tab Bar class</summary>
[TabBarNativeInherit]
public class TabBar : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.Ui.IClickable
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (TabBar))
                return Efl.Ui.TabBarNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_tab_bar_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public TabBar(Efl.Object parent
            , System.String style = null) :
        base(efl_ui_tab_bar_class_get(), typeof(TabBar), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected TabBar(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected TabBar(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
    ///<summary>Verifies if the given object is equal to this one.</summary>
    public override bool Equals(object obj)
    {
        var other = obj as Efl.Object;
        if (other == null)
            return false;
        return this.NativeHandle == other.NativeHandle;
    }
    ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }
    ///<summary>Turns the native pointer into a string representation.</summary>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }
private static object ClickedEvtKey = new object();
    /// <summary>Called when object is clicked</summary>
    public event EventHandler ClickedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ClickedEvt_delegate)) {
                    eventHandlers.AddHandler(ClickedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED";
                if (RemoveNativeEventHandler(key, this.evt_ClickedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ClickedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ClickedEvt.</summary>
    public void On_ClickedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ClickedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ClickedEvt_delegate;
    private void on_ClickedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ClickedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ClickedDoubleEvtKey = new object();
    /// <summary>Called when object receives a double click</summary>
    public event EventHandler ClickedDoubleEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ClickedDoubleEvt_delegate)) {
                    eventHandlers.AddHandler(ClickedDoubleEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED_DOUBLE";
                if (RemoveNativeEventHandler(key, this.evt_ClickedDoubleEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ClickedDoubleEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ClickedDoubleEvt.</summary>
    public void On_ClickedDoubleEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ClickedDoubleEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ClickedDoubleEvt_delegate;
    private void on_ClickedDoubleEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ClickedDoubleEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ClickedTripleEvtKey = new object();
    /// <summary>Called when object receives a triple click</summary>
    public event EventHandler ClickedTripleEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ClickedTripleEvt_delegate)) {
                    eventHandlers.AddHandler(ClickedTripleEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED_TRIPLE";
                if (RemoveNativeEventHandler(key, this.evt_ClickedTripleEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ClickedTripleEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ClickedTripleEvt.</summary>
    public void On_ClickedTripleEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ClickedTripleEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ClickedTripleEvt_delegate;
    private void on_ClickedTripleEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ClickedTripleEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ClickedRightEvtKey = new object();
    /// <summary>Called when object receives a right click</summary>
    public event EventHandler<Efl.Ui.IClickableClickedRightEvt_Args> ClickedRightEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED_RIGHT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ClickedRightEvt_delegate)) {
                    eventHandlers.AddHandler(ClickedRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_CLICKED_RIGHT";
                if (RemoveNativeEventHandler(key, this.evt_ClickedRightEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ClickedRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ClickedRightEvt.</summary>
    public void On_ClickedRightEvt(Efl.Ui.IClickableClickedRightEvt_Args e)
    {
        EventHandler<Efl.Ui.IClickableClickedRightEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IClickableClickedRightEvt_Args>)eventHandlers[ClickedRightEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ClickedRightEvt_delegate;
    private void on_ClickedRightEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IClickableClickedRightEvt_Args args = new Efl.Ui.IClickableClickedRightEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_ClickedRightEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PressedEvtKey = new object();
    /// <summary>Called when the object is pressed</summary>
    public event EventHandler<Efl.Ui.IClickablePressedEvt_Args> PressedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_PRESSED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_PressedEvt_delegate)) {
                    eventHandlers.AddHandler(PressedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_PRESSED";
                if (RemoveNativeEventHandler(key, this.evt_PressedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PressedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PressedEvt.</summary>
    public void On_PressedEvt(Efl.Ui.IClickablePressedEvt_Args e)
    {
        EventHandler<Efl.Ui.IClickablePressedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IClickablePressedEvt_Args>)eventHandlers[PressedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PressedEvt_delegate;
    private void on_PressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IClickablePressedEvt_Args args = new Efl.Ui.IClickablePressedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_PressedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object UnpressedEvtKey = new object();
    /// <summary>Called when the object is no longer pressed</summary>
    public event EventHandler<Efl.Ui.IClickableUnpressedEvt_Args> UnpressedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_UNPRESSED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_UnpressedEvt_delegate)) {
                    eventHandlers.AddHandler(UnpressedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_UNPRESSED";
                if (RemoveNativeEventHandler(key, this.evt_UnpressedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(UnpressedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event UnpressedEvt.</summary>
    public void On_UnpressedEvt(Efl.Ui.IClickableUnpressedEvt_Args e)
    {
        EventHandler<Efl.Ui.IClickableUnpressedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IClickableUnpressedEvt_Args>)eventHandlers[UnpressedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_UnpressedEvt_delegate;
    private void on_UnpressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IClickableUnpressedEvt_Args args = new Efl.Ui.IClickableUnpressedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_UnpressedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object LongpressedEvtKey = new object();
    /// <summary>Called when the object receives a long press</summary>
    public event EventHandler<Efl.Ui.IClickableLongpressedEvt_Args> LongpressedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_LONGPRESSED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_LongpressedEvt_delegate)) {
                    eventHandlers.AddHandler(LongpressedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_LONGPRESSED";
                if (RemoveNativeEventHandler(key, this.evt_LongpressedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(LongpressedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event LongpressedEvt.</summary>
    public void On_LongpressedEvt(Efl.Ui.IClickableLongpressedEvt_Args e)
    {
        EventHandler<Efl.Ui.IClickableLongpressedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IClickableLongpressedEvt_Args>)eventHandlers[LongpressedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_LongpressedEvt_delegate;
    private void on_LongpressedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IClickableLongpressedEvt_Args args = new Efl.Ui.IClickableLongpressedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_LongpressedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object RepeatedEvtKey = new object();
    /// <summary>Called when the object receives repeated presses/clicks</summary>
    public event EventHandler RepeatedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_REPEATED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_RepeatedEvt_delegate)) {
                    eventHandlers.AddHandler(RepeatedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_REPEATED";
                if (RemoveNativeEventHandler(key, this.evt_RepeatedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(RepeatedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event RepeatedEvt.</summary>
    public void On_RepeatedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[RepeatedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_RepeatedEvt_delegate;
    private void on_RepeatedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_RepeatedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_ClickedEvt_delegate = new Efl.EventCb(on_ClickedEvt_NativeCallback);
        evt_ClickedDoubleEvt_delegate = new Efl.EventCb(on_ClickedDoubleEvt_NativeCallback);
        evt_ClickedTripleEvt_delegate = new Efl.EventCb(on_ClickedTripleEvt_NativeCallback);
        evt_ClickedRightEvt_delegate = new Efl.EventCb(on_ClickedRightEvt_NativeCallback);
        evt_PressedEvt_delegate = new Efl.EventCb(on_PressedEvt_NativeCallback);
        evt_UnpressedEvt_delegate = new Efl.EventCb(on_UnpressedEvt_NativeCallback);
        evt_LongpressedEvt_delegate = new Efl.EventCb(on_LongpressedEvt_NativeCallback);
        evt_RepeatedEvt_delegate = new Efl.EventCb(on_RepeatedEvt_NativeCallback);
    }
    /// <summary></summary>
    /// <returns></returns>
    virtual public int GetCurrentTab() {
         var _ret_var = Efl.Ui.TabBarNativeInherit.efl_ui_tab_bar_current_tab_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary></summary>
    /// <param name="index"></param>
    /// <returns></returns>
    virtual public void SetCurrentTab( int index) {
                                 Efl.Ui.TabBarNativeInherit.efl_ui_tab_bar_current_tab_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), index);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary></summary>
    /// <returns></returns>
    virtual public uint TabCount() {
         var _ret_var = Efl.Ui.TabBarNativeInherit.efl_ui_tab_bar_tab_count_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary></summary>
    /// <param name="index"></param>
    /// <param name="label"></param>
    /// <param name="icon"></param>
    /// <returns></returns>
    virtual public void AddTab( int index,  System.String label,  System.String icon) {
                                                                                 Efl.Ui.TabBarNativeInherit.efl_ui_tab_bar_tab_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), index,  label,  icon);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary></summary>
    /// <param name="index"></param>
    /// <returns></returns>
    virtual public void TabRemove( int index) {
                                 Efl.Ui.TabBarNativeInherit.efl_ui_tab_bar_tab_remove_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), index);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary></summary>
    /// <param name="index"></param>
    /// <param name="label"></param>
    /// <returns></returns>
    virtual public void SetTabLabel( int index,  System.String label) {
                                                         Efl.Ui.TabBarNativeInherit.efl_ui_tab_bar_tab_label_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), index,  label);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary></summary>
    /// <param name="index"></param>
    /// <param name="icon"></param>
    /// <returns></returns>
    virtual public void SetTabIcon( int index,  System.String icon) {
                                                         Efl.Ui.TabBarNativeInherit.efl_ui_tab_bar_tab_icon_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), index,  icon);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary></summary>
/// <value></value>
    public int CurrentTab {
        get { return GetCurrentTab(); }
        set { SetCurrentTab( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.TabBar.efl_ui_tab_bar_class_get();
    }
}
public class TabBarNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_tab_bar_current_tab_get_static_delegate == null)
            efl_ui_tab_bar_current_tab_get_static_delegate = new efl_ui_tab_bar_current_tab_get_delegate(current_tab_get);
        if (methods.FirstOrDefault(m => m.Name == "GetCurrentTab") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tab_bar_current_tab_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_current_tab_get_static_delegate)});
        if (efl_ui_tab_bar_current_tab_set_static_delegate == null)
            efl_ui_tab_bar_current_tab_set_static_delegate = new efl_ui_tab_bar_current_tab_set_delegate(current_tab_set);
        if (methods.FirstOrDefault(m => m.Name == "SetCurrentTab") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tab_bar_current_tab_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_current_tab_set_static_delegate)});
        if (efl_ui_tab_bar_tab_count_static_delegate == null)
            efl_ui_tab_bar_tab_count_static_delegate = new efl_ui_tab_bar_tab_count_delegate(tab_count);
        if (methods.FirstOrDefault(m => m.Name == "TabCount") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tab_bar_tab_count"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_count_static_delegate)});
        if (efl_ui_tab_bar_tab_add_static_delegate == null)
            efl_ui_tab_bar_tab_add_static_delegate = new efl_ui_tab_bar_tab_add_delegate(tab_add);
        if (methods.FirstOrDefault(m => m.Name == "AddTab") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tab_bar_tab_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_add_static_delegate)});
        if (efl_ui_tab_bar_tab_remove_static_delegate == null)
            efl_ui_tab_bar_tab_remove_static_delegate = new efl_ui_tab_bar_tab_remove_delegate(tab_remove);
        if (methods.FirstOrDefault(m => m.Name == "TabRemove") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tab_bar_tab_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_remove_static_delegate)});
        if (efl_ui_tab_bar_tab_label_set_static_delegate == null)
            efl_ui_tab_bar_tab_label_set_static_delegate = new efl_ui_tab_bar_tab_label_set_delegate(tab_label_set);
        if (methods.FirstOrDefault(m => m.Name == "SetTabLabel") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tab_bar_tab_label_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_label_set_static_delegate)});
        if (efl_ui_tab_bar_tab_icon_set_static_delegate == null)
            efl_ui_tab_bar_tab_icon_set_static_delegate = new efl_ui_tab_bar_tab_icon_set_delegate(tab_icon_set);
        if (methods.FirstOrDefault(m => m.Name == "SetTabIcon") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_tab_bar_tab_icon_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_tab_bar_tab_icon_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.TabBar.efl_ui_tab_bar_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.TabBar.efl_ui_tab_bar_class_get();
    }


     private delegate int efl_ui_tab_bar_current_tab_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate int efl_ui_tab_bar_current_tab_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_current_tab_get_api_delegate> efl_ui_tab_bar_current_tab_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_current_tab_get_api_delegate>(_Module, "efl_ui_tab_bar_current_tab_get");
     private static int current_tab_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_tab_bar_current_tab_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        int _ret_var = default(int);
            try {
                _ret_var = ((TabBar)wrapper).GetCurrentTab();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_tab_bar_current_tab_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_tab_bar_current_tab_get_delegate efl_ui_tab_bar_current_tab_get_static_delegate;


     private delegate void efl_ui_tab_bar_current_tab_set_delegate(System.IntPtr obj, System.IntPtr pd,   int index);


     public delegate void efl_ui_tab_bar_current_tab_set_api_delegate(System.IntPtr obj,   int index);
     public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_current_tab_set_api_delegate> efl_ui_tab_bar_current_tab_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_current_tab_set_api_delegate>(_Module, "efl_ui_tab_bar_current_tab_set");
     private static void current_tab_set(System.IntPtr obj, System.IntPtr pd,  int index)
    {
        Eina.Log.Debug("function efl_ui_tab_bar_current_tab_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((TabBar)wrapper).SetCurrentTab( index);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_tab_bar_current_tab_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index);
        }
    }
    private static efl_ui_tab_bar_current_tab_set_delegate efl_ui_tab_bar_current_tab_set_static_delegate;


     private delegate uint efl_ui_tab_bar_tab_count_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate uint efl_ui_tab_bar_tab_count_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_count_api_delegate> efl_ui_tab_bar_tab_count_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_count_api_delegate>(_Module, "efl_ui_tab_bar_tab_count");
     private static uint tab_count(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_tab_bar_tab_count was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        uint _ret_var = default(uint);
            try {
                _ret_var = ((TabBar)wrapper).TabCount();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_tab_bar_tab_count_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_tab_bar_tab_count_delegate efl_ui_tab_bar_tab_count_static_delegate;


     private delegate void efl_ui_tab_bar_tab_add_delegate(System.IntPtr obj, System.IntPtr pd,   int index,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String label,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String icon);


     public delegate void efl_ui_tab_bar_tab_add_api_delegate(System.IntPtr obj,   int index,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String label,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String icon);
     public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_add_api_delegate> efl_ui_tab_bar_tab_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_add_api_delegate>(_Module, "efl_ui_tab_bar_tab_add");
     private static void tab_add(System.IntPtr obj, System.IntPtr pd,  int index,  System.String label,  System.String icon)
    {
        Eina.Log.Debug("function efl_ui_tab_bar_tab_add was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                
            try {
                ((TabBar)wrapper).AddTab( index,  label,  icon);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                } else {
            efl_ui_tab_bar_tab_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index,  label,  icon);
        }
    }
    private static efl_ui_tab_bar_tab_add_delegate efl_ui_tab_bar_tab_add_static_delegate;


     private delegate void efl_ui_tab_bar_tab_remove_delegate(System.IntPtr obj, System.IntPtr pd,   int index);


     public delegate void efl_ui_tab_bar_tab_remove_api_delegate(System.IntPtr obj,   int index);
     public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_remove_api_delegate> efl_ui_tab_bar_tab_remove_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_remove_api_delegate>(_Module, "efl_ui_tab_bar_tab_remove");
     private static void tab_remove(System.IntPtr obj, System.IntPtr pd,  int index)
    {
        Eina.Log.Debug("function efl_ui_tab_bar_tab_remove was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((TabBar)wrapper).TabRemove( index);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_tab_bar_tab_remove_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index);
        }
    }
    private static efl_ui_tab_bar_tab_remove_delegate efl_ui_tab_bar_tab_remove_static_delegate;


     private delegate void efl_ui_tab_bar_tab_label_set_delegate(System.IntPtr obj, System.IntPtr pd,   int index,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String label);


     public delegate void efl_ui_tab_bar_tab_label_set_api_delegate(System.IntPtr obj,   int index,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String label);
     public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_label_set_api_delegate> efl_ui_tab_bar_tab_label_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_label_set_api_delegate>(_Module, "efl_ui_tab_bar_tab_label_set");
     private static void tab_label_set(System.IntPtr obj, System.IntPtr pd,  int index,  System.String label)
    {
        Eina.Log.Debug("function efl_ui_tab_bar_tab_label_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((TabBar)wrapper).SetTabLabel( index,  label);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_tab_bar_tab_label_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index,  label);
        }
    }
    private static efl_ui_tab_bar_tab_label_set_delegate efl_ui_tab_bar_tab_label_set_static_delegate;


     private delegate void efl_ui_tab_bar_tab_icon_set_delegate(System.IntPtr obj, System.IntPtr pd,   int index,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String icon);


     public delegate void efl_ui_tab_bar_tab_icon_set_api_delegate(System.IntPtr obj,   int index,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String icon);
     public static Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_icon_set_api_delegate> efl_ui_tab_bar_tab_icon_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_tab_bar_tab_icon_set_api_delegate>(_Module, "efl_ui_tab_bar_tab_icon_set");
     private static void tab_icon_set(System.IntPtr obj, System.IntPtr pd,  int index,  System.String icon)
    {
        Eina.Log.Debug("function efl_ui_tab_bar_tab_icon_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((TabBar)wrapper).SetTabIcon( index,  icon);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_tab_bar_tab_icon_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index,  icon);
        }
    }
    private static efl_ui_tab_bar_tab_icon_set_delegate efl_ui_tab_bar_tab_icon_set_static_delegate;
}
} } 
