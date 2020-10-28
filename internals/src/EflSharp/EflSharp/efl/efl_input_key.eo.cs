#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Input { 
/// <summary>Represents a single key event from a keyboard or similar device.</summary>
[KeyNativeInherit]
public class Key : Efl.Object, Efl.Eo.IWrapper,Efl.IDuplicate,Efl.Input.IEvent,Efl.Input.IState
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Key))
                return Efl.Input.KeyNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
        efl_input_key_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public Key(Efl.Object parent= null
            ) :
        base(efl_input_key_class_get(), typeof(Key), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Key(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Key(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
    }
    /// <summary><c>true</c> if the key is down, <c>false</c> if it is released.</summary>
    /// <returns><c>true</c> if the key is pressed, <c>false</c> otherwise</returns>
    virtual public bool GetPressed() {
         var _ret_var = Efl.Input.KeyNativeInherit.efl_input_key_pressed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if the key is down, <c>false</c> if it is released.</summary>
    /// <param name="val"><c>true</c> if the key is pressed, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetPressed( bool val) {
                                 Efl.Input.KeyNativeInherit.efl_input_key_pressed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Name string of the key.</summary>
    /// <returns>Key name</returns>
    virtual public System.String GetKeyName() {
         var _ret_var = Efl.Input.KeyNativeInherit.efl_input_key_name_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Name string of the key.</summary>
    /// <param name="val">Key name</param>
    /// <returns></returns>
    virtual public void SetKeyName( System.String val) {
                                 Efl.Input.KeyNativeInherit.efl_input_key_name_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Logical key.
    /// Eg. Shift + 1 = exclamation</summary>
    /// <returns>Logical key name</returns>
    virtual public System.String GetKey() {
         var _ret_var = Efl.Input.KeyNativeInherit.efl_input_key_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Logical key.
    /// Eg. Shift + 1 = exclamation</summary>
    /// <param name="val">Logical key name</param>
    /// <returns></returns>
    virtual public void SetKey( System.String val) {
                                 Efl.Input.KeyNativeInherit.efl_input_key_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.</summary>
    /// <returns>Visible string from key press in UTF8</returns>
    virtual public System.String GetString() {
         var _ret_var = Efl.Input.KeyNativeInherit.efl_input_key_string_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.</summary>
    /// <param name="val">Visible string from key press in UTF8</param>
    /// <returns></returns>
    virtual public void SetString( System.String val) {
                                 Efl.Input.KeyNativeInherit.efl_input_key_string_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
    /// Note: This string replaces the previous one</summary>
    /// <returns>Composed key string in UTF8</returns>
    virtual public System.String GetCompose() {
         var _ret_var = Efl.Input.KeyNativeInherit.efl_input_key_compose_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
    /// Note: This string replaces the previous one</summary>
    /// <param name="val">Composed key string in UTF8</param>
    /// <returns></returns>
    virtual public void SetCompose( System.String val) {
                                 Efl.Input.KeyNativeInherit.efl_input_key_compose_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Key scan code numeric value.</summary>
    /// <returns>Key scan code</returns>
    virtual public int GetKeyCode() {
         var _ret_var = Efl.Input.KeyNativeInherit.efl_input_key_code_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Key scan code numeric value.</summary>
    /// <param name="val">Key scan code</param>
    /// <returns></returns>
    virtual public void SetKeyCode( int val) {
                                 Efl.Input.KeyNativeInherit.efl_input_key_code_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Creates a carbon copy of this object and returns it.
    /// The newly created object will have no event handlers or anything of the sort.</summary>
    /// <returns>Returned carbon copy</returns>
    virtual public Efl.IDuplicate DoDuplicate() {
         var _ret_var = Efl.IDuplicateNativeInherit.efl_duplicate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The time at which an event was generated.
    /// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.</summary>
    /// <returns>Time in milliseconds when the event happened.</returns>
    virtual public double GetTimestamp() {
         var _ret_var = Efl.Input.IEventNativeInherit.efl_input_timestamp_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Call this when generating events manually.</summary>
    /// <param name="ms">Time in milliseconds when the event happened.</param>
    /// <returns></returns>
    virtual public void SetTimestamp( double ms) {
                                 Efl.Input.IEventNativeInherit.efl_input_timestamp_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), ms);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Input device that originated this event.</summary>
    /// <returns>Input device origin</returns>
    virtual public Efl.Input.Device GetDevice() {
         var _ret_var = Efl.Input.IEventNativeInherit.efl_input_device_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Input device that originated this event.</summary>
    /// <param name="dev">Input device origin</param>
    /// <returns></returns>
    virtual public void SetDevice( Efl.Input.Device dev) {
                                 Efl.Input.IEventNativeInherit.efl_input_device_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dev);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <returns>Input event flags</returns>
    virtual public Efl.Input.Flags GetEventFlags() {
         var _ret_var = Efl.Input.IEventNativeInherit.efl_input_event_flags_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Extra flags for this event, may be changed by the user.</summary>
    /// <param name="flags">Input event flags</param>
    /// <returns></returns>
    virtual public void SetEventFlags( Efl.Input.Flags flags) {
                                 Efl.Input.IEventNativeInherit.efl_input_event_flags_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), flags);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <returns><c>true</c> if the event is on hold, <c>false</c> otherwise</returns>
    virtual public bool GetProcessed() {
         var _ret_var = Efl.Input.IEventNativeInherit.efl_input_processed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
    /// <param name="val"><c>true</c> if the event is on hold, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetProcessed( bool val) {
                                 Efl.Input.IEventNativeInherit.efl_input_processed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <returns><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</returns>
    virtual public bool GetScrolling() {
         var _ret_var = Efl.Input.IEventNativeInherit.efl_input_scrolling_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
    /// <param name="val"><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetScrolling( bool val) {
                                 Efl.Input.IEventNativeInherit.efl_input_scrolling_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), val);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary><c>true</c> if the event was fake, not triggered by real hardware.</summary>
    /// <returns><c>true</c> if the event was not from real hardware, <c>false</c> otherwise</returns>
    virtual public bool GetFake() {
         var _ret_var = Efl.Input.IEventNativeInherit.efl_input_fake_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Resets the internal data to 0 or default values.</summary>
    /// <returns></returns>
    virtual public void Reset() {
         Efl.Input.IEventNativeInherit.efl_input_reset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Indicates whether a key modifier is on, such as Ctrl, Shift, ...
    /// (Since EFL 1.22)</summary>
    /// <param name="mod">The modifier key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key modifier is pressed.</returns>
    virtual public bool GetModifierEnabled( Efl.Input.Modifier mod,  Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.IStateNativeInherit.efl_input_modifier_enabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), mod,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Indicates whether a key lock is on, such as NumLock, CapsLock, ...
    /// (Since EFL 1.22)</summary>
    /// <param name="kw_lock">The lock key to test.</param>
    /// <param name="seat">The seat device, may be <c>null</c></param>
    /// <returns><c>true</c> if the key lock is on.</returns>
    virtual public bool GetLockEnabled( Efl.Input.Lock kw_lock,  Efl.Input.Device seat) {
                                                         var _ret_var = Efl.Input.IStateNativeInherit.efl_input_lock_enabled_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), kw_lock,  seat);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary><c>true</c> if the key is down, <c>false</c> if it is released.</summary>
/// <value><c>true</c> if the key is pressed, <c>false</c> otherwise</value>
    public bool Pressed {
        get { return GetPressed(); }
        set { SetPressed( value); }
    }
    /// <summary>Name string of the key.</summary>
/// <value>Key name</value>
    public System.String KeyName {
        get { return GetKeyName(); }
        set { SetKeyName( value); }
    }
    /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.</summary>
/// <value>Visible string from key press in UTF8</value>
    public System.String String {
        get { return GetString(); }
        set { SetString( value); }
    }
    /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
/// Note: This string replaces the previous one</summary>
/// <value>Composed key string in UTF8</value>
    public System.String Compose {
        get { return GetCompose(); }
        set { SetCompose( value); }
    }
    /// <summary>Key scan code numeric value.</summary>
/// <value>Key scan code</value>
    public int KeyCode {
        get { return GetKeyCode(); }
        set { SetKeyCode( value); }
    }
    /// <summary>The time at which an event was generated.
/// If the event is generated by a server (eg. X.org or Wayland), then the time may be set by the server. Usually this time will be based on the monotonic clock, if available, but this class can not guarantee it.</summary>
/// <value>Time in milliseconds when the event happened.</value>
    public double Timestamp {
        get { return GetTimestamp(); }
        set { SetTimestamp( value); }
    }
    /// <summary>Input device that originated this event.</summary>
/// <value>Input device origin</value>
    public Efl.Input.Device Device {
        get { return GetDevice(); }
        set { SetDevice( value); }
    }
    /// <summary>Extra flags for this event, may be changed by the user.</summary>
/// <value>Input event flags</value>
    public Efl.Input.Flags EventFlags {
        get { return GetEventFlags(); }
        set { SetEventFlags( value); }
    }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event is on hold.</summary>
/// <value><c>true</c> if the event is on hold, <c>false</c> otherwise</value>
    public bool Processed {
        get { return GetProcessed(); }
        set { SetProcessed( value); }
    }
    /// <summary><c>true</c> if <see cref="Efl.Input.IEvent.EventFlags"/> indicates the event happened while scrolling.</summary>
/// <value><c>true</c> if the event happened while scrolling, <c>false</c> otherwise</value>
    public bool Scrolling {
        get { return GetScrolling(); }
        set { SetScrolling( value); }
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
}
public class KeyNativeInherit : Efl.ObjectNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_input_key_pressed_get_static_delegate == null)
            efl_input_key_pressed_get_static_delegate = new efl_input_key_pressed_get_delegate(pressed_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPressed") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_key_pressed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_pressed_get_static_delegate)});
        if (efl_input_key_pressed_set_static_delegate == null)
            efl_input_key_pressed_set_static_delegate = new efl_input_key_pressed_set_delegate(pressed_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPressed") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_key_pressed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_pressed_set_static_delegate)});
        if (efl_input_key_name_get_static_delegate == null)
            efl_input_key_name_get_static_delegate = new efl_input_key_name_get_delegate(key_name_get);
        if (methods.FirstOrDefault(m => m.Name == "GetKeyName") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_key_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_name_get_static_delegate)});
        if (efl_input_key_name_set_static_delegate == null)
            efl_input_key_name_set_static_delegate = new efl_input_key_name_set_delegate(key_name_set);
        if (methods.FirstOrDefault(m => m.Name == "SetKeyName") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_key_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_name_set_static_delegate)});
        if (efl_input_key_get_static_delegate == null)
            efl_input_key_get_static_delegate = new efl_input_key_get_delegate(key_get);
        if (methods.FirstOrDefault(m => m.Name == "GetKey") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_key_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_get_static_delegate)});
        if (efl_input_key_set_static_delegate == null)
            efl_input_key_set_static_delegate = new efl_input_key_set_delegate(key_set);
        if (methods.FirstOrDefault(m => m.Name == "SetKey") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_key_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_set_static_delegate)});
        if (efl_input_key_string_get_static_delegate == null)
            efl_input_key_string_get_static_delegate = new efl_input_key_string_get_delegate(string_get);
        if (methods.FirstOrDefault(m => m.Name == "GetString") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_key_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_string_get_static_delegate)});
        if (efl_input_key_string_set_static_delegate == null)
            efl_input_key_string_set_static_delegate = new efl_input_key_string_set_delegate(string_set);
        if (methods.FirstOrDefault(m => m.Name == "SetString") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_key_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_string_set_static_delegate)});
        if (efl_input_key_compose_get_static_delegate == null)
            efl_input_key_compose_get_static_delegate = new efl_input_key_compose_get_delegate(compose_get);
        if (methods.FirstOrDefault(m => m.Name == "GetCompose") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_key_compose_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_compose_get_static_delegate)});
        if (efl_input_key_compose_set_static_delegate == null)
            efl_input_key_compose_set_static_delegate = new efl_input_key_compose_set_delegate(compose_set);
        if (methods.FirstOrDefault(m => m.Name == "SetCompose") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_key_compose_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_compose_set_static_delegate)});
        if (efl_input_key_code_get_static_delegate == null)
            efl_input_key_code_get_static_delegate = new efl_input_key_code_get_delegate(key_code_get);
        if (methods.FirstOrDefault(m => m.Name == "GetKeyCode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_key_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_code_get_static_delegate)});
        if (efl_input_key_code_set_static_delegate == null)
            efl_input_key_code_set_static_delegate = new efl_input_key_code_set_delegate(key_code_set);
        if (methods.FirstOrDefault(m => m.Name == "SetKeyCode") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_key_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_code_set_static_delegate)});
        if (efl_duplicate_static_delegate == null)
            efl_duplicate_static_delegate = new efl_duplicate_delegate(duplicate);
        if (methods.FirstOrDefault(m => m.Name == "DoDuplicate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_duplicate"), func = Marshal.GetFunctionPointerForDelegate(efl_duplicate_static_delegate)});
        if (efl_input_timestamp_get_static_delegate == null)
            efl_input_timestamp_get_static_delegate = new efl_input_timestamp_get_delegate(timestamp_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTimestamp") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_timestamp_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_timestamp_get_static_delegate)});
        if (efl_input_timestamp_set_static_delegate == null)
            efl_input_timestamp_set_static_delegate = new efl_input_timestamp_set_delegate(timestamp_set);
        if (methods.FirstOrDefault(m => m.Name == "SetTimestamp") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_timestamp_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_timestamp_set_static_delegate)});
        if (efl_input_device_get_static_delegate == null)
            efl_input_device_get_static_delegate = new efl_input_device_get_delegate(device_get);
        if (methods.FirstOrDefault(m => m.Name == "GetDevice") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_device_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_get_static_delegate)});
        if (efl_input_device_set_static_delegate == null)
            efl_input_device_set_static_delegate = new efl_input_device_set_delegate(device_set);
        if (methods.FirstOrDefault(m => m.Name == "SetDevice") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_device_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_set_static_delegate)});
        if (efl_input_event_flags_get_static_delegate == null)
            efl_input_event_flags_get_static_delegate = new efl_input_event_flags_get_delegate(event_flags_get);
        if (methods.FirstOrDefault(m => m.Name == "GetEventFlags") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_event_flags_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_event_flags_get_static_delegate)});
        if (efl_input_event_flags_set_static_delegate == null)
            efl_input_event_flags_set_static_delegate = new efl_input_event_flags_set_delegate(event_flags_set);
        if (methods.FirstOrDefault(m => m.Name == "SetEventFlags") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_event_flags_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_event_flags_set_static_delegate)});
        if (efl_input_processed_get_static_delegate == null)
            efl_input_processed_get_static_delegate = new efl_input_processed_get_delegate(processed_get);
        if (methods.FirstOrDefault(m => m.Name == "GetProcessed") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_processed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_processed_get_static_delegate)});
        if (efl_input_processed_set_static_delegate == null)
            efl_input_processed_set_static_delegate = new efl_input_processed_set_delegate(processed_set);
        if (methods.FirstOrDefault(m => m.Name == "SetProcessed") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_processed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_processed_set_static_delegate)});
        if (efl_input_scrolling_get_static_delegate == null)
            efl_input_scrolling_get_static_delegate = new efl_input_scrolling_get_delegate(scrolling_get);
        if (methods.FirstOrDefault(m => m.Name == "GetScrolling") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_scrolling_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_scrolling_get_static_delegate)});
        if (efl_input_scrolling_set_static_delegate == null)
            efl_input_scrolling_set_static_delegate = new efl_input_scrolling_set_delegate(scrolling_set);
        if (methods.FirstOrDefault(m => m.Name == "SetScrolling") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_scrolling_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_scrolling_set_static_delegate)});
        if (efl_input_fake_get_static_delegate == null)
            efl_input_fake_get_static_delegate = new efl_input_fake_get_delegate(fake_get);
        if (methods.FirstOrDefault(m => m.Name == "GetFake") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_fake_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_fake_get_static_delegate)});
        if (efl_input_reset_static_delegate == null)
            efl_input_reset_static_delegate = new efl_input_reset_delegate(reset);
        if (methods.FirstOrDefault(m => m.Name == "Reset") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_input_reset_static_delegate)});
        if (efl_input_modifier_enabled_get_static_delegate == null)
            efl_input_modifier_enabled_get_static_delegate = new efl_input_modifier_enabled_get_delegate(modifier_enabled_get);
        if (methods.FirstOrDefault(m => m.Name == "GetModifierEnabled") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_modifier_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_modifier_enabled_get_static_delegate)});
        if (efl_input_lock_enabled_get_static_delegate == null)
            efl_input_lock_enabled_get_static_delegate = new efl_input_lock_enabled_get_delegate(lock_enabled_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLockEnabled") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_input_lock_enabled_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_lock_enabled_get_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Input.Key.efl_input_key_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Input.Key.efl_input_key_class_get();
    }


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_key_pressed_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_input_key_pressed_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_input_key_pressed_get_api_delegate> efl_input_key_pressed_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_pressed_get_api_delegate>(_Module, "efl_input_key_pressed_get");
     private static bool pressed_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_input_key_pressed_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Key)wrapper).GetPressed();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_input_key_pressed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_input_key_pressed_get_delegate efl_input_key_pressed_get_static_delegate;


     private delegate void efl_input_key_pressed_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);


     public delegate void efl_input_key_pressed_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
     public static Efl.Eo.FunctionWrapper<efl_input_key_pressed_set_api_delegate> efl_input_key_pressed_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_pressed_set_api_delegate>(_Module, "efl_input_key_pressed_set");
     private static void pressed_set(System.IntPtr obj, System.IntPtr pd,  bool val)
    {
        Eina.Log.Debug("function efl_input_key_pressed_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Key)wrapper).SetPressed( val);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_input_key_pressed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
        }
    }
    private static efl_input_key_pressed_set_delegate efl_input_key_pressed_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_input_key_name_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_input_key_name_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_input_key_name_get_api_delegate> efl_input_key_name_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_name_get_api_delegate>(_Module, "efl_input_key_name_get");
     private static System.String key_name_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_input_key_name_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Key)wrapper).GetKeyName();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_input_key_name_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_input_key_name_get_delegate efl_input_key_name_get_static_delegate;


     private delegate void efl_input_key_name_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String val);


     public delegate void efl_input_key_name_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String val);
     public static Efl.Eo.FunctionWrapper<efl_input_key_name_set_api_delegate> efl_input_key_name_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_name_set_api_delegate>(_Module, "efl_input_key_name_set");
     private static void key_name_set(System.IntPtr obj, System.IntPtr pd,  System.String val)
    {
        Eina.Log.Debug("function efl_input_key_name_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Key)wrapper).SetKeyName( val);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_input_key_name_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
        }
    }
    private static efl_input_key_name_set_delegate efl_input_key_name_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_input_key_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_input_key_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_input_key_get_api_delegate> efl_input_key_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_get_api_delegate>(_Module, "efl_input_key_get");
     private static System.String key_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_input_key_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Key)wrapper).GetKey();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_input_key_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_input_key_get_delegate efl_input_key_get_static_delegate;


     private delegate void efl_input_key_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String val);


     public delegate void efl_input_key_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String val);
     public static Efl.Eo.FunctionWrapper<efl_input_key_set_api_delegate> efl_input_key_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_set_api_delegate>(_Module, "efl_input_key_set");
     private static void key_set(System.IntPtr obj, System.IntPtr pd,  System.String val)
    {
        Eina.Log.Debug("function efl_input_key_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Key)wrapper).SetKey( val);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_input_key_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
        }
    }
    private static efl_input_key_set_delegate efl_input_key_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_input_key_string_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_input_key_string_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_input_key_string_get_api_delegate> efl_input_key_string_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_string_get_api_delegate>(_Module, "efl_input_key_string_get");
     private static System.String string_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_input_key_string_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Key)wrapper).GetString();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_input_key_string_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_input_key_string_get_delegate efl_input_key_string_get_static_delegate;


     private delegate void efl_input_key_string_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String val);


     public delegate void efl_input_key_string_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String val);
     public static Efl.Eo.FunctionWrapper<efl_input_key_string_set_api_delegate> efl_input_key_string_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_string_set_api_delegate>(_Module, "efl_input_key_string_set");
     private static void string_set(System.IntPtr obj, System.IntPtr pd,  System.String val)
    {
        Eina.Log.Debug("function efl_input_key_string_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Key)wrapper).SetString( val);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_input_key_string_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
        }
    }
    private static efl_input_key_string_set_delegate efl_input_key_string_set_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_input_key_compose_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_input_key_compose_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_input_key_compose_get_api_delegate> efl_input_key_compose_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_compose_get_api_delegate>(_Module, "efl_input_key_compose_get");
     private static System.String compose_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_input_key_compose_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Key)wrapper).GetCompose();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_input_key_compose_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_input_key_compose_get_delegate efl_input_key_compose_get_static_delegate;


     private delegate void efl_input_key_compose_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String val);


     public delegate void efl_input_key_compose_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String val);
     public static Efl.Eo.FunctionWrapper<efl_input_key_compose_set_api_delegate> efl_input_key_compose_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_compose_set_api_delegate>(_Module, "efl_input_key_compose_set");
     private static void compose_set(System.IntPtr obj, System.IntPtr pd,  System.String val)
    {
        Eina.Log.Debug("function efl_input_key_compose_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Key)wrapper).SetCompose( val);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_input_key_compose_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
        }
    }
    private static efl_input_key_compose_set_delegate efl_input_key_compose_set_static_delegate;


     private delegate int efl_input_key_code_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate int efl_input_key_code_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_input_key_code_get_api_delegate> efl_input_key_code_get_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_code_get_api_delegate>(_Module, "efl_input_key_code_get");
     private static int key_code_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_input_key_code_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        int _ret_var = default(int);
            try {
                _ret_var = ((Key)wrapper).GetKeyCode();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_input_key_code_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_input_key_code_get_delegate efl_input_key_code_get_static_delegate;


     private delegate void efl_input_key_code_set_delegate(System.IntPtr obj, System.IntPtr pd,   int val);


     public delegate void efl_input_key_code_set_api_delegate(System.IntPtr obj,   int val);
     public static Efl.Eo.FunctionWrapper<efl_input_key_code_set_api_delegate> efl_input_key_code_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_key_code_set_api_delegate>(_Module, "efl_input_key_code_set");
     private static void key_code_set(System.IntPtr obj, System.IntPtr pd,  int val)
    {
        Eina.Log.Debug("function efl_input_key_code_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Key)wrapper).SetKeyCode( val);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_input_key_code_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
        }
    }
    private static efl_input_key_code_set_delegate efl_input_key_code_set_static_delegate;


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.IDuplicateConcrete, Efl.Eo.OwnTag>))] private delegate Efl.IDuplicate efl_duplicate_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.IDuplicateConcrete, Efl.Eo.OwnTag>))] public delegate Efl.IDuplicate efl_duplicate_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_duplicate_api_delegate> efl_duplicate_ptr = new Efl.Eo.FunctionWrapper<efl_duplicate_api_delegate>(_Module, "efl_duplicate");
     private static Efl.IDuplicate duplicate(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_duplicate was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.IDuplicate _ret_var = default(Efl.IDuplicate);
            try {
                _ret_var = ((Key)wrapper).DoDuplicate();
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Key)wrapper).GetTimestamp();
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


     private delegate void efl_input_timestamp_set_delegate(System.IntPtr obj, System.IntPtr pd,   double ms);


     public delegate void efl_input_timestamp_set_api_delegate(System.IntPtr obj,   double ms);
     public static Efl.Eo.FunctionWrapper<efl_input_timestamp_set_api_delegate> efl_input_timestamp_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_timestamp_set_api_delegate>(_Module, "efl_input_timestamp_set");
     private static void timestamp_set(System.IntPtr obj, System.IntPtr pd,  double ms)
    {
        Eina.Log.Debug("function efl_input_timestamp_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Key)wrapper).SetTimestamp( ms);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Input.Device _ret_var = default(Efl.Input.Device);
            try {
                _ret_var = ((Key)wrapper).GetDevice();
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


     private delegate void efl_input_device_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev);


     public delegate void efl_input_device_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev);
     public static Efl.Eo.FunctionWrapper<efl_input_device_set_api_delegate> efl_input_device_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_device_set_api_delegate>(_Module, "efl_input_device_set");
     private static void device_set(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device dev)
    {
        Eina.Log.Debug("function efl_input_device_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Key)wrapper).SetDevice( dev);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Input.Flags _ret_var = default(Efl.Input.Flags);
            try {
                _ret_var = ((Key)wrapper).GetEventFlags();
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


     private delegate void efl_input_event_flags_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.Flags flags);


     public delegate void efl_input_event_flags_set_api_delegate(System.IntPtr obj,   Efl.Input.Flags flags);
     public static Efl.Eo.FunctionWrapper<efl_input_event_flags_set_api_delegate> efl_input_event_flags_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_event_flags_set_api_delegate>(_Module, "efl_input_event_flags_set");
     private static void event_flags_set(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Flags flags)
    {
        Eina.Log.Debug("function efl_input_event_flags_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Key)wrapper).SetEventFlags( flags);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Key)wrapper).GetProcessed();
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


     private delegate void efl_input_processed_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);


     public delegate void efl_input_processed_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
     public static Efl.Eo.FunctionWrapper<efl_input_processed_set_api_delegate> efl_input_processed_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_processed_set_api_delegate>(_Module, "efl_input_processed_set");
     private static void processed_set(System.IntPtr obj, System.IntPtr pd,  bool val)
    {
        Eina.Log.Debug("function efl_input_processed_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Key)wrapper).SetProcessed( val);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Key)wrapper).GetScrolling();
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


     private delegate void efl_input_scrolling_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);


     public delegate void efl_input_scrolling_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
     public static Efl.Eo.FunctionWrapper<efl_input_scrolling_set_api_delegate> efl_input_scrolling_set_ptr = new Efl.Eo.FunctionWrapper<efl_input_scrolling_set_api_delegate>(_Module, "efl_input_scrolling_set");
     private static void scrolling_set(System.IntPtr obj, System.IntPtr pd,  bool val)
    {
        Eina.Log.Debug("function efl_input_scrolling_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Key)wrapper).SetScrolling( val);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Key)wrapper).GetFake();
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


     private delegate void efl_input_reset_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_input_reset_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_input_reset_api_delegate> efl_input_reset_ptr = new Efl.Eo.FunctionWrapper<efl_input_reset_api_delegate>(_Module, "efl_input_reset");
     private static void reset(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_input_reset was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Key)wrapper).Reset();
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Key)wrapper).GetModifierEnabled( mod,  seat);
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
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Key)wrapper).GetLockEnabled( kw_lock,  seat);
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
