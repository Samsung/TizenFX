#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

///<summary>Event argument wrapper for event <see cref="Efl.LoopMessageFutureHandler.MessageFutureEvt"/>.</summary>
public class LoopMessageFutureHandlerMessageFutureEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.LoopMessageFuture arg { get; set; }
}
/// <summary>Internal use for future on an efl loop - replacing legacy ecore events</summary>
[Efl.LoopMessageFutureHandler.NativeMethods]
public class LoopMessageFutureHandler : Efl.LoopMessageHandler, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(LoopMessageFutureHandler))
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
        efl_loop_message_future_handler_class_get();
    /// <summary>Initializes a new instance of the <see cref="LoopMessageFutureHandler"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public LoopMessageFutureHandler(Efl.Object parent= null
            ) : base(efl_loop_message_future_handler_class_get(), typeof(LoopMessageFutureHandler), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="LoopMessageFutureHandler"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected LoopMessageFutureHandler(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="LoopMessageFutureHandler"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected LoopMessageFutureHandler(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
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

    /// <summary>No description supplied.</summary>
    public event EventHandler<Efl.LoopMessageFutureHandlerMessageFutureEvt_Args> MessageFutureEvt
    {
        add
        {
            lock (eventLock)
            {
                var wRef = new WeakReference(this);
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = wRef.Target as Efl.Eo.IWrapper;
                    if (obj != null)
                    {
                                                Efl.LoopMessageFutureHandlerMessageFutureEvt_Args args = new Efl.LoopMessageFutureHandlerMessageFutureEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.LoopMessageFuture);
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_LOOP_MESSAGE_FUTURE_HANDLER_EVENT_MESSAGE_FUTURE";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_LOOP_MESSAGE_FUTURE_HANDLER_EVENT_MESSAGE_FUTURE";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event MessageFutureEvt.</summary>
    public void OnMessageFutureEvt(Efl.LoopMessageFutureHandlerMessageFutureEvt_Args e)
    {
        var key = "_EFL_LOOP_MESSAGE_FUTURE_HANDLER_EVENT_MESSAGE_FUTURE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>No description supplied.</summary>
    /// <returns>No description supplied.</returns>
    virtual public Efl.LoopMessageFuture AddMessageType() {
         var _ret_var = Efl.LoopMessageFutureHandler.NativeMethods.efl_loop_message_future_handler_message_type_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.LoopMessageFutureHandler.efl_loop_message_future_handler_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.LoopMessageHandler.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_loop_message_future_handler_message_type_add_static_delegate == null)
            {
                efl_loop_message_future_handler_message_type_add_static_delegate = new efl_loop_message_future_handler_message_type_add_delegate(message_type_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddMessageType") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_message_future_handler_message_type_add"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_future_handler_message_type_add_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.LoopMessageFutureHandler.efl_loop_message_future_handler_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.LoopMessageFuture efl_loop_message_future_handler_message_type_add_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.LoopMessageFuture efl_loop_message_future_handler_message_type_add_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_message_future_handler_message_type_add_api_delegate> efl_loop_message_future_handler_message_type_add_ptr = new Efl.Eo.FunctionWrapper<efl_loop_message_future_handler_message_type_add_api_delegate>(Module, "efl_loop_message_future_handler_message_type_add");

        private static Efl.LoopMessageFuture message_type_add(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_message_future_handler_message_type_add was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.LoopMessageFuture _ret_var = default(Efl.LoopMessageFuture);
                try
                {
                    _ret_var = ((LoopMessageFutureHandler)wrapper).AddMessageType();
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
                return efl_loop_message_future_handler_message_type_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_message_future_handler_message_type_add_delegate efl_loop_message_future_handler_message_type_add_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

