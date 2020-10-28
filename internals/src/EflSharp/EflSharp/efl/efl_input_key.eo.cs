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
    virtual public bool GetPressed() {
         var _ret_var = Efl.Input.Key.NativeMethods.efl_input_key_pressed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if the key is down, <c>false</c> if it is released.</summary>
    /// <param name="val"><c>true</c> if the key is pressed, <c>false</c> otherwise.</param>
    virtual public void SetPressed(bool val) {
                                 Efl.Input.Key.NativeMethods.efl_input_key_pressed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Name string of the physical key that produced this event.
    /// This typically matches what is printed on the key. For example, &quot;1&quot; or &quot;a&quot;. Note that both &quot;a&quot; and &quot;A&quot; are obtained with the same physical key, so both events will have the same <see cref="Efl.Input.Key.KeyName"/> &quot;a&quot; but different <see cref="Efl.Input.Key.KeySym"/>.
    /// 
    /// Commonly used in keyboard remapping menus to uniquely identify a physical key.</summary>
    /// <returns>Name of the key that produced this event.</returns>
    virtual public System.String GetKeyName() {
         var _ret_var = Efl.Input.Key.NativeMethods.efl_input_key_name_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Name string of the physical key that produced this event.
    /// This typically matches what is printed on the key. For example, &quot;1&quot; or &quot;a&quot;. Note that both &quot;a&quot; and &quot;A&quot; are obtained with the same physical key, so both events will have the same <see cref="Efl.Input.Key.KeyName"/> &quot;a&quot; but different <see cref="Efl.Input.Key.KeySym"/>.
    /// 
    /// Commonly used in keyboard remapping menus to uniquely identify a physical key.</summary>
    /// <param name="val">Name of the key that produced this event.</param>
    virtual public void SetKeyName(System.String val) {
                                 Efl.Input.Key.NativeMethods.efl_input_key_name_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Name of the symbol produced by this key event.
    /// For example, &quot;a&quot;, &quot;A&quot;, &quot;1&quot; or &quot;exclam&quot;. The same physical key can produce different symbols when combined with other keys like &quot;shift&quot; or &quot;alt gr&quot;. For example, &quot;a&quot; and &quot;A&quot; have different <see cref="Efl.Input.Key.KeySym"/> but the same <see cref="Efl.Input.Key.KeyName"/> &quot;a&quot;.
    /// 
    /// This is the field you typically use to uniquely identify a keyboard symbol, in keyboard shortcuts for example.</summary>
    /// <returns>Symbol name produced by key event.</returns>
    virtual public System.String GetKeySym() {
         var _ret_var = Efl.Input.Key.NativeMethods.efl_input_key_sym_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Name of the symbol produced by this key event.
    /// For example, &quot;a&quot;, &quot;A&quot;, &quot;1&quot; or &quot;exclam&quot;. The same physical key can produce different symbols when combined with other keys like &quot;shift&quot; or &quot;alt gr&quot;. For example, &quot;a&quot; and &quot;A&quot; have different <see cref="Efl.Input.Key.KeySym"/> but the same <see cref="Efl.Input.Key.KeyName"/> &quot;a&quot;.
    /// 
    /// This is the field you typically use to uniquely identify a keyboard symbol, in keyboard shortcuts for example.</summary>
    /// <param name="val">Symbol name produced by key event.</param>
    virtual public void SetKeySym(System.String val) {
                                 Efl.Input.Key.NativeMethods.efl_input_key_sym_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.</summary>
    /// <returns>Visible string produced by this key event, in UTF8.</returns>
    virtual public System.String GetString() {
         var _ret_var = Efl.Input.Key.NativeMethods.efl_input_key_string_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.</summary>
    /// <param name="val">Visible string produced by this key event, in UTF8.</param>
    virtual public void SetString(System.String val) {
                                 Efl.Input.Key.NativeMethods.efl_input_key_string_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
    /// Note: This string replaces the previous one.</summary>
    /// <returns>Composed string in UTF8.</returns>
    virtual public System.String GetComposeString() {
         var _ret_var = Efl.Input.Key.NativeMethods.efl_input_key_compose_string_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
    /// Note: This string replaces the previous one.</summary>
    /// <param name="val">Composed string in UTF8.</param>
    virtual public void SetComposeString(System.String val) {
                                 Efl.Input.Key.NativeMethods.efl_input_key_compose_string_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Keyboard scan code of the physical key that produced this event.
    /// You typically do not need to use this field, because the system maps scan codes to the more convenient <see cref="Efl.Input.Key.KeyName"/>. Us this in keyboard remapping applications or when trying to use a keyboard unknown to your operating system.</summary>
    /// <returns>Keyboard scan code.</returns>
    virtual public int GetKeyCode() {
         var _ret_var = Efl.Input.Key.NativeMethods.efl_input_key_code_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Keyboard scan code of the physical key that produced this event.
    /// You typically do not need to use this field, because the system maps scan codes to the more convenient <see cref="Efl.Input.Key.KeyName"/>. Us this in keyboard remapping applications or when trying to use a keyboard unknown to your operating system.</summary>
    /// <param name="val">Keyboard scan code.</param>
    virtual public void SetKeyCode(int val) {
                                 Efl.Input.Key.NativeMethods.efl_input_key_code_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Creates a carbon copy of this object and returns it.
    /// The newly created object will have no event handlers or anything of the sort.</summary>
    /// <returns>Returned carbon copy</returns>
    virtual public Efl.IDuplicate Duplicate() {
         var _ret_var = Efl.IDuplicateConcrete.NativeMethods.efl_duplicate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The time at which an event was generated.
    /// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.</summary>
    /// <returns>Time in milliseconds when the event happened.</returns>
    virtual public double GetTimestamp() {
         var _ret_var = Efl.Input.IEventConcrete.NativeMethods.efl_input_timestamp_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Call this when generating events manually.</summary>
    /// <param name="ms">Time in milliseconds when the event happened.</param>
    virtual public void SetTimestamp(double ms) {
                                 Efl.Input.IEventConcrete.NativeMethods.efl_input_timestamp_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),ms);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Input device that originated this event.</summary>
    /// <returns>Input device origin</returns>
    virtual public Efl.Input.Device GetDevice() {
         var _ret_var = Efl.Input.IEventConcrete.NativeMethods.efl_input_device_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Input device that originated this event.</summary>
    /// <param name="dev">Input device origin</param>
    virtual public void SetDevice(Efl.Input.Device dev) {
                                 Efl.Input.IEventConcrete.NativeMethods.efl_input_device_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dev);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <returns>Input event flags</returns>
    virtual public Efl.Input.Flags GetEventFlags() {
         var _ret_var = Efl.Input.IEventConcrete.NativeMethods.efl_input_event_flags_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <param name="flags">Input event flags</param>
    virtual public void SetEventFlags(Efl.Input.Flags flags) {
                                 Efl.Input.IEventConcrete.NativeMethods.efl_input_event_flags_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),flags);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <returns><c>true</c> if the event is on hold, <c>false</c> otherwise</returns>
    virtual public bool GetProcessed() {
         var _ret_var = Efl.Input.IEventConcrete.NativeMethods.efl_input_processed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <param name="val"><c>true</c> if the event is on hold, <c>false</c> otherwise</param>
    virtual public void SetProcessed(bool val) {
                                 Efl.Input.IEventConcrete.NativeMethods.efl_input_processed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <returns><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</returns>
    virtual public bool GetScrolling() {
         var _ret_var = Efl.Input.IEventConcrete.NativeMethods.efl_input_scrolling_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <param name="val"><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</param>
    virtual public void SetScrolling(bool val) {
                                 Efl.Input.IEventConcrete.NativeMethods.efl_input_scrolling_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if the event was fake, not triggered by real hardware.</summary>
    /// <returns><c>true</c> if the event was not from real hardware, <c>false</c> otherwise</returns>
    virtual public bool GetFake() {
         var _ret_var = Efl.Input.IEventConcrete.NativeMethods.efl_input_fake_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Resets the internal data to 0 or default values.</summary>
    virtual public void Reset() {
         Efl.Input.IEventConcrete.NativeMethods.efl_input_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...
    /// (Since EFL 1.22)
    /// 
    /// <b>This is a BETA method</b>. It can be modified or removed in the future. Do not use it for product development.</summary>
    /// <param name="mod">The modifier key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key modifier is pressed.</returns>
    virtual public bool GetModifierEnabled(Efl.Input.Modifier mod, Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.IStateConcrete.NativeMethods.efl_input_modifier_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mod, seat);
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
    virtual public bool GetLockEnabled(Efl.Input.Lock kw_lock, Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.IStateConcrete.NativeMethods.efl_input_lock_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),kw_lock, seat);
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
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
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
                    _ret_var = ((Key)ws.Target).Duplicate();
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
                    _ret_var = ((Key)ws.Target).GetTimestamp();
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
                    ((Key)ws.Target).SetTimestamp(ms);
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
                    _ret_var = ((Key)ws.Target).GetDevice();
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
                    ((Key)ws.Target).SetDevice(dev);
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
                    _ret_var = ((Key)ws.Target).GetEventFlags();
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
                    ((Key)ws.Target).SetEventFlags(flags);
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
                    _ret_var = ((Key)ws.Target).GetProcessed();
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
                    ((Key)ws.Target).SetProcessed(val);
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
                    _ret_var = ((Key)ws.Target).GetScrolling();
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
                    ((Key)ws.Target).SetScrolling(val);
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
                    _ret_var = ((Key)ws.Target).GetFake();
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
                    ((Key)ws.Target).Reset();
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
                    _ret_var = ((Key)ws.Target).GetModifierEnabled(mod, seat);
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
                    _ret_var = ((Key)ws.Target).GetLockEnabled(kw_lock, seat);
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
