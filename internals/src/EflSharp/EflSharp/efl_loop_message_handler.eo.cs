#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
///<summary>Event argument wrapper for event <see cref="Efl.LoopMessageHandler.MessageEvt"/>.</summary>
public class LoopMessageHandlerMessageEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.LoopMessage arg { get; set; }
}
/// <summary>Message handlers represent a single message type on the Efl.Loop parent object. These message handlers can be used to listen for that message type by listening to the message event for the generic case or a class specific event type to get specific message object typing correct.</summary>
[LoopMessageHandlerNativeInherit]
public class LoopMessageHandler : Efl.Object, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.LoopMessageHandlerNativeInherit nativeInherit = new Efl.LoopMessageHandlerNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (LoopMessageHandler))
            return Efl.LoopMessageHandlerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_loop_message_handler_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public LoopMessageHandler(Efl.Object parent= null
         ) :
      base(efl_loop_message_handler_class_get(), typeof(LoopMessageHandler), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public LoopMessageHandler(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected LoopMessageHandler(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static LoopMessageHandler static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new LoopMessageHandler(obj.NativeHandle);
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
private static object MessageEvtKey = new object();
   /// <summary>The message payload data</summary>
   public event EventHandler<Efl.LoopMessageHandlerMessageEvt_Args> MessageEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LOOP_MESSAGE_HANDLER_EVENT_MESSAGE";
            if (add_cpp_event_handler(efl.Libs.Ecore, key, this.evt_MessageEvt_delegate)) {
               eventHandlers.AddHandler(MessageEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LOOP_MESSAGE_HANDLER_EVENT_MESSAGE";
            if (remove_cpp_event_handler(key, this.evt_MessageEvt_delegate)) { 
               eventHandlers.RemoveHandler(MessageEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event MessageEvt.</summary>
   public void On_MessageEvt(Efl.LoopMessageHandlerMessageEvt_Args e)
   {
      EventHandler<Efl.LoopMessageHandlerMessageEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.LoopMessageHandlerMessageEvt_Args>)eventHandlers[MessageEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_MessageEvt_delegate;
   private void on_MessageEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.LoopMessageHandlerMessageEvt_Args args = new Efl.LoopMessageHandlerMessageEvt_Args();
      args.arg = new Efl.LoopMessage(evt.Info);
      try {
         On_MessageEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_MessageEvt_delegate = new Efl.EventCb(on_MessageEvt_NativeCallback);
   }
   /// <summary>Creates a new message object of the correct type for this message type.</summary>
   /// <returns>The new message payload object.</returns>
   virtual public Efl.LoopMessage AddMessage() {
       var _ret_var = Efl.LoopMessageHandlerNativeInherit.efl_loop_message_handler_message_add_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Place the message on the queue to be called later when message_process() is called on the loop object.</summary>
   /// <param name="message">The message to place on the queue.</param>
   /// <returns></returns>
   virtual public  void MessageSend( Efl.LoopMessage message) {
                         Efl.LoopMessageHandlerNativeInherit.efl_loop_message_handler_message_send_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), message);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Overide me (implement) then call super after calling the right callback type if you specialize the message type.</summary>
   /// <param name="message">Generic message event type</param>
   /// <returns></returns>
   virtual public  void CallMessage( Efl.LoopMessage message) {
                         Efl.LoopMessageHandlerNativeInherit.efl_loop_message_handler_message_call_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), message);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Delete all queued messages belonging to this message handler that are pending on the queue so they are not processed later.</summary>
   /// <returns>True if any messages of this type were cleared.</returns>
   virtual public bool ClearMessage() {
       var _ret_var = Efl.LoopMessageHandlerNativeInherit.efl_loop_message_handler_message_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.LoopMessageHandler.efl_loop_message_handler_class_get();
   }
}
public class LoopMessageHandlerNativeInherit : Efl.ObjectNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_loop_message_handler_message_add_static_delegate == null)
      efl_loop_message_handler_message_add_static_delegate = new efl_loop_message_handler_message_add_delegate(message_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_message_handler_message_add"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_handler_message_add_static_delegate)});
      if (efl_loop_message_handler_message_send_static_delegate == null)
      efl_loop_message_handler_message_send_static_delegate = new efl_loop_message_handler_message_send_delegate(message_send);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_message_handler_message_send"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_handler_message_send_static_delegate)});
      if (efl_loop_message_handler_message_call_static_delegate == null)
      efl_loop_message_handler_message_call_static_delegate = new efl_loop_message_handler_message_call_delegate(message_call);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_message_handler_message_call"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_handler_message_call_static_delegate)});
      if (efl_loop_message_handler_message_clear_static_delegate == null)
      efl_loop_message_handler_message_clear_static_delegate = new efl_loop_message_handler_message_clear_delegate(message_clear);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_loop_message_handler_message_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_handler_message_clear_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.LoopMessageHandler.efl_loop_message_handler_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.LoopMessageHandler.efl_loop_message_handler_class_get();
   }


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.LoopMessage, Efl.Eo.NonOwnTag>))] private delegate Efl.LoopMessage efl_loop_message_handler_message_add_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.LoopMessage, Efl.Eo.NonOwnTag>))] public delegate Efl.LoopMessage efl_loop_message_handler_message_add_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_add_api_delegate> efl_loop_message_handler_message_add_ptr = new Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_add_api_delegate>(_Module, "efl_loop_message_handler_message_add");
    private static Efl.LoopMessage message_add(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_message_handler_message_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.LoopMessage _ret_var = default(Efl.LoopMessage);
         try {
            _ret_var = ((LoopMessageHandler)wrapper).AddMessage();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_loop_message_handler_message_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_loop_message_handler_message_add_delegate efl_loop_message_handler_message_add_static_delegate;


    private delegate  void efl_loop_message_handler_message_send_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.LoopMessage, Efl.Eo.NonOwnTag>))]  Efl.LoopMessage message);


    public delegate  void efl_loop_message_handler_message_send_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.LoopMessage, Efl.Eo.NonOwnTag>))]  Efl.LoopMessage message);
    public static Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_send_api_delegate> efl_loop_message_handler_message_send_ptr = new Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_send_api_delegate>(_Module, "efl_loop_message_handler_message_send");
    private static  void message_send(System.IntPtr obj, System.IntPtr pd,  Efl.LoopMessage message)
   {
      Eina.Log.Debug("function efl_loop_message_handler_message_send was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LoopMessageHandler)wrapper).MessageSend( message);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_loop_message_handler_message_send_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  message);
      }
   }
   private static efl_loop_message_handler_message_send_delegate efl_loop_message_handler_message_send_static_delegate;


    private delegate  void efl_loop_message_handler_message_call_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.LoopMessage, Efl.Eo.NonOwnTag>))]  Efl.LoopMessage message);


    public delegate  void efl_loop_message_handler_message_call_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.LoopMessage, Efl.Eo.NonOwnTag>))]  Efl.LoopMessage message);
    public static Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_call_api_delegate> efl_loop_message_handler_message_call_ptr = new Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_call_api_delegate>(_Module, "efl_loop_message_handler_message_call");
    private static  void message_call(System.IntPtr obj, System.IntPtr pd,  Efl.LoopMessage message)
   {
      Eina.Log.Debug("function efl_loop_message_handler_message_call was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LoopMessageHandler)wrapper).CallMessage( message);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_loop_message_handler_message_call_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  message);
      }
   }
   private static efl_loop_message_handler_message_call_delegate efl_loop_message_handler_message_call_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_loop_message_handler_message_clear_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_loop_message_handler_message_clear_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_clear_api_delegate> efl_loop_message_handler_message_clear_ptr = new Efl.Eo.FunctionWrapper<efl_loop_message_handler_message_clear_api_delegate>(_Module, "efl_loop_message_handler_message_clear");
    private static bool message_clear(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_message_handler_message_clear was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((LoopMessageHandler)wrapper).ClearMessage();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_loop_message_handler_message_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_loop_message_handler_message_clear_delegate efl_loop_message_handler_message_clear_static_delegate;
}
} 
