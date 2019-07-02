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
public class Pointer : Efl.Object, Efl.IDuplicate, Efl.Input.IEvent, Efl.Input.IState
{
    ///<summary>Pointer to the native class description.</summary>
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
            ) : base(efl_input_pointer_class_get(), typeof(Pointer), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Pointer"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Pointer(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Pointer"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Pointer(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>The action represented by this event.</summary>
    /// <returns>Event action</returns>
    virtual public Efl.Pointer.Action GetAction() {
         var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_action_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The action represented by this event.</summary>
    /// <param name="act">Event action</param>
    virtual public void SetAction(Efl.Pointer.Action act) {
                                 Efl.Input.Pointer.NativeMethods.efl_input_pointer_action_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),act);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if this event carries a valid value for the specified <c>key</c>.</summary>
    /// <param name="key">Pressed <c>key</c></param>
    /// <returns><c>true</c> if input value is valid, <c>false</c> otherwise</returns>
    virtual public bool GetValueHas(Efl.Input.Value key) {
                                 var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_value_has_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),key);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Represents a generic value for this event.
    /// Refer to the documentation of <see cref="Efl.Input.Value"/> for each value&apos;s meaning, type and range. Call <see cref="Efl.Input.Pointer.GetValueHas"/> to determine whether the returned value is valid or not for this event.
    /// 
    /// Most values are precise floating point values, usually in pixels, radians, or in a range of [-1, 1] or [0, 1]. Some values are discrete values (integers) and thus should preferably be queried with the other methods of this class.</summary>
    /// <param name="key"><c>key</c></param>
    /// <returns><c>key</c> value</returns>
    virtual public double GetValue(Efl.Input.Value key) {
                                 var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_value_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),key);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Represents a generic value for this event.
    /// Refer to the documentation of <see cref="Efl.Input.Value"/> for each value&apos;s meaning, type and range. Call <see cref="Efl.Input.Pointer.GetValueHas"/> to determine whether the returned value is valid or not for this event.
    /// 
    /// Most values are precise floating point values, usually in pixels, radians, or in a range of [-1, 1] or [0, 1]. Some values are discrete values (integers) and thus should preferably be queried with the other methods of this class.</summary>
    /// <param name="key"><c>key</c></param>
    /// <param name="val"><c>key</c> value</param>
    /// <returns><c>false</c> if the value could not be set (eg. delta).</returns>
    virtual public bool SetValue(Efl.Input.Value key, double val) {
                                                         var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_value_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),key, val);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>The mouse button that triggered the event.
    /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button</c>) is <c>true</c>.</summary>
    /// <returns>1 to 32, 0 if not a button event.</returns>
    virtual public int GetButton() {
         var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_button_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The mouse button that triggered the event.
    /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button</c>) is <c>true</c>.</summary>
    /// <param name="but">1 to 32, 0 if not a button event.</param>
    virtual public void SetButton(int but) {
                                 Efl.Input.Pointer.NativeMethods.efl_input_pointer_button_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),but);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether a mouse button is pressed at the moment of the event.
    /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button_pressed</c>) is <c>true</c>.</summary>
    /// <param name="button">1 to 32, 0 if not a button event.</param>
    /// <returns><c>true</c> when the button was pressed, <c>false</c> otherwise</returns>
    virtual public bool GetButtonPressed(int button) {
                                 var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_button_pressed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),button);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Whether a mouse button is pressed at the moment of the event.
    /// Valid if and only if <see cref="Efl.Input.Pointer.GetValueHas"/>(<c>button_pressed</c>) is <c>true</c>.</summary>
    /// <param name="button">1 to 32, 0 if not a button event.</param>
    /// <param name="pressed"><c>true</c> when the button was pressed, <c>false</c> otherwise</param>
    virtual public void SetButtonPressed(int button, bool pressed) {
                                                         Efl.Input.Pointer.NativeMethods.efl_input_pointer_button_pressed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),button, pressed);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Position where the event happened, relative to the window.
    /// See <see cref="Efl.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).</summary>
    /// <returns>The position of the event, in pixels.</returns>
    virtual public Eina.Position2D GetPosition() {
         var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Position where the event happened, relative to the window.
    /// See <see cref="Efl.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).</summary>
    /// <param name="pos">The position of the event, in pixels.</param>
    virtual public void SetPosition(Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Input.Pointer.NativeMethods.efl_input_pointer_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Position where the event happened, relative to the window.
    /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="Efl.Input.Pointer.Position"/>.
    /// 
    /// See also <see cref="Efl.Input.Pointer.Position"/>.</summary>
    /// <returns>The position of the event, in pixels.</returns>
    virtual public Eina.Vector2 GetPrecisePosition() {
         var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_precise_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Position where the event happened, relative to the window.
    /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="Efl.Input.Pointer.Position"/>.
    /// 
    /// See also <see cref="Efl.Input.Pointer.Position"/>.</summary>
    /// <param name="pos">The position of the event, in pixels.</param>
    virtual public void SetPrecisePosition(Eina.Vector2 pos) {
         Eina.Vector2.NativeStruct _in_pos = pos;
                        Efl.Input.Pointer.NativeMethods.efl_input_pointer_precise_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Position of the previous event, valid for move events.
    /// Relative to the window. May be equal to <see cref="Efl.Input.Pointer.Position"/> (by default).
    /// 
    /// This position, in integers, is an approximation of <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_x</c>), <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_y</c>). Use <see cref="Efl.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.</summary>
    /// <returns>The position of the event, in pixels.</returns>
    virtual public Eina.Position2D GetPreviousPosition() {
         var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_previous_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Position of the previous event, valid for move events.
    /// Relative to the window. May be equal to <see cref="Efl.Input.Pointer.Position"/> (by default).
    /// 
    /// This position, in integers, is an approximation of <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_x</c>), <see cref="Efl.Input.Pointer.GetValue"/>(<c>previous_y</c>). Use <see cref="Efl.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.</summary>
    /// <param name="pos">The position of the event, in pixels.</param>
    virtual public void SetPreviousPosition(Eina.Position2D pos) {
         Eina.Position2D.NativeStruct _in_pos = pos;
                        Efl.Input.Pointer.NativeMethods.efl_input_pointer_previous_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_pos);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>TThe ID associated with this pointer.
    /// In case there are multiple pointers (for example when multiple fingers are touching the screen) this number uniquely identifies each pointer, for as long as it is present. This is, when a finger is lifted its ID can be later reused by another finger touching the screen.</summary>
    /// <returns>An ID uniquely identifying this pointer among the currently present pointers.</returns>
    virtual public int GetTouchId() {
         var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_touch_id_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>TThe ID associated with this pointer.
    /// In case there are multiple pointers (for example when multiple fingers are touching the screen) this number uniquely identifies each pointer, for as long as it is present. This is, when a finger is lifted its ID can be later reused by another finger touching the screen.</summary>
    /// <param name="id">An ID uniquely identifying this pointer among the currently present pointers.</param>
    virtual public void SetTouchId(int id) {
                                 Efl.Input.Pointer.NativeMethods.efl_input_pointer_touch_id_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),id);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The object where this event first originated, in case of propagation or repetition of the event.</summary>
    /// <returns>Source object: <see cref="Efl.Gfx.IEntity"/></returns>
    virtual public Efl.Object GetSource() {
         var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_source_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The object where this event first originated, in case of propagation or repetition of the event.</summary>
    /// <param name="src">Source object: <see cref="Efl.Gfx.IEntity"/></param>
    virtual public void SetSource(Efl.Object src) {
                                 Efl.Input.Pointer.NativeMethods.efl_input_pointer_source_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),src);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Double or triple click information.</summary>
    /// <returns>Button information flags</returns>
    virtual public Efl.Pointer.Flags GetButtonFlags() {
         var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_button_flags_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Double or triple click information.</summary>
    /// <param name="flags">Button information flags</param>
    virtual public void SetButtonFlags(Efl.Pointer.Flags flags) {
                                 Efl.Input.Pointer.NativeMethods.efl_input_pointer_button_flags_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),flags);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
    /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.</summary>
    /// <returns><c>true</c> if the button press was a double click, <c>false</c> otherwise</returns>
    virtual public bool GetDoubleClick() {
         var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_double_click_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
    /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.</summary>
    /// <param name="val"><c>true</c> if the button press was a double click, <c>false</c> otherwise</param>
    virtual public void SetDoubleClick(bool val) {
                                 Efl.Input.Pointer.NativeMethods.efl_input_pointer_double_click_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
    /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.</summary>
    /// <returns><c>true</c> if the button press was a triple click, <c>false</c> otherwise</returns>
    virtual public bool GetTripleClick() {
         var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_triple_click_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if <see cref="Efl.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
    /// This is just a helper function around <see cref="Efl.Input.Pointer.ButtonFlags"/>.</summary>
    /// <param name="val"><c>true</c> if the button press was a triple click, <c>false</c> otherwise</param>
    virtual public void SetTripleClick(bool val) {
                                 Efl.Input.Pointer.NativeMethods.efl_input_pointer_triple_click_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Direction of the wheel, usually vertical.</summary>
    /// <returns>If <c>true</c> this was a horizontal wheel.</returns>
    virtual public bool GetWheelHorizontal() {
         var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_wheel_horizontal_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Direction of the wheel, usually vertical.</summary>
    /// <param name="horizontal">If <c>true</c> this was a horizontal wheel.</param>
    virtual public void SetWheelHorizontal(bool horizontal) {
                                 Efl.Input.Pointer.NativeMethods.efl_input_pointer_wheel_horizontal_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),horizontal);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Delta movement of the wheel in discrete steps.</summary>
    /// <returns>Wheel movement delta</returns>
    virtual public int GetWheelDelta() {
         var _ret_var = Efl.Input.Pointer.NativeMethods.efl_input_pointer_wheel_delta_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Delta movement of the wheel in discrete steps.</summary>
    /// <param name="dist">Wheel movement delta</param>
    virtual public void SetWheelDelta(int dist) {
                                 Efl.Input.Pointer.NativeMethods.efl_input_pointer_wheel_delta_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),dist);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Creates a carbon copy of this object and returns it.
    /// The newly created object will have no event handlers or anything of the sort.</summary>
    /// <returns>Returned carbon copy</returns>
    virtual public Efl.IDuplicate Duplicate() {
         var _ret_var = Efl.IDuplicateConcrete.NativeMethods.efl_duplicate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The time at which an event was generated.
    /// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.</summary>
    /// <returns>Time in milliseconds when the event happened.</returns>
    virtual public double GetTimestamp() {
         var _ret_var = Efl.Input.IEventConcrete.NativeMethods.efl_input_timestamp_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Call this when generating events manually.</summary>
    /// <param name="ms">Time in milliseconds when the event happened.</param>
    virtual public void SetTimestamp(double ms) {
                                 Efl.Input.IEventConcrete.NativeMethods.efl_input_timestamp_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),ms);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Input device that originated this event.</summary>
    /// <returns>Input device origin</returns>
    virtual public Efl.Input.Device GetDevice() {
         var _ret_var = Efl.Input.IEventConcrete.NativeMethods.efl_input_device_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Input device that originated this event.</summary>
    /// <param name="dev">Input device origin</param>
    virtual public void SetDevice(Efl.Input.Device dev) {
                                 Efl.Input.IEventConcrete.NativeMethods.efl_input_device_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),dev);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <returns>Input event flags</returns>
    virtual public Efl.Input.Flags GetEventFlags() {
         var _ret_var = Efl.Input.IEventConcrete.NativeMethods.efl_input_event_flags_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <param name="flags">Input event flags</param>
    virtual public void SetEventFlags(Efl.Input.Flags flags) {
                                 Efl.Input.IEventConcrete.NativeMethods.efl_input_event_flags_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),flags);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <returns><c>true</c> if the event is on hold, <c>false</c> otherwise</returns>
    virtual public bool GetProcessed() {
         var _ret_var = Efl.Input.IEventConcrete.NativeMethods.efl_input_processed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <param name="val"><c>true</c> if the event is on hold, <c>false</c> otherwise</param>
    virtual public void SetProcessed(bool val) {
                                 Efl.Input.IEventConcrete.NativeMethods.efl_input_processed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <returns><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</returns>
    virtual public bool GetScrolling() {
         var _ret_var = Efl.Input.IEventConcrete.NativeMethods.efl_input_scrolling_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <param name="val"><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</param>
    virtual public void SetScrolling(bool val) {
                                 Efl.Input.IEventConcrete.NativeMethods.efl_input_scrolling_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if the event was fake, not triggered by real hardware.</summary>
    /// <returns><c>true</c> if the event was not from real hardware, <c>false</c> otherwise</returns>
    virtual public bool GetFake() {
         var _ret_var = Efl.Input.IEventConcrete.NativeMethods.efl_input_fake_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Resets the internal data to 0 or default values.</summary>
    virtual public void Reset() {
         Efl.Input.IEventConcrete.NativeMethods.efl_input_reset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...
    /// (Since EFL 1.22)</summary>
    /// <param name="mod">The modifier key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key modifier is pressed.</returns>
    virtual public bool GetModifierEnabled(Efl.Input.Modifier mod, Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.IStateConcrete.NativeMethods.efl_input_modifier_enabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),mod, seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Indicates whether a key lock is on, such as NumLock, CapsLock, ...
    /// (Since EFL 1.22)</summary>
    /// <param name="kw_lock">The lock key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key lock is on.</returns>
    virtual public bool GetLockEnabled(Efl.Input.Lock kw_lock, Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.IStateConcrete.NativeMethods.efl_input_lock_enabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),kw_lock, seat);
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
    /// <summary>TThe ID associated with this pointer.
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
    /// <value>Time in milliseconds when the event happened.</value>
    public double Timestamp {
        get { return GetTimestamp(); }
        set { SetTimestamp(value); }
    }
    /// <summary>Input device that originated this event.</summary>
    /// <value>Input device origin</value>
    public Efl.Input.Device Device {
        get { return GetDevice(); }
        set { SetDevice(value); }
    }
    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <value>Input event flags</value>
    public Efl.Input.Flags EventFlags {
        get { return GetEventFlags(); }
        set { SetEventFlags(value); }
    }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <value><c>true</c> if the event is on hold, <c>false</c> otherwise</value>
    public bool Processed {
        get { return GetProcessed(); }
        set { SetProcessed(value); }
    }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <value><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</value>
    public bool Scrolling {
        get { return GetScrolling(); }
        set { SetScrolling(value); }
    }
    /// <summary><c>true</c> if the event was fake, not triggered by real hardware.</summary>
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
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
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

            if (efl_duplicate_static_delegate == null)
            {
                efl_duplicate_static_delegate = new efl_duplicate_delegate(duplicate);
            }

            if (methods.FirstOrDefault(m => m.Name == "Duplicate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_duplicate"), func = Marshal.GetFunctionPointerForDelegate(efl_duplicate_static_delegate) });
            }

            if (efl_input_timestamp_get_static_delegate == null)
            {
                efl_input_timestamp_get_static_delegate = new efl_input_timestamp_get_delegate(timestamp_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTimestamp") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_timestamp_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_timestamp_get_static_delegate) });
            }

            if (efl_input_timestamp_set_static_delegate == null)
            {
                efl_input_timestamp_set_static_delegate = new efl_input_timestamp_set_delegate(timestamp_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTimestamp") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_timestamp_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_timestamp_set_static_delegate) });
            }

            if (efl_input_device_get_static_delegate == null)
            {
                efl_input_device_get_static_delegate = new efl_input_device_get_delegate(device_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDevice") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_get_static_delegate) });
            }

            if (efl_input_device_set_static_delegate == null)
            {
                efl_input_device_set_static_delegate = new efl_input_device_set_delegate(device_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDevice") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_set_static_delegate) });
            }

            if (efl_input_event_flags_get_static_delegate == null)
            {
                efl_input_event_flags_get_static_delegate = new efl_input_event_flags_get_delegate(event_flags_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEventFlags") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_event_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_event_flags_get_static_delegate) });
            }

            if (efl_input_event_flags_set_static_delegate == null)
            {
                efl_input_event_flags_set_static_delegate = new efl_input_event_flags_set_delegate(event_flags_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetEventFlags") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_event_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_event_flags_set_static_delegate) });
            }

            if (efl_input_processed_get_static_delegate == null)
            {
                efl_input_processed_get_static_delegate = new efl_input_processed_get_delegate(processed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetProcessed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_processed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_processed_get_static_delegate) });
            }

            if (efl_input_processed_set_static_delegate == null)
            {
                efl_input_processed_set_static_delegate = new efl_input_processed_set_delegate(processed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetProcessed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_processed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_processed_set_static_delegate) });
            }

            if (efl_input_scrolling_get_static_delegate == null)
            {
                efl_input_scrolling_get_static_delegate = new efl_input_scrolling_get_delegate(scrolling_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetScrolling") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_scrolling_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_scrolling_get_static_delegate) });
            }

            if (efl_input_scrolling_set_static_delegate == null)
            {
                efl_input_scrolling_set_static_delegate = new efl_input_scrolling_set_delegate(scrolling_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScrolling") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_scrolling_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_scrolling_set_static_delegate) });
            }

            if (efl_input_fake_get_static_delegate == null)
            {
                efl_input_fake_get_static_delegate = new efl_input_fake_get_delegate(fake_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFake") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_fake_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_fake_get_static_delegate) });
            }

            if (efl_input_reset_static_delegate == null)
            {
                efl_input_reset_static_delegate = new efl_input_reset_delegate(reset);
            }

            if (methods.FirstOrDefault(m => m.Name == "Reset") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_input_reset_static_delegate) });
            }

            if (efl_input_modifier_enabled_get_static_delegate == null)
            {
                efl_input_modifier_enabled_get_static_delegate = new efl_input_modifier_enabled_get_delegate(modifier_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetModifierEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_modifier_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_modifier_enabled_get_static_delegate) });
            }

            if (efl_input_lock_enabled_get_static_delegate == null)
            {
                efl_input_lock_enabled_get_static_delegate = new efl_input_lock_enabled_get_delegate(lock_enabled_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLockEnabled") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_lock_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_lock_enabled_get_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
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

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        private delegate Efl.IDuplicate efl_duplicate_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.OwnTag>))]
        public delegate Efl.IDuplicate efl_duplicate_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_duplicate_api_delegate> efl_duplicate_ptr = new Efl.Eo.FunctionWrapper<efl_duplicate_api_delegate>(Module, "efl_duplicate");

        private static Efl.IDuplicate duplicate(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_duplicate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.IDuplicate _ret_var = default(Efl.IDuplicate);
                try
                {
                    _ret_var = ((Pointer)ws.Target).Duplicate();
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
                return efl_duplicate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_duplicate_delegate efl_duplicate_static_delegate;

        
        private delegate double efl_input_timestamp_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_input_timestamp_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_timestamp_get_api_delegate> efl_input_timestamp_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_timestamp_get_api_delegate>(Module, "efl_input_timestamp_get");

        private static double timestamp_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_timestamp_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetTimestamp();
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
                return efl_input_timestamp_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_timestamp_get_delegate efl_input_timestamp_get_static_delegate;

        
        private delegate void efl_input_timestamp_set_delegate(System.IntPtr obj, System.IntPtr pd,  double ms);

        
        public delegate void efl_input_timestamp_set_api_delegate(System.IntPtr obj,  double ms);

        public static Efl.Eo.FunctionWrapper<efl_input_timestamp_set_api_delegate> efl_input_timestamp_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_timestamp_set_api_delegate>(Module, "efl_input_timestamp_set");

        private static void timestamp_set(System.IntPtr obj, System.IntPtr pd, double ms)
        {
            Eina.Log.Debug("function efl_input_timestamp_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Pointer)ws.Target).SetTimestamp(ms);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_timestamp_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), ms);
            }
        }

        private static efl_input_timestamp_set_delegate efl_input_timestamp_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Input.Device efl_input_device_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Input.Device efl_input_device_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_device_get_api_delegate> efl_input_device_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_device_get_api_delegate>(Module, "efl_input_device_get");

        private static Efl.Input.Device device_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_device_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Input.Device _ret_var = default(Efl.Input.Device);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetDevice();
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
                return efl_input_device_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_device_get_delegate efl_input_device_get_static_delegate;

        
        private delegate void efl_input_device_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device dev);

        
        public delegate void efl_input_device_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device dev);

        public static Efl.Eo.FunctionWrapper<efl_input_device_set_api_delegate> efl_input_device_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_device_set_api_delegate>(Module, "efl_input_device_set");

        private static void device_set(System.IntPtr obj, System.IntPtr pd, Efl.Input.Device dev)
        {
            Eina.Log.Debug("function efl_input_device_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Pointer)ws.Target).SetDevice(dev);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_device_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dev);
            }
        }

        private static efl_input_device_set_delegate efl_input_device_set_static_delegate;

        
        private delegate Efl.Input.Flags efl_input_event_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Input.Flags efl_input_event_flags_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_event_flags_get_api_delegate> efl_input_event_flags_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_event_flags_get_api_delegate>(Module, "efl_input_event_flags_get");

        private static Efl.Input.Flags event_flags_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_event_flags_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Input.Flags _ret_var = default(Efl.Input.Flags);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetEventFlags();
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
                return efl_input_event_flags_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_event_flags_get_delegate efl_input_event_flags_get_static_delegate;

        
        private delegate void efl_input_event_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Flags flags);

        
        public delegate void efl_input_event_flags_set_api_delegate(System.IntPtr obj,  Efl.Input.Flags flags);

        public static Efl.Eo.FunctionWrapper<efl_input_event_flags_set_api_delegate> efl_input_event_flags_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_event_flags_set_api_delegate>(Module, "efl_input_event_flags_set");

        private static void event_flags_set(System.IntPtr obj, System.IntPtr pd, Efl.Input.Flags flags)
        {
            Eina.Log.Debug("function efl_input_event_flags_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Pointer)ws.Target).SetEventFlags(flags);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_event_flags_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), flags);
            }
        }

        private static efl_input_event_flags_set_delegate efl_input_event_flags_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_processed_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_processed_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_processed_get_api_delegate> efl_input_processed_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_processed_get_api_delegate>(Module, "efl_input_processed_get");

        private static bool processed_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_processed_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetProcessed();
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
                return efl_input_processed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_processed_get_delegate efl_input_processed_get_static_delegate;

        
        private delegate void efl_input_processed_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

        
        public delegate void efl_input_processed_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

        public static Efl.Eo.FunctionWrapper<efl_input_processed_set_api_delegate> efl_input_processed_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_processed_set_api_delegate>(Module, "efl_input_processed_set");

        private static void processed_set(System.IntPtr obj, System.IntPtr pd, bool val)
        {
            Eina.Log.Debug("function efl_input_processed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Pointer)ws.Target).SetProcessed(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_processed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_input_processed_set_delegate efl_input_processed_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_scrolling_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_scrolling_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_scrolling_get_api_delegate> efl_input_scrolling_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_scrolling_get_api_delegate>(Module, "efl_input_scrolling_get");

        private static bool scrolling_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_scrolling_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetScrolling();
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
                return efl_input_scrolling_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_scrolling_get_delegate efl_input_scrolling_get_static_delegate;

        
        private delegate void efl_input_scrolling_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

        
        public delegate void efl_input_scrolling_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

        public static Efl.Eo.FunctionWrapper<efl_input_scrolling_set_api_delegate> efl_input_scrolling_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_scrolling_set_api_delegate>(Module, "efl_input_scrolling_set");

        private static void scrolling_set(System.IntPtr obj, System.IntPtr pd, bool val)
        {
            Eina.Log.Debug("function efl_input_scrolling_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Pointer)ws.Target).SetScrolling(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_scrolling_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_input_scrolling_set_delegate efl_input_scrolling_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_fake_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_fake_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_fake_get_api_delegate> efl_input_fake_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_fake_get_api_delegate>(Module, "efl_input_fake_get");

        private static bool fake_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_fake_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetFake();
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
                return efl_input_fake_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_fake_get_delegate efl_input_fake_get_static_delegate;

        
        private delegate void efl_input_reset_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_input_reset_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_reset_api_delegate> efl_input_reset_ptr = new Efl.Eo.FunctionWrapper<efl_input_reset_api_delegate>(Module, "efl_input_reset");

        private static void reset(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_reset was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Pointer)ws.Target).Reset();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_input_reset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_reset_delegate efl_input_reset_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_modifier_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_modifier_enabled_get_api_delegate(System.IntPtr obj,  Efl.Input.Modifier mod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        public static Efl.Eo.FunctionWrapper<efl_input_modifier_enabled_get_api_delegate> efl_input_modifier_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_modifier_enabled_get_api_delegate>(Module, "efl_input_modifier_enabled_get");

        private static bool modifier_enabled_get(System.IntPtr obj, System.IntPtr pd, Efl.Input.Modifier mod, Efl.Input.Device seat)
        {
            Eina.Log.Debug("function efl_input_modifier_enabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetModifierEnabled(mod, seat);
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
                return efl_input_modifier_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mod, seat);
            }
        }

        private static efl_input_modifier_enabled_get_delegate efl_input_modifier_enabled_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_lock_enabled_get_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_lock_enabled_get_api_delegate(System.IntPtr obj,  Efl.Input.Lock kw_lock, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Input.Device seat);

        public static Efl.Eo.FunctionWrapper<efl_input_lock_enabled_get_api_delegate> efl_input_lock_enabled_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_lock_enabled_get_api_delegate>(Module, "efl_input_lock_enabled_get");

        private static bool lock_enabled_get(System.IntPtr obj, System.IntPtr pd, Efl.Input.Lock kw_lock, Efl.Input.Device seat)
        {
            Eina.Log.Debug("function efl_input_lock_enabled_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetLockEnabled(kw_lock, seat);
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
                return efl_input_lock_enabled_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), kw_lock, seat);
            }
        }

        private static efl_input_lock_enabled_get_delegate efl_input_lock_enabled_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

