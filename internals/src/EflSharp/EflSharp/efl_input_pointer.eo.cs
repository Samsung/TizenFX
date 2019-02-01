#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Input { 
/// <summary>Event data carried over with any pointer event (mouse, touch, pen, ...)
/// 1.18</summary>
[PointerNativeInherit]
public class Pointer : Efl.Object, Efl.Eo.IWrapper,Efl.Duplicate,Efl.Input.Event,Efl.Input.State
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Input.PointerNativeInherit nativeInherit = new Efl.Input.PointerNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Pointer))
            return Efl.Input.PointerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Pointer obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_input_pointer_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Pointer(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Pointer", efl_input_pointer_class_get(), typeof(Pointer), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Pointer(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Pointer(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Pointer static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Pointer(obj.NativeHandle);
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
   protected override void register_event_proxies()
   {
      base.register_event_proxies();
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern Efl.Pointer.Action efl_input_pointer_action_get(System.IntPtr obj);
   /// <summary>The action represented by this event.
   /// 1.18</summary>
   /// <returns>Event action
   /// 1.18</returns>
   virtual public Efl.Pointer.Action GetAction() {
       var _ret_var = efl_input_pointer_action_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_pointer_action_set(System.IntPtr obj,   Efl.Pointer.Action act);
   /// <summary>The action represented by this event.
   /// 1.18</summary>
   /// <param name="act">Event action
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetAction( Efl.Pointer.Action act) {
                         efl_input_pointer_action_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  act);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_input_pointer_value_has_get(System.IntPtr obj,   Efl.Input.Value key);
   /// <summary><c>true</c> if this event carries a valid value for the specified <c>key</c>.
   /// 1.18</summary>
   /// <param name="key">Pressed <c>key</c>
   /// 1.18</param>
   /// <returns><c>true</c> if input value is valid, <c>false</c> otherwise
   /// 1.18</returns>
   virtual public bool GetValueHas( Efl.Input.Value key) {
                         var _ret_var = efl_input_pointer_value_has_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  key);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern double efl_input_pointer_value_get(System.IntPtr obj,   Efl.Input.Value key);
   /// <summary>Represents a generic value for this event.
   /// Refer to the documentation of <see cref="Efl.Input.Value"/> for each value&apos;s meaning, type and range. Call <see cref="Efl.Input.Pointer.GetValueHas"/> to determine whether the returned value is valid or not for this event.
   /// 
   /// Most values are precise floating point values, usually in pixels, radians, or in a range of [-1, 1] or [0, 1]. Some values are discrete values (integers) and thus should preferably be queried with the other methods of this class.
   /// 1.18</summary>
   /// <param name="key"><c>key</c>
   /// 1.18</param>
   /// <returns><c>key</c> value
   /// 1.18</returns>
   virtual public double GetValue( Efl.Input.Value key) {
                         var _ret_var = efl_input_pointer_value_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  key);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_input_pointer_value_set(System.IntPtr obj,   Efl.Input.Value key,   double val);
   /// <summary>Represents a generic value for this event.
   /// Refer to the documentation of <see cref="Efl.Input.Value"/> for each value&apos;s meaning, type and range. Call <see cref="Efl.Input.Pointer.GetValueHas"/> to determine whether the returned value is valid or not for this event.
   /// 
   /// Most values are precise floating point values, usually in pixels, radians, or in a range of [-1, 1] or [0, 1]. Some values are discrete values (integers) and thus should preferably be queried with the other methods of this class.
   /// 1.18</summary>
   /// <param name="key"><c>key</c>
   /// 1.18</param>
   /// <param name="val"><c>key</c> value
   /// 1.18</param>
   /// <returns><c>false</c> if the value could not be set (eg. delta).
   /// 1.18</returns>
   virtual public bool SetValue( Efl.Input.Value key,  double val) {
                                           var _ret_var = efl_input_pointer_value_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  key,  val);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  int efl_input_pointer_button_get(System.IntPtr obj);
   /// <summary>The mouse button that triggered the event.
   /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button</c>) is <c>true</c>.
   /// 1.18</summary>
   /// <returns>1 to 32, 0 if not a button event.
   /// 1.18</returns>
   virtual public  int GetButton() {
       var _ret_var = efl_input_pointer_button_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_pointer_button_set(System.IntPtr obj,    int but);
   /// <summary>The mouse button that triggered the event.
   /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button</c>) is <c>true</c>.
   /// 1.18</summary>
   /// <param name="but">1 to 32, 0 if not a button event.
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetButton(  int but) {
                         efl_input_pointer_button_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  but);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_input_pointer_button_pressed_get(System.IntPtr obj,    int button);
   /// <summary>Whether a mouse button is pressed at the moment of the event.
   /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button_pressed</c>) is <c>true</c>.
   /// 1.18</summary>
   /// <param name="button">1 to 32, 0 if not a button event.
   /// 1.18</param>
   /// <returns><c>true</c> when the button was pressed, <c>false</c> otherwise
   /// 1.18</returns>
   virtual public bool GetButtonPressed(  int button) {
                         var _ret_var = efl_input_pointer_button_pressed_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  button);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_pointer_button_pressed_set(System.IntPtr obj,    int button,  [MarshalAs(UnmanagedType.U1)]  bool pressed);
   /// <summary>Whether a mouse button is pressed at the moment of the event.
   /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button_pressed</c>) is <c>true</c>.
   /// 1.18</summary>
   /// <param name="button">1 to 32, 0 if not a button event.
   /// 1.18</param>
   /// <param name="pressed"><c>true</c> when the button was pressed, <c>false</c> otherwise
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetButtonPressed(  int button,  bool pressed) {
                                           efl_input_pointer_button_pressed_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  button,  pressed);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern Eina.Position2D_StructInternal efl_input_pointer_position_get(System.IntPtr obj);
   /// <summary>Position where the event happened, relative to the window.
   /// See <see cref="Efl.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).
   /// 1.18</summary>
   /// <returns>The position of the event, in pixels.
   /// 1.18</returns>
   virtual public Eina.Position2D GetPosition() {
       var _ret_var = efl_input_pointer_position_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_pointer_position_set(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
   /// <summary>Position where the event happened, relative to the window.
   /// See <see cref="Efl.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).
   /// 1.18</summary>
   /// <param name="pos">The position of the event, in pixels.
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetPosition( Eina.Position2D pos) {
       var _in_pos = Eina.Position2D_StructConversion.ToInternal(pos);
                  efl_input_pointer_position_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern Eina.Vector2_StructInternal efl_input_pointer_precise_position_get(System.IntPtr obj);
   /// <summary>Position where the event happened, relative to the window.
   /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="Efl.Input.Pointer.Position"/>.
   /// 
   /// See also <see cref="Efl.Input.Pointer.Position"/>.
   /// 1.18</summary>
   /// <returns>The position of the event, in pixels.
   /// 1.18</returns>
   virtual public Eina.Vector2 GetPrecisePosition() {
       var _ret_var = efl_input_pointer_precise_position_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Vector2_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_pointer_precise_position_set(System.IntPtr obj,   Eina.Vector2_StructInternal pos);
   /// <summary>Position where the event happened, relative to the window.
   /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="Efl.Input.Pointer.Position"/>.
   /// 
   /// See also <see cref="Efl.Input.Pointer.Position"/>.
   /// 1.18</summary>
   /// <param name="pos">The position of the event, in pixels.
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetPrecisePosition( Eina.Vector2 pos) {
       var _in_pos = Eina.Vector2_StructConversion.ToInternal(pos);
                  efl_input_pointer_precise_position_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern Eina.Position2D_StructInternal efl_input_pointer_previous_position_get(System.IntPtr obj);
   /// <summary>Position of the previous event, valid for move events.
   /// Relative to the window. May be equal to <see cref="Efl.Input.Pointer.Position"/> (by default).
   /// 
   /// This position, in integers, is an approximation of <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_x</c>), <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_y</c>). Use <see cref="Efl.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.
   /// 1.18</summary>
   /// <returns>The position of the event, in pixels.
   /// 1.18</returns>
   virtual public Eina.Position2D GetPreviousPosition() {
       var _ret_var = efl_input_pointer_previous_position_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_pointer_previous_position_set(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
   /// <summary>Position of the previous event, valid for move events.
   /// Relative to the window. May be equal to <see cref="Efl.Input.Pointer.Position"/> (by default).
   /// 
   /// This position, in integers, is an approximation of <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_x</c>), <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_y</c>). Use <see cref="Efl.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.
   /// 1.18</summary>
   /// <param name="pos">The position of the event, in pixels.
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetPreviousPosition( Eina.Position2D pos) {
       var _in_pos = Eina.Position2D_StructConversion.ToInternal(pos);
                  efl_input_pointer_previous_position_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  int efl_input_pointer_tool_get(System.IntPtr obj);
   /// <summary>ID of the tool (eg. pen) that triggered this event.
   /// 1.18</summary>
   /// <returns>Tool ID
   /// 1.18</returns>
   virtual public  int GetTool() {
       var _ret_var = efl_input_pointer_tool_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_pointer_tool_set(System.IntPtr obj,    int id);
   /// <summary>ID of the tool (eg. pen) that triggered this event.
   /// 1.18</summary>
   /// <param name="id">Tool ID
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetTool(  int id) {
                         efl_input_pointer_tool_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  id);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Object efl_input_pointer_source_get(System.IntPtr obj);
   /// <summary>The object where this event first originated, in case of propagation or repetition of the event.
   /// 1.18</summary>
   /// <returns>Source object: <see cref="Efl.Gfx.Entity"/>
   /// 1.18</returns>
   virtual public Efl.Object GetSource() {
       var _ret_var = efl_input_pointer_source_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_pointer_source_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object src);
   /// <summary>The object where this event first originated, in case of propagation or repetition of the event.
   /// 1.18</summary>
   /// <param name="src">Source object: <see cref="Efl.Gfx.Entity"/>
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetSource( Efl.Object src) {
                         efl_input_pointer_source_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  src);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern Efl.Pointer.Flags efl_input_pointer_button_flags_get(System.IntPtr obj);
   /// <summary>Double or triple click information.
   /// 1.18</summary>
   /// <returns>Button information flags
   /// 1.18</returns>
   virtual public Efl.Pointer.Flags GetButtonFlags() {
       var _ret_var = efl_input_pointer_button_flags_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_pointer_button_flags_set(System.IntPtr obj,   Efl.Pointer.Flags flags);
   /// <summary>Double or triple click information.
   /// 1.18</summary>
   /// <param name="flags">Button information flags
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetButtonFlags( Efl.Pointer.Flags flags) {
                         efl_input_pointer_button_flags_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  flags);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_input_pointer_double_click_get(System.IntPtr obj);
   /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
   /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.
   /// 1.18</summary>
   /// <returns><c>true</c> if the button press was a double click, <c>false</c> otherwise
   /// 1.18</returns>
   virtual public bool GetDoubleClick() {
       var _ret_var = efl_input_pointer_double_click_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_pointer_double_click_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
   /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
   /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.
   /// 1.18</summary>
   /// <param name="val"><c>true</c> if the button press was a double click, <c>false</c> otherwise
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetDoubleClick( bool val) {
                         efl_input_pointer_double_click_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_input_pointer_triple_click_get(System.IntPtr obj);
   /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
   /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.
   /// 1.18</summary>
   /// <returns><c>true</c> if the button press was a triple click, <c>false</c> otherwise
   /// 1.18</returns>
   virtual public bool GetTripleClick() {
       var _ret_var = efl_input_pointer_triple_click_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_pointer_triple_click_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
   /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
   /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.
   /// 1.18</summary>
   /// <param name="val"><c>true</c> if the button press was a triple click, <c>false</c> otherwise
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetTripleClick( bool val) {
                         efl_input_pointer_triple_click_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_input_pointer_wheel_horizontal_get(System.IntPtr obj);
   /// <summary>Direction of the wheel, usually vertical.
   /// 1.18</summary>
   /// <returns>If <c>true</c> this was a horizontal wheel.
   /// 1.18</returns>
   virtual public bool GetWheelHorizontal() {
       var _ret_var = efl_input_pointer_wheel_horizontal_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_pointer_wheel_horizontal_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool horizontal);
   /// <summary>Direction of the wheel, usually vertical.
   /// 1.18</summary>
   /// <param name="horizontal">If <c>true</c> this was a horizontal wheel.
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetWheelHorizontal( bool horizontal) {
                         efl_input_pointer_wheel_horizontal_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  horizontal);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  int efl_input_pointer_wheel_delta_get(System.IntPtr obj);
   /// <summary>Delta movement of the wheel in discrete steps.
   /// 1.18</summary>
   /// <returns>Wheel movement delta
   /// 1.18</returns>
   virtual public  int GetWheelDelta() {
       var _ret_var = efl_input_pointer_wheel_delta_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_pointer_wheel_delta_set(System.IntPtr obj,    int dist);
   /// <summary>Delta movement of the wheel in discrete steps.
   /// 1.18</summary>
   /// <param name="dist">Wheel movement delta
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetWheelDelta(  int dist) {
                         efl_input_pointer_wheel_delta_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dist);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.DuplicateConcrete, Efl.Eo.OwnTag>))] protected static extern Efl.Duplicate efl_duplicate(System.IntPtr obj);
   /// <summary>Creates a carbon copy of this object and returns it.
   /// The newly created object will have no event handlers or anything of the sort.</summary>
   /// <returns>Returned carbon copy</returns>
   virtual public Efl.Duplicate DoDuplicate() {
       var _ret_var = efl_duplicate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern double efl_input_timestamp_get(System.IntPtr obj);
   /// <summary>The time at which an event was generated.
   /// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.
   /// 1.19</summary>
   /// <returns>Time in milliseconds when the event happened.
   /// 1.19</returns>
   virtual public double GetTimestamp() {
       var _ret_var = efl_input_timestamp_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_timestamp_set(System.IntPtr obj,   double ms);
   /// <summary>Call this when generating events manually.
   /// 1.19</summary>
   /// <param name="ms">Time in milliseconds when the event happened.
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetTimestamp( double ms) {
                         efl_input_timestamp_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  ms);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] protected static extern Efl.Input.Device efl_input_device_get(System.IntPtr obj);
   /// <summary>Input device that originated this event.
   /// 1.19</summary>
   /// <returns>Input device origin
   /// 1.19</returns>
   virtual public Efl.Input.Device GetDevice() {
       var _ret_var = efl_input_device_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_device_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev);
   /// <summary>Input device that originated this event.
   /// 1.19</summary>
   /// <param name="dev">Input device origin
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetDevice( Efl.Input.Device dev) {
                         efl_input_device_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dev);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern Efl.Input.Flags efl_input_event_flags_get(System.IntPtr obj);
   /// <summary>Extra flags for this event, may be changed by the user.
   /// 1.19</summary>
   /// <returns>Input event flags
   /// 1.19</returns>
   virtual public Efl.Input.Flags GetEventFlags() {
       var _ret_var = efl_input_event_flags_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_event_flags_set(System.IntPtr obj,   Efl.Input.Flags flags);
   /// <summary>Extra flags for this event, may be changed by the user.
   /// 1.19</summary>
   /// <param name="flags">Input event flags
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetEventFlags( Efl.Input.Flags flags) {
                         efl_input_event_flags_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  flags);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_input_processed_get(System.IntPtr obj);
   /// <summary><c>true</c> if <see cref="Efl.Input.Event.EventFlags"/> indicates the event is on hold.
   /// 1.19</summary>
   /// <returns><c>true</c> if the event is on hold, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetProcessed() {
       var _ret_var = efl_input_processed_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_processed_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
   /// <summary><c>true</c> if <see cref="Efl.Input.Event.EventFlags"/> indicates the event is on hold.
   /// 1.19</summary>
   /// <param name="val"><c>true</c> if the event is on hold, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetProcessed( bool val) {
                         efl_input_processed_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_input_scrolling_get(System.IntPtr obj);
   /// <summary><c>true</c> if <see cref="Efl.Input.Event.EventFlags"/> indicates the event happened while scrolling.
   /// 1.19</summary>
   /// <returns><c>true</c> if the event happened while scrolling, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetScrolling() {
       var _ret_var = efl_input_scrolling_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_scrolling_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
   /// <summary><c>true</c> if <see cref="Efl.Input.Event.EventFlags"/> indicates the event happened while scrolling.
   /// 1.19</summary>
   /// <param name="val"><c>true</c> if the event happened while scrolling, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetScrolling( bool val) {
                         efl_input_scrolling_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_input_fake_get(System.IntPtr obj);
   /// <summary><c>true</c> if the event was fake, not triggered by real hardware.
   /// 1.19</summary>
   /// <returns><c>true</c> if the event was not from real hardware, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetFake() {
       var _ret_var = efl_input_fake_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_reset(System.IntPtr obj);
   /// <summary>Resets the internal data to 0 or default values.
   /// 1.19</summary>
   /// <returns></returns>
   virtual public  void Reset() {
       efl_input_reset((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_input_modifier_enabled_get(System.IntPtr obj,   Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...</summary>
   /// <param name="mod">The modifier key to test.</param>
   /// <param name="seat">The seat device, may be <c>null</c></param>
   /// <returns><c>true</c> if the key modifier is pressed.</returns>
   virtual public bool GetModifierEnabled( Efl.Input.Modifier mod,  Efl.Input.Device seat) {
                                           var _ret_var = efl_input_modifier_enabled_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  mod,  seat);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_input_lock_enabled_get(System.IntPtr obj,   Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   /// <summary>Indicates whether a key lock is on, such as NumLock, CapsLock, ...</summary>
   /// <param name="kw_lock">The lock key to test.</param>
   /// <param name="seat">The seat device, may be <c>null</c></param>
   /// <returns><c>true</c> if the key lock is on.</returns>
   virtual public bool GetLockEnabled( Efl.Input.Lock kw_lock,  Efl.Input.Device seat) {
                                           var _ret_var = efl_input_lock_enabled_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  kw_lock,  seat);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>The action represented by this event.
/// 1.18</summary>
   public Efl.Pointer.Action Action {
      get { return GetAction(); }
      set { SetAction( value); }
   }
   /// <summary>The mouse button that triggered the event.
/// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button</c>) is <c>true</c>.
/// 1.18</summary>
   public  int Button {
      get { return GetButton(); }
      set { SetButton( value); }
   }
   /// <summary>Position where the event happened, relative to the window.
/// See <see cref="Efl.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).
/// 1.18</summary>
   public Eina.Position2D Position {
      get { return GetPosition(); }
      set { SetPosition( value); }
   }
   /// <summary>Position where the event happened, relative to the window.
/// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="Efl.Input.Pointer.Position"/>.
/// 
/// See also <see cref="Efl.Input.Pointer.Position"/>.
/// 1.18</summary>
   public Eina.Vector2 PrecisePosition {
      get { return GetPrecisePosition(); }
      set { SetPrecisePosition( value); }
   }
   /// <summary>Position of the previous event, valid for move events.
/// Relative to the window. May be equal to <see cref="Efl.Input.Pointer.Position"/> (by default).
/// 
/// This position, in integers, is an approximation of <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_x</c>), <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_y</c>). Use <see cref="Efl.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.
/// 1.18</summary>
   public Eina.Position2D PreviousPosition {
      get { return GetPreviousPosition(); }
      set { SetPreviousPosition( value); }
   }
   /// <summary>ID of the tool (eg. pen) that triggered this event.
/// 1.18</summary>
   public  int Tool {
      get { return GetTool(); }
      set { SetTool( value); }
   }
   /// <summary>The object where this event first originated, in case of propagation or repetition of the event.
/// 1.18</summary>
   public Efl.Object Source {
      get { return GetSource(); }
      set { SetSource( value); }
   }
   /// <summary>Double or triple click information.
/// 1.18</summary>
   public Efl.Pointer.Flags ButtonFlags {
      get { return GetButtonFlags(); }
      set { SetButtonFlags( value); }
   }
   /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
/// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.
/// 1.18</summary>
   public bool DoubleClick {
      get { return GetDoubleClick(); }
      set { SetDoubleClick( value); }
   }
   /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
/// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.
/// 1.18</summary>
   public bool TripleClick {
      get { return GetTripleClick(); }
      set { SetTripleClick( value); }
   }
   /// <summary>Direction of the wheel, usually vertical.
/// 1.18</summary>
   public bool WheelHorizontal {
      get { return GetWheelHorizontal(); }
      set { SetWheelHorizontal( value); }
   }
   /// <summary>Delta movement of the wheel in discrete steps.
/// 1.18</summary>
   public  int WheelDelta {
      get { return GetWheelDelta(); }
      set { SetWheelDelta( value); }
   }
   /// <summary>The time at which an event was generated.
/// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.
/// 1.19</summary>
   public double Timestamp {
      get { return GetTimestamp(); }
      set { SetTimestamp( value); }
   }
   /// <summary>Input device that originated this event.
/// 1.19</summary>
   public Efl.Input.Device Device {
      get { return GetDevice(); }
      set { SetDevice( value); }
   }
   /// <summary>Extra flags for this event, may be changed by the user.
/// 1.19</summary>
   public Efl.Input.Flags EventFlags {
      get { return GetEventFlags(); }
      set { SetEventFlags( value); }
   }
   /// <summary><c>true</c> if <see cref="Efl.Input.Event.EventFlags"/> indicates the event is on hold.
/// 1.19</summary>
   public bool Processed {
      get { return GetProcessed(); }
      set { SetProcessed( value); }
   }
   /// <summary><c>true</c> if <see cref="Efl.Input.Event.EventFlags"/> indicates the event happened while scrolling.
/// 1.19</summary>
   public bool Scrolling {
      get { return GetScrolling(); }
      set { SetScrolling( value); }
   }
   /// <summary><c>true</c> if the event was fake, not triggered by real hardware.
/// 1.19</summary>
   public bool Fake {
      get { return GetFake(); }
   }
}
public class PointerNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_input_pointer_action_get_static_delegate = new efl_input_pointer_action_get_delegate(action_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_action_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_action_get_static_delegate)});
      efl_input_pointer_action_set_static_delegate = new efl_input_pointer_action_set_delegate(action_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_action_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_action_set_static_delegate)});
      efl_input_pointer_value_has_get_static_delegate = new efl_input_pointer_value_has_get_delegate(value_has_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_value_has_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_value_has_get_static_delegate)});
      efl_input_pointer_value_get_static_delegate = new efl_input_pointer_value_get_delegate(value_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_value_get_static_delegate)});
      efl_input_pointer_value_set_static_delegate = new efl_input_pointer_value_set_delegate(value_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_value_set_static_delegate)});
      efl_input_pointer_button_get_static_delegate = new efl_input_pointer_button_get_delegate(button_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_button_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_get_static_delegate)});
      efl_input_pointer_button_set_static_delegate = new efl_input_pointer_button_set_delegate(button_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_button_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_set_static_delegate)});
      efl_input_pointer_button_pressed_get_static_delegate = new efl_input_pointer_button_pressed_get_delegate(button_pressed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_button_pressed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_pressed_get_static_delegate)});
      efl_input_pointer_button_pressed_set_static_delegate = new efl_input_pointer_button_pressed_set_delegate(button_pressed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_button_pressed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_pressed_set_static_delegate)});
      efl_input_pointer_position_get_static_delegate = new efl_input_pointer_position_get_delegate(position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_position_get_static_delegate)});
      efl_input_pointer_position_set_static_delegate = new efl_input_pointer_position_set_delegate(position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_position_set_static_delegate)});
      efl_input_pointer_precise_position_get_static_delegate = new efl_input_pointer_precise_position_get_delegate(precise_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_precise_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_precise_position_get_static_delegate)});
      efl_input_pointer_precise_position_set_static_delegate = new efl_input_pointer_precise_position_set_delegate(precise_position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_precise_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_precise_position_set_static_delegate)});
      efl_input_pointer_previous_position_get_static_delegate = new efl_input_pointer_previous_position_get_delegate(previous_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_previous_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_previous_position_get_static_delegate)});
      efl_input_pointer_previous_position_set_static_delegate = new efl_input_pointer_previous_position_set_delegate(previous_position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_previous_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_previous_position_set_static_delegate)});
      efl_input_pointer_tool_get_static_delegate = new efl_input_pointer_tool_get_delegate(tool_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_tool_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_tool_get_static_delegate)});
      efl_input_pointer_tool_set_static_delegate = new efl_input_pointer_tool_set_delegate(tool_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_tool_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_tool_set_static_delegate)});
      efl_input_pointer_source_get_static_delegate = new efl_input_pointer_source_get_delegate(source_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_source_get_static_delegate)});
      efl_input_pointer_source_set_static_delegate = new efl_input_pointer_source_set_delegate(source_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_source_set_static_delegate)});
      efl_input_pointer_button_flags_get_static_delegate = new efl_input_pointer_button_flags_get_delegate(button_flags_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_button_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_flags_get_static_delegate)});
      efl_input_pointer_button_flags_set_static_delegate = new efl_input_pointer_button_flags_set_delegate(button_flags_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_button_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_flags_set_static_delegate)});
      efl_input_pointer_double_click_get_static_delegate = new efl_input_pointer_double_click_get_delegate(double_click_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_double_click_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_double_click_get_static_delegate)});
      efl_input_pointer_double_click_set_static_delegate = new efl_input_pointer_double_click_set_delegate(double_click_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_double_click_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_double_click_set_static_delegate)});
      efl_input_pointer_triple_click_get_static_delegate = new efl_input_pointer_triple_click_get_delegate(triple_click_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_triple_click_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_triple_click_get_static_delegate)});
      efl_input_pointer_triple_click_set_static_delegate = new efl_input_pointer_triple_click_set_delegate(triple_click_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_triple_click_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_triple_click_set_static_delegate)});
      efl_input_pointer_wheel_horizontal_get_static_delegate = new efl_input_pointer_wheel_horizontal_get_delegate(wheel_horizontal_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_wheel_horizontal_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_horizontal_get_static_delegate)});
      efl_input_pointer_wheel_horizontal_set_static_delegate = new efl_input_pointer_wheel_horizontal_set_delegate(wheel_horizontal_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_wheel_horizontal_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_horizontal_set_static_delegate)});
      efl_input_pointer_wheel_delta_get_static_delegate = new efl_input_pointer_wheel_delta_get_delegate(wheel_delta_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_wheel_delta_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_delta_get_static_delegate)});
      efl_input_pointer_wheel_delta_set_static_delegate = new efl_input_pointer_wheel_delta_set_delegate(wheel_delta_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_pointer_wheel_delta_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_delta_set_static_delegate)});
      efl_duplicate_static_delegate = new efl_duplicate_delegate(duplicate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_duplicate"), func = Marshal.GetFunctionPointerForDelegate(efl_duplicate_static_delegate)});
      efl_input_timestamp_get_static_delegate = new efl_input_timestamp_get_delegate(timestamp_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_timestamp_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_timestamp_get_static_delegate)});
      efl_input_timestamp_set_static_delegate = new efl_input_timestamp_set_delegate(timestamp_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_timestamp_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_timestamp_set_static_delegate)});
      efl_input_device_get_static_delegate = new efl_input_device_get_delegate(device_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_device_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_get_static_delegate)});
      efl_input_device_set_static_delegate = new efl_input_device_set_delegate(device_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_device_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_set_static_delegate)});
      efl_input_event_flags_get_static_delegate = new efl_input_event_flags_get_delegate(event_flags_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_event_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_event_flags_get_static_delegate)});
      efl_input_event_flags_set_static_delegate = new efl_input_event_flags_set_delegate(event_flags_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_event_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_event_flags_set_static_delegate)});
      efl_input_processed_get_static_delegate = new efl_input_processed_get_delegate(processed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_processed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_processed_get_static_delegate)});
      efl_input_processed_set_static_delegate = new efl_input_processed_set_delegate(processed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_processed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_processed_set_static_delegate)});
      efl_input_scrolling_get_static_delegate = new efl_input_scrolling_get_delegate(scrolling_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_scrolling_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_scrolling_get_static_delegate)});
      efl_input_scrolling_set_static_delegate = new efl_input_scrolling_set_delegate(scrolling_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_scrolling_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_scrolling_set_static_delegate)});
      efl_input_fake_get_static_delegate = new efl_input_fake_get_delegate(fake_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_fake_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_fake_get_static_delegate)});
      efl_input_reset_static_delegate = new efl_input_reset_delegate(reset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_input_reset_static_delegate)});
      efl_input_modifier_enabled_get_static_delegate = new efl_input_modifier_enabled_get_delegate(modifier_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_modifier_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_modifier_enabled_get_static_delegate)});
      efl_input_lock_enabled_get_static_delegate = new efl_input_lock_enabled_get_delegate(lock_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_lock_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_lock_enabled_get_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Input.Pointer.efl_input_pointer_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Input.Pointer.efl_input_pointer_class_get();
   }


    private delegate Efl.Pointer.Action efl_input_pointer_action_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern Efl.Pointer.Action efl_input_pointer_action_get(System.IntPtr obj);
    private static Efl.Pointer.Action action_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_pointer_action_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Pointer.Action _ret_var = default(Efl.Pointer.Action);
         try {
            _ret_var = ((Pointer)wrapper).GetAction();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_pointer_action_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_pointer_action_get_delegate efl_input_pointer_action_get_static_delegate;


    private delegate  void efl_input_pointer_action_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Pointer.Action act);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_pointer_action_set(System.IntPtr obj,   Efl.Pointer.Action act);
    private static  void action_set(System.IntPtr obj, System.IntPtr pd,  Efl.Pointer.Action act)
   {
      Eina.Log.Debug("function efl_input_pointer_action_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetAction( act);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_pointer_action_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  act);
      }
   }
   private efl_input_pointer_action_set_delegate efl_input_pointer_action_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_pointer_value_has_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Value key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_pointer_value_has_get(System.IntPtr obj,   Efl.Input.Value key);
    private static bool value_has_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Value key)
   {
      Eina.Log.Debug("function efl_input_pointer_value_has_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Pointer)wrapper).GetValueHas( key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_input_pointer_value_has_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
      }
   }
   private efl_input_pointer_value_has_get_delegate efl_input_pointer_value_has_get_static_delegate;


    private delegate double efl_input_pointer_value_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Value key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern double efl_input_pointer_value_get(System.IntPtr obj,   Efl.Input.Value key);
    private static double value_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Value key)
   {
      Eina.Log.Debug("function efl_input_pointer_value_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    double _ret_var = default(double);
         try {
            _ret_var = ((Pointer)wrapper).GetValue( key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_input_pointer_value_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
      }
   }
   private efl_input_pointer_value_get_delegate efl_input_pointer_value_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_pointer_value_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Value key,   double val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_pointer_value_set(System.IntPtr obj,   Efl.Input.Value key,   double val);
    private static bool value_set(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Value key,  double val)
   {
      Eina.Log.Debug("function efl_input_pointer_value_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Pointer)wrapper).SetValue( key,  val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_input_pointer_value_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  val);
      }
   }
   private efl_input_pointer_value_set_delegate efl_input_pointer_value_set_static_delegate;


    private delegate  int efl_input_pointer_button_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  int efl_input_pointer_button_get(System.IntPtr obj);
    private static  int button_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_pointer_button_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Pointer)wrapper).GetButton();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_pointer_button_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_pointer_button_get_delegate efl_input_pointer_button_get_static_delegate;


    private delegate  void efl_input_pointer_button_set_delegate(System.IntPtr obj, System.IntPtr pd,    int but);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_pointer_button_set(System.IntPtr obj,    int but);
    private static  void button_set(System.IntPtr obj, System.IntPtr pd,   int but)
   {
      Eina.Log.Debug("function efl_input_pointer_button_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetButton( but);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_pointer_button_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  but);
      }
   }
   private efl_input_pointer_button_set_delegate efl_input_pointer_button_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_pointer_button_pressed_get_delegate(System.IntPtr obj, System.IntPtr pd,    int button);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_pointer_button_pressed_get(System.IntPtr obj,    int button);
    private static bool button_pressed_get(System.IntPtr obj, System.IntPtr pd,   int button)
   {
      Eina.Log.Debug("function efl_input_pointer_button_pressed_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Pointer)wrapper).GetButtonPressed( button);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_input_pointer_button_pressed_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  button);
      }
   }
   private efl_input_pointer_button_pressed_get_delegate efl_input_pointer_button_pressed_get_static_delegate;


    private delegate  void efl_input_pointer_button_pressed_set_delegate(System.IntPtr obj, System.IntPtr pd,    int button,  [MarshalAs(UnmanagedType.U1)]  bool pressed);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_pointer_button_pressed_set(System.IntPtr obj,    int button,  [MarshalAs(UnmanagedType.U1)]  bool pressed);
    private static  void button_pressed_set(System.IntPtr obj, System.IntPtr pd,   int button,  bool pressed)
   {
      Eina.Log.Debug("function efl_input_pointer_button_pressed_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Pointer)wrapper).SetButtonPressed( button,  pressed);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_input_pointer_button_pressed_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  button,  pressed);
      }
   }
   private efl_input_pointer_button_pressed_set_delegate efl_input_pointer_button_pressed_set_static_delegate;


    private delegate Eina.Position2D_StructInternal efl_input_pointer_position_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern Eina.Position2D_StructInternal efl_input_pointer_position_get(System.IntPtr obj);
    private static Eina.Position2D_StructInternal position_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_pointer_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Position2D _ret_var = default(Eina.Position2D);
         try {
            _ret_var = ((Pointer)wrapper).GetPosition();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Position2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_input_pointer_position_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_pointer_position_get_delegate efl_input_pointer_position_get_static_delegate;


    private delegate  void efl_input_pointer_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal pos);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_pointer_position_set(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
    private static  void position_set(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D_StructInternal pos)
   {
      Eina.Log.Debug("function efl_input_pointer_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_pos = Eina.Position2D_StructConversion.ToManaged(pos);
                     
         try {
            ((Pointer)wrapper).SetPosition( _in_pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_pointer_position_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
      }
   }
   private efl_input_pointer_position_set_delegate efl_input_pointer_position_set_static_delegate;


    private delegate Eina.Vector2_StructInternal efl_input_pointer_precise_position_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern Eina.Vector2_StructInternal efl_input_pointer_precise_position_get(System.IntPtr obj);
    private static Eina.Vector2_StructInternal precise_position_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_pointer_precise_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Vector2 _ret_var = default(Eina.Vector2);
         try {
            _ret_var = ((Pointer)wrapper).GetPrecisePosition();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Vector2_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_input_pointer_precise_position_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_pointer_precise_position_get_delegate efl_input_pointer_precise_position_get_static_delegate;


    private delegate  void efl_input_pointer_precise_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Vector2_StructInternal pos);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_pointer_precise_position_set(System.IntPtr obj,   Eina.Vector2_StructInternal pos);
    private static  void precise_position_set(System.IntPtr obj, System.IntPtr pd,  Eina.Vector2_StructInternal pos)
   {
      Eina.Log.Debug("function efl_input_pointer_precise_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_pos = Eina.Vector2_StructConversion.ToManaged(pos);
                     
         try {
            ((Pointer)wrapper).SetPrecisePosition( _in_pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_pointer_precise_position_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
      }
   }
   private efl_input_pointer_precise_position_set_delegate efl_input_pointer_precise_position_set_static_delegate;


    private delegate Eina.Position2D_StructInternal efl_input_pointer_previous_position_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern Eina.Position2D_StructInternal efl_input_pointer_previous_position_get(System.IntPtr obj);
    private static Eina.Position2D_StructInternal previous_position_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_pointer_previous_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Position2D _ret_var = default(Eina.Position2D);
         try {
            _ret_var = ((Pointer)wrapper).GetPreviousPosition();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Position2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_input_pointer_previous_position_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_pointer_previous_position_get_delegate efl_input_pointer_previous_position_get_static_delegate;


    private delegate  void efl_input_pointer_previous_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal pos);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_pointer_previous_position_set(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
    private static  void previous_position_set(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D_StructInternal pos)
   {
      Eina.Log.Debug("function efl_input_pointer_previous_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_pos = Eina.Position2D_StructConversion.ToManaged(pos);
                     
         try {
            ((Pointer)wrapper).SetPreviousPosition( _in_pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_pointer_previous_position_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
      }
   }
   private efl_input_pointer_previous_position_set_delegate efl_input_pointer_previous_position_set_static_delegate;


    private delegate  int efl_input_pointer_tool_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  int efl_input_pointer_tool_get(System.IntPtr obj);
    private static  int tool_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_pointer_tool_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Pointer)wrapper).GetTool();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_pointer_tool_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_pointer_tool_get_delegate efl_input_pointer_tool_get_static_delegate;


    private delegate  void efl_input_pointer_tool_set_delegate(System.IntPtr obj, System.IntPtr pd,    int id);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_pointer_tool_set(System.IntPtr obj,    int id);
    private static  void tool_set(System.IntPtr obj, System.IntPtr pd,   int id)
   {
      Eina.Log.Debug("function efl_input_pointer_tool_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetTool( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_pointer_tool_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private efl_input_pointer_tool_set_delegate efl_input_pointer_tool_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_input_pointer_source_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Object efl_input_pointer_source_get(System.IntPtr obj);
    private static Efl.Object source_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_pointer_source_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Object _ret_var = default(Efl.Object);
         try {
            _ret_var = ((Pointer)wrapper).GetSource();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_pointer_source_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_pointer_source_get_delegate efl_input_pointer_source_get_static_delegate;


    private delegate  void efl_input_pointer_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object src);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_pointer_source_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object src);
    private static  void source_set(System.IntPtr obj, System.IntPtr pd,  Efl.Object src)
   {
      Eina.Log.Debug("function efl_input_pointer_source_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetSource( src);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_pointer_source_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  src);
      }
   }
   private efl_input_pointer_source_set_delegate efl_input_pointer_source_set_static_delegate;


    private delegate Efl.Pointer.Flags efl_input_pointer_button_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern Efl.Pointer.Flags efl_input_pointer_button_flags_get(System.IntPtr obj);
    private static Efl.Pointer.Flags button_flags_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_pointer_button_flags_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Pointer.Flags _ret_var = default(Efl.Pointer.Flags);
         try {
            _ret_var = ((Pointer)wrapper).GetButtonFlags();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_pointer_button_flags_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_pointer_button_flags_get_delegate efl_input_pointer_button_flags_get_static_delegate;


    private delegate  void efl_input_pointer_button_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Pointer.Flags flags);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_pointer_button_flags_set(System.IntPtr obj,   Efl.Pointer.Flags flags);
    private static  void button_flags_set(System.IntPtr obj, System.IntPtr pd,  Efl.Pointer.Flags flags)
   {
      Eina.Log.Debug("function efl_input_pointer_button_flags_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetButtonFlags( flags);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_pointer_button_flags_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  flags);
      }
   }
   private efl_input_pointer_button_flags_set_delegate efl_input_pointer_button_flags_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_pointer_double_click_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_pointer_double_click_get(System.IntPtr obj);
    private static bool double_click_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_pointer_double_click_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Pointer)wrapper).GetDoubleClick();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_pointer_double_click_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_pointer_double_click_get_delegate efl_input_pointer_double_click_get_static_delegate;


    private delegate  void efl_input_pointer_double_click_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_pointer_double_click_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    private static  void double_click_set(System.IntPtr obj, System.IntPtr pd,  bool val)
   {
      Eina.Log.Debug("function efl_input_pointer_double_click_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetDoubleClick( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_pointer_double_click_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private efl_input_pointer_double_click_set_delegate efl_input_pointer_double_click_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_pointer_triple_click_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_pointer_triple_click_get(System.IntPtr obj);
    private static bool triple_click_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_pointer_triple_click_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Pointer)wrapper).GetTripleClick();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_pointer_triple_click_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_pointer_triple_click_get_delegate efl_input_pointer_triple_click_get_static_delegate;


    private delegate  void efl_input_pointer_triple_click_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_pointer_triple_click_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    private static  void triple_click_set(System.IntPtr obj, System.IntPtr pd,  bool val)
   {
      Eina.Log.Debug("function efl_input_pointer_triple_click_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetTripleClick( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_pointer_triple_click_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private efl_input_pointer_triple_click_set_delegate efl_input_pointer_triple_click_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_pointer_wheel_horizontal_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_pointer_wheel_horizontal_get(System.IntPtr obj);
    private static bool wheel_horizontal_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_pointer_wheel_horizontal_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Pointer)wrapper).GetWheelHorizontal();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_pointer_wheel_horizontal_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_pointer_wheel_horizontal_get_delegate efl_input_pointer_wheel_horizontal_get_static_delegate;


    private delegate  void efl_input_pointer_wheel_horizontal_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool horizontal);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_pointer_wheel_horizontal_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool horizontal);
    private static  void wheel_horizontal_set(System.IntPtr obj, System.IntPtr pd,  bool horizontal)
   {
      Eina.Log.Debug("function efl_input_pointer_wheel_horizontal_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetWheelHorizontal( horizontal);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_pointer_wheel_horizontal_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  horizontal);
      }
   }
   private efl_input_pointer_wheel_horizontal_set_delegate efl_input_pointer_wheel_horizontal_set_static_delegate;


    private delegate  int efl_input_pointer_wheel_delta_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  int efl_input_pointer_wheel_delta_get(System.IntPtr obj);
    private static  int wheel_delta_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_pointer_wheel_delta_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Pointer)wrapper).GetWheelDelta();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_pointer_wheel_delta_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_pointer_wheel_delta_get_delegate efl_input_pointer_wheel_delta_get_static_delegate;


    private delegate  void efl_input_pointer_wheel_delta_set_delegate(System.IntPtr obj, System.IntPtr pd,    int dist);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_pointer_wheel_delta_set(System.IntPtr obj,    int dist);
    private static  void wheel_delta_set(System.IntPtr obj, System.IntPtr pd,   int dist)
   {
      Eina.Log.Debug("function efl_input_pointer_wheel_delta_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetWheelDelta( dist);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_pointer_wheel_delta_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dist);
      }
   }
   private efl_input_pointer_wheel_delta_set_delegate efl_input_pointer_wheel_delta_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.DuplicateConcrete, Efl.Eo.OwnTag>))] private delegate Efl.Duplicate efl_duplicate_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.DuplicateConcrete, Efl.Eo.OwnTag>))] private static extern Efl.Duplicate efl_duplicate(System.IntPtr obj);
    private static Efl.Duplicate duplicate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_duplicate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Duplicate _ret_var = default(Efl.Duplicate);
         try {
            _ret_var = ((Pointer)wrapper).DoDuplicate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_duplicate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_duplicate_delegate efl_duplicate_static_delegate;


    private delegate double efl_input_timestamp_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern double efl_input_timestamp_get(System.IntPtr obj);
    private static double timestamp_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_timestamp_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Pointer)wrapper).GetTimestamp();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_timestamp_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_timestamp_get_delegate efl_input_timestamp_get_static_delegate;


    private delegate  void efl_input_timestamp_set_delegate(System.IntPtr obj, System.IntPtr pd,   double ms);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_timestamp_set(System.IntPtr obj,   double ms);
    private static  void timestamp_set(System.IntPtr obj, System.IntPtr pd,  double ms)
   {
      Eina.Log.Debug("function efl_input_timestamp_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetTimestamp( ms);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_timestamp_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ms);
      }
   }
   private efl_input_timestamp_set_delegate efl_input_timestamp_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private delegate Efl.Input.Device efl_input_device_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private static extern Efl.Input.Device efl_input_device_get(System.IntPtr obj);
    private static Efl.Input.Device device_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_device_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Input.Device _ret_var = default(Efl.Input.Device);
         try {
            _ret_var = ((Pointer)wrapper).GetDevice();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_device_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_device_get_delegate efl_input_device_get_static_delegate;


    private delegate  void efl_input_device_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_device_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev);
    private static  void device_set(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device dev)
   {
      Eina.Log.Debug("function efl_input_device_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetDevice( dev);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_device_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dev);
      }
   }
   private efl_input_device_set_delegate efl_input_device_set_static_delegate;


    private delegate Efl.Input.Flags efl_input_event_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern Efl.Input.Flags efl_input_event_flags_get(System.IntPtr obj);
    private static Efl.Input.Flags event_flags_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_event_flags_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Input.Flags _ret_var = default(Efl.Input.Flags);
         try {
            _ret_var = ((Pointer)wrapper).GetEventFlags();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_event_flags_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_event_flags_get_delegate efl_input_event_flags_get_static_delegate;


    private delegate  void efl_input_event_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Flags flags);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_event_flags_set(System.IntPtr obj,   Efl.Input.Flags flags);
    private static  void event_flags_set(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Flags flags)
   {
      Eina.Log.Debug("function efl_input_event_flags_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetEventFlags( flags);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_event_flags_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  flags);
      }
   }
   private efl_input_event_flags_set_delegate efl_input_event_flags_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_processed_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_processed_get(System.IntPtr obj);
    private static bool processed_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_processed_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Pointer)wrapper).GetProcessed();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_processed_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_processed_get_delegate efl_input_processed_get_static_delegate;


    private delegate  void efl_input_processed_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_processed_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    private static  void processed_set(System.IntPtr obj, System.IntPtr pd,  bool val)
   {
      Eina.Log.Debug("function efl_input_processed_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetProcessed( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_processed_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private efl_input_processed_set_delegate efl_input_processed_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_scrolling_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_scrolling_get(System.IntPtr obj);
    private static bool scrolling_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_scrolling_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Pointer)wrapper).GetScrolling();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_scrolling_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_scrolling_get_delegate efl_input_scrolling_get_static_delegate;


    private delegate  void efl_input_scrolling_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_scrolling_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    private static  void scrolling_set(System.IntPtr obj, System.IntPtr pd,  bool val)
   {
      Eina.Log.Debug("function efl_input_scrolling_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Pointer)wrapper).SetScrolling( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_scrolling_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private efl_input_scrolling_set_delegate efl_input_scrolling_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_fake_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_fake_get(System.IntPtr obj);
    private static bool fake_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_fake_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Pointer)wrapper).GetFake();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_fake_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_fake_get_delegate efl_input_fake_get_static_delegate;


    private delegate  void efl_input_reset_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_reset(System.IntPtr obj);
    private static  void reset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_reset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Pointer)wrapper).Reset();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_input_reset(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_reset_delegate efl_input_reset_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_modifier_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_modifier_enabled_get(System.IntPtr obj,   Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    private static bool modifier_enabled_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Modifier mod,  Efl.Input.Device seat)
   {
      Eina.Log.Debug("function efl_input_modifier_enabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Pointer)wrapper).GetModifierEnabled( mod,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_input_modifier_enabled_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mod,  seat);
      }
   }
   private efl_input_modifier_enabled_get_delegate efl_input_modifier_enabled_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_lock_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_lock_enabled_get(System.IntPtr obj,   Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    private static bool lock_enabled_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Lock kw_lock,  Efl.Input.Device seat)
   {
      Eina.Log.Debug("function efl_input_lock_enabled_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Pointer)wrapper).GetLockEnabled( kw_lock,  seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_input_lock_enabled_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_lock,  seat);
      }
   }
   private efl_input_lock_enabled_get_delegate efl_input_lock_enabled_get_static_delegate;
}
} } 
