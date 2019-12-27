/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI.Input {
    /// <summary>Event data carried over with any pointer event (mouse, touch, pen, ...)</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Input.Pointer.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Pointer : CoreUI.Object, CoreUI.Input.IEvent, CoreUI.Input.IState
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Pointer))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
            efl_input_pointer_class_get();

        /// <summary>Initializes a new instance of the <see cref="Pointer"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public Pointer(CoreUI.Object parent= null) : base(efl_input_pointer_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Pointer(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Pointer"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Pointer(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Pointer"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Pointer(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>The action represented by this event.</summary>
        /// <returns>Event action</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Pointer.Action GetAction() {
            var _ret_var = CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_action_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The action represented by this event.</summary>
        /// <param name="act">Event action</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetAction(CoreUI.Pointer.Action act) {
            CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_action_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), act);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The mouse button that triggered the event.
        /// 
        /// Valid if and only if <span class="text-muted">CoreUI.Input.Pointer.GetValueHas (object still in beta stage)</span>(<c>button</c>) is <c>true</c>.</summary>
        /// <returns>1 to 32, 0 if not a button event.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetButton() {
            var _ret_var = CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_button_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The mouse button that triggered the event.
        /// 
        /// Valid if and only if <span class="text-muted">CoreUI.Input.Pointer.GetValueHas (object still in beta stage)</span>(<c>button</c>) is <c>true</c>.</summary>
        /// <param name="but">1 to 32, 0 if not a button event.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetButton(int but) {
            CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_button_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), but);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Whether a mouse button is pressed at the moment of the event.
        /// 
        /// Valid if and only if <span class="text-muted">CoreUI.Input.Pointer.GetValueHas (object still in beta stage)</span>(<c>button_pressed</c>) is <c>true</c>.</summary>
        /// <param name="button">1 to 32, 0 if not a button event.</param>
        /// <returns><c>true</c> when the button was pressed, <c>false</c> otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetButtonPressed(int button) {
            var _ret_var = CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_button_pressed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), button);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether a mouse button is pressed at the moment of the event.
        /// 
        /// Valid if and only if <span class="text-muted">CoreUI.Input.Pointer.GetValueHas (object still in beta stage)</span>(<c>button_pressed</c>) is <c>true</c>.</summary>
        /// <param name="button">1 to 32, 0 if not a button event.</param>
        /// <param name="pressed"><c>true</c> when the button was pressed, <c>false</c> otherwise</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetButtonPressed(int button, bool pressed) {
            CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_button_pressed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), button, pressed);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Position where the event happened, relative to the window.
        /// 
        /// See <see cref="CoreUI.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).</summary>
        /// <returns>The position of the event, in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Position2D GetPosition() {
            var _ret_var = CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Position where the event happened, relative to the window.
        /// 
        /// See <see cref="CoreUI.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).</summary>
        /// <param name="pos">The position of the event, in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPosition(CoreUI.DataTypes.Position2D pos) {
            CoreUI.DataTypes.Position2D _in_pos = pos;
CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_pos);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Position where the event happened, relative to the window.
        /// 
        /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="CoreUI.Input.Pointer.Position"/>.
        /// 
        /// See also <see cref="CoreUI.Input.Pointer.Position"/>.</summary>
        /// <returns>The position of the event, in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Vector2 GetPrecisePosition() {
            var _ret_var = CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_precise_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Position where the event happened, relative to the window.
        /// 
        /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="CoreUI.Input.Pointer.Position"/>.
        /// 
        /// See also <see cref="CoreUI.Input.Pointer.Position"/>.</summary>
        /// <param name="pos">The position of the event, in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPrecisePosition(CoreUI.DataTypes.Vector2 pos) {
            CoreUI.DataTypes.Vector2 _in_pos = pos;
CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_precise_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_pos);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Position of the previous event, valid for move events.
        /// 
        /// Relative to the window. May be equal to <see cref="CoreUI.Input.Pointer.Position"/> (by default).
        /// 
        /// This position, in integers, is an approximation of <span class="text-muted">CoreUI.Input.Pointer.GetValue (object still in beta stage)</span>(<c>previous_x</c>), <span class="text-muted">CoreUI.Input.Pointer.GetValue (object still in beta stage)</span>(<c>previous_y</c>). Use <see cref="CoreUI.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.</summary>
        /// <returns>The position of the event, in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Position2D GetPreviousPosition() {
            var _ret_var = CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_previous_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Position of the previous event, valid for move events.
        /// 
        /// Relative to the window. May be equal to <see cref="CoreUI.Input.Pointer.Position"/> (by default).
        /// 
        /// This position, in integers, is an approximation of <span class="text-muted">CoreUI.Input.Pointer.GetValue (object still in beta stage)</span>(<c>previous_x</c>), <span class="text-muted">CoreUI.Input.Pointer.GetValue (object still in beta stage)</span>(<c>previous_y</c>). Use <see cref="CoreUI.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.</summary>
        /// <param name="pos">The position of the event, in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPreviousPosition(CoreUI.DataTypes.Position2D pos) {
            CoreUI.DataTypes.Position2D _in_pos = pos;
CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_previous_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_pos);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The ID associated with this pointer.
        /// 
        /// In case there are multiple pointers (for example when multiple fingers are touching the screen) this number uniquely identifies each pointer, for as long as it is present. This is, when a finger is lifted its ID can be later reused by another finger touching the screen.</summary>
        /// <returns>An ID uniquely identifying this pointer among the currently present pointers.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetTouchId() {
            var _ret_var = CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_touch_id_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The ID associated with this pointer.
        /// 
        /// In case there are multiple pointers (for example when multiple fingers are touching the screen) this number uniquely identifies each pointer, for as long as it is present. This is, when a finger is lifted its ID can be later reused by another finger touching the screen.</summary>
        /// <param name="id">An ID uniquely identifying this pointer among the currently present pointers.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetTouchId(int id) {
            CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_touch_id_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), id);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The object where this event first originated, in case of propagation or repetition of the event.</summary>
        /// <returns>Source object: <see cref="CoreUI.Gfx.IEntity"/></returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Object GetSource() {
            var _ret_var = CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_source_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The object where this event first originated, in case of propagation or repetition of the event.</summary>
        /// <param name="src">Source object: <see cref="CoreUI.Gfx.IEntity"/></param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetSource(CoreUI.Object src) {
            CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_source_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), src);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Double or triple click information.</summary>
        /// <returns>Button information flags</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Pointer.Flags GetButtonFlags() {
            var _ret_var = CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_button_flags_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Double or triple click information.</summary>
        /// <param name="flags">Button information flags</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetButtonFlags(CoreUI.Pointer.Flags flags) {
            CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_button_flags_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), flags);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
        /// 
        /// This is just a helper function around <see cref="CoreUI.Input.Pointer.ButtonFlags"/>.</summary>
        /// <returns><c>true</c> if the button press was a double click, <c>false</c> otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetDoubleClick() {
            var _ret_var = CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_double_click_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
        /// 
        /// This is just a helper function around <see cref="CoreUI.Input.Pointer.ButtonFlags"/>.</summary>
        /// <param name="val"><c>true</c> if the button press was a double click, <c>false</c> otherwise</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetDoubleClick(bool val) {
            CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_double_click_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), val);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
        /// 
        /// This is just a helper function around <see cref="CoreUI.Input.Pointer.ButtonFlags"/>.</summary>
        /// <returns><c>true</c> if the button press was a triple click, <c>false</c> otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetTripleClick() {
            var _ret_var = CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_triple_click_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
        /// 
        /// This is just a helper function around <see cref="CoreUI.Input.Pointer.ButtonFlags"/>.</summary>
        /// <param name="val"><c>true</c> if the button press was a triple click, <c>false</c> otherwise</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetTripleClick(bool val) {
            CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_triple_click_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), val);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Direction of the wheel, usually vertical.</summary>
        /// <returns>If <c>true</c> this was a horizontal wheel.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetWheelHorizontal() {
            var _ret_var = CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_wheel_horizontal_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Direction of the wheel, usually vertical.</summary>
        /// <param name="horizontal">If <c>true</c> this was a horizontal wheel.<br/>The default value is <c>false</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetWheelHorizontal(bool horizontal) {
            CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_wheel_horizontal_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), horizontal);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Delta movement of the wheel in discrete steps.</summary>
        /// <returns>Wheel movement delta</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetWheelDelta() {
            var _ret_var = CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_wheel_delta_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Delta movement of the wheel in discrete steps.</summary>
        /// <param name="dist">Wheel movement delta</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetWheelDelta(int dist) {
            CoreUI.Input.Pointer.NativeMethods.efl_input_pointer_wheel_delta_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dist);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The time at which an event was generated.
        /// 
        /// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.</summary>
        /// <returns>Time in milliseconds when the event happened.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetTimestamp() {
            var _ret_var = CoreUI.Input.IEventNativeMethods.efl_input_timestamp_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The time at which an event was generated.
        /// 
        /// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.<br/>
        /// <b>Note:</b> Call this when generating events manually.</summary>
        /// <param name="ms">Time in milliseconds when the event happened.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetTimestamp(double ms) {
            CoreUI.Input.IEventNativeMethods.efl_input_timestamp_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), ms);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Input device that originated this event.</summary>
        /// <returns>Input device origin</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Input.Device GetDevice() {
            var _ret_var = CoreUI.Input.IEventNativeMethods.efl_input_device_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Input device that originated this event.</summary>
        /// <param name="dev">Input device origin</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetDevice(CoreUI.Input.Device dev) {
            CoreUI.Input.IEventNativeMethods.efl_input_device_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dev);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Extra flags for this event, may be changed by the user.</summary>
        /// <returns>Input event flags</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Input.Flags GetEventFlags() {
            var _ret_var = CoreUI.Input.IEventNativeMethods.efl_input_event_flags_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Extra flags for this event, may be changed by the user.</summary>
        /// <param name="flags">Input event flags</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetEventFlags(CoreUI.Input.Flags flags) {
            CoreUI.Input.IEventNativeMethods.efl_input_event_flags_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), flags);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
        /// <returns><c>true</c> if the event is on hold, <c>false</c> otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetProcessed() {
            var _ret_var = CoreUI.Input.IEventNativeMethods.efl_input_processed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
        /// <param name="val"><c>true</c> if the event is on hold, <c>false</c> otherwise</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetProcessed(bool val) {
            CoreUI.Input.IEventNativeMethods.efl_input_processed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), val);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
        /// <returns><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetScrolling() {
            var _ret_var = CoreUI.Input.IEventNativeMethods.efl_input_scrolling_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
        /// <param name="val"><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetScrolling(bool val) {
            CoreUI.Input.IEventNativeMethods.efl_input_scrolling_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), val);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary><c>true</c> if the event was fake, not triggered by real hardware.</summary>
        /// <returns><c>true</c> if the event was not from real hardware, <c>false</c> otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetFake() {
            var _ret_var = CoreUI.Input.IEventNativeMethods.efl_input_fake_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Resets the internal data to 0 or default values.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void Reset() {
            CoreUI.Input.IEventNativeMethods.efl_input_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The action represented by this event.</summary>
        /// <value>Event action</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Pointer.Action Action {
            get { return GetAction(); }
            set { SetAction(value); }
        }

        /// <summary>The mouse button that triggered the event.
        /// 
        /// Valid if and only if <span class="text-muted">CoreUI.Input.Pointer.GetValueHas (object still in beta stage)</span>(<c>button</c>) is <c>true</c>.</summary>
        /// <value>1 to 32, 0 if not a button event.</value>
        /// <since_tizen> 6 </since_tizen>
        public int Button {
            get { return GetButton(); }
            set { SetButton(value); }
        }

        /// <summary>Position where the event happened, relative to the window.
        /// 
        /// See <see cref="CoreUI.Input.Pointer.PrecisePosition"/> for floating point precision (subpixel location).</summary>
        /// <value>The position of the event, in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Position2D Position {
            get { return GetPosition(); }
            set { SetPosition(value); }
        }

        /// <summary>Position where the event happened, relative to the window.
        /// 
        /// This position is in floating point values, for more precise coordinates, in subpixels. Note that many input devices are unable to give better precision than a single pixel, so this may be equal to <see cref="CoreUI.Input.Pointer.Position"/>.
        /// 
        /// See also <see cref="CoreUI.Input.Pointer.Position"/>.</summary>
        /// <value>The position of the event, in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Vector2 PrecisePosition {
            get { return GetPrecisePosition(); }
            set { SetPrecisePosition(value); }
        }

        /// <summary>Position of the previous event, valid for move events.
        /// 
        /// Relative to the window. May be equal to <see cref="CoreUI.Input.Pointer.Position"/> (by default).
        /// 
        /// This position, in integers, is an approximation of <span class="text-muted">CoreUI.Input.Pointer.GetValue (object still in beta stage)</span>(<c>previous_x</c>), <span class="text-muted">CoreUI.Input.Pointer.GetValue (object still in beta stage)</span>(<c>previous_y</c>). Use <see cref="CoreUI.Input.Pointer.PreviousPosition"/> if you need simple pixel positions, but prefer the generic interface if you need precise coordinates.</summary>
        /// <value>The position of the event, in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Position2D PreviousPosition {
            get { return GetPreviousPosition(); }
            set { SetPreviousPosition(value); }
        }

        /// <summary>The ID associated with this pointer.
        /// 
        /// In case there are multiple pointers (for example when multiple fingers are touching the screen) this number uniquely identifies each pointer, for as long as it is present. This is, when a finger is lifted its ID can be later reused by another finger touching the screen.</summary>
        /// <value>An ID uniquely identifying this pointer among the currently present pointers.</value>
        /// <since_tizen> 6 </since_tizen>
        public int TouchId {
            get { return GetTouchId(); }
            set { SetTouchId(value); }
        }

        /// <summary>The object where this event first originated, in case of propagation or repetition of the event.</summary>
        /// <value>Source object: <see cref="CoreUI.Gfx.IEntity"/></value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Object Source {
            get { return GetSource(); }
            set { SetSource(value); }
        }

        /// <summary>Double or triple click information.</summary>
        /// <value>Button information flags</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Pointer.Flags ButtonFlags {
            get { return GetButtonFlags(); }
            set { SetButtonFlags(value); }
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.Pointer.ButtonFlags"/> indicates a double click (2nd press).
        /// 
        /// This is just a helper function around <see cref="CoreUI.Input.Pointer.ButtonFlags"/>.</summary>
        /// <value><c>true</c> if the button press was a double click, <c>false</c> otherwise</value>
        /// <since_tizen> 6 </since_tizen>
        public bool DoubleClick {
            get { return GetDoubleClick(); }
            set { SetDoubleClick(value); }
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.Pointer.ButtonFlags"/> indicates a triple click (3rd press).
        /// 
        /// This is just a helper function around <see cref="CoreUI.Input.Pointer.ButtonFlags"/>.</summary>
        /// <value><c>true</c> if the button press was a triple click, <c>false</c> otherwise</value>
        /// <since_tizen> 6 </since_tizen>
        public bool TripleClick {
            get { return GetTripleClick(); }
            set { SetTripleClick(value); }
        }

        /// <summary>Direction of the wheel, usually vertical.</summary>
        /// <value>If <c>true</c> this was a horizontal wheel.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool WheelHorizontal {
            get { return GetWheelHorizontal(); }
            set { SetWheelHorizontal(value); }
        }

        /// <summary>Delta movement of the wheel in discrete steps.</summary>
        /// <value>Wheel movement delta</value>
        /// <since_tizen> 6 </since_tizen>
        public int WheelDelta {
            get { return GetWheelDelta(); }
            set { SetWheelDelta(value); }
        }

        /// <summary>The time at which an event was generated.
        /// 
        /// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.<br/>
        /// <b>Note on writing:</b> Call this when generating events manually.</summary>
        /// <value>Time in milliseconds when the event happened.</value>
        /// <since_tizen> 6 </since_tizen>
        public double Timestamp {
            get { return GetTimestamp(); }
            set { SetTimestamp(value); }
        }

        /// <summary>Input device that originated this event.</summary>
        /// <value>Input device origin</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Device Device {
            get { return GetDevice(); }
            set { SetDevice(value); }
        }

        /// <summary>Extra flags for this event, may be changed by the user.</summary>
        /// <value>Input event flags</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Flags EventFlags {
            get { return GetEventFlags(); }
            set { SetEventFlags(value); }
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
        /// <value><c>true</c> if the event is on hold, <c>false</c> otherwise</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Processed {
            get { return GetProcessed(); }
            set { SetProcessed(value); }
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
        /// <value><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Scrolling {
            get { return GetScrolling(); }
            set { SetScrolling(value); }
        }

        /// <summary><c>true</c> if the event was fake, not triggered by real hardware.</summary>
        /// <value><c>true</c> if the event was not from real hardware, <c>false</c> otherwise</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Fake {
            get { return GetFake(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Input.Pointer.efl_input_pointer_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Object.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Evas);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_input_pointer_action_get_static_delegate == null)
                {
                    efl_input_pointer_action_get_static_delegate = new efl_input_pointer_action_get_delegate(action_get);
                }

                if (methods.Contains("GetAction"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_action_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_action_get_static_delegate) });
                }

                if (efl_input_pointer_action_set_static_delegate == null)
                {
                    efl_input_pointer_action_set_static_delegate = new efl_input_pointer_action_set_delegate(action_set);
                }

                if (methods.Contains("SetAction"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_action_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_action_set_static_delegate) });
                }

                if (efl_input_pointer_button_get_static_delegate == null)
                {
                    efl_input_pointer_button_get_static_delegate = new efl_input_pointer_button_get_delegate(button_get);
                }

                if (methods.Contains("GetButton"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_get_static_delegate) });
                }

                if (efl_input_pointer_button_set_static_delegate == null)
                {
                    efl_input_pointer_button_set_static_delegate = new efl_input_pointer_button_set_delegate(button_set);
                }

                if (methods.Contains("SetButton"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_set_static_delegate) });
                }

                if (efl_input_pointer_button_pressed_get_static_delegate == null)
                {
                    efl_input_pointer_button_pressed_get_static_delegate = new efl_input_pointer_button_pressed_get_delegate(button_pressed_get);
                }

                if (methods.Contains("GetButtonPressed"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_pressed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_pressed_get_static_delegate) });
                }

                if (efl_input_pointer_button_pressed_set_static_delegate == null)
                {
                    efl_input_pointer_button_pressed_set_static_delegate = new efl_input_pointer_button_pressed_set_delegate(button_pressed_set);
                }

                if (methods.Contains("SetButtonPressed"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_pressed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_pressed_set_static_delegate) });
                }

                if (efl_input_pointer_position_get_static_delegate == null)
                {
                    efl_input_pointer_position_get_static_delegate = new efl_input_pointer_position_get_delegate(position_get);
                }

                if (methods.Contains("GetPosition"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_position_get_static_delegate) });
                }

                if (efl_input_pointer_position_set_static_delegate == null)
                {
                    efl_input_pointer_position_set_static_delegate = new efl_input_pointer_position_set_delegate(position_set);
                }

                if (methods.Contains("SetPosition"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_position_set_static_delegate) });
                }

                if (efl_input_pointer_precise_position_get_static_delegate == null)
                {
                    efl_input_pointer_precise_position_get_static_delegate = new efl_input_pointer_precise_position_get_delegate(precise_position_get);
                }

                if (methods.Contains("GetPrecisePosition"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_precise_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_precise_position_get_static_delegate) });
                }

                if (efl_input_pointer_precise_position_set_static_delegate == null)
                {
                    efl_input_pointer_precise_position_set_static_delegate = new efl_input_pointer_precise_position_set_delegate(precise_position_set);
                }

                if (methods.Contains("SetPrecisePosition"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_precise_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_precise_position_set_static_delegate) });
                }

                if (efl_input_pointer_previous_position_get_static_delegate == null)
                {
                    efl_input_pointer_previous_position_get_static_delegate = new efl_input_pointer_previous_position_get_delegate(previous_position_get);
                }

                if (methods.Contains("GetPreviousPosition"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_previous_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_previous_position_get_static_delegate) });
                }

                if (efl_input_pointer_previous_position_set_static_delegate == null)
                {
                    efl_input_pointer_previous_position_set_static_delegate = new efl_input_pointer_previous_position_set_delegate(previous_position_set);
                }

                if (methods.Contains("SetPreviousPosition"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_previous_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_previous_position_set_static_delegate) });
                }

                if (efl_input_pointer_touch_id_get_static_delegate == null)
                {
                    efl_input_pointer_touch_id_get_static_delegate = new efl_input_pointer_touch_id_get_delegate(touch_id_get);
                }

                if (methods.Contains("GetTouchId"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_touch_id_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_touch_id_get_static_delegate) });
                }

                if (efl_input_pointer_touch_id_set_static_delegate == null)
                {
                    efl_input_pointer_touch_id_set_static_delegate = new efl_input_pointer_touch_id_set_delegate(touch_id_set);
                }

                if (methods.Contains("SetTouchId"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_touch_id_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_touch_id_set_static_delegate) });
                }

                if (efl_input_pointer_source_get_static_delegate == null)
                {
                    efl_input_pointer_source_get_static_delegate = new efl_input_pointer_source_get_delegate(source_get);
                }

                if (methods.Contains("GetSource"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_source_get_static_delegate) });
                }

                if (efl_input_pointer_source_set_static_delegate == null)
                {
                    efl_input_pointer_source_set_static_delegate = new efl_input_pointer_source_set_delegate(source_set);
                }

                if (methods.Contains("SetSource"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_source_set_static_delegate) });
                }

                if (efl_input_pointer_button_flags_get_static_delegate == null)
                {
                    efl_input_pointer_button_flags_get_static_delegate = new efl_input_pointer_button_flags_get_delegate(button_flags_get);
                }

                if (methods.Contains("GetButtonFlags"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_flags_get_static_delegate) });
                }

                if (efl_input_pointer_button_flags_set_static_delegate == null)
                {
                    efl_input_pointer_button_flags_set_static_delegate = new efl_input_pointer_button_flags_set_delegate(button_flags_set);
                }

                if (methods.Contains("SetButtonFlags"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_button_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_button_flags_set_static_delegate) });
                }

                if (efl_input_pointer_double_click_get_static_delegate == null)
                {
                    efl_input_pointer_double_click_get_static_delegate = new efl_input_pointer_double_click_get_delegate(double_click_get);
                }

                if (methods.Contains("GetDoubleClick"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_double_click_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_double_click_get_static_delegate) });
                }

                if (efl_input_pointer_double_click_set_static_delegate == null)
                {
                    efl_input_pointer_double_click_set_static_delegate = new efl_input_pointer_double_click_set_delegate(double_click_set);
                }

                if (methods.Contains("SetDoubleClick"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_double_click_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_double_click_set_static_delegate) });
                }

                if (efl_input_pointer_triple_click_get_static_delegate == null)
                {
                    efl_input_pointer_triple_click_get_static_delegate = new efl_input_pointer_triple_click_get_delegate(triple_click_get);
                }

                if (methods.Contains("GetTripleClick"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_triple_click_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_triple_click_get_static_delegate) });
                }

                if (efl_input_pointer_triple_click_set_static_delegate == null)
                {
                    efl_input_pointer_triple_click_set_static_delegate = new efl_input_pointer_triple_click_set_delegate(triple_click_set);
                }

                if (methods.Contains("SetTripleClick"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_triple_click_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_triple_click_set_static_delegate) });
                }

                if (efl_input_pointer_wheel_horizontal_get_static_delegate == null)
                {
                    efl_input_pointer_wheel_horizontal_get_static_delegate = new efl_input_pointer_wheel_horizontal_get_delegate(wheel_horizontal_get);
                }

                if (methods.Contains("GetWheelHorizontal"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_wheel_horizontal_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_horizontal_get_static_delegate) });
                }

                if (efl_input_pointer_wheel_horizontal_set_static_delegate == null)
                {
                    efl_input_pointer_wheel_horizontal_set_static_delegate = new efl_input_pointer_wheel_horizontal_set_delegate(wheel_horizontal_set);
                }

                if (methods.Contains("SetWheelHorizontal"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_wheel_horizontal_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_horizontal_set_static_delegate) });
                }

                if (efl_input_pointer_wheel_delta_get_static_delegate == null)
                {
                    efl_input_pointer_wheel_delta_get_static_delegate = new efl_input_pointer_wheel_delta_get_delegate(wheel_delta_get);
                }

                if (methods.Contains("GetWheelDelta"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_wheel_delta_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_delta_get_static_delegate) });
                }

                if (efl_input_pointer_wheel_delta_set_static_delegate == null)
                {
                    efl_input_pointer_wheel_delta_set_static_delegate = new efl_input_pointer_wheel_delta_set_delegate(wheel_delta_set);
                }

                if (methods.Contains("SetWheelDelta"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_pointer_wheel_delta_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_pointer_wheel_delta_set_static_delegate) });
                }

                if (includeInherited)
                {
                    var all_interfaces = type.GetInterfaces();
                    foreach (var iface in all_interfaces)
                    {
                        var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                        if (moredescs != null)
                            descs.AddRange(moredescs);
                    }
                }
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.Input.Pointer.efl_input_pointer_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate CoreUI.Pointer.Action efl_input_pointer_action_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.Pointer.Action efl_input_pointer_action_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_action_get_api_delegate> efl_input_pointer_action_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_action_get_api_delegate>(Module, "efl_input_pointer_action_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Pointer.Action action_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_action_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Pointer.Action _ret_var = default(CoreUI.Pointer.Action);
                    try
                    {
                        _ret_var = ((Pointer)ws.Target).GetAction();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_input_pointer_action_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_pointer_action_get_delegate efl_input_pointer_action_get_static_delegate;

            
            private delegate void efl_input_pointer_action_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Pointer.Action act);

            
            internal delegate void efl_input_pointer_action_set_api_delegate(System.IntPtr obj,  CoreUI.Pointer.Action act);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_action_set_api_delegate> efl_input_pointer_action_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_action_set_api_delegate>(Module, "efl_input_pointer_action_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void action_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Pointer.Action act)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_action_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Pointer)ws.Target).SetAction(act);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_pointer_action_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), act);
                }
            }

            private static efl_input_pointer_action_set_delegate efl_input_pointer_action_set_static_delegate;

            
            private delegate int efl_input_pointer_button_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_input_pointer_button_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_button_get_api_delegate> efl_input_pointer_button_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_button_get_api_delegate>(Module, "efl_input_pointer_button_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int button_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_button_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Pointer)ws.Target).GetButton();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_input_pointer_button_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_pointer_button_get_delegate efl_input_pointer_button_get_static_delegate;

            
            private delegate void efl_input_pointer_button_set_delegate(System.IntPtr obj, System.IntPtr pd,  int but);

            
            internal delegate void efl_input_pointer_button_set_api_delegate(System.IntPtr obj,  int but);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_button_set_api_delegate> efl_input_pointer_button_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_button_set_api_delegate>(Module, "efl_input_pointer_button_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void button_set(System.IntPtr obj, System.IntPtr pd, int but)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_button_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Pointer)ws.Target).SetButton(but);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_pointer_button_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), but);
                }
            }

            private static efl_input_pointer_button_set_delegate efl_input_pointer_button_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_input_pointer_button_pressed_get_delegate(System.IntPtr obj, System.IntPtr pd,  int button);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_input_pointer_button_pressed_get_api_delegate(System.IntPtr obj,  int button);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_button_pressed_get_api_delegate> efl_input_pointer_button_pressed_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_button_pressed_get_api_delegate>(Module, "efl_input_pointer_button_pressed_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool button_pressed_get(System.IntPtr obj, System.IntPtr pd, int button)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_button_pressed_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Pointer)ws.Target).GetButtonPressed(button);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_input_pointer_button_pressed_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), button);
                }
            }

            private static efl_input_pointer_button_pressed_get_delegate efl_input_pointer_button_pressed_get_static_delegate;

            
            private delegate void efl_input_pointer_button_pressed_set_delegate(System.IntPtr obj, System.IntPtr pd,  int button, [MarshalAs(UnmanagedType.U1)] bool pressed);

            
            internal delegate void efl_input_pointer_button_pressed_set_api_delegate(System.IntPtr obj,  int button, [MarshalAs(UnmanagedType.U1)] bool pressed);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_button_pressed_set_api_delegate> efl_input_pointer_button_pressed_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_button_pressed_set_api_delegate>(Module, "efl_input_pointer_button_pressed_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void button_pressed_set(System.IntPtr obj, System.IntPtr pd, int button, bool pressed)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_button_pressed_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Pointer)ws.Target).SetButtonPressed(button, pressed);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_pointer_button_pressed_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), button, pressed);
                }
            }

            private static efl_input_pointer_button_pressed_set_delegate efl_input_pointer_button_pressed_set_static_delegate;

            
            private delegate CoreUI.DataTypes.Position2D efl_input_pointer_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.DataTypes.Position2D efl_input_pointer_position_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_position_get_api_delegate> efl_input_pointer_position_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_position_get_api_delegate>(Module, "efl_input_pointer_position_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Position2D position_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_position_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Position2D _ret_var = default(CoreUI.DataTypes.Position2D);
                    try
                    {
                        _ret_var = ((Pointer)ws.Target).GetPosition();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_input_pointer_position_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_pointer_position_get_delegate efl_input_pointer_position_get_static_delegate;

            
            private delegate void efl_input_pointer_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Position2D pos);

            
            internal delegate void efl_input_pointer_position_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Position2D pos);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_position_set_api_delegate> efl_input_pointer_position_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_position_set_api_delegate>(Module, "efl_input_pointer_position_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void position_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Position2D pos)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_position_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Position2D _in_pos = pos;

                    try
                    {
                        ((Pointer)ws.Target).SetPosition(_in_pos);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_pointer_position_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pos);
                }
            }

            private static efl_input_pointer_position_set_delegate efl_input_pointer_position_set_static_delegate;

            
            private delegate CoreUI.DataTypes.Vector2 efl_input_pointer_precise_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.DataTypes.Vector2 efl_input_pointer_precise_position_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_precise_position_get_api_delegate> efl_input_pointer_precise_position_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_precise_position_get_api_delegate>(Module, "efl_input_pointer_precise_position_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Vector2 precise_position_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_precise_position_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Vector2 _ret_var = default(CoreUI.DataTypes.Vector2);
                    try
                    {
                        _ret_var = ((Pointer)ws.Target).GetPrecisePosition();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_input_pointer_precise_position_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_pointer_precise_position_get_delegate efl_input_pointer_precise_position_get_static_delegate;

            
            private delegate void efl_input_pointer_precise_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Vector2 pos);

            
            internal delegate void efl_input_pointer_precise_position_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Vector2 pos);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_precise_position_set_api_delegate> efl_input_pointer_precise_position_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_precise_position_set_api_delegate>(Module, "efl_input_pointer_precise_position_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void precise_position_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Vector2 pos)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_precise_position_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Vector2 _in_pos = pos;

                    try
                    {
                        ((Pointer)ws.Target).SetPrecisePosition(_in_pos);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_pointer_precise_position_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pos);
                }
            }

            private static efl_input_pointer_precise_position_set_delegate efl_input_pointer_precise_position_set_static_delegate;

            
            private delegate CoreUI.DataTypes.Position2D efl_input_pointer_previous_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.DataTypes.Position2D efl_input_pointer_previous_position_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_previous_position_get_api_delegate> efl_input_pointer_previous_position_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_previous_position_get_api_delegate>(Module, "efl_input_pointer_previous_position_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Position2D previous_position_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_previous_position_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Position2D _ret_var = default(CoreUI.DataTypes.Position2D);
                    try
                    {
                        _ret_var = ((Pointer)ws.Target).GetPreviousPosition();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_input_pointer_previous_position_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_pointer_previous_position_get_delegate efl_input_pointer_previous_position_get_static_delegate;

            
            private delegate void efl_input_pointer_previous_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Position2D pos);

            
            internal delegate void efl_input_pointer_previous_position_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Position2D pos);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_previous_position_set_api_delegate> efl_input_pointer_previous_position_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_previous_position_set_api_delegate>(Module, "efl_input_pointer_previous_position_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void previous_position_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Position2D pos)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_previous_position_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Position2D _in_pos = pos;

                    try
                    {
                        ((Pointer)ws.Target).SetPreviousPosition(_in_pos);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_pointer_previous_position_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pos);
                }
            }

            private static efl_input_pointer_previous_position_set_delegate efl_input_pointer_previous_position_set_static_delegate;

            
            private delegate int efl_input_pointer_touch_id_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_input_pointer_touch_id_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_touch_id_get_api_delegate> efl_input_pointer_touch_id_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_touch_id_get_api_delegate>(Module, "efl_input_pointer_touch_id_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int touch_id_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_touch_id_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Pointer)ws.Target).GetTouchId();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_input_pointer_touch_id_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_pointer_touch_id_get_delegate efl_input_pointer_touch_id_get_static_delegate;

            
            private delegate void efl_input_pointer_touch_id_set_delegate(System.IntPtr obj, System.IntPtr pd,  int id);

            
            internal delegate void efl_input_pointer_touch_id_set_api_delegate(System.IntPtr obj,  int id);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_touch_id_set_api_delegate> efl_input_pointer_touch_id_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_touch_id_set_api_delegate>(Module, "efl_input_pointer_touch_id_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void touch_id_set(System.IntPtr obj, System.IntPtr pd, int id)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_touch_id_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Pointer)ws.Target).SetTouchId(id);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_pointer_touch_id_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), id);
                }
            }

            private static efl_input_pointer_touch_id_set_delegate efl_input_pointer_touch_id_set_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Object efl_input_pointer_source_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Object efl_input_pointer_source_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_source_get_api_delegate> efl_input_pointer_source_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_source_get_api_delegate>(Module, "efl_input_pointer_source_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Object source_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_source_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Object _ret_var = default(CoreUI.Object);
                    try
                    {
                        _ret_var = ((Pointer)ws.Target).GetSource();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_input_pointer_source_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_pointer_source_get_delegate efl_input_pointer_source_get_static_delegate;

            
            private delegate void efl_input_pointer_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Object src);

            
            internal delegate void efl_input_pointer_source_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Object src);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_source_set_api_delegate> efl_input_pointer_source_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_source_set_api_delegate>(Module, "efl_input_pointer_source_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void source_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Object src)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_source_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Pointer)ws.Target).SetSource(src);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_pointer_source_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), src);
                }
            }

            private static efl_input_pointer_source_set_delegate efl_input_pointer_source_set_static_delegate;

            
            private delegate CoreUI.Pointer.Flags efl_input_pointer_button_flags_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.Pointer.Flags efl_input_pointer_button_flags_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_button_flags_get_api_delegate> efl_input_pointer_button_flags_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_button_flags_get_api_delegate>(Module, "efl_input_pointer_button_flags_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Pointer.Flags button_flags_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_button_flags_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Pointer.Flags _ret_var = default(CoreUI.Pointer.Flags);
                    try
                    {
                        _ret_var = ((Pointer)ws.Target).GetButtonFlags();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_input_pointer_button_flags_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_pointer_button_flags_get_delegate efl_input_pointer_button_flags_get_static_delegate;

            
            private delegate void efl_input_pointer_button_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Pointer.Flags flags);

            
            internal delegate void efl_input_pointer_button_flags_set_api_delegate(System.IntPtr obj,  CoreUI.Pointer.Flags flags);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_button_flags_set_api_delegate> efl_input_pointer_button_flags_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_button_flags_set_api_delegate>(Module, "efl_input_pointer_button_flags_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void button_flags_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Pointer.Flags flags)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_button_flags_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Pointer)ws.Target).SetButtonFlags(flags);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_pointer_button_flags_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), flags);
                }
            }

            private static efl_input_pointer_button_flags_set_delegate efl_input_pointer_button_flags_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_input_pointer_double_click_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_input_pointer_double_click_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_double_click_get_api_delegate> efl_input_pointer_double_click_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_double_click_get_api_delegate>(Module, "efl_input_pointer_double_click_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool double_click_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_double_click_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Pointer)ws.Target).GetDoubleClick();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_input_pointer_double_click_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_pointer_double_click_get_delegate efl_input_pointer_double_click_get_static_delegate;

            
            private delegate void efl_input_pointer_double_click_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

            
            internal delegate void efl_input_pointer_double_click_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_double_click_set_api_delegate> efl_input_pointer_double_click_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_double_click_set_api_delegate>(Module, "efl_input_pointer_double_click_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void double_click_set(System.IntPtr obj, System.IntPtr pd, bool val)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_double_click_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Pointer)ws.Target).SetDoubleClick(val);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_pointer_double_click_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), val);
                }
            }

            private static efl_input_pointer_double_click_set_delegate efl_input_pointer_double_click_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_input_pointer_triple_click_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_input_pointer_triple_click_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_triple_click_get_api_delegate> efl_input_pointer_triple_click_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_triple_click_get_api_delegate>(Module, "efl_input_pointer_triple_click_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool triple_click_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_triple_click_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Pointer)ws.Target).GetTripleClick();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_input_pointer_triple_click_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_pointer_triple_click_get_delegate efl_input_pointer_triple_click_get_static_delegate;

            
            private delegate void efl_input_pointer_triple_click_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

            
            internal delegate void efl_input_pointer_triple_click_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_triple_click_set_api_delegate> efl_input_pointer_triple_click_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_triple_click_set_api_delegate>(Module, "efl_input_pointer_triple_click_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void triple_click_set(System.IntPtr obj, System.IntPtr pd, bool val)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_triple_click_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Pointer)ws.Target).SetTripleClick(val);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_pointer_triple_click_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), val);
                }
            }

            private static efl_input_pointer_triple_click_set_delegate efl_input_pointer_triple_click_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_input_pointer_wheel_horizontal_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_input_pointer_wheel_horizontal_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_wheel_horizontal_get_api_delegate> efl_input_pointer_wheel_horizontal_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_wheel_horizontal_get_api_delegate>(Module, "efl_input_pointer_wheel_horizontal_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool wheel_horizontal_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_wheel_horizontal_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Pointer)ws.Target).GetWheelHorizontal();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_input_pointer_wheel_horizontal_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_pointer_wheel_horizontal_get_delegate efl_input_pointer_wheel_horizontal_get_static_delegate;

            
            private delegate void efl_input_pointer_wheel_horizontal_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool horizontal);

            
            internal delegate void efl_input_pointer_wheel_horizontal_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool horizontal);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_wheel_horizontal_set_api_delegate> efl_input_pointer_wheel_horizontal_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_wheel_horizontal_set_api_delegate>(Module, "efl_input_pointer_wheel_horizontal_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void wheel_horizontal_set(System.IntPtr obj, System.IntPtr pd, bool horizontal)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_wheel_horizontal_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Pointer)ws.Target).SetWheelHorizontal(horizontal);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_pointer_wheel_horizontal_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), horizontal);
                }
            }

            private static efl_input_pointer_wheel_horizontal_set_delegate efl_input_pointer_wheel_horizontal_set_static_delegate;

            
            private delegate int efl_input_pointer_wheel_delta_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_input_pointer_wheel_delta_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_wheel_delta_get_api_delegate> efl_input_pointer_wheel_delta_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_wheel_delta_get_api_delegate>(Module, "efl_input_pointer_wheel_delta_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int wheel_delta_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_wheel_delta_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Pointer)ws.Target).GetWheelDelta();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_input_pointer_wheel_delta_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_pointer_wheel_delta_get_delegate efl_input_pointer_wheel_delta_get_static_delegate;

            
            private delegate void efl_input_pointer_wheel_delta_set_delegate(System.IntPtr obj, System.IntPtr pd,  int dist);

            
            internal delegate void efl_input_pointer_wheel_delta_set_api_delegate(System.IntPtr obj,  int dist);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_wheel_delta_set_api_delegate> efl_input_pointer_wheel_delta_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_pointer_wheel_delta_set_api_delegate>(Module, "efl_input_pointer_wheel_delta_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void wheel_delta_set(System.IntPtr obj, System.IntPtr pd, int dist)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_pointer_wheel_delta_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Pointer)ws.Target).SetWheelDelta(dist);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_pointer_wheel_delta_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), dist);
                }
            }

            private static efl_input_pointer_wheel_delta_set_delegate efl_input_pointer_wheel_delta_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.Input {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class PointerExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Pointer.Action> Action<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<CoreUI.Pointer.Action>("action", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> Button<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<int>("button", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Position2D> Position<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Position2D>("position", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Vector2> PrecisePosition<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Vector2>("precise_position", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Position2D> PreviousPosition<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Position2D>("previous_position", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> TouchId<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<int>("touch_id", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Object> Source<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<CoreUI.Object>("source", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Pointer.Flags> ButtonFlags<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<CoreUI.Pointer.Flags>("button_flags", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> DoubleClick<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<bool>("double_click", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> TripleClick<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<bool>("triple_click", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> WheelHorizontal<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<bool>("wheel_horizontal", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> WheelDelta<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<int>("wheel_delta", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> Timestamp<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<double>("timestamp", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Input.Device> Device<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<CoreUI.Input.Device>("device", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Input.Flags> EventFlags<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<CoreUI.Input.Flags>("event_flags", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Processed<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<bool>("processed", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Scrolling<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Pointer, T>magic = null) where T : CoreUI.Input.Pointer {
            return new CoreUI.BindableProperty<bool>("scrolling", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

