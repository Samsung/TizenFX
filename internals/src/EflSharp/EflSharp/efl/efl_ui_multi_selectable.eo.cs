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

/// <summary>Interface for getting access to a range of selected items.
/// The implementor of this interface provides the possibility to select multiple Selectables. If not, only <see cref="Efl.Ui.ISingleSelectable"/> should be implemented.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.MultiSelectableConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IMultiSelectable : 
    Efl.Ui.ISingleSelectable ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The mode type for children selection.</summary>
/// <returns>Type of selection of children</returns>
Efl.Ui.SelectMode GetSelectMode();
    /// <summary>The mode type for children selection.</summary>
/// <param name="mode">Type of selection of children</param>
void SetSelectMode(Efl.Ui.SelectMode mode);
    /// <summary>Get the selected items in a iterator. The iterator sequence will be decided by selection.</summary>
/// <returns>User has to free the iterator after usage.</returns>
Eina.Iterator<Efl.Ui.ISelectable> GetSelectedItems();
    /// <summary>Select a range of <see cref="Efl.Ui.ISelectable"/>.
/// This will select the range of selectables from a to b or from b to a depending on which one comes first. If a or b are not part of the widget, a error is returned, and no change is applied. <c>null</c> is not allowed as either of the parameters. Both of the passed values will also be selected.</summary>
/// <param name="a">One side of the range.</param>
/// <param name="b">The other side of the range.</param>
void SelectRange(Efl.Ui.ISelectable a, Efl.Ui.ISelectable b);
    /// <summary>Unselect a range of <see cref="Efl.Ui.ISelectable"/>.
/// This will unselect the range of selectables from a to b or from b to a depending on which one comes first. If a or b are not part of the widget, a error is returned, and no change is applied. <c>null</c> is not allowed as either of the parameters. Both of the passed values will also be unselected.</summary>
/// <param name="a">One side of the range.</param>
/// <param name="b">The other side of the range.</param>
void UnselectRange(Efl.Ui.ISelectable a, Efl.Ui.ISelectable b);
    /// <summary>Select all <see cref="Efl.Ui.ISelectable"/></summary>
void SelectAll();
    /// <summary>Unselect all <see cref="Efl.Ui.ISelectable"/></summary>
