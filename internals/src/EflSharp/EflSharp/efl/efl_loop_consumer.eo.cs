#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>An <see cref="Efl.LoopConsumer"/> is a class which requires one of the parents to provide an <see cref="Efl.Loop"/> interface when performing <see cref="Efl.Object.FindProvider"/>. It will enforce this by only allowing parents which provide such an interface or <c>NULL</c>.
/// (Since EFL 1.22)</summary>
[Efl.LoopConsumer.NativeMethods]
public abstract class LoopConsumer : Efl.Object, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(LoopConsumer))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_loop_consumer_class_get();
    /// <summary>Initializes a new instance of the <see cref="LoopConsumer"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public LoopConsumer(Efl.Object parent= null
            ) : base(efl_loop_consumer_class_get(), typeof(LoopConsumer), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="LoopConsumer"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected LoopConsumer(System.IntPtr raw) : base(raw)
    {
            }

    [Efl.Eo.PrivateNativeClass]
    private class LoopConsumerRealized : LoopConsumer
    {
        private LoopConsumerRealized(IntPtr ptr) : base(ptr)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="LoopConsumer"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected LoopConsumer(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    /// <summary>Gets a handle to the loop.
    /// (Since EFL 1.22)</summary>
    /// <returns>Efl loop</returns>
    virtual public Efl.Loop GetLoop() {
         var _ret_var = Efl.LoopConsumer.NativeMethods.efl_loop_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Creates a new future that is already resolved to a value.
    /// This function creates a new future with an already known value, that will be resolved and dispatched by the loop scheduler as usual.
    /// 
    /// This is a helper that behaves the same as eina_future_resolved.
    /// (Since EFL 1.22)</summary>
    /// <param name="result">The value to be delivered.
    /// Note that the value contents must survive this function scope, that is, do not use stack allocated blobs, arrays, structures or types that keep references to memory you give. Values will be automatically cleaned up using @ref eina_value_flush() once they are unused (no more future or futures returned a new value)</param>
    /// <returns>The future or <c>NULL</c> on error.</returns>
    virtual public  Eina.Future FutureResolved(Eina.Value result) {
         var _in_result = result.GetNative();
                        var _ret_var = Efl.LoopConsumer.NativeMethods.efl_loop_future_resolved_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),_in_result);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Creates a new future that is already rejected to a specified error using the <see cref="Efl.LoopConsumer.GetLoop"/>.
    /// This function creates a new future with an already known error, that will be resolved and dispatched by the loop scheduler as usual.
    /// 
    /// This is a helper that behaves the same as @ref eina_future_rejected.
    /// (Since EFL 1.22)</summary>
    /// <param name="error">An Eina_Error value</param>
    /// <returns>The future or <c>NULL</c> on error.</returns>
    virtual public  Eina.Future FutureRejected(Eina.Error error) {
                                 var _ret_var = Efl.LoopConsumer.NativeMethods.efl_loop_future_rejected_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),error);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Create a new promise with the scheduler coming from the loop provided by this object.
    /// Note: You should not use eina_promise_data_set as this function rely on controlling the promise data.
    /// (Since EFL 1.22)</summary>
    /// <returns>The new promise.</returns>
    virtual public Eina.Promise NewPromise() {
         var _ret_var = Efl.LoopConsumer.NativeMethods.efl_loop_promise_new_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    public System.Threading.Tasks.Task<Eina.Value> FutureResolvedAsync(Eina.Value result, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = FutureResolved( result);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }
    public System.Threading.Tasks.Task<Eina.Value> FutureRejectedAsync(Eina.Error error, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        Eina.Future future = FutureRejected( error);
        return Efl.Eo.Globals.WrapAsync(future, token);
    }
    /// <summary>The loop to which this object belongs to.
/// (Since EFL 1.22)</summary>
/// <value>Efl loop</value>
    public Efl.Loop Loop {
        get { return GetLoop(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.LoopConsumer.efl_loop_consumer_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_loop_get_static_delegate == null)
            {
                efl_loop_get_static_delegate = new efl_loop_get_delegate(loop_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoop") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_get_static_delegate) });
            }

            if (efl_loop_future_resolved_static_delegate == null)
            {
                efl_loop_future_resolved_static_delegate = new efl_loop_future_resolved_delegate(future_resolved);
            }

            if (methods.FirstOrDefault(m => m.Name == "FutureResolved") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_future_resolved"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_future_resolved_static_delegate) });
            }

            if (efl_loop_future_rejected_static_delegate == null)
            {
                efl_loop_future_rejected_static_delegate = new efl_loop_future_rejected_delegate(future_rejected);
            }

            if (methods.FirstOrDefault(m => m.Name == "FutureRejected") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_future_rejected"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_future_rejected_static_delegate) });
            }

            if (efl_loop_promise_new_static_delegate == null)
            {
                efl_loop_promise_new_static_delegate = new efl_loop_promise_new_delegate(promise_new);
            }

            if (methods.FirstOrDefault(m => m.Name == "NewPromise") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_promise_new"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_promise_new_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.LoopConsumer.efl_loop_consumer_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Loop efl_loop_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Loop efl_loop_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_get_api_delegate> efl_loop_get_ptr = new Efl.Eo.FunctionWrapper<efl_loop_get_api_delegate>(Module, "efl_loop_get");

        private static Efl.Loop loop_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.Loop _ret_var = default(Efl.Loop);
                try
                {
                    _ret_var = ((LoopConsumer)wrapper).GetLoop();
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
                return efl_loop_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_get_delegate efl_loop_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_loop_future_resolved_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.ValueNative result);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_loop_future_resolved_api_delegate(System.IntPtr obj,  Eina.ValueNative result);

        public static Efl.Eo.FunctionWrapper<efl_loop_future_resolved_api_delegate> efl_loop_future_resolved_ptr = new Efl.Eo.FunctionWrapper<efl_loop_future_resolved_api_delegate>(Module, "efl_loop_future_resolved");

        private static  Eina.Future future_resolved(System.IntPtr obj, System.IntPtr pd, Eina.ValueNative result)
        {
            Eina.Log.Debug("function efl_loop_future_resolved was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
        var _in_result = new Eina.Value(result);
                             Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((LoopConsumer)wrapper).FutureResolved(_in_result);
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
                return efl_loop_future_resolved_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), result);
            }
        }

        private static efl_loop_future_resolved_delegate efl_loop_future_resolved_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        private delegate  Eina.Future efl_loop_future_rejected_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Error error);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))]
        public delegate  Eina.Future efl_loop_future_rejected_api_delegate(System.IntPtr obj,  Eina.Error error);

        public static Efl.Eo.FunctionWrapper<efl_loop_future_rejected_api_delegate> efl_loop_future_rejected_ptr = new Efl.Eo.FunctionWrapper<efl_loop_future_rejected_api_delegate>(Module, "efl_loop_future_rejected");

        private static  Eina.Future future_rejected(System.IntPtr obj, System.IntPtr pd, Eina.Error error)
        {
            Eina.Log.Debug("function efl_loop_future_rejected was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                     Eina.Future _ret_var = default( Eina.Future);
                try
                {
                    _ret_var = ((LoopConsumer)wrapper).FutureRejected(error);
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
                return efl_loop_future_rejected_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), error);
            }
        }

        private static efl_loop_future_rejected_delegate efl_loop_future_rejected_static_delegate;

        
        private delegate Eina.Promise efl_loop_promise_new_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Promise efl_loop_promise_new_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_promise_new_api_delegate> efl_loop_promise_new_ptr = new Efl.Eo.FunctionWrapper<efl_loop_promise_new_api_delegate>(Module, "efl_loop_promise_new");

        private static Eina.Promise promise_new(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_promise_new was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Eina.Promise _ret_var = default(Eina.Promise);
                try
                {
                    _ret_var = ((LoopConsumer)wrapper).NewPromise();
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
                return efl_loop_promise_new_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_promise_new_delegate efl_loop_promise_new_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

