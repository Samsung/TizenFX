#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Item abstract class for pack widget. All item have to be inherited from this class.</summary>
[ItemNativeInherit]
public abstract class Item : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.Ui.IClickable,Efl.Ui.ISelectable
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Item))
                return Efl.Ui.ItemNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_item_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Item(Efl.Object parent
            , System.String style = null) :
        base(efl_ui_item_class_get(), typeof(Item), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Item(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    [Efl.Eo.PrivateNativeClass]
    private class ItemRealized : Item
    {
        private ItemRealized(IntPtr ptr) : base(ptr)
        {
        }
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Item(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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

private static object ItemSelectedEvtKey = new object();
    /// <summary>Called when selected</summary>
    public event EventHandler<Efl.Ui.ISelectableItemSelectedEvt_Args> ItemSelectedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ITEM_SELECTED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ItemSelectedEvt_delegate)) {
                    eventHandlers.AddHandler(ItemSelectedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ITEM_SELECTED";
                if (RemoveNativeEventHandler(key, this.evt_ItemSelectedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ItemSelectedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ItemSelectedEvt.</summary>
    public void On_ItemSelectedEvt(Efl.Ui.ISelectableItemSelectedEvt_Args e)
    {
        EventHandler<Efl.Ui.ISelectableItemSelectedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.ISelectableItemSelectedEvt_Args>)eventHandlers[ItemSelectedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ItemSelectedEvt_delegate;
    private void on_ItemSelectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.ISelectableItemSelectedEvt_Args args = new Efl.Ui.ISelectableItemSelectedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_ItemSelectedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ItemUnselectedEvtKey = new object();
    /// <summary>Called when no longer selected</summary>
    public event EventHandler<Efl.Ui.ISelectableItemUnselectedEvt_Args> ItemUnselectedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ITEM_UNSELECTED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ItemUnselectedEvt_delegate)) {
                    eventHandlers.AddHandler(ItemUnselectedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_ITEM_UNSELECTED";
                if (RemoveNativeEventHandler(key, this.evt_ItemUnselectedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ItemUnselectedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ItemUnselectedEvt.</summary>
    public void On_ItemUnselectedEvt(Efl.Ui.ISelectableItemUnselectedEvt_Args e)
    {
        EventHandler<Efl.Ui.ISelectableItemUnselectedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.Ui.ISelectableItemUnselectedEvt_Args>)eventHandlers[ItemUnselectedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ItemUnselectedEvt_delegate;
    private void on_ItemUnselectedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.Ui.ISelectableItemUnselectedEvt_Args args = new Efl.Ui.ISelectableItemUnselectedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Object);
        try {
            On_ItemUnselectedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SelectionPasteEvtKey = new object();
    /// <summary>Called when selection is pasted</summary>
    public event EventHandler SelectionPasteEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_PASTE";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SelectionPasteEvt_delegate)) {
                    eventHandlers.AddHandler(SelectionPasteEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_PASTE";
                if (RemoveNativeEventHandler(key, this.evt_SelectionPasteEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SelectionPasteEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SelectionPasteEvt.</summary>
    public void On_SelectionPasteEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SelectionPasteEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SelectionPasteEvt_delegate;
    private void on_SelectionPasteEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SelectionPasteEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SelectionCopyEvtKey = new object();
    /// <summary>Called when selection is copied</summary>
    public event EventHandler SelectionCopyEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_COPY";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SelectionCopyEvt_delegate)) {
                    eventHandlers.AddHandler(SelectionCopyEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_COPY";
                if (RemoveNativeEventHandler(key, this.evt_SelectionCopyEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SelectionCopyEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SelectionCopyEvt.</summary>
    public void On_SelectionCopyEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SelectionCopyEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SelectionCopyEvt_delegate;
    private void on_SelectionCopyEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SelectionCopyEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SelectionCutEvtKey = new object();
    /// <summary>Called when selection is cut</summary>
    public event EventHandler SelectionCutEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_CUT";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SelectionCutEvt_delegate)) {
                    eventHandlers.AddHandler(SelectionCutEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_CUT";
                if (RemoveNativeEventHandler(key, this.evt_SelectionCutEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SelectionCutEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SelectionCutEvt.</summary>
    public void On_SelectionCutEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SelectionCutEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SelectionCutEvt_delegate;
    private void on_SelectionCutEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SelectionCutEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SelectionStartEvtKey = new object();
    /// <summary>Called at selection start</summary>
    public event EventHandler SelectionStartEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_START";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SelectionStartEvt_delegate)) {
                    eventHandlers.AddHandler(SelectionStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_START";
                if (RemoveNativeEventHandler(key, this.evt_SelectionStartEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SelectionStartEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SelectionStartEvt.</summary>
    public void On_SelectionStartEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SelectionStartEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SelectionStartEvt_delegate;
    private void on_SelectionStartEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SelectionStartEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SelectionChangedEvtKey = new object();
    /// <summary>Called when selection is changed</summary>
    public event EventHandler SelectionChangedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_CHANGED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SelectionChangedEvt_delegate)) {
                    eventHandlers.AddHandler(SelectionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_CHANGED";
                if (RemoveNativeEventHandler(key, this.evt_SelectionChangedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SelectionChangedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SelectionChangedEvt.</summary>
    public void On_SelectionChangedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SelectionChangedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SelectionChangedEvt_delegate;
    private void on_SelectionChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SelectionChangedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object SelectionClearedEvtKey = new object();
    /// <summary>Called when selection is cleared</summary>
    public event EventHandler SelectionClearedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_CLEARED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_SelectionClearedEvt_delegate)) {
                    eventHandlers.AddHandler(SelectionClearedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_UI_EVENT_SELECTION_CLEARED";
                if (RemoveNativeEventHandler(key, this.evt_SelectionClearedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(SelectionClearedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event SelectionClearedEvt.</summary>
    public void On_SelectionClearedEvt(EventArgs e)
    {
        EventHandler evt;
        lock (eventLock) {
        evt = (EventHandler)eventHandlers[SelectionClearedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_SelectionClearedEvt_delegate;
    private void on_SelectionClearedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        EventArgs args = EventArgs.Empty;
        try {
            On_SelectionClearedEvt(args);
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
        evt_ItemSelectedEvt_delegate = new Efl.EventCb(on_ItemSelectedEvt_NativeCallback);
        evt_ItemUnselectedEvt_delegate = new Efl.EventCb(on_ItemUnselectedEvt_NativeCallback);
        evt_SelectionPasteEvt_delegate = new Efl.EventCb(on_SelectionPasteEvt_NativeCallback);
        evt_SelectionCopyEvt_delegate = new Efl.EventCb(on_SelectionCopyEvt_NativeCallback);
        evt_SelectionCutEvt_delegate = new Efl.EventCb(on_SelectionCutEvt_NativeCallback);
        evt_SelectionStartEvt_delegate = new Efl.EventCb(on_SelectionStartEvt_NativeCallback);
        evt_SelectionChangedEvt_delegate = new Efl.EventCb(on_SelectionChangedEvt_NativeCallback);
        evt_SelectionClearedEvt_delegate = new Efl.EventCb(on_SelectionClearedEvt_NativeCallback);
    }
    /// <summary>index number of item from their parent object.</summary>
    /// <returns></returns>
    virtual public int GetIndex() {
         var _ret_var = Efl.Ui.ItemNativeInherit.efl_ui_item_index_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Select property for item object. Item can be selected by user mouse/key input also</summary>
    /// <returns></returns>
    virtual public bool GetSelected() {
         var _ret_var = Efl.Ui.ItemNativeInherit.efl_ui_item_selected_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Select property for item object. Item can be selected by user mouse/key input also</summary>
    /// <param name="select"></param>
    /// <returns></returns>
    virtual public void SetSelected( bool select) {
                                 Efl.Ui.ItemNativeInherit.efl_ui_item_selected_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), select);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>index number of item from their parent object.</summary>
/// <value></value>
    public int Index {
        get { return GetIndex(); }
    }
    /// <summary>Select property for item object. Item can be selected by user mouse/key input also</summary>
/// <value></value>
    public bool Selected {
        get { return GetSelected(); }
        set { SetSelected( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Item.efl_ui_item_class_get();
    }
}
public class ItemNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_item_index_get_static_delegate == null)
            efl_ui_item_index_get_static_delegate = new efl_ui_item_index_get_delegate(index_get);
        if (methods.FirstOrDefault(m => m.Name == "GetIndex") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_item_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_index_get_static_delegate)});
        if (efl_ui_item_selected_get_static_delegate == null)
            efl_ui_item_selected_get_static_delegate = new efl_ui_item_selected_get_delegate(selected_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSelected") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_item_selected_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_selected_get_static_delegate)});
        if (efl_ui_item_selected_set_static_delegate == null)
            efl_ui_item_selected_set_static_delegate = new efl_ui_item_selected_set_delegate(selected_set);
        if (methods.FirstOrDefault(m => m.Name == "SetSelected") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_item_selected_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_selected_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.Item.efl_ui_item_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Item.efl_ui_item_class_get();
    }


     private delegate int efl_ui_item_index_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate int efl_ui_item_index_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_item_index_get_api_delegate> efl_ui_item_index_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_item_index_get_api_delegate>(_Module, "efl_ui_item_index_get");
     private static int index_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_item_index_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        int _ret_var = default(int);
            try {
                _ret_var = ((Item)wrapper).GetIndex();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_item_index_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_item_index_get_delegate efl_ui_item_index_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_item_selected_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_item_selected_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_item_selected_get_api_delegate> efl_ui_item_selected_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_item_selected_get_api_delegate>(_Module, "efl_ui_item_selected_get");
     private static bool selected_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_item_selected_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Item)wrapper).GetSelected();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_item_selected_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_item_selected_get_delegate efl_ui_item_selected_get_static_delegate;


     private delegate void efl_ui_item_selected_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool select);


     public delegate void efl_ui_item_selected_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool select);
     public static Efl.Eo.FunctionWrapper<efl_ui_item_selected_set_api_delegate> efl_ui_item_selected_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_item_selected_set_api_delegate>(_Module, "efl_ui_item_selected_set");
     private static void selected_set(System.IntPtr obj, System.IntPtr pd,  bool select)
    {
        Eina.Log.Debug("function efl_ui_item_selected_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Item)wrapper).SetSelected( select);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_item_selected_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  select);
        }
    }
    private static efl_ui_item_selected_set_delegate efl_ui_item_selected_set_static_delegate;
}
} } 
