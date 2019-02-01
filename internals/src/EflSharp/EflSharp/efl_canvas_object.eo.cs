#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Object.Anim_startedEvt"/>.</summary>
public class ObjectAnim_startedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Canvas.ObjectAnimationEvent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Object.Anim_runningEvt"/>.</summary>
public class ObjectAnim_runningEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Canvas.ObjectAnimationEvent arg { get; set; }
}
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.Object.Anim_endedEvt"/>.</summary>
public class ObjectAnim_endedEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Canvas.ObjectAnimationEvent arg { get; set; }
}
/// <summary>Efl canvas object abstract class</summary>
[ObjectNativeInherit]
public class Object : Efl.LoopConsumer, Efl.Eo.IWrapper,Efl.Animator,Efl.Canvas.Pointer,Efl.Gfx.Color,Efl.Gfx.Entity,Efl.Gfx.Map,Efl.Gfx.SizeHint,Efl.Gfx.Stack,Efl.Input.Interface,Efl.Ui.I18n
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.ObjectNativeInherit nativeInherit = new Efl.Canvas.ObjectNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Object))
            return Efl.Canvas.ObjectNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Object obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_object_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Object(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Object", efl_canvas_object_class_get(), typeof(Object), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Object(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Object(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Object static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Object(obj.NativeHandle);
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
private static object Anim_startedEvtKey = new object();
   /// <summary>Animation is started.</summary>
   public event EventHandler<Efl.Canvas.ObjectAnim_startedEvt_Args> Anim_startedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_OBJECT_EVENT_ANIM_STARTED";
            if (add_cpp_event_handler(key, this.evt_Anim_startedEvt_delegate)) {
               eventHandlers.AddHandler(Anim_startedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_OBJECT_EVENT_ANIM_STARTED";
            if (remove_cpp_event_handler(key, this.evt_Anim_startedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Anim_startedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Anim_startedEvt.</summary>
   public void On_Anim_startedEvt(Efl.Canvas.ObjectAnim_startedEvt_Args e)
   {
      EventHandler<Efl.Canvas.ObjectAnim_startedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.ObjectAnim_startedEvt_Args>)eventHandlers[Anim_startedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Anim_startedEvt_delegate;
   private void on_Anim_startedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.ObjectAnim_startedEvt_Args args = new Efl.Canvas.ObjectAnim_startedEvt_Args();
      args.arg = default(Efl.Canvas.ObjectAnimationEvent);
      try {
         On_Anim_startedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Anim_runningEvtKey = new object();
   /// <summary>Animation is running.</summary>
   public event EventHandler<Efl.Canvas.ObjectAnim_runningEvt_Args> Anim_runningEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_OBJECT_EVENT_ANIM_RUNNING";
            if (add_cpp_event_handler(key, this.evt_Anim_runningEvt_delegate)) {
               eventHandlers.AddHandler(Anim_runningEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_OBJECT_EVENT_ANIM_RUNNING";
            if (remove_cpp_event_handler(key, this.evt_Anim_runningEvt_delegate)) { 
               eventHandlers.RemoveHandler(Anim_runningEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Anim_runningEvt.</summary>
   public void On_Anim_runningEvt(Efl.Canvas.ObjectAnim_runningEvt_Args e)
   {
      EventHandler<Efl.Canvas.ObjectAnim_runningEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.ObjectAnim_runningEvt_Args>)eventHandlers[Anim_runningEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Anim_runningEvt_delegate;
   private void on_Anim_runningEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.ObjectAnim_runningEvt_Args args = new Efl.Canvas.ObjectAnim_runningEvt_Args();
      args.arg = default(Efl.Canvas.ObjectAnimationEvent);
      try {
         On_Anim_runningEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object Anim_endedEvtKey = new object();
   /// <summary>Animation is ended.</summary>
   public event EventHandler<Efl.Canvas.ObjectAnim_endedEvt_Args> Anim_endedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CANVAS_OBJECT_EVENT_ANIM_ENDED";
            if (add_cpp_event_handler(key, this.evt_Anim_endedEvt_delegate)) {
               eventHandlers.AddHandler(Anim_endedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CANVAS_OBJECT_EVENT_ANIM_ENDED";
            if (remove_cpp_event_handler(key, this.evt_Anim_endedEvt_delegate)) { 
               eventHandlers.RemoveHandler(Anim_endedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event Anim_endedEvt.</summary>
   public void On_Anim_endedEvt(Efl.Canvas.ObjectAnim_endedEvt_Args e)
   {
      EventHandler<Efl.Canvas.ObjectAnim_endedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.ObjectAnim_endedEvt_Args>)eventHandlers[Anim_endedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_Anim_endedEvt_delegate;
   private void on_Anim_endedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.ObjectAnim_endedEvt_Args args = new Efl.Canvas.ObjectAnim_endedEvt_Args();
      args.arg = default(Efl.Canvas.ObjectAnimationEvent);
      try {
         On_Anim_endedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
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

private static object ShowEvtKey = new object();
   /// <summary>Object just became visible.</summary>
   public event EventHandler ShowEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_SHOW";
            if (add_cpp_event_handler(key, this.evt_ShowEvt_delegate)) {
               eventHandlers.AddHandler(ShowEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_SHOW";
            if (remove_cpp_event_handler(key, this.evt_ShowEvt_delegate)) { 
               eventHandlers.RemoveHandler(ShowEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ShowEvt.</summary>
   public void On_ShowEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ShowEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ShowEvt_delegate;
   private void on_ShowEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ShowEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object HideEvtKey = new object();
   /// <summary>Object just became invisible.</summary>
   public event EventHandler HideEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_HIDE";
            if (add_cpp_event_handler(key, this.evt_HideEvt_delegate)) {
               eventHandlers.AddHandler(HideEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_HIDE";
            if (remove_cpp_event_handler(key, this.evt_HideEvt_delegate)) { 
               eventHandlers.RemoveHandler(HideEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event HideEvt.</summary>
   public void On_HideEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[HideEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_HideEvt_delegate;
   private void on_HideEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_HideEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object MoveEvtKey = new object();
   /// <summary>Object was moved, its position during the event is the new one.</summary>
   public event EventHandler MoveEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_MOVE";
            if (add_cpp_event_handler(key, this.evt_MoveEvt_delegate)) {
               eventHandlers.AddHandler(MoveEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_MOVE";
            if (remove_cpp_event_handler(key, this.evt_MoveEvt_delegate)) { 
               eventHandlers.RemoveHandler(MoveEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event MoveEvt.</summary>
   public void On_MoveEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[MoveEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_MoveEvt_delegate;
   private void on_MoveEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_MoveEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ResizeEvtKey = new object();
   /// <summary>Object was resized, its size during the event is the new one.</summary>
   public event EventHandler ResizeEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_RESIZE";
            if (add_cpp_event_handler(key, this.evt_ResizeEvt_delegate)) {
               eventHandlers.AddHandler(ResizeEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_RESIZE";
            if (remove_cpp_event_handler(key, this.evt_ResizeEvt_delegate)) { 
               eventHandlers.RemoveHandler(ResizeEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ResizeEvt.</summary>
   public void On_ResizeEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ResizeEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ResizeEvt_delegate;
   private void on_ResizeEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ResizeEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object ChangeSizeHintsEvtKey = new object();
   /// <summary>Object size hints changed.</summary>
   public event EventHandler ChangeSizeHintsEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_CHANGE_SIZE_HINTS";
            if (add_cpp_event_handler(key, this.evt_ChangeSizeHintsEvt_delegate)) {
               eventHandlers.AddHandler(ChangeSizeHintsEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_CHANGE_SIZE_HINTS";
            if (remove_cpp_event_handler(key, this.evt_ChangeSizeHintsEvt_delegate)) { 
               eventHandlers.RemoveHandler(ChangeSizeHintsEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ChangeSizeHintsEvt.</summary>
   public void On_ChangeSizeHintsEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[ChangeSizeHintsEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ChangeSizeHintsEvt_delegate;
   private void on_ChangeSizeHintsEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_ChangeSizeHintsEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object RestackEvtKey = new object();
   /// <summary>Object stacking was changed.</summary>
   public event EventHandler RestackEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_RESTACK";
            if (add_cpp_event_handler(key, this.evt_RestackEvt_delegate)) {
               eventHandlers.AddHandler(RestackEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_GFX_ENTITY_EVENT_RESTACK";
            if (remove_cpp_event_handler(key, this.evt_RestackEvt_delegate)) { 
               eventHandlers.RemoveHandler(RestackEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event RestackEvt.</summary>
   public void On_RestackEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[RestackEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_RestackEvt_delegate;
   private void on_RestackEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_RestackEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerMoveEvtKey = new object();
   /// <summary>Main pointer move (current and previous positions are known).
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerMoveEvt_Args> PointerMoveEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_MOVE";
            if (add_cpp_event_handler(key, this.evt_PointerMoveEvt_delegate)) {
               eventHandlers.AddHandler(PointerMoveEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_MOVE";
            if (remove_cpp_event_handler(key, this.evt_PointerMoveEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerMoveEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerMoveEvt.</summary>
   public void On_PointerMoveEvt(Efl.Input.InterfacePointerMoveEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerMoveEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerMoveEvt_Args>)eventHandlers[PointerMoveEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerMoveEvt_delegate;
   private void on_PointerMoveEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerMoveEvt_Args args = new Efl.Input.InterfacePointerMoveEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerMoveEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerDownEvtKey = new object();
   /// <summary>Main pointer button pressed (button id is known).
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerDownEvt_Args> PointerDownEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_DOWN";
            if (add_cpp_event_handler(key, this.evt_PointerDownEvt_delegate)) {
               eventHandlers.AddHandler(PointerDownEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_DOWN";
            if (remove_cpp_event_handler(key, this.evt_PointerDownEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerDownEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerDownEvt.</summary>
   public void On_PointerDownEvt(Efl.Input.InterfacePointerDownEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerDownEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerDownEvt_Args>)eventHandlers[PointerDownEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerDownEvt_delegate;
   private void on_PointerDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerDownEvt_Args args = new Efl.Input.InterfacePointerDownEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerDownEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerUpEvtKey = new object();
   /// <summary>Main pointer button released (button id is known).
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerUpEvt_Args> PointerUpEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_UP";
            if (add_cpp_event_handler(key, this.evt_PointerUpEvt_delegate)) {
               eventHandlers.AddHandler(PointerUpEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_UP";
            if (remove_cpp_event_handler(key, this.evt_PointerUpEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerUpEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerUpEvt.</summary>
   public void On_PointerUpEvt(Efl.Input.InterfacePointerUpEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerUpEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerUpEvt_Args>)eventHandlers[PointerUpEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerUpEvt_delegate;
   private void on_PointerUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerUpEvt_Args args = new Efl.Input.InterfacePointerUpEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerUpEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerCancelEvtKey = new object();
   /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerCancelEvt_Args> PointerCancelEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_CANCEL";
            if (add_cpp_event_handler(key, this.evt_PointerCancelEvt_delegate)) {
               eventHandlers.AddHandler(PointerCancelEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_CANCEL";
            if (remove_cpp_event_handler(key, this.evt_PointerCancelEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerCancelEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerCancelEvt.</summary>
   public void On_PointerCancelEvt(Efl.Input.InterfacePointerCancelEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerCancelEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerCancelEvt_Args>)eventHandlers[PointerCancelEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerCancelEvt_delegate;
   private void on_PointerCancelEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerCancelEvt_Args args = new Efl.Input.InterfacePointerCancelEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerCancelEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerInEvtKey = new object();
   /// <summary>Pointer entered a window or a widget.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerInEvt_Args> PointerInEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_IN";
            if (add_cpp_event_handler(key, this.evt_PointerInEvt_delegate)) {
               eventHandlers.AddHandler(PointerInEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_IN";
            if (remove_cpp_event_handler(key, this.evt_PointerInEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerInEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerInEvt.</summary>
   public void On_PointerInEvt(Efl.Input.InterfacePointerInEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerInEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerInEvt_Args>)eventHandlers[PointerInEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerInEvt_delegate;
   private void on_PointerInEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerInEvt_Args args = new Efl.Input.InterfacePointerInEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerInEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerOutEvtKey = new object();
   /// <summary>Pointer left a window or a widget.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerOutEvt_Args> PointerOutEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_OUT";
            if (add_cpp_event_handler(key, this.evt_PointerOutEvt_delegate)) {
               eventHandlers.AddHandler(PointerOutEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_OUT";
            if (remove_cpp_event_handler(key, this.evt_PointerOutEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerOutEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerOutEvt.</summary>
   public void On_PointerOutEvt(Efl.Input.InterfacePointerOutEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerOutEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerOutEvt_Args>)eventHandlers[PointerOutEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerOutEvt_delegate;
   private void on_PointerOutEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerOutEvt_Args args = new Efl.Input.InterfacePointerOutEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerOutEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerWheelEvtKey = new object();
   /// <summary>Mouse wheel event.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerWheelEvt_Args> PointerWheelEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_WHEEL";
            if (add_cpp_event_handler(key, this.evt_PointerWheelEvt_delegate)) {
               eventHandlers.AddHandler(PointerWheelEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_WHEEL";
            if (remove_cpp_event_handler(key, this.evt_PointerWheelEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerWheelEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerWheelEvt.</summary>
   public void On_PointerWheelEvt(Efl.Input.InterfacePointerWheelEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerWheelEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerWheelEvt_Args>)eventHandlers[PointerWheelEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerWheelEvt_delegate;
   private void on_PointerWheelEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerWheelEvt_Args args = new Efl.Input.InterfacePointerWheelEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerWheelEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object PointerAxisEvtKey = new object();
   /// <summary>Pen or other axis event update.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfacePointerAxisEvt_Args> PointerAxisEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_AXIS";
            if (add_cpp_event_handler(key, this.evt_PointerAxisEvt_delegate)) {
               eventHandlers.AddHandler(PointerAxisEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_POINTER_AXIS";
            if (remove_cpp_event_handler(key, this.evt_PointerAxisEvt_delegate)) { 
               eventHandlers.RemoveHandler(PointerAxisEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event PointerAxisEvt.</summary>
   public void On_PointerAxisEvt(Efl.Input.InterfacePointerAxisEvt_Args e)
   {
      EventHandler<Efl.Input.InterfacePointerAxisEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfacePointerAxisEvt_Args>)eventHandlers[PointerAxisEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_PointerAxisEvt_delegate;
   private void on_PointerAxisEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfacePointerAxisEvt_Args args = new Efl.Input.InterfacePointerAxisEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_PointerAxisEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object FingerMoveEvtKey = new object();
   /// <summary>Finger moved (current and previous positions are known).
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceFingerMoveEvt_Args> FingerMoveEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_FINGER_MOVE";
            if (add_cpp_event_handler(key, this.evt_FingerMoveEvt_delegate)) {
               eventHandlers.AddHandler(FingerMoveEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_FINGER_MOVE";
            if (remove_cpp_event_handler(key, this.evt_FingerMoveEvt_delegate)) { 
               eventHandlers.RemoveHandler(FingerMoveEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FingerMoveEvt.</summary>
   public void On_FingerMoveEvt(Efl.Input.InterfaceFingerMoveEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceFingerMoveEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceFingerMoveEvt_Args>)eventHandlers[FingerMoveEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FingerMoveEvt_delegate;
   private void on_FingerMoveEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceFingerMoveEvt_Args args = new Efl.Input.InterfaceFingerMoveEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_FingerMoveEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object FingerDownEvtKey = new object();
   /// <summary>Finger pressed (finger id is known).
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceFingerDownEvt_Args> FingerDownEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_FINGER_DOWN";
            if (add_cpp_event_handler(key, this.evt_FingerDownEvt_delegate)) {
               eventHandlers.AddHandler(FingerDownEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_FINGER_DOWN";
            if (remove_cpp_event_handler(key, this.evt_FingerDownEvt_delegate)) { 
               eventHandlers.RemoveHandler(FingerDownEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FingerDownEvt.</summary>
   public void On_FingerDownEvt(Efl.Input.InterfaceFingerDownEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceFingerDownEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceFingerDownEvt_Args>)eventHandlers[FingerDownEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FingerDownEvt_delegate;
   private void on_FingerDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceFingerDownEvt_Args args = new Efl.Input.InterfaceFingerDownEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_FingerDownEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object FingerUpEvtKey = new object();
   /// <summary>Finger released (finger id is known).
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceFingerUpEvt_Args> FingerUpEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_FINGER_UP";
            if (add_cpp_event_handler(key, this.evt_FingerUpEvt_delegate)) {
               eventHandlers.AddHandler(FingerUpEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_FINGER_UP";
            if (remove_cpp_event_handler(key, this.evt_FingerUpEvt_delegate)) { 
               eventHandlers.RemoveHandler(FingerUpEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FingerUpEvt.</summary>
   public void On_FingerUpEvt(Efl.Input.InterfaceFingerUpEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceFingerUpEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceFingerUpEvt_Args>)eventHandlers[FingerUpEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FingerUpEvt_delegate;
   private void on_FingerUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceFingerUpEvt_Args args = new Efl.Input.InterfaceFingerUpEvt_Args();
      args.arg = new Efl.Input.Pointer(evt.Info);
      try {
         On_FingerUpEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object KeyDownEvtKey = new object();
   /// <summary>Keyboard key press.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceKeyDownEvt_Args> KeyDownEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_KEY_DOWN";
            if (add_cpp_event_handler(key, this.evt_KeyDownEvt_delegate)) {
               eventHandlers.AddHandler(KeyDownEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_KEY_DOWN";
            if (remove_cpp_event_handler(key, this.evt_KeyDownEvt_delegate)) { 
               eventHandlers.RemoveHandler(KeyDownEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event KeyDownEvt.</summary>
   public void On_KeyDownEvt(Efl.Input.InterfaceKeyDownEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceKeyDownEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceKeyDownEvt_Args>)eventHandlers[KeyDownEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_KeyDownEvt_delegate;
   private void on_KeyDownEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceKeyDownEvt_Args args = new Efl.Input.InterfaceKeyDownEvt_Args();
      args.arg = new Efl.Input.Key(evt.Info);
      try {
         On_KeyDownEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object KeyUpEvtKey = new object();
   /// <summary>Keyboard key release.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceKeyUpEvt_Args> KeyUpEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_KEY_UP";
            if (add_cpp_event_handler(key, this.evt_KeyUpEvt_delegate)) {
               eventHandlers.AddHandler(KeyUpEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_KEY_UP";
            if (remove_cpp_event_handler(key, this.evt_KeyUpEvt_delegate)) { 
               eventHandlers.RemoveHandler(KeyUpEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event KeyUpEvt.</summary>
   public void On_KeyUpEvt(Efl.Input.InterfaceKeyUpEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceKeyUpEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceKeyUpEvt_Args>)eventHandlers[KeyUpEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_KeyUpEvt_delegate;
   private void on_KeyUpEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceKeyUpEvt_Args args = new Efl.Input.InterfaceKeyUpEvt_Args();
      args.arg = new Efl.Input.Key(evt.Info);
      try {
         On_KeyUpEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object HoldEvtKey = new object();
   /// <summary>All input events are on hold or resumed.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceHoldEvt_Args> HoldEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_HOLD";
            if (add_cpp_event_handler(key, this.evt_HoldEvt_delegate)) {
               eventHandlers.AddHandler(HoldEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_HOLD";
            if (remove_cpp_event_handler(key, this.evt_HoldEvt_delegate)) { 
               eventHandlers.RemoveHandler(HoldEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event HoldEvt.</summary>
   public void On_HoldEvt(Efl.Input.InterfaceHoldEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceHoldEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceHoldEvt_Args>)eventHandlers[HoldEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_HoldEvt_delegate;
   private void on_HoldEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceHoldEvt_Args args = new Efl.Input.InterfaceHoldEvt_Args();
      args.arg = new Efl.Input.Hold(evt.Info);
      try {
         On_HoldEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object FocusInEvtKey = new object();
   /// <summary>A focus in event.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceFocusInEvt_Args> FocusInEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_FOCUS_IN";
            if (add_cpp_event_handler(key, this.evt_FocusInEvt_delegate)) {
               eventHandlers.AddHandler(FocusInEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_FOCUS_IN";
            if (remove_cpp_event_handler(key, this.evt_FocusInEvt_delegate)) { 
               eventHandlers.RemoveHandler(FocusInEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FocusInEvt.</summary>
   public void On_FocusInEvt(Efl.Input.InterfaceFocusInEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceFocusInEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceFocusInEvt_Args>)eventHandlers[FocusInEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FocusInEvt_delegate;
   private void on_FocusInEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceFocusInEvt_Args args = new Efl.Input.InterfaceFocusInEvt_Args();
      args.arg = new Efl.Input.Focus(evt.Info);
      try {
         On_FocusInEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object FocusOutEvtKey = new object();
   /// <summary>A focus out event.
   /// 1.19</summary>
   public event EventHandler<Efl.Input.InterfaceFocusOutEvt_Args> FocusOutEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_EVENT_FOCUS_OUT";
            if (add_cpp_event_handler(key, this.evt_FocusOutEvt_delegate)) {
               eventHandlers.AddHandler(FocusOutEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_EVENT_FOCUS_OUT";
            if (remove_cpp_event_handler(key, this.evt_FocusOutEvt_delegate)) { 
               eventHandlers.RemoveHandler(FocusOutEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event FocusOutEvt.</summary>
   public void On_FocusOutEvt(Efl.Input.InterfaceFocusOutEvt_Args e)
   {
      EventHandler<Efl.Input.InterfaceFocusOutEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Input.InterfaceFocusOutEvt_Args>)eventHandlers[FocusOutEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_FocusOutEvt_delegate;
   private void on_FocusOutEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Input.InterfaceFocusOutEvt_Args args = new Efl.Input.InterfaceFocusOutEvt_Args();
      args.arg = new Efl.Input.Focus(evt.Info);
      try {
         On_FocusOutEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_Anim_startedEvt_delegate = new Efl.EventCb(on_Anim_startedEvt_NativeCallback);
      evt_Anim_runningEvt_delegate = new Efl.EventCb(on_Anim_runningEvt_NativeCallback);
      evt_Anim_endedEvt_delegate = new Efl.EventCb(on_Anim_endedEvt_NativeCallback);
      evt_AnimatorTickEvt_delegate = new Efl.EventCb(on_AnimatorTickEvt_NativeCallback);
      evt_ShowEvt_delegate = new Efl.EventCb(on_ShowEvt_NativeCallback);
      evt_HideEvt_delegate = new Efl.EventCb(on_HideEvt_NativeCallback);
      evt_MoveEvt_delegate = new Efl.EventCb(on_MoveEvt_NativeCallback);
      evt_ResizeEvt_delegate = new Efl.EventCb(on_ResizeEvt_NativeCallback);
      evt_ChangeSizeHintsEvt_delegate = new Efl.EventCb(on_ChangeSizeHintsEvt_NativeCallback);
      evt_RestackEvt_delegate = new Efl.EventCb(on_RestackEvt_NativeCallback);
      evt_PointerMoveEvt_delegate = new Efl.EventCb(on_PointerMoveEvt_NativeCallback);
      evt_PointerDownEvt_delegate = new Efl.EventCb(on_PointerDownEvt_NativeCallback);
      evt_PointerUpEvt_delegate = new Efl.EventCb(on_PointerUpEvt_NativeCallback);
      evt_PointerCancelEvt_delegate = new Efl.EventCb(on_PointerCancelEvt_NativeCallback);
      evt_PointerInEvt_delegate = new Efl.EventCb(on_PointerInEvt_NativeCallback);
      evt_PointerOutEvt_delegate = new Efl.EventCb(on_PointerOutEvt_NativeCallback);
      evt_PointerWheelEvt_delegate = new Efl.EventCb(on_PointerWheelEvt_NativeCallback);
      evt_PointerAxisEvt_delegate = new Efl.EventCb(on_PointerAxisEvt_NativeCallback);
      evt_FingerMoveEvt_delegate = new Efl.EventCb(on_FingerMoveEvt_NativeCallback);
      evt_FingerDownEvt_delegate = new Efl.EventCb(on_FingerDownEvt_NativeCallback);
      evt_FingerUpEvt_delegate = new Efl.EventCb(on_FingerUpEvt_NativeCallback);
      evt_KeyDownEvt_delegate = new Efl.EventCb(on_KeyDownEvt_NativeCallback);
      evt_KeyUpEvt_delegate = new Efl.EventCb(on_KeyUpEvt_NativeCallback);
      evt_HoldEvt_delegate = new Efl.EventCb(on_HoldEvt_NativeCallback);
      evt_FocusInEvt_delegate = new Efl.EventCb(on_FocusInEvt_NativeCallback);
      evt_FocusOutEvt_delegate = new Efl.EventCb(on_FocusOutEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_by_device_get(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev);
   /// <summary>Low-level pointer behaviour by device. See <see cref="Efl.Canvas.Object.GetPointerMode"/> and <see cref="Efl.Canvas.Object.SetPointerMode"/> for more explanation.
   /// 1.19</summary>
   /// <param name="dev">The pointer device to set/get the mode. Use <c>null</c> for the default pointer.</param>
   /// <returns>The pointer mode</returns>
   virtual public Efl.Input.ObjectPointerMode GetPointerModeByDevice( Efl.Input.Device dev) {
                         var _ret_var = efl_canvas_object_pointer_mode_by_device_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dev);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_pointer_mode_by_device_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev,   Efl.Input.ObjectPointerMode pointer_mode);
   /// <summary>Low-level pointer behaviour by device. See <see cref="Efl.Canvas.Object.GetPointerMode"/> and <see cref="Efl.Canvas.Object.SetPointerMode"/> for more explanation.
   /// 1.19</summary>
   /// <param name="dev">The pointer device to set/get the mode. Use <c>null</c> for the default pointer.</param>
   /// <param name="pointer_mode">The pointer mode</param>
   /// <returns><c>true</c> if pointer mode was set, <c>false</c> otherwise</returns>
   virtual public bool SetPointerModeByDevice( Efl.Input.Device dev,  Efl.Input.ObjectPointerMode pointer_mode) {
                                           var _ret_var = efl_canvas_object_pointer_mode_by_device_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dev,  pointer_mode);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_get(System.IntPtr obj);
   /// <summary>Low-level pointer behaviour.
   /// This function has a direct effect on event callbacks related to pointers (mouse, ...).
   /// 
   /// If the value is <see cref="Efl.Input.ObjectPointerMode.AutoGrab"/> (default), then when mouse is pressed down over this object, events will be restricted to it as source, mouse moves, for example, will be emitted even when the pointer goes outside this objects geometry.
   /// 
   /// If the value is <see cref="Efl.Input.ObjectPointerMode.NoGrab"/>, then events will be emitted just when inside this object area.
   /// 
   /// The default value is <see cref="Efl.Input.ObjectPointerMode.AutoGrab"/>. See also: <see cref="Efl.Canvas.Object.GetPointerModeByDevice"/> and <see cref="Efl.Canvas.Object.GetPointerModeByDevice"/> Note: This function will only set/get the mode for the default pointer.</summary>
   /// <returns>Input pointer mode</returns>
   virtual public Efl.Input.ObjectPointerMode GetPointerMode() {
       var _ret_var = efl_canvas_object_pointer_mode_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_pointer_mode_set(System.IntPtr obj,   Efl.Input.ObjectPointerMode pointer_mode);
   /// <summary>Low-level pointer behaviour.
   /// This function has a direct effect on event callbacks related to pointers (mouse, ...).
   /// 
   /// If the value is <see cref="Efl.Input.ObjectPointerMode.AutoGrab"/> (default), then when mouse is pressed down over this object, events will be restricted to it as source, mouse moves, for example, will be emitted even when the pointer goes outside this objects geometry.
   /// 
   /// If the value is <see cref="Efl.Input.ObjectPointerMode.NoGrab"/>, then events will be emitted just when inside this object area.
   /// 
   /// The default value is <see cref="Efl.Input.ObjectPointerMode.AutoGrab"/>. See also: <see cref="Efl.Canvas.Object.GetPointerModeByDevice"/> and <see cref="Efl.Canvas.Object.GetPointerModeByDevice"/> Note: This function will only set/get the mode for the default pointer.</summary>
   /// <param name="pointer_mode">Input pointer mode</param>
   /// <returns><c>true</c> if pointer behaviour was set, <c>false</c> otherwise</returns>
   virtual public bool SetPointerMode( Efl.Input.ObjectPointerMode pointer_mode) {
                         var _ret_var = efl_canvas_object_pointer_mode_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  pointer_mode);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern Efl.Gfx.RenderOp efl_canvas_object_render_op_get(System.IntPtr obj);
   /// <summary>Render mode to be used for compositing the Evas object.
   /// Only two modes are supported: - <see cref="Efl.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="Efl.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
   /// 
   /// Please do not assume that <see cref="Efl.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (eg. a transparent background inside a buffer canvas).</summary>
   /// <returns>Blend or copy.</returns>
   virtual public Efl.Gfx.RenderOp GetRenderOp() {
       var _ret_var = efl_canvas_object_render_op_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_render_op_set(System.IntPtr obj,   Efl.Gfx.RenderOp render_op);
   /// <summary>Render mode to be used for compositing the Evas object.
   /// Only two modes are supported: - <see cref="Efl.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="Efl.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
   /// 
   /// Please do not assume that <see cref="Efl.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (eg. a transparent background inside a buffer canvas).</summary>
   /// <param name="render_op">Blend or copy.</param>
   /// <returns></returns>
   virtual public  void SetRenderOp( Efl.Gfx.RenderOp render_op) {
                         efl_canvas_object_render_op_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  render_op);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_freeze_events_get(System.IntPtr obj);
   /// <summary>Determine whether an object is set to freeze (discard) events.
   /// 1.1</summary>
   /// <returns>Pass when <c>obj</c> is to freeze events (<c>true</c>) or not (<c>false</c>).</returns>
   virtual public bool GetFreezeEvents() {
       var _ret_var = efl_canvas_object_freeze_events_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_freeze_events_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool freeze);
   /// <summary>Set whether an Evas object is to freeze (discard) events.
   /// If <c>freeze</c> is <c>true</c>, it will force events on <c>obj</c> to be discarded. Unlike <see cref="Efl.Canvas.Object.SetPassEvents"/>, events will not be passed to next lower object. This API can be used for blocking events while <c>obj</c> is in transition.
   /// 
   /// If <c>freeze</c> is <c>false</c>, events will be processed on that object as normal.
   /// 
   /// Warning: If you block only key/mouse up events with this API, you can&apos;t be sure of the state of any objects that have only key/mouse down events.
   /// 1.1</summary>
   /// <param name="freeze">Pass when <c>obj</c> is to freeze events (<c>true</c>) or not (<c>false</c>).</param>
   /// <returns></returns>
   virtual public  void SetFreezeEvents( bool freeze) {
                         efl_canvas_object_freeze_events_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  freeze);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Object efl_canvas_object_clip_get(System.IntPtr obj);
   /// <summary>Get the object clipping <c>obj</c> (if any).
   /// This function returns the object clipping <c>obj</c>. If <c>obj</c> is not being clipped at all, <c>null</c> is returned. The object <c>obj</c> must be a valid Evas_Object.</summary>
   /// <returns>The object to clip <c>obj</c> by.</returns>
   virtual public Efl.Canvas.Object GetClip() {
       var _ret_var = efl_canvas_object_clip_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_clip_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object clip);
   /// <summary>Clip one object to another.
   /// This function will clip the object <c>obj</c> to the area occupied by the object <c>clip</c>. This means the object <c>obj</c> will only be visible within the area occupied by the clipping object (<c>clip</c>).
   /// 
   /// The color of the object being clipped will be multiplied by the color of the clipping one, so the resulting color for the former will be &quot;RESULT = (OBJ * CLIP) / (255 * 255)&quot;, per color element (red, green, blue and alpha).
   /// 
   /// Clipping is recursive, so clipping objects may be clipped by others, and their color will in term be multiplied. You may not set up circular clipping lists (i.e. object 1 clips object 2, which clips object 1): the behavior of Evas is undefined in this case.
   /// 
   /// Objects which do not clip others are visible in the canvas as normal; those that clip one or more objects become invisible themselves, only affecting what they clip. If an object ceases to have other objects being clipped by it, it will become visible again.
   /// 
   /// The visibility of an object affects the objects that are clipped by it, so if the object clipping others is not shown (as in <see cref="Efl.Gfx.Entity.Visible"/>), the objects clipped by it will not be shown  either.
   /// 
   /// If <c>obj</c> was being clipped by another object when this function is  called, it gets implicitly removed from the old clipper&apos;s domain and is made now to be clipped by its new clipper.
   /// 
   /// If <c>clip</c> is <c>null</c>, this call will disable clipping for the object i.e. its visibility and color get detached from the previous clipper. If it wasn&apos;t, this has no effect.
   /// 
   /// Note: Only rectangle and image (masks) objects can be used as clippers. Anything else will result in undefined behaviour.</summary>
   /// <param name="clip">The object to clip <c>obj</c> by.</param>
   /// <returns></returns>
   virtual public  void SetClip( Efl.Canvas.Object clip) {
                         efl_canvas_object_clip_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  clip);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_repeat_events_get(System.IntPtr obj);
   /// <summary>Determine whether an object is set to repeat events.</summary>
   /// <returns>Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</returns>
   virtual public bool GetRepeatEvents() {
       var _ret_var = efl_canvas_object_repeat_events_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_repeat_events_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool repeat);
   /// <summary>Set whether an Evas object is to repeat events.
   /// If <c>repeat</c> is <c>true</c>, it will make events on <c>obj</c> to also be repeated for the next lower object in the objects&apos; stack (see see <see cref="Efl.Gfx.Stack.GetBelow"/>).
   /// 
   /// If <c>repeat</c> is <c>false</c>, events occurring on <c>obj</c> will be processed only on it.</summary>
   /// <param name="repeat">Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</param>
   /// <returns></returns>
   virtual public  void SetRepeatEvents( bool repeat) {
                         efl_canvas_object_repeat_events_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  repeat);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_key_focus_get(System.IntPtr obj);
   /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
   /// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <see cref="Efl.Canvas.Object.CheckSeatFocus"/>, <see cref="Efl.Canvas.Object.AddSeatFocus"/>, <see cref="Efl.Canvas.Object.DelSeatFocus"/>.</summary>
   /// <returns><c>true</c> when set as focused or <c>false</c> otherwise.</returns>
   virtual public bool GetKeyFocus() {
       var _ret_var = efl_canvas_object_key_focus_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_key_focus_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool focus);
   /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
   /// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <see cref="Efl.Canvas.Object.CheckSeatFocus"/>, <see cref="Efl.Canvas.Object.AddSeatFocus"/>, <see cref="Efl.Canvas.Object.DelSeatFocus"/>.</summary>
   /// <param name="focus"><c>true</c> when set as focused or <c>false</c> otherwise.</param>
   /// <returns></returns>
   virtual public  void SetKeyFocus( bool focus) {
                         efl_canvas_object_key_focus_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  focus);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_seat_focus_get(System.IntPtr obj);
   /// <summary>Check if this object is focused.
   /// 1.19</summary>
   /// <returns><c>true</c> if focused by at least one seat or <c>false</c> otherwise.</returns>
   virtual public bool GetSeatFocus() {
       var _ret_var = efl_canvas_object_seat_focus_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_is_frame_object_get(System.IntPtr obj);
   /// <summary>If <c>true</c> the object belongs to the window border decorations.
   /// This will be <c>false</c> by default, and should be <c>false</c> for all objects created by the application, unless swallowed in some very specific parts of the window.
   /// 
   /// It is very unlikely that an application needs to call this manually, as the window will handle this feature automatically.
   /// 1.2</summary>
   /// <returns><c>true</c> if the object is a frame, <c>false</c> otherwise</returns>
   virtual public bool GetIsFrameObject() {
       var _ret_var = efl_canvas_object_is_frame_object_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_is_frame_object_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool is_frame);
   /// <summary>If <c>true</c> the object belongs to the window border decorations.
   /// This will be <c>false</c> by default, and should be <c>false</c> for all objects created by the application, unless swallowed in some very specific parts of the window.
   /// 
   /// It is very unlikely that an application needs to call this manually, as the window will handle this feature automatically.
   /// 1.2</summary>
   /// <param name="is_frame"><c>true</c> if the object is a frame, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetIsFrameObject( bool is_frame) {
                         efl_canvas_object_is_frame_object_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  is_frame);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_precise_is_inside_get(System.IntPtr obj);
   /// <summary>Determine whether an object is set to use precise point collision detection.</summary>
   /// <returns>Whether to use precise point collision detection or not. The default value is false.</returns>
   virtual public bool GetPreciseIsInside() {
       var _ret_var = efl_canvas_object_precise_is_inside_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_precise_is_inside_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool precise);
   /// <summary>Set whether to use precise (usually expensive) point collision detection for a given Evas object.
   /// Use this function to make Evas treat objects&apos; transparent areas as not belonging to it with regard to mouse pointer events. By default, all of the object&apos;s boundary rectangle will be taken in account for them.
   /// 
   /// Warning: By using precise point collision detection you&apos;ll be making Evas more resource intensive.</summary>
   /// <param name="precise">Whether to use precise point collision detection or not. The default value is false.</param>
   /// <returns></returns>
   virtual public  void SetPreciseIsInside( bool precise) {
                         efl_canvas_object_precise_is_inside_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  precise);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_propagate_events_get(System.IntPtr obj);
   /// <summary>Retrieve whether an Evas object is set to propagate events.
   /// See also <see cref="Efl.Canvas.Object.GetRepeatEvents"/>, <see cref="Efl.Canvas.Object.GetPassEvents"/>, <see cref="Efl.Canvas.Object.GetFreezeEvents"/>.</summary>
   /// <returns>Whether to propagate events (<c>true</c>) or not (<c>false</c>).</returns>
   virtual public bool GetPropagateEvents() {
       var _ret_var = efl_canvas_object_propagate_events_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_propagate_events_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool propagate);
   /// <summary>Set whether events on a smart object&apos;s member should be propagated up to its parent.
   /// This function has no effect if <c>obj</c> is not a member of a smart object.
   /// 
   /// If <c>prop</c> is <c>true</c>, events occurring on this object will be propagated on to the smart object of which <c>obj</c> is a member. If <c>prop</c> is <c>false</c>, events occurring on this object will not be propagated on to the smart object of which <c>obj</c> is a member. The default value is <c>true</c>.
   /// 
   /// See also <see cref="Efl.Canvas.Object.SetRepeatEvents"/>, <see cref="Efl.Canvas.Object.SetPassEvents"/>, <see cref="Efl.Canvas.Object.SetFreezeEvents"/>.</summary>
   /// <param name="propagate">Whether to propagate events (<c>true</c>) or not (<c>false</c>).</param>
   /// <returns></returns>
   virtual public  void SetPropagateEvents( bool propagate) {
                         efl_canvas_object_propagate_events_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  propagate);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_pass_events_get(System.IntPtr obj);
   /// <summary>Determine whether an object is set to pass (ignore) events.
   /// See also <see cref="Efl.Canvas.Object.GetRepeatEvents"/>, <see cref="Efl.Canvas.Object.GetPropagateEvents"/>, <see cref="Efl.Canvas.Object.GetFreezeEvents"/>.</summary>
   /// <returns>Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</returns>
   virtual public bool GetPassEvents() {
       var _ret_var = efl_canvas_object_pass_events_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_pass_events_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool pass);
   /// <summary>Set whether an Evas object is to pass (ignore) events.
   /// If <c>pass</c> is <c>true</c>, it will make events on <c>obj</c> to be ignored. They will be triggered on the next lower object (that is not set to pass events), instead (see <see cref="Efl.Gfx.Stack.GetBelow"/>).
   /// 
   /// If <c>pass</c> is <c>false</c> events will be processed on that object as normal.
   /// 
   /// See also <see cref="Efl.Canvas.Object.SetRepeatEvents"/>, <see cref="Efl.Canvas.Object.SetPropagateEvents"/>, <see cref="Efl.Canvas.Object.SetFreezeEvents"/>.</summary>
   /// <param name="pass">Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</param>
   /// <returns></returns>
   virtual public  void SetPassEvents( bool pass) {
                         efl_canvas_object_pass_events_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  pass);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_anti_alias_get(System.IntPtr obj);
   /// <summary>Retrieves whether or not the given Evas object is to be drawn anti_aliased.</summary>
   /// <returns><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</returns>
   virtual public bool GetAntiAlias() {
       var _ret_var = efl_canvas_object_anti_alias_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_anti_alias_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool anti_alias);
   /// <summary>Sets whether or not the given Evas object is to be drawn anti-aliased.</summary>
   /// <param name="anti_alias"><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</param>
   /// <returns></returns>
   virtual public  void SetAntiAlias( bool anti_alias) {
                         efl_canvas_object_anti_alias_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  anti_alias);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  System.IntPtr efl_canvas_object_clipees_get(System.IntPtr obj);
   /// <summary>Return a list of objects currently clipped by <c>obj</c>.
   /// This returns the internal list handle containing all objects clipped by the object <c>obj</c>. If none are clipped by it, the call returns <c>null</c>. This list is only valid until the clip list is changed and should be fetched again with another call to this function if any objects being clipped by this object are unclipped, clipped by a new object, deleted or get the clipper deleted. These operations will invalidate the list returned, so it should not be used anymore after that point. Any use of the list after this may have undefined results, possibly leading to crashes.
   /// 
   /// See also <see cref="Efl.Canvas.Object.Clip"/>.</summary>
   /// <returns>An iterator over the list of objects clipped by <c>obj</c>.</returns>
   virtual public Eina.Iterator<Efl.Canvas.Object> GetClipees() {
       var _ret_var = efl_canvas_object_clipees_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return new Eina.Iterator<Efl.Canvas.Object>(_ret_var, false, false);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Object efl_canvas_object_render_parent_get(System.IntPtr obj);
   /// <summary>Gets the parent smart object of a given Evas object, if it has one.
   /// This can be different from <see cref="Efl.Object.Parent"/> because this one is used internally for rendering and the normal parent is what the user expects to be the parent.
   /// 1.18</summary>
   /// <returns>The parent smart object of <c>obj</c> or <c>null</c>.</returns>
   virtual public Efl.Canvas.Object GetRenderParent() {
       var _ret_var = efl_canvas_object_render_parent_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern Efl.TextBidirectionalType efl_canvas_object_paragraph_direction_get(System.IntPtr obj);
   /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.</summary>
   /// <returns>Paragraph direction for the given object.</returns>
   virtual public Efl.TextBidirectionalType GetParagraphDirection() {
       var _ret_var = efl_canvas_object_paragraph_direction_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_paragraph_direction_set(System.IntPtr obj,   Efl.TextBidirectionalType dir);
   /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.</summary>
   /// <param name="dir">Paragraph direction for the given object.</param>
   /// <returns></returns>
   virtual public  void SetParagraphDirection( Efl.TextBidirectionalType dir) {
                         efl_canvas_object_paragraph_direction_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dir);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_no_render_get(System.IntPtr obj);
   /// <summary>Returns the state of the &quot;no-render&quot; flag, which means, when true, that an object should never be rendered on the canvas.
   /// This flag can be used to avoid rendering visible clippers on the canvas, even if they currently don&apos;t clip any object.
   /// 1.15</summary>
   /// <returns>Enable &quot;no-render&quot; mode.</returns>
   virtual public bool GetNoRender() {
       var _ret_var = efl_canvas_object_no_render_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_no_render_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enable);
   /// <summary>Disable all rendering on the canvas.
   /// This flag will be used to indicate to Evas that this object should never be rendered on the canvas under any circumstances. In particular, this is useful to avoid drawing clipper objects (or masks) even when they don&apos;t clip any object. This can also be used to replace the old source_visible flag with proxy objects.
   /// 
   /// This is different to the visible property, as even visible objects marked as &quot;no-render&quot; will never appear on screen. But those objects can still be used as proxy sources or clippers. When hidden, all &quot;no-render&quot; objects will completely disappear from the canvas, and hide their clippees or be invisible when used as proxy sources.
   /// 1.15</summary>
   /// <param name="enable">Enable &quot;no-render&quot; mode.</param>
   /// <returns></returns>
   virtual public  void SetNoRender( bool enable) {
                         efl_canvas_object_no_render_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  enable);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_coords_inside_get(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
   /// <summary>Returns whether the coords are logically inside the object.
   /// When this function is called it will return a value of either <c>false</c> or <c>true</c>, depending on if the coords are inside the object&apos;s current geometry.
   /// 
   /// A return value of <c>true</c> indicates the position is logically inside the object, and <c>false</c> implies it is logically outside the object.
   /// 
   /// If <c>e</c> is not a valid object, the return value is undefined.</summary>
   /// <param name="pos">The position in pixels.</param>
   /// <returns><c>true</c> if the coords are inside the object, <c>false</c> otherwise</returns>
   virtual public bool GetCoordsInside( Eina.Position2D pos) {
       var _in_pos = Eina.Position2D_StructConversion.ToInternal(pos);
                  var _ret_var = efl_canvas_object_coords_inside_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Animation efl_canvas_object_event_animation_get(System.IntPtr obj,    System.IntPtr desc);
   /// <summary>Set the <c>animation</c> which starts when the given <c>desc</c> happens to the object.</summary>
   /// <param name="desc">The event description for which the given <c>animation</c> is set.</param>
   /// <returns>The animation which starts when the given <c>desc</c> happens to the object.</returns>
   virtual public Efl.Canvas.Animation GetEventAnimation( Efl.EventDescription desc) {
       var _in_desc = Eina.PrimitiveConversion.ManagedToPointerAlloc(desc);
                  var _ret_var = efl_canvas_object_event_animation_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_desc);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_event_animation_set(System.IntPtr obj,    System.IntPtr desc, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Animation animation);
   /// <summary>Set the <c>animation</c> which starts when the given <c>desc</c> happens to the object.</summary>
   /// <param name="desc">The event description for which the given <c>animation</c> is set.</param>
   /// <param name="animation">The animation which starts when the given <c>desc</c> happens to the object.</param>
   /// <returns></returns>
   virtual public  void SetEventAnimation( Efl.EventDescription desc,  Efl.Canvas.Animation animation) {
       var _in_desc = Eina.PrimitiveConversion.ManagedToPointerAlloc(desc);
                                    efl_canvas_object_event_animation_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_desc,  animation);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_seat_focus_check(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   /// <summary>Check if this object is focused by a given seat
   /// 1.19</summary>
   /// <param name="seat">The seat to check if the object is focused. Use <c>null</c> for the default seat.</param>
   /// <returns><c>true</c> if focused or <c>false</c> otherwise.</returns>
   virtual public bool CheckSeatFocus( Efl.Input.Device seat) {
                         var _ret_var = efl_canvas_object_seat_focus_check((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  seat);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_seat_focus_add(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   /// <summary>Add a seat to the focus list.
   /// Evas allows the Efl.Canvas.Object to be focused by multiple seats at the same time. This function adds a new seat to the focus list. In other words, after the seat is added to the list this object will now be also focused by this new seat.
   /// 
   /// Note: The old focus APIs still work, however they will only act on the default seat.
   /// 1.19</summary>
   /// <param name="seat">The seat that should be added to the focus list. Use <c>null</c> for the default seat.</param>
   /// <returns><c>true</c> if the focus has been set or <c>false</c> otherwise.</returns>
   virtual public bool AddSeatFocus( Efl.Input.Device seat) {
                         var _ret_var = efl_canvas_object_seat_focus_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  seat);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_seat_focus_del(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   /// <summary>Remove a seat from the focus list.
   /// 1.19</summary>
   /// <param name="seat">The seat that should be removed from the focus list. Use <c>null</c> for the default seat.</param>
   /// <returns><c>true</c> if the seat was removed from the focus list or <c>false</c> otherwise.</returns>
   virtual public bool DelSeatFocus( Efl.Input.Device seat) {
                         var _ret_var = efl_canvas_object_seat_focus_del((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  seat);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_clipees_has(System.IntPtr obj);
   /// <summary>Test if any object is clipped by <c>obj</c>.
   /// 1.8</summary>
   /// <returns><c>true</c> if any object is clipped by <c>obj</c>, <c>false</c> otherwise</returns>
   virtual public bool HasClipees() {
       var _ret_var = efl_canvas_object_clipees_has((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_object_key_grab(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String keyname,   Efl.Input.Modifier modifiers,   Efl.Input.Modifier not_modifiers,  [MarshalAs(UnmanagedType.U1)]  bool exclusive);
   /// <summary>Requests <c>keyname</c> key events be directed to <c>obj</c>.
   /// Key grabs allow one or more objects to receive key events for specific key strokes even if other objects have focus. Whenever a key is grabbed, only the objects grabbing it will get the events for the given keys.
   /// 
   /// <c>keyname</c> is a platform dependent symbolic name for the key pressed.
   /// 
   /// <c>modifiers</c> and <c>not_modifiers</c> are bit masks of all the modifiers that must and mustn&apos;t, respectively, be pressed along with <c>keyname</c> key in order to trigger this new key grab. Modifiers can be things such as Shift and Ctrl as well as user defined types via @ref evas_key_modifier_add. <c>exclusive</c> will make the given object the only one permitted to grab the given key. If given <c>true</c>, subsequent calls on this function with different <c>obj</c> arguments will fail, unless the key is ungrabbed again.
   /// 
   /// Warning: Providing impossible modifier sets creates undefined behavior.</summary>
   /// <param name="keyname">The key to request events for.</param>
   /// <param name="modifiers">A combination of modifier keys that must be present to trigger the event.</param>
   /// <param name="not_modifiers">A combination of modifier keys that must not be present to trigger the event.</param>
   /// <param name="exclusive">Request that the <c>obj</c> is the only object receiving the <c>keyname</c> events.</param>
   /// <returns><c>true</c> if the call succeeded, <c>false</c> otherwise.</returns>
   virtual public bool GrabKey(  System.String keyname,  Efl.Input.Modifier modifiers,  Efl.Input.Modifier not_modifiers,  bool exclusive) {
                                                                               var _ret_var = efl_canvas_object_key_grab((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  keyname,  modifiers,  not_modifiers,  exclusive);
      Eina.Error.RaiseIfUnhandledException();
                                                      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_canvas_object_key_ungrab(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String keyname,   Efl.Input.Modifier modifiers,   Efl.Input.Modifier not_modifiers);
   /// <summary>Removes the grab on <c>keyname</c> key events by <c>obj</c>.
   /// Removes a key grab on <c>obj</c> if <c>keyname</c>, <c>modifiers</c>, and <c>not_modifiers</c> match.
   /// 
   /// See also <see cref="Efl.Canvas.Object.GrabKey"/>, <see cref="Efl.Canvas.Object.GetKeyFocus"/>, <see cref="Efl.Canvas.Object.SetKeyFocus"/>, and the legacy API evas_focus_get.</summary>
   /// <param name="keyname">The key the grab is set for.</param>
   /// <param name="modifiers">A mask of modifiers that must be present to trigger the event.</param>
   /// <param name="not_modifiers">A mask of modifiers that must not not be present to trigger the event.</param>
   /// <returns></returns>
   virtual public  void UngrabKey(  System.String keyname,  Efl.Input.Modifier modifiers,  Efl.Input.Modifier not_modifiers) {
                                                             efl_canvas_object_key_ungrab((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  keyname,  modifiers,  not_modifiers);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_canvas_pointer_inside_get(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   /// <summary>Returns whether the mouse pointer is logically inside the canvas.
   /// When this function is called it will return a value of either <c>false</c> or <c>true</c>, depending on whether a pointer,in or pointer,out event has been called previously.
   /// 
   /// A return value of <c>true</c> indicates the mouse is logically inside the canvas, and <c>false</c> implies it is logically outside the canvas.
   /// 
   /// A canvas begins with the mouse being assumed outside (<c>false</c>).</summary>
   /// <param name="seat">The seat to consider, if <c>null</c> then the default seat will be used.</param>
   /// <returns><c>true</c> if the mouse pointer is inside the canvas, <c>false</c> otherwise</returns>
   virtual public bool GetPointerInside( Efl.Input.Device seat) {
                         var _ret_var = efl_canvas_pointer_inside_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  seat);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_color_get(System.IntPtr obj,   out  int r,   out  int g,   out  int b,   out  int a);
   /// <summary>Retrieves the general/main color of the given Evas object.
   /// Retrieves the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
   /// 
   /// Usually youll use this attribute for text and rectangle objects, where the main color is their unique one. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
   /// 
   /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
   /// 
   /// Use null pointers on the components you&apos;re not interested in: they&apos;ll be ignored by the function.</summary>
   /// <param name="r"></param>
   /// <param name="g"></param>
   /// <param name="b"></param>
   /// <param name="a"></param>
   /// <returns></returns>
   virtual public  void GetColor( out  int r,  out  int g,  out  int b,  out  int a) {
                                                                               efl_gfx_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_color_set(System.IntPtr obj,    int r,    int g,    int b,    int a);
   /// <summary>Sets the general/main color of the given Evas object to the given one.
   /// See also <see cref="Efl.Gfx.Color.GetColor"/> (for an example)
   /// 
   /// These color values are expected to be premultiplied by alpha.</summary>
   /// <param name="r"></param>
   /// <param name="g"></param>
   /// <param name="b"></param>
   /// <param name="a"></param>
   /// <returns></returns>
   virtual public  void SetColor(  int r,   int g,   int b,   int a) {
                                                                               efl_gfx_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_gfx_color_code_get(System.IntPtr obj);
   /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.</summary>
   /// <returns>the hex color code.</returns>
   virtual public  System.String GetColorCode() {
       var _ret_var = efl_gfx_color_code_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_color_code_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
   /// <summary>Set the color of given Evas object to the given hex color code(#RRGGBBAA). e.g. efl_gfx_color_code_set(obj, &quot;#FFCCAACC&quot;);</summary>
   /// <param name="colorcode">the hex color code.</param>
   /// <returns></returns>
   virtual public  void SetColorCode(  System.String colorcode) {
                         efl_gfx_color_code_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  colorcode);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_gfx_color_class_code_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer);
   /// <summary>Get hex color class code of given Evas Object. This returns a short lived hex color class code string.</summary>
   /// <param name="color_class">The name of color class</param>
   /// <param name="layer">The layer to set the color</param>
   /// <returns>the hex color code.</returns>
   virtual public  System.String GetColorClassCode(  System.String color_class,  Efl.Gfx.ColorClassLayer layer) {
                                           var _ret_var = efl_gfx_color_class_code_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  color_class,  layer);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_color_class_code_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
   /// <summary>Set the color class color of given Evas Object to the given hex color code(#RRGGBBAA). e.g. efl_gfx_color_class_code_set(obj, &quot;color_class_name&quot;, layer, &quot;#FFCCAACC&quot;);</summary>
   /// <param name="color_class">The name of color class</param>
   /// <param name="layer">The layer to set the color</param>
   /// <param name="colorcode">the hex color code.</param>
   /// <returns></returns>
   virtual public  void SetColorClassCode(  System.String color_class,  Efl.Gfx.ColorClassLayer layer,   System.String colorcode) {
                                                             efl_gfx_color_class_code_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  color_class,  layer,  colorcode);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Position2D_StructInternal efl_gfx_entity_position_get(System.IntPtr obj);
   /// <summary>Retrieves the position of the given canvas object.</summary>
   /// <returns>A 2D coordinate in pixel units.</returns>
   virtual public Eina.Position2D GetPosition() {
       var _ret_var = efl_gfx_entity_position_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Position2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_entity_position_set(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
   /// <summary>Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.</summary>
   /// <param name="pos">A 2D coordinate in pixel units.</param>
   /// <returns></returns>
   virtual public  void SetPosition( Eina.Position2D pos) {
       var _in_pos = Eina.Position2D_StructConversion.ToInternal(pos);
                  efl_gfx_entity_position_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_pos);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Size2D_StructInternal efl_gfx_entity_size_get(System.IntPtr obj);
   /// <summary>Retrieves the (rectangular) size of the given Evas object.</summary>
   /// <returns>A 2D size in pixel units.</returns>
   virtual public Eina.Size2D GetSize() {
       var _ret_var = efl_gfx_entity_size_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_entity_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal size);
   /// <summary>Changes the size of the given object.
   /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="Efl.Gfx.SizeHint"/> instead, when manipulating widgets.</summary>
   /// <param name="size">A 2D size in pixel units.</param>
   /// <returns></returns>
   virtual public  void SetSize( Eina.Size2D size) {
       var _in_size = Eina.Size2D_StructConversion.ToInternal(size);
                  efl_gfx_entity_size_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_size);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Rect_StructInternal efl_gfx_entity_geometry_get(System.IntPtr obj);
   /// <summary>Rectangular geometry that combines both position and size.</summary>
   /// <returns>The X,Y position and W,H size, in pixels.</returns>
   virtual public Eina.Rect GetGeometry() {
       var _ret_var = efl_gfx_entity_geometry_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Rect_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_entity_geometry_set(System.IntPtr obj,   Eina.Rect_StructInternal rect);
   /// <summary>Rectangular geometry that combines both position and size.</summary>
   /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
   /// <returns></returns>
   virtual public  void SetGeometry( Eina.Rect rect) {
       var _in_rect = Eina.Rect_StructConversion.ToInternal(rect);
                  efl_gfx_entity_geometry_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_rect);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_entity_visible_get(System.IntPtr obj);
   /// <summary>Retrieves whether or not the given canvas object is visible.</summary>
   /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
   virtual public bool GetVisible() {
       var _ret_var = efl_gfx_entity_visible_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_entity_visible_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool v);
   /// <summary>Shows or hides this object.</summary>
   /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
   /// <returns></returns>
   virtual public  void SetVisible( bool v) {
                         efl_gfx_entity_visible_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  v);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_gfx_entity_scale_get(System.IntPtr obj);
   /// <summary>Gets an object&apos;s scaling factor.</summary>
   /// <returns>The scaling factor (the default value is 0.0, meaning individual scaling is not set)</returns>
   virtual public double GetScale() {
       var _ret_var = efl_gfx_entity_scale_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_entity_scale_set(System.IntPtr obj,   double scale);
   /// <summary>Sets the scaling factor of an object.</summary>
   /// <param name="scale">The scaling factor (the default value is 0.0, meaning individual scaling is not set)</param>
   /// <returns></returns>
   virtual public  void SetScale( double scale) {
                         efl_gfx_entity_scale_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  scale);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  int efl_gfx_map_point_count_get(System.IntPtr obj);
   /// <summary>Number of points of a map.
   /// This sets the number of points of map. Currently, the number of points must be multiples of 4.
   /// 1.20</summary>
   /// <returns>The number of points of map
   /// 1.20</returns>
   virtual public  int GetMapPointCount() {
       var _ret_var = efl_gfx_map_point_count_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_point_count_set(System.IntPtr obj,    int count);
   /// <summary>Number of points of a map.
   /// This sets the number of points of map. Currently, the number of points must be multiples of 4.
   /// 1.20</summary>
   /// <param name="count">The number of points of map
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetMapPointCount(  int count) {
                         efl_gfx_map_point_count_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  count);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_map_clockwise_get(System.IntPtr obj);
   /// <summary>Clockwise state of a map (read-only).
   /// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
   /// 1.20</summary>
   /// <returns><c>true</c> if clockwise, <c>false</c> if counter clockwise
   /// 1.20</returns>
   virtual public bool GetMapClockwise() {
       var _ret_var = efl_gfx_map_clockwise_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_map_smooth_get(System.IntPtr obj);
   /// <summary>Smoothing state for map rendering.
   /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
   /// 1.20</summary>
   /// <returns><c>true</c> by default.
   /// 1.20</returns>
   virtual public bool GetMapSmooth() {
       var _ret_var = efl_gfx_map_smooth_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_smooth_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool smooth);
   /// <summary>Smoothing state for map rendering.
   /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
   /// 1.20</summary>
   /// <param name="smooth"><c>true</c> by default.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetMapSmooth( bool smooth) {
                         efl_gfx_map_smooth_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  smooth);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_map_alpha_get(System.IntPtr obj);
   /// <summary>Alpha flag for map rendering.
   /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
   /// 
   /// Note that this may conflict with <see cref="Efl.Gfx.Map.MapSmooth"/> depending on which algorithm is used for anti-aliasing.
   /// 1.20</summary>
   /// <returns><c>true</c> by default.
   /// 1.20</returns>
   virtual public bool GetMapAlpha() {
       var _ret_var = efl_gfx_map_alpha_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_alpha_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
   /// <summary>Alpha flag for map rendering.
   /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
   /// 
   /// Note that this may conflict with <see cref="Efl.Gfx.Map.MapSmooth"/> depending on which algorithm is used for anti-aliasing.
   /// 1.20</summary>
   /// <param name="alpha"><c>true</c> by default.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetMapAlpha( bool alpha) {
                         efl_gfx_map_alpha_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  alpha);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_coord_absolute_get(System.IntPtr obj,    int idx,   out double x,   out double y,   out double z);
   /// <summary>A point&apos;s absolute coordinate on the canvas.
   /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
   /// 
   /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
   /// 
   /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
   /// 
   /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.
   /// 1.20</summary>
   /// <param name="idx">ID of the point, from 0 to 3 (included).
   /// 1.20</param>
   /// <param name="x">Point X coordinate in absolute pixel coordinates.
   /// 1.20</param>
   /// <param name="y">Point Y coordinate in absolute pixel coordinates.
   /// 1.20</param>
   /// <param name="z">Point Z coordinate hint (pre-perspective transform).
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetMapCoordAbsolute(  int idx,  out double x,  out double y,  out double z) {
                                                                               efl_gfx_map_coord_absolute_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  idx,  out x,  out y,  out z);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_coord_absolute_set(System.IntPtr obj,    int idx,   double x,   double y,   double z);
   /// <summary>A point&apos;s absolute coordinate on the canvas.
   /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
   /// 
   /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
   /// 
   /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
   /// 
   /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.
   /// 1.20</summary>
   /// <param name="idx">ID of the point, from 0 to 3 (included).
   /// 1.20</param>
   /// <param name="x">Point X coordinate in absolute pixel coordinates.
   /// 1.20</param>
   /// <param name="y">Point Y coordinate in absolute pixel coordinates.
   /// 1.20</param>
   /// <param name="z">Point Z coordinate hint (pre-perspective transform).
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetMapCoordAbsolute(  int idx,  double x,  double y,  double z) {
                                                                               efl_gfx_map_coord_absolute_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  idx,  x,  y,  z);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_uv_get(System.IntPtr obj,    int idx,   out double u,   out double v);
   /// <summary>Map point&apos;s U and V texture source point.
   /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
   /// 
   /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).
   /// 1.20</summary>
   /// <param name="idx">ID of the point, from 0 to 3 (included).
   /// 1.20</param>
   /// <param name="u">Relative X coordinate within the image, from 0 to 1.
   /// 1.20</param>
   /// <param name="v">Relative Y coordinate within the image, from 0 to 1.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetMapUv(  int idx,  out double u,  out double v) {
                                                             efl_gfx_map_uv_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  idx,  out u,  out v);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_uv_set(System.IntPtr obj,    int idx,   double u,   double v);
   /// <summary>Map point&apos;s U and V texture source point.
   /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
   /// 
   /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).
   /// 1.20</summary>
   /// <param name="idx">ID of the point, from 0 to 3 (included).
   /// 1.20</param>
   /// <param name="u">Relative X coordinate within the image, from 0 to 1.
   /// 1.20</param>
   /// <param name="v">Relative Y coordinate within the image, from 0 to 1.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetMapUv(  int idx,  double u,  double v) {
                                                             efl_gfx_map_uv_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  idx,  u,  v);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_color_get(System.IntPtr obj,    int idx,   out  int r,   out  int g,   out  int b,   out  int a);
   /// <summary>Color of a vertex in the map.
   /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
   /// 
   /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).
   /// 1.20</summary>
   /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().
   /// 1.20</param>
   /// <param name="r">Red (0 - 255)
   /// 1.20</param>
   /// <param name="g">Green (0 - 255)
   /// 1.20</param>
   /// <param name="b">Blue (0 - 255)
   /// 1.20</param>
   /// <param name="a">Alpha (0 - 255)
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void GetMapColor(  int idx,  out  int r,  out  int g,  out  int b,  out  int a) {
                                                                                                 efl_gfx_map_color_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  idx,  out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_color_set(System.IntPtr obj,    int idx,    int r,    int g,    int b,    int a);
   /// <summary>Color of a vertex in the map.
   /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
   /// 
   /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).
   /// 1.20</summary>
   /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().
   /// 1.20</param>
   /// <param name="r">Red (0 - 255)
   /// 1.20</param>
   /// <param name="g">Green (0 - 255)
   /// 1.20</param>
   /// <param name="b">Blue (0 - 255)
   /// 1.20</param>
   /// <param name="a">Alpha (0 - 255)
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void SetMapColor(  int idx,   int r,   int g,   int b,   int a) {
                                                                                                 efl_gfx_map_color_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  idx,  r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_gfx_map_has(System.IntPtr obj);
   /// <summary>Read-only property indicating whether an object is mapped.
   /// This will be <c>true</c> if any transformation is applied to this object.
   /// 1.20</summary>
   /// <returns><c>true</c> if the object is mapped.
   /// 1.20</returns>
   virtual public bool HasMap() {
       var _ret_var = efl_gfx_map_has((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_reset(System.IntPtr obj);
   /// <summary>Resets the map transformation to its default state.
   /// This will reset all transformations to identity, meaning the points&apos; colors, positions and UV coordinates will be reset to their default values. <see cref="Efl.Gfx.Map.HasMap"/> will then return <c>false</c>. This function will not modify the values of <see cref="Efl.Gfx.Map.MapSmooth"/> or <see cref="Efl.Gfx.Map.MapAlpha"/>.
   /// 1.20</summary>
   /// <returns></returns>
   virtual public  void ResetMap() {
       efl_gfx_map_reset((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_translate(System.IntPtr obj,   double dx,   double dy,   double dz);
   /// <summary>Apply a translation to the object using map.
   /// This does not change the real geometry of the object but will affect its visible position.
   /// 1.20</summary>
   /// <param name="dx">Distance in pixels along the X axis.
   /// 1.20</param>
   /// <param name="dy">Distance in pixels along the Y axis.
   /// 1.20</param>
   /// <param name="dz">Distance in pixels along the Z axis.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void Translate( double dx,  double dy,  double dz) {
                                                             efl_gfx_map_translate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dx,  dy,  dz);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_rotate(System.IntPtr obj,   double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
   /// <summary>Apply a rotation to the object.
   /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
   /// 
   /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly.
   /// 
   /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom of the <c>pivot</c> object.
   /// 1.20</summary>
   /// <param name="degrees">CCW rotation in degrees.
   /// 1.20</param>
   /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.
   /// 1.20</param>
   /// <param name="cx">X relative coordinate of the center point.
   /// 1.20</param>
   /// <param name="cy">y relative coordinate of the center point.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void Rotate( double degrees,  Efl.Gfx.Entity pivot,  double cx,  double cy) {
                                                                               efl_gfx_map_rotate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  degrees,  pivot,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_rotate_3d(System.IntPtr obj,   double dx,   double dy,   double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
   /// <summary>Rotate the object around 3 axes in 3D.
   /// This will rotate in 3D, not just around the &quot;Z&quot; axis as is the case with <see cref="Efl.Gfx.Map.Rotate"/>. You can rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
   /// 
   /// As with <see cref="Efl.Gfx.Map.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
   /// 1.20</summary>
   /// <param name="dx">Rotation in degrees around X axis (0 to 360).
   /// 1.20</param>
   /// <param name="dy">Rotation in degrees around Y axis (0 to 360).
   /// 1.20</param>
   /// <param name="dz">Rotation in degrees around Z axis (0 to 360).
   /// 1.20</param>
   /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.
   /// 1.20</param>
   /// <param name="cx">X relative coordinate of the center point.
   /// 1.20</param>
   /// <param name="cy">y relative coordinate of the center point.
   /// 1.20</param>
   /// <param name="cz">Z absolute coordinate of the center point.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void Rotate3d( double dx,  double dy,  double dz,  Efl.Gfx.Entity pivot,  double cx,  double cy,  double cz) {
                                                                                                                                     efl_gfx_map_rotate_3d((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dx,  dy,  dz,  pivot,  cx,  cy,  cz);
      Eina.Error.RaiseIfUnhandledException();
                                                                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_rotate_quat(System.IntPtr obj,   double qx,   double qy,   double qz,   double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
   /// <summary>Rotate the object in 3D using a unit quaternion.
   /// This is similar to <see cref="Efl.Gfx.Map.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
   /// 
   /// As with <see cref="Efl.Gfx.Map.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.
   /// 1.20</summary>
   /// <param name="qx">The x component of the imaginary part of the quaternion.
   /// 1.20</param>
   /// <param name="qy">The y component of the imaginary part of the quaternion.
   /// 1.20</param>
   /// <param name="qz">The z component of the imaginary part of the quaternion.
   /// 1.20</param>
   /// <param name="qw">The w component of the real part of the quaternion.
   /// 1.20</param>
   /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.
   /// 1.20</param>
   /// <param name="cx">X relative coordinate of the center point.
   /// 1.20</param>
   /// <param name="cy">y relative coordinate of the center point.
   /// 1.20</param>
   /// <param name="cz">Z absolute coordinate of the center point.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void RotateQuat( double qx,  double qy,  double qz,  double qw,  Efl.Gfx.Entity pivot,  double cx,  double cy,  double cz) {
                                                                                                                                                       efl_gfx_map_rotate_quat((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  qx,  qy,  qz,  qw,  pivot,  cx,  cy,  cz);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_zoom(System.IntPtr obj,   double zoomx,   double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
   /// <summary>Apply a zoom to the object.
   /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
   /// 
   /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom.
   /// 1.20</summary>
   /// <param name="zoomx">Zoom in X direction
   /// 1.20</param>
   /// <param name="zoomy">Zoom in Y direction
   /// 1.20</param>
   /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.
   /// 1.20</param>
   /// <param name="cx">X relative coordinate of the center point.
   /// 1.20</param>
   /// <param name="cy">y relative coordinate of the center point.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void Zoom( double zoomx,  double zoomy,  Efl.Gfx.Entity pivot,  double cx,  double cy) {
                                                                                                 efl_gfx_map_zoom((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  zoomx,  zoomy,  pivot,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_lightning_3d(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
   /// <summary>Apply a lighting effect on the object.
   /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The R, G and B values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color and the ambient color, and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
   /// 
   /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.
   /// 1.20</summary>
   /// <param name="pivot">A pivot object for the light point, can be <c>null</c>.
   /// 1.20</param>
   /// <param name="lx">X relative coordinate in space of light point.
   /// 1.20</param>
   /// <param name="ly">Y relative coordinate in space of light point.
   /// 1.20</param>
   /// <param name="lz">Z absolute coordinate in space of light point.
   /// 1.20</param>
   /// <param name="lr">Light red value (0 - 255).
   /// 1.20</param>
   /// <param name="lg">Light green value (0 - 255).
   /// 1.20</param>
   /// <param name="lb">Light blue value (0 - 255).
   /// 1.20</param>
   /// <param name="ar">Ambient color red value (0 - 255).
   /// 1.20</param>
   /// <param name="ag">Ambient color green value (0 - 255).
   /// 1.20</param>
   /// <param name="ab">Ambient color blue value (0 - 255).
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void Lightning3d( Efl.Gfx.Entity pivot,  double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab) {
                                                                                                                                                                                           efl_gfx_map_lightning_3d((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  pivot,  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_perspective_3d(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double px,   double py,   double z0,   double foc);
   /// <summary>Apply a perspective transform to the map
   /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those under this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
   /// 
   /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.
   /// 1.20</summary>
   /// <param name="pivot">A pivot object for the infinite point, can be <c>null</c>.
   /// 1.20</param>
   /// <param name="px">The perspective distance X relative coordinate.
   /// 1.20</param>
   /// <param name="py">The perspective distance Y relative coordinate.
   /// 1.20</param>
   /// <param name="z0">The &quot;0&quot; Z plane value.
   /// 1.20</param>
   /// <param name="foc">The focal distance, must be greater than 0.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void Perspective3d( Efl.Gfx.Entity pivot,  double px,  double py,  double z0,  double foc) {
                                                                                                 efl_gfx_map_perspective_3d((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  pivot,  px,  py,  z0,  foc);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_rotate_absolute(System.IntPtr obj,   double degrees,   double cx,   double cy);
   /// <summary>Apply a rotation to the object, using absolute coordinates.
   /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
   /// 
   /// The given coordinates are absolute values in pixels. See also <see cref="Efl.Gfx.Map.Rotate"/> for a relative coordinate version.
   /// 1.20</summary>
   /// <param name="degrees">CCW rotation in degrees.
   /// 1.20</param>
   /// <param name="cx">X absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <param name="cy">y absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void RotateAbsolute( double degrees,  double cx,  double cy) {
                                                             efl_gfx_map_rotate_absolute((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  degrees,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_rotate_3d_absolute(System.IntPtr obj,   double dx,   double dy,   double dz,   double cx,   double cy,   double cz);
   /// <summary>Rotate the object around 3 axes in 3D, using absolute coordinates.
   /// This will rotate in 3D and not just around the &quot;Z&quot; axis as the case with <see cref="Efl.Gfx.Map.Rotate"/>. This will rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.Rotate3d"/> for a pivot-based 3D rotation.
   /// 1.20</summary>
   /// <param name="dx">Rotation in degrees around X axis (0 to 360).
   /// 1.20</param>
   /// <param name="dy">Rotation in degrees around Y axis (0 to 360).
   /// 1.20</param>
   /// <param name="dz">Rotation in degrees around Z axis (0 to 360).
   /// 1.20</param>
   /// <param name="cx">X absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <param name="cy">y absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <param name="cz">Z absolute coordinate of the center point.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void Rotate3dAbsolute( double dx,  double dy,  double dz,  double cx,  double cy,  double cz) {
                                                                                                                   efl_gfx_map_rotate_3d_absolute((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  dx,  dy,  dz,  cx,  cy,  cz);
      Eina.Error.RaiseIfUnhandledException();
                                                                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_rotate_quat_absolute(System.IntPtr obj,   double qx,   double qy,   double qz,   double qw,   double cx,   double cy,   double cz);
   /// <summary>Rotate the object in 3D using a unit quaternion, using absolute coordinates.
   /// This is similar to <see cref="Efl.Gfx.Map.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.RotateQuat"/> for a pivot-based 3D rotation.
   /// 1.20</summary>
   /// <param name="qx">The x component of the imaginary part of the quaternion.
   /// 1.20</param>
   /// <param name="qy">The y component of the imaginary part of the quaternion.
   /// 1.20</param>
   /// <param name="qz">The z component of the imaginary part of the quaternion.
   /// 1.20</param>
   /// <param name="qw">The w component of the real part of the quaternion.
   /// 1.20</param>
   /// <param name="cx">X absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <param name="cy">y absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <param name="cz">Z absolute coordinate of the center point.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void RotateQuatAbsolute( double qx,  double qy,  double qz,  double qw,  double cx,  double cy,  double cz) {
                                                                                                                                     efl_gfx_map_rotate_quat_absolute((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  qx,  qy,  qz,  qw,  cx,  cy,  cz);
      Eina.Error.RaiseIfUnhandledException();
                                                                                           }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_zoom_absolute(System.IntPtr obj,   double zoomx,   double zoomy,   double cx,   double cy);
   /// <summary>Apply a zoom to the object, using absolute coordinates.
   /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.Zoom"/> for a pivot-based zoom.
   /// 1.20</summary>
   /// <param name="zoomx">Zoom in X direction
   /// 1.20</param>
   /// <param name="zoomy">Zoom in Y direction
   /// 1.20</param>
   /// <param name="cx">X absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <param name="cy">y absolute coordinate in pixels of the center point.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void ZoomAbsolute( double zoomx,  double zoomy,  double cx,  double cy) {
                                                                               efl_gfx_map_zoom_absolute((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  zoomx,  zoomy,  cx,  cy);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_lightning_3d_absolute(System.IntPtr obj,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
   /// <summary>Apply a lighting effect to the object.
   /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The RGB values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color, the ambient color and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.Lightning3d"/> for a pivot-based lightning effect.
   /// 1.20</summary>
   /// <param name="lx">X absolute coordinate in pixels of the light point.
   /// 1.20</param>
   /// <param name="ly">y absolute coordinate in pixels of the light point.
   /// 1.20</param>
   /// <param name="lz">Z absolute coordinate in space of light point.
   /// 1.20</param>
   /// <param name="lr">Light red value (0 - 255).
   /// 1.20</param>
   /// <param name="lg">Light green value (0 - 255).
   /// 1.20</param>
   /// <param name="lb">Light blue value (0 - 255).
   /// 1.20</param>
   /// <param name="ar">Ambient color red value (0 - 255).
   /// 1.20</param>
   /// <param name="ag">Ambient color green value (0 - 255).
   /// 1.20</param>
   /// <param name="ab">Ambient color blue value (0 - 255).
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void Lightning3dAbsolute( double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab) {
                                                                                                                                                                         efl_gfx_map_lightning_3d_absolute((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_gfx_map_perspective_3d_absolute(System.IntPtr obj,   double px,   double py,   double z0,   double foc);
   /// <summary>Apply a perspective transform to the map
   /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those less than this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
   /// 
   /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="Efl.Gfx.Map.Perspective3d"/> for a pivot-based perspective effect.
   /// 1.20</summary>
   /// <param name="px">The perspective distance X relative coordinate.
   /// 1.20</param>
   /// <param name="py">The perspective distance Y relative coordinate.
   /// 1.20</param>
   /// <param name="z0">The &quot;0&quot; Z plane value.
   /// 1.20</param>
   /// <param name="foc">The focal distance, must be greater than 0.
   /// 1.20</param>
   /// <returns></returns>
   virtual public  void Perspective3dAbsolute( double px,  double py,  double z0,  double foc) {
                                                                               efl_gfx_map_perspective_3d_absolute((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  px,  py,  z0,  foc);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_size_hint_aspect_get(System.IntPtr obj,   out Efl.Gfx.SizeHintAspect mode,   out Eina.Size2D_StructInternal sz);
   /// <summary>Defines the aspect ratio to respect when scaling this object.
   /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
   /// 
   /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
   /// <param name="mode">Mode of interpretation.</param>
   /// <param name="sz">Base size to use for aspecting.</param>
   /// <returns></returns>
   virtual public  void GetHintAspect( out Efl.Gfx.SizeHintAspect mode,  out Eina.Size2D sz) {
                         var _out_sz = new Eina.Size2D_StructInternal();
                  efl_gfx_size_hint_aspect_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out mode,  out _out_sz);
      Eina.Error.RaiseIfUnhandledException();
            sz = Eina.Size2D_StructConversion.ToManaged(_out_sz);
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_size_hint_aspect_set(System.IntPtr obj,   Efl.Gfx.SizeHintAspect mode,   Eina.Size2D_StructInternal sz);
   /// <summary>Defines the aspect ratio to respect when scaling this object.
   /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
   /// 
   /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
   /// <param name="mode">Mode of interpretation.</param>
   /// <param name="sz">Base size to use for aspecting.</param>
   /// <returns></returns>
   virtual public  void SetHintAspect( Efl.Gfx.SizeHintAspect mode,  Eina.Size2D sz) {
             var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                              efl_gfx_size_hint_aspect_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  mode,  _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Size2D_StructInternal efl_gfx_size_hint_max_get(System.IntPtr obj);
   /// <summary>Hints on the object&apos;s maximum size.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Values -1 will be treated as unset hint components, when queried by managers.
   /// 
   /// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   /// <returns>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</returns>
   virtual public Eina.Size2D GetHintMax() {
       var _ret_var = efl_gfx_size_hint_max_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_size_hint_max_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
   /// <summary>Hints on the object&apos;s maximum size.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Values -1 will be treated as unset hint components, when queried by managers.
   /// 
   /// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   /// <param name="sz">Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</param>
   /// <returns></returns>
   virtual public  void SetHintMax( Eina.Size2D sz) {
       var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                  efl_gfx_size_hint_max_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Size2D_StructInternal efl_gfx_size_hint_min_get(System.IntPtr obj);
   /// <summary>Hints on the object&apos;s minimum size.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Value 0 will be treated as unset hint components, when queried by managers.
   /// 
   /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).</summary>
   /// <returns>Minimum size (hint) in pixels.</returns>
   virtual public Eina.Size2D GetHintMin() {
       var _ret_var = efl_gfx_size_hint_min_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_size_hint_min_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
   /// <summary>Hints on the object&apos;s minimum size.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Value 0 will be treated as unset hint components, when queried by managers.
   /// 
   /// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).</summary>
   /// <param name="sz">Minimum size (hint) in pixels.</param>
   /// <returns></returns>
   virtual public  void SetHintMin( Eina.Size2D sz) {
       var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                  efl_gfx_size_hint_min_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Size2D_StructInternal efl_gfx_size_hint_restricted_min_get(System.IntPtr obj);
   /// <summary>Get the &quot;intrinsic&quot; minimum size of this object.</summary>
   /// <returns>Minimum size (hint) in pixels.</returns>
   virtual public Eina.Size2D GetHintRestrictedMin() {
       var _ret_var = efl_gfx_size_hint_restricted_min_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_size_hint_restricted_min_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
   /// <summary>This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; minimum size.</summary>
   /// <param name="sz">Minimum size (hint) in pixels.</param>
   /// <returns></returns>
   virtual public  void SetHintRestrictedMin( Eina.Size2D sz) {
       var _in_sz = Eina.Size2D_StructConversion.ToInternal(sz);
                  efl_gfx_size_hint_restricted_min_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_sz);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern Eina.Size2D_StructInternal efl_gfx_size_hint_combined_min_get(System.IntPtr obj);
   /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.SizeHint.HintRestrictedMin"/> and <see cref="Efl.Gfx.SizeHint.HintMin"/> size hints.
   /// <see cref="Efl.Gfx.SizeHint.HintRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.SizeHint.HintMin"/> is intended to be set from application side. <see cref="Efl.Gfx.SizeHint.GetHintCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
   /// <returns>Minimum size (hint) in pixels.</returns>
   virtual public Eina.Size2D GetHintCombinedMin() {
       var _ret_var = efl_gfx_size_hint_combined_min_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return Eina.Size2D_StructConversion.ToManaged(_ret_var);
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_size_hint_margin_get(System.IntPtr obj,   out  int l,   out  int r,   out  int t,   out  int b);
   /// <summary>Hints for an object&apos;s margin or padding space.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   /// <param name="l">Integer to specify left padding.</param>
   /// <param name="r">Integer to specify right padding.</param>
   /// <param name="t">Integer to specify top padding.</param>
   /// <param name="b">Integer to specify bottom padding.</param>
   /// <returns></returns>
   virtual public  void GetHintMargin( out  int l,  out  int r,  out  int t,  out  int b) {
                                                                               efl_gfx_size_hint_margin_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out l,  out r,  out t,  out b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_size_hint_margin_set(System.IntPtr obj,    int l,    int r,    int t,    int b);
   /// <summary>Hints for an object&apos;s margin or padding space.
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// The object container is in charge of fetching this property and placing the object accordingly.
   /// 
   /// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   /// <param name="l">Integer to specify left padding.</param>
   /// <param name="r">Integer to specify right padding.</param>
   /// <param name="t">Integer to specify top padding.</param>
   /// <param name="b">Integer to specify bottom padding.</param>
   /// <returns></returns>
   virtual public  void SetHintMargin(  int l,   int r,   int t,   int b) {
                                                                               efl_gfx_size_hint_margin_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  l,  r,  t,  b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_size_hint_weight_get(System.IntPtr obj,   out double x,   out double y);
   /// <summary>Hints for an object&apos;s weight.
   /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.SizeHintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
   /// 
   /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
   /// 
   /// Note: Default weight hint values are 0.0, for both axis.</summary>
   /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
   /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
   /// <returns></returns>
   virtual public  void GetHintWeight( out double x,  out double y) {
                                           efl_gfx_size_hint_weight_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_size_hint_weight_set(System.IntPtr obj,   double x,   double y);
   /// <summary>Hints for an object&apos;s weight.
   /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="Efl.Gfx.SizeHintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
   /// 
   /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
   /// 
   /// Note: Default weight hint values are 0.0, for both axis.</summary>
   /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
   /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
   /// <returns></returns>
   virtual public  void SetHintWeight( double x,  double y) {
                                           efl_gfx_size_hint_weight_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_size_hint_align_get(System.IntPtr obj,   out double x,   out double y);
   /// <summary>Hints for an object&apos;s alignment.
   /// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
   /// 
   /// For the horizontal component, 0.0 means to the left, 1.0 means to the right. Analogously, for the vertical component, 0.0 to the top, 1.0 means to the bottom.
   /// 
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// Note: Default alignment hint values are 0.5, for both axes.</summary>
   /// <param name="x">Double, ranging from 0.0 to 1.0.</param>
   /// <param name="y">Double, ranging from 0.0 to 1.0.</param>
   /// <returns></returns>
   virtual public  void GetHintAlign( out double x,  out double y) {
                                           efl_gfx_size_hint_align_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_size_hint_align_set(System.IntPtr obj,   double x,   double y);
   /// <summary>Hints for an object&apos;s alignment.
   /// These are hints on how to align an object inside the boundaries of a container/manager. Accepted values are in the 0.0 to 1.0 range.
   /// 
   /// For the horizontal component, 0.0 means to the left, 1.0 means to the right. Analogously, for the vertical component, 0.0 to the top, 1.0 means to the bottom.
   /// 
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// Note: Default alignment hint values are 0.5, for both axes.</summary>
   /// <param name="x">Double, ranging from 0.0 to 1.0.</param>
   /// <param name="y">Double, ranging from 0.0 to 1.0.</param>
   /// <returns></returns>
   virtual public  void SetHintAlign( double x,  double y) {
                                           efl_gfx_size_hint_align_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_size_hint_fill_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool x,  [MarshalAs(UnmanagedType.U1)]  out bool y);
   /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.SizeHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
   /// Maximum size hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.SizeHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
   /// 
   /// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
   /// 
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// Note: Default fill hint values are true, for both axes.</summary>
   /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
   /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
   /// <returns></returns>
   virtual public  void GetHintFill( out bool x,  out bool y) {
                                           efl_gfx_size_hint_fill_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  out x,  out y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_size_hint_fill_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool x,  [MarshalAs(UnmanagedType.U1)]  bool y);
   /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="Efl.Gfx.SizeHint.GetHintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
   /// Maximum size hints should be enforced with higher priority, if they are set. Also, any <see cref="Efl.Gfx.SizeHint.GetHintMargin"/> set on objects should add up to the object space on the final scene composition.
   /// 
   /// See documentation of possible users: in Evas, they are the <see cref="Efl.Ui.Box"/> &quot;box&quot; and <see cref="Efl.Ui.Table"/> &quot;table&quot; smart objects.
   /// 
   /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
   /// 
   /// Note: Default fill hint values are true, for both axes.</summary>
   /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
   /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
   /// <returns></returns>
   virtual public  void SetHintFill( bool x,  bool y) {
                                           efl_gfx_size_hint_fill_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  x,  y);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  short efl_gfx_stack_layer_get(System.IntPtr obj);
   /// <summary>Retrieves the layer of its canvas that the given object is part of.
   /// See also <see cref="Efl.Gfx.Stack.SetLayer"/></summary>
   /// <returns>The number of the layer to place the object on. Must be between #EFL_GFX_STACK_LAYER_MIN and #EFL_GFX_STACK_LAYER_MAX.</returns>
   virtual public  short GetLayer() {
       var _ret_var = efl_gfx_stack_layer_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_stack_layer_set(System.IntPtr obj,    short l);
   /// <summary>Sets the layer of its canvas that the given object will be part of.
   /// If you don&apos;t use this function, you&apos;ll be dealing with an unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
   /// 
   /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
   /// 
   /// Warning: Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.GetLayer"/></summary>
   /// <param name="l">The number of the layer to place the object on. Must be between #EFL_GFX_STACK_LAYER_MIN and #EFL_GFX_STACK_LAYER_MAX.</param>
   /// <returns></returns>
   virtual public  void SetLayer(  short l) {
                         efl_gfx_stack_layer_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  l);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Gfx.Stack efl_gfx_stack_below_get(System.IntPtr obj);
   /// <summary>Get the Evas object stacked right below <c>obj</c>
   /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.GetLayer"/>, <see cref="Efl.Gfx.Stack.SetLayer"/> and <see cref="Efl.Gfx.Stack.GetBelow"/></summary>
   /// <returns>The #Efl_Gfx_Stack directly below <c>obj</c>, if any, or <c>null</c>, if none</returns>
   virtual public Efl.Gfx.Stack GetBelow() {
       var _ret_var = efl_gfx_stack_below_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))] protected static extern Efl.Gfx.Stack efl_gfx_stack_above_get(System.IntPtr obj);
   /// <summary>Get the Evas object stacked right above <c>obj</c>
   /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.GetLayer"/>, <see cref="Efl.Gfx.Stack.SetLayer"/> and <see cref="Efl.Gfx.Stack.GetBelow"/></summary>
   /// <returns>The #Efl_Gfx_Stack directly below <c>obj</c>, if any, or <c>null</c>, if none</returns>
   virtual public Efl.Gfx.Stack GetAbove() {
       var _ret_var = efl_gfx_stack_above_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_stack_below(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Stack below);
   /// <summary>Stack <c>obj</c> immediately <c>below</c>
   /// Objects, in a given canvas, are stacked in the order they&apos;re added. This means that, if they overlap, the highest ones will cover the lowest ones, in that order. This function is a way to change the stacking order for the objects.
   /// 
   /// Its intended to be used with objects belonging to the same layer in a given canvas, otherwise it will fail (and accomplish nothing).
   /// 
   /// If you have smart objects on your canvas and <c>obj</c> is a member of one of them, then <c>below</c> must also be a member of the same smart object.
   /// 
   /// Similarly, if <c>obj</c> is not a member of a smart object, <c>below</c> must not be either.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.GetLayer"/>, <see cref="Efl.Gfx.Stack.SetLayer"/> and <see cref="Efl.Gfx.Stack.StackBelow"/></summary>
   /// <param name="below">The object below which to stack</param>
   /// <returns></returns>
   virtual public  void StackBelow( Efl.Gfx.Stack below) {
                         efl_gfx_stack_below((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  below);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_stack_raise(System.IntPtr obj);
   /// <summary>Raise <c>obj</c> to the top of its layer.
   /// <c>obj</c> will, then, be the highest one in the layer it belongs to. Object on other layers won&apos;t get touched.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.StackAbove"/>, <see cref="Efl.Gfx.Stack.StackBelow"/> and <see cref="Efl.Gfx.Stack.Lower"/></summary>
   /// <returns></returns>
   virtual public  void Raise() {
       efl_gfx_stack_raise((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_stack_above(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Stack above);
   /// <summary>Stack <c>obj</c> immediately <c>above</c>
   /// Objects, in a given canvas, are stacked in the order they&apos;re added. This means that, if they overlap, the highest ones will cover the lowest ones, in that order. This function is a way to change the stacking order for the objects.
   /// 
   /// Its intended to be used with objects belonging to the same layer in a given canvas, otherwise it will fail (and accomplish nothing).
   /// 
   /// If you have smart objects on your canvas and <c>obj</c> is a member of one of them, then <c>above</c> must also be a member of the same smart object.
   /// 
   /// Similarly, if <c>obj</c> is not a member of a smart object, <c>above</c> must not be either.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.GetLayer"/>, <see cref="Efl.Gfx.Stack.SetLayer"/> and <see cref="Efl.Gfx.Stack.StackBelow"/></summary>
   /// <param name="above">The object above which to stack</param>
   /// <returns></returns>
   virtual public  void StackAbove( Efl.Gfx.Stack above) {
                         efl_gfx_stack_above((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  above);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_gfx_stack_lower(System.IntPtr obj);
   /// <summary>Lower <c>obj</c> to the bottom of its layer.
   /// <c>obj</c> will, then, be the lowest one in the layer it belongs to. Objects on other layers won&apos;t get touched.
   /// 
   /// See also <see cref="Efl.Gfx.Stack.StackAbove"/>, <see cref="Efl.Gfx.Stack.StackBelow"/> and <see cref="Efl.Gfx.Stack.Raise"/></summary>
   /// <returns></returns>
   virtual public  void Lower() {
       efl_gfx_stack_lower((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_input_seat_event_filter_get(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   /// <summary>Check if input events from a given seat is enabled.
   /// 1.19</summary>
   /// <param name="seat">The seat to act on.
   /// 1.19</param>
   /// <returns><c>true</c> to enable events for a seat or <c>false</c> otherwise.
   /// 1.19</returns>
   virtual public bool GetSeatEventFilter( Efl.Input.Device seat) {
                         var _ret_var = efl_input_seat_event_filter_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  seat);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_input_seat_event_filter_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat,  [MarshalAs(UnmanagedType.U1)]  bool enable);
   /// <summary>Add or remove a given seat to the filter list. If the filter list is empty this object will report mouse, keyboard and focus events from any seat, otherwise those events will only be reported if the event comes from a seat that is in the list.
   /// 1.19</summary>
   /// <param name="seat">The seat to act on.
   /// 1.19</param>
   /// <param name="enable"><c>true</c> to enable events for a seat or <c>false</c> otherwise.
   /// 1.19</param>
   /// <returns></returns>
   virtual public  void SetSeatEventFilter( Efl.Input.Device seat,  bool enable) {
                                           efl_input_seat_event_filter_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  seat,  enable);
      Eina.Error.RaiseIfUnhandledException();
                               }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_mirrored_get(System.IntPtr obj);
   /// <summary>Whether this object should be mirrored.
   /// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
   /// <returns><c>true</c> for RTL, <c>false</c> for LTR (default).</returns>
   virtual public bool GetMirrored() {
       var _ret_var = efl_ui_mirrored_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_mirrored_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool rtl);
   /// <summary>Whether this object should be mirrored.
   /// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
   /// <param name="rtl"><c>true</c> for RTL, <c>false</c> for LTR (default).</param>
   /// <returns></returns>
   virtual public  void SetMirrored( bool rtl) {
                         efl_ui_mirrored_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  rtl);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_mirrored_automatic_get(System.IntPtr obj);
   /// <summary>Whether the property <see cref="Efl.Ui.I18n.Mirrored"/> should be set automatically.
   /// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.I18n.Mirrored"/>.
   /// 
   /// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.Scene"/>) as the configuration should affect only high-level widgets.</summary>
   /// <returns>Whether the widget uses automatic mirroring</returns>
   virtual public bool GetMirroredAutomatic() {
       var _ret_var = efl_ui_mirrored_automatic_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_mirrored_automatic_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool automatic);
   /// <summary>Whether the property <see cref="Efl.Ui.I18n.Mirrored"/> should be set automatically.
   /// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.I18n.Mirrored"/>.
   /// 
   /// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.Scene"/>) as the configuration should affect only high-level widgets.</summary>
   /// <param name="automatic">Whether the widget uses automatic mirroring</param>
   /// <returns></returns>
   virtual public  void SetMirroredAutomatic( bool automatic) {
                         efl_ui_mirrored_automatic_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  automatic);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] protected static extern  System.String efl_ui_language_get(System.IntPtr obj);
   /// <summary>Gets the language for this object.</summary>
   /// <returns>The current language.</returns>
   virtual public  System.String GetLanguage() {
       var _ret_var = efl_ui_language_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_ui_language_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String language);
   /// <summary>Sets the language for this object.</summary>
   /// <param name="language">The current language.</param>
   /// <returns></returns>
   virtual public  void SetLanguage(  System.String language) {
                         efl_ui_language_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  language);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Low-level pointer behaviour.
/// This function has a direct effect on event callbacks related to pointers (mouse, ...).
/// 
/// If the value is <see cref="Efl.Input.ObjectPointerMode.AutoGrab"/> (default), then when mouse is pressed down over this object, events will be restricted to it as source, mouse moves, for example, will be emitted even when the pointer goes outside this objects geometry.
/// 
/// If the value is <see cref="Efl.Input.ObjectPointerMode.NoGrab"/>, then events will be emitted just when inside this object area.
/// 
/// The default value is <see cref="Efl.Input.ObjectPointerMode.AutoGrab"/>. See also: <see cref="Efl.Canvas.Object.GetPointerModeByDevice"/> and <see cref="Efl.Canvas.Object.GetPointerModeByDevice"/> Note: This function will only set/get the mode for the default pointer.</summary>
   public Efl.Input.ObjectPointerMode PointerMode {
      get { return GetPointerMode(); }
      set { SetPointerMode( value); }
   }
   /// <summary>Render mode to be used for compositing the Evas object.
/// Only two modes are supported: - <see cref="Efl.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="Efl.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
/// 
/// Please do not assume that <see cref="Efl.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (eg. a transparent background inside a buffer canvas).</summary>
   public Efl.Gfx.RenderOp RenderOp {
      get { return GetRenderOp(); }
      set { SetRenderOp( value); }
   }
   /// <summary>Determine whether an object is set to freeze (discard) events.
/// 1.1</summary>
   public bool FreezeEvents {
      get { return GetFreezeEvents(); }
      set { SetFreezeEvents( value); }
   }
   /// <summary>Get the object clipping <c>obj</c> (if any).
/// This function returns the object clipping <c>obj</c>. If <c>obj</c> is not being clipped at all, <c>null</c> is returned. The object <c>obj</c> must be a valid Evas_Object.</summary>
   public Efl.Canvas.Object Clip {
      get { return GetClip(); }
      set { SetClip( value); }
   }
   /// <summary>Determine whether an object is set to repeat events.</summary>
   public bool RepeatEvents {
      get { return GetRepeatEvents(); }
      set { SetRepeatEvents( value); }
   }
   /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
/// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <see cref="Efl.Canvas.Object.CheckSeatFocus"/>, <see cref="Efl.Canvas.Object.AddSeatFocus"/>, <see cref="Efl.Canvas.Object.DelSeatFocus"/>.</summary>
   public bool KeyFocus {
      get { return GetKeyFocus(); }
      set { SetKeyFocus( value); }
   }
   /// <summary>Check if this object is focused.
/// 1.19</summary>
   public bool SeatFocus {
      get { return GetSeatFocus(); }
   }
   /// <summary>If <c>true</c> the object belongs to the window border decorations.
/// This will be <c>false</c> by default, and should be <c>false</c> for all objects created by the application, unless swallowed in some very specific parts of the window.
/// 
/// It is very unlikely that an application needs to call this manually, as the window will handle this feature automatically.
/// 1.2</summary>
   public bool IsFrameObject {
      get { return GetIsFrameObject(); }
      set { SetIsFrameObject( value); }
   }
   /// <summary>Determine whether an object is set to use precise point collision detection.</summary>
   public bool PreciseIsInside {
      get { return GetPreciseIsInside(); }
      set { SetPreciseIsInside( value); }
   }
   /// <summary>Retrieve whether an Evas object is set to propagate events.
/// See also <see cref="Efl.Canvas.Object.GetRepeatEvents"/>, <see cref="Efl.Canvas.Object.GetPassEvents"/>, <see cref="Efl.Canvas.Object.GetFreezeEvents"/>.</summary>
   public bool PropagateEvents {
      get { return GetPropagateEvents(); }
      set { SetPropagateEvents( value); }
   }
   /// <summary>Determine whether an object is set to pass (ignore) events.
/// See also <see cref="Efl.Canvas.Object.GetRepeatEvents"/>, <see cref="Efl.Canvas.Object.GetPropagateEvents"/>, <see cref="Efl.Canvas.Object.GetFreezeEvents"/>.</summary>
   public bool PassEvents {
      get { return GetPassEvents(); }
      set { SetPassEvents( value); }
   }
   /// <summary>Retrieves whether or not the given Evas object is to be drawn anti_aliased.</summary>
   public bool AntiAlias {
      get { return GetAntiAlias(); }
      set { SetAntiAlias( value); }
   }
   /// <summary>Return a list of objects currently clipped by <c>obj</c>.
/// This returns the internal list handle containing all objects clipped by the object <c>obj</c>. If none are clipped by it, the call returns <c>null</c>. This list is only valid until the clip list is changed and should be fetched again with another call to this function if any objects being clipped by this object are unclipped, clipped by a new object, deleted or get the clipper deleted. These operations will invalidate the list returned, so it should not be used anymore after that point. Any use of the list after this may have undefined results, possibly leading to crashes.
/// 
/// See also <see cref="Efl.Canvas.Object.Clip"/>.</summary>
   public Eina.Iterator<Efl.Canvas.Object> Clipees {
      get { return GetClipees(); }
   }
   /// <summary>Gets the parent smart object of a given Evas object, if it has one.
/// This can be different from <see cref="Efl.Object.Parent"/> because this one is used internally for rendering and the normal parent is what the user expects to be the parent.
/// 1.18</summary>
   public Efl.Canvas.Object RenderParent {
      get { return GetRenderParent(); }
   }
   /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.</summary>
   public Efl.TextBidirectionalType ParagraphDirection {
      get { return GetParagraphDirection(); }
      set { SetParagraphDirection( value); }
   }
   /// <summary>Returns the state of the &quot;no-render&quot; flag, which means, when true, that an object should never be rendered on the canvas.
/// This flag can be used to avoid rendering visible clippers on the canvas, even if they currently don&apos;t clip any object.
/// 1.15</summary>
   public bool NoRender {
      get { return GetNoRender(); }
      set { SetNoRender( value); }
   }
   /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.</summary>
   public  System.String ColorCode {
      get { return GetColorCode(); }
      set { SetColorCode( value); }
   }
   /// <summary>The 2D position of a canvas object.
/// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).</summary>
   public Eina.Position2D Position {
      get { return GetPosition(); }
      set { SetPosition( value); }
   }
   /// <summary>The 2D size of a canvas object.</summary>
   public Eina.Size2D Size {
      get { return GetSize(); }
      set { SetSize( value); }
   }
   /// <summary>Rectangular geometry that combines both position and size.</summary>
   public Eina.Rect Geometry {
      get { return GetGeometry(); }
      set { SetGeometry( value); }
   }
   /// <summary>The visibility of a canvas object.
/// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="Efl.Gfx.Entity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
/// 
/// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...</summary>
   public bool Visible {
      get { return GetVisible(); }
      set { SetVisible( value); }
   }
   /// <summary>The scaling factor of an object.
/// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, than the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
/// 
/// Warning: In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.</summary>
   public double Scale {
      get { return GetScale(); }
      set { SetScale( value); }
   }
   /// <summary>Number of points of a map.
/// This sets the number of points of map. Currently, the number of points must be multiples of 4.
/// 1.20</summary>
   public  int MapPointCount {
      get { return GetMapPointCount(); }
      set { SetMapPointCount( value); }
   }
   /// <summary>Clockwise state of a map (read-only).
/// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.
/// 1.20</summary>
   public bool MapClockwise {
      get { return GetMapClockwise(); }
   }
   /// <summary>Smoothing state for map rendering.
/// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.
/// 1.20</summary>
   public bool MapSmooth {
      get { return GetMapSmooth(); }
      set { SetMapSmooth( value); }
   }
   /// <summary>Alpha flag for map rendering.
/// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<see cref="Efl.Canvas.Image"/> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
/// 
/// Note that this may conflict with <see cref="Efl.Gfx.Map.MapSmooth"/> depending on which algorithm is used for anti-aliasing.
/// 1.20</summary>
   public bool MapAlpha {
      get { return GetMapAlpha(); }
      set { SetMapAlpha( value); }
   }
   /// <summary>Hints on the object&apos;s maximum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Values -1 will be treated as unset hint components, when queried by managers.
/// 
/// Note: Smart objects (such as elementary) can have their own size hint policy. So calling this API may or may not affect the size of smart objects.</summary>
   public Eina.Size2D HintMax {
      get { return GetHintMax(); }
      set { SetHintMax( value); }
   }
   /// <summary>Hints on the object&apos;s minimum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
/// 
/// Value 0 will be treated as unset hint components, when queried by managers.
/// 
/// Note: This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).</summary>
   public Eina.Size2D HintMin {
      get { return GetHintMin(); }
      set { SetHintMin( value); }
   }
   /// <summary>Internal hints for an object&apos;s minimum size.
/// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
/// 
/// Values 0 will be treated as unset hint components, when queried by managers.
/// 
/// Note: This property is internal and meant for widget developers to define the absolute minimum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Use <see cref="Efl.Gfx.SizeHint.HintMin"/> instead.</summary>
   public Eina.Size2D HintRestrictedMin {
      get { return GetHintRestrictedMin(); }
      set { SetHintRestrictedMin( value); }
   }
   /// <summary>Read-only minimum size combining both <see cref="Efl.Gfx.SizeHint.HintRestrictedMin"/> and <see cref="Efl.Gfx.SizeHint.HintMin"/> size hints.
/// <see cref="Efl.Gfx.SizeHint.HintRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="Efl.Gfx.SizeHint.HintMin"/> is intended to be set from application side. <see cref="Efl.Gfx.SizeHint.GetHintCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
   public Eina.Size2D HintCombinedMin {
      get { return GetHintCombinedMin(); }
   }
   /// <summary>Retrieves the layer of its canvas that the given object is part of.
/// See also <see cref="Efl.Gfx.Stack.SetLayer"/></summary>
   public  short Layer {
      get { return GetLayer(); }
      set { SetLayer( value); }
   }
   /// <summary>Get the Evas object stacked right below <c>obj</c>
/// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
/// 
/// See also <see cref="Efl.Gfx.Stack.GetLayer"/>, <see cref="Efl.Gfx.Stack.SetLayer"/> and <see cref="Efl.Gfx.Stack.GetBelow"/></summary>
   public Efl.Gfx.Stack Below {
      get { return GetBelow(); }
   }
   /// <summary>Get the Evas object stacked right above <c>obj</c>
/// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
/// 
/// See also <see cref="Efl.Gfx.Stack.GetLayer"/>, <see cref="Efl.Gfx.Stack.SetLayer"/> and <see cref="Efl.Gfx.Stack.GetBelow"/></summary>
   public Efl.Gfx.Stack Above {
      get { return GetAbove(); }
   }
   /// <summary>Whether this object should be mirrored.
/// If mirrored, an object is in RTL (right to left) mode instead of LTR (left to right).</summary>
   public bool Mirrored {
      get { return GetMirrored(); }
      set { SetMirrored( value); }
   }
   /// <summary>Whether the property <see cref="Efl.Ui.I18n.Mirrored"/> should be set automatically.
/// If enabled, the system or application configuration will be used to set the value of <see cref="Efl.Ui.I18n.Mirrored"/>.
/// 
/// This property may be implemented by high-level widgets (in Efl.Ui) but not by low-level widgets (in <see cref="Efl.Canvas.Scene"/>) as the configuration should affect only high-level widgets.</summary>
   public bool MirroredAutomatic {
      get { return GetMirroredAutomatic(); }
      set { SetMirroredAutomatic( value); }
   }
   /// <summary>The (human) language for this object.</summary>
   public  System.String Language {
      get { return GetLanguage(); }
      set { SetLanguage( value); }
   }
}
public class ObjectNativeInherit : Efl.LoopConsumerNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_canvas_object_pointer_mode_by_device_get_static_delegate = new efl_canvas_object_pointer_mode_by_device_get_delegate(pointer_mode_by_device_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_pointer_mode_by_device_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pointer_mode_by_device_get_static_delegate)});
      efl_canvas_object_pointer_mode_by_device_set_static_delegate = new efl_canvas_object_pointer_mode_by_device_set_delegate(pointer_mode_by_device_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_pointer_mode_by_device_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pointer_mode_by_device_set_static_delegate)});
      efl_canvas_object_pointer_mode_get_static_delegate = new efl_canvas_object_pointer_mode_get_delegate(pointer_mode_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_pointer_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pointer_mode_get_static_delegate)});
      efl_canvas_object_pointer_mode_set_static_delegate = new efl_canvas_object_pointer_mode_set_delegate(pointer_mode_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_pointer_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pointer_mode_set_static_delegate)});
      efl_canvas_object_render_op_get_static_delegate = new efl_canvas_object_render_op_get_delegate(render_op_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_render_op_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_op_get_static_delegate)});
      efl_canvas_object_render_op_set_static_delegate = new efl_canvas_object_render_op_set_delegate(render_op_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_render_op_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_op_set_static_delegate)});
      efl_canvas_object_freeze_events_get_static_delegate = new efl_canvas_object_freeze_events_get_delegate(freeze_events_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_freeze_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_freeze_events_get_static_delegate)});
      efl_canvas_object_freeze_events_set_static_delegate = new efl_canvas_object_freeze_events_set_delegate(freeze_events_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_freeze_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_freeze_events_set_static_delegate)});
      efl_canvas_object_clip_get_static_delegate = new efl_canvas_object_clip_get_delegate(clip_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_clip_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clip_get_static_delegate)});
      efl_canvas_object_clip_set_static_delegate = new efl_canvas_object_clip_set_delegate(clip_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_clip_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clip_set_static_delegate)});
      efl_canvas_object_repeat_events_get_static_delegate = new efl_canvas_object_repeat_events_get_delegate(repeat_events_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_repeat_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_repeat_events_get_static_delegate)});
      efl_canvas_object_repeat_events_set_static_delegate = new efl_canvas_object_repeat_events_set_delegate(repeat_events_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_repeat_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_repeat_events_set_static_delegate)});
      efl_canvas_object_key_focus_get_static_delegate = new efl_canvas_object_key_focus_get_delegate(key_focus_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_key_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_focus_get_static_delegate)});
      efl_canvas_object_key_focus_set_static_delegate = new efl_canvas_object_key_focus_set_delegate(key_focus_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_key_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_focus_set_static_delegate)});
      efl_canvas_object_seat_focus_get_static_delegate = new efl_canvas_object_seat_focus_get_delegate(seat_focus_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_seat_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_get_static_delegate)});
      efl_canvas_object_is_frame_object_get_static_delegate = new efl_canvas_object_is_frame_object_get_delegate(is_frame_object_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_is_frame_object_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_is_frame_object_get_static_delegate)});
      efl_canvas_object_is_frame_object_set_static_delegate = new efl_canvas_object_is_frame_object_set_delegate(is_frame_object_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_is_frame_object_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_is_frame_object_set_static_delegate)});
      efl_canvas_object_precise_is_inside_get_static_delegate = new efl_canvas_object_precise_is_inside_get_delegate(precise_is_inside_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_precise_is_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_precise_is_inside_get_static_delegate)});
      efl_canvas_object_precise_is_inside_set_static_delegate = new efl_canvas_object_precise_is_inside_set_delegate(precise_is_inside_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_precise_is_inside_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_precise_is_inside_set_static_delegate)});
      efl_canvas_object_propagate_events_get_static_delegate = new efl_canvas_object_propagate_events_get_delegate(propagate_events_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_propagate_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_propagate_events_get_static_delegate)});
      efl_canvas_object_propagate_events_set_static_delegate = new efl_canvas_object_propagate_events_set_delegate(propagate_events_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_propagate_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_propagate_events_set_static_delegate)});
      efl_canvas_object_pass_events_get_static_delegate = new efl_canvas_object_pass_events_get_delegate(pass_events_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_pass_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pass_events_get_static_delegate)});
      efl_canvas_object_pass_events_set_static_delegate = new efl_canvas_object_pass_events_set_delegate(pass_events_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_pass_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pass_events_set_static_delegate)});
      efl_canvas_object_anti_alias_get_static_delegate = new efl_canvas_object_anti_alias_get_delegate(anti_alias_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_anti_alias_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_anti_alias_get_static_delegate)});
      efl_canvas_object_anti_alias_set_static_delegate = new efl_canvas_object_anti_alias_set_delegate(anti_alias_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_anti_alias_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_anti_alias_set_static_delegate)});
      efl_canvas_object_clipees_get_static_delegate = new efl_canvas_object_clipees_get_delegate(clipees_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_clipees_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipees_get_static_delegate)});
      efl_canvas_object_render_parent_get_static_delegate = new efl_canvas_object_render_parent_get_delegate(render_parent_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_render_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_parent_get_static_delegate)});
      efl_canvas_object_paragraph_direction_get_static_delegate = new efl_canvas_object_paragraph_direction_get_delegate(paragraph_direction_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_paragraph_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_paragraph_direction_get_static_delegate)});
      efl_canvas_object_paragraph_direction_set_static_delegate = new efl_canvas_object_paragraph_direction_set_delegate(paragraph_direction_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_paragraph_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_paragraph_direction_set_static_delegate)});
      efl_canvas_object_no_render_get_static_delegate = new efl_canvas_object_no_render_get_delegate(no_render_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_no_render_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_no_render_get_static_delegate)});
      efl_canvas_object_no_render_set_static_delegate = new efl_canvas_object_no_render_set_delegate(no_render_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_no_render_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_no_render_set_static_delegate)});
      efl_canvas_object_coords_inside_get_static_delegate = new efl_canvas_object_coords_inside_get_delegate(coords_inside_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_coords_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_coords_inside_get_static_delegate)});
      efl_canvas_object_event_animation_get_static_delegate = new efl_canvas_object_event_animation_get_delegate(event_animation_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_event_animation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_event_animation_get_static_delegate)});
      efl_canvas_object_event_animation_set_static_delegate = new efl_canvas_object_event_animation_set_delegate(event_animation_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_event_animation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_event_animation_set_static_delegate)});
      efl_canvas_object_seat_focus_check_static_delegate = new efl_canvas_object_seat_focus_check_delegate(seat_focus_check);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_seat_focus_check"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_check_static_delegate)});
      efl_canvas_object_seat_focus_add_static_delegate = new efl_canvas_object_seat_focus_add_delegate(seat_focus_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_seat_focus_add"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_add_static_delegate)});
      efl_canvas_object_seat_focus_del_static_delegate = new efl_canvas_object_seat_focus_del_delegate(seat_focus_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_seat_focus_del"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_del_static_delegate)});
      efl_canvas_object_clipees_has_static_delegate = new efl_canvas_object_clipees_has_delegate(clipees_has);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_clipees_has"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipees_has_static_delegate)});
      efl_canvas_object_key_grab_static_delegate = new efl_canvas_object_key_grab_delegate(key_grab);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_key_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_grab_static_delegate)});
      efl_canvas_object_key_ungrab_static_delegate = new efl_canvas_object_key_ungrab_delegate(key_ungrab);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_object_key_ungrab"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_ungrab_static_delegate)});
      efl_canvas_pointer_inside_get_static_delegate = new efl_canvas_pointer_inside_get_delegate(pointer_inside_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_pointer_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_pointer_inside_get_static_delegate)});
      efl_gfx_color_get_static_delegate = new efl_gfx_color_get_delegate(color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_get_static_delegate)});
      efl_gfx_color_set_static_delegate = new efl_gfx_color_set_delegate(color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_set_static_delegate)});
      efl_gfx_color_code_get_static_delegate = new efl_gfx_color_code_get_delegate(color_code_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_get_static_delegate)});
      efl_gfx_color_code_set_static_delegate = new efl_gfx_color_code_set_delegate(color_code_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_set_static_delegate)});
      efl_gfx_color_class_code_get_static_delegate = new efl_gfx_color_class_code_get_delegate(color_class_code_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_class_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_code_get_static_delegate)});
      efl_gfx_color_class_code_set_static_delegate = new efl_gfx_color_class_code_set_delegate(color_class_code_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_color_class_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_class_code_set_static_delegate)});
      efl_gfx_entity_position_get_static_delegate = new efl_gfx_entity_position_get_delegate(position_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_entity_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_get_static_delegate)});
      efl_gfx_entity_position_set_static_delegate = new efl_gfx_entity_position_set_delegate(position_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_entity_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_set_static_delegate)});
      efl_gfx_entity_size_get_static_delegate = new efl_gfx_entity_size_get_delegate(size_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_entity_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_get_static_delegate)});
      efl_gfx_entity_size_set_static_delegate = new efl_gfx_entity_size_set_delegate(size_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_entity_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_set_static_delegate)});
      efl_gfx_entity_geometry_get_static_delegate = new efl_gfx_entity_geometry_get_delegate(geometry_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_entity_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_get_static_delegate)});
      efl_gfx_entity_geometry_set_static_delegate = new efl_gfx_entity_geometry_set_delegate(geometry_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_entity_geometry_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_set_static_delegate)});
      efl_gfx_entity_visible_get_static_delegate = new efl_gfx_entity_visible_get_delegate(visible_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_entity_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_get_static_delegate)});
      efl_gfx_entity_visible_set_static_delegate = new efl_gfx_entity_visible_set_delegate(visible_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_entity_visible_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_set_static_delegate)});
      efl_gfx_entity_scale_get_static_delegate = new efl_gfx_entity_scale_get_delegate(scale_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_entity_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_get_static_delegate)});
      efl_gfx_entity_scale_set_static_delegate = new efl_gfx_entity_scale_set_delegate(scale_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_entity_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_set_static_delegate)});
      efl_gfx_map_point_count_get_static_delegate = new efl_gfx_map_point_count_get_delegate(map_point_count_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_point_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_point_count_get_static_delegate)});
      efl_gfx_map_point_count_set_static_delegate = new efl_gfx_map_point_count_set_delegate(map_point_count_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_point_count_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_point_count_set_static_delegate)});
      efl_gfx_map_clockwise_get_static_delegate = new efl_gfx_map_clockwise_get_delegate(map_clockwise_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_clockwise_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_clockwise_get_static_delegate)});
      efl_gfx_map_smooth_get_static_delegate = new efl_gfx_map_smooth_get_delegate(map_smooth_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_smooth_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_smooth_get_static_delegate)});
      efl_gfx_map_smooth_set_static_delegate = new efl_gfx_map_smooth_set_delegate(map_smooth_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_smooth_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_smooth_set_static_delegate)});
      efl_gfx_map_alpha_get_static_delegate = new efl_gfx_map_alpha_get_delegate(map_alpha_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_alpha_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_alpha_get_static_delegate)});
      efl_gfx_map_alpha_set_static_delegate = new efl_gfx_map_alpha_set_delegate(map_alpha_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_alpha_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_alpha_set_static_delegate)});
      efl_gfx_map_coord_absolute_get_static_delegate = new efl_gfx_map_coord_absolute_get_delegate(map_coord_absolute_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_coord_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_coord_absolute_get_static_delegate)});
      efl_gfx_map_coord_absolute_set_static_delegate = new efl_gfx_map_coord_absolute_set_delegate(map_coord_absolute_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_coord_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_coord_absolute_set_static_delegate)});
      efl_gfx_map_uv_get_static_delegate = new efl_gfx_map_uv_get_delegate(map_uv_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_uv_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_uv_get_static_delegate)});
      efl_gfx_map_uv_set_static_delegate = new efl_gfx_map_uv_set_delegate(map_uv_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_uv_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_uv_set_static_delegate)});
      efl_gfx_map_color_get_static_delegate = new efl_gfx_map_color_get_delegate(map_color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_color_get_static_delegate)});
      efl_gfx_map_color_set_static_delegate = new efl_gfx_map_color_set_delegate(map_color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_color_set_static_delegate)});
      efl_gfx_map_has_static_delegate = new efl_gfx_map_has_delegate(map_has);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_has"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_has_static_delegate)});
      efl_gfx_map_reset_static_delegate = new efl_gfx_map_reset_delegate(map_reset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_reset_static_delegate)});
      efl_gfx_map_translate_static_delegate = new efl_gfx_map_translate_delegate(translate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_translate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_translate_static_delegate)});
      efl_gfx_map_rotate_static_delegate = new efl_gfx_map_rotate_delegate(rotate);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_rotate"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_rotate_static_delegate)});
      efl_gfx_map_rotate_3d_static_delegate = new efl_gfx_map_rotate_3d_delegate(rotate_3d);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_rotate_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_rotate_3d_static_delegate)});
      efl_gfx_map_rotate_quat_static_delegate = new efl_gfx_map_rotate_quat_delegate(rotate_quat);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_rotate_quat"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_rotate_quat_static_delegate)});
      efl_gfx_map_zoom_static_delegate = new efl_gfx_map_zoom_delegate(zoom);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_zoom"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_zoom_static_delegate)});
      efl_gfx_map_lightning_3d_static_delegate = new efl_gfx_map_lightning_3d_delegate(lightning_3d);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_lightning_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_lightning_3d_static_delegate)});
      efl_gfx_map_perspective_3d_static_delegate = new efl_gfx_map_perspective_3d_delegate(perspective_3d);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_perspective_3d"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_perspective_3d_static_delegate)});
      efl_gfx_map_rotate_absolute_static_delegate = new efl_gfx_map_rotate_absolute_delegate(rotate_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_rotate_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_rotate_absolute_static_delegate)});
      efl_gfx_map_rotate_3d_absolute_static_delegate = new efl_gfx_map_rotate_3d_absolute_delegate(rotate_3d_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_rotate_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_rotate_3d_absolute_static_delegate)});
      efl_gfx_map_rotate_quat_absolute_static_delegate = new efl_gfx_map_rotate_quat_absolute_delegate(rotate_quat_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_rotate_quat_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_rotate_quat_absolute_static_delegate)});
      efl_gfx_map_zoom_absolute_static_delegate = new efl_gfx_map_zoom_absolute_delegate(zoom_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_zoom_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_zoom_absolute_static_delegate)});
      efl_gfx_map_lightning_3d_absolute_static_delegate = new efl_gfx_map_lightning_3d_absolute_delegate(lightning_3d_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_lightning_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_lightning_3d_absolute_static_delegate)});
      efl_gfx_map_perspective_3d_absolute_static_delegate = new efl_gfx_map_perspective_3d_absolute_delegate(perspective_3d_absolute);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_map_perspective_3d_absolute"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_map_perspective_3d_absolute_static_delegate)});
      efl_gfx_size_hint_aspect_get_static_delegate = new efl_gfx_size_hint_aspect_get_delegate(hint_aspect_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_aspect_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_aspect_get_static_delegate)});
      efl_gfx_size_hint_aspect_set_static_delegate = new efl_gfx_size_hint_aspect_set_delegate(hint_aspect_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_aspect_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_aspect_set_static_delegate)});
      efl_gfx_size_hint_max_get_static_delegate = new efl_gfx_size_hint_max_get_delegate(hint_max_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_max_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_max_get_static_delegate)});
      efl_gfx_size_hint_max_set_static_delegate = new efl_gfx_size_hint_max_set_delegate(hint_max_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_max_set_static_delegate)});
      efl_gfx_size_hint_min_get_static_delegate = new efl_gfx_size_hint_min_get_delegate(hint_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_min_get_static_delegate)});
      efl_gfx_size_hint_min_set_static_delegate = new efl_gfx_size_hint_min_set_delegate(hint_min_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_min_set_static_delegate)});
      efl_gfx_size_hint_restricted_min_get_static_delegate = new efl_gfx_size_hint_restricted_min_get_delegate(hint_restricted_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_restricted_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_restricted_min_get_static_delegate)});
      efl_gfx_size_hint_restricted_min_set_static_delegate = new efl_gfx_size_hint_restricted_min_set_delegate(hint_restricted_min_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_restricted_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_restricted_min_set_static_delegate)});
      efl_gfx_size_hint_combined_min_get_static_delegate = new efl_gfx_size_hint_combined_min_get_delegate(hint_combined_min_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_combined_min_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_combined_min_get_static_delegate)});
      efl_gfx_size_hint_margin_get_static_delegate = new efl_gfx_size_hint_margin_get_delegate(hint_margin_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_margin_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_margin_get_static_delegate)});
      efl_gfx_size_hint_margin_set_static_delegate = new efl_gfx_size_hint_margin_set_delegate(hint_margin_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_margin_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_margin_set_static_delegate)});
      efl_gfx_size_hint_weight_get_static_delegate = new efl_gfx_size_hint_weight_get_delegate(hint_weight_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_weight_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_weight_get_static_delegate)});
      efl_gfx_size_hint_weight_set_static_delegate = new efl_gfx_size_hint_weight_set_delegate(hint_weight_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_weight_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_weight_set_static_delegate)});
      efl_gfx_size_hint_align_get_static_delegate = new efl_gfx_size_hint_align_get_delegate(hint_align_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_align_get_static_delegate)});
      efl_gfx_size_hint_align_set_static_delegate = new efl_gfx_size_hint_align_set_delegate(hint_align_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_align_set_static_delegate)});
      efl_gfx_size_hint_fill_get_static_delegate = new efl_gfx_size_hint_fill_get_delegate(hint_fill_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_fill_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_fill_get_static_delegate)});
      efl_gfx_size_hint_fill_set_static_delegate = new efl_gfx_size_hint_fill_set_delegate(hint_fill_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_size_hint_fill_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_size_hint_fill_set_static_delegate)});
      efl_gfx_stack_layer_get_static_delegate = new efl_gfx_stack_layer_get_delegate(layer_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_stack_layer_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_layer_get_static_delegate)});
      efl_gfx_stack_layer_set_static_delegate = new efl_gfx_stack_layer_set_delegate(layer_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_stack_layer_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_layer_set_static_delegate)});
      efl_gfx_stack_below_get_static_delegate = new efl_gfx_stack_below_get_delegate(below_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_stack_below_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_below_get_static_delegate)});
      efl_gfx_stack_above_get_static_delegate = new efl_gfx_stack_above_get_delegate(above_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_stack_above_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_above_get_static_delegate)});
      efl_gfx_stack_below_static_delegate = new efl_gfx_stack_below_delegate(stack_below);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_stack_below"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_below_static_delegate)});
      efl_gfx_stack_raise_static_delegate = new efl_gfx_stack_raise_delegate(raise);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_stack_raise"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_raise_static_delegate)});
      efl_gfx_stack_above_static_delegate = new efl_gfx_stack_above_delegate(stack_above);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_stack_above"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_above_static_delegate)});
      efl_gfx_stack_lower_static_delegate = new efl_gfx_stack_lower_delegate(lower);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_gfx_stack_lower"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_lower_static_delegate)});
      efl_input_seat_event_filter_get_static_delegate = new efl_input_seat_event_filter_get_delegate(seat_event_filter_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_seat_event_filter_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_seat_event_filter_get_static_delegate)});
      efl_input_seat_event_filter_set_static_delegate = new efl_input_seat_event_filter_set_delegate(seat_event_filter_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_input_seat_event_filter_set"), func = Marshal.GetFunctionPointerForDelegate(efl_input_seat_event_filter_set_static_delegate)});
      efl_ui_mirrored_get_static_delegate = new efl_ui_mirrored_get_delegate(mirrored_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_mirrored_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_get_static_delegate)});
      efl_ui_mirrored_set_static_delegate = new efl_ui_mirrored_set_delegate(mirrored_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_mirrored_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_set_static_delegate)});
      efl_ui_mirrored_automatic_get_static_delegate = new efl_ui_mirrored_automatic_get_delegate(mirrored_automatic_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_mirrored_automatic_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_automatic_get_static_delegate)});
      efl_ui_mirrored_automatic_set_static_delegate = new efl_ui_mirrored_automatic_set_delegate(mirrored_automatic_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_mirrored_automatic_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_mirrored_automatic_set_static_delegate)});
      efl_ui_language_get_static_delegate = new efl_ui_language_get_delegate(language_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_language_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_language_get_static_delegate)});
      efl_ui_language_set_static_delegate = new efl_ui_language_set_delegate(language_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_language_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_language_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.Object.efl_canvas_object_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Object.efl_canvas_object_class_get();
   }


    private delegate Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_by_device_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_by_device_get(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev);
    private static Efl.Input.ObjectPointerMode pointer_mode_by_device_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device dev)
   {
      Eina.Log.Debug("function efl_canvas_object_pointer_mode_by_device_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Input.ObjectPointerMode _ret_var = default(Efl.Input.ObjectPointerMode);
         try {
            _ret_var = ((Object)wrapper).GetPointerModeByDevice( dev);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_object_pointer_mode_by_device_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dev);
      }
   }
   private efl_canvas_object_pointer_mode_by_device_get_delegate efl_canvas_object_pointer_mode_by_device_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_pointer_mode_by_device_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev,   Efl.Input.ObjectPointerMode pointer_mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_pointer_mode_by_device_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device dev,   Efl.Input.ObjectPointerMode pointer_mode);
    private static bool pointer_mode_by_device_set(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device dev,  Efl.Input.ObjectPointerMode pointer_mode)
   {
      Eina.Log.Debug("function efl_canvas_object_pointer_mode_by_device_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).SetPointerModeByDevice( dev,  pointer_mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_canvas_object_pointer_mode_by_device_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dev,  pointer_mode);
      }
   }
   private efl_canvas_object_pointer_mode_by_device_set_delegate efl_canvas_object_pointer_mode_by_device_set_static_delegate;


    private delegate Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern Efl.Input.ObjectPointerMode efl_canvas_object_pointer_mode_get(System.IntPtr obj);
    private static Efl.Input.ObjectPointerMode pointer_mode_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_pointer_mode_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Input.ObjectPointerMode _ret_var = default(Efl.Input.ObjectPointerMode);
         try {
            _ret_var = ((Object)wrapper).GetPointerMode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_pointer_mode_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_pointer_mode_get_delegate efl_canvas_object_pointer_mode_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_pointer_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Input.ObjectPointerMode pointer_mode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_pointer_mode_set(System.IntPtr obj,   Efl.Input.ObjectPointerMode pointer_mode);
    private static bool pointer_mode_set(System.IntPtr obj, System.IntPtr pd,  Efl.Input.ObjectPointerMode pointer_mode)
   {
      Eina.Log.Debug("function efl_canvas_object_pointer_mode_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).SetPointerMode( pointer_mode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_object_pointer_mode_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pointer_mode);
      }
   }
   private efl_canvas_object_pointer_mode_set_delegate efl_canvas_object_pointer_mode_set_static_delegate;


    private delegate Efl.Gfx.RenderOp efl_canvas_object_render_op_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern Efl.Gfx.RenderOp efl_canvas_object_render_op_get(System.IntPtr obj);
    private static Efl.Gfx.RenderOp render_op_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_render_op_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.RenderOp _ret_var = default(Efl.Gfx.RenderOp);
         try {
            _ret_var = ((Object)wrapper).GetRenderOp();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_render_op_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_render_op_get_delegate efl_canvas_object_render_op_get_static_delegate;


    private delegate  void efl_canvas_object_render_op_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.RenderOp render_op);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_render_op_set(System.IntPtr obj,   Efl.Gfx.RenderOp render_op);
    private static  void render_op_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.RenderOp render_op)
   {
      Eina.Log.Debug("function efl_canvas_object_render_op_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetRenderOp( render_op);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_object_render_op_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  render_op);
      }
   }
   private efl_canvas_object_render_op_set_delegate efl_canvas_object_render_op_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_freeze_events_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_freeze_events_get(System.IntPtr obj);
    private static bool freeze_events_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_freeze_events_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetFreezeEvents();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_freeze_events_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_freeze_events_get_delegate efl_canvas_object_freeze_events_get_static_delegate;


    private delegate  void efl_canvas_object_freeze_events_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool freeze);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_freeze_events_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool freeze);
    private static  void freeze_events_set(System.IntPtr obj, System.IntPtr pd,  bool freeze)
   {
      Eina.Log.Debug("function efl_canvas_object_freeze_events_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetFreezeEvents( freeze);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_object_freeze_events_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  freeze);
      }
   }
   private efl_canvas_object_freeze_events_set_delegate efl_canvas_object_freeze_events_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_canvas_object_clip_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Object efl_canvas_object_clip_get(System.IntPtr obj);
    private static Efl.Canvas.Object clip_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_clip_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Object)wrapper).GetClip();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_clip_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_clip_get_delegate efl_canvas_object_clip_get_static_delegate;


    private delegate  void efl_canvas_object_clip_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object clip);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_clip_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object clip);
    private static  void clip_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object clip)
   {
      Eina.Log.Debug("function efl_canvas_object_clip_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetClip( clip);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_object_clip_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  clip);
      }
   }
   private efl_canvas_object_clip_set_delegate efl_canvas_object_clip_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_repeat_events_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_repeat_events_get(System.IntPtr obj);
    private static bool repeat_events_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_repeat_events_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetRepeatEvents();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_repeat_events_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_repeat_events_get_delegate efl_canvas_object_repeat_events_get_static_delegate;


    private delegate  void efl_canvas_object_repeat_events_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool repeat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_repeat_events_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool repeat);
    private static  void repeat_events_set(System.IntPtr obj, System.IntPtr pd,  bool repeat)
   {
      Eina.Log.Debug("function efl_canvas_object_repeat_events_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetRepeatEvents( repeat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_object_repeat_events_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  repeat);
      }
   }
   private efl_canvas_object_repeat_events_set_delegate efl_canvas_object_repeat_events_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_key_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_key_focus_get(System.IntPtr obj);
    private static bool key_focus_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_key_focus_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetKeyFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_key_focus_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_key_focus_get_delegate efl_canvas_object_key_focus_get_static_delegate;


    private delegate  void efl_canvas_object_key_focus_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool focus);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_key_focus_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool focus);
    private static  void key_focus_set(System.IntPtr obj, System.IntPtr pd,  bool focus)
   {
      Eina.Log.Debug("function efl_canvas_object_key_focus_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetKeyFocus( focus);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_object_key_focus_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  focus);
      }
   }
   private efl_canvas_object_key_focus_set_delegate efl_canvas_object_key_focus_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_seat_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_seat_focus_get(System.IntPtr obj);
    private static bool seat_focus_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_seat_focus_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetSeatFocus();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_seat_focus_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_seat_focus_get_delegate efl_canvas_object_seat_focus_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_is_frame_object_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_is_frame_object_get(System.IntPtr obj);
    private static bool is_frame_object_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_is_frame_object_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetIsFrameObject();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_is_frame_object_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_is_frame_object_get_delegate efl_canvas_object_is_frame_object_get_static_delegate;


    private delegate  void efl_canvas_object_is_frame_object_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool is_frame);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_is_frame_object_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool is_frame);
    private static  void is_frame_object_set(System.IntPtr obj, System.IntPtr pd,  bool is_frame)
   {
      Eina.Log.Debug("function efl_canvas_object_is_frame_object_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetIsFrameObject( is_frame);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_object_is_frame_object_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  is_frame);
      }
   }
   private efl_canvas_object_is_frame_object_set_delegate efl_canvas_object_is_frame_object_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_precise_is_inside_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_precise_is_inside_get(System.IntPtr obj);
    private static bool precise_is_inside_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_precise_is_inside_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetPreciseIsInside();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_precise_is_inside_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_precise_is_inside_get_delegate efl_canvas_object_precise_is_inside_get_static_delegate;


    private delegate  void efl_canvas_object_precise_is_inside_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool precise);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_precise_is_inside_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool precise);
    private static  void precise_is_inside_set(System.IntPtr obj, System.IntPtr pd,  bool precise)
   {
      Eina.Log.Debug("function efl_canvas_object_precise_is_inside_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetPreciseIsInside( precise);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_object_precise_is_inside_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  precise);
      }
   }
   private efl_canvas_object_precise_is_inside_set_delegate efl_canvas_object_precise_is_inside_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_propagate_events_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_propagate_events_get(System.IntPtr obj);
    private static bool propagate_events_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_propagate_events_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetPropagateEvents();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_propagate_events_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_propagate_events_get_delegate efl_canvas_object_propagate_events_get_static_delegate;


    private delegate  void efl_canvas_object_propagate_events_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool propagate);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_propagate_events_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool propagate);
    private static  void propagate_events_set(System.IntPtr obj, System.IntPtr pd,  bool propagate)
   {
      Eina.Log.Debug("function efl_canvas_object_propagate_events_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetPropagateEvents( propagate);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_object_propagate_events_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  propagate);
      }
   }
   private efl_canvas_object_propagate_events_set_delegate efl_canvas_object_propagate_events_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_pass_events_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_pass_events_get(System.IntPtr obj);
    private static bool pass_events_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_pass_events_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetPassEvents();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_pass_events_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_pass_events_get_delegate efl_canvas_object_pass_events_get_static_delegate;


    private delegate  void efl_canvas_object_pass_events_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool pass);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_pass_events_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool pass);
    private static  void pass_events_set(System.IntPtr obj, System.IntPtr pd,  bool pass)
   {
      Eina.Log.Debug("function efl_canvas_object_pass_events_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetPassEvents( pass);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_object_pass_events_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pass);
      }
   }
   private efl_canvas_object_pass_events_set_delegate efl_canvas_object_pass_events_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_anti_alias_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_anti_alias_get(System.IntPtr obj);
    private static bool anti_alias_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_anti_alias_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetAntiAlias();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_anti_alias_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_anti_alias_get_delegate efl_canvas_object_anti_alias_get_static_delegate;


    private delegate  void efl_canvas_object_anti_alias_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool anti_alias);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_anti_alias_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool anti_alias);
    private static  void anti_alias_set(System.IntPtr obj, System.IntPtr pd,  bool anti_alias)
   {
      Eina.Log.Debug("function efl_canvas_object_anti_alias_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetAntiAlias( anti_alias);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_object_anti_alias_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  anti_alias);
      }
   }
   private efl_canvas_object_anti_alias_set_delegate efl_canvas_object_anti_alias_set_static_delegate;


    private delegate  System.IntPtr efl_canvas_object_clipees_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  System.IntPtr efl_canvas_object_clipees_get(System.IntPtr obj);
    private static  System.IntPtr clipees_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_clipees_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Iterator<Efl.Canvas.Object> _ret_var = default(Eina.Iterator<Efl.Canvas.Object>);
         try {
            _ret_var = ((Object)wrapper).GetClipees();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var.Handle;
      } else {
         return efl_canvas_object_clipees_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_clipees_get_delegate efl_canvas_object_clipees_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_canvas_object_render_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Object efl_canvas_object_render_parent_get(System.IntPtr obj);
    private static Efl.Canvas.Object render_parent_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_render_parent_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Object)wrapper).GetRenderParent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_render_parent_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_render_parent_get_delegate efl_canvas_object_render_parent_get_static_delegate;


    private delegate Efl.TextBidirectionalType efl_canvas_object_paragraph_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern Efl.TextBidirectionalType efl_canvas_object_paragraph_direction_get(System.IntPtr obj);
    private static Efl.TextBidirectionalType paragraph_direction_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_paragraph_direction_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.TextBidirectionalType _ret_var = default(Efl.TextBidirectionalType);
         try {
            _ret_var = ((Object)wrapper).GetParagraphDirection();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_paragraph_direction_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_paragraph_direction_get_delegate efl_canvas_object_paragraph_direction_get_static_delegate;


    private delegate  void efl_canvas_object_paragraph_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.TextBidirectionalType dir);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_paragraph_direction_set(System.IntPtr obj,   Efl.TextBidirectionalType dir);
    private static  void paragraph_direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.TextBidirectionalType dir)
   {
      Eina.Log.Debug("function efl_canvas_object_paragraph_direction_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetParagraphDirection( dir);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_object_paragraph_direction_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
      }
   }
   private efl_canvas_object_paragraph_direction_set_delegate efl_canvas_object_paragraph_direction_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_no_render_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_no_render_get(System.IntPtr obj);
    private static bool no_render_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_no_render_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetNoRender();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_no_render_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_no_render_get_delegate efl_canvas_object_no_render_get_static_delegate;


    private delegate  void efl_canvas_object_no_render_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool enable);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_no_render_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool enable);
    private static  void no_render_set(System.IntPtr obj, System.IntPtr pd,  bool enable)
   {
      Eina.Log.Debug("function efl_canvas_object_no_render_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetNoRender( enable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_canvas_object_no_render_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  enable);
      }
   }
   private efl_canvas_object_no_render_set_delegate efl_canvas_object_no_render_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_coords_inside_get_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal pos);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_coords_inside_get(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
    private static bool coords_inside_get(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D_StructInternal pos)
   {
      Eina.Log.Debug("function efl_canvas_object_coords_inside_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_pos = Eina.Position2D_StructConversion.ToManaged(pos);
                     bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetCoordsInside( _in_pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_object_coords_inside_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
      }
   }
   private efl_canvas_object_coords_inside_get_delegate efl_canvas_object_coords_inside_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Animation efl_canvas_object_event_animation_get_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr desc);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Animation efl_canvas_object_event_animation_get(System.IntPtr obj,    System.IntPtr desc);
    private static Efl.Canvas.Animation event_animation_get(System.IntPtr obj, System.IntPtr pd,   System.IntPtr desc)
   {
      Eina.Log.Debug("function efl_canvas_object_event_animation_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_desc = Eina.PrimitiveConversion.PointerToManaged<Efl.EventDescription>(desc);
                     Efl.Canvas.Animation _ret_var = default(Efl.Canvas.Animation);
         try {
            _ret_var = ((Object)wrapper).GetEventAnimation( _in_desc);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_object_event_animation_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  desc);
      }
   }
   private efl_canvas_object_event_animation_get_delegate efl_canvas_object_event_animation_get_static_delegate;


    private delegate  void efl_canvas_object_event_animation_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr desc, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Animation animation);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_event_animation_set(System.IntPtr obj,    System.IntPtr desc, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Animation animation);
    private static  void event_animation_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr desc,  Efl.Canvas.Animation animation)
   {
      Eina.Log.Debug("function efl_canvas_object_event_animation_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_desc = Eina.PrimitiveConversion.PointerToManaged<Efl.EventDescription>(desc);
                                       
         try {
            ((Object)wrapper).SetEventAnimation( _in_desc,  animation);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_canvas_object_event_animation_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  desc,  animation);
      }
   }
   private efl_canvas_object_event_animation_set_delegate efl_canvas_object_event_animation_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_seat_focus_check_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_seat_focus_check(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    private static bool seat_focus_check(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device seat)
   {
      Eina.Log.Debug("function efl_canvas_object_seat_focus_check was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).CheckSeatFocus( seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_object_seat_focus_check(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private efl_canvas_object_seat_focus_check_delegate efl_canvas_object_seat_focus_check_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_seat_focus_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_seat_focus_add(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    private static bool seat_focus_add(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device seat)
   {
      Eina.Log.Debug("function efl_canvas_object_seat_focus_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).AddSeatFocus( seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_object_seat_focus_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private efl_canvas_object_seat_focus_add_delegate efl_canvas_object_seat_focus_add_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_seat_focus_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_seat_focus_del(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    private static bool seat_focus_del(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device seat)
   {
      Eina.Log.Debug("function efl_canvas_object_seat_focus_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).DelSeatFocus( seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_object_seat_focus_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private efl_canvas_object_seat_focus_del_delegate efl_canvas_object_seat_focus_del_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_clipees_has_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_clipees_has(System.IntPtr obj);
    private static bool clipees_has(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_canvas_object_clipees_has was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).HasClipees();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_canvas_object_clipees_has(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_canvas_object_clipees_has_delegate efl_canvas_object_clipees_has_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_object_key_grab_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String keyname,   Efl.Input.Modifier modifiers,   Efl.Input.Modifier not_modifiers,  [MarshalAs(UnmanagedType.U1)]  bool exclusive);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_object_key_grab(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String keyname,   Efl.Input.Modifier modifiers,   Efl.Input.Modifier not_modifiers,  [MarshalAs(UnmanagedType.U1)]  bool exclusive);
    private static bool key_grab(System.IntPtr obj, System.IntPtr pd,   System.String keyname,  Efl.Input.Modifier modifiers,  Efl.Input.Modifier not_modifiers,  bool exclusive)
   {
      Eina.Log.Debug("function efl_canvas_object_key_grab was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GrabKey( keyname,  modifiers,  not_modifiers,  exclusive);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                      return _ret_var;
      } else {
         return efl_canvas_object_key_grab(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  keyname,  modifiers,  not_modifiers,  exclusive);
      }
   }
   private efl_canvas_object_key_grab_delegate efl_canvas_object_key_grab_static_delegate;


    private delegate  void efl_canvas_object_key_ungrab_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String keyname,   Efl.Input.Modifier modifiers,   Efl.Input.Modifier not_modifiers);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_canvas_object_key_ungrab(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String keyname,   Efl.Input.Modifier modifiers,   Efl.Input.Modifier not_modifiers);
    private static  void key_ungrab(System.IntPtr obj, System.IntPtr pd,   System.String keyname,  Efl.Input.Modifier modifiers,  Efl.Input.Modifier not_modifiers)
   {
      Eina.Log.Debug("function efl_canvas_object_key_ungrab was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Object)wrapper).UngrabKey( keyname,  modifiers,  not_modifiers);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_canvas_object_key_ungrab(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  keyname,  modifiers,  not_modifiers);
      }
   }
   private efl_canvas_object_key_ungrab_delegate efl_canvas_object_key_ungrab_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_canvas_pointer_inside_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_canvas_pointer_inside_get(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    private static bool pointer_inside_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device seat)
   {
      Eina.Log.Debug("function efl_canvas_pointer_inside_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetPointerInside( seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_canvas_pointer_inside_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private efl_canvas_pointer_inside_get_delegate efl_canvas_pointer_inside_get_static_delegate;


    private delegate  void efl_gfx_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int r,   out  int g,   out  int b,   out  int a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_color_get(System.IntPtr obj,   out  int r,   out  int g,   out  int b,   out  int a);
    private static  void color_get(System.IntPtr obj, System.IntPtr pd,  out  int r,  out  int g,  out  int b,  out  int a)
   {
      Eina.Log.Debug("function efl_gfx_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( int);      g = default( int);      b = default( int);      a = default( int);                                 
         try {
            ((Object)wrapper).GetColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private efl_gfx_color_get_delegate efl_gfx_color_get_static_delegate;


    private delegate  void efl_gfx_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    int r,    int g,    int b,    int a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_color_set(System.IntPtr obj,    int r,    int g,    int b,    int a);
    private static  void color_set(System.IntPtr obj, System.IntPtr pd,   int r,   int g,   int b,   int a)
   {
      Eina.Log.Debug("function efl_gfx_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Object)wrapper).SetColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private efl_gfx_color_set_delegate efl_gfx_color_set_static_delegate;


    private delegate  System.IntPtr efl_gfx_color_code_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_gfx_color_code_get(System.IntPtr obj);
    private static  System.IntPtr color_code_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_color_code_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Object)wrapper).GetColorCode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Object)wrapper).cached_strings, _ret_var);
      } else {
         return efl_gfx_color_code_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_color_code_get_delegate efl_gfx_color_code_get_static_delegate;


    private delegate  void efl_gfx_color_code_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_color_code_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
    private static  void color_code_set(System.IntPtr obj, System.IntPtr pd,   System.String colorcode)
   {
      Eina.Log.Debug("function efl_gfx_color_code_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetColorCode( colorcode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_color_code_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  colorcode);
      }
   }
   private efl_gfx_color_code_set_delegate efl_gfx_color_code_set_static_delegate;


    private delegate  System.IntPtr efl_gfx_color_class_code_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_gfx_color_class_code_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer);
    private static  System.IntPtr color_class_code_get(System.IntPtr obj, System.IntPtr pd,   System.String color_class,  Efl.Gfx.ColorClassLayer layer)
   {
      Eina.Log.Debug("function efl_gfx_color_class_code_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                       System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Object)wrapper).GetColorClassCode( color_class,  layer);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return Efl.Eo.Globals.cached_string_to_intptr(((Object)wrapper).cached_strings, _ret_var);
      } else {
         return efl_gfx_color_class_code_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer);
      }
   }
   private efl_gfx_color_class_code_get_delegate efl_gfx_color_class_code_get_static_delegate;


    private delegate  void efl_gfx_color_class_code_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_color_class_code_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String color_class,   Efl.Gfx.ColorClassLayer layer,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
    private static  void color_class_code_set(System.IntPtr obj, System.IntPtr pd,   System.String color_class,  Efl.Gfx.ColorClassLayer layer,   System.String colorcode)
   {
      Eina.Log.Debug("function efl_gfx_color_class_code_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Object)wrapper).SetColorClassCode( color_class,  layer,  colorcode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_color_class_code_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  color_class,  layer,  colorcode);
      }
   }
   private efl_gfx_color_class_code_set_delegate efl_gfx_color_class_code_set_static_delegate;


    private delegate Eina.Position2D_StructInternal efl_gfx_entity_position_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Position2D_StructInternal efl_gfx_entity_position_get(System.IntPtr obj);
    private static Eina.Position2D_StructInternal position_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_entity_position_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Position2D _ret_var = default(Eina.Position2D);
         try {
            _ret_var = ((Object)wrapper).GetPosition();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Position2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_entity_position_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_entity_position_get_delegate efl_gfx_entity_position_get_static_delegate;


    private delegate  void efl_gfx_entity_position_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Position2D_StructInternal pos);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_entity_position_set(System.IntPtr obj,   Eina.Position2D_StructInternal pos);
    private static  void position_set(System.IntPtr obj, System.IntPtr pd,  Eina.Position2D_StructInternal pos)
   {
      Eina.Log.Debug("function efl_gfx_entity_position_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_pos = Eina.Position2D_StructConversion.ToManaged(pos);
                     
         try {
            ((Object)wrapper).SetPosition( _in_pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_entity_position_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pos);
      }
   }
   private efl_gfx_entity_position_set_delegate efl_gfx_entity_position_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_entity_size_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_entity_size_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal size_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_entity_size_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Object)wrapper).GetSize();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_entity_size_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_entity_size_get_delegate efl_gfx_entity_size_get_static_delegate;


    private delegate  void efl_gfx_entity_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal size);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_entity_size_set(System.IntPtr obj,   Eina.Size2D_StructInternal size);
    private static  void size_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal size)
   {
      Eina.Log.Debug("function efl_gfx_entity_size_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_size = Eina.Size2D_StructConversion.ToManaged(size);
                     
         try {
            ((Object)wrapper).SetSize( _in_size);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_entity_size_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  size);
      }
   }
   private efl_gfx_entity_size_set_delegate efl_gfx_entity_size_set_static_delegate;


    private delegate Eina.Rect_StructInternal efl_gfx_entity_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Rect_StructInternal efl_gfx_entity_geometry_get(System.IntPtr obj);
    private static Eina.Rect_StructInternal geometry_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_entity_geometry_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Rect _ret_var = default(Eina.Rect);
         try {
            _ret_var = ((Object)wrapper).GetGeometry();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Rect_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_entity_geometry_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_entity_geometry_get_delegate efl_gfx_entity_geometry_get_static_delegate;


    private delegate  void efl_gfx_entity_geometry_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Rect_StructInternal rect);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_entity_geometry_set(System.IntPtr obj,   Eina.Rect_StructInternal rect);
    private static  void geometry_set(System.IntPtr obj, System.IntPtr pd,  Eina.Rect_StructInternal rect)
   {
      Eina.Log.Debug("function efl_gfx_entity_geometry_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_rect = Eina.Rect_StructConversion.ToManaged(rect);
                     
         try {
            ((Object)wrapper).SetGeometry( _in_rect);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_entity_geometry_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rect);
      }
   }
   private efl_gfx_entity_geometry_set_delegate efl_gfx_entity_geometry_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_entity_visible_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_entity_visible_get(System.IntPtr obj);
    private static bool visible_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_entity_visible_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetVisible();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_entity_visible_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_entity_visible_get_delegate efl_gfx_entity_visible_get_static_delegate;


    private delegate  void efl_gfx_entity_visible_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool v);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_entity_visible_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool v);
    private static  void visible_set(System.IntPtr obj, System.IntPtr pd,  bool v)
   {
      Eina.Log.Debug("function efl_gfx_entity_visible_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetVisible( v);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_entity_visible_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  v);
      }
   }
   private efl_gfx_entity_visible_set_delegate efl_gfx_entity_visible_set_static_delegate;


    private delegate double efl_gfx_entity_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_gfx_entity_scale_get(System.IntPtr obj);
    private static double scale_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_entity_scale_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Object)wrapper).GetScale();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_entity_scale_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_entity_scale_get_delegate efl_gfx_entity_scale_get_static_delegate;


    private delegate  void efl_gfx_entity_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,   double scale);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_entity_scale_set(System.IntPtr obj,   double scale);
    private static  void scale_set(System.IntPtr obj, System.IntPtr pd,  double scale)
   {
      Eina.Log.Debug("function efl_gfx_entity_scale_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetScale( scale);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_entity_scale_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  scale);
      }
   }
   private efl_gfx_entity_scale_set_delegate efl_gfx_entity_scale_set_static_delegate;


    private delegate  int efl_gfx_map_point_count_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  int efl_gfx_map_point_count_get(System.IntPtr obj);
    private static  int map_point_count_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_map_point_count_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   int _ret_var = default( int);
         try {
            _ret_var = ((Object)wrapper).GetMapPointCount();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_map_point_count_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_map_point_count_get_delegate efl_gfx_map_point_count_get_static_delegate;


    private delegate  void efl_gfx_map_point_count_set_delegate(System.IntPtr obj, System.IntPtr pd,    int count);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_point_count_set(System.IntPtr obj,    int count);
    private static  void map_point_count_set(System.IntPtr obj, System.IntPtr pd,   int count)
   {
      Eina.Log.Debug("function efl_gfx_map_point_count_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetMapPointCount( count);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_map_point_count_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  count);
      }
   }
   private efl_gfx_map_point_count_set_delegate efl_gfx_map_point_count_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_map_clockwise_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_map_clockwise_get(System.IntPtr obj);
    private static bool map_clockwise_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_map_clockwise_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetMapClockwise();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_map_clockwise_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_map_clockwise_get_delegate efl_gfx_map_clockwise_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_map_smooth_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_map_smooth_get(System.IntPtr obj);
    private static bool map_smooth_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_map_smooth_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetMapSmooth();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_map_smooth_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_map_smooth_get_delegate efl_gfx_map_smooth_get_static_delegate;


    private delegate  void efl_gfx_map_smooth_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool smooth);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_smooth_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool smooth);
    private static  void map_smooth_set(System.IntPtr obj, System.IntPtr pd,  bool smooth)
   {
      Eina.Log.Debug("function efl_gfx_map_smooth_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetMapSmooth( smooth);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_map_smooth_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  smooth);
      }
   }
   private efl_gfx_map_smooth_set_delegate efl_gfx_map_smooth_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_map_alpha_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_map_alpha_get(System.IntPtr obj);
    private static bool map_alpha_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_map_alpha_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetMapAlpha();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_map_alpha_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_map_alpha_get_delegate efl_gfx_map_alpha_get_static_delegate;


    private delegate  void efl_gfx_map_alpha_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_alpha_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool alpha);
    private static  void map_alpha_set(System.IntPtr obj, System.IntPtr pd,  bool alpha)
   {
      Eina.Log.Debug("function efl_gfx_map_alpha_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetMapAlpha( alpha);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_map_alpha_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  alpha);
      }
   }
   private efl_gfx_map_alpha_set_delegate efl_gfx_map_alpha_set_static_delegate;


    private delegate  void efl_gfx_map_coord_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   out double x,   out double y,   out double z);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_coord_absolute_get(System.IntPtr obj,    int idx,   out double x,   out double y,   out double z);
    private static  void map_coord_absolute_get(System.IntPtr obj, System.IntPtr pd,   int idx,  out double x,  out double y,  out double z)
   {
      Eina.Log.Debug("function efl_gfx_map_coord_absolute_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                             x = default(double);      y = default(double);      z = default(double);                                 
         try {
            ((Object)wrapper).GetMapCoordAbsolute( idx,  out x,  out y,  out z);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_map_coord_absolute_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  out x,  out y,  out z);
      }
   }
   private efl_gfx_map_coord_absolute_get_delegate efl_gfx_map_coord_absolute_get_static_delegate;


    private delegate  void efl_gfx_map_coord_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   double x,   double y,   double z);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_coord_absolute_set(System.IntPtr obj,    int idx,   double x,   double y,   double z);
    private static  void map_coord_absolute_set(System.IntPtr obj, System.IntPtr pd,   int idx,  double x,  double y,  double z)
   {
      Eina.Log.Debug("function efl_gfx_map_coord_absolute_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Object)wrapper).SetMapCoordAbsolute( idx,  x,  y,  z);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_map_coord_absolute_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  x,  y,  z);
      }
   }
   private efl_gfx_map_coord_absolute_set_delegate efl_gfx_map_coord_absolute_set_static_delegate;


    private delegate  void efl_gfx_map_uv_get_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   out double u,   out double v);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_uv_get(System.IntPtr obj,    int idx,   out double u,   out double v);
    private static  void map_uv_get(System.IntPtr obj, System.IntPtr pd,   int idx,  out double u,  out double v)
   {
      Eina.Log.Debug("function efl_gfx_map_uv_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       u = default(double);      v = default(double);                           
         try {
            ((Object)wrapper).GetMapUv( idx,  out u,  out v);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_map_uv_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  out u,  out v);
      }
   }
   private efl_gfx_map_uv_get_delegate efl_gfx_map_uv_get_static_delegate;


    private delegate  void efl_gfx_map_uv_set_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   double u,   double v);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_uv_set(System.IntPtr obj,    int idx,   double u,   double v);
    private static  void map_uv_set(System.IntPtr obj, System.IntPtr pd,   int idx,  double u,  double v)
   {
      Eina.Log.Debug("function efl_gfx_map_uv_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Object)wrapper).SetMapUv( idx,  u,  v);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_map_uv_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  u,  v);
      }
   }
   private efl_gfx_map_uv_set_delegate efl_gfx_map_uv_set_static_delegate;


    private delegate  void efl_gfx_map_color_get_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,   out  int r,   out  int g,   out  int b,   out  int a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_color_get(System.IntPtr obj,    int idx,   out  int r,   out  int g,   out  int b,   out  int a);
    private static  void map_color_get(System.IntPtr obj, System.IntPtr pd,   int idx,  out  int r,  out  int g,  out  int b,  out  int a)
   {
      Eina.Log.Debug("function efl_gfx_map_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                   r = default( int);      g = default( int);      b = default( int);      a = default( int);                                       
         try {
            ((Object)wrapper).GetMapColor( idx,  out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_map_color_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  out r,  out g,  out b,  out a);
      }
   }
   private efl_gfx_map_color_get_delegate efl_gfx_map_color_get_static_delegate;


    private delegate  void efl_gfx_map_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    int idx,    int r,    int g,    int b,    int a);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_color_set(System.IntPtr obj,    int idx,    int r,    int g,    int b,    int a);
    private static  void map_color_set(System.IntPtr obj, System.IntPtr pd,   int idx,   int r,   int g,   int b,   int a)
   {
      Eina.Log.Debug("function efl_gfx_map_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((Object)wrapper).SetMapColor( idx,  r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_map_color_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  idx,  r,  g,  b,  a);
      }
   }
   private efl_gfx_map_color_set_delegate efl_gfx_map_color_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_gfx_map_has_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_gfx_map_has(System.IntPtr obj);
    private static bool map_has(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_map_has was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).HasMap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_map_has(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_map_has_delegate efl_gfx_map_has_static_delegate;


    private delegate  void efl_gfx_map_reset_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_reset(System.IntPtr obj);
    private static  void map_reset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_map_reset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Object)wrapper).ResetMap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_map_reset(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_map_reset_delegate efl_gfx_map_reset_static_delegate;


    private delegate  void efl_gfx_map_translate_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy,   double dz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_translate(System.IntPtr obj,   double dx,   double dy,   double dz);
    private static  void translate(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz)
   {
      Eina.Log.Debug("function efl_gfx_map_translate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Object)wrapper).Translate( dx,  dy,  dz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_map_translate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy,  dz);
      }
   }
   private efl_gfx_map_translate_delegate efl_gfx_map_translate_static_delegate;


    private delegate  void efl_gfx_map_rotate_delegate(System.IntPtr obj, System.IntPtr pd,   double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_rotate(System.IntPtr obj,   double degrees, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
    private static  void rotate(System.IntPtr obj, System.IntPtr pd,  double degrees,  Efl.Gfx.Entity pivot,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_gfx_map_rotate was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Object)wrapper).Rotate( degrees,  pivot,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_map_rotate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  degrees,  pivot,  cx,  cy);
      }
   }
   private efl_gfx_map_rotate_delegate efl_gfx_map_rotate_static_delegate;


    private delegate  void efl_gfx_map_rotate_3d_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy,   double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_rotate_3d(System.IntPtr obj,   double dx,   double dy,   double dz, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
    private static  void rotate_3d(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz,  Efl.Gfx.Entity pivot,  double cx,  double cy,  double cz)
   {
      Eina.Log.Debug("function efl_gfx_map_rotate_3d was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                
         try {
            ((Object)wrapper).Rotate3d( dx,  dy,  dz,  pivot,  cx,  cy,  cz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                } else {
         efl_gfx_map_rotate_3d(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy,  dz,  pivot,  cx,  cy,  cz);
      }
   }
   private efl_gfx_map_rotate_3d_delegate efl_gfx_map_rotate_3d_static_delegate;


    private delegate  void efl_gfx_map_rotate_quat_delegate(System.IntPtr obj, System.IntPtr pd,   double qx,   double qy,   double qz,   double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_rotate_quat(System.IntPtr obj,   double qx,   double qy,   double qz,   double qw, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy,   double cz);
    private static  void rotate_quat(System.IntPtr obj, System.IntPtr pd,  double qx,  double qy,  double qz,  double qw,  Efl.Gfx.Entity pivot,  double cx,  double cy,  double cz)
   {
      Eina.Log.Debug("function efl_gfx_map_rotate_quat was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                                  
         try {
            ((Object)wrapper).RotateQuat( qx,  qy,  qz,  qw,  pivot,  cx,  cy,  cz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                            } else {
         efl_gfx_map_rotate_quat(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  qx,  qy,  qz,  qw,  pivot,  cx,  cy,  cz);
      }
   }
   private efl_gfx_map_rotate_quat_delegate efl_gfx_map_rotate_quat_static_delegate;


    private delegate  void efl_gfx_map_zoom_delegate(System.IntPtr obj, System.IntPtr pd,   double zoomx,   double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_zoom(System.IntPtr obj,   double zoomx,   double zoomy, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double cx,   double cy);
    private static  void zoom(System.IntPtr obj, System.IntPtr pd,  double zoomx,  double zoomy,  Efl.Gfx.Entity pivot,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_gfx_map_zoom was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((Object)wrapper).Zoom( zoomx,  zoomy,  pivot,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_map_zoom(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  zoomx,  zoomy,  pivot,  cx,  cy);
      }
   }
   private efl_gfx_map_zoom_delegate efl_gfx_map_zoom_static_delegate;


    private delegate  void efl_gfx_map_lightning_3d_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_lightning_3d(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
    private static  void lightning_3d(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity pivot,  double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab)
   {
      Eina.Log.Debug("function efl_gfx_map_lightning_3d was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                                                                      
         try {
            ((Object)wrapper).Lightning3d( pivot,  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                                                    } else {
         efl_gfx_map_lightning_3d(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pivot,  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
      }
   }
   private efl_gfx_map_lightning_3d_delegate efl_gfx_map_lightning_3d_static_delegate;


    private delegate  void efl_gfx_map_perspective_3d_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double px,   double py,   double z0,   double foc);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_perspective_3d(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity pivot,   double px,   double py,   double z0,   double foc);
    private static  void perspective_3d(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity pivot,  double px,  double py,  double z0,  double foc)
   {
      Eina.Log.Debug("function efl_gfx_map_perspective_3d was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((Object)wrapper).Perspective3d( pivot,  px,  py,  z0,  foc);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_map_perspective_3d(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pivot,  px,  py,  z0,  foc);
      }
   }
   private efl_gfx_map_perspective_3d_delegate efl_gfx_map_perspective_3d_static_delegate;


    private delegate  void efl_gfx_map_rotate_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double degrees,   double cx,   double cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_rotate_absolute(System.IntPtr obj,   double degrees,   double cx,   double cy);
    private static  void rotate_absolute(System.IntPtr obj, System.IntPtr pd,  double degrees,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_gfx_map_rotate_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((Object)wrapper).RotateAbsolute( degrees,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_map_rotate_absolute(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  degrees,  cx,  cy);
      }
   }
   private efl_gfx_map_rotate_absolute_delegate efl_gfx_map_rotate_absolute_static_delegate;


    private delegate  void efl_gfx_map_rotate_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double dx,   double dy,   double dz,   double cx,   double cy,   double cz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_rotate_3d_absolute(System.IntPtr obj,   double dx,   double dy,   double dz,   double cx,   double cy,   double cz);
    private static  void rotate_3d_absolute(System.IntPtr obj, System.IntPtr pd,  double dx,  double dy,  double dz,  double cx,  double cy,  double cz)
   {
      Eina.Log.Debug("function efl_gfx_map_rotate_3d_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                              
         try {
            ((Object)wrapper).Rotate3dAbsolute( dx,  dy,  dz,  cx,  cy,  cz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                    } else {
         efl_gfx_map_rotate_3d_absolute(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dx,  dy,  dz,  cx,  cy,  cz);
      }
   }
   private efl_gfx_map_rotate_3d_absolute_delegate efl_gfx_map_rotate_3d_absolute_static_delegate;


    private delegate  void efl_gfx_map_rotate_quat_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double qx,   double qy,   double qz,   double qw,   double cx,   double cy,   double cz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_rotate_quat_absolute(System.IntPtr obj,   double qx,   double qy,   double qz,   double qw,   double cx,   double cy,   double cz);
    private static  void rotate_quat_absolute(System.IntPtr obj, System.IntPtr pd,  double qx,  double qy,  double qz,  double qw,  double cx,  double cy,  double cz)
   {
      Eina.Log.Debug("function efl_gfx_map_rotate_quat_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                
         try {
            ((Object)wrapper).RotateQuatAbsolute( qx,  qy,  qz,  qw,  cx,  cy,  cz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                } else {
         efl_gfx_map_rotate_quat_absolute(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  qx,  qy,  qz,  qw,  cx,  cy,  cz);
      }
   }
   private efl_gfx_map_rotate_quat_absolute_delegate efl_gfx_map_rotate_quat_absolute_static_delegate;


    private delegate  void efl_gfx_map_zoom_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double zoomx,   double zoomy,   double cx,   double cy);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_zoom_absolute(System.IntPtr obj,   double zoomx,   double zoomy,   double cx,   double cy);
    private static  void zoom_absolute(System.IntPtr obj, System.IntPtr pd,  double zoomx,  double zoomy,  double cx,  double cy)
   {
      Eina.Log.Debug("function efl_gfx_map_zoom_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Object)wrapper).ZoomAbsolute( zoomx,  zoomy,  cx,  cy);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_map_zoom_absolute(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  zoomx,  zoomy,  cx,  cy);
      }
   }
   private efl_gfx_map_zoom_absolute_delegate efl_gfx_map_zoom_absolute_static_delegate;


    private delegate  void efl_gfx_map_lightning_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_lightning_3d_absolute(System.IntPtr obj,   double lx,   double ly,   double lz,    int lr,    int lg,    int lb,    int ar,    int ag,    int ab);
    private static  void lightning_3d_absolute(System.IntPtr obj, System.IntPtr pd,  double lx,  double ly,  double lz,   int lr,   int lg,   int lb,   int ar,   int ag,   int ab)
   {
      Eina.Log.Debug("function efl_gfx_map_lightning_3d_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                                                    
         try {
            ((Object)wrapper).Lightning3dAbsolute( lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                                        } else {
         efl_gfx_map_lightning_3d_absolute(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  lx,  ly,  lz,  lr,  lg,  lb,  ar,  ag,  ab);
      }
   }
   private efl_gfx_map_lightning_3d_absolute_delegate efl_gfx_map_lightning_3d_absolute_static_delegate;


    private delegate  void efl_gfx_map_perspective_3d_absolute_delegate(System.IntPtr obj, System.IntPtr pd,   double px,   double py,   double z0,   double foc);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_gfx_map_perspective_3d_absolute(System.IntPtr obj,   double px,   double py,   double z0,   double foc);
    private static  void perspective_3d_absolute(System.IntPtr obj, System.IntPtr pd,  double px,  double py,  double z0,  double foc)
   {
      Eina.Log.Debug("function efl_gfx_map_perspective_3d_absolute was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Object)wrapper).Perspective3dAbsolute( px,  py,  z0,  foc);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_map_perspective_3d_absolute(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  px,  py,  z0,  foc);
      }
   }
   private efl_gfx_map_perspective_3d_absolute_delegate efl_gfx_map_perspective_3d_absolute_static_delegate;


    private delegate  void efl_gfx_size_hint_aspect_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.Gfx.SizeHintAspect mode,   out Eina.Size2D_StructInternal sz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_aspect_get(System.IntPtr obj,   out Efl.Gfx.SizeHintAspect mode,   out Eina.Size2D_StructInternal sz);
    private static  void hint_aspect_get(System.IntPtr obj, System.IntPtr pd,  out Efl.Gfx.SizeHintAspect mode,  out Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_aspect_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           mode = default(Efl.Gfx.SizeHintAspect);      Eina.Size2D _out_sz = default(Eina.Size2D);
                     
         try {
            ((Object)wrapper).GetHintAspect( out mode,  out _out_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            sz = Eina.Size2D_StructConversion.ToInternal(_out_sz);
                        } else {
         efl_gfx_size_hint_aspect_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out mode,  out sz);
      }
   }
   private efl_gfx_size_hint_aspect_get_delegate efl_gfx_size_hint_aspect_get_static_delegate;


    private delegate  void efl_gfx_size_hint_aspect_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Gfx.SizeHintAspect mode,   Eina.Size2D_StructInternal sz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_aspect_set(System.IntPtr obj,   Efl.Gfx.SizeHintAspect mode,   Eina.Size2D_StructInternal sz);
    private static  void hint_aspect_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.SizeHintAspect mode,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_aspect_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                     var _in_sz = Eina.Size2D_StructConversion.ToManaged(sz);
                                 
         try {
            ((Object)wrapper).SetHintAspect( mode,  _in_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_aspect_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mode,  sz);
      }
   }
   private efl_gfx_size_hint_aspect_set_delegate efl_gfx_size_hint_aspect_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_size_hint_max_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_size_hint_max_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal hint_max_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_max_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Object)wrapper).GetHintMax();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_size_hint_max_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_size_hint_max_get_delegate efl_gfx_size_hint_max_get_static_delegate;


    private delegate  void efl_gfx_size_hint_max_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal sz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_max_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
    private static  void hint_max_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_max_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_sz = Eina.Size2D_StructConversion.ToManaged(sz);
                     
         try {
            ((Object)wrapper).SetHintMax( _in_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_size_hint_max_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sz);
      }
   }
   private efl_gfx_size_hint_max_set_delegate efl_gfx_size_hint_max_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_size_hint_min_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_size_hint_min_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal hint_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Object)wrapper).GetHintMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_size_hint_min_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_size_hint_min_get_delegate efl_gfx_size_hint_min_get_static_delegate;


    private delegate  void efl_gfx_size_hint_min_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal sz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_min_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
    private static  void hint_min_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_min_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_sz = Eina.Size2D_StructConversion.ToManaged(sz);
                     
         try {
            ((Object)wrapper).SetHintMin( _in_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_size_hint_min_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sz);
      }
   }
   private efl_gfx_size_hint_min_set_delegate efl_gfx_size_hint_min_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_size_hint_restricted_min_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_size_hint_restricted_min_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal hint_restricted_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_restricted_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Object)wrapper).GetHintRestrictedMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_size_hint_restricted_min_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_size_hint_restricted_min_get_delegate efl_gfx_size_hint_restricted_min_get_static_delegate;


    private delegate  void efl_gfx_size_hint_restricted_min_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.Size2D_StructInternal sz);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_restricted_min_set(System.IntPtr obj,   Eina.Size2D_StructInternal sz);
    private static  void hint_restricted_min_set(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D_StructInternal sz)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_restricted_min_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_sz = Eina.Size2D_StructConversion.ToManaged(sz);
                     
         try {
            ((Object)wrapper).SetHintRestrictedMin( _in_sz);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_size_hint_restricted_min_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sz);
      }
   }
   private efl_gfx_size_hint_restricted_min_set_delegate efl_gfx_size_hint_restricted_min_set_static_delegate;


    private delegate Eina.Size2D_StructInternal efl_gfx_size_hint_combined_min_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern Eina.Size2D_StructInternal efl_gfx_size_hint_combined_min_get(System.IntPtr obj);
    private static Eina.Size2D_StructInternal hint_combined_min_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_combined_min_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Size2D _ret_var = default(Eina.Size2D);
         try {
            _ret_var = ((Object)wrapper).GetHintCombinedMin();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Eina.Size2D_StructConversion.ToInternal(_ret_var);
      } else {
         return efl_gfx_size_hint_combined_min_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_size_hint_combined_min_get_delegate efl_gfx_size_hint_combined_min_get_static_delegate;


    private delegate  void efl_gfx_size_hint_margin_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int l,   out  int r,   out  int t,   out  int b);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_margin_get(System.IntPtr obj,   out  int l,   out  int r,   out  int t,   out  int b);
    private static  void hint_margin_get(System.IntPtr obj, System.IntPtr pd,  out  int l,  out  int r,  out  int t,  out  int b)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_margin_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       l = default( int);      r = default( int);      t = default( int);      b = default( int);                                 
         try {
            ((Object)wrapper).GetHintMargin( out l,  out r,  out t,  out b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_size_hint_margin_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out l,  out r,  out t,  out b);
      }
   }
   private efl_gfx_size_hint_margin_get_delegate efl_gfx_size_hint_margin_get_static_delegate;


    private delegate  void efl_gfx_size_hint_margin_set_delegate(System.IntPtr obj, System.IntPtr pd,    int l,    int r,    int t,    int b);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_margin_set(System.IntPtr obj,    int l,    int r,    int t,    int b);
    private static  void hint_margin_set(System.IntPtr obj, System.IntPtr pd,   int l,   int r,   int t,   int b)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_margin_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((Object)wrapper).SetHintMargin( l,  r,  t,  b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_size_hint_margin_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  l,  r,  t,  b);
      }
   }
   private efl_gfx_size_hint_margin_set_delegate efl_gfx_size_hint_margin_set_static_delegate;


    private delegate  void efl_gfx_size_hint_weight_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_weight_get(System.IntPtr obj,   out double x,   out double y);
    private static  void hint_weight_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_weight_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((Object)wrapper).GetHintWeight( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_weight_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_gfx_size_hint_weight_get_delegate efl_gfx_size_hint_weight_get_static_delegate;


    private delegate  void efl_gfx_size_hint_weight_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_weight_set(System.IntPtr obj,   double x,   double y);
    private static  void hint_weight_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_weight_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Object)wrapper).SetHintWeight( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_weight_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_gfx_size_hint_weight_set_delegate efl_gfx_size_hint_weight_set_static_delegate;


    private delegate  void efl_gfx_size_hint_align_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double x,   out double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_align_get(System.IntPtr obj,   out double x,   out double y);
    private static  void hint_align_get(System.IntPtr obj, System.IntPtr pd,  out double x,  out double y)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_align_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(double);      y = default(double);                     
         try {
            ((Object)wrapper).GetHintAlign( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_align_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_gfx_size_hint_align_get_delegate efl_gfx_size_hint_align_get_static_delegate;


    private delegate  void efl_gfx_size_hint_align_set_delegate(System.IntPtr obj, System.IntPtr pd,   double x,   double y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_align_set(System.IntPtr obj,   double x,   double y);
    private static  void hint_align_set(System.IntPtr obj, System.IntPtr pd,  double x,  double y)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_align_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Object)wrapper).SetHintAlign( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_align_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_gfx_size_hint_align_set_delegate efl_gfx_size_hint_align_set_static_delegate;


    private delegate  void efl_gfx_size_hint_fill_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  out bool x,  [MarshalAs(UnmanagedType.U1)]  out bool y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_fill_get(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  out bool x,  [MarshalAs(UnmanagedType.U1)]  out bool y);
    private static  void hint_fill_get(System.IntPtr obj, System.IntPtr pd,  out bool x,  out bool y)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_fill_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           x = default(bool);      y = default(bool);                     
         try {
            ((Object)wrapper).GetHintFill( out x,  out y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_fill_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out x,  out y);
      }
   }
   private efl_gfx_size_hint_fill_get_delegate efl_gfx_size_hint_fill_get_static_delegate;


    private delegate  void efl_gfx_size_hint_fill_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool x,  [MarshalAs(UnmanagedType.U1)]  bool y);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_size_hint_fill_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool x,  [MarshalAs(UnmanagedType.U1)]  bool y);
    private static  void hint_fill_set(System.IntPtr obj, System.IntPtr pd,  bool x,  bool y)
   {
      Eina.Log.Debug("function efl_gfx_size_hint_fill_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Object)wrapper).SetHintFill( x,  y);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_size_hint_fill_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  x,  y);
      }
   }
   private efl_gfx_size_hint_fill_set_delegate efl_gfx_size_hint_fill_set_static_delegate;


    private delegate  short efl_gfx_stack_layer_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  short efl_gfx_stack_layer_get(System.IntPtr obj);
    private static  short layer_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_stack_layer_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   short _ret_var = default( short);
         try {
            _ret_var = ((Object)wrapper).GetLayer();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_stack_layer_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_stack_layer_get_delegate efl_gfx_stack_layer_get_static_delegate;


    private delegate  void efl_gfx_stack_layer_set_delegate(System.IntPtr obj, System.IntPtr pd,    short l);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_stack_layer_set(System.IntPtr obj,    short l);
    private static  void layer_set(System.IntPtr obj, System.IntPtr pd,   short l)
   {
      Eina.Log.Debug("function efl_gfx_stack_layer_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetLayer( l);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_stack_layer_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  l);
      }
   }
   private efl_gfx_stack_layer_set_delegate efl_gfx_stack_layer_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Stack efl_gfx_stack_below_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Stack efl_gfx_stack_below_get(System.IntPtr obj);
    private static Efl.Gfx.Stack below_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_stack_below_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Stack _ret_var = default(Efl.Gfx.Stack);
         try {
            _ret_var = ((Object)wrapper).GetBelow();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_stack_below_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_stack_below_get_delegate efl_gfx_stack_below_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Stack efl_gfx_stack_above_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))] private static extern Efl.Gfx.Stack efl_gfx_stack_above_get(System.IntPtr obj);
    private static Efl.Gfx.Stack above_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_stack_above_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Stack _ret_var = default(Efl.Gfx.Stack);
         try {
            _ret_var = ((Object)wrapper).GetAbove();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_stack_above_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_stack_above_get_delegate efl_gfx_stack_above_get_static_delegate;


    private delegate  void efl_gfx_stack_below_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Stack below);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_stack_below(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Stack below);
    private static  void stack_below(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Stack below)
   {
      Eina.Log.Debug("function efl_gfx_stack_below was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).StackBelow( below);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_stack_below(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  below);
      }
   }
   private efl_gfx_stack_below_delegate efl_gfx_stack_below_static_delegate;


    private delegate  void efl_gfx_stack_raise_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_stack_raise(System.IntPtr obj);
    private static  void raise(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_stack_raise was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Object)wrapper).Raise();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_stack_raise(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_stack_raise_delegate efl_gfx_stack_raise_static_delegate;


    private delegate  void efl_gfx_stack_above_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Stack above);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_stack_above(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Gfx.StackConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Stack above);
    private static  void stack_above(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Stack above)
   {
      Eina.Log.Debug("function efl_gfx_stack_above was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).StackAbove( above);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_stack_above(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  above);
      }
   }
   private efl_gfx_stack_above_delegate efl_gfx_stack_above_static_delegate;


    private delegate  void efl_gfx_stack_lower_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_gfx_stack_lower(System.IntPtr obj);
    private static  void lower(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_stack_lower was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Object)wrapper).Lower();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_gfx_stack_lower(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_gfx_stack_lower_delegate efl_gfx_stack_lower_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_input_seat_event_filter_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_input_seat_event_filter_get(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat);
    private static bool seat_event_filter_get(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device seat)
   {
      Eina.Log.Debug("function efl_input_seat_event_filter_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetSeatEventFilter( seat);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_input_seat_event_filter_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat);
      }
   }
   private efl_input_seat_event_filter_get_delegate efl_input_seat_event_filter_get_static_delegate;


    private delegate  void efl_input_seat_event_filter_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat,  [MarshalAs(UnmanagedType.U1)]  bool enable);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_input_seat_event_filter_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Input.Device, Efl.Eo.NonOwnTag>))]  Efl.Input.Device seat,  [MarshalAs(UnmanagedType.U1)]  bool enable);
    private static  void seat_event_filter_set(System.IntPtr obj, System.IntPtr pd,  Efl.Input.Device seat,  bool enable)
   {
      Eina.Log.Debug("function efl_input_seat_event_filter_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((Object)wrapper).SetSeatEventFilter( seat,  enable);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_input_seat_event_filter_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  seat,  enable);
      }
   }
   private efl_input_seat_event_filter_set_delegate efl_input_seat_event_filter_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_mirrored_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_mirrored_get(System.IntPtr obj);
    private static bool mirrored_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_mirrored_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetMirrored();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_mirrored_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_mirrored_get_delegate efl_ui_mirrored_get_static_delegate;


    private delegate  void efl_ui_mirrored_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool rtl);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_mirrored_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool rtl);
    private static  void mirrored_set(System.IntPtr obj, System.IntPtr pd,  bool rtl)
   {
      Eina.Log.Debug("function efl_ui_mirrored_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetMirrored( rtl);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_mirrored_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rtl);
      }
   }
   private efl_ui_mirrored_set_delegate efl_ui_mirrored_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_mirrored_automatic_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_mirrored_automatic_get(System.IntPtr obj);
    private static bool mirrored_automatic_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_mirrored_automatic_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Object)wrapper).GetMirroredAutomatic();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_ui_mirrored_automatic_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_mirrored_automatic_get_delegate efl_ui_mirrored_automatic_get_static_delegate;


    private delegate  void efl_ui_mirrored_automatic_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool automatic);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_mirrored_automatic_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool automatic);
    private static  void mirrored_automatic_set(System.IntPtr obj, System.IntPtr pd,  bool automatic)
   {
      Eina.Log.Debug("function efl_ui_mirrored_automatic_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetMirroredAutomatic( automatic);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_mirrored_automatic_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  automatic);
      }
   }
   private efl_ui_mirrored_automatic_set_delegate efl_ui_mirrored_automatic_set_static_delegate;


    private delegate  System.IntPtr efl_ui_language_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  System.IntPtr efl_ui_language_get(System.IntPtr obj);
    private static  System.IntPtr language_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_ui_language_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((Object)wrapper).GetLanguage();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return Efl.Eo.Globals.cached_string_to_intptr(((Object)wrapper).cached_strings, _ret_var);
      } else {
         return efl_ui_language_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_ui_language_get_delegate efl_ui_language_get_static_delegate;


    private delegate  void efl_ui_language_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String language);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_ui_language_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String language);
    private static  void language_set(System.IntPtr obj, System.IntPtr pd,   System.String language)
   {
      Eina.Log.Debug("function efl_ui_language_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Object)wrapper).SetLanguage( language);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_ui_language_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  language);
      }
   }
   private efl_ui_language_set_delegate efl_ui_language_set_static_delegate;
}
} } 
namespace Efl { namespace Canvas { 
/// <summary>Information of animation events</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ObjectAnimationEvent
{
///<summary>Placeholder field</summary>
public IntPtr field;
public static implicit operator ObjectAnimationEvent(IntPtr ptr)
   {
      var tmp = (ObjectAnimationEvent_StructInternal)Marshal.PtrToStructure(ptr, typeof(ObjectAnimationEvent_StructInternal));
      return ObjectAnimationEvent_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct ObjectAnimationEvent.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ObjectAnimationEvent_StructInternal
{
internal IntPtr field;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator ObjectAnimationEvent(ObjectAnimationEvent_StructInternal struct_)
   {
      return ObjectAnimationEvent_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator ObjectAnimationEvent_StructInternal(ObjectAnimationEvent struct_)
   {
      return ObjectAnimationEvent_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct ObjectAnimationEvent</summary>
public static class ObjectAnimationEvent_StructConversion
{
   internal static ObjectAnimationEvent_StructInternal ToInternal(ObjectAnimationEvent _external_struct)
   {
      var _internal_struct = new ObjectAnimationEvent_StructInternal();


      return _internal_struct;
   }

   internal static ObjectAnimationEvent ToManaged(ObjectAnimationEvent_StructInternal _internal_struct)
   {
      var _external_struct = new ObjectAnimationEvent();


      return _external_struct;
   }

}
} } 
