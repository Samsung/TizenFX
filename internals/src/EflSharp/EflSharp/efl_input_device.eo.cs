#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Input { 
/// <summary>Represents a pointing device such as a touch finger, pen or mouse.
/// 1.18</summary>
[DeviceNativeInherit]
public class Device : Efl.Object, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Input.DeviceNativeInherit nativeInherit = new Efl.Input.DeviceNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Device))
            return Efl.Input.DeviceNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Device obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_input_device_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Device(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Device", efl_input_device_class_get(), typeof(Device), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Device(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Device(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Device static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Device(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Efl.Input.DeviceType efl_input_device_type_get(System.IntPtr obj);
   /// <summary>Device type property
   /// 1.18</summary>
   /// <returns>Input device class
   /// 1.18</returns>
   virtual public Efl.Input.DeviceType GetDeviceType() {
       var _ret_var = efl_input_device_type_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_input_device_type_set(System.IntPtr obj,   Efl.Input.DeviceType klass);
   /// <summary>Device type property
   /// 1.18</summary>
   /// <param name="klass">Input device class
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetDeviceType( Efl.Input.DeviceType klass) {
                         efl_input_device_type_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  klass);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] protected static extern Efl.Input.Device efl_input_device_source_get(System.IntPtr obj);
   /// <summary>Device source property
   /// 1.18</summary>
   /// <returns>Input device
   /// 1.18</returns>
   virtual public Efl.Input.Device GetSource() {
       var _ret_var = efl_input_device_source_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_input_device_source_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device src);
   /// <summary>Device source property
   /// 1.18</summary>
   /// <param name="src">Input device
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetSource( Efl.Input.Device src) {
                         efl_input_device_source_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  src);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] protected static extern Efl.Input.Device efl_input_device_seat_get(System.IntPtr obj);
   /// <summary>Get the <see cref="Efl.Input.Device"/> that represents a seat.
   /// This method will find the seat the device belongs to.
   /// 
   /// For this, it walk through device&apos;s parents looking for a device with <see cref="Efl.Input.DeviceType.Seat"/>. It may be the device itself.
   /// 
   /// In case no seat is found, <c>null</c> is returned.
   /// 1.18</summary>
   /// <returns>The seat this device belongs to.
   /// 1.18</returns>
   virtual public Efl.Input.Device GetSeat() {
       var _ret_var = efl_input_device_seat_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  uint efl_input_device_seat_id_get(System.IntPtr obj);
   /// <summary>Seat id number
   /// 1.20</summary>
   /// <returns>The id of the seat
   /// 1.18</returns>
   virtual public  uint GetSeatId() {
       var _ret_var = efl_input_device_seat_id_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_input_device_seat_id_set(System.IntPtr obj,    uint id);
   /// <summary>Seat id number
   /// 1.20</summary>
   /// <param name="id">The id of the seat
   /// 1.18</param>
   /// <returns></returns>
   virtual public  void SetSeatId(  uint id) {
                         efl_input_device_seat_id_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  id);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  System.IntPtr efl_input_device_children_iterate(System.IntPtr obj);
   /// <summary>Lists the children attached to this device.
   /// This is only meaningful with seat devices, as they are groups of real input devices.
   /// 1.20</summary>
   /// <returns>List of device children
   /// 1.18</returns>
   virtual public Eina.Iterator<Efl.Input.Device> ChildrenIterate() {
       var _ret_var = efl_input_device_children_iterate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Input.Device>(_ret_var, true, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  uint efl_input_device_has_pointer_caps(System.IntPtr obj);
   /// <summary>Determine whether a device has pointer capabilities.
   /// Returns 1 for Mouse, Touch, Pen, Pointer, and Wand type devices.
   /// 
   /// If a seat device is passed returns the number of pointer devices in the seat.
   /// 1.20</summary>
   /// <returns>Pointer caps
   /// 1.18</returns>
   virtual public  uint HasPointerCaps() {
       var _ret_var = efl_input_device_has_pointer_caps((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Device type property
/// 1.18</summary>
   public Efl.Input.DeviceType DeviceType {
      get { return GetDeviceType(); }
      set { SetDeviceType( value); }
   }
   /// <summary>Device source property
/// 1.18</summary>
   public Efl.Input.Device Source {
      get { return GetSource(); }
      set { SetSource( value); }
   }
   /// <summary>Get the <see cref="Efl.Input.Device"/> that represents a seat.
/// This method will find the seat the device belongs to.
/// 
/// For this, it walk through device&apos;s parents looking for a device with <see cref="Efl.Input.DeviceType.Seat"/>. It may be the device itself.
/// 
/// In case no seat is found, <c>null</c> is returned.
/// 1.18</summary>
   public Efl.Input.Device Seat {
      get { return GetSeat(); }
   }
   /// <summary>Seat id number
/// 1.20</summary>
   public  uint SeatId {
      get { return GetSeatId(); }
      set { SetSeatId( value); }
   }
}
public class DeviceNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_input_device_type_get_static_delegate = new efl_input_device_type_get_delegate(device_type_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_device_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_type_get_static_delegate)});
      efl_input_device_type_set_static_delegate = new efl_input_device_type_set_delegate(device_type_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_device_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_type_set_static_delegate)});
      efl_input_device_source_get_static_delegate = new efl_input_device_source_get_delegate(source_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_device_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_source_get_static_delegate)});
      efl_input_device_source_set_static_delegate = new efl_input_device_source_set_delegate(source_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_device_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_source_set_static_delegate)});
      efl_input_device_seat_get_static_delegate = new efl_input_device_seat_get_delegate(seat_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_device_seat_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_seat_get_static_delegate)});
      efl_input_device_seat_id_get_static_delegate = new efl_input_device_seat_id_get_delegate(seat_id_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_device_seat_id_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_seat_id_get_static_delegate)});
      efl_input_device_seat_id_set_static_delegate = new efl_input_device_seat_id_set_delegate(seat_id_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_device_seat_id_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_seat_id_set_static_delegate)});
      efl_input_device_children_iterate_static_delegate = new efl_input_device_children_iterate_delegate(children_iterate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_device_children_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_children_iterate_static_delegate)});
      efl_input_device_has_pointer_caps_static_delegate = new efl_input_device_has_pointer_caps_delegate(has_pointer_caps);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_device_has_pointer_caps"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_has_pointer_caps_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Input.Device.efl_input_device_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Input.Device.efl_input_device_class_get();
   }


    private delegate Efl.Input.DeviceType efl_input_device_type_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Efl.Input.DeviceType efl_input_device_type_get(System.IntPtr obj);
    private static Efl.Input.DeviceType device_type_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_device_type_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Input.DeviceType _ret_var = default(Efl.Input.DeviceType);
         try {
            _ret_var = ((Device)wrapper).GetDeviceType();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_device_type_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_device_type_get_delegate efl_input_device_type_get_static_delegate;


    private delegate  void efl_input_device_type_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.DeviceType klass);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_input_device_type_set(System.IntPtr obj,   Efl.Input.DeviceType klass);
    private static  void device_type_set(System.IntPtr obj, System.IntPtr pd,  Efl.Input.DeviceType klass)
   {
      Eina.Log.Debug("function efl_input_device_type_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Device)wrapper).SetDeviceType( klass);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_device_type_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  klass);
      }
   }
   private efl_input_device_type_set_delegate efl_input_device_type_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private delegate Efl.Input.Device efl_input_device_source_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private static extern Efl.Input.Device efl_input_device_source_get(System.IntPtr obj);
    private static Efl.Input.Device source_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_device_source_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Input.Device _ret_var = default(Efl.Input.Device);
         try {
            _ret_var = ((Device)wrapper).GetSource();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_device_source_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_device_source_get_delegate efl_input_device_source_get_static_delegate;


    private delegate  void efl_input_device_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device src);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_input_device_source_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device src);
    private static  void source_set(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device src)
   {
      Eina.Log.Debug("function efl_input_device_source_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Device)wrapper).SetSource( src);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_device_source_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  src);
      }
   }
   private efl_input_device_source_set_delegate efl_input_device_source_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private delegate Efl.Input.Device efl_input_device_seat_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))] private static extern Efl.Input.Device efl_input_device_seat_get(System.IntPtr obj);
    private static Efl.Input.Device seat_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_device_seat_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Input.Device _ret_var = default(Efl.Input.Device);
         try {
            _ret_var = ((Device)wrapper).GetSeat();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_device_seat_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_device_seat_get_delegate efl_input_device_seat_get_static_delegate;


    private delegate  uint efl_input_device_seat_id_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  uint efl_input_device_seat_id_get(System.IntPtr obj);
    private static  uint seat_id_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_device_seat_id_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
         try {
            _ret_var = ((Device)wrapper).GetSeatId();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_device_seat_id_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_device_seat_id_get_delegate efl_input_device_seat_id_get_static_delegate;


    private delegate  void efl_input_device_seat_id_set_delegate(System.IntPtr obj, System.IntPtr pd,    uint id);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_input_device_seat_id_set(System.IntPtr obj,    uint id);
    private static  void seat_id_set(System.IntPtr obj, System.IntPtr pd,   uint id)
   {
      Eina.Log.Debug("function efl_input_device_seat_id_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Device)wrapper).SetSeatId( id);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_input_device_seat_id_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  id);
      }
   }
   private efl_input_device_seat_id_set_delegate efl_input_device_seat_id_set_static_delegate;


    private delegate  System.IntPtr efl_input_device_children_iterate_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_input_device_children_iterate(System.IntPtr obj);
    private static  System.IntPtr children_iterate(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_device_children_iterate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Input.Device> _ret_var = default(Eina.Iterator<Efl.Input.Device>);
         try {
            _ret_var = ((Device)wrapper).ChildrenIterate();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      _ret_var.Own = false; return _ret_var.Handle;
      } else {
         return efl_input_device_children_iterate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_device_children_iterate_delegate efl_input_device_children_iterate_static_delegate;


    private delegate  uint efl_input_device_has_pointer_caps_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  uint efl_input_device_has_pointer_caps(System.IntPtr obj);
    private static  uint has_pointer_caps(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_input_device_has_pointer_caps was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   uint _ret_var = default( uint);
         try {
            _ret_var = ((Device)wrapper).HasPointerCaps();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_input_device_has_pointer_caps(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_input_device_has_pointer_caps_delegate efl_input_device_has_pointer_caps_static_delegate;
}
} } 
namespace Efl { namespace Input { 
/// <summary>General type of input device.
/// Legacy support since 1.8 as <c>Evas_Device_Class</c>.</summary>
public enum DeviceType
{
/// <summary>Not a device.</summary>
None = 0,
/// <summary>The user/seat (the user themselves).</summary>
Seat = 1,
/// <summary>A regular keyboard, numberpad or attached buttons.</summary>
Keyboard = 2,
/// <summary>A mouse, trackball or touchpad relative motion device.</summary>
Mouse = 3,
/// <summary>A touchscreen with fingers or stylus.</summary>
Touch = 4,
/// <summary>A special pen device.</summary>
Pen = 5,
/// <summary>A laser pointer, wii-style or &quot;Minority Report&quot; pointing device.</summary>
Wand = 6,
/// <summary>A gamepad controller or joystick.</summary>
Gamepad = 7,
}
} } 
namespace Efl { namespace Input { 
/// <summary>General type of input device.
/// Legacy support since 1.8 as <c>Evas_Device_Subclass</c>.</summary>
public enum DeviceSubtype
{
/// <summary>Not a device.</summary>
None = 0,
/// <summary>The normal flat of your finger.</summary>
Finger = 1,
/// <summary>A fingernai.</summary>
Fingernail = 2,
/// <summary>A Knuckle.</summary>
Knuckle = 3,
/// <summary>The palm of a users hand.</summary>
Palm = 4,
/// <summary>The side of your hand.</summary>
HandSize = 5,
/// <summary>The flat of your hand.</summary>
HandFlat = 6,
/// <summary>The tip of a pen.</summary>
PenTip = 7,
/// <summary>A trackpad style mouse.</summary>
Trackpad = 8,
/// <summary>A trackpoint style mouse.</summary>
Trackpoint = 9,
/// <summary>A trackball style mouse.</summary>
Trackball = 10,
/// <summary>A remote controller.</summary>
Remocon = 11,
/// <summary>A virtual keyboard.</summary>
VirtualKeyboard = 12,
}
} } 
