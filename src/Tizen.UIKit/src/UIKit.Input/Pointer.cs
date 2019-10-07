#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

namespace Input {

/// <summary>Event data carried over with any pointer event (mouse, touch, pen, ...)</summary>
[UIKit.Input.Pointer.NativeMethods]
[UIKit.Wrapper.BindingEntity]
public class Pointer : UIKit.Object, UIKit.Input.IEvent, UIKit.Input.IState
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Pointer))
            {
                return GetUIKitClassStatic();
            }
            else
            {
                return UIKit.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(UIKit.Libs.Evas)] internal static extern System.IntPtr
        efl_input_pointer_class_get();

    /// <summary>Initializes a new instance of the <see cref="Pointer"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <since_tizen> 6 </since_tizen>
    public Pointer(UIKit.Object parent= null
            ) : base(efl_input_pointer_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    /// <since_tizen> 6 </since_tizen>
    protected Pointer(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Pointer"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    /// <since_tizen> 6 </since_tizen>
    protected Pointer(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Pointer"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The UIKit.Object parent of this instance.</param>
    protected Pointer(IntPtr baseKlass, UIKit.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>The action represented by this event.</summary>
    /// <returns>Event action</returns>
    public virtual UIKit.Pointer.Action GetAction() {
        var _ret_var = UIKit.Input.Pointer.NativeMethods.efl_input_pointer_action_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The action represented by this event.</summary>
    /// <param name="act">Event action</param>
    public virtual void SetAction(UIKit.Pointer.Action act) {
        UIKit.Input.Pointer.NativeMethods.efl_input_pointer_action_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),act);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The mouse button that triggered the event.
    /// Valid if and only if <span class="text-muted">UIKit.Input.Pointer.GetValueHas (object still in beta stage)</span>(<c>button</c>) is <c>true</c>.</summary>
    /// <returns>1 to 32, 0 if not a button event.</returns>
    public virtual int GetButton() {
        var _ret_var = UIKit.Input.Pointer.NativeMethods.efl_input_pointer_button_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The mouse button that triggered the event.
    /// Valid if and only if <span class="text-muted">UIKit.Input.Pointer.GetValueHas (object still in beta stage)</span>(<c>button</c>) is <c>true</c>.</summary>
    /// <param name="but">1 to 32, 0 if not a button event.</param>
    public virtual void SetButton(int but) {
        UIKit.Input.Pointer.NativeMethods.efl_input_pointer_button_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),but);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Whether a mouse button is pressed at the moment of the event.
    /// Valid if and only if <span class="text-muted">UIKit.Input.Pointer.GetValueHas (object still in beta stage)</span>(<c>button_pressed</c>) is <c>true</c>.</summary>
    /// <param name="button">1 to 32, 0 if not a button event.</param>
    /// <returns><c>true</c> when the button was pressed, <c>false</c> otherwise</returns>
    public virtual bool GetButtonPressed(int button) {
        var _ret_var = UIKit.Input.Pointer.NativeMethods.efl_input_pointer_button_pressed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),button);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Whether a mouse button is pressed at the moment of the event.
    /// Valid if and only if <span class="text-muted">UIKit.Input.Pointer.GetValueHas (object still in beta stage)</span>(<c>button_pressed</c>) is <c>true</c>.</summary>
    /// <param name="button">1 to 32, 0 if not a button event.</param>
    /// <param name="pressed"><c>true</c> when the button was pressed, <c>false</c> otherwise</param>
    public virtual void SetButtonPressed(int button, bool pressed) {
        UIKit.Input.Pointer.NativeMethods.efl_input_pointer_button_pressed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),button, pressed);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Position where the event happened, relative to the window.
    /// See <see cref="UIKit.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).</summary>
    /// <returns>The position of the event, in pixels.</returns>
    public virtual UIKit.DataTypes.Position2D GetPosition() {
        var _ret_var = UIKit.Input.Pointer.NativeMethods.efl_input_pointer_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Position where the event happened, relative to the window.
    /// See <see cref="UIKit.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).</summary>
    /// <param name="pos">The position of the event, in pixels.</param>
    public virtual void SetPosition(UIKit.DataTypes.Position2D pos) {
        UIKit.DataTypes.Position2D.NativeStruct _in_pos = pos;
UIKit.Input.Pointer.NativeMethods.efl_input_pointer_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Position where the event happened, relative to the window.
    /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="UIKit.Input.Pointer.Position"/>.
    /// 
    /// See also <see cref="UIKit.Input.Pointer.Position"/>.</summary>
    /// <returns>The position of the event, in pixels.</returns>
    public virtual UIKit.DataTypes.Vector2 GetPrecisePosition() {
        var _ret_var = UIKit.Input.Pointer.NativeMethods.efl_input_pointer_precise_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Position where the event happened, relative to the window.
    /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="UIKit.Input.Pointer.Position"/>.
    /// 
    /// See also <see cref="UIKit.Input.Pointer.Position"/>.</summary>
    /// <param name="pos">The position of the event, in pixels.</param>
    public virtual void SetPrecisePosition(UIKit.DataTypes.Vector2 pos) {
        UIKit.DataTypes.Vector2.NativeStruct _in_pos = pos;
UIKit.Input.Pointer.NativeMethods.efl_input_pointer_precise_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Position of the previous event, valid for move events.
    /// Relative to the window. May be equal to <see cref="UIKit.Input.Pointer.Position"/> (by default).
    /// 
    /// This position, in integers, is an approximation of <span class="text-muted">UIKit.Input.Pointer.GetValue (object still in beta stage)</span>(<c>previous_x</c>), <span class="text-muted">UIKit.Input.Pointer.GetValue (object still in beta stage)</span>(<c>previous_y</c>). Use <see cref="UIKit.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.</summary>
    /// <returns>The position of the event, in pixels.</returns>
    public virtual UIKit.DataTypes.Position2D GetPreviousPosition() {
        var _ret_var = UIKit.Input.Pointer.NativeMethods.efl_input_pointer_previous_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Position of the previous event, valid for move events.
    /// Relative to the window. May be equal to <see cref="UIKit.Input.Pointer.Position"/> (by default).
    /// 
    /// This position, in integers, is an approximation of <span class="text-muted">UIKit.Input.Pointer.GetValue (object still in beta stage)</span>(<c>previous_x</c>), <span class="text-muted">UIKit.Input.Pointer.GetValue (object still in beta stage)</span>(<c>previous_y</c>). Use <see cref="UIKit.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.</summary>
    /// <param name="pos">The position of the event, in pixels.</param>
    public virtual void SetPreviousPosition(UIKit.DataTypes.Position2D pos) {
        UIKit.DataTypes.Position2D.NativeStruct _in_pos = pos;
UIKit.Input.Pointer.NativeMethods.efl_input_pointer_previous_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_pos);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The ID associated with this pointer.
    /// In case there are multiple pointers (for example when multiple fingers are touching the screen) this number uniquely identifies each pointer, for as long as it is present. This is, when a finger is lifted its ID can be later reused by another finger touching the screen.</summary>
    /// <returns>An ID uniquely identifying this pointer among the currently present pointers.</returns>
    public virtual int GetTouchId() {
        var _ret_var = UIKit.Input.Pointer.NativeMethods.efl_input_pointer_touch_id_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The ID associated with this pointer.
    /// In case there are multiple pointers (for example when multiple fingers are touching the screen) this number uniquely identifies each pointer, for as long as it is present. This is, when a finger is lifted its ID can be later reused by another finger touching the screen.</summary>
    /// <param name="id">An ID uniquely identifying this pointer among the currently present pointers.</param>
    public virtual void SetTouchId(int id) {
        UIKit.Input.Pointer.NativeMethods.efl_input_pointer_touch_id_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),id);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The object where this event first originated, in case of propagation or repetition of the event.</summary>
    /// <returns>Source object: <see cref="UIKit.Gfx.IEntity"/></returns>
    public virtual UIKit.Object GetSource() {
        var _ret_var = UIKit.Input.Pointer.NativeMethods.efl_input_pointer_source_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The object where this event first originated, in case of propagation or repetition of the event.</summary>
    /// <param name="src">Source object: <see cref="UIKit.Gfx.IEntity"/></param>
    public virtual void SetSource(UIKit.Object src) {
        UIKit.Input.Pointer.NativeMethods.efl_input_pointer_source_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),src);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Double or triple click information.</summary>
    /// <returns>Button information flags</returns>
    public virtual UIKit.Pointer.Flags GetButtonFlags() {
        var _ret_var = UIKit.Input.Pointer.NativeMethods.efl_input_pointer_button_flags_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Double or triple click information.</summary>
    /// <param name="flags">Button information flags</param>
    public virtual void SetButtonFlags(UIKit.Pointer.Flags flags) {
        UIKit.Input.Pointer.NativeMethods.efl_input_pointer_button_flags_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),flags);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
    /// This is just a helper function around <see cref="UIKit.Input.Pointer.ButtonFlags"/>.</summary>
    /// <returns><c>true</c> if the button press was a double click, <c>false</c> otherwise</returns>
    public virtual bool GetDoubleClick() {
        var _ret_var = UIKit.Input.Pointer.NativeMethods.efl_input_pointer_double_click_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
    /// This is just a helper function around <see cref="UIKit.Input.Pointer.ButtonFlags"/>.</summary>
    /// <param name="val"><c>true</c> if the button press was a double click, <c>false</c> otherwise</param>
    public virtual void SetDoubleClick(bool val) {
        UIKit.Input.Pointer.NativeMethods.efl_input_pointer_double_click_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
    /// This is just a helper function around <see cref="UIKit.Input.Pointer.ButtonFlags"/>.</summary>
    /// <returns><c>true</c> if the button press was a triple click, <c>false</c> otherwise</returns>
    public virtual bool GetTripleClick() {
        var _ret_var = UIKit.Input.Pointer.NativeMethods.efl_input_pointer_triple_click_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
    /// This is just a helper function around <see cref="UIKit.Input.Pointer.ButtonFlags"/>.</summary>
    /// <param name="val"><c>true</c> if the button press was a triple click, <c>false</c> otherwise</param>
    public virtual void SetTripleClick(bool val) {
        UIKit.Input.Pointer.NativeMethods.efl_input_pointer_triple_click_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Direction of the wheel, usually vertical.</summary>
    /// <returns>If <c>true</c> this was a horizontal wheel.</returns>
    public virtual bool GetWheelHorizontal() {
        var _ret_var = UIKit.Input.Pointer.NativeMethods.efl_input_pointer_wheel_horizontal_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Direction of the wheel, usually vertical.</summary>
    /// <param name="horizontal">If <c>true</c> this was a horizontal wheel.<br/>The default value is <c>false</c>.</param>
    public virtual void SetWheelHorizontal(bool horizontal) {
        UIKit.Input.Pointer.NativeMethods.efl_input_pointer_wheel_horizontal_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),horizontal);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Delta movement of the wheel in discrete steps.</summary>
    /// <returns>Wheel movement delta</returns>
    public virtual int GetWheelDelta() {
        var _ret_var = UIKit.Input.Pointer.NativeMethods.efl_input_pointer_wheel_delta_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Delta movement of the wheel in discrete steps.</summary>
    /// <param name="dist">Wheel movement delta</param>
    public virtual void SetWheelDelta(int dist) {
        UIKit.Input.Pointer.NativeMethods.efl_input_pointer_wheel_delta_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),dist);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The time at which an event was generated.
    /// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Time in milliseconds when the event happened.</returns>
    public virtual double GetTimestamp() {
        var _ret_var = UIKit.Input.EventConcrete.NativeMethods.efl_input_timestamp_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Call this when generating events manually.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="ms">Time in milliseconds when the event happened.</param>
    public virtual void SetTimestamp(double ms) {
        UIKit.Input.EventConcrete.NativeMethods.efl_input_timestamp_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),ms);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Input device that originated this event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Input device origin</returns>
    public virtual UIKit.Input.Device GetDevice() {
        var _ret_var = UIKit.Input.EventConcrete.NativeMethods.efl_input_device_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Input device that originated this event.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="dev">Input device origin</param>
    public virtual void SetDevice(UIKit.Input.Device dev) {
        UIKit.Input.EventConcrete.NativeMethods.efl_input_device_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),dev);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Input event flags</returns>
    public virtual UIKit.Input.Flags GetEventFlags() {
        var _ret_var = UIKit.Input.EventConcrete.NativeMethods.efl_input_event_flags_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="flags">Input event flags</param>
    public virtual void SetEventFlags(UIKit.Input.Flags flags) {
        UIKit.Input.EventConcrete.NativeMethods.efl_input_event_flags_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),flags);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the event is on hold, <c>false</c> otherwise</returns>
    public virtual bool GetProcessed() {
        var _ret_var = UIKit.Input.EventConcrete.NativeMethods.efl_input_processed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val"><c>true</c> if the event is on hold, <c>false</c> otherwise</param>
    public virtual void SetProcessed(bool val) {
        UIKit.Input.EventConcrete.NativeMethods.efl_input_processed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</returns>
    public virtual bool GetScrolling() {
        var _ret_var = UIKit.Input.EventConcrete.NativeMethods.efl_input_scrolling_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="val"><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</param>
    public virtual void SetScrolling(bool val) {
        UIKit.Input.EventConcrete.NativeMethods.efl_input_scrolling_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary><c>true</c> if the event was fake, not triggered by real hardware.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the event was not from real hardware, <c>false</c> otherwise</returns>
    public virtual bool GetFake() {
        var _ret_var = UIKit.Input.EventConcrete.NativeMethods.efl_input_fake_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Resets the internal data to 0 or default values.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void Reset() {
        UIKit.Input.EventConcrete.NativeMethods.efl_input_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The action represented by this event.</summary>
    /// <value>Event action</value>
    public UIKit.Pointer.Action Action {
        get { return GetAction(); }
        set { SetAction(value); }
    }

    /// <summary>The mouse button that triggered the event.
    /// Valid if and only if <span class="text-muted">UIKit.Input.Pointer.GetValueHas (object still in beta stage)</span>(<c>button</c>) is <c>true</c>.</summary>
    /// <value>1 to 32, 0 if not a button event.</value>
    public int Button {
        get { return GetButton(); }
        set { SetButton(value); }
    }

    /// <summary>Position where the event happened, relative to the window.
    /// See <see cref="UIKit.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).</summary>
    /// <value>The position of the event, in pixels.</value>
    public UIKit.DataTypes.Position2D Position {
        get { return GetPosition(); }
        set { SetPosition(value); }
    }

    /// <summary>Position where the event happened, relative to the window.
    /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="UIKit.Input.Pointer.Position"/>.
    /// 
    /// See also <see cref="UIKit.Input.Pointer.Position"/>.</summary>
    /// <value>The position of the event, in pixels.</value>
    public UIKit.DataTypes.Vector2 PrecisePosition {
        get { return GetPrecisePosition(); }
        set { SetPrecisePosition(value); }
    }

    /// <summary>Position of the previous event, valid for move events.
    /// Relative to the window. May be equal to <see cref="UIKit.Input.Pointer.Position"/> (by default).
    /// 
    /// This position, in integers, is an approximation of <span class="text-muted">UIKit.Input.Pointer.GetValue (object still in beta stage)</span>(<c>previous_x</c>), <span class="text-muted">UIKit.Input.Pointer.GetValue (object still in beta stage)</span>(<c>previous_y</c>). Use <see cref="UIKit.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.</summary>
    /// <value>The position of the event, in pixels.</value>
    public UIKit.DataTypes.Position2D PreviousPosition {
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
    /// <value>Source object: <see cref="UIKit.Gfx.IEntity"/></value>
    public UIKit.Object Source {
        get { return GetSource(); }
        set { SetSource(value); }
    }

    /// <summary>Double or triple click information.</summary>
    /// <value>Button information flags</value>
    public UIKit.Pointer.Flags ButtonFlags {
        get { return GetButtonFlags(); }
        set { SetButtonFlags(value); }
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
    /// This is just a helper function around <see cref="UIKit.Input.Pointer.ButtonFlags"/>.</summary>
    /// <value><c>true</c> if the button press was a double click, <c>false</c> otherwise</value>
    public bool DoubleClick {
        get { return GetDoubleClick(); }
        set { SetDoubleClick(value); }
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
    /// This is just a helper function around <see cref="UIKit.Input.Pointer.ButtonFlags"/>.</summary>
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
    public UIKit.Input.Device Device {
        get { return GetDevice(); }
        set { SetDevice(value); }
    }

    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Input event flags</value>
    public UIKit.Input.Flags EventFlags {
        get { return GetEventFlags(); }
        set { SetEventFlags(value); }
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if the event is on hold, <c>false</c> otherwise</value>
    public bool Processed {
        get { return GetProcessed(); }
        set { SetProcessed(value); }
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
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

    private static IntPtr GetUIKitClassStatic()
    {
        return UIKit.Input.Pointer.efl_input_pointer_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : UIKit.Object.NativeMethods
    {
        private static UIKit.Wrapper.NativeModule Module = new UIKit.Wrapper.NativeModule(UIKit.Libs.Evas);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<UIKit_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<UIKit_Op_Description>();
            var methods = UIKit.Wrapper.Globals.GetUserMethods(type);

            if (efl_input_pointer_action_get_static_delegate == null)
            {
                efl_input_pointer_action_get_static_delegate = new efl_input_pointer_action_get_delegate(action_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAction") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_action_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_action_get_static_delegate) });
            }

            if (efl_input_pointer_action_set_static_delegate == null)
            {
                efl_input_pointer_action_set_static_delegate = new efl_input_pointer_action_set_delegate(action_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAction") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_action_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_action_set_static_delegate) });
            }

            if (efl_input_pointer_button_get_static_delegate == null)
            {
                efl_input_pointer_button_get_static_delegate = new efl_input_pointer_button_get_delegate(button_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetButton") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_get_static_delegate) });
            }

            if (efl_input_pointer_button_set_static_delegate == null)
            {
                efl_input_pointer_button_set_static_delegate = new efl_input_pointer_button_set_delegate(button_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetButton") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_set_static_delegate) });
            }

            if (efl_input_pointer_button_pressed_get_static_delegate == null)
            {
                efl_input_pointer_button_pressed_get_static_delegate = new efl_input_pointer_button_pressed_get_delegate(button_pressed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetButtonPressed") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_pressed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_pressed_get_static_delegate) });
            }

            if (efl_input_pointer_button_pressed_set_static_delegate == null)
            {
                efl_input_pointer_button_pressed_set_static_delegate = new efl_input_pointer_button_pressed_set_delegate(button_pressed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetButtonPressed") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_pressed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_pressed_set_static_delegate) });
            }

            if (efl_input_pointer_position_get_static_delegate == null)
            {
                efl_input_pointer_position_get_static_delegate = new efl_input_pointer_position_get_delegate(position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPosition") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_position_get_static_delegate) });
            }

            if (efl_input_pointer_position_set_static_delegate == null)
            {
                efl_input_pointer_position_set_static_delegate = new efl_input_pointer_position_set_delegate(position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPosition") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_position_set_static_delegate) });
            }

            if (efl_input_pointer_precise_position_get_static_delegate == null)
            {
                efl_input_pointer_precise_position_get_static_delegate = new efl_input_pointer_precise_position_get_delegate(precise_position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPrecisePosition") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_precise_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_precise_position_get_static_delegate) });
            }

            if (efl_input_pointer_precise_position_set_static_delegate == null)
            {
                efl_input_pointer_precise_position_set_static_delegate = new efl_input_pointer_precise_position_set_delegate(precise_position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPrecisePosition") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_precise_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_precise_position_set_static_delegate) });
            }

            if (efl_input_pointer_previous_position_get_static_delegate == null)
            {
                efl_input_pointer_previous_position_get_static_delegate = new efl_input_pointer_previous_position_get_delegate(previous_position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPreviousPosition") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_previous_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_previous_position_get_static_delegate) });
            }

            if (efl_input_pointer_previous_position_set_static_delegate == null)
            {
                efl_input_pointer_previous_position_set_static_delegate = new efl_input_pointer_previous_position_set_delegate(previous_position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPreviousPosition") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_previous_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_previous_position_set_static_delegate) });
            }

            if (efl_input_pointer_touch_id_get_static_delegate == null)
            {
                efl_input_pointer_touch_id_get_static_delegate = new efl_input_pointer_touch_id_get_delegate(touch_id_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTouchId") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_touch_id_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_touch_id_get_static_delegate) });
            }

            if (efl_input_pointer_touch_id_set_static_delegate == null)
            {
                efl_input_pointer_touch_id_set_static_delegate = new efl_input_pointer_touch_id_set_delegate(touch_id_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTouchId") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_touch_id_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_touch_id_set_static_delegate) });
            }

            if (efl_input_pointer_source_get_static_delegate == null)
            {
                efl_input_pointer_source_get_static_delegate = new efl_input_pointer_source_get_delegate(source_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSource") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_source_get_static_delegate) });
            }

            if (efl_input_pointer_source_set_static_delegate == null)
            {
                efl_input_pointer_source_set_static_delegate = new efl_input_pointer_source_set_delegate(source_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSource") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_source_set_static_delegate) });
            }

            if (efl_input_pointer_button_flags_get_static_delegate == null)
            {
                efl_input_pointer_button_flags_get_static_delegate = new efl_input_pointer_button_flags_get_delegate(button_flags_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetButtonFlags") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_flags_get_static_delegate) });
            }

            if (efl_input_pointer_button_flags_set_static_delegate == null)
            {
                efl_input_pointer_button_flags_set_static_delegate = new efl_input_pointer_button_flags_set_delegate(button_flags_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetButtonFlags") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_flags_set_static_delegate) });
            }

            if (efl_input_pointer_double_click_get_static_delegate == null)
            {
                efl_input_pointer_double_click_get_static_delegate = new efl_input_pointer_double_click_get_delegate(double_click_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDoubleClick") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_double_click_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_double_click_get_static_delegate) });
            }

            if (efl_input_pointer_double_click_set_static_delegate == null)
            {
                efl_input_pointer_double_click_set_static_delegate = new efl_input_pointer_double_click_set_delegate(double_click_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDoubleClick") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_double_click_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_double_click_set_static_delegate) });
            }

            if (efl_input_pointer_triple_click_get_static_delegate == null)
            {
                efl_input_pointer_triple_click_get_static_delegate = new efl_input_pointer_triple_click_get_delegate(triple_click_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTripleClick") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_triple_click_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_triple_click_get_static_delegate) });
            }

            if (efl_input_pointer_triple_click_set_static_delegate == null)
            {
                efl_input_pointer_triple_click_set_static_delegate = new efl_input_pointer_triple_click_set_delegate(triple_click_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTripleClick") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_triple_click_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_triple_click_set_static_delegate) });
            }

            if (efl_input_pointer_wheel_horizontal_get_static_delegate == null)
            {
                efl_input_pointer_wheel_horizontal_get_static_delegate = new efl_input_pointer_wheel_horizontal_get_delegate(wheel_horizontal_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWheelHorizontal") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_wheel_horizontal_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_horizontal_get_static_delegate) });
            }

            if (efl_input_pointer_wheel_horizontal_set_static_delegate == null)
            {
                efl_input_pointer_wheel_horizontal_set_static_delegate = new efl_input_pointer_wheel_horizontal_set_delegate(wheel_horizontal_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWheelHorizontal") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_wheel_horizontal_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_horizontal_set_static_delegate) });
            }

            if (efl_input_pointer_wheel_delta_get_static_delegate == null)
            {
                efl_input_pointer_wheel_delta_get_static_delegate = new efl_input_pointer_wheel_delta_get_delegate(wheel_delta_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetWheelDelta") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_wheel_delta_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_delta_get_static_delegate) });
            }

            if (efl_input_pointer_wheel_delta_set_static_delegate == null)
            {
                efl_input_pointer_wheel_delta_set_static_delegate = new efl_input_pointer_wheel_delta_set_delegate(wheel_delta_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetWheelDelta") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_wheel_delta_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_delta_set_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((UIKit.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is UIKit.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetUIKitClass()
        {
            return UIKit.Input.Pointer.efl_input_pointer_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate UIKit.Pointer.Action efl_input_pointer_action_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.Pointer.Action efl_input_pointer_action_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_action_get_api_delegate> efl_input_pointer_action_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_action_get_api_delegate>(Module, "efl_input_pointer_action_get");

        private static UIKit.Pointer.Action action_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_action_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Pointer.Action _ret_var = default(UIKit.Pointer.Action);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetAction();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_input_pointer_action_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_action_get_delegate efl_input_pointer_action_get_static_delegate;

        
        private delegate void efl_input_pointer_action_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.Pointer.Action act);

        
        public delegate void efl_input_pointer_action_set_api_delegate(System.IntPtr obj,  UIKit.Pointer.Action act);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_action_set_api_delegate> efl_input_pointer_action_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_action_set_api_delegate>(Module, "efl_input_pointer_action_set");

        private static void action_set(System.IntPtr obj, System.IntPtr pd, UIKit.Pointer.Action act)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_action_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetAction(act);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_action_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), act);
            }
        }

        private static efl_input_pointer_action_set_delegate efl_input_pointer_action_set_static_delegate;

        
        private delegate int efl_input_pointer_button_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_input_pointer_button_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_button_get_api_delegate> efl_input_pointer_button_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_button_get_api_delegate>(Module, "efl_input_pointer_button_get");

        private static int button_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_button_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetButton();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_input_pointer_button_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_button_get_delegate efl_input_pointer_button_get_static_delegate;

        
        private delegate void efl_input_pointer_button_set_delegate(System.IntPtr obj, System.IntPtr pd,  int but);

        
        public delegate void efl_input_pointer_button_set_api_delegate(System.IntPtr obj,  int but);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_button_set_api_delegate> efl_input_pointer_button_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_button_set_api_delegate>(Module, "efl_input_pointer_button_set");

        private static void button_set(System.IntPtr obj, System.IntPtr pd, int but)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_button_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetButton(but);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_button_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), but);
            }
        }

        private static efl_input_pointer_button_set_delegate efl_input_pointer_button_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_pointer_button_pressed_get_delegate(System.IntPtr obj, System.IntPtr pd,  int button);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_pointer_button_pressed_get_api_delegate(System.IntPtr obj,  int button);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_button_pressed_get_api_delegate> efl_input_pointer_button_pressed_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_button_pressed_get_api_delegate>(Module, "efl_input_pointer_button_pressed_get");

        private static bool button_pressed_get(System.IntPtr obj, System.IntPtr pd, int button)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_button_pressed_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetButtonPressed(button);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_input_pointer_button_pressed_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), button);
            }
        }

        private static efl_input_pointer_button_pressed_get_delegate efl_input_pointer_button_pressed_get_static_delegate;

        
        private delegate void efl_input_pointer_button_pressed_set_delegate(System.IntPtr obj, System.IntPtr pd,  int button, [MarshalAs(UnmanagedType.U1)] bool pressed);

        
        public delegate void efl_input_pointer_button_pressed_set_api_delegate(System.IntPtr obj,  int button, [MarshalAs(UnmanagedType.U1)] bool pressed);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_button_pressed_set_api_delegate> efl_input_pointer_button_pressed_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_button_pressed_set_api_delegate>(Module, "efl_input_pointer_button_pressed_set");

        private static void button_pressed_set(System.IntPtr obj, System.IntPtr pd, int button, bool pressed)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_button_pressed_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetButtonPressed(button, pressed);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_button_pressed_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), button, pressed);
            }
        }

        private static efl_input_pointer_button_pressed_set_delegate efl_input_pointer_button_pressed_set_static_delegate;

        
        private delegate UIKit.DataTypes.Position2D.NativeStruct efl_input_pointer_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.DataTypes.Position2D.NativeStruct efl_input_pointer_position_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_position_get_api_delegate> efl_input_pointer_position_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_position_get_api_delegate>(Module, "efl_input_pointer_position_get");

        private static UIKit.DataTypes.Position2D.NativeStruct position_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_position_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Position2D _ret_var = default(UIKit.DataTypes.Position2D);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetPosition();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_input_pointer_position_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_position_get_delegate efl_input_pointer_position_get_static_delegate;

        
        private delegate void efl_input_pointer_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.DataTypes.Position2D.NativeStruct pos);

        
        public delegate void efl_input_pointer_position_set_api_delegate(System.IntPtr obj,  UIKit.DataTypes.Position2D.NativeStruct pos);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_position_set_api_delegate> efl_input_pointer_position_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_position_set_api_delegate>(Module, "efl_input_pointer_position_set");

        private static void position_set(System.IntPtr obj, System.IntPtr pd, UIKit.DataTypes.Position2D.NativeStruct pos)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_position_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Position2D _in_pos = pos;

                try
                {
                    ((Pointer)ws.Target).SetPosition(_in_pos);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_position_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_input_pointer_position_set_delegate efl_input_pointer_position_set_static_delegate;

        
        private delegate UIKit.DataTypes.Vector2.NativeStruct efl_input_pointer_precise_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.DataTypes.Vector2.NativeStruct efl_input_pointer_precise_position_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_precise_position_get_api_delegate> efl_input_pointer_precise_position_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_precise_position_get_api_delegate>(Module, "efl_input_pointer_precise_position_get");

        private static UIKit.DataTypes.Vector2.NativeStruct precise_position_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_precise_position_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Vector2 _ret_var = default(UIKit.DataTypes.Vector2);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetPrecisePosition();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_input_pointer_precise_position_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_precise_position_get_delegate efl_input_pointer_precise_position_get_static_delegate;

        
        private delegate void efl_input_pointer_precise_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.DataTypes.Vector2.NativeStruct pos);

        
        public delegate void efl_input_pointer_precise_position_set_api_delegate(System.IntPtr obj,  UIKit.DataTypes.Vector2.NativeStruct pos);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_precise_position_set_api_delegate> efl_input_pointer_precise_position_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_precise_position_set_api_delegate>(Module, "efl_input_pointer_precise_position_set");

        private static void precise_position_set(System.IntPtr obj, System.IntPtr pd, UIKit.DataTypes.Vector2.NativeStruct pos)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_precise_position_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Vector2 _in_pos = pos;

                try
                {
                    ((Pointer)ws.Target).SetPrecisePosition(_in_pos);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_precise_position_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_input_pointer_precise_position_set_delegate efl_input_pointer_precise_position_set_static_delegate;

        
        private delegate UIKit.DataTypes.Position2D.NativeStruct efl_input_pointer_previous_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.DataTypes.Position2D.NativeStruct efl_input_pointer_previous_position_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_previous_position_get_api_delegate> efl_input_pointer_previous_position_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_previous_position_get_api_delegate>(Module, "efl_input_pointer_previous_position_get");

        private static UIKit.DataTypes.Position2D.NativeStruct previous_position_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_previous_position_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Position2D _ret_var = default(UIKit.DataTypes.Position2D);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetPreviousPosition();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_input_pointer_previous_position_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_previous_position_get_delegate efl_input_pointer_previous_position_get_static_delegate;

        
        private delegate void efl_input_pointer_previous_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.DataTypes.Position2D.NativeStruct pos);

        
        public delegate void efl_input_pointer_previous_position_set_api_delegate(System.IntPtr obj,  UIKit.DataTypes.Position2D.NativeStruct pos);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_previous_position_set_api_delegate> efl_input_pointer_previous_position_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_previous_position_set_api_delegate>(Module, "efl_input_pointer_previous_position_set");

        private static void previous_position_set(System.IntPtr obj, System.IntPtr pd, UIKit.DataTypes.Position2D.NativeStruct pos)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_previous_position_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Position2D _in_pos = pos;

                try
                {
                    ((Pointer)ws.Target).SetPreviousPosition(_in_pos);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_previous_position_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), pos);
            }
        }

        private static efl_input_pointer_previous_position_set_delegate efl_input_pointer_previous_position_set_static_delegate;

        
        private delegate int efl_input_pointer_touch_id_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_input_pointer_touch_id_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_touch_id_get_api_delegate> efl_input_pointer_touch_id_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_touch_id_get_api_delegate>(Module, "efl_input_pointer_touch_id_get");

        private static int touch_id_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_touch_id_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetTouchId();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_input_pointer_touch_id_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_touch_id_get_delegate efl_input_pointer_touch_id_get_static_delegate;

        
        private delegate void efl_input_pointer_touch_id_set_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

        
        public delegate void efl_input_pointer_touch_id_set_api_delegate(System.IntPtr obj,  int id);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_touch_id_set_api_delegate> efl_input_pointer_touch_id_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_touch_id_set_api_delegate>(Module, "efl_input_pointer_touch_id_set");

        private static void touch_id_set(System.IntPtr obj, System.IntPtr pd, int id)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_touch_id_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetTouchId(id);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_touch_id_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), id);
            }
        }

        private static efl_input_pointer_touch_id_set_delegate efl_input_pointer_touch_id_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        private delegate UIKit.Object efl_input_pointer_source_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        public delegate UIKit.Object efl_input_pointer_source_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_source_get_api_delegate> efl_input_pointer_source_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_source_get_api_delegate>(Module, "efl_input_pointer_source_get");

        private static UIKit.Object source_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_source_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Object _ret_var = default(UIKit.Object);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetSource();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_input_pointer_source_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_source_get_delegate efl_input_pointer_source_get_static_delegate;

        
        private delegate void efl_input_pointer_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Object src);

        
        public delegate void efl_input_pointer_source_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Object src);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_source_set_api_delegate> efl_input_pointer_source_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_source_set_api_delegate>(Module, "efl_input_pointer_source_set");

        private static void source_set(System.IntPtr obj, System.IntPtr pd, UIKit.Object src)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_source_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetSource(src);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_source_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), src);
            }
        }

        private static efl_input_pointer_source_set_delegate efl_input_pointer_source_set_static_delegate;

        
        private delegate UIKit.Pointer.Flags efl_input_pointer_button_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.Pointer.Flags efl_input_pointer_button_flags_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_button_flags_get_api_delegate> efl_input_pointer_button_flags_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_button_flags_get_api_delegate>(Module, "efl_input_pointer_button_flags_get");

        private static UIKit.Pointer.Flags button_flags_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_button_flags_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Pointer.Flags _ret_var = default(UIKit.Pointer.Flags);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetButtonFlags();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_input_pointer_button_flags_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_button_flags_get_delegate efl_input_pointer_button_flags_get_static_delegate;

        
        private delegate void efl_input_pointer_button_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.Pointer.Flags flags);

        
        public delegate void efl_input_pointer_button_flags_set_api_delegate(System.IntPtr obj,  UIKit.Pointer.Flags flags);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_button_flags_set_api_delegate> efl_input_pointer_button_flags_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_button_flags_set_api_delegate>(Module, "efl_input_pointer_button_flags_set");

        private static void button_flags_set(System.IntPtr obj, System.IntPtr pd, UIKit.Pointer.Flags flags)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_button_flags_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetButtonFlags(flags);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_button_flags_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), flags);
            }
        }

        private static efl_input_pointer_button_flags_set_delegate efl_input_pointer_button_flags_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_pointer_double_click_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_pointer_double_click_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_double_click_get_api_delegate> efl_input_pointer_double_click_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_double_click_get_api_delegate>(Module, "efl_input_pointer_double_click_get");

        private static bool double_click_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_double_click_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetDoubleClick();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_input_pointer_double_click_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_double_click_get_delegate efl_input_pointer_double_click_get_static_delegate;

        
        private delegate void efl_input_pointer_double_click_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

        
        public delegate void efl_input_pointer_double_click_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_double_click_set_api_delegate> efl_input_pointer_double_click_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_double_click_set_api_delegate>(Module, "efl_input_pointer_double_click_set");

        private static void double_click_set(System.IntPtr obj, System.IntPtr pd, bool val)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_double_click_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetDoubleClick(val);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_double_click_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_input_pointer_double_click_set_delegate efl_input_pointer_double_click_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_pointer_triple_click_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_pointer_triple_click_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_triple_click_get_api_delegate> efl_input_pointer_triple_click_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_triple_click_get_api_delegate>(Module, "efl_input_pointer_triple_click_get");

        private static bool triple_click_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_triple_click_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetTripleClick();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_input_pointer_triple_click_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_triple_click_get_delegate efl_input_pointer_triple_click_get_static_delegate;

        
        private delegate void efl_input_pointer_triple_click_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

        
        public delegate void efl_input_pointer_triple_click_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_triple_click_set_api_delegate> efl_input_pointer_triple_click_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_triple_click_set_api_delegate>(Module, "efl_input_pointer_triple_click_set");

        private static void triple_click_set(System.IntPtr obj, System.IntPtr pd, bool val)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_triple_click_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetTripleClick(val);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_triple_click_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_input_pointer_triple_click_set_delegate efl_input_pointer_triple_click_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_pointer_wheel_horizontal_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_pointer_wheel_horizontal_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_wheel_horizontal_get_api_delegate> efl_input_pointer_wheel_horizontal_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_wheel_horizontal_get_api_delegate>(Module, "efl_input_pointer_wheel_horizontal_get");

        private static bool wheel_horizontal_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_wheel_horizontal_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetWheelHorizontal();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_input_pointer_wheel_horizontal_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_wheel_horizontal_get_delegate efl_input_pointer_wheel_horizontal_get_static_delegate;

        
        private delegate void efl_input_pointer_wheel_horizontal_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool horizontal);

        
        public delegate void efl_input_pointer_wheel_horizontal_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool horizontal);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_wheel_horizontal_set_api_delegate> efl_input_pointer_wheel_horizontal_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_wheel_horizontal_set_api_delegate>(Module, "efl_input_pointer_wheel_horizontal_set");

        private static void wheel_horizontal_set(System.IntPtr obj, System.IntPtr pd, bool horizontal)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_wheel_horizontal_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetWheelHorizontal(horizontal);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_wheel_horizontal_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), horizontal);
            }
        }

        private static efl_input_pointer_wheel_horizontal_set_delegate efl_input_pointer_wheel_horizontal_set_static_delegate;

        
        private delegate int efl_input_pointer_wheel_delta_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_input_pointer_wheel_delta_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_wheel_delta_get_api_delegate> efl_input_pointer_wheel_delta_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_wheel_delta_get_api_delegate>(Module, "efl_input_pointer_wheel_delta_get");

        private static int wheel_delta_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_wheel_delta_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((Pointer)ws.Target).GetWheelDelta();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_input_pointer_wheel_delta_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_pointer_wheel_delta_get_delegate efl_input_pointer_wheel_delta_get_static_delegate;

        
        private delegate void efl_input_pointer_wheel_delta_set_delegate(System.IntPtr obj, System.IntPtr pd,  int dist);

        
        public delegate void efl_input_pointer_wheel_delta_set_api_delegate(System.IntPtr obj,  int dist);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_pointer_wheel_delta_set_api_delegate> efl_input_pointer_wheel_delta_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_pointer_wheel_delta_set_api_delegate>(Module, "efl_input_pointer_wheel_delta_set");

        private static void wheel_delta_set(System.IntPtr obj, System.IntPtr pd, int dist)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_pointer_wheel_delta_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Pointer)ws.Target).SetWheelDelta(dist);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_pointer_wheel_delta_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), dist);
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
public static class UIKit_InputPointer_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
