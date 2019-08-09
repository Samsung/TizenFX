#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Object with the default implementation for <see cref="Efl.Ui.IRadioGroup"/>.</summary>
[Efl.Ui.RadioGroupImpl.NativeMethods]
[Efl.Eo.BindingEntity]
public class RadioGroupImpl : Efl.Object, Efl.Ui.IRadioGroup
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(RadioGroupImpl))
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
        efl_ui_radio_group_impl_class_get();
    /// <summary>Initializes a new instance of the <see cref="RadioGroupImpl"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public RadioGroupImpl(Efl.Object parent= null
            ) : base(efl_ui_radio_group_impl_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected RadioGroupImpl(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="RadioGroupImpl"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected RadioGroupImpl(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="RadioGroupImpl"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected RadioGroupImpl(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Emitted each time the <c>selected_value</c> changes. The event information contains the <see cref="Efl.Ui.Radio.StateValue"/> of the newly selected button or -1 if no button is now selected.</summary>
    public event EventHandler<Efl.Ui.IRadioGroupValueChangedEvt_Args> ValueChangedEvt
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
                        Efl.Ui.IRadioGroupValueChangedEvt_Args args = new Efl.Ui.IRadioGroupValueChangedEvt_Args();
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
    ///<summary>Method to raise event ValueChangedEvt.</summary>
    public void OnValueChangedEvt(Efl.Ui.IRadioGroupValueChangedEvt_Args e)
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
    /// <summary>Currently selected button in a radio button group, or <c>NULL</c> if no button is selected.
    /// See also <see cref="Efl.Ui.IRadioGroup.SelectedValue"/>.</summary>
    /// <returns>The currently selected radio button in the group, or <c>NULL</c>.</returns>
    virtual public Efl.Ui.Radio GetSelectedObject() {
         var _ret_var = Efl.Ui.IRadioGroupConcrete.NativeMethods.efl_ui_radio_group_selected_object_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Currently selected button in a radio button group, or <c>NULL</c> if no button is selected.
    /// See also <see cref="Efl.Ui.IRadioGroup.SelectedValue"/>.</summary>
    /// <param name="selected_object">The currently selected radio button in the group, or <c>NULL</c>.</param>
    virtual public void SetSelectedObject(Efl.Ui.Radio selected_object) {
                                 Efl.Ui.IRadioGroupConcrete.NativeMethods.efl_ui_radio_group_selected_object_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),selected_object);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="Efl.Ui.Radio.StateValue"/>.
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <returns>The value of the currently selected radio button, or -1.</returns>
    virtual public int GetSelectedValue() {
         var _ret_var = Efl.Ui.IRadioGroupConcrete.NativeMethods.efl_ui_radio_group_selected_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="Efl.Ui.Radio.StateValue"/>.
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <param name="selected_value">The value of the currently selected radio button, or -1.</param>
    virtual public void SetSelectedValue(int selected_value) {
                                 Efl.Ui.IRadioGroupConcrete.NativeMethods.efl_ui_radio_group_selected_value_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),selected_value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Register a new <see cref="Efl.Ui.Radio"/> button to this group. Keep in mind that registering to a group will only handle button grouping, you still need to add the button to a layout for it to be rendered.
    /// If the <see cref="Efl.Ui.Radio.StateValue"/> of the new button is already used by a previous button in the group, the button will not be added.
    /// 
    /// See also <see cref="Efl.Ui.IRadioGroup.Unregister"/>.</summary>
    /// <param name="radio">The radio button to add to the group.</param>
    virtual public void Register(Efl.Ui.Radio radio) {
                                 Efl.Ui.IRadioGroupConcrete.NativeMethods.efl_ui_radio_group_register_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),radio);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Unregister an <see cref="Efl.Ui.Radio"/> button from this group. This will unlink the behavior of this button from the other buttons in the group, but if it still belongs to a layout, it will still be rendered.
    /// If the button was not registered in the group the call is ignored. If the button was selected, no button will be selected in the group after this call.
    /// 
    /// See also <see cref="Efl.Ui.IRadioGroup.Register"/>.</summary>
    /// <param name="radio">The radio button to remove from the group.</param>
    virtual public void Unregister(Efl.Ui.Radio radio) {
                                 Efl.Ui.IRadioGroupConcrete.NativeMethods.efl_ui_radio_group_unregister_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),radio);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Currently selected button in a radio button group, or <c>NULL</c> if no button is selected.
    /// See also <see cref="Efl.Ui.IRadioGroup.SelectedValue"/>.</summary>
    /// <value>The currently selected radio button in the group, or <c>NULL</c>.</value>
    public Efl.Ui.Radio SelectedObject {
        get { return GetSelectedObject(); }
        set { SetSelectedObject(value); }
    }
    /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="Efl.Ui.Radio.StateValue"/>.
    /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
    /// <value>The value of the currently selected radio button, or -1.</value>
    public int SelectedValue {
        get { return GetSelectedValue(); }
        set { SetSelectedValue(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.RadioGroupImpl.efl_ui_radio_group_impl_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_radio_group_selected_object_get_static_delegate == null)
            {
                efl_ui_radio_group_selected_object_get_static_delegate = new efl_ui_radio_group_selected_object_get_delegate(selected_object_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectedObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_group_selected_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_group_selected_object_get_static_delegate) });
            }

            if (efl_ui_radio_group_selected_object_set_static_delegate == null)
            {
                efl_ui_radio_group_selected_object_set_static_delegate = new efl_ui_radio_group_selected_object_set_delegate(selected_object_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSelectedObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_group_selected_object_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_group_selected_object_set_static_delegate) });
            }

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

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.RadioGroupImpl.efl_ui_radio_group_impl_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Ui.Radio efl_ui_radio_group_selected_object_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Ui.Radio efl_ui_radio_group_selected_object_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_radio_group_selected_object_get_api_delegate> efl_ui_radio_group_selected_object_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_radio_group_selected_object_get_api_delegate>(Module, "efl_ui_radio_group_selected_object_get");

        private static Efl.Ui.Radio selected_object_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_radio_group_selected_object_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.Radio _ret_var = default(Efl.Ui.Radio);
                try
                {
                    _ret_var = ((RadioGroupImpl)ws.Target).GetSelectedObject();
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
                return efl_ui_radio_group_selected_object_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_radio_group_selected_object_get_delegate efl_ui_radio_group_selected_object_get_static_delegate;

        
        private delegate void efl_ui_radio_group_selected_object_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Radio selected_object);

        
        public delegate void efl_ui_radio_group_selected_object_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Radio selected_object);

        public static Efl.Eo.FunctionWrapper<efl_ui_radio_group_selected_object_set_api_delegate> efl_ui_radio_group_selected_object_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_radio_group_selected_object_set_api_delegate>(Module, "efl_ui_radio_group_selected_object_set");

        private static void selected_object_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Radio selected_object)
        {
            Eina.Log.Debug("function efl_ui_radio_group_selected_object_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((RadioGroupImpl)ws.Target).SetSelectedObject(selected_object);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_radio_group_selected_object_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), selected_object);
            }
        }

        private static efl_ui_radio_group_selected_object_set_delegate efl_ui_radio_group_selected_object_set_static_delegate;

        
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
                    _ret_var = ((RadioGroupImpl)ws.Target).GetSelectedValue();
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
                    ((RadioGroupImpl)ws.Target).SetSelectedValue(selected_value);
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
                    ((RadioGroupImpl)ws.Target).Register(radio);
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
                    ((RadioGroupImpl)ws.Target).Unregister(radio);
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

