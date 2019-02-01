#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Input { 
/// <summary>Represents a single key event from a keyboard or similar device.
/// 1.18</summary>
[KeyNativeInherit]
public class Key : Efl.Object, Efl.Eo.IWrapper,Efl.Duplicate,Efl.Input.Event,Efl.Input.State
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Input.KeyNativeInherit nativeInherit = new Efl.Input.KeyNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Key))
            return Efl.Input.KeyNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Key obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_input_key_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Key(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Key", efl_input_key_class_get(), typeof(Key), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Key(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Key(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Key static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Key(obj.NativeHandle);
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
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_input_key_pressed_get(System.IntPtr obj);
   /// <summary><c>true</c> if the key is down, <c>false</c> if it is released.
   /// 1.18</summary>
   /// <returns><c>true</c> if the key is pressed, <c>false</c> otherwise
   /// 1.18</returns>
   virtual public bool GetPressed() {
       var _ret_var = efl_input_key_pressed_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_key_pressed_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
   /// <summary><c>true</c> if the key is down, <c>false</c> if it is released.
   /// 1.18</summary>
   /// <param name="val"><c>true</c> if the key is pressed, <c>false</c> otherwise
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetPressed( bool val) {
                         efl_input_key_pressed_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_input_key_name_get(System.IntPtr obj);
   /// <summary>Name string of the key.
   /// 1.18</summary>
   /// <returns>Key name
   /// 1.18</returns>
   virtual public  System.String GetKeyName() {
       var _ret_var = efl_input_key_name_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_key_name_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String val);
   /// <summary>Name string of the key.
   /// 1.18</summary>
   /// <param name="val">Key name
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetKeyName(  System.String val) {
                         efl_input_key_name_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_input_key_get(System.IntPtr obj);
   /// <summary>Logical key.
   /// Eg. Shift + 1 = exclamation
   /// 1.18</summary>
   /// <returns>Logical key name
   /// 1.18</returns>
   virtual public  System.String GetKey() {
       var _ret_var = efl_input_key_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_key_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String val);
   /// <summary>Logical key.
   /// Eg. Shift + 1 = exclamation
   /// 1.18</summary>
   /// <param name="val">Logical key name
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetKey(  System.String val) {
                         efl_input_key_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_input_key_string_get(System.IntPtr obj);
   /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.
   /// 1.18</summary>
   /// <returns>Visible string from key press in UTF8
   /// 1.18</returns>
   virtual public  System.String GetString() {
       var _ret_var = efl_input_key_string_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_key_string_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String val);
   /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.
   /// 1.18</summary>
   /// <param name="val">Visible string from key press in UTF8
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetString(  System.String val) {
                         efl_input_key_string_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_input_key_compose_get(System.IntPtr obj);
   /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
   /// Note: This string replaces the previous one
   /// 1.18</summary>
   /// <returns>Composed key string in UTF8
   /// 1.18</returns>
   virtual public  System.String GetCompose() {
       var _ret_var = efl_input_key_compose_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_key_compose_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String val);
   /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
   /// Note: This string replaces the previous one
   /// 1.18</summary>
   /// <param name="val">Composed key string in UTF8
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetCompose(  System.String val) {
                         efl_input_key_compose_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  int efl_input_key_code_get(System.IntPtr obj);
   /// <summary>Key scan code numeric value.
   /// 1.18</summary>
   /// <returns>Key scan code
   /// 1.18</returns>
   virtual public  int GetKeyCode() {
       var _ret_var = efl_input_key_code_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_key_code_set(System.IntPtr obj,    int val);
   /// <summary>Key scan code numeric value.
   /// 1.18</summary>
   /// <param name="val">Key scan code
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetKeyCode(  int val) {
                         efl_input_key_code_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  val);
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
   /// <summary><c>true</c> if the key is down, <c>false</c> if it is released.
/// 1.18</summary>
   public bool Pressed {
      get { return GetPressed(); }
      set { SetPressed( value); }
   }
   /// <summary>Name string of the key.
/// 1.18</summary>
   public  System.String KeyName {
      get { return GetKeyName(); }
      set { SetKeyName( value); }
   }
   /// <summary>A UTF8 string if this keystroke has produced a visible string to be added.
/// 1.18</summary>
   public  System.String String {
      get { return GetString(); }
      set { SetString( value); }
   }
   /// <summary>A UTF8 string if this keystroke has modified a string in the middle of being composed.
/// Note: This string replaces the previous one
/// 1.18</summary>
   public  System.String Compose {
      get { return GetCompose(); }
      set { SetCompose( value); }
   }
   /// <summary>Key scan code numeric value.
/// 1.18</summary>
   public  int KeyCode {
      get { return GetKeyCode(); }
      set { SetKeyCode( value); }
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
public class KeyNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_input_key_pressed_get_static_delegate = new efl_input_key_pressed_get_delegate(pressed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_key_pressed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_pressed_get_static_delegate)});
      efl_input_key_pressed_set_static_delegate = new efl_input_key_pressed_set_delegate(pressed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_key_pressed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_pressed_set_static_delegate)});
      efl_input_key_name_get_static_delegate = new efl_input_key_name_get_delegate(key_name_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_key_name_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_name_get_static_delegate)});
      efl_input_key_name_set_static_delegate = new efl_input_key_name_set_delegate(key_name_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_key_name_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_name_set_static_delegate)});
      efl_input_key_get_static_delegate = new efl_input_key_get_delegate(key_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_key_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_get_static_delegate)});
      efl_input_key_set_static_delegate = new efl_input_key_set_delegate(key_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_key_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_set_static_delegate)});
      efl_input_key_string_get_static_delegate = new efl_input_key_string_get_delegate(string_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_key_string_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_string_get_static_delegate)});
      efl_input_key_string_set_static_delegate = new efl_input_key_string_set_delegate(string_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_key_string_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_string_set_static_delegate)});
      efl_input_key_compose_get_static_delegate = new efl_input_key_compose_get_delegate(compose_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_key_compose_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_compose_get_static_delegate)});
      efl_input_key_compose_set_static_delegate = new efl_input_key_compose_set_delegate(compose_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_key_compose_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_compose_set_static_delegate)});
      efl_input_key_code_get_static_delegate = new efl_input_key_code_get_delegate(key_code_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_key_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_code_get_static_delegate)});
      efl_input_key_code_set_static_delegate = new efl_input_key_code_set_delegate(key_code_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_key_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_key_code_set_static_delegate)});
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
      return Efl.Input.Key.efl_input_key_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Input.Key.efl_input_key_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_key_pressed_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_key_pressed_get(System.IntPtr obj);
    private static bool pressed_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_key_pressed_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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
         return efl_input_key_pressed_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_key_pressed_get_delegate efl_input_key_pressed_get_static_delegate;


    private delegate  void efl_input_key_pressed_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_key_pressed_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    private static  void pressed_set(System.IntPtr obj, System.IntPtr pd,  bool val)
   {
      Eina.Log.Debug("function efl_input_key_pressed_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Key)wrapper).SetPressed( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_key_pressed_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private efl_input_key_pressed_set_delegate efl_input_key_pressed_set_static_delegate;


    private delegate  System.IntPtr efl_input_key_name_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  System.IntPtr efl_input_key_name_get(System.IntPtr obj);
    private static  System.IntPtr key_name_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_key_name_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Key)wrapper).GetKeyName();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Key)wrapper).cached_strings, _ret_var);
      } else {
         return efl_input_key_name_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_key_name_get_delegate efl_input_key_name_get_static_delegate;


    private delegate  void efl_input_key_name_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_key_name_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String val);
    private static  void key_name_set(System.IntPtr obj, System.IntPtr pd,   System.String val)
   {
      Eina.Log.Debug("function efl_input_key_name_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Key)wrapper).SetKeyName( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_key_name_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private efl_input_key_name_set_delegate efl_input_key_name_set_static_delegate;


    private delegate  System.IntPtr efl_input_key_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  System.IntPtr efl_input_key_get(System.IntPtr obj);
    private static  System.IntPtr key_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_key_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Key)wrapper).GetKey();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Key)wrapper).cached_strings, _ret_var);
      } else {
         return efl_input_key_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_key_get_delegate efl_input_key_get_static_delegate;


    private delegate  void efl_input_key_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_key_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String val);
    private static  void key_set(System.IntPtr obj, System.IntPtr pd,   System.String val)
   {
      Eina.Log.Debug("function efl_input_key_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Key)wrapper).SetKey( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_key_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private efl_input_key_set_delegate efl_input_key_set_static_delegate;


    private delegate  System.IntPtr efl_input_key_string_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  System.IntPtr efl_input_key_string_get(System.IntPtr obj);
    private static  System.IntPtr string_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_key_string_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Key)wrapper).GetString();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Key)wrapper).cached_strings, _ret_var);
      } else {
         return efl_input_key_string_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_key_string_get_delegate efl_input_key_string_get_static_delegate;


    private delegate  void efl_input_key_string_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_key_string_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String val);
    private static  void string_set(System.IntPtr obj, System.IntPtr pd,   System.String val)
   {
      Eina.Log.Debug("function efl_input_key_string_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Key)wrapper).SetString( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_key_string_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private efl_input_key_string_set_delegate efl_input_key_string_set_static_delegate;


    private delegate  System.IntPtr efl_input_key_compose_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  System.IntPtr efl_input_key_compose_get(System.IntPtr obj);
    private static  System.IntPtr compose_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_key_compose_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Key)wrapper).GetCompose();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Key)wrapper).cached_strings, _ret_var);
      } else {
         return efl_input_key_compose_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_key_compose_get_delegate efl_input_key_compose_get_static_delegate;


    private delegate  void efl_input_key_compose_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_key_compose_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String val);
    private static  void compose_set(System.IntPtr obj, System.IntPtr pd,   System.String val)
   {
      Eina.Log.Debug("function efl_input_key_compose_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Key)wrapper).SetCompose( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_key_compose_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private efl_input_key_compose_set_delegate efl_input_key_compose_set_static_delegate;


    private delegate  int efl_input_key_code_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  int efl_input_key_code_get(System.IntPtr obj);
    private static  int key_code_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_key_code_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Key)wrapper).GetKeyCode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_key_code_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_key_code_get_delegate efl_input_key_code_get_static_delegate;


    private delegate  void efl_input_key_code_set_delegate(System.IntPtr obj, System.IntPtr pd,    int val);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_key_code_set(System.IntPtr obj,    int val);
    private static  void key_code_set(System.IntPtr obj, System.IntPtr pd,   int val)
   {
      Eina.Log.Debug("function efl_input_key_code_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Key)wrapper).SetKeyCode( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_key_code_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private efl_input_key_code_set_delegate efl_input_key_code_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.DuplicateConcrete, Efl.Eo.OwnTag>))] private delegate Efl.Duplicate efl_duplicate_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.DuplicateConcrete, Efl.Eo.OwnTag>))] private static extern Efl.Duplicate efl_duplicate(System.IntPtr obj);
    private static Efl.Duplicate duplicate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_duplicate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Duplicate _ret_var = default(Efl.Duplicate);
         try {
            _ret_var = ((Key)wrapper).DoDuplicate();
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
            _ret_var = ((Key)wrapper).GetTimestamp();
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
            ((Key)wrapper).SetTimestamp( ms);
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
            _ret_var = ((Key)wrapper).GetDevice();
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
            ((Key)wrapper).SetDevice( dev);
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
            _ret_var = ((Key)wrapper).GetEventFlags();
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
            ((Key)wrapper).SetEventFlags( flags);
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
            _ret_var = ((Key)wrapper).GetProcessed();
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
            ((Key)wrapper).SetProcessed( val);
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
            _ret_var = ((Key)wrapper).GetScrolling();
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
            ((Key)wrapper).SetScrolling( val);
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
            _ret_var = ((Key)wrapper).GetFake();
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
            ((Key)wrapper).Reset();
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
            _ret_var = ((Key)wrapper).GetModifierEnabled( mod,  seat);
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
            _ret_var = ((Key)wrapper).GetLockEnabled( kw_lock,  seat);
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
