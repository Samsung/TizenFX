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

/// <summary>Interface for manually handling a group of <see cref="Efl.Ui.Radio"/> buttons.
/// See the documentation of <see cref="Efl.Ui.Radio"/> for an explanation of radio button grouping.</summary>
[Efl.Ui.RadioGroupConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IRadioGroup : 
    Efl.Ui.ISingleSelectable ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="Efl.Ui.Radio.StateValue"/>.
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <returns>The value of the currently selected radio button, or -1.</returns>
    int GetSelectedValue();

    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="Efl.Ui.Radio.StateValue"/>.
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <param name="selected_value">The value of the currently selected radio button, or -1.</param>
    void SetSelectedValue(int selected_value);

    /// <summary>Register a new <see cref="Efl.Ui.Radio"/> button to this group. Keep in mind that registering to a group will only handle button grouping, you still need to add the button to a layout for it to be rendered.
    /// If the <see cref="Efl.Ui.Radio.StateValue"/> of the new button is already used by a previous button in the group, the button will not be added.
    /// 
    /// See also <see cref="Efl.Ui.IRadioGroup.Unregister"/>.</summary>
    /// <param name="radio">The radio button to add to the group.</param>
    void Register(Efl.Ui.Radio radio);

    /// <summary>Unregister an <see cref="Efl.Ui.Radio"/> button from this group. This will unlink the behavior of this button from the other buttons in the group, but if it still belongs to a layout, it will still be rendered.
    /// If the button was not registered in the group the call is ignored. If the button was selected, no button will be selected in the group after this call.
    /// 
    /// See also <see cref="Efl.Ui.IRadioGroup.Register"/>.</summary>
    /// <param name="radio">The radio button to remove from the group.</param>
    void Unregister(Efl.Ui.Radio radio);

    /// <summary>Emitted each time the <c>selected_value</c> changes. The event information contains the <see cref="Efl.Ui.Radio.StateValue"/> of the newly selected button or -1 if no button is now selected.</summary>
    /// <value><see cref="Efl.Ui.RadioGroupValueChangedEventArgs"/></value>
    event EventHandler<Efl.Ui.RadioGroupValueChangedEventArgs> ValueChangedEvent;
    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="Efl.Ui.Radio.StateValue"/>.
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <value>The value of the currently selected radio button, or -1.</value>
    int SelectedValue {
        get;
        set;
    }

}

/// <summary>Event argument wrapper for event <see cref="Efl.Ui.IRadioGroup.ValueChangedEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class RadioGroupValueChangedEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted each time the <c>selected_value</c> changes. The event information contains the <see cref="Efl.Ui.Radio.StateValue"/> of the newly selected button or -1 if no button is now selected.</value>
    public int arg { get; set; }
}

