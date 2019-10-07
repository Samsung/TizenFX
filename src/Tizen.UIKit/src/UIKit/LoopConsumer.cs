#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace UIKit {

/// <summary>An <see cref="UIKit.LoopConsumer"/> is a class which requires one of the parents to provide an <see cref="UIKit.Loop"/> interface when performing <see cref="UIKit.Object.FindProvider"/>. It will enforce this by only allowing parents which provide such an interface or <c>NULL</c>.</summary>
/// <since_tizen> 6 </since_tizen>
[UIKit.LoopConsumer.NativeMethods]
[UIKit.Wrapper.BindingEntity]
public abstract class LoopConsumer : UIKit.Object
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(LoopConsumer))
            {
                return GetUIKitClassStatic();
            }
            else
            {
                return UIKit.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(UIKit.Libs.Ecore)] internal static extern System.IntPtr
        efl_loop_consumer_class_get();

    /// <summary>Initializes a new instance of the <see cref="LoopConsumer"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <since_tizen> 6 </since_tizen>
    public LoopConsumer(UIKit.Object parent= null
            ) : base(efl_loop_consumer_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    /// <since_tizen> 6 </since_tizen>
    protected LoopConsumer(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LoopConsumer"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    /// <since_tizen> 6 </since_tizen>
    protected LoopConsumer(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
    {
    }

    [UIKit.Wrapper.PrivateNativeClass]
    private class LoopConsumerRealized : LoopConsumer
    {
        private LoopConsumerRealized(UIKit.Wrapper.Globals.WrappingHandle wh) : base(wh)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="LoopConsumer"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The UIKit.Object parent of this instance.</param>
    protected LoopConsumer(IntPtr baseKlass, UIKit.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>Handle of the loop this object belongs to.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>UIKit loop.</returns>
    public virtual UIKit.Loop GetLoop() {
        var _ret_var = UIKit.LoopConsumer.NativeMethods.efl_loop_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Creates a new future that is already resolved to a value.
    /// This function creates a new future with an already known value, that will be resolved and dispatched by the loop scheduler as usual.
    /// 
    /// This is a helper that behaves the same as eina_future_resolved.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="result">The value to be delivered.
    /// Note that the value contents must survive this function scope, that is, do not use stack allocated blobs, arrays, structures or types that keep references to memory you give. Values will be automatically cleaned up using ref eina_value_flush() once they are unused (no more future or futures returned a new value)</param>
    /// <returns>The future or <c>NULL</c> on error.</returns>
    public virtual  UIKit.DataTypes.Future FutureResolved(UIKit.DataTypes.Value result) {
        var _in_result = result.GetNative();
var _ret_var = UIKit.LoopConsumer.NativeMethods.efl_loop_future_resolved_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_result);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Creates a new future that is already rejected to a specified error using the <see cref="UIKit.LoopConsumer.GetLoop"/>.
    /// This function creates a new future with an already known error, that will be resolved and dispatched by the loop scheduler as usual.
    /// 
    /// This is a helper that behaves the same as ref eina_future_rejected.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="error">An Eina_Error value</param>
    /// <returns>The future or <c>NULL</c> on error.</returns>
    public virtual  UIKit.DataTypes.Future FutureRejected(UIKit.DataTypes.Error error) {
        var _ret_var = UIKit.LoopConsumer.NativeMethods.efl_loop_future_rejected_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)),error);
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Create a new promise with the scheduler coming from the loop provided by this object.
    /// Note: You should not use eina_promise_data_set as this function rely on controlling the promise data.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The new promise.</returns>
    public virtual UIKit.DataTypes.Promise NewPromise() {
        var _ret_var = UIKit.LoopConsumer.NativeMethods.efl_loop_promise_new_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : UIKit.Wrapper.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        UIKit.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Async wrapper for <see cref="FutureResolved" />.</summary>
    /// <param name="result">The value to be delivered.
    /// Note that the value contents must survive this function scope, that is, do not use stack allocated blobs, arrays, structures or types that keep references to memory you give. Values will be automatically cleaned up using ref eina_value_flush() once they are unused (no more future or futures returned a new value)</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<UIKit.DataTypes.Value> FutureResolvedAsync(UIKit.DataTypes.Value result, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        UIKit.DataTypes.Future future = FutureResolved( result);
        return UIKit.Wrapper.Globals.WrapAsync(future, token);
    }

    /// <summary>Async wrapper for <see cref="FutureRejected" />.</summary>
    /// <param name="error">An Eina_Error value</param>
    /// <param name="token">Token to notify the async operation of external request to cancel.</param>
    /// <returns>An async task wrapping the result of the operation.</returns>
    public System.Threading.Tasks.Task<UIKit.DataTypes.Value> FutureRejectedAsync(UIKit.DataTypes.Error error, System.Threading.CancellationToken token = default(System.Threading.CancellationToken))
    {
        UIKit.DataTypes.Future future = FutureRejected( error);
        return UIKit.Wrapper.Globals.WrapAsync(future, token);
    }

    /// <summary>Handle of the loop this object belongs to.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>UIKit loop.</value>
    public UIKit.Loop Loop {
        get { return GetLoop(); }
    }

    private static IntPtr GetUIKitClassStatic()
    {
        return UIKit.LoopConsumer.efl_loop_consumer_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : UIKit.Object.NativeMethods
    {
        private static UIKit.Wrapper.NativeModule Module = new UIKit.Wrapper.NativeModule(UIKit.Libs.Ecore);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<UIKit_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<UIKit_Op_Description>();
            var methods = UIKit.Wrapper.Globals.GetUserMethods(type);

            if (efl_loop_get_static_delegate == null)
            {
                efl_loop_get_static_delegate = new efl_loop_get_delegate(loop_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoop") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_get_static_delegate) });
            }

            if (efl_loop_future_resolved_static_delegate == null)
            {
                efl_loop_future_resolved_static_delegate = new efl_loop_future_resolved_delegate(future_resolved);
            }

            if (methods.FirstOrDefault(m => m.Name == "FutureResolved") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_future_resolved"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_future_resolved_static_delegate) });
            }

            if (efl_loop_future_rejected_static_delegate == null)
            {
                efl_loop_future_rejected_static_delegate = new efl_loop_future_rejected_delegate(future_rejected);
            }

            if (methods.FirstOrDefault(m => m.Name == "FutureRejected") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_future_rejected"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_future_rejected_static_delegate) });
            }

            if (efl_loop_promise_new_static_delegate == null)
            {
                efl_loop_promise_new_static_delegate = new efl_loop_promise_new_delegate(promise_new);
            }

            if (methods.FirstOrDefault(m => m.Name == "NewPromise") != null)
            {
                descs.Add(new UIKit_Op_Description() {api_func = UIKit.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_promise_new"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_promise_new_static_delegate) });
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
            return UIKit.LoopConsumer.efl_loop_consumer_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        private delegate UIKit.Loop efl_loop_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.Wrapper.MarshalEo<UIKit.Wrapper.NonOwnTag>))]
        public delegate UIKit.Loop efl_loop_get_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_loop_get_api_delegate> efl_loop_get_ptr = new UIKit.Wrapper.FunctionWrapper<efl_loop_get_api_delegate>(Module, "efl_loop_get");

        private static UIKit.Loop loop_get(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_loop_get was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.Loop _ret_var = default(UIKit.Loop);
                try
                {
                    _ret_var = ((LoopConsumer)ws.Target).GetLoop();
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
                return efl_loop_get_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_get_delegate efl_loop_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.DataTypes.FutureMarshaler))]
        private delegate  UIKit.DataTypes.Future efl_loop_future_resolved_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.DataTypes.ValueNative result);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.DataTypes.FutureMarshaler))]
        public delegate  UIKit.DataTypes.Future efl_loop_future_resolved_api_delegate(System.IntPtr obj,  UIKit.DataTypes.ValueNative result);

        public static UIKit.Wrapper.FunctionWrapper<efl_loop_future_resolved_api_delegate> efl_loop_future_resolved_ptr = new UIKit.Wrapper.FunctionWrapper<efl_loop_future_resolved_api_delegate>(Module, "efl_loop_future_resolved");

        private static  UIKit.DataTypes.Future future_resolved(System.IntPtr obj, System.IntPtr pd, UIKit.DataTypes.ValueNative result)
        {
            UIKit.DataTypes.Log.Debug("function efl_loop_future_resolved was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                var _in_result = new UIKit.DataTypes.Value(result);
 UIKit.DataTypes.Future _ret_var = default( UIKit.DataTypes.Future);
                try
                {
                    _ret_var = ((LoopConsumer)ws.Target).FutureResolved(_in_result);
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
                return efl_loop_future_resolved_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), result);
            }
        }

        private static efl_loop_future_resolved_delegate efl_loop_future_resolved_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.DataTypes.FutureMarshaler))]
        private delegate  UIKit.DataTypes.Future efl_loop_future_rejected_delegate(System.IntPtr obj, System.IntPtr pd,  UIKit.DataTypes.Error error);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(UIKit.DataTypes.FutureMarshaler))]
        public delegate  UIKit.DataTypes.Future efl_loop_future_rejected_api_delegate(System.IntPtr obj,  UIKit.DataTypes.Error error);

        public static UIKit.Wrapper.FunctionWrapper<efl_loop_future_rejected_api_delegate> efl_loop_future_rejected_ptr = new UIKit.Wrapper.FunctionWrapper<efl_loop_future_rejected_api_delegate>(Module, "efl_loop_future_rejected");

        private static  UIKit.DataTypes.Future future_rejected(System.IntPtr obj, System.IntPtr pd, UIKit.DataTypes.Error error)
        {
            UIKit.DataTypes.Log.Debug("function efl_loop_future_rejected was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                 UIKit.DataTypes.Future _ret_var = default( UIKit.DataTypes.Future);
                try
                {
                    _ret_var = ((LoopConsumer)ws.Target).FutureRejected(error);
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
                return efl_loop_future_rejected_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)), error);
            }
        }

        private static efl_loop_future_rejected_delegate efl_loop_future_rejected_static_delegate;

        
        private delegate UIKit.DataTypes.Promise efl_loop_promise_new_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate UIKit.DataTypes.Promise efl_loop_promise_new_api_delegate(System.IntPtr obj);

        public static UIKit.Wrapper.FunctionWrapper<efl_loop_promise_new_api_delegate> efl_loop_promise_new_ptr = new UIKit.Wrapper.FunctionWrapper<efl_loop_promise_new_api_delegate>(Module, "efl_loop_promise_new");

        private static UIKit.DataTypes.Promise promise_new(System.IntPtr obj, System.IntPtr pd)
        {
            UIKit.DataTypes.Log.Debug("function efl_loop_promise_new was called");
            var ws = UIKit.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                UIKit.DataTypes.Promise _ret_var = default(UIKit.DataTypes.Promise);
                try
                {
                    _ret_var = ((LoopConsumer)ws.Target).NewPromise();
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
                return efl_loop_promise_new_ptr.Value.Delegate(UIKit.Wrapper.Globals.efl_super(obj, UIKit.Wrapper.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_promise_new_delegate efl_loop_promise_new_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class UIKitLoopConsumer_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