void UnselectAll();
                                /// <summary>The mode type for children selection.</summary>
    /// <value>Type of selection of children</value>
    Efl.Ui.SelectMode SelectMode {
        get;
        set;
    }
}
/// <summary>Interface for getting access to a range of selected items.
/// The implementor of this interface provides the possibility to select multiple Selectables. If not, only <see cref="Efl.Ui.ISingleSelectable"/> should be implemented.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
public sealed class MultiSelectableConcrete :
    Efl.Eo.EoWrapper
    , IMultiSelectable
    , Efl.Ui.ISingleSelectable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(MultiSelectableConcrete))
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
    private MultiSelectableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_multi_selectable_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IMultiSelectable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private MultiSelectableConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
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

                string key = "_EFL_UI_SINGLE_SELECTABLE_EVENT_SELECTION_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_SINGLE_SELECTABLE_EVENT_SELECTION_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event SelectionChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnSelectionChangedEvent(EventArgs e)
    {
        var key = "_EFL_UI_SINGLE_SELECTABLE_EVENT_SELECTION_CHANGED";
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
         var _ret_var = Efl.Ui.MultiSelectableConcrete.NativeMethods.efl_ui_select_mode_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The mode type for children selection.</summary>
    /// <param name="mode">Type of selection of children</param>
    public void SetSelectMode(Efl.Ui.SelectMode mode) {
                                 Efl.Ui.MultiSelectableConcrete.NativeMethods.efl_ui_select_mode_set_ptr.Value.Delegate(this.NativeHandle,mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the selected items in a iterator. The iterator sequence will be decided by selection.</summary>
    /// <returns>User has to free the iterator after usage.</returns>
    public Eina.Iterator<Efl.Ui.ISelectable> GetSelectedItems() {
         var _ret_var = Efl.Ui.MultiSelectableConcrete.NativeMethods.efl_ui_selected_items_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Ui.ISelectable>(_ret_var, true);
 }
    /// <summary>Select a range of <see cref="Efl.Ui.ISelectable"/>.
    /// This will select the range of selectables from a to b or from b to a depending on which one comes first. If a or b are not part of the widget, a error is returned, and no change is applied. <c>null</c> is not allowed as either of the parameters. Both of the passed values will also be selected.</summary>
    /// <param name="a">One side of the range.</param>
    /// <param name="b">The other side of the range.</param>
    public void SelectRange(Efl.Ui.ISelectable a, Efl.Ui.ISelectable b) {
                                                         Efl.Ui.MultiSelectableConcrete.NativeMethods.efl_ui_select_range_ptr.Value.Delegate(this.NativeHandle,a, b);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Unselect a range of <see cref="Efl.Ui.ISelectable"/>.
    /// This will unselect the range of selectables from a to b or from b to a depending on which one comes first. If a or b are not part of the widget, a error is returned, and no change is applied. <c>null</c> is not allowed as either of the parameters. Both of the passed values will also be unselected.</summary>
    /// <param name="a">One side of the range.</param>
    /// <param name="b">The other side of the range.</param>
    public void UnselectRange(Efl.Ui.ISelectable a, Efl.Ui.ISelectable b) {
                                                         Efl.Ui.MultiSelectableConcrete.NativeMethods.efl_ui_unselect_range_ptr.Value.Delegate(this.NativeHandle,a, b);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Select all <see cref="Efl.Ui.ISelectable"/></summary>
    public void SelectAll() {
         Efl.Ui.MultiSelectableConcrete.NativeMethods.efl_ui_select_all_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Unselect all <see cref="Efl.Ui.ISelectable"/></summary>
    public void UnselectAll() {
         Efl.Ui.MultiSelectableConcrete.NativeMethods.efl_ui_unselect_all_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The selectable that was selected most recently.</summary>
    /// <returns>The latest selected item.</returns>
    public Efl.Ui.ISelectable GetLastSelected() {
         var _ret_var = Efl.Ui.SingleSelectableConcrete.NativeMethods.efl_ui_single_selectable_last_selected_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A object that will be selected in case nothing is selected
    /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    public Efl.Ui.ISelectable GetFallbackSelection() {
         var _ret_var = Efl.Ui.SingleSelectableConcrete.NativeMethods.efl_ui_single_selectable_fallback_selection_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A object that will be selected in case nothing is selected
    /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
    /// 
    /// Setting this property as a result of selection events results in undefined behavior.</summary>
    public void SetFallbackSelection(Efl.Ui.ISelectable fallback) {
                                 Efl.Ui.SingleSelectableConcrete.NativeMethods.efl_ui_single_selectable_fallback_selection_set_ptr.Value.Delegate(this.NativeHandle,fallback);
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
        return Efl.Ui.MultiSelectableConcrete.efl_ui_multi_selectable_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_select_mode_get_static_delegate == null)
            {
                efl_ui_select_mode_get_static_delegate = new efl_ui_select_mode_get_delegate(select_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_mode_get_static_delegate) });
            }

            if (efl_ui_select_mode_set_static_delegate == null)
            {
                efl_ui_select_mode_set_static_delegate = new efl_ui_select_mode_set_delegate(select_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelectMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_mode_set_static_delegate) });
            }

            if (efl_ui_selected_items_get_static_delegate == null)
            {
                efl_ui_selected_items_get_static_delegate = new efl_ui_selected_items_get_delegate(selected_items_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectedItems") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_selected_items_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_selected_items_get_static_delegate) });
            }

            if (efl_ui_select_range_static_delegate == null)
            {
                efl_ui_select_range_static_delegate = new efl_ui_select_range_delegate(select_range);
            }

            if (methods.FirstOrDefault(m => m.Name == "SelectRange") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_range"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_range_static_delegate) });
            }

            if (efl_ui_unselect_range_static_delegate == null)
            {
                efl_ui_unselect_range_static_delegate = new efl_ui_unselect_range_delegate(unselect_range);
            }

            if (methods.FirstOrDefault(m => m.Name == "UnselectRange") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_unselect_range"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_unselect_range_static_delegate) });
            }

            if (efl_ui_select_all_static_delegate == null)
            {
                efl_ui_select_all_static_delegate = new efl_ui_select_all_delegate(select_all);
            }

            if (methods.FirstOrDefault(m => m.Name == "SelectAll") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_select_all"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_select_all_static_delegate) });
            }

            if (efl_ui_unselect_all_static_delegate == null)
            {
                efl_ui_unselect_all_static_delegate = new efl_ui_unselect_all_delegate(unselect_all);
            }

            if (methods.FirstOrDefault(m => m.Name == "UnselectAll") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_unselect_all"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_unselect_all_static_delegate) });
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
            return Efl.Ui.MultiSelectableConcrete.efl_ui_multi_selectable_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Ui.SelectMode efl_ui_select_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.SelectMode efl_ui_select_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_mode_get_api_delegate> efl_ui_select_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_mode_get_api_delegate>(Module, "efl_ui_select_mode_get");

        private static Efl.Ui.SelectMode select_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_select_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.SelectMode _ret_var = default(Efl.Ui.SelectMode);
                try
                {
                    _ret_var = ((IMultiSelectable)ws.Target).GetSelectMode();
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
                return efl_ui_select_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_select_mode_get_delegate efl_ui_select_mode_get_static_delegate;

        
        private delegate void efl_ui_select_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.SelectMode mode);

        
        public delegate void efl_ui_select_mode_set_api_delegate(System.IntPtr obj,  Efl.Ui.SelectMode mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_mode_set_api_delegate> efl_ui_select_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_mode_set_api_delegate>(Module, "efl_ui_select_mode_set");

        private static void select_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.SelectMode mode)
        {
            Eina.Log.Debug("function efl_ui_select_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IMultiSelectable)ws.Target).SetSelectMode(mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_select_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode);
            }
        }

        private static efl_ui_select_mode_set_delegate efl_ui_select_mode_set_static_delegate;

        
        private delegate System.IntPtr efl_ui_selected_items_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_selected_items_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_selected_items_get_api_delegate> efl_ui_selected_items_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_selected_items_get_api_delegate>(Module, "efl_ui_selected_items_get");

        private static System.IntPtr selected_items_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_selected_items_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Iterator<Efl.Ui.ISelectable> _ret_var = default(Eina.Iterator<Efl.Ui.ISelectable>);
                try
                {
                    _ret_var = ((IMultiSelectable)ws.Target).GetSelectedItems();
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
                return efl_ui_selected_items_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_selected_items_get_delegate efl_ui_selected_items_get_static_delegate;

        
        private delegate void efl_ui_select_range_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ISelectable a, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ISelectable b);

        
        public delegate void efl_ui_select_range_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ISelectable a, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ISelectable b);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_range_api_delegate> efl_ui_select_range_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_range_api_delegate>(Module, "efl_ui_select_range");

        private static void select_range(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ISelectable a, Efl.Ui.ISelectable b)
        {
            Eina.Log.Debug("function efl_ui_select_range was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IMultiSelectable)ws.Target).SelectRange(a, b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_select_range_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), a, b);
            }
        }

        private static efl_ui_select_range_delegate efl_ui_select_range_static_delegate;

        
        private delegate void efl_ui_unselect_range_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ISelectable a, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ISelectable b);

        
        public delegate void efl_ui_unselect_range_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ISelectable a, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.ISelectable b);

        public static Efl.Eo.FunctionWrapper<efl_ui_unselect_range_api_delegate> efl_ui_unselect_range_ptr = new Efl.Eo.FunctionWrapper<efl_ui_unselect_range_api_delegate>(Module, "efl_ui_unselect_range");

        private static void unselect_range(System.IntPtr obj, System.IntPtr pd, Efl.Ui.ISelectable a, Efl.Ui.ISelectable b)
        {
            Eina.Log.Debug("function efl_ui_unselect_range was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IMultiSelectable)ws.Target).UnselectRange(a, b);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_unselect_range_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), a, b);
            }
        }

        private static efl_ui_unselect_range_delegate efl_ui_unselect_range_static_delegate;

        
        private delegate void efl_ui_select_all_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_select_all_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_select_all_api_delegate> efl_ui_select_all_ptr = new Efl.Eo.FunctionWrapper<efl_ui_select_all_api_delegate>(Module, "efl_ui_select_all");

        private static void select_all(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_select_all was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((IMultiSelectable)ws.Target).SelectAll();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_select_all_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_select_all_delegate efl_ui_select_all_static_delegate;

        
        private delegate void efl_ui_unselect_all_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_unselect_all_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_unselect_all_api_delegate> efl_ui_unselect_all_ptr = new Efl.Eo.FunctionWrapper<efl_ui_unselect_all_api_delegate>(Module, "efl_ui_unselect_all");

        private static void unselect_all(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_unselect_all was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((IMultiSelectable)ws.Target).UnselectAll();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_unselect_all_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_unselect_all_delegate efl_ui_unselect_all_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiMultiSelectableConcrete_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Ui.SelectMode> SelectMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IMultiSelectable, T>magic = null) where T : Efl.Ui.IMultiSelectable {
        return new Efl.BindableProperty<Efl.Ui.SelectMode>("select_mode", fac);
    }

    
    public static Efl.BindableProperty<Efl.Ui.ISelectable> FallbackSelection<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IMultiSelectable, T>magic = null) where T : Efl.Ui.IMultiSelectable {
        return new Efl.BindableProperty<Efl.Ui.ISelectable>("fallback_selection", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>Type of multi selectable object.</summary>
[Efl.Eo.BindingEntity]
public enum SelectMode
{
/// <summary>Only single child is selected. If a child is selected, previous selected child will be unselected.</summary>
Single = 0,
/// <summary>Allow multiple selection of children.</summary>
Multi = 1,
/// <summary>No child can be selected at all.</summary>
None = 2,
}

}

}