/// <summary>Interface for manually handling a group of <see cref="Efl.Ui.Radio"/> buttons.
/// See the documentation of <see cref="Efl.Ui.Radio"/> for an explanation of radio button grouping.</summary>
public sealed class RadioGroupConcrete :
    Efl.Eo.EoWrapper
    , IRadioGroup
    , Efl.Ui.ISingleSelectable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(RadioGroupConcrete))
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
    private RadioGroupConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_radio_group_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IRadioGroup"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private RadioGroupConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Emitted each time the <c>selected_value</c> changes. The event information contains the <see cref="Efl.Ui.Radio.StateValue"/> of the newly selected button or -1 if no button is now selected.</summary>
    /// <value><see cref="Efl.Ui.RadioGroupValueChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.RadioGroupValueChangedEventArgs> ValueChangedEvent
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
                        Efl.Ui.RadioGroupValueChangedEventArgs args = new Efl.Ui.RadioGroupValueChangedEventArgs();
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

                string key = "_EFL_UI_RADIO_GROUP_EVENT_VALUE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_RADIO_GROUP_EVENT_VALUE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }

    /// <summary>Method to raise event ValueChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnValueChangedEvent(Efl.Ui.RadioGroupValueChangedEventArgs e)
    {
        var key = "_EFL_UI_RADIO_GROUP_EVENT_VALUE_CHANGED";
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
    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="Efl.Ui.Radio.StateValue"/>.
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <returns>The value of the currently selected radio button, or -1.</returns>
    public int GetSelectedValue() {
        var _ret_var = Efl.Ui.RadioGroupConcrete.NativeMethods.efl_ui_radio_group_selected_value_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="Efl.Ui.Radio.StateValue"/>.
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <param name="selected_value">The value of the currently selected radio button, or -1.</param>
    public void SetSelectedValue(int selected_value) {
        Efl.Ui.RadioGroupConcrete.NativeMethods.efl_ui_radio_group_selected_value_set_ptr.Value.Delegate(this.NativeHandle,selected_value);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Register a new <see cref="Efl.Ui.Radio"/> button to this group. Keep in mind that registering to a group will only handle button grouping, you still need to add the button to a layout for it to be rendered.
    /// If the <see cref="Efl.Ui.Radio.StateValue"/> of the new button is already used by a previous button in the group, the button will not be added.
    /// 
    /// See also <see cref="Efl.Ui.IRadioGroup.Unregister"/>.</summary>
    /// <param name="radio">The radio button to add to the group.</param>
    public void Register(Efl.Ui.Radio radio) {
        Efl.Ui.RadioGroupConcrete.NativeMethods.efl_ui_radio_group_register_ptr.Value.Delegate(this.NativeHandle,radio);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Unregister an <see cref="Efl.Ui.Radio"/> button from this group. This will unlink the behavior of this button from the other buttons in the group, but if it still belongs to a layout, it will still be rendered.
    /// If the button was not registered in the group the call is ignored. If the button was selected, no button will be selected in the group after this call.
    /// 
    /// See also <see cref="Efl.Ui.IRadioGroup.Register"/>.</summary>
    /// <param name="radio">The radio button to remove from the group.</param>
    public void Unregister(Efl.Ui.Radio radio) {
        Efl.Ui.RadioGroupConcrete.NativeMethods.efl_ui_radio_group_unregister_ptr.Value.Delegate(this.NativeHandle,radio);
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

    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="Efl.Ui.Radio.StateValue"/>.
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <value>The value of the currently selected radio button, or -1.</value>
    public int SelectedValue {
        get { return GetSelectedValue(); }
        set { SetSelectedValue(value); }
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
        return Efl.Ui.RadioGroupConcrete.efl_ui_radio_group_interface_get();
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

            if (efl_ui_radio_group_selected_value_get_static_delegate == null)
            {
                efl_ui_radio_group_selected_value_get_static_delegate = new efl_ui_radio_group_selected_value_get_delegate(selected_value_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectedValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_group_selected_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_group_selected_value_get_static_delegate) });
            }

            if (efl_ui_radio_group_selected_value_set_static_delegate == null)
            {
                efl_ui_radio_group_selected_value_set_static_delegate = new efl_ui_radio_group_selected_value_set_delegate(selected_value_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelectedValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_group_selected_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_group_selected_value_set_static_delegate) });
            }

            if (efl_ui_radio_group_register_static_delegate == null)
            {
                efl_ui_radio_group_register_static_delegate = new efl_ui_radio_group_register_delegate(register);
            }

            if (methods.FirstOrDefault(m => m.Name == "Register") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_group_register"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_group_register_static_delegate) });
            }

            if (efl_ui_radio_group_unregister_static_delegate == null)
            {
                efl_ui_radio_group_unregister_static_delegate = new efl_ui_radio_group_unregister_delegate(unregister);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unregister") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_group_unregister"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_group_unregister_static_delegate) });
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
            return Efl.Ui.RadioGroupConcrete.efl_ui_radio_group_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate int efl_ui_radio_group_selected_value_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_radio_group_selected_value_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_radio_group_selected_value_get_api_delegate> efl_ui_radio_group_selected_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_radio_group_selected_value_get_api_delegate>(Module, "efl_ui_radio_group_selected_value_get");

        private static int selected_value_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_radio_group_selected_value_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IRadioGroup)ws.Target).GetSelectedValue();
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
                return efl_ui_radio_group_selected_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_radio_group_selected_value_get_delegate efl_ui_radio_group_selected_value_get_static_delegate;

        
        private delegate void efl_ui_radio_group_selected_value_set_delegate(System.IntPtr obj, System.IntPtr pd,  int selected_value);

        
        public delegate void efl_ui_radio_group_selected_value_set_api_delegate(System.IntPtr obj,  int selected_value);

        public static Efl.Eo.FunctionWrapper<efl_ui_radio_group_selected_value_set_api_delegate> efl_ui_radio_group_selected_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_radio_group_selected_value_set_api_delegate>(Module, "efl_ui_radio_group_selected_value_set");

        private static void selected_value_set(System.IntPtr obj, System.IntPtr pd, int selected_value)
        {
            Eina.Log.Debug("function efl_ui_radio_group_selected_value_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IRadioGroup)ws.Target).SetSelectedValue(selected_value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_radio_group_selected_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), selected_value);
            }
        }

        private static efl_ui_radio_group_selected_value_set_delegate efl_ui_radio_group_selected_value_set_static_delegate;

        
        private delegate void efl_ui_radio_group_register_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Radio radio);

        
        public delegate void efl_ui_radio_group_register_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Radio radio);

        public static Efl.Eo.FunctionWrapper<efl_ui_radio_group_register_api_delegate> efl_ui_radio_group_register_ptr = new Efl.Eo.FunctionWrapper<efl_ui_radio_group_register_api_delegate>(Module, "efl_ui_radio_group_register");

        private static void register(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Radio radio)
        {
            Eina.Log.Debug("function efl_ui_radio_group_register was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IRadioGroup)ws.Target).Register(radio);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_radio_group_register_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), radio);
            }
        }

        private static efl_ui_radio_group_register_delegate efl_ui_radio_group_register_static_delegate;

        
        private delegate void efl_ui_radio_group_unregister_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Radio radio);

        
        public delegate void efl_ui_radio_group_unregister_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Radio radio);

        public static Efl.Eo.FunctionWrapper<efl_ui_radio_group_unregister_api_delegate> efl_ui_radio_group_unregister_ptr = new Efl.Eo.FunctionWrapper<efl_ui_radio_group_unregister_api_delegate>(Module, "efl_ui_radio_group_unregister");

        private static void unregister(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Radio radio)
        {
            Eina.Log.Debug("function efl_ui_radio_group_unregister was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IRadioGroup)ws.Target).Unregister(radio);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_radio_group_unregister_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), radio);
            }
        }

        private static efl_ui_radio_group_unregister_delegate efl_ui_radio_group_unregister_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiRadioGroupConcrete_ExtensionMethods {
    public static Efl.BindableProperty<int> SelectedValue<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IRadioGroup, T>magic = null) where T : Efl.Ui.IRadioGroup {
        return new Efl.BindableProperty<int>("selected_value", fac);
    }

    public static Efl.BindableProperty<Efl.Ui.ISelectable> FallbackSelection<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.IRadioGroup, T>magic = null) where T : Efl.Ui.IRadioGroup {
        return new Efl.BindableProperty<Efl.Ui.ISelectable>("fallback_selection", fac);
    }

}
#pragma warning restore CS1591
#endif
