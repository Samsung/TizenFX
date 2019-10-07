#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

namespace Input {

/// <summary>Represents a pointing device such as a touch finger, pen or mouse.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Input.Device.NativeMethods]
[UIKit.Wrapper.BindingEntity]
public class Device : UIKit.Object
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Device))
            {
                return GetUIKitClassStatic();
            }
            else
            {
                return UIKit.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_input_device_class_get();

    /// <summary>Initializes a new instance of the <see cref="Device"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <since_tizen> 6 </since_tizen>
    public Device(UIKit.Object parent= null
            ) : base(efl_input_device_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    /// <since_tizen> 6 </since_tizen>
    protected Device(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Device"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    /// <since_tizen> 6 </since_tizen>
    protected Device(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Device"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The UIKit.Object parent of this instance.</param>
    protected Device(IntPtr baseKlass, UIKit.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>Device type property</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Input device class</returns>
    public virtual UIKit.Input.DeviceType GetDeviceType() {
        var _ret_var = UIKit.Input.Device.NativeMethods.efl_input_device_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Device type property</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="klass">Input device class</param>
    public virtual void SetDeviceType(UIKit.Input.DeviceType klass) {
        UIKit.Input.Device.NativeMethods.efl_input_device_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),klass);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Device source property</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Input device</returns>
    public virtual UIKit.Input.Device GetSource() {
        var _ret_var = UIKit.Input.Device.NativeMethods.efl_input_device_source_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Device source property</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="src">Input device</param>
    public virtual void SetSource(UIKit.Input.Device src) {
        UIKit.Input.Device.NativeMethods.efl_input_device_source_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),src);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Get the <see cref="UIKit.Input.Device"/> that represents a seat.
    /// This method will find the seat the device belongs to.
    /// 
    /// For this, it walk through device&apos;s parents looking for a device with <see cref="UIKit.Input.DeviceType.Seat"/>. It may be the device itself.
    /// 
    /// In case no seat is found, <c>null</c> is returned.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The seat this device belongs to.</returns>
    public virtual UIKit.Input.Device GetSeat() {
        var _ret_var = UIKit.Input.Device.NativeMethods.efl_input_device_seat_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Seat id number</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The id of the seat</returns>
    public virtual uint GetSeatId() {
        var _ret_var = UIKit.Input.Device.NativeMethods.efl_input_device_seat_id_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Seat id number</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="id">The id of the seat</param>
    public virtual void SetSeatId(uint id) {
        UIKit.Input.Device.NativeMethods.efl_input_device_seat_id_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),id);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The number of pointer devices in this seat.
    /// Pointer devices are the ones whose <see cref="UIKit.Input.Device.DeviceType"/> is <c>mouse</c>, <c>pen</c>, <c>touch</c> or <c>wand</c>. In case this device is not of the type <c>seat</c>, -1 is returned.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The number of pointer devices.</returns>
    public virtual int GetPointerDeviceCount() {
        var _ret_var = UIKit.Input.Device.NativeMethods.efl_input_device_pointer_device_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.Device.DeviceType"/> is <c>mouse</c>, <c>pen</c>, <c>touch</c> or <c>wand</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the device has pointing capabilities.</returns>
    public virtual bool GetIsPointerType() {
        var _ret_var = UIKit.Input.Device.NativeMethods.efl_input_device_is_pointer_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Lists the children attached to this device.
    /// This is only meaningful with seat devices, as they are groups of real input devices.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>List of device children</returns>
    public virtual UIKit.DataTypes.Iterator<UIKit.Input.Device> IterateChildren() {
        var _ret_var = UIKit.Input.Device.NativeMethods.efl_input_device_children_iterate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return new UIKit.DataTypes.Iterator<UIKit.Input.Device>(_ret_var, true);

    }

    /// <summary>Device type property</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Input device class</value>
    public UIKit.Input.DeviceType DeviceType {
        get { return GetDeviceType(); }
        set { SetDeviceType(value); }
    }

    /// <summary>Device source property</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>Input device</value>
    public UIKit.Input.Device Source {
        get { return GetSource(); }
        set { SetSource(value); }
    }

    /// <summary>Get the <see cref="UIKit.Input.Device"/> that represents a seat.
    /// This method will find the seat the device belongs to.
    /// 
    /// For this, it walk through device&apos;s parents looking for a device with <see cref="UIKit.Input.DeviceType.Seat"/>. It may be the device itself.
    /// 
    /// In case no seat is found, <c>null</c> is returned.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The seat this device belongs to.</value>
    public UIKit.Input.Device Seat {
        get { return GetSeat(); }
    }

    /// <summary>Seat id number</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The id of the seat</value>
    public uint SeatId {
        get { return GetSeatId(); }
        set { SetSeatId(value); }
    }

    /// <summary>The number of pointer devices in this seat.
    /// Pointer devices are the ones whose <see cref="UIKit.Input.Device.DeviceType"/> is <c>mouse</c>, <c>pen</c>, <c>touch</c> or <c>wand</c>. In case this device is not of the type <c>seat</c>, -1 is returned.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The number of pointer devices.</value>
    public int PointerDeviceCount {
        get { return GetPointerDeviceCount(); }
    }

    /// <summary><c>true</c> if <see cref="UIKit.Input.Device.DeviceType"/> is <c>mouse</c>, <c>pen</c>, <c>touch</c> or <c>wand</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if the device has pointing capabilities.</value>
    public bool IsPointerType {
        get { return GetIsPointerType(); }
    }

    private static IntPtr GetUIKitClassStatic()
    {
        return UIKit.Input.Device.efl_input_device_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : UIKit.Object.NativeMethods
    {
        private static UIKit.Wrapper.NativeModule Module = new UIKit.Wrapper.NativeModule(UIKit.Libs.UIKit);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<UIKit_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<UIKit_Op_Description>();
            var methods = UIKit.Wrapper.Globals.GetUserMethods(type);

            if (efl_input_device_type_get_static_delegate == null)
            {
                efl_input_device_type_get_static_delegate = new efl_input_device_type_get_delegate(device_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDeviceType") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_type_get_static_delegate) });
            }

            if (efl_input_device_type_set_static_delegate == null)
            {
                efl_input_device_type_set_static_delegate = new efl_input_device_type_set_delegate(device_type_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDeviceType") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_type_set_static_delegate) });
            }

            if (efl_input_device_source_get_static_delegate == null)
            {
                efl_input_device_source_get_static_delegate = new efl_input_device_source_get_delegate(source_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSource") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_source_get_static_delegate) });
            }

            if (efl_input_device_source_set_static_delegate == null)
            {
                efl_input_device_source_set_static_delegate = new efl_input_device_source_set_delegate(source_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSource") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_source_set_static_delegate) });
            }

            if (efl_input_device_seat_get_static_delegate == null)
            {
                efl_input_device_seat_get_static_delegate = new efl_input_device_seat_get_delegate(seat_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSeat") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_seat_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_seat_get_static_delegate) });
            }

            if (efl_input_device_seat_id_get_static_delegate == null)
            {
                efl_input_device_seat_id_get_static_delegate = new efl_input_device_seat_id_get_delegate(seat_id_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSeatId") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_seat_id_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_seat_id_get_static_delegate) });
            }

            if (efl_input_device_seat_id_set_static_delegate == null)
            {
                efl_input_device_seat_id_set_static_delegate = new efl_input_device_seat_id_set_delegate(seat_id_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSeatId") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_seat_id_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_seat_id_set_static_delegate) });
            }

            if (efl_input_device_pointer_device_count_get_static_delegate == null)
            {
                efl_input_device_pointer_device_count_get_static_delegate = new efl_input_device_pointer_device_count_get_delegate(pointer_device_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPointerDeviceCount") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_pointer_device_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_pointer_device_count_get_static_delegate) });
            }

            if (efl_input_device_is_pointer_type_get_static_delegate == null)
            {
                efl_input_device_is_pointer_type_get_static_delegate = new efl_input_device_is_pointer_type_get_delegate(is_pointer_type_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetIsPointerType") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_is_pointer_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_is_pointer_type_get_static_delegate) });
            }

            if (efl_input_device_children_iterate_static_delegate == null)
            {
                efl_input_device_children_iterate_static_delegate = new efl_input_device_children_iterate_delegate(children_iterate);
            }

            if (methods.FirstOrDefault(m => m.Name == "IterateChildren") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_children_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_children_iterate_static_delegate) });
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
            return UIKit.Input.Device.efl_input_device_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate UIKit.Input.DeviceType efl_input_device_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.Input.DeviceType efl_input_device_type_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_device_type_get_api_delegate> efl_input_device_type_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_device_type_get_api_delegate>(Module, "efl_input_device_type_get");

        private static UIKit.Input.DeviceType device_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_device_type_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Input.DeviceType _ret_var = default(UIKit.Input.DeviceType);
                try
                {
                    _ret_var = ((Device)ws.Target).GetDeviceType();
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
                return efl_input_device_type_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_device_type_get_delegate efl_input_device_type_get_static_delegate;

        
        private delegate void efl_input_device_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.Input.DeviceType klass);

        
        public delegate void efl_input_device_type_set_api_delegate(System.IntPtr obj,  UIKit.Input.DeviceType klass);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_device_type_set_api_delegate> efl_input_device_type_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_device_type_set_api_delegate>(Module, "efl_input_device_type_set");

        private static void device_type_set(System.IntPtr obj, System.IntPtr pd, UIKit.Input.DeviceType klass)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_device_type_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Device)ws.Target).SetDeviceType(klass);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_device_type_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), klass);
            }
        }

        private static efl_input_device_type_set_delegate efl_input_device_type_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        private delegate UIKit.Input.Device efl_input_device_source_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        public delegate UIKit.Input.Device efl_input_device_source_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_device_source_get_api_delegate> efl_input_device_source_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_device_source_get_api_delegate>(Module, "efl_input_device_source_get");

        private static UIKit.Input.Device source_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_device_source_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Input.Device _ret_var = default(UIKit.Input.Device);
                try
                {
                    _ret_var = ((Device)ws.Target).GetSource();
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
                return efl_input_device_source_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_device_source_get_delegate efl_input_device_source_get_static_delegate;

        
        private delegate void efl_input_device_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Input.Device src);

        
        public delegate void efl_input_device_source_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))] UIKit.Input.Device src);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_device_source_set_api_delegate> efl_input_device_source_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_device_source_set_api_delegate>(Module, "efl_input_device_source_set");

        private static void source_set(System.IntPtr obj, System.IntPtr pd, UIKit.Input.Device src)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_device_source_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Device)ws.Target).SetSource(src);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_device_source_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), src);
            }
        }

        private static efl_input_device_source_set_delegate efl_input_device_source_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        private delegate UIKit.Input.Device efl_input_device_seat_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        public delegate UIKit.Input.Device efl_input_device_seat_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_device_seat_get_api_delegate> efl_input_device_seat_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_device_seat_get_api_delegate>(Module, "efl_input_device_seat_get");

        private static UIKit.Input.Device seat_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_device_seat_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Input.Device _ret_var = default(UIKit.Input.Device);
                try
                {
                    _ret_var = ((Device)ws.Target).GetSeat();
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
                return efl_input_device_seat_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_device_seat_get_delegate efl_input_device_seat_get_static_delegate;

        
        private delegate uint efl_input_device_seat_id_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate uint efl_input_device_seat_id_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_device_seat_id_get_api_delegate> efl_input_device_seat_id_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_device_seat_id_get_api_delegate>(Module, "efl_input_device_seat_id_get");

        private static uint seat_id_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_device_seat_id_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                uint _ret_var = default(uint);
                try
                {
                    _ret_var = ((Device)ws.Target).GetSeatId();
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
                return efl_input_device_seat_id_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_device_seat_id_get_delegate efl_input_device_seat_id_get_static_delegate;

        
        private delegate void efl_input_device_seat_id_set_delegate(System.IntPtr obj, System.IntPtr pd,  uint id);

        
        public delegate void efl_input_device_seat_id_set_api_delegate(System.IntPtr obj,  uint id);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_device_seat_id_set_api_delegate> efl_input_device_seat_id_set_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_device_seat_id_set_api_delegate>(Module, "efl_input_device_seat_id_set");

        private static void seat_id_set(System.IntPtr obj, System.IntPtr pd, uint id)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_device_seat_id_set was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Device)ws.Target).SetSeatId(id);
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_input_device_seat_id_set_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), id);
            }
        }

        private static efl_input_device_seat_id_set_delegate efl_input_device_seat_id_set_static_delegate;

        
        private delegate int efl_input_device_pointer_device_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_input_device_pointer_device_count_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_device_pointer_device_count_get_api_delegate> efl_input_device_pointer_device_count_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_device_pointer_device_count_get_api_delegate>(Module, "efl_input_device_pointer_device_count_get");

        private static int pointer_device_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_device_pointer_device_count_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((Device)ws.Target).GetPointerDeviceCount();
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
                return efl_input_device_pointer_device_count_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_device_pointer_device_count_get_delegate efl_input_device_pointer_device_count_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_device_is_pointer_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_input_device_is_pointer_type_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_device_is_pointer_type_get_api_delegate> efl_input_device_is_pointer_type_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_device_is_pointer_type_get_api_delegate>(Module, "efl_input_device_is_pointer_type_get");

        private static bool is_pointer_type_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_device_is_pointer_type_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Device)ws.Target).GetIsPointerType();
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
                return efl_input_device_is_pointer_type_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_device_is_pointer_type_get_delegate efl_input_device_is_pointer_type_get_static_delegate;

        
        private delegate System.IntPtr efl_input_device_children_iterate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_input_device_children_iterate_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_input_device_children_iterate_api_delegate> efl_input_device_children_iterate_ptr = new UIKit.Wrapper.FunctionWrapper<efl_input_device_children_iterate_api_delegate>(Module, "efl_input_device_children_iterate");

        private static System.IntPtr children_iterate(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_input_device_children_iterate was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Iterator<UIKit.Input.Device> _ret_var = default(UIKit.DataTypes.Iterator<UIKit.Input.Device>);
                try
                {
                    _ret_var = ((Device)ws.Target).IterateChildren();
                }
                catch (Exception e)
                {
                    UIKit.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    UIKit.DataTypes.Error.Set(UIKit.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                _ret_var.Own = false; return _ret_var.Handle;
            }
            else
            {
                return efl_input_device_children_iterate_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_input_device_children_iterate_delegate efl_input_device_children_iterate_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class UIKit_InputDevice_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
namespace UIKit {

namespace Input {

/// <summary>General type of input device.
/// Legacy support since 1.8 as <c>Evas_Device_Class</c>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.Wrapper.BindingEntity]
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
}
}

namespace UIKit {

namespace Input {

/// <summary>General type of input device.
/// Legacy support since 1.8 as <c>Evas_Device_Subclass</c>.</summary>
[UIKit.Wrapper.BindingEntity]
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
}
}

