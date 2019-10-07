#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Input {

/// <summary>Event data carried over with any pointer event (mouse, touch, pen, ...)</summary>
[Efl.Input.Pointer.NativeMethods]
[Efl.Eo.BindingEntity]
public class Pointer : Efl.Object, Efl.IDuplicate, Efl.Input.IEvent, Efl.Input.IState
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Pointer))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_input_pointer_class_get();

    /// <summary>Initializes a new instance of the <see cref="Pointer"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Pointer(Efl.Object parent= null
            ) : base(efl_input_pointer_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Pointer(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Pointer"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Pointer(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Pointer"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Pointer(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>The action represented by this event.</summary>
    /// <returns>Event action</returns>
    public virtual Efl.Pointer.Action GetAction() {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_action_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The action represented by this event.</summary>
    /// <param name="act">Event action</param>
    public virtual void SetAction(Efl.Pointer.Action act) {
        Efl.Input.Pointer.NativeMethods.efl_input_pointer_action_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),act);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary><c>true</c> if this event carries a valid value for the specified <c>key</c>.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="key">Pressed <c>key</c></param>
    /// <returns><c>true</c> if input value is valid, <c>false</c> otherwise</returns>
    public virtual bool GetValueHas(Efl.Input.Value key) {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_value_has_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Represents a generic value for this event.
    /// Refer to the documentation of <see cref="Efl.Input.Value"/> for each value&apos;s meaning, type and range. Call <see cref="Efl.Input.Pointer.GetValueHas"/> to determine whether the returned value is valid or not for this event.
    /// 
    /// Most values are precise floating point values, usually in pixels, radians, or in a range of [-1, 1] or [0, 1]. Some values are discrete values (integers) and thus should preferably be queried with the other methods of this class.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="key"><c>key</c></param>
    /// <returns><c>key</c> value</returns>
    public virtual double GetValue(Efl.Input.Value key) {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Represents a generic value for this event.
    /// Refer to the documentation of <see cref="Efl.Input.Value"/> for each value&apos;s meaning, type and range. Call <see cref="Efl.Input.Pointer.GetValueHas"/> to determine whether the returned value is valid or not for this event.
    /// 
    /// Most values are precise floating point values, usually in pixels, radians, or in a range of [-1, 1] or [0, 1]. Some values are discrete values (integers) and thus should preferably be queried with the other methods of this class.
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="key"><c>key</c></param>
    /// <param name="val"><c>key</c> value</param>
    /// <returns><c>false</c> if the value could not be set.</returns>
    public virtual bool SetValue(Efl.Input.Value key, double val) {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_value_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key, val);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The mouse button that triggered the event.
    /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button</c>) is <c>true</c>.</summary>
    /// <returns>1 to 32, 0 if not a button event.</returns>
    public virtual int GetButton() {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_button_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The mouse button that triggered the event.
    /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button</c>) is <c>true</c>.</summary>
    /// <param name="but">1 to 32, 0 if not a button event.</param>
    public virtual void SetButton(int but) {
        Efl.Input.Pointer.NativeMethods.efl_input_pointer_button_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),but);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Whether a mouse button is pressed at the moment of the event.
    /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button_pressed</c>) is <c>true</c>.</summary>
    /// <param name="button">1 to 32, 0 if not a button event.</param>
    /// <returns><c>true</c> when the button was pressed, <c>false</c> otherwise</returns>
    public virtual bool GetButtonPressed(int button) {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_button_pressed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Whether a mouse button is pressed at the moment of the event.
    /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button_pressed</c>) is <c>true</c>.</summary>
    /// <param name="button">1 to 32, 0 if not a button event.</param>
    /// <param name="pressed"><c>true</c> when the button was pressed, <c>false</c> otherwise</param>
    public virtual void SetButtonPressed(int button, bool pressed) {
        Efl.Input.Pointer.NativeMethods.efl_input_pointer_button_pressed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),button, pressed);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Position where the event happened, relative to the window.
    /// See <see cref="Efl.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).</summary>
    /// <returns>The position of the event, in pixels.</returns>
    public virtual Eina.Position2D GetPosition() {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Position where the event happened, relative to the window.
    /// See <see cref="Efl.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).</summary>
    /// <param name="pos">The position of the event, in pixels.</param>
    public virtual void SetPosition(Eina.Position2D pos) {
        Eina.Position2D.NativeStruct _in_pos = pos;
Efl.Input.Pointer.NativeMethods.efl_input_pointer_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Position where the event happened, relative to the window.
    /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="Efl.Input.Pointer.Position"/>.
    /// 
    /// See also <see cref="Efl.Input.Pointer.Position"/>.</summary>
    /// <returns>The position of the event, in pixels.</returns>
    public virtual Eina.Vector2 GetPrecisePosition() {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_precise_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Position where the event happened, relative to the window.
    /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="Efl.Input.Pointer.Position"/>.
    /// 
    /// See also <see cref="Efl.Input.Pointer.Position"/>.</summary>
    /// <param name="pos">The position of the event, in pixels.</param>
    public virtual void SetPrecisePosition(Eina.Vector2 pos) {
        Eina.Vector2.NativeStruct _in_pos = pos;
Efl.Input.Pointer.NativeMethods.efl_input_pointer_precise_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Position of the previous event, valid for move events.
    /// Relative to the window. May be equal to <see cref="Efl.Input.Pointer.Position"/> (by default).
    /// 
    /// This position, in integers, is an approximation of <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_x</c>), <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_y</c>). Use <see cref="Efl.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.</summary>
    /// <returns>The position of the event, in pixels.</returns>
    public virtual Eina.Position2D GetPreviousPosition() {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_previous_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Position of the previous event, valid for move events.
    /// Relative to the window. May be equal to <see cref="Efl.Input.Pointer.Position"/> (by default).
    /// 
    /// This position, in integers, is an approximation of <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_x</c>), <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_y</c>). Use <see cref="Efl.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.</summary>
    /// <param name="pos">The position of the event, in pixels.</param>
    public virtual void SetPreviousPosition(Eina.Position2D pos) {
        Eina.Position2D.NativeStruct _in_pos = pos;
Efl.Input.Pointer.NativeMethods.efl_input_pointer_previous_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The ID associated with this pointer.
    /// In case there are multiple pointers (for example when multiple fingers are touching the screen) this number uniquely identifies each pointer, for as long as it is present. This is, when a finger is lifted its ID can be later reused by another finger touching the screen.</summary>
    /// <returns>An ID uniquely identifying this pointer among the currently present pointers.</returns>
    public virtual int GetTouchId() {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_touch_id_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The ID associated with this pointer.
    /// In case there are multiple pointers (for example when multiple fingers are touching the screen) this number uniquely identifies each pointer, for as long as it is present. This is, when a finger is lifted its ID can be later reused by another finger touching the screen.</summary>
    /// <param name="id">An ID uniquely identifying this pointer among the currently present pointers.</param>
    public virtual void SetTouchId(int id) {
        Efl.Input.Pointer.NativeMethods.efl_input_pointer_touch_id_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),id);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The object where this event first originated, in case of propagation or repetition of the event.</summary>
    /// <returns>Source object: <see cref="Efl.Gfx.IEntity"/></returns>
    public virtual Efl.Object GetSource() {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_source_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The object where this event first originated, in case of propagation or repetition of the event.</summary>
    /// <param name="src">Source object: <see cref="Efl.Gfx.IEntity"/></param>
    public virtual void SetSource(Efl.Object src) {
        Efl.Input.Pointer.NativeMethods.efl_input_pointer_source_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),src);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Double or triple click information.</summary>
    /// <returns>Button information flags</returns>
    public virtual Efl.Pointer.Flags GetButtonFlags() {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_button_flags_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Double or triple click information.</summary>
    /// <param name="flags">Button information flags</param>
    public virtual void SetButtonFlags(Efl.Pointer.Flags flags) {
        Efl.Input.Pointer.NativeMethods.efl_input_pointer_button_flags_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),flags);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
    /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.</summary>
    /// <returns><c>true</c> if the button press was a double click, <c>false</c> otherwise</returns>
    public virtual bool GetDoubleClick() {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_double_click_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
    /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.</summary>
    /// <param name="val"><c>true</c> if the button press was a double click, <c>false</c> otherwise</param>
    public virtual void SetDoubleClick(bool val) {
        Efl.Input.Pointer.NativeMethods.efl_input_pointer_double_click_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
    /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.</summary>
    /// <returns><c>true</c> if the button press was a triple click, <c>false</c> otherwise</returns>
    public virtual bool GetTripleClick() {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_triple_click_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
    /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.</summary>
    /// <param name="val"><c>true</c> if the button press was a triple click, <c>false</c> otherwise</param>
    public virtual void SetTripleClick(bool val) {
        Efl.Input.Pointer.NativeMethods.efl_input_pointer_triple_click_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Direction of the wheel, usually vertical.</summary>
    /// <returns>If <c>true</c> this was a horizontal wheel.</returns>
    public virtual bool GetWheelHorizontal() {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_wheel_horizontal_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Direction of the wheel, usually vertical.</summary>
    /// <param name="horizontal">If <c>true</c> this was a horizontal wheel.<br/>The default value is <c>false</c>.</param>
    public virtual void SetWheelHorizontal(bool horizontal) {
        Efl.Input.Pointer.NativeMethods.efl_input_pointer_wheel_horizontal_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),horizontal);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Delta movement of the wheel in discrete steps.</summary>
    /// <returns>Wheel movement delta</returns>
    public virtual int GetWheelDelta() {
        var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_wheel_delta_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Delta movement of the wheel in discrete steps.</summary>
    /// <param name="dist">Wheel movement delta</param>
    public virtual void SetWheelDelta(int dist) {
        Efl.Input.Pointer.NativeMethods.efl_input_pointer_wheel_delta_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dist);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Creates a carbon copy of this object and returns it.
    /// The newly created object will have no event handlers or anything of the sort.</summary>
    /// <returns>Returned carbon copy</returns>
    public virtual Efl.IDuplicate Duplicate() {
        var _ret_var = Efl.DuplicateConcrete.NativeMethods.efl_duplicate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The time at which an event was generated.
    /// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Time in milliseconds when the event happened.</returns>
    public virtual double GetTimestamp() {
        var _ret_var = Efl.Input.EventConcrete.NativeMethods.efl_input_timestamp_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Call this when generating events manually.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ms">Time in milliseconds when the event happened.</param>
    public virtual void SetTimestamp(double ms) {
        Efl.Input.EventConcrete.NativeMethods.efl_input_timestamp_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ms);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Input device that originated this event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Input device origin</returns>
    public virtual Efl.Input.Device GetDevice() {
        var _ret_var = Efl.Input.EventConcrete.NativeMethods.efl_input_device_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Input device that originated this event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="dev">Input device origin</param>
    public virtual void SetDevice(Efl.Input.Device dev) {
        Efl.Input.EventConcrete.NativeMethods.efl_input_device_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dev);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Input event flags</returns>
    public virtual Efl.Input.Flags GetEventFlags() {
        var _ret_var = Efl.Input.EventConcrete.NativeMethods.efl_input_event_flags_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="flags">Input event flags</param>
    public virtual void SetEventFlags(Efl.Input.Flags flags) {
        Efl.Input.EventConcrete.NativeMethods.efl_input_event_flags_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),flags);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the event is on hold, <c>false</c> otherwise</returns>
    public virtual bool GetProcessed() {
        var _ret_var = Efl.Input.EventConcrete.NativeMethods.efl_input_processed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val"><c>true</c> if the event is on hold, <c>false</c> otherwise</param>
    public virtual void SetProcessed(bool val) {
        Efl.Input.EventConcrete.NativeMethods.efl_input_processed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</returns>
    public virtual bool GetScrolling() {
        var _ret_var = Efl.Input.EventConcrete.NativeMethods.efl_input_scrolling_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val"><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</param>
    public virtual void SetScrolling(bool val) {
        Efl.Input.EventConcrete.NativeMethods.efl_input_scrolling_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary><c>true</c> if the event was fake, not triggered by real hardware.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the event was not from real hardware, <c>false</c> otherwise</returns>
    public virtual bool GetFake() {
        var _ret_var = Efl.Input.EventConcrete.NativeMethods.efl_input_fake_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Resets the internal data to 0 or default values.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void Reset() {
        Efl.Input.EventConcrete.NativeMethods.efl_input_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="mod">The modifier key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key modifier is pressed.</returns>
    public virtual bool GetModifierEnabled(Efl.Input.Modifier mod, Efl.Input.Device seat) {
        var _ret_var = Efl.Input.StateConcrete.NativeMethods.efl_input_modifier_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mod, seat);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Indicates whether a key lock is on, such as NumLock, CapsLock, ...
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="kw_lock">The lock key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key lock is on.</returns>
    public virtual bool GetLockEnabled(Efl.Input.Lock kw_lock, Efl.Input.Device seat) {
        var _ret_var = Efl.Input.StateConcrete.NativeMethods.efl_input_lock_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_lock, seat);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The action represented by this event.</summary>
    /// <value>Event action</value>
    public Efl.Pointer.Action Action {
        get { return GetAction(); }
        set { SetAction(value); }
    }

    /// <summary>The mouse button that triggered the event.
    /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button</c>) is <c>true</c>.</summary>
    /// <value>1 to 32, 0 if not a button event.</value>
    public int Button {
        get { return GetButton(); }
        set { SetButton(value); }
    }

    /// <summary>Position where the event happened, relative to the window.
    /// See <see cref="Efl.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).</summary>
    /// <value>The position of the event, in pixels.</value>
    public Eina.Position2D Position {
        get { return GetPosition(); }
        set { SetPosition(value); }
    }

    /// <summary>Position where the event happened, relative to the window.
    /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="Efl.Input.Pointer.Position"/>.
    /// 
    /// See also <see cref="Efl.Input.Pointer.Position"/>.</summary>
    /// <value>The position of the event, in pixels.</value>
    public Eina.Vector2 PrecisePosition {
        get { return GetPrecisePosition(); }
        set { SetPrecisePosition(value); }
    }

    /// <summary>Position of the previous event, valid for move events.
    /// Relative to the window. May be equal to <see cref="Efl.Input.Pointer.Position"/> (by default).
    /// 
    /// This position, in integers, is an approximation of <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_x</c>), <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_y</c>). Use <see cref="Efl.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.</summary>
    /// <value>The position of the event, in pixels.</value>
    public Eina.Position2D PreviousPosition {
        get { return GetPreviousPosition(); }
        set { SetPreviousPosition(value); }
    }

    /// <summary>The ID associated with this pointer.
    /// In case there are multiple pointers (for example when multiple fingers are touching the screen) this number uniquely identifies each pointer, for as long as it is present. This is, when a finger is lifted its ID can be later reused by another finger touching the screen.</summary>
    /// <value>An ID uniquely identifying this pointer among the currently present pointers.</value>
    public int TouchId {
        get { return GetTouchId(); }
        set { SetTouchId(value); }
    }

    /// <summary>The object where this event first originated, in case of propagation or repetition of the event.</summary>
    /// <value>Source object: <see cref="Efl.Gfx.IEntity"/></value>
    public Efl.Object Source {
        get { return GetSource(); }
        set { SetSource(value); }
    }

    /// <summary>Double or triple click information.</summary>
    /// <value>Button information flags</value>
    public Efl.Pointer.Flags ButtonFlags {
        get { return GetButtonFlags(); }
        set { SetButtonFlags(value); }
    }

    /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
    /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.</summary>
    /// <value><c>true</c> if the button press was a double click, <c>false</c> otherwise</value>
    public bool DoubleClick {
        get { return GetDoubleClick(); }
        set { SetDoubleClick(value); }
    }

    /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
    /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.</summary>
    /// <value><c>true</c> if the button press was a triple click, <c>false</c> otherwise</value>
    public bool TripleClick {
        get { return GetTripleClick(); }
        set { SetTripleClick(value); }
    }

    /// <summary>Direction of the wheel, usually vertical.</summary>
    /// <value>If <c>true</c> this was a horizontal wheel.</value>
    public bool WheelHorizontal {
        get { return GetWheelHorizontal(); }
        set { SetWheelHorizontal(value); }
    }

    /// <summary>Delta movement of the wheel in discrete steps.</summary>
    /// <value>Wheel movement delta</value>
    public int WheelDelta {
        get { return GetWheelDelta(); }
        set { SetWheelDelta(value); }
    }

    /// <summary>The time at which an event was generated.
    /// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Time in milliseconds when the event happened.</value>
    public double Timestamp {
        get { return GetTimestamp(); }
        set { SetTimestamp(value); }
    }

    /// <summary>Input device that originated this event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Input device origin</value>
    public Efl.Input.Device Device {
        get { return GetDevice(); }
        set { SetDevice(value); }
    }

    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Input event flags</value>
    public Efl.Input.Flags EventFlags {
        get { return GetEventFlags(); }
        set { SetEventFlags(value); }
    }

    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if the event is on hold, <c>false</c> otherwise</value>
    public bool Processed {
        get { return GetProcessed(); }
        set { SetProcessed(value); }
    }

    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</value>
    public bool Scrolling {
        get { return GetScrolling(); }
        set { SetScrolling(value); }
    }

    /// <summary><c>true</c> if the event was fake, not triggered by real hardware.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if the event was not from real hardware, <c>false</c> otherwise</value>
    public bool Fake {
        get { return GetFake(); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Input.Pointer.efl_input_pointer_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Evas);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_input_pointer_action_get_static_delegate == null)
            {
                efl_input_pointer_action_get_static_delegate = new efl_input_pointer_action_get_delegate(action_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAction") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_action_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_action_get_static_delegate) });
            }

            if (efl_input_pointer_action_set_static_delegate == null)
            {
                efl_input_pointer_action_set_static_delegate = new efl_input_pointer_action_set_delegate(action_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAction") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_action_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_action_set_static_delegate) });
            }

            if (efl_input_pointer_value_has_get_static_delegate == null)
            {
                efl_input_pointer_value_has_get_static_delegate = new efl_input_pointer_value_has_get_delegate(value_has_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetValueHas") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_value_has_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_value_has_get_static_delegate) });
            }

            if (efl_input_pointer_value_get_static_delegate == null)
            {
                efl_input_pointer_value_get_static_delegate = new efl_input_pointer_value_get_delegate(value_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_value_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_value_get_static_delegate) });
            }

            if (efl_input_pointer_value_set_static_delegate == null)
            {
                efl_input_pointer_value_set_static_delegate = new efl_input_pointer_value_set_delegate(value_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetValue") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_value_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_value_set_static_delegate) });
            }

            if (efl_input_pointer_button_get_static_delegate == null)
            {
                efl_input_pointer_button_get_static_delegate = new efl_input_pointer_button_get_delegate(button_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetButton") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_get_static_delegate) });
            }

            if (efl_input_pointer_button_set_static_delegate == null)
            {
                efl_input_pointer_button_set_static_delegate = new efl_input_pointer_button_set_delegate(button_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetButton") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_set_static_delegate) });
            }

            if (efl_input_pointer_button_pressed_get_static_delegate == null)
            {
                efl_input_pointer_button_pressed_get_static_delegate = new efl_input_pointer_button_pressed_get_delegate(button_pressed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetButtonPressed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_pressed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_pressed_get_static_delegate) });
            }

            if (efl_input_pointer_button_pressed_set_static_delegate == null)
            {
                efl_input_pointer_button_pressed_set_static_delegate = new efl_input_pointer_button_pressed_set_delegate(button_pressed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetButtonPressed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_pressed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_pressed_set_static_delegate) });
            }

            if (efl_input_pointer_position_get_static_delegate == null)
            {
                efl_input_pointer_position_get_static_delegate = new efl_input_pointer_position_get_delegate(position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_position_get_static_delegate) });
            }

            if (efl_input_pointer_position_set_static_delegate == null)
            {
                efl_input_pointer_position_set_static_delegate = new efl_input_pointer_position_set_delegate(position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_position_set_static_delegate) });
            }

            if (efl_input_pointer_precise_position_get_static_delegate == null)
            {
                efl_input_pointer_precise_position_get_static_delegate = new efl_input_pointer_precise_position_get_delegate(precise_position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPrecisePosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_precise_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_precise_position_get_static_delegate) });
            }

            if (efl_input_pointer_precise_position_set_static_delegate == null)
            {
                efl_input_pointer_precise_position_set_static_delegate = new efl_input_pointer_precise_position_set_delegate(precise_position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPrecisePosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_precise_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_precise_position_set_static_delegate) });
            }

            if (efl_input_pointer_previous_position_get_static_delegate == null)
            {
                efl_input_pointer_previous_position_get_static_delegate = new efl_input_pointer_previous_position_get_delegate(previous_position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPreviousPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_previous_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_previous_position_get_static_delegate) });
            }

            if (efl_input_pointer_previous_position_set_static_delegate == null)
            {
                efl_input_pointer_previous_position_set_static_delegate = new efl_input_pointer_previous_position_set_delegate(previous_position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPreviousPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_previous_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_previous_position_set_static_delegate) });
            }

            if (efl_input_pointer_touch_id_get_static_delegate == null)
            {
                efl_input_pointer_touch_id_get_static_delegate = new efl_input_pointer_touch_id_get_delegate(touch_id_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTouchId") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_touch_id_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_touch_id_get_static_delegate) });
            }

            if (efl_input_pointer_touch_id_set_static_delegate == null)
            {
                efl_input_pointer_touch_id_set_static_delegate = new efl_input_pointer_touch_id_set_delegate(touch_id_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTouchId") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_touch_id_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_touch_id_set_static_delegate) });
            }

            if (efl_input_pointer_source_get_static_delegate == null)
            {
                efl_input_pointer_source_get_static_delegate = new efl_input_pointer_source_get_delegate(source_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_source_get_static_delegate) });
            }

            if (efl_input_pointer_source_set_static_delegate == null)
            {
                efl_input_pointer_source_set_static_delegate = new efl_input_pointer_source_set_delegate(source_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSource") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_source_set_static_delegate) });
            }

            if (efl_input_pointer_button_flags_get_static_delegate == null)
            {
                efl_input_pointer_button_flags_get_static_delegate = new efl_input_pointer_button_flags_get_delegate(button_flags_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetButtonFlags") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_flags_get_static_delegate) });
            }

            if (efl_input_pointer_button_flags_set_static_delegate == null)
            {
                efl_input_pointer_button_flags_set_static_delegate = new efl_input_pointer_button_flags_set_delegate(button_flags_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetButtonFlags") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_flags_set_static_delegate) });
            }

            if (efl_input_pointer_double_click_get_static_delegate == null)
            {
                efl_input_pointer_double_click_get_static_delegate = new efl_input_pointer_double_click_get_delegate(double_click_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDoubleClick") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_double_click_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_double_click_get_static_delegate) });
            }

            if (efl_input_pointer_double_click_set_static_delegate == null)
            {
                efl_input_pointer_double_click_set_static_delegate = new efl_input_pointer_double_click_set_delegate(double_click_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDoubleClick") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_double_click_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_double_click_set_static_delegate) });
            }

            if (efl_input_pointer_triple_click_get_static_delegate == null)
            {
                efl_input_pointer_triple_click_get_static_delegate = new efl_input_pointer_triple_click_get_delegate(triple_click_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTripleClick") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_triple_click_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_triple_click_get_static_delegate) });
            }

            if (efl_input_pointer_triple_click_set_static_delegate == null)
            {
                efl_input_pointer_triple_click_set_static_delegate = new efl_input_pointer_triple_click_set_delegate(triple_click_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTripleClick") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_triple_click_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_triple_click_set_static_delegate) });
            }

            if (efl_input_pointer_wheel_horizontal_get_static_delegate == null)
            {
                efl_input_pointer_wheel_horizontal_get_static_delegate = new efl_input_pointer_wheel_horizontal_get_delegate(wheel_horizontal_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWheelHorizontal") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_wheel_horizontal_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_horizontal_get_static_delegate) });
            }

            if (efl_input_pointer_wheel_horizontal_set_static_delegate == null)
            {
                efl_input_pointer_wheel_horizontal_set_static_delegate = new efl_input_pointer_wheel_horizontal_set_delegate(wheel_horizontal_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWheelHorizontal") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_wheel_horizontal_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_horizontal_set_static_delegate) });
            }

            if (efl_input_pointer_wheel_delta_get_static_delegate == null)
            {
                efl_input_pointer_wheel_delta_get_static_delegate = new efl_input_pointer_wheel_delta_get_delegate(wheel_delta_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWheelDelta") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_wheel_delta_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_delta_get_static_delegate) });
            }

            if (efl_input_pointer_wheel_delta_set_static_delegate == null)
            {
                efl_input_pointer_wheel_delta_set_static_delegate = new efl_input_pointer_wheel_delta_set_delegate(wheel_delta_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWheelDelta") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_wheel_delta_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_delta_set_static_delegate) });
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
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Input.Pointer.efl_input_pointer_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Pointer.Action efl_input_pointer_action_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Pointer.Action efl_input_pointer_action_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_action_get_api_delegate> efl_input_pointer_action_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_action_get_api_delegate>(Module, "efl_input_pointer_action_get");

        private static Efl.Pointer.Action action_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_pointer_action_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Efl.Pointer.Action _ret_var = default(Efl.Pointer.Action);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetAction();
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
                return efl_input_pointer_action_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_action_get_delegate efl_input_pointer_action_get_static_delegate;

        
        private delegate void efl_input_pointer_action_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Pointer.Action act);

        
        public delegate void efl_input_pointer_action_set_api_delegate(System.IntPtr obj,  Efl.Pointer.Action act);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_action_set_api_delegate> efl_input_pointer_action_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_action_set_api_delegate>(Module, "efl_input_pointer_action_set");

        private static void action_set(System.IntPtr obj, System.IntPtr pd, Efl.Pointer.Action act)
        {
            Eina.Log.Debug("function efl_input_pointer_action_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetAction(act);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_action_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), act);
            }
        }

        private static efl_input_pointer_action_set_delegate efl_input_pointer_action_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_pointer_value_has_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Value key);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_pointer_value_has_get_api_delegate(System.IntPtr obj,  Efl.Input.Value key);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_value_has_get_api_delegate> efl_input_pointer_value_has_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_value_has_get_api_delegate>(Module, "efl_input_pointer_value_has_get");

        private static bool value_has_get(System.IntPtr obj, System.IntPtr pd, Efl.Input.Value key)
        {
            Eina.Log.Debug("function efl_input_pointer_value_has_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetValueHas(key);
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
                return efl_input_pointer_value_has_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_input_pointer_value_has_get_delegate efl_input_pointer_value_has_get_static_delegate;

        
        private delegate double efl_input_pointer_value_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Value key);

        
        public delegate double efl_input_pointer_value_get_api_delegate(System.IntPtr obj,  Efl.Input.Value key);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_value_get_api_delegate> efl_input_pointer_value_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_value_get_api_delegate>(Module, "efl_input_pointer_value_get");

        private static double value_get(System.IntPtr obj, System.IntPtr pd, Efl.Input.Value key)
        {
            Eina.Log.Debug("function efl_input_pointer_value_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetValue(key);
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
                return efl_input_pointer_value_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_input_pointer_value_get_delegate efl_input_pointer_value_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_pointer_value_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Value key,  double val);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_pointer_value_set_api_delegate(System.IntPtr obj,  Efl.Input.Value key,  double val);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_value_set_api_delegate> efl_input_pointer_value_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_value_set_api_delegate>(Module, "efl_input_pointer_value_set");

        private static bool value_set(System.IntPtr obj, System.IntPtr pd, Efl.Input.Value key, double val)
        {
            Eina.Log.Debug("function efl_input_pointer_value_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).SetValue(key, val);
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
                return efl_input_pointer_value_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key, val);
            }
        }

        private static efl_input_pointer_value_set_delegate efl_input_pointer_value_set_static_delegate;

        
        private delegate int efl_input_pointer_button_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_input_pointer_button_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_button_get_api_delegate> efl_input_pointer_button_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_button_get_api_delegate>(Module, "efl_input_pointer_button_get");

        private static int button_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_pointer_button_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetButton();
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
                return efl_input_pointer_button_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_button_get_delegate efl_input_pointer_button_get_static_delegate;

        
        private delegate void efl_input_pointer_button_set_delegate(System.IntPtr obj, System.IntPtr pd,  int but);

        
        public delegate void efl_input_pointer_button_set_api_delegate(System.IntPtr obj,  int but);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_button_set_api_delegate> efl_input_pointer_button_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_button_set_api_delegate>(Module, "efl_input_pointer_button_set");

        private static void button_set(System.IntPtr obj, System.IntPtr pd, int but)
        {
            Eina.Log.Debug("function efl_input_pointer_button_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetButton(but);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_button_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), but);
            }
        }

        private static efl_input_pointer_button_set_delegate efl_input_pointer_button_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_pointer_button_pressed_get_delegate(System.IntPtr obj, System.IntPtr pd,  int button);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_pointer_button_pressed_get_api_delegate(System.IntPtr obj,  int button);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_button_pressed_get_api_delegate> efl_input_pointer_button_pressed_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_button_pressed_get_api_delegate>(Module, "efl_input_pointer_button_pressed_get");

        private static bool button_pressed_get(System.IntPtr obj, System.IntPtr pd, int button)
        {
            Eina.Log.Debug("function efl_input_pointer_button_pressed_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetButtonPressed(button);
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
                return efl_input_pointer_button_pressed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_pointer_button_pressed_get_delegate efl_input_pointer_button_pressed_get_static_delegate;

        
        private delegate void efl_input_pointer_button_pressed_set_delegate(System.IntPtr obj, System.IntPtr pd,  int button, [MarshalAs(UnmanagedType.U1)] bool pressed);

        
        public delegate void efl_input_pointer_button_pressed_set_api_delegate(System.IntPtr obj,  int button, [MarshalAs(UnmanagedType.U1)] bool pressed);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_button_pressed_set_api_delegate> efl_input_pointer_button_pressed_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_button_pressed_set_api_delegate>(Module, "efl_input_pointer_button_pressed_set");

        private static void button_pressed_set(System.IntPtr obj, System.IntPtr pd, int button, bool pressed)
        {
            Eina.Log.Debug("function efl_input_pointer_button_pressed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetButtonPressed(button, pressed);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_button_pressed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), button, pressed);
            }
        }

        private static efl_input_pointer_button_pressed_set_delegate efl_input_pointer_button_pressed_set_static_delegate;

        
        private delegate Eina.Position2D.NativeStruct efl_input_pointer_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Position2D.NativeStruct efl_input_pointer_position_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_position_get_api_delegate> efl_input_pointer_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_position_get_api_delegate>(Module, "efl_input_pointer_position_get");

        private static Eina.Position2D.NativeStruct position_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_pointer_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Position2D _ret_var = default(Eina.Position2D);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetPosition();
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
                return efl_input_pointer_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_position_get_delegate efl_input_pointer_position_get_static_delegate;

        
        private delegate void efl_input_pointer_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos);

        
        public delegate void efl_input_pointer_position_set_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct pos);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_position_set_api_delegate> efl_input_pointer_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_position_set_api_delegate>(Module, "efl_input_pointer_position_set");

        private static void position_set(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct pos)
        {
            Eina.Log.Debug("function efl_input_pointer_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Position2D _in_pos = pos;

                try
                {
                    ((Pointer)ws.Target).SetPosition(_in_pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_input_pointer_position_set_delegate efl_input_pointer_position_set_static_delegate;

        
        private delegate Eina.Vector2.NativeStruct efl_input_pointer_precise_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Vector2.NativeStruct efl_input_pointer_precise_position_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_precise_position_get_api_delegate> efl_input_pointer_precise_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_precise_position_get_api_delegate>(Module, "efl_input_pointer_precise_position_get");

        private static Eina.Vector2.NativeStruct precise_position_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_pointer_precise_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Vector2 _ret_var = default(Eina.Vector2);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetPrecisePosition();
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
                return efl_input_pointer_precise_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_precise_position_get_delegate efl_input_pointer_precise_position_get_static_delegate;

        
        private delegate void efl_input_pointer_precise_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Vector2.NativeStruct pos);

        
        public delegate void efl_input_pointer_precise_position_set_api_delegate(System.IntPtr obj,  Eina.Vector2.NativeStruct pos);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_precise_position_set_api_delegate> efl_input_pointer_precise_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_precise_position_set_api_delegate>(Module, "efl_input_pointer_precise_position_set");

        private static void precise_position_set(System.IntPtr obj, System.IntPtr pd, Eina.Vector2.NativeStruct pos)
        {
            Eina.Log.Debug("function efl_input_pointer_precise_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Vector2 _in_pos = pos;

                try
                {
                    ((Pointer)ws.Target).SetPrecisePosition(_in_pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_precise_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_input_pointer_precise_position_set_delegate efl_input_pointer_precise_position_set_static_delegate;

        
        private delegate Eina.Position2D.NativeStruct efl_input_pointer_previous_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Position2D.NativeStruct efl_input_pointer_previous_position_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_previous_position_get_api_delegate> efl_input_pointer_previous_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_previous_position_get_api_delegate>(Module, "efl_input_pointer_previous_position_get");

        private static Eina.Position2D.NativeStruct previous_position_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_pointer_previous_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Position2D _ret_var = default(Eina.Position2D);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetPreviousPosition();
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
                return efl_input_pointer_previous_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_previous_position_get_delegate efl_input_pointer_previous_position_get_static_delegate;

        
        private delegate void efl_input_pointer_previous_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D.NativeStruct pos);

        
        public delegate void efl_input_pointer_previous_position_set_api_delegate(System.IntPtr obj,  Eina.Position2D.NativeStruct pos);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_previous_position_set_api_delegate> efl_input_pointer_previous_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_previous_position_set_api_delegate>(Module, "efl_input_pointer_previous_position_set");

        private static void previous_position_set(System.IntPtr obj, System.IntPtr pd, Eina.Position2D.NativeStruct pos)
        {
            Eina.Log.Debug("function efl_input_pointer_previous_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Position2D _in_pos = pos;

                try
                {
                    ((Pointer)ws.Target).SetPreviousPosition(_in_pos);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_previous_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_input_pointer_previous_position_set_delegate efl_input_pointer_previous_position_set_static_delegate;

        
        private delegate int efl_input_pointer_touch_id_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_input_pointer_touch_id_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_touch_id_get_api_delegate> efl_input_pointer_touch_id_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_touch_id_get_api_delegate>(Module, "efl_input_pointer_touch_id_get");

        private static int touch_id_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_pointer_touch_id_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetTouchId();
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
                return efl_input_pointer_touch_id_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_touch_id_get_delegate efl_input_pointer_touch_id_get_static_delegate;

        
        private delegate void efl_input_pointer_touch_id_set_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        
        public delegate void efl_input_pointer_touch_id_set_api_delegate(System.IntPtr obj,  int id);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_touch_id_set_api_delegate> efl_input_pointer_touch_id_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_touch_id_set_api_delegate>(Module, "efl_input_pointer_touch_id_set");

        private static void touch_id_set(System.IntPtr obj, System.IntPtr pd, int id)
        {
            Eina.Log.Debug("function efl_input_pointer_touch_id_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetTouchId(id);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_touch_id_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), id);
            }
        }

        private static efl_input_pointer_touch_id_set_delegate efl_input_pointer_touch_id_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Object efl_input_pointer_source_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Object efl_input_pointer_source_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_source_get_api_delegate> efl_input_pointer_source_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_source_get_api_delegate>(Module, "efl_input_pointer_source_get");

        private static Efl.Object source_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_pointer_source_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Efl.Object _ret_var = default(Efl.Object);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetSource();
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
                return efl_input_pointer_source_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_source_get_delegate efl_input_pointer_source_get_static_delegate;

        
        private delegate void efl_input_pointer_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object src);

        
        public delegate void efl_input_pointer_source_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Object src);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_source_set_api_delegate> efl_input_pointer_source_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_source_set_api_delegate>(Module, "efl_input_pointer_source_set");

        private static void source_set(System.IntPtr obj, System.IntPtr pd, Efl.Object src)
        {
            Eina.Log.Debug("function efl_input_pointer_source_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetSource(src);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_source_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), src);
            }
        }

        private static efl_input_pointer_source_set_delegate efl_input_pointer_source_set_static_delegate;

        
        private delegate Efl.Pointer.Flags efl_input_pointer_button_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Pointer.Flags efl_input_pointer_button_flags_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_button_flags_get_api_delegate> efl_input_pointer_button_flags_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_button_flags_get_api_delegate>(Module, "efl_input_pointer_button_flags_get");

        private static Efl.Pointer.Flags button_flags_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_pointer_button_flags_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Efl.Pointer.Flags _ret_var = default(Efl.Pointer.Flags);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetButtonFlags();
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
                return efl_input_pointer_button_flags_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_button_flags_get_delegate efl_input_pointer_button_flags_get_static_delegate;

        
        private delegate void efl_input_pointer_button_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Pointer.Flags flags);

        
        public delegate void efl_input_pointer_button_flags_set_api_delegate(System.IntPtr obj,  Efl.Pointer.Flags flags);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_button_flags_set_api_delegate> efl_input_pointer_button_flags_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_button_flags_set_api_delegate>(Module, "efl_input_pointer_button_flags_set");

        private static void button_flags_set(System.IntPtr obj, System.IntPtr pd, Efl.Pointer.Flags flags)
        {
            Eina.Log.Debug("function efl_input_pointer_button_flags_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetButtonFlags(flags);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_button_flags_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), flags);
            }
        }

        private static efl_input_pointer_button_flags_set_delegate efl_input_pointer_button_flags_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_pointer_double_click_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_pointer_double_click_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_double_click_get_api_delegate> efl_input_pointer_double_click_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_double_click_get_api_delegate>(Module, "efl_input_pointer_double_click_get");

        private static bool double_click_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_pointer_double_click_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetDoubleClick();
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
                return efl_input_pointer_double_click_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_double_click_get_delegate efl_input_pointer_double_click_get_static_delegate;

        
        private delegate void efl_input_pointer_double_click_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

        
        public delegate void efl_input_pointer_double_click_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_double_click_set_api_delegate> efl_input_pointer_double_click_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_double_click_set_api_delegate>(Module, "efl_input_pointer_double_click_set");

        private static void double_click_set(System.IntPtr obj, System.IntPtr pd, bool val)
        {
            Eina.Log.Debug("function efl_input_pointer_double_click_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetDoubleClick(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_double_click_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_input_pointer_double_click_set_delegate efl_input_pointer_double_click_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_pointer_triple_click_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_pointer_triple_click_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_triple_click_get_api_delegate> efl_input_pointer_triple_click_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_triple_click_get_api_delegate>(Module, "efl_input_pointer_triple_click_get");

        private static bool triple_click_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_pointer_triple_click_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetTripleClick();
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
                return efl_input_pointer_triple_click_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_triple_click_get_delegate efl_input_pointer_triple_click_get_static_delegate;

        
        private delegate void efl_input_pointer_triple_click_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

        
        public delegate void efl_input_pointer_triple_click_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_triple_click_set_api_delegate> efl_input_pointer_triple_click_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_triple_click_set_api_delegate>(Module, "efl_input_pointer_triple_click_set");

        private static void triple_click_set(System.IntPtr obj, System.IntPtr pd, bool val)
        {
            Eina.Log.Debug("function efl_input_pointer_triple_click_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetTripleClick(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_triple_click_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_input_pointer_triple_click_set_delegate efl_input_pointer_triple_click_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_pointer_wheel_horizontal_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_pointer_wheel_horizontal_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_horizontal_get_api_delegate> efl_input_pointer_wheel_horizontal_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_horizontal_get_api_delegate>(Module, "efl_input_pointer_wheel_horizontal_get");

        private static bool wheel_horizontal_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_pointer_wheel_horizontal_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetWheelHorizontal();
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
                return efl_input_pointer_wheel_horizontal_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_wheel_horizontal_get_delegate efl_input_pointer_wheel_horizontal_get_static_delegate;

        
        private delegate void efl_input_pointer_wheel_horizontal_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool horizontal);

        
        public delegate void efl_input_pointer_wheel_horizontal_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool horizontal);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_horizontal_set_api_delegate> efl_input_pointer_wheel_horizontal_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_horizontal_set_api_delegate>(Module, "efl_input_pointer_wheel_horizontal_set");

        private static void wheel_horizontal_set(System.IntPtr obj, System.IntPtr pd, bool horizontal)
        {
            Eina.Log.Debug("function efl_input_pointer_wheel_horizontal_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetWheelHorizontal(horizontal);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_wheel_horizontal_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), horizontal);
            }
        }

        private static efl_input_pointer_wheel_horizontal_set_delegate efl_input_pointer_wheel_horizontal_set_static_delegate;

        
        private delegate int efl_input_pointer_wheel_delta_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_input_pointer_wheel_delta_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_delta_get_api_delegate> efl_input_pointer_wheel_delta_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_delta_get_api_delegate>(Module, "efl_input_pointer_wheel_delta_get");

        private static int wheel_delta_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_pointer_wheel_delta_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetWheelDelta();
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
                return efl_input_pointer_wheel_delta_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_wheel_delta_get_delegate efl_input_pointer_wheel_delta_get_static_delegate;

        
        private delegate void efl_input_pointer_wheel_delta_set_delegate(System.IntPtr obj, System.IntPtr pd,  int dist);

        
        public delegate void efl_input_pointer_wheel_delta_set_api_delegate(System.IntPtr obj,  int dist);

        public static Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_delta_set_api_delegate> efl_input_pointer_wheel_delta_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_pointer_wheel_delta_set_api_delegate>(Module, "efl_input_pointer_wheel_delta_set");

        private static void wheel_delta_set(System.IntPtr obj, System.IntPtr pd, int dist)
        {
            Eina.Log.Debug("function efl_input_pointer_wheel_delta_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetWheelDelta(dist);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_wheel_delta_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dist);
            }
        }

        private static efl_input_pointer_wheel_delta_set_delegate efl_input_pointer_wheel_delta_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_InputPointer_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Pointer.Action> Action<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<Efl.Pointer.Action>("action", fac);
    }

    public static Efl.BindableProperty<int> Button<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<int>("button", fac);
    }

    public static Efl.BindableProperty<Eina.Position2D> Position<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<Eina.Position2D>("position", fac);
    }

    public static Efl.BindableProperty<Eina.Vector2> PrecisePosition<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<Eina.Vector2>("precise_position", fac);
    }

    public static Efl.BindableProperty<Eina.Position2D> PreviousPosition<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<Eina.Position2D>("previous_position", fac);
    }

    public static Efl.BindableProperty<int> TouchId<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<int>("touch_id", fac);
    }

    public static Efl.BindableProperty<Efl.Object> Source<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<Efl.Object>("source", fac);
    }

    public static Efl.BindableProperty<Efl.Pointer.Flags> ButtonFlags<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<Efl.Pointer.Flags>("button_flags", fac);
    }

    public static Efl.BindableProperty<bool> DoubleClick<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<bool>("double_click", fac);
    }

    public static Efl.BindableProperty<bool> TripleClick<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<bool>("triple_click", fac);
    }

    public static Efl.BindableProperty<bool> WheelHorizontal<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<bool>("wheel_horizontal", fac);
    }

    public static Efl.BindableProperty<int> WheelDelta<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<int>("wheel_delta", fac);
    }

    public static Efl.BindableProperty<double> Timestamp<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<double>("timestamp", fac);
    }

    public static Efl.BindableProperty<Efl.Input.Device> Device<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<Efl.Input.Device>("device", fac);
    }

    public static Efl.BindableProperty<Efl.Input.Flags> EventFlags<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<Efl.Input.Flags>("event_flags", fac);
    }

    public static Efl.BindableProperty<bool> Processed<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<bool>("processed", fac);
    }

    public static Efl.BindableProperty<bool> Scrolling<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Pointer, T>magic = null) where T : Efl.Input.Pointer {
        return new Efl.BindableProperty<bool>("scrolling", fac);
    }

}
#pragma warning restore CS1591
#endif
