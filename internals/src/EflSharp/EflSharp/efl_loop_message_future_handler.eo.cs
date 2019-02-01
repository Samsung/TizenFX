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
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.LoopMessageFutureHandlerNativeInherit nativeInherit = new Efl.LoopMessageFutureHandlerNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (LoopMessageFutureHandler))
            return Efl.LoopMessageFutureHandlerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(LoopMessageFutureHandler obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_loop_message_future_handler_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public LoopMessageFutureHandler(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("LoopMessageFutureHandler", efl_loop_message_future_handler_class_get(), typeof(LoopMessageFutureHandler), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected LoopMessageFutureHandler(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public LoopMessageFutureHandler(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static LoopMessageFutureHandler static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new LoopMessageFutureHandler(obj.NativeHandle);
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
private static object MessageFutureEvtKey = new object();
   /// <summary>No description supplied.</summary>
   public event EventHandler<Efl.LoopMessageFutureHandlerMessageFutureEvt_Args> MessageFutureEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LOOP_MESSAGE_FUTURE_HANDLER_EVENT_MESSAGE_FUTURE";
            if (add_cpp_event_handler(key, this.evt_MessageFutureEvt_delegate)) {
               eventHandlers.AddHandler(MessageFutureEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LOOP_MESSAGE_FUTURE_HANDLER_EVENT_MESSAGE_FUTURE";
            if (remove_cpp_event_handler(key, this.evt_MessageFutureEvt_delegate)) { 
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
   private void on_MessageFutureEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.LoopMessageFutureHandlerMessageFutureEvt_Args args = new Efl.LoopMessageFutureHandlerMessageFutureEvt_Args();
      args.arg = new Efl.LoopMessageFuture(evt.Info);
      try {
         On_MessageFutureEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_MessageFutureEvt_delegate = new Efl.EventCb(on_MessageFutureEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.LoopMessageFuture, Efl.Eo.NonOwnTag>))] protected static extern Efl.LoopMessageFuture efl_loop_message_future_handler_message_type_add(System.IntPtr obj);
   /// <summary>No description supplied.</summary>
   /// <returns>No description supplied.</returns>
   virtual public Efl.LoopMessageFuture AddMessageType() {
       var _ret_var = efl_loop_message_future_handler_message_type_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
}
public class LoopMessageFutureHandlerNativeInherit : Efl.LoopMessageHandlerNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_loop_message_future_handler_message_type_add_static_delegate = new efl_loop_message_future_handler_message_type_add_delegate(message_type_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_message_future_handler_message_type_add"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_future_handler_message_type_add_static_delegate)});
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


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.LoopMessageFuture, Efl.Eo.NonOwnTag>))] private delegate Efl.LoopMessageFuture efl_loop_message_future_handler_message_type_add_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.LoopMessageFuture, Efl.Eo.NonOwnTag>))] private static extern Efl.LoopMessageFuture efl_loop_message_future_handler_message_type_add(System.IntPtr obj);
    private static Efl.LoopMessageFuture message_type_add(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_message_future_handler_message_type_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
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
         return efl_loop_message_future_handler_message_type_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_loop_message_future_handler_message_type_add_delegate efl_loop_message_future_handler_message_type_add_static_delegate;
}
} 
