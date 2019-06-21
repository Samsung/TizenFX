#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

/// <summary>A Button Spin.
/// This is a widget which allows the user to increase or decrease numeric values using the arrow buttons or to edit values directly by clicking over them and inputting new ones.</summary>
[Efl.Ui.SpinButton.NativeMethods]
public class SpinButton : Efl.Ui.Spin, Efl.Ui.ILayoutOrientable, Efl.Ui.Focus.IComposition
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(SpinButton))
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
        efl_ui_spin_button_class_get();
    /// <summary>Initializes a new instance of the <see cref="SpinButton"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public SpinButton(Efl.Object parent
            , System.String style = null) : base(efl_ui_spin_button_class_get(), typeof(SpinButton), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="SpinButton"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected SpinButton(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="SpinButton"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected SpinButton(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Called when spin delay is changed.</summary>
    public event EventHandler DelayChangedEvt
    {
        add
        {
            lock (eventLock)
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

                string key = "_EFL_UI_SPIN_BUTTON_EVENT_DELAY_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_UI_SPIN_BUTTON_EVENT_DELAY_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    ///<summary>Method to raise event DelayChangedEvt.</summary>
    public void OnDelayChangedEvt(EventArgs e)
    {
        var key = "_EFL_UI_SPIN_BUTTON_EVENT_DELAY_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Control whether the spin should circulate value when it reaches its minimum or maximum value.
    /// Disabled by default. If disabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will be the maximum value. The same happens when the user tries to decrement it but the value less step is less than minimum value. In this case, the new displayed value will be the minimum value.
    /// 
    /// If enabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will become the minimum value. When the the user tries to decrement it, if the value minus step is less than minimum value, the new displayed value will be the maximum value.
    /// 
    /// E.g.: <c>min</c> = 10 <c>max</c> = 50 <c>step</c> = 20 <c>displayed</c> = 20
    /// 
    /// When the user decrements the value (using left or bottom arrow), it will display $50.</summary>
    /// <returns><c>true</c> to enable circulate or <c>false</c> to disable it.</returns>
    virtual public bool GetCirculate() {
         var _ret_var = Efl.Ui.SpinButton.NativeMethods.efl_ui_spin_button_circulate_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control whether the spin should circulate value when it reaches its minimum or maximum value.
    /// Disabled by default. If disabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will be the maximum value. The same happens when the user tries to decrement it but the value less step is less than minimum value. In this case, the new displayed value will be the minimum value.
    /// 
    /// If enabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will become the minimum value. When the the user tries to decrement it, if the value minus step is less than minimum value, the new displayed value will be the maximum value.
    /// 
    /// E.g.: <c>min</c> = 10 <c>max</c> = 50 <c>step</c> = 20 <c>displayed</c> = 20
    /// 
    /// When the user decrements the value (using left or bottom arrow), it will display $50.</summary>
    /// <param name="circulate"><c>true</c> to enable circulate or <c>false</c> to disable it.</param>
    virtual public void SetCirculate(bool circulate) {
                                 Efl.Ui.SpinButton.NativeMethods.efl_ui_spin_button_circulate_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),circulate);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control whether the spin can be directly edited by the user.
    /// Spin objects can have editing disabled, in which case they can only be changed by using arrows. This is useful for situations where you don&apos;t want your users to write their own value. It&apos;s especially useful when using special values. The user can see the real values instead of special label when editing.</summary>
    /// <returns><c>true</c> to allow users to edit it or <c>false</c> to don&apos;t allow users to edit it directly.</returns>
    virtual public bool GetEditable() {
         var _ret_var = Efl.Ui.SpinButton.NativeMethods.efl_ui_spin_button_editable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control whether the spin can be directly edited by the user.
    /// Spin objects can have editing disabled, in which case they can only be changed by using arrows. This is useful for situations where you don&apos;t want your users to write their own value. It&apos;s especially useful when using special values. The user can see the real values instead of special label when editing.</summary>
    /// <param name="editable"><c>true</c> to allow users to edit it or <c>false</c> to don&apos;t allow users to edit it directly.</param>
    virtual public void SetEditable(bool editable) {
                                 Efl.Ui.SpinButton.NativeMethods.efl_ui_spin_button_editable_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),editable);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <returns>Direction of the widget.</returns>
    virtual public Efl.Ui.LayoutOrientation GetOrientation() {
         var _ret_var = Efl.Ui.ILayoutOrientableConcrete.NativeMethods.efl_ui_layout_orientation_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <param name="dir">Direction of the widget.</param>
    virtual public void SetOrientation(Efl.Ui.LayoutOrientation dir) {
                                 Efl.Ui.ILayoutOrientableConcrete.NativeMethods.efl_ui_layout_orientation_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),dir);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set the order of elements that will be used for composition
    /// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
    /// 
    /// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
    /// 
    /// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
    /// 
    /// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
    /// <returns>The order to use</returns>
    virtual public Eina.List<Efl.Gfx.IEntity> GetCompositionElements() {
         var _ret_var = Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_elements_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.List<Efl.Gfx.IEntity>(_ret_var, true, false);
 }
    /// <summary>Set the order of elements that will be used for composition
    /// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
    /// 
    /// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
    /// 
    /// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
    /// 
    /// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
    /// <param name="logical_order">The order to use</param>
    virtual public void SetCompositionElements(Eina.List<Efl.Gfx.IEntity> logical_order) {
         var _in_logical_order = logical_order.Handle;
logical_order.Own = false;
                        Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_elements_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_logical_order);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <returns><c>true</c> or <c>false</c></returns>
    virtual public bool GetLogicalMode() {
         var _ret_var = Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_logical_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <param name="logical_mode"><c>true</c> or <c>false</c></param>
    virtual public void SetLogicalMode(bool logical_mode) {
                                 Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_logical_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),logical_mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Mark this widget as dirty, the children can be considered to be changed after that call</summary>
    virtual public void Dirty() {
         Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_dirty_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>A call to prepare the children of this element, called if marked as dirty
    /// You can use this function to call composition_elements.</summary>
    virtual public void Prepare() {
         Efl.Ui.Focus.ICompositionConcrete.NativeMethods.efl_ui_focus_composition_prepare_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Control whether the spin should circulate value when it reaches its minimum or maximum value.
    /// Disabled by default. If disabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will be the maximum value. The same happens when the user tries to decrement it but the value less step is less than minimum value. In this case, the new displayed value will be the minimum value.
    /// 
    /// If enabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will become the minimum value. When the the user tries to decrement it, if the value minus step is less than minimum value, the new displayed value will be the maximum value.
    /// 
    /// E.g.: <c>min</c> = 10 <c>max</c> = 50 <c>step</c> = 20 <c>displayed</c> = 20
    /// 
    /// When the user decrements the value (using left or bottom arrow), it will display $50.</summary>
    /// <value><c>true</c> to enable circulate or <c>false</c> to disable it.</value>
    public bool Circulate {
        get { return GetCirculate(); }
        set { SetCirculate(value); }
    }
    /// <summary>Control whether the spin can be directly edited by the user.
    /// Spin objects can have editing disabled, in which case they can only be changed by using arrows. This is useful for situations where you don&apos;t want your users to write their own value. It&apos;s especially useful when using special values. The user can see the real values instead of special label when editing.</summary>
    /// <value><c>true</c> to allow users to edit it or <c>false</c> to don&apos;t allow users to edit it directly.</value>
    public bool Editable {
        get { return GetEditable(); }
        set { SetEditable(value); }
    }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <value>Direction of the widget.</value>
    public Efl.Ui.LayoutOrientation Orientation {
        get { return GetOrientation(); }
        set { SetOrientation(value); }
    }
    /// <summary>Set the order of elements that will be used for composition
    /// Elements of the list can be either an Efl.Ui.Widget, an Efl.Ui.Focus.Object or an Efl.Gfx.
    /// 
    /// If the element is an Efl.Gfx.Entity, then the geometry is used as focus geometry, the focus property is redirected to the evas focus property. The mixin will take care of registration.
    /// 
    /// If the element is an Efl.Ui.Focus.Object, then the mixin will take care of registering the element.
    /// 
    /// If the element is a Efl.Ui.Widget nothing is done and the widget is simply part of the order.</summary>
    /// <value>The order to use</value>
    public Eina.List<Efl.Gfx.IEntity> CompositionElements {
        get { return GetCompositionElements(); }
        set { SetCompositionElements(value); }
    }
    /// <summary>Set to true if all children should be registered as logicals</summary>
    /// <value><c>true</c> or <c>false</c></value>
    public bool LogicalMode {
        get { return GetLogicalMode(); }
        set { SetLogicalMode(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.SpinButton.efl_ui_spin_button_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Spin.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_spin_button_circulate_get_static_delegate == null)
            {
                efl_ui_spin_button_circulate_get_static_delegate = new efl_ui_spin_button_circulate_get_delegate(circulate_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCirculate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spin_button_circulate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spin_button_circulate_get_static_delegate) });
            }

            if (efl_ui_spin_button_circulate_set_static_delegate == null)
            {
                efl_ui_spin_button_circulate_set_static_delegate = new efl_ui_spin_button_circulate_set_delegate(circulate_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCirculate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spin_button_circulate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spin_button_circulate_set_static_delegate) });
            }

            if (efl_ui_spin_button_editable_get_static_delegate == null)
            {
                efl_ui_spin_button_editable_get_static_delegate = new efl_ui_spin_button_editable_get_delegate(editable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEditable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spin_button_editable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spin_button_editable_get_static_delegate) });
            }

            if (efl_ui_spin_button_editable_set_static_delegate == null)
            {
                efl_ui_spin_button_editable_set_static_delegate = new efl_ui_spin_button_editable_set_delegate(editable_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEditable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_spin_button_editable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spin_button_editable_set_static_delegate) });
            }

            if (efl_ui_layout_orientation_get_static_delegate == null)
            {
                efl_ui_layout_orientation_get_static_delegate = new efl_ui_layout_orientation_get_delegate(orientation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetOrientation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_orientation_get_static_delegate) });
            }

            if (efl_ui_layout_orientation_set_static_delegate == null)
            {
                efl_ui_layout_orientation_set_static_delegate = new efl_ui_layout_orientation_set_delegate(orientation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetOrientation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_orientation_set_static_delegate) });
            }

            if (efl_ui_focus_composition_elements_get_static_delegate == null)
            {
                efl_ui_focus_composition_elements_get_static_delegate = new efl_ui_focus_composition_elements_get_delegate(composition_elements_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetCompositionElements") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_get_static_delegate) });
            }

            if (efl_ui_focus_composition_elements_set_static_delegate == null)
            {
                efl_ui_focus_composition_elements_set_static_delegate = new efl_ui_focus_composition_elements_set_delegate(composition_elements_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetCompositionElements") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_elements_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_set_static_delegate) });
            }

            if (efl_ui_focus_composition_logical_mode_get_static_delegate == null)
            {
                efl_ui_focus_composition_logical_mode_get_static_delegate = new efl_ui_focus_composition_logical_mode_get_delegate(logical_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLogicalMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_logical_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_get_static_delegate) });
            }

            if (efl_ui_focus_composition_logical_mode_set_static_delegate == null)
            {
                efl_ui_focus_composition_logical_mode_set_static_delegate = new efl_ui_focus_composition_logical_mode_set_delegate(logical_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetLogicalMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_logical_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_set_static_delegate) });
            }

            if (efl_ui_focus_composition_dirty_static_delegate == null)
            {
                efl_ui_focus_composition_dirty_static_delegate = new efl_ui_focus_composition_dirty_delegate(dirty);
            }

            if (methods.FirstOrDefault(m => m.Name == "Dirty") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_dirty"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_dirty_static_delegate) });
            }

            if (efl_ui_focus_composition_prepare_static_delegate == null)
            {
                efl_ui_focus_composition_prepare_static_delegate = new efl_ui_focus_composition_prepare_delegate(prepare);
            }

            if (methods.FirstOrDefault(m => m.Name == "Prepare") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_focus_composition_prepare"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_prepare_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.SpinButton.efl_ui_spin_button_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_spin_button_circulate_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_spin_button_circulate_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_spin_button_circulate_get_api_delegate> efl_ui_spin_button_circulate_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spin_button_circulate_get_api_delegate>(Module, "efl_ui_spin_button_circulate_get");

        private static bool circulate_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_spin_button_circulate_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((SpinButton)ws.Target).GetCirculate();
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
                return efl_ui_spin_button_circulate_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_spin_button_circulate_get_delegate efl_ui_spin_button_circulate_get_static_delegate;

        
        private delegate void efl_ui_spin_button_circulate_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool circulate);

        
        public delegate void efl_ui_spin_button_circulate_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool circulate);

        public static Efl.Eo.FunctionWrapper<efl_ui_spin_button_circulate_set_api_delegate> efl_ui_spin_button_circulate_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spin_button_circulate_set_api_delegate>(Module, "efl_ui_spin_button_circulate_set");

        private static void circulate_set(System.IntPtr obj, System.IntPtr pd, bool circulate)
        {
            Eina.Log.Debug("function efl_ui_spin_button_circulate_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((SpinButton)ws.Target).SetCirculate(circulate);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_spin_button_circulate_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), circulate);
            }
        }

        private static efl_ui_spin_button_circulate_set_delegate efl_ui_spin_button_circulate_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_spin_button_editable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_spin_button_editable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_spin_button_editable_get_api_delegate> efl_ui_spin_button_editable_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spin_button_editable_get_api_delegate>(Module, "efl_ui_spin_button_editable_get");

        private static bool editable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_spin_button_editable_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((SpinButton)ws.Target).GetEditable();
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
                return efl_ui_spin_button_editable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_spin_button_editable_get_delegate efl_ui_spin_button_editable_get_static_delegate;

        
        private delegate void efl_ui_spin_button_editable_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool editable);

        
        public delegate void efl_ui_spin_button_editable_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool editable);

        public static Efl.Eo.FunctionWrapper<efl_ui_spin_button_editable_set_api_delegate> efl_ui_spin_button_editable_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spin_button_editable_set_api_delegate>(Module, "efl_ui_spin_button_editable_set");

        private static void editable_set(System.IntPtr obj, System.IntPtr pd, bool editable)
        {
            Eina.Log.Debug("function efl_ui_spin_button_editable_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((SpinButton)ws.Target).SetEditable(editable);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_spin_button_editable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), editable);
            }
        }

        private static efl_ui_spin_button_editable_set_delegate efl_ui_spin_button_editable_set_static_delegate;

        
        private delegate Efl.Ui.LayoutOrientation efl_ui_layout_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.LayoutOrientation efl_ui_layout_orientation_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_layout_orientation_get_api_delegate> efl_ui_layout_orientation_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_orientation_get_api_delegate>(Module, "efl_ui_layout_orientation_get");

        private static Efl.Ui.LayoutOrientation orientation_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_layout_orientation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.LayoutOrientation _ret_var = default(Efl.Ui.LayoutOrientation);
                try
                {
                    _ret_var = ((SpinButton)ws.Target).GetOrientation();
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
                return efl_ui_layout_orientation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_layout_orientation_get_delegate efl_ui_layout_orientation_get_static_delegate;

        
        private delegate void efl_ui_layout_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.LayoutOrientation dir);

        
        public delegate void efl_ui_layout_orientation_set_api_delegate(System.IntPtr obj,  Efl.Ui.LayoutOrientation dir);

        public static Efl.Eo.FunctionWrapper<efl_ui_layout_orientation_set_api_delegate> efl_ui_layout_orientation_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_orientation_set_api_delegate>(Module, "efl_ui_layout_orientation_set");

        private static void orientation_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.LayoutOrientation dir)
        {
            Eina.Log.Debug("function efl_ui_layout_orientation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((SpinButton)ws.Target).SetOrientation(dir);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_layout_orientation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir);
            }
        }

        private static efl_ui_layout_orientation_set_delegate efl_ui_layout_orientation_set_static_delegate;

        
        private delegate System.IntPtr efl_ui_focus_composition_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_ui_focus_composition_elements_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_get_api_delegate> efl_ui_focus_composition_elements_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_get_api_delegate>(Module, "efl_ui_focus_composition_elements_get");

        private static System.IntPtr composition_elements_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_elements_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.List<Efl.Gfx.IEntity> _ret_var = default(Eina.List<Efl.Gfx.IEntity>);
                try
                {
                    _ret_var = ((SpinButton)ws.Target).GetCompositionElements();
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
                return efl_ui_focus_composition_elements_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_composition_elements_get_delegate efl_ui_focus_composition_elements_get_static_delegate;

        
        private delegate void efl_ui_focus_composition_elements_set_delegate(System.IntPtr obj, System.IntPtr pd,  System.IntPtr logical_order);

        
        public delegate void efl_ui_focus_composition_elements_set_api_delegate(System.IntPtr obj,  System.IntPtr logical_order);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_set_api_delegate> efl_ui_focus_composition_elements_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_set_api_delegate>(Module, "efl_ui_focus_composition_elements_set");

        private static void composition_elements_set(System.IntPtr obj, System.IntPtr pd, System.IntPtr logical_order)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_elements_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        var _in_logical_order = new Eina.List<Efl.Gfx.IEntity>(logical_order, true, false);
                            
                try
                {
                    ((SpinButton)ws.Target).SetCompositionElements(_in_logical_order);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_composition_elements_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), logical_order);
            }
        }

        private static efl_ui_focus_composition_elements_set_delegate efl_ui_focus_composition_elements_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_focus_composition_logical_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_focus_composition_logical_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_get_api_delegate> efl_ui_focus_composition_logical_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_get_api_delegate>(Module, "efl_ui_focus_composition_logical_mode_get");

        private static bool logical_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((SpinButton)ws.Target).GetLogicalMode();
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
                return efl_ui_focus_composition_logical_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_composition_logical_mode_get_delegate efl_ui_focus_composition_logical_mode_get_static_delegate;

        
        private delegate void efl_ui_focus_composition_logical_mode_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool logical_mode);

        
        public delegate void efl_ui_focus_composition_logical_mode_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool logical_mode);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_set_api_delegate> efl_ui_focus_composition_logical_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_set_api_delegate>(Module, "efl_ui_focus_composition_logical_mode_set");

        private static void logical_mode_set(System.IntPtr obj, System.IntPtr pd, bool logical_mode)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((SpinButton)ws.Target).SetLogicalMode(logical_mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_focus_composition_logical_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), logical_mode);
            }
        }

        private static efl_ui_focus_composition_logical_mode_set_delegate efl_ui_focus_composition_logical_mode_set_static_delegate;

        
        private delegate void efl_ui_focus_composition_dirty_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_composition_dirty_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_dirty_api_delegate> efl_ui_focus_composition_dirty_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_dirty_api_delegate>(Module, "efl_ui_focus_composition_dirty");

        private static void dirty(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_dirty was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((SpinButton)ws.Target).Dirty();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_focus_composition_dirty_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_composition_dirty_delegate efl_ui_focus_composition_dirty_static_delegate;

        
        private delegate void efl_ui_focus_composition_prepare_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_ui_focus_composition_prepare_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_prepare_api_delegate> efl_ui_focus_composition_prepare_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_prepare_api_delegate>(Module, "efl_ui_focus_composition_prepare");

        private static void prepare(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_focus_composition_prepare was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((SpinButton)ws.Target).Prepare();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_ui_focus_composition_prepare_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_focus_composition_prepare_delegate efl_ui_focus_composition_prepare_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

