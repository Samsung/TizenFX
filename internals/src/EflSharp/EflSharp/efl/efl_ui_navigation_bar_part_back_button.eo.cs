#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl Ui Navigation_Bar internal part back button class</summary>
[NavigationBarPartBackButtonNativeInherit]
public class NavigationBarPartBackButton : Efl.Ui.LayoutPart, Efl.Eo.IWrapper,Efl.IContent,Efl.IText,Efl.Gfx.IEntity,Efl.Ui.IClickable
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (NavigationBarPartBackButton))
                return Efl.Ui.NavigationBarPartBackButtonNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_navigation_bar_part_back_button_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public NavigationBarPartBackButton(Efl.Object parent= null
            ) :
        base(efl_ui_navigation_bar_part_back_button_class_get(), typeof(NavigationBarPartBackButton), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected NavigationBarPartBackButton(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected NavigationBarPartBackButton(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
private static object ContentChangedEvtKey = new object();
    /// <summary>Sent after the content is set or unset using the current content object.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.IContentContentChangedEvt_Args> ContentChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ContentChangedEvt_delegate)) {
                    eventHandlers.AddHandler(ContentChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_ContentChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ContentChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ContentChangedEvt.</summary>
    public void On_ContentChangedEvt(Efl.IContentContentChangedEvt_Args e)
    {
        EventHandler<Efl.IContentContentChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.IContentContentChangedEvt_Args>)eventHandlers[ContentChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ContentChangedEvt_delegate;
    private void on_ContentChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.IContentContentChangedEvt_Args args = new Efl.IContentContentChangedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.IEntityConcrete);
        try {
            On_ContentChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object VisibilityChangedEvtKey = new object();
    /// <summary>Object&apos;s visibility state changed, the event value is the new state.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Gfx.IEntityVisibilityChangedEvt_Args> VisibilityChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_VisibilityChangedEvt_delegate)) {
                    eventHandlers.AddHandler(VisibilityChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_VisibilityChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(VisibilityChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event VisibilityChangedEvt.</summary>
    public void On_VisibilityChangedEvt(Efl.Gfx.IEntityVisibilityChangedEvt_Args e)
    {
        EventHandler<Efl.Gfx.IEntityVisibilityChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Gfx.IEntityVisibilityChangedEvt_Args>)eventHandlers[VisibilityChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_VisibilityChangedEvt_delegate;
    private void on_VisibilityChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Gfx.IEntityVisibilityChangedEvt_Args args = new Efl.Gfx.IEntityVisibilityChangedEvt_Args();
      args.arg = evt.Info != IntPtr.Zero;
        try {
            On_VisibilityChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object PositionChangedEvtKey = new object();
    /// <summary>Object was moved, its position during the event is the new one.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Gfx.IEntityPositionChangedEvt_Args> PositionChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_PositionChangedEvt_delegate)) {
                    eventHandlers.AddHandler(PositionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_PositionChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(PositionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event PositionChangedEvt.</summary>
    public void On_PositionChangedEvt(Efl.Gfx.IEntityPositionChangedEvt_Args e)
    {
        EventHandler<Efl.Gfx.IEntityPositionChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Gfx.IEntityPositionChangedEvt_Args>)eventHandlers[PositionChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_PositionChangedEvt_delegate;
    private void on_PositionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Gfx.IEntityPositionChangedEvt_Args args = new Efl.Gfx.IEntityPositionChangedEvt_Args();
      args.arg =  evt.Info;;
        try {
            On_PositionChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SizeChangedEvtKey = new object();
    /// <summary>Object was resized, its size during the event is the new one.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.Gfx.IEntitySizeChangedEvt_Args> SizeChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SizeChangedEvt_delegate)) {
                    eventHandlers.AddHandler(SizeChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_SizeChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SizeChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SizeChangedEvt.</summary>
    public void On_SizeChangedEvt(Efl.Gfx.IEntitySizeChangedEvt_Args e)
    {
        EventHandler<Efl.Gfx.IEntitySizeChangedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Gfx.IEntitySizeChangedEvt_Args>)eventHandlers[SizeChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SizeChangedEvt_delegate;
    private void on_SizeChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Gfx.IEntitySizeChangedEvt_Args args = new Efl.Gfx.IEntitySizeChangedEvt_Args();
      args.arg =  evt.Info;;
        try {
            On_SizeChangedEvt(args);
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
        evt_ContentChangedEvt_delegate = new Efl.EventCb(on_ContentChangedEvt_NativeCallback);
        evt_VisibilityChangedEvt_delegate = new Efl.EventCb(on_VisibilityChangedEvt_NativeCallback);
        evt_PositionChangedEvt_delegate = new Efl.EventCb(on_PositionChangedEvt_NativeCallback);
        evt_SizeChangedEvt_delegate = new Efl.EventCb(on_SizeChangedEvt_NativeCallback);
        evt_ClickedEvt_delegate = new Efl.EventCb(on_ClickedEvt_NativeCallback);
        evt_ClickedDoubleEvt_delegate = new Efl.EventCb(on_ClickedDoubleEvt_NativeCallback);
        evt_ClickedTripleEvt_delegate = new Efl.EventCb(on_ClickedTripleEvt_NativeCallback);
        evt_ClickedRightEvt_delegate = new Efl.EventCb(on_ClickedRightEvt_NativeCallback);
        evt_PressedEvt_delegate = new Efl.EventCb(on_PressedEvt_NativeCallback);
        evt_UnpressedEvt_delegate = new Efl.EventCb(on_UnpressedEvt_NativeCallback);
        evt_LongpressedEvt_delegate = new Efl.EventCb(on_LongpressedEvt_NativeCallback);
        evt_RepeatedEvt_delegate = new Efl.EventCb(on_RepeatedEvt_NativeCallback);
    }
    /// <summary>Swallowed sub-object contained in this object.
    /// (Since EFL 1.22)</summary>
    /// <returns>The object to swallow.</returns>
    virtual public Efl.Gfx.IEntity GetContent() {
         var _ret_var = Efl.IContentNativeInherit.efl_content_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Swallowed sub-object contained in this object.
    /// (Since EFL 1.22)</summary>
    /// <param name="content">The object to swallow.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool SetContent( Efl.Gfx.IEntity content) {
                                 var _ret_var = Efl.IContentNativeInherit.efl_content_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), content);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Unswallow the object in the current container and return it.
    /// (Since EFL 1.22)</summary>
    /// <returns>Unswallowed object</returns>
    virtual public Efl.Gfx.IEntity UnsetContent() {
         var _ret_var = Efl.IContentNativeInherit.efl_content_unset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Retrieves the text string currently being displayed by the given text object.
    /// Do not free() the return value.
    /// 
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <returns>Text string to display on it.</returns>
    virtual public System.String GetText() {
         var _ret_var = Efl.ITextNativeInherit.efl_text_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the text string to be displayed by the given text object.
    /// See also <see cref="Efl.IText.GetText"/>.
    /// (Since EFL 1.22)</summary>
    /// <param name="text">Text string to display on it.</param>
    /// <returns></returns>
    virtual public void SetText( System.String text) {
                                 Efl.ITextNativeInherit.efl_text_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), text);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves the position of the given canvas object.
    /// (Since EFL 1.22)</summary>
    /// <returns>A 2D coordinate in pixel units.</returns>
    virtual public Eina.Position2D GetPosition() {
         var _ret_var = Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.
    /// (Since EFL 1.22)</summary>
    /// <param name="pos">A 2D coordinate in pixel units.</param>
    /// <returns></returns>
    virtual public void SetPosition( Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves the (rectangular) size of the given Evas object.
    /// (Since EFL 1.22)</summary>
    /// <returns>A 2D size in pixel units.</returns>
    virtual public Eina.Size2D GetSize() {
         var _ret_var = Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Changes the size of the given object.
    /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="Efl.Gfx.IHint"/> instead, when manipulating widgets.
    /// (Since EFL 1.22)</summary>
    /// <param name="size">A 2D size in pixel units.</param>
    /// <returns></returns>
    virtual public void SetSize( Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Rectangular geometry that combines both position and size.
    /// (Since EFL 1.22)</summary>
    /// <returns>The X,Y position and W,H size, in pixels.</returns>
    virtual public Eina.Rect GetGeometry() {
         var _ret_var = Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_geometry_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Rectangular geometry that combines both position and size.
    /// (Since EFL 1.22)</summary>
    /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
    /// <returns></returns>
    virtual public void SetGeometry( Eina.Rect rect) {
         Eina.Rect.NativeStruct _in_rect = rect;
                        Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_geometry_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_rect);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Retrieves whether or not the given canvas object is visible.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
    virtual public bool GetVisible() {
         var _ret_var = Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_visible_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Shows or hides this object.
    /// (Since EFL 1.22)</summary>
    /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetVisible( bool v) {
                                 Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_visible_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), v);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Gets an object&apos;s scaling factor.
    /// (Since EFL 1.22)</summary>
    /// <returns>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</returns>
    virtual public double GetScale() {
         var _ret_var = Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_scale_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Sets the scaling factor of an object.
    /// (Since EFL 1.22)</summary>
    /// <param name="scale">The scaling factor (the default value is 0.0, meaning individual scaling is not set)</param>
    /// <returns></returns>
    virtual public void SetScale( double scale) {
                                 Efl.Gfx.IEntityNativeInherit.efl_gfx_entity_scale_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), scale);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Swallowed sub-object contained in this object.
/// (Since EFL 1.22)</summary>
/// <value>The object to swallow.</value>
    public Efl.Gfx.IEntity Content {
        get { return GetContent(); }
        set { SetContent( value); }
    }
    /// <summary>The 2D position of a canvas object.
/// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).
/// (Since EFL 1.22)</summary>
/// <value>A 2D coordinate in pixel units.</value>
    public Eina.Position2D Position {
        get { return GetPosition(); }
        set { SetPosition( value); }
    }
    /// <summary>The 2D size of a canvas object.
/// (Since EFL 1.22)</summary>
/// <value>A 2D size in pixel units.</value>
    public Eina.Size2D Size {
        get { return GetSize(); }
        set { SetSize( value); }
    }
    /// <summary>Rectangular geometry that combines both position and size.
/// (Since EFL 1.22)</summary>
/// <value>The X,Y position and W,H size, in pixels.</value>
    public Eina.Rect Geometry {
        get { return GetGeometry(); }
        set { SetGeometry( value); }
    }
    /// <summary>The visibility of a canvas object.
/// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="Efl.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
/// 
/// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...
/// (Since EFL 1.22)</summary>
/// <value><c>true</c> if to make the object visible, <c>false</c> otherwise</value>
    public bool Visible {
        get { return GetVisible(); }
        set { SetVisible( value); }
    }
    /// <summary>The scaling factor of an object.
/// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, than the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
/// 
/// Warning: In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.
/// (Since EFL 1.22)</summary>
/// <value>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</value>
    public double Scale {
        get { return GetScale(); }
        set { SetScale( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.NavigationBarPartBackButton.efl_ui_navigation_bar_part_back_button_class_get();
    }
}
public class NavigationBarPartBackButtonNativeInherit : Efl.Ui.LayoutPartNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_content_get_static_delegate == null)
            efl_content_get_static_delegate = new efl_content_get_delegate(content_get);
        if (methods.FirstOrDefault(m => m.Name == "GetContent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_content_get_static_delegate)});
        if (efl_content_set_static_delegate == null)
            efl_content_set_static_delegate = new efl_content_set_delegate(content_set);
        if (methods.FirstOrDefault(m => m.Name == "SetContent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_content_set_static_delegate)});
        if (efl_content_unset_static_delegate == null)
            efl_content_unset_static_delegate = new efl_content_unset_delegate(content_unset);
        if (methods.FirstOrDefault(m => m.Name == "UnsetContent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_content_unset_static_delegate)});
        if (efl_text_get_static_delegate == null)
            efl_text_get_static_delegate = new efl_text_get_delegate(text_get);
        if (methods.FirstOrDefault(m => m.Name == "GetText") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_get"), func = Marshal.GetFunctionPointerForDelegate(efl_text_get_static_delegate)});
        if (efl_text_set_static_delegate == null)
            efl_text_set_static_delegate = new efl_text_set_delegate(text_set);
        if (methods.FirstOrDefault(m => m.Name == "SetText") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_text_set"), func = Marshal.GetFunctionPointerForDelegate(efl_text_set_static_delegate)});
        if (efl_gfx_entity_position_get_static_delegate == null)
            efl_gfx_entity_position_get_static_delegate = new efl_gfx_entity_position_get_delegate(position_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_get_static_delegate)});
        if (efl_gfx_entity_position_set_static_delegate == null)
            efl_gfx_entity_position_set_static_delegate = new efl_gfx_entity_position_set_delegate(position_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_set_static_delegate)});
        if (efl_gfx_entity_size_get_static_delegate == null)
            efl_gfx_entity_size_get_static_delegate = new efl_gfx_entity_size_get_delegate(size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_get_static_delegate)});
        if (efl_gfx_entity_size_set_static_delegate == null)
            efl_gfx_entity_size_set_static_delegate = new efl_gfx_entity_size_set_delegate(size_set);
        if (methods.FirstOrDefault(m => m.Name == "SetSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_set_static_delegate)});
        if (efl_gfx_entity_geometry_get_static_delegate == null)
            efl_gfx_entity_geometry_get_static_delegate = new efl_gfx_entity_geometry_get_delegate(geometry_get);
        if (methods.FirstOrDefault(m => m.Name == "GetGeometry") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_get_static_delegate)});
        if (efl_gfx_entity_geometry_set_static_delegate == null)
            efl_gfx_entity_geometry_set_static_delegate = new efl_gfx_entity_geometry_set_delegate(geometry_set);
        if (methods.FirstOrDefault(m => m.Name == "SetGeometry") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_geometry_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_set_static_delegate)});
        if (efl_gfx_entity_visible_get_static_delegate == null)
            efl_gfx_entity_visible_get_static_delegate = new efl_gfx_entity_visible_get_delegate(visible_get);
        if (methods.FirstOrDefault(m => m.Name == "GetVisible") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_get_static_delegate)});
        if (efl_gfx_entity_visible_set_static_delegate == null)
            efl_gfx_entity_visible_set_static_delegate = new efl_gfx_entity_visible_set_delegate(visible_set);
        if (methods.FirstOrDefault(m => m.Name == "SetVisible") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_visible_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_set_static_delegate)});
        if (efl_gfx_entity_scale_get_static_delegate == null)
            efl_gfx_entity_scale_get_static_delegate = new efl_gfx_entity_scale_get_delegate(scale_get);
        if (methods.FirstOrDefault(m => m.Name == "GetScale") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_get_static_delegate)});
        if (efl_gfx_entity_scale_set_static_delegate == null)
            efl_gfx_entity_scale_set_static_delegate = new efl_gfx_entity_scale_set_delegate(scale_set);
        if (methods.FirstOrDefault(m => m.Name == "SetScale") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_entity_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.NavigationBarPartBackButton.efl_ui_navigation_bar_part_back_button_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.NavigationBarPartBackButton.efl_ui_navigation_bar_part_back_button_class_get();
    }


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.IEntity efl_content_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.IEntity efl_content_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_content_get_api_delegate> efl_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_content_get_api_delegate>(_Module, "efl_content_get");
     private static Efl.Gfx.IEntity content_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_content_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
            try {
                _ret_var = ((NavigationBarPartBackButton)wrapper).GetContent();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_content_get_delegate efl_content_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity content);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity content);
     public static Efl.Eo.FunctionWrapper<efl_content_set_api_delegate> efl_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_content_set_api_delegate>(_Module, "efl_content_set");
     private static bool content_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IEntity content)
    {
        Eina.Log.Debug("function efl_content_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((NavigationBarPartBackButton)wrapper).SetContent( content);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  content);
        }
    }
    private static efl_content_set_delegate efl_content_set_static_delegate;


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.IEntity efl_content_unset_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.IEntity efl_content_unset_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate> efl_content_unset_ptr = new Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate>(_Module, "efl_content_unset");
     private static Efl.Gfx.IEntity content_unset(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_content_unset was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
            try {
                _ret_var = ((NavigationBarPartBackButton)wrapper).UnsetContent();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_content_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_content_unset_delegate efl_content_unset_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_text_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_text_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_text_get_api_delegate> efl_text_get_ptr = new Efl.Eo.FunctionWrapper<efl_text_get_api_delegate>(_Module, "efl_text_get");
     private static System.String text_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_text_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((NavigationBarPartBackButton)wrapper).GetText();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_text_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_text_get_delegate efl_text_get_static_delegate;


     private delegate void efl_text_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text);


     public delegate void efl_text_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String text);
     public static Efl.Eo.FunctionWrapper<efl_text_set_api_delegate> efl_text_set_ptr = new Efl.Eo.FunctionWrapper<efl_text_set_api_delegate>(_Module, "efl_text_set");
     private static void text_set(System.IntPtr obj, System.IntPtr pd,  System.String text)
    {
        Eina.Log.Debug("function efl_text_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((NavigationBarPartBackButton)wrapper).SetText( text);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_text_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  text);
        }
    }
    private static efl_text_set_delegate efl_text_set_static_delegate;


     private delegate Eina.Position2D.NativeStruct efl_gfx_entity_position_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Position2D.NativeStruct efl_gfx_entity_position_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_position_get_api_delegate> efl_gfx_entity_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_position_get_api_delegate>(_Module, "efl_gfx_entity_position_get");
     private static Eina.Position2D.NativeStruct position_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_entity_position_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Position2D _ret_var = default(Eina.Position2D);
            try {
                _ret_var = ((NavigationBarPartBackButton)wrapper).GetPosition();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_entity_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_entity_position_get_delegate efl_gfx_entity_position_get_static_delegate;


     private delegate void efl_gfx_entity_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D.NativeStruct pos);


     public delegate void efl_gfx_entity_position_set_api_delegate(System.IntPtr obj,   Eina.Position2D.NativeStruct pos);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_position_set_api_delegate> efl_gfx_entity_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_position_set_api_delegate>(_Module, "efl_gfx_entity_position_set");
     private static void position_set(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos)
    {
        Eina.Log.Debug("function efl_gfx_entity_position_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Position2D _in_pos = pos;
                            
            try {
                ((NavigationBarPartBackButton)wrapper).SetPosition( _in_pos);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_entity_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
        }
    }
    private static efl_gfx_entity_position_set_delegate efl_gfx_entity_position_set_static_delegate;


     private delegate Eina.Size2D.NativeStruct efl_gfx_entity_size_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Size2D.NativeStruct efl_gfx_entity_size_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_size_get_api_delegate> efl_gfx_entity_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_size_get_api_delegate>(_Module, "efl_gfx_entity_size_get");
     private static Eina.Size2D.NativeStruct size_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_entity_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Size2D _ret_var = default(Eina.Size2D);
            try {
                _ret_var = ((NavigationBarPartBackButton)wrapper).GetSize();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_entity_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_entity_size_get_delegate efl_gfx_entity_size_get_static_delegate;


     private delegate void efl_gfx_entity_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D.NativeStruct size);


     public delegate void efl_gfx_entity_size_set_api_delegate(System.IntPtr obj,   Eina.Size2D.NativeStruct size);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_size_set_api_delegate> efl_gfx_entity_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_size_set_api_delegate>(_Module, "efl_gfx_entity_size_set");
     private static void size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct size)
    {
        Eina.Log.Debug("function efl_gfx_entity_size_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Size2D _in_size = size;
                            
            try {
                ((NavigationBarPartBackButton)wrapper).SetSize( _in_size);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_entity_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
        }
    }
    private static efl_gfx_entity_size_set_delegate efl_gfx_entity_size_set_static_delegate;


     private delegate Eina.Rect.NativeStruct efl_gfx_entity_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Eina.Rect.NativeStruct efl_gfx_entity_geometry_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate> efl_gfx_entity_geometry_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate>(_Module, "efl_gfx_entity_geometry_get");
     private static Eina.Rect.NativeStruct geometry_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_entity_geometry_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Rect _ret_var = default(Eina.Rect);
            try {
                _ret_var = ((NavigationBarPartBackButton)wrapper).GetGeometry();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_entity_geometry_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_entity_geometry_get_delegate efl_gfx_entity_geometry_get_static_delegate;


     private delegate void efl_gfx_entity_geometry_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect.NativeStruct rect);


     public delegate void efl_gfx_entity_geometry_set_api_delegate(System.IntPtr obj,   Eina.Rect.NativeStruct rect);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate> efl_gfx_entity_geometry_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate>(_Module, "efl_gfx_entity_geometry_set");
     private static void geometry_set(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct rect)
    {
        Eina.Log.Debug("function efl_gfx_entity_geometry_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                    Eina.Rect _in_rect = rect;
                            
            try {
                ((NavigationBarPartBackButton)wrapper).SetGeometry( _in_rect);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_entity_geometry_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rect);
        }
    }
    private static efl_gfx_entity_geometry_set_delegate efl_gfx_entity_geometry_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_entity_visible_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_gfx_entity_visible_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate> efl_gfx_entity_visible_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate>(_Module, "efl_gfx_entity_visible_get");
     private static bool visible_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_entity_visible_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((NavigationBarPartBackButton)wrapper).GetVisible();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_entity_visible_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_entity_visible_get_delegate efl_gfx_entity_visible_get_static_delegate;


     private delegate void efl_gfx_entity_visible_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool v);


     public delegate void efl_gfx_entity_visible_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool v);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate> efl_gfx_entity_visible_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate>(_Module, "efl_gfx_entity_visible_set");
     private static void visible_set(System.IntPtr obj, System.IntPtr pd,  bool v)
    {
        Eina.Log.Debug("function efl_gfx_entity_visible_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((NavigationBarPartBackButton)wrapper).SetVisible( v);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_entity_visible_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  v);
        }
    }
    private static efl_gfx_entity_visible_set_delegate efl_gfx_entity_visible_set_static_delegate;


     private delegate double efl_gfx_entity_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_gfx_entity_scale_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate> efl_gfx_entity_scale_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate>(_Module, "efl_gfx_entity_scale_get");
     private static double scale_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_gfx_entity_scale_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((NavigationBarPartBackButton)wrapper).GetScale();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_gfx_entity_scale_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_gfx_entity_scale_get_delegate efl_gfx_entity_scale_get_static_delegate;


     private delegate void efl_gfx_entity_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,   double scale);


     public delegate void efl_gfx_entity_scale_set_api_delegate(System.IntPtr obj,   double scale);
     public static Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate> efl_gfx_entity_scale_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate>(_Module, "efl_gfx_entity_scale_set");
     private static void scale_set(System.IntPtr obj, System.IntPtr pd,  double scale)
    {
        Eina.Log.Debug("function efl_gfx_entity_scale_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((NavigationBarPartBackButton)wrapper).SetScale( scale);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_gfx_entity_scale_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale);
        }
    }
    private static efl_gfx_entity_scale_set_delegate efl_gfx_entity_scale_set_static_delegate;
}
} } 
