#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
///<summary>Event argument wrapper for event <see cref="Efl.LoopMessageFutureHandler.MessageFutureEvt"/>.</summary>
public class LoopMessageFutureHandlerMessageFutureEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.LoopMessageFuture arg { get; set; }
}
/// <summary>Internal use for future on an efl loop - replacing legacy ecore events</summary>
[LoopMessageFutureHandlerNativeInherit]
public class LoopMessageFutureHandler : Efl.LoopMessageHandler, Efl.Eo.IWrapper
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (LoopMessageFutureHandler))
                return Efl.LoopMessageFutureHandlerNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_loop_message_future_handler_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public LoopMessageFutureHandler(Efl.Object parent= null
            ) :
        base(efl_loop_message_future_handler_class_get(), typeof(LoopMessageFutureHandler), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected LoopMessageFutureHandler(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected LoopMessageFutureHandler(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
private static object MessageFutureEvtKey = new object();
    /// <summary>No description supplied.</summary>
    public event EventHandler<Efl.LoopMessageFutureHandlerMessageFutureEvt_Args> MessageFutureEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_LOOP_MESSAGE_FUTURE_HANDLER_EVENT_MESSAGE_FUTURE";
                if (AddNativeEventHandler(efl.Libs.Ecore, key, this.evt_MessageFutureEvt_delegate)) {
                    eventHandlers.AddHandler(MessageFutureEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_LOOP_MESSAGE_FUTURE_HANDLER_EVENT_MESSAGE_FUTURE";
                if (RemoveNativeEventHandler(key, this.evt_MessageFutureEvt_delegate)) { 
                    eventHandlers.RemoveHandler(MessageFutureEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event MessageFutureEvt.</summary>
    public void On_MessageFutureEvt(Efl.LoopMessageFutureHandlerMessageFutureEvt_Args e)
    {
        EventHandler<Efl.LoopMessageFutureHandlerMessageFutureEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.LoopMessageFutureHandlerMessageFutureEvt_Args>)eventHandlers[MessageFutureEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_MessageFutureEvt_delegate;
    private void on_MessageFutureEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.LoopMessageFutureHandlerMessageFutureEvt_Args args = new Efl.LoopMessageFutureHandlerMessageFutureEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.LoopMessageFuture);
        try {
            On_MessageFutureEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_MessageFutureEvt_delegate = new Efl.EventCb(on_MessageFutureEvt_NativeCallback);
    }
    /// <summary>No description supplied.</summary>
    /// <returns>No description supplied.</returns>
    virtual public Efl.LoopMessageFuture AddMessageType() {
         var _ret_var = Efl.LoopMessageFutureHandlerNativeInherit.efl_loop_message_future_handler_message_type_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.LoopMessageFutureHandler.efl_loop_message_future_handler_class_get();
    }
}
public class LoopMessageFutureHandlerNativeInherit : Efl.LoopMessageHandlerNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_loop_message_future_handler_message_type_add_static_delegate == null)
            efl_loop_message_future_handler_message_type_add_static_delegate = new efl_loop_message_future_handler_message_type_add_delegate(message_type_add);
        if (methods.FirstOrDefault(m => m.Name == "AddMessageType") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_message_future_handler_message_type_add"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_future_handler_message_type_add_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.LoopMessageFutureHandler.efl_loop_message_future_handler_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.LoopMessageFutureHandler.efl_loop_message_future_handler_class_get();
    }


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.LoopMessageFuture, Efl.Eo.NonOwnTag>))] private delegate Efl.LoopMessageFuture efl_loop_message_future_handler_message_type_add_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.LoopMessageFuture, Efl.Eo.NonOwnTag>))] public delegate Efl.LoopMessageFuture efl_loop_message_future_handler_message_type_add_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_loop_message_future_handler_message_type_add_api_delegate> efl_loop_message_future_handler_message_type_add_ptr = new Efl.Eo.FunctionWrapper<efl_loop_message_future_handler_message_type_add_api_delegate>(_Module, "efl_loop_message_future_handler_message_type_add");
     private static Efl.LoopMessageFuture message_type_add(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_loop_message_future_handler_message_type_add was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.LoopMessageFuture _ret_var = default(Efl.LoopMessageFuture);
            try {
                _ret_var = ((LoopMessageFutureHandler)wrapper).AddMessageType();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_loop_message_future_handler_message_type_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_loop_message_future_handler_message_type_add_delegate efl_loop_message_future_handler_message_type_add_static_delegate;
}
} 
