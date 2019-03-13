#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
///<summary>Event argument wrapper for event <see cref="Efl.LoopMessage.MessageEvt"/>.</summary>
public class LoopMessageMessageEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.LoopMessage arg { get; set; }
}
/// <summary>Base message payload object class. Inherit this and extend for specific message types.</summary>
[LoopMessageNativeInherit]
public class LoopMessage : Efl.Object, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.LoopMessageNativeInherit nativeInherit = new Efl.LoopMessageNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (LoopMessage))
            return Efl.LoopMessageNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_loop_message_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public LoopMessage(Efl.Object parent= null
         ) :
      base(efl_loop_message_class_get(), typeof(LoopMessage), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public LoopMessage(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected LoopMessage(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static LoopMessage static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new LoopMessage(obj.NativeHandle);
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
   public event EventHandler<Efl.LoopMessageMessageEvt_Args> MessageEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_LOOP_MESSAGE_EVENT_MESSAGE";
            if (add_cpp_event_handler(efl.Libs.Ecore, key, this.evt_MessageEvt_delegate)) {
               eventHandlers.AddHandler(MessageEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_LOOP_MESSAGE_EVENT_MESSAGE";
            if (remove_cpp_event_handler(key, this.evt_MessageEvt_delegate)) { 
               eventHandlers.RemoveHandler(MessageEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event MessageEvt.</summary>
   public void On_MessageEvt(Efl.LoopMessageMessageEvt_Args e)
   {
      EventHandler<Efl.LoopMessageMessageEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.LoopMessageMessageEvt_Args>)eventHandlers[MessageEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_MessageEvt_delegate;
   private void on_MessageEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.LoopMessageMessageEvt_Args args = new Efl.LoopMessageMessageEvt_Args();
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
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.LoopMessage.efl_loop_message_class_get();
   }
}
public class LoopMessageNativeInherit : Efl.ObjectNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Ecore);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.LoopMessage.efl_loop_message_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.LoopMessage.efl_loop_message_class_get();
   }
}
} 
