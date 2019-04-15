#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Elementary panes class</summary>
[PanesNativeInherit]
public class Panes : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.Ui.IClickable,Efl.Ui.IDirection
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Panes))
                return Efl.Ui.PanesNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_panes_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Panes(Efl.Object parent
            , System.String style = null) :
        base(efl_ui_panes_class_get(), typeof(Panes), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Panes(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Panes(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
private static object PressEvtKey = new object();
    /// <summary>Called when panes got pressed</summary>
    public event EventHandler PressEvt
    {
        add {
            lock (eventLock) {
                string key = "_ELM_PANES_EVENT_PRESS";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_PressEvt_delegate)) {
                    eventHandlers.AddHandler(PressEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_ELM_PANES_EVENT_PRESS";
                if (RemoveNativeEventHandler(key, this.evt_PressEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PressEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PressEvt.</summary>
    public void On_PressEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[PressEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PressEvt_delegate;
    private void on_PressEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_PressEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object UnpressEvtKey = new object();
    /// <summary>Called when panes are no longer pressed</summary>
    public event EventHandler UnpressEvt
    {
        add {
            lock (eventLock) {
                string key = "_ELM_PANES_EVENT_UNPRESS";
                if (AddNativeEventHandler(efl.Libs.Elementary, key, this.evt_UnpressEvt_delegate)) {
                    eventHandlers.AddHandler(UnpressEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_ELM_PANES_EVENT_UNPRESS";
                if (RemoveNativeEventHandler(key, this.evt_UnpressEvt_delegate)) { 
                    eventHandlers.RemoveHandler(UnpressEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event UnpressEvt.</summary>
    public void On_UnpressEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[UnpressEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_UnpressEvt_delegate;
    private void on_UnpressEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_UnpressEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
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
        evt_PressEvt_delegate = new Efl.EventCb(on_PressEvt_NativeCallback);
        evt_UnpressEvt_delegate = new Efl.EventCb(on_UnpressEvt_NativeCallback);
        evt_ClickedEvt_delegate = new Efl.EventCb(on_ClickedEvt_NativeCallback);
        evt_ClickedDoubleEvt_delegate = new Efl.EventCb(on_ClickedDoubleEvt_NativeCallback);
        evt_ClickedTripleEvt_delegate = new Efl.EventCb(on_ClickedTripleEvt_NativeCallback);
        evt_ClickedRightEvt_delegate = new Efl.EventCb(on_ClickedRightEvt_NativeCallback);
        evt_PressedEvt_delegate = new Efl.EventCb(on_PressedEvt_NativeCallback);
        evt_UnpressedEvt_delegate = new Efl.EventCb(on_UnpressedEvt_NativeCallback);
        evt_LongpressedEvt_delegate = new Efl.EventCb(on_LongpressedEvt_NativeCallback);
        evt_RepeatedEvt_delegate = new Efl.EventCb(on_RepeatedEvt_NativeCallback);
    }
    /// <summary>The second half of the panes widget (right or bottom)</summary>
    public Efl.Ui.PanesPart Second
    {
        get
        {
            return Efl.IPartNativeInherit.efl_part_get_ptr.Value.Delegate(NativeHandle, "second") as Efl.Ui.PanesPart;
        }
    }
    /// <summary>The first half of the panes widget (left or top)</summary>
    public Efl.Ui.PanesPart First
    {
        get
        {
            return Efl.IPartNativeInherit.efl_part_get_ptr.Value.Delegate(NativeHandle, "first") as Efl.Ui.PanesPart;
        }
    }
    /// <summary>Set the split ratio between panes widget first and second parts.
    /// By default it&apos;s homogeneous, i.e., both sides have the same size.
    /// 
    /// If something different is required, it can be set with this function. For example, if the first content should be displayed over 75% of the panes size, <c>ratio</c> should be passed as 0.75. This way, second content will be resized to 25% of panes size.
    /// 
    /// If displayed vertically, first content is displayed at top, and second content at bottom.
    /// 
    /// Note: This ratio will change when user drags the panes bar.</summary>
    /// <returns>Value between 0.0 and 1.0 representing split ratio between panes first and second parts.</returns>
    virtual public double GetSplitRatio() {
         var _ret_var = Efl.Ui.PanesNativeInherit.efl_ui_panes_split_ratio_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the split ratio between panes widget first and second parts.
    /// By default it&apos;s homogeneous, i.e., both sides have the same size.
    /// 
    /// If something different is required, it can be set with this function. For example, if the first content should be displayed over 75% of the panes size, <c>ratio</c> should be passed as 0.75. This way, second content will be resized to 25% of panes size.
    /// 
    /// If displayed vertically, first content is displayed at top, and second content at bottom.
    /// 
    /// Note: This ratio will change when user drags the panes bar.</summary>
    /// <param name="ratio">Value between 0.0 and 1.0 representing split ratio between panes first and second parts.</param>
    /// <returns></returns>
    virtual public void SetSplitRatio( double ratio) {
                                 Efl.Ui.PanesNativeInherit.efl_ui_panes_split_ratio_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), ratio);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set whether the left and right panes can be resized by user interaction.
    /// By default panes&apos; contents are resizable by user interaction.</summary>
    /// <returns>Use <c>true</c> to fix the left and right panes sizes and make them not to be resized by user interaction. Use <c>false</c> to make them resizable.</returns>
    virtual public bool GetFixed() {
         var _ret_var = Efl.Ui.PanesNativeInherit.efl_ui_panes_fixed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set whether the left and right panes can be resized by user interaction.
    /// By default panes&apos; contents are resizable by user interaction.</summary>
    /// <param name="kw_fixed">Use <c>true</c> to fix the left and right panes sizes and make them not to be resized by user interaction. Use <c>false</c> to make them resizable.</param>
    /// <returns></returns>
    virtual public void SetFixed( bool kw_fixed) {
                                 Efl.Ui.PanesNativeInherit.efl_ui_panes_fixed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), kw_fixed);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <returns>Direction of the widget.</returns>
    virtual public Efl.Ui.Dir GetDirection() {
         var _ret_var = Efl.Ui.IDirectionNativeInherit.efl_ui_direction_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <param name="dir">Direction of the widget.</param>
    /// <returns></returns>
    virtual public void SetDirection( Efl.Ui.Dir dir) {
                                 Efl.Ui.IDirectionNativeInherit.efl_ui_direction_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dir);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the split ratio between panes widget first and second parts.
/// By default it&apos;s homogeneous, i.e., both sides have the same size.
/// 
/// If something different is required, it can be set with this function. For example, if the first content should be displayed over 75% of the panes size, <c>ratio</c> should be passed as 0.75. This way, second content will be resized to 25% of panes size.
/// 
/// If displayed vertically, first content is displayed at top, and second content at bottom.
/// 
/// Note: This ratio will change when user drags the panes bar.</summary>
/// <value>Value between 0.0 and 1.0 representing split ratio between panes first and second parts.</value>
    public double SplitRatio {
        get { return GetSplitRatio(); }
        set { SetSplitRatio( value); }
    }
    /// <summary>Set whether the left and right panes can be resized by user interaction.
/// By default panes&apos; contents are resizable by user interaction.</summary>
/// <value>Use <c>true</c> to fix the left and right panes sizes and make them not to be resized by user interaction. Use <c>false</c> to make them resizable.</value>
    public bool Fixed {
        get { return GetFixed(); }
        set { SetFixed( value); }
    }
    /// <summary>Control the direction of a given widget.
/// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
/// 
/// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
/// <value>Direction of the widget.</value>
    public Efl.Ui.Dir Direction {
        get { return GetDirection(); }
        set { SetDirection( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Panes.efl_ui_panes_class_get();
    }
}
public class PanesNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_panes_split_ratio_get_static_delegate == null)
            efl_ui_panes_split_ratio_get_static_delegate = new efl_ui_panes_split_ratio_get_delegate(split_ratio_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSplitRatio") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_panes_split_ratio_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_split_ratio_get_static_delegate)});
        if (efl_ui_panes_split_ratio_set_static_delegate == null)
            efl_ui_panes_split_ratio_set_static_delegate = new efl_ui_panes_split_ratio_set_delegate(split_ratio_set);
        if (methods.FirstOrDefault(m => m.Name == "SetSplitRatio") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_panes_split_ratio_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_split_ratio_set_static_delegate)});
        if (efl_ui_panes_fixed_get_static_delegate == null)
            efl_ui_panes_fixed_get_static_delegate = new efl_ui_panes_fixed_get_delegate(fixed_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFixed") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_panes_fixed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_fixed_get_static_delegate)});
        if (efl_ui_panes_fixed_set_static_delegate == null)
            efl_ui_panes_fixed_set_static_delegate = new efl_ui_panes_fixed_set_delegate(fixed_set);
        if (methods.FirstOrDefault(m => m.Name == "SetFixed") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_panes_fixed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_panes_fixed_set_static_delegate)});
        if (efl_ui_direction_get_static_delegate == null)
            efl_ui_direction_get_static_delegate = new efl_ui_direction_get_delegate(direction_get);
        if (methods.FirstOrDefault(m => m.Name == "GetDirection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_get_static_delegate)});
        if (efl_ui_direction_set_static_delegate == null)
            efl_ui_direction_set_static_delegate = new efl_ui_direction_set_delegate(direction_set);
        if (methods.FirstOrDefault(m => m.Name == "SetDirection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.Panes.efl_ui_panes_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Panes.efl_ui_panes_class_get();
    }


     private delegate double efl_ui_panes_split_ratio_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_ui_panes_split_ratio_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_panes_split_ratio_get_api_delegate> efl_ui_panes_split_ratio_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panes_split_ratio_get_api_delegate>(_Module, "efl_ui_panes_split_ratio_get");
     private static double split_ratio_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_panes_split_ratio_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Panes)wrapper).GetSplitRatio();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_panes_split_ratio_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_panes_split_ratio_get_delegate efl_ui_panes_split_ratio_get_static_delegate;


     private delegate void efl_ui_panes_split_ratio_set_delegate(System.IntPtr obj, System.IntPtr pd,   double ratio);


     public delegate void efl_ui_panes_split_ratio_set_api_delegate(System.IntPtr obj,   double ratio);
     public static Efl.Eo.FunctionWrapper<efl_ui_panes_split_ratio_set_api_delegate> efl_ui_panes_split_ratio_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panes_split_ratio_set_api_delegate>(_Module, "efl_ui_panes_split_ratio_set");
     private static void split_ratio_set(System.IntPtr obj, System.IntPtr pd,  double ratio)
    {
        Eina.Log.Debug("function efl_ui_panes_split_ratio_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Panes)wrapper).SetSplitRatio( ratio);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_panes_split_ratio_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ratio);
        }
    }
    private static efl_ui_panes_split_ratio_set_delegate efl_ui_panes_split_ratio_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_panes_fixed_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_panes_fixed_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_panes_fixed_get_api_delegate> efl_ui_panes_fixed_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panes_fixed_get_api_delegate>(_Module, "efl_ui_panes_fixed_get");
     private static bool fixed_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_panes_fixed_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Panes)wrapper).GetFixed();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_panes_fixed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_panes_fixed_get_delegate efl_ui_panes_fixed_get_static_delegate;


     private delegate void efl_ui_panes_fixed_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool kw_fixed);


     public delegate void efl_ui_panes_fixed_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool kw_fixed);
     public static Efl.Eo.FunctionWrapper<efl_ui_panes_fixed_set_api_delegate> efl_ui_panes_fixed_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_panes_fixed_set_api_delegate>(_Module, "efl_ui_panes_fixed_set");
     private static void fixed_set(System.IntPtr obj, System.IntPtr pd,  bool kw_fixed)
    {
        Eina.Log.Debug("function efl_ui_panes_fixed_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Panes)wrapper).SetFixed( kw_fixed);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_panes_fixed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_fixed);
        }
    }
    private static efl_ui_panes_fixed_set_delegate efl_ui_panes_fixed_set_static_delegate;


     private delegate Efl.Ui.Dir efl_ui_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Ui.Dir efl_ui_direction_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate> efl_ui_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate>(_Module, "efl_ui_direction_get");
     private static Efl.Ui.Dir direction_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_direction_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Ui.Dir _ret_var = default(Efl.Ui.Dir);
            try {
                _ret_var = ((Panes)wrapper).GetDirection();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_direction_get_delegate efl_ui_direction_get_static_delegate;


     private delegate void efl_ui_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir dir);


     public delegate void efl_ui_direction_set_api_delegate(System.IntPtr obj,   Efl.Ui.Dir dir);
     public static Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate> efl_ui_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate>(_Module, "efl_ui_direction_set");
     private static void direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir)
    {
        Eina.Log.Debug("function efl_ui_direction_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Panes)wrapper).SetDirection( dir);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
        }
    }
    private static efl_ui_direction_set_delegate efl_ui_direction_set_static_delegate;
}
} } 
