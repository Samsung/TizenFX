#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>Elementary radio class</summary>
[Efl.Ui.Radio.NativeMethods]
public class Radio : Efl.Ui.Check, Efl.Eo.IWrapper
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
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Radio(Efl.Object parent
            , System.String style = null) : base(efl_ui_radio_class_get(), typeof(Radio), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Radio"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Radio(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="Radio"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Radio(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    /// <summary>Get the integer value that this radio object represents.
    /// This gets the value of the radio.</summary>
    /// <returns>The value to use if this radio object is selected.</returns>
    virtual public int GetStateValue() {
         var _ret_var = Efl.Ui.Radio.NativeMethods.efl_ui_radio_state_value_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the integer value that this radio object represents.
    /// This sets the value of the radio.</summary>
    /// <param name="value">The value to use if this radio object is selected.</param>
    virtual public void SetStateValue(int value) {
                                 Efl.Ui.Radio.NativeMethods.efl_ui_radio_state_value_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),value);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set a convenience pointer to an integer, which changes when radio group value changes.
    /// This sets a pointer to an integer that in addition to the radio object state will also be modified directly. To stop setting the object pointed to, simply use NULL as the valuep argument. If valuep is not NULL then when called, the radio object state will also be modified to reflect the value of the integer valuep points to, just like calling elm_radio_value_set().</summary>
    /// <param name="valuep">Pointer to the integer to modify</param>
    virtual public void SetValuePointer(int valuep) {
         var _in_valuep = Eina.PrimitiveConversion.ManagedToPointerAlloc(valuep);
                        Efl.Ui.Radio.NativeMethods.efl_ui_radio_value_pointer_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_valuep);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the selected radio object.</summary>
    /// <returns>The selected radio object</returns>
    virtual public Efl.Canvas.Object GetSelectedObject() {
         var _ret_var = Efl.Ui.Radio.NativeMethods.efl_ui_radio_selected_object_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Add this radio to a group of other radio objects
    /// Radio objects work in groups. Each member should have a different integer value assigned. In order to have them work as a group, they need to know about each other. This adds the given radio object to the group of which the group object indicated is a member.</summary>
    /// <param name="group">Any radio object whose group the obj is to join.</param>
    virtual public void AddGroup(Efl.Ui.Radio group) {
                                 Efl.Ui.Radio.NativeMethods.efl_ui_radio_group_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),group);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the integer value that this radio object represents.
/// This gets the value of the radio.</summary>
/// <value>The value to use if this radio object is selected.</value>
    public int StateValue {
        get { return GetStateValue(); }
        set { SetStateValue(value); }
    }
    /// <summary>Set a convenience pointer to an integer, which changes when radio group value changes.
/// This sets a pointer to an integer that in addition to the radio object state will also be modified directly. To stop setting the object pointed to, simply use NULL as the valuep argument. If valuep is not NULL then when called, the radio object state will also be modified to reflect the value of the integer valuep points to, just like calling elm_radio_value_set().</summary>
/// <value>Pointer to the integer to modify</value>
    public int ValuePointer {
        set { SetValuePointer(value); }
    }
    /// <summary>Get the selected radio object.</summary>
/// <value>The selected radio object</value>
    public Efl.Canvas.Object SelectedObject {
        get { return GetSelectedObject(); }
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

            if (efl_ui_radio_value_pointer_set_static_delegate == null)
            {
                efl_ui_radio_value_pointer_set_static_delegate = new efl_ui_radio_value_pointer_set_delegate(value_pointer_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetValuePointer") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_value_pointer_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_value_pointer_set_static_delegate) });
            }

            if (efl_ui_radio_selected_object_get_static_delegate == null)
            {
                efl_ui_radio_selected_object_get_static_delegate = new efl_ui_radio_selected_object_get_delegate(selected_object_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSelectedObject") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_selected_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_selected_object_get_static_delegate) });
            }

            if (efl_ui_radio_group_add_static_delegate == null)
            {
                efl_ui_radio_group_add_static_delegate = new efl_ui_radio_group_add_delegate(group_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddGroup") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_radio_group_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_radio_group_add_static_delegate) });
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

        #pragma warning disable CA1707, SA1300, SA1600

        
        private delegate int efl_ui_radio_state_value_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_radio_state_value_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_radio_state_value_get_api_delegate> efl_ui_radio_state_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_radio_state_value_get_api_delegate>(Module, "efl_ui_radio_state_value_get");

        private static int state_value_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_radio_state_value_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Radio)wrapper).GetStateValue();
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
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Radio)wrapper).SetStateValue(value);
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

        
        private delegate void efl_ui_radio_value_pointer_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr valuep);

        
        public delegate void efl_ui_radio_value_pointer_set_api_delegate(System.IntPtr obj,  System.IntPtr valuep);

        public static Efl.Eo.FunctionWrapper<efl_ui_radio_value_pointer_set_api_delegate> efl_ui_radio_value_pointer_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_radio_value_pointer_set_api_delegate>(Module, "efl_ui_radio_value_pointer_set");

        private static void value_pointer_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr valuep)
        {
            Eina.Log.Debug("function efl_ui_radio_value_pointer_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
        var _in_valuep = Eina.PrimitiveConversion.PointerToManaged<int>(valuep);
                            
                try
                {
                    ((Radio)wrapper).SetValuePointer(_in_valuep);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_radio_value_pointer_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), valuep);
            }
        }

        private static efl_ui_radio_value_pointer_set_delegate efl_ui_radio_value_pointer_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_ui_radio_selected_object_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_ui_radio_selected_object_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_radio_selected_object_get_api_delegate> efl_ui_radio_selected_object_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_radio_selected_object_get_api_delegate>(Module, "efl_ui_radio_selected_object_get");

        private static Efl.Canvas.Object selected_object_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_radio_selected_object_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Radio)wrapper).GetSelectedObject();
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
                return efl_ui_radio_selected_object_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_radio_selected_object_get_delegate efl_ui_radio_selected_object_get_static_delegate;

        
        private delegate void efl_ui_radio_group_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Radio group);

        
        public delegate void efl_ui_radio_group_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Ui.Radio group);

        public static Efl.Eo.FunctionWrapper<efl_ui_radio_group_add_api_delegate> efl_ui_radio_group_add_ptr = new Efl.Eo.FunctionWrapper<efl_ui_radio_group_add_api_delegate>(Module, "efl_ui_radio_group_add");

        private static void group_add(System.IntPtr obj, System.IntPtr pd, Efl.Ui.Radio group)
        {
            Eina.Log.Debug("function efl_ui_radio_group_add was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Radio)wrapper).AddGroup(group);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_radio_group_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), group);
            }
        }

        private static efl_ui_radio_group_add_delegate efl_ui_radio_group_add_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

