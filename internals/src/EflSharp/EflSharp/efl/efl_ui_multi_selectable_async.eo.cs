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

/// <summary>Interface for getting access to a range of selected items for widgets that provide them asynchronously.
/// The implementor of this interface provides the possibility to select multiple <see cref="Efl.Ui.ISelectable"/>. If not, only <see cref="Efl.Ui.ISingleSelectable"/> should be implemented. A widget can only provide either this interface or <see cref="Efl.Ui.IMultiSelectable"/>, but not both.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IMultiSelectableAsync : 
    Efl.Ui.ISingleSelectable ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The mode type for children selection.</summary>
    /// <returns>Type of selection of children</returns>
    Efl.Ui.SelectMode GetSelectMode();

    /// <summary>The mode type for children selection.</summary>
    /// <param name="mode">Type of selection of children</param>
    void SetSelectMode(Efl.Ui.SelectMode mode);

    /// <summary>Gets an iterator of all the selected child of this model.</summary>
    /// <returns>The iterator gives indices of selected children. It is valid until any change is made on the model.</returns>
    Eina.Iterator<ulong> NewSelectedIterator();

    /// <summary>Gets an iterator of all the child of this model that are not selected.</summary>
    /// <returns>The iterator gives indices of unselected children. It is valid until any change is made on the model.</returns>
    Eina.Iterator<ulong> NewUnselectedIterator();

    /// <summary>Select a range of <see cref="Efl.Ui.ISelectable"/>.
    /// This will select the range of selectables from <c>a</c> to <c>b</c> or from <c>b</c> to <c>a</c> depending on which one comes first. If <c>a</c> or <c>b</c> are not in the range the widget, an error is returned, and no change is applied. Both of the passed values will also be selected.</summary>
    /// <param name="a">One side of the range.</param>
    /// <param name="b">The other side of the range.</param>
    void SelectRange(ulong a, ulong b);

    /// <summary>Unselect a range of <see cref="Efl.Ui.ISelectable"/>.
    /// This will unselect the range of selectables from <c>a</c> to <c>b</c> or from <c>b</c> to <c>a</c> depending on which one comes first. If <c>a</c> or <c>b</c> are not in the range of the widget, an error is returned, and no change is applied. Both of the passed values will also be unselected.</summary>
    /// <param name="a">One side of the range.</param>
    /// <param name="b">The other side of the range.</param>
    void RangeUnselect(ulong a, ulong b);

    /// <summary>Select all <see cref="Efl.Ui.ISelectable"/></summary>
    void SelectAll();

    /// <summary>Unselect all <see cref="Efl.Ui.ISelectable"/></summary>
    void AllUnselect();

    /// <summary>The mode type for children selection.</summary>
    /// <value>Type of selection of children</value>
    Efl.Ui.SelectMode SelectMode {
        get;
        set;
    }

}

