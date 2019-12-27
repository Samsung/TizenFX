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
namespace CoreUI {
    /// <summary>An <see cref="CoreUI.LoopConsumer"/> is a class which requires one of the parents to provide an <see cref="CoreUI.Loop"/> interface when performing <see cref="CoreUI.Object.FindProvider"/>. It will enforce this by only allowing parents which provide such an interface or <c>NULL</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.LoopConsumer.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class LoopConsumer : CoreUI.Object
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(LoopConsumer))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Ecore)] internal static extern System.IntPtr
            efl_loop_consumer_class_get();

        /// <summary>Initializes a new instance of the <see cref="LoopConsumer"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public LoopConsumer(CoreUI.Object parent= null) : base(efl_loop_consumer_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected LoopConsumer(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="LoopConsumer"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal LoopConsumer(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class LoopConsumerRealized : LoopConsumer
        {
            private LoopConsumerRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="LoopConsumer"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected LoopConsumer(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Handle of the loop this object belongs to.</summary>
        /// <returns>CoreUI loop.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Loop GetLoop() {
            var _ret_var = CoreUI.LoopConsumer.NativeMethods.efl_loop_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Creates a new future that is already resolved to a value.
        /// 
        /// This function creates a new future with an already known value, that will be resolved and dispatched by the loop scheduler as usual.
        /// 
        /// This is a helper that behaves the same as eina_future_resolved.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="result">The value to be delivered.
        /// 
        /// Note that the value contents must survive this function scope, that is, do not use stack allocated blobs, arrays, structures or types that keep references to memory you give. Values will be automatically cleaned up using ref eina_value_flush() once they are unused (no more future or futures returned a new value)</param>
        /// <returns>The future or <c>NULL</c> on error.</returns>
        public virtual  CoreUI.DataTypes.Future FutureResolved(CoreUI.DataTypes.Value result) {
            Contract.Requires(result != null, nameof(result));
var _in_result = result.GetNative();
var _ret_var = CoreUI.LoopConsumer.NativeMethods.efl_loop_future_resolved_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_result);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Creates a new future that is already rejected to a specified error using the <see cref="CoreUI.LoopConsumer.GetLoop"/>.
        /// 
        /// This function creates a new future with an already known error, that will be resolved and dispatched by the loop scheduler as usual.
        /// 
        /// This is a helper that behaves the same as ref eina_future_rejected.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="error">An Eina_Error value</param>
        /// <returns>The future or <c>NULL</c> on error.</returns>
        public virtual  CoreUI.DataTypes.Future FutureRejected(CoreUI.DataTypes.Error error) {
            var _ret_var = CoreUI.LoopConsumer.NativeMethods.efl_loop_future_rejected_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), error);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Create a new promise with the scheduler coming from the loop provided by this object.
        /// 
        /// <b>NOTE: </b>You should not use eina_promise_data_set as this function rely on controlling the promise data.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The new promise.</returns>
        public virtual CoreUI.DataTypes.Promise NewPromise() {
            var _ret_var = CoreUI.LoopConsumer.NativeMethods.efl_loop_promise_new_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Async wrapper for <see cref="FutureResolved" />.
        /// </summary>
    /// <param name="result">The value to be delivered.
    /// 
    /// Note that the value contents must survive this function scope, that is, do not use stack allocated blobs, arrays, structures or types that keep references to memory you give. Values will be automatically cleaned up using ref eina_value_flush() once they are unused (no more future or futures returned a new value)</param>
        /// <param name="token">Token to notify the async operation of external request to cancel.</param>
        /// <returns>An async task wrapping the result of the operation.</returns>
        public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> FutureResolvedAsync(CoreUI.DataTypes.Value result,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
        {
            CoreUI.DataTypes.Future future = FutureResolved( result);
            return CoreUI.Wrapper.Globals.WrapAsync(future, token);
        }

        /// <summary>Async wrapper for <see cref="FutureRejected" />.
        /// </summary>
    /// <param name="error">An Eina_Error value</param>
        /// <param name="token">Token to notify the async operation of external request to cancel.</param>
        /// <returns>An async task wrapping the result of the operation.</returns>
        public System.Threading.Tasks.Task<CoreUI.DataTypes.Value> FutureRejectedAsync(CoreUI.DataTypes.Error error,  System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
        {
            CoreUI.DataTypes.Future future = FutureRejected( error);
            return CoreUI.Wrapper.Globals.WrapAsync(future, token);
        }

        /// <summary>Handle of the loop this object belongs to.</summary>
        /// <value>CoreUI loop.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Loop Loop {
            get { return GetLoop(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.LoopConsumer.efl_loop_consumer_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Object.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Ecore);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_loop_get_static_delegate == null)
                {
                    efl_loop_get_static_delegate = new efl_loop_get_delegate(loop_get);
                }

                if (methods.Contains("GetLoop"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_get_static_delegate) });
                }

                if (efl_loop_future_resolved_static_delegate == null)
                {
                    efl_loop_future_resolved_static_delegate = new efl_loop_future_resolved_delegate(future_resolved);
                }

                if (methods.Contains("FutureResolved"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_future_resolved"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_future_resolved_static_delegate) });
                }

                if (efl_loop_future_rejected_static_delegate == null)
                {
                    efl_loop_future_rejected_static_delegate = new efl_loop_future_rejected_delegate(future_rejected);
                }

                if (methods.Contains("FutureRejected"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_future_rejected"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_future_rejected_static_delegate) });
                }

                if (efl_loop_promise_new_static_delegate == null)
                {
                    efl_loop_promise_new_static_delegate = new efl_loop_promise_new_delegate(promise_new);
                }

                if (methods.Contains("NewPromise"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_promise_new"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_promise_new_static_delegate) });
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
                return CoreUI.LoopConsumer.efl_loop_consumer_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Loop efl_loop_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Loop efl_loop_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_get_api_delegate> efl_loop_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_get_api_delegate>(Module, "efl_loop_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Loop loop_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Loop _ret_var = default(CoreUI.Loop);
                    try
                    {
                        _ret_var = ((LoopConsumer)ws.Target).GetLoop();
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
                    return efl_loop_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_loop_get_delegate efl_loop_get_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            private delegate  CoreUI.DataTypes.Future efl_loop_future_resolved_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.ValueNative result);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            internal delegate  CoreUI.DataTypes.Future efl_loop_future_resolved_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.ValueNative result);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_future_resolved_api_delegate> efl_loop_future_resolved_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_future_resolved_api_delegate>(Module, "efl_loop_future_resolved");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static  CoreUI.DataTypes.Future future_resolved(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.ValueNative result)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_future_resolved was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    var _in_result = new CoreUI.DataTypes.Value(result);
 CoreUI.DataTypes.Future _ret_var = default( CoreUI.DataTypes.Future);
                    try
                    {
                        _ret_var = ((LoopConsumer)ws.Target).FutureResolved(_in_result);
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
                    return efl_loop_future_resolved_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), result);
                }
            }

            private static efl_loop_future_resolved_delegate efl_loop_future_resolved_static_delegate;

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            private delegate  CoreUI.DataTypes.Future efl_loop_future_rejected_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Error error);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.DataTypes.FutureMarshaler))]
            internal delegate  CoreUI.DataTypes.Future efl_loop_future_rejected_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Error error);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_future_rejected_api_delegate> efl_loop_future_rejected_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_future_rejected_api_delegate>(Module, "efl_loop_future_rejected");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static  CoreUI.DataTypes.Future future_rejected(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Error error)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_future_rejected was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                     CoreUI.DataTypes.Future _ret_var = default( CoreUI.DataTypes.Future);
                    try
                    {
                        _ret_var = ((LoopConsumer)ws.Target).FutureRejected(error);
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
                    return efl_loop_future_rejected_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), error);
                }
            }

            private static efl_loop_future_rejected_delegate efl_loop_future_rejected_static_delegate;

            
            private delegate CoreUI.DataTypes.Promise efl_loop_promise_new_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.DataTypes.Promise efl_loop_promise_new_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_loop_promise_new_api_delegate> efl_loop_promise_new_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_loop_promise_new_api_delegate>(Module, "efl_loop_promise_new");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Promise promise_new(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_loop_promise_new was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Promise _ret_var = default(CoreUI.DataTypes.Promise);
                    try
                    {
                        _ret_var = ((LoopConsumer)ws.Target).NewPromise();
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
                    return efl_loop_promise_new_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_loop_promise_new_delegate efl_loop_promise_new_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

