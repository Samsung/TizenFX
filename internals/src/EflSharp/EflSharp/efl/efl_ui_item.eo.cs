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

/// <summary>Selectable Item abstraction.
/// This class serves as the basis to create widgets acting as selectable items inside containers like <see cref="Efl.Ui.List"/> or <see cref="Efl.Ui.Grid"/>, for example.
/// 
/// <see cref="Efl.Ui.Item"/> provides user interaction through the <see cref="Efl.Input.IClickable"/> mixin. Items can be pressed, long-pressed, etc, and appropriate events are generated. <see cref="Efl.Ui.Item"/> also implements the <see cref="Efl.Ui.ISelectable"/> interface, meaning that &quot;selected&quot; and &quot;unselected&quot; events are automatically generated.
/// 
/// Classes inheriting from this one only need to deal with the visual representation of the widget. See for example <see cref="Efl.Ui.GridDefaultItem"/> and <see cref="Efl.Ui.ListDefaultItem"/>.
/// 
/// Some events are converted to edje signals so the theme can react to them: <see cref="Efl.Input.IClickable.PressedEvent"/> -&gt; &quot;efl,state,pressed&quot;, <see cref="Efl.Input.IClickable.UnpressedEvent"/> -&gt; &quot;efl,state,unpressed&quot;, <see cref="Efl.Ui.ISelectable.SelectedChangedEvent"/> (true) -&gt; &quot;efl,state,selected&quot;, <see cref="Efl.Ui.ISelectable.SelectedChangedEvent"/> (false) -&gt; &quot;efl,state,unselected&quot;.
/// 
/// Item grouping inside containers is handled through the <see cref="Efl.Ui.GroupItem"/> class.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Item.NativeMethods]
[Efl.Eo.BindingEntity]
public abstract class Item : Efl.Ui.LayoutBase, Efl.Input.IClickable, Efl.Ui.ISelectable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Item))
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
        efl_ui_item_class_get();
    /// <summary>Initializes a new instance of the <see cref="Item"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Item(Efl.Object parent
            , System.String style = null) : base(efl_ui_item_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Item(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Item"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Item(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [Efl.Eo.PrivateNativeClass]
    private class ItemRealized : Item
    {
        private ItemRealized(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Item"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Item(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when object is in sequence pressed and unpressed by the primary button</summary>
    /// <value><see cref="Efl.Input.ClickableClickedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableClickedEventArgs> ClickedEvent
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
                        Efl.Input.ClickableClickedEventArgs args = new Efl.Input.ClickableClickedEventArgs();
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

                string key = "_EFL_INPUT_EVENT_CLICKED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_CLICKED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ClickedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnClickedEvent(Efl.Input.ClickableClickedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_CLICKED";
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
    /// <summary>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</summary>
    /// <value><see cref="Efl.Input.ClickableClickedAnyEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableClickedAnyEventArgs> ClickedAnyEvent
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
                        Efl.Input.ClickableClickedAnyEventArgs args = new Efl.Input.ClickableClickedAnyEventArgs();
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

                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ClickedAnyEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnClickedAnyEvent(Efl.Input.ClickableClickedAnyEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_CLICKED_ANY";
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
    /// <summary>Called when the object is pressed, event_info is the button that got pressed</summary>
    /// <value><see cref="Efl.Input.ClickablePressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickablePressedEventArgs> PressedEvent
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
                        Efl.Input.ClickablePressedEventArgs args = new Efl.Input.ClickablePressedEventArgs();
                        args.arg = Marshal.ReadInt32(evt.Info);
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

                string key = "_EFL_INPUT_EVENT_PRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_PRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnPressedEvent(Efl.Input.ClickablePressedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_PRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when the object is no longer pressed, event_info is the button that got pressed</summary>
    /// <value><see cref="Efl.Input.ClickableUnpressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableUnpressedEventArgs> UnpressedEvent
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
                        Efl.Input.ClickableUnpressedEventArgs args = new Efl.Input.ClickableUnpressedEventArgs();
                        args.arg = Marshal.ReadInt32(evt.Info);
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

                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event UnpressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnUnpressedEvent(Efl.Input.ClickableUnpressedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_UNPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when the object receives a long press, event_info is the button that got pressed</summary>
    /// <value><see cref="Efl.Input.ClickableLongpressedEventArgs"/></value>
    public event EventHandler<Efl.Input.ClickableLongpressedEventArgs> LongpressedEvent
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
                        Efl.Input.ClickableLongpressedEventArgs args = new Efl.Input.ClickableLongpressedEventArgs();
                        args.arg = Marshal.ReadInt32(evt.Info);
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

                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event LongpressedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLongpressedEvent(Efl.Input.ClickableLongpressedEventArgs e)
    {
        var key = "_EFL_INPUT_EVENT_LONGPRESSED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Called when the selected state has changed.</summary>
    /// <value><see cref="Efl.Ui.SelectableSelectedChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.SelectableSelectedChangedEventArgs> SelectedChangedEvent
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
                        Efl.Ui.SelectableSelectedChangedEventArgs args = new Efl.Ui.SelectableSelectedChangedEventArgs();
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

                string key = "_EFL_UI_EVENT_SELECTED_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_EVENT_SELECTED_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event SelectedChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSelectedChangedEvent(Efl.Ui.SelectableSelectedChangedEventArgs e)
    {
        var key = "_EFL_UI_EVENT_SELECTED_CHANGED";
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
    /// <summary>The index of this item inside its container.
    /// The container must be set through the <see cref="Efl.Ui.Item.Container"/> property.</summary>
    /// <returns>The index where to find this item in its <see cref="Efl.Ui.Item.Container"/>.</returns>
    public virtual int GetIndex() {
         var _ret_var = Efl.Ui.Item.NativeMethods.efl_ui_item_index_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The container this object is part of.
    /// You should never use this property directly, the container will set it when the item is added. Unsetting this while the item is packed inside a container does not remove the item from the container.</summary>
    /// <returns>The container this item is in.</returns>
    public virtual Efl.Ui.Widget GetContainer() {
         var _ret_var = Efl.Ui.Item.NativeMethods.efl_ui_item_container_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The container this object is part of.
    /// You should never use this property directly, the container will set it when the item is added. Unsetting this while the item is packed inside a container does not remove the item from the container.</summary>
    /// <param name="container">The container this item is in.</param>
    public virtual void SetContainer(Efl.Ui.Widget container) {
                                 Efl.Ui.Item.NativeMethods.efl_ui_item_container_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),container);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The parent of the item.
    /// This property expresses a tree structure of items. If the parent is <c>NULL</c> the item is added to the root level of the content. The item parent can only be set once. When the object is invalidated, the item parent is set to <c>NULL</c> and still cannot be reset.</summary>
    public virtual Efl.Ui.Item GetItemParent() {
         var _ret_var = Efl.Ui.Item.NativeMethods.efl_ui_item_parent_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The parent of the item.
    /// This property expresses a tree structure of items. If the parent is <c>NULL</c> the item is added to the root level of the content. The item parent can only be set once. When the object is invalidated, the item parent is set to <c>NULL</c> and still cannot be reset.</summary>
    public virtual void SetItemParent(Efl.Ui.Item parent) {
                                 Efl.Ui.Item.NativeMethods.efl_ui_item_parent_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),parent);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This returns true if the given object is currently in event emission</summary>
    public virtual bool GetInteraction() {
         var _ret_var = Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_interaction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Change internal states that a button got pressed.
    /// When the button is already pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    protected virtual void Press(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_press_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Change internal states that a button got unpressed.
    /// When the button is not pressed, this is silently ignored.</summary>
    /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
    protected virtual void Unpress(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_unpress_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts the internal state after a press call.
    /// This will stop the timer for longpress and set the state of the clickable mixin back into the unpressed state.</summary>
    protected virtual void ResetButtonState(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_button_state_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This aborts ongoing longpress event.
    /// That is, this will stop the timer for longpress.</summary>
    protected virtual void LongpressAbort(uint button) {
                                 Efl.Input.ClickableConcrete.NativeMethods.efl_input_clickable_longpress_abort_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The selected state of this object
    /// A change to this property emits the changed event.</summary>
    /// <returns>The selected state of this object.</returns>
    public virtual bool GetSelected() {
         var _ret_var = Efl.Ui.SelectableConcrete.NativeMethods.efl_ui_selectable_selected_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The selected state of this object
    /// A change to this property emits the changed event.</summary>
    /// <param name="selected">The selected state of this object.</param>
    public virtual void SetSelected(bool selected) {
                                 Efl.Ui.SelectableConcrete.NativeMethods.efl_ui_selectable_selected_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),selected);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The index of this item inside its container.
    /// The container must be set through the <see cref="Efl.Ui.Item.Container"/> property.</summary>
    /// <value>The index where to find this item in its <see cref="Efl.Ui.Item.Container"/>.</value>
    public int Index {
        get { return GetIndex(); }
    }
    /// <summary>The container this object is part of.
    /// You should never use this property directly, the container will set it when the item is added. Unsetting this while the item is packed inside a container does not remove the item from the container.</summary>
    /// <value>The container this item is in.</value>
    public Efl.Ui.Widget Container {
        get { return GetContainer(); }
        set { SetContainer(value); }
    }
    /// <summary>The parent of the item.
    /// This property expresses a tree structure of items. If the parent is <c>NULL</c> the item is added to the root level of the content. The item parent can only be set once. When the object is invalidated, the item parent is set to <c>NULL</c> and still cannot be reset.</summary>
    public Efl.Ui.Item ItemParent {
        get { return GetItemParent(); }
        set { SetItemParent(value); }
    }
    /// <summary>This returns true if the given object is currently in event emission</summary>
    public bool Interaction {
        get { return GetInteraction(); }
    }
    /// <summary>The selected state of this object
    /// A change to this property emits the changed event.</summary>
    /// <value>The selected state of this object.</value>
    public bool Selected {
        get { return GetSelected(); }
        set { SetSelected(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Item.efl_ui_item_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_item_index_get_static_delegate == null)
            {
                efl_ui_item_index_get_static_delegate = new efl_ui_item_index_get_delegate(index_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIndex") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_item_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_index_get_static_delegate) });
            }

            if (efl_ui_item_container_get_static_delegate == null)
            {
                efl_ui_item_container_get_static_delegate = new efl_ui_item_container_get_delegate(container_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetContainer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_item_container_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_container_get_static_delegate) });
            }

            if (efl_ui_item_container_set_static_delegate == null)
            {
                efl_ui_item_container_set_static_delegate = new efl_ui_item_container_set_delegate(container_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetContainer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_item_container_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_container_set_static_delegate) });
            }

            if (efl_ui_item_parent_get_static_delegate == null)
            {
                efl_ui_item_parent_get_static_delegate = new efl_ui_item_parent_get_delegate(item_parent_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetItemParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_item_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_parent_get_static_delegate) });
            }

            if (efl_ui_item_parent_set_static_delegate == null)
            {
                efl_ui_item_parent_set_static_delegate = new efl_ui_item_parent_set_delegate(item_parent_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetItemParent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_item_parent_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_item_parent_set_static_delegate) });
            }

            if (efl_input_clickable_press_static_delegate == null)
            {
                efl_input_clickable_press_static_delegate = new efl_input_clickable_press_delegate(press);
            }

            if (methods.FirstOrDefault(m => m.Name == "Press") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_press"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_press_static_delegate) });
            }

            if (efl_input_clickable_unpress_static_delegate == null)
            {
                efl_input_clickable_unpress_static_delegate = new efl_input_clickable_unpress_delegate(unpress);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unpress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_unpress"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_unpress_static_delegate) });
            }

            if (efl_input_clickable_button_state_reset_static_delegate == null)
            {
                efl_input_clickable_button_state_reset_static_delegate = new efl_input_clickable_button_state_reset_delegate(button_state_reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "ResetButtonState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_button_state_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_button_state_reset_static_delegate) });
            }

            if (efl_input_clickable_longpress_abort_static_delegate == null)
            {
                efl_input_clickable_longpress_abort_static_delegate = new efl_input_clickable_longpress_abort_delegate(longpress_abort);
            }

            if (methods.FirstOrDefault(m => m.Name == "LongpressAbort") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_longpress_abort"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_longpress_abort_static_delegate) });
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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Item.efl_ui_item_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate int efl_ui_item_index_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_item_index_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_item_index_get_api_delegate> efl_ui_item_index_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_item_index_get_api_delegate>(Module, "efl_ui_item_index_get");

        private static int index_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_item_index_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Item)ws.Target).GetIndex();
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
                return efl_ui_item_index_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_item_index_get_delegate efl_ui_item_index_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Widget efl_ui_item_container_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Widget efl_ui_item_container_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_item_container_get_api_delegate> efl_ui_item_container_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_item_container_get_api_delegate>(Module, "efl_ui_item_container_get");

        private static Efl.Ui.Widget container_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_item_container_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.Widget _ret_var = default(Efl.Ui.Widget);
                try
                {
                    _ret_var = ((Item)ws.Target).GetContainer();
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
                return efl_ui_item_container_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_item_container_get_delegate efl_ui_item_container_get_static_delegate;

        
        private delegate void efl_ui_item_container_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Widget container);

        
        public delegate void efl_ui_item_container_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Widget container);

        public static Efl.Eo.FunctionWrapper<efl_ui_item_container_set_api_delegate> efl_ui_item_container_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_item_container_set_api_delegate>(Module, "efl_ui_item_container_set");

        private static void container_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Widget container)
        {
            Eina.Log.Debug("function efl_ui_item_container_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Item)ws.Target).SetContainer(container);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_item_container_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), container);
            }
        }

        private static efl_ui_item_container_set_delegate efl_ui_item_container_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Item efl_ui_item_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Item efl_ui_item_parent_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_item_parent_get_api_delegate> efl_ui_item_parent_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_item_parent_get_api_delegate>(Module, "efl_ui_item_parent_get");

        private static Efl.Ui.Item item_parent_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_item_parent_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.Item _ret_var = default(Efl.Ui.Item);
                try
                {
                    _ret_var = ((Item)ws.Target).GetItemParent();
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
                return efl_ui_item_parent_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_item_parent_get_delegate efl_ui_item_parent_get_static_delegate;

        
        private delegate void efl_ui_item_parent_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Item parent);

        
        public delegate void efl_ui_item_parent_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Item parent);

        public static Efl.Eo.FunctionWrapper<efl_ui_item_parent_set_api_delegate> efl_ui_item_parent_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_item_parent_set_api_delegate>(Module, "efl_ui_item_parent_set");

        private static void item_parent_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Item parent)
        {
            Eina.Log.Debug("function efl_ui_item_parent_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Item)ws.Target).SetItemParent(parent);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_item_parent_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), parent);
            }
        }

        private static efl_ui_item_parent_set_delegate efl_ui_item_parent_set_static_delegate;

        
        private delegate void efl_input_clickable_press_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_press_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_press_api_delegate> efl_input_clickable_press_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_press_api_delegate>(Module, "efl_input_clickable_press");

        private static void press(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_press was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Item)ws.Target).Press(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_clickable_press_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_press_delegate efl_input_clickable_press_static_delegate;

        
        private delegate void efl_input_clickable_unpress_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_unpress_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_unpress_api_delegate> efl_input_clickable_unpress_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_unpress_api_delegate>(Module, "efl_input_clickable_unpress");

        private static void unpress(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_unpress was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Item)ws.Target).Unpress(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_clickable_unpress_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_unpress_delegate efl_input_clickable_unpress_static_delegate;

        
        private delegate void efl_input_clickable_button_state_reset_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_button_state_reset_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate> efl_input_clickable_button_state_reset_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate>(Module, "efl_input_clickable_button_state_reset");

        private static void button_state_reset(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_button_state_reset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Item)ws.Target).ResetButtonState(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_clickable_button_state_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_button_state_reset_delegate efl_input_clickable_button_state_reset_static_delegate;

        
        private delegate void efl_input_clickable_longpress_abort_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        public delegate void efl_input_clickable_longpress_abort_api_delegate(System.IntPtr obj,  uint button);

        public static Efl.Eo.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate> efl_input_clickable_longpress_abort_ptr = new Efl.Eo.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate>(Module, "efl_input_clickable_longpress_abort");

        private static void longpress_abort(System.IntPtr obj, System.IntPtr pd, uint button)
        {
            Eina.Log.Debug("function efl_input_clickable_longpress_abort was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Item)ws.Target).LongpressAbort(button);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_clickable_longpress_abort_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_clickable_longpress_abort_delegate efl_input_clickable_longpress_abort_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiItem_ExtensionMethods {
    
    public static Efl.BindableProperty<Efl.Ui.Widget> Container<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Item, T>magic = null) where T : Efl.Ui.Item {
        return new Efl.BindableProperty<Efl.Ui.Widget>("container", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.Item> ItemParent<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Item, T>magic = null) where T : Efl.Ui.Item {
        return new Efl.BindableProperty<Efl.Ui.Item>("item_parent", fac);
    }

    
    public static Efl.BindableProperty<bool> Selected<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Item, T>magic = null) where T : Efl.Ui.Item {
        return new Efl.BindableProperty<bool>("selected", fac);
    }

}
#pragma warning restore CS1591
#endif
