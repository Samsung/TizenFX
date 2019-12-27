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
    /// <summary>Represents a single key event from a keyboard or similar device.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Input.Key.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Key : CoreUI.Object, CoreUI.Input.IEvent, CoreUI.Input.IState
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Key))
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
            efl_input_key_class_get();

        /// <summary>Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public Key(CoreUI.Object parent= null) : base(efl_input_key_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Key(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Key"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Key(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Key"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Key(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary><c>true</c> if the key is down, <c>false</c> if it is released.</summary>
        /// <returns><c>true</c> if the key is pressed, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetPressed() {
            var _ret_var = CoreUI.Input.Key.NativeMethods.efl_input_key_pressed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary><c>true</c> if the key is down, <c>false</c> if it is released.</summary>
        /// <param name="val"><c>true</c> if the key is pressed, <c>false</c> otherwise.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPressed(bool val) {
            CoreUI.Input.Key.NativeMethods.efl_input_key_pressed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), val);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Name string of the physical key that produced this event.
        /// 
        /// This typically matches what is printed on the key. For example, &quot;1&quot; or &quot;a&quot;. Note that both &quot;a&quot; and &quot;A&quot; are obtained with the same physical key, so both events will have the same <see cref="CoreUI.Input.Key.KeyName"/> &quot;a&quot; but different <see cref="CoreUI.Input.Key.KeySym"/>.
        /// 
        /// Commonly used in keyboard remapping menus to uniquely identify a physical key.</summary>
        /// <returns>Name of the key that produced this event.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetKeyName() {
            var _ret_var = CoreUI.Input.Key.NativeMethods.efl_input_key_name_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Name string of the physical key that produced this event.
        /// 
        /// This typically matches what is printed on the key. For example, &quot;1&quot; or &quot;a&quot;. Note that both &quot;a&quot; and &quot;A&quot; are obtained with the same physical key, so both events will have the same <see cref="CoreUI.Input.Key.KeyName"/> &quot;a&quot; but different <see cref="CoreUI.Input.Key.KeySym"/>.
        /// 
        /// Commonly used in keyboard remapping menus to uniquely identify a physical key.</summary>
        /// <param name="val">Name of the key that produced this event.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetKeyName(System.String val) {
            CoreUI.Input.Key.NativeMethods.efl_input_key_name_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), val);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Name of the symbol produced by this key event.
        /// 
        /// For example, &quot;a&quot;, &quot;A&quot;, &quot;1&quot; or &quot;exclam&quot;. The same physical key can produce different symbols when combined with other keys like &quot;shift&quot; or &quot;alt gr&quot;. For example, &quot;a&quot; and &quot;A&quot; have different <see cref="CoreUI.Input.Key.KeySym"/> but the same <see cref="CoreUI.Input.Key.KeyName"/> &quot;a&quot;.
        /// 
        /// This is the field you typically use to uniquely identify a keyboard symbol, in keyboard shortcuts for example.</summary>
        /// <returns>Symbol name produced by key event.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetKeySym() {
            var _ret_var = CoreUI.Input.Key.NativeMethods.efl_input_key_sym_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Name of the symbol produced by this key event.
        /// 
        /// For example, &quot;a&quot;, &quot;A&quot;, &quot;1&quot; or &quot;exclam&quot;. The same physical key can produce different symbols when combined with other keys like &quot;shift&quot; or &quot;alt gr&quot;. For example, &quot;a&quot; and &quot;A&quot; have different <see cref="CoreUI.Input.Key.KeySym"/> but the same <see cref="CoreUI.Input.Key.KeyName"/> &quot;a&quot;.
        /// 
        /// This is the field you typically use to uniquely identify a keyboard symbol, in keyboard shortcuts for example.</summary>
        /// <param name="val">Symbol name produced by key event.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetKeySym(System.String val) {
            CoreUI.Input.Key.NativeMethods.efl_input_key_sym_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), val);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.</summary>
        /// <returns>Visible string produced by this key event, in UTF8.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetString() {
            var _ret_var = CoreUI.Input.Key.NativeMethods.efl_input_key_string_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.</summary>
        /// <param name="val">Visible string produced by this key event, in UTF8.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetString(System.String val) {
            CoreUI.Input.Key.NativeMethods.efl_input_key_string_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), val);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
        /// 
        /// <b>NOTE: </b>This string replaces the previous one.</summary>
        /// <returns>Composed string in UTF8.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetComposeString() {
            var _ret_var = CoreUI.Input.Key.NativeMethods.efl_input_key_compose_string_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
        /// 
        /// <b>NOTE: </b>This string replaces the previous one.</summary>
        /// <param name="val">Composed string in UTF8.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetComposeString(System.String val) {
            CoreUI.Input.Key.NativeMethods.efl_input_key_compose_string_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), val);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Keyboard scan code of the physical key that produced this event.
        /// 
        /// You typically do not need to use this field, because the system maps scan codes to the more convenient <see cref="CoreUI.Input.Key.KeyName"/>. Us this in keyboard remapping applications or when trying to use a keyboard unknown to your operating system.</summary>
        /// <returns>Keyboard scan code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetKeyCode() {
            var _ret_var = CoreUI.Input.Key.NativeMethods.efl_input_key_code_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Keyboard scan code of the physical key that produced this event.
        /// 
        /// You typically do not need to use this field, because the system maps scan codes to the more convenient <see cref="CoreUI.Input.Key.KeyName"/>. Us this in keyboard remapping applications or when trying to use a keyboard unknown to your operating system.</summary>
        /// <param name="val">Keyboard scan code.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetKeyCode(int val) {
            CoreUI.Input.Key.NativeMethods.efl_input_key_code_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), val);
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

        /// <summary><c>true</c> if the key is down, <c>false</c> if it is released.</summary>
        /// <value><c>true</c> if the key is pressed, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Pressed {
            get { return GetPressed(); }
            set { SetPressed(value); }
        }

        /// <summary>Name string of the physical key that produced this event.
        /// 
        /// This typically matches what is printed on the key. For example, &quot;1&quot; or &quot;a&quot;. Note that both &quot;a&quot; and &quot;A&quot; are obtained with the same physical key, so both events will have the same <see cref="CoreUI.Input.Key.KeyName"/> &quot;a&quot; but different <see cref="CoreUI.Input.Key.KeySym"/>.
        /// 
        /// Commonly used in keyboard remapping menus to uniquely identify a physical key.</summary>
        /// <value>Name of the key that produced this event.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String KeyName {
            get { return GetKeyName(); }
            set { SetKeyName(value); }
        }

        /// <summary>Name of the symbol produced by this key event.
        /// 
        /// For example, &quot;a&quot;, &quot;A&quot;, &quot;1&quot; or &quot;exclam&quot;. The same physical key can produce different symbols when combined with other keys like &quot;shift&quot; or &quot;alt gr&quot;. For example, &quot;a&quot; and &quot;A&quot; have different <see cref="CoreUI.Input.Key.KeySym"/> but the same <see cref="CoreUI.Input.Key.KeyName"/> &quot;a&quot;.
        /// 
        /// This is the field you typically use to uniquely identify a keyboard symbol, in keyboard shortcuts for example.</summary>
        /// <value>Symbol name produced by key event.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String KeySym {
            get { return GetKeySym(); }
            set { SetKeySym(value); }
        }

        /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.</summary>
        /// <value>Visible string produced by this key event, in UTF8.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String String {
            get { return GetString(); }
            set { SetString(value); }
        }

        /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
        /// 
        /// <b>NOTE: </b>This string replaces the previous one.</summary>
        /// <value>Composed string in UTF8.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String ComposeString {
            get { return GetComposeString(); }
            set { SetComposeString(value); }
        }

        /// <summary>Keyboard scan code of the physical key that produced this event.
        /// 
        /// You typically do not need to use this field, because the system maps scan codes to the more convenient <see cref="CoreUI.Input.Key.KeyName"/>. Us this in keyboard remapping applications or when trying to use a keyboard unknown to your operating system.</summary>
        /// <value>Keyboard scan code.</value>
        /// <since_tizen> 6 </since_tizen>
        public int KeyCode {
            get { return GetKeyCode(); }
            set { SetKeyCode(value); }
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
            return CoreUI.Input.Key.efl_input_key_class_get();
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

                if (efl_input_key_pressed_get_static_delegate == null)
                {
                    efl_input_key_pressed_get_static_delegate = new efl_input_key_pressed_get_delegate(pressed_get);
                }

                if (methods.Contains("GetPressed"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_pressed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_pressed_get_static_delegate) });
                }

                if (efl_input_key_pressed_set_static_delegate == null)
                {
                    efl_input_key_pressed_set_static_delegate = new efl_input_key_pressed_set_delegate(pressed_set);
                }

                if (methods.Contains("SetPressed"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_pressed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_pressed_set_static_delegate) });
                }

                if (efl_input_key_name_get_static_delegate == null)
                {
                    efl_input_key_name_get_static_delegate = new efl_input_key_name_get_delegate(key_name_get);
                }

                if (methods.Contains("GetKeyName"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_name_get_static_delegate) });
                }

                if (efl_input_key_name_set_static_delegate == null)
                {
                    efl_input_key_name_set_static_delegate = new efl_input_key_name_set_delegate(key_name_set);
                }

                if (methods.Contains("SetKeyName"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_name_set_static_delegate) });
                }

                if (efl_input_key_sym_get_static_delegate == null)
                {
                    efl_input_key_sym_get_static_delegate = new efl_input_key_sym_get_delegate(key_sym_get);
                }

                if (methods.Contains("GetKeySym"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_sym_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_sym_get_static_delegate) });
                }

                if (efl_input_key_sym_set_static_delegate == null)
                {
                    efl_input_key_sym_set_static_delegate = new efl_input_key_sym_set_delegate(key_sym_set);
                }

                if (methods.Contains("SetKeySym"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_sym_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_sym_set_static_delegate) });
                }

                if (efl_input_key_string_get_static_delegate == null)
                {
                    efl_input_key_string_get_static_delegate = new efl_input_key_string_get_delegate(string_get);
                }

                if (methods.Contains("GetString"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_string_get_static_delegate) });
                }

                if (efl_input_key_string_set_static_delegate == null)
                {
                    efl_input_key_string_set_static_delegate = new efl_input_key_string_set_delegate(string_set);
                }

                if (methods.Contains("SetString"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_string_set_static_delegate) });
                }

                if (efl_input_key_compose_string_get_static_delegate == null)
                {
                    efl_input_key_compose_string_get_static_delegate = new efl_input_key_compose_string_get_delegate(compose_string_get);
                }

                if (methods.Contains("GetComposeString"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_compose_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_compose_string_get_static_delegate) });
                }

                if (efl_input_key_compose_string_set_static_delegate == null)
                {
                    efl_input_key_compose_string_set_static_delegate = new efl_input_key_compose_string_set_delegate(compose_string_set);
                }

                if (methods.Contains("SetComposeString"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_compose_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_compose_string_set_static_delegate) });
                }

                if (efl_input_key_code_get_static_delegate == null)
                {
                    efl_input_key_code_get_static_delegate = new efl_input_key_code_get_delegate(key_code_get);
                }

                if (methods.Contains("GetKeyCode"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_code_get_static_delegate) });
                }

                if (efl_input_key_code_set_static_delegate == null)
                {
                    efl_input_key_code_set_static_delegate = new efl_input_key_code_set_delegate(key_code_set);
                }

                if (methods.Contains("SetKeyCode"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_code_set_static_delegate) });
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
                return CoreUI.Input.Key.efl_input_key_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_input_key_pressed_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_input_key_pressed_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_key_pressed_get_api_delegate> efl_input_key_pressed_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_key_pressed_get_api_delegate>(Module, "efl_input_key_pressed_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool pressed_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_key_pressed_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Key)ws.Target).GetPressed();
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
                    return efl_input_key_pressed_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_key_pressed_get_delegate efl_input_key_pressed_get_static_delegate;

            
            private delegate void efl_input_key_pressed_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

            
            internal delegate void efl_input_key_pressed_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_key_pressed_set_api_delegate> efl_input_key_pressed_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_key_pressed_set_api_delegate>(Module, "efl_input_key_pressed_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void pressed_set(System.IntPtr obj, System.IntPtr pd, bool val)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_key_pressed_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Key)ws.Target).SetPressed(val);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_key_pressed_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), val);
                }
            }

            private static efl_input_key_pressed_set_delegate efl_input_key_pressed_set_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            private delegate System.String efl_input_key_name_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            internal delegate System.String efl_input_key_name_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_key_name_get_api_delegate> efl_input_key_name_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_key_name_get_api_delegate>(Module, "efl_input_key_name_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.String key_name_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_key_name_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    System.String _ret_var = default(System.String);
                    try
                    {
                        _ret_var = ((Key)ws.Target).GetKeyName();
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
                    return efl_input_key_name_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_key_name_get_delegate efl_input_key_name_get_static_delegate;

            
            private delegate void efl_input_key_name_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String val);

            
            internal delegate void efl_input_key_name_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String val);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_key_name_set_api_delegate> efl_input_key_name_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_key_name_set_api_delegate>(Module, "efl_input_key_name_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void key_name_set(System.IntPtr obj, System.IntPtr pd, System.String val)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_key_name_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Key)ws.Target).SetKeyName(val);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_key_name_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), val);
                }
            }

            private static efl_input_key_name_set_delegate efl_input_key_name_set_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            private delegate System.String efl_input_key_sym_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            internal delegate System.String efl_input_key_sym_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_key_sym_get_api_delegate> efl_input_key_sym_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_key_sym_get_api_delegate>(Module, "efl_input_key_sym_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.String key_sym_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_key_sym_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    System.String _ret_var = default(System.String);
                    try
                    {
                        _ret_var = ((Key)ws.Target).GetKeySym();
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
                    return efl_input_key_sym_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_key_sym_get_delegate efl_input_key_sym_get_static_delegate;

            
            private delegate void efl_input_key_sym_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String val);

            
            internal delegate void efl_input_key_sym_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String val);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_key_sym_set_api_delegate> efl_input_key_sym_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_key_sym_set_api_delegate>(Module, "efl_input_key_sym_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void key_sym_set(System.IntPtr obj, System.IntPtr pd, System.String val)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_key_sym_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Key)ws.Target).SetKeySym(val);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_key_sym_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), val);
                }
            }

            private static efl_input_key_sym_set_delegate efl_input_key_sym_set_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            private delegate System.String efl_input_key_string_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            internal delegate System.String efl_input_key_string_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_key_string_get_api_delegate> efl_input_key_string_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_key_string_get_api_delegate>(Module, "efl_input_key_string_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.String string_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_key_string_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    System.String _ret_var = default(System.String);
                    try
                    {
                        _ret_var = ((Key)ws.Target).GetString();
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
                    return efl_input_key_string_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_key_string_get_delegate efl_input_key_string_get_static_delegate;

            
            private delegate void efl_input_key_string_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String val);

            
            internal delegate void efl_input_key_string_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String val);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_key_string_set_api_delegate> efl_input_key_string_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_key_string_set_api_delegate>(Module, "efl_input_key_string_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void string_set(System.IntPtr obj, System.IntPtr pd, System.String val)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_key_string_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Key)ws.Target).SetString(val);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_key_string_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), val);
                }
            }

            private static efl_input_key_string_set_delegate efl_input_key_string_set_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            private delegate System.String efl_input_key_compose_string_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            internal delegate System.String efl_input_key_compose_string_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_key_compose_string_get_api_delegate> efl_input_key_compose_string_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_key_compose_string_get_api_delegate>(Module, "efl_input_key_compose_string_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.String compose_string_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_key_compose_string_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    System.String _ret_var = default(System.String);
                    try
                    {
                        _ret_var = ((Key)ws.Target).GetComposeString();
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
                    return efl_input_key_compose_string_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_key_compose_string_get_delegate efl_input_key_compose_string_get_static_delegate;

            
            private delegate void efl_input_key_compose_string_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String val);

            
            internal delegate void efl_input_key_compose_string_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String val);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_key_compose_string_set_api_delegate> efl_input_key_compose_string_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_key_compose_string_set_api_delegate>(Module, "efl_input_key_compose_string_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void compose_string_set(System.IntPtr obj, System.IntPtr pd, System.String val)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_key_compose_string_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Key)ws.Target).SetComposeString(val);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_key_compose_string_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), val);
                }
            }

            private static efl_input_key_compose_string_set_delegate efl_input_key_compose_string_set_static_delegate;

            
            private delegate int efl_input_key_code_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_input_key_code_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_key_code_get_api_delegate> efl_input_key_code_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_key_code_get_api_delegate>(Module, "efl_input_key_code_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int key_code_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_key_code_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Key)ws.Target).GetKeyCode();
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
                    return efl_input_key_code_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_key_code_get_delegate efl_input_key_code_get_static_delegate;

            
            private delegate void efl_input_key_code_set_delegate(System.IntPtr obj, System.IntPtr pd,  int val);

            
            internal delegate void efl_input_key_code_set_api_delegate(System.IntPtr obj,  int val);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_key_code_set_api_delegate> efl_input_key_code_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_key_code_set_api_delegate>(Module, "efl_input_key_code_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void key_code_set(System.IntPtr obj, System.IntPtr pd, int val)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_key_code_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Key)ws.Target).SetKeyCode(val);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_key_code_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), val);
                }
            }

            private static efl_input_key_code_set_delegate efl_input_key_code_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.Input {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class KeyExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Pressed<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Key, T>magic = null) where T : CoreUI.Input.Key {
            return new CoreUI.BindableProperty<bool>("pressed", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> KeyName<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Key, T>magic = null) where T : CoreUI.Input.Key {
            return new CoreUI.BindableProperty<System.String>("key_name", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> KeySym<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Key, T>magic = null) where T : CoreUI.Input.Key {
            return new CoreUI.BindableProperty<System.String>("key_sym", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> String<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Key, T>magic = null) where T : CoreUI.Input.Key {
            return new CoreUI.BindableProperty<System.String>("string", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> ComposeString<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Key, T>magic = null) where T : CoreUI.Input.Key {
            return new CoreUI.BindableProperty<System.String>("compose_string", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> KeyCode<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Key, T>magic = null) where T : CoreUI.Input.Key {
            return new CoreUI.BindableProperty<int>("key_code", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> Timestamp<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Key, T>magic = null) where T : CoreUI.Input.Key {
            return new CoreUI.BindableProperty<double>("timestamp", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Input.Device> Device<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Key, T>magic = null) where T : CoreUI.Input.Key {
            return new CoreUI.BindableProperty<CoreUI.Input.Device>("device", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Input.Flags> EventFlags<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Key, T>magic = null) where T : CoreUI.Input.Key {
            return new CoreUI.BindableProperty<CoreUI.Input.Flags>("event_flags", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Processed<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Key, T>magic = null) where T : CoreUI.Input.Key {
            return new CoreUI.BindableProperty<bool>("processed", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Scrolling<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Key, T>magic = null) where T : CoreUI.Input.Key {
            return new CoreUI.BindableProperty<bool>("scrolling", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

