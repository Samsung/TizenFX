#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>A Button Spin.
/// This is a widget which allows the user to increase or decrease numeric values using the arrow buttons or to edit values directly by clicking over them and inputting new ones.
/// 1.21</summary>
[SpinButtonNativeInherit]
public class SpinButton : Efl.Ui.Spin, Efl.Eo.IWrapper,Efl.Ui.Direction,Efl.Ui.Focus.Composition
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.SpinButtonNativeInherit nativeInherit = new Efl.Ui.SpinButtonNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (SpinButton))
            return Efl.Ui.SpinButtonNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_spin_button_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
   public SpinButton(Efl.Object parent
         ,  System.String style = null) :
      base(efl_ui_spin_button_class_get(), typeof(SpinButton), parent)
   {
      if (Efl.Eo.Globals.ParamHelperCheck(style))
         SetStyle(Efl.Eo.Globals.GetParamHelper(style));
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public SpinButton(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected SpinButton(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static SpinButton static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new SpinButton(obj.NativeHandle);
   }
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
private static object DelayChangedEvtKey = new object();
   /// <summary>Called when spin delay is changed.
   /// 1.21</summary>
   public event EventHandler DelayChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_UI_SPIN_BUTTON_EVENT_DELAY_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Elementary, key, this.evt_DelayChangedEvt_delegate)) {
               eventHandlers.AddHandler(DelayChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_UI_SPIN_BUTTON_EVENT_DELAY_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_DelayChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(DelayChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event DelayChangedEvt.</summary>
   public void On_DelayChangedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[DelayChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_DelayChangedEvt_delegate;
   private void on_DelayChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_DelayChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_DelayChangedEvt_delegate = new Efl.EventCb(on_DelayChangedEvt_NativeCallback);
   }
   /// <summary>Control whether the spin should circulate value when it reaches its minimum or maximum value.
   /// Disabled by default. If disabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will be the maximum value. The same happens when the user tries to decrement it but the value less step is less than minimum value. In this case, the new displayed value will be the minimum value.
   /// 
   /// If enabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will become the minimum value. When the the user tries to decrement it, if the value minus step is less than minimum value, the new displayed value will be the maximum value.
   /// 
   /// E.g.: <c>min</c> = 10 <c>max</c> = 50 <c>step</c> = 20 <c>displayed</c> = 20
   /// 
   /// When the user decrements the value (using left or bottom arrow), it will display $50.
   /// 1.21</summary>
   /// <returns><c>true</c> to enable circulate or <c>false</c> to disable it.
   /// 1.21</returns>
   virtual public bool GetCirculate() {
       var _ret_var = Efl.Ui.SpinButtonNativeInherit.efl_ui_spin_button_circulate_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
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
   /// When the user decrements the value (using left or bottom arrow), it will display $50.
   /// 1.21</summary>
   /// <param name="circulate"><c>true</c> to enable circulate or <c>false</c> to disable it.
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void SetCirculate( bool circulate) {
                         Efl.Ui.SpinButtonNativeInherit.efl_ui_spin_button_circulate_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), circulate);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control whether the spin can be directly edited by the user.
   /// Spin objects can have editing disabled, in which case they can only be changed by using arrows. This is useful for situations where you don&apos;t want your users to write their own value. It&apos;s especially useful when using special values. The user can see the real values instead of special label when editing.
   /// 1.21</summary>
   /// <returns><c>true</c> to allow users to edit it or <c>false</c> to don&apos;t allow users to edit it directly.
   /// 1.21</returns>
   virtual public bool GetEditable() {
       var _ret_var = Efl.Ui.SpinButtonNativeInherit.efl_ui_spin_button_editable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control whether the spin can be directly edited by the user.
   /// Spin objects can have editing disabled, in which case they can only be changed by using arrows. This is useful for situations where you don&apos;t want your users to write their own value. It&apos;s especially useful when using special values. The user can see the real values instead of special label when editing.
   /// 1.21</summary>
   /// <param name="editable"><c>true</c> to allow users to edit it or <c>false</c> to don&apos;t allow users to edit it directly.
   /// 1.21</param>
   /// <returns></returns>
   virtual public  void SetEditable( bool editable) {
                         Efl.Ui.SpinButtonNativeInherit.efl_ui_spin_button_editable_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), editable);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control the direction of a given widget.
   /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
   /// 
   /// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
   /// <returns>Direction of the widget.</returns>
   virtual public Efl.Ui.Dir GetDirection() {
       var _ret_var = Efl.Ui.DirectionNativeInherit.efl_ui_direction_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the direction of a given widget.
   /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
   /// 
   /// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
   /// <param name="dir">Direction of the widget.</param>
   /// <returns></returns>
   virtual public  void SetDirection( Efl.Ui.Dir dir) {
                         Efl.Ui.DirectionNativeInherit.efl_ui_direction_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dir);
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
   virtual public Eina.List<Efl.Gfx.Entity> GetCompositionElements() {
       var _ret_var = Efl.Ui.Focus.CompositionNativeInherit.efl_ui_focus_composition_elements_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.List<Efl.Gfx.Entity>(_ret_var, true, false);
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
   /// <returns></returns>
   virtual public  void SetCompositionElements( Eina.List<Efl.Gfx.Entity> logical_order) {
       var _in_logical_order = logical_order.Handle;
logical_order.Own = false;
                  Efl.Ui.Focus.CompositionNativeInherit.efl_ui_focus_composition_elements_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_logical_order);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Set to true if all children should be registered as logicals</summary>
   /// <returns><c>true</c> or <c>false</c></returns>
   virtual public bool GetLogicalMode() {
       var _ret_var = Efl.Ui.Focus.CompositionNativeInherit.efl_ui_focus_composition_logical_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set to true if all children should be registered as logicals</summary>
   /// <param name="logical_mode"><c>true</c> or <c>false</c></param>
   /// <returns></returns>
   virtual public  void SetLogicalMode( bool logical_mode) {
                         Efl.Ui.Focus.CompositionNativeInherit.efl_ui_focus_composition_logical_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), logical_mode);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Mark this widget as dirty, the children can be considered to be changed after that call</summary>
   /// <returns></returns>
   virtual public  void Dirty() {
       Efl.Ui.Focus.CompositionNativeInherit.efl_ui_focus_composition_dirty_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>A call to prepare the children of this element, called if marked as dirty
   /// You can use this function to call composition_elements.</summary>
   /// <returns></returns>
   virtual public  void Prepare() {
       Efl.Ui.Focus.CompositionNativeInherit.efl_ui_focus_composition_prepare_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Control whether the spin should circulate value when it reaches its minimum or maximum value.
/// Disabled by default. If disabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will be the maximum value. The same happens when the user tries to decrement it but the value less step is less than minimum value. In this case, the new displayed value will be the minimum value.
/// 
/// If enabled, when the user tries to increment the value but displayed value plus step value is bigger than maximum value, the new value will become the minimum value. When the the user tries to decrement it, if the value minus step is less than minimum value, the new displayed value will be the maximum value.
/// 
/// E.g.: <c>min</c> = 10 <c>max</c> = 50 <c>step</c> = 20 <c>displayed</c> = 20
/// 
/// When the user decrements the value (using left or bottom arrow), it will display $50.
/// 1.21</summary>
/// <value><c>true</c> to enable circulate or <c>false</c> to disable it.
/// 1.21</value>
   public bool Circulate {
      get { return GetCirculate(); }
      set { SetCirculate( value); }
   }
   /// <summary>Control whether the spin can be directly edited by the user.
/// Spin objects can have editing disabled, in which case they can only be changed by using arrows. This is useful for situations where you don&apos;t want your users to write their own value. It&apos;s especially useful when using special values. The user can see the real values instead of special label when editing.
/// 1.21</summary>
/// <value><c>true</c> to allow users to edit it or <c>false</c> to don&apos;t allow users to edit it directly.
/// 1.21</value>
   public bool Editable {
      get { return GetEditable(); }
      set { SetEditable( value); }
   }
   /// <summary>Control the direction of a given widget.
/// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
/// 
/// Mirroring as defined in <see cref="Efl.Ui.I18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
/// <value>Direction of the widget.</value>
   public Efl.Ui.Dir Direction {
      get { return GetDirection(); }
      set { SetDirection( value); }
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
   public Eina.List<Efl.Gfx.Entity> CompositionElements {
      get { return GetCompositionElements(); }
      set { SetCompositionElements( value); }
   }
   /// <summary>Set to true if all children should be registered as logicals</summary>
/// <value><c>true</c> or <c>false</c></value>
   public bool LogicalMode {
      get { return GetLogicalMode(); }
      set { SetLogicalMode( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.SpinButton.efl_ui_spin_button_class_get();
   }
}
public class SpinButtonNativeInherit : Efl.Ui.SpinNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_ui_spin_button_circulate_get_static_delegate == null)
      efl_ui_spin_button_circulate_get_static_delegate = new efl_ui_spin_button_circulate_get_delegate(circulate_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_spin_button_circulate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spin_button_circulate_get_static_delegate)});
      if (efl_ui_spin_button_circulate_set_static_delegate == null)
      efl_ui_spin_button_circulate_set_static_delegate = new efl_ui_spin_button_circulate_set_delegate(circulate_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_spin_button_circulate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spin_button_circulate_set_static_delegate)});
      if (efl_ui_spin_button_editable_get_static_delegate == null)
      efl_ui_spin_button_editable_get_static_delegate = new efl_ui_spin_button_editable_get_delegate(editable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_spin_button_editable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spin_button_editable_get_static_delegate)});
      if (efl_ui_spin_button_editable_set_static_delegate == null)
      efl_ui_spin_button_editable_set_static_delegate = new efl_ui_spin_button_editable_set_delegate(editable_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_spin_button_editable_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_spin_button_editable_set_static_delegate)});
      if (efl_ui_direction_get_static_delegate == null)
      efl_ui_direction_get_static_delegate = new efl_ui_direction_get_delegate(direction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_get_static_delegate)});
      if (efl_ui_direction_set_static_delegate == null)
      efl_ui_direction_set_static_delegate = new efl_ui_direction_set_delegate(direction_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_set_static_delegate)});
      if (efl_ui_focus_composition_elements_get_static_delegate == null)
      efl_ui_focus_composition_elements_get_static_delegate = new efl_ui_focus_composition_elements_get_delegate(composition_elements_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_composition_elements_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_get_static_delegate)});
      if (efl_ui_focus_composition_elements_set_static_delegate == null)
      efl_ui_focus_composition_elements_set_static_delegate = new efl_ui_focus_composition_elements_set_delegate(composition_elements_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_composition_elements_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_elements_set_static_delegate)});
      if (efl_ui_focus_composition_logical_mode_get_static_delegate == null)
      efl_ui_focus_composition_logical_mode_get_static_delegate = new efl_ui_focus_composition_logical_mode_get_delegate(logical_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_composition_logical_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_get_static_delegate)});
      if (efl_ui_focus_composition_logical_mode_set_static_delegate == null)
      efl_ui_focus_composition_logical_mode_set_static_delegate = new efl_ui_focus_composition_logical_mode_set_delegate(logical_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_composition_logical_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_logical_mode_set_static_delegate)});
      if (efl_ui_focus_composition_dirty_static_delegate == null)
      efl_ui_focus_composition_dirty_static_delegate = new efl_ui_focus_composition_dirty_delegate(dirty);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_composition_dirty"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_dirty_static_delegate)});
      if (efl_ui_focus_composition_prepare_static_delegate == null)
      efl_ui_focus_composition_prepare_static_delegate = new efl_ui_focus_composition_prepare_delegate(prepare);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_focus_composition_prepare"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_focus_composition_prepare_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.SpinButton.efl_ui_spin_button_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.SpinButton.efl_ui_spin_button_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_spin_button_circulate_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_spin_button_circulate_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_spin_button_circulate_get_api_delegate> efl_ui_spin_button_circulate_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spin_button_circulate_get_api_delegate>(_Module, "efl_ui_spin_button_circulate_get");
    private static bool circulate_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_spin_button_circulate_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((SpinButton)wrapper).GetCirculate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_spin_button_circulate_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_spin_button_circulate_get_delegate efl_ui_spin_button_circulate_get_static_delegate;


    private delegate  void efl_ui_spin_button_circulate_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool circulate);


    public delegate  void efl_ui_spin_button_circulate_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool circulate);
    public static Efl.Eo.FunctionWrapper<efl_ui_spin_button_circulate_set_api_delegate> efl_ui_spin_button_circulate_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spin_button_circulate_set_api_delegate>(_Module, "efl_ui_spin_button_circulate_set");
    private static  void circulate_set(System.IntPtr obj, System.IntPtr pd,  bool circulate)
   {
      Eina.Log.Debug("function efl_ui_spin_button_circulate_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((SpinButton)wrapper).SetCirculate( circulate);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_spin_button_circulate_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  circulate);
      }
   }
   private static efl_ui_spin_button_circulate_set_delegate efl_ui_spin_button_circulate_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_spin_button_editable_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_spin_button_editable_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_spin_button_editable_get_api_delegate> efl_ui_spin_button_editable_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spin_button_editable_get_api_delegate>(_Module, "efl_ui_spin_button_editable_get");
    private static bool editable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_spin_button_editable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((SpinButton)wrapper).GetEditable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_spin_button_editable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_spin_button_editable_get_delegate efl_ui_spin_button_editable_get_static_delegate;


    private delegate  void efl_ui_spin_button_editable_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool editable);


    public delegate  void efl_ui_spin_button_editable_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool editable);
    public static Efl.Eo.FunctionWrapper<efl_ui_spin_button_editable_set_api_delegate> efl_ui_spin_button_editable_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_spin_button_editable_set_api_delegate>(_Module, "efl_ui_spin_button_editable_set");
    private static  void editable_set(System.IntPtr obj, System.IntPtr pd,  bool editable)
   {
      Eina.Log.Debug("function efl_ui_spin_button_editable_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((SpinButton)wrapper).SetEditable( editable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_spin_button_editable_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  editable);
      }
   }
   private static efl_ui_spin_button_editable_set_delegate efl_ui_spin_button_editable_set_static_delegate;


    private delegate Efl.Ui.Dir efl_ui_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Ui.Dir efl_ui_direction_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate> efl_ui_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate>(_Module, "efl_ui_direction_get");
    private static Efl.Ui.Dir direction_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_direction_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Ui.Dir _ret_var = default(Efl.Ui.Dir);
         try {
            _ret_var = ((SpinButton)wrapper).GetDirection();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_direction_get_delegate efl_ui_direction_get_static_delegate;


    private delegate  void efl_ui_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir dir);


    public delegate  void efl_ui_direction_set_api_delegate(System.IntPtr obj,   Efl.Ui.Dir dir);
    public static Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate> efl_ui_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate>(_Module, "efl_ui_direction_set");
    private static  void direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir)
   {
      Eina.Log.Debug("function efl_ui_direction_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((SpinButton)wrapper).SetDirection( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private static efl_ui_direction_set_delegate efl_ui_direction_set_static_delegate;


    private delegate  System.IntPtr efl_ui_focus_composition_elements_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr efl_ui_focus_composition_elements_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_get_api_delegate> efl_ui_focus_composition_elements_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_get_api_delegate>(_Module, "efl_ui_focus_composition_elements_get");
    private static  System.IntPtr composition_elements_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_elements_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.List<Efl.Gfx.Entity> _ret_var = default(Eina.List<Efl.Gfx.Entity>);
         try {
            _ret_var = ((SpinButton)wrapper).GetCompositionElements();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_ui_focus_composition_elements_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_composition_elements_get_delegate efl_ui_focus_composition_elements_get_static_delegate;


    private delegate  void efl_ui_focus_composition_elements_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr logical_order);


    public delegate  void efl_ui_focus_composition_elements_set_api_delegate(System.IntPtr obj,    System.IntPtr logical_order);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_set_api_delegate> efl_ui_focus_composition_elements_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_elements_set_api_delegate>(_Module, "efl_ui_focus_composition_elements_set");
    private static  void composition_elements_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr logical_order)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_elements_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_logical_order = new Eina.List<Efl.Gfx.Entity>(logical_order, true, false);
                     
         try {
            ((SpinButton)wrapper).SetCompositionElements( _in_logical_order);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_composition_elements_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  logical_order);
      }
   }
   private static efl_ui_focus_composition_elements_set_delegate efl_ui_focus_composition_elements_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_focus_composition_logical_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_focus_composition_logical_mode_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_get_api_delegate> efl_ui_focus_composition_logical_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_get_api_delegate>(_Module, "efl_ui_focus_composition_logical_mode_get");
    private static bool logical_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((SpinButton)wrapper).GetLogicalMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_focus_composition_logical_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_composition_logical_mode_get_delegate efl_ui_focus_composition_logical_mode_get_static_delegate;


    private delegate  void efl_ui_focus_composition_logical_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool logical_mode);


    public delegate  void efl_ui_focus_composition_logical_mode_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool logical_mode);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_set_api_delegate> efl_ui_focus_composition_logical_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_logical_mode_set_api_delegate>(_Module, "efl_ui_focus_composition_logical_mode_set");
    private static  void logical_mode_set(System.IntPtr obj, System.IntPtr pd,  bool logical_mode)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_logical_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((SpinButton)wrapper).SetLogicalMode( logical_mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_focus_composition_logical_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  logical_mode);
      }
   }
   private static efl_ui_focus_composition_logical_mode_set_delegate efl_ui_focus_composition_logical_mode_set_static_delegate;


    private delegate  void efl_ui_focus_composition_dirty_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_focus_composition_dirty_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_dirty_api_delegate> efl_ui_focus_composition_dirty_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_dirty_api_delegate>(_Module, "efl_ui_focus_composition_dirty");
    private static  void dirty(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_dirty was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((SpinButton)wrapper).Dirty();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_composition_dirty_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_composition_dirty_delegate efl_ui_focus_composition_dirty_static_delegate;


    private delegate  void efl_ui_focus_composition_prepare_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_ui_focus_composition_prepare_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_ui_focus_composition_prepare_api_delegate> efl_ui_focus_composition_prepare_ptr = new Efl.Eo.FunctionWrapper<efl_ui_focus_composition_prepare_api_delegate>(_Module, "efl_ui_focus_composition_prepare");
    private static  void prepare(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_focus_composition_prepare was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((SpinButton)wrapper).Prepare();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_ui_focus_composition_prepare_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_ui_focus_composition_prepare_delegate efl_ui_focus_composition_prepare_static_delegate;
}
} } 