/// <summary>Interface for getting access to a range of selected items for widgets that provide them asynchronously.
/// The implementor of this interface provides the possibility to select multiple <see cref="Efl.Ui.ISelectable"/>. If not, only <see cref="Efl.Ui.ISingleSelectable"/> should be implemented. A widget can only provide either this interface or <see cref="Efl.Ui.IMultiSelectable"/>, but not both.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class MultiSelectableAsyncConcrete :
    Efl.Eo.EoWrapper
    , IMultiSelectableAsync
    , Efl.Ui.ISingleSelectable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(MultiSelectableAsyncConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private MultiSelectableAsyncConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_multi_selectable_async_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IMultiSelectableAsync"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private MultiSelectableAsyncConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
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

#pragma warning disable CS0628
    /// <summary>The mode type for children selection.</summary>
    /// <returns>Type of selection of children</returns>
    public Efl.Ui.SelectMode GetSelectMode() {
        var _ret_var = Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_select_mode_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The mode type for children selection.</summary>
    /// <param name="mode">Type of selection of children</param>
    public void SetSelectMode(Efl.Ui.SelectMode mode) {
        Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_select_mode_set_ptr.Value.Delegate(this.NativeHandle,mode);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Gets an iterator of all the selected child of this model.</summary>
    /// <returns>The iterator gives indices of selected children. It is valid until any change is made on the model.</returns>
    public Eina.Iterator<ulong> NewSelectedIterator() {
        var _ret_var = Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_selected_iterator_new_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<ulong>(_ret_var, true);

    }

    /// <summary>Gets an iterator of all the child of this model that are not selected.</summary>
    /// <returns>The iterator gives indices of unselected children. It is valid until any change is made on the model.</returns>
    public Eina.Iterator<ulong> NewUnselectedIterator() {
        var _ret_var = Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_unselected_iterator_new_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<ulong>(_ret_var, true);

    }

    /// <summary>Select a range of <see cref="Efl.Ui.ISelectable"/>.
    /// This will select the range of selectables from <c>a</c> to <c>b</c> or from <c>b</c> to <c>a</c> depending on which one comes first. If <c>a</c> or <c>b</c> are not in the range the widget, an error is returned, and no change is applied. Both of the passed values will also be selected.</summary>
    /// <param name="a">One side of the range.</param>
    /// <param name="b">The other side of the range.</param>
    public void SelectRange(ulong a, ulong b) {
        Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_range_select_ptr.Value.Delegate(this.NativeHandle,a, b);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Unselect a range of <see cref="Efl.Ui.ISelectable"/>.
    /// This will unselect the range of selectables from <c>a</c> to <c>b</c> or from <c>b</c> to <c>a</c> depending on which one comes first. If <c>a</c> or <c>b</c> are not in the range of the widget, an error is returned, and no change is applied. Both of the passed values will also be unselected.</summary>
    /// <param name="a">One side of the range.</param>
    /// <param name="b">The other side of the range.</param>
    public void RangeUnselect(ulong a, ulong b) {
        Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_range_unselect_ptr.Value.Delegate(this.NativeHandle,a, b);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Select all <see cref="Efl.Ui.ISelectable"/></summary>
    public void SelectAll() {
        Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_all_select_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Unselect all <see cref="Efl.Ui.ISelectable"/></summary>
    public void AllUnselect() {
        Efl.Ui.MultiSelectableAsyncConcrete.NativeMethods.efl_ui_multi_selectable_async_all_unselect_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The selectable that was selected most recently.</summary>
    /// <returns>The latest selected item.</returns>
    public Efl.Ui.ISelectable GetLastSelected() {
        var _ret_var = Efl.Ui.SingleSelectableConcrete.NativeMethods.efl_ui_selectable_last_selected_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>A object that will be selected in case nothing is selected
    /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    public Efl.Ui.ISelectable GetFallbackSelection() {
        var _ret_var = Efl.Ui.SingleSelectableConcrete.NativeMethods.efl_ui_selectable_fallback_selection_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>A object that will be selected in case nothing is selected
    /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    public void SetFallbackSelection(Efl.Ui.ISelectable fallback) {
        Efl.Ui.SingleSelectableConcrete.NativeMethods.efl_ui_selectable_fallback_selection_set_ptr.Value.Delegate(this.NativeHandle,fallback);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The mode type for children selection.</summary>
    /// <value>Type of selection of children</value>
    public Efl.Ui.SelectMode SelectMode {
        get { return GetSelectMode(); }
        set { SetSelectMode(value); }
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

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.MultiSelectableAsyncConcrete.efl_ui_multi_selectable_async_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_multi_selectable_async_select_mode_get_static_delegate == null)
            {
                efl_ui_multi_selectable_async_select_mode_get_static_delegate = new efl_ui_multi_selectable_async_select_mode_get_delegate(select_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_async_select_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_async_select_mode_get_static_delegate) });
            }

            if (efl_ui_multi_selectable_async_select_mode_set_static_delegate == null)
            {
                efl_ui_multi_selectable_async_select_mode_set_static_delegate = new efl_ui_multi_selectable_async_select_mode_set_delegate(select_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelectMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_async_select_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_async_select_mode_set_static_delegate) });
            }

            if (efl_ui_multi_selectable_async_selected_iterator_new_static_delegate == null)
            {
                efl_ui_multi_selectable_async_selected_iterator_new_static_delegate = new efl_ui_multi_selectable_async_selected_iterator_new_delegate(selected_iterator_new);
            }

            if (methods.FirstOrDefault(m => m.Name == "NewSelectedIterator") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_async_selected_iterator_new"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_async_selected_iterator_new_static_delegate) });
            }

            if (efl_ui_multi_selectable_async_unselected_iterator_new_static_delegate == null)
            {
                efl_ui_multi_selectable_async_unselected_iterator_new_static_delegate = new efl_ui_multi_selectable_async_unselected_iterator_new_delegate(unselected_iterator_new);
            }

            if (methods.FirstOrDefault(m => m.Name == "NewUnselectedIterator") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_async_unselected_iterator_new"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_async_unselected_iterator_new_static_delegate) });
            }

            if (efl_ui_multi_selectable_async_range_select_static_delegate == null)
            {
                efl_ui_multi_selectable_async_range_select_static_delegate = new efl_ui_multi_selectable_async_range_select_delegate(range_select);
            }

            if (methods.FirstOrDefault(m => m.Name == "SelectRange") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_async_range_select"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_async_range_select_static_delegate) });
            }

            if (efl_ui_multi_selectable_async_range_unselect_static_delegate == null)
            {
                efl_ui_multi_selectable_async_range_unselect_static_delegate = new efl_ui_multi_selectable_async_range_unselect_delegate(range_unselect);
            }

            if (methods.FirstOrDefault(m => m.Name == "RangeUnselect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_async_range_unselect"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_async_range_unselect_static_delegate) });
            }

            if (efl_ui_multi_selectable_async_all_select_static_delegate == null)
            {
                efl_ui_multi_selectable_async_all_select_static_delegate = new efl_ui_multi_selectable_async_all_select_delegate(all_select);
            }

            if (methods.FirstOrDefault(m => m.Name == "SelectAll") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_async_all_select"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_async_all_select_static_delegate) });
            }

            if (efl_ui_multi_selectable_async_all_unselect_static_delegate == null)
            {
                efl_ui_multi_selectable_async_all_unselect_static_delegate = new efl_ui_multi_selectable_async_all_unselect_delegate(all_unselect);
            }

            if (methods.FirstOrDefault(m => m.Name == "AllUnselect") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_multi_selectable_async_all_unselect"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_multi_selectable_async_all_unselect_static_delegate) });
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
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.MultiSelectableAsyncConcrete.efl_ui_multi_selectable_async_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Ui.SelectMode efl_ui_multi_selectable_async_select_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.SelectMode efl_ui_multi_selectable_async_select_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_select_mode_get_api_delegate> efl_ui_multi_selectable_async_select_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_select_mode_get_api_delegate>(Module, "efl_ui_multi_selectable_async_select_mode_get");

        private static Efl.Ui.SelectMode select_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_multi_selectable_async_select_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Efl.Ui.SelectMode _ret_var = default(Efl.Ui.SelectMode);
                try
                {
                    _ret_var = ((IMultiSelectableAsync)ws.Target).GetSelectMode();
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
                return efl_ui_multi_selectable_async_select_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_multi_selectable_async_select_mode_get_delegate efl_ui_multi_selectable_async_select_mode_get_static_delegate;

        
        private delegate void efl_ui_multi_selectable_async_select_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectMode mode);

        
        public delegate void efl_ui_multi_selectable_async_select_mode_set_api_delegate(System.IntPtr obj,  Efl.Ui.SelectMode mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_select_mode_set_api_delegate> efl_ui_multi_selectable_async_select_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_select_mode_set_api_delegate>(Module, "efl_ui_multi_selectable_async_select_mode_set");

        private static void select_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectMode mode)
        {
            Eina.Log.Debug("function efl_ui_multi_selectable_async_select_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMultiSelectableAsync)ws.Target).SetSelectMode(mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_multi_selectable_async_select_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode);
            }
        }

        private static efl_ui_multi_selectable_async_select_mode_set_delegate efl_ui_multi_selectable_async_select_mode_set_static_delegate;

        
        private delegate System.IntPtr efl_ui_multi_selectable_async_selected_iterator_new_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_multi_selectable_async_selected_iterator_new_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_selected_iterator_new_api_delegate> efl_ui_multi_selectable_async_selected_iterator_new_ptr = new Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_selected_iterator_new_api_delegate>(Module, "efl_ui_multi_selectable_async_selected_iterator_new");

        private static System.IntPtr selected_iterator_new(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_multi_selectable_async_selected_iterator_new was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Iterator<ulong> _ret_var = default(Eina.Iterator<ulong>);
                try
                {
                    _ret_var = ((IMultiSelectableAsync)ws.Target).NewSelectedIterator();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                _ret_var.Own = false; return _ret_var.Handle;
            }
            else
            {
                return efl_ui_multi_selectable_async_selected_iterator_new_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_multi_selectable_async_selected_iterator_new_delegate efl_ui_multi_selectable_async_selected_iterator_new_static_delegate;

        
        private delegate System.IntPtr efl_ui_multi_selectable_async_unselected_iterator_new_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_multi_selectable_async_unselected_iterator_new_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_unselected_iterator_new_api_delegate> efl_ui_multi_selectable_async_unselected_iterator_new_ptr = new Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_unselected_iterator_new_api_delegate>(Module, "efl_ui_multi_selectable_async_unselected_iterator_new");

        private static System.IntPtr unselected_iterator_new(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_multi_selectable_async_unselected_iterator_new was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Iterator<ulong> _ret_var = default(Eina.Iterator<ulong>);
                try
                {
                    _ret_var = ((IMultiSelectableAsync)ws.Target).NewUnselectedIterator();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                _ret_var.Own = false; return _ret_var.Handle;
            }
            else
            {
                return efl_ui_multi_selectable_async_unselected_iterator_new_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_multi_selectable_async_unselected_iterator_new_delegate efl_ui_multi_selectable_async_unselected_iterator_new_static_delegate;

        
        private delegate void efl_ui_multi_selectable_async_range_select_delegate(System.IntPtr obj, System.IntPtr pd,  ulong a,  ulong b);

        
        public delegate void efl_ui_multi_selectable_async_range_select_api_delegate(System.IntPtr obj,  ulong a,  ulong b);

        public static Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_range_select_api_delegate> efl_ui_multi_selectable_async_range_select_ptr = new Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_range_select_api_delegate>(Module, "efl_ui_multi_selectable_async_range_select");

        private static void range_select(System.IntPtr obj, System.IntPtr pd, ulong a, ulong b)
        {
            Eina.Log.Debug("function efl_ui_multi_selectable_async_range_select was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMultiSelectableAsync)ws.Target).SelectRange(a, b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_multi_selectable_async_range_select_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), a, b);
            }
        }

        private static efl_ui_multi_selectable_async_range_select_delegate efl_ui_multi_selectable_async_range_select_static_delegate;

        
        private delegate void efl_ui_multi_selectable_async_range_unselect_delegate(System.IntPtr obj, System.IntPtr pd,  ulong a,  ulong b);

        
        public delegate void efl_ui_multi_selectable_async_range_unselect_api_delegate(System.IntPtr obj,  ulong a,  ulong b);

        public static Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_range_unselect_api_delegate> efl_ui_multi_selectable_async_range_unselect_ptr = new Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_range_unselect_api_delegate>(Module, "efl_ui_multi_selectable_async_range_unselect");

        private static void range_unselect(System.IntPtr obj, System.IntPtr pd, ulong a, ulong b)
        {
            Eina.Log.Debug("function efl_ui_multi_selectable_async_range_unselect was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMultiSelectableAsync)ws.Target).RangeUnselect(a, b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_multi_selectable_async_range_unselect_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), a, b);
            }
        }

        private static efl_ui_multi_selectable_async_range_unselect_delegate efl_ui_multi_selectable_async_range_unselect_static_delegate;

        
        private delegate void efl_ui_multi_selectable_async_all_select_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_multi_selectable_async_all_select_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_all_select_api_delegate> efl_ui_multi_selectable_async_all_select_ptr = new Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_all_select_api_delegate>(Module, "efl_ui_multi_selectable_async_all_select");

        private static void all_select(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_multi_selectable_async_all_select was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMultiSelectableAsync)ws.Target).SelectAll();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_multi_selectable_async_all_select_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_multi_selectable_async_all_select_delegate efl_ui_multi_selectable_async_all_select_static_delegate;

        
        private delegate void efl_ui_multi_selectable_async_all_unselect_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_multi_selectable_async_all_unselect_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_all_unselect_api_delegate> efl_ui_multi_selectable_async_all_unselect_ptr = new Efl.Eo.FunctionWrapper<efl_ui_multi_selectable_async_all_unselect_api_delegate>(Module, "efl_ui_multi_selectable_async_all_unselect");

        private static void all_unselect(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_multi_selectable_async_all_unselect was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IMultiSelectableAsync)ws.Target).AllUnselect();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_multi_selectable_async_all_unselect_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_multi_selectable_async_all_unselect_delegate efl_ui_multi_selectable_async_all_unselect_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiMultiSelectableAsyncConcrete_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Ui.SelectMode> SelectMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IMultiSelectableAsync, T>magic = null) where T : Efl.Ui.IMultiSelectableAsync {
        return new Efl.BindableProperty<Efl.Ui.SelectMode>("select_mode", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.ISelectable> FallbackSelection<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IMultiSelectableAsync, T>magic = null) where T : Efl.Ui.IMultiSelectableAsync {
        return new Efl.BindableProperty<Efl.Ui.ISelectable>("fallback_selection", fac);
    }

}
#pragma warning restore CS1591
#endif
