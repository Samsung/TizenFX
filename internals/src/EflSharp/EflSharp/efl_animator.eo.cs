#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl animator interface</summary>
[AnimatorConcreteNativeInherit]
public interface Animator : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Animator tick synchronized with screen vsync if possible.</summary>
   event EventHandler<Efl.AnimatorAnimatorTickEvt_Args> AnimatorTickEvt;
}
///<summary>Event argument wrapper for event <see cref="Efl.Animator.AnimatorTickEvt"/>.</summary>
public class AnimatorAnimatorTickEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.EventAnimatorTick arg { get; set; }
}
/// <summary>Efl animator interface</summary>
sealed public class AnimatorConcrete : 

Animator
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (AnimatorConcrete))
            return Efl.AnimatorConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private EventHandlerList eventHandlers = new EventHandlerList();
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_animator_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public AnimatorConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~AnimatorConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static AnimatorConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new AnimatorConcrete(obj.NativeHandle);
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
   private readonly object eventLock = new object();
   private Dictionary<string, int> event_cb_count = new Dictionary<string, int>();
   private bool add_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 0) {
         IntPtr desc = Efl.EventDescription.GetNative(key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
          bool result = Efl.Eo.Globals.efl_event_callback_priority_add(handle, desc, 0, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to add event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } 
      event_cb_count[key]++;
      return true;
   }
   private bool remove_cpp_event_handler(string key, Efl.EventCb evt_delegate) {
      int event_count = 0;
      if (!event_cb_count.TryGetValue(key, out event_count))
         event_cb_count[key] = event_count;
      if (event_count == 1) {
         IntPtr desc = Efl.EventDescription.GetNative(key);
         if (desc == IntPtr.Zero) {
            Eina.Log.Error($"Failed to get native event {key}");
            return false;
         }
         bool result = Efl.Eo.Globals.efl_event_callback_del(handle, desc, evt_delegate, System.IntPtr.Zero);
         if (!result) {
            Eina.Log.Error($"Failed to remove event proxy for event {key}");
            return false;
         }
         Eina.Error.RaiseIfUnhandledException();
      } else if (event_count == 0) {
         Eina.Log.Error($"Trying to remove proxy for event {key} when there is nothing registered.");
         return false;
      } 
      event_cb_count[key]--;
      return true;
   }
private static object AnimatorTickEvtKey = new object();
   /// <summary>Animator tick synchronized with screen vsync if possible.</summary>
   public event EventHandler<Efl.AnimatorAnimatorTickEvt_Args> AnimatorTickEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_ANIMATOR_TICK";
            if (add_cpp_event_handler(key, this.evt_AnimatorTickEvt_delegate)) {
               eventHandlers.AddHandler(AnimatorTickEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_ANIMATOR_TICK";
            if (remove_cpp_event_handler(key, this.evt_AnimatorTickEvt_delegate)) { 
               eventHandlers.RemoveHandler(AnimatorTickEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event AnimatorTickEvt.</summary>
   public void On_AnimatorTickEvt(Efl.AnimatorAnimatorTickEvt_Args e)
   {
      EventHandler<Efl.AnimatorAnimatorTickEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.AnimatorAnimatorTickEvt_Args>)eventHandlers[AnimatorTickEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_AnimatorTickEvt_delegate;
   private void on_AnimatorTickEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.AnimatorAnimatorTickEvt_Args args = new Efl.AnimatorAnimatorTickEvt_Args();
      args.arg =  evt.Info;;
      try {
         On_AnimatorTickEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

    void register_event_proxies()
   {
      evt_AnimatorTickEvt_delegate = new Efl.EventCb(on_AnimatorTickEvt_NativeCallback);
   }
}
public class AnimatorConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.AnimatorConcrete.efl_animator_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.AnimatorConcrete.efl_animator_interface_get();
   }
}
} 
namespace Efl { 
/// <summary>EFL event animator tick data structure</summary>
[StructLayout(LayoutKind.Sequential)]
public struct EventAnimatorTick
{
   /// <summary>Area of the canvas that will be pushed to screen.</summary>
   public Eina.Rect Update_area;
   ///<summary>Constructor for EventAnimatorTick.</summary>
   public EventAnimatorTick(
      Eina.Rect Update_area=default(Eina.Rect)   )
   {
      this.Update_area = Update_area;
   }
public static implicit operator EventAnimatorTick(IntPtr ptr)
   {
      var tmp = (EventAnimatorTick_StructInternal)Marshal.PtrToStructure(ptr, typeof(EventAnimatorTick_StructInternal));
      return EventAnimatorTick_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct EventAnimatorTick.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct EventAnimatorTick_StructInternal
{
   
   public Eina.Rect_StructInternal Update_area;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator EventAnimatorTick(EventAnimatorTick_StructInternal struct_)
   {
      return EventAnimatorTick_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator EventAnimatorTick_StructInternal(EventAnimatorTick struct_)
   {
      return EventAnimatorTick_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct EventAnimatorTick</summary>
public static class EventAnimatorTick_StructConversion
{
   internal static EventAnimatorTick_StructInternal ToInternal(EventAnimatorTick _external_struct)
   {
      var _internal_struct = new EventAnimatorTick_StructInternal();

      _internal_struct.Update_area = Eina.Rect_StructConversion.ToInternal(_external_struct.Update_area);

      return _internal_struct;
   }

   internal static EventAnimatorTick ToManaged(EventAnimatorTick_StructInternal _internal_struct)
   {
      var _external_struct = new EventAnimatorTick();

      _external_struct.Update_area = Eina.Rect_StructConversion.ToManaged(_internal_struct.Update_area);

      return _external_struct;
   }

}
} 
