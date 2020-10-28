#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { namespace Scroll { 
/// <summary>Efl ui scroll manager class</summary>
[ManagerNativeInherit]
public class Manager : Efl.Object, Efl.Eo.IWrapper,Efl.Ui.II18n,Efl.Ui.IScrollable,Efl.Ui.IScrollableInteractive,Efl.Ui.IScrollbar
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Manager))
                return Efl.Ui.Scroll.ManagerNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_scroll_manager_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public Manager(Efl.Object parent= null
            ) :
        base(efl_ui_scroll_manager_class_get(), typeof(Manager), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Manager(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Manager(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
private static object ScrollStartEvtKey = new object();
    /// <summary>Called when scroll operation starts</summary>
    public event EventHandler ScrollStartEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_START";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollStartEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_START";
                if (RemoveNativeEventHandler(key, this.evt_ScrollStartEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollStartEvt.</summary>
    public void On_ScrollStartEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollStartEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollStartEvt_delegate;
    private void on_ScrollStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollStartEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollEvtKey = new object();
    /// <summary>Called when scrolling</summary>
    public event EventHandler ScrollEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL";
                if (RemoveNativeEventHandler(key, this.evt_ScrollEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollEvt.</summary>
    public void On_ScrollEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollEvt_delegate;
    private void on_ScrollEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollStopEvtKey = new object();
    /// <summary>Called when scroll operation stops</summary>
    public event EventHandler ScrollStopEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_STOP";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollStopEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_STOP";
                if (RemoveNativeEventHandler(key, this.evt_ScrollStopEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollStopEvt.</summary>
    public void On_ScrollStopEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollStopEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollStopEvt_delegate;
    private void on_ScrollStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollStopEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollUpEvtKey = new object();
    /// <summary>Called when scrolling upwards</summary>
    public event EventHandler ScrollUpEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_UP";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollUpEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_UP";
                if (RemoveNativeEventHandler(key, this.evt_ScrollUpEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollUpEvt.</summary>
    public void On_ScrollUpEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollUpEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollUpEvt_delegate;
    private void on_ScrollUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollUpEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollDownEvtKey = new object();
    /// <summary>Called when scrolling downwards</summary>
    public event EventHandler ScrollDownEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_DOWN";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollDownEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_DOWN";
                if (RemoveNativeEventHandler(key, this.evt_ScrollDownEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollDownEvt.</summary>
    public void On_ScrollDownEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollDownEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollDownEvt_delegate;
    private void on_ScrollDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollDownEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollLeftEvtKey = new object();
    /// <summary>Called when scrolling left</summary>
    public event EventHandler ScrollLeftEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_LEFT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollLeftEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollLeftEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_LEFT";
                if (RemoveNativeEventHandler(key, this.evt_ScrollLeftEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollLeftEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollLeftEvt.</summary>
    public void On_ScrollLeftEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollLeftEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollLeftEvt_delegate;
    private void on_ScrollLeftEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollLeftEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollRightEvtKey = new object();
    /// <summary>Called when scrolling right</summary>
    public event EventHandler ScrollRightEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollRightEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
                if (RemoveNativeEventHandler(key, this.evt_ScrollRightEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollRightEvt.</summary>
    public void On_ScrollRightEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollRightEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollRightEvt_delegate;
    private void on_ScrollRightEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollRightEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object EdgeUpEvtKey = new object();
    /// <summary>Called when hitting the top edge</summary>
    public event EventHandler EdgeUpEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_UP";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_EdgeUpEvt_delegate)) {
                    eventHandlers.AddHandler(EdgeUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_UP";
                if (RemoveNativeEventHandler(key, this.evt_EdgeUpEvt_delegate)) { 
                    eventHandlers.RemoveHandler(EdgeUpEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event EdgeUpEvt.</summary>
    public void On_EdgeUpEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[EdgeUpEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_EdgeUpEvt_delegate;
    private void on_EdgeUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_EdgeUpEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object EdgeDownEvtKey = new object();
    /// <summary>Called when hitting the bottom edge</summary>
    public event EventHandler EdgeDownEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_DOWN";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_EdgeDownEvt_delegate)) {
                    eventHandlers.AddHandler(EdgeDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_DOWN";
                if (RemoveNativeEventHandler(key, this.evt_EdgeDownEvt_delegate)) { 
                    eventHandlers.RemoveHandler(EdgeDownEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event EdgeDownEvt.</summary>
    public void On_EdgeDownEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[EdgeDownEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_EdgeDownEvt_delegate;
    private void on_EdgeDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_EdgeDownEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object EdgeLeftEvtKey = new object();
    /// <summary>Called when hitting the left edge</summary>
    public event EventHandler EdgeLeftEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_LEFT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_EdgeLeftEvt_delegate)) {
                    eventHandlers.AddHandler(EdgeLeftEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_LEFT";
                if (RemoveNativeEventHandler(key, this.evt_EdgeLeftEvt_delegate)) { 
                    eventHandlers.RemoveHandler(EdgeLeftEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event EdgeLeftEvt.</summary>
    public void On_EdgeLeftEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[EdgeLeftEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_EdgeLeftEvt_delegate;
    private void on_EdgeLeftEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_EdgeLeftEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object EdgeRightEvtKey = new object();
    /// <summary>Called when hitting the right edge</summary>
    public event EventHandler EdgeRightEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_RIGHT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_EdgeRightEvt_delegate)) {
                    eventHandlers.AddHandler(EdgeRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_EDGE_RIGHT";
                if (RemoveNativeEventHandler(key, this.evt_EdgeRightEvt_delegate)) { 
                    eventHandlers.RemoveHandler(EdgeRightEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event EdgeRightEvt.</summary>
    public void On_EdgeRightEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[EdgeRightEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_EdgeRightEvt_delegate;
    private void on_EdgeRightEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_EdgeRightEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollAnimStartEvtKey = new object();
    /// <summary>Called when scroll animation starts</summary>
    public event EventHandler ScrollAnimStartEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_START";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollAnimStartEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollAnimStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_START";
                if (RemoveNativeEventHandler(key, this.evt_ScrollAnimStartEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollAnimStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollAnimStartEvt.</summary>
    public void On_ScrollAnimStartEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollAnimStartEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollAnimStartEvt_delegate;
    private void on_ScrollAnimStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollAnimStartEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollAnimStopEvtKey = new object();
    /// <summary>Called when scroll animation stopps</summary>
    public event EventHandler ScrollAnimStopEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STOP";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollAnimStopEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollAnimStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STOP";
                if (RemoveNativeEventHandler(key, this.evt_ScrollAnimStopEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollAnimStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollAnimStopEvt.</summary>
    public void On_ScrollAnimStopEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollAnimStopEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollAnimStopEvt_delegate;
    private void on_ScrollAnimStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollAnimStopEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollDragStartEvtKey = new object();
    /// <summary>Called when scroll drag starts</summary>
    public event EventHandler ScrollDragStartEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_START";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollDragStartEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollDragStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_START";
                if (RemoveNativeEventHandler(key, this.evt_ScrollDragStartEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollDragStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollDragStartEvt.</summary>
    public void On_ScrollDragStartEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollDragStartEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollDragStartEvt_delegate;
    private void on_ScrollDragStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollDragStartEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ScrollDragStopEvtKey = new object();
    /// <summary>Called when scroll drag stops</summary>
    public event EventHandler ScrollDragStopEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STOP";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ScrollDragStopEvt_delegate)) {
                    eventHandlers.AddHandler(ScrollDragStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STOP";
                if (RemoveNativeEventHandler(key, this.evt_ScrollDragStopEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ScrollDragStopEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ScrollDragStopEvt.</summary>
    public void On_ScrollDragStopEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[ScrollDragStopEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ScrollDragStopEvt_delegate;
    private void on_ScrollDragStopEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_ScrollDragStopEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarPressEvtKey = new object();
    /// <summary>Called when bar is pressed</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarPressEvt_Args> BarPressEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarPressEvt_delegate)) {
                    eventHandlers.AddHandler(BarPressEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESS";
                if (RemoveNativeEventHandler(key, this.evt_BarPressEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarPressEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarPressEvt.</summary>
    public void On_BarPressEvt(Efl.Ui.IScrollbarBarPressEvt_Args e)
    {
        EventHandler<Efl.Ui.IScrollbarBarPressEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IScrollbarBarPressEvt_Args>)eventHandlers[BarPressEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarPressEvt_delegate;
    private void on_BarPressEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IScrollbarBarPressEvt_Args args = new Efl.Ui.IScrollbarBarPressEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
        try {
            On_BarPressEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarUnpressEvtKey = new object();
    /// <summary>Called when bar is unpressed</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarUnpressEvt_Args> BarUnpressEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarUnpressEvt_delegate)) {
                    eventHandlers.AddHandler(BarUnpressEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESS";
                if (RemoveNativeEventHandler(key, this.evt_BarUnpressEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarUnpressEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarUnpressEvt.</summary>
    public void On_BarUnpressEvt(Efl.Ui.IScrollbarBarUnpressEvt_Args e)
    {
        EventHandler<Efl.Ui.IScrollbarBarUnpressEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IScrollbarBarUnpressEvt_Args>)eventHandlers[BarUnpressEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarUnpressEvt_delegate;
    private void on_BarUnpressEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IScrollbarBarUnpressEvt_Args args = new Efl.Ui.IScrollbarBarUnpressEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
        try {
            On_BarUnpressEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarDragEvtKey = new object();
    /// <summary>Called when bar is dragged</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarDragEvt_Args> BarDragEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarDragEvt_delegate)) {
                    eventHandlers.AddHandler(BarDragEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAG";
                if (RemoveNativeEventHandler(key, this.evt_BarDragEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarDragEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarDragEvt.</summary>
    public void On_BarDragEvt(Efl.Ui.IScrollbarBarDragEvt_Args e)
    {
        EventHandler<Efl.Ui.IScrollbarBarDragEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IScrollbarBarDragEvt_Args>)eventHandlers[BarDragEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarDragEvt_delegate;
    private void on_BarDragEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IScrollbarBarDragEvt_Args args = new Efl.Ui.IScrollbarBarDragEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
        try {
            On_BarDragEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarSizeChangedEvtKey = new object();
    /// <summary>Called when bar size is changed</summary>
    public event EventHandler BarSizeChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarSizeChangedEvt_delegate)) {
                    eventHandlers.AddHandler(BarSizeChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_BarSizeChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarSizeChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarSizeChangedEvt.</summary>
    public void On_BarSizeChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[BarSizeChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarSizeChangedEvt_delegate;
    private void on_BarSizeChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_BarSizeChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarPosChangedEvtKey = new object();
    /// <summary>Called when bar position is changed</summary>
    public event EventHandler BarPosChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarPosChangedEvt_delegate)) {
                    eventHandlers.AddHandler(BarPosChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_BarPosChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarPosChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarPosChangedEvt.</summary>
    public void On_BarPosChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[BarPosChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarPosChangedEvt_delegate;
    private void on_BarPosChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_BarPosChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarShowEvtKey = new object();
    /// <summary>Callend when bar is shown</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarShowEvt_Args> BarShowEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarShowEvt_delegate)) {
                    eventHandlers.AddHandler(BarShowEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
                if (RemoveNativeEventHandler(key, this.evt_BarShowEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarShowEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarShowEvt.</summary>
    public void On_BarShowEvt(Efl.Ui.IScrollbarBarShowEvt_Args e)
    {
        EventHandler<Efl.Ui.IScrollbarBarShowEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IScrollbarBarShowEvt_Args>)eventHandlers[BarShowEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarShowEvt_delegate;
    private void on_BarShowEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IScrollbarBarShowEvt_Args args = new Efl.Ui.IScrollbarBarShowEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
        try {
            On_BarShowEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object BarHideEvtKey = new object();
    /// <summary>Called when bar is hidden</summary>
    public event EventHandler<Efl.Ui.IScrollbarBarHideEvt_Args> BarHideEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_BarHideEvt_delegate)) {
                    eventHandlers.AddHandler(BarHideEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
                if (RemoveNativeEventHandler(key, this.evt_BarHideEvt_delegate)) { 
                    eventHandlers.RemoveHandler(BarHideEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event BarHideEvt.</summary>
    public void On_BarHideEvt(Efl.Ui.IScrollbarBarHideEvt_Args e)
    {
        EventHandler<Efl.Ui.IScrollbarBarHideEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.IScrollbarBarHideEvt_Args>)eventHandlers[BarHideEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_BarHideEvt_delegate;
    private void on_BarHideEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.IScrollbarBarHideEvt_Args args = new Efl.Ui.IScrollbarBarHideEvt_Args();
      args.arg = default(Efl.Ui.ScrollbarDirection);
        try {
            On_BarHideEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_ScrollStartEvt_delegate = new Efl.EventCb(on_ScrollStartEvt_NativeCallback);
        evt_ScrollEvt_delegate = new Efl.EventCb(on_ScrollEvt_NativeCallback);
        evt_ScrollStopEvt_delegate = new Efl.EventCb(on_ScrollStopEvt_NativeCallback);
        evt_ScrollUpEvt_delegate = new Efl.EventCb(on_ScrollUpEvt_NativeCallback);
        evt_ScrollDownEvt_delegate = new Efl.EventCb(on_ScrollDownEvt_NativeCallback);
        evt_ScrollLeftEvt_delegate = new Efl.EventCb(on_ScrollLeftEvt_NativeCallback);
        evt_ScrollRightEvt_delegate = new Efl.EventCb(on_ScrollRightEvt_NativeCallback);
        evt_EdgeUpEvt_delegate = new Efl.EventCb(on_EdgeUpEvt_NativeCallback);
        evt_EdgeDownEvt_delegate = new Efl.EventCb(on_EdgeDownEvt_NativeCallback);
        evt_EdgeLeftEvt_delegate = new Efl.EventCb(on_EdgeLeftEvt_NativeCallback);
        evt_EdgeRightEvt_delegate = new Efl.EventCb(on_EdgeRightEvt_NativeCallback);
        evt_ScrollAnimStartEvt_delegate = new Efl.EventCb(on_ScrollAnimStartEvt_NativeCallback);
        evt_ScrollAnimStopEvt_delegate = new Efl.EventCb(on_ScrollAnimStopEvt_NativeCallback);
        evt_ScrollDragStartEvt_delegate = new Efl.EventCb(on_ScrollDragStartEvt_NativeCallback);
        evt_ScrollDragStopEvt_delegate = new Efl.EventCb(on_ScrollDragStopEvt_NativeCallback);
        evt_BarPressEvt_delegate = new Efl.EventCb(on_BarPressEvt_NativeCallback);
        evt_BarUnpressEvt_delegate = new Efl.EventCb(on_BarUnpressEvt_NativeCallback);
        evt_BarDragEvt_delegate = new Efl.EventCb(on_BarDragEvt_NativeCallback);
        evt_BarSizeChangedEvt_delegate = new Efl.EventCb(on_BarSizeChangedEvt_NativeCallback);
        evt_BarPosChangedEvt_delegate = new Efl.EventCb(on_BarPosChangedEvt_NativeCallback);
        evt_BarShowEvt_delegate = new Efl.EventCb(on_BarShowEvt_NativeCallback);
        evt_BarHideEvt_delegate = new Efl.EventCb(on_BarHideEvt_NativeCallback);
    }
    /// <summary>This is the internal pan object managed by scroll manager.
    /// This property is protected as it is meant for scrollable object implementations only, to set and access the internal pan object. If pan is set to NULL, scrolling does not work.</summary>
    /// <param name="pan">Pan object</param>
    /// <returns></returns>
    virtual public void SetPan( Efl.Ui.Pan pan) {
                                 Efl.Ui.Scroll.ManagerNativeInherit.efl_ui_scroll_manager_pan_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), pan);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether this object should be mirrored.
    /// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
    /// <returns><c>true</c> for RTL, <c>false</c> for LTR (default).</returns>
    virtual public bool GetMirrored() {
         var _ret_var = Efl.Ui.II18nNativeInherit.efl_ui_mirrored_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether this object should be mirrored.
    /// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
    /// <param name="rtl"><c>true</c> for RTL, <c>false</c> for LTR (default).</param>
    /// <returns></returns>
    virtual public void SetMirrored( bool rtl) {
                                 Efl.Ui.II18nNativeInherit.efl_ui_mirrored_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), rtl);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether the property <see cref="Efl.Ui.II18n.Mirrored"/> should be set automatically.
    /// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.II18n.Mirrored"/>.
    /// 
    /// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.IScene"/>) as the configuration should affect only high-level widgets.</summary>
    /// <returns>Whether the widget uses automatic mirroring</returns>
    virtual public bool GetMirroredAutomatic() {
         var _ret_var = Efl.Ui.II18nNativeInherit.efl_ui_mirrored_automatic_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Whether the property <see cref="Efl.Ui.II18n.Mirrored"/> should be set automatically.
    /// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.II18n.Mirrored"/>.
    /// 
    /// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.IScene"/>) as the configuration should affect only high-level widgets.</summary>
    /// <param name="automatic">Whether the widget uses automatic mirroring</param>
    /// <returns></returns>
    virtual public void SetMirroredAutomatic( bool automatic) {
                                 Efl.Ui.II18nNativeInherit.efl_ui_mirrored_automatic_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), automatic);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets the language for this object.</summary>
    /// <returns>The current language.</returns>
    virtual public System.String GetLanguage() {
         var _ret_var = Efl.Ui.II18nNativeInherit.efl_ui_language_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the language for this object.</summary>
    /// <param name="language">The current language.</param>
    /// <returns></returns>
    virtual public void SetLanguage( System.String language) {
                                 Efl.Ui.II18nNativeInherit.efl_ui_language_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), language);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The content position</summary>
    /// <returns>The position is virtual value, (0, 0) starting at the top-left.</returns>
    virtual public Eina.Position2D GetContentPos() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_content_pos_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The content position</summary>
    /// <param name="pos">The position is virtual value, (0, 0) starting at the top-left.</param>
    /// <returns></returns>
    virtual public void SetContentPos( Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_content_pos_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The content size</summary>
    /// <returns>The content size in pixels.</returns>
    virtual public Eina.Size2D GetContentSize() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_content_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The viewport geometry</summary>
    /// <returns>It is absolute geometry.</returns>
    virtual public Eina.Rect GetViewportGeometry() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    /// <returns></returns>
    virtual public void GetBounceEnabled( out bool horiz,  out bool vert) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out horiz,  out vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Bouncing behavior
    /// When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This API will determine if it&apos;s enabled for the given axis with the boolean parameters for each one.</summary>
    /// <param name="horiz">Horizontal bounce policy.</param>
    /// <param name="vert">Vertical bounce policy.</param>
    /// <returns></returns>
    virtual public void SetBounceEnabled( bool horiz,  bool vert) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), horiz,  vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <returns><c>true</c> if freeze, <c>false</c> otherwise</returns>
    virtual public bool GetScrollFreeze() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
    /// <param name="freeze"><c>true</c> if freeze, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetScrollFreeze( bool freeze) {
                                 Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), freeze);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <returns><c>true</c> if hold, <c>false</c> otherwise</returns>
    virtual public bool GetScrollHold() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
    /// <param name="hold"><c>true</c> if hold, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetScrollHold( bool hold) {
                                 Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), hold);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    /// <returns></returns>
    virtual public void GetLooping( out bool loop_h,  out bool loop_v) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_looping_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out loop_h,  out loop_v);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Controls an infinite loop for a scroller.</summary>
    /// <param name="loop_h">The scrolling horizontal loop</param>
    /// <param name="loop_v">The Scrolling vertical loop</param>
    /// <returns></returns>
    virtual public void SetLooping( bool loop_h,  bool loop_v) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_looping_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), loop_h,  loop_v);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <returns>Which axis (or axes) to block</returns>
    virtual public Efl.Ui.ScrollBlock GetMovementBlock() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_movement_block_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Blocking of scrolling (per axis)
    /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
    /// <param name="block">Which axis (or axes) to block</param>
    /// <returns></returns>
    virtual public void SetMovementBlock( Efl.Ui.ScrollBlock block) {
                                 Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_movement_block_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), block);
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
    /// <returns></returns>
    virtual public void GetGravity( out double x,  out double y) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_gravity_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out x,  out y);
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
    /// <returns></returns>
    virtual public void SetGravity( double x,  double y) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_gravity_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), x,  y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
    /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
    /// <param name="w">Whether to limit the minimum horizontal size</param>
    /// <param name="h">Whether to limit the minimum vertical size</param>
    /// <returns></returns>
    virtual public void SetMatchContent( bool w,  bool h) {
                                                         Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_match_content_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), w,  h);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <returns>The step size in pixels</returns>
    virtual public Eina.Position2D GetStepSize() {
         var _ret_var = Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_step_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the step size
    /// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
    /// <param name="step">The step size in pixels</param>
    /// <returns></returns>
    virtual public void SetStepSize( Eina.Position2D step) {
         Eina.Position2D.NativeStruct _in_step = step;
                        Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_step_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_step);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Show a specific virtual region within the scroller content object.
    /// This will ensure all (or part if it does not fit) of the designated region in the virtual content object (0, 0 starting at the top-left of the virtual content object) is shown within the scroller. This allows the scroller to &quot;smoothly slide&quot; to this location (if configuration in general calls for transitions). It may not jump immediately to the new location and make take a while and show other content along the way.</summary>
    /// <param name="rect">The position where to scroll. and The size user want to see</param>
    /// <param name="animation">Whether to scroll with animation or not</param>
    /// <returns></returns>
    virtual public void Scroll( Eina.Rect rect,  bool animation) {
         Eina.Rect.NativeStruct _in_rect = rect;
                                                Efl.Ui.IScrollableInteractiveNativeInherit.efl_ui_scrollable_scroll_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_rect,  animation);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar</param>
    /// <param name="vbar">Vertical scrollbar</param>
    /// <returns></returns>
    virtual public void GetBarMode( out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.IScrollbarNativeInherit.efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out hbar,  out vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar visibility policy</summary>
    /// <param name="hbar">Horizontal scrollbar</param>
    /// <param name="vbar">Vertical scrollbar</param>
    /// <returns></returns>
    virtual public void SetBarMode( Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar) {
                                                         Efl.Ui.IScrollbarNativeInherit.efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), hbar,  vbar);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar size. It is calculated based on viewport size-content sizes.</summary>
    /// <param name="width">Value between 0.0 and 1.0</param>
    /// <param name="height">Value between 0.0 and 1.0</param>
    /// <returns></returns>
    virtual public void GetBarSize( out double width,  out double height) {
                                                         Efl.Ui.IScrollbarNativeInherit.efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out width,  out height);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0</param>
    /// <param name="posy">Value between 0.0 and 1.0</param>
    /// <returns></returns>
    virtual public void GetBarPosition( out double posx,  out double posy) {
                                                         Efl.Ui.IScrollbarNativeInherit.efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out posx,  out posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Scrollbar position. It is calculated based on current position-maximum positions.</summary>
    /// <param name="posx">Value between 0.0 and 1.0</param>
    /// <param name="posy">Value between 0.0 and 1.0</param>
    /// <returns></returns>
    virtual public void SetBarPosition( double posx,  double posy) {
                                                         Efl.Ui.IScrollbarNativeInherit.efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), posx,  posy);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Update bar visibility.
    /// The object will call this function whenever the bar need to be shown or hidden.</summary>
    /// <returns></returns>
    virtual public void UpdateBarVisibility() {
         Efl.Ui.IScrollbarNativeInherit.efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>This is the internal pan object managed by scroll manager.
/// This property is protected as it is meant for scrollable object implementations only, to set and access the internal pan object. If pan is set to NULL, scrolling does not work.</summary>
/// <value>Pan object</value>
    public Efl.Ui.Pan Pan {
        set { SetPan( value); }
    }
    /// <summary>Whether this object should be mirrored.
/// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
/// <value><c>true</c> for RTL, <c>false</c> for LTR (default).</value>
    public bool Mirrored {
        get { return GetMirrored(); }
        set { SetMirrored( value); }
    }
    /// <summary>Whether the property <see cref="Efl.Ui.II18n.Mirrored"/> should be set automatically.
/// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.II18n.Mirrored"/>.
/// 
/// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.IScene"/>) as the configuration should affect only high-level widgets.</summary>
/// <value>Whether the widget uses automatic mirroring</value>
    public bool MirroredAutomatic {
        get { return GetMirroredAutomatic(); }
        set { SetMirroredAutomatic( value); }
    }
    /// <summary>The (human) language for this object.</summary>
/// <value>The current language.</value>
    public System.String Language {
        get { return GetLanguage(); }
        set { SetLanguage( value); }
    }
    /// <summary>The content position</summary>
/// <value>The position is virtual value, (0, 0) starting at the top-left.</value>
    public Eina.Position2D ContentPos {
        get { return GetContentPos(); }
        set { SetContentPos( value); }
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
    /// <summary>Freeze property This function will freeze scrolling movement (by input of a user). Unlike efl_ui_scrollable_movement_block_set, this function freezes bidirectionally. If you want to freeze in only one direction, See <see cref="Efl.Ui.IScrollableInteractive.SetMovementBlock"/>.</summary>
/// <value><c>true</c> if freeze, <c>false</c> otherwise</value>
    public bool ScrollFreeze {
        get { return GetScrollFreeze(); }
        set { SetScrollFreeze( value); }
    }
    /// <summary>Hold property When hold turns on, it only scrolls by holding action.</summary>
/// <value><c>true</c> if hold, <c>false</c> otherwise</value>
    public bool ScrollHold {
        get { return GetScrollHold(); }
        set { SetScrollHold( value); }
    }
    /// <summary>Blocking of scrolling (per axis)
/// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <c>none</c>, where movements are allowed in both directions.</summary>
/// <value>Which axis (or axes) to block</value>
    public Efl.Ui.ScrollBlock MovementBlock {
        get { return GetMovementBlock(); }
        set { SetMovementBlock( value); }
    }
    /// <summary>Control the step size
/// Use this call to set step size. This value is used when scroller scroll by arrow key event.</summary>
/// <value>The step size in pixels</value>
    public Eina.Position2D StepSize {
        get { return GetStepSize(); }
        set { SetStepSize( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Scroll.Manager.efl_ui_scroll_manager_class_get();
    }
}
public class ManagerNativeInherit : Efl.ObjectNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_scroll_manager_pan_set_static_delegate == null)
            efl_ui_scroll_manager_pan_set_static_delegate = new efl_ui_scroll_manager_pan_set_delegate(pan_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPan") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scroll_manager_pan_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scroll_manager_pan_set_static_delegate)});
        if (efl_ui_mirrored_get_static_delegate == null)
            efl_ui_mirrored_get_static_delegate = new efl_ui_mirrored_get_delegate(mirrored_get);
        if (methods.FirstOrDefault(m => m.Name == "GetMirrored") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_mirrored_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_get_static_delegate)});
        if (efl_ui_mirrored_set_static_delegate == null)
            efl_ui_mirrored_set_static_delegate = new efl_ui_mirrored_set_delegate(mirrored_set);
        if (methods.FirstOrDefault(m => m.Name == "SetMirrored") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_mirrored_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_set_static_delegate)});
        if (efl_ui_mirrored_automatic_get_static_delegate == null)
            efl_ui_mirrored_automatic_get_static_delegate = new efl_ui_mirrored_automatic_get_delegate(mirrored_automatic_get);
        if (methods.FirstOrDefault(m => m.Name == "GetMirroredAutomatic") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_mirrored_automatic_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_automatic_get_static_delegate)});
        if (efl_ui_mirrored_automatic_set_static_delegate == null)
            efl_ui_mirrored_automatic_set_static_delegate = new efl_ui_mirrored_automatic_set_delegate(mirrored_automatic_set);
        if (methods.FirstOrDefault(m => m.Name == "SetMirroredAutomatic") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_mirrored_automatic_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_automatic_set_static_delegate)});
        if (efl_ui_language_get_static_delegate == null)
            efl_ui_language_get_static_delegate = new efl_ui_language_get_delegate(language_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLanguage") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_language_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_language_get_static_delegate)});
        if (efl_ui_language_set_static_delegate == null)
            efl_ui_language_set_static_delegate = new efl_ui_language_set_delegate(language_set);
        if (methods.FirstOrDefault(m => m.Name == "SetLanguage") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_language_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_language_set_static_delegate)});
        if (efl_ui_scrollable_content_pos_get_static_delegate == null)
            efl_ui_scrollable_content_pos_get_static_delegate = new efl_ui_scrollable_content_pos_get_delegate(content_pos_get);
        if (methods.FirstOrDefault(m => m.Name == "GetContentPos") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_content_pos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_get_static_delegate)});
        if (efl_ui_scrollable_content_pos_set_static_delegate == null)
            efl_ui_scrollable_content_pos_set_static_delegate = new efl_ui_scrollable_content_pos_set_delegate(content_pos_set);
        if (methods.FirstOrDefault(m => m.Name == "SetContentPos") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_content_pos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_pos_set_static_delegate)});
        if (efl_ui_scrollable_content_size_get_static_delegate == null)
            efl_ui_scrollable_content_size_get_static_delegate = new efl_ui_scrollable_content_size_get_delegate(content_size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetContentSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_content_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_content_size_get_static_delegate)});
        if (efl_ui_scrollable_viewport_geometry_get_static_delegate == null)
            efl_ui_scrollable_viewport_geometry_get_static_delegate = new efl_ui_scrollable_viewport_geometry_get_delegate(viewport_geometry_get);
        if (methods.FirstOrDefault(m => m.Name == "GetViewportGeometry") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_viewport_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_viewport_geometry_get_static_delegate)});
        if (efl_ui_scrollable_bounce_enabled_get_static_delegate == null)
            efl_ui_scrollable_bounce_enabled_get_static_delegate = new efl_ui_scrollable_bounce_enabled_get_delegate(bounce_enabled_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBounceEnabled") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_bounce_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_get_static_delegate)});
        if (efl_ui_scrollable_bounce_enabled_set_static_delegate == null)
            efl_ui_scrollable_bounce_enabled_set_static_delegate = new efl_ui_scrollable_bounce_enabled_set_delegate(bounce_enabled_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBounceEnabled") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_bounce_enabled_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_bounce_enabled_set_static_delegate)});
        if (efl_ui_scrollable_scroll_freeze_get_static_delegate == null)
            efl_ui_scrollable_scroll_freeze_get_static_delegate = new efl_ui_scrollable_scroll_freeze_get_delegate(scroll_freeze_get);
        if (methods.FirstOrDefault(m => m.Name == "GetScrollFreeze") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll_freeze_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_get_static_delegate)});
        if (efl_ui_scrollable_scroll_freeze_set_static_delegate == null)
            efl_ui_scrollable_scroll_freeze_set_static_delegate = new efl_ui_scrollable_scroll_freeze_set_delegate(scroll_freeze_set);
        if (methods.FirstOrDefault(m => m.Name == "SetScrollFreeze") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll_freeze_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_freeze_set_static_delegate)});
        if (efl_ui_scrollable_scroll_hold_get_static_delegate == null)
            efl_ui_scrollable_scroll_hold_get_static_delegate = new efl_ui_scrollable_scroll_hold_get_delegate(scroll_hold_get);
        if (methods.FirstOrDefault(m => m.Name == "GetScrollHold") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll_hold_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_get_static_delegate)});
        if (efl_ui_scrollable_scroll_hold_set_static_delegate == null)
            efl_ui_scrollable_scroll_hold_set_static_delegate = new efl_ui_scrollable_scroll_hold_set_delegate(scroll_hold_set);
        if (methods.FirstOrDefault(m => m.Name == "SetScrollHold") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll_hold_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_hold_set_static_delegate)});
        if (efl_ui_scrollable_looping_get_static_delegate == null)
            efl_ui_scrollable_looping_get_static_delegate = new efl_ui_scrollable_looping_get_delegate(looping_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLooping") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_looping_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_get_static_delegate)});
        if (efl_ui_scrollable_looping_set_static_delegate == null)
            efl_ui_scrollable_looping_set_static_delegate = new efl_ui_scrollable_looping_set_delegate(looping_set);
        if (methods.FirstOrDefault(m => m.Name == "SetLooping") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_looping_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_looping_set_static_delegate)});
        if (efl_ui_scrollable_movement_block_get_static_delegate == null)
            efl_ui_scrollable_movement_block_get_static_delegate = new efl_ui_scrollable_movement_block_get_delegate(movement_block_get);
        if (methods.FirstOrDefault(m => m.Name == "GetMovementBlock") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_movement_block_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_get_static_delegate)});
        if (efl_ui_scrollable_movement_block_set_static_delegate == null)
            efl_ui_scrollable_movement_block_set_static_delegate = new efl_ui_scrollable_movement_block_set_delegate(movement_block_set);
        if (methods.FirstOrDefault(m => m.Name == "SetMovementBlock") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_movement_block_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_movement_block_set_static_delegate)});
        if (efl_ui_scrollable_gravity_get_static_delegate == null)
            efl_ui_scrollable_gravity_get_static_delegate = new efl_ui_scrollable_gravity_get_delegate(gravity_get);
        if (methods.FirstOrDefault(m => m.Name == "GetGravity") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_gravity_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_get_static_delegate)});
        if (efl_ui_scrollable_gravity_set_static_delegate == null)
            efl_ui_scrollable_gravity_set_static_delegate = new efl_ui_scrollable_gravity_set_delegate(gravity_set);
        if (methods.FirstOrDefault(m => m.Name == "SetGravity") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_gravity_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_gravity_set_static_delegate)});
        if (efl_ui_scrollable_match_content_set_static_delegate == null)
            efl_ui_scrollable_match_content_set_static_delegate = new efl_ui_scrollable_match_content_set_delegate(match_content_set);
        if (methods.FirstOrDefault(m => m.Name == "SetMatchContent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_match_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_match_content_set_static_delegate)});
        if (efl_ui_scrollable_step_size_get_static_delegate == null)
            efl_ui_scrollable_step_size_get_static_delegate = new efl_ui_scrollable_step_size_get_delegate(step_size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetStepSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_step_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_step_size_get_static_delegate)});
        if (efl_ui_scrollable_step_size_set_static_delegate == null)
            efl_ui_scrollable_step_size_set_static_delegate = new efl_ui_scrollable_step_size_set_delegate(step_size_set);
        if (methods.FirstOrDefault(m => m.Name == "SetStepSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_step_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_step_size_set_static_delegate)});
        if (efl_ui_scrollable_scroll_static_delegate == null)
            efl_ui_scrollable_scroll_static_delegate = new efl_ui_scrollable_scroll_delegate(scroll);
        if (methods.FirstOrDefault(m => m.Name == "Scroll") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollable_scroll"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollable_scroll_static_delegate)});
        if (efl_ui_scrollbar_bar_mode_get_static_delegate == null)
            efl_ui_scrollbar_bar_mode_get_static_delegate = new efl_ui_scrollbar_bar_mode_get_delegate(bar_mode_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBarMode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_get_static_delegate)});
        if (efl_ui_scrollbar_bar_mode_set_static_delegate == null)
            efl_ui_scrollbar_bar_mode_set_static_delegate = new efl_ui_scrollbar_bar_mode_set_delegate(bar_mode_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBarMode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_set_static_delegate)});
        if (efl_ui_scrollbar_bar_size_get_static_delegate == null)
            efl_ui_scrollbar_bar_size_get_static_delegate = new efl_ui_scrollbar_bar_size_get_delegate(bar_size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBarSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_size_get_static_delegate)});
        if (efl_ui_scrollbar_bar_position_get_static_delegate == null)
            efl_ui_scrollbar_bar_position_get_static_delegate = new efl_ui_scrollbar_bar_position_get_delegate(bar_position_get);
        if (methods.FirstOrDefault(m => m.Name == "GetBarPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_get_static_delegate)});
        if (efl_ui_scrollbar_bar_position_set_static_delegate == null)
            efl_ui_scrollbar_bar_position_set_static_delegate = new efl_ui_scrollbar_bar_position_set_delegate(bar_position_set);
        if (methods.FirstOrDefault(m => m.Name == "SetBarPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_set_static_delegate)});
        if (efl_ui_scrollbar_bar_visibility_update_static_delegate == null)
            efl_ui_scrollbar_bar_visibility_update_static_delegate = new efl_ui_scrollbar_bar_visibility_update_delegate(bar_visibility_update);
        if (methods.FirstOrDefault(m => m.Name == "UpdateBarVisibility") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_scrollbar_bar_visibility_update"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_visibility_update_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.Scroll.Manager.efl_ui_scroll_manager_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Scroll.Manager.efl_ui_scroll_manager_class_get();
    }


     private delegate void efl_ui_scroll_manager_pan_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Pan, Efl.Eo.NonOwnTag>))]  Efl.Ui.Pan pan);


     public delegate void efl_ui_scroll_manager_pan_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Ui.Pan, Efl.Eo.NonOwnTag>))]  Efl.Ui.Pan pan);
     public static Efl.Eo.FunctionWrapper<efl_ui_scroll_manager_pan_set_api_delegate> efl_ui_scroll_manager_pan_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scroll_manager_pan_set_api_delegate>(_Module, "efl_ui_scroll_manager_pan_set");
     private static void pan_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Pan pan)
    {
        Eina.Log.Debug("function efl_ui_scroll_manager_pan_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Manager)wrapper).SetPan( pan);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_scroll_manager_pan_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pan);
        }
    }
    private static efl_ui_scroll_manager_pan_set_delegate efl_ui_scroll_manager_pan_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_mirrored_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_mirrored_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_mirrored_get_api_delegate> efl_ui_mirrored_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_mirrored_get_api_delegate>(_Module, "efl_ui_mirrored_get");
     private static bool mirrored_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_mirrored_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Manager)wrapper).GetMirrored();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_mirrored_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_mirrored_get_delegate efl_ui_mirrored_get_static_delegate;


     private delegate void efl_ui_mirrored_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool rtl);


     public delegate void efl_ui_mirrored_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool rtl);
     public static Efl.Eo.FunctionWrapper<efl_ui_mirrored_set_api_delegate> efl_ui_mirrored_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_mirrored_set_api_delegate>(_Module, "efl_ui_mirrored_set");
     private static void mirrored_set(System.IntPtr obj, System.IntPtr pd,  bool rtl)
    {
        Eina.Log.Debug("function efl_ui_mirrored_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Manager)wrapper).SetMirrored( rtl);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_mirrored_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rtl);
        }
    }
    private static efl_ui_mirrored_set_delegate efl_ui_mirrored_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_mirrored_automatic_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_mirrored_automatic_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_mirrored_automatic_get_api_delegate> efl_ui_mirrored_automatic_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_mirrored_automatic_get_api_delegate>(_Module, "efl_ui_mirrored_automatic_get");
     private static bool mirrored_automatic_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_mirrored_automatic_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Manager)wrapper).GetMirroredAutomatic();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_mirrored_automatic_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_mirrored_automatic_get_delegate efl_ui_mirrored_automatic_get_static_delegate;


     private delegate void efl_ui_mirrored_automatic_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool automatic);


     public delegate void efl_ui_mirrored_automatic_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool automatic);
     public static Efl.Eo.FunctionWrapper<efl_ui_mirrored_automatic_set_api_delegate> efl_ui_mirrored_automatic_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_mirrored_automatic_set_api_delegate>(_Module, "efl_ui_mirrored_automatic_set");
     private static void mirrored_automatic_set(System.IntPtr obj, System.IntPtr pd,  bool automatic)
    {
        Eina.Log.Debug("function efl_ui_mirrored_automatic_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Manager)wrapper).SetMirroredAutomatic( automatic);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_mirrored_automatic_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  automatic);
        }
    }
    private static efl_ui_mirrored_automatic_set_delegate efl_ui_mirrored_automatic_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_ui_language_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_ui_language_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_language_get_api_delegate> efl_ui_language_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_language_get_api_delegate>(_Module, "efl_ui_language_get");
     private static System.String language_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_language_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Manager)wrapper).GetLanguage();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_language_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_language_get_delegate efl_ui_language_get_static_delegate;


     private delegate void efl_ui_language_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String language);


     public delegate void efl_ui_language_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String language);
     public static Efl.Eo.FunctionWrapper<efl_ui_language_set_api_delegate> efl_ui_language_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_language_set_api_delegate>(_Module, "efl_ui_language_set");
     private static void language_set(System.IntPtr obj, System.IntPtr pd,  System.String language)
    {
        Eina.Log.Debug("function efl_ui_language_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Manager)wrapper).SetLanguage( language);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_language_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  language);
        }
    }
    private static efl_ui_language_set_delegate efl_ui_language_set_static_delegate;


     private delegate Eina.Position2D.NativeStruct efl_ui_scrollable_content_pos_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Position2D.NativeStruct efl_ui_scrollable_content_pos_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_get_api_delegate> efl_ui_scrollable_content_pos_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_get_api_delegate>(_Module, "efl_ui_scrollable_content_pos_get");
     private static Eina.Position2D.NativeStruct content_pos_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_content_pos_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Position2D _ret_var = default(Eina.Position2D);
            try {
                _ret_var = ((Manager)wrapper).GetContentPos();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_content_pos_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_content_pos_get_delegate efl_ui_scrollable_content_pos_get_static_delegate;


     private delegate void efl_ui_scrollable_content_pos_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D.NativeStruct pos);


     public delegate void efl_ui_scrollable_content_pos_set_api_delegate(System.IntPtr obj,   Eina.Position2D.NativeStruct pos);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_set_api_delegate> efl_ui_scrollable_content_pos_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_pos_set_api_delegate>(_Module, "efl_ui_scrollable_content_pos_set");
     private static void content_pos_set(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos)
    {
        Eina.Log.Debug("function efl_ui_scrollable_content_pos_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Position2D _in_pos = pos;
                            
            try {
                ((Manager)wrapper).SetContentPos( _in_pos);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_scrollable_content_pos_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
        }
    }
    private static efl_ui_scrollable_content_pos_set_delegate efl_ui_scrollable_content_pos_set_static_delegate;


     private delegate Eina.Size2D.NativeStruct efl_ui_scrollable_content_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Size2D.NativeStruct efl_ui_scrollable_content_size_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_size_get_api_delegate> efl_ui_scrollable_content_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_content_size_get_api_delegate>(_Module, "efl_ui_scrollable_content_size_get");
     private static Eina.Size2D.NativeStruct content_size_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_content_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Size2D _ret_var = default(Eina.Size2D);
            try {
                _ret_var = ((Manager)wrapper).GetContentSize();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_content_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_content_size_get_delegate efl_ui_scrollable_content_size_get_static_delegate;


     private delegate Eina.Rect.NativeStruct efl_ui_scrollable_viewport_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Rect.NativeStruct efl_ui_scrollable_viewport_geometry_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_viewport_geometry_get_api_delegate> efl_ui_scrollable_viewport_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_viewport_geometry_get_api_delegate>(_Module, "efl_ui_scrollable_viewport_geometry_get");
     private static Eina.Rect.NativeStruct viewport_geometry_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_viewport_geometry_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Rect _ret_var = default(Eina.Rect);
            try {
                _ret_var = ((Manager)wrapper).GetViewportGeometry();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_viewport_geometry_get_delegate efl_ui_scrollable_viewport_geometry_get_static_delegate;


     private delegate void efl_ui_scrollable_bounce_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  out bool horiz,  [MarshalAs(UnmanagedType.U1)]  out bool vert);


     public delegate void efl_ui_scrollable_bounce_enabled_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool horiz,  [MarshalAs(UnmanagedType.U1)]  out bool vert);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_get_api_delegate> efl_ui_scrollable_bounce_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_get_api_delegate>(_Module, "efl_ui_scrollable_bounce_enabled_get");
     private static void bounce_enabled_get(System.IntPtr obj, System.IntPtr pd,  out bool horiz,  out bool vert)
    {
        Eina.Log.Debug("function efl_ui_scrollable_bounce_enabled_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    horiz = default(bool);        vert = default(bool);                            
            try {
                ((Manager)wrapper).GetBounceEnabled( out horiz,  out vert);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out horiz,  out vert);
        }
    }
    private static efl_ui_scrollable_bounce_enabled_get_delegate efl_ui_scrollable_bounce_enabled_get_static_delegate;


     private delegate void efl_ui_scrollable_bounce_enabled_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool horiz,  [MarshalAs(UnmanagedType.U1)]  bool vert);


     public delegate void efl_ui_scrollable_bounce_enabled_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool horiz,  [MarshalAs(UnmanagedType.U1)]  bool vert);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_set_api_delegate> efl_ui_scrollable_bounce_enabled_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_bounce_enabled_set_api_delegate>(_Module, "efl_ui_scrollable_bounce_enabled_set");
     private static void bounce_enabled_set(System.IntPtr obj, System.IntPtr pd,  bool horiz,  bool vert)
    {
        Eina.Log.Debug("function efl_ui_scrollable_bounce_enabled_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((Manager)wrapper).SetBounceEnabled( horiz,  vert);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  horiz,  vert);
        }
    }
    private static efl_ui_scrollable_bounce_enabled_set_delegate efl_ui_scrollable_bounce_enabled_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_scrollable_scroll_freeze_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_scrollable_scroll_freeze_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_get_api_delegate> efl_ui_scrollable_scroll_freeze_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_get_api_delegate>(_Module, "efl_ui_scrollable_scroll_freeze_get");
     private static bool scroll_freeze_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_scroll_freeze_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Manager)wrapper).GetScrollFreeze();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_scroll_freeze_get_delegate efl_ui_scrollable_scroll_freeze_get_static_delegate;


     private delegate void efl_ui_scrollable_scroll_freeze_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool freeze);


     public delegate void efl_ui_scrollable_scroll_freeze_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool freeze);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_set_api_delegate> efl_ui_scrollable_scroll_freeze_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_freeze_set_api_delegate>(_Module, "efl_ui_scrollable_scroll_freeze_set");
     private static void scroll_freeze_set(System.IntPtr obj, System.IntPtr pd,  bool freeze)
    {
        Eina.Log.Debug("function efl_ui_scrollable_scroll_freeze_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Manager)wrapper).SetScrollFreeze( freeze);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  freeze);
        }
    }
    private static efl_ui_scrollable_scroll_freeze_set_delegate efl_ui_scrollable_scroll_freeze_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_scrollable_scroll_hold_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_scrollable_scroll_hold_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_get_api_delegate> efl_ui_scrollable_scroll_hold_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_get_api_delegate>(_Module, "efl_ui_scrollable_scroll_hold_get");
     private static bool scroll_hold_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_scroll_hold_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Manager)wrapper).GetScrollHold();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_scroll_hold_get_delegate efl_ui_scrollable_scroll_hold_get_static_delegate;


     private delegate void efl_ui_scrollable_scroll_hold_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool hold);


     public delegate void efl_ui_scrollable_scroll_hold_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool hold);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_set_api_delegate> efl_ui_scrollable_scroll_hold_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_hold_set_api_delegate>(_Module, "efl_ui_scrollable_scroll_hold_set");
     private static void scroll_hold_set(System.IntPtr obj, System.IntPtr pd,  bool hold)
    {
        Eina.Log.Debug("function efl_ui_scrollable_scroll_hold_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Manager)wrapper).SetScrollHold( hold);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hold);
        }
    }
    private static efl_ui_scrollable_scroll_hold_set_delegate efl_ui_scrollable_scroll_hold_set_static_delegate;


     private delegate void efl_ui_scrollable_looping_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  out bool loop_h,  [MarshalAs(UnmanagedType.U1)]  out bool loop_v);


     public delegate void efl_ui_scrollable_looping_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool loop_h,  [MarshalAs(UnmanagedType.U1)]  out bool loop_v);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_get_api_delegate> efl_ui_scrollable_looping_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_get_api_delegate>(_Module, "efl_ui_scrollable_looping_get");
     private static void looping_get(System.IntPtr obj, System.IntPtr pd,  out bool loop_h,  out bool loop_v)
    {
        Eina.Log.Debug("function efl_ui_scrollable_looping_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    loop_h = default(bool);        loop_v = default(bool);                            
            try {
                ((Manager)wrapper).GetLooping( out loop_h,  out loop_v);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_looping_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out loop_h,  out loop_v);
        }
    }
    private static efl_ui_scrollable_looping_get_delegate efl_ui_scrollable_looping_get_static_delegate;


     private delegate void efl_ui_scrollable_looping_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool loop_h,  [MarshalAs(UnmanagedType.U1)]  bool loop_v);


     public delegate void efl_ui_scrollable_looping_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool loop_h,  [MarshalAs(UnmanagedType.U1)]  bool loop_v);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_set_api_delegate> efl_ui_scrollable_looping_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_looping_set_api_delegate>(_Module, "efl_ui_scrollable_looping_set");
     private static void looping_set(System.IntPtr obj, System.IntPtr pd,  bool loop_h,  bool loop_v)
    {
        Eina.Log.Debug("function efl_ui_scrollable_looping_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((Manager)wrapper).SetLooping( loop_h,  loop_v);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_looping_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  loop_h,  loop_v);
        }
    }
    private static efl_ui_scrollable_looping_set_delegate efl_ui_scrollable_looping_set_static_delegate;


     private delegate Efl.Ui.ScrollBlock efl_ui_scrollable_movement_block_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Ui.ScrollBlock efl_ui_scrollable_movement_block_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_get_api_delegate> efl_ui_scrollable_movement_block_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_get_api_delegate>(_Module, "efl_ui_scrollable_movement_block_get");
     private static Efl.Ui.ScrollBlock movement_block_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_movement_block_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Ui.ScrollBlock _ret_var = default(Efl.Ui.ScrollBlock);
            try {
                _ret_var = ((Manager)wrapper).GetMovementBlock();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_movement_block_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_movement_block_get_delegate efl_ui_scrollable_movement_block_get_static_delegate;


     private delegate void efl_ui_scrollable_movement_block_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ScrollBlock block);


     public delegate void efl_ui_scrollable_movement_block_set_api_delegate(System.IntPtr obj,   Efl.Ui.ScrollBlock block);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_set_api_delegate> efl_ui_scrollable_movement_block_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_movement_block_set_api_delegate>(_Module, "efl_ui_scrollable_movement_block_set");
     private static void movement_block_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ScrollBlock block)
    {
        Eina.Log.Debug("function efl_ui_scrollable_movement_block_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Manager)wrapper).SetMovementBlock( block);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_scrollable_movement_block_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  block);
        }
    }
    private static efl_ui_scrollable_movement_block_set_delegate efl_ui_scrollable_movement_block_set_static_delegate;


     private delegate void efl_ui_scrollable_gravity_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);


     public delegate void efl_ui_scrollable_gravity_get_api_delegate(System.IntPtr obj,   out double x,   out double y);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_get_api_delegate> efl_ui_scrollable_gravity_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_get_api_delegate>(_Module, "efl_ui_scrollable_gravity_get");
     private static void gravity_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
    {
        Eina.Log.Debug("function efl_ui_scrollable_gravity_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    x = default(double);        y = default(double);                            
            try {
                ((Manager)wrapper).GetGravity( out x,  out y);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_gravity_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
        }
    }
    private static efl_ui_scrollable_gravity_get_delegate efl_ui_scrollable_gravity_get_static_delegate;


     private delegate void efl_ui_scrollable_gravity_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);


     public delegate void efl_ui_scrollable_gravity_set_api_delegate(System.IntPtr obj,   double x,   double y);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_set_api_delegate> efl_ui_scrollable_gravity_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_gravity_set_api_delegate>(_Module, "efl_ui_scrollable_gravity_set");
     private static void gravity_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
    {
        Eina.Log.Debug("function efl_ui_scrollable_gravity_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((Manager)wrapper).SetGravity( x,  y);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_gravity_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
        }
    }
    private static efl_ui_scrollable_gravity_set_delegate efl_ui_scrollable_gravity_set_static_delegate;


     private delegate void efl_ui_scrollable_match_content_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool w,  [MarshalAs(UnmanagedType.U1)]  bool h);


     public delegate void efl_ui_scrollable_match_content_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool w,  [MarshalAs(UnmanagedType.U1)]  bool h);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_match_content_set_api_delegate> efl_ui_scrollable_match_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_match_content_set_api_delegate>(_Module, "efl_ui_scrollable_match_content_set");
     private static void match_content_set(System.IntPtr obj, System.IntPtr pd,  bool w,  bool h)
    {
        Eina.Log.Debug("function efl_ui_scrollable_match_content_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((Manager)wrapper).SetMatchContent( w,  h);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_match_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  w,  h);
        }
    }
    private static efl_ui_scrollable_match_content_set_delegate efl_ui_scrollable_match_content_set_static_delegate;


     private delegate Eina.Position2D.NativeStruct efl_ui_scrollable_step_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Position2D.NativeStruct efl_ui_scrollable_step_size_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_get_api_delegate> efl_ui_scrollable_step_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_get_api_delegate>(_Module, "efl_ui_scrollable_step_size_get");
     private static Eina.Position2D.NativeStruct step_size_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollable_step_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Position2D _ret_var = default(Eina.Position2D);
            try {
                _ret_var = ((Manager)wrapper).GetStepSize();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_scrollable_step_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollable_step_size_get_delegate efl_ui_scrollable_step_size_get_static_delegate;


     private delegate void efl_ui_scrollable_step_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D.NativeStruct step);


     public delegate void efl_ui_scrollable_step_size_set_api_delegate(System.IntPtr obj,   Eina.Position2D.NativeStruct step);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_set_api_delegate> efl_ui_scrollable_step_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_step_size_set_api_delegate>(_Module, "efl_ui_scrollable_step_size_set");
     private static void step_size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct step)
    {
        Eina.Log.Debug("function efl_ui_scrollable_step_size_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Position2D _in_step = step;
                            
            try {
                ((Manager)wrapper).SetStepSize( _in_step);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_scrollable_step_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  step);
        }
    }
    private static efl_ui_scrollable_step_size_set_delegate efl_ui_scrollable_step_size_set_static_delegate;


     private delegate void efl_ui_scrollable_scroll_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect.NativeStruct rect,  [MarshalAs(UnmanagedType.U1)]  bool animation);


     public delegate void efl_ui_scrollable_scroll_api_delegate(System.IntPtr obj,   Eina.Rect.NativeStruct rect,  [MarshalAs(UnmanagedType.U1)]  bool animation);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_api_delegate> efl_ui_scrollable_scroll_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollable_scroll_api_delegate>(_Module, "efl_ui_scrollable_scroll");
     private static void scroll(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct rect,  bool animation)
    {
        Eina.Log.Debug("function efl_ui_scrollable_scroll was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Rect _in_rect = rect;
                                                    
            try {
                ((Manager)wrapper).Scroll( _in_rect,  animation);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollable_scroll_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rect,  animation);
        }
    }
    private static efl_ui_scrollable_scroll_delegate efl_ui_scrollable_scroll_static_delegate;


     private delegate void efl_ui_scrollbar_bar_mode_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.Ui.ScrollbarMode hbar,   out Efl.Ui.ScrollbarMode vbar);


     public delegate void efl_ui_scrollbar_bar_mode_get_api_delegate(System.IntPtr obj,   out Efl.Ui.ScrollbarMode hbar,   out Efl.Ui.ScrollbarMode vbar);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate> efl_ui_scrollbar_bar_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate>(_Module, "efl_ui_scrollbar_bar_mode_get");
     private static void bar_mode_get(System.IntPtr obj, System.IntPtr pd,  out Efl.Ui.ScrollbarMode hbar,  out Efl.Ui.ScrollbarMode vbar)
    {
        Eina.Log.Debug("function efl_ui_scrollbar_bar_mode_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    hbar = default(Efl.Ui.ScrollbarMode);        vbar = default(Efl.Ui.ScrollbarMode);                            
            try {
                ((Manager)wrapper).GetBarMode( out hbar,  out vbar);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out hbar,  out vbar);
        }
    }
    private static efl_ui_scrollbar_bar_mode_get_delegate efl_ui_scrollbar_bar_mode_get_static_delegate;


     private delegate void efl_ui_scrollbar_bar_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.ScrollbarMode hbar,   Efl.Ui.ScrollbarMode vbar);


     public delegate void efl_ui_scrollbar_bar_mode_set_api_delegate(System.IntPtr obj,   Efl.Ui.ScrollbarMode hbar,   Efl.Ui.ScrollbarMode vbar);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate> efl_ui_scrollbar_bar_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate>(_Module, "efl_ui_scrollbar_bar_mode_set");
     private static void bar_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.ScrollbarMode hbar,  Efl.Ui.ScrollbarMode vbar)
    {
        Eina.Log.Debug("function efl_ui_scrollbar_bar_mode_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((Manager)wrapper).SetBarMode( hbar,  vbar);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  hbar,  vbar);
        }
    }
    private static efl_ui_scrollbar_bar_mode_set_delegate efl_ui_scrollbar_bar_mode_set_static_delegate;


     private delegate void efl_ui_scrollbar_bar_size_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double width,   out double height);


     public delegate void efl_ui_scrollbar_bar_size_get_api_delegate(System.IntPtr obj,   out double width,   out double height);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate> efl_ui_scrollbar_bar_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate>(_Module, "efl_ui_scrollbar_bar_size_get");
     private static void bar_size_get(System.IntPtr obj, System.IntPtr pd,  out double width,  out double height)
    {
        Eina.Log.Debug("function efl_ui_scrollbar_bar_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    width = default(double);        height = default(double);                            
            try {
                ((Manager)wrapper).GetBarSize( out width,  out height);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out width,  out height);
        }
    }
    private static efl_ui_scrollbar_bar_size_get_delegate efl_ui_scrollbar_bar_size_get_static_delegate;


     private delegate void efl_ui_scrollbar_bar_position_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double posx,   out double posy);


     public delegate void efl_ui_scrollbar_bar_position_get_api_delegate(System.IntPtr obj,   out double posx,   out double posy);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate> efl_ui_scrollbar_bar_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate>(_Module, "efl_ui_scrollbar_bar_position_get");
     private static void bar_position_get(System.IntPtr obj, System.IntPtr pd,  out double posx,  out double posy)
    {
        Eina.Log.Debug("function efl_ui_scrollbar_bar_position_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    posx = default(double);        posy = default(double);                            
            try {
                ((Manager)wrapper).GetBarPosition( out posx,  out posy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out posx,  out posy);
        }
    }
    private static efl_ui_scrollbar_bar_position_get_delegate efl_ui_scrollbar_bar_position_get_static_delegate;


     private delegate void efl_ui_scrollbar_bar_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   double posx,   double posy);


     public delegate void efl_ui_scrollbar_bar_position_set_api_delegate(System.IntPtr obj,   double posx,   double posy);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate> efl_ui_scrollbar_bar_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate>(_Module, "efl_ui_scrollbar_bar_position_set");
     private static void bar_position_set(System.IntPtr obj, System.IntPtr pd,  double posx,  double posy)
    {
        Eina.Log.Debug("function efl_ui_scrollbar_bar_position_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((Manager)wrapper).SetBarPosition( posx,  posy);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  posx,  posy);
        }
    }
    private static efl_ui_scrollbar_bar_position_set_delegate efl_ui_scrollbar_bar_position_set_static_delegate;


     private delegate void efl_ui_scrollbar_bar_visibility_update_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_ui_scrollbar_bar_visibility_update_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_visibility_update_api_delegate> efl_ui_scrollbar_bar_visibility_update_ptr = new Efl.Eo.FunctionWrapper<efl_ui_scrollbar_bar_visibility_update_api_delegate>(_Module, "efl_ui_scrollbar_bar_visibility_update");
     private static void bar_visibility_update(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_scrollbar_bar_visibility_update was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Manager)wrapper).UpdateBarVisibility();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_ui_scrollbar_bar_visibility_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_scrollbar_bar_visibility_update_delegate efl_ui_scrollbar_bar_visibility_update_static_delegate;
}
} } } 
