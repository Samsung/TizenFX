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
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_input_pointer_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public Pointer(Efl.Object parent= null
         ) :
      base(efl_input_pointer_class_get(), typeof(Pointer), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public Pointer(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected Pointer(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
   /// <summary>The action represented by this event.
   /// 1.18</summary>
   /// <returns>Event action
   /// 1.18</returns>
   virtual public Efl.Pointer.Action GetAction() {
       var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_action_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The action represented by this event.
   /// 1.18</summary>
   /// <param name="act">Event action
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetAction( Efl.Pointer.Action act) {
                         Efl.Input.PointerNativeInherit.efl_input_pointer_action_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), act);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary><c>true</c> if this event carries a valid value for the specified <c>key</c>.
   /// 1.18</summary>
   /// <param name="key">Pressed <c>key</c>
   /// 1.18</param>
   /// <returns><c>true</c> if input value is valid, <c>false</c> otherwise
   /// 1.18</returns>
   virtual public bool GetValueHas( Efl.Input.Value key) {
                         var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_value_has_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
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
                         var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_value_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
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
                                           var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_value_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key,  val);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>The mouse button that triggered the event.
   /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button</c>) is <c>true</c>.
   /// 1.18</summary>
   /// <returns>1 to 32, 0 if not a button event.
   /// 1.18</returns>
   virtual public  int GetButton() {
       var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_button_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The mouse button that triggered the event.
   /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button</c>) is <c>true</c>.
   /// 1.18</summary>
   /// <param name="but">1 to 32, 0 if not a button event.
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetButton(  int but) {
                         Efl.Input.PointerNativeInherit.efl_input_pointer_button_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), but);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Whether a mouse button is pressed at the moment of the event.
   /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button_pressed</c>) is <c>true</c>.
   /// 1.18</summary>
   /// <param name="button">1 to 32, 0 if not a button event.
   /// 1.18</param>
   /// <returns><c>true</c> when the button was pressed, <c>false</c> otherwise
   /// 1.18</returns>
   virtual public bool GetButtonPressed(  int button) {
                         var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_button_pressed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), button);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Whether a mouse button is pressed at the moment of the event.
   /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button_pressed</c>) is <c>true</c>.
   /// 1.18</summary>
   /// <param name="button">1 to 32, 0 if not a button event.
   /// 1.18</param>
   /// <param name="pressed"><c>true</c> when the button was pressed, <c>false</c> otherwise
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetButtonPressed(  int button,  bool pressed) {
                                           Efl.Input.PointerNativeInherit.efl_input_pointer_button_pressed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), button,  pressed);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Position where the event happened, relative to the window.
   /// See <see cref="Efl.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).
   /// 1.18</summary>
   /// <returns>The position of the event, in pixels.
   /// 1.18</returns>
   virtual public Eina.Position2D GetPosition() {
       var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
 }
   /// <summary>Position where the event happened, relative to the window.
   /// See <see cref="Efl.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).
   /// 1.18</summary>
   /// <param name="pos">The position of the event, in pixels.
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetPosition( Eina.Position2D pos) {
       var _in_pos = Eina.Position2D_StructConversion.ToInternal(pos);
                  Efl.Input.PointerNativeInherit.efl_input_pointer_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Position where the event happened, relative to the window.
   /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="Efl.Input.Pointer.Position"/>.
   /// 
   /// See also <see cref="Efl.Input.Pointer.Position"/>.
   /// 1.18</summary>
   /// <returns>The position of the event, in pixels.
   /// 1.18</returns>
   virtual public Eina.Vector2 GetPrecisePosition() {
       var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_precise_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Vector2_StructConversion.ToManaged(_ret_var);
 }
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
                  Efl.Input.PointerNativeInherit.efl_input_pointer_precise_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Position of the previous event, valid for move events.
   /// Relative to the window. May be equal to <see cref="Efl.Input.Pointer.Position"/> (by default).
   /// 
   /// This position, in integers, is an approximation of <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_x</c>), <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_y</c>). Use <see cref="Efl.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.
   /// 1.18</summary>
   /// <returns>The position of the event, in pixels.
   /// 1.18</returns>
   virtual public Eina.Position2D GetPreviousPosition() {
       var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_previous_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
 }
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
                  Efl.Input.PointerNativeInherit.efl_input_pointer_previous_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>ID of the tool (eg. pen) that triggered this event.
   /// 1.18</summary>
   /// <returns>Tool ID
   /// 1.18</returns>
   virtual public  int GetTool() {
       var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_tool_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>ID of the tool (eg. pen) that triggered this event.
   /// 1.18</summary>
   /// <param name="id">Tool ID
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetTool(  int id) {
                         Efl.Input.PointerNativeInherit.efl_input_pointer_tool_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), id);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>The object where this event first originated, in case of propagation or repetition of the event.
   /// 1.18</summary>
   /// <returns>Source object: <see cref="Efl.Gfx.Entity"/>
   /// 1.18</returns>
   virtual public Efl.Object GetSource() {
       var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_source_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The object where this event first originated, in case of propagation or repetition of the event.
   /// 1.18</summary>
   /// <param name="src">Source object: <see cref="Efl.Gfx.Entity"/>
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetSource( Efl.Object src) {
                         Efl.Input.PointerNativeInherit.efl_input_pointer_source_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), src);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Double or triple click information.
   /// 1.18</summary>
   /// <returns>Button information flags
   /// 1.18</returns>
   virtual public Efl.Pointer.Flags GetButtonFlags() {
       var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_button_flags_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Double or triple click information.
   /// 1.18</summary>
   /// <param name="flags">Button information flags
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetButtonFlags( Efl.Pointer.Flags flags) {
                         Efl.Input.PointerNativeInherit.efl_input_pointer_button_flags_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), flags);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
   /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.
   /// 1.18</summary>
   /// <returns><c>true</c> if the button press was a double click, <c>false</c> otherwise
   /// 1.18</returns>
   virtual public bool GetDoubleClick() {
       var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_double_click_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
   /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.
   /// 1.18</summary>
   /// <param name="val"><c>true</c> if the button press was a double click, <c>false</c> otherwise
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetDoubleClick( bool val) {
                         Efl.Input.PointerNativeInherit.efl_input_pointer_double_click_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
   /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.
   /// 1.18</summary>
   /// <returns><c>true</c> if the button press was a triple click, <c>false</c> otherwise
   /// 1.18</returns>
   virtual public bool GetTripleClick() {
       var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_triple_click_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
   /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.
   /// 1.18</summary>
   /// <param name="val"><c>true</c> if the button press was a triple click, <c>false</c> otherwise
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetTripleClick( bool val) {
                         Efl.Input.PointerNativeInherit.efl_input_pointer_triple_click_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Direction of the wheel, usually vertical.
   /// 1.18</summary>
   /// <returns>If <c>true</c> this was a horizontal wheel.
   /// 1.18</returns>
   virtual public bool GetWheelHorizontal() {
       var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_wheel_horizontal_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Direction of the wheel, usually vertical.
   /// 1.18</summary>
   /// <param name="horizontal">If <c>true</c> this was a horizontal wheel.
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetWheelHorizontal( bool horizontal) {
                         Efl.Input.PointerNativeInherit.efl_input_pointer_wheel_horizontal_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), horizontal);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Delta movement of the wheel in discrete steps.
   /// 1.18</summary>
   /// <returns>Wheel movement delta
   /// 1.18</returns>
   virtual public  int GetWheelDelta() {
       var _ret_var = Efl.Input.PointerNativeInherit.efl_input_pointer_wheel_delta_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Delta movement of the wheel in discrete steps.
   /// 1.18</summary>
   /// <param name="dist">Wheel movement delta
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetWheelDelta(  int dist) {
                         Efl.Input.PointerNativeInherit.efl_input_pointer_wheel_delta_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dist);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Creates a carbon copy of this object and returns it.
   /// The newly created object will have no event handlers or anything of the sort.</summary>
   /// <returns>Returned carbon copy</returns>
   virtual public Efl.Duplicate DoDuplicate() {
       var _ret_var = Efl.DuplicateNativeInherit.efl_duplicate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>The time at which an event was generated.
   /// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.
   /// 1.19</summary>
   /// <returns>Time in milliseconds when the event happened.
   /// 1.19</returns>
   virtual public double GetTimestamp() {
       var _ret_var = Efl.Input.EventNativeInherit.efl_input_timestamp_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Call this when generating events manually.
   /// 1.19</summary>
   /// <param name="ms">Time in milliseconds when the event happened.
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetTimestamp( double ms) {
                         Efl.Input.EventNativeInherit.efl_input_timestamp_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), ms);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Input device that originated this event.
   /// 1.19</summary>
   /// <returns>Input device origin
   /// 1.19</returns>
   virtual public Efl.Input.Device GetDevice() {
       var _ret_var = Efl.Input.EventNativeInherit.efl_input_device_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Input device that originated this event.
   /// 1.19</summary>
   /// <param name="dev">Input device origin
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetDevice( Efl.Input.Device dev) {
                         Efl.Input.EventNativeInherit.efl_input_device_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dev);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Extra flags for this event, may be changed by the user.
   /// 1.19</summary>
   /// <returns>Input event flags
   /// 1.19</returns>
   virtual public Efl.Input.Flags GetEventFlags() {
       var _ret_var = Efl.Input.EventNativeInherit.efl_input_event_flags_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Extra flags for this event, may be changed by the user.
   /// 1.19</summary>
   /// <param name="flags">Input event flags
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetEventFlags( Efl.Input.Flags flags) {
                         Efl.Input.EventNativeInherit.efl_input_event_flags_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), flags);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary><c>true</c> if <see cref="Efl.Input.Event.EventFlags"/> indicates the event is on hold.
   /// 1.19</summary>
   /// <returns><c>true</c> if the event is on hold, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetProcessed() {
       var _ret_var = Efl.Input.EventNativeInherit.efl_input_processed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary><c>true</c> if <see cref="Efl.Input.Event.EventFlags"/> indicates the event is on hold.
   /// 1.19</summary>
   /// <param name="val"><c>true</c> if the event is on hold, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetProcessed( bool val) {
                         Efl.Input.EventNativeInherit.efl_input_processed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary><c>true</c> if <see cref="Efl.Input.Event.EventFlags"/> indicates the event happened while scrolling.
   /// 1.19</summary>
   /// <returns><c>true</c> if the event happened while scrolling, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetScrolling() {
       var _ret_var = Efl.Input.EventNativeInherit.efl_input_scrolling_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary><c>true</c> if <see cref="Efl.Input.Event.EventFlags"/> indicates the event happened while scrolling.
   /// 1.19</summary>
   /// <param name="val"><c>true</c> if the event happened while scrolling, <c>false</c> otherwise
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetScrolling( bool val) {
                         Efl.Input.EventNativeInherit.efl_input_scrolling_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary><c>true</c> if the event was fake, not triggered by real hardware.
   /// 1.19</summary>
   /// <returns><c>true</c> if the event was not from real hardware, <c>false</c> otherwise
   /// 1.19</returns>
   virtual public bool GetFake() {
       var _ret_var = Efl.Input.EventNativeInherit.efl_input_fake_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Resets the internal data to 0 or default values.
   /// 1.19</summary>
   /// <returns></returns>
   virtual public  void Reset() {
       Efl.Input.EventNativeInherit.efl_input_reset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...</summary>
   /// <param name="mod">The modifier key to test.</param>
   /// <param name="seat">The seat device, may be <c>null</c></param>
   /// <returns><c>true</c> if the key modifier is pressed.</returns>
   virtual public bool GetModifierEnabled( Efl.Input.Modifier mod,  Efl.Input.Device seat) {
                                           var _ret_var = Efl.Input.StateNativeInherit.efl_input_modifier_enabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), mod,  seat);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>Indicates whether a key lock is on, such as NumLock, CapsLock, ...</summary>
   /// <param name="kw_lock">The lock key to test.</param>
   /// <param name="seat">The seat device, may be <c>null</c></param>
   /// <returns><c>true</c> if the key lock is on.</returns>
   virtual public bool GetLockEnabled( Efl.Input.Lock kw_lock,  Efl.Input.Device seat) {
                                           var _ret_var = Efl.Input.StateNativeInherit.efl_input_lock_enabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), kw_lock,  seat);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
   /// <summary>The action represented by this event.
/// 1.18</summary>
/// <value>Event action
/// 1.18</value>
   public Efl.Pointer.Action Action {
      get { return GetAction(); }
      set { SetAction( value); }
   }
   /// <summary>The mouse button that triggered the event.
/// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button</c>) is <c>true</c>.
/// 1.18</summary>
/// <value>1 to 32, 0 if not a button event.
/// 1.18</value>
   public  int Button {
      get { return GetButton(); }
      set { SetButton( value); }
   }
   /// <summary>Position where the event happened, relative to the window.
/// See <see cref="Efl.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).
/// 1.18</summary>
/// <value>The position of the event, in pixels.
/// 1.18</value>
   public Eina.Position2D Position {
      get { return GetPosition(); }
      set { SetPosition( value); }
   }
   /// <summary>Position where the event happened, relative to the window.
/// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="Efl.Input.Pointer.Position"/>.
/// 
/// See also <see cref="Efl.Input.Pointer.Position"/>.
/// 1.18</summary>
/// <value>The position of the event, in pixels.
/// 1.18</value>
   public Eina.Vector2 PrecisePosition {
      get { return GetPrecisePosition(); }
      set { SetPrecisePosition( value); }
   }
   /// <summary>Position of the previous event, valid for move events.
/// Relative to the window. May be equal to <see cref="Efl.Input.Pointer.Position"/> (by default).
/// 
/// This position, in integers, is an approximation of <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_x</c>), <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_y</c>). Use <see cref="Efl.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.
/// 1.18</summary>
/// <value>The position of the event, in pixels.
/// 1.18</value>
   public Eina.Position2D PreviousPosition {
      get { return GetPreviousPosition(); }
      set { SetPreviousPosition( value); }
   }
   /// <summary>ID of the tool (eg. pen) that triggered this event.
/// 1.18</summary>
/// <value>Tool ID
/// 1.18</value>
   public  int Tool {
      get { return GetTool(); }
      set { SetTool( value); }
   }
   /// <summary>The object where this event first originated, in case of propagation or repetition of the event.
/// 1.18</summary>
/// <value>Source object: <see cref="Efl.Gfx.Entity"/>
/// 1.18</value>
   public Efl.Object Source {
      get { return GetSource(); }
      set { SetSource( value); }
   }
   /// <summary>Double or triple click information.
/// 1.18</summary>
/// <value>Button information flags
/// 1.18</value>
   public Efl.Pointer.Flags ButtonFlags {
      get { return GetButtonFlags(); }
      set { SetButtonFlags( value); }
   }
   /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
/// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.
/// 1.18</summary>
/// <value><c>true</c> if the button press was a double click, <c>false</c> otherwise
/// 1.18</value>
   public bool DoubleClick {
      get { return GetDoubleClick(); }
      set { SetDoubleClick( value); }
   }
   /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
/// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.
/// 1.18</summary>
/// <value><c>true</c> if the button press was a triple click, <c>false</c> otherwise
/// 1.18</value>
   public bool TripleClick {
      get { return GetTripleClick(); }
      set { SetTripleClick( value); }
   }
   /// <summary>Direction of the wheel, usually vertical.
/// 1.18</summary>
/// <value>If <c>true</c> this was a horizontal wheel.
/// 1.18</value>
   public bool WheelHorizontal {
      get { return GetWheelHorizontal(); }
      set { SetWheelHorizontal( value); }
   }
   /// <summary>Delta movement of the wheel in discrete steps.
/// 1.18</summary>
/// <value>Wheel movement delta
/// 1.18</value>
   public  int WheelDelta {
      get { return GetWheelDelta(); }
      set { SetWheelDelta( value); }
   }
   /// <summary>The time at which an event was generated.
/// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.
/// 1.19</summary>
/// <value>Time in milliseconds when the event happened.
/// 1.19</value>
   public double Timestamp {
      get { return GetTimestamp(); }
      set { SetTimestamp( value); }
   }
   /// <summary>Input device that originated this event.
/// 1.19</summary>
/// <value>Input device origin
/// 1.19</value>
   public Efl.Input.Device Device {
      get { return GetDevice(); }
      set { SetDevice( value); }
   }
   /// <summary>Extra flags for this event, may be changed by the user.
/// 1.19</summary>
/// <value>Input event flags
/// 1.19</value>
   public Efl.Input.Flags EventFlags {
      get { return GetEventFlags(); }
      set { SetEventFlags( value); }
   }
   /// <summary><c>true</c> if <see cref="Efl.Input.Event.EventFlags"/> indicates the event is on hold.
/// 1.19</summary>
/// <value><c>true</c> if the event is on hold, <c>false</c> otherwise
/// 1.19</value>
   public bool Processed {
      get { return GetProcessed(); }
      set { SetProcessed( value); }
   }
   /// <summary><c>true</c> if <see cref="Efl.Input.Event.EventFlags"/> indicates the event happened while scrolling.
/// 1.19</summary>
/// <value><c>true</c> if the event happened while scrolling, <c>false</c> otherwise
/// 1.19</value>
   public bool Scrolling {
      get { return GetScrolling(); }
      set { SetScrolling( value); }
   }
   /// <summary><c>true</c> if the event was fake, not triggered by real hardware.
/// 1.19</summary>
/// <value><c>true</c> if the event was not from real hardware, <c>false</c> otherwise
/// 1.19</value>
   public bool Fake {
      get { return GetFake(); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Input.Pointer.efl_input_pointer_class_get();
   }
}
public class PointerNativeInherit : Efl.ObjectNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_input_pointer_action_get_static_delegate == null)
      efl_input_pointer_action_get_static_delegate = new efl_input_pointer_action_get_delegate(action_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_action_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_action_get_static_delegate)});
      if (efl_input_pointer_action_set_static_delegate == null)
      efl_input_pointer_action_set_static_delegate = new efl_input_pointer_action_set_delegate(action_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_action_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_action_set_static_delegate)});
      if (efl_input_pointer_value_has_get_static_delegate == null)
      efl_input_pointer_value_has_get_static_delegate = new efl_input_pointer_value_has_get_delegate(value_has_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_value_has_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_value_has_get_static_delegate)});
      if (efl_input_pointer_value_get_static_delegate == null)
      efl_input_pointer_value_get_static_delegate = new efl_input_pointer_value_get_delegate(value_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_value_get_static_delegate)});
      if (efl_input_pointer_value_set_static_delegate == null)
      efl_input_pointer_value_set_static_delegate = new efl_input_pointer_value_set_delegate(value_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_value_set_static_delegate)});
      if (efl_input_pointer_button_get_static_delegate == null)
      efl_input_pointer_button_get_static_delegate = new efl_input_pointer_button_get_delegate(button_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_button_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_get_static_delegate)});
      if (efl_input_pointer_button_set_static_delegate == null)
      efl_input_pointer_button_set_static_delegate = new efl_input_pointer_button_set_delegate(button_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_button_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_set_static_delegate)});
      if (efl_input_pointer_button_pressed_get_static_delegate == null)
      efl_input_pointer_button_pressed_get_static_delegate = new efl_input_pointer_button_pressed_get_delegate(button_pressed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_button_pressed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_pressed_get_static_delegate)});
      if (efl_input_pointer_button_pressed_set_static_delegate == null)
      efl_input_pointer_button_pressed_set_static_delegate = new efl_input_pointer_button_pressed_set_delegate(button_pressed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_button_pressed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_pressed_set_static_delegate)});
      if (efl_input_pointer_position_get_static_delegate == null)
      efl_input_pointer_position_get_static_delegate = new efl_input_pointer_position_get_delegate(position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_position_get_static_delegate)});
      if (efl_input_pointer_position_set_static_delegate == null)
      efl_input_pointer_position_set_static_delegate = new efl_input_pointer_position_set_delegate(position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_position_set_static_delegate)});
      if (efl_input_pointer_precise_position_get_static_delegate == null)
      efl_input_pointer_precise_position_get_static_delegate = new efl_input_pointer_precise_position_get_delegate(precise_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_precise_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_precise_position_get_static_delegate)});
      if (efl_input_pointer_precise_position_set_static_delegate == null)
      efl_input_pointer_precise_position_set_static_delegate = new efl_input_pointer_precise_position_set_delegate(precise_position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_precise_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_precise_position_set_static_delegate)});
      if (efl_input_pointer_previous_position_get_static_delegate == null)
      efl_input_pointer_previous_position_get_static_delegate = new efl_input_pointer_previous_position_get_delegate(previous_position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_previous_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_previous_position_get_static_delegate)});
      if (efl_input_pointer_previous_position_set_static_delegate == null)
      efl_input_pointer_previous_position_set_static_delegate = new efl_input_pointer_previous_position_set_delegate(previous_position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_previous_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_previous_position_set_static_delegate)});
      if (efl_input_pointer_tool_get_static_delegate == null)
      efl_input_pointer_tool_get_static_delegate = new efl_input_pointer_tool_get_delegate(tool_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_tool_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_tool_get_static_delegate)});
      if (efl_input_pointer_tool_set_static_delegate == null)
      efl_input_pointer_tool_set_static_delegate = new efl_input_pointer_tool_set_delegate(tool_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_tool_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_tool_set_static_delegate)});
      if (efl_input_pointer_source_get_static_delegate == null)
      efl_input_pointer_source_get_static_delegate = new efl_input_pointer_source_get_delegate(source_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_source_get_static_delegate)});
      if (efl_input_pointer_source_set_static_delegate == null)
      efl_input_pointer_source_set_static_delegate = new efl_input_pointer_source_set_delegate(source_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_source_set_static_delegate)});
      if (efl_input_pointer_button_flags_get_static_delegate == null)
      efl_input_pointer_button_flags_get_static_delegate = new efl_input_pointer_button_flags_get_delegate(button_flags_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_button_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_flags_get_static_delegate)});
      if (efl_input_pointer_button_flags_set_static_delegate == null)
      efl_input_pointer_button_flags_set_static_delegate = new efl_input_pointer_button_flags_set_delegate(button_flags_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_button_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_flags_set_static_delegate)});
      if (efl_input_pointer_double_click_get_static_delegate == null)
      efl_input_pointer_double_click_get_static_delegate = new efl_input_pointer_double_click_get_delegate(double_click_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_double_click_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_double_click_get_static_delegate)});
      if (efl_input_pointer_double_click_set_static_delegate == null)
      efl_input_pointer_double_click_set_static_delegate = new efl_input_pointer_double_click_set_delegate(double_click_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_double_click_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_double_click_set_static_delegate)});
      if (efl_input_pointer_triple_click_get_static_delegate == null)
      efl_input_pointer_triple_click_get_static_delegate = new efl_input_pointer_triple_click_get_delegate(triple_click_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_triple_click_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_triple_click_get_static_delegate)});
      if (efl_input_pointer_triple_click_set_static_delegate == null)
      efl_input_pointer_triple_click_set_static_delegate = new efl_input_pointer_triple_click_set_delegate(triple_click_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_triple_click_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_triple_click_set_static_delegate)});
      if (efl_input_pointer_wheel_horizontal_get_static_delegate == null)
      efl_input_pointer_wheel_horizontal_get_static_delegate = new efl_input_pointer_wheel_horizontal_get_delegate(wheel_horizontal_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_wheel_horizontal_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_horizontal_get_static_delegate)});
      if (efl_input_pointer_wheel_horizontal_set_static_delegate == null)
      efl_input_pointer_wheel_horizontal_set_static_delegate = new efl_input_pointer_wheel_horizontal_set_delegate(wheel_horizontal_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_wheel_horizontal_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_horizontal_set_static_delegate)});
      if (efl_input_pointer_wheel_delta_get_static_delegate == null)
      efl_input_pointer_wheel_delta_get_static_delegate = new efl_input_pointer_wheel_delta_get_delegate(wheel_delta_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_wheel_delta_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_delta_get_static_delegate)});
      if (efl_input_pointer_wheel_delta_set_static_delegate == null)
      efl_input_pointer_wheel_delta_set_static_delegate = new efl_input_pointer_wheel_delta_set_delegate(wheel_delta_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_pointer_wheel_delta_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_delta_set_static_delegate)});
      if (efl_duplicate_static_delegate == null)
      efl_duplicate_static_delegate = new efl_duplicate_delegate(duplicate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_duplicate"), func = Marshal.GetFunctionPointerForDelegate(efl_duplicate_static_delegate)});
      if (efl_input_timestamp_get_static_delegate == null)
      efl_input_timestamp_get_static_delegate = new efl_input_timestamp_get_delegate(timestamp_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_timestamp_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_timestamp_get_static_delegate)});
      if (efl_input_timestamp_set_static_delegate == null)
      efl_input_timestamp_set_static_delegate = new efl_input_timestamp_set_delegate(timestamp_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_timestamp_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_timestamp_set_static_delegate)});
      if (efl_input_device_get_static_delegate == null)
      efl_input_device_get_static_delegate = new efl_input_device_get_delegate(device_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_device_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_get_static_delegate)});
      if (efl_input_device_set_static_delegate == null)
      efl_input_device_set_static_delegate = new efl_input_device_set_delegate(device_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_device_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_set_static_delegate)});
      if (efl_input_event_flags_get_static_delegate == null)
      efl_input_event_flags_get_static_delegate = new efl_input_event_flags_get_delegate(event_flags_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_event_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_event_flags_get_static_delegate)});
      if (efl_input_event_flags_set_static_delegate == null)
      efl_input_event_flags_set_static_delegate = new efl_input_event_flags_set_delegate(event_flags_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_event_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_event_flags_set_static_delegate)});
      if (efl_input_processed_get_static_delegate == null)
      efl_input_processed_get_static_delegate = new efl_input_processed_get_delegate(processed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_processed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_processed_get_static_delegate)});
      if (efl_input_processed_set_static_delegate == null)
      efl_input_processed_set_static_delegate = new efl_input_processed_set_delegate(processed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_processed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_processed_set_static_delegate)});
      if (efl_input_scrolling_get_static_delegate == null)
      efl_input_scrolling_get_static_delegate = new efl_input_scrolling_get_delegate(scrolling_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_scrolling_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_scrolling_get_static_delegate)});
      if (efl_input_scrolling_set_static_delegate == null)
      efl_input_scrolling_set_static_delegate = new efl_input_scrolling_set_delegate(scrolling_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_scrolling_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_scrolling_set_static_delegate)});
      if (efl_input_fake_get_static_delegate == null)
      efl_input_fake_get_static_delegate = new efl_input_fake_get_delegate(fake_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_fake_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_fake_get_static_delegate)});
      if (efl_input_reset_static_delegate == null)
      efl_input_reset_static_delegate = new efl_input_reset_delegate(reset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_input_reset_static_delegate)});
      if (efl_input_modifier_enabled_get_static_delegate == null)
      efl_input_modifier_enabled_get_static_delegate = new efl_input_modifier_enabled_get_delegate(modifier_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_modifier_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_modifier_enabled_get_static_delegate)});
      if (efl_input_lock_enabled_get_static_delegate == null)
      efl_input_lock_enabled_get_static_delegate = new efl_input_lock_enabled_get_delegate(lock_enabled_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_lock_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_lock_enabled_get_static_delegate)});
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


    public delegate Efl.Pointer.Action efl_input_pointer_action_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_action_get_api_delegate> efl_input_pointer_action_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_action_get_api_delegate>(_Module, "efl_input_pointer_action_get");
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
         return efl_input_pointer_action_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_pointer_action_get_delegate efl_input_pointer_action_get_static_delegate;


    private delegate  void efl_input_pointer_action_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Pointer.Action act);


    public delegate  void efl_input_pointer_action_set_api_delegate(System.IntPtr obj,   Efl.Pointer.Action act);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_action_set_api_delegate> efl_input_pointer_action_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_action_set_api_delegate>(_Module, "efl_input_pointer_action_set");
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
         efl_input_pointer_action_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  act);
      }
   }
   private static efl_input_pointer_action_set_delegate efl_input_pointer_action_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_pointer_value_has_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Value key);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_pointer_value_has_get_api_delegate(System.IntPtr obj,   Efl.Input.Value key);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_value_has_get_api_delegate> efl_input_pointer_value_has_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_value_has_get_api_delegate>(_Module, "efl_input_pointer_value_has_get");
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
         return efl_input_pointer_value_has_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
      }
   }
   private static efl_input_pointer_value_has_get_delegate efl_input_pointer_value_has_get_static_delegate;


    private delegate double efl_input_pointer_value_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Value key);


    public delegate double efl_input_pointer_value_get_api_delegate(System.IntPtr obj,   Efl.Input.Value key);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_value_get_api_delegate> efl_input_pointer_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_value_get_api_delegate>(_Module, "efl_input_pointer_value_get");
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
         return efl_input_pointer_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
      }
   }
   private static efl_input_pointer_value_get_delegate efl_input_pointer_value_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_pointer_value_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Value key,   double val);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_pointer_value_set_api_delegate(System.IntPtr obj,   Efl.Input.Value key,   double val);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_value_set_api_delegate> efl_input_pointer_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_value_set_api_delegate>(_Module, "efl_input_pointer_value_set");
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
         return efl_input_pointer_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key,  val);
      }
   }
   private static efl_input_pointer_value_set_delegate efl_input_pointer_value_set_static_delegate;


    private delegate  int efl_input_pointer_button_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_input_pointer_button_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_button_get_api_delegate> efl_input_pointer_button_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_button_get_api_delegate>(_Module, "efl_input_pointer_button_get");
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
         return efl_input_pointer_button_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_pointer_button_get_delegate efl_input_pointer_button_get_static_delegate;


    private delegate  void efl_input_pointer_button_set_delegate(System.IntPtr obj, System.IntPtr pd,    int but);


    public delegate  void efl_input_pointer_button_set_api_delegate(System.IntPtr obj,    int but);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_button_set_api_delegate> efl_input_pointer_button_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_button_set_api_delegate>(_Module, "efl_input_pointer_button_set");
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
         efl_input_pointer_button_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  but);
      }
   }
   private static efl_input_pointer_button_set_delegate efl_input_pointer_button_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_pointer_button_pressed_get_delegate(System.IntPtr obj, System.IntPtr pd,    int button);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_pointer_button_pressed_get_api_delegate(System.IntPtr obj,    int button);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_button_pressed_get_api_delegate> efl_input_pointer_button_pressed_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_button_pressed_get_api_delegate>(_Module, "efl_input_pointer_button_pressed_get");
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
         return efl_input_pointer_button_pressed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  button);
      }
   }
   private static efl_input_pointer_button_pressed_get_delegate efl_input_pointer_button_pressed_get_static_delegate;


    private delegate  void efl_input_pointer_button_pressed_set_delegate(System.IntPtr obj, System.IntPtr pd,    int button,  [MarshalAs(UnmanagedType.U1)]  bool pressed);


    public delegate  void efl_input_pointer_button_pressed_set_api_delegate(System.IntPtr obj,    int button,  [MarshalAs(UnmanagedType.U1)]  bool pressed);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_button_pressed_set_api_delegate> efl_input_pointer_button_pressed_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_button_pressed_set_api_delegate>(_Module, "efl_input_pointer_button_pressed_set");
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
         efl_input_pointer_button_pressed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  button,  pressed);
      }
   }
   private static efl_input_pointer_button_pressed_set_delegate efl_input_pointer_button_pressed_set_static_delegate;


    private delegate Eina.Position2D_StructInternal efl_input_pointer_position_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Position2D_StructInternal efl_input_pointer_position_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_position_get_api_delegate> efl_input_pointer_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_position_get_api_delegate>(_Module, "efl_input_pointer_position_get");
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
         return efl_input_pointer_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_pointer_position_get_delegate efl_input_pointer_position_get_static_delegate;


    private delegate  void efl_input_pointer_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal pos);


    public delegate  void efl_input_pointer_position_set_api_delegate(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_position_set_api_delegate> efl_input_pointer_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_position_set_api_delegate>(_Module, "efl_input_pointer_position_set");
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
         efl_input_pointer_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
      }
   }
   private static efl_input_pointer_position_set_delegate efl_input_pointer_position_set_static_delegate;


    private delegate Eina.Vector2_StructInternal efl_input_pointer_precise_position_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Vector2_StructInternal efl_input_pointer_precise_position_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_precise_position_get_api_delegate> efl_input_pointer_precise_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_precise_position_get_api_delegate>(_Module, "efl_input_pointer_precise_position_get");
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
         return efl_input_pointer_precise_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_pointer_precise_position_get_delegate efl_input_pointer_precise_position_get_static_delegate;


    private delegate  void efl_input_pointer_precise_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Vector2_StructInternal pos);


    public delegate  void efl_input_pointer_precise_position_set_api_delegate(System.IntPtr obj,   Eina.Vector2_StructInternal pos);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_precise_position_set_api_delegate> efl_input_pointer_precise_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_precise_position_set_api_delegate>(_Module, "efl_input_pointer_precise_position_set");
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
         efl_input_pointer_precise_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
      }
   }
   private static efl_input_pointer_precise_position_set_delegate efl_input_pointer_precise_position_set_static_delegate;


    private delegate Eina.Position2D_StructInternal efl_input_pointer_previous_position_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.Position2D_StructInternal efl_input_pointer_previous_position_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_previous_position_get_api_delegate> efl_input_pointer_previous_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_previous_position_get_api_delegate>(_Module, "efl_input_pointer_previous_position_get");
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
         return efl_input_pointer_previous_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_pointer_previous_position_get_delegate efl_input_pointer_previous_position_get_static_delegate;


    private delegate  void efl_input_pointer_previous_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal pos);


    public delegate  void efl_input_pointer_previous_position_set_api_delegate(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_previous_position_set_api_delegate> efl_input_pointer_previous_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_previous_position_set_api_delegate>(_Module, "efl_input_pointer_previous_position_set");
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
         efl_input_pointer_previous_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
      }
   }
   private static efl_input_pointer_previous_position_set_delegate efl_input_pointer_previous_position_set_static_delegate;


    private delegate  int efl_input_pointer_tool_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_input_pointer_tool_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_tool_get_api_delegate> efl_input_pointer_tool_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_tool_get_api_delegate>(_Module, "efl_input_pointer_tool_get");
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
         return efl_input_pointer_tool_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_pointer_tool_get_delegate efl_input_pointer_tool_get_static_delegate;


    private delegate  void efl_input_pointer_tool_set_delegate(System.IntPtr obj, System.IntPtr pd,    int id);


    public delegate  void efl_input_pointer_tool_set_api_delegate(System.IntPtr obj,    int id);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_tool_set_api_delegate> efl_input_pointer_tool_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_tool_set_api_delegate>(_Module, "efl_input_pointer_tool_set");
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
         efl_input_pointer_tool_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private static efl_input_pointer_tool_set_delegate efl_input_pointer_tool_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Object efl_input_pointer_source_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Object efl_input_pointer_source_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_source_get_api_delegate> efl_input_pointer_source_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_source_get_api_delegate>(_Module, "efl_input_pointer_source_get");
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
         return efl_input_pointer_source_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_pointer_source_get_delegate efl_input_pointer_source_get_static_delegate;


    private delegate  void efl_input_pointer_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object src);


    public delegate  void efl_input_pointer_source_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object src);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_source_set_api_delegate> efl_input_pointer_source_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_source_set_api_delegate>(_Module, "efl_input_pointer_source_set");
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
         efl_input_pointer_source_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  src);
      }
   }
   private static efl_input_pointer_source_set_delegate efl_input_pointer_source_set_static_delegate;


    private delegate Efl.Pointer.Flags efl_input_pointer_button_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Pointer.Flags efl_input_pointer_button_flags_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_button_flags_get_api_delegate> efl_input_pointer_button_flags_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_button_flags_get_api_delegate>(_Module, "efl_input_pointer_button_flags_get");
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
         return efl_input_pointer_button_flags_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_pointer_button_flags_get_delegate efl_input_pointer_button_flags_get_static_delegate;


    private delegate  void efl_input_pointer_button_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Pointer.Flags flags);


    public delegate  void efl_input_pointer_button_flags_set_api_delegate(System.IntPtr obj,   Efl.Pointer.Flags flags);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_button_flags_set_api_delegate> efl_input_pointer_button_flags_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_button_flags_set_api_delegate>(_Module, "efl_input_pointer_button_flags_set");
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
         efl_input_pointer_button_flags_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  flags);
      }
   }
   private static efl_input_pointer_button_flags_set_delegate efl_input_pointer_button_flags_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_pointer_double_click_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_pointer_double_click_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_double_click_get_api_delegate> efl_input_pointer_double_click_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_double_click_get_api_delegate>(_Module, "efl_input_pointer_double_click_get");
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
         return efl_input_pointer_double_click_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_pointer_double_click_get_delegate efl_input_pointer_double_click_get_static_delegate;


    private delegate  void efl_input_pointer_double_click_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);


    public delegate  void efl_input_pointer_double_click_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_double_click_set_api_delegate> efl_input_pointer_double_click_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_double_click_set_api_delegate>(_Module, "efl_input_pointer_double_click_set");
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
         efl_input_pointer_double_click_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private static efl_input_pointer_double_click_set_delegate efl_input_pointer_double_click_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_pointer_triple_click_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_pointer_triple_click_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_triple_click_get_api_delegate> efl_input_pointer_triple_click_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_triple_click_get_api_delegate>(_Module, "efl_input_pointer_triple_click_get");
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
         return efl_input_pointer_triple_click_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_pointer_triple_click_get_delegate efl_input_pointer_triple_click_get_static_delegate;


    private delegate  void efl_input_pointer_triple_click_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);


    public delegate  void efl_input_pointer_triple_click_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_triple_click_set_api_delegate> efl_input_pointer_triple_click_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_triple_click_set_api_delegate>(_Module, "efl_input_pointer_triple_click_set");
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
         efl_input_pointer_triple_click_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private static efl_input_pointer_triple_click_set_delegate efl_input_pointer_triple_click_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_pointer_wheel_horizontal_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_pointer_wheel_horizontal_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_horizontal_get_api_delegate> efl_input_pointer_wheel_horizontal_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_horizontal_get_api_delegate>(_Module, "efl_input_pointer_wheel_horizontal_get");
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
         return efl_input_pointer_wheel_horizontal_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_pointer_wheel_horizontal_get_delegate efl_input_pointer_wheel_horizontal_get_static_delegate;


    private delegate  void efl_input_pointer_wheel_horizontal_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool horizontal);


    public delegate  void efl_input_pointer_wheel_horizontal_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool horizontal);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_horizontal_set_api_delegate> efl_input_pointer_wheel_horizontal_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_horizontal_set_api_delegate>(_Module, "efl_input_pointer_wheel_horizontal_set");
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
         efl_input_pointer_wheel_horizontal_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  horizontal);
      }
   }
   private static efl_input_pointer_wheel_horizontal_set_delegate efl_input_pointer_wheel_horizontal_set_static_delegate;


    private delegate  int efl_input_pointer_wheel_delta_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  int efl_input_pointer_wheel_delta_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_delta_get_api_delegate> efl_input_pointer_wheel_delta_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_delta_get_api_delegate>(_Module, "efl_input_pointer_wheel_delta_get");
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
         return efl_input_pointer_wheel_delta_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_pointer_wheel_delta_get_delegate efl_input_pointer_wheel_delta_get_static_delegate;


    private delegate  void efl_input_pointer_wheel_delta_set_delegate(System.IntPtr obj, System.IntPtr pd,    int dist);


    public delegate  void efl_input_pointer_wheel_delta_set_api_delegate(System.IntPtr obj,    int dist);
    public static Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_delta_set_api_delegate> efl_input_pointer_wheel_delta_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_delta_set_api_delegate>(_Module, "efl_input_pointer_wheel_delta_set");
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
         efl_input_pointer_wheel_delta_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dist);
      }
   }
   private static efl_input_pointer_wheel_delta_set_delegate efl_input_pointer_wheel_delta_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.DuplicateConcrete, Efl.Eo.OwnTag>))] private delegate Efl.Duplicate efl_duplicate_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.DuplicateConcrete, Efl.Eo.OwnTag>))] public delegate Efl.Duplicate efl_duplicate_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_duplicate_api_delegate> efl_duplicate_ptr = new Efl.Eo.FunctionWrapper<efl_duplicate_api_delegate>(_Module, "efl_duplicate");
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
         return efl_duplicate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_duplicate_delegate efl_duplicate_static_delegate;


    private delegate double efl_input_timestamp_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_input_timestamp_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_timestamp_get_api_delegate> efl_input_timestamp_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_timestamp_get_api_delegate>(_Module, "efl_input_timestamp_get");
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
         return efl_input_timestamp_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_timestamp_get_delegate efl_input_timestamp_get_static_delegate;


    private delegate  void efl_input_timestamp_set_delegate(System.IntPtr obj, System.IntPtr pd,   double ms);


    public delegate  void efl_input_timestamp_set_api_delegate(System.IntPtr obj,   double ms);
    public static Efl.Eo.FunctionWrapper<efl_input_timestamp_set_api_delegate> efl_input_timestamp_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_timestamp_set_api_delegate>(_Module, "efl_input_timestamp_set");
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
         efl_input_timestamp_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  ms);
      }
   }
   private static efl_input_timestamp_set_delegate efl_input_timestamp_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private delegate Efl.Input.Device efl_input_device_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] public delegate Efl.Input.Device efl_input_device_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_device_get_api_delegate> efl_input_device_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_device_get_api_delegate>(_Module, "efl_input_device_get");
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
         return efl_input_device_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_device_get_delegate efl_input_device_get_static_delegate;


    private delegate  void efl_input_device_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev);


    public delegate  void efl_input_device_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev);
    public static Efl.Eo.FunctionWrapper<efl_input_device_set_api_delegate> efl_input_device_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_device_set_api_delegate>(_Module, "efl_input_device_set");
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
         efl_input_device_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dev);
      }
   }
   private static efl_input_device_set_delegate efl_input_device_set_static_delegate;


    private delegate Efl.Input.Flags efl_input_event_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Efl.Input.Flags efl_input_event_flags_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_event_flags_get_api_delegate> efl_input_event_flags_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_event_flags_get_api_delegate>(_Module, "efl_input_event_flags_get");
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
         return efl_input_event_flags_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_event_flags_get_delegate efl_input_event_flags_get_static_delegate;


    private delegate  void efl_input_event_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Flags flags);


    public delegate  void efl_input_event_flags_set_api_delegate(System.IntPtr obj,   Efl.Input.Flags flags);
    public static Efl.Eo.FunctionWrapper<efl_input_event_flags_set_api_delegate> efl_input_event_flags_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_event_flags_set_api_delegate>(_Module, "efl_input_event_flags_set");
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
         efl_input_event_flags_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  flags);
      }
   }
   private static efl_input_event_flags_set_delegate efl_input_event_flags_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_processed_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_processed_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_processed_get_api_delegate> efl_input_processed_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_processed_get_api_delegate>(_Module, "efl_input_processed_get");
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
         return efl_input_processed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_processed_get_delegate efl_input_processed_get_static_delegate;


    private delegate  void efl_input_processed_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);


    public delegate  void efl_input_processed_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    public static Efl.Eo.FunctionWrapper<efl_input_processed_set_api_delegate> efl_input_processed_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_processed_set_api_delegate>(_Module, "efl_input_processed_set");
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
         efl_input_processed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private static efl_input_processed_set_delegate efl_input_processed_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_scrolling_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_scrolling_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_scrolling_get_api_delegate> efl_input_scrolling_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_scrolling_get_api_delegate>(_Module, "efl_input_scrolling_get");
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
         return efl_input_scrolling_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_scrolling_get_delegate efl_input_scrolling_get_static_delegate;


    private delegate  void efl_input_scrolling_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);


    public delegate  void efl_input_scrolling_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    public static Efl.Eo.FunctionWrapper<efl_input_scrolling_set_api_delegate> efl_input_scrolling_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_scrolling_set_api_delegate>(_Module, "efl_input_scrolling_set");
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
         efl_input_scrolling_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private static efl_input_scrolling_set_delegate efl_input_scrolling_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_fake_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_fake_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_fake_get_api_delegate> efl_input_fake_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_fake_get_api_delegate>(_Module, "efl_input_fake_get");
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
         return efl_input_fake_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_fake_get_delegate efl_input_fake_get_static_delegate;


    private delegate  void efl_input_reset_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_input_reset_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_input_reset_api_delegate> efl_input_reset_ptr = new Efl.Eo.FunctionWrapper<efl_input_reset_api_delegate>(_Module, "efl_input_reset");
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
         efl_input_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_input_reset_delegate efl_input_reset_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_modifier_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_modifier_enabled_get_api_delegate(System.IntPtr obj,   Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    public static Efl.Eo.FunctionWrapper<efl_input_modifier_enabled_get_api_delegate> efl_input_modifier_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_modifier_enabled_get_api_delegate>(_Module, "efl_input_modifier_enabled_get");
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
         return efl_input_modifier_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mod,  seat);
      }
   }
   private static efl_input_modifier_enabled_get_delegate efl_input_modifier_enabled_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_lock_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_lock_enabled_get_api_delegate(System.IntPtr obj,   Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    public static Efl.Eo.FunctionWrapper<efl_input_lock_enabled_get_api_delegate> efl_input_lock_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_lock_enabled_get_api_delegate>(_Module, "efl_input_lock_enabled_get");
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
         return efl_input_lock_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_lock,  seat);
      }
   }
   private static efl_input_lock_enabled_get_delegate efl_input_lock_enabled_get_static_delegate;
}
} } 
