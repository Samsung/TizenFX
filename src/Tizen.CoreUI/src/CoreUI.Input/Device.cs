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
    /// <summary>Represents a pointing device such as a touch finger, pen or mouse.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Input.Device.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Device : CoreUI.Object
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Device))
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
            efl_input_device_class_get();

        /// <summary>Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public Device(CoreUI.Object parent= null) : base(efl_input_device_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Device(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Device"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Device(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Device"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Device(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Device type property</summary>
        /// <returns>Input device class</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Input.DeviceType GetDeviceType() {
            var _ret_var = CoreUI.Input.Device.NativeMethods.efl_input_device_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Device type property</summary>
        /// <param name="klass">Input device class</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetDeviceType(CoreUI.Input.DeviceType klass) {
            CoreUI.Input.Device.NativeMethods.efl_input_device_type_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), klass);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Device source property</summary>
        /// <returns>Input device</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Input.Device GetSource() {
            var _ret_var = CoreUI.Input.Device.NativeMethods.efl_input_device_source_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Device source property</summary>
        /// <param name="src">Input device</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetSource(CoreUI.Input.Device src) {
            CoreUI.Input.Device.NativeMethods.efl_input_device_source_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), src);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Get the <see cref="CoreUI.Input.Device"/> that represents a seat.
        /// 
        /// This method will find the seat the device belongs to.
        /// 
        /// For this, it walk through device&apos;s parents looking for a device with <see cref="CoreUI.Input.DeviceType.Seat"/>. It may be the device itself.
        /// 
        /// In case no seat is found, <c>null</c> is returned.</summary>
        /// <returns>The seat this device belongs to.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Input.Device GetSeat() {
            var _ret_var = CoreUI.Input.Device.NativeMethods.efl_input_device_seat_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Seat id number</summary>
        /// <returns>The id of the seat</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual uint GetSeatId() {
            var _ret_var = CoreUI.Input.Device.NativeMethods.efl_input_device_seat_id_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Seat id number</summary>
        /// <param name="id">The id of the seat</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetSeatId(uint id) {
            CoreUI.Input.Device.NativeMethods.efl_input_device_seat_id_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), id);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The number of pointer devices in this seat.
        /// 
        /// Pointer devices are the ones whose <see cref="CoreUI.Input.Device.DeviceType"/> is <c>mouse</c>, <c>pen</c>, <c>touch</c> or <c>wand</c>. In case this device is not of the type <c>seat</c>, -1 is returned.</summary>
        /// <returns>The number of pointer devices.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetPointerDeviceCount() {
            var _ret_var = CoreUI.Input.Device.NativeMethods.efl_input_device_pointer_device_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.Device.DeviceType"/> is <c>mouse</c>, <c>pen</c>, <c>touch</c> or <c>wand</c>.</summary>
        /// <returns><c>true</c> if the device has pointing capabilities.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetIsPointerType() {
            var _ret_var = CoreUI.Input.Device.NativeMethods.efl_input_device_is_pointer_type_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Lists the children attached to this device.
        /// 
        /// This is only meaningful with seat devices, as they are groups of real input devices.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>List of device children</returns>
        public virtual IEnumerable<CoreUI.Input.Device> IterateChildren() {
            var _ret_var = CoreUI.Input.Device.NativeMethods.efl_input_device_children_iterate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Input.Device>(_ret_var);
        }

        /// <summary>Device type property</summary>
        /// <value>Input device class</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.DeviceType DeviceType {
            get { return GetDeviceType(); }
            set { SetDeviceType(value); }
        }

        /// <summary>Device source property</summary>
        /// <value>Input device</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Device Source {
            get { return GetSource(); }
            set { SetSource(value); }
        }

        /// <summary>Get the <see cref="CoreUI.Input.Device"/> that represents a seat.
        /// 
        /// This method will find the seat the device belongs to.
        /// 
        /// For this, it walk through device&apos;s parents looking for a device with <see cref="CoreUI.Input.DeviceType.Seat"/>. It may be the device itself.
        /// 
        /// In case no seat is found, <c>null</c> is returned.</summary>
        /// <value>The seat this device belongs to.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Device Seat {
            get { return GetSeat(); }
        }

        /// <summary>Seat id number</summary>
        /// <value>The id of the seat</value>
        /// <since_tizen> 6 </since_tizen>
        public uint SeatId {
            get { return GetSeatId(); }
            set { SetSeatId(value); }
        }

        /// <summary>The number of pointer devices in this seat.
        /// 
        /// Pointer devices are the ones whose <see cref="CoreUI.Input.Device.DeviceType"/> is <c>mouse</c>, <c>pen</c>, <c>touch</c> or <c>wand</c>. In case this device is not of the type <c>seat</c>, -1 is returned.</summary>
        /// <value>The number of pointer devices.</value>
        /// <since_tizen> 6 </since_tizen>
        public int PointerDeviceCount {
            get { return GetPointerDeviceCount(); }
        }

        /// <summary><c>true</c> if <see cref="CoreUI.Input.Device.DeviceType"/> is <c>mouse</c>, <c>pen</c>, <c>touch</c> or <c>wand</c>.</summary>
        /// <value><c>true</c> if the device has pointing capabilities.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool IsPointerType {
            get { return GetIsPointerType(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Input.Device.efl_input_device_class_get();
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

                if (efl_input_device_type_get_static_delegate == null)
                {
                    efl_input_device_type_get_static_delegate = new efl_input_device_type_get_delegate(device_type_get);
                }

                if (methods.Contains("GetDeviceType"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_type_get_static_delegate) });
                }

                if (efl_input_device_type_set_static_delegate == null)
                {
                    efl_input_device_type_set_static_delegate = new efl_input_device_type_set_delegate(device_type_set);
                }

                if (methods.Contains("SetDeviceType"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_type_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_type_set_static_delegate) });
                }

                if (efl_input_device_source_get_static_delegate == null)
                {
                    efl_input_device_source_get_static_delegate = new efl_input_device_source_get_delegate(source_get);
                }

                if (methods.Contains("GetSource"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_source_get_static_delegate) });
                }

                if (efl_input_device_source_set_static_delegate == null)
                {
                    efl_input_device_source_set_static_delegate = new efl_input_device_source_set_delegate(source_set);
                }

                if (methods.Contains("SetSource"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_source_set_static_delegate) });
                }

                if (efl_input_device_seat_get_static_delegate == null)
                {
                    efl_input_device_seat_get_static_delegate = new efl_input_device_seat_get_delegate(seat_get);
                }

                if (methods.Contains("GetSeat"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_seat_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_seat_get_static_delegate) });
                }

                if (efl_input_device_seat_id_get_static_delegate == null)
                {
                    efl_input_device_seat_id_get_static_delegate = new efl_input_device_seat_id_get_delegate(seat_id_get);
                }

                if (methods.Contains("GetSeatId"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_seat_id_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_seat_id_get_static_delegate) });
                }

                if (efl_input_device_seat_id_set_static_delegate == null)
                {
                    efl_input_device_seat_id_set_static_delegate = new efl_input_device_seat_id_set_delegate(seat_id_set);
                }

                if (methods.Contains("SetSeatId"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_seat_id_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_seat_id_set_static_delegate) });
                }

                if (efl_input_device_pointer_device_count_get_static_delegate == null)
                {
                    efl_input_device_pointer_device_count_get_static_delegate = new efl_input_device_pointer_device_count_get_delegate(pointer_device_count_get);
                }

                if (methods.Contains("GetPointerDeviceCount"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_pointer_device_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_pointer_device_count_get_static_delegate) });
                }

                if (efl_input_device_is_pointer_type_get_static_delegate == null)
                {
                    efl_input_device_is_pointer_type_get_static_delegate = new efl_input_device_is_pointer_type_get_delegate(is_pointer_type_get);
                }

                if (methods.Contains("GetIsPointerType"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_is_pointer_type_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_is_pointer_type_get_static_delegate) });
                }

                if (efl_input_device_children_iterate_static_delegate == null)
                {
                    efl_input_device_children_iterate_static_delegate = new efl_input_device_children_iterate_delegate(children_iterate);
                }

                if (methods.Contains("IterateChildren"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_device_children_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_input_device_children_iterate_static_delegate) });
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
                return CoreUI.Input.Device.efl_input_device_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate CoreUI.Input.DeviceType efl_input_device_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.Input.DeviceType efl_input_device_type_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_device_type_get_api_delegate> efl_input_device_type_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_device_type_get_api_delegate>(Module, "efl_input_device_type_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Input.DeviceType device_type_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_device_type_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Input.DeviceType _ret_var = default(CoreUI.Input.DeviceType);
                    try
                    {
                        _ret_var = ((Device)ws.Target).GetDeviceType();
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
                    return efl_input_device_type_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_device_type_get_delegate efl_input_device_type_get_static_delegate;

            
            private delegate void efl_input_device_type_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Input.DeviceType klass);

            
            internal delegate void efl_input_device_type_set_api_delegate(System.IntPtr obj,  CoreUI.Input.DeviceType klass);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_device_type_set_api_delegate> efl_input_device_type_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_device_type_set_api_delegate>(Module, "efl_input_device_type_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void device_type_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Input.DeviceType klass)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_device_type_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Device)ws.Target).SetDeviceType(klass);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_device_type_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), klass);
                }
            }

            private static efl_input_device_type_set_delegate efl_input_device_type_set_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Input.Device efl_input_device_source_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Input.Device efl_input_device_source_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_device_source_get_api_delegate> efl_input_device_source_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_device_source_get_api_delegate>(Module, "efl_input_device_source_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Input.Device source_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_device_source_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Input.Device _ret_var = default(CoreUI.Input.Device);
                    try
                    {
                        _ret_var = ((Device)ws.Target).GetSource();
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
                    return efl_input_device_source_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_device_source_get_delegate efl_input_device_source_get_static_delegate;

            
            private delegate void efl_input_device_source_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Input.Device src);

            
            internal delegate void efl_input_device_source_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Input.Device src);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_device_source_set_api_delegate> efl_input_device_source_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_device_source_set_api_delegate>(Module, "efl_input_device_source_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void source_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Input.Device src)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_device_source_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Device)ws.Target).SetSource(src);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_device_source_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), src);
                }
            }

            private static efl_input_device_source_set_delegate efl_input_device_source_set_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Input.Device efl_input_device_seat_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Input.Device efl_input_device_seat_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_device_seat_get_api_delegate> efl_input_device_seat_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_device_seat_get_api_delegate>(Module, "efl_input_device_seat_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Input.Device seat_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_device_seat_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Input.Device _ret_var = default(CoreUI.Input.Device);
                    try
                    {
                        _ret_var = ((Device)ws.Target).GetSeat();
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
                    return efl_input_device_seat_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_device_seat_get_delegate efl_input_device_seat_get_static_delegate;

            
            private delegate uint efl_input_device_seat_id_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate uint efl_input_device_seat_id_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_device_seat_id_get_api_delegate> efl_input_device_seat_id_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_device_seat_id_get_api_delegate>(Module, "efl_input_device_seat_id_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static uint seat_id_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_device_seat_id_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    uint _ret_var = default(uint);
                    try
                    {
                        _ret_var = ((Device)ws.Target).GetSeatId();
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
                    return efl_input_device_seat_id_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_device_seat_id_get_delegate efl_input_device_seat_id_get_static_delegate;

            
            private delegate void efl_input_device_seat_id_set_delegate(System.IntPtr obj, System.IntPtr pd,  uint id);

            
            internal delegate void efl_input_device_seat_id_set_api_delegate(System.IntPtr obj,  uint id);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_device_seat_id_set_api_delegate> efl_input_device_seat_id_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_device_seat_id_set_api_delegate>(Module, "efl_input_device_seat_id_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void seat_id_set(System.IntPtr obj, System.IntPtr pd, uint id)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_device_seat_id_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Device)ws.Target).SetSeatId(id);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_device_seat_id_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), id);
                }
            }

            private static efl_input_device_seat_id_set_delegate efl_input_device_seat_id_set_static_delegate;

            
            private delegate int efl_input_device_pointer_device_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_input_device_pointer_device_count_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_device_pointer_device_count_get_api_delegate> efl_input_device_pointer_device_count_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_device_pointer_device_count_get_api_delegate>(Module, "efl_input_device_pointer_device_count_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int pointer_device_count_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_device_pointer_device_count_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Device)ws.Target).GetPointerDeviceCount();
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
                    return efl_input_device_pointer_device_count_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_device_pointer_device_count_get_delegate efl_input_device_pointer_device_count_get_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_input_device_is_pointer_type_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_input_device_is_pointer_type_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_device_is_pointer_type_get_api_delegate> efl_input_device_is_pointer_type_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_device_is_pointer_type_get_api_delegate>(Module, "efl_input_device_is_pointer_type_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool is_pointer_type_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_device_is_pointer_type_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Device)ws.Target).GetIsPointerType();
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
                    return efl_input_device_is_pointer_type_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_device_is_pointer_type_get_delegate efl_input_device_is_pointer_type_get_static_delegate;

            
            private delegate System.IntPtr efl_input_device_children_iterate_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate System.IntPtr efl_input_device_children_iterate_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_device_children_iterate_api_delegate> efl_input_device_children_iterate_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_device_children_iterate_api_delegate>(Module, "efl_input_device_children_iterate");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.IntPtr children_iterate(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_device_children_iterate was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    IEnumerable<CoreUI.Input.Device> _ret_var = null;
                    try
                    {
                        _ret_var = ((Device)ws.Target).IterateChildren();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return CoreUI.Wrapper.Globals.IEnumerableToIterator(_ret_var, true);
                }
                else
                {
                    return efl_input_device_children_iterate_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_input_device_children_iterate_delegate efl_input_device_children_iterate_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.Input {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class DeviceExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Input.DeviceType> DeviceType<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Device, T>magic = null) where T : CoreUI.Input.Device {
            return new CoreUI.BindableProperty<CoreUI.Input.DeviceType>("device_type", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Input.Device> Source<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Device, T>magic = null) where T : CoreUI.Input.Device {
            return new CoreUI.BindableProperty<CoreUI.Input.Device>("source", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<uint> SeatId<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Input.Device, T>magic = null) where T : CoreUI.Input.Device {
            return new CoreUI.BindableProperty<uint>("seat_id", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI.Input {
    /// <summary>General type of input device.
    /// 
    /// Legacy support since 1.8 as <c>Evas_Device_Class</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum DeviceType
    {
        /// <summary>Not a device.</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 0,
        /// <summary>The user/seat (the user themselves).</summary>
        /// <since_tizen> 6 </since_tizen>
        Seat = 1,
        /// <summary>A regular keyboard, numberpad or attached buttons.</summary>
        /// <since_tizen> 6 </since_tizen>
        Keyboard = 2,
        /// <summary>A mouse, trackball or touchpad relative motion device.</summary>
        /// <since_tizen> 6 </since_tizen>
        Mouse = 3,
        /// <summary>A touchscreen with fingers or stylus.</summary>
        /// <since_tizen> 6 </since_tizen>
        Touch = 4,
        /// <summary>A special pen device.</summary>
        /// <since_tizen> 6 </since_tizen>
        Pen = 5,
        /// <summary>A laser pointer, wii-style or &quot;Minority Report&quot; pointing device.</summary>
        /// <since_tizen> 6 </since_tizen>
        Wand = 6,
        /// <summary>A gamepad controller or joystick.</summary>
        /// <since_tizen> 6 </since_tizen>
        Gamepad = 7,
    }
}

