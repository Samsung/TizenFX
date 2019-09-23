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

/// <summary>Represents a single key event from a keyboard or similar device.</summary>
[Efl.Input.Key.NativeMethods]
[Efl.Eo.BindingEntity]
public class Key : Efl.Object, Efl.IDuplicate, Efl.Input.IEvent, Efl.Input.IState
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Key))
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
        efl_input_key_class_get();
    /// <summary>Initializes a new instance of the <see cref="Key"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Key(Efl.Object parent= null
            ) : base(efl_input_key_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Key(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Key"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Key(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Key"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Key(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary><c>true</c> if the key is down, <c>false</c> if it is released.</summary>
    /// <returns><c>true</c> if the key is pressed, <c>false</c> otherwise.</returns>
    public virtual bool GetPressed() {
         var _ret_var = Efl.Input.Key.NativeMethods.efl_input_key_pressed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if the key is down, <c>false</c> if it is released.</summary>
    /// <param name="val"><c>true</c> if the key is pressed, <c>false</c> otherwise.</param>
    public virtual void SetPressed(bool val) {
                                 Efl.Input.Key.NativeMethods.efl_input_key_pressed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Name string of the physical key that produced this event.
    /// This typically matches what is printed on the key. For example, &quot;1&quot; or &quot;a&quot;. Note that both &quot;a&quot; and &quot;A&quot; are obtained with the same physical key, so both events will have the same <see cref="Efl.Input.Key.KeyName"/> &quot;a&quot; but different <see cref="Efl.Input.Key.KeySym"/>.
    /// 
    /// Commonly used in keyboard remapping menus to uniquely identify a physical key.</summary>
    /// <returns>Name of the key that produced this event.</returns>
    public virtual System.String GetKeyName() {
         var _ret_var = Efl.Input.Key.NativeMethods.efl_input_key_name_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Name string of the physical key that produced this event.
    /// This typically matches what is printed on the key. For example, &quot;1&quot; or &quot;a&quot;. Note that both &quot;a&quot; and &quot;A&quot; are obtained with the same physical key, so both events will have the same <see cref="Efl.Input.Key.KeyName"/> &quot;a&quot; but different <see cref="Efl.Input.Key.KeySym"/>.
    /// 
    /// Commonly used in keyboard remapping menus to uniquely identify a physical key.</summary>
    /// <param name="val">Name of the key that produced this event.</param>
    public virtual void SetKeyName(System.String val) {
                                 Efl.Input.Key.NativeMethods.efl_input_key_name_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Name of the symbol produced by this key event.
    /// For example, &quot;a&quot;, &quot;A&quot;, &quot;1&quot; or &quot;exclam&quot;. The same physical key can produce different symbols when combined with other keys like &quot;shift&quot; or &quot;alt gr&quot;. For example, &quot;a&quot; and &quot;A&quot; have different <see cref="Efl.Input.Key.KeySym"/> but the same <see cref="Efl.Input.Key.KeyName"/> &quot;a&quot;.
    /// 
    /// This is the field you typically use to uniquely identify a keyboard symbol, in keyboard shortcuts for example.</summary>
    /// <returns>Symbol name produced by key event.</returns>
    public virtual System.String GetKeySym() {
         var _ret_var = Efl.Input.Key.NativeMethods.efl_input_key_sym_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Name of the symbol produced by this key event.
    /// For example, &quot;a&quot;, &quot;A&quot;, &quot;1&quot; or &quot;exclam&quot;. The same physical key can produce different symbols when combined with other keys like &quot;shift&quot; or &quot;alt gr&quot;. For example, &quot;a&quot; and &quot;A&quot; have different <see cref="Efl.Input.Key.KeySym"/> but the same <see cref="Efl.Input.Key.KeyName"/> &quot;a&quot;.
    /// 
    /// This is the field you typically use to uniquely identify a keyboard symbol, in keyboard shortcuts for example.</summary>
    /// <param name="val">Symbol name produced by key event.</param>
    public virtual void SetKeySym(System.String val) {
                                 Efl.Input.Key.NativeMethods.efl_input_key_sym_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.</summary>
    /// <returns>Visible string produced by this key event, in UTF8.</returns>
    public virtual System.String GetString() {
         var _ret_var = Efl.Input.Key.NativeMethods.efl_input_key_string_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.</summary>
    /// <param name="val">Visible string produced by this key event, in UTF8.</param>
    public virtual void SetString(System.String val) {
                                 Efl.Input.Key.NativeMethods.efl_input_key_string_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
    /// Note: This string replaces the previous one.</summary>
    /// <returns>Composed string in UTF8.</returns>
    public virtual System.String GetComposeString() {
         var _ret_var = Efl.Input.Key.NativeMethods.efl_input_key_compose_string_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
    /// Note: This string replaces the previous one.</summary>
    /// <param name="val">Composed string in UTF8.</param>
    public virtual void SetComposeString(System.String val) {
                                 Efl.Input.Key.NativeMethods.efl_input_key_compose_string_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Keyboard scan code of the physical key that produced this event.
    /// You typically do not need to use this field, because the system maps scan codes to the more convenient <see cref="Efl.Input.Key.KeyName"/>. Us this in keyboard remapping applications or when trying to use a keyboard unknown to your operating system.</summary>
    /// <returns>Keyboard scan code.</returns>
    public virtual int GetKeyCode() {
         var _ret_var = Efl.Input.Key.NativeMethods.efl_input_key_code_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Keyboard scan code of the physical key that produced this event.
    /// You typically do not need to use this field, because the system maps scan codes to the more convenient <see cref="Efl.Input.Key.KeyName"/>. Us this in keyboard remapping applications or when trying to use a keyboard unknown to your operating system.</summary>
    /// <param name="val">Keyboard scan code.</param>
    public virtual void SetKeyCode(int val) {
                                 Efl.Input.Key.NativeMethods.efl_input_key_code_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
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
    /// <returns>Time in milliseconds when the event happened.</returns>
    public virtual double GetTimestamp() {
         var _ret_var = Efl.Input.EventConcrete.NativeMethods.efl_input_timestamp_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Call this when generating events manually.</summary>
    /// <param name="ms">Time in milliseconds when the event happened.</param>
    public virtual void SetTimestamp(double ms) {
                                 Efl.Input.EventConcrete.NativeMethods.efl_input_timestamp_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ms);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Input device that originated this event.</summary>
    /// <returns>Input device origin</returns>
    public virtual Efl.Input.Device GetDevice() {
         var _ret_var = Efl.Input.EventConcrete.NativeMethods.efl_input_device_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Input device that originated this event.</summary>
    /// <param name="dev">Input device origin</param>
    public virtual void SetDevice(Efl.Input.Device dev) {
                                 Efl.Input.EventConcrete.NativeMethods.efl_input_device_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dev);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <returns>Input event flags</returns>
    public virtual Efl.Input.Flags GetEventFlags() {
         var _ret_var = Efl.Input.EventConcrete.NativeMethods.efl_input_event_flags_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <param name="flags">Input event flags</param>
    public virtual void SetEventFlags(Efl.Input.Flags flags) {
                                 Efl.Input.EventConcrete.NativeMethods.efl_input_event_flags_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),flags);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <returns><c>true</c> if the event is on hold, <c>false</c> otherwise</returns>
    public virtual bool GetProcessed() {
         var _ret_var = Efl.Input.EventConcrete.NativeMethods.efl_input_processed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <param name="val"><c>true</c> if the event is on hold, <c>false</c> otherwise</param>
    public virtual void SetProcessed(bool val) {
                                 Efl.Input.EventConcrete.NativeMethods.efl_input_processed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <returns><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</returns>
    public virtual bool GetScrolling() {
         var _ret_var = Efl.Input.EventConcrete.NativeMethods.efl_input_scrolling_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <param name="val"><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</param>
    public virtual void SetScrolling(bool val) {
                                 Efl.Input.EventConcrete.NativeMethods.efl_input_scrolling_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if the event was fake, not triggered by real hardware.</summary>
    /// <returns><c>true</c> if the event was not from real hardware, <c>false</c> otherwise</returns>
    public virtual bool GetFake() {
         var _ret_var = Efl.Input.EventConcrete.NativeMethods.efl_input_fake_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Resets the internal data to 0 or default values.</summary>
    public virtual void Reset() {
         Efl.Input.EventConcrete.NativeMethods.efl_input_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="mod">The modifier key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key modifier is pressed.</returns>
    public virtual bool GetModifierEnabled(Efl.Input.Modifier mod, Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.StateConcrete.NativeMethods.efl_input_modifier_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mod, seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Indicates whether a key lock is on, such as NumLock, CapsLock, ...
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="kw_lock">The lock key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key lock is on.</returns>
    public virtual bool GetLockEnabled(Efl.Input.Lock kw_lock, Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.StateConcrete.NativeMethods.efl_input_lock_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_lock, seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary><c>true</c> if the key is down, <c>false</c> if it is released.</summary>
    /// <value><c>true</c> if the key is pressed, <c>false</c> otherwise.</value>
    public bool Pressed {
        get { return GetPressed(); }
        set { SetPressed(value); }
    }
    /// <summary>Name string of the physical key that produced this event.
    /// This typically matches what is printed on the key. For example, &quot;1&quot; or &quot;a&quot;. Note that both &quot;a&quot; and &quot;A&quot; are obtained with the same physical key, so both events will have the same <see cref="Efl.Input.Key.KeyName"/> &quot;a&quot; but different <see cref="Efl.Input.Key.KeySym"/>.
    /// 
    /// Commonly used in keyboard remapping menus to uniquely identify a physical key.</summary>
    /// <value>Name of the key that produced this event.</value>
    public System.String KeyName {
        get { return GetKeyName(); }
        set { SetKeyName(value); }
    }
    /// <summary>Name of the symbol produced by this key event.
    /// For example, &quot;a&quot;, &quot;A&quot;, &quot;1&quot; or &quot;exclam&quot;. The same physical key can produce different symbols when combined with other keys like &quot;shift&quot; or &quot;alt gr&quot;. For example, &quot;a&quot; and &quot;A&quot; have different <see cref="Efl.Input.Key.KeySym"/> but the same <see cref="Efl.Input.Key.KeyName"/> &quot;a&quot;.
    /// 
    /// This is the field you typically use to uniquely identify a keyboard symbol, in keyboard shortcuts for example.</summary>
    /// <value>Symbol name produced by key event.</value>
    public System.String KeySym {
        get { return GetKeySym(); }
        set { SetKeySym(value); }
    }
    /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.</summary>
    /// <value>Visible string produced by this key event, in UTF8.</value>
    public System.String String {
        get { return GetString(); }
        set { SetString(value); }
    }
    /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
    /// Note: This string replaces the previous one.</summary>
    /// <value>Composed string in UTF8.</value>
    public System.String ComposeString {
        get { return GetComposeString(); }
        set { SetComposeString(value); }
    }
    /// <summary>Keyboard scan code of the physical key that produced this event.
    /// You typically do not need to use this field, because the system maps scan codes to the more convenient <see cref="Efl.Input.Key.KeyName"/>. Us this in keyboard remapping applications or when trying to use a keyboard unknown to your operating system.</summary>
    /// <value>Keyboard scan code.</value>
    public int KeyCode {
        get { return GetKeyCode(); }
        set { SetKeyCode(value); }
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
        return Efl.Input.Key.efl_input_key_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_input_key_pressed_get_static_delegate == null)
            {
                efl_input_key_pressed_get_static_delegate = new efl_input_key_pressed_get_delegate(pressed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPressed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_pressed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_pressed_get_static_delegate) });
            }

            if (efl_input_key_pressed_set_static_delegate == null)
            {
                efl_input_key_pressed_set_static_delegate = new efl_input_key_pressed_set_delegate(pressed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPressed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_pressed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_pressed_set_static_delegate) });
            }

            if (efl_input_key_name_get_static_delegate == null)
            {
                efl_input_key_name_get_static_delegate = new efl_input_key_name_get_delegate(key_name_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetKeyName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_name_get_static_delegate) });
            }

            if (efl_input_key_name_set_static_delegate == null)
            {
                efl_input_key_name_set_static_delegate = new efl_input_key_name_set_delegate(key_name_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetKeyName") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_name_set_static_delegate) });
            }

            if (efl_input_key_sym_get_static_delegate == null)
            {
                efl_input_key_sym_get_static_delegate = new efl_input_key_sym_get_delegate(key_sym_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetKeySym") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_sym_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_sym_get_static_delegate) });
            }

            if (efl_input_key_sym_set_static_delegate == null)
            {
                efl_input_key_sym_set_static_delegate = new efl_input_key_sym_set_delegate(key_sym_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetKeySym") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_sym_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_sym_set_static_delegate) });
            }

            if (efl_input_key_string_get_static_delegate == null)
            {
                efl_input_key_string_get_static_delegate = new efl_input_key_string_get_delegate(string_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_string_get_static_delegate) });
            }

            if (efl_input_key_string_set_static_delegate == null)
            {
                efl_input_key_string_set_static_delegate = new efl_input_key_string_set_delegate(string_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_string_set_static_delegate) });
            }

            if (efl_input_key_compose_string_get_static_delegate == null)
            {
                efl_input_key_compose_string_get_static_delegate = new efl_input_key_compose_string_get_delegate(compose_string_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetComposeString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_compose_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_compose_string_get_static_delegate) });
            }

            if (efl_input_key_compose_string_set_static_delegate == null)
            {
                efl_input_key_compose_string_set_static_delegate = new efl_input_key_compose_string_set_delegate(compose_string_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetComposeString") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_compose_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_compose_string_set_static_delegate) });
            }

            if (efl_input_key_code_get_static_delegate == null)
            {
                efl_input_key_code_get_static_delegate = new efl_input_key_code_get_delegate(key_code_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetKeyCode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_code_get_static_delegate) });
            }

            if (efl_input_key_code_set_static_delegate == null)
            {
                efl_input_key_code_set_static_delegate = new efl_input_key_code_set_delegate(key_code_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetKeyCode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_key_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_code_set_static_delegate) });
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
            return Efl.Input.Key.efl_input_key_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_key_pressed_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_key_pressed_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_key_pressed_get_api_delegate> efl_input_key_pressed_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_pressed_get_api_delegate>(Module, "efl_input_key_pressed_get");

        private static bool pressed_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_key_pressed_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Key)ws.Target).GetPressed();
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
                return efl_input_key_pressed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_key_pressed_get_delegate efl_input_key_pressed_get_static_delegate;

        
        private delegate void efl_input_key_pressed_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool val);

        
        public delegate void efl_input_key_pressed_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool val);

        public static Efl.Eo.FunctionWrapper<efl_input_key_pressed_set_api_delegate> efl_input_key_pressed_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_pressed_set_api_delegate>(Module, "efl_input_key_pressed_set");

        private static void pressed_set(System.IntPtr obj, System.IntPtr pd, bool val)
        {
            Eina.Log.Debug("function efl_input_key_pressed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Key)ws.Target).SetPressed(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_key_pressed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_input_key_pressed_set_delegate efl_input_key_pressed_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_input_key_name_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_input_key_name_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_key_name_get_api_delegate> efl_input_key_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_name_get_api_delegate>(Module, "efl_input_key_name_get");

        private static System.String key_name_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_key_name_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Key)ws.Target).GetKeyName();
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
                return efl_input_key_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_key_name_get_delegate efl_input_key_name_get_static_delegate;

        
        private delegate void efl_input_key_name_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String val);

        
        public delegate void efl_input_key_name_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String val);

        public static Efl.Eo.FunctionWrapper<efl_input_key_name_set_api_delegate> efl_input_key_name_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_name_set_api_delegate>(Module, "efl_input_key_name_set");

        private static void key_name_set(System.IntPtr obj, System.IntPtr pd, System.String val)
        {
            Eina.Log.Debug("function efl_input_key_name_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Key)ws.Target).SetKeyName(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_key_name_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_input_key_name_set_delegate efl_input_key_name_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_input_key_sym_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_input_key_sym_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_key_sym_get_api_delegate> efl_input_key_sym_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_sym_get_api_delegate>(Module, "efl_input_key_sym_get");

        private static System.String key_sym_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_key_sym_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Key)ws.Target).GetKeySym();
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
                return efl_input_key_sym_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_key_sym_get_delegate efl_input_key_sym_get_static_delegate;

        
        private delegate void efl_input_key_sym_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String val);

        
        public delegate void efl_input_key_sym_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String val);

        public static Efl.Eo.FunctionWrapper<efl_input_key_sym_set_api_delegate> efl_input_key_sym_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_sym_set_api_delegate>(Module, "efl_input_key_sym_set");

        private static void key_sym_set(System.IntPtr obj, System.IntPtr pd, System.String val)
        {
            Eina.Log.Debug("function efl_input_key_sym_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Key)ws.Target).SetKeySym(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_key_sym_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_input_key_sym_set_delegate efl_input_key_sym_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_input_key_string_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_input_key_string_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_key_string_get_api_delegate> efl_input_key_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_string_get_api_delegate>(Module, "efl_input_key_string_get");

        private static System.String string_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_key_string_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Key)ws.Target).GetString();
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
                return efl_input_key_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_key_string_get_delegate efl_input_key_string_get_static_delegate;

        
        private delegate void efl_input_key_string_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String val);

        
        public delegate void efl_input_key_string_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String val);

        public static Efl.Eo.FunctionWrapper<efl_input_key_string_set_api_delegate> efl_input_key_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_string_set_api_delegate>(Module, "efl_input_key_string_set");

        private static void string_set(System.IntPtr obj, System.IntPtr pd, System.String val)
        {
            Eina.Log.Debug("function efl_input_key_string_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Key)ws.Target).SetString(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_key_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_input_key_string_set_delegate efl_input_key_string_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_input_key_compose_string_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_input_key_compose_string_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_key_compose_string_get_api_delegate> efl_input_key_compose_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_compose_string_get_api_delegate>(Module, "efl_input_key_compose_string_get");

        private static System.String compose_string_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_key_compose_string_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Key)ws.Target).GetComposeString();
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
                return efl_input_key_compose_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_key_compose_string_get_delegate efl_input_key_compose_string_get_static_delegate;

        
        private delegate void efl_input_key_compose_string_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String val);

        
        public delegate void efl_input_key_compose_string_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String val);

        public static Efl.Eo.FunctionWrapper<efl_input_key_compose_string_set_api_delegate> efl_input_key_compose_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_compose_string_set_api_delegate>(Module, "efl_input_key_compose_string_set");

        private static void compose_string_set(System.IntPtr obj, System.IntPtr pd, System.String val)
        {
            Eina.Log.Debug("function efl_input_key_compose_string_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Key)ws.Target).SetComposeString(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_key_compose_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_input_key_compose_string_set_delegate efl_input_key_compose_string_set_static_delegate;

        
        private delegate int efl_input_key_code_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_input_key_code_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_input_key_code_get_api_delegate> efl_input_key_code_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_code_get_api_delegate>(Module, "efl_input_key_code_get");

        private static int key_code_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_input_key_code_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Key)ws.Target).GetKeyCode();
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
                return efl_input_key_code_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_key_code_get_delegate efl_input_key_code_get_static_delegate;

        
        private delegate void efl_input_key_code_set_delegate(System.IntPtr obj, System.IntPtr pd,  int val);

        
        public delegate void efl_input_key_code_set_api_delegate(System.IntPtr obj,  int val);

        public static Efl.Eo.FunctionWrapper<efl_input_key_code_set_api_delegate> efl_input_key_code_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_code_set_api_delegate>(Module, "efl_input_key_code_set");

        private static void key_code_set(System.IntPtr obj, System.IntPtr pd, int val)
        {
            Eina.Log.Debug("function efl_input_key_code_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Key)ws.Target).SetKeyCode(val);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_input_key_code_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), val);
            }
        }

        private static efl_input_key_code_set_delegate efl_input_key_code_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_InputKey_ExtensionMethods {
    public static Efl.BindableProperty<bool> Pressed<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Key, T>magic = null) where T : Efl.Input.Key {
        return new Efl.BindableProperty<bool>("pressed", fac);
    }

    public static Efl.BindableProperty<System.String> KeyName<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Key, T>magic = null) where T : Efl.Input.Key {
        return new Efl.BindableProperty<System.String>("key_name", fac);
    }

    public static Efl.BindableProperty<System.String> KeySym<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Key, T>magic = null) where T : Efl.Input.Key {
        return new Efl.BindableProperty<System.String>("key_sym", fac);
    }

    public static Efl.BindableProperty<System.String> String<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Key, T>magic = null) where T : Efl.Input.Key {
        return new Efl.BindableProperty<System.String>("string", fac);
    }

    public static Efl.BindableProperty<System.String> ComposeString<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Key, T>magic = null) where T : Efl.Input.Key {
        return new Efl.BindableProperty<System.String>("compose_string", fac);
    }

    public static Efl.BindableProperty<int> KeyCode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Key, T>magic = null) where T : Efl.Input.Key {
        return new Efl.BindableProperty<int>("key_code", fac);
    }

    public static Efl.BindableProperty<double> Timestamp<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Key, T>magic = null) where T : Efl.Input.Key {
        return new Efl.BindableProperty<double>("timestamp", fac);
    }

    public static Efl.BindableProperty<Efl.Input.Device> Device<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Key, T>magic = null) where T : Efl.Input.Key {
        return new Efl.BindableProperty<Efl.Input.Device>("device", fac);
    }

    public static Efl.BindableProperty<Efl.Input.Flags> EventFlags<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Key, T>magic = null) where T : Efl.Input.Key {
        return new Efl.BindableProperty<Efl.Input.Flags>("event_flags", fac);
    }

    public static Efl.BindableProperty<bool> Processed<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Key, T>magic = null) where T : Efl.Input.Key {
        return new Efl.BindableProperty<bool>("processed", fac);
    }

    public static Efl.BindableProperty<bool> Scrolling<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Input.Key, T>magic = null) where T : Efl.Input.Key {
        return new Efl.BindableProperty<bool>("scrolling", fac);
    }

    
    
    
}
#pragma warning restore CS1591
#endif
