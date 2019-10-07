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

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.SelectModel.SelectedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class SelectModelSelectedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Object arg { get; set; }
}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.SelectModel.UnselectedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class SelectModelUnselectedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Object arg { get; set; }
}

/// <summary>Efl ui select model class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.SelectModel.NativeMethods]
[Efl.Eo.BindingEntity]
public class SelectModel : Efl.BooleanModel, Efl.Ui.IMultiSelectableAsync, Efl.Ui.ISelectable, Efl.Ui.ISingleSelectable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(SelectModel))
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
        efl_ui_select_model_class_get();

    /// <summary>Initializes a new instance of the <see cref="SelectModel"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
/// <param name="model">Model that is/will be See <see cref="Efl.Ui.IView.SetModel" /></param>
/// <param name="index">Position of this object in the parent model. See <see cref="Efl.CompositeModel.SetIndex" /></param>
    public SelectModel(Efl.Object parent
            , Efl.IModel model, uint? index = null) : base(efl_ui_select_model_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(model))
        {
            SetModel(Efl.Eo.Globals.GetParamHelper(model));
        }

        if (Efl.Eo.Globals.ParamHelperCheck(index))
        {
            SetIndex(Efl.Eo.Globals.GetParamHelper(index));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected SelectModel(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="SelectModel"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected SelectModel(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="SelectModel"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected SelectModel(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <value><see cref="Efl.Ui.SelectModelSelectedEventArgs"/></value>
    public event EventHandler<Efl.Ui.SelectModelSelectedEventArgs> SelectedEvent
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
                        Efl.Ui.SelectModelSelectedEventArgs args = new Efl.Ui.SelectModelSelectedEventArgs();
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

                string key = "_EFL_UI_SELECT_MODEL_EVENT_SELECTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SELECT_MODEL_EVENT_SELECTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event SelectedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSelectedEvent(Efl.Ui.SelectModelSelectedEventArgs e)
    {
        var key = "_EFL_UI_SELECT_MODEL_EVENT_SELECTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }

    /// <value><see cref="Efl.Ui.SelectModelUnselectedEventArgs"/></value>
    public event EventHandler<Efl.Ui.SelectModelUnselectedEventArgs> UnselectedEvent
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
                        Efl.Ui.SelectModelUnselectedEventArgs args = new Efl.Ui.SelectModelUnselectedEventArgs();
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

                string key = "_EFL_UI_SELECT_MODEL_EVENT_UNSELECTED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SELECT_MODEL_EVENT_UNSELECTED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event UnselectedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnUnselectedEvent(Efl.Ui.SelectModelUnselectedEventArgs e)
    {
        var key = "_EFL_UI_SELECT_MODEL_EVENT_UNSELECTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
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

    /// <summary>Emitted when there is a change in the selection state. This event will collect all the item selection change events that are happening within one loop iteration. This means, you will only get this event once, even if a lot of items have changed. If you are interested in detailed changes, subscribe to the individual <see cref="Efl.Ui.ISelectable.SelectedChangedEvent"/> events of each item.</summary>
    public event EventHandler SelectionChangedEvent
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

                string key = "_EFL_UI_SELECTABLE_EVENT_SELECTION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SELECTABLE_EVENT_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event SelectionChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSelectionChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_SELECTABLE_EVENT_SELECTION_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }

    /// <summary>The mode type for children selection.</summary>
    /// <returns>Type of selection of children</returns>
    public virtual Efl.Ui.SelectMode GetSelectMode() {
        var _ret_var = Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_select_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The mode type for children selection.</summary>
    /// <param name="mode">Type of selection of children</param>
    public virtual void SetSelectMode(Efl.Ui.SelectMode mode) {
        Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_select_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mode);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Gets an iterator of all the selected child of this model.</summary>
    /// <returns>The iterator gives indices of selected children. It is valid until any change is made on the model.</returns>
    public virtual Eina.Iterator<ulong> NewSelectedIterator() {
        var _ret_var = Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_selected_iterator_new_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<ulong>(_ret_var, true);

    }

    /// <summary>Gets an iterator of all the child of this model that are not selected.</summary>
    /// <returns>The iterator gives indices of unselected children. It is valid until any change is made on the model.</returns>
    public virtual Eina.Iterator<ulong> NewUnselectedIterator() {
        var _ret_var = Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_unselected_iterator_new_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<ulong>(_ret_var, true);

    }

    /// <summary>Select a range of <see cref="Efl.Ui.ISelectable"/>.
    /// This will select the range of selectables from <c>a</c> to <c>b</c> or from <c>b</c> to <c>a</c> depending on which one comes first. If <c>a</c> or <c>b</c> are not in the range the widget, an error is returned, and no change is applied. Both of the passed values will also be selected.</summary>
    /// <param name="a">One side of the range.</param>
    /// <param name="b">The other side of the range.</param>
    public virtual void SelectRange(ulong a, ulong b) {
        Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_range_select_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),a, b);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Unselect a range of <see cref="Efl.Ui.ISelectable"/>.
    /// This will unselect the range of selectables from <c>a</c> to <c>b</c> or from <c>b</c> to <c>a</c> depending on which one comes first. If <c>a</c> or <c>b</c> are not in the range of the widget, an error is returned, and no change is applied. Both of the passed values will also be unselected.</summary>
    /// <param name="a">One side of the range.</param>
    /// <param name="b">The other side of the range.</param>
    public virtual void RangeUnselect(ulong a, ulong b) {
        Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_range_unselect_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),a, b);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Select all <see cref="Efl.Ui.ISelectable"/></summary>
    public virtual void SelectAll() {
        Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_all_select_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Unselect all <see cref="Efl.Ui.ISelectable"/></summary>
    public virtual void AllUnselect() {
        Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_all_unselect_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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

    /// <summary>The selectable that was selected most recently.</summary>
    /// <returns>The latest selected item.</returns>
    public virtual Efl.Ui.ISelectable GetLastSelected() {
        var _ret_var = Efl.Ui.SingleSelectableConcrete.NativeMethods.efl_ui_selectable_last_selected_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>A object that will be selected in case nothing is selected
    /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    public virtual Efl.Ui.ISelectable GetFallbackSelection() {
        var _ret_var = Efl.Ui.SingleSelectableConcrete.NativeMethods.efl_ui_selectable_fallback_selection_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>A object that will be selected in case nothing is selected
    /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    public virtual void SetFallbackSelection(Efl.Ui.ISelectable fallback) {
        Efl.Ui.SingleSelectableConcrete.NativeMethods.efl_ui_selectable_fallback_selection_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fallback);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The mode type for children selection.</summary>
    /// <value>Type of selection of children</value>
    public Efl.Ui.SelectMode SelectMode {
        get { return GetSelectMode(); }
        set { SetSelectMode(value); }
    }

    /// <summary>The selected state of this object
    /// A change to this property emits the changed event.</summary>
    /// <value>The selected state of this object.</value>
    public bool Selected {
        get { return GetSelected(); }
        set { SetSelected(value); }
    }

    /// <summary>The selectable that was selected most recently.</summary>
    /// <value>The latest selected item.</value>
    public Efl.Ui.ISelectable LastSelected {
        get { return GetLastSelected(); }
    }

    /// <summary>A object that will be selected in case nothing is selected
    /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    public Efl.Ui.ISelectable FallbackSelection {
        get { return GetFallbackSelection(); }
        set { SetFallbackSelection(value); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.SelectModel.efl_ui_select_model_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.BooleanModel.NativeMethods
    {
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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.SelectModel.efl_ui_select_model_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiSelectModel_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Ui.SelectMode> SelectMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.SelectModel, T>magic = null) where T : Efl.Ui.SelectModel {
        return new Efl.BindableProperty<Efl.Ui.SelectMode>("select_mode", fac);
    }

    public static Efl.BindableProperty<bool> Selected<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.SelectModel, T>magic = null) where T : Efl.Ui.SelectModel {
        return new Efl.BindableProperty<bool>("selected", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.ISelectable> FallbackSelection<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.SelectModel, T>magic = null) where T : Efl.Ui.SelectModel {
        return new Efl.BindableProperty<Efl.Ui.ISelectable>("fallback_selection", fac);
    }

}
#pragma warning restore CS1591
#endif
