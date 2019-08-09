#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Elementary radio button class.
/// Radio buttons are like check boxes in that they can be either checked or unchecked. However, radio buttons are always bunched together in groups, and only one button in each group can be checked at any given time. Pressing a different button in the group will automatically uncheck any previously checked button.
/// 
/// They are a common way to allow a user to select one option among a list.
/// 
/// To handle button grouping, you can either use an <see cref="Efl.Ui.RadioGroupImpl"/> object or use more convenient widgets like <see cref="Efl.Ui.RadioBox"/>.</summary>
[Efl.Ui.Radio.NativeMethods]
[Efl.Eo.BindingEntity]
public class Radio : Efl.Ui.Check
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Radio))
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
        efl_ui_radio_class_get();
    /// <summary>Initializes a new instance of the <see cref="Radio"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Radio(Efl.Object parent
            , System.String style = null) : base(efl_ui_radio_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Constructor to be used when objects are expected to be constructed from native code.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Radio(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Radio"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Radio(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Radio"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Radio(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Integer value that this radio button represents.
    /// Each radio button in a group must have a unique value. The selected button in a group can then be set or retrieved through the <see cref="Efl.Ui.IRadioGroup.SelectedValue"/> property. This value is also informed through the <see cref="Efl.Ui.IRadioGroup.ValueChangedEvt"/> event.
    /// 
    /// All non-negative values are legal but keep in mind that 0 is the starting value for all new groups: If no button in the group has this value, then no button in the group is initially selected. -1 is the value that <see cref="Efl.Ui.IRadioGroup.SelectedValue"/> returns when no button is selected and therefore cannot be used.</summary>
    /// <returns>The value to use when this radio button is selected. Any value can be used but 0 and -1 have special meanings as described above.</returns>
    virtual public int GetStateValue() {
         var _ret_var = Efl.Ui.Radio.NativeMethods.efl_ui_radio_state_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Integer value that this radio button represents.
    /// Each radio button in a group must have a unique value. The selected button in a group can then be set or retrieved through the <see cref="Efl.Ui.IRadioGroup.SelectedValue"/> property. This value is also informed through the <see cref="Efl.Ui.IRadioGroup.ValueChangedEvt"/> event.
    /// 
    /// All non-negative values are legal but keep in mind that 0 is the starting value for all new groups: If no button in the group has this value, then no button in the group is initially selected. -1 is the value that <see cref="Efl.Ui.IRadioGroup.SelectedValue"/> returns when no button is selected and therefore cannot be used.</summary>
    /// <param name="value">The value to use when this radio button is selected. Any value can be used but 0 and -1 have special meanings as described above.</param>
    virtual public void SetStateValue(int value) {
                                 Efl.Ui.Radio.NativeMethods.efl_ui_radio_state_value_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Integer value that this radio button represents.
    /// Each radio button in a group must have a unique value. The selected button in a group can then be set or retrieved through the <see cref="Efl.Ui.IRadioGroup.SelectedValue"/> property. This value is also informed through the <see cref="Efl.Ui.IRadioGroup.ValueChangedEvt"/> event.
    /// 
    /// All non-negative values are legal but keep in mind that 0 is the starting value for all new groups: If no button in the group has this value, then no button in the group is initially selected. -1 is the value that <see cref="Efl.Ui.IRadioGroup.SelectedValue"/> returns when no button is selected and therefore cannot be used.</summary>
    /// <value>The value to use when this radio button is selected. Any value can be used but 0 and -1 have special meanings as described above.</value>
    public int StateValue {
        get { return GetStateValue(); }
        set { SetStateValue(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Radio.efl_ui_radio_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Check.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_radio_state_value_get_static_delegate == null)
            {
                efl_ui_radio_state_value_get_static_delegate = new efl_ui_radio_state_value_get_delegate(state_value_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStateValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_state_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_state_value_get_static_delegate) });
            }

            if (efl_ui_radio_state_value_set_static_delegate == null)
            {
                efl_ui_radio_state_value_set_static_delegate = new efl_ui_radio_state_value_set_delegate(state_value_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStateValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_state_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_state_value_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.Radio.efl_ui_radio_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate int efl_ui_radio_state_value_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_radio_state_value_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_radio_state_value_get_api_delegate> efl_ui_radio_state_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_radio_state_value_get_api_delegate>(Module, "efl_ui_radio_state_value_get");

        private static int state_value_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_radio_state_value_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Radio)ws.Target).GetStateValue();
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
                return efl_ui_radio_state_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_radio_state_value_get_delegate efl_ui_radio_state_value_get_static_delegate;

        
        private delegate void efl_ui_radio_state_value_set_delegate(System.IntPtr obj, System.IntPtr pd,  int value);

        
        public delegate void efl_ui_radio_state_value_set_api_delegate(System.IntPtr obj,  int value);

        public static Efl.Eo.FunctionWrapper<efl_ui_radio_state_value_set_api_delegate> efl_ui_radio_state_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_radio_state_value_set_api_delegate>(Module, "efl_ui_radio_state_value_set");

        private static void state_value_set(System.IntPtr obj, System.IntPtr pd, int value)
        {
            Eina.Log.Debug("function efl_ui_radio_state_value_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Radio)ws.Target).SetStateValue(value);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_radio_state_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), value);
            }
        }

        private static efl_ui_radio_state_value_set_delegate efl_ui_radio_state_value_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

