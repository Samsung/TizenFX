#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Event argument wrapper for event <see cref="Efl.LoopMessageHandler.MessageEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class LoopMessageHandlerMessageEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>The message payload data</value>
    public Efl.LoopMessage arg { get; set; }
}
/// <summary>Message handlers represent a single message type on the Efl.Loop parent object. These message handlers can be used to listen for that message type by listening to the message event for the generic case or a class specific event type to get specific message object typing correct.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.LoopMessageHandler.NativeMethods]
[Efl.Eo.BindingEntity]
public class LoopMessageHandler : Efl.Object
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(LoopMessageHandler))
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
        efl_loop_message_handler_class_get();
    /// <summary>Initializes a new instance of the <see cref="LoopMessageHandler"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public LoopMessageHandler(Efl.Object parent= null
            ) : base(efl_loop_message_handler_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected LoopMessageHandler(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LoopMessageHandler"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected LoopMessageHandler(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LoopMessageHandler"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected LoopMessageHandler(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>The message payload data</summary>
    /// <value><see cref="Efl.LoopMessageHandlerMessageEventArgs"/></value>
    public event EventHandler<Efl.LoopMessageHandlerMessageEventArgs> MessageEvent
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.LoopMessageHandlerMessageEventArgs args = new Efl.LoopMessageHandlerMessageEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.LoopMessage);
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

                string key = "_EFL_LOOP_MESSAGE_HANDLER_EVENT_MESSAGE";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_LOOP_MESSAGE_HANDLER_EVENT_MESSAGE";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    /// <summary>Method to raise event MessageEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnMessageEvent(Efl.LoopMessageHandlerMessageEventArgs e)
    {
        var key = "_EFL_LOOP_MESSAGE_HANDLER_EVENT_MESSAGE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Creates a new message object of the correct type for this message type.</summary>
    /// <returns>The new message payload object.</returns>
    public virtual Efl.LoopMessage AddMessage() {
         var _ret_var = Efl.LoopMessageHandler.NativeMethods.efl_loop_message_handler_message_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Place the message on the queue to be called later when message_process() is called on the loop object.</summary>
    /// <param name="message">The message to place on the queue.</param>
    public virtual void MessageSend(Efl.LoopMessage message) {
                                 Efl.LoopMessageHandler.NativeMethods.efl_loop_message_handler_message_send_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),message);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Overide me (implement) then call super after calling the right callback type if you specialize the message type.</summary>
    /// <param name="message">Generic message event type</param>
    public virtual void CallMessage(Efl.LoopMessage message) {
                                 Efl.LoopMessageHandler.NativeMethods.efl_loop_message_handler_message_call_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),message);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Delete all queued messages belonging to this message handler that are pending on the queue so they are not processed later.</summary>
    /// <returns>True if any messages of this type were cleared.</returns>
    public virtual bool ClearMessage() {
         var _ret_var = Efl.LoopMessageHandler.NativeMethods.efl_loop_message_handler_message_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.LoopMessageHandler.efl_loop_message_handler_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Ecore);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_loop_message_handler_message_add_static_delegate == null)
            {
                efl_loop_message_handler_message_add_static_delegate = new efl_loop_message_handler_message_add_delegate(message_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddMessage") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_message_handler_message_add"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_handler_message_add_static_delegate) });
            }

            if (efl_loop_message_handler_message_send_static_delegate == null)
            {
                efl_loop_message_handler_message_send_static_delegate = new efl_loop_message_handler_message_send_delegate(message_send);
            }

            if (methods.FirstOrDefault(m => m.Name == "MessageSend") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_message_handler_message_send"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_handler_message_send_static_delegate) });
            }

            if (efl_loop_message_handler_message_call_static_delegate == null)
            {
                efl_loop_message_handler_message_call_static_delegate = new efl_loop_message_handler_message_call_delegate(message_call);
            }

            if (methods.FirstOrDefault(m => m.Name == "CallMessage") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_message_handler_message_call"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_handler_message_call_static_delegate) });
            }

            if (efl_loop_message_handler_message_clear_static_delegate == null)
            {
                efl_loop_message_handler_message_clear_static_delegate = new efl_loop_message_handler_message_clear_delegate(message_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearMessage") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_loop_message_handler_message_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_handler_message_clear_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.LoopMessageHandler.efl_loop_message_handler_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.LoopMessage efl_loop_message_handler_message_add_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.LoopMessage efl_loop_message_handler_message_add_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_add_api_delegate> efl_loop_message_handler_message_add_ptr = new Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_add_api_delegate>(Module, "efl_loop_message_handler_message_add");

        private static Efl.LoopMessage message_add(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_message_handler_message_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.LoopMessage _ret_var = default(Efl.LoopMessage);
                try
                {
                    _ret_var = ((LoopMessageHandler)ws.Target).AddMessage();
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
                return efl_loop_message_handler_message_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_message_handler_message_add_delegate efl_loop_message_handler_message_add_static_delegate;

        
        private delegate void efl_loop_message_handler_message_send_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.LoopMessage message);

        
        public delegate void efl_loop_message_handler_message_send_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.LoopMessage message);

        public static Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_send_api_delegate> efl_loop_message_handler_message_send_ptr = new Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_send_api_delegate>(Module, "efl_loop_message_handler_message_send");

        private static void message_send(System.IntPtr obj, System.IntPtr pd, Efl.LoopMessage message)
        {
            Eina.Log.Debug("function efl_loop_message_handler_message_send was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((LoopMessageHandler)ws.Target).MessageSend(message);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_loop_message_handler_message_send_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), message);
            }
        }

        private static efl_loop_message_handler_message_send_delegate efl_loop_message_handler_message_send_static_delegate;

        
        private delegate void efl_loop_message_handler_message_call_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.LoopMessage message);

        
        public delegate void efl_loop_message_handler_message_call_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.LoopMessage message);

        public static Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_call_api_delegate> efl_loop_message_handler_message_call_ptr = new Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_call_api_delegate>(Module, "efl_loop_message_handler_message_call");

        private static void message_call(System.IntPtr obj, System.IntPtr pd, Efl.LoopMessage message)
        {
            Eina.Log.Debug("function efl_loop_message_handler_message_call was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((LoopMessageHandler)ws.Target).CallMessage(message);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_loop_message_handler_message_call_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), message);
            }
        }

        private static efl_loop_message_handler_message_call_delegate efl_loop_message_handler_message_call_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_loop_message_handler_message_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_loop_message_handler_message_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_clear_api_delegate> efl_loop_message_handler_message_clear_ptr = new Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_clear_api_delegate>(Module, "efl_loop_message_handler_message_clear");

        private static bool message_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_loop_message_handler_message_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((LoopMessageHandler)ws.Target).ClearMessage();
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
                return efl_loop_message_handler_message_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_loop_message_handler_message_clear_delegate efl_loop_message_handler_message_clear_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflLoopMessageHandler_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
